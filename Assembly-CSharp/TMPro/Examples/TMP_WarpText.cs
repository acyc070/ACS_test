using System;
using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x020002CB RID: 715
	public class TMP_WarpText : MonoBehaviour
	{
		// Token: 0x06001AE3 RID: 6883 RVA: 0x00015BDF File Offset: 0x00013DDF
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x00002482 File Offset: 0x00000682
		private void Start()
		{
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x00015BF2 File Offset: 0x00013DF2
		private void OnEnable()
		{
			base.StartCoroutine(this.WarpText());
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x00090740 File Offset: 0x0008E940
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
		{
			return new AnimationCurve
			{
				keys = curve.keys
			};
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x00090760 File Offset: 0x0008E960
		private IEnumerator WarpText()
		{
			this.VertexCurve.preWrapMode = WrapMode.Once;
			this.VertexCurve.postWrapMode = WrapMode.Once;
			this.m_TextComponent.havePropertiesChanged = true;
			float old_CurveScale = this.CurveScale;
			AnimationCurve old_curve = this.CopyAnimationCurve(this.VertexCurve);
			bool isComplete = false;
			while (!isComplete)
			{
				if (!this.m_TextComponent.havePropertiesChanged && old_CurveScale == this.CurveScale && old_curve.keys[1].value == this.VertexCurve.keys[1].value)
				{
					yield return null;
				}
				else
				{
					old_CurveScale = this.CurveScale;
					old_curve = this.CopyAnimationCurve(this.VertexCurve);
					this.m_TextComponent.ForceMeshUpdate();
					TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
					int characterCount = textInfo.characterCount;
					if (characterCount != 0)
					{
						float boundsMinX = this.m_TextComponent.bounds.min.x;
						float boundsMaxX = this.m_TextComponent.bounds.max.x;
						for (int i = 0; i < characterCount; i++)
						{
							if (textInfo.characterInfo[i].isVisible)
							{
								int vertexIndex = textInfo.characterInfo[i].vertexIndex;
								int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								Vector3 vector = new Vector2((vertices[vertexIndex].x + vertices[vertexIndex + 2].x) / 2f, textInfo.characterInfo[i].baseLine);
								vertices[vertexIndex] += -vector;
								vertices[vertexIndex + 1] += -vector;
								vertices[vertexIndex + 2] += -vector;
								vertices[vertexIndex + 3] += -vector;
								float num = (vector.x - boundsMinX) / (boundsMaxX - boundsMinX);
								float num2 = num + 0.0001f;
								float num3 = this.VertexCurve.Evaluate(num) * this.CurveScale;
								float num4 = this.VertexCurve.Evaluate(num2) * this.CurveScale;
								Vector3 vector2 = new Vector3(1f, 0f, 0f);
								Vector3 vector3 = new Vector3(num2 * (boundsMaxX - boundsMinX) + boundsMinX, num4) - new Vector3(vector.x, num3);
								float num5 = Mathf.Acos(Vector3.Dot(vector2, vector3.normalized)) * 57.29578f;
								float num6 = ((Vector3.Cross(vector2, vector3).z <= 0f) ? (360f - num5) : num5);
								Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0f, num3, 0f), Quaternion.Euler(0f, 0f, num6), Vector3.one);
								vertices[vertexIndex] = matrix.MultiplyPoint3x4(vertices[vertexIndex]);
								vertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
								vertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
								vertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
								vertices[vertexIndex] += vector;
								vertices[vertexIndex + 1] += vector;
								vertices[vertexIndex + 2] += vector;
								vertices[vertexIndex + 3] += vector;
							}
						}
						this.m_TextComponent.UpdateVertexData();
						isComplete = true;
						yield return new WaitForSeconds(0.025f);
					}
				}
			}
			yield break;
		}

		// Token: 0x04001776 RID: 6006
		private TMP_Text m_TextComponent;

		// Token: 0x04001777 RID: 6007
		public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.25f, 2f),
			new Keyframe(0.5f, 0f),
			new Keyframe(0.75f, 2f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x04001778 RID: 6008
		public float AngleMultiplier = 1f;

		// Token: 0x04001779 RID: 6009
		public float SpeedMultiplier = 1f;

		// Token: 0x0400177A RID: 6010
		public float CurveScale = 1f;
	}
}

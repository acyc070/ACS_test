using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x020005E3 RID: 1507
	[ExecuteInEditMode]
	public class InlineGraphicManager : MonoBehaviour
	{
		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06002974 RID: 10612 RVA: 0x0001DAF3 File Offset: 0x0001BCF3
		// (set) Token: 0x06002975 RID: 10613 RVA: 0x0001DAFB File Offset: 0x0001BCFB
		public TMP_SpriteAsset spriteAsset
		{
			get
			{
				return this.m_spriteAsset;
			}
			set
			{
				this.LoadSpriteAsset(value);
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06002976 RID: 10614 RVA: 0x0001DB04 File Offset: 0x0001BD04
		// (set) Token: 0x06002977 RID: 10615 RVA: 0x0001DB0C File Offset: 0x0001BD0C
		public InlineGraphic inlineGraphic
		{
			get
			{
				return this.m_inlineGraphic;
			}
			set
			{
				if (this.m_inlineGraphic != value)
				{
					this.m_inlineGraphic = value;
				}
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06002978 RID: 10616 RVA: 0x0001DB26 File Offset: 0x0001BD26
		public CanvasRenderer canvasRenderer
		{
			get
			{
				return this.m_inlineGraphicCanvasRenderer;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06002979 RID: 10617 RVA: 0x0001DB2E File Offset: 0x0001BD2E
		public UIVertex[] uiVertex
		{
			get
			{
				return this.m_uiVertex;
			}
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x000ED610 File Offset: 0x000EB810
		private void Awake()
		{
			if (!TMP_Settings.warningsDisabled)
			{
				Debug.LogWarning("InlineGraphicManager component is now Obsolete and has been removed from [" + base.gameObject.name + "] along with its InlineGraphic child.", this);
			}
			if (this.inlineGraphic.gameObject != null)
			{
				global::UnityEngine.Object.DestroyImmediate(this.inlineGraphic.gameObject);
				this.inlineGraphic = null;
			}
			global::UnityEngine.Object.DestroyImmediate(this);
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x0001DB36 File Offset: 0x0001BD36
		private void OnEnable()
		{
			base.enabled = false;
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x00002482 File Offset: 0x00000682
		private void OnDisable()
		{
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x00002482 File Offset: 0x00000682
		private void OnDestroy()
		{
		}

		// Token: 0x0600297E RID: 10622 RVA: 0x000ED67C File Offset: 0x000EB87C
		private void LoadSpriteAsset(TMP_SpriteAsset spriteAsset)
		{
			if (spriteAsset == null)
			{
				if (TMP_Settings.defaultSpriteAsset != null)
				{
					spriteAsset = TMP_Settings.defaultSpriteAsset;
				}
				else
				{
					spriteAsset = Resources.Load("Sprite Assets/Default Sprite Asset") as TMP_SpriteAsset;
				}
			}
			this.m_spriteAsset = spriteAsset;
			this.m_inlineGraphic.texture = this.m_spriteAsset.spriteSheet;
			if (this.m_textComponent != null && this.m_isInitialized)
			{
				this.m_textComponent.havePropertiesChanged = true;
				this.m_textComponent.SetVerticesDirty();
			}
		}

		// Token: 0x0600297F RID: 10623 RVA: 0x000ED714 File Offset: 0x000EB914
		public void AddInlineGraphicsChild()
		{
			if (this.m_inlineGraphic != null)
			{
				return;
			}
			GameObject gameObject = new GameObject("Inline Graphic");
			this.m_inlineGraphic = gameObject.AddComponent<InlineGraphic>();
			this.m_inlineGraphicRectTransform = gameObject.GetComponent<RectTransform>();
			this.m_inlineGraphicCanvasRenderer = gameObject.GetComponent<CanvasRenderer>();
			this.m_inlineGraphicRectTransform.SetParent(base.transform, false);
			this.m_inlineGraphicRectTransform.localPosition = Vector3.zero;
			this.m_inlineGraphicRectTransform.anchoredPosition3D = Vector3.zero;
			this.m_inlineGraphicRectTransform.sizeDelta = Vector2.zero;
			this.m_inlineGraphicRectTransform.anchorMin = Vector2.zero;
			this.m_inlineGraphicRectTransform.anchorMax = Vector2.one;
			this.m_textComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x06002980 RID: 10624 RVA: 0x000ED7D0 File Offset: 0x000EB9D0
		public void AllocatedVertexBuffers(int size)
		{
			if (this.m_inlineGraphic == null)
			{
				this.AddInlineGraphicsChild();
				this.LoadSpriteAsset(this.m_spriteAsset);
			}
			if (this.m_uiVertex == null)
			{
				this.m_uiVertex = new UIVertex[4];
			}
			int num = size * 4;
			if (num > this.m_uiVertex.Length)
			{
				this.m_uiVertex = new UIVertex[Mathf.NextPowerOfTwo(num)];
			}
		}

		// Token: 0x06002981 RID: 10625 RVA: 0x0001DB3F File Offset: 0x0001BD3F
		public void UpdatePivot(Vector2 pivot)
		{
			if (this.m_inlineGraphicRectTransform == null)
			{
				this.m_inlineGraphicRectTransform = this.m_inlineGraphic.GetComponent<RectTransform>();
			}
			this.m_inlineGraphicRectTransform.pivot = pivot;
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x0001DB6F File Offset: 0x0001BD6F
		public void ClearUIVertex()
		{
			if (this.uiVertex != null && this.uiVertex.Length > 0)
			{
				Array.Clear(this.uiVertex, 0, this.uiVertex.Length);
				this.m_inlineGraphicCanvasRenderer.Clear();
			}
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x0001DBA9 File Offset: 0x0001BDA9
		public void DrawSprite(UIVertex[] uiVertices, int spriteCount)
		{
			if (this.m_inlineGraphicCanvasRenderer == null)
			{
				this.m_inlineGraphicCanvasRenderer = this.m_inlineGraphic.GetComponent<CanvasRenderer>();
			}
			this.m_inlineGraphicCanvasRenderer.SetVertices(uiVertices, spriteCount * 4);
			this.m_inlineGraphic.UpdateMaterial();
		}

		// Token: 0x06002984 RID: 10628 RVA: 0x000ED83C File Offset: 0x000EBA3C
		public TMP_Sprite GetSprite(int index)
		{
			if (this.m_spriteAsset == null)
			{
				Debug.LogWarning("No Sprite Asset is assigned.", this);
				return null;
			}
			if (this.m_spriteAsset.spriteInfoList == null || index > this.m_spriteAsset.spriteInfoList.Count - 1)
			{
				Debug.LogWarning("Sprite index exceeds the number of sprites in this Sprite Asset.", this);
				return null;
			}
			return this.m_spriteAsset.spriteInfoList[index];
		}

		// Token: 0x06002985 RID: 10629 RVA: 0x000ED8B0 File Offset: 0x000EBAB0
		public int GetSpriteIndexByHashCode(int hashCode)
		{
			if (this.m_spriteAsset == null || this.m_spriteAsset.spriteInfoList == null)
			{
				Debug.LogWarning("No Sprite Asset is assigned.", this);
				return -1;
			}
			return this.m_spriteAsset.spriteInfoList.FindIndex((TMP_Sprite item) => item.hashCode == hashCode);
		}

		// Token: 0x06002986 RID: 10630 RVA: 0x000ED918 File Offset: 0x000EBB18
		public int GetSpriteIndexByIndex(int index)
		{
			if (this.m_spriteAsset == null || this.m_spriteAsset.spriteInfoList == null)
			{
				Debug.LogWarning("No Sprite Asset is assigned.", this);
				return -1;
			}
			return this.m_spriteAsset.spriteInfoList.FindIndex((TMP_Sprite item) => item.id == index);
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x0001DBE7 File Offset: 0x0001BDE7
		public void SetUIVertex(UIVertex[] uiVertex)
		{
			this.m_uiVertex = uiVertex;
		}

		// Token: 0x04002E8F RID: 11919
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset;

		// Token: 0x04002E90 RID: 11920
		[SerializeField]
		[HideInInspector]
		private InlineGraphic m_inlineGraphic;

		// Token: 0x04002E91 RID: 11921
		[SerializeField]
		[HideInInspector]
		private CanvasRenderer m_inlineGraphicCanvasRenderer;

		// Token: 0x04002E92 RID: 11922
		private UIVertex[] m_uiVertex;

		// Token: 0x04002E93 RID: 11923
		private RectTransform m_inlineGraphicRectTransform;

		// Token: 0x04002E94 RID: 11924
		private TMP_Text m_textComponent;

		// Token: 0x04002E95 RID: 11925
		private bool m_isInitialized;
	}
}

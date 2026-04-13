using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
[RequireComponent(typeof(CapsuleCollider))]
public class AI_DangerRoom_AI_Controller : MonoBehaviour
{
	// Token: 0x06001BB2 RID: 7090 RVA: 0x00093164 File Offset: 0x00091364
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			this.activationMode = DangerRoom_Zapper.ActivationMode.FROZEN;
		}
		if (this.currentAction - 1 <= this.animatorToUse.runtimeAnimatorController.animationClips.Length && this.activationMode == DangerRoom_Zapper.ActivationMode.MOVE)
		{
			if (this.MoveTowardThis != null)
			{
				Vector3 vector = new Vector3(this.MoveTowardThis.position.x, base.transform.position.y, this.MoveTowardThis.position.z) - base.transform.position;
				Quaternion quaternion = Quaternion.LookRotation(vector);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, quaternion, this.speeds[this.currentAction - 1] * Time.deltaTime);
				if (Vector3.Distance(base.transform.position, this.MoveTowardThis.position) > 5f)
				{
					base.transform.Translate(0f, 0f, this.speeds[this.currentAction - 1] * Time.deltaTime);
				}
			}
			else
			{
				base.transform.Translate(0f, 0f, this.speeds[this.currentAction - 1] * Time.deltaTime);
			}
		}
	}

	// Token: 0x06001BB3 RID: 7091 RVA: 0x000932C8 File Offset: 0x000914C8
	public void SetActivationMode(DangerRoom_Zapper.ActionInfo info)
	{
		if (info.animIndex - 1 <= this.animatorToUse.runtimeAnimatorController.animationClips.Length || this.animatorToUse.runtimeAnimatorController.animationClips.Length == 10)
		{
			this.activationMode = info.sendMode;
			this.currentAction = info.animIndex;
			this.animatorToUse.Play(info.animIndex.ToString(), -1, 0f);
			MonoBehaviour.print(string.Concat(new object[]
			{
				"SETTING ",
				base.gameObject.name,
				" ANIM: ",
				this.currentAction,
				" MODE: ",
				this.activationMode
			}));
		}
		else
		{
			this.activationMode = DangerRoom_Zapper.ActivationMode.STOP;
			this.currentAction = 1;
			this.animatorToUse.Play(info.animIndex.ToString());
			MonoBehaviour.print(string.Concat(new object[]
			{
				"NO ANIMATION FOR ",
				base.gameObject.name,
				" AT: ",
				info.animIndex
			}));
		}
	}

	// Token: 0x04001815 RID: 6165
	[Header("Target Setup")]
	public Transform MoveTowardThis;

	// Token: 0x04001816 RID: 6166
	public Animator animatorToUse;

	// Token: 0x04001817 RID: 6167
	private int currentAction = 1;

	// Token: 0x04001818 RID: 6168
	private bool changeAction;

	// Token: 0x04001819 RID: 6169
	private DangerRoom_Zapper.ActivationMode activationMode;

	// Token: 0x0400181A RID: 6170
	[HideInInspector]
	public float[] speeds = new float[10];

	// Token: 0x0400181B RID: 6171
	[HideInInspector]
	public string[] speedLabels = new string[10];
}

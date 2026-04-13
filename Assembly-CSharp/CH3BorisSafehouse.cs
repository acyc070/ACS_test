using System;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

// Token: 0x020000DF RID: 223
public class CH3BorisSafehouse : TMGMonoBehaviour
{
	// Token: 0x1400000D RID: 13
	// (add) Token: 0x060008D3 RID: 2259 RVA: 0x0004AB14 File Offset: 0x00048D14
	// (remove) Token: 0x060008D4 RID: 2260 RVA: 0x0004AB4C File Offset: 0x00048D4C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnToolboxPlaced;

	// Token: 0x060008D5 RID: 2261 RVA: 0x0000918D File Offset: 0x0000738D
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ToolboxParent = this.m_Toolbox.parent;
		this.m_Animator.Play("Chair_Idle");
		this.m_Target = GameManager.Instance.Player.transform;
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x0004AB84 File Offset: 0x00048D84
	private void LateUpdate()
	{
		if (this.m_Target == null)
		{
			return;
		}
		if (Vector3.Distance(this.m_Target.position, base.transform.position) > 10f)
		{
			return;
		}
		this.m_Head.LookAt(this.m_Target);
		Quaternion quaternion = (this.m_Head.rotation *= Quaternion.Euler(this.m_HeadOffset));
		this.m_Head.rotation = Quaternion.Lerp(this.m_Head.rotation, quaternion, 0.1f * Time.deltaTime);
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x0004AC28 File Offset: 0x00048E28
	public void GetToolbox()
	{
		this.m_Animator.Play("Chair_GetToolbox");
		AnimationClip animationClip = this.m_Animator.runtimeAnimatorController.animationClips[1];
		animationClip.AddEvent(this.AddEvent("GrabToolbox", 0.6666667f));
		animationClip.AddEvent(this.AddEvent("PlaceToolbox", 2.3666666f));
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x000399F4 File Offset: 0x00037BF4
	private AnimationEvent AddEvent(string functionName, float time)
	{
		return new AnimationEvent
		{
			functionName = functionName,
			time = time,
			objectReferenceParameter = this
		};
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000091CB File Offset: 0x000073CB
	public void GrabToolbox()
	{
		this.m_Toolbox.SetParent(this.m_Hand);
		this.m_Toolbox.localPosition = Vector3.zero;
		this.m_Toolbox.localEulerAngles = Vector3.zero;
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x0004AC84 File Offset: 0x00048E84
	public void PlaceToolbox()
	{
		this.m_Toolbox.SetParent(this.m_ToolboxParent);
		this.m_Toolbox.position = this.m_Table.position;
		this.m_Toolbox.eulerAngles = this.m_Table.eulerAngles;
		this.OnToolboxPlaced.Send(this);
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x0004ACDC File Offset: 0x00048EDC
	public void GetUp()
	{
		this.m_Animator.Play("Chair_GetUp");
		AnimationClip animationClip = this.m_Animator.runtimeAnimatorController.animationClips[2];
		animationClip.AddEvent(this.AddEvent("EnableBorisPathing", 2f));
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x000091FE File Offset: 0x000073FE
	private void EnableBorisPathing()
	{
		base.transform.position = this.m_GetUp.position;
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x00009216 File Offset: 0x00007416
	protected override void OnDisposed()
	{
		this.OnToolboxPlaced = null;
		base.OnDisposed();
	}

	// Token: 0x04000732 RID: 1842
	private const string CHAIR_GET_TOOLBOX = "Chair_GetToolbox";

	// Token: 0x04000733 RID: 1843
	private const string CHAIR_GET_UP = "Chair_GetUp";

	// Token: 0x04000734 RID: 1844
	private const string CHAIR_IDLE = "Chair_Idle";

	// Token: 0x04000735 RID: 1845
	[Header("Transforms")]
	[SerializeField]
	private Transform m_Head;

	// Token: 0x04000736 RID: 1846
	[SerializeField]
	private Vector3 m_HeadOffset;

	// Token: 0x04000737 RID: 1847
	[SerializeField]
	private Animator m_Animator;

	// Token: 0x04000738 RID: 1848
	[SerializeField]
	private Transform m_Toolbox;

	// Token: 0x04000739 RID: 1849
	[SerializeField]
	private Transform m_Hand;

	// Token: 0x0400073A RID: 1850
	[SerializeField]
	private Transform m_Table;

	// Token: 0x0400073B RID: 1851
	[SerializeField]
	private Transform m_GetUp;

	// Token: 0x0400073C RID: 1852
	private Transform m_ToolboxParent;

	// Token: 0x0400073D RID: 1853
	private Transform m_Target;

	// Token: 0x0400073E RID: 1854
	private bool m_IsLooking;
}

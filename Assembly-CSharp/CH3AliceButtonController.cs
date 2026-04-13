using System;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class CH3AliceButtonController : TMGMonoBehaviour
{
	// Token: 0x14000006 RID: 6
	// (add) Token: 0x06000610 RID: 1552 RVA: 0x000398E4 File Offset: 0x00037AE4
	// (remove) Token: 0x06000611 RID: 1553 RVA: 0x0003991C File Offset: 0x00037B1C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnPressed;

	// Token: 0x06000612 RID: 1554 RVA: 0x00039954 File Offset: 0x00037B54
	public void Activate()
	{
		this.m_AnimationController.SetTrigger("Activate");
		AnimationClip animationClip = null;
		for (int i = 0; i < this.m_AnimationController.runtimeAnimatorController.animationClips.Length; i++)
		{
			if (this.m_AnimationController.runtimeAnimatorController.animationClips[i].name.Contains("monologue"))
			{
				animationClip = this.m_AnimationController.runtimeAnimatorController.animationClips[i];
			}
		}
		if (animationClip != null)
		{
			animationClip.AddEvent(this.AddEvent("PressButton", 97.13333f));
		}
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x000076F9 File Offset: 0x000058F9
	public void PressButton()
	{
		this.OnPressed.Send(this);
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x000399F4 File Offset: 0x00037BF4
	private AnimationEvent AddEvent(string functionName, float time)
	{
		return new AnimationEvent
		{
			functionName = functionName,
			time = time,
			objectReferenceParameter = this
		};
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040004AE RID: 1198
	[SerializeField]
	private Animator m_AnimationController;
}

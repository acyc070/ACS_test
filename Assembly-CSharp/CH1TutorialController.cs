using System;
using TMG.Controls;
using UnityEngine;

// Token: 0x02000078 RID: 120
public class CH1TutorialController : BaseController
{
	// Token: 0x06000451 RID: 1105 RVA: 0x00006105 File Offset: 0x00004305
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_JumpTutorialTrigger.SetActive(false);
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineRevealObjective.IsComplete)
		{
			this.Activate();
		}
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x0002FB64 File Offset: 0x0002DD64
	public override void Activate()
	{
		this.m_JumpTutorialTrigger.OnEnter += this.HandleJumpTutorialTriggerOnEnter;
		this.m_JumpTutorialTrigger.OnExit += this.HandleJumpTutorialTriggerOnExit;
		this.m_JumpTutorialTrigger.SetActive(true);
		this.m_InteractTutorialTrigger.OnEnter += this.HandleInteractTutorialTriggerOnEnter;
		this.m_InteractTutorialTrigger.OnExit += this.HandleInteractTutorialTriggerOnExit;
		this.m_InteractTutorialTrigger.SetActive(true);
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x0002FBE8 File Offset: 0x0002DDE8
	private void Update()
	{
		if (this.m_IsShowingJump && PlayerInput.Jump())
		{
			this.m_JumpTutorialTrigger.OnExit -= this.HandleJumpTutorialTriggerOnExit;
			this.m_JumpTutorialTrigger.OnEnter -= this.HandleJumpTutorialTriggerOnEnter;
			this.m_JumpTutorialTrigger.Dispose();
			GameManager.Instance.HideTutorial();
		}
		if (this.m_IsShowingInteract && PlayerInput.InteractOnPressed())
		{
			this.m_InteractTutorialTrigger.OnExit -= this.HandleInteractTutorialTriggerOnExit;
			this.m_InteractTutorialTrigger.OnEnter -= this.HandleInteractTutorialTriggerOnEnter;
			this.m_InteractTutorialTrigger.Dispose();
			GameManager.Instance.HideTutorial();
		}
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x00006142 File Offset: 0x00004342
	private void HandleJumpTutorialTriggerOnExit(object sender, EventArgs e)
	{
		this.m_IsShowingJump = false;
		GameManager.Instance.HideTutorial();
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x00006155 File Offset: 0x00004355
	private void HandleJumpTutorialTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_IsShowingJump = true;
		GameManager.Instance.ShowTutorial(new TutorialDataVO("Tutorial/TUTORIAL_JUMP"));
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x00006172 File Offset: 0x00004372
	private void HandleInteractTutorialTriggerOnExit(object sender, EventArgs e)
	{
		this.m_IsShowingInteract = false;
		GameManager.Instance.HideTutorial();
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x00006185 File Offset: 0x00004385
	private void HandleInteractTutorialTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_IsShowingInteract = true;
		GameManager.Instance.ShowTutorial(new TutorialDataVO("Tutorial/TUTORIAL_INTERACT"));
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0002FCA8 File Offset: 0x0002DEA8
	protected override void OnDisposed()
	{
		if (this.m_JumpTutorialTrigger)
		{
			this.m_JumpTutorialTrigger.OnExit -= this.HandleJumpTutorialTriggerOnExit;
			this.m_JumpTutorialTrigger.OnEnter -= this.HandleJumpTutorialTriggerOnEnter;
		}
		if (this.m_InteractTutorialTrigger)
		{
			this.m_InteractTutorialTrigger.OnExit -= this.HandleInteractTutorialTriggerOnExit;
			this.m_InteractTutorialTrigger.OnEnter -= this.HandleInteractTutorialTriggerOnEnter;
		}
		base.OnDisposed();
	}

	// Token: 0x040002CB RID: 715
	[SerializeField]
	private EventTrigger m_JumpTutorialTrigger;

	// Token: 0x040002CC RID: 716
	[SerializeField]
	private EventTrigger m_InteractTutorialTrigger;

	// Token: 0x040002CD RID: 717
	private bool m_IsShowingJump;

	// Token: 0x040002CE RID: 718
	private bool m_IsShowingInteract;
}

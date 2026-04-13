using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000073 RID: 115
public class CH1JumpScareController : BaseController
{
	// Token: 0x06000409 RID: 1033 RVA: 0x00005C7D File Offset: 0x00003E7D
	public override void Init()
	{
		base.Init();
		this.m_BendyDoor.Lock();
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0002E588 File Offset: 0x0002C788
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsStarted)
		{
			this.m_Plank.gameObject.SetActive(false);
			return;
		}
		this.m_PlankFallClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_WoodPlankFall");
		this.m_JumpscareClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Jumpscare_01");
		this.m_HenryClip10 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_10");
		this.m_PlankEventTrigger.SetActive(false);
		this.m_PlankExitTrigger.SetActive(false);
		this.m_Cutout.SetActive(false);
		this.m_JumpScareTrigger.SetActive(false);
		this.m_DestroyTrigger.SetActive(false);
		this.m_DialogueTrigger.SetActive(false);
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00005C90 File Offset: 0x00003E90
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete)
		{
			this.ActivateBendyDoor();
			return;
		}
		this.ActivatePlankScare();
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00005CC2 File Offset: 0x00003EC2
	private void ActivatePlankScare()
	{
		this.m_PlankEventTrigger.SetActive(true);
		this.m_PlankEventTrigger.OnEnter += this.HandleEventTriggerOnEnter;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00005CE7 File Offset: 0x00003EE7
	private void HandleEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_PlankEventTrigger.OnEnter -= this.HandleEventTriggerOnEnter;
		this.DOPlankScare().OnComplete(new TweenCallback(this.PlankScareOnComplete));
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0002E658 File Offset: 0x0002C858
	private Sequence DOPlankScare()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		sequence.Insert(num, this.m_Plank.DOMove(this.m_EndPosition.position, 1f, false).SetEase(Ease.OutBounce, 0.025f));
		num += 0.4f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_PlankFallClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		return sequence;
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00005D18 File Offset: 0x00003F18
	private void PlankScareOnComplete()
	{
		this.m_PlankExitTrigger.SetActive(true);
		this.m_PlankExitTrigger.OnEnter += this.HandlePlankExitTriggerOnEnter;
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x00005D3D File Offset: 0x00003F3D
	private void HandlePlankExitTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_PlankExitTrigger.OnEnter -= this.HandlePlankExitTriggerOnEnter;
		this.ActivateCutoutScare();
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x0002E6C0 File Offset: 0x0002C8C0
	private void ActivateCutoutScare()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete)
		{
			return;
		}
		this.m_Plank.gameObject.SetActive(false);
		this.m_Cutout.SetActive(true);
		this.m_JumpScareTrigger.SetActive(true);
		this.m_JumpScareTrigger.OnEnter += this.HandleJumpScareTriggerOnEnter;
		this.m_DialogueTrigger.SetActive(true);
		this.m_DialogueTrigger.OnEnter += this.HandleDialogueTriggerOnEnter;
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x0002E754 File Offset: 0x0002C954
	private void HandleJumpScareTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_JumpScareTrigger.OnEnter -= this.HandleJumpScareTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_JumpscareClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_DestroyTrigger.SetActive(true);
		this.m_DestroyTrigger.OnEnter += this.HandleDestroyTriggerOnEnter;
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00005D5C File Offset: 0x00003F5C
	private void HandleDialogueTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_DialogueTrigger.OnEnter -= this.HandleDialogueTriggerOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip10, "DIACH1/DIA_CH1_HENRY_10", false));
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x00005D91 File Offset: 0x00003F91
	private void HandleDestroyTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_DestroyTrigger.OnEnter -= this.HandleDestroyTriggerOnEnter;
		this.m_Cutout.SetActive(false);
		this.ActivateBendyDoor();
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x00005DBC File Offset: 0x00003FBC
	private void ActivateBendyDoor()
	{
		this.m_BendyDoor.Unlock();
		this.m_BendyDoor.DoorSpeed = 0.35f;
		this.m_BendyDoor.OnInteract += this.HandleBendyDoorOnInteract;
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00005DF0 File Offset: 0x00003FF0
	private void HandleBendyDoorOnInteract(object sender, EventArgs e)
	{
		this.m_BendyDoor.OnInteract -= this.HandleBendyDoorOnInteract;
		this.DOBendyDoor().OnComplete(new TweenCallback(base.SendOnComplete));
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0002E7B4 File Offset: 0x0002C9B4
	private Sequence DOBendyDoor()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		float num2 = 0.15f;
		sequence.Insert(num, this.m_BendyDoorCutout.DOLocalMove(this.m_BendyDoorCutoutEndPosition.localPosition, num2, false).SetEase(Ease.Linear));
		sequence.Insert(num, this.m_BendyDoorCutout.DOLocalRotate(this.m_BendyDoorCutoutEndPosition.localEulerAngles, num2, RotateMode.Fast).SetEase(Ease.Linear));
		num += num2 / 2f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_JumpscareClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		sequence.InsertCallback(num + 0.25f, delegate
		{
		});
		return sequence;
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0002E86C File Offset: 0x0002CA6C
	protected override void OnDisposed()
	{
		this.m_PlankFallClip = null;
		this.m_BendyDoor.OnInteract -= this.HandleBendyDoorOnInteract;
		if (this.m_PlankExitTrigger != null)
		{
			this.m_PlankExitTrigger.OnEnter -= this.HandlePlankExitTriggerOnEnter;
		}
		if (this.m_PlankEventTrigger != null)
		{
			this.m_PlankEventTrigger.OnEnter -= this.HandleEventTriggerOnEnter;
		}
		if (this.m_JumpScareTrigger != null)
		{
			this.m_JumpScareTrigger.OnEnter += this.HandleJumpScareTriggerOnEnter;
		}
		if (this.m_DialogueTrigger != null)
		{
			this.m_DialogueTrigger.OnEnter += this.HandleDialogueTriggerOnEnter;
		}
		if (this.m_DestroyTrigger != null)
		{
			this.m_DestroyTrigger.OnEnter -= this.HandleDestroyTriggerOnEnter;
		}
		this.m_PlankFallClip = null;
		this.m_JumpscareClip = null;
		this.m_HenryClip10 = null;
		base.OnDisposed();
	}

	// Token: 0x0400028C RID: 652
	[Header("Scare: Falling Plank")]
	[SerializeField]
	private Transform m_Plank;

	// Token: 0x0400028D RID: 653
	[SerializeField]
	private Transform m_EndPosition;

	// Token: 0x0400028E RID: 654
	[SerializeField]
	private EventTrigger m_PlankEventTrigger;

	// Token: 0x0400028F RID: 655
	[SerializeField]
	private EventTrigger m_PlankExitTrigger;

	// Token: 0x04000290 RID: 656
	[Header("Scare: Bendy Cutout")]
	[SerializeField]
	private GameObject m_Cutout;

	// Token: 0x04000291 RID: 657
	[SerializeField]
	private EventTrigger m_JumpScareTrigger;

	// Token: 0x04000292 RID: 658
	[SerializeField]
	private EventTrigger m_DestroyTrigger;

	// Token: 0x04000293 RID: 659
	[SerializeField]
	private EventTrigger m_DialogueTrigger;

	// Token: 0x04000294 RID: 660
	[Header("Scare: Behind The Door")]
	[SerializeField]
	private Transform m_BendyDoorCutout;

	// Token: 0x04000295 RID: 661
	[SerializeField]
	private Transform m_BendyDoorCutoutEndPosition;

	// Token: 0x04000296 RID: 662
	[SerializeField]
	private CustomDoorController m_BendyDoor;

	// Token: 0x04000297 RID: 663
	private AudioClip m_PlankFallClip;

	// Token: 0x04000298 RID: 664
	private AudioClip m_JumpscareClip;

	// Token: 0x04000299 RID: 665
	private AudioClip m_HenryClip10;
}

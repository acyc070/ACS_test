using System;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class CH3BorisJumpscareController : BaseController
{
	// Token: 0x0600068A RID: 1674 RVA: 0x0003C558 File Offset: 0x0003A758
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_JumpscareClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Jumpscare_01");
		this.m_Henry24Clip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_24_thiswilldo");
		this.m_HenryBorisScareClip = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Henry/BorisScare/");
		this.m_Door.Lock();
		this.m_Boris = GameManager.Instance.CharacterManager.Boris;
		this.m_Cutout.position = this.m_StartCutoutPosition.position;
		this.m_Cutout.gameObject.SetActive(false);
		this.m_JumpscareTrigger.SetActive(false);
		this.m_AudioTrigger.SetActive(false);
		this.m_EnableGameObjects.SetActive(false);
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x0003C618 File Offset: 0x0003A818
	public override void Activate()
	{
		this.m_InstancedPipe = global::UnityEngine.Object.Instantiate<MeleeWeapon>(this.m_Pipe);
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.BorisJumpscareObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x0003C66C File Offset: 0x0003A86C
	private void InternalActivate()
	{
		this.m_InstancedPipe.gameObject.SetActive(true);
		this.m_InstancedPipe.transform.SetParent(this.m_Boris.PipeHand);
		this.m_InstancedPipe.transform.localPosition = Vector3.zero;
		this.m_InstancedPipe.transform.localEulerAngles = Vector3.zero;
		this.m_InstancedPipe.Interaction.SetActive(false);
		this.m_JumpscareTrigger.OnEnter += this.HandleJumpscareTriggerOnEnter;
		this.m_JumpscareTrigger.SetActive(true);
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x0003C704 File Offset: 0x0003A904
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH3_save_point_06", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 0f, false, 0f));
		this.m_Door.ForceOpen(145f);
		this.m_Door.Lock();
		this.m_PreviousDoor.ForceOpen(145f);
		this.m_PreviousDoor.Lock();
		GameManager.Instance.Player.WeaponGameObject = this.m_InstancedPipe.gameObject;
		this.m_InstancedPipe.gameObject.SetActive(true);
		this.m_InstancedPipe.transform.SetParent(GameManager.Instance.Player.WeaponParent);
		this.m_InstancedPipe.transform.localPosition = Vector3.zero;
		this.m_InstancedPipe.transform.localEulerAngles = Vector3.zero;
		this.m_InstancedPipe.Equip();
		this.m_InstancedPipe.Interaction.SetActive(false);
		this.m_InstancedPipe.Interaction.Dispose();
		this.m_EnableGameObjects.SetActive(true);
		this.m_Cutout.gameObject.SetActive(true);
		this.m_Cutout.position = this.m_EndCutoutPosition.position;
		this.m_Cutout.eulerAngles = this.m_EndCutoutPosition.eulerAngles;
		base.SendOnComplete();
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x0003C874 File Offset: 0x0003AA74
	private void HandleJumpscareTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_JumpscareTrigger.OnEnter -= this.HandleJumpscareTriggerOnEnter;
		this.m_EnableGameObjects.SetActive(true);
		this.m_Cutout.gameObject.SetActive(true);
		GameManager.Instance.AudioManager.Play(this.m_JumpscareClip, AudioObjectType.SOUND_EFFECT, 0, false);
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		float num2 = 0.225f;
		sequence.Insert(num, this.m_Cutout.DOMove(this.m_ScareCutoutPosition.position, num2, false).SetEase(Ease.OutBack));
		sequence.Insert(num, this.m_Cutout.DORotate(this.m_ScareCutoutPosition.eulerAngles, num2, RotateMode.Fast).SetEase(Ease.OutBack));
		num += 0.825f;
		sequence.Insert(num, this.m_Cutout.DOMove(this.m_StartCutoutPosition.position, num2, false).SetEase(Ease.InBack));
		sequence.Insert(num, this.m_Cutout.DORotate(this.m_StartCutoutPosition.eulerAngles, num2, RotateMode.Fast).SetEase(Ease.InBack));
		sequence.OnComplete(new TweenCallback(this.ScareOnComplete));
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x0003C998 File Offset: 0x0003AB98
	private void ScareOnComplete()
	{
		this.m_Cutout.position = this.m_EndCutoutPosition.position;
		this.m_Cutout.eulerAngles = this.m_EndCutoutPosition.eulerAngles;
		this.m_AudioTrigger.SetActive(true);
		this.m_AudioTrigger.OnEnter += this.HandleAudioTriggerOnEnter;
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x0003C9F4 File Offset: 0x0003ABF4
	private void HandleAudioTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_AudioTrigger.OnEnter -= this.HandleAudioTriggerOnEnter;
		for (int i = 0; i < this.m_HenryBorisScareClip.Length; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryBorisScareClip[i], SubtitleConstants.DIA_CH3_HENRY_BORIS_SCARE[i], false));
			if (i == 1)
			{
				audioObject.OnComplete += this.HandleBorisScareOnComplete;
			}
		}
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x0003CA6C File Offset: 0x0003AC6C
	private void HandleBorisScareOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleBorisScareOnComplete;
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_BORIS_PIPE", "OBJECTIVES/CH3_OBJECTIVE_BORIS_PIPE_TIP", 4f, false, 0f));
		this.m_InstancedPipe.Interaction.SetActive(true);
		this.m_InstancedPipe.OnEquipped += this.HandlePipeOnEquipped;
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x0003CAE4 File Offset: 0x0003ACE4
	private void HandlePipeOnEquipped(object sender, EventArgs e)
	{
		this.m_InstancedPipe.OnEquipped -= this.HandlePipeOnEquipped;
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 0f, false, 0f));
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_Henry24Clip, "DIACH3/DIA_CH3_HENRY_20", false));
		this.m_Door.OnOpen += this.HandleDoorOnOpened;
		this.m_Door.Unlock();
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x0003CB70 File Offset: 0x0003AD70
	private void HandleDoorOnOpened(object sender, EventArgs e)
	{
		this.m_Door.OnOpen -= this.HandleDoorOnOpened;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.BorisJumpscareObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00007CA3 File Offset: 0x00005EA3
	protected override void OnDisposed()
	{
		this.m_JumpscareClip = null;
		this.m_Henry24Clip = null;
		this.m_HenryBorisScareClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400051F RID: 1311
	[Header("Boris")]
	[SerializeField]
	private BorisAi m_Boris;

	// Token: 0x04000520 RID: 1312
	[SerializeField]
	private MeleeWeapon m_Pipe;

	// Token: 0x04000521 RID: 1313
	[Header("GameObjects")]
	[SerializeField]
	private GameObject m_EnableGameObjects;

	// Token: 0x04000522 RID: 1314
	[Header("Transforms")]
	[SerializeField]
	private Transform m_Cutout;

	// Token: 0x04000523 RID: 1315
	[SerializeField]
	private Transform m_StartCutoutPosition;

	// Token: 0x04000524 RID: 1316
	[SerializeField]
	private Transform m_ScareCutoutPosition;

	// Token: 0x04000525 RID: 1317
	[SerializeField]
	private Transform m_EndCutoutPosition;

	// Token: 0x04000526 RID: 1318
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_JumpscareTrigger;

	// Token: 0x04000527 RID: 1319
	[SerializeField]
	private EventTrigger m_AudioTrigger;

	// Token: 0x04000528 RID: 1320
	[Header("Doors")]
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x04000529 RID: 1321
	[SerializeField]
	private BaseDoorController m_PreviousDoor;

	// Token: 0x0400052A RID: 1322
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x0400052B RID: 1323
	private MeleeWeapon m_InstancedPipe;

	// Token: 0x0400052C RID: 1324
	private AudioClip m_JumpscareClip;

	// Token: 0x0400052D RID: 1325
	private AudioClip m_Henry24Clip;

	// Token: 0x0400052E RID: 1326
	private AudioClip[] m_HenryBorisScareClip;
}

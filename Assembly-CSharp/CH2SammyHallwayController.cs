using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class CH2SammyHallwayController : BaseController
{
	// Token: 0x06000599 RID: 1433 RVA: 0x00037284 File Offset: 0x00035484
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_HorrorCueAudioClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_Horror_Cue_02");
		this.m_HenryClip03 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_03");
		this.m_HenryClip04 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_04");
		this.m_HenryClip05 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_05");
		this.m_SammyDialogueClip_01 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Sammy/DIA_Sammy_01");
		this.m_Sammy.gameObject.SetActive(false);
		this.m_SammyEvent.SetActive(false);
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x00037320 File Offset: 0x00035520
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.GateObjective.IsStarted)
		{
			this.ForceComplete();
			return;
		}
		this.m_SammyEvent.OnEnter += this.HandleSammyEventOnEnter;
		this.m_SammyEvent.SetActive(true);
		this.m_LobbyEventTrigger.OnEnter += this.HandleLobbyEventTriggerOnEnter;
		this.m_LobbyEventTrigger.SetActive(true);
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x000070E8 File Offset: 0x000052E8
	private void HandleLobbyEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_LobbyEventTrigger.OnEnter -= this.HandleLobbyEventTriggerOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip03, "DIACH2/DIA_CH2_HENRY_03", true));
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x000373A0 File Offset: 0x000355A0
	private void HandleSammyEventOnEnter(object sender, EventArgs e)
	{
		this.m_SammyEvent.OnEnter -= this.HandleSammyEventOnEnter;
		this.m_Sammy.gameObject.SetActive(true);
		this.m_Sammy.localPosition = this.m_SammyStartPos.localPosition;
		GameManager.Instance.AudioManager.Play(this.m_HorrorCueAudioClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_DialogueAudio = GameManager.Instance.AudioManager.PlayAtPosition(this.m_SammyDialogueClip_01, this.m_AudioPosition.position, AudioObjectType.DIALOGUE, 0, false, this.m_Sammy);
		this.DOSammyEvent().OnComplete(new TweenCallback(this.HandleSammyEventOnComplete));
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x0003744C File Offset: 0x0003564C
	private Sequence DOSammyEvent()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		sequence.Insert(num, this.m_Sammy.DOLocalMove(this.m_SammyEndPos.localPosition, this.m_WalkDuration, false).SetEase(Ease.Linear).OnComplete(new TweenCallback(this.HandleSammyMoveOnComplete)));
		num += 1f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip04, "DIACH2/DIA_CH2_HENRY_04", true));
		});
		return sequence;
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x0000711D File Offset: 0x0000531D
	private void HandleSammyEventOnComplete()
	{
		this.m_SammyEndEvent.SetActive(true);
		this.m_SammyEndEvent.OnEnter += this.HandleSammyEndEventOnEnter;
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x00007142 File Offset: 0x00005342
	private void HandleSammyEndEventOnEnter(object sender, EventArgs e)
	{
		this.m_SammyEndEvent.OnEnter -= this.HandleSammyEndEventOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip05, "DIACH2/DIA_CH2_HENRY_05", true));
		base.SendOnComplete();
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x000374C0 File Offset: 0x000356C0
	private void HandleSammyMoveOnComplete()
	{
		if (!this.m_DialogueAudio)
		{
			return;
		}
		this.m_DialogueAudio.transform.SetParent(null);
		this.m_DialogueAudio.transform.DOLocalMoveX(this.m_DialogueAudio.transform.localPosition.x + 25f, 5f, false);
		this.m_DialogueAudio.OnComplete += delegate(object sender, EventArgs e)
		{
			if (this.m_DialogueAudio)
			{
				this.m_DialogueAudio.transform.DOKill(false);
				this.m_DialogueAudio.Clear();
				this.m_DialogueAudio = null;
			}
		};
		global::UnityEngine.Object.Destroy(this.m_Sammy.gameObject);
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0003754C File Offset: 0x0003574C
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_GATE", "OBJECTIVES/CH2_OBJECTIVE_GATE_TIP", 0f, false, 0f));
		global::UnityEngine.Object.Destroy(this.m_Sammy.gameObject);
		base.SendOnComplete();
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00037598 File Offset: 0x00035798
	protected override void OnDisposed()
	{
		if (this.m_SammyEvent)
		{
			this.m_SammyEvent.OnEnter -= this.HandleSammyEventOnEnter;
		}
		if (this.m_SammyEndEvent)
		{
			this.m_SammyEndEvent.OnEnter -= this.HandleSammyEndEventOnEnter;
		}
		if (this.m_LobbyEventTrigger)
		{
			this.m_LobbyEventTrigger.OnEnter -= this.HandleLobbyEventTriggerOnEnter;
		}
		this.m_HorrorCueAudioClip = null;
		this.m_HenryClip03 = null;
		this.m_HenryClip04 = null;
		this.m_HenryClip05 = null;
		this.m_SammyDialogueClip_01 = null;
		this.m_DialogueAudio = null;
		base.OnDisposed();
	}

	// Token: 0x04000430 RID: 1072
	[Header("< Audio Event >")]
	[SerializeField]
	private EventTrigger m_LobbyEventTrigger;

	// Token: 0x04000431 RID: 1073
	[Header("Jumpscare: Sammy!")]
	[SerializeField]
	private Transform m_Sammy;

	// Token: 0x04000432 RID: 1074
	[SerializeField]
	private Transform m_SammyStartPos;

	// Token: 0x04000433 RID: 1075
	[SerializeField]
	private Transform m_SammyEndPos;

	// Token: 0x04000434 RID: 1076
	[SerializeField]
	private Transform m_AudioPosition;

	// Token: 0x04000435 RID: 1077
	[SerializeField]
	private EventTrigger m_SammyEvent;

	// Token: 0x04000436 RID: 1078
	[SerializeField]
	private EventTrigger m_SammyEndEvent;

	// Token: 0x04000437 RID: 1079
	[SerializeField]
	private float m_WalkDuration = 5.58f;

	// Token: 0x04000438 RID: 1080
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000439 RID: 1081
	private AudioObject m_DialogueAudio;

	// Token: 0x0400043A RID: 1082
	private AudioClip m_HorrorCueAudioClip;

	// Token: 0x0400043B RID: 1083
	private AudioClip m_HenryClip03;

	// Token: 0x0400043C RID: 1084
	private AudioClip m_HenryClip04;

	// Token: 0x0400043D RID: 1085
	private AudioClip m_HenryClip05;

	// Token: 0x0400043E RID: 1086
	private AudioClip m_SammyDialogueClip_01;
}

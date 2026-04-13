using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000075 RID: 117
public class CH1OpeningSequenceController : BaseController
{
	// Token: 0x06000428 RID: 1064 RVA: 0x00005EE9 File Offset: 0x000040E9
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_DoorClip = GameManager.Instance.GetAudioClip("Audio/SFX/Door/SFX_Door_Unlock_Open_Close_01");
		this.m_HenryClip01 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_01");
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0002ED80 File Offset: 0x0002CF80
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineRevealObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else
		{
			this.DOSequence().OnComplete(new TweenCallback(base.SendOnComplete));
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0002EDD4 File Offset: 0x0002CFD4
	private void ForceComplete()
	{
		GameManager.Instance.Player.transform.position = GameManager.Instance.GameData.CurrentSaveFile.CH1Data.PlayerPosition.GetVector();
		GameManager.Instance.Player.LookRotation(Quaternion.Euler(GameManager.Instance.GameData.CurrentSaveFile.CH1Data.PlayerRotation.GetVector()));
		GameManager.Instance.HideScreenBlocker(0.1f, 0.5f, null);
		this.UnlockPlayer();
		base.SendOnComplete();
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0002EE68 File Offset: 0x0002D068
	private Sequence DOSequence()
	{
		this.ResetSequence();
		float num = 1f;
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.HideScreenBlocker(0.1f, 0f, null);
			GameManager.Instance.AudioManager.Play(this.m_DoorClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowChapterTitle("MENU/CH1_LABEL", "MENU/CH1_TITLE", true);
		});
		num += 4f;
		this.m_Sequence.InsertCallback(num, new TweenCallback(this.UnlockPlayer));
		this.m_Sequence.InsertCallback(1f + this.m_HenryClip01.length, new TweenCallback(this.PlayInitialDialogue));
		return this.m_Sequence;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00005F1B File Offset: 0x0000411B
	private void UnlockPlayer()
	{
		GameManager.Instance.Player.SetLock(false, false);
		GameManager.Instance.UnlockPause();
		GameManager.Instance.Player.SetCameraSway(true);
		GameManager.Instance.ShowCrosshair();
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0002EF14 File Offset: 0x0002D114
	private void PlayInitialDialogue()
	{
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip01, "DIACH1/DIA_CH1_HENRY_01", false));
		audioObject.OnComplete += delegate(object _sender, EventArgs _e)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_01", "OBJECTIVES/CH1_OBJ_01_TIP", 4f, false, 0f));
		};
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x00005F52 File Offset: 0x00004152
	private void ResetSequence()
	{
		this.KillSequence();
		this.m_Sequence = DOTween.Sequence();
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x00005F65 File Offset: 0x00004165
	private void KillSequence()
	{
		if (this.m_Sequence != null)
		{
			this.m_Sequence.Kill(false);
			this.m_Sequence = null;
		}
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x00005F85 File Offset: 0x00004185
	protected override void OnDisposed()
	{
		this.KillSequence();
		this.m_HenryClip01 = null;
		base.OnDisposed();
	}

	// Token: 0x040002A8 RID: 680
	private Sequence m_Sequence;

	// Token: 0x040002A9 RID: 681
	private AudioClip m_DoorClip;

	// Token: 0x040002AA RID: 682
	private AudioClip m_HenryClip01;
}

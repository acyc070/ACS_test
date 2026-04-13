using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000085 RID: 133
public class CH2ClosingSequenceController : BaseController
{
	// Token: 0x060004C5 RID: 1221 RVA: 0x00032AB8 File Offset: 0x00030CB8
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_BorisFootstepClips = GameManager.Instance.GetAudioClips("Audio/SFX/Footsteps/Boris/Wood");
		this.m_HenryClip15 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_15");
		this.m_HenryClip16 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_16");
		this.m_CanKickClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Can_Roll_slow_01");
		this.m_HorrorCueClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_Horror_Cue_02");
		this.m_WhooshClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_HUD_whoosh_01");
		this.m_Boris = GameManager.Instance.CharacterManager.Boris;
		this.m_FinalTrigger.SetActive(false);
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0000670B File Offset: 0x0000490B
	public override void Activate()
	{
		this.m_FinalTrigger.OnEnter += this.HandleFinalTriggerOnEnter;
		this.m_FinalTrigger.SetActive(true);
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00032B6C File Offset: 0x00030D6C
	private void HandleFinalTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_FinalTrigger.OnEnter -= this.HandleFinalTriggerOnEnter;
		GameManager.Instance.HideCrosshair();
		GameManager.Instance.LockPause();
		GameManager.Instance.Player.SetCameraSway(true);
		GameManager.Instance.Player.SetLock(true, false);
		GameManager.Instance.Player.HeadContainer.DOLookAt(this.m_FinalLookAt.position, 2f, AxisConstraint.None, null).SetEase(Ease.InOutQuad);
		GameManager.Instance.AudioManager.Play(this.m_CanKickClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.DOSequence().OnComplete(new TweenCallback(this.SequenceOnComplete));
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00032C2C File Offset: 0x00030E2C
	private Sequence DOSequence()
	{
		this.ResetSequence();
		float num = 0f;
		this.m_Sequence.Insert(0f, this.m_Can.DOMove(this.m_CanEndPos.position, 3.5f, false).SetEase(Ease.Linear));
		this.m_Sequence.Insert(0f, this.m_Can.DOLocalRotate(new Vector3(0f, 2160f, 0f), 3.5f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
		num += 1.5f;
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_HorrorCueClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		return this.m_Sequence;
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x00006730 File Offset: 0x00004930
	private void SequenceOnComplete()
	{
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip15, "DIACH2/DIA_CH2_HENRY_15", false)).OnComplete += this.HandleDialogueOnComplete;
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00032CDC File Offset: 0x00030EDC
	private void HandleDialogueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleDialogueOnComplete;
		this.m_Boris.EnableWaypointPathing();
		this.m_Boris.OnWaypointComplete += this.HandleBorisOnWaypointComplete;
		this.m_Boris.UpdateWaypointList(this.m_WaypointList.Waypoints, false);
		this.DOBorisSequence();
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x00032D40 File Offset: 0x00030F40
	private void HandleBorisOnWaypointComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleBorisOnWaypointComplete;
		this.m_WaypointList.Dispose();
		this.m_Boris.StopWaypointPathing();
		this.m_Sequence.Kill(false);
		this.DOFinalSequence().OnComplete(new TweenCallback(base.SendOnComplete));
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x00032DA0 File Offset: 0x00030FA0
	private Sequence DOBorisSequence()
	{
		this.ResetSequence();
		for (int i = 0; i < 20; i++)
		{
			this.m_Sequence.InsertCallback(0.6666667f * (float)i, new TweenCallback(this.PlayFootStepAudio));
		}
		return this.m_Sequence;
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x00032DEC File Offset: 0x00030FEC
	private Sequence DOFinalSequence()
	{
		this.ResetSequence();
		float num = 1f;
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_WhooshClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0f, 0f, null);
		});
		num += 2f;
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip16, "DIACH2/DIA_CH2_HENRY_16", false));
		});
		num += this.m_HenryClip16.length + 0.5f;
		this.m_Sequence.InsertCallback(num, delegate
		{
		});
		return this.m_Sequence;
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x00032EB0 File Offset: 0x000310B0
	private void PlayFootStepAudio()
	{
		if (this.m_BorisFootstepClips == null || this.m_BorisFootstepClips.Length <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_BorisFootstepClips.Length);
		AudioClip audioClip = this.m_BorisFootstepClips[num];
		GameManager.Instance.AudioManager.Play(audioClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_BorisFootstepClips[num] = this.m_BorisFootstepClips[0];
		this.m_BorisFootstepClips[0] = audioClip;
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x0000675E File Offset: 0x0000495E
	private void ResetSequence()
	{
		this.KillSequence();
		this.m_Sequence = DOTween.Sequence();
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x00006771 File Offset: 0x00004971
	private void KillSequence()
	{
		if (this.m_Sequence != null)
		{
			this.m_Sequence.Kill(false);
			this.m_Sequence = null;
		}
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x00032F1C File Offset: 0x0003111C
	protected override void OnDisposed()
	{
		this.KillSequence();
		if (this.m_FinalTrigger)
		{
			this.m_FinalTrigger.OnEnter -= this.HandleFinalTriggerOnEnter;
		}
		this.m_BorisFootstepClips = null;
		this.m_CanKickClip = null;
		this.m_HorrorCueClip = null;
		this.m_HenryClip15 = null;
		this.m_HenryClip16 = null;
		this.m_WhooshClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400034D RID: 845
	[Header("< END >")]
	[SerializeField]
	private Transform m_FinalLookAt;

	// Token: 0x0400034E RID: 846
	[SerializeField]
	private Transform m_BorisEndPos;

	// Token: 0x0400034F RID: 847
	[SerializeField]
	private Transform m_FinalRot;

	// Token: 0x04000350 RID: 848
	[SerializeField]
	private Transform m_BorisNeck;

	// Token: 0x04000351 RID: 849
	[SerializeField]
	private Transform m_Can;

	// Token: 0x04000352 RID: 850
	[SerializeField]
	private Transform m_CanEndPos;

	// Token: 0x04000353 RID: 851
	[SerializeField]
	private EventTrigger m_FinalTrigger;

	// Token: 0x04000354 RID: 852
	[SerializeField]
	private BorisAi m_Boris;

	// Token: 0x04000355 RID: 853
	[SerializeField]
	private WaypointList m_WaypointList;

	// Token: 0x04000356 RID: 854
	private Sequence m_Sequence;

	// Token: 0x04000357 RID: 855
	private AudioClip[] m_BorisFootstepClips;

	// Token: 0x04000358 RID: 856
	private AudioClip m_CanKickClip;

	// Token: 0x04000359 RID: 857
	private AudioClip m_HorrorCueClip;

	// Token: 0x0400035A RID: 858
	private AudioClip m_HenryClip15;

	// Token: 0x0400035B RID: 859
	private AudioClip m_HenryClip16;

	// Token: 0x0400035C RID: 860
	private AudioClip m_WhooshClip;
}

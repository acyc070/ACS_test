using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Token: 0x02000091 RID: 145
public class CH2OpeningSequenceController : BaseController
{
	// Token: 0x0600052C RID: 1324 RVA: 0x00034EF8 File Offset: 0x000330F8
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_TitleMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_Chapter_Two_Title");
		this.m_RingingEarsClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Ringing_Ears_01");
		this.m_StandUpClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Stand_Up_Player_01");
		this.m_HenryClip01 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_01");
		this.m_HenryClip02 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_02");
		this.m_HenryClipGetUp = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_GET_UP");
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x00034F8C File Offset: 0x0003318C
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.RitualObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else
		{
			this.m_GameCam = GameManager.Instance.GameCamera;
			this.m_GameCamTransform = GameManager.Instance.GameCamera.InitializeFreeRoamCam();
			this.m_GameCamTransform.position = this.m_StartPosition.position;
			this.m_GameCamTransform.eulerAngles = this.m_StartPosition.eulerAngles;
			if (this.m_GameCam.DoF)
			{
				this.m_GameCam.UnityDOF.manualDOF = true;
				this.m_GameCam.UnityDOF.focalDistance = 0f;
			}
			this.DOOpeningSequence();
		}
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x00035058 File Offset: 0x00033258
	private void ForceComplete()
	{
		GameManager.Instance.Player.transform.position = GameManager.Instance.GameData.CurrentSaveFile.CH2Data.PlayerPosition.GetVector();
		GameManager.Instance.Player.LookRotation(Quaternion.Euler(GameManager.Instance.GameData.CurrentSaveFile.CH2Data.PlayerRotation.GetVector()));
		GameManager.Instance.HideScreenBlocker(0.1f, 0.5f, null);
		GameManager.Instance.ShowCrosshair();
		GameManager.Instance.Player.SetLock(false, false);
		GameManager.Instance.UnlockPause();
		GameManager.Instance.Player.SetInteraction(true);
		GameManager.Instance.Player.SetCameraSway(true);
		base.SendOnComplete();
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x0003512C File Offset: 0x0003332C
	private Sequence DOOpeningSequence()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 1f;
		float duration = 1f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_TitleMusicClip, AudioObjectType.MUSIC, 0, false);
			GameManager.Instance.ShowHurtBorder(true);
		});
		num += 5f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowChapterTitle("MENU/CH2_LABEL", "MENU/CH2_TITLE", false);
		});
		num += 2f;
		for (int i = 0; i < 4; i++)
		{
			sequence.InsertCallback(num, delegate
			{
				GameManager.Instance.ShowHurtBorder(true);
			});
		}
		sequence.InsertCallback(num, new TweenCallback(this.PlayIntroDialogue_01));
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.HideScreenBlocker(duration, 0f, null);
		});
		num += duration;
		duration = 0.5f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowScreenBlocker(duration, 0f, null);
		});
		num += duration + 0.75f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.HideScreenBlocker(duration, 0f, null);
		});
		num += duration + 0.25f;
		if (this.m_GameCam.DoF)
		{
			this.m_GameCam.UnityDOF.manualDOF = true;
			float distance = this.m_GameCam.UnityDOF.focalDistance;
			sequence.Insert(num, DOTween.To(() => distance, delegate(float value)
			{
				distance = value;
			}, 5f, 2f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				this.m_GameCam.UnityDOF.focalDistance = distance;
			}));
		}
		num += 1.5f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0.5f, 0f, null);
		});
		num += 0.6f;
		if (this.m_GameCam.DoF)
		{
			sequence.InsertCallback(num, delegate
			{
				this.m_GameCam.UnityDOF.manualDOF = false;
			});
		}
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.HideScreenBlocker(0.5f, 0f, null);
		});
		return sequence;
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x00035370 File Offset: 0x00033570
	private Sequence DOGetUpSequence()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 1f;
		sequence.InsertCallback(num, delegate
		{
			this.m_GameCam.Camera.transform.SetParent(GameManager.Instance.Player.CameraParent);
		});
		sequence.InsertCallback(num += 0.5f, new TweenCallback(this.PlayIntroDialogue_02));
		sequence.Insert(num, this.m_GameCamTransform.DOMove(this.m_KneelPosition.position, 1.5f, false).SetEase(Ease.InOutQuad));
		sequence.Insert(num, this.m_GameCamTransform.DORotate(this.m_KneelPosition.eulerAngles, 1.5f, RotateMode.Fast).SetEase(Ease.InOutQuad));
		num += 2.1f;
		sequence.Insert(num, this.m_GameCamTransform.DOMove(GameManager.Instance.Player.HeadContainer.position, 2f, false).SetEase(this.m_KneelCurve));
		sequence.Insert(num, this.m_GameCamTransform.DORotate(GameManager.Instance.Player.transform.eulerAngles, 2f, RotateMode.Fast).SetEase(this.m_KneelCurve));
		return sequence;
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00035488 File Offset: 0x00033688
	private void PlayIntroDialogue_01()
	{
		GameManager.Instance.AudioManager.Play(this.m_RingingEarsClip, AudioObjectType.SOUND_EFFECT, 0, false);
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip01, "DIACH2/DIA_CH2_HENRY_01", true));
		audioObject.OnComplete += delegate(object sender, EventArgs e)
		{
			this.DOGetUpSequence().OnComplete(new TweenCallback(this.GetUpSequenceOnComplete));
		};
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x000354DC File Offset: 0x000336DC
	private void GetUpSequenceOnComplete()
	{
		GameManager.Instance.GameCamera.ExitFreeRoamCam();
		this.PlayIntroDialogue_03();
		GameManager.Instance.Player.SetLock(false, false);
		GameManager.Instance.UnlockPause();
		GameManager.Instance.Player.SetInteraction(true);
		GameManager.Instance.Player.SetCameraSway(true);
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x00006B45 File Offset: 0x00004D45
	private void PlayIntroDialogue_02()
	{
		GameManager.Instance.AudioManager.Play(this.m_StandUpClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClipGetUp, string.Empty, true));
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x0003553C File Offset: 0x0003373C
	private void PlayIntroDialogue_03()
	{
		GameManager.Instance.ShowCrosshair();
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip02, "DIACH2/DIA_CH2_HENRY_02", true));
		audioObject.OnComplete += delegate(object sender, EventArgs e)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_NEW_EXIT", "OBJECTIVES/CH2_OBJECTIVE_NEW_EXIT_TIP", 4f, false, 0f));
		};
		base.SendOnComplete();
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x00006B7C File Offset: 0x00004D7C
	protected override void OnDisposed()
	{
		this.m_GameCam = null;
		this.m_GameCamTransform = null;
		this.m_TitleMusicClip = null;
		this.m_RingingEarsClip = null;
		this.m_StandUpClip = null;
		this.m_HenryClip01 = null;
		this.m_HenryClip02 = null;
		this.m_HenryClipGetUp = null;
		base.OnDisposed();
	}

	// Token: 0x040003BC RID: 956
	[Header("< START >")]
	[SerializeField]
	private Transform m_StartPosition;

	// Token: 0x040003BD RID: 957
	[SerializeField]
	private Transform m_KneelPosition;

	// Token: 0x040003BE RID: 958
	[SerializeField]
	private AnimationCurve m_KneelCurve;

	// Token: 0x040003BF RID: 959
	private GameCamera m_GameCam;

	// Token: 0x040003C0 RID: 960
	private Transform m_GameCamTransform;

	// Token: 0x040003C1 RID: 961
	private AudioClip m_TitleMusicClip;

	// Token: 0x040003C2 RID: 962
	private AudioClip m_RingingEarsClip;

	// Token: 0x040003C3 RID: 963
	private AudioClip m_StandUpClip;

	// Token: 0x040003C4 RID: 964
	private AudioClip m_HenryClip01;

	// Token: 0x040003C5 RID: 965
	private AudioClip m_HenryClip02;

	// Token: 0x040003C6 RID: 966
	private AudioClip m_HenryClipGetUp;
}

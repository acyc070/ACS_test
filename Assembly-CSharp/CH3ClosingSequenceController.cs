using System;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class CH3ClosingSequenceController : BaseController
{
	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00007707 File Offset: 0x00005907
	private BorisAi m_Boris
	{
		get
		{
			return GameManager.Instance.CharacterManager.Boris;
		}
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x0003DAA4 File Offset: 0x0003BCA4
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_CompleteTaskClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/DIA/CH3/Alice/TasksComplete/");
		this.m_MonologueAClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/MonologueFinaleA/");
		this.m_MonologueBClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/MonologueFinaleB/");
		this.m_MonologueCClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/MonologueFinaleC/");
		this.m_HorrorAmbienceClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Horror_Ambience_Loop_01");
		this.m_FinalClip_01 = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_finaleending");
		this.m_FinalClip_02 = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_finaleending2");
		this.m_FinalClip_03 = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_finaleending3");
		this.m_LiftDepartClip = GameManager.Instance.GetAudioClip("Audio/SFX/Lift/SFX_Lift_Depart");
		this.m_LiftLoopClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_Lift_End_Loop");
		this.m_LiftFallLoopClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_elevatorfallingloop");
		this.m_SafehouseDoorClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_safehousedoor");
		this.m_Sparks.SetActive(false);
		this.m_FinalTrigger.SetActive(false);
		this.m_AliceHum.SetActive(false);
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x0003DBDC File Offset: 0x0003BDDC
	public override void Activate()
	{
		this.m_ServiceController.Activate();
		this.m_LiftController.ActivateFinale();
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceTasksObjective.IsStarted)
		{
			this.m_LiftController.DisableLift();
			GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_COMPLETE_B", string.Empty, 0f, false, 0f));
			this.m_FinalTrigger.SetActive(true);
			this.m_FinalTrigger.OnEnter += this.HandleFinalTriggerOnEnter;
		}
		else
		{
			for (int i = 0; i < this.m_CompleteTaskClips.Length; i++)
			{
				AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_CompleteTaskClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_TASKS_COMPLETE[i], true));
				if (i >= this.m_CompleteTaskClips.Length - 1)
				{
					audioObject.OnComplete += this.HandleFinalTaskOnComplete;
				}
			}
		}
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x0003DCDC File Offset: 0x0003BEDC
	private void HandleFinalTaskOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleFinalTaskOnComplete;
		this.m_LiftController.DisableLift();
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceTasksObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_COMPLETE_B", string.Empty, 4f, false, 0f));
		this.m_FinalTrigger.SetActive(true);
		this.m_FinalTrigger.OnEnter += this.HandleFinalTriggerOnEnter;
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00007D7E File Offset: 0x00005F7E
	private void HandleFinalTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_FinalTrigger.OnEnter -= this.HandleFinalTriggerOnEnter;
		this.m_LiftController.OnAliceDoorClosed += this.HandleAliceDoorClosed;
		this.m_LiftController.FinaleCloseAliceFloor();
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00007DB9 File Offset: 0x00005FB9
	private void HandleAliceDoorClosed(object sender, EventArgs e)
	{
		this.m_LiftController.OnAliceDoorClosed -= this.HandleAliceDoorClosed;
		this.DOLiftAscend().OnComplete(new TweenCallback(this.AscendOnComplete));
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x0003DD88 File Offset: 0x0003BF88
	private Sequence DOLiftAscend()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		float num2 = 0f;
		GameManager.Instance.Player.transform.SetParent(this.m_Lift);
		for (int i = 0; i < this.m_MonologueAClips.Length; i++)
		{
			AudioClip audioClip = this.m_MonologueAClips[i];
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(audioClip, SubtitleConstants.DIALOGUE_CH3_ALICE_FINALE_MONOLOGUE_A[i], true));
			num2 += audioClip.length;
		}
		GameManager.Instance.AudioManager.Play(this.m_LiftDepartClip, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += delegate(object _sender, EventArgs _e)
		{
			this.m_LoopObject = GameManager.Instance.AudioManager.Play(this.m_LiftLoopClip, AudioObjectType.SOUND_EFFECT, -1, false);
		};
		sequence.Insert(num, this.m_Lift.DOMoveY(this.m_EndPosition.position.y, num2, false).SetEase(Ease.Linear));
		return sequence;
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x0003DE64 File Offset: 0x0003C064
	private void AscendOnComplete()
	{
		Vector3 position = this.m_Lift.position;
		position.y = this.m_EndPosition.position.y;
		position.z = this.m_EndPosition.position.z;
		this.m_Lift.position = position;
		GameManager.Instance.AiGlobalNetwork.ClearAllAi();
		if (this.m_LoopObject != null)
		{
			this.m_LoopObject.Clear();
			this.m_LoopObject = null;
		}
		GameManager.Instance.AudioManager.Play(this.m_SafehouseDoorClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.DOLiftDrop().OnComplete(new TweenCallback(this.LiftDropOnComplete));
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x0003DF20 File Offset: 0x0003C120
	private Sequence DOLiftDrop()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		sequence.InsertCallback(num, delegate
		{
			this.m_Sparks.SetActive(true);
			this.m_Boris.SetCower(true);
			this.m_LoopObject = GameManager.Instance.AudioManager.Play(this.m_LiftFallLoopClip, AudioObjectType.SOUND_EFFECT, -1, false);
			this.DoShake();
			this.Go(1f, Ease.InBack);
		});
		for (int i = 0; i < this.m_MonologueBClips.Length; i++)
		{
			AudioClip audioClip = this.m_MonologueBClips[i];
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(audioClip, SubtitleConstants.DIALOGUE_CH3_ALICE_FINALE_MONOLOGUE_B[i], true));
			num += audioClip.length;
		}
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_FinalClip_01, AudioObjectType.SOUND_EFFECT, 0, false);
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_MonologueCClips[0], SubtitleConstants.DIALOGUE_CH3_ALICE_FINALE_MONOLOGUE_C[0], true));
		});
		num += this.m_MonologueCClips[0].length;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0f, 0f, null);
		});
		return sequence;
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x0003DFDC File Offset: 0x0003C1DC
	private void LiftDropOnComplete()
	{
		if (this.m_LoopObject != null)
		{
			this.m_LoopObject.Clear();
			this.m_LoopObject = null;
		}
		this.m_IsLanded = true;
		this.KillDropSequence();
		this.KillShake();
		this.m_Boris.gameObject.SetActive(false);
		this.m_Alice.OnWaypointComplete += this.HandleAliceOnWaypointComplete;
		this.m_Lift.position = this.m_LiftPosition.position;
		this.m_Sparks.SetActive(false);
		GameManager.Instance.Player.SetCameraSway(true);
		GameManager.Instance.Player.SetLock(true, false);
		GameManager.Instance.LockPause();
		GameManager.Instance.HideCrosshair();
		this.DOAliceSeuence();
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x0003E0A8 File Offset: 0x0003C2A8
	private Sequence DOAliceSeuence()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_FinalClip_02, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		num += 4f;
		sequence.InsertCallback(num, delegate
		{
			this.m_Ambience = GameManager.Instance.AudioManager.Play(this.m_HorrorAmbienceClip, AudioObjectType.SOUND_EFFECT, -1, false);
		});
		num += 1f;
		sequence.InsertCallback(num, delegate
		{
			this.m_Alice.gameObject.SetActive(true);
			this.m_AliceHum.SetActive(true);
			GameManager.Instance.Player.HeadContainer.SetParent(this.m_EndCameraPosition);
			GameManager.Instance.Player.HeadContainer.localPosition = Vector3.zero;
			GameManager.Instance.Player.HeadContainer.localEulerAngles = Vector3.zero;
			GameManager.Instance.HideScreenBlocker(4f, 0f, null);
			for (int i = 0; i < this.m_Lights.Count; i++)
			{
				this.m_Lights[i].DOIntensity(0f, 5f).SetDelay(2f).SetEase(Ease.Linear);
			}
		});
		return sequence;
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x0003E110 File Offset: 0x0003C310
	private void HandleAliceOnWaypointComplete(object sender, EventArgs e)
	{
		this.m_Alice.OnWaypointComplete -= this.HandleAliceOnWaypointComplete;
		GameManager.Instance.ShowScreenBlocker(0f, 0f, null);
		this.m_Alice.gameObject.SetActive(false);
		GameManager.Instance.AudioManager.Play(this.m_FinalClip_02, AudioObjectType.SOUND_EFFECT, 0, false);
		for (int i = 0; i < this.m_LightFlicker.Count; i++)
		{
			this.m_LightFlicker[i].Light.DOKill(false);
			this.m_LightFlicker[i].Light.intensity = 1.5f;
			this.m_LightFlicker[i].enabled = true;
		}
		for (int j = 0; j < this.m_ToDisable.Count; j++)
		{
			this.m_ToDisable[j].SetActive(false);
		}
		RenderSettings.ambientIntensity = 0f;
		this.DOBorisPull().OnComplete(new TweenCallback(this.BorisPullOnComplete));
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0003E224 File Offset: 0x0003C424
	private Sequence DOBorisPull()
	{
		if (this.m_Ambience)
		{
			this.m_Ambience.Stop();
			this.m_Ambience = null;
		}
		Sequence sequence = DOTween.Sequence();
		float num = 2f;
		sequence.InsertCallback(num, delegate
		{
			this.m_BorisAnimationController.SetTrigger("Pull");
			this.m_BorisAnimationController.transform.DOMove(this.m_BorisEndPosition.position, 0.5f, false).SetEase(Ease.Linear);
			this.m_BorisAnimationController.transform.DOLocalRotate(Vector3.zero, 0.3f, RotateMode.Fast).SetEase(Ease.Linear);
			GameManager.Instance.HideScreenBlocker(0f, 0f, null);
			GameManager.Instance.AudioManager.Play(this.m_FinalClip_03, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		num += 0.45f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0f, 0f, null);
			GameManager.Instance.Player.transform.SetParent(null);
			GameManager.Instance.Player.gameObject.SetActive(false);
			GameManager.Instance.GameCamera.gameObject.SetActive(false);
			GameManager.Instance.AudioManager.ListenerSetActive(true);
		});
		num += 3.5f;
		sequence.InsertCallback(num, delegate
		{
		});
		return sequence;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0003E2D0 File Offset: 0x0003C4D0
	private void BorisPullOnComplete()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ChoseDevilsPath)
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.THE_PATH_OF_THE_DEMON);
		}
		else
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.THE_PATH_OF_THE_ANGEL);
		}
		base.SendOnComplete();
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x0003E328 File Offset: 0x0003C528
	private void DoShake()
	{
		if (this.m_IsLanded)
		{
			return;
		}
		GameManager.Instance.GameCamera.Camera.transform.DOShakePosition(0.1f, 0.25f, 1, 90f, false, true).OnComplete(new TweenCallback(this.DoShake));
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00007DEA File Offset: 0x00005FEA
	private void KillShake()
	{
		GameManager.Instance.GameCamera.Camera.transform.DOKill(false);
		GameManager.Instance.GameCamera.Camera.transform.localPosition = Vector3.zero;
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x0003E380 File Offset: 0x0003C580
	private void Go(float speed, Ease ease = Ease.Linear)
	{
		this.ResetDropSequence();
		for (int i = 0; i < this.m_Shafts.Count; i++)
		{
			DisposableObject disposableObject = this.m_Shafts[i];
			float num = disposableObject.transform.localPosition.y + 60f;
			this.m_DropSequence.Insert(0f, disposableObject.transform.DOLocalMoveY(num, speed, false).SetEase(ease));
		}
		this.m_DropSequence.InsertCallback(speed, delegate
		{
			DisposableObject disposableObject2 = this.m_Shafts[this.m_Shafts.Count - 1];
			Vector3 localPosition = disposableObject2.transform.localPosition;
			localPosition.y -= 240f;
			disposableObject2.transform.localPosition = localPosition;
			this.m_Shafts.Insert(0, disposableObject2);
			this.m_Shafts.RemoveAt(this.m_Shafts.Count - 1);
		});
		this.m_DropSequence.OnComplete(delegate
		{
			this.Go(this.Speed, Ease.Linear);
		});
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00007E25 File Offset: 0x00006025
	private void ResetDropSequence()
	{
		this.KillDropSequence();
		this.m_DropSequence = DOTween.Sequence();
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00007E38 File Offset: 0x00006038
	private void KillDropSequence()
	{
		if (this.m_DropSequence != null)
		{
			this.m_DropSequence.Kill(false);
			this.m_DropSequence = null;
		}
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0003E42C File Offset: 0x0003C62C
	protected override void OnDisposed()
	{
		this.KillDropSequence();
		this.m_Ambience = null;
		this.m_LoopObject = null;
		this.m_MonologueAClips = null;
		this.m_MonologueBClips = null;
		this.m_MonologueCClips = null;
		this.m_HorrorAmbienceClip = null;
		this.m_FinalClip_01 = null;
		this.m_FinalClip_02 = null;
		this.m_FinalClip_03 = null;
		this.m_LiftDepartClip = null;
		this.m_LiftLoopClip = null;
		this.m_LiftFallLoopClip = null;
		this.m_SafehouseDoorClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000547 RID: 1351
	[Header("<Controllers>")]
	[SerializeField]
	private CH3LiftController m_LiftController;

	// Token: 0x04000548 RID: 1352
	[SerializeField]
	private CH3ServiceController m_ServiceController;

	// Token: 0x04000549 RID: 1353
	[Header("Triggers")]
	[SerializeField]
	private EventTrigger m_FinalTrigger;

	// Token: 0x0400054A RID: 1354
	[Header("Alice")]
	[SerializeField]
	private BaseAiController m_Alice;

	// Token: 0x0400054B RID: 1355
	[SerializeField]
	private GameObject m_AliceHum;

	// Token: 0x0400054C RID: 1356
	[SerializeField]
	private Animator m_BorisAnimationController;

	// Token: 0x0400054D RID: 1357
	[Header("Lift")]
	[SerializeField]
	private Transform m_BorisEndPosition;

	// Token: 0x0400054E RID: 1358
	[SerializeField]
	private Transform m_Lift;

	// Token: 0x0400054F RID: 1359
	[SerializeField]
	private Transform m_LiftPosition;

	// Token: 0x04000550 RID: 1360
	[SerializeField]
	private Transform m_EndPosition;

	// Token: 0x04000551 RID: 1361
	[SerializeField]
	private Transform m_EndCameraPosition;

	// Token: 0x04000552 RID: 1362
	[Header("Shafts")]
	[SerializeField]
	private List<DisposableObject> m_Shafts;

	// Token: 0x04000553 RID: 1363
	[Header("Lighting")]
	[SerializeField]
	private GameObject m_Sparks;

	// Token: 0x04000554 RID: 1364
	[SerializeField]
	private List<LightFlicker> m_LightFlicker;

	// Token: 0x04000555 RID: 1365
	[SerializeField]
	private List<Light> m_Lights;

	// Token: 0x04000556 RID: 1366
	[Header("Disable")]
	[SerializeField]
	private List<GameObject> m_ToDisable;

	// Token: 0x04000557 RID: 1367
	private AudioObject m_LoopObject;

	// Token: 0x04000558 RID: 1368
	private AudioClip[] m_CompleteTaskClips;

	// Token: 0x04000559 RID: 1369
	private AudioClip[] m_MonologueAClips;

	// Token: 0x0400055A RID: 1370
	private AudioClip[] m_MonologueBClips;

	// Token: 0x0400055B RID: 1371
	private AudioClip[] m_MonologueCClips;

	// Token: 0x0400055C RID: 1372
	private AudioObject m_Ambience;

	// Token: 0x0400055D RID: 1373
	private AudioClip m_HorrorAmbienceClip;

	// Token: 0x0400055E RID: 1374
	private AudioClip m_FinalClip_01;

	// Token: 0x0400055F RID: 1375
	private AudioClip m_FinalClip_02;

	// Token: 0x04000560 RID: 1376
	private AudioClip m_FinalClip_03;

	// Token: 0x04000561 RID: 1377
	private AudioClip m_LiftDepartClip;

	// Token: 0x04000562 RID: 1378
	private AudioClip m_LiftLoopClip;

	// Token: 0x04000563 RID: 1379
	private AudioClip m_LiftFallLoopClip;

	// Token: 0x04000564 RID: 1380
	private AudioClip m_SafehouseDoorClip;

	// Token: 0x04000565 RID: 1381
	private Sequence m_DropSequence;

	// Token: 0x04000566 RID: 1382
	private float Speed = 0.15f;

	// Token: 0x04000567 RID: 1383
	private bool m_IsLanded;
}

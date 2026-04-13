using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public class CH3AliceLairController : BaseController
{
	// Token: 0x17000057 RID: 87
	// (get) Token: 0x06000617 RID: 1559 RVA: 0x00007707 File Offset: 0x00005907
	private BorisAi m_Boris
	{
		get
		{
			return GameManager.Instance.CharacterManager.Boris;
		}
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x00039A20 File Offset: 0x00037C20
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_AliceLiftDeadBodiesClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/MonologueDeadBodies/");
		this.m_AliceMonologueClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/MonologueMain/");
		this.m_HorrorCue = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_Horror_Cue_02");
		this.m_TortureEndClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_pipertorturestop");
		this.m_MonologueMusic = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_thedarkpuddles");
		this.m_BeautyMusic = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_thepriceofbeauty");
		this.m_AliceControllerButtonClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_alicepressbutton");
		this.m_GateOpenClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Gate_Open_Slow_01");
		this.m_GateCloseClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Gate_Close_01");
		this.m_AliceDeadBodiesTrigger.SetActive(false);
		this.m_BorisExitLiftTrigger.SetActive(false);
		this.m_LiftExitTrigger.SetActive(false);
		this.m_EntranceTrigger.SetActive(false);
		this.m_BodyRoomTrigger.SetActive(false);
		this.m_AliceCutsceneTrigger.SetActive(false);
		this.m_LeaveTrigger.SetActive(false);
		this.m_WalkTrigger.SetActive(false);
		this.m_HorrorCueTrigger.SetActive(false);
		this.m_Alice.SetActive(false);
		this.m_TortureRoomTrigger.SetActive(false);
		this.m_TortureDoorCloseTrigger.SetActive(false);
		this.m_TortureRoomLockout.ForceOpen();
		for (int i = 0; i < this.m_WindowShutters.Count; i++)
		{
			this.m_WindowShutters[i].localPosition += new Vector3(0f, 15f, 0f);
		}
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x00039BD8 File Offset: 0x00037DD8
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsStarted)
		{
			this.ClearLair();
			this.m_LairEntrance.ForceClose();
			base.SendOnComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceLairObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceLairObjective.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x00039C8C File Offset: 0x00037E8C
	private void InternalActivate()
	{
		this.m_LiftExitTrigger.OnEnter += this.HandleLiftExitTriggerOnEnter;
		this.m_LiftExitTrigger.SetActive(true);
		this.m_BorisExitLiftTrigger.OnEnter += this.HandleBorisExitLiftTriggerOnEnter;
		this.m_BorisExitLiftTrigger.SetActive(true);
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x00039CE0 File Offset: 0x00037EE0
	private void ForceStart()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_16", "OBJECTIVES/CH3_OBJECTIVE_16_TIP", 0f, false, 0f));
		this.m_LairEntrance.ForceOpen();
		this.m_Boris.StopWaypointPathing();
		this.m_Boris.transform.position = this.m_BodyRoomPath.Waypoints[this.m_BodyRoomPath.Waypoints.Count - 1].transform.position;
		this.m_Boris.transform.eulerAngles = this.m_BodyRoomPath.Waypoints[this.m_BodyRoomPath.Waypoints.Count - 1].transform.eulerAngles;
		this.m_Boris.LookAtTarget(this.m_DeadBorisHeadPosition);
		this.m_LiftController.GoToFloor(3, true, true);
		this.m_AliceDeadBodiesTrigger.SetActive(true);
		this.m_AliceDeadBodiesTrigger.OnEnter += this.HandleAliceDeadBodiesTriggerOnEnter;
		this.m_WalkTrigger.SetActive(true);
		this.m_WalkTrigger.OnEnter += this.HandleWalkTriggerOnEnter;
		this.m_WalkTrigger.OnExit += this.HandleWalkTriggerOnExit;
		this.m_TortureRoomTrigger.OnEnter += this.HandleTortureRoomTriggerOnEnter;
		this.m_TortureRoomTrigger.SetActive(true);
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x00007718 File Offset: 0x00005918
	private void ForceComplete()
	{
		this.ClearLair();
		this.m_LeaveTrigger.SetActive(true);
		this.m_LeaveTrigger.OnEnter += this.HandleLeaveTriggerOnEnter;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x00039E44 File Offset: 0x00038044
	private void ClearLair()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_17", "OBJECTIVES/CH3_OBJECTIVE_17_TIP", 0f, false, 0f));
		this.m_PiperSparks.emission.enabled = false;
		for (int i = 0; i < this.m_WindowShutters.Count; i++)
		{
			this.m_WindowShutters[i].localPosition -= new Vector3(0f, 15f, 0f);
		}
		this.m_WalkTrigger.SetActive(true);
		this.m_WalkTrigger.OnEnter += this.HandleWalkTriggerOnEnter;
		this.m_WalkTrigger.OnExit += this.HandleWalkTriggerOnExit;
		this.m_LairEntrance.ForceOpen();
		this.m_TortureRoomEntrance.ForceOpen();
		this.m_LiftController.GoToAlice(0f, false);
		this.m_LiftController.EnableBoris();
		this.m_LiftController.EnableLift();
		DOTween.Sequence().InsertCallback(0.1f, delegate
		{
			this.m_LiftController.ForceCloseLift();
		});
		this.m_StairwellController.UnlockAllFloors();
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x00007743 File Offset: 0x00005943
	private void HandleWalkTriggerOnEnter(object sender, EventArgs e)
	{
		GameManager.Instance.Player.SetRun(false);
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x00007755 File Offset: 0x00005955
	private void HandleWalkTriggerOnExit(object sender, EventArgs e)
	{
		GameManager.Instance.Player.SetRun(true);
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x00039F78 File Offset: 0x00038178
	private void HandleAliceDeadBodiesTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_AliceDeadBodiesTrigger.OnEnter -= this.HandleAliceDeadBodiesTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_BeautyMusic, AudioObjectType.MUSIC, 0, false);
		for (int i = 0; i < this.m_AliceLiftDeadBodiesClips.Length; i++)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_AliceLiftDeadBodiesClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_DEAD_BODIES[i], true));
		}
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x00039FF0 File Offset: 0x000381F0
	private void HandleBorisExitLiftTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BorisExitLiftTrigger.OnEnter -= this.HandleBorisExitLiftTriggerOnEnter;
		this.m_LiftController.DisableLift();
		this.m_Boris.OnWaypointComplete += this.HandleBorisExitLiftNodeOnComplete;
		this.m_Boris.UpdateWaypointList(this.m_ExitLiftPath.Waypoints, false);
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0003A050 File Offset: 0x00038250
	private void HandleLiftExitTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_LiftExitTrigger.OnEnter -= this.HandleLiftExitTriggerOnEnter;
		this.m_LiftExitTrigger.SetActive(false);
		this.m_Boris.OnWaypointComplete += this.HandleBorisAliceDoorNodeOnComplete;
		this.m_Boris.AddToWaypointList(this.m_AliceLairPath.Waypoints, false);
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x00007767 File Offset: 0x00005967
	private void HandleBorisExitLiftNodeOnComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleBorisExitLiftNodeOnComplete;
		this.m_Boris.StopWaypointPathing();
		this.m_ExitLiftPath.Dispose();
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x0003A0B0 File Offset: 0x000382B0
	private void HandleBorisAliceDoorNodeOnComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleBorisExitLiftNodeOnComplete;
		this.m_Boris.OnWaypointComplete -= this.HandleBorisAliceDoorNodeOnComplete;
		this.m_Boris.StopWaypointPathing();
		this.m_AliceLairPath.Dispose();
		if (this.m_ExitLiftPath != null)
		{
			this.m_ExitLiftPath.Dispose();
		}
		this.m_EntranceTrigger.SetActive(true);
		this.m_EntranceTrigger.OnEnter += this.HandleEntranceOnEnter;
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x0003A140 File Offset: 0x00038340
	private void HandleEntranceOnEnter(object sender, EventArgs e)
	{
		this.m_EntranceTrigger.OnEnter -= this.HandleEntranceOnEnter;
		Sequence sequence = DOTween.Sequence();
		GameManager.Instance.AudioManager.Play(this.m_GateOpenClip, AudioObjectType.SOUND_EFFECT, 0, false);
		sequence.InsertCallback(2f, delegate
		{
			GameManager.Instance.GameCamera.transform.DOShakePosition(8f, 0.1f, 7, 90f, false, true).SetDelay(1f).OnComplete(delegate
			{
				GameManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
			});
			this.m_LairEntrance.Open();
		});
		sequence.InsertCallback(7f, delegate
		{
			this.m_Boris.OnWaypointComplete += this.HandleBorisDeadNodeOnComplete;
			this.m_Boris.gameObject.layer = LayerMask.NameToLayer("SelfDefault");
			this.m_Boris.LookAtTarget(this.m_DeadBorisHeadPosition);
			this.m_Boris.AddToWaypointList(this.m_BodyRoomPath.Waypoints, true);
		});
		this.m_BodyRoomTrigger.SetActive(true);
		this.m_BodyRoomTrigger.OnEnter += this.HandleBodyRoomTriggerOnEnter;
		this.m_AliceDeadBodiesTrigger.SetActive(true);
		this.m_AliceDeadBodiesTrigger.OnEnter += this.HandleAliceDeadBodiesTriggerOnEnter;
		this.m_WalkTrigger.SetActive(true);
		this.m_WalkTrigger.OnEnter += this.HandleWalkTriggerOnEnter;
		this.m_WalkTrigger.OnExit += this.HandleWalkTriggerOnExit;
		this.m_HorrorCueTrigger.SetActive(true);
		this.m_HorrorCueTrigger.OnEnter += this.HandleHorrorCueTriggerOnEnter;
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x00007796 File Offset: 0x00005996
	private void HandleHorrorCueTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_HorrorCueTrigger.OnEnter -= this.HandleHorrorCueTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_HorrorCue, AudioObjectType.SOUND_EFFECT, 0, false);
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x0003A258 File Offset: 0x00038458
	private void HandleBorisDeadNodeOnComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleBorisExitLiftNodeOnComplete;
		this.m_Boris.OnWaypointComplete -= this.HandleBorisAliceDoorNodeOnComplete;
		this.m_Boris.OnWaypointComplete -= this.HandleBorisDeadNodeOnComplete;
		this.m_Boris.gameObject.layer = LayerMask.NameToLayer("Ai");
		this.m_Boris.StopWaypointPathing();
		this.m_Boris.LookAtTarget(this.m_DeadBorisHeadPosition);
		this.m_BodyRoomPath.Dispose();
		if (this.m_AliceLairPath != null)
		{
			this.m_AliceLairPath.Dispose();
		}
		if (this.m_ExitLiftPath != null)
		{
			this.m_ExitLiftPath.Dispose();
		}
		this.m_BodyRoomPath.Dispose();
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x0003A330 File Offset: 0x00038530
	private void HandleBodyRoomTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BodyRoomTrigger.OnEnter -= this.HandleBodyRoomTriggerOnEnter;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceLairObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_TortureRoomTrigger.OnEnter += this.HandleTortureRoomTriggerOnEnter;
		this.m_TortureRoomTrigger.SetActive(true);
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x0003A3A8 File Offset: 0x000385A8
	private void HandleTortureRoomTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_TortureRoomTrigger.OnEnter -= this.HandleTortureRoomTriggerOnEnter;
		this.m_Alice.SetActive(true);
		this.m_TortureRoomEntrance.Open();
		this.m_TortureDoorCloseTrigger.OnEnter += this.HandleTortureDoorCloseTriggerOnEnter;
		this.m_TortureDoorCloseTrigger.SetActive(true);
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x0003A408 File Offset: 0x00038608
	private void HandleTortureDoorCloseTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_TortureDoorCloseTrigger.OnEnter -= this.HandleTortureDoorCloseTriggerOnEnter;
		this.m_TortureRoomLockout.Close();
		S13AudioManager.Instance.ToSnapshot("TMGAudioMixer", "mxs_alice_monologues", 1f);
		this.m_AliceCutsceneTrigger.OnEnter += this.HandleAliceCutsceneOnEnter;
		this.m_AliceCutsceneTrigger.SetActive(true);
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0003A474 File Offset: 0x00038674
	private void HandleAliceCutsceneOnEnter(object sender, EventArgs e)
	{
		this.m_AliceCutsceneTrigger.OnEnter -= this.HandleAliceCutsceneOnEnter;
		this.m_PiperAnimationController.SetTrigger("Dead");
		this.m_PiperLight.TurnOff();
		this.m_PiperTriggerSparks.Emit(30);
		this.m_PiperSparks.emission.enabled = false;
		this.m_TortureAudio.Stop();
		this.m_TortureAudio.volume = 0f;
		GameManager.Instance.AudioManager.Play(this.m_TortureEndClip, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += this.HandleTortureEndOnComplete;
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x0003A518 File Offset: 0x00038718
	private void HandleTortureEndOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleTortureEndOnComplete;
		GameManager.Instance.AudioManager.Play(this.m_MonologueMusic, AudioObjectType.MUSIC, 0, false);
		this.m_AliceController.OnPressed += this.HandleAliceControllerOnPressed;
		this.m_AliceController.Activate();
		for (int i = 0; i < this.m_AliceMonologueClips.Length; i++)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_AliceMonologueClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_MAIN_MONOLOGUE[i], true));
		}
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x0003A5B0 File Offset: 0x000387B0
	private void HandleAliceControllerOnPressed(object sender, EventArgs e)
	{
		this.m_AliceController.OnPressed -= this.HandleAliceControllerOnPressed;
		Sequence sequence = DOTween.Sequence();
		float num = 0.25f;
		float num2 = 0.5f;
		GameManager.Instance.AudioManager.Play(this.m_AliceControllerButtonClip, AudioObjectType.SOUND_EFFECT, 0, false);
		for (int i = 0; i < this.m_WindowShutters.Count; i++)
		{
			Transform transform = this.m_WindowShutters[i];
			sequence.InsertCallback(num, delegate
			{
				GameManager.Instance.AudioManager.Play(this.m_GateCloseClip, AudioObjectType.SOUND_EFFECT, 0, false);
			});
			sequence.Insert(num, transform.DOLocalMoveY(transform.localPosition.y - 15f, num2, false).SetEase(Ease.Linear));
			num += num2 / 2f;
		}
		sequence.OnComplete(new TweenCallback(this.ShuttersOnComplete));
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0003A688 File Offset: 0x00038888
	private void ShuttersOnComplete()
	{
		this.m_TortureAudio.Play();
		this.m_TortureAudio.DOFade(1f, 0.75f);
		this.m_TortureRoomLockout.Open();
		S13AudioManager.Instance.ToSnapshot("TMGAudioMixer", "mxs_base", 1f);
		this.m_LiftController.EnableBoris();
		this.m_LiftController.CloseLift();
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_17", "OBJECTIVES/CH3_OBJECTIVE_17_TIP", 4f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceLairObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_LeaveTrigger.SetActive(true);
		this.m_LeaveTrigger.OnEnter += this.HandleLeaveTriggerOnEnter;
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x000077C8 File Offset: 0x000059C8
	private void HandleLeaveTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_LeaveTrigger.OnEnter -= this.HandleLeaveTriggerOnEnter;
		this.m_LairEntrance.OnClose += this.HandleGateCloseOnComplete;
		this.m_LairEntrance.Close();
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x00007803 File Offset: 0x00005A03
	private void HandleGateCloseOnComplete(object sender, EventArgs e)
	{
		this.m_LairEntrance.OnClose -= this.HandleGateCloseOnComplete;
		this.m_StairwellController.UnlockAllFloors();
		this.m_LiftController.EnableLift();
		base.SendOnComplete();
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0003A76C File Offset: 0x0003896C
	protected override void OnDisposed()
	{
		this.m_AliceLiftDeadBodiesClips = null;
		this.m_AliceMonologueClips = null;
		this.m_HorrorCue = null;
		this.m_TortureEndClip = null;
		this.m_MonologueMusic = null;
		this.m_BeautyMusic = null;
		this.m_AliceControllerButtonClip = null;
		this.m_GateCloseClip = null;
		this.m_GateOpenClip = null;
		base.OnDisposed();
	}

	// Token: 0x040004AF RID: 1199
	[Header("<Controllers>")]
	[SerializeField]
	private CH3LiftController m_LiftController;

	// Token: 0x040004B0 RID: 1200
	[SerializeField]
	private CH3StairwellController m_StairwellController;

	// Token: 0x040004B1 RID: 1201
	[Header("Objective: Get Out Of The Lift!")]
	[SerializeField]
	private EventTrigger m_BorisExitLiftTrigger;

	// Token: 0x040004B2 RID: 1202
	[SerializeField]
	private EventTrigger m_LiftExitTrigger;

	// Token: 0x040004B3 RID: 1203
	[SerializeField]
	private WaypointList m_ExitLiftPath;

	// Token: 0x040004B4 RID: 1204
	[SerializeField]
	private WaypointList m_AliceLairPath;

	// Token: 0x040004B5 RID: 1205
	[Header("Objective: Enter The Lair!")]
	[SerializeField]
	private GenericDoorController m_LairEntrance;

	// Token: 0x040004B6 RID: 1206
	[SerializeField]
	private EventTrigger m_EntranceTrigger;

	// Token: 0x040004B7 RID: 1207
	[SerializeField]
	private EventTrigger m_LeaveTrigger;

	// Token: 0x040004B8 RID: 1208
	[SerializeField]
	private WaypointList m_BodyRoomPath;

	// Token: 0x040004B9 RID: 1209
	[Header("Boris Meets Boris")]
	[SerializeField]
	private EventTrigger m_BodyRoomTrigger;

	// Token: 0x040004BA RID: 1210
	[SerializeField]
	private EventTrigger m_TortureRoomTrigger;

	// Token: 0x040004BB RID: 1211
	[SerializeField]
	private GenericDoorController m_TortureRoomEntrance;

	// Token: 0x040004BC RID: 1212
	[SerializeField]
	private EventTrigger m_AliceDeadBodiesTrigger;

	// Token: 0x040004BD RID: 1213
	[SerializeField]
	private EventTrigger m_WalkTrigger;

	// Token: 0x040004BE RID: 1214
	[SerializeField]
	private EventTrigger m_HorrorCueTrigger;

	// Token: 0x040004BF RID: 1215
	[SerializeField]
	private Transform m_DeadBorisHeadPosition;

	// Token: 0x040004C0 RID: 1216
	[Header("Alice Cutscene")]
	[SerializeField]
	private CH3AliceButtonController m_AliceController;

	// Token: 0x040004C1 RID: 1217
	[SerializeField]
	private AudioSource m_TortureAudio;

	// Token: 0x040004C2 RID: 1218
	[SerializeField]
	private EventTrigger m_TortureDoorCloseTrigger;

	// Token: 0x040004C3 RID: 1219
	[SerializeField]
	private LightFlicker m_PiperLight;

	// Token: 0x040004C4 RID: 1220
	[SerializeField]
	private ParticleSystem m_PiperSparks;

	// Token: 0x040004C5 RID: 1221
	[SerializeField]
	private ParticleSystem m_PiperTriggerSparks;

	// Token: 0x040004C6 RID: 1222
	[SerializeField]
	private Animator m_AnimationController;

	// Token: 0x040004C7 RID: 1223
	[SerializeField]
	private Animator m_PiperAnimationController;

	// Token: 0x040004C8 RID: 1224
	[SerializeField]
	private GenericDoorController m_TortureRoomLockout;

	// Token: 0x040004C9 RID: 1225
	[SerializeField]
	private GameObject m_Alice;

	// Token: 0x040004CA RID: 1226
	[SerializeField]
	private EventTrigger m_AliceCutsceneTrigger;

	// Token: 0x040004CB RID: 1227
	[SerializeField]
	private List<Transform> m_WindowShutters;

	// Token: 0x040004CC RID: 1228
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform[] m_CheatPoints;

	// Token: 0x040004CD RID: 1229
	private int m_CurrentCheatPoint;

	// Token: 0x040004CE RID: 1230
	private AudioClip[] m_AliceMonologueClips;

	// Token: 0x040004CF RID: 1231
	private AudioClip[] m_AliceLiftDeadBodiesClips;

	// Token: 0x040004D0 RID: 1232
	private AudioClip m_HorrorCue;

	// Token: 0x040004D1 RID: 1233
	private AudioClip m_TortureEndClip;

	// Token: 0x040004D2 RID: 1234
	private AudioClip m_MonologueMusic;

	// Token: 0x040004D3 RID: 1235
	private AudioClip m_BeautyMusic;

	// Token: 0x040004D4 RID: 1236
	private AudioClip m_AliceControllerButtonClip;

	// Token: 0x040004D5 RID: 1237
	private AudioClip m_GateOpenClip;

	// Token: 0x040004D6 RID: 1238
	private AudioClip m_GateCloseClip;
}

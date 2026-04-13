using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x02000095 RID: 149
public class CH2RecordingStudioController : BaseController
{
	// Token: 0x17000051 RID: 81
	// (get) Token: 0x0600054E RID: 1358 RVA: 0x00006DA5 File Offset: 0x00004FA5
	// (set) Token: 0x0600054F RID: 1359 RVA: 0x00006DAD File Offset: 0x00004FAD
	public bool IsTiming { get; private set; }

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000550 RID: 1360 RVA: 0x00006DB6 File Offset: 0x00004FB6
	// (set) Token: 0x06000551 RID: 1361 RVA: 0x00006DBE File Offset: 0x00004FBE
	public bool IsSuccess { get; private set; }

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000552 RID: 1362 RVA: 0x00006DC7 File Offset: 0x00004FC7
	// (set) Token: 0x06000553 RID: 1363 RVA: 0x00006DCF File Offset: 0x00004FCF
	public bool IsDoorOpening { get; private set; }

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x06000554 RID: 1364 RVA: 0x00006DD8 File Offset: 0x00004FD8
	// (set) Token: 0x06000555 RID: 1365 RVA: 0x00006DE0 File Offset: 0x00004FE0
	public List<int> InstrumentOrder { get; private set; }

	// Token: 0x06000556 RID: 1366 RVA: 0x00035778 File Offset: 0x00033978
	public override void InitOnComplete()
	{
		this.m_ProjectorRunningWildClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Projector_Running_Wild_01");
		this.m_PianoJumpscareClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Piano_Lid_Close_Jumpscare");
		this.m_ProjectorClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Projector_Switch_Turn_On_01");
		this.m_HenryClip10 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_10");
		this.m_StrikeUpTheBandMax = this.m_BendyCutouts.Count;
		for (int i = 0; i < this.m_Instruments.Count; i++)
		{
			InteractableMusicalInstrument interactableMusicalInstrument = this.m_Instruments[i];
			if (interactableMusicalInstrument.InstrumentType == InstrumentType.PIANO)
			{
				interactableMusicalInstrument.SetActive(false);
			}
			interactableMusicalInstrument.OnNotePlayed += this.HandleInstrumentOnNotePlayed;
		}
		this.GenerateCutoutPositions();
		this.m_LightController.TurnOff();
		IEnumerator enumerator = this.m_Lights.transform.parent.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				if (transform.name == "Sanctuary_Light REPLACEMENT")
				{
					this.m_Lights = transform.gameObject;
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
		this.m_Lights.SetActive(false);
		this.m_ProjectorController.InitTurnOff();
		this.m_ProjectorInteract.OnInteracted += this.HandleProjectorOnInteracted;
		this.m_ProjectorInteract.SetActive(true);
		this.m_PianoJumpscare.OnEnter += this.HandlePianoJumpscareOnEnter;
		this.m_PianoJumpscare.SetActive(true);
		this.m_LowerTrigger.OnEnter += this.HandleLowerTriggerOnEnter;
		this.m_LowerTrigger.SetActive(true);
		this.m_UpperTrigger.OnEnter += this.HandleUpperTriggerOnEnter;
		this.m_UpperTrigger.SetActive(true);
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x00035970 File Offset: 0x00033B70
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicPuzzleObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicPuzzleObjective.IsStarted)
		{
			this.m_ClosetDoor.ForceOpen(145f);
			this.m_CanSolve = true;
			GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SANCTUARY", "OBJECTIVES/CH2_OBJECTIVE_SANCTUARY_TIP", 0f, false, 0f));
		}
		else
		{
			this.m_AudioLogController.OnFavoriteSongObjective += this.HandleFavoriteSongObjectiveOnActive;
		}
		this.m_AudioLogController.ActivateFavoriteSong();
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x00006DE9 File Offset: 0x00004FE9
	private void HandleFavoriteSongObjectiveOnActive(object sender, EventArgs e)
	{
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicPuzzleObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_CanSolve = true;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x00035A34 File Offset: 0x00033C34
	private void GenerateCutoutPositions()
	{
		this.m_BendyCutouts.Shuffle<Transform>();
		this.m_StagePositions.Shuffle<Transform>();
		this.m_BalconyPositions.Shuffle<Transform>();
		for (int i = 0; i < this.m_StrikeUpTheBandMax; i++)
		{
			CH2RecordingStudioController.Cutout cutout = new CH2RecordingStudioController.Cutout
			{
				Trans = this.m_BendyCutouts[i],
				StagePosition = this.m_StagePositions[i].position,
				StageRotation = this.m_StagePositions[i].rotation,
				BalconyPosition = this.m_BalconyPositions[i].position,
				BalconyRotation = this.m_BalconyPositions[i].rotation
			};
			this.m_ActiveCutouts.Add(cutout);
		}
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x00006E22 File Offset: 0x00005022
	public void GeneratePuzzle()
	{
		this.InstrumentOrder = new List<int>();
		this.SetupInstruments();
		this.InstrumentOrder.Shuffle<int>();
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x00035AFC File Offset: 0x00033CFC
	private void SetupInstruments()
	{
		if (this.m_AvailableInstruments != null)
		{
			this.m_AvailableInstruments.Clear();
			this.m_AvailableInstruments = null;
		}
		this.m_AvailableInstruments = new List<CH2RecordingStudioController.Instrument>();
		this.m_AvailableInstruments.Add(new CH2RecordingStudioController.Instrument
		{
			InstrumentType = InstrumentType.BANJO,
			AvailableMax = 2
		});
		this.m_AvailableInstruments.Add(new CH2RecordingStudioController.Instrument
		{
			InstrumentType = InstrumentType.DRUM,
			AvailableMax = 2
		});
		this.m_AvailableInstruments.Add(new CH2RecordingStudioController.Instrument
		{
			InstrumentType = InstrumentType.BASS_FIDDLE,
			AvailableMax = 2
		});
		this.m_AvailableInstruments.Add(new CH2RecordingStudioController.Instrument
		{
			InstrumentType = InstrumentType.VIOLIN,
			AvailableMax = 2
		});
		this.m_AvailableInstruments.Add(new CH2RecordingStudioController.Instrument
		{
			InstrumentType = InstrumentType.PIANO,
			AvailableMax = 2
		});
		for (int i = 0; i < 4; i++)
		{
			this.FindNextInstrument();
		}
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x00035BEC File Offset: 0x00033DEC
	private void FindNextInstrument()
	{
		int num = global::UnityEngine.Random.Range(0, this.m_AvailableInstruments.Count);
		if (this.m_AvailableInstruments[num].AvailableMax <= 0)
		{
			this.FindNextInstrument();
		}
		else
		{
			this.m_AvailableInstruments[num].AvailableMax--;
			this.InstrumentOrder.Add(num);
		}
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x00035C54 File Offset: 0x00033E54
	private void Update()
	{
		if (GameManager.Instance.isPaused)
		{
			return;
		}
		if (this.IsSuccess && this.m_IsCompleted && !this.IsDoorOpening && this.m_CanSolve)
		{
			this.DOSuccess();
		}
		if (this.IsTiming && !this.m_IsCompleted)
		{
			this.DOTimer();
		}
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x00006E40 File Offset: 0x00005040
	private void DOTimer()
	{
		this.m_Timer += Time.deltaTime;
		if (this.m_Timer > this.m_TimerMax)
		{
			this.Reset();
		}
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x00035CC0 File Offset: 0x00033EC0
	private void DOSuccess()
	{
		this.m_SuccessTimer += Time.deltaTime;
		if (this.m_SuccessTimer > this.m_SuccessTimerMax)
		{
			this.IsDoorOpening = true;
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_ENTER_SANCTUARY", string.Empty, 4f, false, 0f));
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.MY_FAVORITE_SONG);
			this.m_LightController.TurnOn();
			this.m_Lights.SetActive(true);
			this.TurnOffProjector();
			this.OpenGate();
		}
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x00035D54 File Offset: 0x00033F54
	private void HandlePianoJumpscareOnEnter(object sender, EventArgs e)
	{
		this.m_PianoJumpscare.OnEnter -= this.HandlePianoJumpscareOnEnter;
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_PianoJumpscareClip, this.m_PianoLid.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_PianoLid.DOKill(false);
		this.m_PianoLid.DOLocalRotate(Vector3.zero, 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(new TweenCallback(this.PianoJumpscareOnComplete));
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x00035DDC File Offset: 0x00033FDC
	private void PianoJumpscareOnComplete()
	{
		for (int i = 0; i < this.m_Instruments.Count; i++)
		{
			InteractableMusicalInstrument interactableMusicalInstrument = this.m_Instruments[i];
			if (interactableMusicalInstrument.InstrumentType == InstrumentType.PIANO)
			{
				interactableMusicalInstrument.SetActive(true);
			}
		}
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x00035E28 File Offset: 0x00034028
	private void HandleInstrumentOnNotePlayed(object sender, EventArgs e)
	{
		if (!this.IsTiming || this.m_IsCompleted)
		{
			return;
		}
		InteractableMusicalInstrument interactableMusicalInstrument = (InteractableMusicalInstrument)sender;
		if (interactableMusicalInstrument == null)
		{
			return;
		}
		this.m_InstrumentsPlayed.Add((int)interactableMusicalInstrument.InstrumentType);
		if (this.InstrumentOrder.Count == this.m_InstrumentsPlayed.Count)
		{
			for (int i = 0; i < this.InstrumentOrder.Count; i++)
			{
				if (this.InstrumentOrder[i] != this.m_InstrumentsPlayed[i])
				{
					this.IsSuccess = false;
					break;
				}
				this.IsSuccess = true;
			}
		}
		if (this.m_InstrumentsPlayed.Count > 4)
		{
			this.Reset();
			return;
		}
		if (this.IsSuccess)
		{
			this.IsTiming = false;
			this.m_IsCompleted = true;
			this.m_Timer = 0f;
			if (this.m_StrikeUpTheBandCount >= this.m_StrikeUpTheBandMax)
			{
				GameManager.Instance.AchievementManager.SetAchievement(AchievementName.STRIKE_UP_THE_BAND);
			}
		}
		else if (!this.IsSuccess && this.m_InstrumentsPlayed.Count == 4)
		{
			this.Reset();
		}
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x00035F64 File Offset: 0x00034164
	private void Reset()
	{
		this.IsSuccess = false;
		this.m_Timer = 0f;
		this.IsTiming = false;
		this.IsSuccess = false;
		this.TurnOffProjector();
		this.m_ProjectorInteract.OnInteracted += this.HandleProjectorOnInteracted;
		this.m_ProjectorInteract.SetActive(true);
		if (this.m_ProjectorRunningWildObject != null)
		{
			this.m_ProjectorRunningWildObject.Clear();
			this.m_ProjectorRunningWildObject = null;
		}
		if (this.m_InstrumentsPlayed != null)
		{
			this.m_InstrumentsPlayed.Clear();
		}
		this.m_StrikeUpTheBandCount++;
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x00036004 File Offset: 0x00034204
	private void TurnOffProjector()
	{
		GameManager.Instance.AudioManager.Play(this.m_ProjectorClip, AudioObjectType.SOUND_EFFECT, 0, false);
		if (this.m_ProjectorRunningWildObject != null)
		{
			this.m_ProjectorRunningWildObject.Clear();
			this.m_ProjectorRunningWildObject = null;
		}
		this.m_ProjectorController.TurnOffSilent();
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x00006E6B File Offset: 0x0000506B
	private void HandleLowerTriggerOnEnter(object sender, EventArgs e)
	{
		this.MoveCutoutsToBalcony();
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x00006E73 File Offset: 0x00005073
	private void HandleUpperTriggerOnEnter(object sender, EventArgs e)
	{
		this.MoveCutoutsToStage();
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x00036058 File Offset: 0x00034258
	private void MoveCutoutsToStage()
	{
		for (int i = 0; i < this.m_StrikeUpTheBandCount; i++)
		{
			if (i >= this.m_StrikeUpTheBandMax)
			{
				break;
			}
			CH2RecordingStudioController.Cutout cutout = this.m_ActiveCutouts[i];
			cutout.Trans.position = cutout.StagePosition;
			cutout.Trans.rotation = cutout.StageRotation;
		}
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x000360BC File Offset: 0x000342BC
	private void MoveCutoutsToBalcony()
	{
		for (int i = 0; i < this.m_StrikeUpTheBandCount; i++)
		{
			if (i >= this.m_StrikeUpTheBandMax)
			{
				break;
			}
			CH2RecordingStudioController.Cutout cutout = this.m_ActiveCutouts[i];
			cutout.Trans.position = cutout.BalconyPosition;
			cutout.Trans.rotation = cutout.BalconyRotation;
		}
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x00036120 File Offset: 0x00034320
	private void OpenGate()
	{
		this.m_Gate.Open();
		if (this.m_PianoJumpscare != null)
		{
			this.m_PianoJumpscare.OnEnter -= this.HandlePianoJumpscareOnEnter;
		}
		this.m_PianoLid.localEulerAngles = Vector3.zero;
		this.PianoJumpscareOnComplete();
		for (int i = 0; i < this.m_Instruments.Count; i++)
		{
			this.m_Instruments[i].ForceRemoveEffects();
		}
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicPuzzleObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x00006E7B File Offset: 0x0000507B
	public void EnableTip()
	{
		this.m_PuzzleTip.OnEnter += this.HandlePuzzleTipOnEnter;
		this.m_PuzzleTip.SetActive(true);
		this.m_HasTip = true;
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x00006EA7 File Offset: 0x000050A7
	private void HandlePuzzleTipOnEnter(object sender, EventArgs e)
	{
		this.m_PuzzleTip.OnEnter -= this.HandlePuzzleTipOnEnter;
		if (this.m_HasTip)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip10, "DIACH2/DIA_CH2_HENRY_10", false));
		}
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x000361DC File Offset: 0x000343DC
	private void HandleProjectorOnInteracted(object sender, EventArgs e)
	{
		this.m_ProjectorInteract.SetActive(false);
		this.m_ProjectorInteract.OnInteracted -= this.HandleProjectorOnInteracted;
		this.m_ProjectorController.TurnOn(false);
		this.m_ProjectorRunningWildObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_ProjectorRunningWildClip, this.m_ProjectorController.transform.position, AudioObjectType.SOUND_EFFECT, -1, false, null);
		this.IsTiming = true;
		this.m_HasTip = false;
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x00036258 File Offset: 0x00034458
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH2_save_point_06", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_ENTER_SANCTUARY", string.Empty, 0f, false, 0f));
		for (int i = 0; i < this.m_Instruments.Count; i++)
		{
			this.m_Instruments[i].ForceRemoveEffects();
		}
		this.m_AudioLogController.ActivateFavoriteSong();
		this.m_ClosetDoor.ForceOpen(145f);
		this.m_CanSolve = false;
		this.m_PuzzleTip.OnEnter -= this.HandlePuzzleTipOnEnter;
		this.m_PuzzleTip.SetActive(false);
		this.m_Gate.ForceOpen();
		this.m_LightController.TurnOn();
		this.m_Lights.SetActive(true);
		base.SendOnComplete();
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x0003633C File Offset: 0x0003453C
	protected override void OnDisposed()
	{
		this.m_ProjectorInteract.OnInteracted -= this.HandleProjectorOnInteracted;
		this.m_LowerTrigger.OnEnter -= this.HandleLowerTriggerOnEnter;
		this.m_UpperTrigger.OnEnter -= this.HandleUpperTriggerOnEnter;
		if (this.m_PianoJumpscare != null)
		{
			this.m_PianoJumpscare.OnEnter -= this.HandlePianoJumpscareOnEnter;
		}
		for (int i = 0; i < this.m_Instruments.Count; i++)
		{
			this.m_Instruments[i].OnNotePlayed -= this.HandleInstrumentOnNotePlayed;
		}
		this.m_PianoJumpscareClip = null;
		this.m_ProjectorRunningWildClip = null;
		this.m_ProjectorClip = null;
		this.m_HenryClip10 = null;
		base.OnDisposed();
	}

	// Token: 0x040003D7 RID: 983
	[Header("<Controllers>")]
	[SerializeField]
	private CH2AudioLogsController m_AudioLogController;

	// Token: 0x040003D8 RID: 984
	[Header("Wally Closet Door")]
	[SerializeField]
	private BaseDoorController m_ClosetDoor;

	// Token: 0x040003D9 RID: 985
	[Header("Transforms")]
	[SerializeField]
	private GenericDoorController m_Gate;

	// Token: 0x040003DA RID: 986
	[SerializeField]
	private Transform m_PianoLid;

	// Token: 0x040003DB RID: 987
	[Header("Projector")]
	[SerializeField]
	private ProjectorController m_ProjectorController;

	// Token: 0x040003DC RID: 988
	[SerializeField]
	private Interactable m_ProjectorInteract;

	// Token: 0x040003DD RID: 989
	[Header("Light Fixture")]
	[SerializeField]
	private LightFixtureController m_LightController;

	// Token: 0x040003DE RID: 990
	[SerializeField]
	private GameObject m_Lights;

	// Token: 0x040003DF RID: 991
	[Header("Instruments")]
	[SerializeField]
	private List<InteractableMusicalInstrument> m_Instruments;

	// Token: 0x040003E0 RID: 992
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_PianoJumpscare;

	// Token: 0x040003E1 RID: 993
	[SerializeField]
	private EventTrigger m_PuzzleTip;

	// Token: 0x040003E2 RID: 994
	[Header("Strike Up The Band")]
	[SerializeField]
	private EventTrigger m_LowerTrigger;

	// Token: 0x040003E3 RID: 995
	[SerializeField]
	private EventTrigger m_UpperTrigger;

	// Token: 0x040003E4 RID: 996
	[SerializeField]
	private List<Transform> m_StagePositions;

	// Token: 0x040003E5 RID: 997
	[SerializeField]
	private List<Transform> m_BalconyPositions;

	// Token: 0x040003E6 RID: 998
	[SerializeField]
	private List<Transform> m_BendyCutouts;

	// Token: 0x040003E7 RID: 999
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x040003E8 RID: 1000
	private List<CH2RecordingStudioController.Instrument> m_AvailableInstruments;

	// Token: 0x040003E9 RID: 1001
	private List<int> m_InstrumentsPlayed = new List<int>();

	// Token: 0x040003EA RID: 1002
	private List<CH2RecordingStudioController.Cutout> m_ActiveCutouts = new List<CH2RecordingStudioController.Cutout>();

	// Token: 0x040003EB RID: 1003
	private AudioClip m_PianoJumpscareClip;

	// Token: 0x040003EC RID: 1004
	private AudioClip m_ProjectorRunningWildClip;

	// Token: 0x040003ED RID: 1005
	private AudioClip m_ProjectorClip;

	// Token: 0x040003EE RID: 1006
	private AudioClip m_HenryClip10;

	// Token: 0x040003EF RID: 1007
	private AudioObject m_ProjectorRunningWildObject;

	// Token: 0x040003F0 RID: 1008
	private float m_Timer;

	// Token: 0x040003F1 RID: 1009
	private float m_TimerMax = 45f;

	// Token: 0x040003F2 RID: 1010
	private float m_SuccessTimer;

	// Token: 0x040003F3 RID: 1011
	private float m_SuccessTimerMax = 1f;

	// Token: 0x040003F4 RID: 1012
	private int m_StrikeUpTheBandCount = 1;

	// Token: 0x040003F5 RID: 1013
	private int m_StrikeUpTheBandMax;

	// Token: 0x040003F8 RID: 1016
	private bool m_IsCompleted;

	// Token: 0x040003FB RID: 1019
	private bool m_HasTip;

	// Token: 0x040003FC RID: 1020
	private bool m_CanSolve;

	// Token: 0x02000096 RID: 150
	private class Instrument
	{
		// Token: 0x040003FD RID: 1021
		public InstrumentType InstrumentType;

		// Token: 0x040003FE RID: 1022
		public int AvailableMax;
	}

	// Token: 0x02000097 RID: 151
	public class Cutout
	{
		// Token: 0x040003FF RID: 1023
		public Transform Trans;

		// Token: 0x04000400 RID: 1024
		public Vector3 StagePosition;

		// Token: 0x04000401 RID: 1025
		public Quaternion StageRotation;

		// Token: 0x04000402 RID: 1026
		public Vector3 BalconyPosition;

		// Token: 0x04000403 RID: 1027
		public Quaternion BalconyRotation;
	}
}

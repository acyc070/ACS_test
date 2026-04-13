using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using TMG.Controls;
using UnityEngine;

// Token: 0x02000067 RID: 103
public class CH1BendyFinaleController : BaseController
{
	// Token: 0x06000397 RID: 919 RVA: 0x000055F4 File Offset: 0x000037F4
	public override void Init()
	{
		base.Init();
		this.m_LightFixtureControllers = global::UnityEngine.Object.FindObjectsOfType<LightFixtureController>();
		this.m_LightControllers = global::UnityEngine.Object.FindObjectsOfType<LightController>();
	}

	// Token: 0x06000398 RID: 920 RVA: 0x0002B894 File Offset: 0x00029A94
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_MusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/MUS_Little_Devil_Darling_Remastered");
		this.m_JumpscareClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_ChapterOneBendyAppears");
		this.m_HenryBClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_LAND");
		this.m_TumbleDownClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Tumble_Down_Shaft_01");
		this.m_BodyFallClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Tumble_Down_Shaft_Body_Fall_01");
		this.m_SplashClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Splash_01");
		this.m_SketchesMusic = GameManager.Instance.GetAudioClip("Audio/MUS/CH1/MUS_DownWhereMonstersLive");
		this.m_HenryBodyFallClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Henry_Body_Fall_01");
		this.m_InkFinale.SetActive(false);
		this.m_Barricade.SetActive(false);
		this.m_BnedyEventTrigger.SetActive(false);
		this.m_ExitEventTrigger.SetActive(false);
		this.m_GateEventTrigger.SetActive(false);
		this.m_HenryGateDoor.ForceOpen();
		this.m_GateBent_01.SetActive(false);
		this.m_GateBent_02.SetActive(false);
		for (int i = 0; i < this.m_BasementLights.Count; i++)
		{
			this.m_BasementLights[i].SetActive(false);
		}
		for (int j = 0; j < this.m_CH1FinaleMaterials.Count; j++)
		{
			Material material = this.m_CH1FinaleMaterials[j];
			material.SetFloat("_Cutout", 0f);
		}
		for (int k = 0; k < this.m_GameObjectsToActive.Count; k++)
		{
			this.m_GameObjectsToActive[k].SetActive(false);
		}
		for (int l = 0; l < this.m_GameObjectsToDisable.Count; l++)
		{
			this.m_GameObjectsToDisable[l].SetActive(true);
		}
		IEnumerator enumerator = this.m_BrokenPlanksParent.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				Rigidbody component = transform.GetComponent<Rigidbody>();
				if (component != null)
				{
					this.m_BrokenPlanks.Add(component);
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
		this.m_FallingEventTrigger.SetActive(false);
	}

	// Token: 0x06000399 RID: 921 RVA: 0x0002BB00 File Offset: 0x00029D00
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.BendyChaseObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		DOTweenUtil.DOAmbientLightColor(0.75f, 2f, null);
		this.m_Barricade.SetActive(true);
		this.m_BnedyEventTrigger.OnEnter += this.HandleBendyEventTriggerOnEnter;
		this.m_BnedyEventTrigger.OnExit += this.HandleBendyEventTriggerOnExit;
		this.m_BnedyEventTrigger.SetActive(true);
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0002BB90 File Offset: 0x00029D90
	private void Update()
	{
		if (this.m_ShowRunTutorial && PlayerInput.Run())
		{
			GameManager.Instance.HideTutorial();
			this.m_ShowRunTutorial = false;
		}
		if (!this.m_CanScare)
		{
			return;
		}
		if (this.m_InkMachineMeshRenderer.isVisible)
		{
			this.m_BnedyEventTrigger.OnEnter -= this.HandleBendyEventTriggerOnEnter;
			this.m_BnedyEventTrigger.OnExit -= this.HandleBendyEventTriggerOnExit;
			this.m_BnedyEventTrigger.Dispose();
			this.m_InkMachineMeshRenderer.enabled = false;
			this.m_CanScare = false;
			this.m_HasEffects = true;
			Sequence sequence = DOTween.Sequence();
			float num = 0f;
			sequence.InsertCallback(num, new TweenCallback(this.ActualActivate));
			sequence.InsertCallback(num + 2f, delegate
			{
				this.m_Music = GameManager.Instance.AudioManager.Play(this.m_MusicClip, AudioObjectType.MUSIC, -1, false);
			});
			Transform transform = GameManager.Instance.GameCamera.InitializeFreeRoamCam();
			GameManager.Instance.Player.GoToAndLookAt(this.m_HenryFallLocation);
			sequence.InsertCallback(num, delegate
			{
				GameManager.Instance.GameCamera.transform.DOShakePosition(3f, 0.6f, 15, 90f, false, true);
			});
			sequence.Insert(num, transform.DOLookAt(this.m_BendyLookAt.position, 0.2f, AxisConstraint.None, null).SetEase(Ease.Linear));
			num += 0.4f;
			sequence.Insert(num, transform.DOMoveX(this.m_HenryFallLocation.position.x, 0.5f, false).SetEase(Ease.Linear));
			sequence.Insert(num, transform.DOMoveZ(this.m_HenryFallLocation.position.z, 0.5f, false).SetEase(Ease.Linear));
			num += 0.35f;
			sequence.Insert(num, transform.DOMoveY(this.m_HenryFallLocation.position.y - 2f, 0.15f, false).SetEase(Ease.Linear));
			sequence.InsertCallback(num + 0.15f, delegate
			{
				GameManager.Instance.AudioManager.Play(this.m_HenryBodyFallClip, AudioObjectType.SOUND_EFFECT, 0, false);
			});
			sequence.Insert(num, transform.DORotate(new Vector3(-70f, -15f, 20f), 0.4f, RotateMode.Fast).SetEase(Ease.Linear));
			num += 0.75f;
			sequence.InsertCallback(num, delegate
			{
				this.m_BENDY.SetActive(false);
			});
			sequence.Insert(num, transform.DORotate(this.m_HenryFallLocation.eulerAngles, 1f, RotateMode.Fast).SetEase(Ease.InOutQuad));
			sequence.Insert(num, transform.DOMove(GameManager.Instance.Player.HeadContainer.position, 1f, false).SetEase(Ease.InOutQuad));
			sequence.InsertCallback(num + 1f, delegate
			{
				GameManager.Instance.GameCamera.ExitFreeRoamCam();
				GameManager.Instance.Player.SetLock(false, false);
				GameManager.Instance.ShowTutorial(new TutorialDataVO("Tutorial/TUTORIAL_RUN"));
				this.m_ShowRunTutorial = true;
			});
			num += 1.5f;
			sequence.InsertCallback(num, delegate
			{
				GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_06", string.Empty, 2f, false, 1.75f));
			});
		}
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00005612 File Offset: 0x00003812
	private void LateUpdate()
	{
		if (!this.m_HasEffects)
		{
			return;
		}
		GameManager.Instance.InkEffectManager.SetPosition(GameManager.Instance.Player.transform.position);
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00005643 File Offset: 0x00003843
	private void HandleBendyEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_CanScare = true;
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0000564C File Offset: 0x0000384C
	private void HandleBendyEventTriggerOnExit(object sender, EventArgs e)
	{
		this.m_CanScare = false;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x0002BE84 File Offset: 0x0002A084
	private void ShakeCamera()
	{
		GameManager.Instance.GameCamera.transform.DOKill(false);
		GameManager.Instance.GameCamera.transform.DOShakePosition(0.4f, 1.2f, 18, 90f, false, true).SetEase(Ease.Linear).OnComplete(delegate
		{
			GameManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
		});
	}

	// Token: 0x0600039F RID: 927 RVA: 0x0002BEF8 File Offset: 0x0002A0F8
	private void ActualActivate()
	{
		S13AudioManager.Instance.InvokeEvent("evt_bendy_appears", 0f);
		GameManager.Instance.AudioManager.Play(this.m_JumpscareClip, AudioObjectType.MUSIC, 0, false);
		this.m_EntranceDoor.Activate();
		this.m_HenryGateDoor.ForceClose();
		this.m_BENDY.SetActive(true);
		this.m_StobeLight.SetActive(false);
		this.m_InkFinale.SetActive(true);
		if (this.m_SammyRoomController != null)
		{
			this.m_SammyRoomController.ForceClose();
		}
		this.TurnOffLights();
		this.m_ProjectorController.ShutDown();
		this.m_SammysDoor.ForceClose();
		this.m_SammysDoor.Lock();
		this.ResetSequence();
		float num = 0.25f;
		for (int i = 0; i < this.m_CH1FinaleMaterials.Count; i++)
		{
			Material material = this.m_CH1FinaleMaterials[i];
			material.SetFloat("_Cutout", 0f);
			this.m_FinaleSequence.Insert(num, material.DOFloat(0.5f, "_Cutout", 3f).SetEase(Ease.InOutQuad));
		}
		num += 3.5f;
		this.m_FinaleSequence.Insert(num, this.m_InkRaise.DOLocalMoveY(2.15f, 30f, false).SetEase(Ease.InOutQuad));
		num += 10f;
		this.m_FinaleSequence.InsertCallback(num, delegate
		{
			this.m_InkRaise.GetChild(0).gameObject.tag = "DeepInk";
		});
		this.m_BendyCollapseObject.SetActive(true);
		for (int j = 0; j < this.m_CollapseTriggers.Count; j++)
		{
			this.m_CollapseTriggers[j].OnEnter += this.HandleColllapseTriggerEnter;
			this.m_CollapseTriggers[j].SetActive(true);
		}
		this.m_ExitEventTrigger.OnEnter += this.HandleExitEventTriggerOnEnter;
		this.m_ExitEventTrigger.SetActive(true);
		this.m_GateEventTrigger.OnEnter += this.HandleGateBenderOnEnter;
		this.m_GateEventTrigger.SetActive(true);
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x0002C10C File Offset: 0x0002A30C
	private void HandleGateBenderOnEnter(object sender, EventArgs e)
	{
		this.m_GateEventTrigger.OnEnter -= this.HandleGateBenderOnEnter;
		Sequence sequence = DOTween.Sequence();
		sequence.InsertCallback(0f, delegate
		{
			this.m_HallwayDoor.Close();
		});
		sequence.InsertCallback(0.8f, delegate
		{
			this.ShakeCamera();
			S13AudioManager.Instance.PlayAudio("sfx_ink_bursts");
			this.m_HallwayDoor.gameObject.SetActive(false);
			this.m_GateBent_01.SetActive(true);
			this.m_GateSpew_01.SetActive(true);
		});
		sequence.InsertCallback(2f, delegate
		{
			this.ShakeCamera();
			S13AudioManager.Instance.PlayAudio("sfx_ink_bursts");
			this.m_GateBent_01.SetActive(false);
			this.m_GateBent_02.SetActive(true);
			this.m_GateSpew_02.SetActive(true);
		});
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x0002C180 File Offset: 0x0002A380
	private void HandleColllapseTriggerEnter(object sender, EventArgs e)
	{
		EventTrigger eventTrigger = this.m_CollapseTriggers[this.m_CurrentColapseIndex];
		eventTrigger.OnEnter -= this.HandleColllapseTriggerEnter;
		eventTrigger.SetActive(false);
		this.ShakeCamera();
		CH1BendyFinaleController.CollapseSection collapseSection = this.m_CollapseSections[this.m_CurrentColapseIndex];
		S13AudioManager.Instance.PlayAudio("sfx_ink_bursts");
		if (collapseSection != null)
		{
			if (collapseSection.Collapse)
			{
				collapseSection.Collapse.SetActive(true);
			}
			if (collapseSection.AudioClip != null)
			{
				GameManager.Instance.AudioManager.PlayAtPosition(collapseSection.AudioClip, eventTrigger.transform.position + Vector3.up * 2f, AudioObjectType.SOUND_EFFECT, 0, false, null);
			}
			if (collapseSection.Ceilings != null && collapseSection.Ceilings.Length > 0)
			{
				for (int i = 0; i < collapseSection.Ceilings.Length; i++)
				{
					collapseSection.Ceilings[i].Activate();
				}
			}
		}
		this.m_CurrentColapseIndex++;
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x0002C298 File Offset: 0x0002A498
	private void HandleExitEventTriggerOnEnter(object sender, EventArgs e)
	{
		if (this.m_Music != null)
		{
			this.m_Music.AudioSource.DOFade(0f, 1.5f).OnComplete(delegate
			{
				this.m_Music.Clear();
				this.m_Music = null;
			});
		}
		if (this.m_InkFlowLoop != null)
		{
			this.m_InkFlowLoop.AudioSource.DOFade(0f, 1f).OnComplete(delegate
			{
				this.m_InkFlowLoop.Clear();
				this.m_InkFlowLoop = null;
			});
		}
		this.m_HasEffects = false;
		this.BreakFloor();
		this.m_FallingEventTrigger.SetActive(true);
		this.m_FallingEventTrigger.OnEnter += this.HandleOnFallingEventTriggerOnEnter;
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0002C350 File Offset: 0x0002A550
	private void BreakFloor()
	{
		S13AudioManager.Instance.InvokeEvent("evt_floor_caves_in", 0f);
		for (int i = 0; i < this.m_GameObjectsToActive.Count; i++)
		{
			this.m_GameObjectsToActive[i].SetActive(true);
		}
		for (int j = 0; j < this.m_GameObjectsToDisable.Count; j++)
		{
			this.m_GameObjectsToDisable[j].SetActive(false);
		}
		for (int k = 0; k < this.m_BrokenPlanks.Count; k++)
		{
			this.m_BrokenPlanks[k].AddExplosionForce(1000f, this.m_ExplosionForcePosition.position, 10f);
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x0002C410 File Offset: 0x0002A610
	private void HandleOnFallingEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_FallingEventTrigger.OnEnter -= this.HandleOnFallingEventTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_TumbleDownClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_InkMachineController.Dispose();
		this.DOFall().OnComplete(new TweenCallback(this.Complete));
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x0002C470 File Offset: 0x0002A670
	private void TurnOffLights()
	{
		for (int i = 0; i < this.m_LightFixtureControllers.Length; i++)
		{
			this.m_LightFixtureControllers[i].TurnOff();
		}
		for (int j = 0; j < this.m_LightControllers.Length; j++)
		{
			this.m_LightControllers[j].TurnOff();
		}
		for (int k = 0; k < this.m_Lights.Count; k++)
		{
			this.m_Lights[k].SetActive(false);
		}
		for (int l = 0; l < this.m_BasementLights.Count; l++)
		{
			this.m_BasementLights[l].SetActive(true);
		}
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x0002C528 File Offset: 0x0002A728
	private Sequence DOFall()
	{
		Sequence sequence = DOTween.Sequence();
		this.m_FreeRoamCam = GameManager.Instance.GameCamera.InitializeFreeRoamCam();
		GameManager.Instance.Player.GoToAndLookAt(this.m_FallPoint);
		Vector3 vector = GameManager.Instance.Player.HeadContainer.position - Vector3.up * 0.25f;
		sequence.Insert(0f, this.m_FreeRoamCam.DOMove(vector, 2f, false).SetEase(Ease.Linear));
		sequence.Insert(0f, this.m_FreeRoamCam.DORotate(new Vector3(-90f, 0f, 90f), 1f, RotateMode.Fast).SetEase(Ease.InBack));
		sequence.Insert(1f, this.m_FreeRoamCam.DORotate(new Vector3(-90f, 0f, 180f), 1f, RotateMode.Fast).SetEase(Ease.OutQuad));
		sequence.InsertCallback(2f, new TweenCallback(this.OnLanding));
		sequence.Insert(2f, this.m_FreeRoamCam.DORotate(this.m_FallPoint.eulerAngles, 0.5f, RotateMode.Fast).SetEase(Ease.OutElastic));
		sequence.Insert(2f, this.m_FreeRoamCam.DOShakePosition(0.5f, 5f, 15, 90f, false, true).SetEase(Ease.Linear));
		sequence.Insert(2f, this.m_FreeRoamCam.DOMoveY(GameManager.Instance.Player.HeadContainer.position.y, 0.5f, false).SetEase(Ease.OutQuad));
		return sequence;
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x0002C6D8 File Offset: 0x0002A8D8
	private void OnLanding()
	{
		GameManager.Instance.ShowHurtBorder(true);
		GameManager.Instance.AudioManager.Play(this.m_HenryBClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.AudioManager.Play(this.m_BodyFallClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.AudioManager.Play(this.m_SplashClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.AudioManager.Play(this.m_SketchesMusic, AudioObjectType.MUSIC, 0, false);
		GameManager.Instance.Player.SetSlowed(false);
		GameManager.Instance.InkEffectManager.SetActive(false, false);
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0002C778 File Offset: 0x0002A978
	private void Complete()
	{
		GameManager.Instance.GameCamera.ExitFreeRoamCam();
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.HELLO_BENDY);
		GameManager.Instance.HideTutorial();
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.BendyChaseObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00005655 File Offset: 0x00003855
	private void ResetSequence()
	{
		this.KillSequence();
		this.m_FinaleSequence = DOTween.Sequence();
	}

	// Token: 0x060003AA RID: 938 RVA: 0x00005668 File Offset: 0x00003868
	private void KillSequence()
	{
		if (this.m_FinaleSequence != null)
		{
			this.m_FinaleSequence.Kill(false);
			this.m_FinaleSequence = null;
		}
	}

	// Token: 0x060003AB RID: 939 RVA: 0x0002C7E4 File Offset: 0x0002A9E4
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH1_save_point_05", 0f);
		this.TurnOffLights();
		this.m_HenryGateDoor.ForceClose();
		for (int i = 0; i < this.m_GameObjectsToActive.Count; i++)
		{
			this.m_GameObjectsToActive[i].SetActive(true);
		}
		for (int j = 0; j < this.m_GameObjectsToDisable.Count; j++)
		{
			this.m_GameObjectsToDisable[j].SetActive(false);
		}
		this.m_BENDY.SetActive(false);
		this.m_StobeLight.SetActive(false);
		this.m_InkFinale.SetActive(true);
		this.m_ProjectorController.ShutDown();
		for (int k = 0; k < this.m_CH1FinaleMaterials.Count; k++)
		{
			Material material = this.m_CH1FinaleMaterials[k];
			material.SetFloat("_Cutout", 0.5f);
		}
		GameManager.Instance.HideTutorial();
		base.SendOnComplete();
	}

	// Token: 0x060003AC RID: 940 RVA: 0x0002C8EC File Offset: 0x0002AAEC
	protected override void OnDisposed()
	{
		this.KillSequence();
		if (this.m_BnedyEventTrigger)
		{
			this.m_BnedyEventTrigger.OnEnter -= this.HandleBendyEventTriggerOnEnter;
			this.m_BnedyEventTrigger.OnExit -= this.HandleBendyEventTriggerOnExit;
		}
		if (this.m_ExitEventTrigger)
		{
			this.m_ExitEventTrigger.OnEnter -= this.HandleExitEventTriggerOnEnter;
		}
		if (this.m_FallingEventTrigger)
		{
			this.m_FallingEventTrigger.OnEnter -= this.HandleOnFallingEventTriggerOnEnter;
		}
		if (this.m_BrokenPlanks != null)
		{
			this.m_BrokenPlanks.Clear();
			this.m_BrokenPlanks = null;
		}
		this.m_LightFixtureControllers = null;
		this.m_LightControllers = null;
		this.m_Music = null;
		this.m_InkFlowLoop = null;
		this.m_JumpscareClip = null;
		this.m_MusicClip = null;
		this.m_HenryBClip = null;
		this.m_TumbleDownClip = null;
		this.m_BodyFallClip = null;
		this.m_SplashClip = null;
		this.m_SketchesMusic = null;
		base.OnDisposed();
	}

	// Token: 0x040001FF RID: 511
	private const string CUTOUT = "_Cutout";

	// Token: 0x04000200 RID: 512
	[Header("<Initializers>")]
	[SerializeField]
	private GameObject m_Barricade;

	// Token: 0x04000201 RID: 513
	[SerializeField]
	private GenericDoorController m_HenryGateDoor;

	// Token: 0x04000202 RID: 514
	[Header("<Bendy Jumpscare>")]
	[SerializeField]
	private Transform m_BendyLookAt;

	// Token: 0x04000203 RID: 515
	[SerializeField]
	private EventTrigger m_BnedyEventTrigger;

	// Token: 0x04000204 RID: 516
	[SerializeField]
	private GameObject m_BENDY;

	// Token: 0x04000205 RID: 517
	[SerializeField]
	private MeshRenderer m_InkMachineMeshRenderer;

	// Token: 0x04000206 RID: 518
	[SerializeField]
	private Transform m_HenryFallLocation;

	// Token: 0x04000207 RID: 519
	[SerializeField]
	private Transform m_InkRaise;

	// Token: 0x04000208 RID: 520
	[Header("GameObjects")]
	[SerializeField]
	private GameObject m_InkFinale;

	// Token: 0x04000209 RID: 521
	[SerializeField]
	private GameObject m_StobeLight;

	// Token: 0x0400020A RID: 522
	[Header("Sammys Room")]
	[SerializeField]
	private CH1GeneralController m_ProjectorController;

	// Token: 0x0400020B RID: 523
	[Header("<Lighting>")]
	[SerializeField]
	private List<GameObject> m_Lights;

	// Token: 0x0400020C RID: 524
	[SerializeField]
	private List<GameObject> m_BasementLights;

	// Token: 0x0400020D RID: 525
	[Header("Door")]
	[SerializeField]
	private CH1SammysRoomController m_SammyRoomController;

	// Token: 0x0400020E RID: 526
	[SerializeField]
	private BaseDoorController m_SammysDoor;

	// Token: 0x0400020F RID: 527
	[SerializeField]
	private GenericDoorController m_HallwayDoor;

	// Token: 0x04000210 RID: 528
	[Header("Exit")]
	[SerializeField]
	private EventTrigger m_ExitEventTrigger;

	// Token: 0x04000211 RID: 529
	[SerializeField]
	private CH1EntranceDoor m_EntranceDoor;

	// Token: 0x04000212 RID: 530
	[Header("Materials")]
	[SerializeField]
	private List<Material> m_CH1FinaleMaterials;

	// Token: 0x04000213 RID: 531
	[Header("<Fake Floor>")]
	[SerializeField]
	private InkMachineController m_InkMachineController;

	// Token: 0x04000214 RID: 532
	[Header("GameObjects")]
	[SerializeField]
	private List<GameObject> m_GameObjectsToActive;

	// Token: 0x04000215 RID: 533
	[SerializeField]
	private List<GameObject> m_GameObjectsToDisable;

	// Token: 0x04000216 RID: 534
	[Header("Transforms")]
	[SerializeField]
	private Transform m_BrokenPlanksParent;

	// Token: 0x04000217 RID: 535
	[SerializeField]
	private Transform m_ExplosionForcePosition;

	// Token: 0x04000218 RID: 536
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_FallingEventTrigger;

	// Token: 0x04000219 RID: 537
	[Header("Collapse Triggers")]
	[SerializeField]
	private List<EventTrigger> m_CollapseTriggers;

	// Token: 0x0400021A RID: 538
	[Header("Collapse Objects")]
	[SerializeField]
	private GameObject m_BendyCollapseObject;

	// Token: 0x0400021B RID: 539
	[SerializeField]
	private List<CH1BendyFinaleController.CollapseSection> m_CollapseSections;

	// Token: 0x0400021C RID: 540
	[Header("GateDoor")]
	[SerializeField]
	private EventTrigger m_GateEventTrigger;

	// Token: 0x0400021D RID: 541
	[SerializeField]
	private GameObject m_GateBent_01;

	// Token: 0x0400021E RID: 542
	[SerializeField]
	private GameObject m_GateBent_02;

	// Token: 0x0400021F RID: 543
	[SerializeField]
	private GameObject m_GateSpew_01;

	// Token: 0x04000220 RID: 544
	[SerializeField]
	private GameObject m_GateSpew_02;

	// Token: 0x04000221 RID: 545
	[SerializeField]
	private Transform m_FallPoint;

	// Token: 0x04000222 RID: 546
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000223 RID: 547
	private Transform m_FreeRoamCam;

	// Token: 0x04000224 RID: 548
	private List<Rigidbody> m_BrokenPlanks = new List<Rigidbody>();

	// Token: 0x04000225 RID: 549
	private LightFixtureController[] m_LightFixtureControllers;

	// Token: 0x04000226 RID: 550
	private LightController[] m_LightControllers;

	// Token: 0x04000227 RID: 551
	private AudioClip m_JumpscareClip;

	// Token: 0x04000228 RID: 552
	private AudioClip m_MusicClip;

	// Token: 0x04000229 RID: 553
	private AudioClip m_HenryBClip;

	// Token: 0x0400022A RID: 554
	private AudioClip m_TumbleDownClip;

	// Token: 0x0400022B RID: 555
	private AudioClip m_BodyFallClip;

	// Token: 0x0400022C RID: 556
	private AudioClip m_SplashClip;

	// Token: 0x0400022D RID: 557
	private AudioClip m_SketchesMusic;

	// Token: 0x0400022E RID: 558
	private AudioClip m_HenryBodyFallClip;

	// Token: 0x0400022F RID: 559
	private AudioObject m_Music;

	// Token: 0x04000230 RID: 560
	private AudioObject m_InkFlowLoop;

	// Token: 0x04000231 RID: 561
	private Sequence m_FinaleSequence;

	// Token: 0x04000232 RID: 562
	private bool m_CanScare;

	// Token: 0x04000233 RID: 563
	private bool m_HasEffects;

	// Token: 0x04000234 RID: 564
	private bool m_ShowRunTutorial;

	// Token: 0x04000235 RID: 565
	private int m_CurrentColapseIndex;

	// Token: 0x02000068 RID: 104
	[Serializable]
	private class CollapseSection
	{
		// Token: 0x04000239 RID: 569
		public AudioClip AudioClip;

		// Token: 0x0400023A RID: 570
		public GameObject Collapse;

		// Token: 0x0400023B RID: 571
		public CollapsableCeiling[] Ceilings;
	}
}

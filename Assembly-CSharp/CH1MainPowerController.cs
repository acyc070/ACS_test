using System;
using System.Collections.Generic;
using DG.Tweening;
using I2.Loc;
using S13Audio;
using TMPro;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class CH1MainPowerController : BaseController
{
	// Token: 0x0600041D RID: 1053 RVA: 0x0002E97C File Offset: 0x0002CB7C
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_LeverClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Mainr_Power_Lever_Turn_On_01");
		this.m_LightClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Light_Switch_Sammys_Room_01");
		this.m_Lever.SetActive(false);
		for (int i = 0; i < this.m_ActiveGameObjects.Count; i++)
		{
			this.m_ActiveGameObjects[i].SetActive(false);
		}
		this.m_MainPowerLight.TurnOff();
		this.SetScreenLabel("INWORLD/LOW PRESSURE", 0.5f, 0.25f, true);
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0002EA14 File Offset: 0x0002CC14
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineObjective.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0002EA84 File Offset: 0x0002CC84
	private void InternalActivate()
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_05", string.Empty, 4f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.InternalInitialize();
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0002EAF0 File Offset: 0x0002CCF0
	private void InternalInitialize()
	{
		this.SetScreenLabel("INWORLD/PRESSURE_READY", 0.5f, 0.25f, true);
		this.m_Lever.OnComplete += this.HandleLeverOnComplete;
		this.m_Lever.OnInteracted += this.HandleLeverOnInteracted;
		this.m_Lever.SetActive(true);
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00005E57 File Offset: 0x00004057
	private void ForceStart()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_05", string.Empty, 0f, false, 0f));
		this.InternalInitialize();
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x0002EB50 File Offset: 0x0002CD50
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH1_save_point_04", 0f);
		this.SetScreenLabel("INWORLD/PRESSURE_RUNNING", 0.25f, 0.15f, true);
		for (int i = 0; i < this.m_ActiveGameObjects.Count; i++)
		{
			this.m_ActiveGameObjects[i].SetActive(true);
		}
		for (int j = 0; j < this.m_InkPipes.Count; j++)
		{
			this.m_InkPipes[j].TurnOn();
		}
		for (int k = 0; k < this.m_Pedestals.Count; k++)
		{
			this.m_Pedestals[k].TurnLightOff();
		}
		this.m_InkMachineController.TurnOn();
		this.m_MainPowerLight.TurnOn();
		this.m_HallwayLightController.TurnOff();
		this.m_HallwayLights.SetActive(false);
		this.m_MeatlyController.Activate();
		this.m_BreakRoomDoor.ForceClose();
		this.m_BreakRoomDoor.Lock();
		this.m_Lever.ForceOpen();
		base.SendOnComplete();
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x00005E88 File Offset: 0x00004088
	private void HandleLeverOnInteracted(object sender, EventArgs e)
	{
		this.m_Lever.OnInteracted -= this.HandleLeverOnInteracted;
		this.m_Lever.SetActive(false);
		GameManager.Instance.AudioManager.Play(this.m_LeverClip, AudioObjectType.SOUND_EFFECT, 0, false);
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0002EC70 File Offset: 0x0002CE70
	private void HandleLeverOnComplete(object sender, EventArgs e)
	{
		this.m_Lever.OnComplete -= this.HandleLeverOnComplete;
		GameManager.Instance.AudioManager.Play(this.m_LightClip, AudioObjectType.SOUND_EFFECT, 0, false);
		S13AudioManager.Instance.InvokeEvent("evt_main_power_switch_activated", 0f);
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.ForceComplete();
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0002ECF8 File Offset: 0x0002CEF8
	private void SetScreenLabel(string label, float duration = 0.5f, float delay = 0.25f, bool toUpper = true)
	{
		this.m_ScreenLbl.DOKill(false);
		string empty = string.Empty;
		if (LocalizationManager.TryGetTranslation(label, out empty, true, 0, true, true, null, null))
		{
			label = empty;
		}
		if (toUpper)
		{
			label = label.ToUpper();
		}
		this.m_ScreenLbl.text = label;
		this.m_ScreenLbl.alpha = 1f;
		this.m_ScreenLbl.DOFade(0.25f, duration).SetDelay(delay).SetLoops(-1, LoopType.Yoyo)
			.SetEase(Ease.InOutQuad);
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00005EC6 File Offset: 0x000040C6
	protected override void OnDisposed()
	{
		this.m_ScreenLbl.DOKill(false);
		this.m_LeverClip = null;
		this.m_LightClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400029B RID: 667
	[Header("<Controller>")]
	[SerializeField]
	private MeatlyController m_MeatlyController;

	// Token: 0x0400029C RID: 668
	[SerializeField]
	private List<CH1Pedestal> m_Pedestals;

	// Token: 0x0400029D RID: 669
	[Header("Objective: Turn On Ink Machine")]
	[SerializeField]
	private InkMachineController m_InkMachineController;

	// Token: 0x0400029E RID: 670
	[SerializeField]
	private List<GameObject> m_ActiveGameObjects;

	// Token: 0x0400029F RID: 671
	[SerializeField]
	private TextMeshPro m_ScreenLbl;

	// Token: 0x040002A0 RID: 672
	[SerializeField]
	private InteractablePowerLever m_Lever;

	// Token: 0x040002A1 RID: 673
	[SerializeField]
	private List<InkPipeController> m_InkPipes;

	// Token: 0x040002A2 RID: 674
	[SerializeField]
	private LightController m_MainPowerLight;

	// Token: 0x040002A3 RID: 675
	[SerializeField]
	private LightFixtureController m_HallwayLightController;

	// Token: 0x040002A4 RID: 676
	[SerializeField]
	private GameObject m_HallwayLights;

	// Token: 0x040002A5 RID: 677
	[SerializeField]
	private BaseDoorController m_BreakRoomDoor;

	// Token: 0x040002A6 RID: 678
	private AudioClip m_LeverClip;

	// Token: 0x040002A7 RID: 679
	private AudioClip m_LightClip;
}

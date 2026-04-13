using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x02000089 RID: 137
public class CH2MainGateSwitchController : BaseController
{
	// Token: 0x060004F4 RID: 1268 RVA: 0x00033880 File Offset: 0x00031A80
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_GenericButtonClips = GameManager.Instance.GetAudioClips("Audio/SFX/GenericButtons/");
		this.m_HenryClip06 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_06");
		this.m_SearcherClip = GameManager.Instance.GetAudioClip("Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_02");
		this.m_LightClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Light_Switch_Sammys_Room_01");
		this.m_PowerLeverClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Mainr_Power_Lever_Turn_On_01");
		this.m_BaconSoupSwitchBox.ForceDoorOpen();
		this.m_GateObjective.SetActive(false);
		this.m_GateSwitchInteract.SetActive(false);
		this.m_PlankLight.SetActive(false);
		this.m_LightFixture.TurnOn();
		for (int i = 0; i < this.m_GateSwitchLights.Count; i++)
		{
			this.m_GateSwitchLights[i].TurnOn();
		}
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00033964 File Offset: 0x00031B64
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.GateObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.GateObjective.IsStarted)
		{
			GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_GATE", "OBJECTIVES/CH2_OBJECTIVE_GATE_TIP", 0f, false, 0f));
			this.ActivateSwitchBoxes();
		}
		else
		{
			this.m_GateObjective.OnEnter += this.HandleObjectiveOnEnter;
			this.m_GateObjective.SetActive(true);
		}
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x00033A18 File Offset: 0x00031C18
	private void HandleObjectiveOnEnter(object sender, EventArgs e)
	{
		this.m_GateObjective.OnEnter -= this.HandleObjectiveOnEnter;
		this.ActivateSwitchBoxes();
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.GateObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip06, "DIACH2/DIA_CH2_HENRY_06", true));
		audioObject.OnComplete += delegate(object _sender, EventArgs _e)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_GATE", "OBJECTIVES/CH2_OBJECTIVE_GATE_TIP", 4f, false, 0f));
		};
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00033AB4 File Offset: 0x00031CB4
	private void ActivateSwitchBoxes()
	{
		this.m_BaconSoupSwitchBox.ActivateSwitch();
		this.m_BaconSoupSwitchBox.OnComplete += this.HandleSwitchBoxOnComplete;
		for (int i = 0; i < this.m_SwitchBoxes.Count; i++)
		{
			this.m_SwitchBoxes[i].OnComplete += this.HandleSwitchBoxOnComplete;
			this.m_SwitchBoxes[i].ActivateDoor();
		}
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x00033B30 File Offset: 0x00031D30
	private void HandleSwitchBoxOnComplete(object sender, EventArgs e)
	{
		InteractableSwitchBox interactableSwitchBox = sender as InteractableSwitchBox;
		interactableSwitchBox.OnComplete -= this.HandleSwitchBoxOnComplete;
		this.PlayGenericButtonSound(interactableSwitchBox.transform.position);
		this.m_GateSwitchLights[this.m_ActiveSwitches].TurnOff();
		this.m_ActiveSwitches++;
		if (this.m_ActiveSwitches >= this.m_MaxSwitches)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_RAISE_GATE", string.Empty, 4f, false, 0f));
			this.m_GateSwitchInteract.SetActive(true);
			this.m_GateSwitchInteract.OnInteracted += this.HandleGateSwitchOnInteract;
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x00006919 File Offset: 0x00004B19
	private void HandleGateSwitchOnInteract(object sender, EventArgs e)
	{
		this.m_GateSwitchInteract.OnInteracted -= this.HandleGateSwitchOnInteract;
		this.DOGateRise().OnComplete(new TweenCallback(this.HandleGateRiseOnComplete));
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x00033BE8 File Offset: 0x00031DE8
	private Sequence DOGateRise()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		float num2 = 0.5f;
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_PowerLeverClip, this.m_GateSwitch.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		sequence.Insert(num, this.m_GateSwitch.DOLocalMove(this.m_GateSwitchEndPos.localPosition, num2, false).SetEase(Ease.OutQuad));
		num += num2;
		sequence.InsertCallback(num, new TweenCallback(this.TurnOffLights));
		sequence.InsertCallback(num, new TweenCallback(this.m_GateDoor.Open));
		S13AudioManager.Instance.InvokeEvent("evt_enter_music_department", 0f);
		num += 2f;
		for (int i = 0; i < 7; i++)
		{
			sequence.Insert(num + (float)i * 1f, GameManager.Instance.GameCamera.Camera.DOShakePosition(1f, 0.05f, 10, 90f, false));
		}
		num += 7f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_LightClip, this.m_EntranceAudioLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_SearcherClip, this.m_EntranceAudioLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
			this.m_PlankLight.SetActive(true);
		});
		sequence.Insert(num, GameManager.Instance.GameCamera.Camera.DOShakePosition(1f, 0.05f, 10, 90f, true));
		num += 1f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.GameCamera.Camera.transform.localPosition = Vector3.zero;
		});
		return sequence;
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00033D60 File Offset: 0x00031F60
	private void HandleGateRiseOnComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 0f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.GateObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00033DCC File Offset: 0x00031FCC
	private void TurnOffLights()
	{
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_LightClip, this.m_LightFixture.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_LightFixture.TurnOff();
		this.m_LightObjects.SetActive(false);
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x00033E1C File Offset: 0x0003201C
	private void PlayGenericButtonSound(Vector3 position)
	{
		if (this.m_GenericButtonClips == null || this.m_GenericButtonClips.Length <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_GenericButtonClips.Length);
		AudioClip audioClip = this.m_GenericButtonClips[num];
		GameManager.Instance.AudioManager.PlayAtPosition(audioClip, position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_GenericButtonClips[num] = this.m_GenericButtonClips[0];
		this.m_GenericButtonClips[0] = audioClip;
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x00033E8C File Offset: 0x0003208C
	private void RemoveListeners()
	{
		this.m_BaconSoupSwitchBox.OnComplete -= this.HandleSwitchBoxOnComplete;
		for (int i = 0; i < this.m_SwitchBoxes.Count; i++)
		{
			this.m_SwitchBoxes[i].OnComplete -= this.HandleSwitchBoxOnComplete;
		}
		this.m_GateSwitchInteract.OnInteracted -= this.HandleGateSwitchOnInteract;
		this.m_GateObjective.OnEnter -= this.HandleObjectiveOnEnter;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00033F18 File Offset: 0x00032118
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 0f, false, 0f));
		for (int i = 0; i < this.m_GateSwitchLights.Count; i++)
		{
			this.m_GateSwitchLights[i].TurnOff();
		}
		this.m_GateSwitch.localPosition = this.m_GateSwitchEndPos.localPosition;
		this.m_GateDoor.ForceOpen();
		this.m_BaconSoupSwitchBox.ForceDoorOpen();
		this.m_BaconSoupSwitchBox.ForceSwitchOn();
		for (int j = 0; j < this.m_SwitchBoxes.Count; j++)
		{
			this.m_SwitchBoxes[j].ForceDoorOpen();
			this.m_SwitchBoxes[j].ForceSwitchOn();
		}
		this.m_LightFixture.TurnOff();
		this.m_PlankLight.SetActive(true);
		for (int k = 0; k < this.m_PlanksAtDoor.Count; k++)
		{
			this.m_PlanksAtDoor[k].SetActive(false);
		}
		base.SendOnComplete();
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x0000694A File Offset: 0x00004B4A
	protected override void OnDisposed()
	{
		this.RemoveListeners();
		this.m_GenericButtonClips = null;
		this.m_HenryClip06 = null;
		this.m_SearcherClip = null;
		this.m_LightClip = null;
		this.m_PowerLeverClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400037A RID: 890
	[Header("Objective: Open Gate")]
	[SerializeField]
	private GenericDoorController m_GateDoor;

	// Token: 0x0400037B RID: 891
	[SerializeField]
	private Interactable m_GateSwitchInteract;

	// Token: 0x0400037C RID: 892
	[SerializeField]
	private InteractableSwitchBox m_BaconSoupSwitchBox;

	// Token: 0x0400037D RID: 893
	[SerializeField]
	private List<InteractableSwitchBox> m_SwitchBoxes;

	// Token: 0x0400037E RID: 894
	[SerializeField]
	private List<LightFlicker> m_GateSwitchLights;

	// Token: 0x0400037F RID: 895
	[SerializeField]
	private LightFixtureController m_LightFixture;

	// Token: 0x04000380 RID: 896
	[SerializeField]
	private Transform m_GateSwitch;

	// Token: 0x04000381 RID: 897
	[SerializeField]
	private Transform m_GateSwitchEndPos;

	// Token: 0x04000382 RID: 898
	[SerializeField]
	private GameObject m_LightObjects;

	// Token: 0x04000383 RID: 899
	[SerializeField]
	private EventTrigger m_GateObjective;

	// Token: 0x04000384 RID: 900
	[Header("Objective: Enter Music Lobby")]
	[SerializeField]
	private Transform m_EntranceAudioLocation;

	// Token: 0x04000385 RID: 901
	[SerializeField]
	private GameObject m_PlankLight;

	// Token: 0x04000386 RID: 902
	[SerializeField]
	private List<GameObject> m_PlanksAtDoor;

	// Token: 0x04000387 RID: 903
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000388 RID: 904
	private AudioClip[] m_GenericButtonClips;

	// Token: 0x04000389 RID: 905
	private AudioClip m_HenryClip06;

	// Token: 0x0400038A RID: 906
	private AudioClip m_SearcherClip;

	// Token: 0x0400038B RID: 907
	private AudioClip m_LightClip;

	// Token: 0x0400038C RID: 908
	private AudioClip m_PowerLeverClip;

	// Token: 0x0400038D RID: 909
	private int m_ActiveSwitches;

	// Token: 0x0400038E RID: 910
	private int m_MaxSwitches = 3;
}

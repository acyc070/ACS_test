using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000A3 RID: 163
public class CH2SewerController : BaseController
{
	// Token: 0x060005E3 RID: 1507 RVA: 0x00038998 File Offset: 0x00036B98
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ValveClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Valve_Turn_01");
		this.m_ValvePlaceClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/Valves/SFX_CH3_valvepuzzle_valvearray_02");
		this.m_HenryClip12 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_12");
		this.m_HenryClip13 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_13");
		this.m_HenryClip14 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_14");
		this.m_SearcherIdleClip = GameManager.Instance.GetAudioClip("Audio/SFX/Characters/SwollenSearchers/CH3_SWOLLEN_SEARCHER_IDLE");
		this.m_Jack.Valve.SetActive(false);
		this.m_Jack.transform.position = this.m_JackStartLocation.position;
		this.m_Jack.transform.eulerAngles = this.m_JackStartLocation.eulerAngles;
		this.m_JackTrigger.SetActive(false);
		this.m_SearcherAudioTrigger.SetActive(false);
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x00038A88 File Offset: 0x00036C88
	public override void Activate()
	{
		this.m_Target = GameManager.Instance.Player.transform;
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SewersObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SewersObjective.IsStarted)
		{
			for (int i = 0; i < this.m_BreakablePlanks.Length; i++)
			{
				this.m_BreakablePlanks[i].SetActive(false);
			}
			if (this.m_SearcherIdleObject != null)
			{
				this.m_SearcherIdleObject.Clear();
				this.m_SearcherIdleObject = null;
			}
			this.m_IsReady = false;
			this.ForceMoveJack();
			this.m_Jack.PlayAudio();
		}
		else
		{
			this.m_Jack.Show();
			this.m_CanKillJack = true;
			this.m_JackTrigger.OnEnter += this.HandleJackTriggerOnEnter;
			this.m_JackTrigger.SetActive(true);
			this.m_SearcherAudioTrigger.OnEnter += this.HandleSearcherAudioTriggerOnEnter;
			this.m_SearcherAudioTrigger.SetActive(true);
			this.m_Jack.PlayAudio();
		}
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x00038BC4 File Offset: 0x00036DC4
	private void HandleSearcherAudioTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_SearcherAudioTrigger.OnEnter -= this.HandleSearcherAudioTriggerOnEnter;
		this.m_SearcherIdleObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_SearcherIdleClip, this.m_SearcherAudioLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x00038C14 File Offset: 0x00036E14
	private void Update()
	{
		if (!this.m_IsReady || !this.m_Target)
		{
			return;
		}
		if (Vector3.Distance(this.m_Jack.transform.position, this.m_Target.position) < 15f)
		{
			this.m_IsReady = false;
			this.HideJack();
		}
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x00038C74 File Offset: 0x00036E74
	private void HandleJackTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_JackTrigger.OnEnter -= this.HandleJackTriggerOnEnter;
		this.m_SearcherIdleObject.AudioSource.DOFade(0f, 1f).OnComplete(delegate
		{
			if (this.m_SearcherIdleObject != null)
			{
				this.m_SearcherIdleObject.Clear();
				this.m_SearcherIdleObject = null;
			}
		});
		this.m_IsReady = false;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip12, "DIACH2/DIA_CH2_HENRY_12", false));
		this.HideJack();
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SewersObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x00038D20 File Offset: 0x00036F20
	public void KillJack()
	{
		this.m_IsReady = false;
		this.m_ValvePickup = this.m_Jack.Valve;
		this.m_ValvePickup.transform.SetParent(this.m_ValveLocation);
		this.m_ValvePickup.transform.localPosition = Vector3.zero;
		this.m_ValvePickup.transform.localEulerAngles = Vector3.zero;
		Transform hat = this.m_Jack.Hat;
		hat.SetParent(this.m_HatLocation);
		hat.localPosition = Vector3.zero;
		hat.localEulerAngles = Vector3.zero;
		this.m_Jack.Kill(false);
		this.m_ShadowSammy.SetActive(false);
		this.m_ValvePickup.OnInteracted += this.HandleValvePickupOnInteracted;
		this.m_ValvePickup.SetActive(true);
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x00038DF0 File Offset: 0x00036FF0
	private void HandleValvePickupOnInteracted(object sender, EventArgs e)
	{
		this.m_ValvePickup.OnInteracted -= this.HandleValvePickupOnInteracted;
		this.m_ValvePickup.Dispose();
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.A_SPECIAL_HAT);
		GameManager.Instance.Player.PlayPickUpSound();
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip13, "DIACH2/DIA_CH2_HENRY_13", false));
		this.m_Valve.OnInteracted += this.HandleValveEmptyOnInteracted;
		this.m_Valve.SetEmptyCollision(true);
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x00038E80 File Offset: 0x00037080
	private void HandleValveEmptyOnInteracted(object sender, EventArgs e)
	{
		this.m_Valve.OnInteracted -= this.HandleValveEmptyOnInteracted;
		GameManager.Instance.AudioManager.Play(this.m_ValvePlaceClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Valve.OnInteracted += this.HandleValveOnInteracted;
		this.m_Valve.Activate();
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x00038EE0 File Offset: 0x000370E0
	private void HandleValveOnInteracted(object sender, EventArgs e)
	{
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_ValveClip, this.m_Valve.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_Valve.DORotate(2f).OnComplete(new TweenCallback(this.ValveRotationOnComplete));
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00038F3C File Offset: 0x0003713C
	private void ValveRotationOnComplete()
	{
		this.m_SammyDoorBlockage.SetActive(false);
		this.m_SammyDoorInkVolume.enabled = false;
		this.m_Door.Unlock();
		S13AudioManager.Instance.InvokeEvent("evt_office_door_ink_drained", 0f);
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SewersObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip14, "DIACH2/DIA_CH2_HENRY_14", true));
		audioObject.OnComplete += delegate(object _sender, EventArgs _e)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SAMMYS_OFFICE", string.Empty, 4f, false, 0f));
			base.SendOnComplete();
		};
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x000074D5 File Offset: 0x000056D5
	private void HideJack()
	{
		this.m_Jack.Hide();
		DOTween.Sequence().InsertCallback(1.5f, new TweenCallback(this.MoveJack));
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00038FE0 File Offset: 0x000371E0
	private void ForceMoveJack()
	{
		this.GoToNextPosition();
		if (this.m_Target)
		{
			while (Vector3.Distance(this.m_Jack.transform.position, this.m_Target.position) < 20f)
			{
				this.GoToNextPosition();
			}
		}
		this.m_Jack.Show();
		this.m_CanKillJack = this.m_CurrentLocation == this.m_JackDeathLocation;
		this.m_IsReady = true;
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x00039064 File Offset: 0x00037264
	private void MoveJack()
	{
		this.GoToNextPosition();
		if (this.m_Target)
		{
			while (Vector3.Distance(this.m_Jack.transform.position, this.m_Target.position) < 20f)
			{
				this.GoToNextPosition();
			}
		}
		DOTween.Sequence().InsertCallback(1f, new TweenCallback(this.ShowJack));
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x000074FE File Offset: 0x000056FE
	private void ShowJack()
	{
		this.m_Jack.Show();
		this.m_CanKillJack = this.m_CurrentLocation == this.m_JackDeathLocation;
		DOTween.Sequence().InsertCallback(1f, delegate
		{
			this.m_IsReady = true;
		});
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x000390D8 File Offset: 0x000372D8
	private void GoToNextPosition()
	{
		Transform nextPosition = this.GetNextPosition();
		this.m_Jack.transform.position = nextPosition.position;
		this.m_Jack.transform.eulerAngles = nextPosition.eulerAngles;
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00039118 File Offset: 0x00037318
	private Transform GetNextPosition()
	{
		int num = 0;
		Transform transform = this.m_JackLocations[num];
		if (this.m_Smasher.IsDown && transform == this.m_JackDeathLocation)
		{
			num = 1;
			transform = this.m_JackLocations[num];
		}
		this.m_CurrentLocation = transform;
		this.m_JackLocations.Add(transform);
		this.m_JackLocations.RemoveAt(num);
		return transform;
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x0000753E File Offset: 0x0000573E
	private void Complete()
	{
		this.m_Valve.Disable();
		this.m_SammyDoorBlockage.SetActive(false);
		this.m_Door.Unlock();
		base.SendOnComplete();
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00039184 File Offset: 0x00037384
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH2_save_point_10", 0f);
		for (int i = 0; i < this.m_BreakablePlanks.Length; i++)
		{
			this.m_BreakablePlanks[i].SetActive(false);
		}
		this.m_Jack.transform.position = this.m_JackDeathLocation.position;
		this.m_Jack.transform.eulerAngles = this.m_JackDeathLocation.eulerAngles;
		Transform hat = this.m_Jack.Hat;
		hat.SetParent(this.m_HatLocation);
		hat.localPosition = Vector3.zero;
		hat.localEulerAngles = Vector3.zero;
		this.m_Jack.Kill(true);
		this.m_Jack.Valve.Dispose();
		this.m_Valve.Disable();
		this.m_SammyDoorBlockage.SetActive(false);
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SammysOfficeObjective.IsComplete)
		{
			this.m_Door.ForceOpen(-145f);
			this.m_Door.Lock();
		}
		else
		{
			this.m_Door.Unlock();
		}
		base.SendOnComplete();
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x000392B8 File Offset: 0x000374B8
	protected override void OnDisposed()
	{
		if (this.m_ValvePickup)
		{
			this.m_ValvePickup.OnInteracted -= this.HandleValvePickupOnInteracted;
		}
		this.m_Smasher = null;
		this.m_Target = null;
		this.m_CurrentLocation = null;
		this.m_HenryClip12 = null;
		this.m_HenryClip13 = null;
		this.m_HenryClip14 = null;
		this.m_ValveClip = null;
		this.m_SearcherIdleClip = null;
		this.m_SearcherIdleObject = null;
		base.OnDisposed();
	}

	// Token: 0x04000472 RID: 1138
	[Header("Searcher Audio")]
	[SerializeField]
	private EventTrigger m_SearcherAudioTrigger;

	// Token: 0x04000473 RID: 1139
	[SerializeField]
	private Transform m_SearcherAudioLocation;

	// Token: 0x04000474 RID: 1140
	[Header("Objective: Get The Valve")]
	[SerializeField]
	private CH1PipeValve m_Valve;

	// Token: 0x04000475 RID: 1141
	[SerializeField]
	private GameObject m_SammyDoorBlockage;

	// Token: 0x04000476 RID: 1142
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x04000477 RID: 1143
	[SerializeField]
	private CH2SwollenJack m_Jack;

	// Token: 0x04000478 RID: 1144
	[SerializeField]
	private List<Transform> m_JackLocations;

	// Token: 0x04000479 RID: 1145
	[SerializeField]
	private Transform m_JackDeathLocation;

	// Token: 0x0400047A RID: 1146
	[SerializeField]
	private Transform m_JackStartLocation;

	// Token: 0x0400047B RID: 1147
	[SerializeField]
	private Collider m_SammyDoorInkVolume;

	// Token: 0x0400047C RID: 1148
	[SerializeField]
	private GameObject m_ShadowSammy;

	// Token: 0x0400047D RID: 1149
	[Header("<Crusher>")]
	[SerializeField]
	private CH2CSmasherController m_Smasher;

	// Token: 0x0400047E RID: 1150
	[SerializeField]
	private Transform m_HatLocation;

	// Token: 0x0400047F RID: 1151
	[SerializeField]
	private Transform m_ValveLocation;

	// Token: 0x04000480 RID: 1152
	[SerializeField]
	private EventTrigger m_JackTrigger;

	// Token: 0x04000481 RID: 1153
	[Header("Breakables")]
	[SerializeField]
	private GameObject[] m_BreakablePlanks;

	// Token: 0x04000482 RID: 1154
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000483 RID: 1155
	private Transform m_Target;

	// Token: 0x04000484 RID: 1156
	private Transform m_CurrentLocation;

	// Token: 0x04000485 RID: 1157
	private AudioObject m_SearcherIdleObject;

	// Token: 0x04000486 RID: 1158
	private AudioClip m_ValveClip;

	// Token: 0x04000487 RID: 1159
	private AudioClip m_ValvePlaceClip;

	// Token: 0x04000488 RID: 1160
	private AudioClip m_HenryClip12;

	// Token: 0x04000489 RID: 1161
	private AudioClip m_HenryClip13;

	// Token: 0x0400048A RID: 1162
	private AudioClip m_HenryClip14;

	// Token: 0x0400048B RID: 1163
	private AudioClip m_SearcherIdleClip;

	// Token: 0x0400048C RID: 1164
	private Interactable m_ValvePickup;

	// Token: 0x0400048D RID: 1165
	public bool m_CanKillJack;

	// Token: 0x0400048E RID: 1166
	private bool m_IsReady;
}

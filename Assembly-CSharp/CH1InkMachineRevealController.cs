using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x0200006F RID: 111
public class CH1InkMachineRevealController : BaseController
{
	// Token: 0x060003F2 RID: 1010 RVA: 0x0002DAC4 File Offset: 0x0002BCC4
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_HenryClip02 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_02");
		this.m_HenryClip03 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_03");
		this.m_InkMachineMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH1/MUS_MachineRevealed");
		this.m_Gate.ForceClose();
		this.m_Machinery.Stop();
		this.m_Trunk.SetActive(false);
		this.m_Lever.SetSingleInteraction(true);
		this.m_InteractTutorial.SetActive(false);
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x00005B6E File Offset: 0x00003D6E
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineRevealObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00005BA4 File Offset: 0x00003DA4
	private void InternalActivate()
	{
		this.m_InkMachineEventTrigger.OnEnter += this.HandleInkMachineTriggerOnEnter;
		this.m_InkMachineEventTrigger.SetActive(true);
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0002DB50 File Offset: 0x0002BD50
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH1_save_point_01", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_02", "OBJECTIVES/CH1_OBJ_02_TIP", 0f, false, 0f));
		this.m_InkMachineEventTrigger.OnEnter -= this.HandleInkMachineTriggerOnEnter;
		this.m_InkMachineEventTrigger.SetActive(false);
		this.m_Generator.DOScaleY(1.01f, 0.2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
		this.m_Trunk.ForceOpen();
		this.m_Trunk.SetActive(false);
		this.m_Trunk.ForceRemoveEffects();
		this.m_Lever.Activate(true);
		this.m_Gate.ForceOpen();
		this.m_BreakRoomDoor.ForceOpen(-145f);
		this.m_Machinery.Play();
		this.m_InkMachine.position = this.m_InkMachineRevealPoint.position;
		for (int i = 0; i < this.m_Batteries.Count; i++)
		{
			Interactable interactable = this.m_Batteries[i];
			interactable.SetActive(false);
			interactable.transform.SetParent(this.m_Generator);
			interactable.transform.position = this.m_BatterySlots[i].EndPos.position;
			interactable.transform.eulerAngles = this.m_BatterySlots[i].EndPos.eulerAngles;
		}
		base.SendOnComplete();
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0002DCD4 File Offset: 0x0002BED4
	private void HandleInkMachineTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_InkMachineEventTrigger.OnEnter -= this.HandleInkMachineTriggerOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip02, "DIACH1/DIA_CH1_HENRY_02", false)).OnComplete += this.HandleInitialDialogueOnComplete;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0002DD24 File Offset: 0x0002BF24
	private void HandleInitialDialogueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleInitialDialogueOnComplete;
		this.m_InteractTutorial.SetActive(true);
		this.m_Trunk.SetActive(true);
		for (int i = 0; i < this.m_BatterySlots.Count; i++)
		{
			Interactable slot = this.m_BatterySlots[i].Slot;
			slot.GetComponent<Collider>().enabled = false;
			slot.SetActive(true);
		}
		for (int j = 0; j < this.m_Batteries.Count; j++)
		{
			Interactable interactable = this.m_Batteries[j];
			interactable.OnInteracted += this.HandleBatteryOnInteracted;
			interactable.SetActive(true);
		}
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0002DDE4 File Offset: 0x0002BFE4
	private void HandleBatteryOnInteracted(object sender, EventArgs e)
	{
		Interactable interactable = sender as Interactable;
		interactable.OnInteracted -= this.HandleBatteryOnInteracted;
		interactable.SetActive(false);
		interactable.gameObject.SetActive(false);
		GameManager.Instance.Player.PlayPickUpSound();
		this.m_CollectedBatteries.Add(interactable.gameObject);
		if (this.m_CollectedBatteries.Count < 2)
		{
			for (int i = 0; i < this.m_BatterySlots.Count; i++)
			{
				Interactable slot = this.m_BatterySlots[i].Slot;
				slot.GetComponent<Collider>().enabled = true;
				slot.OnInteracted += this.HandleEmptyBatteryOnInteracted;
			}
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0002DE9C File Offset: 0x0002C09C
	private void HandleEmptyBatteryOnInteracted(object sender, EventArgs e)
	{
		Interactable interactable = sender as Interactable;
		CH1InkMachineRevealController.BatterySlots batterySlots = null;
		for (int i = 0; i < this.m_BatterySlots.Count; i++)
		{
			if (this.m_BatterySlots[i].Slot == interactable)
			{
				batterySlots = this.m_BatterySlots[i];
				this.m_BatterySlots.RemoveAt(i);
				break;
			}
		}
		if (this.m_BatterySlots.Count > 0 && this.m_BatterySlots[0].Slot == interactable)
		{
			return;
		}
		interactable.OnInteracted -= this.HandleBatteryOnInteracted;
		interactable.SetActive(false);
		interactable.gameObject.SetActive(false);
		GameObject gameObject = this.m_CollectedBatteries[0];
		this.m_CollectedBatteries.RemoveAt(0);
		gameObject.SetActive(true);
		gameObject.transform.SetParent(this.m_Generator);
		gameObject.transform.position = batterySlots.StartPos.position;
		gameObject.transform.eulerAngles = batterySlots.StartPos.eulerAngles;
		if (this.m_CollectedBatteries.Count <= 0)
		{
			for (int j = 0; j < this.m_BatterySlots.Count; j++)
			{
				Interactable slot = this.m_BatterySlots[j].Slot;
				slot.GetComponent<Collider>().enabled = false;
				slot.OnInteracted -= this.HandleEmptyBatteryOnInteracted;
			}
		}
		this.m_BatteryCount++;
		bool isComplete = this.m_BatteryCount >= this.m_MaxBatteries;
		S13AudioManager.Instance.PlayAudio("sfx_battery_added");
		gameObject.transform.DOMove(batterySlots.EndPos.position, 0.5f, false).SetDelay(0.1f).SetEase(Ease.InQuad)
			.OnComplete(delegate
			{
				if (isComplete)
				{
					this.m_Generator.DOScaleY(1.01f, 0.2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
					S13AudioManager.Instance.InvokeEvent("evt_battery_pack_on", 0f);
					GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip03, "DIACH1/DIA_CH1_HENRY_03", false));
					this.m_Lever.OnComplete += this.HandleLeverOnComplete;
					this.m_Lever.Activate(false);
				}
			});
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0002E0A4 File Offset: 0x0002C2A4
	private void HandleLeverOnComplete(object sender, EventArgs e)
	{
		this.m_Lever.OnComplete += this.HandleLeverOnComplete;
		GameManager.Instance.AudioManager.Play(this.m_InkMachineMusicClip, AudioObjectType.MUSIC, 0, false);
		S13AudioManager.Instance.InvokeEvent("evt_ink_machine_reveal_start", 0f);
		this.m_BreakRoomDoor.ForceOpen(-20f);
		this.m_BreakRoomDoor.Unlock();
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		sequence.Insert(num, this.m_Chains.DOMove(this.m_ChainsEndPoint.position, 22f, false).SetEase(Ease.OutQuad));
		sequence.Insert(num, this.m_InkMachine.DOMove(this.m_InkMachineRevealPoint.position, 22f, false).SetEase(Ease.OutQuad));
		sequence.InsertCallback(num, new TweenCallback(this.m_Machinery.Play));
		sequence.InsertCallback(num + 10f, new TweenCallback(this.m_Gate.Open));
		sequence.OnComplete(new TweenCallback(this.OnMachineRevealComplete));
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0002E1BC File Offset: 0x0002C3BC
	private void OnMachineRevealComplete()
	{
		this.m_InkMachineController.ShowSteam();
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_02", "OBJECTIVES/CH1_OBJ_02_TIP", 4f, false, 0f));
		S13AudioManager.Instance.InvokeEvent("evt_ink_machine_reveal_stop", 0f);
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.InkMachineRevealObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x00005BC9 File Offset: 0x00003DC9
	protected override void OnDisposed()
	{
		if (this.m_CollectedBatteries != null)
		{
			this.m_CollectedBatteries.Clear();
			this.m_CollectedBatteries = null;
		}
		this.m_HenryClip02 = null;
		this.m_HenryClip03 = null;
		this.m_InkMachineMusicClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400026C RID: 620
	[Header("Objective: Turn On Ink Machine")]
	[SerializeField]
	private InkMachineController m_InkMachineController;

	// Token: 0x0400026D RID: 621
	[SerializeField]
	private EventTrigger m_InkMachineEventTrigger;

	// Token: 0x0400026E RID: 622
	[SerializeField]
	private Transform m_InkMachine;

	// Token: 0x0400026F RID: 623
	[SerializeField]
	private Transform m_InkMachineRevealPoint;

	// Token: 0x04000270 RID: 624
	[SerializeField]
	private Transform m_Chains;

	// Token: 0x04000271 RID: 625
	[SerializeField]
	private Transform m_ChainsEndPoint;

	// Token: 0x04000272 RID: 626
	[SerializeField]
	private Transform m_Generator;

	// Token: 0x04000273 RID: 627
	[SerializeField]
	private List<Interactable> m_Batteries;

	// Token: 0x04000274 RID: 628
	[SerializeField]
	private List<CH1InkMachineRevealController.BatterySlots> m_BatterySlots;

	// Token: 0x04000275 RID: 629
	[SerializeField]
	private CH3LeverLight m_Lever;

	// Token: 0x04000276 RID: 630
	[Header("Other")]
	[SerializeField]
	private InteractableTrunk m_Trunk;

	// Token: 0x04000277 RID: 631
	[SerializeField]
	private BasicAnimationController m_Machinery;

	// Token: 0x04000278 RID: 632
	[SerializeField]
	private GenericDoorController m_Gate;

	// Token: 0x04000279 RID: 633
	[SerializeField]
	private BaseDoorController m_BreakRoomDoor;

	// Token: 0x0400027A RID: 634
	[SerializeField]
	private GameObject m_InteractTutorial;

	// Token: 0x0400027B RID: 635
	private List<GameObject> m_CollectedBatteries = new List<GameObject>();

	// Token: 0x0400027C RID: 636
	private AudioClip m_HenryClip02;

	// Token: 0x0400027D RID: 637
	private AudioClip m_HenryClip03;

	// Token: 0x0400027E RID: 638
	private AudioClip m_InkMachineMusicClip;

	// Token: 0x0400027F RID: 639
	private int m_BatteryCount;

	// Token: 0x04000280 RID: 640
	private int m_MaxBatteries = 2;

	// Token: 0x02000070 RID: 112
	[Serializable]
	private class BatterySlots
	{
		// Token: 0x04000281 RID: 641
		public Interactable Slot;

		// Token: 0x04000282 RID: 642
		public Transform StartPos;

		// Token: 0x04000283 RID: 643
		public Transform EndPos;
	}
}

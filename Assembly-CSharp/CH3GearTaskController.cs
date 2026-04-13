using System;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class CH3GearTaskController : CH3BaseTaskController
{
	// Token: 0x0600083D RID: 2109 RVA: 0x000466DC File Offset: 0x000448DC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ObjectiveSprite = GameManager.Instance.AssetManager.GetAsset<Sprite>("UI/ObjectiveIcons/gear_icon");
		this.m_BeginTaskClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/TasksBegin/");
		this.m_MissionCompleteClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/TaskGearEnd/");
		this.m_MissionEndClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/TaskGear/");
		this.m_TakeGearClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_gearmission_takegear");
		this.m_AliceMissionIntroClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Alice/ch3_alice_22_gearmissionintro");
		this.m_HenryTrueClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_27_valvepuzzle_trueA");
		this.m_HenryFalseClip_01 = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_25_valvepuzzle_falseA");
		this.m_HenryFalseClip_02 = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_26_valvepuzzle_falseB");
		this.m_FinalLiftTrigger.SetActive(false);
		this.m_Piper = GameManager.Instance.AssetManager.CreateAsset<PiperAi>("GamePlay/Characters/Ai_Piper");
		this.m_Piper.gameObject.SetActive(false);
		base.SetWeapon(this.m_WeaponStationController.WeaponStation.m_Wrench);
		for (int i = 0; i < this.m_GearPanels.Count; i++)
		{
			CH3GearPanel ch3GearPanel = this.m_GearPanels[i];
			ch3GearPanel.ID = i;
			if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object[i].ID == i && GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object[i].IsComplete)
			{
				ch3GearPanel.ForceComplete();
			}
			else
			{
				ch3GearPanel.Activate();
			}
		}
		for (int j = 0; j < this.m_EmptyGearPanels.Count; j++)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsComplete)
			{
				this.m_EmptyGearPanels[j].ForceComplete();
			}
			else
			{
				this.m_EmptyGearPanels[j].Activate();
			}
		}
		this.m_InkDemonWarningTrigger.SetActive(false);
		this.m_BendyDontRunTrigger.SetActive(false);
		this.m_DontRunClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/InkDemon/");
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x0004692C File Offset: 0x00044B2C
	public override void Activate()
	{
		base.Activate();
		this.m_BendyController.SetActive(false);
		this.m_SearcherController.SetActive(true);
		this.m_ProjectionistScareController.Activate();
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsComplete)
		{
			for (int i = 0; i < this.m_GearPanels.Count; i++)
			{
				CH3GearPanel ch3GearPanel = this.m_GearPanels[i];
				ch3GearPanel.RotateGears();
				ch3GearPanel.ActivateInteraction();
				ch3GearPanel.OnComplete += this.HandleGearPanelOnComplete;
			}
			for (int j = 0; j < this.m_EmptyGearPanels.Count; j++)
			{
				CH3GearPanel ch3GearPanel2 = this.m_EmptyGearPanels[j];
				ch3GearPanel2.RotateGears();
				ch3GearPanel2.ActivateInteraction();
				ch3GearPanel2.OnComplete += this.HandleEmptyGearPanelOnComplete;
			}
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ThickInkTask.Status.IsStarted)
		{
			this.GoToNextController();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x00046AB8 File Offset: 0x00044CB8
	private void GoToNextController()
	{
		for (int i = 0; i < this.m_GearPanels.Count; i++)
		{
			CH3GearPanel ch3GearPanel = this.m_GearPanels[i];
			if (ch3GearPanel)
			{
				ch3GearPanel.ForceComplete();
			}
		}
		for (int j = 0; j < this.m_EmptyGearPanels.Count; j++)
		{
			CH3GearPanel ch3GearPanel2 = this.m_EmptyGearPanels[j];
			if (ch3GearPanel2)
			{
				ch3GearPanel2.ForceComplete();
			}
		}
		if (this.m_Weapon)
		{
			this.m_Weapon.Dispose();
		}
		base.SendOnComplete();
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x00046B5C File Offset: 0x00044D5C
	private void InternalActivate()
	{
		this.CheckForPiper();
		this.m_WeaponStationController.Block();
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_AliceMissionIntroClip, "DIACH3/DIA_CH3_ALICE_01", false)).OnComplete += this.HandleBeginDialogueOnComplete;
		this.m_InkDemonWarningTrigger.OnEnter -= this.HandleInkDemonWarningTriggerOnEnter;
		this.m_InkDemonWarningTrigger.OnEnter += this.HandleInkDemonWarningTriggerOnEnter;
		this.m_InkDemonWarningTrigger.SetActive(true);
		this.m_BendyDontRunTrigger.OnEnter -= this.HandleBendyDontRunTriggerOnEnter;
		this.m_BendyDontRunTrigger.OnEnter += this.HandleBendyDontRunTriggerOnEnter;
		this.m_BendyDontRunTrigger.SetActive(true);
		this.m_Weapon.Interaction.SetActive(false);
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x00046C2C File Offset: 0x00044E2C
	private void ForceStart()
	{
		this.m_LiftController.GoToFloor(GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor, false, false);
		DOTween.Sequence().InsertCallback(0.1f, delegate
		{
			this.m_LiftController.ForceCloseLift();
		});
		this.UpdateObjective();
		this.CheckForPiper();
		this.GetWeapon();
		if (this.m_GearCount < 1)
		{
			this.m_InkDemonWarningTrigger.OnEnter -= this.HandleInkDemonWarningTriggerOnEnter;
			this.m_InkDemonWarningTrigger.OnEnter += this.HandleInkDemonWarningTriggerOnEnter;
			this.m_InkDemonWarningTrigger.SetActive(true);
			this.m_BendyDontRunTrigger.OnEnter -= this.HandleBendyDontRunTriggerOnEnter;
			this.m_BendyDontRunTrigger.OnEnter += this.HandleBendyDontRunTriggerOnEnter;
			this.m_BendyDontRunTrigger.SetActive(true);
		}
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x00046D10 File Offset: 0x00044F10
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_RETURN_TO_THE_ANGEL", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS_COMPLETE_TIP", 0f, false, 0f));
		this.m_LiftController.GoToFloor(GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor, false, false);
		DOTween.Sequence().InsertCallback(0.1f, delegate
		{
			this.m_LiftController.ForceCloseLift();
		});
		if (this.m_Piper)
		{
			this.m_Piper.Dispose();
		}
		this.m_BendyController.SetActive(true);
		this.GetWeapon();
		for (int i = 0; i < this.m_GearPanels.Count; i++)
		{
			CH3GearPanel ch3GearPanel = this.m_GearPanels[i];
			if (ch3GearPanel)
			{
				ch3GearPanel.ForceComplete();
			}
		}
		for (int j = 0; j < this.m_EmptyGearPanels.Count; j++)
		{
			CH3GearPanel ch3GearPanel2 = this.m_EmptyGearPanels[j];
			if (ch3GearPanel2)
			{
				ch3GearPanel2.ForceComplete();
			}
		}
		this.m_FinalLiftTrigger.OnEnter += this.HandleFinalLiftTriggerOnEnter;
		this.m_FinalLiftTrigger.SetActive(true);
		base.ActivateDropbox();
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x00046E54 File Offset: 0x00045054
	private void UpdateObjective()
	{
		ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS_START", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS_TIP", 0f, false, 0f);
		for (int i = 0; i < GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object.Length; i++)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object[i].IsComplete)
			{
				this.m_GearCount++;
			}
		}
		objectiveDataVO.AddItemCounter(this.m_ObjectiveSprite, this.m_GearCount);
		GameManager.Instance.UpdateObjective(objectiveDataVO);
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x00046330 File Offset: 0x00044530
	private void GetWeapon()
	{
		if (this.m_Weapon)
		{
			PlayerController player = GameManager.Instance.Player;
			player.InactiveWeapon = player.WeaponGameObject;
			player.InactiveWeapon.gameObject.SetActive(false);
			player.WeaponGameObject = this.m_Weapon.gameObject;
			this.m_Weapon.SetParentAndAlign(player.WeaponParent);
			this.m_Weapon.Equip();
			this.m_Weapon.Interaction.SetActive(false);
			this.m_Weapon.Interaction.Dispose();
		}
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x00046F08 File Offset: 0x00045108
	private void CheckForPiper()
	{
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object[2].IsComplete)
		{
			this.m_Piper.gameObject.SetActive(true);
			this.m_Piper.OnDeath += this.HandlePiperOnDeath;
			this.m_Piper.GearSetActive(true);
			this.m_Piper.transform.position = this.m_PiperSpawner.transform.position;
			this.m_Piper.transform.eulerAngles = new Vector3(0f, global::UnityEngine.Random.Range(0f, 360f), 0f);
			this.m_Piper.UpdateWaypointList(this.m_RoamingList.Waypoints, false);
		}
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00008D66 File Offset: 0x00006F66
	private void HandleBeginDialogueOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS_START", string.Empty, 4f, false, 0f));
		base.EnableWeapon();
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x00046FD8 File Offset: 0x000451D8
	protected override void BeginTask()
	{
		ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS_TIP", 4f, false, 0f);
		objectiveDataVO.AddItemCounter(this.m_ObjectiveSprite, 0);
		GameManager.Instance.ShowObjective(objectiveDataVO);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsStarted = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x0004707C File Offset: 0x0004527C
	private void HandleInkDemonWarningTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_InkDemonWarningTrigger.OnEnter -= this.HandleInkDemonWarningTriggerOnEnter;
		for (int i = 0; i < this.m_BeginTaskClips.Length; i++)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_BeginTaskClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_BEGIN_TASKS[i], true));
		}
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x000470DC File Offset: 0x000452DC
	private void HandleBendyDontRunTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BendyDontRunTrigger.OnEnter -= this.HandleBendyDontRunTriggerOnEnter;
		for (int i = 0; i < this.m_DontRunClips.Length; i++)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_DontRunClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_INK_DEMON[i], true));
		}
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x0004713C File Offset: 0x0004533C
	private void HandlePiperOnDeath(object sender, EventArgs e)
	{
		this.m_Piper.OnDeath -= this.HandlePiperOnDeath;
		this.m_Piper.GearSetActive(false);
		Vector3 position = this.m_Piper.transform.position;
		Vector3 vector = position + Vector3.up * 5f;
		Interactable gear = GameManager.Instance.AssetManager.CreateAsset<Interactable>("GamePlay/CH3/CH3Gear");
		gear.transform.position = vector;
		gear.transform.DOMove(position, 0.5f, false).SetEase(Ease.OutBounce).OnComplete(delegate
		{
			this.GearDropOnComplete(gear);
		});
		this.m_BendyController.SetActive(true);
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x00008D97 File Offset: 0x00006F97
	private void GearDropOnComplete(Interactable gear)
	{
		gear.SetActive(true);
		gear.OnInteracted += this.HandlePiperGearOnInteracted;
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x00047208 File Offset: 0x00045408
	private void HandlePiperGearOnInteracted(object sender, EventArgs e)
	{
		Interactable interactable = (Interactable)sender;
		interactable.OnInteracted -= this.HandlePiperGearOnInteracted;
		GameManager.Instance.AudioManager.Play(this.m_TakeGearClip, AudioObjectType.SOUND_EFFECT, 0, false);
		interactable.Dispose();
		this.m_GearCount++;
		GameManager.Instance.CurrentObjective.ItemCounter++;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object[2].IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		if (this.m_GearCount < 3)
		{
			GameManager.Instance.GameDataManager.Save(false, true);
		}
		this.CheckStatus();
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000472E4 File Offset: 0x000454E4
	private void HandleGearPanelOnComplete(object sender, EventArgs e)
	{
		CH3GearPanel ch3GearPanel = (CH3GearPanel)sender;
		ch3GearPanel.OnComplete -= this.HandleGearPanelOnComplete;
		if (this.m_GearPanels.Contains(ch3GearPanel))
		{
			this.m_GearPanels.Remove(ch3GearPanel);
			this.m_GearCount++;
			GameManager.Instance.CurrentObjective.ItemCounter++;
		}
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Object[ch3GearPanel.ID].IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		if (this.m_GearCount < 3)
		{
			GameManager.Instance.GameDataManager.Save(false, true);
		}
		this.CheckStatus();
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x000473C4 File Offset: 0x000455C4
	private void CheckStatus()
	{
		if (this.m_GearCount == 1)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryTrueClip, "DIACH3/DIA_CH3_HENRY_28", false));
		}
		else if (this.m_GearCount == 2)
		{
			this.m_LiftController.GoToRandomFloor();
		}
		else if (this.m_GearCount >= 3)
		{
			for (int i = 0; i < this.m_MissionCompleteClips.Length; i++)
			{
				AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_MissionCompleteClips[i], SubtitleConstants.DIA_CH3_ALICE_GEAR_END[i], true));
				if (i >= this.m_MissionCompleteClips.Length - 1)
				{
					audioObject.OnComplete += this.HandleMissionCompleteDialogueOnComplete;
				}
			}
			this.CollectAllGears();
		}
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x00047488 File Offset: 0x00045688
	private void CollectAllGears()
	{
		for (int i = 0; i < this.m_GearPanels.Count; i++)
		{
			this.m_GearPanels[i].DisableInteraction();
		}
		this.m_FinalLiftTrigger.SetActive(true);
		this.m_FinalLiftTrigger.OnEnter += this.HandleFinalLiftTriggerOnEnter;
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.SPARE_PARTS);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.GearTask.Status.IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.ActivateDropbox();
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x0004755C File Offset: 0x0004575C
	private void HandleEmptyGearPanelOnComplete(object sender, EventArgs e)
	{
		(sender as CH3GearPanel).OnComplete -= this.HandleEmptyGearPanelOnComplete;
		if (this.m_FalseCount == 0)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryFalseClip_01, "DIACH3/DIA_CH3_HENRY_26", false));
		}
		else if (this.m_FalseCount == 1)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryFalseClip_02, "DIACH3/DIA_CH3_HENRY_27", false));
		}
		this.m_FalseCount++;
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x000475E4 File Offset: 0x000457E4
	private void HandleMissionCompleteDialogueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleMissionCompleteDialogueOnComplete;
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_RETURN_TO_THE_ANGEL", "OBJECTIVES/CH3_OBJECTIVE_TASK_GEARS_COMPLETE_TIP", 4f, false, 0f));
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00047634 File Offset: 0x00045834
	private void HandleFinalLiftTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_FinalLiftTrigger.OnEnter -= this.HandleFinalLiftTriggerOnEnter;
		for (int i = 0; i < this.m_MissionEndClips.Length; i++)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_MissionEndClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_TASK_GEARS_LIFT[i], true));
		}
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x00047694 File Offset: 0x00045894
	private void ClearWarningDialogues()
	{
		if (this.m_InkDemonWarningTrigger)
		{
			this.m_InkDemonWarningTrigger.SetActive(false);
			this.m_InkDemonWarningTrigger.OnEnter -= this.HandleInkDemonWarningTriggerOnEnter;
		}
		if (this.m_BendyDontRunTrigger)
		{
			this.m_BendyDontRunTrigger.SetActive(false);
			this.m_BendyDontRunTrigger.OnEnter -= this.HandleBendyDontRunTriggerOnEnter;
		}
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x00047708 File Offset: 0x00045908
	protected override void OnDisposed()
	{
		this.ClearWarningDialogues();
		if (this.m_FinalLiftTrigger != null)
		{
			this.m_FinalLiftTrigger.Dispose();
		}
		this.m_Piper = null;
		this.m_MissionEndClips = null;
		this.m_BeginTaskClips = null;
		this.m_DontRunClips = null;
		this.m_TakeGearClip = null;
		this.m_AliceMissionIntroClip = null;
		this.m_HenryTrueClip = null;
		this.m_HenryFalseClip_01 = null;
		this.m_HenryFalseClip_02 = null;
		this.m_MissionCompleteClips = null;
		this.m_ObjectiveSprite = null;
		base.OnDisposed();
	}

	// Token: 0x040006A6 RID: 1702
	private const int GEAR_MAX = 3;

	// Token: 0x040006A7 RID: 1703
	private const int GEAR_ACTIVE = 2;

	// Token: 0x040006A8 RID: 1704
	[Header("<Controllers>")]
	[SerializeField]
	private CH3LiftController m_LiftController;

	// Token: 0x040006A9 RID: 1705
	[SerializeField]
	private CH3ProjectionistScareController m_ProjectionistScareController;

	// Token: 0x040006AA RID: 1706
	[Header("Spawner")]
	[SerializeField]
	private SpecialSpawnerNode m_PiperSpawner;

	// Token: 0x040006AB RID: 1707
	[SerializeField]
	private WaypointList m_RoamingList;

	// Token: 0x040006AC RID: 1708
	[Header("Puzzles")]
	[SerializeField]
	private List<CH3GearPanel> m_GearPanels;

	// Token: 0x040006AD RID: 1709
	[SerializeField]
	private List<CH3GearPanel> m_EmptyGearPanels;

	// Token: 0x040006AE RID: 1710
	[Header("Triggers")]
	[SerializeField]
	private EventTrigger m_FinalLiftTrigger;

	// Token: 0x040006AF RID: 1711
	[Header("Alice Angel Dialogue")]
	[SerializeField]
	private EventTrigger m_InkDemonWarningTrigger;

	// Token: 0x040006B0 RID: 1712
	[SerializeField]
	private EventTrigger m_BendyDontRunTrigger;

	// Token: 0x040006B1 RID: 1713
	private PiperAi m_Piper;

	// Token: 0x040006B2 RID: 1714
	private AudioClip[] m_MissionEndClips;

	// Token: 0x040006B3 RID: 1715
	private AudioClip[] m_BeginTaskClips;

	// Token: 0x040006B4 RID: 1716
	private AudioClip[] m_DontRunClips;

	// Token: 0x040006B5 RID: 1717
	private AudioClip m_TakeGearClip;

	// Token: 0x040006B6 RID: 1718
	private AudioClip m_AliceMissionIntroClip;

	// Token: 0x040006B7 RID: 1719
	private AudioClip m_HenryTrueClip;

	// Token: 0x040006B8 RID: 1720
	private AudioClip m_HenryFalseClip_01;

	// Token: 0x040006B9 RID: 1721
	private AudioClip m_HenryFalseClip_02;

	// Token: 0x040006BA RID: 1722
	private AudioClip[] m_MissionCompleteClips;

	// Token: 0x040006BB RID: 1723
	private int m_FalseCount;

	// Token: 0x040006BC RID: 1724
	private Sprite m_ObjectiveSprite;

	// Token: 0x040006BD RID: 1725
	private int m_GearCount;
}

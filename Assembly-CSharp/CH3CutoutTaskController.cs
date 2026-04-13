using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class CH3CutoutTaskController : CH3BaseTaskController
{
	// Token: 0x0600082B RID: 2091 RVA: 0x00045E28 File Offset: 0x00044028
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ObjectiveSprite = GameManager.Instance.AssetManager.GetAsset<Sprite>("UI/ObjectiveIcons/cutout_icon");
		this.m_BeginTaskClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/TaskCutoutStart/");
		this.m_MissionEndClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/TaskCutoutEnd/");
		this.m_CutoutMax = this.m_Cutouts.Count;
		base.SetWeapon(this.m_WeaponStationController.WeaponStation.m_Axe);
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x00045EA8 File Offset: 0x000440A8
	public override void Activate()
	{
		base.Activate();
		this.m_SearcherController.SetActive(true);
		this.m_GangsterController.SetActive(true);
		for (int i = 0; i < this.m_Cutouts.Count; i++)
		{
			Breakable breakable = this.m_Cutouts[i];
			if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Object[i].ID == i && GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Object[i].IsComplete)
			{
				breakable.Dispose();
			}
		}
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Status.IsComplete)
		{
			for (int j = 0; j < this.m_Cutouts.Count; j++)
			{
				Breakable breakable2 = this.m_Cutouts[j];
				if (breakable2)
				{
					breakable2.OnBroken += this.HandleCutoutOnBroken;
				}
			}
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ButcherGangTask.IsStarted)
		{
			this.GoToNextController();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Status.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Status.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x00046060 File Offset: 0x00044260
	private void GoToNextController()
	{
		for (int i = 0; i < this.m_Cutouts.Count; i++)
		{
			Breakable breakable = this.m_Cutouts[i];
			if (breakable)
			{
				breakable.Dispose();
			}
		}
		if (this.m_Weapon)
		{
			this.m_Weapon.Dispose();
		}
		base.SendOnComplete();
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x000460C8 File Offset: 0x000442C8
	private void InternalActivate()
	{
		this.m_WeaponStationController.Block();
		for (int i = 0; i < this.m_BeginTaskClips.Length; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_BeginTaskClips[i], SubtitleConstants.DIA_CH3_ALICE_CUTOUTS_START[i], true));
			if (i >= this.m_BeginTaskClips.Length - 1)
			{
				audioObject.OnComplete += this.HandleBeginDialogueOnComplete;
			}
		}
		this.m_Weapon.Interaction.SetActive(false);
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x0004614C File Offset: 0x0004434C
	private void ForceStart()
	{
		this.m_LiftController.GoToFloor(GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor, false, false);
		DOTween.Sequence().InsertCallback(0.1f, delegate
		{
			this.m_LiftController.ForceCloseLift();
		});
		this.UpdateObjective();
		this.GetWeapon();
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x000461A8 File Offset: 0x000443A8
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_RETURN_TO_THE_ANGEL", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT_COMPLETE_TIP", 0f, false, 0f));
		this.m_LiftController.GoToFloor(GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor, false, false);
		DOTween.Sequence().InsertCallback(0.1f, delegate
		{
			this.m_LiftController.ForceCloseLift();
		});
		this.m_BendyController.SetActive(true);
		this.GetWeapon();
		for (int i = 0; i < this.m_Cutouts.Count; i++)
		{
			Breakable breakable = this.m_Cutouts[i];
			if (breakable)
			{
				breakable.Dispose();
			}
		}
		base.ActivateDropbox();
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x00046274 File Offset: 0x00044474
	private void UpdateObjective()
	{
		ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT_START", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT_TIP", 0f, false, 0f);
		for (int i = 0; i < GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Object.Length; i++)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Object[i].IsComplete)
			{
				this.m_CutoutCount++;
			}
		}
		objectiveDataVO.AddItemCounter(this.m_ObjectiveSprite, this.m_CutoutMax - this.m_CutoutCount);
		GameManager.Instance.UpdateObjective(objectiveDataVO);
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x00046330 File Offset: 0x00044530
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

	// Token: 0x06000833 RID: 2099 RVA: 0x000463C4 File Offset: 0x000445C4
	protected override void BeginTask()
	{
		ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT_TIP", 4f, false, 0f);
		objectiveDataVO.AddItemCounter(this.m_ObjectiveSprite, this.m_CutoutMax);
		GameManager.Instance.ShowObjective(objectiveDataVO);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Status.IsStarted = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x00008D0B File Offset: 0x00006F0B
	private void HandleBeginDialogueOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT_START", string.Empty, 4f, false, 0f));
		base.EnableWeapon();
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0004646C File Offset: 0x0004466C
	private void HandleCutoutOnBroken(object sender, EventArgs e)
	{
		Breakable breakable = (Breakable)sender;
		breakable.OnBroken -= this.HandleCutoutOnBroken;
		int num = -1;
		if (this.m_Cutouts.Contains(breakable))
		{
			num = this.m_Cutouts.IndexOf(breakable);
			this.m_CutoutCount++;
			GameManager.Instance.CurrentObjective.ItemCounter--;
		}
		if (num > -1)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Object[num].IsComplete = true;
			GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
			if (this.m_CutoutCount == 6 || this.m_CutoutCount == 12)
			{
				GameManager.Instance.GameDataManager.Save(false, true);
			}
		}
		this.CheckStatus();
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x00046560 File Offset: 0x00044760
	private void CheckStatus()
	{
		if (this.m_CutoutCount == 2)
		{
			this.m_LiftController.GoToRandomFloor();
		}
		else if (this.m_CutoutCount >= this.m_CutoutMax)
		{
			this.m_LiftController.GoToRandomFloor();
			for (int i = 0; i < this.m_MissionEndClips.Length; i++)
			{
				AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_MissionEndClips[i], SubtitleConstants.DIA_CH3_ALICE_CUTOUTS_END[i], true));
				if (i >= this.m_MissionEndClips.Length - 1)
				{
					audioObject.OnComplete += this.HandleMissionEndClipsOnComplete;
				}
			}
			this.BreakAllCutouts();
		}
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x00046608 File Offset: 0x00044808
	private void BreakAllCutouts()
	{
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.ANGER_MANAGEMENT);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.CutoutTask.Status.IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00046684 File Offset: 0x00044884
	private void HandleMissionEndClipsOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_RETURN_TO_THE_ANGEL", "OBJECTIVES/CH3_OBJECTIVE_TASK_CUTOUT_COMPLETE_TIP", 4f, false, 0f));
		this.m_BendyController.GoToCutout();
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.ANGER_MANAGEMENT);
		base.ActivateDropbox();
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x00008D3C File Offset: 0x00006F3C
	protected override void OnDisposed()
	{
		this.m_ObjectiveSprite = null;
		this.m_MissionEndClips = null;
		this.m_BeginTaskClips = null;
		base.OnDisposed();
	}

	// Token: 0x0400069E RID: 1694
	[Header("<Controllers>")]
	[SerializeField]
	private CH3LiftController m_LiftController;

	// Token: 0x0400069F RID: 1695
	[Header("Task Objective")]
	[SerializeField]
	private List<Breakable> m_Cutouts;

	// Token: 0x040006A0 RID: 1696
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x040006A1 RID: 1697
	private int m_CutoutMax;

	// Token: 0x040006A2 RID: 1698
	private int m_CutoutCount;

	// Token: 0x040006A3 RID: 1699
	private Sprite m_ObjectiveSprite;

	// Token: 0x040006A4 RID: 1700
	private AudioClip[] m_MissionEndClips;

	// Token: 0x040006A5 RID: 1701
	private AudioClip[] m_BeginTaskClips;
}

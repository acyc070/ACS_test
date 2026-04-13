using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006C RID: 108
public class CH1CollectableController : BaseController
{
	// Token: 0x060003D2 RID: 978 RVA: 0x0002D024 File Offset: 0x0002B224
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_HenryClip04 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_04");
		this.m_HenryClip05 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_05");
		this.m_MainPowerTrigger.SetActive(false);
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			this.m_Pedestals[i].Initialize(this.m_Locations[i]);
		}
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete)
		{
			for (int j = 0; j < this.m_Pedestals.Count; j++)
			{
				if (!this.m_Pedestals[j].isComplete)
				{
					return;
				}
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete = true;
			GameManager.Instance.GameDataManager.Save(true, true);
		}
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0002D12C File Offset: 0x0002B32C
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Record.IsStarted)
		{
			this.m_SammysRoomController.ForceOpen();
		}
		else
		{
			this.m_SammysRoomController.Activate();
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x00005994 File Offset: 0x00003B94
	private void InternalActivate()
	{
		this.m_JumpscareController.Activate();
		this.m_MainPowerTrigger.OnEnter += this.HandleMainPowerTriggerOnEnter;
		this.m_MainPowerTrigger.SetActive(true);
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x0002D1DC File Offset: 0x0002B3DC
	private void ForceStart()
	{
		this.UpdateObjective(false);
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			CH1Pedestal ch1Pedestal = this.m_Pedestals[i];
			if (!ch1Pedestal.isCollected && !ch1Pedestal.isComplete)
			{
				ch1Pedestal.OnCollect += this.HandleCollectableOnCollect;
				ch1Pedestal.OnComplete += this.HandlePedestalOnComplete;
				ch1Pedestal.Activate();
			}
			else if (ch1Pedestal.isCollected && !ch1Pedestal.isComplete)
			{
				ch1Pedestal.OnComplete += this.HandlePedestalOnComplete;
				ch1Pedestal.Activate();
			}
		}
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x000059C4 File Offset: 0x00003BC4
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_04", "OBJECTIVES/CH1_OBJ_04_TIP", 4f, false, 0f));
		base.SendOnComplete();
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0002D28C File Offset: 0x0002B48C
	private void HandleMainPowerTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_MainPowerTrigger.OnEnter -= this.HandleMainPowerTriggerOnEnter;
		this.m_MainPowerTrigger.Dispose();
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsStarted = true;
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip04, "DIACH1/DIA_CH1_HENRY_04", false));
		audioObject.OnComplete += delegate(object _sender, EventArgs _e)
		{
			this.UpdateObjective(true);
		};
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			CH1Pedestal ch1Pedestal = this.m_Pedestals[i];
			ch1Pedestal.Activate();
			ch1Pedestal.OnCollect += this.HandleCollectableOnCollect;
			ch1Pedestal.OnComplete += this.HandlePedestalOnComplete;
		}
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0002D35C File Offset: 0x0002B55C
	private void UpdateObjective(bool isShow = false)
	{
		ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_03", "OBJECTIVES/CH1_OBJ_03_TIP", 4f, false, 0f);
		List<Sprite> list = new List<Sprite>();
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			list.Add(this.m_Pedestals[i].MenuSprite);
		}
		objectiveDataVO.AddItems(list);
		if (isShow)
		{
			GameManager.Instance.ShowObjective(objectiveDataVO);
		}
		else
		{
			GameManager.Instance.UpdateObjective(objectiveDataVO);
			for (int j = 0; j < this.m_Pedestals.Count; j++)
			{
				this.m_Pedestals[j].UpdateObjective();
			}
		}
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0002D418 File Offset: 0x0002B618
	private void HandleCollectableOnCollect(object sender, EventArgs e)
	{
		CH1Pedestal ch1Pedestal = (CH1Pedestal)sender;
		ch1Pedestal.OnCollect -= this.HandleCollectableOnCollect;
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			if (!this.m_Pedestals[i].isCollected)
			{
				return;
			}
		}
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip05, "DIACH1/DIA_CH1_HENRY_05", false));
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0002D490 File Offset: 0x0002B690
	private void HandlePedestalOnComplete(object sender, EventArgs e)
	{
		CH1Pedestal ch1Pedestal = sender as CH1Pedestal;
		if (ch1Pedestal == null)
		{
			return;
		}
		ch1Pedestal.OnComplete -= this.HandlePedestalOnComplete;
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			if (!this.m_Pedestals[i].isComplete)
			{
				return;
			}
		}
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.PICKING_UP_THE_PIECES);
		base.SendOnComplete();
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0002D50C File Offset: 0x0002B70C
	public void TurnOffLights()
	{
		for (int i = 0; i < this.m_Pedestals.Count; i++)
		{
			this.m_Pedestals[i].TurnLightOff();
		}
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0002D548 File Offset: 0x0002B748
	protected override void OnDisposed()
	{
		if (this.m_MainPowerTrigger)
		{
			this.m_MainPowerTrigger.OnEnter -= this.HandleMainPowerTriggerOnEnter;
		}
		if (this.m_Pedestals != null)
		{
			this.m_Pedestals.Clear();
			this.m_Pedestals = null;
		}
		this.m_HenryClip04 = null;
		this.m_HenryClip05 = null;
		base.OnDisposed();
	}

	// Token: 0x04000252 RID: 594
	[Header("<Controllers>")]
	[SerializeField]
	private CH1JumpScareController m_JumpscareController;

	// Token: 0x04000253 RID: 595
	[SerializeField]
	private CH1SammysRoomController m_SammysRoomController;

	// Token: 0x04000254 RID: 596
	[Header("Objectives")]
	[SerializeField]
	private EventTrigger m_MainPowerTrigger;

	// Token: 0x04000255 RID: 597
	[Header("Collectables")]
	[SerializeField]
	private List<CH1Pedestal> m_Pedestals;

	// Token: 0x04000256 RID: 598
	[SerializeField]
	private List<Transform> m_Locations;

	// Token: 0x04000257 RID: 599
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000258 RID: 600
	private AudioClip m_HenryClip04;

	// Token: 0x04000259 RID: 601
	private AudioClip m_HenryClip05;
}

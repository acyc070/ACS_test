using System;
using TMG.Core;

// Token: 0x02000246 RID: 582
public class AchievementManager : TMGAbstractDisposable
{
	// Token: 0x06001692 RID: 5778 RVA: 0x00002482 File Offset: 0x00000682
	private void InitializeStatAchievements()
	{
	}

	// Token: 0x06001693 RID: 5779 RVA: 0x00002482 File Offset: 0x00000682
	public void CheckAchievementsAgainstStatRequirements(StatName statUpdated)
	{
	}

	// Token: 0x06001694 RID: 5780 RVA: 0x00002482 File Offset: 0x00000682
	private void DebugOutAllStatProgress()
	{
	}

	// Token: 0x06001695 RID: 5781 RVA: 0x000124F9 File Offset: 0x000106F9
	private StatAchievement GetStatAchievementByStatName(StatName statName)
	{
		return null;
	}

	// Token: 0x06001696 RID: 5782 RVA: 0x000124FC File Offset: 0x000106FC
	public bool GetAchievement(AchievementName key)
	{
		return this.CanUseAchievements() && this.m_AchievementController.GetAchievement(key);
	}

	// Token: 0x06001697 RID: 5783 RVA: 0x00012514 File Offset: 0x00010714
	public void SetAchievement(AchievementName key)
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.SetAchievement(key);
		this.m_AchievementController.StoreStats();
	}

	// Token: 0x06001698 RID: 5784 RVA: 0x00012536 File Offset: 0x00010736
	public void ClearAchievement(AchievementName key)
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.ClearAchievement(key);
	}

	// Token: 0x06001699 RID: 5785 RVA: 0x0001254D File Offset: 0x0001074D
	public void GetStat(StatName name, out int? data)
	{
		if (!this.CanUseAchievements())
		{
			data = null;
			return;
		}
		this.m_AchievementController.GetStat(name, out data);
	}

	// Token: 0x0600169A RID: 5786 RVA: 0x0001256C File Offset: 0x0001076C
	public void GetStat(StatName name, out float? data)
	{
		if (!this.CanUseAchievements())
		{
			data = null;
			return;
		}
		this.m_AchievementController.GetStat(name, out data);
	}

	// Token: 0x0600169B RID: 5787 RVA: 0x00080A44 File Offset: 0x0007EC44
	public void SetStat(StatName name, int data)
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		StatAchievement statAchievementByStatName = this.GetStatAchievementByStatName(name);
		if (statAchievementByStatName != null)
		{
			statAchievementByStatName.CurrentValue = new int?(data);
		}
		this.m_AchievementController.SetStat(name, data);
	}

	// Token: 0x0600169C RID: 5788 RVA: 0x0001258B File Offset: 0x0001078B
	public void SetStat(StatName name, float data)
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.SetStat(name, data);
	}

	// Token: 0x0600169D RID: 5789 RVA: 0x000125A3 File Offset: 0x000107A3
	public void IncrementStatAchievement(StatName name)
	{
		this.CanUseAchievements();
	}

	// Token: 0x0600169E RID: 5790 RVA: 0x000125A3 File Offset: 0x000107A3
	public void IncrementStatByValue(StatName name, int incrementAmount)
	{
		this.CanUseAchievements();
	}

	// Token: 0x0600169F RID: 5791 RVA: 0x000125A3 File Offset: 0x000107A3
	public void SaveStatAchievement(StatName name)
	{
		this.CanUseAchievements();
	}

	// Token: 0x060016A0 RID: 5792 RVA: 0x000125AC File Offset: 0x000107AC
	public void IndicateProgress(AchievementName name, uint currentProgress, uint maxProgress)
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.IndicateProgress(name, currentProgress, maxProgress);
	}

	// Token: 0x060016A1 RID: 5793 RVA: 0x000125C5 File Offset: 0x000107C5
	public void StoreStats()
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.StoreStats();
	}

	// Token: 0x060016A2 RID: 5794 RVA: 0x000125DB File Offset: 0x000107DB
	public void ResetStats()
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.ResetStats();
		this.m_AchievementController.StoreStats();
	}

	// Token: 0x060016A3 RID: 5795 RVA: 0x000125FC File Offset: 0x000107FC
	public void ResetStatsAndAchievements()
	{
		if (!this.CanUseAchievements())
		{
			return;
		}
		this.m_AchievementController.ResetStatsAndAchievements();
		this.m_AchievementController.StoreStats();
	}

	// Token: 0x060016A4 RID: 5796 RVA: 0x0001261D File Offset: 0x0001081D
	public void SetAchievementUser(int id)
	{
		this.m_AchievementController.SetAchievementUser(id);
	}

	// Token: 0x060016A5 RID: 5797 RVA: 0x0001262B File Offset: 0x0001082B
	private bool CanUseAchievements()
	{
		return this.m_AchievementController != null && this.m_AchievementController.IsConnected();
	}

	// Token: 0x060016A6 RID: 5798 RVA: 0x00012642 File Offset: 0x00010842
	public void InitSteam()
	{
		this.m_AchievementIDs = new AchievementIDMapping[0];
		this.m_AchievementController = new SteamAchievements();
		if (this.m_AchievementController != null)
		{
			this.m_AchievementController.Initialize(this.m_AchievementIDs);
		}
	}

	// Token: 0x060016A7 RID: 5799 RVA: 0x00012674 File Offset: 0x00010874
	public void InitGOG()
	{
		this.m_AchievementIDs = new AchievementIDMapping[0];
		if (this.m_AchievementController != null)
		{
			this.m_AchievementController.Initialize(this.m_AchievementIDs);
		}
	}

	// Token: 0x060016A8 RID: 5800 RVA: 0x0001269B File Offset: 0x0001089B
	public void InitEpic()
	{
		this.m_AchievementIDs = new AchievementIDMapping[0];
		this.m_AchievementController = new EpicAchievements();
		if (this.m_AchievementController != null)
		{
			this.m_AchievementController.Initialize(this.m_AchievementIDs);
		}
	}

	// Token: 0x04001414 RID: 5140
	private IAchievements m_AchievementController;

	// Token: 0x04001415 RID: 5141
	private AchievementIDMapping[] m_AchievementIDs;
}

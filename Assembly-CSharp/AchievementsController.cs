using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

// Token: 0x02000173 RID: 371
public class AchievementsController : MonoBehaviour
{
	// Token: 0x1700009F RID: 159
	// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x0000D149 File Offset: 0x0000B349
	public static Dictionary<AchievementName, string> AchievementNames
	{
		get
		{
			return AchievementsController._AchievementNames;
		}
	}

	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x06000EFA RID: 3834 RVA: 0x0000D150 File Offset: 0x0000B350
	public static ReadOnlyCollection<StatAchievement> Stats
	{
		get
		{
			return AchievementsController._StatAchievements.AsReadOnly();
		}
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x00068D48 File Offset: 0x00066F48
	public static void Initialize()
	{
		AchievementIDMapping[] array = new AchievementIDMapping[0];
		AchievementsController._CurrentAchievementsController = new SteamAchievements();
		if (AchievementsController._CurrentAchievementsController != null)
		{
			AchievementsController._CurrentAchievementsController.Initialize(array);
		}
		AchievementsController.InitializeStatAchievements();
		AchievementsController.InitializeAchievementNames();
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x0000D15C File Offset: 0x0000B35C
	private void Awake()
	{
		AchievementsController.achievementMappers = base.gameObject.GetComponentsInChildren<AchievementMapper>();
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x00002482 File Offset: 0x00000682
	private void Start()
	{
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x0000D16E File Offset: 0x0000B36E
	private static void InitializeAchievementNames()
	{
		AchievementsController._AchievementNames = new Dictionary<AchievementName, string>();
		AchievementsController.Achievements = new List<Achievement>();
	}

	// Token: 0x06000EFF RID: 3839 RVA: 0x00068D88 File Offset: 0x00066F88
	public static void CheckAchievementsAgainstStatRequirements(StatName statUpdated)
	{
		StatAchievement statAchievementByStatName = AchievementsController.GetStatAchievementByStatName(statUpdated);
		foreach (ProgressAchievement progressAchievement in AchievementsController.Achievements.OfType<ProgressAchievement>())
		{
			if (progressAchievement.StatRequirement.Stat == statAchievementByStatName && statAchievementByStatName.CurrentValue >= progressAchievement.StatRequirement.MinimumRequirement)
			{
				Debug.Log("*AchievementController* Awarding achievement " + progressAchievement.DisplayName);
				AchievementsController._CurrentAchievementsController.SetAchievement(progressAchievement.AchievementName);
			}
		}
		AchievementsController.DebugOutAllStatProgress();
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x00068E54 File Offset: 0x00067054
	private static void DebugOutAllStatProgress()
	{
		foreach (ProgressAchievement progressAchievement in AchievementsController.Achievements.OfType<ProgressAchievement>())
		{
			StatAchievement statAchievementByStatName = AchievementsController.GetStatAchievementByStatName(progressAchievement.StatRequirement.Stat.StatKey);
			Debug.Log(string.Concat(new object[]
			{
				"*AchievementController* Checking achievement ",
				progressAchievement.DisplayName,
				" with stat requirement ",
				progressAchievement.StatRequirement.Stat.StatKey.ToString(),
				" and minimum req ",
				progressAchievement.StatRequirement.MinimumRequirement.ToString(),
				" current amount is ",
				statAchievementByStatName.CurrentValue
			}));
		}
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x00068F48 File Offset: 0x00067148
	private static StatAchievement GetStatAchievementByStatName(StatName statName)
	{
		return AchievementsController._StatAchievements.Find((StatAchievement statAchievement) => statAchievement.StatKey == statName);
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x00068F78 File Offset: 0x00067178
	private static void InitializeStatAchievements()
	{
		Debug.Log("Initializing stat achievements.");
		AchievementsController._StatAchievements = new List<StatAchievement>();
		foreach (StatAchievement statAchievement in AchievementsController._StatAchievements)
		{
		}
	}

	// Token: 0x06000F03 RID: 3843 RVA: 0x0000D184 File Offset: 0x0000B384
	public static bool GetAchievement(AchievementName key)
	{
		return AchievementsController.CanUseAchievements() && AchievementsController._CurrentAchievementsController.GetAchievement(key);
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x0000D19D File Offset: 0x0000B39D
	public static void SetAchievement(AchievementName key)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.SetAchievement(key);
		AchievementsController._CurrentAchievementsController.StoreStats();
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x0000D1BF File Offset: 0x0000B3BF
	public static void ClearAchievement(AchievementName key)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.ClearAchievement(key);
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x00068FE0 File Offset: 0x000671E0
	public static void GetStat(StatName name, out int? data)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			data = null;
			return;
		}
		AchievementsController._CurrentAchievementsController.GetStat(name, out data);
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x00069014 File Offset: 0x00067214
	public static void GetStat(StatName name, out float? data)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			data = null;
			return;
		}
		AchievementsController._CurrentAchievementsController.GetStat(name, out data);
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x00069048 File Offset: 0x00067248
	public static void SetStat(StatName name, int data)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			Debug.Log("AchievementController - cannot set achievement");
			return;
		}
		StatAchievement statAchievementByStatName = AchievementsController.GetStatAchievementByStatName(name);
		if (statAchievementByStatName != null)
		{
			Debug.Log(string.Concat(new object[] { "Got stat ", name, ", now setting it to ", data }));
			statAchievementByStatName.CurrentValue = new int?(data);
		}
		AchievementsController._CurrentAchievementsController.SetStat(name, data);
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x0000D1D7 File Offset: 0x0000B3D7
	public static void SetStat(StatName name, float data)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.SetStat(name, data);
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x000690C4 File Offset: 0x000672C4
	public static void IncrementStatAchievement(StatName name)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		Debug.Log("*Can save stat " + name + ". Now trying to find it in collection and increment.*");
		StatAchievement statAchievement = AchievementsController._StatAchievements.Find((StatAchievement achievement) => achievement.StatKey == name);
		statAchievement.IncrementStat();
	}

	// Token: 0x06000F0B RID: 3851 RVA: 0x00069128 File Offset: 0x00067328
	public static void IncrementStatByValue(StatName name, int incrementAmount)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		StatAchievement statAchievement = AchievementsController._StatAchievements.Find((StatAchievement achievement) => achievement.StatKey == name);
		statAchievement.IncrementStatByValue(incrementAmount);
	}

	// Token: 0x06000F0C RID: 3852 RVA: 0x0006916C File Offset: 0x0006736C
	public static void SaveStatAchievement(StatName name)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		StatAchievement statAchievement = AchievementsController._StatAchievements.Find((StatAchievement achievement) => achievement.StatKey == name);
		statAchievement.SaveStat();
	}

	// Token: 0x06000F0D RID: 3853 RVA: 0x0000D1F0 File Offset: 0x0000B3F0
	public static void IndicateProgress(AchievementName name, uint currentProgress, uint maxProgress)
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.IndicateProgress(name, currentProgress, maxProgress);
	}

	// Token: 0x06000F0E RID: 3854 RVA: 0x0000D20A File Offset: 0x0000B40A
	public static void StoreStats()
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.StoreStats();
	}

	// Token: 0x06000F0F RID: 3855 RVA: 0x0000D221 File Offset: 0x0000B421
	public static void ResetStats()
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.ResetStats();
		AchievementsController._CurrentAchievementsController.StoreStats();
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x0000D242 File Offset: 0x0000B442
	public static void ResetStatsAndAchievements()
	{
		if (!AchievementsController.CanUseAchievements())
		{
			return;
		}
		AchievementsController._CurrentAchievementsController.ResetStatsAndAchievements();
		AchievementsController._CurrentAchievementsController.StoreStats();
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x0000D263 File Offset: 0x0000B463
	public static void SetAchievementUser(int id)
	{
		AchievementsController._CurrentAchievementsController.SetAchievementUser(id);
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x0000D270 File Offset: 0x0000B470
	private static bool CanUseAchievements()
	{
		return false;
	}

	// Token: 0x04000CB3 RID: 3251
	private static IAchievements _CurrentAchievementsController;

	// Token: 0x04000CB4 RID: 3252
	private static List<Achievement> Achievements;

	// Token: 0x04000CB5 RID: 3253
	private static Dictionary<AchievementName, string> _AchievementNames;

	// Token: 0x04000CB6 RID: 3254
	private static List<StatAchievement> _StatAchievements;

	// Token: 0x04000CB7 RID: 3255
	private static AchievementMapper[] achievementMappers;
}

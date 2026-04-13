using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000178 RID: 376
public class AchievementsDebugHelper : MonoBehaviour
{
	// Token: 0x06000F1C RID: 3868 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
	private void OnGUI()
	{
		if (!this._ShowDebugInfo)
		{
			return;
		}
	}

	// Token: 0x06000F1D RID: 3869 RVA: 0x0000D2EE File Offset: 0x0000B4EE
	private void DrawAchievements()
	{
		if (this._IsShowingAchievements)
		{
			if (!this._IsShowingIndividualAchievement)
			{
				this.DrawAchievementButtons();
			}
			else
			{
				this.DrawIndividualAchievement();
			}
		}
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x000691B0 File Offset: 0x000673B0
	private void DrawAchievementButtons()
	{
		int num = this._DefaultXOffset;
		int num2 = 10;
		foreach (KeyValuePair<AchievementName, string> keyValuePair in AchievementsController.AchievementNames)
		{
			if (GUI.Button(new Rect((float)num, (float)num2, 130f, (float)this._ButtonHeight), keyValuePair.Value))
			{
				this._IsShowingIndividualAchievement = true;
				this._CurrentAchievementShowing = keyValuePair;
			}
			num += this._DefaultXOffset;
			if (num > 600)
			{
				num = this._DefaultXOffset;
				num2 += 40;
			}
		}
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x00069264 File Offset: 0x00067464
	private void DrawIndividualAchievement()
	{
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 10f, 130f, (float)this._ButtonHeight), this._CurrentAchievementShowing.Value))
		{
			this._IsShowingIndividualAchievement = false;
			this._AchievementStatus = string.Empty;
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 60f, 200f, (float)this._ButtonHeight), "Unlock Achievement"))
		{
			AchievementsController.SetAchievement(this._CurrentAchievementShowing.Key);
			this._AchievementStatus = "Achievement Status: Successfully got an achievement!";
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 100f, 200f, (float)this._ButtonHeight), "Clear Achievement"))
		{
			AchievementsController.ClearAchievement(this._CurrentAchievementShowing.Key);
			this._AchievementStatus = "Achievement Status: Successfully cleared an achievement!";
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 140f, 200f, (float)this._ButtonHeight), "Check Achievement"))
		{
			bool achievement = AchievementsController.GetAchievement(this._CurrentAchievementShowing.Key);
			if (achievement)
			{
				this._AchievementStatus = "Achievement Status: achievement is unlocked!";
			}
			else
			{
				this._AchievementStatus = "Achievement Status: achievement is locked!";
			}
		}
		GUI.Label(new Rect((float)this._DefaultXOffset, 170f, 500f, 20f), this._AchievementStatus);
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0000D317 File Offset: 0x0000B517
	private void DrawStats()
	{
		if (this._IsShowingStats)
		{
			if (this._IsShowingIndividualStat)
			{
				this.DrawIndividualStat();
			}
			else
			{
				this.DrawStatsButtons();
			}
		}
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x000693C8 File Offset: 0x000675C8
	private void DrawStatsButtons()
	{
		int num = this._DefaultXOffset;
		int num2 = 10;
		foreach (StatAchievement statAchievement in AchievementsController.Stats)
		{
			if (GUI.Button(new Rect((float)num, (float)num2, 130f, (float)this._ButtonHeight), statAchievement.StatKey.ToString()))
			{
				this._IsShowingIndividualStat = true;
				this._CurrentStatName = statAchievement.StatKey;
				AchievementsController.GetStat(this._CurrentStatName, out this._CurrentStatValue);
			}
			num += this._DefaultXOffset;
			if (num > 600)
			{
				num = this._DefaultXOffset;
				num2 += 40;
			}
		}
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x0006949C File Offset: 0x0006769C
	private void DrawIndividualStat()
	{
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 10f, 130f, (float)this._ButtonHeight), this._CurrentStatName.ToString()))
		{
			this._IsShowingIndividualStat = false;
		}
		if (this._CurrentStatValue != null)
		{
			GUI.Label(new Rect((float)(this._DefaultXOffset * 2), 10f, 250f, (float)(this._ButtonHeight * 2)), this._CurrentStatValue.ToString());
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 60f, 60f, (float)this._ButtonHeight), "+1"))
		{
			int? currentStatValue = this._CurrentStatValue;
			this._CurrentStatValue = ((currentStatValue == null) ? null : new int?(currentStatValue.GetValueOrDefault() + 1));
			AchievementsController.IncrementStatByValue(this._CurrentStatName, 1);
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 110f, 60f, (float)this._ButtonHeight), "+10"))
		{
			int? currentStatValue2 = this._CurrentStatValue;
			this._CurrentStatValue = ((currentStatValue2 == null) ? null : new int?(currentStatValue2.GetValueOrDefault() + 10));
			AchievementsController.IncrementStatByValue(this._CurrentStatName, 10);
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 160f, 60f, (float)this._ButtonHeight), "+100"))
		{
			int? currentStatValue3 = this._CurrentStatValue;
			this._CurrentStatValue = ((currentStatValue3 == null) ? null : new int?(currentStatValue3.GetValueOrDefault() + 100));
			AchievementsController.IncrementStatByValue(this._CurrentStatName, 100);
		}
		if (GUI.Button(new Rect((float)this._DefaultXOffset, 210f, 60f, (float)this._ButtonHeight), "+1,000"))
		{
			int? currentStatValue4 = this._CurrentStatValue;
			this._CurrentStatValue = ((currentStatValue4 == null) ? null : new int?(currentStatValue4.GetValueOrDefault() + 1000));
			AchievementsController.IncrementStatByValue(this._CurrentStatName, 1000);
		}
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x000696E4 File Offset: 0x000678E4
	private void DrawHideShowAchievementButton()
	{
		if (GUI.Button(new Rect(10f, 10f, 130f, (float)this._ButtonHeight), (!this._IsShowingAchievements) ? "Show Achievements" : "Hide Achievements"))
		{
			this._IsShowingAchievements = !this._IsShowingAchievements;
			if (!this._IsShowingAchievements)
			{
				this._IsShowingIndividualAchievement = false;
			}
			this._IsShowingIndividualStat = false;
			this._IsShowingStats = false;
		}
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x00069760 File Offset: 0x00067960
	private void DrawShowHideStatButton()
	{
		if (GUI.Button(new Rect(10f, 50f, 130f, (float)this._ButtonHeight), (!this._IsShowingStats) ? "Show Stats" : "Hide Stats"))
		{
			this._IsShowingStats = !this._IsShowingStats;
			if (!this._IsShowingStats)
			{
				this._IsShowingIndividualAchievement = false;
			}
			this._IsShowingAchievements = false;
			this._IsShowingIndividualStat = false;
		}
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x000697DC File Offset: 0x000679DC
	private void DrawResetButtons()
	{
		if (GUI.Button(new Rect(10f, 90f, 130f, (float)this._ButtonHeight), "Reset Stats"))
		{
			AchievementsController.ResetStats();
		}
		if (GUI.Button(new Rect(10f, 130f, 130f, (float)this._ButtonHeight), "Reset Achievements"))
		{
			foreach (KeyValuePair<AchievementName, string> keyValuePair in AchievementsController.AchievementNames)
			{
				AchievementsController.ClearAchievement(keyValuePair.Key);
			}
			AchievementsController.StoreStats();
		}
		if (GUI.Button(new Rect(10f, 170f, 130f, (float)this._ButtonHeight), "Clear All Level Times"))
		{
		}
		if (GUI.Button(new Rect(10f, 200f, 130f, (float)this._ButtonHeight), "Clear All PlayerPrefs"))
		{
			PlayerPrefs.DeleteAll();
		}
	}

	// Token: 0x04000CBC RID: 3260
	[SerializeField]
	private bool _ShowDebugInfo = true;

	// Token: 0x04000CBD RID: 3261
	private bool _IsShowingAchievements;

	// Token: 0x04000CBE RID: 3262
	private bool _IsShowingIndividualAchievement;

	// Token: 0x04000CBF RID: 3263
	private bool _IsShowingStats;

	// Token: 0x04000CC0 RID: 3264
	private bool _IsShowingIndividualStat;

	// Token: 0x04000CC1 RID: 3265
	private string _AchievementStatus = string.Empty;

	// Token: 0x04000CC2 RID: 3266
	private int? _CurrentStatValue;

	// Token: 0x04000CC3 RID: 3267
	private int _DefaultXOffset = 150;

	// Token: 0x04000CC4 RID: 3268
	private int _ButtonHeight = 30;

	// Token: 0x04000CC5 RID: 3269
	private KeyValuePair<AchievementName, string> _CurrentAchievementShowing;

	// Token: 0x04000CC6 RID: 3270
	private StatName _CurrentStatName;
}

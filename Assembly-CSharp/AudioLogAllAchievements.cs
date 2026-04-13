using System;

// Token: 0x020001C6 RID: 454
public static class AudioLogAllAchievements
{
	// Token: 0x0600136A RID: 4970 RVA: 0x00076EBC File Offset: 0x000750BC
	public static void Check()
	{
		if (GameManager.Instance.AchievementManager.GetAchievement(AchievementName.THE_PAST_SPEAKS) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.OLD_PROBLEMS) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.HEARING_VOICES) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.STILL_LISTENING) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.NOW_HEAR_THIS))
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.THE_VOICE_COLLECTOR);
		}
	}
}

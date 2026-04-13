using System;

// Token: 0x02000170 RID: 368
[Serializable]
public class AchievementIDMapping
{
	// Token: 0x06000EF5 RID: 3829 RVA: 0x0000D126 File Offset: 0x0000B326
	public AchievementIDMapping(int id, AchievementName name)
	{
		this.AchievementID = id;
		this.AchievementName = name;
	}

	// Token: 0x04000C72 RID: 3186
	public AchievementName AchievementName;

	// Token: 0x04000C73 RID: 3187
	public int AchievementID;
}

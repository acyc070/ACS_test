using System;

// Token: 0x0200016F RID: 367
public class Achievement
{
	// Token: 0x06000EEF RID: 3823 RVA: 0x0000D0E7 File Offset: 0x0000B2E7
	public Achievement(int id, AchievementName name, string displayName)
	{
		this.ID = id;
		this.AchievementName = name;
		this.DisplayName = displayName;
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x000026AE File Offset: 0x000008AE
	public Achievement()
	{
	}

	// Token: 0x1700009C RID: 156
	// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0000D104 File Offset: 0x0000B304
	// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x0000D10C File Offset: 0x0000B30C
	public AchievementName AchievementName { get; private set; }

	// Token: 0x1700009D RID: 157
	// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x0000D115 File Offset: 0x0000B315
	// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x0000D11D File Offset: 0x0000B31D
	public string DisplayName { get; private set; }

	// Token: 0x04000C6F RID: 3183
	public int ID;
}

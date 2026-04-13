using System;

namespace TMG.Data
{
	// Token: 0x020001FB RID: 507
	[Serializable]
	public class GameData
	{
		// Token: 0x04001265 RID: 4709
		private const int SAVE_FILE_COUNT = 3;

		// Token: 0x04001266 RID: 4710
		public SaveFileData[] SaveFiles = new SaveFileData[3];

		// Token: 0x04001267 RID: 4711
		public SaveFileData CurrentSaveFile;

		// Token: 0x04001268 RID: 4712
		public SaveFileData NoSaveFile;

		// Token: 0x04001269 RID: 4713
		public AchievementSaveData CH1AchievementData = new AchievementSaveData();

		// Token: 0x0400126A RID: 4714
		public AchievementSaveData CH2AchievementData = new AchievementSaveData();

		// Token: 0x0400126B RID: 4715
		public AchievementSaveData CH3AchievementData = new AchievementSaveData();

		// Token: 0x0400126C RID: 4716
		public AchievementSaveData CH4AchievementData = new AchievementSaveData();

		// Token: 0x0400126D RID: 4717
		public AchievementSaveData CH5AchievementData = new AchievementSaveData();

		// Token: 0x0400126E RID: 4718
		public int ContinueIndex;

		// Token: 0x0400126F RID: 4719
		public bool HasChapter02;

		// Token: 0x04001270 RID: 4720
		public bool HasChapter03;

		// Token: 0x04001271 RID: 4721
		public bool HasChapter04;

		// Token: 0x04001272 RID: 4722
		public bool HasChapter05;
	}
}

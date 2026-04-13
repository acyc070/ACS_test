using System;

namespace TMG.Data
{
	// Token: 0x020001FC RID: 508
	[Serializable]
	public class SaveFileData
	{
		// Token: 0x060014B0 RID: 5296 RVA: 0x00010F84 File Offset: 0x0000F184
		public SaveFileData(int id)
		{
			this.ID = id;
		}

		// Token: 0x04001273 RID: 4723
		public int ID;

		// Token: 0x04001274 RID: 4724
		public int CurrentChapter;

		// Token: 0x04001275 RID: 4725
		public bool HasDied;

		// Token: 0x04001276 RID: 4726
		public float PlayTime;

		// Token: 0x04001277 RID: 4727
		public bool IsNewGamePlus;

		// Token: 0x04001278 RID: 4728
		public int CompleteCount;

		// Token: 0x04001279 RID: 4729
		public int[] Internecions = new int[5];

		// Token: 0x0400127A RID: 4730
		public string Internecion = string.Empty;

		// Token: 0x0400127B RID: 4731
		public CH1DataVO CH1Data;

		// Token: 0x0400127C RID: 4732
		public CH2DataVO CH2Data;

		// Token: 0x0400127D RID: 4733
		public CH3DataVO CH3Data;

		// Token: 0x0400127E RID: 4734
		public CH4DataVO CH4Data;

		// Token: 0x0400127F RID: 4735
		public CH5DataVO CH5Data;
	}
}

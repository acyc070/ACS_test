using System;

namespace TMPro
{
	// Token: 0x02000645 RID: 1605
	[Serializable]
	public class KerningPair
	{
		// Token: 0x06002D88 RID: 11656 RVA: 0x00020A62 File Offset: 0x0001EC62
		public KerningPair(int left, int right, float offset)
		{
			this.AscII_Left = left;
			this.AscII_Right = right;
			this.XadvanceOffset = offset;
		}

		// Token: 0x040031B1 RID: 12721
		public int AscII_Left;

		// Token: 0x040031B2 RID: 12722
		public int AscII_Right;

		// Token: 0x040031B3 RID: 12723
		public float XadvanceOffset;
	}
}

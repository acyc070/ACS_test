using System;

namespace TMPro
{
	// Token: 0x02000635 RID: 1589
	public struct CaretInfo
	{
		// Token: 0x06002D35 RID: 11573 RVA: 0x00020735 File Offset: 0x0001E935
		public CaretInfo(int index, CaretPosition position)
		{
			this.index = index;
			this.position = position;
		}

		// Token: 0x0400315E RID: 12638
		public int index;

		// Token: 0x0400315F RID: 12639
		public CaretPosition position;
	}
}

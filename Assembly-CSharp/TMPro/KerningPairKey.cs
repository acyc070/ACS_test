using System;

namespace TMPro
{
	// Token: 0x02000644 RID: 1604
	public struct KerningPairKey
	{
		// Token: 0x06002D87 RID: 11655 RVA: 0x00020A46 File Offset: 0x0001EC46
		public KerningPairKey(int ascii_left, int ascii_right)
		{
			this.ascii_Left = ascii_left;
			this.ascii_Right = ascii_right;
			this.key = (ascii_right << 16) + ascii_left;
		}

		// Token: 0x040031AE RID: 12718
		public int ascii_Left;

		// Token: 0x040031AF RID: 12719
		public int ascii_Right;

		// Token: 0x040031B0 RID: 12720
		public int key;
	}
}

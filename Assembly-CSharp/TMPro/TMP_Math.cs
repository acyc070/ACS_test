using System;

namespace TMPro
{
	// Token: 0x0200063F RID: 1599
	public static class TMP_Math
	{
		// Token: 0x06002D82 RID: 11650 RVA: 0x00020A2A File Offset: 0x0001EC2A
		public static bool Approximately(float a, float b)
		{
			return b - 0.0001f < a && a < b + 0.0001f;
		}

		// Token: 0x04003183 RID: 12675
		public const float FLOAT_MAX = 32768f;

		// Token: 0x04003184 RID: 12676
		public const float FLOAT_MIN = -32768f;

		// Token: 0x04003185 RID: 12677
		public const int INT_MAX = 2147483647;

		// Token: 0x04003186 RID: 12678
		public const int INT_MIN = -2147483647;
	}
}

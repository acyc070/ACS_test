using System;

namespace TMPro
{
	// Token: 0x020005F0 RID: 1520
	internal interface ITweenValue
	{
		// Token: 0x06002A5C RID: 10844
		void TweenValue(float floatPercentage);

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06002A5D RID: 10845
		bool ignoreTimeScale { get; }

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06002A5E RID: 10846
		float duration { get; }

		// Token: 0x06002A5F RID: 10847
		bool ValidTarget();
	}
}

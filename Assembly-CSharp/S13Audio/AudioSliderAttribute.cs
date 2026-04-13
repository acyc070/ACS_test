using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000003 RID: 3
	public class AudioSliderAttribute : PropertyAttribute
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002378 File Offset: 0x00000578
		public AudioSliderAttribute(string label, float minValue, float maxValue)
		{
			this.label = label;
			this.minFloatValue = minValue;
			this.maxFloatValue = maxValue;
			this.propertyType = PropertyType.Float;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000239C File Offset: 0x0000059C
		public AudioSliderAttribute(string label, int minValue, int maxValue)
		{
			this.label = label;
			this.minIntValue = minValue;
			this.maxIntValue = maxValue;
			this.propertyType = PropertyType.Int;
		}

		// Token: 0x04000004 RID: 4
		public readonly string label;

		// Token: 0x04000005 RID: 5
		public readonly float minFloatValue;

		// Token: 0x04000006 RID: 6
		public readonly float maxFloatValue;

		// Token: 0x04000007 RID: 7
		public readonly int minIntValue;

		// Token: 0x04000008 RID: 8
		public readonly int maxIntValue;

		// Token: 0x04000009 RID: 9
		public readonly PropertyType propertyType;
	}
}

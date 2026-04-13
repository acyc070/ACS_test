using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000004 RID: 4
	public class AudioFieldAttribute : PropertyAttribute
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000023C0 File Offset: 0x000005C0
		public AudioFieldAttribute(string label, float minValue, float maxValue)
		{
			this.label = label;
			this.minFloatValue = minValue;
			this.maxFloatValue = maxValue;
			this.propertyType = PropertyType.Float;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000023E4 File Offset: 0x000005E4
		public AudioFieldAttribute(string label, int minValue, int maxValue)
		{
			this.label = label;
			this.minIntValue = minValue;
			this.maxIntValue = maxValue;
			this.propertyType = PropertyType.Int;
		}

		// Token: 0x0400000A RID: 10
		public readonly string label;

		// Token: 0x0400000B RID: 11
		public readonly float minFloatValue;

		// Token: 0x0400000C RID: 12
		public readonly float maxFloatValue;

		// Token: 0x0400000D RID: 13
		public readonly int minIntValue;

		// Token: 0x0400000E RID: 14
		public readonly int maxIntValue;

		// Token: 0x0400000F RID: 15
		public readonly PropertyType propertyType;
	}
}

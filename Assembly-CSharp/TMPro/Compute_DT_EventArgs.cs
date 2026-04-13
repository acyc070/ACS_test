using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200063D RID: 1597
	public class Compute_DT_EventArgs
	{
		// Token: 0x06002D75 RID: 11637 RVA: 0x00020988 File Offset: 0x0001EB88
		public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, float progress)
		{
			this.EventType = type;
			this.ProgressPercentage = progress;
		}

		// Token: 0x06002D76 RID: 11638 RVA: 0x0002099E File Offset: 0x0001EB9E
		public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, Color[] colors)
		{
			this.EventType = type;
			this.Colors = colors;
		}

		// Token: 0x04003180 RID: 12672
		public Compute_DistanceTransform_EventTypes EventType;

		// Token: 0x04003181 RID: 12673
		public float ProgressPercentage;

		// Token: 0x04003182 RID: 12674
		public Color[] Colors;
	}
}

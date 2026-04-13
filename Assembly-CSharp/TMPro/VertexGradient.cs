using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200064C RID: 1612
	[Serializable]
	public struct VertexGradient
	{
		// Token: 0x06002D95 RID: 11669 RVA: 0x00020AF8 File Offset: 0x0001ECF8
		public VertexGradient(Color color)
		{
			this.topLeft = color;
			this.topRight = color;
			this.bottomLeft = color;
			this.bottomRight = color;
		}

		// Token: 0x06002D96 RID: 11670 RVA: 0x00020B16 File Offset: 0x0001ED16
		public VertexGradient(Color color0, Color color1, Color color2, Color color3)
		{
			this.topLeft = color0;
			this.topRight = color1;
			this.bottomLeft = color2;
			this.bottomRight = color3;
		}

		// Token: 0x040031E8 RID: 12776
		public Color topLeft;

		// Token: 0x040031E9 RID: 12777
		public Color topRight;

		// Token: 0x040031EA RID: 12778
		public Color bottomLeft;

		// Token: 0x040031EB RID: 12779
		public Color bottomRight;
	}
}

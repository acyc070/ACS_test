using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x020005ED RID: 1517
	[Serializable]
	public class TMP_ColorGradient : ScriptableObject
	{
		// Token: 0x06002A59 RID: 10841 RVA: 0x000FF708 File Offset: 0x000FD908
		public TMP_ColorGradient()
		{
			Color white = Color.white;
			this.topLeft = white;
			this.topRight = white;
			this.bottomLeft = white;
			this.bottomRight = white;
		}

		// Token: 0x06002A5A RID: 10842 RVA: 0x0001E607 File Offset: 0x0001C807
		public TMP_ColorGradient(Color color)
		{
			this.topLeft = color;
			this.topRight = color;
			this.bottomLeft = color;
			this.bottomRight = color;
		}

		// Token: 0x06002A5B RID: 10843 RVA: 0x0001E62B File Offset: 0x0001C82B
		public TMP_ColorGradient(Color color0, Color color1, Color color2, Color color3)
		{
			this.topLeft = color0;
			this.topRight = color1;
			this.bottomLeft = color2;
			this.bottomRight = color3;
		}

		// Token: 0x04002EF0 RID: 12016
		public Color topLeft;

		// Token: 0x04002EF1 RID: 12017
		public Color topRight;

		// Token: 0x04002EF2 RID: 12018
		public Color bottomLeft;

		// Token: 0x04002EF3 RID: 12019
		public Color bottomRight;
	}
}

using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000651 RID: 1617
	public struct Extents
	{
		// Token: 0x06002D9B RID: 11675 RVA: 0x00020B60 File Offset: 0x0001ED60
		public Extents(Vector2 min, Vector2 max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x06002D9C RID: 11676 RVA: 0x001127C0 File Offset: 0x001109C0
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Min (",
				this.min.x.ToString("f2"),
				", ",
				this.min.y.ToString("f2"),
				")   Max (",
				this.max.x.ToString("f2"),
				", ",
				this.max.y.ToString("f2"),
				")"
			});
		}

		// Token: 0x040031FF RID: 12799
		public Vector2 min;

		// Token: 0x04003200 RID: 12800
		public Vector2 max;
	}
}

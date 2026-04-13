using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000652 RID: 1618
	[Serializable]
	public struct Mesh_Extents
	{
		// Token: 0x06002D9D RID: 11677 RVA: 0x00020B70 File Offset: 0x0001ED70
		public Mesh_Extents(Vector2 min, Vector2 max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x06002D9E RID: 11678 RVA: 0x00112864 File Offset: 0x00110A64
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

		// Token: 0x04003201 RID: 12801
		public Vector2 min;

		// Token: 0x04003202 RID: 12802
		public Vector2 max;
	}
}

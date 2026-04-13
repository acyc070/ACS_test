using System;
using UnityEngine;

namespace XInputDotNetPure
{
	// Token: 0x02000589 RID: 1417
	public struct GamePadThumbSticks
	{
		// Token: 0x060027AD RID: 10157 RVA: 0x0001C71D File Offset: 0x0001A91D
		internal GamePadThumbSticks(GamePadThumbSticks.StickValue left, GamePadThumbSticks.StickValue right)
		{
			this.left = left;
			this.right = right;
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060027AE RID: 10158 RVA: 0x0001C72D File Offset: 0x0001A92D
		public GamePadThumbSticks.StickValue Left
		{
			get
			{
				return this.left;
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060027AF RID: 10159 RVA: 0x0001C735 File Offset: 0x0001A935
		public GamePadThumbSticks.StickValue Right
		{
			get
			{
				return this.right;
			}
		}

		// Token: 0x04001F91 RID: 8081
		private GamePadThumbSticks.StickValue left;

		// Token: 0x04001F92 RID: 8082
		private GamePadThumbSticks.StickValue right;

		// Token: 0x0200058A RID: 1418
		public struct StickValue
		{
			// Token: 0x060027B0 RID: 10160 RVA: 0x0001C73D File Offset: 0x0001A93D
			internal StickValue(float x, float y)
			{
				this.vector = new Vector2(x, y);
			}

			// Token: 0x170003B3 RID: 947
			// (get) Token: 0x060027B1 RID: 10161 RVA: 0x0001C74C File Offset: 0x0001A94C
			public float X
			{
				get
				{
					return this.vector.x;
				}
			}

			// Token: 0x170003B4 RID: 948
			// (get) Token: 0x060027B2 RID: 10162 RVA: 0x0001C759 File Offset: 0x0001A959
			public float Y
			{
				get
				{
					return this.vector.y;
				}
			}

			// Token: 0x170003B5 RID: 949
			// (get) Token: 0x060027B3 RID: 10163 RVA: 0x0001C766 File Offset: 0x0001A966
			public Vector2 Vector
			{
				get
				{
					return this.vector;
				}
			}

			// Token: 0x04001F93 RID: 8083
			private Vector2 vector;
		}
	}
}

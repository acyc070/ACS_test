using System;

namespace XInputDotNetPure
{
	// Token: 0x0200058B RID: 1419
	public struct GamePadTriggers
	{
		// Token: 0x060027B4 RID: 10164 RVA: 0x0001C76E File Offset: 0x0001A96E
		internal GamePadTriggers(float left, float right)
		{
			this.left = left;
			this.right = right;
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060027B5 RID: 10165 RVA: 0x0001C77E File Offset: 0x0001A97E
		public float Left
		{
			get
			{
				return this.left;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060027B6 RID: 10166 RVA: 0x0001C786 File Offset: 0x0001A986
		public float Right
		{
			get
			{
				return this.right;
			}
		}

		// Token: 0x04001F94 RID: 8084
		private float left;

		// Token: 0x04001F95 RID: 8085
		private float right;
	}
}

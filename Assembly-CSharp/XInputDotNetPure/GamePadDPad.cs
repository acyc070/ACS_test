using System;

namespace XInputDotNetPure
{
	// Token: 0x02000588 RID: 1416
	public struct GamePadDPad
	{
		// Token: 0x060027A8 RID: 10152 RVA: 0x0001C6DE File Offset: 0x0001A8DE
		internal GamePadDPad(ButtonState up, ButtonState down, ButtonState left, ButtonState right)
		{
			this.up = up;
			this.down = down;
			this.left = left;
			this.right = right;
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060027A9 RID: 10153 RVA: 0x0001C6FD File Offset: 0x0001A8FD
		public ButtonState Up
		{
			get
			{
				return this.up;
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x060027AA RID: 10154 RVA: 0x0001C705 File Offset: 0x0001A905
		public ButtonState Down
		{
			get
			{
				return this.down;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x060027AB RID: 10155 RVA: 0x0001C70D File Offset: 0x0001A90D
		public ButtonState Left
		{
			get
			{
				return this.left;
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060027AC RID: 10156 RVA: 0x0001C715 File Offset: 0x0001A915
		public ButtonState Right
		{
			get
			{
				return this.right;
			}
		}

		// Token: 0x04001F8D RID: 8077
		private ButtonState up;

		// Token: 0x04001F8E RID: 8078
		private ButtonState down;

		// Token: 0x04001F8F RID: 8079
		private ButtonState left;

		// Token: 0x04001F90 RID: 8080
		private ButtonState right;
	}
}

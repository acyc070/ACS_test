using System;

namespace XInputDotNetPure
{
	// Token: 0x02000587 RID: 1415
	public struct GamePadButtons
	{
		// Token: 0x0600279D RID: 10141 RVA: 0x000E650C File Offset: 0x000E470C
		internal GamePadButtons(ButtonState start, ButtonState back, ButtonState leftStick, ButtonState rightStick, ButtonState leftShoulder, ButtonState rightShoulder, ButtonState a, ButtonState b, ButtonState x, ButtonState y)
		{
			this.start = start;
			this.back = back;
			this.leftStick = leftStick;
			this.rightStick = rightStick;
			this.leftShoulder = leftShoulder;
			this.rightShoulder = rightShoulder;
			this.a = a;
			this.b = b;
			this.x = x;
			this.y = y;
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x0600279E RID: 10142 RVA: 0x0001C68E File Offset: 0x0001A88E
		public ButtonState Start
		{
			get
			{
				return this.start;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x0600279F RID: 10143 RVA: 0x0001C696 File Offset: 0x0001A896
		public ButtonState Back
		{
			get
			{
				return this.back;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060027A0 RID: 10144 RVA: 0x0001C69E File Offset: 0x0001A89E
		public ButtonState LeftStick
		{
			get
			{
				return this.leftStick;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060027A1 RID: 10145 RVA: 0x0001C6A6 File Offset: 0x0001A8A6
		public ButtonState RightStick
		{
			get
			{
				return this.rightStick;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060027A2 RID: 10146 RVA: 0x0001C6AE File Offset: 0x0001A8AE
		public ButtonState LeftShoulder
		{
			get
			{
				return this.leftShoulder;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060027A3 RID: 10147 RVA: 0x0001C6B6 File Offset: 0x0001A8B6
		public ButtonState RightShoulder
		{
			get
			{
				return this.rightShoulder;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x060027A4 RID: 10148 RVA: 0x0001C6BE File Offset: 0x0001A8BE
		public ButtonState A
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x060027A5 RID: 10149 RVA: 0x0001C6C6 File Offset: 0x0001A8C6
		public ButtonState B
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060027A6 RID: 10150 RVA: 0x0001C6CE File Offset: 0x0001A8CE
		public ButtonState X
		{
			get
			{
				return this.x;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x060027A7 RID: 10151 RVA: 0x0001C6D6 File Offset: 0x0001A8D6
		public ButtonState Y
		{
			get
			{
				return this.y;
			}
		}

		// Token: 0x04001F83 RID: 8067
		private ButtonState start;

		// Token: 0x04001F84 RID: 8068
		private ButtonState back;

		// Token: 0x04001F85 RID: 8069
		private ButtonState leftStick;

		// Token: 0x04001F86 RID: 8070
		private ButtonState rightStick;

		// Token: 0x04001F87 RID: 8071
		private ButtonState leftShoulder;

		// Token: 0x04001F88 RID: 8072
		private ButtonState rightShoulder;

		// Token: 0x04001F89 RID: 8073
		private ButtonState a;

		// Token: 0x04001F8A RID: 8074
		private ButtonState b;

		// Token: 0x04001F8B RID: 8075
		private ButtonState x;

		// Token: 0x04001F8C RID: 8076
		private ButtonState y;
	}
}

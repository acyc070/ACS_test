using System;

namespace XInputDotNetPure
{
	// Token: 0x0200058C RID: 1420
	public struct GamePadState
	{
		// Token: 0x060027B7 RID: 10167 RVA: 0x000E6568 File Offset: 0x000E4768
		internal GamePadState(bool isConnected, GamePadState.RawState rawState)
		{
			this.isConnected = isConnected;
			if (!isConnected)
			{
				rawState.dwPacketNumber = 0U;
				rawState.Gamepad.dwButtons = 0;
				rawState.Gamepad.bLeftTrigger = 0;
				rawState.Gamepad.bRightTrigger = 0;
				rawState.Gamepad.sThumbLX = 0;
				rawState.Gamepad.sThumbLY = 0;
				rawState.Gamepad.sThumbRX = 0;
				rawState.Gamepad.sThumbRY = 0;
			}
			this.packetNumber = rawState.dwPacketNumber;
			this.buttons = new GamePadButtons(((rawState.Gamepad.dwButtons & 16) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 32) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 64) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 128) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 256) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 512) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 4096) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 8192) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 16384) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 32768) == 0) ? ButtonState.Released : ButtonState.Pressed);
			this.dPad = new GamePadDPad(((rawState.Gamepad.dwButtons & 1) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 2) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 4) == 0) ? ButtonState.Released : ButtonState.Pressed, ((rawState.Gamepad.dwButtons & 8) == 0) ? ButtonState.Released : ButtonState.Pressed);
			this.thumbSticks = new GamePadThumbSticks(new GamePadThumbSticks.StickValue((float)rawState.Gamepad.sThumbLX / 32767f, (float)rawState.Gamepad.sThumbLY / 32767f), new GamePadThumbSticks.StickValue((float)rawState.Gamepad.sThumbRX / 32767f, (float)rawState.Gamepad.sThumbRY / 32767f));
			this.triggers = new GamePadTriggers((float)rawState.Gamepad.bLeftTrigger / 255f, (float)rawState.Gamepad.bRightTrigger / 255f);
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060027B8 RID: 10168 RVA: 0x0001C78E File Offset: 0x0001A98E
		public uint PacketNumber
		{
			get
			{
				return this.packetNumber;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060027B9 RID: 10169 RVA: 0x0001C796 File Offset: 0x0001A996
		public bool IsConnected
		{
			get
			{
				return this.isConnected;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060027BA RID: 10170 RVA: 0x0001C79E File Offset: 0x0001A99E
		public GamePadButtons Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060027BB RID: 10171 RVA: 0x0001C7A6 File Offset: 0x0001A9A6
		public GamePadDPad DPad
		{
			get
			{
				return this.dPad;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060027BC RID: 10172 RVA: 0x0001C7AE File Offset: 0x0001A9AE
		public GamePadTriggers Triggers
		{
			get
			{
				return this.triggers;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060027BD RID: 10173 RVA: 0x0001C7B6 File Offset: 0x0001A9B6
		public GamePadThumbSticks ThumbSticks
		{
			get
			{
				return this.thumbSticks;
			}
		}

		// Token: 0x04001F96 RID: 8086
		private bool isConnected;

		// Token: 0x04001F97 RID: 8087
		private uint packetNumber;

		// Token: 0x04001F98 RID: 8088
		private GamePadButtons buttons;

		// Token: 0x04001F99 RID: 8089
		private GamePadDPad dPad;

		// Token: 0x04001F9A RID: 8090
		private GamePadThumbSticks thumbSticks;

		// Token: 0x04001F9B RID: 8091
		private GamePadTriggers triggers;

		// Token: 0x0200058D RID: 1421
		internal struct RawState
		{
			// Token: 0x04001F9C RID: 8092
			public uint dwPacketNumber;

			// Token: 0x04001F9D RID: 8093
			public GamePadState.RawState.GamePad Gamepad;

			// Token: 0x0200058E RID: 1422
			public struct GamePad
			{
				// Token: 0x04001F9E RID: 8094
				public ushort dwButtons;

				// Token: 0x04001F9F RID: 8095
				public byte bLeftTrigger;

				// Token: 0x04001FA0 RID: 8096
				public byte bRightTrigger;

				// Token: 0x04001FA1 RID: 8097
				public short sThumbLX;

				// Token: 0x04001FA2 RID: 8098
				public short sThumbLY;

				// Token: 0x04001FA3 RID: 8099
				public short sThumbRX;

				// Token: 0x04001FA4 RID: 8100
				public short sThumbRY;
			}
		}

		// Token: 0x0200058F RID: 1423
		private enum ButtonsConstants
		{
			// Token: 0x04001FA6 RID: 8102
			DPadUp = 1,
			// Token: 0x04001FA7 RID: 8103
			DPadDown,
			// Token: 0x04001FA8 RID: 8104
			DPadLeft = 4,
			// Token: 0x04001FA9 RID: 8105
			DPadRight = 8,
			// Token: 0x04001FAA RID: 8106
			Start = 16,
			// Token: 0x04001FAB RID: 8107
			Back = 32,
			// Token: 0x04001FAC RID: 8108
			LeftThumb = 64,
			// Token: 0x04001FAD RID: 8109
			RightThumb = 128,
			// Token: 0x04001FAE RID: 8110
			LeftShoulder = 256,
			// Token: 0x04001FAF RID: 8111
			RightShoulder = 512,
			// Token: 0x04001FB0 RID: 8112
			A = 4096,
			// Token: 0x04001FB1 RID: 8113
			B = 8192,
			// Token: 0x04001FB2 RID: 8114
			X = 16384,
			// Token: 0x04001FB3 RID: 8115
			Y = 32768
		}
	}
}

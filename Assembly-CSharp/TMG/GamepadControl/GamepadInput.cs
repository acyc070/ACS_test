using System;
using InControl;

namespace TMG.GamepadControl
{
	// Token: 0x020001E8 RID: 488
	public static class GamepadInput
	{
		// Token: 0x06001461 RID: 5217 RVA: 0x0007A5D8 File Offset: 0x000787D8
		public static bool GetButton(InputControlType inputControlType)
		{
			InputControl control = GamepadInput.GetControl(inputControlType);
			bool flag = false;
			if (control != null)
			{
				flag = control.IsPressed;
			}
			return flag;
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x0007A5FC File Offset: 0x000787FC
		public static bool GetButtonDown(InputControlType inputControlType)
		{
			InputControl control = GamepadInput.GetControl(inputControlType);
			bool flag = false;
			if (control != null)
			{
				flag = control.WasPressed;
			}
			return flag;
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x0007A620 File Offset: 0x00078820
		public static bool GetButtonUp(InputControlType inputControlType)
		{
			InputControl control = GamepadInput.GetControl(inputControlType);
			bool flag = false;
			if (control != null)
			{
				flag = control.WasReleased;
			}
			return flag;
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x0007A644 File Offset: 0x00078844
		public static float GetAxis(InputControlType inputControlType)
		{
			InputControl control = GamepadInput.GetControl(inputControlType);
			float num = 0f;
			if (control != null)
			{
				num = control.Value;
			}
			return num;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0007A66C File Offset: 0x0007886C
		public static float GetAxisRaw(InputControlType inputControlType)
		{
			InputControl control = GamepadInput.GetControl(inputControlType);
			float num = 0f;
			if (control != null)
			{
				num = control.RawValue;
			}
			return num;
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0007A694 File Offset: 0x00078894
		private static InputControl GetControl(InputControlType inputControlType)
		{
			InputDevice activeDevice = InputManager.ActiveDevice;
			if (activeDevice != null)
			{
				return activeDevice.GetControl(inputControlType);
			}
			return null;
		}
	}
}

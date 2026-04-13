using System;
using InControl;
using TMG.GamepadControl;
using UnityEngine;

namespace TMG.Controls
{
	// Token: 0x020001E7 RID: 487
	public class BasePlayerInput
	{
		// Token: 0x06001458 RID: 5208 RVA: 0x00010946 File Offset: 0x0000EB46
		public static bool VirtualMouseLeftOnPressed()
		{
			return BasePlayerInput.GetInput<bool>(GamepadInput.GetButtonDown(InputControlType.Action1), Input.GetMouseButtonDown(0));
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0001095A File Offset: 0x0000EB5A
		public static bool VirtualMouseLeftOnReleased()
		{
			return BasePlayerInput.GetInput<bool>(GamepadInput.GetButtonUp(InputControlType.Action1), Input.GetMouseButtonUp(0));
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0001096E File Offset: 0x0000EB6E
		public static bool VirtualMouseRightOnPressed()
		{
			return BasePlayerInput.GetInput<bool>(GamepadInput.GetButtonDown(InputControlType.Action2), Input.GetMouseButtonDown(1));
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x00010982 File Offset: 0x0000EB82
		public static bool VirtualMouseRightOnReleased()
		{
			return BasePlayerInput.GetInput<bool>(GamepadInput.GetButtonUp(InputControlType.Action2), Input.GetMouseButtonUp(1));
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x00010996 File Offset: 0x0000EB96
		public static bool VirtualMouseMiddleOnPressed()
		{
			return BasePlayerInput.GetInput<bool>(GamepadInput.GetButtonDown(InputControlType.Action3), Input.GetMouseButtonDown(2));
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x000109AA File Offset: 0x0000EBAA
		public static bool VirtualMouseMiddleOnReleased()
		{
			return BasePlayerInput.GetInput<bool>(GamepadInput.GetButtonUp(InputControlType.Action3), Input.GetMouseButtonUp(2));
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x000109BE File Offset: 0x0000EBBE
		protected static bool GetInputBool(bool inputGamepad, bool inputKeyboard)
		{
			if (inputGamepad)
			{
				return inputGamepad;
			}
			return inputKeyboard && inputKeyboard;
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x000109D1 File Offset: 0x0000EBD1
		protected static float GetInputFloat(float inputGamepad, float inputKeyboard)
		{
			if (Mathf.Abs(inputGamepad) > 1E-45f)
			{
				return inputGamepad;
			}
			if (Mathf.Abs(inputKeyboard) > 1E-45f)
			{
				return inputKeyboard;
			}
			return 0f;
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x0007A574 File Offset: 0x00078774
		protected static T GetInput<T>(T inputGamepad, T inputKeyboard)
		{
			T t = default(T);
			if (!inputGamepad.Equals(default(T)))
			{
				t = inputGamepad;
			}
			else if (!inputKeyboard.Equals(default(T)))
			{
				t = inputKeyboard;
			}
			return t;
		}
	}
}

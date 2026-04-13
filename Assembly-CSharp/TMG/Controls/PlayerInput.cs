using System;
using InControl;
using TMG.GamepadControl;
using UnityEngine;

namespace TMG.Controls
{
	// Token: 0x020001EA RID: 490
	public class PlayerInput : BasePlayerInput
	{
		// Token: 0x0600146C RID: 5228 RVA: 0x00010A04 File Offset: 0x0000EC04
		public static bool Any()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.Action1) || GamepadInput.GetButtonDown(InputControlType.Action2) || GamepadInput.GetButtonDown(InputControlType.Action3) || GamepadInput.GetButtonDown(InputControlType.Action4), Input.anyKeyDown);
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x00010A3E File Offset: 0x0000EC3E
		public static bool Attack()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.RightTrigger), Input.GetMouseButtonDown(0));
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x00010A52 File Offset: 0x0000EC52
		public static bool SeeingTool()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.LeftTrigger), Input.GetMouseButtonDown(1));
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x00010A66 File Offset: 0x0000EC66
		public static bool AttackHold()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButton(InputControlType.RightTrigger), Input.GetMouseButton(0));
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x00010A7A File Offset: 0x0000EC7A
		public static bool Run()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButton(InputControlType.LeftStickButton) || GamepadInput.GetButton(InputControlType.LeftBumper), Input.GetKey(KeyCode.LeftShift));
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x00010AA0 File Offset: 0x0000ECA0
		public static bool RunDown()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.LeftStickButton) || GamepadInput.GetButtonDown(InputControlType.LeftBumper), Input.GetKeyDown(KeyCode.LeftShift));
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x00010AC6 File Offset: 0x0000ECC6
		public static bool Jump()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.Action1), Input.GetKeyDown(KeyCode.Space));
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x00010ADB File Offset: 0x0000ECDB
		public static bool ExpoInvert()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.Action4), Input.GetKeyDown(KeyCode.H));
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x00010AF0 File Offset: 0x0000ECF0
		public static bool Pause()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.Start) || GamepadInput.GetButtonDown(InputControlType.Menu), Input.GetKeyDown(KeyCode.Escape));
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x00010B14 File Offset: 0x0000ED14
		public static float MoveX()
		{
			return BasePlayerInput.GetInputFloat(GamepadInput.GetAxis(InputControlType.LeftStickX), Input.GetAxis("Horizontal"));
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00010B2F File Offset: 0x0000ED2F
		public static float MoveY()
		{
			return BasePlayerInput.GetInputFloat(GamepadInput.GetAxis(InputControlType.LeftStickY), Input.GetAxis("Vertical"));
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x00010B4A File Offset: 0x0000ED4A
		public static float LookX(float TSpeed = 0f)
		{
			return BasePlayerInput.GetInputFloat(GamepadInput.GetAxis(InputControlType.RightStickX) * (1.25f + TSpeed), Input.GetAxis("Mouse X"));
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x0007A8E0 File Offset: 0x00078AE0
		public static float LookY(float TSpeed = 0f)
		{
			float num = (float)((!GameManager.Instance.PlayerSettings.Inverted) ? 1 : (-1));
			return BasePlayerInput.GetInputFloat(GamepadInput.GetAxis(InputControlType.RightStickY) * (0.75f + TSpeed), Input.GetAxis("Mouse Y")) * num;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x00010B6D File Offset: 0x0000ED6D
		public static bool BackOnPressed()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.Action2), Input.GetKeyDown(KeyCode.Q));
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x00010B82 File Offset: 0x0000ED82
		public static bool InteractOnPressed()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonDown(InputControlType.Action3), Input.GetKeyDown(KeyCode.E));
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x00010B97 File Offset: 0x0000ED97
		public static bool InteractOnReleased()
		{
			return BasePlayerInput.GetInputBool(GamepadInput.GetButtonUp(InputControlType.Action3), Input.GetKeyUp(KeyCode.E));
		}
	}
}

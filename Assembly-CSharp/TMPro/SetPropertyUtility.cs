using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200060F RID: 1551
	internal static class SetPropertyUtility
	{
		// Token: 0x06002B94 RID: 11156 RVA: 0x00104D84 File Offset: 0x00102F84
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			if (currentValue.r == newValue.r && currentValue.g == newValue.g && currentValue.b == newValue.b && currentValue.a == newValue.a)
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06002B95 RID: 11157 RVA: 0x0001F2D6 File Offset: 0x0001D4D6
		public static bool SetEquatableStruct<T>(ref T currentValue, T newValue) where T : IEquatable<T>
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06002B96 RID: 11158 RVA: 0x0001F2F4 File Offset: 0x0001D4F4
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x00104DE4 File Offset: 0x00102FE4
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}
	}
}

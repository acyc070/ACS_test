using System;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000341 RID: 833
	public static class DOTweenAnimationExtensions
	{
		// Token: 0x06001CFC RID: 7420 RVA: 0x00016EED File Offset: 0x000150ED
		public static bool IsSameOrSubclassOf<T>(this Component t)
		{
			return t is T;
		}
	}
}

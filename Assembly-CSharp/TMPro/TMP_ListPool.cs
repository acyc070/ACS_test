using System;
using System.Collections.Generic;

namespace TMPro
{
	// Token: 0x02000611 RID: 1553
	internal static class TMP_ListPool<T>
	{
		// Token: 0x06002B98 RID: 11160 RVA: 0x0001F317 File Offset: 0x0001D517
		public static List<T> Get()
		{
			return TMP_ListPool<T>.s_ListPool.Get();
		}

		// Token: 0x06002B99 RID: 11161 RVA: 0x0001F323 File Offset: 0x0001D523
		public static void Release(List<T> toRelease)
		{
			TMP_ListPool<T>.s_ListPool.Release(toRelease);
		}

		// Token: 0x04002FD1 RID: 12241
		private static readonly TMP_ObjectPool<List<T>> s_ListPool = new TMP_ObjectPool<List<T>>(null, delegate(List<T> l)
		{
			l.Clear();
		});
	}
}

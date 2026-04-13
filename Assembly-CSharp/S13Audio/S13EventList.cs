using System;
using System.Collections.Generic;
using System.Reflection;

namespace S13Audio
{
	// Token: 0x02000054 RID: 84
	public static class S13EventList
	{
		// Token: 0x06000332 RID: 818 RVA: 0x0002A19C File Offset: 0x0002839C
		private static List<string> PopulateList()
		{
			Type typeFromHandle = typeof(S13AudioEvents);
			MethodInfo[] methods = typeFromHandle.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
			S13EventList.eventStrings = new List<string>(methods.Length);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.Name != "Start" && methodInfo.IsPrivate)
				{
					S13EventList.eventStrings.Add(methodInfo.Name);
				}
			}
			return S13EventList.eventStrings;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00005054 File Offset: 0x00003254
		public static List<string> GetList()
		{
			if (S13EventList.eventStrings == null || S13EventList.eventStrings.Count < 1)
			{
				S13EventList.PopulateList();
			}
			return S13EventList.eventStrings;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000507B File Offset: 0x0000327B
		public static void Refresh()
		{
			S13EventList.eventStrings.Clear();
		}

		// Token: 0x040001AB RID: 427
		private static List<string> eventStrings = new List<string>();
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000171 RID: 369
public class AchievementMapper : MonoBehaviour
{
	// Token: 0x1700009E RID: 158
	// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x0000D13C File Offset: 0x0000B33C
	public AchievementIDMapping[] AchievementIDs
	{
		get
		{
			return this.achievementIDs.ToArray();
		}
	}

	// Token: 0x04000C74 RID: 3188
	[SerializeField]
	private List<AchievementIDMapping> achievementIDs;
}

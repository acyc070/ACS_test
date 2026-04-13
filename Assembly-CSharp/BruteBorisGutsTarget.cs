using System;
using TMG.Core;
using UnityEngine;

// Token: 0x0200014F RID: 335
public class BruteBorisGutsTarget : TMGMonoBehaviour, IHittable
{
	// Token: 0x06000DA4 RID: 3492 RVA: 0x0000C42A File Offset: 0x0000A62A
	public void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
	{
		if (weaponInfo == null)
		{
			return;
		}
		if (this.m_Boris)
		{
			this.m_Boris.Hit(weaponInfo.IsBullet);
		}
	}

	// Token: 0x04000BA3 RID: 2979
	[SerializeField]
	private BruteBorisAi m_Boris;
}

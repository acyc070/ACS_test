using System;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x020002DE RID: 734
public class BrokenWeapon : TMGMonoBehaviour
{
	// Token: 0x06001B51 RID: 6993 RVA: 0x00091EEC File Offset: 0x000900EC
	public void Break(Transform weapon, Vector3 fromPosition)
	{
		base.transform.position = weapon.position;
		base.transform.rotation = weapon.rotation;
		for (int i = 0; i < this.m_Pieces.Count; i++)
		{
			this.m_Pieces[i].transform.SetParent(null);
			this.m_Pieces[i].AddExplosionForce(5f, fromPosition, 15f, 1f, ForceMode.Impulse);
		}
		base.Dispose();
	}

	// Token: 0x06001B52 RID: 6994 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040017CA RID: 6090
	[SerializeField]
	private List<Rigidbody> m_Pieces;
}

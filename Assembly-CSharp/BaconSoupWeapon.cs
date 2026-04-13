using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class BaconSoupWeapon : ThrowableObject
{
	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06001B29 RID: 6953 RVA: 0x00015DD4 File Offset: 0x00013FD4
	public Rigidbody[] BrokenPieces
	{
		get
		{
			return this.m_BrokenPieces;
		}
	}

	// Token: 0x06001B2A RID: 6954 RVA: 0x00091824 File Offset: 0x0008FA24
	public override void DoHitStuff(Vector3 hitPosition)
	{
		base.DoHitStuff(hitPosition);
		base.SendOnHit();
		GameManager.Instance.AiGlobalNetwork.SetNoiseLocation(hitPosition);
		if (this.m_BrokenPieces.Length > 0)
		{
			this.m_Active.SetActive(false);
			for (int i = 0; i < this.m_BrokenPieces.Length; i++)
			{
				Rigidbody rigidbody = this.m_BrokenPieces[i];
				if (rigidbody)
				{
					rigidbody.transform.SetParent(null);
					rigidbody.gameObject.SetActive(true);
					rigidbody.velocity = base.GetComponent<Rigidbody>().velocity;
					rigidbody.AddExplosionForce(5f, base.transform.position, 15f, 2f, ForceMode.Impulse);
				}
			}
		}
		if (this.m_Respawner)
		{
			List<MeshRenderer> list = new List<MeshRenderer>();
			for (int j = 0; j < this.m_BrokenPieces.Length; j++)
			{
				list.Add(this.m_BrokenPieces[j].GetComponent<MeshRenderer>());
			}
			this.m_Respawner.CheckMeshVisibility(list);
			this.m_Respawner.Respawn();
		}
	}

	// Token: 0x040017B5 RID: 6069
	[SerializeField]
	private GameObject m_Active;

	// Token: 0x040017B6 RID: 6070
	[SerializeField]
	private Rigidbody[] m_BrokenPieces;
}

using System;
using TMG.Core;
using UnityEngine;

// Token: 0x0200007E RID: 126
public class CH1EntranceDoor : TMGMonoBehaviour
{
	// Token: 0x06000467 RID: 1127 RVA: 0x00006227 File Offset: 0x00004427
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ActiveDoor.SetActive(true);
		this.m_EndingDoor.SetActive(false);
		this.m_Portal = base.gameObject.GetComponent<OcclusionPortal>();
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00006258 File Offset: 0x00004458
	public void Activate()
	{
		if (this.m_Portal)
		{
			this.m_Portal.open = true;
		}
		this.m_ActiveDoor.SetActive(false);
		this.m_EndingDoor.SetActive(true);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x0000628E File Offset: 0x0000448E
	protected override void OnDisposed()
	{
		this.m_Portal = null;
		base.OnDisposed();
	}

	// Token: 0x040002EB RID: 747
	[SerializeField]
	private GameObject m_ActiveDoor;

	// Token: 0x040002EC RID: 748
	[SerializeField]
	private GameObject m_EndingDoor;

	// Token: 0x040002ED RID: 749
	private OcclusionPortal m_Portal;
}

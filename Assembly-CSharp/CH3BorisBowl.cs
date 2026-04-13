using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
public class CH3BorisBowl : Interactable
{
	// Token: 0x060008CD RID: 2253 RVA: 0x000090DA File Offset: 0x000072DA
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		base.SetActive(false);
		this.m_FullBowl.SetActive(false);
		this.m_EmptyBowl.SetActive(false);
		this.m_HighlightBowl.gameObject.SetActive(false);
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00009112 File Offset: 0x00007312
	public void Activate()
	{
		this.m_HighlightBowl.gameObject.SetActive(true);
		this.m_HighlightBowl.material.SetFloat("_Shimmer", 1f);
		base.SetActive(true);
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x00009146 File Offset: 0x00007346
	public override void OnInteract()
	{
		base.OnInteract();
		this.m_HighlightBowl.gameObject.SetActive(false);
		this.m_FullBowl.SetActive(true);
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x0000916B File Offset: 0x0000736B
	public void Empty()
	{
		this.m_FullBowl.SetActive(false);
		this.m_EmptyBowl.SetActive(true);
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x00009185 File Offset: 0x00007385
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x0400072E RID: 1838
	[SerializeField]
	private GameObject m_FullBowl;

	// Token: 0x0400072F RID: 1839
	[SerializeField]
	private GameObject m_EmptyBowl;

	// Token: 0x04000730 RID: 1840
	[SerializeField]
	private Renderer m_HighlightBowl;
}

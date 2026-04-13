using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000227 RID: 551
public class CannedSoupEdibleStack : CannedSoupEdible
{
	// Token: 0x0600157E RID: 5502 RVA: 0x0007DA40 File Offset: 0x0007BC40
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		if (this.m_StackedCan != null)
		{
			this.m_Active = false;
			this.m_StackedCan.OnInteracted += this.HandleStackedCanOnInteracted;
		}
		base.StartCoroutine(this.DelayStackCheck());
	}

	// Token: 0x0600157F RID: 5503 RVA: 0x0007DA90 File Offset: 0x0007BC90
	private IEnumerator DelayStackCheck()
	{
		yield return new WaitForSeconds(1f);
		yield return new WaitForEndOfFrame();
		if (this.m_StackedCan == null)
		{
			this.m_Active = true;
		}
		yield break;
	}

	// Token: 0x06001580 RID: 5504 RVA: 0x000117B6 File Offset: 0x0000F9B6
	private void HandleStackedCanOnInteracted(object sender, EventArgs e)
	{
		this.m_StackedCan.OnInteracted += this.HandleStackedCanOnInteracted;
		this.m_Active = true;
	}

	// Token: 0x06001581 RID: 5505 RVA: 0x000117D6 File Offset: 0x0000F9D6
	public override void OnInteract()
	{
		if (this.m_StackedCan != null)
		{
			this.m_StackedCan.OnInteracted += this.HandleStackedCanOnInteracted;
		}
		base.PlayEatSound();
		base.Dispose();
	}

	// Token: 0x0400135D RID: 4957
	[Header("Stacked Options")]
	[SerializeField]
	private CannedSoupEdible m_StackedCan;
}

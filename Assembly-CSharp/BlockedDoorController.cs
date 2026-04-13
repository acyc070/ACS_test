using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

// Token: 0x020001CA RID: 458
public class BlockedDoorController : TMGMonoBehaviour
{
	// Token: 0x1400007A RID: 122
	// (add) Token: 0x06001382 RID: 4994 RVA: 0x0007747C File Offset: 0x0007567C
	// (remove) Token: 0x06001383 RID: 4995 RVA: 0x000774B4 File Offset: 0x000756B4
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnUnlocked;

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x06001384 RID: 4996 RVA: 0x0001008E File Offset: 0x0000E28E
	public BaseDoorController Door
	{
		get
		{
			return this.m_Door;
		}
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x000774EC File Offset: 0x000756EC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		for (int i = 0; i < this.m_Planks.Count; i++)
		{
			this.m_Planks[i].OnBroken += this.HandlePlankOnBroken;
		}
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x00077538 File Offset: 0x00075738
	public void ForceOpen()
	{
		for (int i = 0; i < this.m_Planks.Count; i++)
		{
			this.m_Planks[i].Dispose();
			this.m_Door.Unlock();
		}
	}

	// Token: 0x06001387 RID: 4999 RVA: 0x00077580 File Offset: 0x00075780
	private void HandlePlankOnBroken(object sender, EventArgs e)
	{
		Breakable breakable = (Breakable)sender;
		breakable.OnBroken -= this.HandlePlankOnBroken;
		if (this.m_Planks.Contains(breakable))
		{
			this.m_Planks.Remove(breakable);
		}
		if (this.m_Planks.Count <= 0)
		{
			this.m_Door.Unlock();
			this.OnUnlocked.Send(this);
		}
	}

	// Token: 0x06001388 RID: 5000 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000F84 RID: 3972
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x04000F85 RID: 3973
	[SerializeField]
	private List<Breakable> m_Planks;
}

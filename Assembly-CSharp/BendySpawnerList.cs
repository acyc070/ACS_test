using System;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x0200019E RID: 414
public class BendySpawnerList : TMGMonoBehaviour
{
	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x06001121 RID: 4385 RVA: 0x0000E65D File Offset: 0x0000C85D
	public List<BendySpawner> BendySpawners
	{
		get
		{
			return this.m_BendySpawners;
		}
	}

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x06001122 RID: 4386 RVA: 0x0000E665 File Offset: 0x0000C865
	// (set) Token: 0x06001123 RID: 4387 RVA: 0x0000E66D File Offset: 0x0000C86D
	public bool InUse { get; private set; }

	// Token: 0x06001124 RID: 4388 RVA: 0x0006F1BC File Offset: 0x0006D3BC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		for (int i = 0; i < this.m_BendySpawners.Count; i++)
		{
			this.m_BendySpawners[i].Initialize(this);
		}
	}

	// Token: 0x06001125 RID: 4389 RVA: 0x0000E676 File Offset: 0x0000C876
	public void Use()
	{
		this.InUse = true;
	}

	// Token: 0x06001126 RID: 4390 RVA: 0x0006F200 File Offset: 0x0006D400
	public void Reset()
	{
		this.InUse = false;
		for (int i = 0; i < this.m_BendySpawners.Count; i++)
		{
			this.m_BendySpawners[i].Disable();
		}
	}

	// Token: 0x06001127 RID: 4391 RVA: 0x0000E67F File Offset: 0x0000C87F
	protected override void OnDisposed()
	{
		if (this.m_BendySpawners != null)
		{
			this.m_BendySpawners.Clear();
			this.m_BendySpawners = null;
		}
		base.OnDisposed();
	}

	// Token: 0x04000DF1 RID: 3569
	[SerializeField]
	private List<BendySpawner> m_BendySpawners;
}

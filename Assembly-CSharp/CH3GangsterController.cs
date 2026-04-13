using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class CH3GangsterController : BaseController
{
	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060006F2 RID: 1778 RVA: 0x000080C0 File Offset: 0x000062C0
	// (set) Token: 0x060006F3 RID: 1779 RVA: 0x000080C8 File Offset: 0x000062C8
	public bool IsActive { get; private set; }

	// Token: 0x060006F4 RID: 1780 RVA: 0x000080D1 File Offset: 0x000062D1
	public void SetActive(bool active)
	{
		this.IsActive = active;
		if (this.IsActive)
		{
			this.KillAllGangsters();
			this.ReSpawn();
		}
		else
		{
			this.KillAllGangsters();
		}
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0003F8F8 File Offset: 0x0003DAF8
	public void ReSpawn()
	{
		this.SpawnButcherGangAi(ref this.m_Piper, "GamePlay/Characters/Ai_Piper", this.m_PiperSpawner, this.m_PiperWaypointList);
		this.SpawnButcherGangAi(ref this.m_Striker, "GamePlay/Characters/Ai_Striker", this.m_StrikerSpawner, this.m_StrikerWaypointList);
		this.SpawnButcherGangAi(ref this.m_Fisher, "GamePlay/Characters/Ai_Fisher", this.m_FisherSpawner, this.m_FisherWaypointList);
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0003F95C File Offset: 0x0003DB5C
	private void SpawnButcherGangAi(ref ButcherGangAi butcherGangAi, string prefab, SpecialSpawnerNode spawnPoint, WaypointList waypointList)
	{
		if (!this.m_Gangsters.Contains(butcherGangAi))
		{
			butcherGangAi = GameManager.Instance.AssetManager.CreateAsset<ButcherGangAi>(prefab);
			butcherGangAi.transform.position = spawnPoint.transform.position;
			butcherGangAi.UpdateWaypointList(waypointList.Waypoints, false);
			butcherGangAi.OnDeath += this.HandleGangsterOnDeath;
			this.m_Gangsters.Add(butcherGangAi);
		}
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x0003F9D4 File Offset: 0x0003DBD4
	private void HandleGangsterOnDeath(object sender, EventArgs e)
	{
		ButcherGangAi butcherGangAi = (ButcherGangAi)sender;
		butcherGangAi.OnDeath -= this.HandleGangsterOnDeath;
		if (this.m_Gangsters.Contains(butcherGangAi))
		{
			this.m_Gangsters.Remove(butcherGangAi);
			if (!butcherGangAi.Equals(this.m_Piper))
			{
				this.SpawnButcherGangAi(ref this.m_Piper, "GamePlay/Characters/Ai_Piper", this.m_PiperSpawner, this.m_PiperWaypointList);
			}
			if (!butcherGangAi.Equals(this.m_Striker))
			{
				this.SpawnButcherGangAi(ref this.m_Striker, "GamePlay/Characters/Ai_Striker", this.m_StrikerSpawner, this.m_StrikerWaypointList);
			}
			if (!butcherGangAi.Equals(this.m_Fisher))
			{
				this.SpawnButcherGangAi(ref this.m_Fisher, "GamePlay/Characters/Ai_Fisher", this.m_FisherSpawner, this.m_FisherWaypointList);
			}
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0003FAA4 File Offset: 0x0003DCA4
	private void KillAllGangsters()
	{
		if (this.m_Piper != null)
		{
			this.m_Piper.Dispose();
		}
		if (this.m_Striker != null)
		{
			this.m_Striker.Dispose();
		}
		if (this.m_Fisher != null)
		{
			this.m_Fisher.Dispose();
		}
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x000080FC File Offset: 0x000062FC
	protected override void OnDisposed()
	{
		if (this.m_Gangsters != null)
		{
			this.m_Gangsters.Clear();
			this.m_Gangsters = null;
		}
		base.OnDisposed();
	}

	// Token: 0x040005A0 RID: 1440
	[Header("Piper")]
	[SerializeField]
	private SpecialSpawnerNode m_PiperSpawner;

	// Token: 0x040005A1 RID: 1441
	[SerializeField]
	private WaypointList m_PiperWaypointList;

	// Token: 0x040005A2 RID: 1442
	[Header("Striker")]
	[SerializeField]
	private SpecialSpawnerNode m_StrikerSpawner;

	// Token: 0x040005A3 RID: 1443
	[SerializeField]
	private WaypointList m_StrikerWaypointList;

	// Token: 0x040005A4 RID: 1444
	[Header("Fisher")]
	[SerializeField]
	private SpecialSpawnerNode m_FisherSpawner;

	// Token: 0x040005A5 RID: 1445
	[SerializeField]
	private WaypointList m_FisherWaypointList;

	// Token: 0x040005A6 RID: 1446
	private ButcherGangAi m_Piper;

	// Token: 0x040005A7 RID: 1447
	private ButcherGangAi m_Striker;

	// Token: 0x040005A8 RID: 1448
	private ButcherGangAi m_Fisher;

	// Token: 0x040005A9 RID: 1449
	private List<ButcherGangAi> m_Gangsters = new List<ButcherGangAi>();
}

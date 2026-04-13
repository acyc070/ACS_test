using System;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x0200019D RID: 413
public class BendySpawner : TMGMonoBehaviour
{
	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x06001118 RID: 4376 RVA: 0x0000E5E3 File Offset: 0x0000C7E3
	public List<WaypointNode> Watpoints
	{
		get
		{
			return this.m_Waypoints;
		}
	}

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x06001119 RID: 4377 RVA: 0x0000E5EB File Offset: 0x0000C7EB
	// (set) Token: 0x0600111A RID: 4378 RVA: 0x0000E5F3 File Offset: 0x0000C7F3
	public BendySpawnerList BendySpawnerList { get; private set; }

	// Token: 0x0600111B RID: 4379 RVA: 0x0000E5FC File Offset: 0x0000C7FC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_BendyController = global::UnityEngine.Object.FindObjectOfType<CH3BendyController>();
		this.m_CH5BendyController = global::UnityEngine.Object.FindObjectOfType<CH5Administration>();
	}

	// Token: 0x0600111C RID: 4380 RVA: 0x0000E61A File Offset: 0x0000C81A
	public void Initialize(BendySpawnerList list = null)
	{
		this.BendySpawnerList = list;
	}

	// Token: 0x0600111D RID: 4381 RVA: 0x0006F07C File Offset: 0x0006D27C
	public void Update()
	{
		if (this.m_BendyController != null && this.m_BendyController.Bendy)
		{
			if (Vector3.Distance(this.m_BendyController.Bendy.transform.position, base.transform.position) < 10f)
			{
				if (!this.m_Particles.isPlaying)
				{
					this.m_Particles.Play();
				}
			}
			else if (this.m_Particles.isPlaying)
			{
				this.m_Particles.Stop();
			}
		}
		else if (this.m_CH5BendyController != null && this.m_CH5BendyController.Bendy)
		{
			if (Vector3.Distance(this.m_CH5BendyController.Bendy.transform.position, base.transform.position) < 10f)
			{
				if (!this.m_Particles.isPlaying)
				{
					this.m_Particles.Play();
				}
			}
			else if (this.m_Particles.isPlaying)
			{
				this.m_Particles.Stop();
			}
		}
		else
		{
			this.Disable();
		}
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x0000E623 File Offset: 0x0000C823
	public void Disable()
	{
		if (this.m_Particles.isPlaying)
		{
			this.m_Particles.Stop();
		}
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x0000E640 File Offset: 0x0000C840
	protected override void OnDisposed()
	{
		this.m_BendyController = null;
		this.m_CH5BendyController = null;
		this.BendySpawnerList = null;
		base.OnDisposed();
	}

	// Token: 0x04000DEC RID: 3564
	[SerializeField]
	private List<WaypointNode> m_Waypoints;

	// Token: 0x04000DED RID: 3565
	[SerializeField]
	private ParticleSystem m_Particles;

	// Token: 0x04000DEF RID: 3567
	private CH3BendyController m_BendyController;

	// Token: 0x04000DF0 RID: 3568
	private CH5Administration m_CH5BendyController;
}

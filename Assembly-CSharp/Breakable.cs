using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

// Token: 0x02000223 RID: 547
public class Breakable : TMGMonoBehaviour, IHittable
{
	// Token: 0x14000089 RID: 137
	// (add) Token: 0x06001569 RID: 5481 RVA: 0x0007D494 File Offset: 0x0007B694
	// (remove) Token: 0x0600156A RID: 5482 RVA: 0x0007D4CC File Offset: 0x0007B6CC
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnBroken;

	// Token: 0x0600156B RID: 5483 RVA: 0x0007D504 File Offset: 0x0007B704
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Collider = base.GetComponent<Collider>();
		if (this.m_AudioClips.Count > 0)
		{
			int num = global::UnityEngine.Random.Range(0, this.m_AudioClips.Count);
			this.m_BreakClip = this.m_AudioClips[num];
		}
	}

	// Token: 0x0600156C RID: 5484 RVA: 0x0007D558 File Offset: 0x0007B758
	public void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
	{
		if (weaponInfo == null)
		{
			return;
		}
		if (this.m_AxeOnly && (weaponInfo.ImpactType == ImpactType.AXE || weaponInfo.IsBullet))
		{
			this.Destroy(hit.point);
		}
		else if (!this.m_BendyCutout && !this.m_AxeOnly)
		{
			this.m_HitCount++;
			if (this.m_HitCount > -this.m_HitMax)
			{
				this.Destroy(hit.point);
			}
		}
	}

	// Token: 0x0600156D RID: 5485 RVA: 0x0007D5E4 File Offset: 0x0007B7E4
	public void Destroy(Vector3 fromPosition)
	{
		if (this.m_Collider)
		{
			this.m_Collider.enabled = false;
		}
		if (this.m_BreakClip)
		{
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_BreakClip, fromPosition, AudioObjectType.SOUND_EFFECT, 0, false, null);
		}
		this.SilentDestroy(fromPosition);
	}

	// Token: 0x0600156E RID: 5486 RVA: 0x0007D640 File Offset: 0x0007B840
	public void SilentDestroy(Vector3 fromPosition)
	{
		Vector3 vector = fromPosition + (GameManager.Instance.GameCamera.transform.position - fromPosition).normalized;
		for (int i = 0; i < this.m_Pieces.Count; i++)
		{
			Rigidbody rigidbody = this.m_Pieces[i];
			if (rigidbody)
			{
				rigidbody.transform.SetParent(base.transform.parent);
				rigidbody.angularVelocity = global::UnityEngine.Random.insideUnitSphere * global::UnityEngine.Random.Range(-360f, 360f);
				rigidbody.AddExplosionForce(15f, vector, 15f, -0.25f, ForceMode.Impulse);
			}
		}
		this.OnBroken.Send(this);
		base.Dispose();
	}

	// Token: 0x0600156F RID: 5487 RVA: 0x0001172E File Offset: 0x0000F92E
	protected override void OnDisposed()
	{
		this.OnBroken = null;
		base.OnDisposed();
	}

	// Token: 0x04001346 RID: 4934
	[SerializeField]
	private List<Rigidbody> m_Pieces;

	// Token: 0x04001347 RID: 4935
	[SerializeField]
	private List<AudioClip> m_AudioClips;

	// Token: 0x04001348 RID: 4936
	[SerializeField]
	private bool m_AxeOnly;

	// Token: 0x04001349 RID: 4937
	[SerializeField]
	private bool m_BendyCutout;

	// Token: 0x0400134A RID: 4938
	private Collider m_Collider;

	// Token: 0x0400134B RID: 4939
	private AudioClip m_BreakClip;

	// Token: 0x0400134C RID: 4940
	private int m_HitCount;

	// Token: 0x0400134D RID: 4941
	private int m_HitMax = 2;
}

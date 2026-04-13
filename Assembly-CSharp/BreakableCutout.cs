using System;
using System.Collections;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x02000224 RID: 548
public class BreakableCutout : TMGMonoBehaviour, IHittable
{
	// Token: 0x06001571 RID: 5489 RVA: 0x0007D708 File Offset: 0x0007B908
	public override void Init()
	{
		this.m_Collider = base.GetComponent<Collider>();
		this.m_RendererCollider = this.m_StaticRenderer.GetComponent<Collider>();
		this.m_BrokenCutout.SetActive(false);
		IEnumerator enumerator = this.m_BrokenCutout.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				Rigidbody component = transform.GetComponent<Rigidbody>();
				if (component != null)
				{
					this.m_BrokenCutouts.Add(new BreakableCutout.BrokenCutout
					{
						Rigidbody = component,
						Renderer = transform.GetComponent<MeshRenderer>(),
						Origin = transform.position
					});
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
		this.m_BrokenCuroutsCount = this.m_BrokenCutouts.Count;
	}

	// Token: 0x06001572 RID: 5490 RVA: 0x0007D7EC File Offset: 0x0007B9EC
	public void Update()
	{
		if (!this.m_IsBroken)
		{
			return;
		}
		this.m_IsVisible = false;
		for (int i = 0; i < this.m_BrokenCuroutsCount; i++)
		{
			if (this.m_BrokenCutouts[i].Renderer.isVisible)
			{
				this.m_IsVisible = true;
				break;
			}
		}
		if (!this.m_IsVisible && !this.m_StaticRenderer.isVisible)
		{
			this.m_BrokenCutout.SetActive(false);
			for (int j = 0; j < this.m_BrokenCuroutsCount; j++)
			{
				BreakableCutout.BrokenCutout brokenCutout = this.m_BrokenCutouts[j];
				brokenCutout.Rigidbody.velocity = Vector3.zero;
				brokenCutout.Rigidbody.transform.position = brokenCutout.Origin;
			}
			this.m_StaticRenderer.gameObject.layer = LayerMask.NameToLayer("Default");
			this.m_IsBroken = false;
			this.m_Collider.enabled = true;
			this.m_RendererCollider.enabled = true;
		}
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x00011750 File Offset: 0x0000F950
	public void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
	{
		if (weaponInfo == null || weaponInfo.ImpactType != ImpactType.AXE)
		{
			return;
		}
		this.Break(hit.point);
	}

	// Token: 0x06001574 RID: 5492 RVA: 0x0007D8F4 File Offset: 0x0007BAF4
	public void Break(Vector3 fromPosition)
	{
		this.m_Collider.enabled = false;
		this.m_RendererCollider.enabled = false;
		this.m_StaticRenderer.gameObject.layer = LayerMask.NameToLayer("Invisible");
		GameManager.Instance.AudioManager.PlayAtPosition("Audio/SFX/SFX_Bendy_Cutout_Impact_01", base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_BrokenCutout.SetActive(true);
		for (int i = 0; i < this.m_BrokenCuroutsCount; i++)
		{
			this.m_BrokenCutouts[i].Rigidbody.AddExplosionForce(1500f, fromPosition, 10f, 0.25f);
		}
		this.m_IsBroken = true;
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x0400134E RID: 4942
	[Header("GameObjects")]
	[SerializeField]
	private GameObject m_StaticCutout;

	// Token: 0x0400134F RID: 4943
	[SerializeField]
	private GameObject m_BrokenCutout;

	// Token: 0x04001350 RID: 4944
	[Header("MeshRenderer")]
	[SerializeField]
	private MeshRenderer m_StaticRenderer;

	// Token: 0x04001351 RID: 4945
	private List<BreakableCutout.BrokenCutout> m_BrokenCutouts = new List<BreakableCutout.BrokenCutout>();

	// Token: 0x04001352 RID: 4946
	private Collider m_Collider;

	// Token: 0x04001353 RID: 4947
	private Collider m_RendererCollider;

	// Token: 0x04001354 RID: 4948
	private int m_BrokenCuroutsCount;

	// Token: 0x04001355 RID: 4949
	private bool m_IsVisible;

	// Token: 0x04001356 RID: 4950
	private bool m_IsBroken;

	// Token: 0x02000225 RID: 549
	private class BrokenCutout
	{
		// Token: 0x04001357 RID: 4951
		public Rigidbody Rigidbody;

		// Token: 0x04001358 RID: 4952
		public MeshRenderer Renderer;

		// Token: 0x04001359 RID: 4953
		public Vector3 Origin;
	}
}

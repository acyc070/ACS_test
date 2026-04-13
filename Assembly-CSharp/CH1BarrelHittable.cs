using System;
using System.Collections;
using TMG.Core;
using UnityEngine;

// Token: 0x0200007B RID: 123
public class CH1BarrelHittable : TMGMonoBehaviour, IHittable
{
	// Token: 0x0600045C RID: 1116 RVA: 0x000061B1 File Offset: 0x000043B1
	public override void Init()
	{
		base.Init();
		if (this.m_Rigidbody == null)
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x0002FDD0 File Offset: 0x0002DFD0
	public void Hit(RaycastHit hit, WeaponInfo weaponInfo)
	{
		if (weaponInfo == null)
		{
			return;
		}
		if (weaponInfo.Audio != null && weaponInfo.Audio.Count > 0)
		{
			GameManager.Instance.AudioManager.PlayAtPosition(weaponInfo.Audio[global::UnityEngine.Random.Range(0, weaponInfo.Audio.Count)], hit.point, AudioObjectType.SOUND_EFFECT, 0, false, null);
		}
		if (weaponInfo.ImpactType == ImpactType.AXE)
		{
			this.m_HitCount++;
		}
		else if (weaponInfo.ImpactType == ImpactType.INSTANT_DESTROY)
		{
			this.m_HitCount = this.m_HitMax;
		}
		if (this.m_Rigidbody != null && this.m_HitCount >= this.m_HitMax)
		{
			this.m_ActiveBarrel.SetActive(false);
			this.m_Broken.SetActive(true);
			this.m_Broken.transform.SetParent(null);
			IEnumerator enumerator = this.m_Broken.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					Rigidbody component = transform.GetComponent<Rigidbody>();
					if (component != null)
					{
						component.AddExplosionForce(20f, hit.point, 10f, 2f, ForceMode.Impulse);
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
			base.Dispose();
		}
		else
		{
			if (this.m_InkPrefab)
			{
				CH1BarrelInk ch1BarrelInk = global::UnityEngine.Object.Instantiate<CH1BarrelInk>(this.m_InkPrefab);
				ch1BarrelInk.transform.position = hit.point;
				Vector3 vector = hit.point - base.transform.position;
				Quaternion quaternion = Quaternion.LookRotation(vector);
				ch1BarrelInk.transform.rotation = quaternion;
				if (weaponInfo.ImpactType != ImpactType.AXE)
				{
					Vector3 localEulerAngles = ch1BarrelInk.transform.localEulerAngles;
					localEulerAngles.z = global::UnityEngine.Random.Range(0f, 360f);
					ch1BarrelInk.transform.localEulerAngles = localEulerAngles;
				}
				ch1BarrelInk.transform.SetParent(base.transform);
				ch1BarrelInk.Activate(weaponInfo.ImpactType);
			}
			if (this.m_Rigidbody != null)
			{
				this.m_Rigidbody.AddExplosionForce(10f, hit.point, 10f, 1f, ForceMode.Impulse);
			}
		}
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040002DD RID: 733
	[SerializeField]
	private Rigidbody m_Rigidbody;

	// Token: 0x040002DE RID: 734
	[SerializeField]
	private CH1BarrelInk m_InkPrefab;

	// Token: 0x040002DF RID: 735
	[SerializeField]
	private GameObject m_ActiveBarrel;

	// Token: 0x040002E0 RID: 736
	[SerializeField]
	private GameObject m_Broken;

	// Token: 0x040002E1 RID: 737
	private int m_HitCount;

	// Token: 0x040002E2 RID: 738
	private int m_HitMax = 5;
}

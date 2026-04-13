using System;
using System.Collections;
using TMG.Core;
using UnityEngine;

// Token: 0x0200007D RID: 125
public class CH1ChairHittable : TMGMonoBehaviour, IHittable
{
	// Token: 0x06000463 RID: 1123 RVA: 0x00006202 File Offset: 0x00004402
	public override void Init()
	{
		base.Init();
		if (this.m_Rigidbody == null)
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x000300B0 File Offset: 0x0002E2B0
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
			this.m_ActiveChair.SetActive(false);
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
			string text = string.Empty;
			float num = 0f;
			if (weaponInfo.ImpactType == ImpactType.AXE)
			{
				text = "GamePlay/Decals/Axe_Hit_Effect";
			}
			else if (weaponInfo.ImpactType == ImpactType.BLUNT)
			{
				text = "GamePlay/Decals/Blunt_Hit_Effect";
				num = global::UnityEngine.Random.Range(0f, 360f);
			}
			if (!string.IsNullOrEmpty(text))
			{
				GameObject fromPool = GameManager.Instance.PoolingManager.GetFromPool(text);
				fromPool.transform.position = hit.point;
				fromPool.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
				Vector3 localEulerAngles = fromPool.transform.localEulerAngles;
				localEulerAngles.z = num;
				fromPool.transform.localEulerAngles = localEulerAngles;
				fromPool.transform.SetParent(base.transform);
			}
			if (this.m_Rigidbody != null)
			{
				this.m_Rigidbody.AddExplosionForce(10f, hit.point, 10f, 1f, ForceMode.Impulse);
			}
		}
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040002E6 RID: 742
	[SerializeField]
	private Rigidbody m_Rigidbody;

	// Token: 0x040002E7 RID: 743
	[SerializeField]
	private GameObject m_ActiveChair;

	// Token: 0x040002E8 RID: 744
	[SerializeField]
	private GameObject m_Broken;

	// Token: 0x040002E9 RID: 745
	private int m_HitCount;

	// Token: 0x040002EA RID: 746
	private int m_HitMax = 3;
}

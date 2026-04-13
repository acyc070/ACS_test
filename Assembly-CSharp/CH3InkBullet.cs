using System;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class CH3InkBullet : TMGMonoBehaviour
{
	// Token: 0x06000912 RID: 2322 RVA: 0x0004B8E4 File Offset: 0x00049AE4
	public void OnParticleCollision(GameObject other)
	{
		int safeCollisionEventSize = this.m_Particles.GetSafeCollisionEventSize();
		this.m_ParticleCollisionEvents = null;
		this.m_ParticleCollisionEvents = new List<ParticleCollisionEvent>(safeCollisionEventSize);
		int collisionEvents = this.m_Particles.GetCollisionEvents(other, this.m_ParticleCollisionEvents);
		for (int i = 0; i < collisionEvents; i++)
		{
			ParticleCollisionEvent particleCollisionEvent = this.m_ParticleCollisionEvents[i];
			IHittable component = other.GetComponent<IHittable>();
			if (component != null)
			{
				RaycastHit raycastHit = default(RaycastHit);
				raycastHit.point = particleCollisionEvent.intersection;
				raycastHit.normal = particleCollisionEvent.normal;
				WeaponInfo weaponInfo = new WeaponInfo();
				weaponInfo.Damage = 2;
				weaponInfo.ImpactType = ImpactType.BLUNT;
				weaponInfo.IsBullet = true;
				weaponInfo.Attacker = GameManager.Instance.Player.gameObject;
				weaponInfo.Audio = new List<AudioClip>();
				weaponInfo.Audio.Add(GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/SFX/Gun/SFX_Ink_Gun_Impact"));
				component.Hit(raycastHit, weaponInfo);
			}
		}
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x0000943D File Offset: 0x0000763D
	protected override void OnDisposed()
	{
		this.m_ParticleCollisionEvents = null;
		base.OnDisposed();
	}

	// Token: 0x04000761 RID: 1889
	[SerializeField]
	private ParticleSystem m_Particles;

	// Token: 0x04000762 RID: 1890
	private List<ParticleCollisionEvent> m_ParticleCollisionEvents;
}

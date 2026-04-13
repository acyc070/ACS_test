using System;
using System.Collections.Generic;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200000D RID: 13
	public class S13ParticleTrigger : MonoBehaviour
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00002654 File Offset: 0x00000854
		private void Start()
		{
			this.m_Particles = base.GetComponent<ParticleSystem>();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00021994 File Offset: 0x0001FB94
		private void OnParticleTrigger()
		{
			if (!this.m_Particles || !this.m_AudioSource)
			{
				return;
			}
			int triggerParticles = this.m_Particles.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, this.enter);
			if (triggerParticles > 0)
			{
				this.m_AudioSource.Play();
			}
		}

		// Token: 0x0400003B RID: 59
		[SerializeField]
		private S13AudioSource m_AudioSource;

		// Token: 0x0400003C RID: 60
		private ParticleSystem m_Particles;

		// Token: 0x0400003D RID: 61
		private List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
	}
}

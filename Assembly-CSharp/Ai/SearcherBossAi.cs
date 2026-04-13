using System;
using UnityEngine;

namespace Ai
{
	// Token: 0x020001B3 RID: 435
	public class SearcherBossAi : BaseAiController
	{
		// Token: 0x06001288 RID: 4744 RVA: 0x0000F773 File Offset: 0x0000D973
		public override void Init()
		{
			base.Init();
			this.m_DripEffect.SetActive(false);
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x00074718 File Offset: 0x00072918
		public override void InitOnComplete()
		{
			this.m_AppearClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Appear/");
			this.m_IdleClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Idle/");
			this.m_AttackClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Attack/");
			this.m_DeathClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Death/");
			this.m_HitClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Hit/");
			base.InitOnComplete();
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x000747B0 File Offset: 0x000729B0
		public override void Activate()
		{
			base.Activate();
			base.SendOnActive();
			this.PlayAudio(ref this.m_AppearClips, true);
			this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
			base.transform.rotation = base.FaceDirection(false, 1f);
			this.m_ModelRenderer.enabled = true;
			this.m_HasIdleAudio = true;
			this.m_IdleAudio = this.PlayAudio(ref this.m_IdleClips, false);
			this.m_IdleAudioTimerLimit = this.m_IdleAudio.AudioClip.length + 0.5f;
			this.m_InkPuddle.Play();
			this.m_DripEffect.SetActive(true);
			this.InkSplash(true);
			base.transform.eulerAngles = new Vector3(0f, global::UnityEngine.Random.Range(0f, 360f), 0f);
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x00074894 File Offset: 0x00072A94
		private void InkSplash(bool isInitial)
		{
			if (this.m_InkDeathEffect != null && this.m_InkDeathEffect.Count > 0)
			{
				this.m_InkDeathEffect[0].InkExplosion.OnExplode += this.HandleDeathOnComplete;
				for (int i = 0; i < this.m_InkDeathEffect.Count; i++)
				{
					BaseAiController.InkDeathEffect inkDeathEffect = this.m_InkDeathEffect[i];
					if (isInitial)
					{
						inkDeathEffect.InkExplosion.Birth(inkDeathEffect.Renderer);
					}
					else
					{
						inkDeathEffect.InkExplosion.Activate(inkDeathEffect.Renderer, 0f, 0.6f);
					}
				}
			}
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x00074940 File Offset: 0x00072B40
		protected override void Update()
		{
			base.Update();
			this.m_IdleAudioTimer += Time.deltaTime;
			if (this.m_HasIdleAudio && this.m_IdleAudioTimer > this.m_IdleAudioTimerLimit && (this.m_IdleAudio == null || !this.m_IdleAudio.AudioSource.isPlaying))
			{
				this.m_IdleAudioTimer = 0f;
				this.m_IdleAudio = this.PlayAudio(ref this.m_IdleClips, false);
				this.m_IdleAudioTimerLimit = this.m_IdleAudio.AudioClip.length + global::UnityEngine.Random.Range(0.5f, 1f);
			}
			Vector3 vector = this.m_DraggerFoot.position;
			vector.y = this.m_InkPuddle.transform.position.y;
			vector += base.transform.forward;
			this.m_InkPuddle.transform.position = vector;
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x0000F6EF File Offset: 0x0000D8EF
		protected override void T_EnterIdle()
		{
			base.T_EnterIdle();
			if (!this.m_CharacterController.enabled)
			{
				this.m_CharacterController.enabled = true;
			}
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x0000DE5E File Offset: 0x0000C05E
		protected override void T_EnterRetreat()
		{
			base.T_EnterRetreat();
			base.SetThought(AiThought.Idle);
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x0000F787 File Offset: 0x0000D987
		public override void AttackTarget()
		{
			base.AttackTarget();
			this.PlayAudio(ref this.m_AttackClips, false);
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x0000F79D File Offset: 0x0000D99D
		public override void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
		{
			if (weaponInfo == null)
			{
				return;
			}
			this.PlayAudio(ref this.m_HitClips, true);
			base.Hit(hit, weaponInfo);
		}

		// Token: 0x06001291 RID: 4753 RVA: 0x00074A3C File Offset: 0x00072C3C
		protected override void T_EnterDie()
		{
			this.m_HasIdleAudio = false;
			if (this.m_IdleAudio != null)
			{
				this.m_IdleAudio.Clear();
				this.m_IdleAudio = null;
			}
			this.PlayAudio(ref this.m_DeathClips, true);
			base.SetTarget(null);
			base.tag = "Dead";
			base.SetMoveDirection(Vector3.zero);
			this.m_CharacterController.enabled = false;
			base.SetAnimationTrigger("Dead");
			this.InkSplash(false);
			this.m_InkPuddle.Stop();
			this.m_InkPuddle.transform.SetParent(null);
			global::UnityEngine.Object.Destroy(this.m_InkPuddle.gameObject, 5f);
			this.m_DripEffect.SetActive(false);
			base.SendOnDeath();
			base.SendOnRespawn();
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x0007443C File Offset: 0x0007263C
		private AudioObject PlayAudio(ref AudioClip[] audioClips, bool is2D = false)
		{
			if (audioClips == null || audioClips.Length <= 0)
			{
				return null;
			}
			int num = global::UnityEngine.Random.Range(0, audioClips.Length);
			AudioClip audioClip = audioClips[num];
			AudioObject audioObject;
			if (is2D)
			{
				audioObject = GameManager.Instance.AudioManager.Play(audioClip, AudioObjectType.SOUND_EFFECT, 0, false);
			}
			else
			{
				audioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioClip, this.m_EyeLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
			}
			audioClips[num] = audioClips[0];
			audioClips[0] = audioClip;
			return audioObject;
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x0000DF94 File Offset: 0x0000C194
		protected override void OnDisposed()
		{
			base.OnDisposed();
		}

		// Token: 0x04000EE5 RID: 3813
		[Header("<== Searcher OPTIONS ==>")]
		[SerializeField]
		private GameObject m_DripEffect;

		// Token: 0x04000EE6 RID: 3814
		[SerializeField]
		private ParticleSystem m_InkPuddle;

		// Token: 0x04000EE7 RID: 3815
		[SerializeField]
		private Transform m_DraggerFoot;

		// Token: 0x04000EE8 RID: 3816
		[SerializeField]
		private Renderer m_ModelRenderer;

		// Token: 0x04000EE9 RID: 3817
		private AudioClip[] m_AppearClips;

		// Token: 0x04000EEA RID: 3818
		private AudioClip[] m_IdleClips;

		// Token: 0x04000EEB RID: 3819
		private AudioClip[] m_HitClips;

		// Token: 0x04000EEC RID: 3820
		private AudioClip[] m_AttackClips;

		// Token: 0x04000EED RID: 3821
		private AudioClip[] m_DeathClips;

		// Token: 0x04000EEE RID: 3822
		private AudioObject m_IdleAudio;

		// Token: 0x04000EEF RID: 3823
		private bool m_HasIdleAudio;

		// Token: 0x04000EF0 RID: 3824
		private float m_IdleAudioTimer;

		// Token: 0x04000EF1 RID: 3825
		private float m_IdleAudioTimerLimit = 10f;
	}
}

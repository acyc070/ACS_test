using System;
using System.Collections;
using UnityEngine;

namespace Ai
{
	// Token: 0x020001B1 RID: 433
	public class SearcherAi : BaseAiController
	{
		// Token: 0x06001271 RID: 4721 RVA: 0x0000F698 File Offset: 0x0000D898
		public override void Init()
		{
			base.Init();
			this.m_DripEffect.SetActive(false);
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00073F64 File Offset: 0x00072164
		public override void InitOnComplete()
		{
			base.InitOnComplete();
			this.m_AppearClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Appear/");
			this.m_IdleClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Idle/");
			this.m_AttackClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Attack/");
			this.m_DeathClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Death/");
			this.m_HitClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/Searchers/Hit/");
			this.m_ModelRenderer.enabled = false;
			this.m_CharacterController.enabled = false;
			if (this.m_HasInkPool)
			{
				Transform transform = GameManager.Instance.AssetManager.CreateAsset<Transform>("GamePlay/Particles/Searcher_SpawnPool");
				transform.position = base.transform.position;
				transform.eulerAngles = new Vector3(0f, global::UnityEngine.Random.Range(0f, 360f), 0f);
			}
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x0000F229 File Offset: 0x0000D429
		public override void Activate()
		{
			base.Activate();
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x00074068 File Offset: 0x00072268
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
						if (!this.m_IgnoreSpawnInkExplosion)
						{
							inkDeathEffect.InkExplosion.Birth(inkDeathEffect.Renderer);
						}
						else
						{
							inkDeathEffect.InkExplosion.ExplodeOnly();
						}
					}
					else
					{
						inkDeathEffect.InkExplosion.Activate(inkDeathEffect.Renderer, 0f, 0.6f);
					}
				}
			}
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x00074130 File Offset: 0x00072330
		protected override void Update()
		{
			base.Update();
			if (base.IsDisposed || GameManager.Instance.isPaused)
			{
				return;
			}
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

		// Token: 0x06001276 RID: 4726 RVA: 0x0000F6AC File Offset: 0x0000D8AC
		protected override void T_EnterDistanceActivation()
		{
			base.T_EnterDistanceActivation();
			this.m_StartingThought = AiThought.Retreat;
			this.m_ModelRenderer.enabled = false;
			this.m_CharacterController.enabled = false;
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x00074244 File Offset: 0x00072444
		protected override void T_EnterActivate()
		{
			base.T_EnterActivate();
			base.SendOnActive();
			this.PlayAudio(ref this.m_AppearClips, false);
			this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
			base.transform.rotation = base.FaceDirection(false, 1f);
			this.m_ModelRenderer.enabled = true;
			this.m_HasIdleAudio = true;
			this.m_IdleAudio = this.PlayAudio(ref this.m_IdleClips, false);
			this.m_IdleAudioTimerLimit = this.m_IdleAudio.AudioClip.length + 0.5f;
			this.m_InkPuddle.Play();
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x0000F6D4 File Offset: 0x0000D8D4
		protected override void T_Activate()
		{
			base.T_Activate();
			this.m_DripEffect.SetActive(true);
			this.InkSplash(true);
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x0000F6EF File Offset: 0x0000D8EF
		protected override void T_EnterIdle()
		{
			base.T_EnterIdle();
			if (!this.m_CharacterController.enabled)
			{
				this.m_CharacterController.enabled = true;
			}
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x000742EC File Offset: 0x000724EC
		protected override void T_EnterRetreat()
		{
			base.T_EnterRetreat();
			this.PlayAudio(ref this.m_AppearClips, false);
			this.m_CharacterController.enabled = false;
			base.SetTarget(null);
			base.SetAnimatiorMovement(0);
			base.SetAnimatiorAttack(0);
			base.SetMoveDirection(Vector3.zero);
			base.SetAnimationTrigger("Hide");
			base.StartCoroutine(this.HideDelay());
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00074354 File Offset: 0x00072554
		private IEnumerator HideDelay()
		{
			if (base.IsDisposed)
			{
				yield return null;
			}
			float halfTime = this.m_AwakeAnimationWaitTime / 2f;
			yield return new WaitForSeconds(halfTime);
			yield return new WaitForEndOfFrame();
			if (base.IsDisposed)
			{
				yield return null;
			}
			this.InkSplash(false);
			if (this.m_InkDeathEffect != null && this.m_InkDeathEffect.Count > 0)
			{
				for (int i = 0; i < this.m_InkDeathEffect.Count; i++)
				{
					BaseAiController.InkDeathEffect inkDeathEffect = this.m_InkDeathEffect[i];
					inkDeathEffect.InkExplosion.transform.SetParent(null);
					global::UnityEngine.Object.Destroy(inkDeathEffect.InkExplosion.gameObject, 5f);
				}
			}
			yield return new WaitForSeconds(halfTime);
			yield return new WaitForEndOfFrame();
			if (base.IsDisposed)
			{
				yield return null;
			}
			this.m_InkPuddle.Stop();
			this.m_InkPuddle.transform.SetParent(null);
			global::UnityEngine.Object.Destroy(this.m_InkPuddle.gameObject, 5f);
			base.SendOnHide();
			base.SendOnRespawn();
			base.Dispose();
			yield break;
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x0000F713 File Offset: 0x0000D913
		public override void AttackTarget()
		{
			base.AttackTarget();
			this.PlayAudio(ref this.m_AttackClips, false);
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x0000F729 File Offset: 0x0000D929
		public override void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
		{
			if (weaponInfo == null)
			{
				return;
			}
			this.PlayAudio(ref this.m_HitClips, false);
			base.Hit(hit, weaponInfo);
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x00074370 File Offset: 0x00072570
		protected override void T_EnterDie()
		{
			this.m_HasIdleAudio = false;
			if (this.m_IdleAudio != null)
			{
				this.m_IdleAudio.Clear();
				this.m_IdleAudio = null;
			}
			this.PlayAudio(ref this.m_DeathClips, false);
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

		// Token: 0x0600127F RID: 4735 RVA: 0x0007443C File Offset: 0x0007263C
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

		// Token: 0x06001280 RID: 4736 RVA: 0x0000DF94 File Offset: 0x0000C194
		protected override void OnDisposed()
		{
			base.OnDisposed();
		}

		// Token: 0x04000ED1 RID: 3793
		[Header("<== Searcher OPTIONS ==>")]
		[SerializeField]
		private bool m_HasInkPool;

		// Token: 0x04000ED2 RID: 3794
		[SerializeField]
		private bool m_IgnoreSpawnInkExplosion;

		// Token: 0x04000ED3 RID: 3795
		[SerializeField]
		private GameObject m_DripEffect;

		// Token: 0x04000ED4 RID: 3796
		[SerializeField]
		private ParticleSystem m_InkPuddle;

		// Token: 0x04000ED5 RID: 3797
		[SerializeField]
		private Transform m_DraggerFoot;

		// Token: 0x04000ED6 RID: 3798
		[SerializeField]
		private Renderer m_ModelRenderer;

		// Token: 0x04000ED7 RID: 3799
		private AudioClip[] m_AppearClips;

		// Token: 0x04000ED8 RID: 3800
		private AudioClip[] m_IdleClips;

		// Token: 0x04000ED9 RID: 3801
		private AudioClip[] m_HitClips;

		// Token: 0x04000EDA RID: 3802
		private AudioClip[] m_AttackClips;

		// Token: 0x04000EDB RID: 3803
		private AudioClip[] m_DeathClips;

		// Token: 0x04000EDC RID: 3804
		private AudioObject m_IdleAudio;

		// Token: 0x04000EDD RID: 3805
		private bool m_HasIdleAudio;

		// Token: 0x04000EDE RID: 3806
		private float m_IdleAudioTimer;

		// Token: 0x04000EDF RID: 3807
		private float m_IdleAudioTimerLimit = 10f;
	}
}

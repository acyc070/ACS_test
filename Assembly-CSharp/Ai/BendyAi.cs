using System;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;

namespace Ai
{
	// Token: 0x0200019C RID: 412
	public class BendyAi : BaseAiController
	{
		// Token: 0x14000064 RID: 100
		// (add) Token: 0x06001107 RID: 4359 RVA: 0x0006ED18 File Offset: 0x0006CF18
		// (remove) Token: 0x06001108 RID: 4360 RVA: 0x0006ED50 File Offset: 0x0006CF50
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnTrackingLost;

		// Token: 0x06001109 RID: 4361 RVA: 0x0006ED88 File Offset: 0x0006CF88
		protected override void Update()
		{
			base.Update();
			if (GameManager.Instance.InkEffectManager != null)
			{
				GameManager.Instance.InkEffectManager.SetPosition(base.transform.position);
			}
			if (GameManager.Instance.Player && GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
			{
				return;
			}
			if (GameManager.Instance.Player && Vector3.Distance(this.m_KneeLocation.position, GameManager.Instance.Player.transform.position) < 5f)
			{
				for (int i = 0; i < 6; i++)
				{
					GameManager.Instance.ShowHurtBorder(false);
				}
				return;
			}
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0006EE50 File Offset: 0x0006D050
		public override void Activate()
		{
			base.Activate();
			GameManager.Instance.InkEffectManager = new GlobalInkEffectManager();
			GameManager.Instance.InkEffectManager.GetEffects();
			GameManager.Instance.InkEffectManager.SetActive(true, false);
			GameManager.Instance.CharacterManager.Bendy = this;
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
		protected override void T_EnterInactive()
		{
			base.T_EnterInactive();
			base.SetAnimatiorMovement(0);
			DOTween.Sequence().InsertCallback(2f, delegate
			{
				base.SetThought(AiThought.UseWaypoints);
			});
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0000E50B File Offset: 0x0000C70B
		protected override void T_EnterUseWaypoints()
		{
			this.m_WalkMode = 1;
			base.T_EnterUseWaypoints();
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x0006EEA4 File Offset: 0x0006D0A4
		protected override void T_UseWaypoints()
		{
			RaycastHit raycastHit;
			if (GameManager.Instance.Player && Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) < 30f && GameManager.Instance.Player.CurrentStatus != CombatStatus.Hiding && !this.m_PassiveAi && !Physics.Linecast(this.m_KneeLocation.position, GameManager.Instance.Player.transform.position, out raycastHit, this.m_ObstructionLayers))
			{
				this.m_WalkMode = 2;
				base.SetTarget(GameManager.Instance.Player.transform);
				base.DoWait(this.m_SpottedAnimationWaitTime, AiThought.Follow, null);
				base.CurrentTarget = GameManager.Instance.Player.transform;
				this.m_TrackObjectPosition = base.CurrentTarget.position;
				base.transform.rotation = base.FaceDirection(false, 1f);
				base.SetAnimationTrigger("EnemySpotted");
				base.SendOnSpotted();
				return;
			}
			base.T_UseWaypoints();
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0000E51A File Offset: 0x0000C71A
		protected override void T_Follow()
		{
			if (GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
			{
				base.SetThought(AiThought.UseWaypoints);
				return;
			}
			base.T_Follow();
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0000E53F File Offset: 0x0000C73F
		protected override bool TrackingLostEvents(AiThought _repalcementThought)
		{
			if (base.TrackingLostEvents(_repalcementThought))
			{
				this.OnTrackingLost.Send(this);
				return true;
			}
			return false;
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0000E55C File Offset: 0x0000C75C
		protected override void T_EnterRetreat()
		{
			base.T_EnterRetreat();
			base.SetThought(AiThought.UseWaypoints);
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0000E56B File Offset: 0x0000C76B
		public void UpdateWaypointList(List<WaypointNode> waypointList, bool _isActive = false)
		{
			this.m_CurrentWaypointList.Clear();
			this.m_WaypointIndex = 0;
			this.m_CurrentWaypointList = new List<WaypointNode>(waypointList);
			this.m_StartingThought = AiThought.UseWaypoints;
			if (_isActive)
			{
				base.SetThought(AiThought.UseWaypoints);
			}
			else
			{
				base.SetThought(AiThought.Inactive);
			}
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0000DF8B File Offset: 0x0000C18B
		public void ForceSetAnimationTrigger(string animation)
		{
			base.SetAnimationTrigger(animation);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0006EFC8 File Offset: 0x0006D1C8
		public void ForceKill()
		{
			this.m_InkEffect.transform.SetParent(null);
			this.m_InkExplosion.Emit(30);
			this.m_InkDrops.Emit(20);
			global::UnityEngine.Object.Destroy(this.m_InkEffect, 5f);
			base.Dispose();
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0006F018 File Offset: 0x0006D218
		private void ClearAudioSources()
		{
			for (int i = 0; i < this.m_AudioSources.Count; i++)
			{
				AudioSource audioSource = this.m_AudioSources[i];
				audioSource.transform.SetParent(null);
				audioSource.DOFade(0f, 2f);
				global::UnityEngine.Object.Destroy(audioSource.gameObject, 2.05f);
			}
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x0000E5AB File Offset: 0x0000C7AB
		protected override void OnDisposed()
		{
			GameManager.Instance.CharacterManager.Bendy = null;
			GameManager.Instance.InkEffectManager.SetActive(false, false);
			this.ClearAudioSources();
			base.OnDisposed();
		}

		// Token: 0x04000DE8 RID: 3560
		[Header("<== BENDY OPTIONS ==>")]
		[SerializeField]
		private GameObject m_InkEffect;

		// Token: 0x04000DE9 RID: 3561
		[SerializeField]
		private ParticleSystem m_InkExplosion;

		// Token: 0x04000DEA RID: 3562
		[SerializeField]
		private ParticleSystem m_InkDrops;

		// Token: 0x04000DEB RID: 3563
		[Header("AudioSources")]
		[SerializeField]
		private List<AudioSource> m_AudioSources;
	}
}

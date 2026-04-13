using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Ai
{
	// Token: 0x02000197 RID: 407
	public class BaseAiController : AiThoughtMachine, IHittable
	{
		// Token: 0x1400005C RID: 92
		// (add) Token: 0x06001090 RID: 4240 RVA: 0x0006C1B8 File Offset: 0x0006A3B8
		// (remove) Token: 0x06001091 RID: 4241 RVA: 0x0006C1F0 File Offset: 0x0006A3F0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnWaypointComplete;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06001092 RID: 4242 RVA: 0x0006C228 File Offset: 0x0006A428
		// (remove) Token: 0x06001093 RID: 4243 RVA: 0x0006C260 File Offset: 0x0006A460
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnDeath;

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06001094 RID: 4244 RVA: 0x0006C298 File Offset: 0x0006A498
		// (remove) Token: 0x06001095 RID: 4245 RVA: 0x0006C2D0 File Offset: 0x0006A4D0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnHide;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06001096 RID: 4246 RVA: 0x0006C308 File Offset: 0x0006A508
		// (remove) Token: 0x06001097 RID: 4247 RVA: 0x0006C340 File Offset: 0x0006A540
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnRespawn;

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06001098 RID: 4248 RVA: 0x0006C378 File Offset: 0x0006A578
		// (remove) Token: 0x06001099 RID: 4249 RVA: 0x0006C3B0 File Offset: 0x0006A5B0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnDistanceActivate;

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x0600109A RID: 4250 RVA: 0x0006C3E8 File Offset: 0x0006A5E8
		// (remove) Token: 0x0600109B RID: 4251 RVA: 0x0006C420 File Offset: 0x0006A620
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnActivate;

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x0600109C RID: 4252 RVA: 0x0006C458 File Offset: 0x0006A658
		// (remove) Token: 0x0600109D RID: 4253 RVA: 0x0006C490 File Offset: 0x0006A690
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnSpotted;

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x0600109E RID: 4254 RVA: 0x0006C4C8 File Offset: 0x0006A6C8
		// (remove) Token: 0x0600109F RID: 4255 RVA: 0x0006C500 File Offset: 0x0006A700
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnRetreat;

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060010A0 RID: 4256 RVA: 0x0000DFAF File Offset: 0x0000C1AF
		public Animator AnimationController
		{
			get
			{
				return this.m_AnimationController;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x0000DFB7 File Offset: 0x0000C1B7
		// (set) Token: 0x060010A2 RID: 4258 RVA: 0x0000DFBF File Offset: 0x0000C1BF
		public Transform CurrentTarget { get; protected set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060010A3 RID: 4259 RVA: 0x0000DFC8 File Offset: 0x0000C1C8
		// (set) Token: 0x060010A4 RID: 4260 RVA: 0x0000DFD0 File Offset: 0x0000C1D0
		public Transform PreviousTarget { get; protected set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060010A5 RID: 4261 RVA: 0x0000DFD9 File Offset: 0x0000C1D9
		// (set) Token: 0x060010A6 RID: 4262 RVA: 0x0000DFE1 File Offset: 0x0000C1E1
		public Vector3 OriginPosition { get; protected set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060010A7 RID: 4263 RVA: 0x0000DFEA File Offset: 0x0000C1EA
		public bool isGrounded
		{
			get
			{
				return this.m_CharacterController.isGrounded;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060010A8 RID: 4264 RVA: 0x0000DFF7 File Offset: 0x0000C1F7
		// (set) Token: 0x060010A9 RID: 4265 RVA: 0x0000DFFF File Offset: 0x0000C1FF
		public GameObject Attacker { get; private set; }

		// Token: 0x060010AA RID: 4266 RVA: 0x0006C538 File Offset: 0x0006A738
		public override void Init()
		{
			base.Init();
			this.m_CharacterController = base.GetComponent<CharacterController>();
			this.m_SightMask = 1 << LayerMask.NameToLayer("Default");
			this.m_AnimationController.logWarnings = false;
			this.m_WeaponInfo = new WeaponInfo();
			this.m_WeaponInfo.Attacker = base.gameObject;
			this.m_WeaponInfo.Damage = (int)this.m_AttackPower;
			this.m_RaycastHit = default(RaycastHit);
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0006C5B8 File Offset: 0x0006A7B8
		public override void InitOnComplete()
		{
			base.InitOnComplete();
			this.m_HitAudio = GameManager.Instance.GetAudioClips("Audio/SFX/Weapons/HitEnemy/");
			this.m_AnimationController.gameObject.AddComponent<AnimationEventController>().Init(this);
			for (int i = 0; i < this.m_AnimationSettings.Count; i++)
			{
				BaseAiController.AnimationSettings animationSettings = this.m_AnimationSettings[i];
				AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, animationSettings.Clip.name, "AttackTarget", animationSettings.Frame);
			}
			if (this.m_RagdollParent)
			{
				Ragdoll[] componentsInChildren = this.m_RagdollParent.GetComponentsInChildren<Ragdoll>();
				this.m_Ragdolls = new List<Ragdoll>();
				foreach (Ragdoll ragdoll in componentsInChildren)
				{
					ragdoll.Initialize();
					this.m_Ragdolls.Add(ragdoll);
				}
			}
			base.SetThought(this.m_StartingThought);
			this.m_TrackObjectPosition = base.transform.position + base.transform.forward * 10f;
			this.Activate();
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x0000E008 File Offset: 0x0000C208
		public override void Activate()
		{
			base.Activate();
			this.m_CurrentHealth = this.m_Health;
			this.SetAnimatiorMovement(0);
			GameManager.Instance.AiGlobalNetwork.AddAi(this);
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x0006C6C4 File Offset: 0x0006A8C4
		protected override void T_EnterDie()
		{
			base.T_EnterDie();
			this.SetTarget(null);
			base.tag = "Dead";
			this.SetMoveDirection(Vector3.zero);
			this.m_CharacterController.enabled = false;
			CapsuleCollider component = base.GetComponent<CapsuleCollider>();
			if (component)
			{
				component.enabled = false;
			}
			if (this.m_RagdollParent)
			{
				this.m_AnimationController.enabled = false;
				for (int i = 0; i < this.m_Ragdolls.Count; i++)
				{
					Ragdoll ragdoll = this.m_Ragdolls[i];
					Vector3 vector = this.m_HitPosition + new Vector3(0f, -0.5f, 0f);
					ragdoll.Activate(50f, vector, 10f, -1f);
				}
			}
			else
			{
				this.SetAnimationTrigger("Dead");
			}
			if (this.m_InkDeathEffect != null && this.m_InkDeathEffect.Count > 0)
			{
				BaseAiController.InkDeathEffect inkDeathEffect = this.m_InkDeathEffect[0];
				if (inkDeathEffect.InkExplosion)
				{
					inkDeathEffect.InkExplosion.OnExplode += this.HandleDeathOnComplete;
				}
				for (int j = 0; j < this.m_InkDeathEffect.Count; j++)
				{
					BaseAiController.InkDeathEffect inkDeathEffect2 = this.m_InkDeathEffect[j];
					if (inkDeathEffect2.InkExplosion)
					{
						inkDeathEffect2.InkExplosion.Activate(inkDeathEffect2.Renderer, 2f, 2f);
					}
				}
			}
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0000E033 File Offset: 0x0000C233
		protected virtual void HandleDeathOnComplete(object sender, EventArgs e)
		{
			(sender as InkExplosionEffect).OnExplode -= this.HandleDeathOnComplete;
			base.Dispose();
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0006C838 File Offset: 0x0006AA38
		protected override void T_Wait()
		{
			base.T_Wait();
			this.SetMoveDirection(Vector3.zero);
			this.SetAnimatiorMovement(0);
			if (this.m_WaitTimer <= 0f)
			{
				if (this.m_WaitCallback != null)
				{
					this.m_WaitCallback();
				}
				base.SetThought(this.m_NextThought);
			}
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x0006C88C File Offset: 0x0006AA8C
		protected override void T_DistanceActivation()
		{
			Vector3 position = GameManager.Instance.Player.transform.position;
			if (Vector3.Distance(base.transform.position, position) < this.m_ActivationDistance && !Physics.Linecast(this.m_EyeLocation.position, position, this.m_SightMask))
			{
				base.SetThought(AiThought.Activate);
				this.SetTarget(GameManager.Instance.Player.transform);
			}
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x0000E053 File Offset: 0x0000C253
		protected override void T_Activate()
		{
			this.SetAnimationTrigger("Birth");
			this.SetPhysicsEnabled(false);
			this.DoWait(this.m_AwakeAnimationWaitTime, AiThought.Idle, null);
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x0006C904 File Offset: 0x0006AB04
		protected override void T_Idle()
		{
			if (!this.CheckPhysicsEnabled())
			{
				this.SetPhysicsEnabled(true);
			}
			if (!this.CurrentTarget || Vector3.Distance(base.transform.position, this.CurrentTarget.position) > this.m_AttackDistance)
			{
				this.SetAnimatiorMovement(0);
			}
			else if (base.WasInThought(AiThought.Follow) && base.CurrentThought == AiThought.Attack)
			{
				this.SetAnimatiorMovement(1);
			}
			this.SetMoveDirection(Vector3.zero);
			this.m_TrackObjectPosition = base.transform.position + base.transform.forward * 10f;
			if (!this.m_PassiveAi)
			{
				if (GameManager.Instance.Player != null && GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
				{
					base.SetThought(AiThought.Retreat);
					return;
				}
				if (!this.CurrentTarget)
				{
					this.SetTarget(this.TestTargetVisibility());
					return;
				}
				base.SetThought(AiThought.Attack);
			}
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x0000E075 File Offset: 0x0000C275
		protected override void T_EnterAttack()
		{
			base.T_EnterAttack();
			this.m_WaypointIndex = 0;
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x0006CA00 File Offset: 0x0006AC00
		protected override void T_Attack()
		{
			if (!this.CurrentTarget || this.m_PassiveAi)
			{
				base.SetThought(AiThought.Idle);
				return;
			}
			if (this.CurrentTarget.tag == "Dead")
			{
				this.CurrentTarget = null;
				base.SetThought(AiThought.Idle);
				return;
			}
			if (this.CurrentTarget == GameManager.Instance.Player.transform && GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
			{
				base.SetThought(AiThought.Retreat);
				return;
			}
			if (this.m_AvoidanceCooldownTime <= 0f)
			{
				this.m_TrackObjectPosition = this.CurrentTarget.position;
			}
			if (Vector3.Angle(base.transform.forward, new Vector3(this.CurrentTarget.position.x, base.transform.position.y, this.CurrentTarget.position.z) - base.transform.position) > 40f)
			{
				base.SetThought(AiThought.Follow);
				return;
			}
			if (Vector3.Distance(base.transform.position, this.CurrentTarget.position) < this.m_AttackDistanceBuffer && !Physics.Linecast(this.m_KneeLocation.position, this.OffsetTargetPosition(), this.m_ObstructionLayers))
			{
				int num = global::UnityEngine.Random.Range(0, this.m_AnimationSettings.Count);
				float length = this.m_AnimationSettings[num].Clip.length;
				this.m_AttackDistanceBuffer = this.m_AttackDistance;
				base.transform.rotation = this.FaceDirection(true, 1f);
				this.DoWait(length + 0.25f, AiThought.Idle, null);
				this.StartAttack(num);
				return;
			}
			base.SetThought(AiThought.Follow);
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x0000E084 File Offset: 0x0000C284
		public virtual void SetVectorPoint(Vector3 point)
		{
			this.m_MoveToVectorPoint = point;
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0006CBBC File Offset: 0x0006ADBC
		protected override void T_MoveToPoint()
		{
			this.SolvePathMovement(this.m_MoveToVectorPoint);
			this.CheckSpeed(this.m_UseRunForWaypoints);
			this.SetMoveDirection(base.transform.forward);
			if (Vector3.Distance(base.transform.position, this.m_MoveToVectorPoint) < this.m_DistanceToAcceptNodeReached)
			{
				this.OnMoveToPointReached();
			}
			if (!this.m_PassiveAi)
			{
				if (!this.CurrentTarget)
				{
					this.SetTarget(this.TestTargetVisibility());
					return;
				}
				base.SetThought(AiThought.Attack);
			}
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x0000DD5B File Offset: 0x0000BF5B
		protected virtual void OnMoveToPointReached()
		{
			base.SetThought(base.PreviousThought);
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x0000E08D File Offset: 0x0000C28D
		protected override void T_EnterUseWaypoints()
		{
			base.T_EnterUseWaypoints();
			this.CurrentTarget = null;
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0006CC40 File Offset: 0x0006AE40
		protected override void T_UseWaypoints()
		{
			if (this.m_WaypointMode == AiWaypointMode.None)
			{
				base.SetThought(AiThought.Idle);
				return;
			}
			if (this.m_WaypointMode == AiWaypointMode.Incremental && this.m_WaypointIndex >= this.m_CurrentWaypointList.Count)
			{
				if (this.m_UseRotateAtEndWaypoint && this.m_CurrentWaypointList.Count > 0)
				{
					Transform transform = this.m_CurrentWaypointList[this.m_CurrentWaypointList.Count - 1].transform;
					this.m_TrackObjectPosition = transform.position + transform.forward;
					Quaternion quaternion = Quaternion.LookRotation(transform.forward);
					base.transform.rotation = quaternion;
				}
				base.SetThought(AiThought.Idle);
				this.SendOnWaypointComplete();
				return;
			}
			this.SetMoveDirection(Vector3.zero);
			Transform transform2 = null;
			this.m_WaypointIndex = Mathf.Clamp(this.m_WaypointIndex, 0, this.m_CurrentWaypointList.Count);
			Vector3 vector = Vector3.zero;
			if (this.m_CurrentWaypointList != null && this.m_CurrentWaypointList.Count > 0)
			{
				transform2 = this.m_CurrentWaypointList[this.m_WaypointIndex].transform;
				if (Vector3.Distance(base.transform.position, transform2.position) < this.m_TimescaleDistanceIncrease)
				{
					if (this.m_WaypointMode == AiWaypointMode.Roam)
					{
						this.m_WaypointIndex = global::UnityEngine.Random.Range(0, this.m_CurrentWaypointList.Count);
					}
					else if (this.m_WaypointMode == AiWaypointMode.Loop)
					{
						this.m_WaypointIndex++;
						if (this.m_WaypointIndex >= this.m_CurrentWaypointList.Count)
						{
							this.m_WaypointIndex = 0;
						}
					}
					else if (this.m_WaypointMode == AiWaypointMode.PingPing)
					{
						this.m_WaypointIndex++;
						if (this.m_WaypointIndex >= this.m_CurrentWaypointList.Count)
						{
							this.m_CurrentWaypointList.Reverse();
							this.m_WaypointIndex = 0;
						}
					}
					else if (this.m_WaypointMode == AiWaypointMode.Incremental)
					{
						this.m_WaypointIndex++;
					}
				}
			}
			if (this.m_WaypointMode == AiWaypointMode.Follow_Ai)
			{
				if (this.m_CurrentAiToFollow)
				{
					if (this.AiToFollow_Offset == Vector3.zero)
					{
						this.AiToFollow_Offset = new Vector3((float)global::UnityEngine.Random.Range(-1, 2), 0f, (float)global::UnityEngine.Random.Range(-1, 1));
						if (this.AiToFollow_Offset.x == 0f && this.AiToFollow_Offset.z == 0f)
						{
							this.AiToFollow_Offset.z = -1f;
						}
						this.AiToFollow_Offset *= 4f;
					}
					transform2 = this.m_CurrentAiToFollow.transform;
					vector = this.m_CurrentAiToFollow.transform.TransformDirection(this.AiToFollow_Offset);
				}
				else
				{
					this.m_WaypointMode = AiWaypointMode.Roam;
				}
			}
			if (transform2)
			{
				this.CheckSpeed(this.m_UseRunForWaypoints);
				if (!this.SolvePathMovement(transform2.position + vector))
				{
					if (Vector3.Distance(base.transform.position, transform2.position) < this.m_TimescaleDistanceIncrease)
					{
						this.SetMoveDirection(Vector3.zero);
						this.m_WaypointIndex++;
					}
				}
				else if (this.m_CurrentPath != null && this.m_CurrentPath.Count > 0)
				{
					this.SetMoveDirection(base.transform.forward);
				}
				else
				{
					this.SetMoveDirection(base.transform.forward);
					this.SolvePathMovement(transform2.position);
				}
			}
			else if (this.CurrentTarget)
			{
				this.SolvePathMovement(this.OffsetTargetPosition());
				this.SetMoveDirection(base.transform.forward);
			}
			else
			{
				base.SetThought(AiThought.Idle);
			}
			if (!this.m_PassiveAi)
			{
				if (!this.CurrentTarget)
				{
					this.SetTarget(this.TestTargetVisibility());
					return;
				}
				base.SetThought(AiThought.Attack);
			}
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0000E09C File Offset: 0x0000C29C
		protected override void T_EnterFollow()
		{
			base.T_EnterFollow();
			if (this.CurrentTarget && !this.m_PassiveAi)
			{
				this.SolvePathMovement(this.OffsetTargetPosition());
			}
			this.m_AttackDistanceBuffer = this.m_AttackDistance;
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x0006CFF0 File Offset: 0x0006B1F0
		protected override void T_Follow()
		{
			this.SetMoveDirection(Vector3.zero);
			if (this.CurrentTarget == GameManager.Instance.Player.transform && GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
			{
				base.SetThought(AiThought.UseWaypoints);
				return;
			}
			if (this.TestLoseTracking())
			{
				return;
			}
			if (Vector3.Distance(base.transform.position, this.CurrentTarget.position) < this.m_AttackDistanceBuffer)
			{
				this.m_AttackDistanceBuffer = this.m_AttackDistance + 8f;
				if (!Physics.Linecast(this.m_KneeLocation.position, this.OffsetTargetPosition(), this.m_ObstructionLayers))
				{
					base.SetThought(AiThought.Idle);
					return;
				}
			}
			else
			{
				this.m_AttackDistanceBuffer = this.m_AttackDistance;
			}
			if (!Physics.Linecast(this.m_KneeLocation.position, this.OffsetTargetPosition(), this.m_ObstructionLayers))
			{
				global::UnityEngine.Debug.DrawLine(this.m_KneeLocation.position, this.CurrentTarget.position);
				this.m_CurrentPath = null;
				if (this.m_AvoidanceCooldownTime > 0f)
				{
					this.m_TrackObjectPosition = this.CurrentTarget.position;
				}
			}
			else
			{
				this.SolvePathMovement(this.OffsetTargetPosition());
				if (this.TestLoseTracking())
				{
					return;
				}
			}
			this.CheckSpeed(Vector3.Distance(base.transform.position, this.CurrentTarget.position) >= this.m_RunDistanceBuffer);
			this.SetMoveDirection(base.transform.forward);
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void FixedUpdate()
		{
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x0006D16C File Offset: 0x0006B36C
		protected virtual void Update()
		{
			if (base.IsDisposed || GameManager.Instance.isPaused)
			{
				return;
			}
			if (!base.IsActive || base.IsInThought(AiThought.Die) || base.IsInThought(AiThought.Inactive) || base.IsInThought(AiThought.DistanceActivation) || base.IsInThought(AiThought.Activate))
			{
				return;
			}
			if (base.IsInThought(AiThought.Wait))
			{
				this.m_WaitTimer -= Time.deltaTime;
				base.transform.rotation = this.FaceDirection(true, 1f);
				return;
			}
			base.transform.rotation = this.FaceDirection(true, 1f);
			this.m_TimescaleDistanceIncrease = Mathf.Clamp(Time.unscaledDeltaTime / 0.016f / 2f, 1f, 3f);
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0006D230 File Offset: 0x0006B430
		protected virtual void LateUpdate()
		{
			if (base.IsDisposed || GameManager.Instance.isPaused)
			{
				return;
			}
			if (!base.IsActive || base.IsInThought(AiThought.Die) || base.IsInThought(AiThought.Inactive) || base.IsInThought(AiThought.DistanceActivation) || base.IsInThought(AiThought.Activate) || base.IsInThought(AiThought.Wait))
			{
				return;
			}
			if (this.m_EnableAvoidance)
			{
				this.AvoidObstacle(this.m_TrackObjectPosition);
				this.CheckIfStuck(this.m_TrackObjectPosition);
				if (Vector3.Distance(base.transform.position, this.m_TrackObjectPosition) < 0.5f)
				{
					this.SetAnimatiorMovement(0);
					this.m_MoveDir = Vector3.zero;
				}
			}
			this.CheckGrounding();
			this.Move();
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x0006D2E8 File Offset: 0x0006B4E8
		public virtual void SetPhysicsEnabled(bool AllowPhysics)
		{
			this.m_CharacterController.enabled = AllowPhysics;
			CapsuleCollider component = base.GetComponent<CapsuleCollider>();
			if (component)
			{
				component.enabled = AllowPhysics;
			}
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x0006D318 File Offset: 0x0006B518
		private bool CheckPhysicsEnabled()
		{
			if (this.m_CharacterController != null)
			{
				CapsuleCollider component = base.GetComponent<CapsuleCollider>();
				return component != null && this.m_CharacterController.enabled && component.enabled;
			}
			return false;
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x0006D35C File Offset: 0x0006B55C
		private void CheckGrounding()
		{
			if (this.isGrounded && !this.m_PreviouslyGrounded)
			{
				this.m_MoveDir.y = 0f;
			}
			if (!this.isGrounded && this.m_PreviouslyGrounded)
			{
				this.m_MoveDir.y = 0f;
			}
			this.m_PreviouslyGrounded = this.isGrounded;
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x0006D3B8 File Offset: 0x0006B5B8
		public virtual void Move()
		{
			if (this.isGrounded)
			{
				this.m_MoveDir.y = -10f;
			}
			else if (this.m_EnableGravity)
			{
				this.m_MoveDir += Physics.gravity * this.m_GravityMultiplier * Time.fixedDeltaTime / GameManager.Instance.Player.deltaTimeMultiplier;
			}
			if (this.m_CharacterController.enabled)
			{
				this.m_CollisionFlags = this.m_CharacterController.Move(this.m_MoveDir * Time.fixedDeltaTime / GameManager.Instance.Player.deltaTimeMultiplier);
			}
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0006D468 File Offset: 0x0006B668
		public Quaternion FaceDirection(bool isSmooth = true, float speedModifier = 1f)
		{
			Vector3 vector = new Vector3(this.m_TrackObjectPosition.x, base.transform.position.y, this.m_TrackObjectPosition.z) - base.transform.position;
			Quaternion quaternion = ((!(vector == Vector3.zero)) ? Quaternion.LookRotation(vector) : Quaternion.identity);
			if (vector == Vector3.zero)
			{
				return Quaternion.identity;
			}
			if (isSmooth)
			{
				return Quaternion.Slerp(base.transform.rotation, quaternion, this.m_CurrentTurnRate * speedModifier * Time.deltaTime);
			}
			return quaternion;
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0000E0D2 File Offset: 0x0000C2D2
		public Quaternion ForceFaceDirection()
		{
			this.m_TrackObjectPosition = this.CurrentTarget.position;
			return this.FaceDirection(false, 1f);
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0000E0F1 File Offset: 0x0000C2F1
		public void PlayAnimation(string _AnimationName, float _waitTime, AiThought _followupThought)
		{
			this.m_AnimationController.Play(_AnimationName);
			base.SetThought(AiThought.PlaySingleAnimation);
			this.DoWait(_waitTime, _followupThought, null);
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0000E110 File Offset: 0x0000C310
		protected bool SolvePathMovement(Vector3 targetPosition)
		{
			return this.CheckPath(targetPosition);
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x0006D504 File Offset: 0x0006B704
		private bool CheckPath(Vector3 targetPosition)
		{
			if (this.m_AvoidanceCooldownTime > 0f)
			{
				return true;
			}
			Vector3 position = base.transform.position;
			position.y += 1f;
			Vector3 vector = targetPosition;
			vector.y += 1f;
			if (Vector3.Distance(base.transform.position, targetPosition) > this.m_UseNodePathDistance)
			{
				return this.GetPath(targetPosition, false);
			}
			RaycastHit raycastHit;
			if (Physics.Linecast(position, vector, out raycastHit, this.m_ObstructionLayers, QueryTriggerInteraction.Ignore))
			{
				return this.GetPath(targetPosition, false);
			}
			this.m_CurrentPath = null;
			this.m_TrackObjectPosition = targetPosition;
			return true;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x0006D5A0 File Offset: 0x0006B7A0
		private bool GetPath(Vector3 targetPosition, bool TrackingLostValidationCheck = false)
		{
			if (this.m_CurrentPath == null || Vector3.Distance(this.m_PlayerLastCheckedPosition, targetPosition) > this.m_PlayerMoveDistanceBeforeRepathing)
			{
				this.m_CurrentPath = GameManager.Instance.AiGlobalNetwork.SolvePath(base.transform.position, targetPosition);
				if (this.m_CurrentPath == null || this.m_CurrentPath.Count == 0)
				{
					if (!this.m_PassiveAi && base.CurrentThought == AiThought.Follow && !TrackingLostValidationCheck)
					{
						this.TestLoseTracking();
					}
					this.m_LastEndNode = null;
					return false;
				}
				this.m_LastEndNode = this.m_CurrentPath[this.m_CurrentPath.Count - 1];
				if (this.m_CurrentPath != null && this.m_CurrentPath.Count > 1)
				{
					this.m_CurrentPath.RemoveAt(0);
				}
				this.m_PlayerLastCheckedPosition = targetPosition;
			}
			if (this.m_CurrentPath != null && this.m_CurrentPath.Count > 0 && Vector3.Distance(base.transform.position, this.m_CurrentPath[0].Position) < this.m_DistanceToAcceptNodeReached)
			{
				if (this.m_CurrentPath.Count > 0)
				{
					this.m_CurrentPath.RemoveAt(0);
				}
				else
				{
					this.m_CurrentPath = null;
				}
			}
			if (this.m_CurrentPath != null && this.m_CurrentPath.Count > 0)
			{
				this.m_TrackObjectPosition = this.m_CurrentPath[0].Position;
			}
			return true;
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0000E119 File Offset: 0x0000C319
		public PathfinderNode GetCurrentEndNode()
		{
			return this.m_LastEndNode;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0006D700 File Offset: 0x0006B900
		private void AvoidObstacle(Vector3 targetPosition)
		{
			if (this.m_AvoidanceCooldownTime <= 0f)
			{
				this.m_AvoidanceLastPosition = Vector3.zero;
				bool flag = false;
				if (Physics.CheckSphere(this.m_KneeLocation.position + base.transform.forward * 1.5f, 0.4f, this.m_ObstructionLayers, QueryTriggerInteraction.Ignore))
				{
					flag = true;
				}
				if (flag)
				{
					List<Vector3> list = new List<Vector3>();
					global::UnityEngine.Debug.DrawRay(this.m_KneeLocation.position, base.transform.forward * 1.5f, Color.yellow, 2f);
					if (Vector3.Distance(base.transform.position, this.m_TrackObjectPosition) > 20f)
					{
						this.m_CurrentPath = null;
					}
					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							if ((i != 0 || j != 0) && Mathf.Abs(i) != Mathf.Abs(j))
							{
								Vector3 position = this.m_KneeLocation.position;
								Vector3 vector = new Vector3((float)i, 0f, (float)j);
								Vector3 vector2 = position + vector.normalized * 1.7f;
								if (!Physics.CheckSphere(vector2, 0.6f, this.m_ObstructionLayers) && !Physics.Linecast(this.m_KneeLocation.position, vector2, this.m_ObstructionLayers))
								{
									List<Vector3> list2 = list;
									Vector3 vector3 = vector2;
									Vector3 vector4 = new Vector3((float)i, 0f, (float)j);
									list2.Add(vector3 + vector4.normalized * 10f);
									global::UnityEngine.Debug.DrawLine(this.m_KneeLocation.position, vector2, Color.cyan, 1f);
								}
							}
						}
					}
					float num = -1f;
					Vector3 vector5 = Vector3.zero;
					for (int k = 0; k < list.Count; k++)
					{
						float num2 = Vector3.Distance(targetPosition, list[k]);
						if (k == 0 || num2 < num)
						{
							num = num2;
							vector5 = list[k];
						}
					}
					this.m_AvoidanceLastPosition = vector5;
					this.m_AvoidanceCooldownTime = 0.5f;
				}
			}
			else
			{
				this.m_AvoidanceCooldownTime -= Time.deltaTime;
			}
			if (this.m_AvoidanceLastPosition != Vector3.zero)
			{
				this.m_TrackObjectPosition = this.m_AvoidanceLastPosition;
			}
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0006D95C File Offset: 0x0006BB5C
		public virtual Transform FineNearbyTargets()
		{
			int num = Physics.OverlapSphereNonAlloc(base.transform.position, this.m_VisibilityDistance, this.fnt_NearbyEntities, this.m_TargetableEntityLayers);
			if (num > 0)
			{
				Transform transform = null;
				float num2 = -1f;
				for (int i = 0; i < num; i++)
				{
					Transform transform2 = this.fnt_NearbyEntities[i].transform;
					float num3 = Vector3.Distance(base.transform.position, transform2.position);
					if (transform2.gameObject.tag != "Dead" && (num2 < 0f || num3 < num2))
					{
						num2 = num3;
						transform = transform2;
					}
				}
				return transform;
			}
			return null;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0000E121 File Offset: 0x0000C321
		public virtual Vector3 OffsetTargetPosition()
		{
			return this.CurrentTarget.position + this.m_RaiseFromGroundOffset;
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0006DA00 File Offset: 0x0006BC00
		public virtual Transform TestTargetVisibility()
		{
			Transform transform = this.FineNearbyTargets();
			if (transform && (Vector3.Angle(base.transform.forward, transform.position - base.transform.position) < this.m_TargetVisibilityAngle || Vector3.Distance(transform.position, base.transform.position) < 10f) && !Physics.Linecast(this.m_EyeLocation.position, transform.position + this.m_RaiseFromGroundOffset, this.m_SightMask))
			{
				if (!this.CurrentTarget && this.m_EnableSpottedAnimation)
				{
					this.DoWait(this.m_SpottedAnimationWaitTime, AiThought.Follow, null);
					this.m_TrackObjectPosition = transform.position;
					this.SendOnSpotted();
					this.SetAnimationTrigger("EnemySpotted");
				}
				return transform;
			}
			return null;
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x0000E139 File Offset: 0x0000C339
		public void ForceOnSpotted()
		{
			this.SendOnSpotted();
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x0006DADC File Offset: 0x0006BCDC
		public virtual void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
		{
			if (base.CurrentThought == AiThought.Die)
			{
				return;
			}
			this.m_HitPosition = hit.point;
			if (base.CurrentThought != AiThought.Attack && this.m_TargetableEntityLayers == (this.m_TargetableEntityLayers | (1 << weaponInfo.Attacker.layer)))
			{
				this.SetTarget(weaponInfo.Attacker.transform);
				base.SetThought(AiThought.Attack);
			}
			if (!this.m_IsInvincible)
			{
				this.PlayAudio(ref this.m_HitAudio, false);
				GameObject fromPool = GameManager.Instance.PoolingManager.GetFromPool("GamePlay/Particles/InkHit");
				fromPool.transform.position = hit.point;
				fromPool.transform.localScale = Vector3.one;
				this.m_CurrentHealth -= weaponInfo.Damage;
				if (this.m_CurrentHealth <= 0)
				{
					if (weaponInfo != null)
					{
						this.Attacker = weaponInfo.Attacker;
					}
					base.SetThought(AiThought.Die);
				}
			}
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x0000E141 File Offset: 0x0000C341
		public void Reset()
		{
			this.SetAnimationTrigger("Respawn");
			base.SetThought(this.m_StartingThought);
			this.m_CharacterController.enabled = true;
			this.m_CurrentHealth = this.m_Health;
			this.SetTarget(null);
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x0000E179 File Offset: 0x0000C379
		public void SetPassive(bool IsPassive)
		{
			this.m_PassiveAi = IsPassive;
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x0000E182 File Offset: 0x0000C382
		protected void StartAttack(int attackNumber)
		{
			this.SetMoveDirection(Vector3.zero);
			this.SetAnimatiorAttack(attackNumber + 1);
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x0006DBCC File Offset: 0x0006BDCC
		public virtual void AttackTarget()
		{
			if (!this.CurrentTarget)
			{
				return;
			}
			this.m_TrackObjectPosition = this.CurrentTarget.position;
			base.transform.rotation = this.FaceDirection(true, 10f);
			Vector3 vector = this.m_KneeLocation.position + base.transform.forward * (this.m_AttackDistance + 1f);
			Collider[] array = Physics.OverlapCapsule(this.m_KneeLocation.position, vector, 1f, this.m_TargetableEntityLayers);
			if (array.Length == 0)
			{
				this.SetAnimatiorMovement(0);
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.layer == LayerMask.NameToLayer("Player"))
				{
					int num = 0;
					while ((float)num < this.m_AttackPower)
					{
						GameManager.Instance.ShowHurtBorder(false);
						num++;
					}
				}
				if (array[i].gameObject.GetComponent<IHittable>() != null)
				{
					this.m_RaycastHit.point = vector;
					array[i].gameObject.GetComponent<IHittable>().Hit(this.m_RaycastHit, this.m_WeaponInfo);
				}
			}
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x0006DCE8 File Offset: 0x0006BEE8
		protected bool TestLoseTracking()
		{
			if (!this.m_PassiveAi && this.CurrentTarget && (this.m_CurrentPath == null || this.m_CurrentPath.Count == 0))
			{
				if (!Physics.Linecast(this.m_EyeLocation.position, this.OffsetTargetPosition(), this.m_SightMask))
				{
					this.m_TrackObjectPosition = this.CurrentTarget.position;
					return false;
				}
				if (this.m_LastEndNode && !Physics.Linecast(this.m_LastEndNode.Position + Vector3.up * 5f, this.OffsetTargetPosition(), this.m_ObstructionLayers))
				{
					if (this.m_AvoidanceCooldownTime <= 0f)
					{
						this.m_TrackObjectPosition = this.m_LastEndNode.Position;
						this.m_LastEndNode = null;
						return false;
					}
				}
				else
				{
					if (!this.GetPath(this.OffsetTargetPosition(), true))
					{
						return this.TrackingLostEvents(AiThought.Retreat);
					}
					if (this.m_AvoidanceCooldownTime <= 0f)
					{
						this.m_TrackObjectPosition = this.CurrentTarget.position;
					}
					return false;
				}
			}
			return (GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding || !this.CurrentTarget || (this.CurrentTarget && Vector3.Distance(base.transform.position, this.CurrentTarget.position) > this.m_LoseTrackingVisibilityDistance)) && this.TrackingLostEvents(AiThought.Retreat);
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0000E198 File Offset: 0x0000C398
		protected virtual bool TrackingLostEvents(AiThought _repalcementThought)
		{
			if (!this.m_PassiveAi)
			{
				this.m_CurrentPath = null;
				this.SetTarget(null);
			}
			base.SetThought(_repalcementThought);
			return true;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x0006DE5C File Offset: 0x0006C05C
		protected virtual void CheckIfStuck(Vector3 inputPosition)
		{
			if (this.m_MyLastCheckedPosition == Vector3.zero)
			{
				this.m_MyLastCheckedPosition = base.transform.position;
				return;
			}
			if (this.m_StuckCheckTimer > 5f)
			{
				if (Vector3.Distance(this.m_MyLastCheckedPosition, base.transform.position) < 5f)
				{
					this.m_CurrentPath = null;
				}
				this.m_MyLastCheckedPosition = base.transform.position;
				this.m_StuckCheckTimer = 0f;
				return;
			}
			this.m_StuckCheckTimer += Time.deltaTime;
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0000E1B8 File Offset: 0x0000C3B8
		protected void DoWait(float timer, AiThought nextThought = AiThought.Idle, Action callback = null)
		{
			this.m_WaitCallback = callback;
			base.SetThought(AiThought.Wait);
			this.m_WaitTimer = timer;
			this.m_NextThought = nextThought;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0000E1D7 File Offset: 0x0000C3D7
		public void SetUseRunForWaypoints(bool useRun)
		{
			this.m_UseRunForWaypoints = useRun;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0000E1E0 File Offset: 0x0000C3E0
		protected void CheckSpeed(bool shouldRun)
		{
			if (shouldRun)
			{
				this.SetRun();
				this.m_RunDistanceBuffer = this.m_RunDistance - 1.5f;
				return;
			}
			this.SetWalk();
			this.m_RunDistanceBuffer = this.m_RunDistance;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0000E210 File Offset: 0x0000C410
		protected void SetRun()
		{
			this.m_CurrentMoveSpeed = this.m_RunSpeed;
			this.m_CurrentTurnRate = this.m_RunTurnSpeed;
			this.SetAnimatiorMovement(this.m_RunMode);
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0000E236 File Offset: 0x0000C436
		protected void SetWalk()
		{
			this.m_CurrentMoveSpeed = this.m_WalkSpeed;
			this.m_CurrentTurnRate = this.m_WalkTurnSpeed;
			this.SetAnimatiorMovement(this.m_WalkMode);
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0000E25C File Offset: 0x0000C45C
		protected void SetAnimatiorMovement(int _movemetType)
		{
			this.m_AnimationController.SetInteger("MovementMode", _movemetType);
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0000E26F File Offset: 0x0000C46F
		protected void SetAnimatiorAttack(int _attackType)
		{
			if (_attackType <= 0)
			{
				return;
			}
			if (!this.m_PassiveAi)
			{
				this.m_AnimationController.SetTrigger("Attack_" + _attackType.ToString());
			}
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0000E29A File Offset: 0x0000C49A
		protected void SetAnimationTrigger(string _Trigger)
		{
			this.m_AnimationController.SetTrigger(_Trigger);
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0000E2A8 File Offset: 0x0000C4A8
		protected void SetMoveDirection(Vector3 moveDirection)
		{
			this.m_MoveDir.x = moveDirection.x * this.m_CurrentMoveSpeed;
			this.m_MoveDir.z = moveDirection.z * this.m_CurrentMoveSpeed;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0006DEF0 File Offset: 0x0006C0F0
		public void SetTarget(Transform newTarget)
		{
			if (this.CurrentTarget != newTarget)
			{
				this.PreviousTarget = this.CurrentTarget;
				this.CurrentTarget = newTarget;
				if (!this.m_PassiveAi)
				{
					GameManager.Instance.AiGlobalNetwork.CheckCombatStatus();
				}
				if (this is Ch4_SoundBasedAI)
				{
					for (int i = 0; i < GameManager.Instance.AiGlobalNetwork.ListeningAi.Count; i++)
					{
						if (this != GameManager.Instance.AiGlobalNetwork.ListeningAi[i])
						{
							GameManager.Instance.AiGlobalNetwork.ListeningAi[i].SetTarget(newTarget);
						}
					}
				}
			}
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0000E2DA File Offset: 0x0000C4DA
		public virtual void SetAiFollowTarget(BaseAiController aiToFollow)
		{
			this.m_CurrentAiToFollow = aiToFollow;
			this.m_WaypointMode = AiWaypointMode.Follow_Ai;
			base.SetThought(AiThought.UseWaypoints);
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0000E2F1 File Offset: 0x0000C4F1
		public void SetStartingThought(AiThought startingThought)
		{
			this.m_StartingThought = startingThought;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0006DF98 File Offset: 0x0006C198
		private AudioObject PlayAudio(ref AudioClip[] audioClips, bool is2D = false)
		{
			if (audioClips == null || audioClips.Length == 0)
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

		// Token: 0x060010E4 RID: 4324 RVA: 0x0000E2FA File Offset: 0x0000C4FA
		public void ForceDeath(Vector3 position)
		{
			this.m_HitPosition = position;
			this.CurrentTarget = null;
			this.m_CurrentHealth = 0;
			base.SetThought(AiThought.Die);
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0000E319 File Offset: 0x0000C519
		protected void SendOnWaypointComplete()
		{
			this.OnWaypointComplete.Send(this);
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0000E327 File Offset: 0x0000C527
		protected void SendOnDeath()
		{
			this.OnDeath.Send(this);
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0000E335 File Offset: 0x0000C535
		protected void SendOnHide()
		{
			this.OnHide.Send(this);
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0000E343 File Offset: 0x0000C543
		protected void SendOnRespawn()
		{
			this.OnRespawn.Send(this);
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0000E351 File Offset: 0x0000C551
		protected void SendOnDistanceActivate()
		{
			this.OnDistanceActivate.Send(this);
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0000E35F File Offset: 0x0000C55F
		protected void SendOnActive()
		{
			this.OnActivate.Send(this);
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0000E36D File Offset: 0x0000C56D
		protected void SendOnSpotted()
		{
			this.OnSpotted.Send(this);
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0000E37B File Offset: 0x0000C57B
		protected void SendOnRetreat()
		{
			this.OnRetreat.Send(this);
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0000E389 File Offset: 0x0000C589
		protected override void OnDisposed()
		{
			this.OnWaypointComplete = null;
			this.OnDeath = null;
			this.OnHide = null;
			this.OnRespawn = null;
			this.OnDistanceActivate = null;
			this.OnActivate = null;
			this.OnSpotted = null;
			this.OnRetreat = null;
			base.OnDisposed();
		}

		// Token: 0x04000D77 RID: 3447
		[Header("Layer Options")]
		[SerializeField]
		protected LayerMask m_TargetableEntityLayers;

		// Token: 0x04000D78 RID: 3448
		[SerializeField]
		protected LayerMask m_ObstructionLayers;

		// Token: 0x04000D79 RID: 3449
		[Header("Animation Options")]
		[SerializeField]
		protected Animator m_AnimationController;

		// Token: 0x04000D7A RID: 3450
		[SerializeField]
		protected float m_AwakeAnimationWaitTime;

		// Token: 0x04000D7B RID: 3451
		[Header("Movement Options")]
		[SerializeField]
		protected bool m_PassiveAi;

		// Token: 0x04000D7C RID: 3452
		[SerializeField]
		protected AiThought m_StartingThought;

		// Token: 0x04000D7D RID: 3453
		[SerializeField]
		protected float m_WalkSpeed = 3f;

		// Token: 0x04000D7E RID: 3454
		[SerializeField]
		protected float m_WalkTurnSpeed = 3f;

		// Token: 0x04000D7F RID: 3455
		[SerializeField]
		protected float m_RunSpeed = 6f;

		// Token: 0x04000D80 RID: 3456
		[SerializeField]
		protected float m_RunTurnSpeed = 3f;

		// Token: 0x04000D81 RID: 3457
		[Header("Gravity Options")]
		[SerializeField]
		protected bool m_EnableGravity = true;

		// Token: 0x04000D82 RID: 3458
		[SerializeField]
		protected float m_GravityMultiplier = 3f;

		// Token: 0x04000D83 RID: 3459
		[Header("Avoidance Options")]
		[SerializeField]
		private bool m_EnableAvoidance = true;

		// Token: 0x04000D84 RID: 3460
		[Header("Tracking Options")]
		[SerializeField]
		protected Transform m_EyeLocation;

		// Token: 0x04000D85 RID: 3461
		[SerializeField]
		protected Transform m_KneeLocation;

		// Token: 0x04000D86 RID: 3462
		[SerializeField]
		protected float m_ActivationDistance = 10f;

		// Token: 0x04000D87 RID: 3463
		[SerializeField]
		protected float m_VisibilityDistance = 50f;

		// Token: 0x04000D88 RID: 3464
		[SerializeField]
		[Range(0f, 180f)]
		protected float m_TargetVisibilityAngle = 80f;

		// Token: 0x04000D89 RID: 3465
		[SerializeField]
		protected float m_LoseTrackingVisibilityDistance = 200f;

		// Token: 0x04000D8A RID: 3466
		[SerializeField]
		protected float m_RunDistance = 15f;

		// Token: 0x04000D8B RID: 3467
		[SerializeField]
		protected float m_UseNodePathDistance = 15f;

		// Token: 0x04000D8C RID: 3468
		[SerializeField]
		protected bool m_EnableSpottedAnimation;

		// Token: 0x04000D8D RID: 3469
		[SerializeField]
		protected float m_SpottedAnimationWaitTime;

		// Token: 0x04000D8E RID: 3470
		[Header("Health Options")]
		[SerializeField]
		protected bool m_IsInvincible;

		// Token: 0x04000D8F RID: 3471
		[SerializeField]
		protected int m_Health;

		// Token: 0x04000D90 RID: 3472
		[Header("Attack Options")]
		[SerializeField]
		protected float m_AttackDistance = 5f;

		// Token: 0x04000D91 RID: 3473
		[SerializeField]
		protected float m_AttackPower = 1f;

		// Token: 0x04000D92 RID: 3474
		[SerializeField]
		protected List<BaseAiController.AnimationSettings> m_AnimationSettings;

		// Token: 0x04000D93 RID: 3475
		[Header("Waypoint Options")]
		[SerializeField]
		protected AiWaypointMode m_WaypointMode;

		// Token: 0x04000D94 RID: 3476
		[SerializeField]
		protected bool m_UseRunForWaypoints;

		// Token: 0x04000D95 RID: 3477
		[SerializeField]
		protected bool m_UseRotateAtEndWaypoint;

		// Token: 0x04000D96 RID: 3478
		[SerializeField]
		protected Vector3 m_MoveToVectorPoint;

		// Token: 0x04000D97 RID: 3479
		[SerializeField]
		protected List<WaypointNode> m_CurrentWaypointList;

		// Token: 0x04000D98 RID: 3480
		[SerializeField]
		protected BaseAiController m_CurrentAiToFollow;

		// Token: 0x04000D99 RID: 3481
		[Header("Death Options")]
		[SerializeField]
		protected Transform m_RagdollParent;

		// Token: 0x04000D9A RID: 3482
		[SerializeField]
		protected List<BaseAiController.InkDeathEffect> m_InkDeathEffect;

		// Token: 0x04000D9C RID: 3484
		protected Collider m_CurrentTargetCollider;

		// Token: 0x04000D9F RID: 3487
		protected CharacterController m_CharacterController;

		// Token: 0x04000DA0 RID: 3488
		protected CollisionFlags m_CollisionFlags;

		// Token: 0x04000DA1 RID: 3489
		protected int m_CurrentHealth;

		// Token: 0x04000DA2 RID: 3490
		protected Vector3 m_MoveDir = Vector3.zero;

		// Token: 0x04000DA3 RID: 3491
		protected bool m_PreviouslyGrounded;

		// Token: 0x04000DA4 RID: 3492
		protected float m_CurrentMoveSpeed;

		// Token: 0x04000DA5 RID: 3493
		protected float m_CurrentTurnRate = 3f;

		// Token: 0x04000DA6 RID: 3494
		protected float m_RunDistanceBuffer;

		// Token: 0x04000DA7 RID: 3495
		protected float m_AttackDistanceBuffer;

		// Token: 0x04000DA8 RID: 3496
		protected List<PathfinderNode> m_CurrentPath;

		// Token: 0x04000DA9 RID: 3497
		protected Vector3 m_TrackObjectPosition;

		// Token: 0x04000DAA RID: 3498
		protected Vector3 m_PlayerLastCheckedPosition;

		// Token: 0x04000DAB RID: 3499
		protected Vector3 m_MyLastCheckedPosition;

		// Token: 0x04000DAC RID: 3500
		protected float m_StuckCheckTimer;

		// Token: 0x04000DAD RID: 3501
		protected int m_WaypointIndex;

		// Token: 0x04000DAE RID: 3502
		protected float m_TimescaleDistanceIncrease;

		// Token: 0x04000DAF RID: 3503
		protected Vector3 AiToFollow_Offset;

		// Token: 0x04000DB0 RID: 3504
		protected PathfinderNode m_LastEndNode;

		// Token: 0x04000DB1 RID: 3505
		protected float m_PlayerMoveDistanceBeforeRepathing = 5f;

		// Token: 0x04000DB2 RID: 3506
		protected float m_DistanceToAcceptNodeReached = 3f;

		// Token: 0x04000DB3 RID: 3507
		protected float m_WaitTimer;

		// Token: 0x04000DB4 RID: 3508
		protected AiThought m_NextThought;

		// Token: 0x04000DB5 RID: 3509
		protected Vector3 m_AvoidanceLastPosition;

		// Token: 0x04000DB6 RID: 3510
		protected float m_AvoidanceCooldownTime;

		// Token: 0x04000DB7 RID: 3511
		protected List<Ragdoll> m_Ragdolls;

		// Token: 0x04000DB8 RID: 3512
		protected Vector3 m_HitPosition;

		// Token: 0x04000DB9 RID: 3513
		protected Action m_WaitCallback;

		// Token: 0x04000DBA RID: 3514
		private AudioClip[] m_HitAudio;

		// Token: 0x04000DBB RID: 3515
		protected int m_WalkMode = 1;

		// Token: 0x04000DBC RID: 3516
		protected int m_RunMode = 2;

		// Token: 0x04000DBD RID: 3517
		protected LayerMask m_SightMask;

		// Token: 0x04000DBE RID: 3518
		protected WeaponInfo m_WeaponInfo;

		// Token: 0x04000DBF RID: 3519
		protected RaycastHit m_RaycastHit;

		// Token: 0x04000DC0 RID: 3520
		private Vector3 m_RaiseFromGroundOffset = new Vector3(0f, 0.5f, 0f);

		// Token: 0x04000DC2 RID: 3522
		private Collider[] fnt_NearbyEntities = new Collider[10];

		// Token: 0x02000198 RID: 408
		[Serializable]
		public class InkDeathEffect
		{
			// Token: 0x04000DC3 RID: 3523
			public InkExplosionEffect InkExplosion;

			// Token: 0x04000DC4 RID: 3524
			public Renderer Renderer;
		}

		// Token: 0x02000199 RID: 409
		[Serializable]
		public class AnimationSettings
		{
			// Token: 0x04000DC5 RID: 3525
			public AnimationClip Clip;

			// Token: 0x04000DC6 RID: 3526
			public int Frame;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ai;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000196 RID: 406
public class AllyAiController : BaseAiController
{
	// Token: 0x1400005B RID: 91
	// (add) Token: 0x06001078 RID: 4216 RVA: 0x0006B944 File Offset: 0x00069B44
	// (remove) Token: 0x06001079 RID: 4217 RVA: 0x0006B97C File Offset: 0x00069B7C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnDoorSmashed;

	// Token: 0x0600107A RID: 4218 RVA: 0x0000DE30 File Offset: 0x0000C030
	protected override void Update()
	{
		base.Update();
		if (!this.m_HasHeadTracking)
		{
			return;
		}
		this.m_AnimatedHeadPosition = this.m_HeadLookForward.forward;
	}

	// Token: 0x0600107B RID: 4219 RVA: 0x0006B9B4 File Offset: 0x00069BB4
	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (!this.m_HasHeadTracking)
		{
			return;
		}
		Transform transform = GameManager.Instance.Player.transform;
		bool flag = transform && this.m_AnimationController.GetInteger("MovementMode") < 1;
		float num = 0f;
		if (flag && transform)
		{
			num = Vector3.Angle(base.transform.forward, transform.position - base.transform.position);
		}
		if (flag && transform && Vector3.Distance(transform.position, base.transform.position) < 15f && num < 55f)
		{
			Vector3 vector = transform.position - this.m_Head.position;
			Quaternion quaternion = Quaternion.LookRotation(vector) * Quaternion.Euler(this.m_HeadOffset);
			this.m_Head.rotation = Quaternion.Slerp(this.m_LastLookRotation, quaternion, 5f * Time.deltaTime);
		}
		else
		{
			Quaternion quaternion2 = Quaternion.LookRotation(this.m_AnimatedHeadPosition) * Quaternion.Euler(this.m_HeadOffset);
			this.m_Head.rotation = Quaternion.Slerp(this.m_LastLookRotation, quaternion2, 5f * Time.deltaTime);
		}
		this.m_LastLookRotation = this.m_Head.rotation;
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x0006BB28 File Offset: 0x00069D28
	public override Transform FineNearbyTargets()
	{
		int num = Physics.OverlapSphereNonAlloc(base.transform.position, this.m_VisibilityDistance, this.fnt_NearbyEntities, this.m_TargetableEntityLayers, QueryTriggerInteraction.Ignore);
		if (num > 0)
		{
			Transform transform = null;
			float num2 = -1f;
			for (int i = 0; i < num; i++)
			{
				Transform transform2 = this.fnt_NearbyEntities[i].transform;
				float num3 = Vector3.Distance(base.transform.position, transform2.position);
				if (transform2.gameObject.tag != "Dead" && (num2 < 0f || num3 < num2) && (num == 1 || !GameManager.Instance.AiGlobalNetwork.CheckAllyTarget(transform2)))
				{
					num2 = num3;
					transform = transform2;
				}
			}
			if (transform != null)
			{
				GameManager.Instance.AiGlobalNetwork.CleanAllyTargets();
				GameManager.Instance.AiGlobalNetwork.AddAllyTarget(transform);
			}
			return transform;
		}
		return null;
	}

	// Token: 0x0600107D RID: 4221 RVA: 0x0000DE55 File Offset: 0x0000C055
	public void SetHeadTracking(bool active)
	{
		this.m_HasHeadTracking = active;
	}

	// Token: 0x0600107E RID: 4222 RVA: 0x0006BC28 File Offset: 0x00069E28
	protected override void T_Idle()
	{
		if (!base.CurrentTarget || Vector3.Distance(base.transform.position, base.CurrentTarget.position) > this.m_AttackDistance)
		{
			base.SetAnimatiorMovement(0);
		}
		else if (base.WasInThought(AiThought.Follow) && base.CurrentThought == AiThought.Attack)
		{
			base.SetAnimatiorMovement(1);
		}
		base.SetMoveDirection(Vector3.zero);
		this.m_TrackObjectPosition = base.transform.position + base.transform.forward * 10f;
		if (!this.m_PassiveAi)
		{
			if (GameManager.Instance.Player != null && GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
			{
				base.SetThought(AiThought.Retreat);
			}
			else if (!base.CurrentTarget)
			{
				base.SetTarget(this.TestTargetVisibility());
			}
			else
			{
				base.SetThought(AiThought.Attack);
			}
		}
	}

	// Token: 0x0600107F RID: 4223 RVA: 0x0000DE5E File Offset: 0x0000C05E
	protected override void T_EnterRetreat()
	{
		base.T_EnterRetreat();
		base.SetThought(AiThought.Idle);
	}

	// Token: 0x06001080 RID: 4224 RVA: 0x0000DE6D File Offset: 0x0000C06D
	protected override void T_Attack()
	{
		if (base.CurrentTarget == GameManager.Instance.Player.transform)
		{
			base.SetThought(AiThought.Follow);
			return;
		}
		base.T_Attack();
	}

	// Token: 0x06001081 RID: 4225 RVA: 0x0006BD38 File Offset: 0x00069F38
	protected override void T_Follow()
	{
		if (base.CurrentTarget == GameManager.Instance.Player.transform)
		{
			Transform transform = this.FineNearbyTargets();
			if (transform != null)
			{
				base.CurrentTarget = transform;
			}
			if (Vector3.Distance(base.transform.position, base.CurrentTarget.position) < this.m_FollowPlayerBuffer)
			{
				this.m_FollowPlayerBuffer = this.m_FollowPlayerBufferDistance + 3f;
				base.SetThought(AiThought.Idle);
				return;
			}
			this.m_FollowPlayerBuffer = this.m_FollowPlayerBufferDistance;
		}
		base.T_Follow();
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x0000DE9C File Offset: 0x0000C09C
	public void ForceStartIdle()
	{
		while (this.m_AnimationSettings.Count > 1)
		{
			this.m_AnimationSettings.RemoveAt(1);
		}
		base.SetAnimationTrigger("Birth");
		base.SetThought(AiThought.Idle);
	}

	// Token: 0x06001083 RID: 4227 RVA: 0x0000DED2 File Offset: 0x0000C0D2
	public void UpdateWaypointList(List<WaypointNode> waypointList)
	{
		this.m_CurrentWaypointList.Clear();
		this.m_WaypointIndex = 0;
		this.m_CurrentWaypointList = waypointList;
		base.SetThought(AiThought.UseWaypoints);
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x0006BDD0 File Offset: 0x00069FD0
	public override void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
	{
		if (base.CurrentThought == AiThought.Die)
		{
			return;
		}
		this.m_HitPosition = hit.point;
		if (base.CurrentThought != AiThought.Attack && this.m_TargetableEntityLayers == (this.m_TargetableEntityLayers | (1 << weaponInfo.Attacker.layer)))
		{
			if (base.CurrentTarget != null)
			{
				GameManager.Instance.AiGlobalNetwork.RemoveAllyTarget(base.CurrentTarget);
			}
			base.SetTarget(weaponInfo.Attacker.transform);
			base.SetThought(AiThought.Attack);
		}
		if (!this.m_IsInvincible)
		{
			GameObject fromPool = GameManager.Instance.PoolingManager.GetFromPool("GamePlay/Particles/InkHit");
			fromPool.transform.position = hit.point;
			fromPool.transform.localScale = Vector3.one;
			this.m_CurrentHealth -= weaponInfo.Damage;
			if (this.m_CurrentHealth <= 0)
			{
				base.SetThought(AiThought.Die);
			}
		}
	}

	// Token: 0x06001085 RID: 4229 RVA: 0x0006BED8 File Offset: 0x0006A0D8
	public override void AttackTarget()
	{
		if (!base.CurrentTarget)
		{
			return;
		}
		if (base.CurrentTarget.parent)
		{
			CH5FenceDoor component = base.CurrentTarget.parent.GetComponent<CH5FenceDoor>();
			if (component)
			{
				component.Open();
				this.ExitCombat();
				base.SetTarget(GameManager.Instance.Player.transform);
				return;
			}
			CH5VaultDoor component2 = base.CurrentTarget.parent.GetComponent<CH5VaultDoor>();
			if (component2)
			{
				this.OnDoorSmashed.Send(this);
				component2.Open();
				this.ExitCombat();
				base.SetTarget(GameManager.Instance.Player.transform);
				base.gameObject.layer = LayerMask.NameToLayer("Ally");
				return;
			}
		}
		this.m_TrackObjectPosition = base.CurrentTarget.position;
		base.transform.rotation = base.FaceDirection(true, 10f);
		Vector3 vector = this.m_KneeLocation.position + base.transform.forward * (this.m_AttackDistance + 1f);
		Collider[] array = Physics.OverlapCapsule(this.m_KneeLocation.position, vector, 1f, this.m_TargetableEntityLayers);
		if (array.Length == 0)
		{
			base.SetAnimatiorMovement(0);
		}
		else if (array[0].gameObject.GetComponent<IHittable>() != null)
		{
			this.m_RaycastHit.point = vector;
			array[0].gameObject.GetComponent<IHittable>().Hit(this.m_RaycastHit, this.m_WeaponInfo);
		}
	}

	// Token: 0x06001086 RID: 4230 RVA: 0x0000DEF4 File Offset: 0x0000C0F4
	protected override bool TrackingLostEvents(AiThought _repalcementThought)
	{
		if (base.CurrentTarget == GameManager.Instance.Player.transform)
		{
			this.m_CurrentPath = null;
			base.SetThought(AiThought.Idle);
			return true;
		}
		return base.TrackingLostEvents(_repalcementThought);
	}

	// Token: 0x06001087 RID: 4231 RVA: 0x0000DF2C File Offset: 0x0000C12C
	public void ExitCombat()
	{
		this.m_AnimationController.SetBool("IsNotInCombat", true);
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x0000DF3F File Offset: 0x0000C13F
	public void EnterCombat()
	{
		this.m_AnimationController.SetBool("IsNotInCombat", false);
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x0000DF52 File Offset: 0x0000C152
	public void PlayAnimation(string animation)
	{
		this.m_AnimationController.Play(animation);
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x0000DF60 File Offset: 0x0000C160
	public void DoSpeak(float _Duration)
	{
		this.m_AnimationController.SetBool("IsSpeaking", true);
		DOTween.Sequence().InsertCallback(_Duration, delegate
		{
			this.m_AnimationController.SetBool("IsSpeaking", false);
		});
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x0006C070 File Offset: 0x0006A270
	public void SetCollider(bool active)
	{
		this.m_CharacterController.enabled = active;
		CapsuleCollider component = base.GetComponent<CapsuleCollider>();
		if (component)
		{
			component.enabled = active;
		}
	}

	// Token: 0x0600108C RID: 4236 RVA: 0x0000DF8B File Offset: 0x0000C18B
	public void SetTrigger(string trigger)
	{
		base.SetAnimationTrigger(trigger);
	}

	// Token: 0x0600108D RID: 4237 RVA: 0x0000DF94 File Offset: 0x0000C194
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000D64 RID: 3428
	private Collider[] fnt_NearbyEntities = new Collider[10];

	// Token: 0x04000D65 RID: 3429
	[SerializeField]
	private float m_FollowPlayerBufferDistance = 8f;

	// Token: 0x04000D66 RID: 3430
	[Header("Head Tracking")]
	[SerializeField]
	private bool m_HasHeadTracking;

	// Token: 0x04000D67 RID: 3431
	[SerializeField]
	private Transform m_Head;

	// Token: 0x04000D68 RID: 3432
	[SerializeField]
	private Transform m_HeadLookForward;

	// Token: 0x04000D69 RID: 3433
	[SerializeField]
	private Vector3 m_HeadOffset;

	// Token: 0x04000D6A RID: 3434
	private Quaternion m_LastLookRotation;

	// Token: 0x04000D6B RID: 3435
	private Quaternion SnapRotation;

	// Token: 0x04000D6C RID: 3436
	private Vector3 SnapPosition;

	// Token: 0x04000D6D RID: 3437
	private Vector3 m_AnimatedHeadPosition;

	// Token: 0x04000D6E RID: 3438
	private float m_FollowPlayerBuffer;
}

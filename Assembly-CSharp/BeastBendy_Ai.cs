using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using TMG.Core;
using UnityEngine;

// Token: 0x0200019A RID: 410
public class BeastBendy_Ai : TMGMonoBehaviour
{
	// Token: 0x060010F1 RID: 4337 RVA: 0x0000E3C9 File Offset: 0x0000C5C9
	public override void Init()
	{
		base.Init();
		this.m_CharacterController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060010F2 RID: 4338 RVA: 0x0006E060 File Offset: 0x0006C260
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_MoveToTargetTransform = GameManager.Instance.Player.transform;
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Walk.name, "Stomp", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Walk.name, "Stomp", 30);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Charge.name, "Stomp", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Charge.name, "Stomp", 15);
		DOTween.Sequence().InsertCallback(0.01f, delegate
		{
			AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Attack1.name, "DoAttack", 25);
		});
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x0006E118 File Offset: 0x0006C318
	public override void OnEnable()
	{
		this.m_IsIntro = true;
		for (int i = 0; i < this.m_PortalParticles.Length; i++)
		{
			ParticleSystem particleSystem = this.m_PortalParticles[i];
			ParticleSystem particleSystem2 = global::UnityEngine.Object.Instantiate<ParticleSystem>(this.m_PortalParticles[i]);
			particleSystem2.transform.position = particleSystem.transform.position;
			particleSystem2.transform.eulerAngles = particleSystem.transform.eulerAngles;
			particleSystem2.Emit(15);
		}
		base.transform.rotation = this.FaceDirection(false);
		this.DoWait(1.5f, delegate
		{
			this.m_IsIntro = false;
			this.m_TrackObjectPosition = this.m_MoveToTargetTransform.position;
			base.transform.rotation = this.FaceDirection(true);
			this.m_AnimationController.SetTrigger("Roar");
			DOTween.Sequence().InsertCallback(1.9f, delegate
			{
				this.m_TrackObjectPosition = this.m_MoveToTargetTransform.position;
				base.transform.rotation = this.FaceDirection(false);
				this.m_IsCharging = true;
				this.m_TurnSpeed = 0.25f;
			});
		});
	}

	// Token: 0x060010F4 RID: 4340 RVA: 0x0000E3DD File Offset: 0x0000C5DD
	public override void OnDisable()
	{
		this.m_IsIntro = false;
	}

	// Token: 0x060010F5 RID: 4341 RVA: 0x0006E1BC File Offset: 0x0006C3BC
	private void Update()
	{
		if (this.m_IsIntro)
		{
			this.m_MoveDir = base.transform.forward * this.m_WalkSpeed * Time.deltaTime;
			this.m_AnimationController.SetInteger("MovementMode", 1);
		}
		if (this.m_WaitTimer <= 0f)
		{
			this.WalkAndPunch();
			if (this.m_WaitCallback != null)
			{
				Action waitCallback = this.m_WaitCallback;
				this.m_WaitTimer = 0f;
				this.m_WaitCallback = null;
				waitCallback();
			}
			else if (this.m_IsCharging)
			{
				if (Physics.CheckSphere(this.m_KneeTransform.position + base.transform.forward * this.m_AttackDistance, 1f, LayerMask.GetMask(new string[] { "Player" })))
				{
					this.ApplyShake(0.25f);
					if (!this.m_HasAttackedPlayer)
					{
						this.AttackTarget(base.transform.forward * this.m_AttackDistance, this.m_AttackRadious + 0.5f, false);
						this.m_HasAttackedPlayer = true;
					}
				}
				else if (Physics.CheckSphere(this.m_KneeTransform.position + base.transform.forward * this.m_AttackDistance, 1f, this.m_ObstructionLayers))
				{
					this.m_AnimationController.SetTrigger("Dazed");
					this.m_IsCharging = false;
					if (!this.m_HasAttackedPlayer)
					{
						this.AttackTarget(base.transform.forward * this.m_AttackDistance, this.m_AttackRadious + 0.5f, false);
					}
					this.m_HasAttackedPlayer = false;
					this.ApplyShake(0.25f);
					this.DoWait(3.6f, null);
				}
			}
			else if (!Physics.Linecast(base.transform.position, this.m_MoveToTargetTransform.position, this.m_ObstructionLayers) && Vector3.Angle(base.transform.forward, this.m_MoveToTargetTransform.position - base.transform.position) < 15f && this.m_AvoidanceCooldownTime <= 0f && !this.m_IsCharging)
			{
				this.m_TrackObjectPosition = this.m_MoveToTargetTransform.position;
				base.transform.rotation = this.FaceDirection(true);
				this.m_AnimationController.SetTrigger("Roar");
				this.DoWait(1.9f, delegate
				{
					this.m_TrackObjectPosition = this.m_MoveToTargetTransform.position;
					base.transform.rotation = this.FaceDirection(false);
					this.m_IsCharging = true;
					this.m_TurnSpeed = 0.25f;
				});
			}
		}
		else
		{
			this.m_WaitTimer -= Time.deltaTime;
		}
	}

	// Token: 0x060010F6 RID: 4342 RVA: 0x0006E478 File Offset: 0x0006C678
	private void FixedUpdate()
	{
		if (this.m_IsCharging)
		{
			this.m_TurnSpeed -= 0.01f;
		}
		if (this.m_GravityMiultiplier < 10f)
		{
			this.m_GravityPower += Vector3.down * this.m_GravityMiultiplier * Time.deltaTime;
		}
		if (this.m_CharacterController.isGrounded && this.m_GravityPower.y <= 0f)
		{
			this.m_GravityPower.y = -10f;
		}
		if (this.m_MoveToTargetTransform)
		{
			if (this.m_AvoidanceCooldownTime <= 0f && this.m_WaitTimer <= 0f)
			{
				this.m_TrackObjectPosition = this.m_MoveToTargetTransform.position;
			}
			this.AvoidObstacle(this.m_MoveToTargetTransform.position);
		}
		if (this.m_IsIntro || this.m_WaitTimer <= 0f)
		{
			base.transform.rotation = this.FaceDirection(true);
			this.m_CharacterController.Move(this.m_MoveDir + this.m_GravityPower);
			this.m_MoveDir = Vector3.zero;
		}
	}

	// Token: 0x060010F7 RID: 4343 RVA: 0x0006E5BC File Offset: 0x0006C7BC
	public Quaternion FaceDirection(bool isSmooth = true)
	{
		Vector3 vector = new Vector3(this.m_TrackObjectPosition.x, base.transform.position.y, this.m_TrackObjectPosition.z) - base.transform.position;
		Quaternion quaternion = ((!(vector == Vector3.zero)) ? Quaternion.LookRotation(vector) : Quaternion.identity);
		return (!(vector == Vector3.zero)) ? ((!isSmooth) ? quaternion : Quaternion.Slerp(base.transform.rotation, quaternion, this.m_TurnSpeed * Time.deltaTime)) : Quaternion.identity;
	}

	// Token: 0x060010F8 RID: 4344 RVA: 0x0006E66C File Offset: 0x0006C86C
	private void WalkAndPunch()
	{
		if (this.m_IsCharging)
		{
			this.m_MoveDir = base.transform.forward * this.m_RunSpeed * Time.fixedDeltaTime;
			this.m_AnimationController.SetInteger("MovementMode", 2);
			return;
		}
		if (Vector3.Distance(this.m_TrackObjectPosition, base.transform.position) <= 3f)
		{
			this.m_AnimationController.SetInteger("MovementMode", 0);
			return;
		}
		if (Physics.CheckSphere(this.m_KneeTransform.transform.position + Vector3.forward * 3f, 5f, this.m_AttackableLayers))
		{
			this.m_AnimationController.SetInteger("MovementMode", 0);
			this.m_AnimationController.SetTrigger("Attack_1");
			this.m_TrackObjectPosition = this.m_MoveToTargetTransform.position;
			base.transform.rotation = this.FaceDirection(false);
			this.DoWait(3f, null);
			return;
		}
		this.m_TurnSpeed = 5f;
		this.m_MoveDir = base.transform.forward * this.m_WalkSpeed * Time.fixedDeltaTime;
		this.m_AnimationController.SetInteger("MovementMode", 1);
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x0000E3E6 File Offset: 0x0000C5E6
	private void DoWait(float waitTime, Action callback = null)
	{
		if (this.m_WaitCallback == null)
		{
			this.m_WaitTimer = waitTime;
			this.m_WaitCallback = callback;
		}
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x0006E7BC File Offset: 0x0006C9BC
	private void AvoidObstacle(Vector3 targetPosition)
	{
		if (this.m_AvoidanceCooldownTime <= 0f)
		{
			this.m_AvoidanceLastPosition = Vector3.zero;
			bool flag = false;
			if (Physics.CheckSphere(this.m_KneeTransform.position + base.transform.forward * (this.m_AttackDistance + 2f), this.m_AttackRadious, this.m_ObstructionLayers, QueryTriggerInteraction.Ignore))
			{
				flag = true;
			}
			Debug.DrawRay(this.m_KneeTransform.position, base.transform.forward * this.m_AttackDistance, Color.white);
			if (flag)
			{
				List<Vector3> list = new List<Vector3>();
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if ((i != 0 || j != 0) && Mathf.Abs(i) != Mathf.Abs(j))
						{
							Vector3 position = this.m_KneeTransform.position;
							Vector3 vector = new Vector3((float)i, 0f, (float)j);
							Vector3 vector2 = position + vector.normalized * (this.m_AttackDistance + 2f);
							if (!Physics.CheckSphere(vector2, 0.6f, this.m_ObstructionLayers) && !Physics.Linecast(this.m_KneeTransform.position, vector2, this.m_ObstructionLayers))
							{
								List<Vector3> list2 = list;
								Vector3 vector3 = vector2;
								Vector3 vector4 = new Vector3((float)i, 0f, (float)j);
								list2.Add(vector3 + vector4.normalized * 10f);
								Debug.DrawLine(this.m_KneeTransform.position, vector2, Color.cyan, 1f);
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

	// Token: 0x060010FB RID: 4347 RVA: 0x0006EA14 File Offset: 0x0006CC14
	public void ApplyShake(float shakePower = 0.5f)
	{
		float num = Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) / this.m_CameraShakeDistance;
		num = 1f - Mathf.Clamp01(num);
		GameManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
		GameManager.Instance.GameCamera.transform.DOKill(false);
		GameManager.Instance.GameCamera.transform.DOShakePosition(0.5f, shakePower * num, 15, 90f, false, true).OnComplete(delegate
		{
			GameManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
		});
	}

	// Token: 0x060010FC RID: 4348 RVA: 0x0006EAD4 File Offset: 0x0006CCD4
	public void AttackTarget(Vector3 _AttackPosition, float _AttackRadious = 4f, bool NoDamage = false)
	{
		Collider[] array = Physics.OverlapSphere(this.m_KneeTransform.position + _AttackPosition, _AttackRadious);
		RaycastHit raycastHit = default(RaycastHit);
		raycastHit.point = this.m_KneeTransform.position;
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			IHittable componentInParent = array[i].gameObject.GetComponentInParent<IHittable>();
			if (componentInParent != null)
			{
				raycastHit.point = array[i].transform.position - Vector3.up + (array[i].transform.position - this.m_KneeTransform.position).normalized;
				componentInParent.Hit(raycastHit, this.m_FistWeaponInfo);
			}
			if (!flag && array[i].gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				GameManager.Instance.Player.AddForce((-base.transform.right + base.transform.forward + Vector3.up * 0.5f) * 25f);
				this.ApplyShake(2f);
				flag = true;
				base.DebugLog("[Ai] - (" + base.gameObject.name + ") - Hit Player");
				if (!NoDamage)
				{
					if (!this.m_IsCharging)
					{
						for (int j = 0; j < this.m_FistWeaponInfo.Damage; j++)
						{
							GameManager.Instance.ShowHurtBorder(true);
						}
					}
					else
					{
						for (int k = 0; k < 5; k++)
						{
							GameManager.Instance.ShowHurtBorder(true);
						}
						GameManager.Instance.ShowHurtBorder(false);
					}
				}
				S13AudioManager.Instance.InvokeEvent("evt_player_hit_by_boris", 0f);
			}
		}
	}

	// Token: 0x04000DC7 RID: 3527
	[Header("AI References")]
	[SerializeField]
	private Transform m_KneeTransform;

	// Token: 0x04000DC8 RID: 3528
	[SerializeField]
	private LayerMask m_ObstructionLayers;

	// Token: 0x04000DC9 RID: 3529
	[SerializeField]
	private Animator m_AnimationController;

	// Token: 0x04000DCA RID: 3530
	[SerializeField]
	private float m_WalkSpeed = 5f;

	// Token: 0x04000DCB RID: 3531
	[SerializeField]
	private float m_RunSpeed = 15f;

	// Token: 0x04000DCC RID: 3532
	[SerializeField]
	private float m_GravityMiultiplier;

	// Token: 0x04000DCD RID: 3533
	[SerializeField]
	private float m_CameraShakeDistance = 30f;

	// Token: 0x04000DCE RID: 3534
	[Header("Attack")]
	[SerializeField]
	private WeaponInfo m_FistWeaponInfo;

	// Token: 0x04000DCF RID: 3535
	[SerializeField]
	private LayerMask m_AttackableLayers;

	// Token: 0x04000DD0 RID: 3536
	[SerializeField]
	private ParticleSystem m_dustCloud;

	// Token: 0x04000DD1 RID: 3537
	[Header("Animation Clips")]
	[SerializeField]
	private AnimationClip m_Anim_Walk;

	// Token: 0x04000DD2 RID: 3538
	[SerializeField]
	private AnimationClip m_Anim_Charge;

	// Token: 0x04000DD3 RID: 3539
	[SerializeField]
	private AnimationClip m_Anim_Attack1;

	// Token: 0x04000DD4 RID: 3540
	[SerializeField]
	private ParticleSystem[] m_PortalParticles;

	// Token: 0x04000DD5 RID: 3541
	private CharacterController m_CharacterController;

	// Token: 0x04000DD6 RID: 3542
	private float m_TurnSpeed = 5f;

	// Token: 0x04000DD7 RID: 3543
	private float m_AttackDistance = 5f;

	// Token: 0x04000DD8 RID: 3544
	private float m_AttackRadious = 2f;

	// Token: 0x04000DD9 RID: 3545
	private Vector3 m_MoveDir;

	// Token: 0x04000DDA RID: 3546
	private Vector3 m_GravityPower;

	// Token: 0x04000DDB RID: 3547
	private Vector3 m_TrackObjectPosition;

	// Token: 0x04000DDC RID: 3548
	private Transform m_MoveToTargetTransform;

	// Token: 0x04000DDD RID: 3549
	protected Vector3 m_AvoidanceLastPosition;

	// Token: 0x04000DDE RID: 3550
	protected float m_AvoidanceCooldownTime;

	// Token: 0x04000DDF RID: 3551
	protected Action m_WaitCallback;

	// Token: 0x04000DE0 RID: 3552
	private float m_WaitTimer;

	// Token: 0x04000DE1 RID: 3553
	private bool m_HasAttackedPlayer;

	// Token: 0x04000DE2 RID: 3554
	[SerializeField]
	private bool m_IsCharging;

	// Token: 0x04000DE3 RID: 3555
	private bool m_IsIntro;
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ai;
using UnityEngine;

// Token: 0x020001A0 RID: 416
public class BorisAiOld : BaseAiController
{
	// Token: 0x14000068 RID: 104
	// (add) Token: 0x06001159 RID: 4441 RVA: 0x0006FD50 File Offset: 0x0006DF50
	// (remove) Token: 0x0600115A RID: 4442 RVA: 0x0006FD88 File Offset: 0x0006DF88
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnToolboxPlaced;

	// Token: 0x14000069 RID: 105
	// (add) Token: 0x0600115B RID: 4443 RVA: 0x0006FDC0 File Offset: 0x0006DFC0
	// (remove) Token: 0x0600115C RID: 4444 RVA: 0x0006FDF8 File Offset: 0x0006DFF8
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnGetUp;

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x0600115D RID: 4445 RVA: 0x0000E9BE File Offset: 0x0000CBBE
	public Transform FlashlightHand
	{
		get
		{
			return this.m_FlashlightHand;
		}
	}

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x0600115E RID: 4446 RVA: 0x0000E9C6 File Offset: 0x0000CBC6
	public Transform ToolboxHand
	{
		get
		{
			return this.m_ToolboxHand;
		}
	}

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x0600115F RID: 4447 RVA: 0x0000E9CE File Offset: 0x0000CBCE
	public Transform PipeHand
	{
		get
		{
			return this.m_PipeHand;
		}
	}

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x06001160 RID: 4448 RVA: 0x0000E9D6 File Offset: 0x0000CBD6
	public Transform Mouth
	{
		get
		{
			return this.m_Mouth;
		}
	}

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x06001161 RID: 4449 RVA: 0x0000E9DE File Offset: 0x0000CBDE
	public Interactable Interact
	{
		get
		{
			return this.m_Interact;
		}
	}

	// Token: 0x06001162 RID: 4450 RVA: 0x0000E9E6 File Offset: 0x0000CBE6
	public override void Init()
	{
		base.Init();
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x0000E9EE File Offset: 0x0000CBEE
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_RunMode = 3;
		this.m_CharacterController.enabled = false;
		this.m_OriginWalkSpeed = this.m_WalkSpeed;
		this.m_OriginRunSpeed = this.m_RunSpeed;
	}

	// Token: 0x06001164 RID: 4452 RVA: 0x0000EA21 File Offset: 0x0000CC21
	public override void Activate()
	{
		base.Activate();
		GameManager.Instance.AiGlobalNetwork.RemoveAi(this);
		base.StopStateMachine();
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x0000EA3F File Offset: 0x0000CC3F
	protected override void Update()
	{
		if (!this.m_IsSitting)
		{
			base.Update();
		}
	}

	// Token: 0x06001166 RID: 4454 RVA: 0x0006FE30 File Offset: 0x0006E030
	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (this.m_Target == null || !this.m_IsLooking || this.m_IsCowering || this.m_IsInVent)
		{
			return;
		}
		float num = Vector3.Angle(base.transform.forward, this.m_Target.position - base.transform.position);
		if (Vector3.Distance(this.m_Target.position, base.transform.position) < 15f && num < 70f)
		{
			Vector3 vector = this.m_Target.position - this.m_Head.position;
			Quaternion quaternion = Quaternion.LookRotation(vector) * Quaternion.Euler(this.m_HeadOffset);
			this.m_Head.rotation = Quaternion.Slerp(this.m_LastLookRotation, quaternion, 2f * Time.deltaTime);
		}
		else
		{
			Quaternion quaternion2 = Quaternion.LookRotation(this.m_HeadLookForward.forward) * Quaternion.Euler(this.m_HeadOffset);
			this.m_Head.rotation = Quaternion.Slerp(this.m_LastLookRotation, quaternion2, 2f * Time.deltaTime);
		}
		this.m_LastLookRotation = this.m_Head.rotation;
	}

	// Token: 0x06001167 RID: 4455 RVA: 0x0006FF80 File Offset: 0x0006E180
	protected override void T_UseWaypoints()
	{
		base.SetMoveDirection(Vector3.zero);
		if (this.m_IsCowering)
		{
			return;
		}
		if (this.m_WaypointMode == AiWaypointMode.Incremental && this.m_WaypointIndex >= this.m_CurrentWaypointList.Count)
		{
			if (this.m_UseRotateAtEndWaypoint && this.m_CurrentWaypointList.Count > 0)
			{
				base.transform.rotation = this.m_CurrentWaypointList[this.m_CurrentWaypointList.Count - 1].transform.rotation;
			}
			base.SetThought(AiThought.Idle);
			this.m_CurrentWaypointList.Clear();
			this.m_WaypointIndex = 0;
			this.m_IsWaypointPathing = true;
			base.SendOnWaypointComplete();
			return;
		}
		if (!this.m_UseRunForWaypoints && Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) < 5f)
		{
			base.SetThought(AiThought.Idle);
			return;
		}
		this.m_WaypointIndex = Mathf.Clamp(this.m_WaypointIndex, 0, this.m_CurrentWaypointList.Count);
		Transform transform = this.m_CurrentWaypointList[this.m_WaypointIndex].transform;
		if (this.m_CurrentWaypointList != null && this.m_CurrentWaypointList.Count > 0)
		{
			if (Vector3.Distance(base.transform.position, transform.position) < this.m_TimescaleDistanceIncrease)
			{
				if (this.m_WaypointMode == AiWaypointMode.Roam)
				{
					this.m_WaypointIndex = global::UnityEngine.Random.Range(0, this.m_CurrentWaypointList.Count);
				}
				else if (this.m_WaypointMode == AiWaypointMode.Loop)
				{
					this.m_WaypointIndex++;
					if (this.m_WaypointIndex == this.m_CurrentWaypointList.Count)
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
			this.m_TrackObjectPosition = transform.position;
			base.CheckSpeed(this.m_UseRunForWaypoints);
			this.StopLooking();
			base.SetMoveDirection(base.transform.forward);
		}
	}

	// Token: 0x06001168 RID: 4456 RVA: 0x0000DE5E File Offset: 0x0000C05E
	protected override void T_EnterRetreat()
	{
		base.T_EnterRetreat();
		base.SetThought(AiThought.Idle);
	}

	// Token: 0x06001169 RID: 4457 RVA: 0x0000EA52 File Offset: 0x0000CC52
	protected override void T_EnterIdle()
	{
		this.LookReset();
		this.m_LastLookRotation = this.m_Head.rotation;
		base.T_EnterIdle();
	}

	// Token: 0x0600116A RID: 4458 RVA: 0x000701DC File Offset: 0x0006E3DC
	protected override void T_Idle()
	{
		base.SetMoveDirection(Vector3.zero);
		base.SetAnimatiorMovement(0);
		if (this.m_IsCowering)
		{
			return;
		}
		if (!this.m_IsFollowing && !this.m_IsWaypointPathing)
		{
			base.T_Idle();
			return;
		}
		if (this.m_IsWaypointPathing && Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) > 5f)
		{
			base.SetThought(AiThought.UseWaypoints);
			return;
		}
		this.LookReset();
		this.m_TrackObjectPosition = base.transform.position + base.transform.forward * 10f;
		if (base.CurrentTarget == null)
		{
			base.SetTarget(this.TestTargetVisibility());
		}
		else
		{
			base.SetThought(AiThought.Follow);
		}
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x000702C0 File Offset: 0x0006E4C0
	protected override void T_Follow()
	{
		base.SetMoveDirection(Vector3.zero);
		if (this.m_IsCowering)
		{
			return;
		}
		if (base.CurrentTarget == null)
		{
			base.SetTarget(this.TestTargetVisibility());
		}
		if (base.CurrentTarget == null)
		{
			return;
		}
		if (Vector3.Distance(base.transform.position, base.CurrentTarget.position) < this.m_AttackDistance)
		{
			base.SetThought(AiThought.Idle);
			return;
		}
		base.SolvePathMovement(base.CurrentTarget.position);
		if (base.CurrentTarget != null)
		{
			base.CheckSpeed(Vector3.Distance(base.transform.position, base.CurrentTarget.position) >= this.m_RunDistance);
		}
		this.StopLooking();
		base.SetMoveDirection(base.transform.forward);
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x000703A8 File Offset: 0x0006E5A8
	public void SetCower(bool active)
	{
		int num = ((!active) ? 0 : 2);
		this.m_IsCowering = active;
		this.m_AnimationController.SetTrigger("Cower");
		this.m_AnimationController.SetInteger("AnimationMode", num);
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x0000EA71 File Offset: 0x0000CC71
	public void LookAround()
	{
		this.m_AnimationController.SetInteger("AnimationMode", 1);
		base.DoWait(this.m_LookAroundAnimTime, base.CurrentThought, delegate
		{
			this.m_AnimationController.SetInteger("AnimationMode", 0);
		});
	}

	// Token: 0x0600116E RID: 4462 RVA: 0x0000EAA2 File Offset: 0x0000CCA2
	public void FollowPlayer()
	{
		this.m_IsFollowing = true;
		base.SetThought(AiThought.Follow);
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x0000EAB2 File Offset: 0x0000CCB2
	public void StopFollowing()
	{
		this.m_IsFollowing = false;
		base.SetThought(AiThought.Idle);
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x0000EAC2 File Offset: 0x0000CCC2
	public void SlowSpeeds()
	{
		this.m_WalkMode = 2;
		this.m_RunSpeed = 6f;
		this.m_WalkSpeed = 3f;
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x0000EAE1 File Offset: 0x0000CCE1
	public void ResetSpeeds()
	{
		this.m_WalkMode = 1;
		this.m_RunSpeed = this.m_OriginRunSpeed;
		this.m_WalkSpeed = this.m_OriginWalkSpeed;
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x0000EB02 File Offset: 0x0000CD02
	public void EnableInteract()
	{
		this.m_Interact.SetActive(true);
	}

	// Token: 0x06001173 RID: 4467 RVA: 0x0000EB10 File Offset: 0x0000CD10
	public void EnterVent()
	{
		this.StopLooking();
		this.m_IsInVent = true;
		this.m_CharacterController.enabled = false;
		this.m_AnimationController.SetInteger("AnimationMode", 3);
		base.SetThought(AiThought.Inactive);
	}

	// Token: 0x06001174 RID: 4468 RVA: 0x000703EC File Offset: 0x0006E5EC
	public void ResetAll()
	{
		this.m_IsInVent = false;
		this.m_CharacterController.enabled = true;
		this.m_TrackObjectPosition = base.transform.position + base.transform.forward * 10f;
		base.SetMoveDirection(Vector3.zero);
		this.m_AnimationController.SetInteger("AnimationMode", 0);
		base.SetAnimatiorMovement(0);
		base.SetThought(AiThought.Idle);
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x0000EB43 File Offset: 0x0000CD43
	public void IsAlreadyActive()
	{
		this.m_AnimationController.SetBool("IsActive", true);
		base.SetThought(AiThought.Idle);
	}

	// Token: 0x06001176 RID: 4470 RVA: 0x00070464 File Offset: 0x0006E664
	public void GetToolbox()
	{
		this.StopLooking();
		this.m_AnimationController.SetTrigger("GetToolbox");
		AnimationClip animationClip = null;
		for (int i = 0; i < this.m_AnimationController.runtimeAnimatorController.animationClips.Length; i++)
		{
			if (this.m_AnimationController.runtimeAnimatorController.animationClips[i].name.Contains("toolbox"))
			{
				animationClip = this.m_AnimationController.runtimeAnimatorController.animationClips[i];
			}
		}
		if (animationClip != null)
		{
			animationClip.AddEvent(this.AddEvent("GrabToolbox", 0.6666667f));
			animationClip.AddEvent(this.AddEvent("PlaceToolbox", 2.3666666f));
			animationClip.AddEvent(this.AddEvent("LookReset", 3.5f));
		}
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x000399F4 File Offset: 0x00037BF4
	private AnimationEvent AddEvent(string functionName, float time)
	{
		return new AnimationEvent
		{
			functionName = functionName,
			time = time,
			objectReferenceParameter = this
		};
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x0000EB5D File Offset: 0x0000CD5D
	public void GrabToolbox()
	{
		this.m_Toolbox.SetParent(this.m_Hand);
		this.m_Toolbox.localPosition = Vector3.zero;
		this.m_Toolbox.localEulerAngles = Vector3.zero;
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x00070534 File Offset: 0x0006E734
	public void PlaceToolbox()
	{
		this.m_Toolbox.SetParent(this.m_ToolboxParent);
		this.m_Toolbox.position = this.m_Table.position;
		this.m_Toolbox.eulerAngles = this.m_Table.eulerAngles;
		GameManager.Instance.AudioManager.PlayAtPosition("Audio/SFX/CH3/SFX_CH3_borisplacetoolbox", this.m_Toolbox.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.OnToolboxPlaced.Send(this);
	}

	// Token: 0x0600117A RID: 4474 RVA: 0x0000EB90 File Offset: 0x0000CD90
	public void LookReset()
	{
		if (this.m_Target != null)
		{
			this.LookAtTarget(this.m_Target);
		}
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x0000EBAF File Offset: 0x0000CDAF
	public void ForceStand()
	{
		this.m_AnimationController.SetBool("IsActive", true);
		this.m_IsSitting = false;
		base.StartStateMachine();
		base.SetThought(AiThought.Idle);
		this.m_CharacterController.enabled = true;
	}

	// Token: 0x0600117C RID: 4476 RVA: 0x000705B0 File Offset: 0x0006E7B0
	public void GetUp()
	{
		this.m_AnimationController.SetBool("IsSitting", false);
		AnimationClip animationClip = null;
		for (int i = 0; i < this.m_AnimationController.runtimeAnimatorController.animationClips.Length; i++)
		{
			if (this.m_AnimationController.runtimeAnimatorController.animationClips[i].name.Contains("getup"))
			{
				animationClip = this.m_AnimationController.runtimeAnimatorController.animationClips[i];
			}
		}
		if (animationClip != null)
		{
			animationClip.AddEvent(this.AddEvent("EnableBorisPathing", 2f));
		}
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x0000EBE2 File Offset: 0x0000CDE2
	private void EnableBorisPathing()
	{
		this.EnableWaypointPathing();
		base.transform.position = this.m_GetUp.position;
		this.OnGetUp.Send(this);
	}

	// Token: 0x0600117E RID: 4478 RVA: 0x0000EC0C File Offset: 0x0000CE0C
	public void EnableWaypointPathing()
	{
		this.m_IsSitting = false;
		base.StartStateMachine();
		base.SetThought(AiThought.Idle);
		this.m_CharacterController.enabled = true;
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x0000EC2E File Offset: 0x0000CE2E
	public void UpdateWaypointList(List<WaypointNode> waypointList, bool isRunning = false)
	{
		this.m_CurrentWaypointList.Clear();
		this.m_UseRunForWaypoints = isRunning;
		this.m_WaypointIndex = 0;
		this.m_IsWaypointPathing = true;
		this.m_CurrentWaypointList = waypointList;
		base.SetThought(AiThought.UseWaypoints);
	}

	// Token: 0x06001180 RID: 4480 RVA: 0x00070650 File Offset: 0x0006E850
	public void AddToWaypointList(List<WaypointNode> waypointList, bool isRunning = false)
	{
		this.m_UseRunForWaypoints = isRunning;
		this.m_IsWaypointPathing = true;
		for (int i = 0; i < waypointList.Count; i++)
		{
			this.m_CurrentWaypointList.Add(waypointList[i]);
		}
	}

	// Token: 0x06001181 RID: 4481 RVA: 0x00002482 File Offset: 0x00000682
	protected override void CheckIfStuck(Vector3 inputPosition)
	{
	}

	// Token: 0x06001182 RID: 4482 RVA: 0x0000EC5E File Offset: 0x0000CE5E
	public void StopWaypointPathing()
	{
		this.m_IsWaypointPathing = false;
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x0000EC67 File Offset: 0x0000CE67
	public void LookAtTarget(Transform target)
	{
		this.m_IsLooking = true;
		this.m_Target = target;
	}

	// Token: 0x06001184 RID: 4484 RVA: 0x0000EC77 File Offset: 0x0000CE77
	public void StopLooking()
	{
		this.m_IsLooking = false;
	}

	// Token: 0x06001185 RID: 4485 RVA: 0x0000EC80 File Offset: 0x0000CE80
	public void ClearTarget()
	{
		this.m_Target = null;
	}

	// Token: 0x04000E1E RID: 3614
	[Header("<< Boris Options >>")]
	[SerializeField]
	private float m_LookAroundAnimTime = 2.66f;

	// Token: 0x04000E1F RID: 3615
	[SerializeField]
	private Interactable m_Interact;

	// Token: 0x04000E20 RID: 3616
	[SerializeField]
	private Transform m_Head;

	// Token: 0x04000E21 RID: 3617
	[SerializeField]
	private Transform m_HeadLookForward;

	// Token: 0x04000E22 RID: 3618
	[SerializeField]
	private Vector3 m_HeadOffset;

	// Token: 0x04000E23 RID: 3619
	[SerializeField]
	private Transform m_ToolboxParent;

	// Token: 0x04000E24 RID: 3620
	[SerializeField]
	private Transform m_Toolbox;

	// Token: 0x04000E25 RID: 3621
	[SerializeField]
	private Transform m_Hand;

	// Token: 0x04000E26 RID: 3622
	[SerializeField]
	private Transform m_Table;

	// Token: 0x04000E27 RID: 3623
	[SerializeField]
	private Transform m_GetUp;

	// Token: 0x04000E28 RID: 3624
	[Header("Hand Holders")]
	[SerializeField]
	private Transform m_FlashlightHand;

	// Token: 0x04000E29 RID: 3625
	[SerializeField]
	private Transform m_ToolboxHand;

	// Token: 0x04000E2A RID: 3626
	[SerializeField]
	private Transform m_PipeHand;

	// Token: 0x04000E2B RID: 3627
	[Header("Mouth")]
	[SerializeField]
	private Transform m_Mouth;

	// Token: 0x04000E2C RID: 3628
	private Transform m_Target;

	// Token: 0x04000E2D RID: 3629
	private bool m_IsInVent;

	// Token: 0x04000E2E RID: 3630
	private bool m_IsLooking;

	// Token: 0x04000E2F RID: 3631
	private bool m_IsSitting = true;

	// Token: 0x04000E30 RID: 3632
	private bool m_IsWaypointPathing;

	// Token: 0x04000E31 RID: 3633
	private bool m_IsFollowing;

	// Token: 0x04000E32 RID: 3634
	private bool m_IsCowering;

	// Token: 0x04000E33 RID: 3635
	private float m_OriginWalkSpeed;

	// Token: 0x04000E34 RID: 3636
	private float m_OriginRunSpeed;

	// Token: 0x04000E35 RID: 3637
	private Quaternion m_LastLookRotation;
}

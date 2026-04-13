using System;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using S13Audio;
using TMG.Core;
using UnityEngine;

// Token: 0x0200019F RID: 415
public class BorisAi : TMGMonoBehaviour, IHittable
{
	// Token: 0x14000065 RID: 101
	// (add) Token: 0x06001129 RID: 4393 RVA: 0x0006F244 File Offset: 0x0006D444
	// (remove) Token: 0x0600112A RID: 4394 RVA: 0x0006F27C File Offset: 0x0006D47C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnToolboxPlaced;

	// Token: 0x14000066 RID: 102
	// (add) Token: 0x0600112B RID: 4395 RVA: 0x0006F2B4 File Offset: 0x0006D4B4
	// (remove) Token: 0x0600112C RID: 4396 RVA: 0x0006F2EC File Offset: 0x0006D4EC
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnGetUp;

	// Token: 0x14000067 RID: 103
	// (add) Token: 0x0600112D RID: 4397 RVA: 0x0006F324 File Offset: 0x0006D524
	// (remove) Token: 0x0600112E RID: 4398 RVA: 0x0006F35C File Offset: 0x0006D55C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnWaypointComplete;

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x0600112F RID: 4399 RVA: 0x0000E6C9 File Offset: 0x0000C8C9
	public Transform FlashlightHand
	{
		get
		{
			return this.m_FlashlightHand;
		}
	}

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x06001130 RID: 4400 RVA: 0x0000E6D1 File Offset: 0x0000C8D1
	public Transform ToolboxHand
	{
		get
		{
			return this.m_ToolboxHand;
		}
	}

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x06001131 RID: 4401 RVA: 0x0000E6D9 File Offset: 0x0000C8D9
	public Transform PipeHand
	{
		get
		{
			return this.m_PipeHand;
		}
	}

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x06001132 RID: 4402 RVA: 0x0000E6E1 File Offset: 0x0000C8E1
	public Transform Mouth
	{
		get
		{
			return this.m_Mouth;
		}
	}

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x06001133 RID: 4403 RVA: 0x0000E6E9 File Offset: 0x0000C8E9
	public Interactable Interact
	{
		get
		{
			return this.m_Interact;
		}
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x0000E6F1 File Offset: 0x0000C8F1
	public override void Init()
	{
		base.Init();
		GameManager.Instance.CharacterManager.Boris = this;
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x0006F394 File Offset: 0x0006D594
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_CharacterController = base.GetComponent<CharacterController>();
		this.m_CharacterController.enabled = false;
		this.LookAtPlayer();
		this.m_OriginWalkSpeed = this.m_WalkSpeed;
		this.m_OriginRunSpeed = this.m_RunSpeed;
		if (this.m_LookAroundClip)
		{
			this.m_AnimationController.gameObject.AddComponent<AnimationEventController>();
			AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_LookAroundClip.name, "ResetMovement", 76);
		}
		if (this.m_AudioProxy)
		{
			this.m_AudioSwitch = this.m_AudioProxy.GetComponentInChildren<S13Switch>();
		}
	}

	// Token: 0x06001136 RID: 4406 RVA: 0x0006F43C File Offset: 0x0006D63C
	protected void Update()
	{
		if (this.m_WaitTimer <= 0f)
		{
			if (this.m_WaitCallback != null)
			{
				this.m_WaitCallback();
				this.m_WaitCallback = null;
			}
		}
		else
		{
			this.m_WaitTimer -= Time.deltaTime;
		}
		this.m_AnimatedHeadPosition = this.m_HeadLookForward.forward;
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x0006F4A0 File Offset: 0x0006D6A0
	protected void LateUpdate()
	{
		if (this.m_WaitTimer <= 0f)
		{
			this.SolveMovement();
		}
		if (this.m_IsCowering || this.m_IsInVent || this.m_IsAnimating)
		{
			return;
		}
		bool flag = this.m_Target && this.m_AnimationController.GetInteger("MovementMode") < 1;
		float num = 0f;
		if (flag && this.m_Target)
		{
			num = Vector3.Angle(base.transform.forward, this.m_Target.position - base.transform.position);
		}
		if (flag && this.m_Target && Vector3.Distance(this.m_Target.position, base.transform.position) < 15f && num < 70f)
		{
			Vector3 vector = this.m_Target.position - this.m_Head.position;
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

	// Token: 0x06001138 RID: 4408 RVA: 0x0000E709 File Offset: 0x0000C909
	public void UpdateWaypointList(List<WaypointNode> waypointList, bool isRunning = false)
	{
		this.m_CurrentWaypointList.Clear();
		this.m_UseRun = isRunning;
		this.m_WaypointIndex = 0;
		this.m_CurrentWaypointList = waypointList;
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x0006F648 File Offset: 0x0006D848
	public void AddToWaypointList(List<WaypointNode> waypointList, bool isRunning = false)
	{
		this.m_UseRun = isRunning;
		for (int i = 0; i < waypointList.Count; i++)
		{
			this.m_CurrentWaypointList.Add(waypointList[i]);
		}
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x0000E72B File Offset: 0x0000C92B
	private void PauseForAnimation(float AnimLength)
	{
		this.m_IsAnimating = true;
		DOTween.Sequence().InsertCallback(AnimLength, delegate
		{
			if (this.m_IsCowering)
			{
				this.m_AnimationController.SetBool("Cower", true);
			}
			this.m_IsAnimating = false;
		});
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x0006F688 File Offset: 0x0006D888
	private void SolveMovement()
	{
		if (this.m_CurrentWaypointList == null || this.m_CurrentWaypointList.Count == 0)
		{
			return;
		}
		if (this.m_IsAnimating || this.m_IsSitting)
		{
			return;
		}
		if (this.m_IsSlow)
		{
			if (Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) > this.m_CowerApproachDistance)
			{
				this.SetCower(true);
				this.m_CowerApproachDistance = 7f;
				return;
			}
			this.SetCower(false);
			this.m_CowerApproachDistance = 10f;
		}
		if (this.m_WaypointIndex >= this.m_CurrentWaypointList.Count)
		{
			if (this.m_CurrentWaypointList.Count > 0)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.m_CurrentWaypointList[this.m_CurrentWaypointList.Count - 1].transform.rotation, 6f * Time.deltaTime);
				base.transform.position = Vector3.MoveTowards(base.transform.position, this.m_CurrentWaypointList[this.m_CurrentWaypointList.Count - 1].transform.position, this.m_WalkSpeed * Time.deltaTime);
			}
			if (Vector3.Distance(base.transform.position, this.m_CurrentWaypointList[this.m_CurrentWaypointList.Count - 1].transform.position) < 0.2f)
			{
				this.m_AnimationController.SetInteger("MovementMode", 0);
				this.SendOnWaypointComplete();
			}
			return;
		}
		if (!this.m_IsSlow && !this.m_UseRun && Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) < 4f)
		{
			this.m_AnimationController.SetInteger("MovementMode", 0);
			return;
		}
		if (Vector3.Distance(base.transform.position, this.m_CurrentWaypointList[this.m_WaypointIndex].transform.position) > 1.5f)
		{
			float num = this.m_WalkSpeed;
			if (this.m_IsSlow)
			{
				this.m_AnimationController.SetInteger("MovementMode", 2);
			}
			else if (this.m_UseRun)
			{
				this.m_AnimationController.SetInteger("MovementMode", 3);
				num = this.m_RunSpeed;
			}
			else
			{
				this.m_AnimationController.SetInteger("MovementMode", 1);
			}
			Vector3 vector = this.m_CurrentWaypointList[this.m_WaypointIndex].transform.position - base.transform.position;
			vector.y = 0f;
			Quaternion quaternion = Quaternion.LookRotation(vector);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, quaternion, 3f * Time.deltaTime);
			this.m_CharacterController.Move(base.transform.forward * num * Time.deltaTime);
			if (this.m_CharacterController.velocity.magnitude < 2f)
			{
				this.m_AnimationController.SetInteger("MovementMode", 0);
			}
			this.m_CharacterController.Move(Vector3.down * 10f * Time.fixedDeltaTime);
		}
		else
		{
			this.m_WaypointIndex++;
		}
	}

	// Token: 0x0600113C RID: 4412 RVA: 0x0006FA14 File Offset: 0x0006DC14
	public void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
	{
		if (!this.m_IsCowering)
		{
			this.m_AnimationController.SetTrigger("Hit");
		}
		this.m_AudioSwitch.Play("hit");
		GameObject fromPool = GameManager.Instance.PoolingManager.GetFromPool("GamePlay/Particles/InkHit");
		fromPool.transform.position = hit.point;
		fromPool.transform.localScale = Vector3.one * 0.2f;
		this.DoWait(0.5f, null);
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x0000E74C File Offset: 0x0000C94C
	protected void SendOnWaypointComplete()
	{
		this.m_CurrentWaypointList.Clear();
		this.m_WaypointIndex = 0;
		this.OnWaypointComplete.Send(this);
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x0000E76C File Offset: 0x0000C96C
	protected void DoWait(float timer, Action callback = null)
	{
		this.m_WaitCallback = callback;
		this.m_WaitTimer = timer;
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x0000E77C File Offset: 0x0000C97C
	public void SetDancing(bool active)
	{
		this.m_AnimationController.SetBool("IsDancing", active);
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x0006FA9C File Offset: 0x0006DC9C
	public void SetCower(bool active)
	{
		int num = ((!active) ? 0 : 2);
		this.m_IsCowering = active;
		this.m_AnimationController.SetBool("Cower", active);
		this.m_AnimationController.SetInteger("AnimationMode", num);
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x0000E78F File Offset: 0x0000C98F
	public void LookAround()
	{
		this.m_IsAnimating = true;
		this.m_AnimationController.SetBool("Cower", false);
		this.m_AnimationController.SetTrigger("LookAround");
		this.PauseForAnimation(this.m_LookAroundClip.length);
	}

	// Token: 0x06001142 RID: 4418 RVA: 0x0000E7CA File Offset: 0x0000C9CA
	public void ResetMovement()
	{
		this.m_IsAnimating = false;
		this.m_AnimationController.SetTrigger("Reset");
	}

	// Token: 0x06001143 RID: 4419 RVA: 0x0000E7E3 File Offset: 0x0000C9E3
	public void SlowSpeeds()
	{
		this.m_IsSlow = true;
		this.m_RunSpeed = 6f;
		this.m_WalkSpeed = 3f;
	}

	// Token: 0x06001144 RID: 4420 RVA: 0x0000E802 File Offset: 0x0000CA02
	public void ResetSpeeds()
	{
		this.m_IsSlow = false;
		this.m_RunSpeed = this.m_OriginRunSpeed;
		this.m_WalkSpeed = this.m_OriginWalkSpeed;
	}

	// Token: 0x06001145 RID: 4421 RVA: 0x0000E823 File Offset: 0x0000CA23
	public void EnableInteract()
	{
		this.m_Interact.SetActive(true);
	}

	// Token: 0x06001146 RID: 4422 RVA: 0x0000E831 File Offset: 0x0000CA31
	public void EnterVent()
	{
		this.StopLooking();
		this.m_IsInVent = true;
		this.m_CharacterController.enabled = false;
		this.m_AnimationController.SetInteger("AnimationMode", 3);
	}

	// Token: 0x06001147 RID: 4423 RVA: 0x0000E85D File Offset: 0x0000CA5D
	public void ResetAll()
	{
		this.m_IsInVent = false;
		this.m_CharacterController.enabled = true;
		this.m_AnimationController.SetInteger("AnimationMode", 0);
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x0000E883 File Offset: 0x0000CA83
	public void IsAlreadyActive()
	{
		this.m_AnimationController.SetBool("IsActive", true);
	}

	// Token: 0x06001149 RID: 4425 RVA: 0x0006FAE0 File Offset: 0x0006DCE0
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
			animationClip.AddEvent(this.AddEvent("PlaceToolboxEvent", 2.3666666f));
			animationClip.AddEvent(this.AddEvent("LookAtPlayer", 3.5f));
		}
	}

	// Token: 0x0600114A RID: 4426 RVA: 0x000399F4 File Offset: 0x00037BF4
	private AnimationEvent AddEvent(string functionName, float time)
	{
		return new AnimationEvent
		{
			functionName = functionName,
			time = time,
			objectReferenceParameter = this
		};
	}

	// Token: 0x0600114B RID: 4427 RVA: 0x0000E896 File Offset: 0x0000CA96
	public void GrabToolbox()
	{
		this.m_Toolbox.SetParent(this.m_Hand);
		this.m_Toolbox.localPosition = Vector3.zero;
		this.m_Toolbox.localEulerAngles = Vector3.zero;
	}

	// Token: 0x0600114C RID: 4428 RVA: 0x0000E8C9 File Offset: 0x0000CAC9
	public void PlaceToolboxEvent()
	{
		this.PlaceToolbox(false);
	}

	// Token: 0x0600114D RID: 4429 RVA: 0x0006FBB0 File Offset: 0x0006DDB0
	public void PlaceToolbox(bool isSilent = false)
	{
		this.m_Toolbox.SetParent(this.m_ToolboxParent);
		this.m_Toolbox.position = this.m_Table.position;
		this.m_Toolbox.eulerAngles = this.m_Table.eulerAngles;
		if (!isSilent)
		{
			GameManager.Instance.AudioManager.PlayAtPosition("Audio/SFX/CH3/SFX_CH3_borisplacetoolbox", this.m_Toolbox.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
			this.OnToolboxPlaced.Send(this);
		}
	}

	// Token: 0x0600114E RID: 4430 RVA: 0x0000E8D2 File Offset: 0x0000CAD2
	public void ForceStand()
	{
		this.m_AnimationController.SetBool("IsActive", true);
		this.m_IsSitting = false;
		this.m_CharacterController.enabled = true;
	}

	// Token: 0x0600114F RID: 4431 RVA: 0x0006FC30 File Offset: 0x0006DE30
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

	// Token: 0x06001150 RID: 4432 RVA: 0x0000E8F8 File Offset: 0x0000CAF8
	private void EnableBorisPathing()
	{
		this.EnableWaypointPathing();
		base.transform.position = this.m_GetUp.position;
		this.OnGetUp.Send(this);
	}

	// Token: 0x06001151 RID: 4433 RVA: 0x0000E922 File Offset: 0x0000CB22
	public void EnableWaypointPathing()
	{
		this.m_IsSitting = false;
		this.m_CharacterController.enabled = true;
	}

	// Token: 0x06001152 RID: 4434 RVA: 0x0000E937 File Offset: 0x0000CB37
	public void StopWaypointPathing()
	{
		this.UpdateWaypointList(new List<WaypointNode>(), false);
		this.m_AnimationController.SetInteger("MovementMode", 0);
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x0000E956 File Offset: 0x0000CB56
	public void LookAtTarget(Transform target)
	{
		this.m_Target = target;
	}

	// Token: 0x06001154 RID: 4436 RVA: 0x0000E95F File Offset: 0x0000CB5F
	public void LookAtPlayer()
	{
		this.LookAtTarget(GameManager.Instance.GameCamera.transform);
	}

	// Token: 0x06001155 RID: 4437 RVA: 0x0000E976 File Offset: 0x0000CB76
	public void StopLooking()
	{
		this.m_Target = null;
	}

	// Token: 0x06001156 RID: 4438 RVA: 0x0006FCD0 File Offset: 0x0006DED0
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
			audioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioClip, base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		}
		audioClips[num] = audioClips[0];
		audioClips[0] = audioClip;
		return audioObject;
	}

	// Token: 0x04000DF6 RID: 3574
	[Header("<< Boris Options >>")]
	[SerializeField]
	private Interactable m_Interact;

	// Token: 0x04000DF7 RID: 3575
	[SerializeField]
	private Transform m_Head;

	// Token: 0x04000DF8 RID: 3576
	[SerializeField]
	private Transform m_HeadLookForward;

	// Token: 0x04000DF9 RID: 3577
	[SerializeField]
	private Vector3 m_HeadOffset;

	// Token: 0x04000DFA RID: 3578
	[SerializeField]
	private Transform m_ToolboxParent;

	// Token: 0x04000DFB RID: 3579
	[SerializeField]
	private Transform m_Toolbox;

	// Token: 0x04000DFC RID: 3580
	[SerializeField]
	private Transform m_Hand;

	// Token: 0x04000DFD RID: 3581
	[SerializeField]
	private Transform m_Table;

	// Token: 0x04000DFE RID: 3582
	[SerializeField]
	private Transform m_GetUp;

	// Token: 0x04000DFF RID: 3583
	[SerializeField]
	private Animator m_AnimationController;

	// Token: 0x04000E00 RID: 3584
	[SerializeField]
	private Transform m_AudioProxy;

	// Token: 0x04000E01 RID: 3585
	[SerializeField]
	private AnimationClip m_LookAroundClip;

	// Token: 0x04000E02 RID: 3586
	[Header("<< Boris Moement Options >>")]
	[SerializeField]
	private float m_WalkSpeed;

	// Token: 0x04000E03 RID: 3587
	[SerializeField]
	private float m_RunSpeed;

	// Token: 0x04000E04 RID: 3588
	[Header("Hand Holders")]
	[SerializeField]
	private Transform m_FlashlightHand;

	// Token: 0x04000E05 RID: 3589
	[SerializeField]
	private Transform m_ToolboxHand;

	// Token: 0x04000E06 RID: 3590
	[SerializeField]
	private Transform m_PipeHand;

	// Token: 0x04000E07 RID: 3591
	[Header("Mouth")]
	[SerializeField]
	private Transform m_Mouth;

	// Token: 0x04000E08 RID: 3592
	private Transform m_Target;

	// Token: 0x04000E09 RID: 3593
	private List<WaypointNode> m_CurrentWaypointList = new List<WaypointNode>();

	// Token: 0x04000E0A RID: 3594
	private int m_WaypointIndex;

	// Token: 0x04000E0B RID: 3595
	private bool m_UseRun;

	// Token: 0x04000E0C RID: 3596
	protected float m_WaitTimer;

	// Token: 0x04000E0D RID: 3597
	private S13Switch m_AudioSwitch;

	// Token: 0x04000E0E RID: 3598
	private bool m_IsInVent;

	// Token: 0x04000E0F RID: 3599
	private bool m_IsSitting = true;

	// Token: 0x04000E10 RID: 3600
	private Quaternion SnapRotation;

	// Token: 0x04000E11 RID: 3601
	private Vector3 SnapPosition;

	// Token: 0x04000E12 RID: 3602
	private Vector3 m_AnimatedHeadPosition;

	// Token: 0x04000E13 RID: 3603
	private bool m_IsCowering;

	// Token: 0x04000E14 RID: 3604
	private bool m_IsSlow;

	// Token: 0x04000E15 RID: 3605
	private bool m_IsAnimating;

	// Token: 0x04000E16 RID: 3606
	private float m_OriginWalkSpeed;

	// Token: 0x04000E17 RID: 3607
	private float m_OriginRunSpeed;

	// Token: 0x04000E18 RID: 3608
	private float m_CowerApproachDistance = 10f;

	// Token: 0x04000E19 RID: 3609
	private CharacterController m_CharacterController;

	// Token: 0x04000E1A RID: 3610
	protected Action m_WaitCallback;

	// Token: 0x04000E1B RID: 3611
	private Quaternion m_LastLookRotation;
}

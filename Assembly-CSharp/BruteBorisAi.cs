using System;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using S13Audio;
using TMG.Core;
using UnityEngine;

// Token: 0x020001A1 RID: 417
public class BruteBorisAi : TMGMonoBehaviour
{
	// Token: 0x1400006A RID: 106
	// (add) Token: 0x06001188 RID: 4488 RVA: 0x0007072C File Offset: 0x0006E92C
	// (remove) Token: 0x06001189 RID: 4489 RVA: 0x00070764 File Offset: 0x0006E964
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnBegin;

	// Token: 0x1400006B RID: 107
	// (add) Token: 0x0600118A RID: 4490 RVA: 0x0007079C File Offset: 0x0006E99C
	// (remove) Token: 0x0600118B RID: 4491 RVA: 0x000707D4 File Offset: 0x0006E9D4
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnCartSmashed;

	// Token: 0x1400006C RID: 108
	// (add) Token: 0x0600118C RID: 4492 RVA: 0x0007080C File Offset: 0x0006EA0C
	// (remove) Token: 0x0600118D RID: 4493 RVA: 0x00070844 File Offset: 0x0006EA44
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnDoorSmashed;

	// Token: 0x1400006D RID: 109
	// (add) Token: 0x0600118E RID: 4494 RVA: 0x0007087C File Offset: 0x0006EA7C
	// (remove) Token: 0x0600118F RID: 4495 RVA: 0x000708B4 File Offset: 0x0006EAB4
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnTired;

	// Token: 0x1400006E RID: 110
	// (add) Token: 0x06001190 RID: 4496 RVA: 0x000708EC File Offset: 0x0006EAEC
	// (remove) Token: 0x06001191 RID: 4497 RVA: 0x00070924 File Offset: 0x0006EB24
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnHit;

	// Token: 0x1400006F RID: 111
	// (add) Token: 0x06001192 RID: 4498 RVA: 0x0007095C File Offset: 0x0006EB5C
	// (remove) Token: 0x06001193 RID: 4499 RVA: 0x00070994 File Offset: 0x0006EB94
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnDeath;

	// Token: 0x14000070 RID: 112
	// (add) Token: 0x06001194 RID: 4500 RVA: 0x000709CC File Offset: 0x0006EBCC
	// (remove) Token: 0x06001195 RID: 4501 RVA: 0x00070A04 File Offset: 0x0006EC04
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnComplete;

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x06001196 RID: 4502 RVA: 0x0000EC9C File Offset: 0x0000CE9C
	public Transform CartParent
	{
		get
		{
			return this.m_CartParentTransform;
		}
	}

	// Token: 0x06001197 RID: 4503 RVA: 0x0000ECA4 File Offset: 0x0000CEA4
	public override void Init()
	{
		base.Init();
		this.m_CharacterController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06001198 RID: 4504 RVA: 0x00070A3C File Offset: 0x0006EC3C
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		GameManager.Instance.CharacterManager.BruteBoris = this;
		this.m_Bone.SetActive(false);
		this.m_ThrowableCartObject.SetActive(false);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Walk.name, "Stomp", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Walk.name, "Stomp", 20);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_BattleDeath.name, "ShakeCamera", 117);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Charge.name, "Stomp", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Charge.name, "Stomp", 19);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_ThrowWalk.name, "Stomp", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_ThrowWalk.name, "Stomp", 20);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Attack1.name, "Attack1", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Attack2.name, "Attack2", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Attack1.name, "DoAttack", 15);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Attack2.name, "DoAttack", 15);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_JumpStart.name, "DoJump", 22);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_GroundPound.name, "DoSmash", 30);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_GroundPound.name, "PlaySmashAudio", 0);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_PickupCart.name, "PickupCart", 30);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_ThrowCart.name, "ThrowCart", 26);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Reveal.name, "RevealGrabCart", 15);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Reveal.name, "HenryDialogue", 80);
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Reveal.name, "UnlockPlayer", 430);
		this.m_LockPhysics = true;
		base.transform.position = this.m_RevealPosition.position + this.m_RevealPosition.forward * -5f;
		base.transform.rotation = this.m_RevealPosition.rotation;
		this.m_GutsCollider.enabled = false;
		this.m_RumbleClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Rumble_Loop_01");
		this.m_AudioSwitch = base.GetComponentInChildren<S13Switch>();
	}

	// Token: 0x06001199 RID: 4505 RVA: 0x00070D18 File Offset: 0x0006EF18
	public void DoRevealSequence()
	{
		bool flag = false;
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data != null)
		{
			flag = GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HasBorisBone;
		}
		this.m_Bone.SetActive(flag);
		this.m_ThrowableCartObject.SetActive(true);
		GameManager.Instance.Player.transform.SetParent(null);
		GameManager.Instance.Player.GoToAndLookAt(this.m_PlayerLandPoint);
		base.transform.position = this.m_RevealPosition.position;
		this.m_AnimationController.speed = 1f;
		AnimationEventUtil.AddAnimationEvent(ref this.m_AnimationController, this.m_Anim_Reveal.name, "Reveal", 0);
		this.m_AnimationController.SetTrigger("Reveal");
		this.m_CartRevealAnimator.SetTrigger("Reveal");
		this.m_LockPhysics = true;
		this.DoWait(15f, delegate
		{
			this.SetThought(BruteBorisAi.BorisThought.PHASE1);
		});
	}

	// Token: 0x0600119A RID: 4506 RVA: 0x00070E1C File Offset: 0x0006F01C
	public void Reset()
	{
		this.m_AnimationController.SetTrigger("Reset");
		this.m_DoingSpecialAttack = false;
		this.m_SpecialAttackCooldown = 5f;
		this.m_SpecialAttackCount = 0;
		this.m_DidJump = false;
		this.m_IsTired = false;
		this.CanSpawnInk = true;
		this.m_AvoidanceCooldownTime = 0.5f;
		this.m_TrackObjectPosition = Vector3.zero;
		this.m_WaitCallback = null;
		this.m_WaitTimer = 0f;
		this.m_IsCartPickedUp = false;
		this.m_MoveDir = Vector3.zero;
		this.m_GravityPower = Vector3.zero;
		this.CurrentPhase = BruteBorisAi.BorisThought.PHASE1;
		this.CurrentThought = BruteBorisAi.BorisThought.NONE;
		this.m_IsDoingPickupAnimation = false;
		this.m_CartRestocked = true;
		this.m_HasSmashedDoor = false;
		this.m_ThrowableCartObject.transform.localPosition = this.m_CartPath[0].localPosition;
		if (this.m_GrabbedObject)
		{
			global::UnityEngine.Object.Destroy(this.m_GrabbedObject);
		}
		if (this.m_ActiveCart)
		{
			this.m_ActiveCart.transform.DOKill(false);
			global::UnityEngine.Object.Destroy(this.m_ActiveCart);
			this.m_ActiveCart = null;
		}
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x0000ECB8 File Offset: 0x0000CEB8
	public void WarpToStartLocation()
	{
		base.transform.position = this.m_BorisWarpPoint.position;
		base.transform.eulerAngles = this.m_BorisWarpPoint.eulerAngles;
	}

	// Token: 0x0600119C RID: 4508 RVA: 0x0000ECE6 File Offset: 0x0000CEE6
	public void SetCartActive(bool active)
	{
		this.m_CartParentTransform.gameObject.SetActive(active);
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x0000ECF9 File Offset: 0x0000CEF9
	public void SetCartParent(bool Unparent = false)
	{
		if (Unparent)
		{
			this.m_CartObjectToParent.SetParent(null);
		}
		else if (this.m_CartObjectToParent)
		{
			this.m_CartObjectToParent.SetParent(this.m_CartParentTransform);
		}
	}

	// Token: 0x0600119E RID: 4510 RVA: 0x0000ED33 File Offset: 0x0000CF33
	public void Reveal()
	{
		this.m_AudioSwitch.Play("reveal");
	}

	// Token: 0x0600119F RID: 4511 RVA: 0x00070F3C File Offset: 0x0006F13C
	public void UnlockPlayer()
	{
		this.OnBegin.Send(this);
		Transform freeRoamCam = GameManager.Instance.GameCamera.FreeRoamCam;
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		sequence.InsertCallback(num, delegate
		{
			freeRoamCam.SetParent(null);
			this.m_CartDestroy.transform.position = this.m_CartParentTransform.position;
			this.m_CartDestroy.Destroy(this.m_CartDestroy.transform.position, 30f, 15f, 2f);
			S13AudioManager.Instance.InvokeEvent("evt_haunted_house_cart_smashed", 0f);
		});
		sequence.Insert(num, freeRoamCam.DOMoveX(this.m_PlayerLandPoint.position.x, 1f, false));
		sequence.Insert(num, freeRoamCam.DOMoveZ(this.m_PlayerLandPoint.position.z, 1f, false));
		sequence.Insert(num, freeRoamCam.DOMoveY(this.m_PlayerLandPoint.position.y - 2f, 1f, false));
		sequence.Insert(num, freeRoamCam.DORotate(new Vector3(-90f, 0f, -90f), 1f, RotateMode.Fast));
		sequence.InsertCallback(1f, delegate
		{
			this.transform.position = this.m_BorisWarpPoint.position;
		});
		num += 1.5f;
		sequence.Insert(num, freeRoamCam.DORotate(this.m_PlayerLandPoint.eulerAngles, 1f, RotateMode.Fast).SetEase(Ease.InOutQuad));
		sequence.Insert(num, freeRoamCam.DOMove(GameManager.Instance.Player.HeadContainer.position, 1f, false).SetEase(Ease.InOutQuad));
		sequence.OnComplete(delegate
		{
			this.OnCartSmashed.Send(this);
			GameManager.Instance.GameCamera.ExitFreeRoamCam();
			GameManager.Instance.Player.SetLock(false, false);
			if (GameManager.Instance.Player.WeaponGameObject)
			{
				GameManager.Instance.Player.WeaponGameObject.SetActive(true);
			}
		});
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x0000ED45 File Offset: 0x0000CF45
	public void SetTarget(Transform NewTarget)
	{
		this.m_MoveToTargetTransform = NewTarget;
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x0000ED4E File Offset: 0x0000CF4E
	public void SetThought(BruteBorisAi.BorisThought Thought)
	{
		this.PreviousThought = this.CurrentThought;
		this.CurrentThought = Thought;
	}

	// Token: 0x060011A2 RID: 4514 RVA: 0x000710E0 File Offset: 0x0006F2E0
	private void SetTired()
	{
		if (!this.m_IsTired)
		{
			this.OnTired.Send(this);
			this.m_TurnSpeed = 8f;
			this.m_IsTired = true;
			this.m_AnimationController.SetInteger("MovementMode", 0);
			this.m_AnimationController.SetBool("Tired", true);
			this.m_GutsCollider.enabled = true;
			this.SetTarget(null);
			if (this.CurrentThought != BruteBorisAi.BorisThought.PHASE3)
			{
				this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
			}
			else
			{
				this.m_TrackObjectPosition = this.m_ThrowLocation.position + this.m_ThrowLocation.forward * 10f;
			}
			this.PreviousThought = this.CurrentThought;
			this.SetThought(BruteBorisAi.BorisThought.NONE);
			this.SpawnInkSequence();
		}
	}

	// Token: 0x060011A3 RID: 4515 RVA: 0x000711BC File Offset: 0x0006F3BC
	private void Phase1()
	{
		this.m_LockPhysics = false;
		this.m_TurnSpeed = 5f;
		if (this.m_DoingSpecialAttack)
		{
			this.SetTarget(null);
			this.m_TrackObjectPosition = base.transform.position + base.transform.forward * 5f;
			this.m_MoveDir = base.transform.forward * this.m_ChargeSpeed * Time.fixedDeltaTime;
			this.m_SpecialAttackCooldown = this.m_ChargeCooldown;
			this.m_ChargeSafetyTimer += Time.deltaTime;
			if (Physics.CheckSphere(this.m_KneeTransform.position + base.transform.forward, 1.4f, this.m_AttackableLayers))
			{
				this.m_AnimationController.SetTrigger("ChargeThrough");
				this.AttackTarget(base.transform.forward * 4f, 2f, false);
				this.m_AnimationController.SetInteger("ChargeAnim", global::UnityEngine.Random.Range(0, 3));
				return;
			}
			if (Physics.CheckSphere(this.m_KneeTransform.position + Vector3.up + base.transform.forward * 3f, 2f, this.m_ObstructionLayers + LayerMask.GetMask(new string[] { "Player" })) || this.m_ChargeSafetyTimer > 6f)
			{
				this.m_AnimationController.SetTrigger("ChargeEnd");
				this.m_DoingSpecialAttack = false;
				this.m_ChargeSafetyTimer = 0f;
				this.AttackTarget(base.transform.forward * 4f, 4f, false);
				this.DoWait(1.6f, delegate
				{
					this.m_SpecialAttackCount++;
					if (this.m_SpecialAttackCount >= 3)
					{
						this.SetTired();
					}
				});
				return;
			}
		}
		else
		{
			this.m_AnimationController.ResetTrigger("ChargeEnd");
			this.SetTarget(GameManager.Instance.Player.transform);
			if (Vector3.Distance(base.transform.position, this.m_MoveToTargetTransform.position) > 12f && this.m_SpecialAttackCooldown <= 0f)
			{
				if (Vector3.Angle(base.transform.forward, this.m_MoveToTargetTransform.position - base.transform.position) < 15f)
				{
					this.m_AnimationController.SetInteger("MovementMode", 0);
					this.m_AnimationController.SetTrigger("ChargeStart");
					this.m_AudioSwitch.Play("charge");
					this.m_DoingSpecialAttack = true;
					this.DoWait(2f, delegate
					{
						this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
						base.transform.rotation = this.FaceDirection(false);
					});
					return;
				}
				this.WalkAndPunch(true);
				return;
			}
			else
			{
				this.WalkAndPunch(true);
			}
		}
	}

	// Token: 0x060011A4 RID: 4516 RVA: 0x00071488 File Offset: 0x0006F688
	private void Phase2()
	{
		this.m_LockPhysics = false;
		this.m_TurnSpeed = 5f;
		float num = this.m_JumpForwardForce;
		if (this.m_DoingSpecialAttack)
		{
			if (this.m_DidJump)
			{
				this.SetTarget(null);
				if (!this.m_HasSmashedDoor)
				{
					this.m_TrackObjectPosition = this.m_SmashDoorPosition.position;
					num = this.m_JumpForwardForce * 1.3f;
				}
				else
				{
					this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
				}
				if (!this.m_CharacterController.isGrounded)
				{
					this.m_MoveDir = base.transform.forward * num * Vector3.Distance(base.transform.position, this.m_TrackObjectPosition) * Time.fixedDeltaTime;
				}
				else if (this.m_GravityPower.y < 0f)
				{
					this.m_dustCloud.Emit(30);
					this.AttackTarget(Vector3.zero, 10f, false);
					this.m_DoingSpecialAttack = false;
					this.m_AnimationController.SetTrigger("JumpEnd");
					this.m_DidJump = false;
					this.m_AudioSwitch.Play("land");
					if (!this.m_HasSmashedDoor)
					{
						this.OnDoorSmashed.Send(this);
						this.m_HasSmashedDoor = true;
					}
					this.ApplyShake(2f);
					this.DoWait(1f, delegate
					{
						this.m_SpecialAttackCount++;
						if (this.m_SpecialAttackCount >= 3)
						{
							this.SetTired();
						}
					});
				}
			}
			this.m_AnimationController.SetInteger("MovementMode", 0);
			this.m_SpecialAttackCooldown = this.m_JumpCooldown;
			return;
		}
		this.m_AnimationController.ResetTrigger("JumpEnd");
		this.SetTarget(GameManager.Instance.Player.transform);
		if (Vector3.Distance(base.transform.position, this.m_MoveToTargetTransform.position) > 12f && this.m_SpecialAttackCooldown <= 0f)
		{
			this.m_AnimationController.SetInteger("MovementMode", 0);
			this.m_AnimationController.SetTrigger("JumpStart");
			this.m_DoingSpecialAttack = true;
			return;
		}
		this.WalkAndPunch(true);
	}

	// Token: 0x060011A5 RID: 4517 RVA: 0x0000ED63 File Offset: 0x0000CF63
	public void DoJump()
	{
		this.m_DidJump = true;
		this.Jump(this.m_JumpPower);
		this.m_AudioSwitch.Play("jump");
	}

	// Token: 0x060011A6 RID: 4518 RVA: 0x0007169C File Offset: 0x0006F89C
	private void Phase3()
	{
		this.m_LockPhysics = false;
		this.m_TurnSpeed = 5f;
		this.SetTarget(null);
		if (this.m_IsCartPickedUp)
		{
			if (Vector3.Distance(base.transform.position, this.m_ThrowLocation.position) > 2f)
			{
				this.WalkAndPunch(false);
			}
			else
			{
				this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
				this.FaceDirection(true);
				if (!this.m_IsDoingPickupAnimation)
				{
					this.m_IsDoingPickupAnimation = true;
					base.transform.position = this.m_ThrowLocation.position;
					this.m_AnimationController.ResetTrigger("PickupCart");
					this.m_AnimationController.SetInteger("MovementMode", 0);
					this.m_AnimationController.SetTrigger("ThrowCart");
					this.m_GrabbedObject.GetComponentInChildren<S13Switch>().Play("toss");
					this.DoCartRestockSequence();
					this.DoWait(2f, null);
				}
			}
		}
		else if (Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) < 5f)
		{
			if (!this.m_IsDoingPickupAnimation)
			{
				this.m_TrackObjectPosition = GameManager.Instance.Player.transform.position;
				this.WalkAndPunch(true);
				return;
			}
		}
		else if (Vector3.Distance(base.transform.position, this.m_GrabLocation.position) > 2f || !this.m_CartRestocked)
		{
			this.m_TrackObjectPosition = this.m_GrabLocation.position;
			this.WalkAndPunch(true);
		}
		else
		{
			base.transform.position = this.m_GrabLocation.position;
			this.m_TrackObjectPosition = this.m_GrabLocation.position + this.m_GrabLocation.forward * 5f;
			if (!this.m_IsDoingPickupAnimation)
			{
				this.m_IsDoingPickupAnimation = true;
				this.m_AnimationController.ResetTrigger("ThrowCart");
				this.m_AnimationController.SetInteger("MovementMode", 0);
				this.m_AnimationController.SetTrigger("PickupCart");
			}
			else if (this.m_GrabbedObject && this.m_CartRestocked)
			{
				this.m_GrabbedObject.transform.SetParent(this.m_GrabHand);
				this.m_GrabbedObject.transform.localPosition = new Vector3(0f, 2.7f, 4f);
				this.m_GrabbedObject.transform.localEulerAngles = new Vector3(178f, 124f, -5.2f);
				this.m_GrabbedObject.GetComponentInChildren<S13Switch>().Play("pickup");
				if (!this.m_IsCartPickedUp)
				{
					this.DoCartRestockSequence();
					this.m_TrackObjectPosition = this.m_ThrowLocation.position;
					this.m_IsCartPickedUp = true;
					this.m_IsDoingPickupAnimation = false;
				}
			}
		}
	}

	// Token: 0x060011A7 RID: 4519 RVA: 0x0007199C File Offset: 0x0006FB9C
	public void PickupCart()
	{
		this.m_GrabbedObject = global::UnityEngine.Object.Instantiate<GameObject>(this.m_ActiveCart);
		this.m_GrabbedObject.transform.position = this.m_ActiveCart.transform.position;
		this.m_GrabbedObject.transform.eulerAngles = this.m_ActiveCart.transform.eulerAngles;
		global::UnityEngine.Object.Destroy(this.m_ActiveCart);
		this.m_ActiveCart = null;
	}

	// Token: 0x060011A8 RID: 4520 RVA: 0x00071A0C File Offset: 0x0006FC0C
	public void ThrowCart()
	{
		this.m_IsCartPickedUp = false;
		this.m_GrabbedObject.transform.SetParent(null);
		Rigidbody component = this.m_GrabbedObject.GetComponent<Rigidbody>();
		ThrowableObject component2 = this.m_GrabbedObject.GetComponent<ThrowableObject>();
		component.isKinematic = false;
		component2.Initialize(component2.WeaponInfo, base.transform.forward * 50f + Vector3.up * 10f, false);
		component2.Throw();
		this.m_GrabbedObject = null;
		this.DoWait(1f, delegate
		{
			this.m_SpecialAttackCount++;
			this.m_IsDoingPickupAnimation = false;
			if (this.m_SpecialAttackCount >= 3)
			{
				this.SetTired();
			}
		});
	}

	// Token: 0x060011A9 RID: 4521 RVA: 0x0000ED88 File Offset: 0x0000CF88
	public void HandleOnCartDestroyed(object sender, EventArgs e)
	{
		this.m_ActiveCart = null;
		this.DoCartRestockSequence();
	}

	// Token: 0x060011AA RID: 4522 RVA: 0x00071AAC File Offset: 0x0006FCAC
	private void DoCartRestockSequence()
	{
		if (this.m_ActiveCart)
		{
			return;
		}
		this.m_ActiveCart = global::UnityEngine.Object.Instantiate<GameObject>(this.m_ThrowableCartObject);
		this.m_ActiveCart.GetComponent<EnemyHittableObject>().OnDestroyEvent += this.HandleOnCartDestroyed;
		this.m_ActiveCart.transform.SetParent(this.m_ThrowableCartObject.transform.parent);
		this.m_ActiveCart.transform.localPosition = this.m_CartPath[0].localPosition;
		this.m_CartRestocked = false;
		if (this.m_CartRestockSequence != null)
		{
			this.m_CartRestockSequence.Kill(false);
			this.m_CartRestockSequence = null;
		}
		this.m_CartRestockSequence = DOTween.Sequence();
		float num = 1f;
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < this.m_CartPath.Length; i++)
		{
			list.Add(this.m_CartPath[i].localPosition);
		}
		this.m_CartRestockSequence.Insert(num, this.m_ActiveCart.transform.DOLocalPath(list.ToArray(), 10f, PathType.CatmullRom, PathMode.Full3D, 10, null).SetLookAt(0.01f, new Vector3?(-this.m_ActiveCart.transform.right), null).SetEase(Ease.Linear));
		this.m_CartRestockSequence.OnComplete(delegate
		{
			this.m_CartRestocked = true;
		});
	}

	// Token: 0x060011AB RID: 4523 RVA: 0x00071C20 File Offset: 0x0006FE20
	private void WalkAndPunch(bool canPunch = true)
	{
		if (Physics.CheckSphere(this.m_AnimationController.transform.position, 3f, this.m_AttackableLayers) && canPunch)
		{
			this.m_AnimationController.SetInteger("MovementMode", 0);
			int num = global::UnityEngine.Random.Range(1, 3);
			this.m_AnimationController.SetTrigger("Attack_" + num.ToString());
			this.DoWait(1f, null);
			return;
		}
		if (Vector3.Distance(this.m_TrackObjectPosition, base.transform.position) > 2f)
		{
			this.m_MoveDir = base.transform.forward * 5f * Time.fixedDeltaTime;
			this.m_AnimationController.SetInteger("MovementMode", 1);
			return;
		}
		this.m_AnimationController.SetInteger("MovementMode", 0);
	}

	// Token: 0x060011AC RID: 4524 RVA: 0x00071D00 File Offset: 0x0006FF00
	private void Update()
	{
		if (GameManager.Instance.isPaused)
		{
			return;
		}
		if (this.m_WaitTimer <= 0f && !this.m_IsTired)
		{
			if (this.CurrentThought == BruteBorisAi.BorisThought.PHASE1)
			{
				this.Phase1();
			}
			else if (this.CurrentThought == BruteBorisAi.BorisThought.PHASE2)
			{
				this.Phase2();
			}
			else if (this.CurrentThought == BruteBorisAi.BorisThought.PHASE3)
			{
				this.Phase3();
			}
		}
		if (this.m_SpecialAttackCooldown > 0f && this.CurrentThought != BruteBorisAi.BorisThought.NONE && !this.m_IsTired && this.m_WaitTimer <= 0f)
		{
			this.m_SpecialAttackCooldown -= Time.deltaTime;
		}
		if (this.m_WaitTimer <= 0f)
		{
			if (this.m_WaitCallback != null)
			{
				Action waitCallback = this.m_WaitCallback;
				this.m_WaitTimer = 0f;
				this.m_WaitCallback = null;
				waitCallback();
			}
		}
		else
		{
			this.m_WaitTimer -= Time.deltaTime;
		}
	}

	// Token: 0x060011AD RID: 4525 RVA: 0x00071E14 File Offset: 0x00070014
	private void FixedUpdate()
	{
		if (this.m_LockPhysics)
		{
			return;
		}
		if (this.m_GravityMiultiplier < 10f)
		{
			this.m_GravityPower += Vector3.down * this.m_GravityMiultiplier * Time.fixedDeltaTime;
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
		base.transform.rotation = this.FaceDirection(true);
		this.m_CharacterController.Move(this.m_MoveDir + this.m_GravityPower);
		this.m_MoveDir = Vector3.zero;
	}

	// Token: 0x060011AE RID: 4526 RVA: 0x0000ED97 File Offset: 0x0000CF97
	private void Jump(float JumpPower)
	{
		this.m_GravityPower.y = JumpPower;
	}

	// Token: 0x060011AF RID: 4527 RVA: 0x00071F14 File Offset: 0x00070114
	public Quaternion FaceDirection(bool isSmooth = true)
	{
		Vector3 vector = new Vector3(this.m_TrackObjectPosition.x, base.transform.position.y, this.m_TrackObjectPosition.z) - base.transform.position;
		Quaternion quaternion = ((!(vector == Vector3.zero)) ? Quaternion.LookRotation(vector) : Quaternion.identity);
		return (!(vector == Vector3.zero)) ? ((!isSmooth) ? quaternion : Quaternion.Slerp(base.transform.rotation, quaternion, this.m_TurnSpeed * Time.deltaTime)) : Quaternion.identity;
	}

	// Token: 0x060011B0 RID: 4528 RVA: 0x00071FC4 File Offset: 0x000701C4
	public void AttackTarget(Vector3 _AttackPosition, float _AttackRadious = 4f, bool NoDamage = false)
	{
		Collider[] array = Physics.OverlapSphere(this.m_KneeTransform.position + _AttackPosition, _AttackRadious, this.m_AttackableLayers);
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
					for (int j = 0; j < this.m_FistWeaponInfo.Damage; j++)
					{
						GameManager.Instance.ShowHurtBorder(true);
					}
				}
				S13AudioManager.Instance.InvokeEvent("evt_player_hit_by_boris", 0f);
			}
		}
	}

	// Token: 0x060011B1 RID: 4529 RVA: 0x00072174 File Offset: 0x00070374
	private void AvoidObstacle(Vector3 targetPosition)
	{
		if (this.m_AvoidanceCooldownTime <= 0f)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(this.m_KneeTransform.position, (this.m_TrackObjectPosition + Vector3.up - base.transform.position).normalized, out raycastHit, this.m_AvoidanceDistance * 2f, this.m_ObstructionLayers))
			{
				List<Vector3> list = new List<Vector3>();
				global::UnityEngine.Debug.DrawLine(this.m_KneeTransform.position, this.m_TrackObjectPosition + Vector3.up, Color.yellow, 2f);
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if ((i != 0 || j != 0) && Mathf.Abs(i) != Mathf.Abs(j))
						{
							Vector3 position = this.m_KneeTransform.position;
							Vector3 vector = new Vector3((float)i, 0f, (float)j);
							Vector3 vector2 = position + vector.normalized * this.m_AvoidanceDistance;
							if (!Physics.Linecast(this.m_KneeTransform.position, vector2, this.m_ObstructionLayers))
							{
								list.Add(vector2);
								global::UnityEngine.Debug.DrawLine(this.m_KneeTransform.position, vector2, Color.cyan, 1f);
							}
						}
					}
				}
				float num = -1f;
				Vector3 vector3 = Vector3.zero;
				for (int k = 0; k < list.Count; k++)
				{
					float num2 = Vector3.Distance(targetPosition, list[k]);
					if (k == 0 || num2 < num)
					{
						num = num2;
						vector3 = list[k];
					}
				}
				this.m_TrackObjectPosition = vector3;
				this.m_AvoidanceCooldownTime = 1f;
			}
		}
		else
		{
			this.m_AvoidanceCooldownTime -= Time.deltaTime;
		}
	}

	// Token: 0x060011B2 RID: 4530 RVA: 0x0000EDA5 File Offset: 0x0000CFA5
	public void Hit(bool isBaconSoup)
	{
		this.OnHit.Send(this);
		if (this.CurrentPhase != BruteBorisAi.BorisThought.PHASE3)
		{
			this.Hurt();
		}
		else
		{
			this.Death(isBaconSoup);
		}
	}

	// Token: 0x060011B3 RID: 4531 RVA: 0x00072360 File Offset: 0x00070560
	private void Hurt()
	{
		this.ResetTiredBoris();
		this.m_AnimationController.SetTrigger("Hit");
		this.m_AudioSwitch.Play("hit");
		this.ActivateParticles(1f);
		this.SpawnInkSequence();
		this.m_SpecialAttackCooldown = 5f;
		this.m_SpecialAttackCount = 0;
		this.m_GutsCollider.enabled = false;
		this.DoWait(2f, delegate
		{
			this.SetThought(this.CurrentPhase);
			this.PreviousThought = this.CurrentPhase;
		});
		this.m_AnimationController.SetTrigger("GroundPound");
		if (this.CurrentPhase == BruteBorisAi.BorisThought.PHASE1)
		{
			this.CurrentPhase = BruteBorisAi.BorisThought.PHASE2;
			this.m_SpecialAttackCooldown = 2f;
		}
		else if (this.CurrentPhase == BruteBorisAi.BorisThought.PHASE2)
		{
			this.CurrentPhase = BruteBorisAi.BorisThought.PHASE3;
			this.DoCartRestockSequence();
		}
	}

	// Token: 0x060011B4 RID: 4532 RVA: 0x00072428 File Offset: 0x00070628
	private void Death(bool isBaconSoup)
	{
		if (this.m_CharacterController)
		{
			this.m_CharacterController.enabled = false;
		}
		this.SetThought(BruteBorisAi.BorisThought.NONE);
		base.transform.rotation = this.m_ThrowLocation.rotation;
		base.transform.position = this.m_ThrowLocation.position;
		if (isBaconSoup && GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[5] != -1)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[5] = GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[5] * 414;
			bool flag = false;
			if (GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[0] == GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[0] * 414 && GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[1] == GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[1] * 414 && GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[2] == GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[2] * 414 && GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[3] == GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[3] * 414 && GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[4] == GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[4] * 414 && GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionBools[5] == GameManager.Instance.GameData.CurrentSaveFile.CH4Data.InternecionValues[5] * 414)
			{
				GameManager.Instance.GameData.CurrentSaveFile.Internecions[3] = 4;
				flag = true;
			}
			GameManager.Instance.GameDataManager.Save(true, false);
			if (flag)
			{
				GameManager.Instance.GameCamera.VisionEffect.BeginEffect(false);
				DOTween.Sequence().InsertCallback(1f, delegate
				{
					GameManager.Instance.GameCamera.VisionEffect.EndEffect(false);
				});
				this.m_RumbleAudio = GameManager.Instance.AudioManager.Play(this.m_RumbleClip, AudioObjectType.SOUND_EFFECT, -1, false);
				GameManager.Instance.GameCamera.transform.DOShakePosition(5f, 0.1f, 15, 90f, false, false).OnComplete(new TweenCallback(this.ScreenRumbleOnComplete));
			}
		}
		this.OnDeath.Send(this);
		this.m_Bone.SetActive(false);
		this.m_LockPhysics = true;
		this.m_GutsCollider.enabled = false;
		this.ActivateParticles(6f);
		this.m_AnimationController.SetBool("Tired", false);
		this.m_AnimationController.SetTrigger("Dead");
		this.m_AudioSwitch.Play("battle_fall");
		DOTween.Sequence().InsertCallback(3.8f, new TweenCallback(this.ActualDeath));
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x000727BC File Offset: 0x000709BC
	private void ScreenRumbleOnComplete()
	{
		GameManager.Instance.GameCamera.transform.DOKill(false);
		GameManager.Instance.GameCamera.transform.DOLocalMove(Vector3.zero, 0.5f, false);
		this.m_RumbleAudio.AudioSource.DOFade(0f, 1f).OnComplete(delegate
		{
			if (this.m_RumbleAudio != null)
			{
				this.m_RumbleAudio.Clear();
				this.m_RumbleAudio = null;
			}
		});
	}

	// Token: 0x060011B6 RID: 4534 RVA: 0x0007282C File Offset: 0x00070A2C
	private void ActualDeath()
	{
		base.transform.rotation = this.m_ThrowLocation.rotation;
		base.transform.position = this.m_ThrowLocation.position;
		this.DisableParticles();
		this.m_dustCloud.Emit(30);
		this.AttackTarget(-base.transform.forward * 4f, 10f, true);
		GameManager.Instance.GameCamera.transform.DOKill(false);
		GameManager.Instance.GameCamera.transform.DOShakePosition(0.4f, 1.2f, 18, 90f, false, true).SetEase(Ease.Linear).OnComplete(delegate
		{
			GameManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
		});
		this.OnComplete.Send(this);
	}

	// Token: 0x060011B7 RID: 4535 RVA: 0x0000EDD1 File Offset: 0x0000CFD1
	private void ResetTiredBoris()
	{
		this.m_AnimationController.SetBool("Tired", false);
		this.m_IsTired = false;
		this.m_GutsCollider.enabled = false;
		this.SetThought(this.PreviousThought);
	}

	// Token: 0x060011B8 RID: 4536 RVA: 0x00072910 File Offset: 0x00070B10
	public void DoSmash()
	{
		this.m_dustCloud.Emit(30);
		if (Vector3.Distance(base.transform.position, GameManager.Instance.Player.transform.position) < 10f)
		{
			GameManager.Instance.Player.AddForce((-base.transform.right + base.transform.forward + Vector3.up * 0.5f) * 25f);
			this.ApplyShake(2f);
		}
		this.DoWait(1f, delegate
		{
			this.CurrentThought = this.CurrentPhase;
		});
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x000729C8 File Offset: 0x00070BC8
	private void SpawnInkSequence()
	{
		this.ActivateParticles(3f);
		this.m_AudioSwitch.Play("gush");
		this.m_InkSequence.Kill(false);
		this.m_InkSequence = DOTween.Sequence();
		float num = 5f;
		this.m_InkSequence.InsertCallback(num, new TweenCallback(this.ResetTiredBoris));
	}

	// Token: 0x060011BA RID: 4538 RVA: 0x00072A28 File Offset: 0x00070C28
	private void ActivateParticles(float duration)
	{
		for (int i = 0; i < this.m_HitInk.Length; i++)
		{
			ParticleSystem particleSystem = this.m_HitInk[i];
			ParticleSystem.MainModule main = particleSystem.main;
			particleSystem.Stop();
			main.duration = duration;
			particleSystem.Play();
		}
	}

	// Token: 0x060011BB RID: 4539 RVA: 0x00072A74 File Offset: 0x00070C74
	private void DisableParticles()
	{
		for (int i = 0; i < this.m_HitInk.Length; i++)
		{
			this.m_HitInk[i].Stop();
		}
	}

	// Token: 0x060011BC RID: 4540 RVA: 0x0000EE03 File Offset: 0x0000D003
	private void DoWait(float waitTime, Action callback = null)
	{
		if (this.m_WaitCallback == null)
		{
			this.m_WaitTimer = waitTime;
			this.m_WaitCallback = callback;
			this.PreviousThought = this.CurrentThought;
		}
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x0000EE2A File Offset: 0x0000D02A
	public void ApplyAttack(int attackIndex)
	{
		this.m_AudioSwitch.Play((attackIndex != 0) ? "attack2" : "attack1");
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x0000EE4C File Offset: 0x0000D04C
	public void ApplyStomp()
	{
		this.m_AudioSwitch.Play("footsteps");
		this.ApplyShake(0.5f);
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x00072AA8 File Offset: 0x00070CA8
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

	// Token: 0x060011C0 RID: 4544 RVA: 0x0000EE69 File Offset: 0x0000D069
	public void PlaySmashAudio()
	{
		this.m_AudioSwitch.Play("pound");
	}

	// Token: 0x060011C1 RID: 4545 RVA: 0x0000EE7B File Offset: 0x0000D07B
	protected override void OnDisposed()
	{
		if (this.m_InkSequence != null)
		{
			this.m_InkSequence.Kill(false);
			this.m_InkSequence = null;
		}
		this.m_AudioSwitch = null;
		base.OnDisposed();
	}

	// Token: 0x04000E3D RID: 3645
	[Header("AI References")]
	[SerializeField]
	private Transform m_KneeTransform;

	// Token: 0x04000E3E RID: 3646
	[SerializeField]
	private LayerMask m_ObstructionLayers;

	// Token: 0x04000E3F RID: 3647
	[Header("General References")]
	[SerializeField]
	private Animator m_AnimationController;

	// Token: 0x04000E40 RID: 3648
	[SerializeField]
	private float m_CameraShakeDistance = 30f;

	// Token: 0x04000E41 RID: 3649
	[SerializeField]
	private float m_GravityMiultiplier;

	// Token: 0x04000E42 RID: 3650
	[Header("Attack")]
	[SerializeField]
	private WeaponInfo m_FistWeaponInfo;

	// Token: 0x04000E43 RID: 3651
	[SerializeField]
	private LayerMask m_AttackableLayers;

	// Token: 0x04000E44 RID: 3652
	[SerializeField]
	private ParticleSystem m_dustCloud;

	// Token: 0x04000E45 RID: 3653
	[Header("Guts")]
	[SerializeField]
	private Collider m_GutsCollider;

	// Token: 0x04000E46 RID: 3654
	[SerializeField]
	private ParticleSystem[] m_HitInk;

	// Token: 0x04000E47 RID: 3655
	[Header("Reveal Objects")]
	[SerializeField]
	private Animator m_CartRevealAnimator;

	// Token: 0x04000E48 RID: 3656
	[SerializeField]
	private Transform m_RevealPosition;

	// Token: 0x04000E49 RID: 3657
	[SerializeField]
	private Transform m_CartParentTransform;

	// Token: 0x04000E4A RID: 3658
	[SerializeField]
	private Transform m_PlayerLandPoint;

	// Token: 0x04000E4B RID: 3659
	[SerializeField]
	private Transform m_BorisWarpPoint;

	// Token: 0x04000E4C RID: 3660
	[SerializeField]
	private DestructibleObject m_CartDestroy;

	// Token: 0x04000E4D RID: 3661
	[Header("[==PHASE 1==]")]
	[SerializeField]
	private float m_ChargeSpeed = 20f;

	// Token: 0x04000E4E RID: 3662
	[SerializeField]
	private float m_ChargeCooldown = 5f;

	// Token: 0x04000E4F RID: 3663
	[Header("[==PHASE 2==]")]
	[SerializeField]
	private float m_JumpForwardForce = 20f;

	// Token: 0x04000E50 RID: 3664
	[SerializeField]
	private float m_JumpPower = 30f;

	// Token: 0x04000E51 RID: 3665
	[SerializeField]
	private float m_JumpCooldown = 5f;

	// Token: 0x04000E52 RID: 3666
	[Header("[==PHASE 3==]")]
	[SerializeField]
	private GameObject m_ThrowableCartObject;

	// Token: 0x04000E53 RID: 3667
	[SerializeField]
	private Transform m_ThrowLocation;

	// Token: 0x04000E54 RID: 3668
	[SerializeField]
	private Transform m_GrabLocation;

	// Token: 0x04000E55 RID: 3669
	[SerializeField]
	private Transform m_GrabHand;

	// Token: 0x04000E56 RID: 3670
	[SerializeField]
	private Transform[] m_CartPath;

	// Token: 0x04000E57 RID: 3671
	[Header("Animation Clips")]
	[SerializeField]
	private AnimationClip m_Anim_Walk;

	// Token: 0x04000E58 RID: 3672
	[SerializeField]
	private AnimationClip m_Anim_BattleDeath;

	// Token: 0x04000E59 RID: 3673
	[SerializeField]
	private AnimationClip m_Anim_Reveal;

	// Token: 0x04000E5A RID: 3674
	[SerializeField]
	private AnimationClip m_Anim_Attack1;

	// Token: 0x04000E5B RID: 3675
	[SerializeField]
	private AnimationClip m_Anim_Attack2;

	// Token: 0x04000E5C RID: 3676
	[SerializeField]
	private AnimationClip m_Anim_Charge;

	// Token: 0x04000E5D RID: 3677
	[SerializeField]
	private AnimationClip m_Anim_JumpStart;

	// Token: 0x04000E5E RID: 3678
	[SerializeField]
	private AnimationClip m_Anim_GroundPound;

	// Token: 0x04000E5F RID: 3679
	[SerializeField]
	private AnimationClip m_Anim_PickupCart;

	// Token: 0x04000E60 RID: 3680
	[SerializeField]
	private AnimationClip m_Anim_ThrowCart;

	// Token: 0x04000E61 RID: 3681
	[SerializeField]
	private AnimationClip m_Anim_ThrowWalk;

	// Token: 0x04000E62 RID: 3682
	[Header("Doors")]
	[SerializeField]
	private Transform m_SmashDoorPosition;

	// Token: 0x04000E63 RID: 3683
	[Header("Easter Egg Objects")]
	[SerializeField]
	private GameObject m_Bone;

	// Token: 0x04000E64 RID: 3684
	private CharacterController m_CharacterController;

	// Token: 0x04000E65 RID: 3685
	private Transform m_MoveToTargetTransform;

	// Token: 0x04000E66 RID: 3686
	private Transform m_CartObjectToParent;

	// Token: 0x04000E67 RID: 3687
	private bool m_DoingSpecialAttack;

	// Token: 0x04000E68 RID: 3688
	private float m_SpecialAttackCooldown = 5f;

	// Token: 0x04000E69 RID: 3689
	private int m_SpecialAttackCount;

	// Token: 0x04000E6A RID: 3690
	private bool m_DidJump;

	// Token: 0x04000E6B RID: 3691
	private float m_ChargeSafetyTimer;

	// Token: 0x04000E6C RID: 3692
	public bool CanSpawnInk = true;

	// Token: 0x04000E6D RID: 3693
	private bool m_IsTired;

	// Token: 0x04000E6E RID: 3694
	private Sequence m_InkSequence;

	// Token: 0x04000E6F RID: 3695
	private S13Switch m_AudioSwitch;

	// Token: 0x04000E70 RID: 3696
	private float m_AvoidanceCooldownTime = 0.5f;

	// Token: 0x04000E71 RID: 3697
	private float m_AvoidanceDistance = 4f;

	// Token: 0x04000E72 RID: 3698
	private Vector3 m_TrackObjectPosition;

	// Token: 0x04000E73 RID: 3699
	protected Action m_WaitCallback;

	// Token: 0x04000E74 RID: 3700
	private float m_WaitTimer;

	// Token: 0x04000E75 RID: 3701
	private bool m_IsCartPickedUp;

	// Token: 0x04000E76 RID: 3702
	private GameObject m_ActiveCart;

	// Token: 0x04000E77 RID: 3703
	private GameObject m_GrabbedObject;

	// Token: 0x04000E78 RID: 3704
	private bool m_CartRestocked = true;

	// Token: 0x04000E79 RID: 3705
	private Vector3 m_MoveDir;

	// Token: 0x04000E7A RID: 3706
	private Vector3 m_GravityPower;

	// Token: 0x04000E7B RID: 3707
	private BruteBorisAi.BorisThought CurrentPhase = BruteBorisAi.BorisThought.PHASE1;

	// Token: 0x04000E7C RID: 3708
	private BruteBorisAi.BorisThought CurrentThought;

	// Token: 0x04000E7D RID: 3709
	private BruteBorisAi.BorisThought PreviousThought;

	// Token: 0x04000E7E RID: 3710
	private float m_TurnSpeed = 5f;

	// Token: 0x04000E7F RID: 3711
	private bool m_IsDoingPickupAnimation;

	// Token: 0x04000E80 RID: 3712
	private Sequence m_CartRestockSequence;

	// Token: 0x04000E81 RID: 3713
	private bool m_HasSmashedDoor;

	// Token: 0x04000E82 RID: 3714
	private bool m_LockPhysics;

	// Token: 0x04000E83 RID: 3715
	private AudioClip m_RumbleClip;

	// Token: 0x04000E84 RID: 3716
	private AudioObject m_RumbleAudio;

	// Token: 0x020001A2 RID: 418
	public enum BorisThought
	{
		// Token: 0x04000E89 RID: 3721
		NONE,
		// Token: 0x04000E8A RID: 3722
		PHASE1,
		// Token: 0x04000E8B RID: 3723
		PHASE2,
		// Token: 0x04000E8C RID: 3724
		PHASE3,
		// Token: 0x04000E8D RID: 3725
		SMASH
	}
}

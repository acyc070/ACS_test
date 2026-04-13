using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using TMG.Controls;
using TMG.Core;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class BaseWeapon : TMGMonoBehaviour
{
	// Token: 0x140000BC RID: 188
	// (add) Token: 0x06001B2C RID: 6956 RVA: 0x00091938 File Offset: 0x0008FB38
	// (remove) Token: 0x06001B2D RID: 6957 RVA: 0x00091970 File Offset: 0x0008FB70
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnInteract;

	// Token: 0x140000BD RID: 189
	// (add) Token: 0x06001B2E RID: 6958 RVA: 0x000919A8 File Offset: 0x0008FBA8
	// (remove) Token: 0x06001B2F RID: 6959 RVA: 0x000919E0 File Offset: 0x0008FBE0
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnEquipped;

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06001B30 RID: 6960 RVA: 0x00015DDC File Offset: 0x00013FDC
	public Interactable Interaction
	{
		get
		{
			return this.m_Interaction;
		}
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x00015DE4 File Offset: 0x00013FE4
	public WeaponInfo GetWeaponInfo()
	{
		return this.m_WeaponInfo;
	}

	// Token: 0x06001B32 RID: 6962 RVA: 0x00015DEC File Offset: 0x00013FEC
	public override void Init()
	{
		base.Init();
		this.m_Interaction.OnInteracted += this.HandleOnInteracted;
	}

	// Token: 0x06001B33 RID: 6963 RVA: 0x00015E0B File Offset: 0x0001400B
	public virtual void Update()
	{
		this.Attack();
	}

	// Token: 0x06001B34 RID: 6964 RVA: 0x00091A18 File Offset: 0x0008FC18
	private void Attack()
	{
		if (!this.m_CanAttack || !this.m_IsEquipped || GameManager.Instance.Player.isLocked || GameManager.Instance.isPaused)
		{
			return;
		}
		bool flag = ((!this.m_IsHoldToAttack) ? PlayerInput.Attack() : PlayerInput.AttackHold());
		if (flag)
		{
			this.m_CanAttack = false;
			this.OnAttack();
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x00002482 File Offset: 0x00000682
	public virtual void OnAttack()
	{
	}

	// Token: 0x06001B36 RID: 6966 RVA: 0x00091A90 File Offset: 0x0008FC90
	public void Equip()
	{
		GameManager.Instance.ShowCrosshair();
		GameManager.Instance.Player.EquipWeapon();
		this.m_WeaponInfo.Attacker = GameManager.Instance.Player.gameObject;
		this.CleanEquip();
		this.OnEquip();
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x00002482 File Offset: 0x00000682
	protected virtual void OnEquip()
	{
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x00091ADC File Offset: 0x0008FCDC
	private IEnumerator DelayEquip()
	{
		if (base.IsDisposed)
		{
			yield return null;
		}
		yield return new WaitForEndOfFrame();
		if (!base.IsDisposed)
		{
			this.Equip();
		}
		yield break;
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x00015E13 File Offset: 0x00014013
	public void UnEquip()
	{
		this.m_IsEquipped = false;
		this.m_CanAttack = false;
		this.UpdateLayer("Default");
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x00015E2E File Offset: 0x0001402E
	public void CleanEquip()
	{
		this.m_IsEquipped = true;
		this.m_CanAttack = true;
		this.UpdateLayer("Weapon");
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x00015E49 File Offset: 0x00014049
	public void KillInteraction()
	{
		this.m_Interaction.TurnOfAllEFfects();
		this.m_Interaction.Dispose();
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x00091AF8 File Offset: 0x0008FCF8
	private void HandleOnInteracted(object sender, EventArgs e)
	{
		if (GameManager.Instance.Player.WeaponGameObject && GameManager.Instance.Player.InactiveWeapon)
		{
			this.Interaction.ResetInteraction();
			return;
		}
		this.m_Interaction.OnInteracted -= this.HandleOnInteracted;
		Interactable interactable = sender as Interactable;
		if (!interactable)
		{
			return;
		}
		this.OnInteracted();
		this.OnInteract.Send(this);
		if (base.IsDisposed)
		{
			return;
		}
		global::UnityEngine.Object.Destroy(interactable.gameObject);
		this.m_Interaction = null;
		if (this.m_EquipSound != null)
		{
			GameManager.Instance.AudioManager.Play(this.m_EquipSound, AudioObjectType.SOUND_EFFECT, 0, false);
		}
		if (GameManager.Instance.Player.WeaponGameObject)
		{
			GameManager.Instance.Player.InactiveWeapon = GameManager.Instance.Player.WeaponGameObject;
			GameManager.Instance.Player.WeaponGameObject = null;
			GameManager.Instance.Player.InactiveWeapon.SetActive(false);
		}
		GameManager.Instance.Player.WeaponGameObject = base.gameObject;
		base.transform.SetParent(GameManager.Instance.Player.WeaponParent);
		base.transform.localEulerAngles = Vector3.zero;
		base.transform.localPosition = Vector3.zero;
		base.StartCoroutine(this.DelayEquip());
	}

	// Token: 0x06001B3D RID: 6973 RVA: 0x00002482 File Offset: 0x00000682
	protected virtual void OnInteracted()
	{
	}

	// Token: 0x06001B3E RID: 6974 RVA: 0x00091C80 File Offset: 0x0008FE80
	protected virtual void HandleSwingBegin()
	{
		if (this.m_AttackClips == null || this.m_AttackClips.Count <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_AttackClips.Count);
		AudioClip audioClip = this.m_AttackClips[num];
		GameManager.Instance.AudioManager.Play(audioClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_AttackClips[num] = this.m_AttackClips[0];
		this.m_AttackClips[0] = audioClip;
		this.m_HasAttackedThisSwing = false;
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x00015E61 File Offset: 0x00014061
	protected virtual void HandleSwingHit()
	{
		if (!this.m_HasAttackedThisSwing)
		{
			this.CheckHitRaycast();
			this.m_HasAttackedThisSwing = true;
		}
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x00002482 File Offset: 0x00000682
	protected virtual void HandleSwingEnd()
	{
	}

	// Token: 0x06001B41 RID: 6977 RVA: 0x00015E7B File Offset: 0x0001407B
	protected virtual void HandleSwingComplete()
	{
		this.m_CanAttack = true;
	}

	// Token: 0x06001B42 RID: 6978 RVA: 0x00091D0C File Offset: 0x0008FF0C
	public void CheckHitRaycast()
	{
		Transform transform = GameManager.Instance.GameCamera.transform;
		RaycastHit raycastHit;
		if (Physics.SphereCast(transform.position, 0.7f, transform.forward, out raycastHit, this.m_WeaponRange + 1.5f, ~this.m_IgnoreLayers))
		{
			this.OnRaycastHit(raycastHit);
			if (this.m_debugHitObject)
			{
				global::UnityEngine.Debug.Log("Weapon Hit Object: " + raycastHit.transform.name);
			}
		}
	}

	// Token: 0x06001B43 RID: 6979 RVA: 0x00091D8C File Offset: 0x0008FF8C
	private void OnRaycastHit(RaycastHit _hitData)
	{
		GameObject gameObject = _hitData.transform.gameObject;
		IHittable componentInParent = gameObject.GetComponentInParent<IHittable>();
		global::UnityEngine.Debug.Log("OnRaycastHit() " + gameObject, gameObject);
		if (componentInParent != null)
		{
			componentInParent.Hit(_hitData, this.m_WeaponInfo);
		}
	}

	// Token: 0x06001B44 RID: 6980 RVA: 0x00091DD4 File Offset: 0x0008FFD4
	private void UpdateLayer(string layer)
	{
		if (this.m_WeaponModel)
		{
			this.m_WeaponModel.layer = LayerMask.NameToLayer(layer);
			Transform[] componentsInChildren = this.m_WeaponModel.GetComponentsInChildren<Transform>(true);
			if (componentsInChildren != null && componentsInChildren.Length > 0)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.layer = LayerMask.NameToLayer(layer);
				}
			}
		}
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x00015E84 File Offset: 0x00014084
	public void SetDamage(int damage)
	{
		this.m_WeaponInfo.Damage = damage;
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x00015E92 File Offset: 0x00014092
	protected void ResetAttackSequence()
	{
		this.KillAttackSequence();
		this.m_AttackSequence = DOTween.Sequence();
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x00015EA5 File Offset: 0x000140A5
	protected void KillAttackSequence()
	{
		if (this.m_AttackSequence != null)
		{
			this.m_AttackSequence.Kill(false);
			this.m_AttackSequence = null;
		}
	}

	// Token: 0x06001B48 RID: 6984 RVA: 0x00015EC5 File Offset: 0x000140C5
	protected void SendOnEquipped()
	{
		this.OnEquipped.Send(this);
	}

	// Token: 0x06001B49 RID: 6985 RVA: 0x00015ED3 File Offset: 0x000140D3
	protected override void OnDisposed()
	{
		this.KillAttackSequence();
		base.OnDisposed();
	}

	// Token: 0x040017B9 RID: 6073
	[Header("Layer Masks")]
	[SerializeField]
	private LayerMask m_IgnoreLayers;

	// Token: 0x040017BA RID: 6074
	[Header("Interaction")]
	[SerializeField]
	private Interactable m_Interaction;

	// Token: 0x040017BB RID: 6075
	[Header("Weapon Model")]
	[SerializeField]
	private bool m_IsHoldToAttack;

	// Token: 0x040017BC RID: 6076
	[SerializeField]
	protected GameObject m_WeaponModel;

	// Token: 0x040017BD RID: 6077
	[SerializeField]
	private float m_WeaponRange;

	// Token: 0x040017BE RID: 6078
	[Header("WeaponInfo")]
	[SerializeField]
	protected AudioClip m_EquipSound;

	// Token: 0x040017BF RID: 6079
	[SerializeField]
	protected List<AudioClip> m_AttackClips;

	// Token: 0x040017C0 RID: 6080
	[SerializeField]
	private WeaponInfo m_WeaponInfo;

	// Token: 0x040017C1 RID: 6081
	[Header("Debug")]
	[SerializeField]
	private bool m_debugHitObject;

	// Token: 0x040017C2 RID: 6082
	protected Sequence m_AttackSequence;

	// Token: 0x040017C3 RID: 6083
	protected bool m_CanAttack;

	// Token: 0x040017C4 RID: 6084
	protected bool m_IsEquipped;

	// Token: 0x040017C5 RID: 6085
	private bool m_HasAttackedThisSwing;
}

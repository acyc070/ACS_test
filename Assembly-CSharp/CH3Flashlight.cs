using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class CH3Flashlight : TMGMonoBehaviour
{
	// Token: 0x14000011 RID: 17
	// (add) Token: 0x060008FB RID: 2299 RVA: 0x0004B300 File Offset: 0x00049500
	// (remove) Token: 0x060008FC RID: 2300 RVA: 0x0004B338 File Offset: 0x00049538
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnInteracted;

	// Token: 0x060008FD RID: 2301 RVA: 0x0004B370 File Offset: 0x00049570
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		for (int i = 0; i < this.m_Lights.Count; i++)
		{
			this.m_Lights[i].gameObject.SetActive(false);
		}
		this.m_Interaction.SetActive(false);
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000092FC File Offset: 0x000074FC
	public void Activate()
	{
		this.m_Interaction.SetActive(true);
		this.m_Interaction.OnInteracted += this.HandleInteractionOnInteracted;
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x00009321 File Offset: 0x00007521
	private void HandleInteractionOnInteracted(object sender, EventArgs e)
	{
		this.Equip();
		this.OnInteracted.Send(this);
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x0004B3C4 File Offset: 0x000495C4
	public void Equip()
	{
		this.m_Interaction.OnInteracted -= this.HandleInteractionOnInteracted;
		this.m_Interaction.SetActive(false);
		this.m_Interaction.gameObject.layer = LayerMask.NameToLayer("Weapon");
		GameManager.Instance.Player.WeaponGameObject = base.gameObject;
		GameManager.Instance.Player.UnEquipWeapon();
		base.transform.SetParent(GameManager.Instance.Player.WeaponParent);
		base.transform.localPosition = Vector3.zero;
		base.transform.localEulerAngles = Vector3.zero;
		for (int i = 0; i < this.m_Lights.Count; i++)
		{
			this.m_Lights[i].gameObject.SetActive(true);
		}
		GameManager.Instance.Player.ScaleWeapon();
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x00009335 File Offset: 0x00007535
	protected override void OnDisposed()
	{
		this.m_Interaction.OnInteracted -= this.HandleInteractionOnInteracted;
		base.OnDisposed();
	}

	// Token: 0x04000753 RID: 1875
	[SerializeField]
	private List<Light> m_Lights;

	// Token: 0x04000754 RID: 1876
	[SerializeField]
	private Interactable m_Interaction;
}

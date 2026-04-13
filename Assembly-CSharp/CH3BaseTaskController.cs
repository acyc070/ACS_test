using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020000CB RID: 203
public class CH3BaseTaskController : BaseController
{
	// Token: 0x14000008 RID: 8
	// (add) Token: 0x060007EA RID: 2026 RVA: 0x00044CCC File Offset: 0x00042ECC
	// (remove) Token: 0x060007EB RID: 2027 RVA: 0x00044D04 File Offset: 0x00042F04
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnReady;

	// Token: 0x14000009 RID: 9
	// (add) Token: 0x060007EC RID: 2028 RVA: 0x00044D3C File Offset: 0x00042F3C
	// (remove) Token: 0x060007ED RID: 2029 RVA: 0x00044D74 File Offset: 0x00042F74
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnBegin;

	// Token: 0x1400000A RID: 10
	// (add) Token: 0x060007EE RID: 2030 RVA: 0x00044DAC File Offset: 0x00042FAC
	// (remove) Token: 0x060007EF RID: 2031 RVA: 0x00044DE4 File Offset: 0x00042FE4
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnRestart;

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x060007F0 RID: 2032 RVA: 0x00008A73 File Offset: 0x00006C73
	public BaseWeapon Weapon
	{
		get
		{
			return this.m_Weapon;
		}
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00008A7B File Offset: 0x00006C7B
	public override void Activate()
	{
		if (this.m_Weapon)
		{
			this.m_Weapon.gameObject.SetActive(true);
		}
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00008A9E File Offset: 0x00006C9E
	protected void SetWeapon(BaseWeapon weapon)
	{
		this.m_Weapon = weapon;
		if (this.m_Weapon)
		{
			this.m_Weapon.Interaction.SetActive(false);
			this.m_Weapon.gameObject.SetActive(false);
		}
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00008AD9 File Offset: 0x00006CD9
	protected void EnableWeapon()
	{
		if (this.m_Weapon)
		{
			this.m_WeaponStationController.OnOpenComplete += this.HandleOnOpenComplete;
			this.m_WeaponStationController.Open();
		}
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x00044E1C File Offset: 0x0004301C
	private void HandleOnOpenComplete(object sender, EventArgs e)
	{
		this.m_WeaponStationController.OnOpenComplete -= this.HandleOnOpenComplete;
		this.m_Weapon.OnEquipped += this.HandleWeaponOnEquipped;
		this.m_Weapon.Interaction.SetActive(true);
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x00008B0D File Offset: 0x00006D0D
	private void HandleWeaponOnEquipped(object sender, EventArgs e)
	{
		this.m_Weapon.OnEquipped -= this.HandleWeaponOnEquipped;
		this.m_WeaponStationController.Close();
		this.m_WeaponStationController.Unblock();
		this.BeginTask();
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x00002482 File Offset: 0x00000682
	protected virtual void BeginTask()
	{
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x00008B42 File Offset: 0x00006D42
	protected void ActivateDropbox()
	{
		this.m_WeaponStationController.OnTaskComplete += this.HandleTaskOnComplete;
		this.m_WeaponStationController.ActivateDropbox();
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x00008B66 File Offset: 0x00006D66
	private void HandleTaskOnComplete(object sender, EventArgs e)
	{
		this.m_WeaponStationController.OnTaskComplete -= this.HandleTaskOnComplete;
		base.SendOnComplete();
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x00008B85 File Offset: 0x00006D85
	public void SendOnBegin()
	{
		this.OnBegin.Send(this);
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x00008B93 File Offset: 0x00006D93
	public void SendOnReady()
	{
		this.OnReady.Send(this);
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x00008BA1 File Offset: 0x00006DA1
	public void SendOnRestart()
	{
		this.OnRestart.Send(this);
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x00006F06 File Offset: 0x00005106
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x0400066E RID: 1646
	[Header("<Controllers>")]
	[SerializeField]
	protected CH3WeaponStationController m_WeaponStationController;

	// Token: 0x0400066F RID: 1647
	[SerializeField]
	protected CH3BendyController m_BendyController;

	// Token: 0x04000670 RID: 1648
	[SerializeField]
	protected CH3SearcherController m_SearcherController;

	// Token: 0x04000671 RID: 1649
	[SerializeField]
	protected CH3GangsterController m_GangsterController;

	// Token: 0x04000672 RID: 1650
	[HideInInspector]
	public int ID;

	// Token: 0x04000673 RID: 1651
	protected BaseWeapon m_Weapon;
}

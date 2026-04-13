using System;
using UnityEngine;

// Token: 0x02000098 RID: 152
public class CH2RitualRoomController : BaseController
{
	// Token: 0x06000572 RID: 1394 RVA: 0x00006EE7 File Offset: 0x000050E7
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ScareTrigger.SetActive(false);
		this.m_Door.Lock();
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x00036414 File Offset: 0x00034614
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.RitualObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.m_Door.Lock();
		this.m_Plank.OnBroken += this.HandlePlankOnBroken;
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x00036470 File Offset: 0x00034670
	private void HandlePlankOnBroken(object sender, EventArgs e)
	{
		this.m_Plank.OnBroken -= this.HandlePlankOnBroken;
		this.m_Door.Unlock();
		this.m_ScareTrigger.SetActive(true);
		this.m_ScareTrigger.OnEnter += this.HandleScareTriggerOnEnter;
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x000364C4 File Offset: 0x000346C4
	private void HandleScareTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_ScareTrigger.OnEnter -= this.HandleScareTriggerOnEnter;
		this.m_ScarePlank.Destroy(this.m_ScarePlank.transform.position + Vector3.up * 0.5f);
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.RitualObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x00036550 File Offset: 0x00034750
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/CURRENT_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 0f, false, 0f));
		GameManager.Instance.Player.WeaponGameObject = this.m_Axe.gameObject;
		GameManager.Instance.Player.EquipWeapon();
		if (this.m_Axe && this.m_Axe.Interaction != null)
		{
			this.m_Axe.Interaction.SetActive(false);
		}
		this.m_Axe.KillInteraction();
		this.m_Axe.Equip();
		this.m_Axe.transform.SetParent(GameManager.Instance.Player.WeaponParent);
		this.m_Axe.transform.localPosition = Vector3.zero;
		this.m_Axe.transform.localEulerAngles = Vector3.zero;
		this.m_Plank.gameObject.SetActive(false);
		this.m_ScarePlank.gameObject.SetActive(false);
		this.m_Door.ForceOpen(145f);
		this.m_Door.Lock();
		base.SendOnComplete();
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x00006F06 File Offset: 0x00005106
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000404 RID: 1028
	[Header("Objective: Leave the room!")]
	[SerializeField]
	private Breakable m_Plank;

	// Token: 0x04000405 RID: 1029
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x04000406 RID: 1030
	[Header("Jumpscare: Plank Break")]
	[SerializeField]
	private Breakable m_ScarePlank;

	// Token: 0x04000407 RID: 1031
	[SerializeField]
	private EventTrigger m_ScareTrigger;

	// Token: 0x04000408 RID: 1032
	[Header("Weapon")]
	[SerializeField]
	private MeleeWeapon m_Axe;

	// Token: 0x04000409 RID: 1033
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;
}

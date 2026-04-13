using System;
using TMG.Core;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class CH3AccountingController : TMGMonoBehaviour
{
	// Token: 0x06000606 RID: 1542 RVA: 0x00039550 File Offset: 0x00037750
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AccountingRoom.IsComplete)
		{
			this.m_IsUnlocked = true;
			this.m_AccountingDoor.ForceOpen();
			this.m_AccountingDoor.Door.ForceOpen(140f);
			this.m_AccountingDoor.Door.Lock();
			if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.UsedAxe && GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ButcherGangTask.IsStarted)
			{
				if (this.m_HiddenAxe)
				{
					this.m_HiddenAxe.Interaction.SetActive(true);
				}
			}
			else if (this.m_HiddenAxe)
			{
				this.m_HiddenAxe.Dispose();
			}
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AccountingRoom.IsStarted)
		{
			this.m_AccountingDoor.ForceOpen();
			this.m_AccountingDoor.Door.OnInteracted += this.HandleDoorOnInteracted;
		}
		else if (this.m_HiddenAxe)
		{
			this.m_HiddenAxe.Interaction.SetActive(false);
		}
		this.m_AxeOriginPosition = this.m_HiddenAxe.transform.position;
		this.m_AxeOriginRotation = this.m_HiddenAxe.transform.eulerAngles;
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x0000768F File Offset: 0x0000588F
	public void Activate()
	{
		if (!this.m_IsUnlocked)
		{
			this.m_IsUnlocked = true;
			this.m_AccountingDoor.OnUnlocked += this.HandleAccountingDoorOnUnlocked;
		}
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x000076BA File Offset: 0x000058BA
	public void ActivateAxe()
	{
		if (this.m_HiddenAxe)
		{
			this.m_HiddenAxe.Interaction.OnInteracted += this.HandleAxeOnInteracted;
			this.m_HiddenAxe.Interaction.SetActive(true);
		}
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x000396E0 File Offset: 0x000378E0
	public void DisableAxe()
	{
		if (this.m_HiddenAxe && this.m_HiddenAxe.Interaction)
		{
			this.m_HiddenAxe.Interaction.SetActive(false);
		}
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.UsedAxe = false;
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x00039740 File Offset: 0x00037940
	private void HandleAxeOnInteracted(object sender, EventArgs e)
	{
		if (this.m_HiddenAxe)
		{
			if (this.m_HiddenAxe.Interaction)
			{
				this.m_HiddenAxe.Interaction.OnInteracted -= this.HandleAxeOnInteracted;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH3Data.UsedAxe = true;
		}
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x000397A8 File Offset: 0x000379A8
	public void Reset()
	{
		if (this.m_HiddenAxe)
		{
			this.m_HiddenAxe.Dispose();
		}
		this.m_HiddenAxe = GameManager.Instance.AssetManager.CreateAsset<MeleeWeapon>("GamePlay/Weapons/Weapon_Axe");
		this.m_HiddenAxe.transform.position = this.m_AxeOriginPosition;
		this.m_HiddenAxe.transform.eulerAngles = this.m_AxeOriginRotation;
		this.m_HiddenAxe.Interaction.SetActive(false);
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x00039828 File Offset: 0x00037A28
	private void HandleAccountingDoorOnUnlocked(object sender, EventArgs e)
	{
		this.m_AccountingDoor.OnUnlocked -= this.HandleAccountingDoorOnUnlocked;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AccountingRoom.IsStarted = true;
		this.m_AccountingDoor.Door.OnInteracted += this.HandleDoorOnInteracted;
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x00039888 File Offset: 0x00037A88
	private void HandleDoorOnInteracted(object sender, EventArgs e)
	{
		this.m_AccountingDoor.Door.OnInteracted -= this.HandleDoorOnInteracted;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AccountingRoom.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040004A8 RID: 1192
	[SerializeField]
	private MeleeWeapon m_HiddenAxe;

	// Token: 0x040004A9 RID: 1193
	[SerializeField]
	private BlockedDoorController m_AccountingDoor;

	// Token: 0x040004AA RID: 1194
	private Vector3 m_AxeOriginPosition;

	// Token: 0x040004AB RID: 1195
	private Vector3 m_AxeOriginRotation;

	// Token: 0x040004AC RID: 1196
	private bool m_IsUnlocked;
}

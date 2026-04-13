using System;
using S13Audio;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public class CH3DecisionController : BaseController
{
	// Token: 0x060006E8 RID: 1768 RVA: 0x0003F448 File Offset: 0x0003D648
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_GateCloseClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Gate_Close_01");
		this.m_SlowTrigger.SetActive(false);
		this.m_BendyTrigger.SetActive(false);
		this.m_AliceTrigger.SetActive(false);
		this.m_DecisionCompleteTrigger.SetActive(false);
		this.m_BendyGate.SetActive(false);
		this.m_AliceGate.SetActive(false);
		this.m_BendyWall.SetActive(false);
		this.m_AliceWall.SetActive(false);
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x0003F4D0 File Offset: 0x0003D6D0
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.DecisionObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.m_BendyTrigger.SetActive(true);
		this.m_BendyTrigger.OnEnter += this.HandleBendyTriggerOnEnter;
		this.m_AliceTrigger.SetActive(true);
		this.m_AliceTrigger.OnEnter += this.HandleAliceTriggerOnEnter;
		this.m_DecisionCompleteTrigger.SetActive(true);
		this.m_DecisionCompleteTrigger.OnEnter += this.HandleDecisionTriggerOnComplete;
		this.m_SlowTrigger.SetActive(true);
		this.m_SlowTrigger.OnEnter += this.HandleSlowTriggerOnEnter;
		this.m_SlowTrigger.OnExit += this.HandleSlowTriggerOnExit;
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x00008069 File Offset: 0x00006269
	private void HandleSlowTriggerOnEnter(object sender, EventArgs e)
	{
		GameManager.Instance.Player.SetSlowed(true);
		GameManager.Instance.Player.SetJump(false);
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x0000808B File Offset: 0x0000628B
	private void HandleSlowTriggerOnExit(object sender, EventArgs e)
	{
		GameManager.Instance.Player.SetSlowed(false);
		GameManager.Instance.Player.SetJump(true);
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x0003F5AC File Offset: 0x0003D7AC
	private void HandleBendyTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BendyTrigger.OnEnter -= this.HandleBendyTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_GateCloseClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ChoseDevilsPath = true;
		this.m_AliceRoom.Dispose();
		this.m_AliceGate.SetActive(true);
		this.m_AliceWall.SetActive(true);
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x0003F628 File Offset: 0x0003D828
	private void HandleAliceTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_AliceTrigger.OnEnter -= this.HandleAliceTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_GateCloseClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ChoseDevilsPath = false;
		this.m_SlowTrigger.OnEnter -= this.HandleSlowTriggerOnEnter;
		this.m_SlowTrigger.OnExit -= this.HandleSlowTriggerOnExit;
		this.m_BendyRoom.Dispose();
		this.m_BendyGate.SetActive(true);
		this.m_BendyWall.SetActive(true);
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x0003F6D0 File Offset: 0x0003D8D0
	private void HandleDecisionTriggerOnComplete(object sender, EventArgs e)
	{
		this.m_DecisionCompleteTrigger.OnEnter -= this.HandleDecisionTriggerOnComplete;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.DecisionObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x0003F72C File Offset: 0x0003D92C
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH3_save_point_05", 0f);
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ChoseDevilsPath)
		{
			this.m_AliceRoom.Dispose();
			this.m_AliceGate.SetActive(true);
			this.m_AliceDoor.ForceOpen(145f);
			this.m_AliceWall.SetActive(true);
			this.m_SlowTrigger.SetActive(true);
			this.m_SlowTrigger.OnEnter += this.HandleSlowTriggerOnEnter;
			this.m_SlowTrigger.OnExit += this.HandleSlowTriggerOnExit;
		}
		else
		{
			this.m_BendyRoom.Dispose();
			this.m_BendyGate.SetActive(true);
			this.m_BendyDoor.ForceOpen(-145f);
			this.m_BendyWall.SetActive(true);
		}
		base.SendOnComplete();
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x0003F818 File Offset: 0x0003DA18
	protected override void OnDisposed()
	{
		if (this.m_BendyTrigger)
		{
			this.m_BendyTrigger.OnEnter -= this.HandleBendyTriggerOnEnter;
		}
		if (this.m_AliceTrigger)
		{
			this.m_AliceTrigger.OnEnter -= this.HandleAliceTriggerOnEnter;
		}
		if (this.m_DecisionCompleteTrigger)
		{
			this.m_DecisionCompleteTrigger.OnEnter -= this.HandleDecisionTriggerOnComplete;
		}
		if (this.m_SlowTrigger)
		{
			this.m_SlowTrigger.OnEnter -= this.HandleSlowTriggerOnEnter;
		}
		if (this.m_SlowTrigger)
		{
			this.m_SlowTrigger.OnExit -= this.HandleSlowTriggerOnExit;
		}
		this.m_GateCloseClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000592 RID: 1426
	[Header("Choose Bendy!")]
	[SerializeField]
	private EventTrigger m_BendyTrigger;

	// Token: 0x04000593 RID: 1427
	[SerializeField]
	private EventTrigger m_SlowTrigger;

	// Token: 0x04000594 RID: 1428
	[SerializeField]
	private DisposableObject m_AliceRoom;

	// Token: 0x04000595 RID: 1429
	[SerializeField]
	private BaseDoorController m_AliceDoor;

	// Token: 0x04000596 RID: 1430
	[SerializeField]
	private GameObject m_AliceGate;

	// Token: 0x04000597 RID: 1431
	[SerializeField]
	private GameObject m_AliceWall;

	// Token: 0x04000598 RID: 1432
	[Header("Choose Alice!")]
	[SerializeField]
	private EventTrigger m_AliceTrigger;

	// Token: 0x04000599 RID: 1433
	[SerializeField]
	private DisposableObject m_BendyRoom;

	// Token: 0x0400059A RID: 1434
	[SerializeField]
	private BaseDoorController m_BendyDoor;

	// Token: 0x0400059B RID: 1435
	[SerializeField]
	private GameObject m_BendyGate;

	// Token: 0x0400059C RID: 1436
	[SerializeField]
	private GameObject m_BendyWall;

	// Token: 0x0400059D RID: 1437
	[Header("Chosen!")]
	[SerializeField]
	private EventTrigger m_DecisionCompleteTrigger;

	// Token: 0x0400059E RID: 1438
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x0400059F RID: 1439
	private AudioClip m_GateCloseClip;
}

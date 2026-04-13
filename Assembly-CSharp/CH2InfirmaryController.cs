using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
public class CH2InfirmaryController : BaseController
{
	// Token: 0x060004E5 RID: 1253 RVA: 0x0000686A File Offset: 0x00004A6A
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_HenryClip11 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_11");
		this.m_ValveEventTrigger.SetActive(false);
		this.m_Lever.Disable();
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x0003340C File Offset: 0x0003160C
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InfirmaryObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.m_Blocker.SetActive(false);
		this.m_ValveEventTrigger.OnEnter += this.HandleValveTriggerOnEnter;
		this.m_ValveEventTrigger.SetActive(true);
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00033474 File Offset: 0x00031674
	private void HandleValveTriggerOnEnter(object sender, EventArgs e)
	{
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip11, "DIACH2/DIA_CH2_HENRY_11", false));
		this.m_Valve.SetEmptyCollision(false);
		this.m_Valve.ActivateEmpty();
		this.m_Lever.OnComplete += this.HandleLeverOnComplete;
		this.m_Lever.Activate(false);
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x000334D8 File Offset: 0x000316D8
	private void HandleLeverOnComplete(object sender, EventArgs e)
	{
		this.m_Lever.OnComplete -= this.HandleLeverOnComplete;
		this.m_GateDoor.Open();
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InfirmaryObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00033540 File Offset: 0x00031740
	private void ForceComplete()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SewersObjective.IsComplete)
		{
			this.m_Valve.ForceComplete();
		}
		else
		{
			this.m_Valve.SetEmptyCollision(false);
			this.m_Valve.ActivateEmpty();
		}
		this.m_Blocker.SetActive(false);
		this.m_GateDoor.ForceOpen();
		this.m_Lever.ForceComplete();
		base.SendOnComplete();
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x000335C0 File Offset: 0x000317C0
	protected override void OnDisposed()
	{
		if (this.m_Lever)
		{
			this.m_Lever.OnComplete -= this.HandleLeverOnComplete;
		}
		if (this.m_ValveEventTrigger)
		{
			this.m_ValveEventTrigger.OnEnter -= this.HandleValveTriggerOnEnter;
		}
		this.m_HenryClip11 = null;
		base.OnDisposed();
	}

	// Token: 0x0400036C RID: 876
	[Header("Objective: Go To The Sewers")]
	[SerializeField]
	private CH1PipeValve m_Valve;

	// Token: 0x0400036D RID: 877
	[SerializeField]
	private EventTrigger m_ValveEventTrigger;

	// Token: 0x0400036E RID: 878
	[SerializeField]
	private CH3LeverLight m_Lever;

	// Token: 0x0400036F RID: 879
	[SerializeField]
	private GenericDoorController m_GateDoor;

	// Token: 0x04000370 RID: 880
	[SerializeField]
	private GameObject m_Blocker;

	// Token: 0x04000371 RID: 881
	[SerializeField]
	private GameObject m_SammyDoorBlockage;

	// Token: 0x04000372 RID: 882
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000373 RID: 883
	private AudioClip m_HenryClip11;
}

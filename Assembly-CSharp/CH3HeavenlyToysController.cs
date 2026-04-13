using System;
using S13Audio;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class CH3HeavenlyToysController : BaseController
{
	// Token: 0x060006FB RID: 1787 RVA: 0x0003FB08 File Offset: 0x0003DD08
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_EntranceMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_formerglory");
		this.m_HummingClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Alice/ch3_alice_01_lobbyhumming");
		this.m_PowerLeverClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Mainr_Power_Lever_Turn_On_01");
		this.m_Henry13Clip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_13_wowidontrememberanyofthis");
		this.m_HenryBlockingTheWayClip = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Henry/BlockingTheWay/");
		this.m_EntranceTrigger.SetActive(false);
		this.m_EntranceDialogueTrigger.SetActive(false);
		this.m_BlockageEventTrigger.SetActive(false);
		this.m_ToyMachineLever.SetActive(false);
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0003FBB4 File Offset: 0x0003DDB4
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HeavenlyToysObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HeavenlyToysObjective.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0003FC24 File Offset: 0x0003DE24
	private void InternalActivate()
	{
		this.m_BlockedDoor.Lock();
		this.m_BlockageEventTrigger.OnEnter += this.HandleBlockageTriggerOnEnter;
		this.m_BlockageEventTrigger.SetActive(true);
		this.m_EntranceTrigger.OnEnter += this.HandleEntranceMusicOnEnter;
		this.m_EntranceTrigger.SetActive(true);
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0003FC84 File Offset: 0x0003DE84
	private void ForceStart()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH3_save_point_03", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_10", "OBJECTIVES/CH3_OBJECTIVE_10_TIP", 0f, false, 0f));
		this.m_BlockedDoor.Lock();
		this.m_ToyMachineLever.OnInteracted += this.HandleToyMachineLeverOnInteracted;
		this.m_ToyMachineLever.OnComplete += this.HandleToyMachineLeverOnComplete;
		this.m_ToyMachineLever.SetActive(true);
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0003FD14 File Offset: 0x0003DF14
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH3_save_point_03", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_12", string.Empty, 0f, false, 0f));
		this.m_ToyMachineLever.ForceOpen();
		this.m_LightFixture.TurnOn();
		this.m_ToyMachine.Activate(true);
		this.m_BlockedDoor.Unlock();
		base.SendOnComplete();
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0003FD94 File Offset: 0x0003DF94
	private void HandleEntranceMusicOnEnter(object sender, EventArgs e)
	{
		this.m_EntranceTrigger.OnEnter -= this.HandleEntranceMusicOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_EntranceMusicClip, AudioObjectType.MUSIC, 0, false).OnComplete += delegate(object _sender, EventArgs _e)
		{
			GameManager.Instance.AudioManager.Play(this.m_HummingClip, AudioObjectType.SOUND_EFFECT, 0, false);
		};
		this.m_EntranceDialogueTrigger.OnEnter += this.HandleEntranceDialogueOnEnter;
		this.m_EntranceDialogueTrigger.SetActive(true);
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x00008121 File Offset: 0x00006321
	private void HandleEntranceDialogueOnEnter(object sender, EventArgs e)
	{
		this.m_EntranceDialogueTrigger.OnEnter -= this.HandleEntranceDialogueOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_Henry13Clip, "DIACH3/DIA_CH3_HENRY_13", false));
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0003FE04 File Offset: 0x0003E004
	private void HandleBlockageTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BlockageEventTrigger.OnEnter -= this.HandleBlockageTriggerOnEnter;
		for (int i = 0; i < this.m_HenryBlockingTheWayClip.Length; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryBlockingTheWayClip[i], SubtitleConstants.DIA_CH3_HENRY_BLOCKING_THE_WAY[i], false));
			if (i >= this.m_HenryBlockingTheWayClip.Length - 1)
			{
				audioObject.OnComplete += this.HandleBlockingTheWayOnComplete;
			}
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0003FE84 File Offset: 0x0003E084
	private void HandleBlockingTheWayOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_10", "OBJECTIVES/CH3_OBJECTIVE_10_TIP", 4f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HeavenlyToysObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_ToyMachineLever.OnInteracted += this.HandleToyMachineLeverOnInteracted;
		this.m_ToyMachineLever.OnComplete += this.HandleToyMachineLeverOnComplete;
		this.m_ToyMachineLever.SetActive(true);
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x00008156 File Offset: 0x00006356
	private void HandleToyMachineLeverOnInteracted(object sender, EventArgs e)
	{
		this.m_ToyMachineLever.OnInteracted -= this.HandleToyMachineLeverOnInteracted;
		this.m_ToyMachineLever.SetActive(false);
		GameManager.Instance.AudioManager.Play(this.m_PowerLeverClip, AudioObjectType.SOUND_EFFECT, 0, false);
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0003FF24 File Offset: 0x0003E124
	private void HandleToyMachineLeverOnComplete(object sender, EventArgs e)
	{
		this.m_ToyMachineLever.OnComplete -= this.HandleToyMachineLeverOnComplete;
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_11", "OBJECTIVES/CH3_OBJECTIVE_11_TIP", 4f, false, 0f));
		this.m_LightFixture.TurnOn();
		this.m_ToyMachine.OnComplete += this.HandleToyMachineOnComplete;
		this.m_ToyMachine.Activate(false);
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x0003FFA0 File Offset: 0x0003E1A0
	private void HandleToyMachineOnComplete(object sender, EventArgs e)
	{
		this.m_ToyMachine.OnComplete -= this.HandleToyMachineOnComplete;
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_12", string.Empty, 4f, false, 0f));
		this.m_BlockedDoor.Unlock();
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HeavenlyToysObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x00040030 File Offset: 0x0003E230
	protected override void OnDisposed()
	{
		if (this.m_BlockageEventTrigger)
		{
			this.m_BlockageEventTrigger.OnEnter -= this.HandleBlockageTriggerOnEnter;
		}
		if (this.m_ToyMachineLever)
		{
			this.m_ToyMachineLever.OnInteracted -= this.HandleToyMachineLeverOnInteracted;
		}
		if (this.m_ToyMachineLever)
		{
			this.m_ToyMachineLever.OnComplete -= this.HandleToyMachineLeverOnComplete;
		}
		if (this.m_ToyMachine)
		{
			this.m_ToyMachine.OnComplete -= this.HandleToyMachineOnComplete;
		}
		this.m_EntranceMusicClip = null;
		this.m_HummingClip = null;
		this.m_PowerLeverClip = null;
		this.m_Henry13Clip = null;
		this.m_HenryBlockingTheWayClip = null;
		base.OnDisposed();
	}

	// Token: 0x040005AB RID: 1451
	[Header("Entrance!")]
	[SerializeField]
	private EventTrigger m_EntranceTrigger;

	// Token: 0x040005AC RID: 1452
	[SerializeField]
	private EventTrigger m_EntranceDialogueTrigger;

	// Token: 0x040005AD RID: 1453
	[Header("Objective: Clear Blockage!")]
	[SerializeField]
	private CH3ToyMachine m_ToyMachine;

	// Token: 0x040005AE RID: 1454
	[SerializeField]
	private InteractablePowerLever m_ToyMachineLever;

	// Token: 0x040005AF RID: 1455
	[SerializeField]
	private LightFixtureController m_LightFixture;

	// Token: 0x040005B0 RID: 1456
	[SerializeField]
	private BaseDoorController m_BlockedDoor;

	// Token: 0x040005B1 RID: 1457
	[SerializeField]
	private EventTrigger m_BlockageEventTrigger;

	// Token: 0x040005B2 RID: 1458
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x040005B3 RID: 1459
	private AudioClip m_EntranceMusicClip;

	// Token: 0x040005B4 RID: 1460
	private AudioClip m_HummingClip;

	// Token: 0x040005B5 RID: 1461
	private AudioClip m_PowerLeverClip;

	// Token: 0x040005B6 RID: 1462
	private AudioClip m_Henry13Clip;

	// Token: 0x040005B7 RID: 1463
	private AudioClip[] m_HenryBlockingTheWayClip;
}

using System;
using S13Audio;
using UnityEngine;

// Token: 0x02000088 RID: 136
public class CH2LostKeysController : BaseController
{
	// Token: 0x17000050 RID: 80
	// (get) Token: 0x060004EC RID: 1260 RVA: 0x0000689E File Offset: 0x00004A9E
	public Sprite KeySprite
	{
		get
		{
			return this.m_KeySprite;
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x000068A6 File Offset: 0x00004AA6
	public override void InitOnComplete()
	{
		this.m_KeyClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Keys_Pickup_01");
		this.m_Keys.SetActive(false);
		this.m_ClosetDoor.Lock();
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00033628 File Offset: 0x00031828
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.LostKeysObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.LostKeysObjective.IsStarted)
		{
			ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_UNLOCK_CLOSET", "OBJECTIVES/CH2_OBJECTIVE_UNLOCK_CLOSET_TIP", 0f, false, 0f);
			objectiveDataVO.AddItemCounter(this.m_KeySprite, 0);
			GameManager.Instance.UpdateObjective(objectiveDataVO);
			this.m_AudioLogController.Activate();
			this.m_Keys.OnInteracted += this.HandleKeysOnCollected;
			this.m_Keys.SetActive(true);
		}
		else
		{
			this.m_AudioLogController.OnLostKeyObjective += this.HandleLostKeysObjectiveOnActive;
			this.m_AudioLogController.Activate();
		}
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x00033710 File Offset: 0x00031910
	private void HandleLostKeysObjectiveOnActive(object sender, EventArgs e)
	{
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.LostKeysObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_Keys.OnInteracted += this.HandleKeysOnCollected;
		this.m_Keys.SetActive(true);
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x00033770 File Offset: 0x00031970
	private void HandleKeysOnCollected(object sender, EventArgs e)
	{
		this.m_Keys.OnInteracted -= this.HandleKeysOnCollected;
		this.m_Keys.Dispose();
		GameManager.Instance.ShowCollectable(CollectableDataVO.Create(this.m_KeyClip, "UI/ChapterOneCollectables/ChapterOneCollectables", "collectable_keys"));
		this.m_ClosetDoor.Unlock();
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.LostKeysObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x00033800 File Offset: 0x00031A00
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH2_save_point_05", 0f);
		ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_UNLOCK_CLOSET", "OBJECTIVES/CH2_OBJECTIVE_UNLOCK_CLOSET_TIP", 0f, false, 0f);
		objectiveDataVO.AddItemCounter(this.m_KeySprite, 1);
		GameManager.Instance.UpdateObjective(objectiveDataVO);
		this.m_AudioLogController.Activate();
		this.m_Keys.Dispose();
		this.m_ClosetDoor.Unlock();
		base.SendOnComplete();
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x000068D4 File Offset: 0x00004AD4
	protected override void OnDisposed()
	{
		if (this.m_Keys)
		{
			this.m_Keys.OnInteracted -= this.HandleKeysOnCollected;
		}
		this.m_KeyClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000374 RID: 884
	[Header("<Controllers>")]
	[SerializeField]
	private CH2AudioLogsController m_AudioLogController;

	// Token: 0x04000375 RID: 885
	[Header("Objective: Find The Keys")]
	[SerializeField]
	private Interactable m_Keys;

	// Token: 0x04000376 RID: 886
	[SerializeField]
	private BaseDoorController m_ClosetDoor;

	// Token: 0x04000377 RID: 887
	[SerializeField]
	private Sprite m_KeySprite;

	// Token: 0x04000378 RID: 888
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000379 RID: 889
	private AudioClip m_KeyClip;
}

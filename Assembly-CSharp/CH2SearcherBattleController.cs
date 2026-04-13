using System;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class CH2SearcherBattleController : BaseController
{
	// Token: 0x060005D6 RID: 1494 RVA: 0x00038570 File Offset: 0x00036770
	public override void InitOnComplete()
	{
		this.m_SammyBalcony.SetActive(false);
		this.m_FinaleTrigger.SetActive(false);
		this.m_ExitTrigger.SetActive(false);
		for (int i = 0; i < this.m_Searchers.Count; i++)
		{
			SearcherAi searcherAi = this.m_Searchers[i];
			searcherAi.gameObject.SetActive(false);
		}
		this.m_SearcherMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_The_Searchers");
		this.m_SearcherMusicStartClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_SearcherStartCue01");
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00038600 File Offset: 0x00036800
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InfirmaryObjective.IsStarted)
		{
			this.ForceComplete();
			return;
		}
		this.m_Door.Close(0f, Ease.Linear);
		this.m_Door.Lock();
		this.m_SammyBalcony.SetActive(true);
		this.m_FinaleTrigger.OnEnter += this.HandleFinaleTriggerOnEnter;
		this.m_FinaleTrigger.SetActive(true);
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00038684 File Offset: 0x00036884
	private void HandleFinaleTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_FinaleTrigger.OnEnter -= this.HandleFinaleTriggerOnEnter;
		GameManager.Instance.CurrentChapter.DeathController.OnSpawned += this.HandlePlayerOnSpawned;
		for (int i = 0; i < this.m_Searchers.Count; i++)
		{
			SearcherAi searcherAi = this.m_Searchers[i];
			searcherAi.OnRespawn += this.HandleSearcherOnRespawn;
			searcherAi.gameObject.SetActive(true);
		}
		AudioObject audioObject = GameManager.Instance.AudioManager.Play(this.m_SearcherMusicStartClip, AudioObjectType.MUSIC, 0, false);
		audioObject.OnComplete += delegate(object _sender, EventArgs _e)
		{
			this.m_SearcherMusic = GameManager.Instance.AudioManager.Play(this.m_SearcherMusicClip, AudioObjectType.MUSIC, -1, false);
		};
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x0003873C File Offset: 0x0003693C
	private void HandlePlayerOnSpawned(object sender, EventArgs e)
	{
		GameManager.Instance.CurrentChapter.DeathController.OnSpawned -= this.HandlePlayerOnSpawned;
		this.ClearSearcherMusic();
		this.m_Door.ForceOpen(145f);
		this.m_Door.Lock();
		this.m_SammyBalcony.SetActive(false);
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SanctuaryObjective.IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InfirmaryObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x000387EC File Offset: 0x000369EC
	private void HandleSearcherOnRespawn(object sender, EventArgs e)
	{
		SearcherAi searcherAi = (SearcherAi)sender;
		if (this.m_Searchers.Contains(searcherAi))
		{
			this.m_Searchers.Remove(searcherAi);
		}
		if (this.m_Searchers.Count <= 0)
		{
			this.m_PostFightSearchers.SetActive(true);
			this.OpenDoor();
		}
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x0000741B File Offset: 0x0000561B
	public void OpenDoor()
	{
		this.ClearSearcherMusic();
		this.m_Door.Unlock();
		this.m_ExitTrigger.OnEnter += this.HandleExitTriggerOnEnter;
		this.m_ExitTrigger.SetActive(true);
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x00038844 File Offset: 0x00036A44
	private void HandleExitTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_ExitTrigger.OnEnter -= this.HandleExitTriggerOnEnter;
		this.m_SammyBalcony.SetActive(false);
		GameManager.Instance.CurrentChapter.DeathController.OnSpawned -= this.HandlePlayerOnSpawned;
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SanctuaryObjective.IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InfirmaryObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x00007451 File Offset: 0x00005651
	private void ClearSearcherMusic()
	{
		if (this.m_SearcherMusic != null)
		{
			this.m_SearcherMusic.AudioSource.DOFade(0f, 5f).OnComplete(delegate
			{
				if (this.m_SearcherMusic != null)
				{
					this.m_SearcherMusic.Clear();
					this.m_SearcherMusic = null;
				}
			});
		}
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x000388EC File Offset: 0x00036AEC
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH2_save_point_08", 0f);
		this.m_SammyBalcony.SetActive(false);
		this.m_Door.ForceOpen(-145f);
		this.m_Door.Lock();
		base.SendOnComplete();
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x0003893C File Offset: 0x00036B3C
	protected override void OnDisposed()
	{
		if (GameManager.Instance.Player)
		{
			GameManager.Instance.CurrentChapter.DeathController.OnSpawned -= this.HandlePlayerOnSpawned;
		}
		this.ClearSearcherMusic();
		this.m_SearcherMusicClip = null;
		this.m_SearcherMusicStartClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000468 RID: 1128
	[Header("Objective: Defeat The Searchers")]
	[SerializeField]
	private GameObject m_SammyBalcony;

	// Token: 0x04000469 RID: 1129
	[SerializeField]
	private GameObject m_PostFightSearchers;

	// Token: 0x0400046A RID: 1130
	[SerializeField]
	private List<SearcherAi> m_Searchers;

	// Token: 0x0400046B RID: 1131
	[SerializeField]
	private EventTrigger m_FinaleTrigger;

	// Token: 0x0400046C RID: 1132
	[SerializeField]
	private EventTrigger m_ExitTrigger;

	// Token: 0x0400046D RID: 1133
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x0400046E RID: 1134
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x0400046F RID: 1135
	private AudioObject m_SearcherMusic;

	// Token: 0x04000470 RID: 1136
	private AudioClip m_SearcherMusicClip;

	// Token: 0x04000471 RID: 1137
	private AudioClip m_SearcherMusicStartClip;
}

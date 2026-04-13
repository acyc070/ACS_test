using System;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x02000090 RID: 144
public class CH2MusicDepartmentController : BaseController
{
	// Token: 0x06000520 RID: 1312 RVA: 0x00006ACB File Offset: 0x00004CCB
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_SearchersMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_The_Searchers");
		this.m_SearcherScareClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_SearcherStartCue01");
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x00034B50 File Offset: 0x00032D50
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicDepartmentObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.m_SearcherSpawnTrigger.OnEnter += this.HandleSearcherEventTriggerOnEnter;
		this.m_SearcherSpawnTrigger.SetActive(true);
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x00034BAC File Offset: 0x00032DAC
	private void HandleSearcherEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_SearcherSpawnTrigger.OnEnter -= this.HandleSearcherEventTriggerOnEnter;
		if (this.m_InitialSearcher)
		{
			this.m_InitialSearcher.OnActivate += this.HandleInitialSearcherOnActivate;
			this.m_InitialSearcher.OnRespawn += this.HandleInitialSearcherOnDeath;
			Sequence sequence = DOTween.Sequence();
			S13AudioManager.Instance.InvokeEvent("evt_ch2_dept_ink_blob_fall", 0f);
			sequence.Insert(0f, this.m_SearcherInkBlob.DOLocalMoveY(-15f, 1f, false).SetEase(Ease.InQuad).OnComplete(delegate
			{
				if (this.m_InitialSearcher)
				{
					this.m_InkExplosion.ExplodeOnly();
					this.m_InitialSearcher.gameObject.SetActive(true);
					S13AudioManager.Instance.InvokeEvent("evt_ch2_dept_ink_blob_land", 0f);
				}
			}));
		}
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00034C64 File Offset: 0x00032E64
	private void HandleInitialSearcherOnActivate(object sender, EventArgs e)
	{
		this.m_InitialSearcher.OnActivate -= this.HandleInitialSearcherOnActivate;
		this.m_InkExplosion.ExplodeOnly();
		GameManager.Instance.AudioManager.Play(this.m_SearcherScareClip, AudioObjectType.MUSIC, 0, false);
		this.m_SearchersMusicObject = GameManager.Instance.AudioManager.Play(this.m_SearchersMusicClip, AudioObjectType.MUSIC, -1, false);
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x00034CCC File Offset: 0x00032ECC
	private void HandleInitialSearcherOnDeath(object sender, EventArgs e)
	{
		this.m_InitialSearcher.OnDeath -= this.HandleInitialSearcherOnDeath;
		this.m_RandomSearchers.SetActive(true);
		for (int i = 0; i < this.m_MusicDeptSearchers.Count; i++)
		{
			SearcherAi searcherAi = this.m_MusicDeptSearchers[i];
			searcherAi.OnRespawn += this.HandleSearcherOnDeath;
			searcherAi.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x00034D44 File Offset: 0x00032F44
	private void HandleSearcherOnDeath(object sender, EventArgs e)
	{
		SearcherAi searcherAi = (SearcherAi)sender;
		searcherAi.OnDeath -= this.HandleSearcherOnDeath;
		if (this.m_MusicDeptSearchers.Contains(searcherAi))
		{
			this.m_MusicDeptSearchers.Remove(searcherAi);
		}
		if (this.m_MusicDeptSearchers.Count <= 0)
		{
			this.OpenDepartment();
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x00034DA0 File Offset: 0x00032FA0
	private void OpenDepartment()
	{
		if (this.m_SearchersMusicObject != null)
		{
			this.m_SearchersMusicObject.AudioSource.DOFade(0f, 1.5f).OnComplete(new TweenCallback(this.ClearSearcherMusic));
		}
		this.m_RecordingStudioDoor.Unlock();
		this.m_PoolRoomDoor.Unlock();
		this.m_GateDoor.Open();
		this.m_MusicController.Activate();
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicDepartmentObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x00006AFD File Offset: 0x00004CFD
	private void ClearSearcherMusic()
	{
		if (this.m_SearchersMusicObject != null)
		{
			this.m_SearchersMusicObject.Clear();
			this.m_SearchersMusicObject = null;
		}
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x00034E4C File Offset: 0x0003304C
	private void ForceComplete()
	{
		this.m_GateDoor.ForceOpen();
		this.m_RandomSearchers.SetActive(true);
		this.m_RecordingStudioDoor.Unlock();
		this.m_PoolRoomDoor.Unlock();
		if (this.m_InitialSearcher)
		{
			this.m_InitialSearcher.Dispose();
		}
		base.SendOnComplete();
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00006B22 File Offset: 0x00004D22
	protected override void OnDisposed()
	{
		this.ClearSearcherMusic();
		this.m_SearchersMusicObject = null;
		this.m_SearchersMusicClip = null;
		this.m_SearcherScareClip = null;
		base.OnDisposed();
	}

	// Token: 0x040003AE RID: 942
	[Header("<Controllers>")]
	[SerializeField]
	private CH2MusicController m_MusicController;

	// Token: 0x040003AF RID: 943
	[Header("Searcher Spawn Trigger")]
	[SerializeField]
	private EventTrigger m_SearcherSpawnTrigger;

	// Token: 0x040003B0 RID: 944
	[SerializeField]
	private InkExplosionEffect m_InkExplosion;

	// Token: 0x040003B1 RID: 945
	[Header("Searcher Spawners")]
	[SerializeField]
	private Transform m_SearcherInkBlob;

	// Token: 0x040003B2 RID: 946
	[SerializeField]
	private SearcherAi m_InitialSearcher;

	// Token: 0x040003B3 RID: 947
	[SerializeField]
	private List<SearcherAi> m_MusicDeptSearchers;

	// Token: 0x040003B4 RID: 948
	[Header("Randoms")]
	[SerializeField]
	private GameObject m_RandomSearchers;

	// Token: 0x040003B5 RID: 949
	[Header("Doors")]
	[SerializeField]
	private GenericDoorController m_GateDoor;

	// Token: 0x040003B6 RID: 950
	[SerializeField]
	private BaseDoorController m_RecordingStudioDoor;

	// Token: 0x040003B7 RID: 951
	[SerializeField]
	private BaseDoorController m_PoolRoomDoor;

	// Token: 0x040003B8 RID: 952
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x040003B9 RID: 953
	private AudioObject m_SearchersMusicObject;

	// Token: 0x040003BA RID: 954
	private AudioClip m_SearchersMusicClip;

	// Token: 0x040003BB RID: 955
	private AudioClip m_SearcherScareClip;
}

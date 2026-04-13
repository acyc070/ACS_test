using System;
using System.Collections;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000CC RID: 204
public class CH3ButcherGangTaskController : CH3BaseTaskController
{
	// Token: 0x060007FE RID: 2046 RVA: 0x00044E68 File Offset: 0x00043068
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_BeginTaskClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/TaskButcherGangStart/");
		this.m_MusicSlow = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_theoldgangslow");
		this.m_MusicFast = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_theoldgangfaster");
		this.m_MusicEnd = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_theoldgangending");
		this.m_ButcherGangBreakInClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_theyrebreakingin");
		this.m_ReturnClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Alice/ch3_alice_spawnreturn");
		this.m_AliceMissionEndClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Alice/ch3_alice_68_enemymissionendA");
		IEnumerator enumerator = this.m_SearcherSpawnerParent.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				CH3ButcherGangTaskController.SpawnPoint spawnPoint = new CH3ButcherGangTaskController.SpawnPoint();
				spawnPoint.Spawner = transform;
				this.m_SearcherSpawners.Add(spawnPoint);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
		this.m_EndMissionEventTrigger.SetActive(false);
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00044F78 File Offset: 0x00043178
	public override void Activate()
	{
		base.Activate();
		this.m_AccountingDoor.Activate();
		this.m_AccountingDoor.ActivateAxe();
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HeartTask.Status.IsStarted)
		{
			this.GoToNextController();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ButcherGangTask.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.InternalActivate();
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x00008BDF File Offset: 0x00006DDF
	private void GoToNextController()
	{
		base.SendOnComplete();
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x00044FFC File Offset: 0x000431FC
	private void InternalActivate()
	{
		this.m_StairwellController.CloseAllFloors();
		this.m_LiftController.DisableLift();
		this.m_BendyController.SetActive(false);
		this.m_SearcherController.SetActive(false);
		this.m_GangsterController.SetActive(false);
		this.ActivateSearchers();
		for (int i = 0; i < this.m_BeginTaskClips.Length; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_BeginTaskClips[i], SubtitleConstants.DIA_CH3_ALICE_TASK_BUTCHER_GANG_START[i], true));
			if (i == 1)
			{
				audioObject.OnComplete += this.HandleBeginDialogueMiddleOnComplete;
			}
			else if (i >= this.m_BeginTaskClips.Length - 1)
			{
				audioObject.OnComplete += this.HandleBeginDialogueOnComplete;
			}
		}
		this.m_MusicAudio = GameManager.Instance.AudioManager.Play(this.m_MusicSlow, AudioObjectType.MUSIC, -1, false);
		this.m_MusicAudio.AudioSource.volume = 0f;
		this.m_MusicAudio.AudioSource.DOFade(1f, 30f);
		GameManager.Instance.CurrentChapter.DeathController.OnSpawned += this.HandlePlayerOnSpawned;
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ButcherGangTask.IsStarted)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ButcherGangTask.IsStarted = true;
			GameManager.Instance.GameDataManager.Save(false, true);
		}
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x00045174 File Offset: 0x00043374
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_RETURN_TO_THE_ANGEL", string.Empty, 0f, false, 0f));
		this.m_BendyController.SetActive(true);
		this.m_SearcherController.SetActive(true);
		this.m_GangsterController.SetActive(true);
		this.m_StairwellController.OpenAllFloors();
		this.m_LiftController.EnableLift();
		this.m_EndMissionEventTrigger.OnEnter += this.HandleEndMissionEventTriggerOnEnter;
		this.m_EndMissionEventTrigger.SetActive(true);
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x00045208 File Offset: 0x00043408
	private void HandleEndMissionEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_EndMissionEventTrigger.OnEnter -= this.HandleEndMissionEventTriggerOnEnter;
		if (GameManager.Instance.Player.InactiveWeapon)
		{
			global::UnityEngine.Object.Destroy(GameManager.Instance.Player.InactiveWeapon);
			GameManager.Instance.Player.InactiveWeapon = null;
		}
		base.SendOnComplete();
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x00008BE7 File Offset: 0x00006DE7
	private void HandleBeginDialogueMiddleOnComplete(object sender, EventArgs e)
	{
		this.m_ButchGangAudio = GameManager.Instance.AudioManager.Play(this.m_ButcherGangBreakInClip, AudioObjectType.SOUND_EFFECT, -1, false);
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x00008C07 File Offset: 0x00006E07
	private void HandleBeginDialogueOnComplete(object sender, EventArgs e)
	{
		this.ActivateButcherGang();
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_TASK_KILL_START", "OBJECTIVES/CH3_OBJECTIVE_TASK_KILL_START_TIP", 4f, false, 0f));
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x0004526C File Offset: 0x0004346C
	private void ActivateSearchers()
	{
		for (int i = 0; i < this.m_SearcherSpawners.Count; i++)
		{
			CH3ButcherGangTaskController.SpawnPoint spawnPoint = this.m_SearcherSpawners[i];
			spawnPoint.Ai = null;
			spawnPoint.isInUse = false;
		}
		base.StartCoroutine(this.SpawnSearchers(7, null));
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x00008C38 File Offset: 0x00006E38
	private IEnumerator SpawnSearchers(int count, CH3ButcherGangTaskController.SpawnPoint ignoreSpawner = null)
	{
		if (base.IsDisposed)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < count; i = num + 1)
		{
			yield return new WaitForSeconds(1f);
			yield return new WaitForEndOfFrame();
			if (base.IsDisposed || this.m_Searchers == null)
			{
				yield return null;
			}
			BaseAiController baseAiController = GameManager.Instance.AssetManager.CreateAsset<BaseAiController>("GamePlay/Characters/Ai_Searcher");
			this.m_SearcherSpawners.Shuffle<CH3ButcherGangTaskController.SpawnPoint>();
			for (int j = 0; j < this.m_SearcherSpawners.Count; j++)
			{
				CH3ButcherGangTaskController.SpawnPoint spawnPoint = this.m_SearcherSpawners[j];
				if (!spawnPoint.isInUse && !spawnPoint.Equals(ignoreSpawner))
				{
					spawnPoint.Ai = baseAiController;
					spawnPoint.isInUse = true;
					baseAiController.transform.position = spawnPoint.Spawner.position;
					baseAiController.OnRespawn += this.HandleSearcherOnRespawn;
					break;
				}
			}
			this.m_Searchers.Add(baseAiController);
			num = i;
		}
		yield break;
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x000452B8 File Offset: 0x000434B8
	private void HandleSearcherOnRespawn(object sender, EventArgs e)
	{
		BaseAiController baseAiController = (BaseAiController)sender;
		baseAiController.OnRespawn -= this.HandleSearcherOnRespawn;
		if (this.m_IsCompleted)
		{
			return;
		}
		if (this.m_Searchers.Contains(baseAiController))
		{
			this.m_Searchers.Remove(baseAiController);
		}
		this.m_SearcherSpawners.Shuffle<CH3ButcherGangTaskController.SpawnPoint>();
		foreach (CH3ButcherGangTaskController.SpawnPoint spawnPoint in this.m_SearcherSpawners)
		{
			if (spawnPoint.Ai != null && spawnPoint.Ai.Equals(baseAiController))
			{
				spawnPoint.Ai = null;
				spawnPoint.isInUse = false;
				base.StartCoroutine(this.SpawnSearchers(1, spawnPoint));
				break;
			}
		}
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x00045388 File Offset: 0x00043588
	private void ActivateButcherGang()
	{
		for (int i = 0; i < this.m_Gangsters.Count; i++)
		{
			ButcherGangAi butcherGangAi = this.m_Gangsters[i];
			if (butcherGangAi)
			{
				butcherGangAi.Dispose();
			}
		}
		this.m_Gangsters.Clear();
		base.StartCoroutine(this.SpawnButcherGang("GamePlay/Characters/Ai_Striker", this.m_GangsterSpawners[0], 0f));
		base.StartCoroutine(this.SpawnButcherGang("GamePlay/Characters/Ai_Piper", this.m_GangsterSpawners[1], 4f));
		base.StartCoroutine(this.SpawnButcherGang("GamePlay/Characters/Ai_Fisher", this.m_GangsterSpawners[2], 8f));
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x00008C55 File Offset: 0x00006E55
	private IEnumerator SpawnButcherGang(string prefab, Transform spawnPosition, float delay = 0f)
	{
		if (base.IsDisposed)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.1f + delay);
		yield return new WaitForEndOfFrame();
		if (base.IsDisposed || this.m_Gangsters == null)
		{
			yield return null;
		}
		ButcherGangAi butcherGangAi = GameManager.Instance.AssetManager.CreateAsset<ButcherGangAi>(prefab);
		butcherGangAi.OnDeath += this.HandleButcherGangOnDeath;
		butcherGangAi.transform.position = spawnPosition.position;
		butcherGangAi.transform.eulerAngles = new Vector3(0f, 90f, 0f);
		butcherGangAi.SetTarget(GameManager.Instance.Player.transform);
		butcherGangAi.SetThought(AiThought.Follow);
		this.m_Gangsters.Add(butcherGangAi);
		yield break;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x0004543C File Offset: 0x0004363C
	private void HandleButcherGangOnDeath(object sender, EventArgs e)
	{
		ButcherGangAi butcherGangAi = (ButcherGangAi)sender;
		butcherGangAi.OnDeath -= this.HandleButcherGangOnDeath;
		this.m_ButcherGangDeaths++;
		if (this.m_Gangsters.Contains(butcherGangAi))
		{
			this.m_Gangsters.Remove(butcherGangAi);
		}
		if (this.m_ButcherGangDeaths >= this.m_ButcherGangCount)
		{
			this.StartComplete();
			return;
		}
		if (this.m_ButcherGangDeaths == 2)
		{
			this.QuickenMusic();
		}
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x000454B0 File Offset: 0x000436B0
	private void QuickenMusic()
	{
		float num = this.m_MusicAudio.AudioSource.time - this.m_MusicSlow.length / this.m_MusicFast.length;
		this.m_MusicAudio.Clear();
		this.m_MusicAudio = GameManager.Instance.AudioManager.Play(this.m_MusicFast, AudioObjectType.MUSIC, -1, false);
		if (num <= 0f || num > this.m_MusicAudio.AudioSource.time)
		{
			num = 0f;
		}
		this.m_MusicAudio.AudioSource.time = num;
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00045544 File Offset: 0x00043744
	private void StartComplete()
	{
		GameManager.Instance.Player.OnDeath -= this.HandlePlayerOnSpawned;
		this.m_IsCompleted = true;
		for (int i = 0; i < this.m_Searchers.Count; i++)
		{
			this.m_Searchers[i].SetThought(AiThought.Die);
		}
		this.ClearEnemies();
		this.m_ButchGangAudio.Clear();
		this.m_MusicAudio.Clear();
		this.m_MusicEndAudio = GameManager.Instance.AudioManager.Play(this.m_MusicEnd, AudioObjectType.MUSIC, 0, false);
		this.m_MusicEndAudio.OnComplete += this.HandleMusicEndOnComplete;
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x000455F0 File Offset: 0x000437F0
	private void HandleMusicEndOnComplete(object sender, EventArgs e)
	{
		this.m_MusicEndAudio.OnComplete -= this.HandleMusicEndOnComplete;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_AliceMissionEndClip, "DIACH3/DIA_CH3_ALICE_29", false)).OnComplete += this.HandleAliceEndDialogueOnComplete;
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x00045640 File Offset: 0x00043840
	private void HandleAliceEndDialogueOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_RETURN_TO_THE_ANGEL", string.Empty, 4f, false, 0f));
		this.m_BendyController.SetActive(true);
		this.m_SearcherController.SetActive(true);
		this.m_GangsterController.SetActive(true);
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.FRONT_LINES);
		this.m_StairwellController.UnlockAllFloors();
		this.m_LiftController.EnableLift();
		this.m_ServiceController.Activate();
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.ButcherGangTask.IsComplete = true;
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.LiftFloor = this.m_LiftController.CurrentFloor.ID;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_EndMissionEventTrigger.OnEnter += this.HandleEndMissionEventTriggerOnEnter;
		this.m_EndMissionEventTrigger.SetActive(true);
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00045748 File Offset: 0x00043948
	private void HandlePlayerOnSpawned(object sender, EventArgs e)
	{
		GameManager.Instance.CurrentChapter.DeathController.OnSpawned -= this.HandlePlayerOnSpawned;
		this.m_ButcherGangDeaths = 0;
		this.m_BendyController.SetActive(true);
		base.StartCoroutine(this.RestartTask());
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00008C79 File Offset: 0x00006E79
	private IEnumerator RestartTask()
	{
		this.KillAllEnemies();
		if (GameManager.Instance.Player.WeaponGameObject)
		{
			global::UnityEngine.Object.Destroy(GameManager.Instance.Player.WeaponGameObject);
		}
		if (GameManager.Instance.Player.InactiveWeapon)
		{
			global::UnityEngine.Object.Destroy(GameManager.Instance.Player.InactiveWeapon);
		}
		MeleeWeapon meleeWeapon = GameManager.Instance.AssetManager.CreateAsset<MeleeWeapon>("GamePlay/Weapons/Weapon_Axe");
		MeleeWeapon meleeWeapon2 = GameManager.Instance.AssetManager.CreateAsset<MeleeWeapon>("GamePlay/Weapons/Weapon_Gent");
		this.m_AccountingDoor.Reset();
		this.m_AccountingDoor.DisableAxe();
		meleeWeapon2.KillInteraction();
		meleeWeapon2.Equip();
		GameManager.Instance.Player.InactiveWeapon = meleeWeapon2.gameObject;
		meleeWeapon2.SetParentAndAlign(GameManager.Instance.Player.WeaponParent);
		meleeWeapon2.gameObject.SetActive(false);
		meleeWeapon.KillInteraction();
		meleeWeapon.Equip();
		GameManager.Instance.Player.WeaponGameObject = meleeWeapon.gameObject;
		GameManager.Instance.Player.EquipWeapon();
		meleeWeapon.SetParentAndAlign(GameManager.Instance.Player.WeaponParent);
		this.ClearAudio();
		yield return new WaitForSeconds(1.5f);
		yield return new WaitForEndOfFrame();
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_ReturnClip, "DIACH3/DIA_CH3_ALICE_SPAWN", false));
		this.m_WeaponStationController.OnTaskComplete += this.HandleDropboxOnInteracted;
		this.m_WeaponStationController.ActivateDropbox();
		yield break;
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x00045798 File Offset: 0x00043998
	private void HandleDropboxOnInteracted(object sender, EventArgs e)
	{
		this.m_WeaponStationController.OnTaskComplete -= this.HandleDropboxOnInteracted;
		PlayerController player = GameManager.Instance.Player;
		if (player.InactiveWeapon != null)
		{
			global::UnityEngine.Object.Destroy(player.WeaponGameObject);
			player.WeaponGameObject = player.InactiveWeapon;
			player.WeaponGameObject.SetActive(true);
			player.WeaponGameObject.transform.localPosition = Vector3.zero;
			player.WeaponGameObject.transform.localEulerAngles = Vector3.zero;
			player.InactiveWeapon = null;
		}
		this.Activate();
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x00045830 File Offset: 0x00043A30
	public void KillAllEnemies()
	{
		for (int i = 0; i < this.m_Gangsters.Count; i++)
		{
			this.m_Gangsters[i].Dispose();
		}
		this.m_Gangsters.Clear();
		for (int j = 0; j < this.m_Searchers.Count; j++)
		{
			this.m_Searchers[j].Dispose();
		}
		this.m_Searchers.Clear();
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x00008C88 File Offset: 0x00006E88
	private void ClearEnemies()
	{
		if (this.m_Gangsters != null)
		{
			this.m_Gangsters.Clear();
			this.m_Gangsters = null;
		}
		if (this.m_Searchers != null)
		{
			this.m_Searchers.Clear();
			this.m_Searchers = null;
		}
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x000458A4 File Offset: 0x00043AA4
	private void ClearAudio()
	{
		if (this.m_MusicAudio != null)
		{
			this.m_MusicAudio.Clear();
			this.m_MusicAudio = null;
		}
		if (this.m_MusicEndAudio != null)
		{
			this.m_MusicEndAudio.Clear();
			this.m_MusicEndAudio = null;
		}
		if (this.m_ButchGangAudio != null)
		{
			this.m_ButchGangAudio.Clear();
			this.m_ButchGangAudio = null;
		}
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x00045914 File Offset: 0x00043B14
	protected override void OnDisposed()
	{
		this.ClearEnemies();
		this.ClearAudio();
		if (this.m_EndMissionEventTrigger)
		{
			this.m_EndMissionEventTrigger.OnEnter += this.HandleEndMissionEventTriggerOnEnter;
		}
		this.m_BeginTaskClips = null;
		this.m_MusicSlow = null;
		this.m_MusicFast = null;
		this.m_MusicEnd = null;
		this.m_ButcherGangBreakInClip = null;
		this.m_ReturnClip = null;
		this.m_AliceMissionEndClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000674 RID: 1652
	[Header("<Controllers>")]
	[SerializeField]
	private CH3ServiceController m_ServiceController;

	// Token: 0x04000675 RID: 1653
	[SerializeField]
	private CH3LiftController m_LiftController;

	// Token: 0x04000676 RID: 1654
	[SerializeField]
	private CH3StairwellController m_StairwellController;

	// Token: 0x04000677 RID: 1655
	[SerializeField]
	private CH3AccountingController m_AccountingDoor;

	// Token: 0x04000678 RID: 1656
	[Header("Spawners")]
	[SerializeField]
	private List<Transform> m_GangsterSpawners;

	// Token: 0x04000679 RID: 1657
	[SerializeField]
	private Transform m_SearcherSpawnerParent;

	// Token: 0x0400067A RID: 1658
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_EndMissionEventTrigger;

	// Token: 0x0400067B RID: 1659
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x0400067C RID: 1660
	private List<ButcherGangAi> m_Gangsters = new List<ButcherGangAi>();

	// Token: 0x0400067D RID: 1661
	private List<BaseAiController> m_Searchers = new List<BaseAiController>();

	// Token: 0x0400067E RID: 1662
	private List<CH3ButcherGangTaskController.SpawnPoint> m_SearcherSpawners = new List<CH3ButcherGangTaskController.SpawnPoint>();

	// Token: 0x0400067F RID: 1663
	private AudioClip[] m_BeginTaskClips;

	// Token: 0x04000680 RID: 1664
	private AudioObject m_MusicAudio;

	// Token: 0x04000681 RID: 1665
	private AudioObject m_MusicEndAudio;

	// Token: 0x04000682 RID: 1666
	private AudioObject m_ButchGangAudio;

	// Token: 0x04000683 RID: 1667
	private AudioClip m_MusicSlow;

	// Token: 0x04000684 RID: 1668
	private AudioClip m_MusicFast;

	// Token: 0x04000685 RID: 1669
	private AudioClip m_MusicEnd;

	// Token: 0x04000686 RID: 1670
	private AudioClip m_ButcherGangBreakInClip;

	// Token: 0x04000687 RID: 1671
	private AudioClip m_ReturnClip;

	// Token: 0x04000688 RID: 1672
	private AudioClip m_AliceMissionEndClip;

	// Token: 0x04000689 RID: 1673
	private int m_ButcherGangCount = 3;

	// Token: 0x0400068A RID: 1674
	private int m_ButcherGangDeaths;

	// Token: 0x0400068B RID: 1675
	private bool m_IsCompleted;

	// Token: 0x020000CD RID: 205
	private class SpawnPoint
	{
		// Token: 0x0400068C RID: 1676
		public Transform Spawner;

		// Token: 0x0400068D RID: 1677
		public BaseAiController Ai;

		// Token: 0x0400068E RID: 1678
		public bool isInUse;
	}
}

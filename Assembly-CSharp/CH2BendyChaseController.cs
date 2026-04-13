using System;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x02000084 RID: 132
public class CH2BendyChaseController : BaseController
{
	// Token: 0x060004B7 RID: 1207 RVA: 0x0003211C File Offset: 0x0003031C
	public override void InitOnComplete()
	{
		for (int i = 0; i < this.m_EnableSpawners.Length; i++)
		{
			this.m_EnableSpawners[i].SetActive(false);
		}
		this.m_BendyTrigger.SetActive(false);
		this.m_BarricadeTrigger.SetActive(false);
		this.m_BendyPoolTrigger.SetActive(false);
		this.m_Bendy.gameObject.SetActive(false);
		this.m_BendyFootstepClips = GameManager.Instance.GetAudioClips("Audio/SFX/Footsteps/Bendy/Loud");
		this.m_BendyRevealClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_BendyAppearsFromInk");
		this.m_LittleDevilMusic = GameManager.Instance.GetAudioClip("Audio/MUS/MUS_Little_Devil_Darling_Remastered");
		this.m_CeilingCollapseClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Ceiling_Collapse_02");
		this.m_CelingSettleClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Ceiling_Settle_02");
		this.m_DoorSlamClip = GameManager.Instance.GetAudioClip("Audio/SFX/Door/SFX_Door_Slam_01");
		this.m_BendyAtDoorClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_BendyAtTheDoor");
		this.m_HorrorCueClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_Horror_Cue_02");
		this.m_AxePickupClip = GameManager.Instance.GetAudioClip("Audio/SFX/Weapons/Axe/SFX_Axe_Pick_Up_01");
		this.m_ActiveWave = this.m_WaveA;
		for (int j = 0; j < this.m_DisableGameObjects.Count; j++)
		{
			this.m_DisableGameObjects[j].SetActive(false);
		}
		for (int k = 0; k < this.m_ActiveGameObjects.Count; k++)
		{
			this.m_ActiveGameObjects[k].SetActive(true);
		}
		for (int l = 0; l < this.m_DissolveMaterials.Length; l++)
		{
			Material material = this.m_DissolveMaterials[l];
			material.SetFloat("_Cutout", 0f);
		}
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x000322E0 File Offset: 0x000304E0
	public override void Activate()
	{
		for (int i = 0; i < this.m_Planks.Count; i++)
		{
			this.m_Planks[i].OnBroken += this.HandlePlankOnBroken;
		}
		this.m_BendyTrigger.OnEnter += this.HandleBendyOnEntered;
		this.m_BendyTrigger.SetActive(true);
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0003234C File Offset: 0x0003054C
	private void HandlePlayerOnDeath(object sender, EventArgs e)
	{
		this.m_Bendy.ForceKill();
		S13AudioManager.Instance.ToSnapshot("TMGAudioMixer", "mxs_base", 3f);
		for (int i = 0; i < this.m_DissolveMaterials.Length; i++)
		{
			Material material = this.m_DissolveMaterials[i];
			material.SetFloat("_Cutout", 0f);
		}
		if (this.m_MusicAudioObject)
		{
			this.m_MusicAudioObject.Clear();
			this.m_MusicAudioObject = null;
		}
		this.m_ActiveWave = this.m_WaveB;
		this.m_Bendy = global::UnityEngine.Object.Instantiate<BendyAi>(this.m_BendyPrefab);
		this.m_Bendy.transform.position = this.m_BendyPoolSpawnPoint.position;
		this.m_Bendy.gameObject.SetActive(false);
		this.m_BendyPoolTrigger.OnEnter += this.HandleBendyPoolSpawnTriggerOnEnter;
		this.m_BendyPoolTrigger.ResetTrigger();
		this.m_BendyPoolTrigger.SetActive(true);
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x000066A3 File Offset: 0x000048A3
	private void HandleBendyPoolSpawnTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BendyPoolTrigger.OnEnter -= this.HandleBendyPoolSpawnTriggerOnEnter;
		this.m_BendyPoolTrigger.SetActive(false);
		this.BendyReveal();
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x00032448 File Offset: 0x00030648
	private void HandlePlankOnBroken(object sender, EventArgs e)
	{
		Breakable breakable = (Breakable)sender;
		if (this.m_Planks.Contains(breakable))
		{
			this.m_Planks.Remove(breakable);
		}
		if (this.m_Planks.Count <= 0)
		{
			this.m_BreakablePlankBlockage.SetActive(false);
			GameManager.Instance.AudioManager.Play(this.m_AxePickupClip, AudioObjectType.SOUND_EFFECT, 0, false);
			BrokenWeapon brokenWeapon = global::UnityEngine.Object.Instantiate<BrokenWeapon>(this.m_BrokenAxe);
			brokenWeapon.Break(GameManager.Instance.Player.WeaponGameObject.transform, GameManager.Instance.Player.transform.position);
			global::UnityEngine.Object.Destroy(GameManager.Instance.Player.WeaponGameObject);
			GameManager.Instance.Player.UnEquipWeapon();
			foreach (SearcherAi searcherAi in Resources.FindObjectsOfTypeAll<SearcherAi>())
			{
				searcherAi.SetThought(AiThought.Retreat);
			}
		}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x00032538 File Offset: 0x00030738
	private void HandleBendyOnEntered(object sender, EventArgs e)
	{
		if (this.m_BendyRenderer.isVisible)
		{
			this.m_BendyTrigger.OnEnter -= this.HandleBendyOnEntered;
			this.m_BendyTrigger.Dispose();
			for (int i = 0; i < this.m_DisableGameObjects.Count; i++)
			{
				this.m_DisableGameObjects[i].SetActive(true);
			}
			for (int j = 0; j < this.m_ActiveGameObjects.Count; j++)
			{
				this.m_ActiveGameObjects[j].SetActive(false);
			}
			for (int k = 0; k < this.m_DisableSpawners.Length; k++)
			{
				this.m_DisableSpawners[k].SetActive(false);
			}
			for (int l = 0; l < this.m_EnableSpawners.Length; l++)
			{
				this.m_EnableSpawners[l].SetActive(true);
			}
			GameManager.Instance.AudioManager.Play(this.m_CeilingCollapseClip, AudioObjectType.SOUND_EFFECT, 0, false);
			GameManager.Instance.AudioManager.Play(this.m_CelingSettleClip, AudioObjectType.SOUND_EFFECT, 0, false);
			this.BendyReveal();
			this.m_DoorController.Open(0f, Ease.Linear, -125f);
			this.m_BarricadeTrigger.SetActive(true);
			this.m_BarricadeTrigger.OnEnter += this.HandleBarricadeTriggerOnEnter;
			GameManager.Instance.CurrentChapter.DeathController.OnDeath += this.HandlePlayerOnDeath;
		}
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x000326B4 File Offset: 0x000308B4
	private void BendyReveal()
	{
		this.m_Bendy.gameObject.SetActive(true);
		this.m_Bendy.ForceSetAnimationTrigger("EnemySpotted");
		this.m_Bendy.SetTarget(GameManager.Instance.Player.transform);
		this.m_Bendy.ForceFaceDirection();
		this.m_ActiveWave.AddWave(this.m_Bendy.transform.position, 7f, 0.04f, 15f);
		S13AudioManager.Instance.ToSnapshot("TMGAudioMixer", "mxs_bendy_overload", 0.2f);
		GameManager.Instance.AudioManager.Play(this.m_BendyRevealClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_MusicAudioObject = GameManager.Instance.AudioManager.Play(this.m_LittleDevilMusic, AudioObjectType.MUSIC, -1, false);
		this.m_MusicAudioObject.AudioSource.volume = 0f;
		this.m_MusicAudioObject.AudioSource.DOFade(1f, 1.5f);
		for (int i = 0; i < this.m_DissolveMaterials.Length; i++)
		{
			Material material = this.m_DissolveMaterials[i];
			material.DOFloat(0.5f, "_Cutout", 5f);
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x000327EC File Offset: 0x000309EC
	private void HandleBarricadeTriggerOnEnter(object sender, EventArgs e)
	{
		if (GameManager.Instance.CurrentChapter.DeathController)
		{
			GameManager.Instance.CurrentChapter.DeathController.OnDeath -= this.HandlePlayerOnDeath;
		}
		this.m_BarricadeTrigger.OnEnter -= this.HandleBarricadeTriggerOnEnter;
		this.m_Bendy.ForceKill();
		GameManager.Instance.Player.SetRun(false);
		GameManager.Instance.AudioManager.Play(this.m_DoorSlamClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_DoorController.OnClose += this.HandleDoorCloseOnComplete;
		this.m_DoorController.Close(0.25f, Ease.Linear);
		this.m_DoorController.Lock();
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_BendyAtDoorClip, this.m_DoorController.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		S13AudioManager.Instance.ToSnapshot("TMGAudioMixer", "mxs_base", 3f);
		if (this.m_MusicAudioObject != null)
		{
			this.m_MusicAudioObject.AudioSource.DOFade(0f, 3f).OnComplete(delegate
			{
				if (this.m_MusicAudioObject != null)
				{
					this.m_MusicAudioObject.Clear();
					this.m_MusicAudioObject = null;
				}
			});
		}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x00032930 File Offset: 0x00030B30
	private void HandleDoorCloseOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.AudioManager.Play(this.m_HorrorCueClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_PlankBarricade.DOLocalRotate(new Vector3(0f, 0f, 70f), 0.75f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(delegate
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.THE_BELIEVER);
			base.SendOnComplete();
		});
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00032994 File Offset: 0x00030B94
	private void PlayFootStepAudio()
	{
		if (this.m_BendyFootstepClips == null || this.m_BendyFootstepClips.Length <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_BendyFootstepClips.Length);
		AudioClip audioClip = this.m_BendyFootstepClips[num];
		GameManager.Instance.GameCamera.transform.DOShakePosition(0.25f, 0.15f, 12, 90f, false, true);
		GameManager.Instance.AudioManager.Play(audioClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_BendyFootstepClips[num] = this.m_BendyFootstepClips[0];
		this.m_BendyFootstepClips[0] = audioClip;
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x00032A28 File Offset: 0x00030C28
	protected override void OnDisposed()
	{
		if (this.m_BendyTrigger)
		{
			this.m_BendyTrigger.OnEnter -= this.HandleBendyOnEntered;
		}
		this.m_MusicAudioObject = null;
		this.m_BendyFootstepClips = null;
		this.m_BendyRevealClip = null;
		this.m_LittleDevilMusic = null;
		this.m_CeilingCollapseClip = null;
		this.m_CelingSettleClip = null;
		this.m_DoorSlamClip = null;
		this.m_BendyAtDoorClip = null;
		this.m_HorrorCueClip = null;
		this.m_AxePickupClip = null;
		this.m_EnableSpawners = null;
		this.m_DisableSpawners = null;
		base.OnDisposed();
	}

	// Token: 0x04000329 RID: 809
	private const string CUTOUT = "_Cutout";

	// Token: 0x0400032A RID: 810
	[Header("Transforms")]
	[SerializeField]
	private Transform m_PlankBarricade;

	// Token: 0x0400032B RID: 811
	[SerializeField]
	private Transform m_BendyPoolSpawnPoint;

	// Token: 0x0400032C RID: 812
	[Header("GameObjects")]
	[SerializeField]
	private GameObject m_BreakablePlankBlockage;

	// Token: 0x0400032D RID: 813
	[SerializeField]
	private List<GameObject> m_ActiveGameObjects;

	// Token: 0x0400032E RID: 814
	[SerializeField]
	private List<GameObject> m_DisableGameObjects;

	// Token: 0x0400032F RID: 815
	[SerializeField]
	private List<Breakable> m_Planks;

	// Token: 0x04000330 RID: 816
	[SerializeField]
	private BrokenWeapon m_BrokenAxe;

	// Token: 0x04000331 RID: 817
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_BendyTrigger;

	// Token: 0x04000332 RID: 818
	[SerializeField]
	private EventTrigger m_BarricadeTrigger;

	// Token: 0x04000333 RID: 819
	[SerializeField]
	private EventTrigger m_BendyPoolTrigger;

	// Token: 0x04000334 RID: 820
	[Header("Materials")]
	[SerializeField]
	private Material[] m_DissolveMaterials;

	// Token: 0x04000335 RID: 821
	[Header("Doors")]
	[SerializeField]
	private BaseDoorController m_DoorController;

	// Token: 0x04000336 RID: 822
	[Header("Light Fixture")]
	[SerializeField]
	private LightFixtureController m_LightController;

	// Token: 0x04000337 RID: 823
	[Header("Bendy")]
	[SerializeField]
	private BendyAi m_Bendy;

	// Token: 0x04000338 RID: 824
	[SerializeField]
	private MeshRenderer m_BendyRenderer;

	// Token: 0x04000339 RID: 825
	[Header("Spawners")]
	[SerializeField]
	private PlayerSpawnNode m_SacrificeSpawner;

	// Token: 0x0400033A RID: 826
	[SerializeField]
	private PlayerSpawnNode m_BendySpawner;

	// Token: 0x0400033B RID: 827
	[Header("Spawners")]
	[SerializeField]
	private RiverWaves m_WaveA;

	// Token: 0x0400033C RID: 828
	[SerializeField]
	private RiverWaves m_WaveB;

	// Token: 0x0400033D RID: 829
	[Header("Bendy Prefab (i know, just bandaids right now!)")]
	[SerializeField]
	private BendyAi m_BendyPrefab;

	// Token: 0x0400033E RID: 830
	[Header("Spawners")]
	[SerializeField]
	private GameObject[] m_DisableSpawners;

	// Token: 0x0400033F RID: 831
	[SerializeField]
	private GameObject[] m_EnableSpawners;

	// Token: 0x04000340 RID: 832
	private AudioObject m_MusicAudioObject;

	// Token: 0x04000341 RID: 833
	private AudioClip[] m_BendyFootstepClips;

	// Token: 0x04000342 RID: 834
	private AudioClip m_BendyRevealClip;

	// Token: 0x04000343 RID: 835
	private AudioClip m_LittleDevilMusic;

	// Token: 0x04000344 RID: 836
	private AudioClip m_CeilingCollapseClip;

	// Token: 0x04000345 RID: 837
	private AudioClip m_CelingSettleClip;

	// Token: 0x04000346 RID: 838
	private AudioClip m_DoorSlamClip;

	// Token: 0x04000347 RID: 839
	private AudioClip m_BendyAtDoorClip;

	// Token: 0x04000348 RID: 840
	private AudioClip m_HorrorCueClip;

	// Token: 0x04000349 RID: 841
	private AudioClip m_AxePickupClip;

	// Token: 0x0400034A RID: 842
	private bool m_IsClose;

	// Token: 0x0400034B RID: 843
	private bool m_IsBendyGone;

	// Token: 0x0400034C RID: 844
	private RiverWaves m_ActiveWave;
}

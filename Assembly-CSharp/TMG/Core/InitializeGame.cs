using System;
using System.IO;
using DG.Tweening;
using InControl;
using S13Audio;
using TMG.Data;
using TMG.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TMG.Core
{
	// Token: 0x020001EB RID: 491
	public class InitializeGame : TMGMonoBehaviour
	{
		// Token: 0x0600147D RID: 5245 RVA: 0x00010BAC File Offset: 0x0000EDAC
		public override void Init()
		{
			base.Init();
			Application.targetFrameRate = 60;
			this.m_GameManager = GameManager.Instance;
			if (this.m_GameManager.isGameLoaded)
			{
				this.InitializeFramework();
				return;
			}
			this.PreloadFramework();
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x0007A930 File Offset: 0x00078B30
		private void PreloadFramework()
		{
			this.InitAssetManager();
			this.InitUIManager();
			this.InitAudioManager();
			this.InitDOTween();
			this.InitPlayerSettings();
			if (this.IsRunningOnEpic())
			{
				this.InitPlatformController();
			}
			GameManager.Instance.AssetManager.CreateAsset<IntroController>("UI/Intro/MeatlyLogo").OnCompleteEvent += this.HandleSplashScreenOnComplete;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x0007A990 File Offset: 0x00078B90
		private void HandleSplashScreenOnComplete(object sender, EventArgs e)
		{
			IntroController introController = sender as IntroController;
			introController.OnCompleteEvent -= this.HandleSplashScreenOnComplete;
			introController.Dispose();
			GameManager.Instance.UIManager.Show<PreLoaderController>("UI/Loaders/PreLoaderController", "VIEW", null).OnPlayOutComplete += this.HandlePreLoaderOnComplete;
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x00010BE0 File Offset: 0x0000EDE0
		private void HandlePreLoaderOnComplete(object sender, EventArgs e)
		{
			(sender as PreLoaderController).OnPlayOutComplete -= this.HandlePreLoaderOnComplete;
			this.FinalizeFramework();
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x00010BFF File Offset: 0x0000EDFF
		private void InitializeFramework()
		{
			this.InitPlayerSettings();
			this.InitAssetManager();
			this.InitUIManager();
			this.InitAudioManager();
			this.InitDOTween();
			this.InitSaveData();
			this.FinalizeFramework();
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x00010C2B File Offset: 0x0000EE2B
		private void FinalizeFramework()
		{
			this.InitCharacterManager();
			this.InitParticleManager();
			this.InitPoolingManager();
			this.InitAchievementManager();
			this.InitInControl();
			this.LoadTitleScreen();
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x00010C51 File Offset: 0x0000EE51
		private void LoadTitleScreen()
		{
			SceneManager.LoadScene("Empty");
			GameManager.Instance.UIManager.Show<TitleScreenController>("UI/Views/TitleScreen", "VIEW", null);
			this.m_GameManager.isGameLoaded = true;
			base.Dispose();
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x00010C8A File Offset: 0x0000EE8A
		private void InitSaveData()
		{
			if (this.m_GameManager.GameDataManager != null)
			{
				Debug.LogWarning("Game Data Manager already exists.", this);
				return;
			}
			this.m_GameManager.GameDataManager = new GameDataManager();
			this.m_GameManager.GameDataManager.Load();
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x00010CC5 File Offset: 0x0000EEC5
		private void InitAssetManager()
		{
			if (this.m_GameManager.AssetManager != null)
			{
				Debug.LogWarning("Asset Manager already exists.", this);
				return;
			}
			this.m_GameManager.AssetManager = new AssetManager();
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x0007A9E8 File Offset: 0x00078BE8
		private void InitPoolingManager()
		{
			if (this.m_GameManager.PoolingManager)
			{
				Debug.LogWarning("Pooling Manager already exists.", this);
				return;
			}
			this.m_GameManager.PoolingManager = new GameObject("[POOLING MANAGER]").AddComponent<PoolingManager>();
			global::UnityEngine.Object.DontDestroyOnLoad(this.m_GameManager.PoolingManager.gameObject);
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x00010CF0 File Offset: 0x0000EEF0
		private void InitPlayerSettings()
		{
			if (this.m_GameManager.PlayerSettings != null)
			{
				Debug.LogWarning("Player Settings already exists.", this);
				return;
			}
			this.m_GameManager.PlayerSettings = new PlayerSettings();
			this.m_GameManager.PlayerSettings.Initialize();
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0007AA44 File Offset: 0x00078C44
		private void InitAchievementManager()
		{
			if (this.IsRunningOnSteam())
			{
				this.m_GameManager.SteamManager = global::UnityEngine.Object.FindObjectOfType<SteamManager>();
				if (this.m_GameManager.SteamManager == null)
				{
					this.m_GameManager.SteamManager = new GameObject("[SteamManager]").AddComponent<SteamManager>();
				}
				this.m_GameManager.AchievementManager = new AchievementManager();
				this.m_GameManager.AchievementManager.InitSteam();
				return;
			}
			if (this.IsRunningOnEpic())
			{
				this.m_GameManager.AchievementManager = new AchievementManager();
				this.m_GameManager.AchievementManager.InitEpic();
				return;
			}
			this.m_GameManager.AchievementManager = new AchievementManager();
			this.m_GameManager.AchievementManager.InitGOG();
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0007AB00 File Offset: 0x00078D00
		private void InitDOTween()
		{
			DOTween.Init(null, null, null);
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x00010D2B File Offset: 0x0000EF2B
		private void InitInControl()
		{
			InControlManager instance = SingletonMonoBehavior<InControlManager>.Instance;
			instance.enabled = false;
			instance.dontDestroyOnLoad = true;
			instance.enabled = true;
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0007AB30 File Offset: 0x00078D30
		private void InitAudioManager()
		{
			if (this.m_GameManager.AudioManager)
			{
				Debug.LogWarning("Audio Manager already exists.", this);
				return;
			}
			this.m_GameManager.AudioManager = AudioManager.Create();
			this.m_GameManager.AssetManager.CreateAsset<S13AudioManager>("S13AudioManager");
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x00010D46 File Offset: 0x0000EF46
		private void InitUIManager()
		{
			if (this.m_GameManager.UIManager)
			{
				Debug.LogWarning("UI Mananger already exists.", this);
				return;
			}
			this.m_GameManager.UIManager = UIManager.Create(null);
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x00010D77 File Offset: 0x0000EF77
		private void InitCharacterManager()
		{
			if (this.m_GameManager.CharacterManager != null)
			{
				Debug.LogWarning("Character Manager already exists.", this);
				return;
			}
			this.m_GameManager.CharacterManager = new CharacterManager();
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x00010DA2 File Offset: 0x0000EFA2
		private void InitParticleManager()
		{
			if (this.m_GameManager.ParticleManager != null)
			{
				Debug.LogWarning("Particle Manager already exists.", this);
				return;
			}
			this.m_GameManager.ParticleManager = new ParticleManager();
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x00010DCD File Offset: 0x0000EFCD
		protected override void OnDisposed()
		{
			this.m_GameManager = null;
			base.OnDisposed();
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x00010DDC File Offset: 0x0000EFDC
		private bool IsRunningOnSteam()
		{
			return Directory.GetFiles(Path.Combine(Application.dataPath, ".."), "*steam_api64*", SearchOption.TopDirectoryOnly).Length != 0;
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0007AB84 File Offset: 0x00078D84
		private void InitPlatformController()
		{
			try
			{
				EOSController eoscontroller = global::UnityEngine.Object.Instantiate<EOSController>(Resources.Load<EOSController>("EOSController"));
				if (eoscontroller)
				{
					EOSController.onUserSignin = (Action<EOSController>)Delegate.Combine(EOSController.onUserSignin, new Action<EOSController>(this.OnPlatformInitialized));
					eoscontroller.Init();
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
			}
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x00010DFC File Offset: 0x0000EFFC
		private bool IsRunningOnEpic()
		{
			return Directory.GetDirectories(Path.Combine(Application.dataPath, ".."), ".egstore", SearchOption.TopDirectoryOnly).Length != 0;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x00010E1C File Offset: 0x0000F01C
		private void OnPlatformInitialized(EOSController obj)
		{
			EOSController.onUserSignin = (Action<EOSController>)Delegate.Remove(EOSController.onUserSignin, new Action<EOSController>(this.OnPlatformInitialized));
			if (this.m_hasNoLanguagePrefs)
			{
				GameManager.SetLanguage(obj.PreferredLanguage);
			}
		}

		// Token: 0x04001018 RID: 4120
		private GameManager m_GameManager;

		// Token: 0x04001019 RID: 4121
		private bool m_hasNoLanguagePrefs;
	}
}

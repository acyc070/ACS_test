using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using TMG.Core;
using UnityEngine;

namespace TMG.Data
{
	// Token: 0x020001FE RID: 510
	public class PlayerSettings : TMGAbstractDisposable
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060014B3 RID: 5299 RVA: 0x00010FC8 File Offset: 0x0000F1C8
		public bool isVolumetricLightSupported
		{
			get
			{
				return Shader.Find("Sandbox/VolumetricLight").isSupported && Shader.Find("Hidden/BilateralBlur").isSupported && Shader.Find("Hidden/BlitAdd").isSupported;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060014B4 RID: 5300 RVA: 0x00010FFD File Offset: 0x0000F1FD
		public bool isPostProcessSupported
		{
			get
			{
				return SystemInfo.supportsImageEffects && Shader.Find("Hidden/ScionBloom").isSupported && Shader.Find("Hidden/ScionDepthOfField").isSupported;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060014B5 RID: 5301 RVA: 0x00011028 File Offset: 0x0000F228
		public bool isSSAOSupported
		{
			get
			{
				return Shader.Find("Hidden/Amplify Occlusion/Occlusion").isSupported && Shader.Find("Hidden/Amplify Occlusion/Blur").isSupported && Shader.Find("Hidden/Amplify Occlusion/Copy").isSupported;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0001105D File Offset: 0x0000F25D
		// (set) Token: 0x060014B7 RID: 5303 RVA: 0x00011069 File Offset: 0x0000F269
		public float Sensitivity
		{
			get
			{
				return PlayerPrefsManager.GetFloat("SENSITIVITY");
			}
			set
			{
				PlayerPrefsManager.Save("SENSITIVITY", value);
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060014B8 RID: 5304 RVA: 0x00011076 File Offset: 0x0000F276
		// (set) Token: 0x060014B9 RID: 5305 RVA: 0x0007BE44 File Offset: 0x0007A044
		public bool Inverted
		{
			get
			{
				return PlayerPrefsManager.GetBool("INVERTED");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("INVERTED", num);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060014BA RID: 5306 RVA: 0x00011082 File Offset: 0x0000F282
		// (set) Token: 0x060014BB RID: 5307 RVA: 0x0007BE64 File Offset: 0x0007A064
		public bool ToggleRun
		{
			get
			{
				return PlayerPrefsManager.GetBool("TOGGLE_RUN");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("TOGGLE_RUN", num);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060014BC RID: 5308 RVA: 0x0001108E File Offset: 0x0000F28E
		// (set) Token: 0x060014BD RID: 5309 RVA: 0x0007BE84 File Offset: 0x0007A084
		public bool Tips
		{
			get
			{
				return PlayerPrefsManager.GetBool("TIPS");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("TIPS", num);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060014BE RID: 5310 RVA: 0x0001109A File Offset: 0x0000F29A
		// (set) Token: 0x060014BF RID: 5311 RVA: 0x0007BEA4 File Offset: 0x0007A0A4
		public bool Crosshair
		{
			get
			{
				return PlayerPrefsManager.GetBool("CROSSHAIR");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("CROSSHAIR", num);
				if (GameManager.Instance.GameCamera != null)
				{
					if (num == 1)
					{
						GameManager.Instance.ShowCrosshair();
						return;
					}
					GameManager.Instance.HideCrosshair();
				}
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060014C0 RID: 5312 RVA: 0x000110A6 File Offset: 0x0000F2A6
		// (set) Token: 0x060014C1 RID: 5313 RVA: 0x000110B2 File Offset: 0x0000F2B2
		public float Volume
		{
			get
			{
				return PlayerPrefsManager.GetFloat("VOLUME");
			}
			set
			{
				PlayerPrefsManager.Save("VOLUME", value);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060014C2 RID: 5314 RVA: 0x000110BF File Offset: 0x0000F2BF
		// (set) Token: 0x060014C3 RID: 5315 RVA: 0x000110CB File Offset: 0x0000F2CB
		public float MusicVolume
		{
			get
			{
				return PlayerPrefsManager.GetFloat("MUSIC_VOLUME");
			}
			set
			{
				PlayerPrefsManager.Save("MUSIC_VOLUME", value);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060014C4 RID: 5316 RVA: 0x000110D8 File Offset: 0x0000F2D8
		// (set) Token: 0x060014C5 RID: 5317 RVA: 0x000110E4 File Offset: 0x0000F2E4
		public float SFXVolume
		{
			get
			{
				return PlayerPrefsManager.GetFloat("SFX_VOLUME");
			}
			set
			{
				PlayerPrefsManager.Save("SFX_VOLUME", value);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060014C6 RID: 5318 RVA: 0x000110F1 File Offset: 0x0000F2F1
		// (set) Token: 0x060014C7 RID: 5319 RVA: 0x000110FD File Offset: 0x0000F2FD
		public float DialogueVolume
		{
			get
			{
				return PlayerPrefsManager.GetFloat("DIALOGUE_VOLUME");
			}
			set
			{
				PlayerPrefsManager.Save("DIALOGUE_VOLUME", value);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x0001110A File Offset: 0x0000F30A
		// (set) Token: 0x060014C9 RID: 5321 RVA: 0x0007BEEC File Offset: 0x0007A0EC
		public bool Subtitles
		{
			get
			{
				return PlayerPrefsManager.GetBool("SUBTITLES");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("SUBTITLES", num);
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060014CA RID: 5322 RVA: 0x00011116 File Offset: 0x0000F316
		// (set) Token: 0x060014CB RID: 5323 RVA: 0x00011122 File Offset: 0x0000F322
		public string Language
		{
			get
			{
				return PlayerPrefsManager.GetString("LANGUAGE");
			}
			set
			{
				PlayerPrefsManager.Save("LANGUAGE", value);
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060014CC RID: 5324 RVA: 0x0001112F File Offset: 0x0000F32F
		// (set) Token: 0x060014CD RID: 5325 RVA: 0x0001113B File Offset: 0x0000F33B
		public float Brightness
		{
			get
			{
				return PlayerPrefsManager.GetFloat("BRIGHTNESS");
			}
			set
			{
				PlayerPrefsManager.Save("BRIGHTNESS", value);
				if (GameManager.Instance.GameCamera)
				{
					GameManager.Instance.GameCamera.Brightness.SetBrightness(value);
				}
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060014CE RID: 5326 RVA: 0x0001116E File Offset: 0x0000F36E
		// (set) Token: 0x060014CF RID: 5327 RVA: 0x0007BF0C File Offset: 0x0007A10C
		public bool Fullscreen
		{
			get
			{
				return PlayerPrefsManager.GetBool("FULLSCREEN");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("FULLSCREEN", num);
				Screen.fullScreen = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060014D0 RID: 5328 RVA: 0x0001117A File Offset: 0x0000F37A
		// (set) Token: 0x060014D1 RID: 5329 RVA: 0x0007BF30 File Offset: 0x0007A130
		public bool DoF
		{
			get
			{
				return PlayerPrefsManager.GetBool("DOF");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("DOF", num);
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060014D2 RID: 5330 RVA: 0x00011186 File Offset: 0x0000F386
		// (set) Token: 0x060014D3 RID: 5331 RVA: 0x0007BF50 File Offset: 0x0007A150
		public bool Bloom
		{
			get
			{
				return PlayerPrefsManager.GetBool("BLOOM");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("BLOOM", num);
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060014D4 RID: 5332 RVA: 0x00011192 File Offset: 0x0000F392
		// (set) Token: 0x060014D5 RID: 5333 RVA: 0x0007BF70 File Offset: 0x0007A170
		public bool VolumetricLighting
		{
			get
			{
				return PlayerPrefsManager.GetBool("VOLUMETRIC_LIGHT");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("VOLUMETRIC_LIGHT", num);
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060014D6 RID: 5334 RVA: 0x0001119E File Offset: 0x0000F39E
		// (set) Token: 0x060014D7 RID: 5335 RVA: 0x0007BF90 File Offset: 0x0007A190
		public bool AmbientOcclusion
		{
			get
			{
				return PlayerPrefsManager.GetBool("AMBIENT_OCCLUSION");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("AMBIENT_OCCLUSION", num);
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060014D8 RID: 5336 RVA: 0x000111AA File Offset: 0x0000F3AA
		// (set) Token: 0x060014D9 RID: 5337 RVA: 0x0007BFB0 File Offset: 0x0007A1B0
		public bool Grain
		{
			get
			{
				return PlayerPrefsManager.GetBool("GRAIN");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("GRAIN", num);
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060014DA RID: 5338 RVA: 0x000111B6 File Offset: 0x0000F3B6
		// (set) Token: 0x060014DB RID: 5339 RVA: 0x0007BFD0 File Offset: 0x0007A1D0
		public bool MotionBlur
		{
			get
			{
				return PlayerPrefsManager.GetBool("MOTION_BLUR");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("MOTION_BLUR", num);
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060014DC RID: 5340 RVA: 0x000111C2 File Offset: 0x0000F3C2
		// (set) Token: 0x060014DD RID: 5341 RVA: 0x0007BFF0 File Offset: 0x0007A1F0
		public bool ViewBobbing
		{
			get
			{
				return PlayerPrefsManager.GetBool("VIEW_BOBBING");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("VIEW_BOBBING", num);
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060014DE RID: 5342 RVA: 0x000111CE File Offset: 0x0000F3CE
		// (set) Token: 0x060014DF RID: 5343 RVA: 0x0007C010 File Offset: 0x0007A210
		public bool ViewSwaying
		{
			get
			{
				return PlayerPrefsManager.GetBool("VIEW_SWAYING");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("VIEW_SWAYING", num);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x000111DA File Offset: 0x0000F3DA
		// (set) Token: 0x060014E1 RID: 5345 RVA: 0x0007C030 File Offset: 0x0007A230
		public bool AA
		{
			get
			{
				return PlayerPrefsManager.GetBool("ANTI_ALIASING");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("ANTI_ALIASING", num);
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060014E2 RID: 5346 RVA: 0x000111E6 File Offset: 0x0000F3E6
		// (set) Token: 0x060014E3 RID: 5347 RVA: 0x0007C050 File Offset: 0x0007A250
		public bool VSync
		{
			get
			{
				return PlayerPrefsManager.GetBool("V_SYNC");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("V_SYNC", num);
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060014E4 RID: 5348 RVA: 0x000111F2 File Offset: 0x0000F3F2
		// (set) Token: 0x060014E5 RID: 5349 RVA: 0x0007C070 File Offset: 0x0007A270
		public bool Fog
		{
			get
			{
				return PlayerPrefsManager.GetBool("FOG");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("FOG", num);
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060014E6 RID: 5350 RVA: 0x000111FE File Offset: 0x0000F3FE
		// (set) Token: 0x060014E7 RID: 5351 RVA: 0x0007C090 File Offset: 0x0007A290
		public bool Shadows
		{
			get
			{
				return PlayerPrefsManager.GetBool("SHADOWS");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("SHADOWS", num);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060014E8 RID: 5352 RVA: 0x0001120A File Offset: 0x0000F40A
		// (set) Token: 0x060014E9 RID: 5353 RVA: 0x0007C0B0 File Offset: 0x0007A2B0
		public bool DustParticles
		{
			get
			{
				return PlayerPrefsManager.GetBool("DUST_PARTICLES");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("DUST_PARTICLES", num);
				if (GameManager.Instance.GameCamera)
				{
					GameManager.Instance.GameCamera.Dust = value;
				}
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060014EA RID: 5354 RVA: 0x00011216 File Offset: 0x0000F416
		// (set) Token: 0x060014EB RID: 5355 RVA: 0x00011222 File Offset: 0x0000F422
		public int currentQuality
		{
			get
			{
				return PlayerPrefsManager.GetInt("QUALITY");
			}
			set
			{
				PlayerPrefsManager.Save("QUALITY", value);
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060014EC RID: 5356 RVA: 0x0001122F File Offset: 0x0000F42F
		// (set) Token: 0x060014ED RID: 5357 RVA: 0x0001123B File Offset: 0x0000F43B
		public int CurrentResolution
		{
			get
			{
				return PlayerPrefsManager.GetInt("RESOLUTION_CURRENT");
			}
			set
			{
				PlayerPrefsManager.Save("RESOLUTION_CURRENT", value);
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060014EE RID: 5358 RVA: 0x00011248 File Offset: 0x0000F448
		// (set) Token: 0x060014EF RID: 5359 RVA: 0x00011254 File Offset: 0x0000F454
		public int ResolutionWidth
		{
			get
			{
				return PlayerPrefsManager.GetInt("RESOLUTION_WIDTH");
			}
			set
			{
				PlayerPrefsManager.Save("RESOLUTION_WIDTH", value);
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060014F0 RID: 5360 RVA: 0x00011261 File Offset: 0x0000F461
		// (set) Token: 0x060014F1 RID: 5361 RVA: 0x0001126D File Offset: 0x0000F46D
		public int ResolutionHeight
		{
			get
			{
				return PlayerPrefsManager.GetInt("RESOLUTION_HEIGHT");
			}
			set
			{
				PlayerPrefsManager.Save("RESOLUTION_HEIGHT", value);
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060014F2 RID: 5362 RVA: 0x0007C0F0 File Offset: 0x0007A2F0
		public List<Resolution> Resolutions
		{
			get
			{
				if (this.m_Resolutions == null || this.m_Resolutions.Count <= 0)
				{
					this.m_Resolutions = new List<Resolution>(Screen.resolutions);
					Resolution currentResolution = Screen.currentResolution;
					if (!this.m_Resolutions.Contains(currentResolution, new PlayerSettings.ResolutionEqualityComparer()))
					{
						this.m_Resolutions.Add(currentResolution);
					}
					this.m_Resolutions = this.m_Resolutions.OrderBy<Resolution, int>(delegate(Resolution r)
					{
						Resolution resolution = r;
						return resolution.width;
					}).ThenBy<Resolution, int>(delegate(Resolution r)
					{
						Resolution resolution2 = r;
						return resolution2.height;
					}).ToList<Resolution>();
				}
				return this.m_Resolutions;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060014F3 RID: 5363 RVA: 0x0007C1AC File Offset: 0x0007A3AC
		public Dictionary<int, string> Quality
		{
			get
			{
				if (this.m_Quality == null || this.m_Quality.Count <= 0)
				{
					this.m_Quality = new Dictionary<int, string>();
					string[] array = new string[] { "Very Low", "Low", "Medium", "High" };
					for (int i = 0; i < 4; i++)
					{
						this.m_Quality.Add(i, array[i]);
					}
				}
				return this.m_Quality;
			}
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0007C224 File Offset: 0x0007A424
		public void Initialize()
		{
			if (!PlayerPrefs.HasKey("v1.5.1.0"))
			{
				Debug.Log("Resetting Player Prefs");
				PlayerPrefs.DeleteAll();
				PlayerPrefsManager.Save("v1.5.1.0", 1);
			}
			if (!PlayerPrefs.HasKey("BRIGHTNESS"))
			{
				Debug.Log("Initializing Brightness");
				PlayerPrefsManager.Save("BRIGHTNESS", 0.5f);
			}
			if (!PlayerPrefs.HasKey("QUALITY"))
			{
				Debug.Log("Initializing Quality");
				PlayerPrefsManager.Save("QUALITY", 3);
			}
			if (!PlayerPrefs.HasKey("VOLUME"))
			{
				Debug.Log("Initializing Volume");
				PlayerPrefsManager.Save("VOLUME", 1f);
			}
			if (!PlayerPrefs.HasKey("FoV"))
			{
				Debug.Log("Initializing FoV");
				PlayerPrefsManager.Save("FoV", 55f);
			}
			if (!PlayerPrefs.HasKey("CROSSHAIR_SCALE"))
			{
				Debug.Log("Initializing Crosshair Scale");
				PlayerPrefsManager.Save("CROSSHAIR_SCALE", 1f);
			}
			if (!PlayerPrefs.HasKey("CROSSHAIR_OPACITY"))
			{
				Debug.Log("Initializing Crosshair Opacity");
				PlayerPrefsManager.Save("CROSSHAIR_OPACITY", 0.5f);
			}
			if (!PlayerPrefs.HasKey("MUSIC_VOLUME"))
			{
				Debug.Log("Initializing Music Volume");
				PlayerPrefsManager.Save("MUSIC_VOLUME", 0.95f);
			}
			if (!PlayerPrefs.HasKey("SFX_VOLUME"))
			{
				Debug.Log("Initializing SFX Volume");
				PlayerPrefsManager.Save("SFX_VOLUME", 0.95f);
			}
			if (!PlayerPrefs.HasKey("DIALOGUE_VOLUME"))
			{
				Debug.Log("Initializing Dialogue Volume");
				PlayerPrefsManager.Save("DIALOGUE_VOLUME", 0.95f);
			}
			if (!PlayerPrefs.HasKey("SUBTITLES"))
			{
				Debug.Log("Initializing Subtitles");
				PlayerPrefsManager.Save("SUBTITLES", 1);
			}
			if (!PlayerPrefs.HasKey("LANGUAGE"))
			{
				Debug.Log("Initializing Language");
				string languageCode = LocalizationManager.GetLanguageCode(LocalizationManager.GetCurrentDeviceLanguage());
				LocalizationManager.CurrentLanguageCode = languageCode;
				PlayerPrefsManager.Save("LANGUAGE", languageCode);
			}
			if (!PlayerPrefs.HasKey("INVERTED"))
			{
				Debug.Log("Initializing Inverted");
				PlayerPrefsManager.Save("INVERTED", 0);
			}
			if (!PlayerPrefs.HasKey("TOGGLE_RUN"))
			{
				Debug.Log("Initializing Toggle Run");
				PlayerPrefsManager.Save("TOGGLE_RUN", 0);
			}
			if (!PlayerPrefs.HasKey("CROSSHAIR"))
			{
				Debug.Log("Initializing Crosshair");
				PlayerPrefsManager.Save("CROSSHAIR", 1);
			}
			if (!PlayerPrefs.HasKey("SENSITIVITY"))
			{
				Debug.Log("Initializing Look Sensitivity");
				PlayerPrefsManager.Save("SENSITIVITY", 0.35f);
			}
			if (!PlayerPrefs.HasKey("BLOOM"))
			{
				Debug.Log("Initializing Bloom Lighting");
				PlayerPrefsManager.Save("BLOOM", 1);
			}
			if (!PlayerPrefs.HasKey("DOF"))
			{
				Debug.Log("Initializing Depth of Field");
				PlayerPrefsManager.Save("DOF", 1);
			}
			if (!PlayerPrefs.HasKey("VOLUMETRIC_LIGHT"))
			{
				Debug.Log("Initializing Volumetric Lighting");
				PlayerPrefsManager.Save("VOLUMETRIC_LIGHT", 1);
			}
			if (!PlayerPrefs.HasKey("AMBIENT_OCCLUSION"))
			{
				Debug.Log("Initializing Ambient Occlusion");
				PlayerPrefsManager.Save("AMBIENT_OCCLUSION", 1);
			}
			if (!PlayerPrefs.HasKey("GRAIN"))
			{
				Debug.Log("Initializing Grain");
				PlayerPrefsManager.Save("GRAIN", 1);
			}
			if (!PlayerPrefs.HasKey("MOTION_BLUR"))
			{
				Debug.Log("Initializing Motion Blur");
				PlayerPrefsManager.Save("MOTION_BLUR", 1);
			}
			if (!PlayerPrefs.HasKey("ANTI_ALIASING"))
			{
				Debug.Log("Initializing Anti Aliasing");
				PlayerPrefsManager.Save("ANTI_ALIASING", 1);
			}
			if (!PlayerPrefs.HasKey("V_SYNC"))
			{
				Debug.Log("Initializing V-Sync");
				PlayerPrefsManager.Save("V_SYNC", 1);
			}
			if (!PlayerPrefs.HasKey("VIEW_BOBBING"))
			{
				Debug.Log("Initializing View Bobbing");
				PlayerPrefsManager.Save("VIEW_BOBBING", 1);
			}
			if (!PlayerPrefs.HasKey("VIEW_SWAYING"))
			{
				Debug.Log("Initializing View Swaying");
				PlayerPrefsManager.Save("VIEW_SWAYING", 1);
			}
			if (!PlayerPrefs.HasKey("SHADOWS"))
			{
				Debug.Log("Initializing Shadow");
				PlayerPrefsManager.Save("SHADOWS", 1);
			}
			if (!PlayerPrefs.HasKey("FOG"))
			{
				Debug.Log("Initializing Fog");
				PlayerPrefsManager.Save("FOG", 1);
			}
			if (!PlayerPrefs.HasKey("DUST_PARTICLES"))
			{
				Debug.Log("Initializing Dust Particles");
				PlayerPrefsManager.Save("DUST_PARTICLES", 1);
			}
			if (!PlayerPrefs.HasKey("TIPS"))
			{
				Debug.Log("Initializing TIPS");
				PlayerPrefsManager.Save("TIPS", 1);
			}
			if (!PlayerPrefs.HasKey("AUDIO_TYPE"))
			{
				Debug.Log("Initializing Audio Type");
				PlayerPrefsManager.Save("AUDIO_TYPE", 1);
			}
			if (!PlayerPrefs.HasKey("FLICKER_LIGHTS"))
			{
				Debug.Log("Initializing Flickering Lights");
				PlayerPrefsManager.Save("FLICKER_LIGHTS", 1);
			}
			if (!PlayerPrefs.HasKey("WEAPON_SCALE"))
			{
				Debug.Log("Initializing Weapon Scale");
				PlayerPrefsManager.Save("WEAPON_SCALE", 1f);
			}
			if (!PlayerPrefs.HasKey("BENDY_AGGRESSION_SCALE"))
			{
				Debug.Log("Initializing Bendy Aggression Scale");
				PlayerPrefsManager.Save("BENDY_AGGRESSION_SCALE", 1f);
			}
			if (!PlayerPrefs.HasKey("FORCE_HALLOWEEN"))
			{
				Debug.Log("Initializing Force Halloween");
				PlayerPrefsManager.Save("FORCE_HALLOWEEN", 0);
			}
			LocalizationManager.CurrentLanguageCode = GameManager.Instance.PlayerSettings.Language;
			QualitySettings.vSyncCount = ((GameManager.Instance.PlayerSettings.VSync > false) ? 1 : 0);
			if (QualitySettings.vSyncCount == 0)
			{
				Application.targetFrameRate = -1;
			}
			else
			{
				Application.targetFrameRate = 60;
			}
			this.InitializeQuality();
			this.InitializeResolution();
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x0001127A File Offset: 0x0000F47A
		private void InitializeQuality()
		{
			QualitySettings.SetQualityLevel(this.currentQuality, true);
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0007C744 File Offset: 0x0007A944
		private void InitializeResolution()
		{
			if (!PlayerPrefs.HasKey("FULLSCREEN"))
			{
				Debug.Log("Initializing Fullscreen");
				PlayerPrefsManager.Save("FULLSCREEN", 1);
			}
			if (!PlayerPrefs.HasKey("RESOLUTION_WIDTH"))
			{
				Debug.Log("Initializing Resolution Width");
				PlayerPrefsManager.Save("RESOLUTION_WIDTH", GameManager.Instance.PlayerSettings.Resolutions[GameManager.Instance.PlayerSettings.Resolutions.Count - 1].width);
			}
			if (!PlayerPrefs.HasKey("RESOLUTION_HEIGHT"))
			{
				Debug.Log("Initializing Resolution Height");
				PlayerPrefsManager.Save("RESOLUTION_HEIGHT", GameManager.Instance.PlayerSettings.Resolutions[GameManager.Instance.PlayerSettings.Resolutions.Count - 1].height);
			}
			if (!PlayerPrefs.HasKey("RESOLUTION_CURRENT"))
			{
				Debug.Log("Initializing Resolution Current");
				PlayerPrefsManager.Save("RESOLUTION_CURRENT", GameManager.Instance.PlayerSettings.Resolutions.Count - 1);
			}
			this.Fullscreen = PlayerPrefsManager.GetBool("FULLSCREEN");
			int @int = PlayerPrefsManager.GetInt("RESOLUTION_WIDTH");
			int int2 = PlayerPrefsManager.GetInt("RESOLUTION_HEIGHT");
			Screen.SetResolution(@int, int2, this.Fullscreen);
			Debug.Log(string.Concat(new object[] { "Fullscreen: ", this.Fullscreen, "\nResolution :", @int, " x ", int2, "\nResolution Index: ", this.CurrentResolution }));
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x00011288 File Offset: 0x0000F488
		protected override void OnDisposed()
		{
			if (this.m_Resolutions != null)
			{
				this.m_Resolutions.Clear();
				this.m_Resolutions = null;
			}
			base.OnDisposed();
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060014F8 RID: 5368 RVA: 0x000112AA File Offset: 0x0000F4AA
		// (set) Token: 0x060014F9 RID: 5369 RVA: 0x000112B6 File Offset: 0x0000F4B6
		public float FoV
		{
			get
			{
				return PlayerPrefsManager.GetFloat("FoV");
			}
			set
			{
				PlayerPrefsManager.Save("FoV", value);
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060014FA RID: 5370 RVA: 0x000112C3 File Offset: 0x0000F4C3
		// (set) Token: 0x060014FB RID: 5371 RVA: 0x000112CF File Offset: 0x0000F4CF
		public float CrosshairScale
		{
			get
			{
				return PlayerPrefsManager.GetFloat("CROSSHAIR_SCALE");
			}
			set
			{
				PlayerPrefsManager.Save("CROSSHAIR_SCALE", value);
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060014FC RID: 5372 RVA: 0x000112DC File Offset: 0x0000F4DC
		// (set) Token: 0x060014FD RID: 5373 RVA: 0x000112E8 File Offset: 0x0000F4E8
		public float CrosshairOpacity
		{
			get
			{
				return PlayerPrefsManager.GetFloat("CROSSHAIR_OPACITY");
			}
			set
			{
				PlayerPrefsManager.Save("CROSSHAIR_OPACITY", value);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060014FE RID: 5374 RVA: 0x000112F5 File Offset: 0x0000F4F5
		// (set) Token: 0x060014FF RID: 5375 RVA: 0x00011301 File Offset: 0x0000F501
		public int currentAudioType
		{
			get
			{
				return PlayerPrefsManager.GetInt("AUDIO_TYPE");
			}
			set
			{
				PlayerPrefsManager.Save("AUDIO_TYPE", value);
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06001500 RID: 5376 RVA: 0x0001130E File Offset: 0x0000F50E
		// (set) Token: 0x06001501 RID: 5377 RVA: 0x0007C8E0 File Offset: 0x0007AAE0
		public bool flickerLights
		{
			get
			{
				return PlayerPrefsManager.GetBool("FLICKER_LIGHTS");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("FLICKER_LIGHTS", num);
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06001502 RID: 5378 RVA: 0x0001131A File Offset: 0x0000F51A
		// (set) Token: 0x06001503 RID: 5379 RVA: 0x00011326 File Offset: 0x0000F526
		public float weaponScale
		{
			get
			{
				return PlayerPrefsManager.GetFloat("WEAPON_SCALE");
			}
			set
			{
				PlayerPrefsManager.Save("WEAPON_SCALE", value);
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06001504 RID: 5380 RVA: 0x00011333 File Offset: 0x0000F533
		// (set) Token: 0x06001505 RID: 5381 RVA: 0x0001133F File Offset: 0x0000F53F
		public float BendyAggressionScale
		{
			get
			{
				return PlayerPrefsManager.GetFloat("BENDY_AGGRESSION_SCALE");
			}
			set
			{
				PlayerPrefsManager.Save("BENDY_AGGRESSION_SCALE", value);
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06001506 RID: 5382 RVA: 0x0001134C File Offset: 0x0000F54C
		// (set) Token: 0x06001507 RID: 5383 RVA: 0x0007C900 File Offset: 0x0007AB00
		public bool forceHalloween
		{
			get
			{
				return PlayerPrefsManager.GetBool("FORCE_HALLOWEEN");
			}
			set
			{
				int num = ((value > false) ? 1 : 0);
				PlayerPrefsManager.Save("FORCE_HALLOWEEN", num);
			}
		}

		// Token: 0x04001282 RID: 4738
		public const float SENSITIVITY_MULTIPLIER = 5f;

		// Token: 0x04001283 RID: 4739
		private bool m_Shadows;

		// Token: 0x04001284 RID: 4740
		private List<Resolution> m_Resolutions;

		// Token: 0x04001285 RID: 4741
		private Dictionary<int, string> m_Quality;

		// Token: 0x020001FF RID: 511
		private class ResolutionEqualityComparer : IEqualityComparer<Resolution>
		{
			// Token: 0x06001508 RID: 5384 RVA: 0x00011358 File Offset: 0x0000F558
			public bool Equals(Resolution x, Resolution y)
			{
				return x.width == y.width && x.height == y.height && x.refreshRate == y.refreshRate;
			}

			// Token: 0x06001509 RID: 5385 RVA: 0x0001138C File Offset: 0x0000F58C
			public int GetHashCode(Resolution obj)
			{
				return obj.width ^ obj.height ^ obj.refreshRate;
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace S13Audio
{
	// Token: 0x0200004E RID: 78
	public class S13AudioManager : MonoBehaviour
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00004EE2 File Offset: 0x000030E2
		public static S13AudioManager Instance
		{
			get
			{
				return S13AudioManager._instance;
			}
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00028DF8 File Offset: 0x00026FF8
		private void Awake()
		{
			if (S13AudioManager._instance != null)
			{
				Debug.LogWarning(base.name + ": Another singleton instance found in scene. Destroying...");
				global::UnityEngine.Object.Destroy(base.gameObject);
				global::UnityEngine.Object.Destroy(this);
				base.enabled = false;
				base.gameObject.SetActive(false);
				return;
			}
			S13AudioManager._instance = this;
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			this.LoadSoundBanksInScene();
			this.audioEvents = base.GetComponent<S13AudioEvents>();
			if (this.audioEvents == null)
			{
				Debug.LogWarning(base.name + ": Reference to AudioEvents not found.");
			}
			if (this.mixerAssets.Length < 1)
			{
				Debug.LogWarning("S13AudioManager missing explicit references to mixer assets, resource load methods will increase load times significantly");
				this.mixerAssets = Resources.LoadAll(string.Empty, typeof(AudioMixer)) as AudioMixer[];
			}
			string text = string.Empty;
			foreach (AudioMixer audioMixer in this.mixerAssets)
			{
				if (audioMixer != null)
				{
					this._mixers.Add(audioMixer.name, audioMixer);
					text = text + audioMixer.name + ", ";
				}
			}
			Debug.Log(string.Concat(new object[]
			{
				base.name,
				": Loaded ",
				this._mixers.Count,
				" mixers: ",
				text
			}));
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00004EE9 File Offset: 0x000030E9
		private void OnEnable()
		{
			SceneManager.sceneLoaded += this.OnLevelFinishedLoading;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00004EFC File Offset: 0x000030FC
		private void OnDisable()
		{
			SceneManager.sceneLoaded -= this.OnLevelFinishedLoading;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00028F64 File Offset: 0x00027164
		private void Start()
		{
			if (this.debugMode && this.debugScreenMode)
			{
				GameObject gameObject = new GameObject("debug");
				gameObject.AddComponent<S13AudioManagerDebug>();
				gameObject.transform.parent = base.transform;
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00004F0F File Offset: 0x0000310F
		public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			this.LoadSoundBanksInScene();
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00002482 File Offset: 0x00000682
		public void SetSoundBank(string bankName)
		{
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00028FAC File Offset: 0x000271AC
		public void LoadSoundBank(string bankName)
		{
			if (!this._loadedSoundBanks.ContainsKey(bankName))
			{
				GameObject gameObject = Resources.Load<GameObject>(bankName);
				if (gameObject != null)
				{
					GameObject gameObject2 = global::UnityEngine.Object.Instantiate<GameObject>(gameObject);
					gameObject2.name = bankName;
					this._loadedSoundBanks.Add(bankName, gameObject2.GetComponent<S13SoundBank>());
				}
				else
				{
					Debug.LogError(base.name + ": Error loading sound bank '" + bankName + "'. Could not locate in Resources.");
				}
			}
			else
			{
				Debug.LogError(base.name + ": Cannot load sound bank '" + bankName + "' because it is already loaded.");
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00029040 File Offset: 0x00027240
		public void UnloadSoundBank(string bankName)
		{
			if (this._loadedSoundBanks.ContainsKey(bankName))
			{
				GameObject gameObject = GameObject.Find(bankName);
				if (gameObject != null)
				{
					this._loadedSoundBanks.Remove(bankName);
					global::UnityEngine.Object.Destroy(gameObject);
					Resources.UnloadUnusedAssets();
				}
				else
				{
					this._loadedSoundBanks.Remove(bankName);
					Debug.Log(base.name + ": Removed sound bank '" + bankName + "' from loaded sound banks, but its GameObject has already been destroyed.");
				}
			}
			else
			{
				Debug.LogWarning(base.name + ": Cannot unload sound bank '" + bankName + "' because it is not loaded.");
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000290D8 File Offset: 0x000272D8
		public void UnloadAllSoundBanks()
		{
			if (this._loadedSoundBanks.Count < 1)
			{
				Debug.Log("UnloadAllSoundBanks() cancelled. There are no sound banks to unload", base.gameObject);
				return;
			}
			List<string> list = new List<string>(this._loadedSoundBanks.Keys);
			foreach (string text in list)
			{
				if (this._loadedSoundBanks.ContainsKey(text))
				{
					this.UnloadSoundBank(text);
				}
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00029174 File Offset: 0x00027374
		public void PruneIDFromSoundBank(string soundIdToRemove)
		{
			foreach (KeyValuePair<string, S13SoundBank> keyValuePair in this._loadedSoundBanks)
			{
				this.m_keysList.Clear();
				this.m_keysList.AddRange(keyValuePair.Value.SoundIDs);
				foreach (string text in this.m_keysList)
				{
					if (text == soundIdToRemove)
					{
						keyValuePair.Value.RemoveSoundFromBank(soundIdToRemove);
					}
				}
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00029248 File Offset: 0x00027448
		public void PlayAudio(string soundId)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null)
			{
				audioInSoundBanks.Play();
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00029270 File Offset: 0x00027470
		public void PlayAudio(string soundId, float duration)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null)
			{
				audioInSoundBanks.Play(duration);
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00029298 File Offset: 0x00027498
		public void PlayAudioDelayed(string soundId, float delayTime)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null)
			{
				audioInSoundBanks.PlayDelayed(delayTime);
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000292C0 File Offset: 0x000274C0
		public void StopAudio(string soundId, bool ignoreFade = false)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null)
			{
				audioInSoundBanks.Stop(ignoreFade);
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x000292E8 File Offset: 0x000274E8
		public void StopAudioDelayed(string soundId, float delayTime, bool ignoreFade = false)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null)
			{
				audioInSoundBanks.StopDelayed(delayTime, ignoreFade);
			}
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00029314 File Offset: 0x00027514
		public void StopAllAudio(bool ignoreFade = false)
		{
			foreach (string text in this.masterSoundBank.SoundIDs)
			{
				try
				{
					this.masterSoundBank[text].Stop(ignoreFade);
				}
				catch (Exception ex)
				{
					Debug.Log("Trying to stop " + text + " threw an error: " + ex.ToString());
				}
			}
			foreach (KeyValuePair<string, S13SoundBank> keyValuePair in this._loadedSoundBanks)
			{
				foreach (string text2 in keyValuePair.Value.SoundIDs)
				{
					try
					{
						keyValuePair.Value[text2].Stop(ignoreFade);
					}
					catch (Exception ex2)
					{
						Debug.Log("Trying to stop " + text2 + " threw an error: " + ex2.ToString());
					}
				}
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0002948C File Offset: 0x0002768C
		public void PauseAudio(string soundId, bool ignoreFade = false)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null && audioInSoundBanks.gamePauseEnabled)
			{
				audioInSoundBanks.Pause(ignoreFade);
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000294C0 File Offset: 0x000276C0
		public void ResumeAudio(string soundId)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			if (audioInSoundBanks != null && audioInSoundBanks.gamePauseEnabled)
			{
				audioInSoundBanks.Resume();
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000294F4 File Offset: 0x000276F4
		public bool IsAudioPlaying(string soundId)
		{
			S13AudioSource audioInSoundBanks = this.GetAudioInSoundBanks(soundId);
			return audioInSoundBanks.IsPlaying;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00029510 File Offset: 0x00027710
		public void InvokeEvent(string eventName, float delayTime = 0f)
		{
			if (this.audioEvents != null)
			{
				this.audioEvents.Invoke(eventName, delayTime);
				if (this.debugMode)
				{
					Debug.Log(string.Concat(new object[] { base.name, ": InvokeEvent '", eventName, "' with delay ", delayTime }));
				}
			}
			else
			{
				Debug.LogError(base.name + ": No reference to AudioEvents; could not invoke event '" + eventName + "'.");
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0002959C File Offset: 0x0002779C
		public void SetMutingForAudioGroup(bool muting, S13AudioGroup group)
		{
			foreach (string text in this.masterSoundBank.SoundIDs)
			{
				S13AudioSource s13AudioSource = this.masterSoundBank[text];
				if (s13AudioSource.group == group)
				{
					s13AudioSource.SetMuting(muting);
				}
			}
			foreach (KeyValuePair<string, S13SoundBank> keyValuePair in this._loadedSoundBanks)
			{
				foreach (string text2 in keyValuePair.Value.SoundIDs)
				{
					S13AudioSource s13AudioSource2 = keyValuePair.Value[text2];
					if (s13AudioSource2.group == group)
					{
						s13AudioSource2.SetMuting(muting);
					}
				}
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x000296CC File Offset: 0x000278CC
		public void ToSnapshot(string mixerName, string snapshotName, float time)
		{
			AudioMixer audioMixer = this._mixers[mixerName];
			if (audioMixer != null)
			{
				AudioMixerSnapshot audioMixerSnapshot = audioMixer.FindSnapshot(snapshotName);
				if (audioMixerSnapshot != null)
				{
					if (time > 0f && Time.timeScale == 0f)
					{
						Debug.LogWarning(base.name + ": Transition time to snapshot " + snapshotName + " is > 0 with a time scale of 0.");
					}
					audioMixerSnapshot.TransitionTo(time);
				}
				else
				{
					Debug.LogError(base.name + ": Cannot transition to snapshot. No snapshot named '" + snapshotName + "' in master mixer.");
				}
			}
			else
			{
				Debug.LogError(string.Concat(new string[] { base.name, ": Error transitioning to snapshot '", snapshotName, "' because the mixer '", mixerName, "' was not found." }));
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000297A0 File Offset: 0x000279A0
		public void BlendSnapshots(string mixerName, string[] snapshotNames, float[] weights, float time)
		{
			if (snapshotNames.Length != weights.Length)
			{
				Debug.LogError(base.name + ": Each snapshot in blending must have a corresponding weight value. Length of arrays not equal.");
				return;
			}
			AudioMixer audioMixer = this._mixers[mixerName];
			if (audioMixer != null)
			{
				AudioMixerSnapshot[] array = new AudioMixerSnapshot[snapshotNames.Length];
				int num = 0;
				foreach (string text in snapshotNames)
				{
					AudioMixerSnapshot audioMixerSnapshot = audioMixer.FindSnapshot(text);
					if (audioMixerSnapshot != null)
					{
						array[num++] = audioMixerSnapshot;
					}
					else
					{
						Debug.LogError(string.Concat(new string[] { text, ": Snapshot named '", text, "' not found in mixer '", mixerName, "'." }));
					}
				}
				audioMixer.TransitionToSnapshots(array, weights, time);
			}
			else
			{
				Debug.LogError(base.name + ": Mixer '" + mixerName + "' was not found.");
			}
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00029898 File Offset: 0x00027A98
		public void SetMixerProperty(string mixerName, string propName, float value)
		{
			AudioMixer audioMixer = this._mixers[mixerName];
			if (audioMixer != null)
			{
				if (audioMixer.SetFloat(propName, value))
				{
					if (!this._modifiedMixerProperties.Contains(propName))
					{
						this._modifiedMixerProperties.Add(propName);
					}
				}
				else
				{
					Debug.LogError(base.name + ": Failed to set mixer property '" + propName + "' because it is either not exposed, or snapshots are editing.");
				}
			}
			else
			{
				Debug.LogError(string.Concat(new string[] { base.name, ": Error setting mixer property '", propName, "' because the mixer '", mixerName, "' was not found." }));
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00029948 File Offset: 0x00027B48
		public void LerpMixerProperty(string mixerName, string propName, float targetValue, float time, bool ignoreTimeScale = false)
		{
			AudioMixer mixer = this._mixers[mixerName];
			if (mixer != null)
			{
				float num;
				if (mixer.GetFloat(propName, out num))
				{
					base.StartCoroutine(this.LerpMixerValue(mixer, propName, num, targetValue, time, ignoreTimeScale, delegate
					{
						mixer.SetFloat(propName, targetValue);
					}));
					if (!this._modifiedMixerProperties.Contains(propName))
					{
						this._modifiedMixerProperties.Add(propName);
					}
				}
				else
				{
					Debug.LogError(base.name + ": Failed to lerp mixer property '" + propName + "' because it is either not exposed, or snapshots are editing.");
				}
			}
			else
			{
				Debug.LogError(string.Concat(new string[] { base.name, ": Error lerping mixer property '", propName, "' because the mixer '", mixerName, "' was not found." }));
			}
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00029A64 File Offset: 0x00027C64
		public void ClearMixerProperty(string mixerName, string propName)
		{
			AudioMixer audioMixer = this._mixers[mixerName];
			if (audioMixer != null)
			{
				if (audioMixer.ClearFloat(propName))
				{
					if (this._modifiedMixerProperties.Contains(propName))
					{
						this._modifiedMixerProperties.Remove(propName);
					}
				}
				else
				{
					Debug.LogError(base.name + ": Failed to clear mixer property '" + propName + "' because it is either not exposed, or snapshots are editing.");
				}
			}
			else
			{
				Debug.LogError(string.Concat(new string[] { base.name, ": Error clearing mixer property '", propName, "' because the mixer '", mixerName, "' was not found." }));
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00029B14 File Offset: 0x00027D14
		public void ClearAllMixerProperties(string mixerName)
		{
			AudioMixer audioMixer = this._mixers[mixerName];
			if (audioMixer != null)
			{
				foreach (string text in this._modifiedMixerProperties)
				{
					if (!audioMixer.ClearFloat(text))
					{
						Debug.LogError(base.name + ": Failed to clear mixer property '" + text + "' because it is either not exposed, or snapshots are editing.");
					}
				}
				this._modifiedMixerProperties.Clear();
			}
			else
			{
				Debug.LogError(base.name + ": Error clearing all mixer properties because the mixer '" + mixerName + "' was not found.");
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00002482 File Offset: 0x00000682
		public static void VOPlay(AudioClip clip, S13AudioSource.AudioEndedHandler handler = null)
		{
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00002482 File Offset: 0x00000682
		public static void VOStop()
		{
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00002482 File Offset: 0x00000682
		public static void VOStopAll()
		{
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00029BD4 File Offset: 0x00027DD4
		private void LoadSoundBanksInScene()
		{
			S13SoundBank[] array = global::UnityEngine.Object.FindObjectsOfType<S13SoundBank>();
			int num = 0;
			foreach (S13SoundBank s13SoundBank in array)
			{
				if (s13SoundBank != this.masterSoundBank)
				{
					if (this._loadedSoundBanks.ContainsKey(s13SoundBank.gameObject.name))
					{
						this._loadedSoundBanks[s13SoundBank.gameObject.name] = s13SoundBank;
					}
					else
					{
						this._loadedSoundBanks.Add(s13SoundBank.gameObject.name, s13SoundBank);
					}
					num++;
					Debug.Log(base.name + ": Loaded sound bank '" + s13SoundBank.gameObject.name + "'.");
				}
			}
			Debug.Log(string.Concat(new object[]
			{
				base.name,
				": Loaded ",
				num,
				" sound banks. Total sound banks loaded: ",
				this._loadedSoundBanks.Count
			}));
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00029CD8 File Offset: 0x00027ED8
		private S13AudioSource GetAudioInSoundBanks(string soundId)
		{
			S13AudioSource s13AudioSource = null;
			foreach (KeyValuePair<string, S13SoundBank> keyValuePair in this._loadedSoundBanks)
			{
				s13AudioSource = keyValuePair.Value[soundId];
				if (s13AudioSource)
				{
					break;
				}
			}
			if (s13AudioSource == null)
			{
				s13AudioSource = this.masterSoundBank[soundId];
			}
			if (s13AudioSource == null)
			{
				Debug.LogError(base.name + ": Could not find audio with name '" + soundId + "' in either the current sound bank or the master sound bank.", base.gameObject);
			}
			return s13AudioSource;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00029D94 File Offset: 0x00027F94
		private IEnumerator LerpMixerValue(AudioMixer mixer, string propName, float fromValue, float toValue, float time, bool ignoreTimeScale, S13AudioUtil.FadeInOutDelegate completionHandler = null)
		{
			float timeElapsed = 0f;
			float lastTime = Time.realtimeSinceStartup;
			while (timeElapsed < time)
			{
				float t = timeElapsed / time;
				mixer.SetFloat(propName, Mathf.Lerp(fromValue, toValue, t));
				if (ignoreTimeScale)
				{
					timeElapsed += Time.realtimeSinceStartup - lastTime;
					lastTime = Time.realtimeSinceStartup;
				}
				else
				{
					timeElapsed += Time.deltaTime;
				}
				yield return null;
			}
			if (completionHandler != null)
			{
				completionHandler();
			}
			yield break;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00002482 File Offset: 0x00000682
		private static void OnVOAudioComplete(S13AudioSource audioSource)
		{
		}

		// Token: 0x0400017A RID: 378
		private static S13AudioManager _instance;

		// Token: 0x0400017B RID: 379
		public S13SoundBank masterSoundBank;

		// Token: 0x0400017C RID: 380
		public S13AudioEvents audioEvents;

		// Token: 0x0400017D RID: 381
		public bool debugMode;

		// Token: 0x0400017E RID: 382
		public AudioMixer[] mixerAssets;

		// Token: 0x0400017F RID: 383
		public bool debugScreenMode;

		// Token: 0x04000180 RID: 384
		private Dictionary<string, S13SoundBank> _loadedSoundBanks = new Dictionary<string, S13SoundBank>();

		// Token: 0x04000181 RID: 385
		private Dictionary<string, AudioMixer> _mixers = new Dictionary<string, AudioMixer>();

		// Token: 0x04000182 RID: 386
		private List<string> _modifiedMixerProperties = new List<string>();

		// Token: 0x04000183 RID: 387
		private List<string> m_keysList = new List<string>();
	}
}

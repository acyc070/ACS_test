using System;
using System.Collections.Generic;
using System.Linq;
using TMG.Core;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x0200024A RID: 586
public class AudioManager : TMGMonoBehaviour
{
	// Token: 0x17000176 RID: 374
	// (get) Token: 0x060016C1 RID: 5825 RVA: 0x00012768 File Offset: 0x00010968
	// (set) Token: 0x060016C2 RID: 5826 RVA: 0x00012770 File Offset: 0x00010970
	public Transform AudioManagerParent { get; private set; }

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x060016C3 RID: 5827 RVA: 0x00012779 File Offset: 0x00010979
	// (set) Token: 0x060016C4 RID: 5828 RVA: 0x00012781 File Offset: 0x00010981
	public Transform PooledAudioObjectsParent { get; private set; }

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x060016C5 RID: 5829 RVA: 0x0001278A File Offset: 0x0001098A
	// (set) Token: 0x060016C6 RID: 5830 RVA: 0x00012792 File Offset: 0x00010992
	public Transform Ambience { get; private set; }

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x060016C7 RID: 5831 RVA: 0x0001279B File Offset: 0x0001099B
	// (set) Token: 0x060016C8 RID: 5832 RVA: 0x000127A3 File Offset: 0x000109A3
	public Transform SoundEffects { get; private set; }

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x060016C9 RID: 5833 RVA: 0x000127AC File Offset: 0x000109AC
	// (set) Token: 0x060016CA RID: 5834 RVA: 0x000127B4 File Offset: 0x000109B4
	public Transform Music { get; private set; }

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x060016CB RID: 5835 RVA: 0x000127BD File Offset: 0x000109BD
	// (set) Token: 0x060016CC RID: 5836 RVA: 0x000127C5 File Offset: 0x000109C5
	public Transform Dialogue { get; private set; }

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x060016CD RID: 5837 RVA: 0x000127CE File Offset: 0x000109CE
	// (set) Token: 0x060016CE RID: 5838 RVA: 0x000127D6 File Offset: 0x000109D6
	public AudioListener AudioListener { get; private set; }

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x060016CF RID: 5839 RVA: 0x000127DF File Offset: 0x000109DF
	// (set) Token: 0x060016D0 RID: 5840 RVA: 0x000127E7 File Offset: 0x000109E7
	public AudioMixer AudioMixer { get; private set; }

	// Token: 0x060016D1 RID: 5841 RVA: 0x00080E20 File Offset: 0x0007F020
	public static AudioManager Create()
	{
		AudioManager audioManager = new GameObject("[Audio Manager]").AddComponent<AudioManager>();
		audioManager.AudioManagerParent = audioManager.transform;
		global::UnityEngine.Object.DontDestroyOnLoad(audioManager.gameObject);
		audioManager.AudioListener = audioManager.gameObject.AddComponent<AudioListener>();
		audioManager.AudioMixer = GameManager.Instance.AssetManager.GetAsset<AudioMixer>("GamePlay/Audio/TMGAudioMixer");
		audioManager.PooledAudioObjectsParent = new GameObject("[Pooled Audio Objects]").transform;
		audioManager.PooledAudioObjectsParent.SetParent(audioManager.AudioManagerParent);
		audioManager.Ambience = new GameObject("[Ambience]").transform;
		audioManager.Ambience.SetParent(audioManager.AudioManagerParent);
		audioManager.SoundEffects = new GameObject("[Sound Effects]").transform;
		audioManager.SoundEffects.SetParent(audioManager.AudioManagerParent);
		audioManager.Music = new GameObject("[Music]").transform;
		audioManager.Music.SetParent(audioManager.AudioManagerParent);
		audioManager.Dialogue = new GameObject("[Dialogue]").transform;
		audioManager.Dialogue.SetParent(audioManager.AudioManagerParent);
		return audioManager;
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x000127F0 File Offset: 0x000109F0
	private void FixedUpdate()
	{
		this.CheckDialogueQueue();
		this.CheckSoundEffectQueue();
		this.CheckForPooling();
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x00012804 File Offset: 0x00010A04
	public void ListenerSetActive(bool active)
	{
		this.AudioListener.enabled = active;
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x00080F40 File Offset: 0x0007F140
	private void CheckForPooling()
	{
		if (this.m_UsedAudioObjects.Count > 0)
		{
			for (int i = 0; i < this.m_UsedAudioObjects.Count; i++)
			{
				this.SendToPool(this.m_UsedAudioObjects[i]);
			}
			this.m_UsedAudioObjects.Clear();
		}
		if (this.m_UsedAudioObjects2D.Count > 0)
		{
			for (int j = 0; j < this.m_UsedAudioObjects2D.Count; j++)
			{
				this.SendToPool2D(this.m_UsedAudioObjects2D[j]);
			}
			this.m_UsedAudioObjects2D.Clear();
		}
	}

	// Token: 0x060016D5 RID: 5845 RVA: 0x00080FD0 File Offset: 0x0007F1D0
	private void CheckDialogueQueue()
	{
		if (this.m_DialogueQueue.Count <= 0)
		{
			return;
		}
		this.m_DialogueTimer += Time.deltaTime;
		if (this.m_DialogueTimer >= this.m_DialogueLength)
		{
			this.m_DialogueLength = 0f;
			this.m_DialogueTimer = 0f;
			this.m_ActiveDialogue = this.m_DialogueQueue[0];
			this.m_DialogueLength = this.m_ActiveDialogue.AudioClip.length - Time.fixedDeltaTime;
			this.m_DialogueQueue.RemoveAt(0);
			this.m_ActiveDialogue.IsQueued = false;
			this.m_ActiveDialogue.Play();
			this.m_ActiveDialogue.OnComplete += this.HandleActiveDialogueOnComplete;
		}
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x0008108C File Offset: 0x0007F28C
	private void HandleActiveDialogueOnComplete(object sender, EventArgs e)
	{
		AudioObject audioObject = (AudioObject)sender;
		if (audioObject == null)
		{
			return;
		}
		audioObject.OnComplete -= this.HandleActiveDialogueOnComplete;
		if (this.m_DialogueQueue.Count <= 0)
		{
			this.m_ActiveDialogue = null;
			this.m_DialogueLength = 0f;
		}
	}

	// Token: 0x060016D7 RID: 5847 RVA: 0x000810DC File Offset: 0x0007F2DC
	private void CheckSoundEffectQueue()
	{
		if (this.m_SoundEffectsQueue.Count <= 0)
		{
			return;
		}
		this.m_SoundEffectTimer += Time.deltaTime;
		if (this.m_SoundEffectTimer >= this.m_SoundEffectLength)
		{
			this.m_SoundEffectLength = 0f;
			this.m_SoundEffectTimer = 0f;
			AudioObject audioObject = this.m_SoundEffectsQueue[0];
			this.m_SoundEffectLength = ((this.m_SoundEffectsQueue.Count > 0) ? audioObject.AudioClip.length : 0f);
			this.m_SoundEffectsQueue.RemoveAt(0);
			audioObject.IsQueued = false;
			audioObject.Play();
		}
	}

	// Token: 0x060016D8 RID: 5848 RVA: 0x0008117C File Offset: 0x0007F37C
	public AudioObject PlayAtPosition(string _clipKey, Vector3 position, AudioObjectType audioType = AudioObjectType.SOUND_EFFECT, int _loops = 0, bool isQueued = false, Transform parent = null)
	{
		AudioClip asset = GameManager.Instance.AssetManager.GetAsset<AudioClip>(_clipKey);
		return this.PlayAtPosition(asset, position, audioType, _loops, isQueued, parent);
	}

	// Token: 0x060016D9 RID: 5849 RVA: 0x000811AC File Offset: 0x0007F3AC
	public AudioObject PlayAtPosition(AudioClip _clip, Vector3 position, AudioObjectType audioType = AudioObjectType.SOUND_EFFECT, int _loops = 0, bool isQueued = false, Transform parent = null)
	{
		AudioObject fromPool = this.GetFromPool();
		if (!fromPool.AudioSource)
		{
			fromPool.Dispose();
			return this.PlayAtPosition(_clip, position, audioType, _loops, isQueued, parent);
		}
		fromPool.AudioClip = _clip;
		fromPool.Loops = _loops;
		fromPool.AudioSource.loop = _loops == -1;
		fromPool.WorldPosition = position;
		fromPool.IsQueued = isQueued;
		fromPool.Parent = parent;
		fromPool.OnComplete += this.HandleAudioOnComplete;
		if (parent == null)
		{
			this.SetEditorParent(fromPool, audioType);
		}
		this.CheckMixerGroup(fromPool, audioType);
		if (isQueued)
		{
			if (audioType == AudioObjectType.SOUND_EFFECT)
			{
				this.m_SoundEffectsQueue.Add(fromPool);
			}
			else if (audioType == AudioObjectType.DIALOGUE)
			{
				this.m_DialogueQueue.Add(fromPool);
			}
		}
		else
		{
			fromPool.Play();
		}
		return fromPool;
	}

	// Token: 0x060016DA RID: 5850 RVA: 0x00081274 File Offset: 0x0007F474
	public AudioObject Play(string _clipKey, AudioObjectType audioType = AudioObjectType.SOUND_EFFECT, int _loops = 0, bool isQueued = false)
	{
		AudioClip asset = GameManager.Instance.AssetManager.GetAsset<AudioClip>(_clipKey);
		return this.Play(asset, audioType, _loops, isQueued);
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x000812A0 File Offset: 0x0007F4A0
	public AudioObject Play(AudioClip _clip, AudioObjectType audioType = AudioObjectType.SOUND_EFFECT, int _loops = 0, bool isQueued = false)
	{
		AudioObject fromPool2D = this.GetFromPool2D();
		fromPool2D.AudioClip = _clip;
		fromPool2D.Loops = _loops;
		fromPool2D.AudioSource.loop = _loops == -1;
		fromPool2D.IsQueued = isQueued;
		if (audioType == AudioObjectType.SOUND_EFFECT)
		{
			fromPool2D.AudioSource.outputAudioMixerGroup = this.AudioMixer.FindMatchingGroups("SFX")[0];
		}
		fromPool2D.OnComplete += this.HandleAudioOnComplete;
		this.SetEditorParent(fromPool2D, audioType);
		this.CheckMixerGroup(fromPool2D, audioType);
		if (isQueued)
		{
			if (audioType == AudioObjectType.SOUND_EFFECT)
			{
				this.m_SoundEffectsQueue.Add(fromPool2D);
			}
			else if (audioType == AudioObjectType.DIALOGUE)
			{
				this.m_DialogueQueue.Add(fromPool2D);
			}
		}
		else
		{
			fromPool2D.Play();
		}
		return fromPool2D;
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x0008134C File Offset: 0x0007F54C
	private void CheckMixerGroup(AudioObject audioObject, AudioObjectType audioType)
	{
		if (audioType == AudioObjectType.SOUND_EFFECT)
		{
			audioObject.AudioSource.outputAudioMixerGroup = this.AudioMixer.FindMatchingGroups("SFX")[0];
			return;
		}
		if (audioType == AudioObjectType.DIALOGUE)
		{
			audioObject.AudioSource.outputAudioMixerGroup = this.AudioMixer.FindMatchingGroups("Dialogue")[0];
			return;
		}
		if (audioType == AudioObjectType.MUSIC)
		{
			audioObject.AudioSource.outputAudioMixerGroup = this.AudioMixer.FindMatchingGroups("Music")[0];
		}
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x000813C0 File Offset: 0x0007F5C0
	public void PauseAll()
	{
		AudioSource[] array = Resources.FindObjectsOfTypeAll<AudioSource>();
		this.m_PausedAudioSources = new List<AudioSource>();
		foreach (AudioSource audioSource in array)
		{
			if (audioSource.isPlaying)
			{
				audioSource.Pause();
				this.m_PausedAudioSources.Add(audioSource);
			}
		}
	}

	// Token: 0x060016DE RID: 5854 RVA: 0x0008140C File Offset: 0x0007F60C
	public void ResumeAll()
	{
		if (this.m_PausedAudioSources != null)
		{
			for (int i = 0; i < this.m_PausedAudioSources.Count; i++)
			{
				this.m_PausedAudioSources[i].UnPause();
			}
			this.m_PausedAudioSources.Clear();
		}
		this.m_PausedAudioSources = null;
	}

	// Token: 0x060016DF RID: 5855 RVA: 0x00002482 File Offset: 0x00000682
	private void SetEditorParent(AudioObject audioObject, AudioObjectType audioType)
	{
	}

	// Token: 0x060016E0 RID: 5856 RVA: 0x0008145C File Offset: 0x0007F65C
	private AudioObject GetFromPool()
	{
		if (this.m_AudioObjectPool.Count <= 0)
		{
			this.m_AudioObjectPool.Add(this.CreateAudioObject3D());
		}
		AudioObject audioObject = this.m_AudioObjectPool[0];
		this.m_AudioObjectPool.Remove(audioObject);
		return audioObject;
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x000814A4 File Offset: 0x0007F6A4
	private AudioObject GetFromPool2D()
	{
		if (this.m_AudioObject2DPool.Count <= 0)
		{
			this.m_AudioObject2DPool.Add(this.CreateAudioObject2D());
		}
		AudioObject audioObject = this.m_AudioObject2DPool[0];
		this.m_AudioObject2DPool.Remove(audioObject);
		return audioObject;
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x00012812 File Offset: 0x00010A12
	private void SendToPool(AudioObject audioObject)
	{
		if (audioObject != null)
		{
			audioObject.Clear();
			this.m_AudioObjectPool.Add(audioObject);
		}
	}

	// Token: 0x060016E3 RID: 5859 RVA: 0x0001282F File Offset: 0x00010A2F
	private void SendToPool2D(AudioObject audioObject)
	{
		if (audioObject != null)
		{
			audioObject.Clear();
			this.m_AudioObject2DPool.Add(audioObject);
		}
	}

	// Token: 0x060016E4 RID: 5860 RVA: 0x000814EC File Offset: 0x0007F6EC
	private void HandleAudioOnComplete(object sender, EventArgs e)
	{
		AudioObject audioObject = (AudioObject)sender;
		audioObject.OnComplete -= this.HandleAudioOnComplete;
		if (base.IsDisposed)
		{
			return;
		}
		if (this.m_UsedAudioObjects != null && !audioObject.Is2D)
		{
			this.m_UsedAudioObjects.Add(audioObject);
			return;
		}
		if (this.m_UsedAudioObjects2D != null && audioObject.Is2D)
		{
			this.m_UsedAudioObjects2D.Add(audioObject);
		}
	}

	// Token: 0x060016E5 RID: 5861 RVA: 0x0001284C File Offset: 0x00010A4C
	private AudioObject CreateAudioObject2D()
	{
		return AudioObject.Create("GamePlay/Audio/AudioObject_2D", true);
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x00012859 File Offset: 0x00010A59
	private AudioObject CreateAudioObject3D()
	{
		return AudioObject.Create("GamePlay/Audio/AudioObject_3D", false);
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x00081554 File Offset: 0x0007F754
	public AudioClip Combine(List<AudioClip> clips)
	{
		int num = 48000;
		if (clips == null || clips.Count == 0)
		{
			return null;
		}
		int num2 = 0;
		for (int i = 0; i < clips.Count; i++)
		{
			if (!(clips[i] == null))
			{
				num2 += clips[i].samples;
				num = clips[i].frequency;
			}
		}
		float[] array = new float[num2];
		num2 = 0;
		for (int j = 0; j < clips.Count; j++)
		{
			if (!(clips[j] == null))
			{
				float[] array2 = new float[clips[j].samples];
				clips[j].GetData(array2, 0);
				array2.CopyTo(array, num2);
				num2 += array2.Length;
			}
		}
		if (num2 == 0)
		{
			return null;
		}
		AudioClip audioClip = AudioClip.Create("Combine", num2, 1, num, false);
		audioClip.SetData(array, 0);
		return audioClip;
	}

	// Token: 0x060016E8 RID: 5864 RVA: 0x00081634 File Offset: 0x0007F834
	public void ClearAll()
	{
		for (int i = 0; i < this.m_UsedAudioObjects.Count; i++)
		{
			this.SendToPool(this.m_UsedAudioObjects[i]);
		}
		this.m_UsedAudioObjects.Clear();
		for (int j = 0; j < this.m_SoundEffectsQueue.Count; j++)
		{
			this.SendToPool(this.m_SoundEffectsQueue[j]);
		}
		this.m_SoundEffectsQueue.Clear();
		for (int k = 0; k < this.m_DialogueQueue.Count; k++)
		{
			this.SendToPool(this.m_DialogueQueue[k]);
		}
		this.m_DialogueQueue.Clear();
	}

	// Token: 0x060016E9 RID: 5865 RVA: 0x000816DC File Offset: 0x0007F8DC
	public void ClearCurrentDialogueQueue()
	{
		this.m_DialogueLength = 0f;
		this.m_DialogueTimer = 0f;
		if (this.m_ActiveDialogue != null)
		{
			this.m_ActiveDialogue.IsQueued = false;
			this.m_ActiveDialogue.Clear();
			this.m_ActiveDialogue = null;
		}
		for (int i = 0; i < this.m_DialogueQueue.Count; i++)
		{
			this.SendToPool(this.m_DialogueQueue[i]);
		}
		this.m_DialogueQueue.Clear();
	}

	// Token: 0x060016EA RID: 5866 RVA: 0x00081760 File Offset: 0x0007F960
	private void DisposeAll()
	{
		if (this.m_AudioObjectPool != null)
		{
			for (int i = this.m_AudioObjectPool.Count - 1; i >= 0; i--)
			{
				this.m_AudioObjectPool[i].Dispose();
			}
			this.m_AudioObjectPool.Clear();
		}
		if (this.m_AudioObject2DPool != null)
		{
			for (int j = this.m_AudioObject2DPool.Count - 1; j >= 0; j--)
			{
				this.m_AudioObject2DPool[j].Dispose();
			}
			this.m_AudioObject2DPool.Clear();
		}
		if (this.m_UsedAudioObjects != null)
		{
			for (int k = this.m_UsedAudioObjects.Count - 1; k >= 0; k--)
			{
				this.m_UsedAudioObjects[k].Dispose();
			}
			this.m_UsedAudioObjects.Clear();
		}
		if (this.m_SoundEffectsQueue != null)
		{
			for (int l = this.m_SoundEffectsQueue.Count - 1; l >= 0; l--)
			{
				this.m_SoundEffectsQueue[l].Dispose();
			}
			this.m_SoundEffectsQueue.Clear();
		}
		if (this.m_DialogueQueue != null)
		{
			for (int m = this.m_DialogueQueue.Count - 1; m >= 0; m--)
			{
				this.m_DialogueQueue[m].Dispose();
			}
			this.m_DialogueQueue.Clear();
		}
		AudioObject[] array = global::UnityEngine.Object.FindObjectsOfType<AudioObject>();
		for (int n = array.Length - 1; n >= 0; n--)
		{
			array[n].Dispose();
		}
	}

	// Token: 0x060016EB RID: 5867 RVA: 0x00012866 File Offset: 0x00010A66
	protected override void OnDisposed()
	{
		this.DisposeAll();
		this.m_AudioObjectPool = null;
		this.m_AudioObject2DPool = null;
		this.m_UsedAudioObjects = null;
		this.m_SoundEffectsQueue = null;
		this.m_DialogueQueue = null;
		this.m_ActiveDialogue = null;
		base.OnDisposed();
	}

	// Token: 0x060016EC RID: 5868 RVA: 0x000818C8 File Offset: 0x0007FAC8
	public void RefreshAllAudioSources()
	{
		GameObject[] array = (from go in global::UnityEngine.Object.FindObjectsOfType<GameObject>()
			where go.name.Contains("AudioEventTriggers")
			select go).ToArray<GameObject>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
			array[i].SetActive(true);
			GameManager.Instance.AudioTypeChanged = false;
		}
	}

	// Token: 0x04001423 RID: 5155
	private const string MASTER_MIXER_GROUP = "Master";

	// Token: 0x04001424 RID: 5156
	private const string SFX_MIXER_GROUP = "SFX";

	// Token: 0x04001425 RID: 5157
	private const string MUSIC_MIXER_GROUP = "Music";

	// Token: 0x04001426 RID: 5158
	private const string DIALOGUE_MIXER_GROUP = "Dialogue";

	// Token: 0x0400142F RID: 5167
	private List<AudioObject> m_AudioObjectPool = new List<AudioObject>();

	// Token: 0x04001430 RID: 5168
	private List<AudioObject> m_UsedAudioObjects = new List<AudioObject>();

	// Token: 0x04001431 RID: 5169
	private List<AudioObject> m_AudioObject2DPool = new List<AudioObject>();

	// Token: 0x04001432 RID: 5170
	private List<AudioObject> m_UsedAudioObjects2D = new List<AudioObject>();

	// Token: 0x04001433 RID: 5171
	private List<AudioObject> m_SoundEffectsQueue = new List<AudioObject>();

	// Token: 0x04001434 RID: 5172
	private List<AudioObject> m_DialogueQueue = new List<AudioObject>();

	// Token: 0x04001435 RID: 5173
	private AudioObject m_ActiveDialogue;

	// Token: 0x04001436 RID: 5174
	private float m_DialogueTimer;

	// Token: 0x04001437 RID: 5175
	private float m_DialogueLength;

	// Token: 0x04001438 RID: 5176
	private float m_SoundEffectTimer;

	// Token: 0x04001439 RID: 5177
	private float m_SoundEffectLength;

	// Token: 0x0400143A RID: 5178
	private List<AudioSource> m_PausedAudioSources;
}

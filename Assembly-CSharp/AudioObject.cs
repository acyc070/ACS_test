using System;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

// Token: 0x02000184 RID: 388
public class AudioObject : TMGMonoBehaviour
{
	// Token: 0x1400005A RID: 90
	// (add) Token: 0x06000F9A RID: 3994 RVA: 0x00069F04 File Offset: 0x00068104
	// (remove) Token: 0x06000F9B RID: 3995 RVA: 0x00069F3C File Offset: 0x0006813C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnComplete;

	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x06000F9C RID: 3996 RVA: 0x0000D532 File Offset: 0x0000B732
	// (set) Token: 0x06000F9D RID: 3997 RVA: 0x0000D53A File Offset: 0x0000B73A
	public AudioSource AudioSource { get; private set; }

	// Token: 0x170000A9 RID: 169
	// (get) Token: 0x06000F9E RID: 3998 RVA: 0x0000D543 File Offset: 0x0000B743
	// (set) Token: 0x06000F9F RID: 3999 RVA: 0x0000D54B File Offset: 0x0000B74B
	public bool Is2D { get; private set; }

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0000D554 File Offset: 0x0000B754
	// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x0000D561 File Offset: 0x0000B761
	public Vector3 WorldPosition
	{
		get
		{
			return base.transform.position;
		}
		set
		{
			base.transform.position = value;
		}
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x0000D56F File Offset: 0x0000B76F
	// (set) Token: 0x06000FA3 RID: 4003 RVA: 0x0000D57C File Offset: 0x0000B77C
	public Vector3 LocalPosition
	{
		get
		{
			return base.transform.localPosition;
		}
		set
		{
			base.transform.localPosition = value;
		}
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x0000D58A File Offset: 0x0000B78A
	// (set) Token: 0x06000FA5 RID: 4005 RVA: 0x0000D597 File Offset: 0x0000B797
	public Transform Parent
	{
		get
		{
			return base.transform.parent;
		}
		set
		{
			base.transform.SetParent(value);
		}
	}

	// Token: 0x170000AD RID: 173
	// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0000D5A5 File Offset: 0x0000B7A5
	private AudioManager m_AudioManager
	{
		get
		{
			return GameManager.Instance.AudioManager;
		}
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x00069F74 File Offset: 0x00068174
	public static AudioObject Create(string objectType, bool is2D = false)
	{
		AudioObject audioObject = GameManager.Instance.AssetManager.CreateAsset<AudioObject>(objectType);
		global::UnityEngine.Object.DontDestroyOnLoad(audioObject.gameObject);
		audioObject.Is2D = is2D;
		audioObject.AudioSource = audioObject.GetComponent<AudioSource>();
		audioObject.AudioSource.playOnAwake = false;
		audioObject.AudioSource.mute = false;
		return audioObject;
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x00069FCC File Offset: 0x000681CC
	private void FixedUpdate()
	{
		if (this.AudioSource.isPlaying || this.IsQueued || this.m_Stopped)
		{
			return;
		}
		this.m_TimesPlayed++;
		if (this.Loops == -1 || (this.Loops > 0 && this.m_TimesPlayed < this.Loops))
		{
			this.m_Stopped = false;
			this.AudioSource.time = 0f;
			this.AudioSource.Play();
		}
		else
		{
			this.Stop();
		}
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0000D5B1 File Offset: 0x0000B7B1
	public void Play()
	{
		this.m_Stopped = false;
		this.AudioSource.clip = this.AudioClip;
		this.m_TimesPlayed = 0;
		this.AudioSource.time = 0f;
		this.AudioSource.Play();
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0000D5ED File Offset: 0x0000B7ED
	public void Pause()
	{
		this.m_PauseTime = this.AudioSource.time;
		this.AudioSource.Pause();
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x0000D60B File Offset: 0x0000B80B
	public void Resume()
	{
		this.AudioSource.time = this.m_PauseTime;
		this.AudioSource.Play();
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x0000D629 File Offset: 0x0000B829
	public void Stop()
	{
		this.m_Stopped = true;
		if (this.AudioSource != null)
		{
			this.AudioSource.Stop();
			this.OnComplete.Send(this);
		}
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x0006A064 File Offset: 0x00068264
	public void Clear()
	{
		this.OnComplete = null;
		if (this.AudioSource)
		{
			this.AudioSource.clip = null;
			this.AudioSource.volume = 1f;
		}
		this.AudioClip = null;
		this.Parent = null;
	}

	// Token: 0x06000FAE RID: 4014 RVA: 0x0006A0B4 File Offset: 0x000682B4
	protected override void OnDisposed()
	{
		this.OnComplete = null;
		this.AudioClip = null;
		if (this.AudioSource != null)
		{
			this.AudioSource.Stop();
			this.AudioSource.clip = null;
			this.AudioSource = null;
		}
		base.OnDisposed();
	}

	// Token: 0x04000CDD RID: 3293
	public const string DEFAULT_NAME = "[POOLED AUDIO OBJECT]";

	// Token: 0x04000CDF RID: 3295
	public AudioClip AudioClip;

	// Token: 0x04000CE0 RID: 3296
	public int Loops;

	// Token: 0x04000CE1 RID: 3297
	public bool IsQueued;

	// Token: 0x04000CE3 RID: 3299
	private int m_TimesPlayed;

	// Token: 0x04000CE4 RID: 3300
	private float m_PauseTime;

	// Token: 0x04000CE5 RID: 3301
	private bool m_Stopped;
}

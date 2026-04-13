using System;
using UnityEngine;

// Token: 0x02000094 RID: 148
public class CH2PipeOrganController : BaseController
{
	// Token: 0x06000548 RID: 1352 RVA: 0x00035598 File Offset: 0x00033798
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_PipeOrganAudioClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Instruments/PipeOrgan/");
		this.m_PipeOrganInteract.SetActive(true);
		this.m_PipeOrganInteract.OnInteracted += this.HandlePipeOrganOnInteracted;
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x000355E8 File Offset: 0x000337E8
	private void HandlePipeOrganOnInteracted(object sender, EventArgs e)
	{
		this.m_PipeOrganInteract.SetActive(false);
		this.m_PipeOrganInteract.OnInteracted -= this.HandlePipeOrganOnInteracted;
		this.PlayPipeOrganAudio();
		if (!this.m_HasAchievement)
		{
			this.m_InteractCount++;
			if (this.m_InteractCount >= this.m_InteractMax)
			{
				this.m_HasAchievement = true;
				GameManager.Instance.AchievementManager.SetAchievement(AchievementName.JOHNNYS_BROKEN_HEART);
			}
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00006D2E File Offset: 0x00004F2E
	private void HandlePipeOrganAudioOnComplete(object sender, EventArgs e)
	{
		this.m_PipeOrganAudioObject.OnComplete -= this.HandlePipeOrganAudioOnComplete;
		this.m_PipeOrganInteract.SetActive(true);
		this.m_PipeOrganInteract.OnInteracted += this.HandlePipeOrganOnInteracted;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00035660 File Offset: 0x00033860
	private void PlayPipeOrganAudio()
	{
		if (this.m_PipeOrganAudioClips == null || this.m_PipeOrganAudioClips.Length <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_PipeOrganAudioClips.Length);
		AudioClip audioClip = this.m_PipeOrganAudioClips[num];
		this.m_PipeOrganAudioObject = null;
		this.m_PipeOrganAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioClip, this.m_AudioPosition.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_PipeOrganAudioObject.OnComplete += this.HandlePipeOrganAudioOnComplete;
		this.m_PipeOrganAudioClips[num] = this.m_PipeOrganAudioClips[0];
		this.m_PipeOrganAudioClips[0] = audioClip;
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x000356FC File Offset: 0x000338FC
	protected override void OnDisposed()
	{
		if (this.m_PipeOrganInteract != null)
		{
			this.m_PipeOrganInteract.OnInteracted -= this.HandlePipeOrganOnInteracted;
		}
		if (this.m_PipeOrganAudioObject != null)
		{
			this.m_PipeOrganAudioObject.OnComplete -= this.HandlePipeOrganAudioOnComplete;
			this.m_PipeOrganAudioObject.Clear();
			this.m_PipeOrganAudioObject = null;
		}
		this.m_PipeOrganAudioClips = null;
		base.OnDisposed();
	}

	// Token: 0x040003D0 RID: 976
	[Header("Transforms")]
	[SerializeField]
	private Transform m_AudioPosition;

	// Token: 0x040003D1 RID: 977
	[Header("Interactable")]
	[SerializeField]
	private Interactable m_PipeOrganInteract;

	// Token: 0x040003D2 RID: 978
	private AudioObject m_PipeOrganAudioObject;

	// Token: 0x040003D3 RID: 979
	private AudioClip[] m_PipeOrganAudioClips;

	// Token: 0x040003D4 RID: 980
	private int m_InteractCount;

	// Token: 0x040003D5 RID: 981
	private int m_InteractMax = 5;

	// Token: 0x040003D6 RID: 982
	private bool m_HasAchievement;
}

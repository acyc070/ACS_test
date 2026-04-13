using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000182 RID: 386
public class AudioLog : Interactable
{
	// Token: 0x06000F8A RID: 3978 RVA: 0x00069AD8 File Offset: 0x00067CD8
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_OnClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Cassette_Player_Turn_On_01");
		this.m_OffClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Cassette_Player_Turn_Off_01");
		this.m_RunningClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Cassette_Player_Run_01");
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x00069B2C File Offset: 0x00067D2C
	public void Play(string audioKey, Action onComplete = null)
	{
		this.m_OnComplete = onComplete;
		this.m_CassettePlayer.localScale = Vector3.one;
		this.m_CassettePlayer.DOKill(false);
		this.m_CassettePlayer.DOScale(1.01f, 0.25f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_OnClip, this.m_CassettePlayer.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_RunningAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_RunningClip, this.m_CassettePlayer.position, AudioObjectType.SOUND_EFFECT, -1, false, null);
		this.m_AudioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioKey, this.m_CassettePlayer.position, AudioObjectType.DIALOGUE, 0, false, null);
		this.m_AudioObject.OnComplete += this.HandleAudioObjectOnComplete;
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x00069C0C File Offset: 0x00067E0C
	public void Play(AudioClip audioClip, Action onComplete = null)
	{
		this.m_OnComplete = onComplete;
		base.SetActive(false);
		this.m_CassettePlayer.localScale = Vector3.one;
		this.m_CassettePlayer.DOKill(false);
		this.m_CassettePlayer.DOScale(1.01f, 0.25f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_OnClip, this.m_CassettePlayer.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_RunningAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_RunningClip, this.m_CassettePlayer.position, AudioObjectType.SOUND_EFFECT, -1, false, null);
		this.m_AudioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioClip, this.m_CassettePlayer.position, AudioObjectType.DIALOGUE, 0, false, null);
		this.m_AudioObject.OnComplete += this.HandleAudioObjectOnComplete;
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x00069CF4 File Offset: 0x00067EF4
	private void HandleAudioObjectOnComplete(object sender, EventArgs e)
	{
		this.m_AudioObject.OnComplete -= this.HandleAudioObjectOnComplete;
		this.m_AudioObject = null;
		this.m_RunningAudioObject.Clear();
		this.m_RunningAudioObject = null;
		this.m_CassettePlayer.DOKill(false);
		this.m_CassettePlayer.DOScale(1f, 0.25f).SetEase(Ease.InOutQuad);
		if (!base.isSingleInteraction)
		{
			base.SetActive(true);
		}
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_OffClip, this.m_CassettePlayer.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		base.StartCoroutine(this.DelayOnComplete());
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x00069DA0 File Offset: 0x00067FA0
	private IEnumerator DelayOnComplete()
	{
		yield return new WaitForSeconds(0.5f);
		if (this.m_OnComplete != null)
		{
			this.m_OnComplete();
		}
		yield break;
	}

	// Token: 0x06000F8F RID: 3983 RVA: 0x00069DBC File Offset: 0x00067FBC
	public int SetID(int CurrentIDCount)
	{
		if (this.ID != -1)
		{
			return this.ID;
		}
		return this.ID = ++CurrentIDCount;
	}

	// Token: 0x06000F90 RID: 3984 RVA: 0x0000D4FB File Offset: 0x0000B6FB
	public int GetID()
	{
		if (this.ID != -1)
		{
			return this.ID;
		}
		return -1;
	}

	// Token: 0x06000F91 RID: 3985 RVA: 0x0000D511 File Offset: 0x0000B711
	public void ResetID()
	{
		this.ID = -1;
	}

	// Token: 0x06000F92 RID: 3986 RVA: 0x00069DEC File Offset: 0x00067FEC
	protected override void OnDisposed()
	{
		this.m_CassettePlayer.DOKill(false);
		if (this.m_AudioObject != null)
		{
			this.m_AudioObject.OnComplete -= this.HandleAudioObjectOnComplete;
			this.m_AudioObject.Clear();
			this.m_AudioObject = null;
		}
		if (this.m_RunningAudioObject != null)
		{
			this.m_RunningAudioObject.Clear();
			this.m_RunningAudioObject = null;
		}
		this.m_OnComplete = null;
		this.m_OnClip = null;
		this.m_OffClip = null;
		this.m_RunningClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000CD0 RID: 3280
	[Header("ID")]
	[SerializeField]
	private int ID = -1;

	// Token: 0x04000CD1 RID: 3281
	[Header("Transforms")]
	[SerializeField]
	private Transform m_CassettePlayer;

	// Token: 0x04000CD2 RID: 3282
	private AudioObject m_RunningAudioObject;

	// Token: 0x04000CD3 RID: 3283
	private AudioObject m_AudioObject;

	// Token: 0x04000CD4 RID: 3284
	private Action m_OnComplete;

	// Token: 0x04000CD5 RID: 3285
	private AudioClip m_OnClip;

	// Token: 0x04000CD6 RID: 3286
	private AudioClip m_OffClip;

	// Token: 0x04000CD7 RID: 3287
	private AudioClip m_RunningClip;
}

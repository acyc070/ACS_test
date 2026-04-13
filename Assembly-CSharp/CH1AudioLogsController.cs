using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
public class CH1AudioLogsController : BaseController
{
	// Token: 0x0600037F RID: 895 RVA: 0x0002B140 File Offset: 0x00029340
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Wally_01 = GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/DIA/CH1/AudioLogs/ch1_audiolog_wally");
		this.m_Thomas_01 = GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/DIA/CH1/AudioLogs/ch1_audiolog_thomas");
		this.m_AudioLogWally01.OnInteracted += this.HandleAudioLogWally01OnInteracted;
		this.m_AudioLogThomas01.OnInteracted += this.HandleAudioLogThomas01OnInteracted;
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0002B1B8 File Offset: 0x000293B8
	private void HandleAudioLogWally01OnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogWally01.SetActive(false);
		this.m_AudioLogWally01.OnInteracted -= this.HandleAudioLogWally01OnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogWally01.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_WALLY",
			Log = "AudioLog/WALLY_OFFERING_TO_THE_DOGS",
			LogWorldPosition = this.m_AudioLogWally01.transform.position
		}, this.m_AudioLogWally01, this.m_Wally_01, new Action(this.HandleAudioWally01OnComplete));
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0002B254 File Offset: 0x00029454
	private void HandleAudioWally01OnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_Wally_01)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogWally01.SetActive(true);
		this.m_AudioLogWally01.OnInteracted += this.HandleAudioLogWally01OnInteracted;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0002B2A8 File Offset: 0x000294A8
	private void HandleAudioLogThomas01OnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogThomas01.SetActive(false);
		this.m_AudioLogThomas01.OnInteracted -= this.HandleAudioLogThomas01OnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogThomas01.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_THOMAS",
			Log = "AudioLog/THOMAS_DIRTY_JOB",
			LogWorldPosition = this.m_AudioLogThomas01.transform.position
		}, this.m_AudioLogThomas01, this.m_Thomas_01, new Action(this.HandleAudioThomas01OnComplete));
	}

	// Token: 0x06000383 RID: 899 RVA: 0x0002B344 File Offset: 0x00029544
	private void HandleAudioThomas01OnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_Thomas_01)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogThomas01.SetActive(true);
		this.m_AudioLogThomas01.OnInteracted += this.HandleAudioLogThomas01OnInteracted;
	}

	// Token: 0x06000384 RID: 900 RVA: 0x000054AD File Offset: 0x000036AD
	private void PlayAudioLog(AudioLogDataVO vo, AudioLog audioLog, AudioClip audioClip, Action onComplete)
	{
		this.AudioControllerReset();
		this.m_ActiveAudioClip = audioClip;
		this.m_AudioLogController = GameManager.Instance.UIManager.Show<AudioLogModalController>("UI/Modals/AudioLogModalController", "MODAL", vo);
		audioLog.Play(this.m_ActiveAudioClip, onComplete);
	}

	// Token: 0x06000385 RID: 901 RVA: 0x000054EA File Offset: 0x000036EA
	private void AudioControllerReset()
	{
		if (this.m_AudioLogController != null)
		{
			this.m_AudioLogController.Dispose();
			this.m_AudioLogController = null;
		}
	}

	// Token: 0x06000386 RID: 902 RVA: 0x0002B398 File Offset: 0x00029598
	private void TryAudioLogAchievement(int id)
	{
		if (!GameManager.Instance.GameData.CH1AchievementData.AudioLogs.Contains(id))
		{
			GameManager.Instance.GameData.CH1AchievementData.AudioLogs.Add(id);
		}
		if (GameManager.Instance.GameData.CH1AchievementData.AudioLogs.Count >= 2)
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.THE_PAST_SPEAKS);
		}
		AudioLogAllAchievements.Check();
	}

	// Token: 0x06000387 RID: 903 RVA: 0x0000550F File Offset: 0x0000370F
	protected override void OnDisposed()
	{
		this.AudioControllerReset();
		this.m_ActiveAudioClip = null;
		this.m_Wally_01 = null;
		this.m_Thomas_01 = null;
		base.OnDisposed();
	}

	// Token: 0x040001EC RID: 492
	[Header("Interactables")]
	[SerializeField]
	private AudioLog m_AudioLogWally01;

	// Token: 0x040001ED RID: 493
	[SerializeField]
	private AudioLog m_AudioLogThomas01;

	// Token: 0x040001EE RID: 494
	private AudioLogModalController m_AudioLogController;

	// Token: 0x040001EF RID: 495
	private AudioClip m_ActiveAudioClip;

	// Token: 0x040001F0 RID: 496
	private AudioClip m_Wally_01;

	// Token: 0x040001F1 RID: 497
	private AudioClip m_Thomas_01;
}

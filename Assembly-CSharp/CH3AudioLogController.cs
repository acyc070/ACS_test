using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class CH3AudioLogController : BaseController
{
	// Token: 0x06000644 RID: 1604 RVA: 0x0003AFC0 File Offset: 0x000391C0
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_AudioClipGrantGenius = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_grant_thegeniusupstairs");
		this.m_AudioClipShawnCrooked = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_shawn_crookedsmiles");
		this.m_AudioClipNormanTrouble = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_norman_lookingfortrouble");
		this.m_AudioClipWallySmile = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_wally_crackasmile");
		this.m_AudioClipSusieApart = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_susie_everythingiscomingapart");
		this.m_AudioClipSusieLunch = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_susie_lunchwithjoey");
		this.m_AudioClipJoeyDrewBelief = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_joeydrew_timetobelieve");
		this.m_AudioClipHenry = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_henry");
		this.m_AudioClipThomams = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_Thomas_CuttingCorners");
		this.m_AudioClipWallyThomas = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/AudioLogs/CH3_AudioLog_Wally_Thomas");
		this.m_AudioLogGrantGenius.OnInteracted += this.HandleAudioLogGrantGeniusOnInteracted;
		this.m_AudioLogShawnCrooked.OnInteracted += this.HandleAudioLogShawnCrookedOnInteracted;
		this.m_AudioLogNormanTrouble.OnInteracted += this.HandleAudioLogNormanTroubleOnInteracted;
		this.m_AudioLogWallySmile.OnInteracted += this.HandleAudioLogWallySmileOnInteracted;
		this.m_AudioLogSusieApart.OnInteracted += this.HandleAudioLogSusieApartOnInteracted;
		this.m_AudioLogSusieLunch.OnInteracted += this.HandleAudioLogSusieLunchOnInteracted;
		this.m_AudioLogJoeyDrewBelief.OnInteracted += this.HandleAudioLogJoeyDrewBeliefOnInteracted;
		this.m_AudioLogHenry.OnInteracted += this.HandleAudioLogHenryOnInteracted;
		this.m_AudioLogThomas.OnInteracted += this.HandleAudioLogThomasOnInteracted;
		this.m_AudioLogWallyThomas.OnInteracted += this.HandleAudioLogWallyThomasOnInteracted;
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x0003B18C File Offset: 0x0003938C
	private void HandleAudioLogGrantGeniusOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogGrantGenius.SetActive(false);
		this.m_AudioLogGrantGenius.OnInteracted -= this.HandleAudioLogGrantGeniusOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogGrantGenius.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_GRANT",
			Log = "AudioLog/GRANT_THE_GENIUS_UPSTAIRS",
			LogWorldPosition = this.m_AudioLogGrantGenius.transform.position
		}, this.m_AudioLogGrantGenius, this.m_AudioClipGrantGenius, new Action(this.HandleAudioLogGrantGeniusOnComplete));
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0000789E File Offset: 0x00005A9E
	private void HandleAudioLogGrantGeniusOnComplete()
	{
		this.CheckClip(this.m_AudioClipGrantGenius);
		this.m_AudioLogGrantGenius.SetActive(true);
		this.m_AudioLogGrantGenius.OnInteracted += this.HandleAudioLogGrantGeniusOnInteracted;
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x0003B228 File Offset: 0x00039428
	private void HandleAudioLogShawnCrookedOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogShawnCrooked.SetActive(false);
		this.m_AudioLogShawnCrooked.OnInteracted -= this.HandleAudioLogShawnCrookedOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogShawnCrooked.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SHAWN",
			Log = "AudioLog/SHAWN_CROOKED_SMILES",
			LogWorldPosition = this.m_AudioLogShawnCrooked.transform.position
		}, this.m_AudioLogShawnCrooked, this.m_AudioClipShawnCrooked, new Action(this.HandleAudioLogShawnCrookedOnComplete));
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x000078CF File Offset: 0x00005ACF
	private void HandleAudioLogShawnCrookedOnComplete()
	{
		this.CheckClip(this.m_AudioClipShawnCrooked);
		this.m_AudioLogShawnCrooked.SetActive(true);
		this.m_AudioLogShawnCrooked.OnInteracted += this.HandleAudioLogShawnCrookedOnInteracted;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x0003B2C4 File Offset: 0x000394C4
	private void HandleAudioLogNormanTroubleOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogNormanTrouble.SetActive(false);
		this.m_AudioLogNormanTrouble.OnInteracted -= this.HandleAudioLogNormanTroubleOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogNormanTrouble.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_NORMAN",
			Log = "AudioLog/NORMAN_LOOKING_FOR_TROUBLE",
			LogWorldPosition = this.m_AudioLogNormanTrouble.transform.position
		}, this.m_AudioLogNormanTrouble, this.m_AudioClipNormanTrouble, new Action(this.HandleAudioLogNormanTroubleOnComplete));
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x00007900 File Offset: 0x00005B00
	private void HandleAudioLogNormanTroubleOnComplete()
	{
		this.CheckClip(this.m_AudioClipNormanTrouble);
		this.m_AudioLogNormanTrouble.SetActive(true);
		this.m_AudioLogNormanTrouble.OnInteracted += this.HandleAudioLogNormanTroubleOnInteracted;
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0003B360 File Offset: 0x00039560
	private void HandleAudioLogWallySmileOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogWallySmile.SetActive(false);
		this.m_AudioLogWallySmile.OnInteracted -= this.HandleAudioLogWallySmileOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogWallySmile.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_WALLY",
			Log = "AudioLog/WALLY_CRACK_A_SMILE",
			LogWorldPosition = this.m_AudioLogWallySmile.transform.position
		}, this.m_AudioLogWallySmile, this.m_AudioClipWallySmile, new Action(this.HandleAudioLogWallySmileOnComplete));
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x00007931 File Offset: 0x00005B31
	private void HandleAudioLogWallySmileOnComplete()
	{
		this.CheckClip(this.m_AudioClipWallySmile);
		this.m_AudioLogWallySmile.SetActive(true);
		this.m_AudioLogWallySmile.OnInteracted += this.HandleAudioLogWallySmileOnInteracted;
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0003B3FC File Offset: 0x000395FC
	private void HandleAudioLogSusieApartOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogSusieApart.SetActive(false);
		this.m_AudioLogSusieApart.OnInteracted -= this.HandleAudioLogSusieApartOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogSusieApart.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SUSIE",
			Log = "AudioLog/SUSIE_EVERYTHING_IS_COMING_APART",
			LogWorldPosition = this.m_AudioLogSusieApart.transform.position
		}, this.m_AudioLogSusieApart, this.m_AudioClipSusieApart, new Action(this.HandleAudioLogSusieApartOnComplete));
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x00007962 File Offset: 0x00005B62
	private void HandleAudioLogSusieApartOnComplete()
	{
		this.CheckClip(this.m_AudioClipSusieApart);
		this.m_AudioLogSusieApart.SetActive(true);
		this.m_AudioLogSusieApart.OnInteracted += this.HandleAudioLogSusieApartOnInteracted;
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0003B498 File Offset: 0x00039698
	private void HandleAudioLogSusieLunchOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogSusieLunch.SetActive(false);
		this.m_AudioLogSusieLunch.OnInteracted -= this.HandleAudioLogSusieLunchOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogSusieLunch.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SUSIE",
			Log = "AudioLog/SUSIE_LUNCH_WITH_JOEY",
			LogWorldPosition = this.m_AudioLogSusieLunch.transform.position
		}, this.m_AudioLogSusieLunch, this.m_AudioClipSusieLunch, new Action(this.HandleAudioLogSusieLunchOnComplete));
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x00007993 File Offset: 0x00005B93
	private void HandleAudioLogSusieLunchOnComplete()
	{
		this.CheckClip(this.m_AudioClipSusieLunch);
		this.m_AudioLogSusieLunch.SetActive(true);
		this.m_AudioLogSusieLunch.OnInteracted += this.HandleAudioLogSusieLunchOnInteracted;
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0003B534 File Offset: 0x00039734
	private void HandleAudioLogJoeyDrewBeliefOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogJoeyDrewBelief.SetActive(false);
		this.m_AudioLogJoeyDrewBelief.OnInteracted -= this.HandleAudioLogJoeyDrewBeliefOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogJoeyDrewBelief.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_JOEY",
			Log = "AudioLog/JOEY_BELIEF",
			LogWorldPosition = this.m_AudioLogJoeyDrewBelief.transform.position
		}, this.m_AudioLogJoeyDrewBelief, this.m_AudioClipJoeyDrewBelief, new Action(this.HandleAudioLogJoeyDrewBeliefOnComplete));
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x000079C4 File Offset: 0x00005BC4
	private void HandleAudioLogJoeyDrewBeliefOnComplete()
	{
		this.CheckClip(this.m_AudioClipJoeyDrewBelief);
		this.m_AudioLogJoeyDrewBelief.SetActive(true);
		this.m_AudioLogJoeyDrewBelief.OnInteracted += this.HandleAudioLogJoeyDrewBeliefOnInteracted;
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0003B5D0 File Offset: 0x000397D0
	private void HandleAudioLogHenryOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogHenry.SetActive(false);
		this.m_AudioLogHenry.OnInteracted -= this.HandleAudioLogHenryOnInteracted;
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.LONG_FORGOTTEN_SELF);
		this.TryAudioLogAchievement(this.m_AudioLogHenry.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_HENRY",
			Log = "AudioLog/HENRY_NEW_CHARACTER",
			LogWorldPosition = this.m_AudioLogHenry.transform.position
		}, this.m_AudioLogHenry, this.m_AudioClipHenry, new Action(this.HandleAudioLogHenryOnComplete));
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x000079F5 File Offset: 0x00005BF5
	private void HandleAudioLogHenryOnComplete()
	{
		this.CheckClip(this.m_AudioClipHenry);
		this.m_AudioLogHenry.SetActive(true);
		this.m_AudioLogHenry.OnInteracted += this.HandleAudioLogHenryOnInteracted;
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0003B680 File Offset: 0x00039880
	private void HandleAudioLogThomasOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogThomas.SetActive(false);
		this.m_AudioLogThomas.OnInteracted -= this.HandleAudioLogThomasOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogThomas.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_THOMAS",
			Log = "AudioLog/THOMAS_CUTTING_CORNERS",
			LogWorldPosition = this.m_AudioLogThomas.transform.position
		}, this.m_AudioLogThomas, this.m_AudioClipThomams, new Action(this.HandleAudioLogThomasOnComplete));
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x00007A26 File Offset: 0x00005C26
	private void HandleAudioLogThomasOnComplete()
	{
		this.CheckClip(this.m_AudioClipThomams);
		this.m_AudioLogThomas.SetActive(true);
		this.m_AudioLogThomas.OnInteracted += this.HandleAudioLogThomasOnInteracted;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0003B71C File Offset: 0x0003991C
	private void HandleAudioLogWallyThomasOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogWallyThomas.SetActive(false);
		this.m_AudioLogWallyThomas.OnInteracted -= this.HandleAudioLogWallyThomasOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogWallyThomas.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/WALLY_AND_THOMAS_NAME",
			Log = "AudioLog/WALLY_AND_THOMAS_THE_CREATORS",
			LogWorldPosition = this.m_AudioLogWallyThomas.transform.position
		}, this.m_AudioLogWallyThomas, this.m_AudioClipWallyThomas, new Action(this.HandleAudioLogWallyThomasOnComplete));
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x00007A57 File Offset: 0x00005C57
	private void HandleAudioLogWallyThomasOnComplete()
	{
		this.CheckClip(this.m_AudioClipWallyThomas);
		this.m_AudioLogWallyThomas.SetActive(true);
		this.m_AudioLogWallyThomas.OnInteracted += this.HandleAudioLogWallyThomasOnInteracted;
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x00007A88 File Offset: 0x00005C88
	private void CheckClip(AudioClip clip)
	{
		if (this.m_ActiveAudioClip == clip)
		{
			this.m_AudioLogController.PlayOut();
		}
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x00007AA6 File Offset: 0x00005CA6
	private void PlayAudioLog(AudioLogDataVO vo, AudioLog audioLog, AudioClip audioClip, Action onComplete)
	{
		this.AudioControllerReset();
		this.m_ActiveAudioClip = audioClip;
		this.m_AudioLogController = GameManager.Instance.UIManager.Show<AudioLogModalController>("UI/Modals/AudioLogModalController", "MODAL", vo);
		audioLog.Play(this.m_ActiveAudioClip, onComplete);
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x00007AE3 File Offset: 0x00005CE3
	private void AudioControllerReset()
	{
		if (this.m_AudioLogController != null)
		{
			this.m_AudioLogController.Dispose();
			this.m_AudioLogController = null;
		}
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0003B7B8 File Offset: 0x000399B8
	private void TryAudioLogAchievement(int id)
	{
		if (!GameManager.Instance.GameData.CH3AchievementData.AudioLogs.Contains(id))
		{
			GameManager.Instance.GameData.CH3AchievementData.AudioLogs.Add(id);
		}
		if (GameManager.Instance.GameData.CH3AchievementData.AudioLogs.Count >= 10)
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.HEARING_VOICES);
		}
		AudioLogAllAchievements.Check();
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x0003B834 File Offset: 0x00039A34
	protected override void OnDisposed()
	{
		this.AudioControllerReset();
		this.m_ActiveAudioClip = null;
		this.m_AudioClipGrantGenius = null;
		this.m_AudioClipShawnCrooked = null;
		this.m_AudioClipNormanTrouble = null;
		this.m_AudioClipWallySmile = null;
		this.m_AudioClipSusieApart = null;
		this.m_AudioClipSusieLunch = null;
		this.m_AudioClipJoeyDrewBelief = null;
		this.m_AudioClipHenry = null;
		this.m_AudioClipWallyThomas = null;
		this.m_AudioClipThomams = null;
		base.OnDisposed();
	}

	// Token: 0x040004EE RID: 1262
	[Header("Interactables")]
	[SerializeField]
	private AudioLog m_AudioLogGrantGenius;

	// Token: 0x040004EF RID: 1263
	[SerializeField]
	private AudioLog m_AudioLogShawnCrooked;

	// Token: 0x040004F0 RID: 1264
	[SerializeField]
	private AudioLog m_AudioLogNormanTrouble;

	// Token: 0x040004F1 RID: 1265
	[SerializeField]
	private AudioLog m_AudioLogWallySmile;

	// Token: 0x040004F2 RID: 1266
	[SerializeField]
	private AudioLog m_AudioLogSusieApart;

	// Token: 0x040004F3 RID: 1267
	[SerializeField]
	private AudioLog m_AudioLogSusieLunch;

	// Token: 0x040004F4 RID: 1268
	[SerializeField]
	private AudioLog m_AudioLogJoeyDrewBelief;

	// Token: 0x040004F5 RID: 1269
	[SerializeField]
	private AudioLog m_AudioLogHenry;

	// Token: 0x040004F6 RID: 1270
	[SerializeField]
	private AudioLog m_AudioLogThomas;

	// Token: 0x040004F7 RID: 1271
	[SerializeField]
	private AudioLog m_AudioLogWallyThomas;

	// Token: 0x040004F8 RID: 1272
	private AudioLogModalController m_AudioLogController;

	// Token: 0x040004F9 RID: 1273
	private AudioClip m_ActiveAudioClip;

	// Token: 0x040004FA RID: 1274
	private AudioClip m_AudioClipGrantGenius;

	// Token: 0x040004FB RID: 1275
	private AudioClip m_AudioClipShawnCrooked;

	// Token: 0x040004FC RID: 1276
	private AudioClip m_AudioClipNormanTrouble;

	// Token: 0x040004FD RID: 1277
	private AudioClip m_AudioClipWallySmile;

	// Token: 0x040004FE RID: 1278
	private AudioClip m_AudioClipSusieApart;

	// Token: 0x040004FF RID: 1279
	private AudioClip m_AudioClipSusieLunch;

	// Token: 0x04000500 RID: 1280
	private AudioClip m_AudioClipJoeyDrewBelief;

	// Token: 0x04000501 RID: 1281
	private AudioClip m_AudioClipHenry;

	// Token: 0x04000502 RID: 1282
	private AudioClip m_AudioClipThomams;

	// Token: 0x04000503 RID: 1283
	private AudioClip m_AudioClipWallyThomas;
}

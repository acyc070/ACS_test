using System;
using System.Collections.Generic;
using System.Diagnostics;
using I2.Loc;
using UnityEngine;

// Token: 0x02000083 RID: 131
public class CH2AudioLogsController : BaseController
{
	// Token: 0x14000004 RID: 4
	// (add) Token: 0x0600049B RID: 1179 RVA: 0x000311E8 File Offset: 0x0002F3E8
	// (remove) Token: 0x0600049C RID: 1180 RVA: 0x00031220 File Offset: 0x0002F420
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnLostKeyObjective;

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x0600049D RID: 1181 RVA: 0x00031258 File Offset: 0x0002F458
	// (remove) Token: 0x0600049E RID: 1182 RVA: 0x00031290 File Offset: 0x0002F490
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnFavoriteSongObjective;

	// Token: 0x0600049F RID: 1183 RVA: 0x000312C8 File Offset: 0x0002F4C8
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_LostKeysClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/AudioLogs/DIA_WAL_Diary_Lost_Keys_01_temp");
		this.m_ThePrayerClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/AudioLogs/DIA_SammyC2_Audio_Diarry_01");
		this.m_ThePrayerFinaleClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Sammy/DIA_SammyC2_01");
		this.m_DistractionsClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/AudioLogs/DIA_SAM_Diary_Distractions_01_temp");
		this.m_ProjectionistClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/AudioLogs/DIA_NOR_Diary_Projectionist_01_temp");
		this.m_TheNewVoiceActressClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/AudioLogs/DIA_SUS_Diary_New_Voice_Actress_01_temp");
		this.m_JackFainClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/AudioLogs/ch2_audiolog_jackfain");
		this.m_AudioLogThePrayer.OnInteracted += this.HandleAudioLogThePrayerOnInteracted;
		this.m_AudioLogThePrayer.SetActive(true);
		this.m_AudioLogDistractions.OnInteracted += this.HandleAudioLogDistractionsOnInteracted;
		this.m_AudioLogDistractions.SetActive(true);
		this.m_AudioLogTheProjectionist.OnInteracted += this.HandleAudioLogTheProjectionistOnInteracted;
		this.m_AudioLogTheProjectionist.SetActive(true);
		this.m_AudioLogTheNewVoiceAcress.OnInteracted += this.HandleAudioLogTheNewVoiceAcressOnInteracted;
		this.m_AudioLogTheNewVoiceAcress.SetActive(true);
		this.m_AudioLogJackFain.OnInteracted += this.HandleAudioLogJackFainOnInteracted;
		this.m_AudioLogJackFain.SetActive(true);
		this.m_AudioLogLostKeys.SetActive(false);
		this.m_AudioLogFavoriteSong.SetActive(false);
		this.m_PuzzleController.GeneratePuzzle();
		this.GenerateDialogue();
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x00031448 File Offset: 0x0002F648
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.LostKeysObjective.IsStarted)
		{
			this.m_HasKeyObjective = true;
			this.OnLostKeyObjective.Send(this);
		}
		this.m_AudioLogLostKeys.OnInteracted += this.HandleAudioLogLostKeyOnInteracted;
		this.m_AudioLogLostKeys.SetActive(true);
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x000314B0 File Offset: 0x0002F6B0
	public void ActivateFavoriteSong()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicPuzzleObjective.IsStarted)
		{
			this.m_HasFavoriteSongObjective = true;
			this.OnFavoriteSongObjective.Send(this);
		}
		this.m_AudioLogFavoriteSong.OnInteracted += this.HandleAudioLogFavoriteSongOnInteracted;
		this.m_AudioLogFavoriteSong.SetActive(true);
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00031518 File Offset: 0x0002F718
	private void GenerateDialogue()
	{
		string empty = string.Empty;
		string text = "AudioLog/SAMMY_MY_FAVORITE_SONG_HEADER";
		if (LocalizationManager.TryGetTranslation("AudioLog/SAMMY_MY_FAVORITE_SONG_HEADER", out empty, true, 0, true, true, null, null))
		{
			text = empty;
		}
		List<AudioClip> list = new List<AudioClip>();
		list.Add(GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Sammy/Puzzle/DIA_Sammy_Puzzle_Diary_Intro_01"));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < this.m_PuzzleController.InstrumentOrder.Count; i++)
		{
			int num6 = this.m_PuzzleController.InstrumentOrder[i];
			if (num6 == 0)
			{
				this.UpdatePuzzleAudioLog(AudioLogConstants.SAMMY_BANJO, GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/Puzzle/Banjo/"), ref text, ref num, ref list);
			}
			else if (num6 == 1)
			{
				this.UpdatePuzzleAudioLog(AudioLogConstants.SAMMY_DRUM, GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/Puzzle/Drum/"), ref text, ref num2, ref list);
			}
			else if (num6 == 2)
			{
				this.UpdatePuzzleAudioLog(AudioLogConstants.SAMMY_BASS, GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/Puzzle/BassFiddle/"), ref text, ref num3, ref list);
			}
			else if (num6 == 3)
			{
				this.UpdatePuzzleAudioLog(AudioLogConstants.SAMMY_VIOLIN, GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/Puzzle/Violin/"), ref text, ref num4, ref list);
			}
			else if (num6 == 4)
			{
				this.UpdatePuzzleAudioLog(AudioLogConstants.SAMMY_PIANO, GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/Puzzle/Piano/"), ref text, ref num5, ref list);
			}
		}
		list.Add(GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Sammy/Puzzle/DIA_Sammy_Puzzle_Diary_Outro_01"));
		string text2 = "AudioLog/SAMMY_MY_FAVORITE_SONG_FOOTER";
		if (LocalizationManager.TryGetTranslation(text2, out empty, true, 0, true, true, null, null))
		{
			text2 = empty;
		}
		text += text2;
		this.m_PuzzleLog = text;
		this.m_PuzzleClip = GameManager.Instance.AudioManager.Combine(list);
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x000316E0 File Offset: 0x0002F8E0
	private void UpdatePuzzleAudioLog(string[] instrumentLog, AudioClip[] dialogueClips, ref string audioLog, ref int index, ref List<AudioClip> audioClips)
	{
		string empty = string.Empty;
		string text = instrumentLog[index];
		if (LocalizationManager.TryGetTranslation(text, out empty, true, 0, true, true, null, null))
		{
			text = empty;
		}
		audioLog += text;
		audioClips.Add(dialogueClips[index]);
		index++;
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x00031730 File Offset: 0x0002F930
	private void HandleAudioLogLostKeyOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogLostKeys.SetActive(false);
		this.m_AudioLogLostKeys.OnInteracted -= this.HandleAudioLogLostKeyOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogLostKeys.GetID());
		if (!this.m_HasKeyObjective)
		{
			this.m_HasKeyObjective = true;
			ObjectiveDataVO objectiveDataVO = ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_UNLOCK_CLOSET", "OBJECTIVES/CH2_OBJECTIVE_UNLOCK_CLOSET_TIP", 4f, false, 0f);
			objectiveDataVO.AddItemCounter(this.m_KeyController.KeySprite, 0);
			GameManager.Instance.ShowObjective(objectiveDataVO);
			this.OnLostKeyObjective.Send(this);
		}
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_WALLY",
			Log = "AudioLog/WALLY_LOST_KEYS",
			LogWorldPosition = this.m_AudioLogLostKeys.transform.position
		}, this.m_AudioLogLostKeys, this.m_LostKeysClip, new Action(this.HandleAudioLostKeyOnComplete));
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x00031828 File Offset: 0x0002FA28
	private void HandleAudioLostKeyOnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_LostKeysClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogLostKeys.SetActive(true);
		this.m_AudioLogLostKeys.OnInteracted += this.HandleAudioLogLostKeyOnInteracted;
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0003187C File Offset: 0x0002FA7C
	private void HandleAudioLogThePrayerOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogThePrayer.SetActive(false);
		this.m_AudioLogThePrayer.OnInteracted -= this.HandleAudioLogThePrayerOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogThePrayer.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SAMMY",
			Log = "AudioLog/SAMMY_THE_PRAYER",
			LogWorldPosition = this.m_AudioLogThePrayer.transform.position
		}, this.m_AudioLogThePrayer, this.m_ThePrayerClip, new Action(this.HandleAudioThePrayerOnComplete));
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x00031918 File Offset: 0x0002FB18
	private void HandleAudioThePrayerOnComplete()
	{
		if (!this.m_IsSammyScareComplete && Vector3.Distance(GameManager.Instance.Player.transform.position, this.m_AudioLogThePrayer.transform.position) < 15f)
		{
			this.m_IsSammyScareComplete = true;
			Vector3 vector = GameManager.Instance.Player.transform.position;
			vector -= GameManager.Instance.Player.transform.forward * 4f;
			this.m_AudioObjectThePrayerFinale = GameManager.Instance.AudioManager.PlayAtPosition(this.m_ThePrayerFinaleClip, vector, AudioObjectType.DIALOGUE, 0, false, GameManager.Instance.Player.transform);
		}
		if (this.m_ActiveAudioClip == this.m_ThePrayerClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogThePrayer.SetActive(true);
		this.m_AudioLogThePrayer.OnInteracted += this.HandleAudioLogThePrayerOnInteracted;
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00031A18 File Offset: 0x0002FC18
	private void HandleAudioLogDistractionsOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogDistractions.SetActive(false);
		this.m_AudioLogDistractions.OnInteracted -= this.HandleAudioLogDistractionsOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogDistractions.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SAMMY",
			Log = "AudioLog/SAMMY_DISTRACTIONS",
			LogWorldPosition = this.m_AudioLogDistractions.transform.position
		}, this.m_AudioLogDistractions, this.m_DistractionsClip, new Action(this.HandleAudioDistractionsOnComplete));
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x00031AB4 File Offset: 0x0002FCB4
	private void HandleAudioDistractionsOnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_DistractionsClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogDistractions.SetActive(true);
		this.m_AudioLogDistractions.OnInteracted += this.HandleAudioLogDistractionsOnInteracted;
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x00031B08 File Offset: 0x0002FD08
	private void HandleAudioLogTheProjectionistOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogTheProjectionist.SetActive(false);
		this.m_AudioLogTheProjectionist.OnInteracted -= this.HandleAudioLogTheProjectionistOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogTheProjectionist.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_NORMAN",
			Log = "AudioLog/NORMAN_THE_PROJECTIONIST",
			LogWorldPosition = this.m_AudioLogTheProjectionist.transform.position
		}, this.m_AudioLogTheProjectionist, this.m_ProjectionistClip, new Action(this.HandleAudioTheProjectionistOnComplete));
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x00031BA4 File Offset: 0x0002FDA4
	private void HandleAudioTheProjectionistOnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_ProjectionistClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogTheProjectionist.SetActive(true);
		this.m_AudioLogTheProjectionist.OnInteracted += this.HandleAudioLogTheProjectionistOnInteracted;
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x00031BF8 File Offset: 0x0002FDF8
	private void HandleAudioLogTheNewVoiceAcressOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogTheNewVoiceAcress.SetActive(false);
		this.m_AudioLogTheNewVoiceAcress.OnInteracted -= this.HandleAudioLogTheNewVoiceAcressOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogTheNewVoiceAcress.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SUSIE",
			Log = "AudioLog/SUSIE_THE_NEW_VOICE_ACTRESS",
			LogWorldPosition = this.m_AudioLogTheNewVoiceAcress.transform.position
		}, this.m_AudioLogTheNewVoiceAcress, this.m_TheNewVoiceActressClip, new Action(this.HandleAudioTheNewVoiceAcressOnComplete));
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x00031C94 File Offset: 0x0002FE94
	private void HandleAudioTheNewVoiceAcressOnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_TheNewVoiceActressClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogTheNewVoiceAcress.SetActive(true);
		this.m_AudioLogTheNewVoiceAcress.OnInteracted += this.HandleAudioLogTheNewVoiceAcressOnInteracted;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x00031CE8 File Offset: 0x0002FEE8
	private void HandleAudioLogJackFainOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogJackFain.SetActive(false);
		this.m_AudioLogJackFain.OnInteracted -= this.HandleAudioLogJackFainOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogJackFain.GetID());
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_JACK",
			Log = "AudioLog/JACK_NOSE_CLOSED",
			LogWorldPosition = this.m_AudioLogJackFain.transform.position
		}, this.m_AudioLogJackFain, this.m_JackFainClip, new Action(this.HandleAudioLogJackFainOnComplete));
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x00031D84 File Offset: 0x0002FF84
	private void HandleAudioLogJackFainOnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_JackFainClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogJackFain.SetActive(true);
		this.m_AudioLogJackFain.OnInteracted += this.HandleAudioLogJackFainOnInteracted;
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x00031DD8 File Offset: 0x0002FFD8
	private void HandleAudioLogFavoriteSongOnInteracted(object sender, EventArgs e)
	{
		this.m_AudioLogFavoriteSong.SetActive(false);
		this.m_AudioLogFavoriteSong.OnInteracted -= this.HandleAudioLogFavoriteSongOnInteracted;
		this.TryAudioLogAchievement(this.m_AudioLogFavoriteSong.GetID());
		if (!this.m_HasFavoriteSongObjective)
		{
			this.m_HasFavoriteSongObjective = true;
			this.OnFavoriteSongObjective.Send(this);
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SANCTUARY", "OBJECTIVES/CH2_OBJECTIVE_SANCTUARY_TIP", 4f, false, 0f));
			this.m_PuzzleController.EnableTip();
		}
		this.PlayAudioLog(new AudioLogDataVO
		{
			Name = "AudioLog/NAME_SAMMY",
			LogString = this.m_PuzzleLog,
			LogWorldPosition = this.m_AudioLogFavoriteSong.transform.position
		}, this.m_AudioLogFavoriteSong, this.m_PuzzleClip, new Action(this.HandleAudioFavoriteSongOnComplete));
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x00031EC4 File Offset: 0x000300C4
	private void HandleAudioFavoriteSongOnComplete()
	{
		if (this.m_ActiveAudioClip == this.m_PuzzleClip)
		{
			this.m_AudioLogController.PlayOut();
		}
		this.m_AudioLogFavoriteSong.SetActive(true);
		this.m_AudioLogFavoriteSong.OnInteracted += this.HandleAudioLogFavoriteSongOnInteracted;
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x00031F18 File Offset: 0x00030118
	private void TryAudioLogAchievement(int id)
	{
		if (!GameManager.Instance.GameData.CH2AchievementData.AudioLogs.Contains(id))
		{
			GameManager.Instance.GameData.CH2AchievementData.AudioLogs.Add(id);
		}
		if (GameManager.Instance.GameData.CH2AchievementData.AudioLogs.Count >= 7)
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.OLD_PROBLEMS);
		}
		AudioLogAllAchievements.Check();
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x00006641 File Offset: 0x00004841
	private void PlayAudioLog(AudioLogDataVO vo, AudioLog audioLog, AudioClip audioClip, Action onComplete)
	{
		this.AudioControllerReset();
		this.m_ActiveAudioClip = audioClip;
		this.m_AudioLogController = GameManager.Instance.UIManager.Show<AudioLogModalController>("UI/Modals/AudioLogModalController", "MODAL", vo);
		audioLog.Play(this.m_ActiveAudioClip, onComplete);
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x0000667E File Offset: 0x0000487E
	private void AudioControllerReset()
	{
		if (this.m_AudioLogController != null)
		{
			this.m_AudioLogController.Dispose();
			this.m_AudioLogController = null;
		}
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x00031F94 File Offset: 0x00030194
	protected override void OnDisposed()
	{
		this.AudioControllerReset();
		if (this.m_AudioLogThePrayer)
		{
			this.m_AudioLogThePrayer.OnInteracted -= this.HandleAudioLogThePrayerOnInteracted;
		}
		if (this.m_AudioLogDistractions)
		{
			this.m_AudioLogDistractions.OnInteracted -= this.HandleAudioLogDistractionsOnInteracted;
		}
		if (this.m_AudioLogTheProjectionist)
		{
			this.m_AudioLogTheProjectionist.OnInteracted -= this.HandleAudioLogTheProjectionistOnInteracted;
		}
		if (this.m_AudioLogTheNewVoiceAcress)
		{
			this.m_AudioLogTheNewVoiceAcress.OnInteracted -= this.HandleAudioLogTheNewVoiceAcressOnInteracted;
		}
		if (this.m_AudioLogFavoriteSong)
		{
			this.m_AudioLogFavoriteSong.OnInteracted -= this.HandleAudioLogFavoriteSongOnInteracted;
		}
		if (this.m_AudioLogLostKeys)
		{
			this.m_AudioLogLostKeys.OnInteracted -= this.HandleAudioLogLostKeyOnInteracted;
		}
		if (this.m_AudioLogJackFain)
		{
			this.m_AudioLogJackFain.OnInteracted -= this.HandleAudioLogJackFainOnInteracted;
		}
		if (this.m_AudioObjectThePrayerFinale != null)
		{
			this.m_AudioObjectThePrayerFinale.Clear();
			this.m_AudioObjectThePrayerFinale = null;
		}
		this.m_LostKeysClip = null;
		this.m_ThePrayerClip = null;
		this.m_ThePrayerFinaleClip = null;
		this.m_DistractionsClip = null;
		this.m_ProjectionistClip = null;
		this.m_TheNewVoiceActressClip = null;
		this.m_PuzzleClip = null;
		this.m_JackFainClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000311 RID: 785
	[Header("<Controllers>")]
	[SerializeField]
	private CH2RecordingStudioController m_PuzzleController;

	// Token: 0x04000312 RID: 786
	[SerializeField]
	private CH2LostKeysController m_KeyController;

	// Token: 0x04000313 RID: 787
	[Header("<Audio Logs>")]
	[SerializeField]
	private AudioLog m_AudioLogLostKeys;

	// Token: 0x04000314 RID: 788
	[SerializeField]
	private AudioLog m_AudioLogThePrayer;

	// Token: 0x04000315 RID: 789
	[SerializeField]
	private AudioLog m_AudioLogDistractions;

	// Token: 0x04000316 RID: 790
	[SerializeField]
	private AudioLog m_AudioLogTheProjectionist;

	// Token: 0x04000317 RID: 791
	[SerializeField]
	private AudioLog m_AudioLogTheNewVoiceAcress;

	// Token: 0x04000318 RID: 792
	[SerializeField]
	private AudioLog m_AudioLogFavoriteSong;

	// Token: 0x04000319 RID: 793
	[SerializeField]
	private AudioLog m_AudioLogJackFain;

	// Token: 0x0400031A RID: 794
	private AudioObject m_AudioObjectThePrayerFinale;

	// Token: 0x0400031B RID: 795
	private AudioClip m_ActiveAudioClip;

	// Token: 0x0400031C RID: 796
	private AudioClip m_LostKeysClip;

	// Token: 0x0400031D RID: 797
	private AudioClip m_ThePrayerClip;

	// Token: 0x0400031E RID: 798
	private AudioClip m_ThePrayerFinaleClip;

	// Token: 0x0400031F RID: 799
	private AudioClip m_DistractionsClip;

	// Token: 0x04000320 RID: 800
	private AudioClip m_ProjectionistClip;

	// Token: 0x04000321 RID: 801
	private AudioClip m_TheNewVoiceActressClip;

	// Token: 0x04000322 RID: 802
	private AudioClip m_PuzzleClip;

	// Token: 0x04000323 RID: 803
	private AudioClip m_JackFainClip;

	// Token: 0x04000324 RID: 804
	private AudioLogModalController m_AudioLogController;

	// Token: 0x04000325 RID: 805
	private bool m_IsSammyScareComplete;

	// Token: 0x04000326 RID: 806
	private string m_PuzzleLog;

	// Token: 0x04000327 RID: 807
	private bool m_HasKeyObjective;

	// Token: 0x04000328 RID: 808
	private bool m_HasFavoriteSongObjective;
}

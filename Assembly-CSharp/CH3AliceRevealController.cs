using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class CH3AliceRevealController : BaseController
{
	// Token: 0x06000638 RID: 1592 RVA: 0x0003A894 File Offset: 0x00038A94
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_AliceMusic = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_aaintroductionsong");
		this.m_AliceJumpscare = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_aajumpscare");
		this.m_LightClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Light_Switch_Sammys_Room_01");
		this.m_AliceAmbienceClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH3/MUS_CH3_angelicambience");
		this.m_AliceRevealClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Alice/MonologueReveal/");
		this.m_AliceEnable.SetActive(false);
		this.m_ExitBlocker.SetActive(false);
		this.m_CompleteEnable.SetActive(false);
		this.m_TelevisionLighting.SetActive(false);
		this.m_DoorSpotlight.enabled = false;
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x0003A94C File Offset: 0x00038B4C
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceRevealObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.m_IntroTrigger.OnEnter += this.HandleIntroTriggerOnEnter;
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x0003A99C File Offset: 0x00038B9C
	private void HandleIntroTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_IntroTrigger.OnEnter -= this.HandleIntroTriggerOnEnter;
		this.m_DoorController.Close();
		this.m_DoorController.Lock();
		GameManager.Instance.AudioManager.Play(this.m_LightClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_EnvironmentLighting.SetActive(false);
		this.m_ExitBlocker.SetActive(true);
		RenderSettings.ambientIntensity = 0f;
		this.BeginJumpscare();
		S13AudioManager.Instance.InvokeEvent("evt_alice_reveal_start", 0f);
		GameManager.Instance.AudioManager.Play(this.m_AliceMusic, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += this.HandleAliceIntroMusicOnComplete;
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x0003AA58 File Offset: 0x00038C58
	private Sequence BeginJumpscare()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 31f;
		float num2 = 2f;
		for (int i = 0; i < this.m_Televisions.Count; i++)
		{
			CH3Television ch3Television = this.m_Televisions[i];
			sequence.InsertCallback(num2, new TweenCallback(ch3Television.Play));
			num2 += 0.15f;
		}
		sequence.InsertCallback(num, delegate
		{
			this.m_DoorSpotlight.enabled = true;
			GameManager.Instance.AudioManager.Play(this.m_LightClip, AudioObjectType.SOUND_EFFECT, 0, false);
			for (int j = 0; j < this.m_LightFixtures.Count; j++)
			{
				this.m_LightFixtures[j].TurnOff();
			}
		});
		return sequence;
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0003AAD4 File Offset: 0x00038CD4
	private void HandleAliceIntroMusicOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleAliceIntroMusicOnComplete;
		this.m_DoorSpotlight.intensity = 2f;
		this.m_AliceEnable.SetActive(true);
		this.m_TelevisionLighting.SetActive(true);
		this.m_SignSpotlight.SetActive(true);
		for (int i = 0; i < this.m_Televisions.Count; i++)
		{
			this.m_Televisions[i].Stop();
		}
		GameManager.Instance.GameCamera.transform.DOShakePosition(3.5f, 0.1f, 10, 90f, false, true);
		GameManager.Instance.ShowScreenBlocker(0f, 3.65f, delegate
		{
			GameManager.Instance.Player.SetLock(true, false);
		});
		GameManager.Instance.AudioManager.Play(this.m_AliceJumpscare, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += this.HandleAliceJumpscareOnComplete;
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x0003ABDC File Offset: 0x00038DDC
	private void HandleAliceJumpscareOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleAliceJumpscareOnComplete;
		GameManager.Instance.AudioManager.Play(this.m_AliceAmbienceClip, AudioObjectType.SOUND_EFFECT, 0, false);
		for (int i = 0; i < this.m_AliceRevealClips.Length; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_AliceRevealClips[i], SubtitleConstants.DIALOGUE_CH3_ALICE_REVEAL[i], true));
			if (i == this.m_AliceRevealClips.Length - 1)
			{
				audioObject.OnComplete += this.HandleRevealDialogueOnComplete;
			}
		}
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x0003AC74 File Offset: 0x00038E74
	private void HandleRevealDialogueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleRevealDialogueOnComplete;
		GameManager.Instance.HideScreenBlocker(1f, 0f, null);
		DOTweenUtil.DOAmbientLightColor(1f, 2f, null);
		GameManager.Instance.Player.transform.position = this.m_FinalPosition.position;
		GameManager.Instance.Player.LookRotation(this.m_FinalPosition.rotation, Quaternion.identity);
		GameManager.Instance.Player.SetLock(false, false);
		this.m_Glass.material.SetFloat("_IsBroken", 1f);
		this.m_AliceProps.Dispose();
		this.m_AliceEnable.SetActive(false);
		this.m_CompleteDisable.SetActive(false);
		this.m_CompleteEnable.SetActive(true);
		this.m_TelevisionLighting.SetActive(false);
		this.m_EnvironmentLighting.SetActive(true);
		for (int i = 0; i < this.m_LightFixtures.Count; i++)
		{
			this.m_LightFixtures[i].TurnOn();
		}
		this.m_DoorController.Unlock();
		this.m_DoorController.Open(1f, Ease.OutQuad, 145f);
		this.m_DoorSpotlight.enabled = false;
		this.m_ExitBlocker.SetActive(false);
		S13AudioManager.Instance.InvokeEvent("evt_alice_reveal_complete", 0f);
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 4f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.AliceRevealObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0003AE48 File Offset: 0x00039048
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH3_save_point_04", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/OBJECTIVE_FIND_A_NEW_EXIT", string.Empty, 0f, false, 0f));
		this.m_Glass.material.SetFloat("_IsBroken", 1f);
		this.m_AliceProps.Dispose();
		this.m_AliceEnable.SetActive(false);
		this.m_CompleteDisable.SetActive(false);
		this.m_CompleteEnable.SetActive(true);
		this.m_TelevisionLighting.SetActive(false);
		this.m_EnvironmentLighting.SetActive(true);
		for (int i = 0; i < this.m_LightFixtures.Count; i++)
		{
			this.m_LightFixtures[i].TurnOn();
		}
		this.m_DoorController.Unlock();
		this.m_DoorController.Open(1f, Ease.OutQuad, 145f);
		this.m_DoorSpotlight.enabled = false;
		this.m_ExitBlocker.SetActive(false);
		base.SendOnComplete();
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x00007860 File Offset: 0x00005A60
	protected override void OnDisposed()
	{
		this.m_AliceMusic = null;
		this.m_AliceJumpscare = null;
		this.m_LightClip = null;
		this.m_AliceAmbienceClip = null;
		this.m_AliceRevealClips = null;
		base.OnDisposed();
	}

	// Token: 0x040004D8 RID: 1240
	[Header("Alice Angel Intro")]
	[SerializeField]
	private Transform m_FinalPosition;

	// Token: 0x040004D9 RID: 1241
	[SerializeField]
	private EventTrigger m_IntroTrigger;

	// Token: 0x040004DA RID: 1242
	[SerializeField]
	private GameObject m_ExitBlocker;

	// Token: 0x040004DB RID: 1243
	[SerializeField]
	private BaseDoorController m_DoorController;

	// Token: 0x040004DC RID: 1244
	[SerializeField]
	private DisposableObject m_AliceProps;

	// Token: 0x040004DD RID: 1245
	[Header("GameObjects")]
	[SerializeField]
	private GameObject m_CompleteDisable;

	// Token: 0x040004DE RID: 1246
	[SerializeField]
	private GameObject m_CompleteEnable;

	// Token: 0x040004DF RID: 1247
	[SerializeField]
	private GameObject m_AliceEnable;

	// Token: 0x040004E0 RID: 1248
	[Header("Lighting")]
	[SerializeField]
	private GameObject m_SignSpotlight;

	// Token: 0x040004E1 RID: 1249
	[SerializeField]
	private Light m_DoorSpotlight;

	// Token: 0x040004E2 RID: 1250
	[SerializeField]
	private GameObject m_EnvironmentLighting;

	// Token: 0x040004E3 RID: 1251
	[SerializeField]
	private GameObject m_TelevisionLighting;

	// Token: 0x040004E4 RID: 1252
	[Header("Televisions")]
	[SerializeField]
	private List<CH3Television> m_Televisions;

	// Token: 0x040004E5 RID: 1253
	[Header("Light Fixtures")]
	[SerializeField]
	private List<LightFixtureController> m_LightFixtures;

	// Token: 0x040004E6 RID: 1254
	[SerializeField]
	private MeshRenderer m_Glass;

	// Token: 0x040004E7 RID: 1255
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x040004E8 RID: 1256
	private AudioClip m_AliceMusic;

	// Token: 0x040004E9 RID: 1257
	private AudioClip m_AliceJumpscare;

	// Token: 0x040004EA RID: 1258
	private AudioClip m_LightClip;

	// Token: 0x040004EB RID: 1259
	private AudioClip m_AliceAmbienceClip;

	// Token: 0x040004EC RID: 1260
	private AudioClip[] m_AliceRevealClips;
}

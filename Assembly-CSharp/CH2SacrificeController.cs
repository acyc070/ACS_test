using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Token: 0x02000099 RID: 153
public class CH2SacrificeController : BaseController
{
	// Token: 0x06000579 RID: 1401 RVA: 0x00036688 File Offset: 0x00034888
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_SammyFootstepClips = GameManager.Instance.GetAudioClips("Audio/SFX/Footsteps/Sammy/Wood");
		this.m_MonologueClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/FinaleMonologue/");
		this.m_SpeakerMonologueClips = GameManager.Instance.GetAudioClips("Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/");
		this.m_MusicLittleDevilClip = GameManager.Instance.GetAudioClip("Audio/MUS/MUS_Little_Devil_Darling_Remastered");
		this.m_SammyMonologueBGClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Sammy/DIA_Sammy_Finale_BG_Audio");
		this.m_DuctCrawlingClip = GameManager.Instance.GetAudioClip("Audio/SFX/FOL_Duct_Crawling_01");
		this.m_RopeStressClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Rope_Stress_01");
		this.m_RopeStressSnapClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Rope_Stress_Snap_02");
		this.m_SpeakerTapClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Speaker_Tap_Feedback");
		this.m_DoorCloseClip = GameManager.Instance.GetAudioClip("Audio/SFX/Door/SFX_Door_Generic_Close_01");
		this.m_LightController.TurnOff();
		this.m_SammysDoor.ForceOpen(85f);
		this.m_SacrificeSpawner.gameObject.SetActive(false);
		this.m_SammyBlood.localScale = new Vector3(this.m_SammyBlood.localScale.x, -0.1f, this.m_SammyBlood.localScale.z);
		this.m_InkMachineLoop.gameObject.SetActive(false);
		this.m_GateDoor.Close();
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x000367F0 File Offset: 0x000349F0
	public override void Activate()
	{
		GameManager.Instance.Player.SetLock(false, false);
		GameManager.Instance.Player.SetLockedMovement(true);
		GameManager.Instance.Player.transform.SetParent(this.m_TiedUpPosition);
		GameManager.Instance.Player.LookRotation(Quaternion.identity, Quaternion.identity);
		GameManager.Instance.Player.LockRotation(50f, 25f);
		GameManager.Instance.Player.transform.localPosition = Vector3.zero;
		GameManager.Instance.Player.transform.localEulerAngles = Vector3.zero;
		GameManager.Instance.GameCamera.Camera.transform.localPosition = Vector3.zero;
		GameManager.Instance.GameCamera.Camera.transform.localEulerAngles = Vector3.zero;
		this.m_SammyAnimator.SetTrigger("Monologue");
		Sequence sequence = DOTween.Sequence();
		GameCamera gameCam = GameManager.Instance.GameCamera;
		sequence.InsertCallback(0.75f, delegate
		{
			GameManager.Instance.HideScreenBlocker(2f, 0f, null);
		});
		sequence.InsertCallback(3.2f, delegate
		{
			GameManager.Instance.ShowScreenBlocker(1f, 0f, null);
		});
		sequence.InsertCallback(4.3f, delegate
		{
			GameManager.Instance.HideScreenBlocker(1f, 0f, null);
		});
		sequence.InsertCallback(24.14f, delegate
		{
			this.HandleAxeSwap();
		});
		this.m_InitialSpawner.gameObject.SetActive(false);
		this.m_SacrificeSpawner.gameObject.SetActive(true);
		if (gameCam.DoF)
		{
			float distance = gameCam.UnityDOF.focalDistance;
			sequence.Insert(2.5f, DOTween.To(() => distance, delegate(float value)
			{
				distance = value;
			}, 5f, 2f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				gameCam.UnityDOF.focalDistance = distance;
			}));
			sequence.InsertCallback(4.5f, delegate
			{
				gameCam.UnityDOF.manualDOF = false;
			});
		}
		int num = this.m_MonologueClips.Length;
		int num2 = 7;
		for (int i = 0; i < num; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_MonologueClips[i], SubtitleConstants.DIALOGUE_CHAPTER_TWO_SAMMY_FINALE_MONOLOGUE[i], true));
			if (i == num - 1)
			{
				audioObject.OnComplete += this.HandleMonologueOnComplete;
			}
			else if (i == num2)
			{
				audioObject.OnComplete += this.HandleDuctCrawlingAudio;
			}
		}
		GameManager.Instance.Player.OnDeath += this.HandlePlayerOnDeath;
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x00006F0E File Offset: 0x0000510E
	private void HandleAxeSwap()
	{
		this.m_SammyAxe.SetActive(false);
		this.m_PickupAxe.SetActive(true);
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x00006F28 File Offset: 0x00005128
	private void HandleDuctCrawlingAudio(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleDuctCrawlingAudio;
		GameManager.Instance.AudioManager.Play(this.m_DuctCrawlingClip, AudioObjectType.SOUND_EFFECT, 0, false);
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x00006F5A File Offset: 0x0000515A
	private void HandleMonologueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleMonologueOnComplete;
		this.DOWalkSequence().OnComplete(new TweenCallback(this.HandleSammyExitOnComplete));
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x00036AF4 File Offset: 0x00034CF4
	private Sequence DOWalkSequence()
	{
		GameManager.Instance.AudioManager.Play(this.m_RopeStressClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.GameCamera.Camera.DOShakePosition(2f, 0.15f, 10, 90f, false).OnComplete(delegate
		{
			GameManager.Instance.GameCamera.Camera.DOShakePosition(2f, 0.15f, 10, 90f, false).SetDelay(1f);
		});
		this.m_SammyAnimator.SetBool("Walk", true);
		Sequence sequence = DOTween.Sequence();
		sequence.Insert(0f, this.m_Sammy.DOLookAt(this.m_SammyEndPosition.position, 0.45f, AxisConstraint.None, null));
		for (int i = 0; i < 9; i++)
		{
			sequence.InsertCallback((float)i * 0.72f, new TweenCallback(this.PlayFootStepAudio));
		}
		sequence.Insert(0f, this.m_Sammy.DOMoveX(this.m_SammyEndPosition.position.x, 6.5f, false).SetEase(Ease.Linear));
		sequence.Insert(0f, this.m_Sammy.DOMoveZ(this.m_SammyEndPosition.position.z, 6.5f, false).SetEase(Ease.Linear));
		sequence.InsertCallback(5.5f, new TweenCallback(this.m_SammysDoor.Close));
		sequence.InsertCallback(5.5f, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_DoorCloseClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		sequence.InsertCallback(6f, new TweenCallback(this.m_SammysDoor.Lock));
		return sequence;
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x00036C9C File Offset: 0x00034E9C
	private void HandleSammyExitOnComplete()
	{
		GameManager.Instance.AudioManager.Play(this.m_SpeakerTapClip, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += this.HandleSpeakersOnComplete;
		for (int i = 0; i < this.m_Speakers.Count; i++)
		{
			this.m_Speakers[i].DOScaleZ(global::UnityEngine.Random.Range(1.03f, 1.05f), 0.25f).SetDelay(global::UnityEngine.Random.Range(0.05f, 0.15f)).SetEase(Ease.InOutQuad)
				.SetLoops(-1, LoopType.Yoyo);
		}
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00036D38 File Offset: 0x00034F38
	private void HandleSpeakersOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.AudioManager.Play(this.m_SammyMonologueBGClip, AudioObjectType.SOUND_EFFECT, 0, false);
		int num = this.m_SpeakerMonologueClips.Length;
		int num2 = 1;
		int num3 = num - 3;
		for (int i = 0; i < num; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_SpeakerMonologueClips[i], SubtitleConstants.DIALOGUE_CHAPTER_TWO_SAMMY_FINALE_SPEAKER_MONOLOGUE[i], true));
			if (i == num2)
			{
				audioObject.OnComplete += this.HandleGateDoorOpen;
			}
			else if (i == num3)
			{
				audioObject.OnComplete += this.HandleMusicTrigger;
			}
			if (i == num - 1)
			{
				audioObject.OnComplete += this.HandleSpeakerMonologueOnComplete;
			}
		}
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x00036DF8 File Offset: 0x00034FF8
	private void HandleGateDoorOpen(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleGateDoorOpen;
		GameManager.Instance.AudioManager.Play(this.m_RopeStressClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.GameCamera.Camera.DOShakePosition(2f, 0.15f, 10, 90f, false).OnComplete(delegate
		{
			GameManager.Instance.GameCamera.Camera.DOShakePosition(2f, 0.15f, 10, 90f, false).SetDelay(1f);
		});
		this.m_LightController.TurnOn();
		this.m_GateDoor.Open();
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x00036E94 File Offset: 0x00035094
	private void HandleMusicTrigger(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleMusicTrigger;
		this.m_MusicAudioObject = GameManager.Instance.AudioManager.Play(this.m_MusicLittleDevilClip, AudioObjectType.MUSIC, -1, false);
		this.m_MusicAudioObject.AudioSource.volume = 0.1f;
		this.m_MusicAudioObject.AudioSource.DOFade(1f, 4f).SetEase(Ease.Linear).SetDelay(0.2f);
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00036F18 File Offset: 0x00035118
	private void HandleSpeakerMonologueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleSpeakerMonologueOnComplete;
		for (int i = 0; i < this.m_Speakers.Count; i++)
		{
			this.m_Speakers[i].DOKill(false);
		}
		DOTween.Sequence().Insert(0f, this.m_SammyBlood.DOScaleY(20f, 8f).SetEase(Ease.InOutQuad));
		GameManager.Instance.AudioManager.Play(this.m_RopeStressSnapClip, AudioObjectType.SOUND_EFFECT, 0, false);
		GameManager.Instance.GameCamera.Camera.DOShakePosition(3f, 0.25f, 10, 90f, false).OnComplete(delegate
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_ESCAPE_BENDY", "OBJECTIVES/CH2_OBJECTIVE_ESCAPE_BENDY_TIP", 4f, false, 0f));
			GameManager.Instance.ShowCrosshair();
			GameManager.Instance.Player.SetLockedMovement(false);
			GameManager.Instance.Player.UnlockRotation();
			Vector3 vector = GameManager.Instance.Player.transform.forward * 2f;
			GameManager.Instance.Player.transform.SetParent(null);
			GameManager.Instance.Player.LookRotation(Quaternion.LookRotation(vector));
		});
		this.m_MusicEventTrigger.OnEnter += this.HandleMusicEventTriggerOnEnter;
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x00037010 File Offset: 0x00035210
	private void HandleMusicEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_MusicEventTrigger.OnEnter -= this.HandleMusicEventTriggerOnEnter;
		this.m_InkMachineLoop.gameObject.SetActive(true);
		this.m_InkMachineLoop.Activate();
		GameManager.Instance.AudioManager.Play(this.m_DuctCrawlingClip, AudioObjectType.SOUND_EFFECT, 0, false);
		if (this.m_MusicAudioObject != null)
		{
			this.m_MusicAudioObject.AudioSource.DOFade(0f, 8f).OnComplete(delegate
			{
				if (this.m_MusicAudioObject != null)
				{
					this.m_MusicAudioObject.Clear();
					this.m_MusicAudioObject = null;
				}
			});
		}
		base.SendOnComplete();
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x000370AC File Offset: 0x000352AC
	private void PlayFootStepAudio()
	{
		if (this.m_SammyFootstepClips == null || this.m_SammyFootstepClips.Length <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_SammyFootstepClips.Length);
		AudioClip audioClip = this.m_SammyFootstepClips[num];
		GameManager.Instance.AudioManager.PlayAtPosition(audioClip, this.m_Sammy.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_SammyFootstepClips[num] = this.m_SammyFootstepClips[0];
		this.m_SammyFootstepClips[0] = audioClip;
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x00006F8B File Offset: 0x0000518B
	private void HandlePlayerOnDeath(object sender, EventArgs e)
	{
		if (this.m_MusicAudioObject != null)
		{
			this.m_MusicAudioObject.AudioSource.DOFade(0f, 3f).OnComplete(delegate
			{
				if (this.m_MusicAudioObject != null)
				{
					this.m_MusicAudioObject.Clear();
					this.m_MusicAudioObject = null;
				}
			});
		}
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x00037124 File Offset: 0x00035324
	protected override void OnDisposed()
	{
		if (GameManager.Instance.Player)
		{
			GameManager.Instance.Player.OnDeath -= this.HandlePlayerOnDeath;
		}
		for (int i = 0; i < this.m_Speakers.Count; i++)
		{
			this.m_Speakers[i].DOKill(false);
		}
		this.m_SammyFootstepClips = null;
		this.m_MonologueClips = null;
		this.m_SpeakerMonologueClips = null;
		this.m_MusicLittleDevilClip = null;
		this.m_SammyMonologueBGClip = null;
		this.m_DuctCrawlingClip = null;
		this.m_RopeStressClip = null;
		this.m_RopeStressSnapClip = null;
		this.m_SpeakerTapClip = null;
		this.m_DoorCloseClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400040A RID: 1034
	private const float LOCK_VERTICAL = 25f;

	// Token: 0x0400040B RID: 1035
	private const float LOCK_HORIZONTAL = 50f;

	// Token: 0x0400040C RID: 1036
	[Header("Transforms")]
	[SerializeField]
	private Transform m_Sammy;

	// Token: 0x0400040D RID: 1037
	[SerializeField]
	private Transform m_SammyEndPosition;

	// Token: 0x0400040E RID: 1038
	[SerializeField]
	private Transform m_TiedUpPosition;

	// Token: 0x0400040F RID: 1039
	[SerializeField]
	private GenericDoorController m_GateDoor;

	// Token: 0x04000410 RID: 1040
	[SerializeField]
	private List<Transform> m_Speakers;

	// Token: 0x04000411 RID: 1041
	[SerializeField]
	private Transform m_SammyBlood;

	// Token: 0x04000412 RID: 1042
	[Header("Animator")]
	[SerializeField]
	private Animator m_SammyAnimator;

	// Token: 0x04000413 RID: 1043
	[Header("Door")]
	[SerializeField]
	private BaseDoorController m_SammysDoor;

	// Token: 0x04000414 RID: 1044
	[Header("Light Fixture")]
	[SerializeField]
	private LightFixtureController m_LightController;

	// Token: 0x04000415 RID: 1045
	[Header("Event Trigger")]
	[SerializeField]
	private EventTrigger m_MusicEventTrigger;

	// Token: 0x04000416 RID: 1046
	[SerializeField]
	private InkMachineLoopController m_InkMachineLoop;

	// Token: 0x04000417 RID: 1047
	[Header("Spawners")]
	[SerializeField]
	private PlayerSpawnNode m_InitialSpawner;

	// Token: 0x04000418 RID: 1048
	[SerializeField]
	private PlayerSpawnNode m_SacrificeSpawner;

	// Token: 0x04000419 RID: 1049
	[Header("Animation Event Objects")]
	[SerializeField]
	private GameObject m_PickupAxe;

	// Token: 0x0400041A RID: 1050
	[SerializeField]
	private GameObject m_SammyAxe;

	// Token: 0x0400041B RID: 1051
	private AudioClip[] m_SammyFootstepClips;

	// Token: 0x0400041C RID: 1052
	private AudioClip[] m_MonologueClips;

	// Token: 0x0400041D RID: 1053
	private AudioClip[] m_SpeakerMonologueClips;

	// Token: 0x0400041E RID: 1054
	private AudioClip m_MusicLittleDevilClip;

	// Token: 0x0400041F RID: 1055
	private AudioClip m_SammyMonologueBGClip;

	// Token: 0x04000420 RID: 1056
	private AudioClip m_DuctCrawlingClip;

	// Token: 0x04000421 RID: 1057
	private AudioClip m_RopeStressClip;

	// Token: 0x04000422 RID: 1058
	private AudioClip m_RopeStressSnapClip;

	// Token: 0x04000423 RID: 1059
	private AudioClip m_SpeakerTapClip;

	// Token: 0x04000424 RID: 1060
	private AudioClip m_DoorCloseClip;

	// Token: 0x04000425 RID: 1061
	private AudioObject m_MusicAudioObject;
}

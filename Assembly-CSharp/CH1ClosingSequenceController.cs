using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using S13Audio;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class CH1ClosingSequenceController : BaseController
{
	// Token: 0x060003BC RID: 956 RVA: 0x0002C9FC File Offset: 0x0002ABFC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_FinalEventTrigger.SetActive(false);
		this.m_EndSmoke.SetActive(false);
		this.m_RumbleAudioClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Rumble_Loop_01");
		this.m_VisionClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Visions_CH1");
		this.m_FlashClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Camera_Flash_02");
	}

	// Token: 0x060003BD RID: 957 RVA: 0x0002CA68 File Offset: 0x0002AC68
	public override void Activate()
	{
		S13AudioManager.Instance.InvokeEvent("evt_bendy_finale_scare", 0f);
		this.m_RumbleAudio = GameManager.Instance.AudioManager.Play(this.m_RumbleAudioClip, AudioObjectType.SOUND_EFFECT, -1, false);
		this.ScreenRumble();
		this.m_FinalEventTrigger.SetActive(true);
		this.m_FinalEventTrigger.OnEnter += this.HandleFinaleEventTriggerOnEnter;
	}

	// Token: 0x060003BE RID: 958 RVA: 0x0000588A File Offset: 0x00003A8A
	private void ScreenRumble()
	{
		GameManager.Instance.GameCamera.transform.DOShakePosition(0.5f, this.m_Intensity, this.m_Vibration, 90f, false, false).OnComplete(delegate
		{
			if (!base.IsDisposed)
			{
				if (this.m_Vibration < this.m_MaxVibration)
				{
					this.m_Vibration += this.m_VibrationIncrease;
				}
				if (this.m_Intensity < this.m_MaxIntensity)
				{
					this.m_Intensity += this.m_IntensityIncrease;
				}
				this.ScreenRumble();
			}
		});
	}

	// Token: 0x060003BF RID: 959 RVA: 0x000058CA File Offset: 0x00003ACA
	private void HandleFinaleEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_FinalEventTrigger.OnEnter -= this.HandleFinaleEventTriggerOnEnter;
		this.DOSequence().OnComplete(new TweenCallback(this.SequenceOnComplete));
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0002CAD0 File Offset: 0x0002ACD0
	private Sequence DOSequence()
	{
		this.ResetSequence();
		float num = 0f;
		float num2 = 1f;
		GameManager.Instance.Player.SetSlowed(true);
		GameManager.Instance.HideCrosshair();
		GameManager.Instance.AudioManager.Play(this.m_VisionClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Sequence.InsertCallback(num, delegate
		{
			this.m_ConclusionController = GameManager.Instance.UIManager.Show<CH1ConclusionModalController>("UI/Modals/CH1ConclusionModalController", "MODAL", null);
			this.m_ConclusionController.ShowImage(0);
		});
		num += num2;
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_FlashClip, AudioObjectType.SOUND_EFFECT, 0, false);
			this.m_ConclusionController.ShowImage(1);
			this.m_EndSmoke.SetActive(true);
		});
		num += num2;
		this.m_Sequence.Insert(num, this.m_RumbleAudio.AudioSource.DOFade(0f, 2.5f));
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_FlashClip, AudioObjectType.SOUND_EFFECT, 0, false);
			this.m_ConclusionController.ShowImage(2);
			RenderSettings.ambientIntensity = 0f;
			GameManager.Instance.GameCamera.transform.DOKill(false);
		});
		num += num2;
		this.m_Sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.Player.SetLock(true, false);
			GameManager.Instance.Player.SetLockedMovement(true);
			GameManager.Instance.Player.UnEquipWeapon();
			GameManager.Instance.GameCamera.transform.DOShakePosition(0.75f, this.m_Intensity, this.m_Vibration, 90f, false, true);
		});
		GameCamera gameCam = GameManager.Instance.GameCamera;
		if (gameCam.DoF)
		{
			gameCam.UnityDOF.manualDOF = true;
			float distance = gameCam.UnityDOF.focalDistance;
			this.m_Sequence.Insert(num, DOTween.To(() => distance, delegate(float value)
			{
				distance = value;
			}, 0f, 0.75f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				gameCam.UnityDOF.focalDistance = distance;
			}));
		}
		GameManager.Instance.ShowScreenBlocker(0.95f, num, null);
		this.m_Sequence.InsertCallback(num, delegate
		{
			Rigidbody rigidbody = global::UnityEngine.Object.Instantiate<Rigidbody>(this.m_Axe_Physics);
			rigidbody.transform.position = GameManager.Instance.Player.WeaponGameObject.transform.position;
			rigidbody.transform.rotation = GameManager.Instance.Player.WeaponGameObject.transform.rotation;
			rigidbody.AddForce(GameManager.Instance.Player.transform.forward * 5f, ForceMode.Impulse);
			global::UnityEngine.Object.Destroy(GameManager.Instance.Player.WeaponGameObject);
		});
		this.m_Sequence.Insert(num, GameManager.Instance.GameCamera.transform.DOMoveY(this.m_FinalEndRotation.position.y, 2f, false).SetEase(Ease.InQuad));
		this.m_Sequence.Insert(num, GameManager.Instance.GameCamera.transform.DORotateQuaternion(this.m_FinalEndRotation.rotation, 1.5f).SetEase(Ease.InQuad));
		num += 1f;
		this.m_Sequence.InsertCallback(num, delegate
		{
		});
		return this.m_Sequence;
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0002CD40 File Offset: 0x0002AF40
	private void SequenceOnComplete()
	{
		this.KillSequence();
		if (this.m_RumbleAudio != null)
		{
			this.m_RumbleAudio.Clear();
			this.m_RumbleAudio = null;
		}
		if (this.m_ConclusionController != null)
		{
			this.m_ConclusionController.Dispose();
		}
		base.SendOnComplete();
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x000058FB File Offset: 0x00003AFB
	private void ResetSequence()
	{
		this.KillSequence();
		this.m_Sequence = DOTween.Sequence();
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x0000590E File Offset: 0x00003B0E
	private void KillSequence()
	{
		if (this.m_Sequence != null)
		{
			this.m_Sequence.Kill(false);
			this.m_Sequence = null;
		}
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x0002CD98 File Offset: 0x0002AF98
	protected override void OnDisposed()
	{
		this.KillSequence();
		this.m_ConclusionController = null;
		this.m_RumbleAudio = null;
		this.m_RumbleAudioClip = null;
		this.m_VisionClip = null;
		this.m_FlashClip = null;
		if (this.m_FinalEventTrigger != null)
		{
			this.m_FinalEventTrigger.OnEnter -= this.HandleFinaleEventTriggerOnEnter;
		}
		base.OnDisposed();
	}

	// Token: 0x0400023C RID: 572
	[Header("< END >")]
	[SerializeField]
	private GameObject m_EndSmoke;

	// Token: 0x0400023D RID: 573
	[SerializeField]
	private Transform m_FinalInkEffect;

	// Token: 0x0400023E RID: 574
	[SerializeField]
	private Transform m_FinalEndRotation;

	// Token: 0x0400023F RID: 575
	[SerializeField]
	private EventTrigger m_FinalEventTrigger;

	// Token: 0x04000240 RID: 576
	[SerializeField]
	private Rigidbody m_Axe_Physics;

	// Token: 0x04000241 RID: 577
	private CH1ConclusionModalController m_ConclusionController;

	// Token: 0x04000242 RID: 578
	private Sequence m_Sequence;

	// Token: 0x04000243 RID: 579
	private AudioObject m_RumbleAudio;

	// Token: 0x04000244 RID: 580
	private AudioClip m_RumbleAudioClip;

	// Token: 0x04000245 RID: 581
	private AudioClip m_VisionClip;

	// Token: 0x04000246 RID: 582
	private AudioClip m_FlashClip;

	// Token: 0x04000247 RID: 583
	private float m_Intensity = 0.04f;

	// Token: 0x04000248 RID: 584
	private float m_IntensityIncrease = 0.05f;

	// Token: 0x04000249 RID: 585
	private float m_MaxIntensity = 0.175f;

	// Token: 0x0400024A RID: 586
	private int m_Vibration = 7;

	// Token: 0x0400024B RID: 587
	private int m_VibrationIncrease = 1;

	// Token: 0x0400024C RID: 588
	private int m_MaxVibration = 14;
}

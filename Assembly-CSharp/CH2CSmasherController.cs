using System;
using Ai;
using DG.Tweening;
using S13Audio;
using TMG.Core;
using UnityEngine;

// Token: 0x02000086 RID: 134
public class CH2CSmasherController : TMGMonoBehaviour
{
	// Token: 0x1700004F RID: 79
	// (get) Token: 0x060004D8 RID: 1240 RVA: 0x000067FC File Offset: 0x000049FC
	// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00006804 File Offset: 0x00004A04
	public bool IsDown { get; private set; }

	// Token: 0x060004DA RID: 1242 RVA: 0x00032F88 File Offset: 0x00031188
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Lever.Disable();
		this.m_LeverUp.Disable();
		this.IsDown = true;
		this.m_Lever.SetSingleInteraction(false);
		this.m_Lever.Activate(true);
		this.m_Lever.OnComplete += this.HandleLeverOnComplete;
		this.m_LeverUp.SetSingleInteraction(false);
		this.m_LeverUp.OnComplete += this.HandleLeverUpOnComplete;
		this.m_LeverUp.Activate(false);
		this.m_RumbleClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Rumble_Loop_01");
		this.m_Smasher.transform.position = this.m_BottomLocation.position;
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InternecionValue == 414)
		{
			this.m_MinerHat.SetActive(true);
		}
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x00033078 File Offset: 0x00031278
	private void HandleLeverOnComplete(object sender, EventArgs e)
	{
		this.IsDown = true;
		Sequence sequence = DOTween.Sequence();
		float num = 0.5f;
		if (this.m_SewerController != null && this.m_SewerController.m_CanKillJack)
		{
			sequence.InsertCallback(0.75f, new TweenCallback(this.m_SewerController.KillJack));
			this.m_SewerController = null;
		}
		sequence.InsertCallback(0.75f, delegate
		{
			this.m_Particles.Emit(30);
			Collider[] array = Physics.OverlapSphere(this.m_BottomLocation.position, 3.5f, LayerMask.GetMask(new string[] { "Ai" }));
			for (int i = 0; i < array.Length; i++)
			{
				BaseAiController component = array[i].GetComponent<BaseAiController>();
				if (component)
				{
					if (this.m_SearcherB && component.transform == this.m_SearcherB)
					{
						GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InternecionValue = 414;
						GameManager.Instance.GameData.CurrentSaveFile.Internecions[1] = 4;
						GameManager.Instance.GameDataManager.Save(true, false);
						this.m_MinerHat.SetActive(true);
						GameManager.Instance.GameCamera.VisionEffect.BeginEffect(false);
						DOTween.Sequence().InsertCallback(1f, delegate
						{
							GameManager.Instance.GameCamera.VisionEffect.EndEffect(false);
						});
						this.m_RumbleAudio = GameManager.Instance.AudioManager.Play(this.m_RumbleClip, AudioObjectType.SOUND_EFFECT, -1, false);
						GameManager.Instance.GameCamera.transform.DOShakePosition(5f, 0.1f, 15, 90f, false, false).OnComplete(new TweenCallback(this.ScreenRumbleOnComplete));
					}
					component.Dispose();
				}
			}
		});
		S13AudioManager.Instance.InvokeEvent("evt_sewer_puzzle_winch_down", 0f);
		sequence.Insert(num, this.m_Smasher.DOMove(this.m_BottomLocation.position, 1f, false).SetEase(Ease.OutBounce));
		sequence.OnComplete(new TweenCallback(this.SmasherDownOnComplete));
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x00033148 File Offset: 0x00031348
	private void ScreenRumbleOnComplete()
	{
		GameManager.Instance.GameCamera.transform.DOKill(false);
		GameManager.Instance.GameCamera.transform.DOLocalMove(Vector3.zero, 0.5f, false);
		this.m_RumbleAudio.AudioSource.DOFade(0f, 1f).OnComplete(delegate
		{
			if (this.m_RumbleAudio != null)
			{
				this.m_RumbleAudio.Clear();
				this.m_RumbleAudio = null;
			}
		});
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x0000680D File Offset: 0x00004A0D
	private void SmasherDownOnComplete()
	{
		this.m_LeverUp.DOReset();
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x000331B8 File Offset: 0x000313B8
	private void HandleLeverUpOnComplete(object sender, EventArgs e)
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0.5f;
		S13AudioManager.Instance.InvokeEvent("evt_sewer_puzzle_winch_up_start", 0f);
		sequence.Insert(num, this.m_Smasher.DOMove(this.m_TopLocation.position, 8f, false).SetEase(Ease.InQuad));
		sequence.OnComplete(new TweenCallback(this.SmasherUpOnComplete));
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x0000681A File Offset: 0x00004A1A
	private void SmasherUpOnComplete()
	{
		this.m_Lever.DOReset();
		this.IsDown = false;
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x00033224 File Offset: 0x00031424
	protected override void OnDisposed()
	{
		if (this.m_Lever)
		{
			this.m_Lever.OnComplete -= this.HandleLeverOnComplete;
		}
		if (this.m_LeverUp)
		{
			this.m_LeverUp.OnComplete -= this.HandleLeverOnComplete;
		}
		base.OnDisposed();
	}

	// Token: 0x0400035F RID: 863
	[SerializeField]
	private CH2SewerController m_SewerController;

	// Token: 0x04000360 RID: 864
	[SerializeField]
	private Transform m_Smasher;

	// Token: 0x04000361 RID: 865
	[SerializeField]
	private CH3LeverLight m_Lever;

	// Token: 0x04000362 RID: 866
	[SerializeField]
	private CH3LeverLight m_LeverUp;

	// Token: 0x04000363 RID: 867
	[SerializeField]
	private Transform m_TopLocation;

	// Token: 0x04000364 RID: 868
	[SerializeField]
	private Transform m_BottomLocation;

	// Token: 0x04000365 RID: 869
	[SerializeField]
	private ParticleSystem m_Particles;

	// Token: 0x04000366 RID: 870
	[SerializeField]
	private Transform m_SearcherB;

	// Token: 0x04000367 RID: 871
	[SerializeField]
	private GameObject m_MinerHat;

	// Token: 0x04000368 RID: 872
	private AudioClip m_RumbleClip;

	// Token: 0x04000369 RID: 873
	private AudioObject m_RumbleAudio;
}

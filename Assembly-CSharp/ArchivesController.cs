using System;
using DG.Tweening;
using I2.Loc;
using UnityEngine;

// Token: 0x020001C4 RID: 452
public class ArchivesController : BaseController
{
	// Token: 0x06001362 RID: 4962 RVA: 0x00076CDC File Offset: 0x00074EDC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.SetupGameSettings();
		GameManager.Instance.HideScreenBlocker(1f, 0f, null);
		this.m_Music = GameManager.Instance.AudioManager.Play("Audio/MUS/CH5/MUS_LonelyAngelViolinEdition", AudioObjectType.MUSIC, -1, false);
		this.m_HenryTrigger.OnEnter += this.HandleHenryOnEnter;
		this.m_HenryTrigger.SetActive(true);
		this.SetupLocalization();
	}

	// Token: 0x06001363 RID: 4963 RVA: 0x00076D50 File Offset: 0x00074F50
	private void SetupGameSettings()
	{
		AudioListener.volume = 0f;
		GameManager.Instance.ParticleManager.Initialize();
		if (GameManager.Instance.GameCamera)
		{
			GameManager.Instance.GameCamera.Brightness.SetBrightness(GameManager.Instance.PlayerSettings.Brightness);
		}
		this.m_Player.SetSensitivity(GameManager.Instance.PlayerSettings.Sensitivity);
		if (GameManager.Instance.AiGlobalNetwork != null)
		{
			GameManager.Instance.AiGlobalNetwork.Dispose();
		}
		GameManager.Instance.UnlockPause();
		DOTweenUtil.DOAudioListenerVolume(1f, 1f, null).SetDelay(0.5f).SetEase(Ease.InQuad);
	}

	// Token: 0x06001364 RID: 4964 RVA: 0x00076E10 File Offset: 0x00075010
	private void HandleHenryOnEnter(object sender, EventArgs e)
	{
		this.m_HenryTrigger.OnEnter -= this.HandleHenryOnEnter;
		DOTween.Sequence().InsertCallback(1f, delegate
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.STANDING_PROUD);
		});
	}

	// Token: 0x06001365 RID: 4965 RVA: 0x00076E64 File Offset: 0x00075064
	private void SetupLocalization()
	{
		if (ArchivesController.localizationParamsManager == null)
		{
			ArchivesController.localizationParamsManager = new ArchivesController.LocalizationSupport();
			if (!LocalizationManager.ParamManagers.Contains(ArchivesController.localizationParamsManager))
			{
				Debug.Log("<color=green>-- Adding Localization Support object for Globals replacement --</color>", this);
				LocalizationManager.ParamManagers.Add(ArchivesController.localizationParamsManager);
				LocalizationManager.LocalizeAll(true);
			}
		}
	}

	// Token: 0x06001366 RID: 4966 RVA: 0x0000FFF1 File Offset: 0x0000E1F1
	protected override void OnDisposed()
	{
		if (this.m_Music != null)
		{
			this.m_Music.Clear();
			this.m_Music = null;
		}
		base.OnDisposed();
	}

	// Token: 0x04000F75 RID: 3957
	[SerializeField]
	private PlayerController m_Player;

	// Token: 0x04000F76 RID: 3958
	[SerializeField]
	private EventTrigger m_HenryTrigger;

	// Token: 0x04000F77 RID: 3959
	private AudioObject m_Music;

	// Token: 0x04000F78 RID: 3960
	protected static ILocalizationParamsManager localizationParamsManager;

	// Token: 0x020001C5 RID: 453
	protected class LocalizationSupport : ILocalizationParamsManager
	{
		// Token: 0x06001369 RID: 4969 RVA: 0x0000D05D File Offset: 0x0000B25D
		public string GetParameterValue(string Param)
		{
			if (Param != null)
			{
				if (Param == "N")
				{
					return "\n";
				}
			}
			return null;
		}
	}
}

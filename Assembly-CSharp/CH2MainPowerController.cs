using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// Token: 0x0200008A RID: 138
public class CH2MainPowerController : BaseController
{
	// Token: 0x06000505 RID: 1285 RVA: 0x000340A0 File Offset: 0x000322A0
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Henry07Clip = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_07");
		this.m_HenryClip08 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_08");
		this.m_PowerLeverClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Mainr_Power_Lever_Turn_On_01");
		this.m_LightClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Light_Switch_Sammys_Room_01");
		this.m_LobbyEntranceMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH4/MUS_OldLightHead");
		this.m_EntranceTrigger.SetActive(false);
		for (int i = 0; i < this.m_LobbyLights.Count; i++)
		{
			GameObject lights = this.m_LobbyLights[i].Lights;
			if (lights != null)
			{
				IEnumerator enumerator = lights.transform.parent.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Transform transform = (Transform)obj;
						if (transform.name == lights.name + " REPLACEMENT")
						{
							this.m_LobbyLights[i].Lights = transform.gameObject;
							break;
						}
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = enumerator as IDisposable) != null)
					{
						disposable.Dispose();
					}
				}
			}
			this.TurnOffLobbyLight(this.m_LobbyLights[i]);
		}
		for (int j = 0; j < this.m_MusicRoomLights.Count; j++)
		{
			GameObject lights2 = this.m_MusicRoomLights[j].Lights;
			if (lights2 != null)
			{
				IEnumerator enumerator2 = lights2.transform.parent.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						Transform transform2 = (Transform)obj2;
						if (transform2.name == lights2.name + " REPLACEMENT")
						{
							this.m_MusicRoomLights[j].Lights = transform2.gameObject;
							break;
						}
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = enumerator2 as IDisposable) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			this.TurnOffLobbyLight(this.m_MusicRoomLights[j]);
		}
		for (int k = 0; k < this.m_LobbyLongLights.Count; k++)
		{
			this.m_LobbyLongLights[k].TurnOff();
		}
		for (int l = 0; l < this.m_RecordingLbls.Count; l++)
		{
			this.m_RecordingLbls[l].SetActive(false);
		}
		this.m_InkStairwellEventTrigger.SetActive(false);
		this.m_DarknessProjection.SetActive(true);
		this.m_Lever.SetActive(false);
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00034380 File Offset: 0x00032580
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicDepartmentObjective.IsStarted)
		{
			this.ForceComplete();
			return;
		}
		this.m_EntranceTrigger.OnEnter += this.HandleEntranceTriggerOnEnter;
		this.m_EntranceTrigger.SetActive(true);
		this.m_InkStairwellEventTrigger.OnEnter += this.HandleInkStairwellEventTriggerOnEnter;
		this.m_InkStairwellEventTrigger.SetActive(true);
		this.m_Lever.OnInteracted += this.HandleLeverOnInteracted;
		this.m_Lever.OnComplete += this.HandleLeverOnComplete;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x0003442C File Offset: 0x0003262C
	private void HandleEntranceTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_EntranceTrigger.OnEnter -= this.HandleEntranceTriggerOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_Henry07Clip, "DIACH2/DIA_CH2_HENRY_07", false));
		GameManager.Instance.AudioManager.Play(this.m_LobbyEntranceMusicClip, AudioObjectType.MUSIC, 0, false);
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00034488 File Offset: 0x00032688
	private void HandleLeverOnInteracted(object sender, EventArgs e)
	{
		this.m_Lever.OnInteracted -= this.HandleLeverOnInteracted;
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_PowerLeverClip, this.m_Lever.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_SearcherSpawnInkDrip.SetActive(true);
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x000344E4 File Offset: 0x000326E4
	private void HandleLeverOnComplete(object sender, EventArgs e)
	{
		this.m_Lever.OnComplete -= this.HandleLeverOnComplete;
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.MusicDepartmentObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.DOPowerSequence().OnComplete(new TweenCallback(base.SendOnComplete));
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00034550 File Offset: 0x00032750
	private void HandleInkStairwellEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_InkStairwellEventTrigger.OnEnter -= this.HandleInkStairwellEventTriggerOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip08, "DIACH2/DIA_CH2_HENRY_08", false));
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_STAIRWELL", "OBJECTIVES/CH2_OBJECTIVE_STAIRWELL_TIP", 4f, false, 0f));
		this.m_Lever.SetActive(true);
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x000345C8 File Offset: 0x000327C8
	private Sequence DOPowerSequence()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		for (int i = 0; i < this.m_LobbyLights.Count; i++)
		{
			CH2MainPowerController.LobbyLights lobbyLight = this.m_LobbyLights[i];
			sequence.InsertCallback(num, delegate
			{
				GameManager.Instance.AudioManager.Play(this.m_LightClip, AudioObjectType.SOUND_EFFECT, 0, false);
				this.TurnOnLobbyLight(lobbyLight);
			});
			num += 0.75f;
		}
		for (int j = 0; j < this.m_LobbyLongLights.Count; j++)
		{
			LightController lightController = this.m_LobbyLongLights[j];
			sequence.InsertCallback(num - 0.75f, delegate
			{
				lightController.TurnOff();
			});
		}
		for (int k = 0; k < this.m_MusicRoomLights.Count; k++)
		{
			CH2MainPowerController.LobbyLights musicRoomLight = this.m_MusicRoomLights[k];
			sequence.InsertCallback(num, delegate
			{
				this.TurnOnLobbyLight(musicRoomLight);
			});
		}
		num += 0.5f;
		sequence.InsertCallback(num, new TweenCallback(this.TurnOnRecordingLabels));
		return sequence;
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00034704 File Offset: 0x00032904
	private void TurnOnRecordingLabels()
	{
		this.m_DarknessProjection.SetActive(false);
		for (int i = 0; i < this.m_RecordingLbls.Count; i++)
		{
			this.m_RecordingLbls[i].SetActive(true);
		}
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x000069C6 File Offset: 0x00004BC6
	private void TurnOnLobbyLight(CH2MainPowerController.LobbyLights lobbyLight)
	{
		if (lobbyLight.LightFixture)
		{
			lobbyLight.LightFixture.TurnOn();
		}
		if (lobbyLight.Lights)
		{
			lobbyLight.Lights.SetActive(true);
		}
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x000069FF File Offset: 0x00004BFF
	private void TurnOffLobbyLight(CH2MainPowerController.LobbyLights lobbyLight)
	{
		if (lobbyLight.LightFixture)
		{
			lobbyLight.LightFixture.TurnOff();
		}
		if (lobbyLight.Lights)
		{
			lobbyLight.Lights.SetActive(false);
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x0003474C File Offset: 0x0003294C
	private void ForceComplete()
	{
		this.TurnOnRecordingLabels();
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_STAIRWELL", "OBJECTIVES/CH2_OBJECTIVE_STAIRWELL_TIP", 0f, false, 0f));
		this.m_Lever.ForceOpen();
		this.m_SearcherSpawnInkDrip.SetActive(true);
		for (int i = 0; i < this.m_LobbyLights.Count; i++)
		{
			this.TurnOnLobbyLight(this.m_LobbyLights[i]);
		}
		for (int j = 0; j < this.m_LobbyLongLights.Count; j++)
		{
			this.m_LobbyLongLights[j].TurnOn();
		}
		for (int k = 0; k < this.m_MusicRoomLights.Count; k++)
		{
			this.TurnOnLobbyLight(this.m_MusicRoomLights[k]);
		}
		base.SendOnComplete();
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00034830 File Offset: 0x00032A30
	protected override void OnDisposed()
	{
		this.m_Henry07Clip = null;
		this.m_HenryClip08 = null;
		this.m_LightClip = null;
		this.m_PowerLeverClip = null;
		this.m_LobbyEntranceMusicClip = null;
		if (this.m_InkStairwellEventTrigger != null)
		{
			this.m_InkStairwellEventTrigger.OnEnter -= this.HandleInkStairwellEventTriggerOnEnter;
		}
		base.OnDisposed();
	}

	// Token: 0x04000391 RID: 913
	[Header("Triggers")]
	[SerializeField]
	private EventTrigger m_EntranceTrigger;

	// Token: 0x04000392 RID: 914
	[Header("Objective: Turn On Lobby Lights")]
	[SerializeField]
	private InteractablePowerLever m_Lever;

	// Token: 0x04000393 RID: 915
	[SerializeField]
	private List<GameObject> m_RecordingLbls;

	// Token: 0x04000394 RID: 916
	[SerializeField]
	private List<CH2MainPowerController.LobbyLights> m_LobbyLights;

	// Token: 0x04000395 RID: 917
	[SerializeField]
	private List<LightController> m_LobbyLongLights;

	// Token: 0x04000396 RID: 918
	[SerializeField]
	private List<CH2MainPowerController.LobbyLights> m_MusicRoomLights;

	// Token: 0x04000397 RID: 919
	[SerializeField]
	private EventTrigger m_InkStairwellEventTrigger;

	// Token: 0x04000398 RID: 920
	[SerializeField]
	private GameObject m_DarknessProjection;

	// Token: 0x04000399 RID: 921
	[SerializeField]
	private GameObject m_SearcherSpawnInkDrip;

	// Token: 0x0400039A RID: 922
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x0400039B RID: 923
	private AudioClip m_Henry07Clip;

	// Token: 0x0400039C RID: 924
	private AudioClip m_HenryClip08;

	// Token: 0x0400039D RID: 925
	private AudioClip m_PowerLeverClip;

	// Token: 0x0400039E RID: 926
	private AudioClip m_LightClip;

	// Token: 0x0400039F RID: 927
	private AudioClip m_LobbyEntranceMusicClip;

	// Token: 0x0200008B RID: 139
	[Serializable]
	private class LobbyLights
	{
		// Token: 0x040003A0 RID: 928
		public LightFixtureController LightFixture;

		// Token: 0x040003A1 RID: 929
		public GameObject Lights;
	}
}

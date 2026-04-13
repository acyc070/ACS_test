using System;
using TMG.Core;
using UnityEngine;

// Token: 0x0200006E RID: 110
public class CH1GeneralController : TMGMonoBehaviour
{
	// Token: 0x060003E8 RID: 1000 RVA: 0x0002D7BC File Offset: 0x0002B9BC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_HenryClip08 = GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_08");
		this.m_HenryClip11 = GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_11");
		this.m_HenryClip12 = GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_12");
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Inkwell.IsStarted)
		{
			this.m_HenryOldDesk.OnEnter += this.HandleHenryOldDeskOnEnter;
			this.m_HenryArtRoom.OnEnter += this.HandleHenryArtRoomOnEnter;
		}
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Wrench.IsStarted)
		{
			this.m_BorisRoom.OnEnter += this.HandleBorisRoomOnEnter;
		}
		this.m_ProjectorInteract.OnInteracted += this.HandleProjectorOnInteract;
		this.m_Projector.FilmAudioObject = GameManager.Instance.AudioManager.PlayAtPosition("Audio/SFX/SFX_Projector_Run_With_Film_01", this.m_Projector.AudioPosition.position, AudioObjectType.SOUND_EFFECT, -1, false, null);
		this.m_Projector.MusicAudioObject = GameManager.Instance.AudioManager.PlayAtPosition("Audio/MUS/CH1/MUS_Hellfire_Follies", this.m_Projector.MusicPosition.position, AudioObjectType.SOUND_EFFECT, -1, false, this.m_Projector.MusicPosition);
		this.m_Projector.InitTurnOn();
		this.m_IsProjectorOn = true;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x00005A69 File Offset: 0x00003C69
	private void HandleHenryOldDeskOnEnter(object sender, EventArgs e)
	{
		this.m_HenryOldDesk.OnEnter -= this.HandleHenryOldDeskOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip11, "DIACH1/DIA_CH1_HENRY_11", false));
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00005A9E File Offset: 0x00003C9E
	private void HandleHenryArtRoomOnEnter(object sender, EventArgs e)
	{
		this.m_HenryArtRoom.OnEnter -= this.HandleHenryArtRoomOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip12, "DIACH1/DIA_CH1_HENRY_12", false));
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00005AD3 File Offset: 0x00003CD3
	private void HandleBorisRoomOnEnter(object sender, EventArgs e)
	{
		this.m_BorisRoom.OnEnter -= this.HandleBorisRoomOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip08, "DIACH1/DIA_CH1_HENRY_08", false));
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0002D944 File Offset: 0x0002BB44
	private void HandleProjectorOnInteract(object sender, EventArgs e)
	{
		if (this.m_IsProjectorOn)
		{
			this.TurnOff();
			this.m_IsProjectorOn = false;
		}
		else
		{
			this.m_Projector.FilmAudioObject = GameManager.Instance.AudioManager.PlayAtPosition("Audio/SFX/SFX_Projector_Run_With_Film_01", this.m_Projector.AudioPosition.position, AudioObjectType.SOUND_EFFECT, -1, false, null);
			this.m_Projector.MusicAudioObject = GameManager.Instance.AudioManager.PlayAtPosition("Audio/MUS/CH1/MUS_Hellfire_Follies", this.m_Projector.MusicPosition.position, AudioObjectType.SOUND_EFFECT, -1, false, this.m_Projector.MusicPosition);
			this.TurnOn();
			this.m_IsProjectorOn = true;
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00005B08 File Offset: 0x00003D08
	public void TurnOn()
	{
		this.m_Projector.TurnOn(false);
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00005B16 File Offset: 0x00003D16
	public void TurnOff()
	{
		this.m_Projector.TurnOff();
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00005B23 File Offset: 0x00003D23
	public void ShutDown()
	{
		this.TurnOff();
		this.m_ProjectorInteract.OnInteracted -= this.HandleProjectorOnInteract;
		this.m_ProjectorInteract.SetActive(false);
		base.Dispose();
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x0002D9EC File Offset: 0x0002BBEC
	protected override void OnDisposed()
	{
		this.m_ProjectorInteract.OnInteracted -= this.HandleProjectorOnInteract;
		if (this.m_BorisRoom != null)
		{
			this.m_BorisRoom.OnEnter -= this.HandleBorisRoomOnEnter;
			this.m_BorisRoom.Dispose();
		}
		if (this.m_HenryOldDesk != null)
		{
			this.m_HenryOldDesk.OnEnter -= this.HandleHenryOldDeskOnEnter;
			this.m_HenryOldDesk.Dispose();
		}
		if (this.m_HenryArtRoom != null)
		{
			this.m_HenryArtRoom.OnEnter -= this.HandleHenryArtRoomOnEnter;
			this.m_HenryArtRoom.Dispose();
		}
		this.m_HenryClip08 = null;
		this.m_HenryClip11 = null;
		this.m_HenryClip12 = null;
		base.OnDisposed();
	}

	// Token: 0x04000263 RID: 611
	[Header("Interactable")]
	[SerializeField]
	private Interactable m_ProjectorInteract;

	// Token: 0x04000264 RID: 612
	[SerializeField]
	private ProjectorController m_Projector;

	// Token: 0x04000265 RID: 613
	[Header("Audio")]
	[SerializeField]
	private EventTrigger m_HenryOldDesk;

	// Token: 0x04000266 RID: 614
	[SerializeField]
	private EventTrigger m_HenryArtRoom;

	// Token: 0x04000267 RID: 615
	[SerializeField]
	private EventTrigger m_BorisRoom;

	// Token: 0x04000268 RID: 616
	private AudioClip m_HenryClip08;

	// Token: 0x04000269 RID: 617
	private AudioClip m_HenryClip11;

	// Token: 0x0400026A RID: 618
	private AudioClip m_HenryClip12;

	// Token: 0x0400026B RID: 619
	private bool m_IsProjectorOn;
}

using System;
using UnityEngine;

// Token: 0x02000076 RID: 118
public class CH1SammysRoomController : BaseController
{
	// Token: 0x06000435 RID: 1077 RVA: 0x0002EF60 File Offset: 0x0002D160
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_LightClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Light_Switch_Sammys_Room_01");
		this.m_RoomMusicAudioObject = GameManager.Instance.AudioManager.PlayAtPosition("Audio/MUS/CH1/MUS_Ode_To_Bendy_Loop_Through_Door_01", this.m_MusicPosition.position, AudioObjectType.SOUND_EFFECT, -1, false, null);
		this.m_Door.Lock();
		this.m_EventTrigger.SetActive(false);
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0000600C File Offset: 0x0000420C
	public override void Activate()
	{
		this.m_EventTrigger.SetActive(true);
		this.m_EventTrigger.OnEnter += this.HandleEventTriggerOnEnter;
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00006031 File Offset: 0x00004231
	private void HandleEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_EventTrigger.OnEnter -= this.HandleEventTriggerOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_LightClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.UnlockRoom();
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0002EFC8 File Offset: 0x0002D1C8
	public void UnlockRoom()
	{
		if (this.m_RoomMusicAudioObject != null)
		{
			this.m_RoomMusicAudioObject.Clear();
			this.m_RoomMusicAudioObject = null;
		}
		this.m_LightBar.SetActive(false);
		this.m_InnerLights.SetActive(true);
		this.m_Door.Unlock();
		base.Dispose();
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0002F024 File Offset: 0x0002D224
	public void ForceOpen()
	{
		if (this.m_RoomMusicAudioObject != null)
		{
			this.m_RoomMusicAudioObject.Clear();
			this.m_RoomMusicAudioObject = null;
		}
		this.m_LightBar.SetActive(false);
		this.m_InnerLights.SetActive(true);
		this.m_Door.ForceOpen(145f);
		this.m_Door.Lock();
		base.Dispose();
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0002F090 File Offset: 0x0002D290
	public void ForceClose()
	{
		if (this.m_EventTrigger != null)
		{
			this.m_EventTrigger.OnEnter -= this.HandleEventTriggerOnEnter;
		}
		if (this.m_RoomMusicAudioObject != null)
		{
			this.m_RoomMusicAudioObject.Clear();
			this.m_RoomMusicAudioObject = null;
		}
		this.m_LightBar.SetActive(false);
		this.m_Door.Lock();
		base.SendOnComplete();
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x00006069 File Offset: 0x00004269
	protected override void OnDisposed()
	{
		this.m_RoomMusicAudioObject = null;
		this.m_LightClip = null;
		this.m_EventTrigger.OnEnter -= this.HandleEventTriggerOnEnter;
		base.OnDisposed();
	}

	// Token: 0x040002AD RID: 685
	[Header("Transforms")]
	[SerializeField]
	private Transform m_MusicPosition;

	// Token: 0x040002AE RID: 686
	[Header("GameObjects")]
	[SerializeField]
	private GameObject m_LightBar;

	// Token: 0x040002AF RID: 687
	[SerializeField]
	private GameObject m_InnerLights;

	// Token: 0x040002B0 RID: 688
	[Header("Door")]
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x040002B1 RID: 689
	[Header("< Event Triggers >")]
	[SerializeField]
	private EventTrigger m_EventTrigger;

	// Token: 0x040002B2 RID: 690
	private AudioObject m_RoomMusicAudioObject;

	// Token: 0x040002B3 RID: 691
	private AudioClip m_LightClip;
}

using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// Token: 0x0200008F RID: 143
public class CH2MusicController : BaseController
{
	// Token: 0x06000519 RID: 1305 RVA: 0x00006A89 File Offset: 0x00004C89
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_MusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH2/MUS_Lobby_Jazz_01");
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00034890 File Offset: 0x00032A90
	private void Update()
	{
		if (!this.m_IsActive && this.m_MusicAudioObject == null)
		{
			return;
		}
		Transform transform = GameManager.Instance.Player.transform;
		if (transform.position.x < this.m_MusicPositionRight.position.x && transform.position.x > this.m_MusicPositionLeft.position.x)
		{
			Vector3 worldPosition = this.m_MusicAudioObject.WorldPosition;
			worldPosition.x = transform.position.x;
			this.m_MusicAudioObject.WorldPosition = worldPosition;
		}
		if (transform.position.z < this.m_MusicPositionForward.position.z && transform.position.z > this.m_MusicPositionBack.position.z)
		{
			Vector3 worldPosition2 = this.m_MusicAudioObject.WorldPosition;
			worldPosition2.z = transform.position.z;
			this.m_MusicAudioObject.WorldPosition = worldPosition2;
		}
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x000349C8 File Offset: 0x00032BC8
	public override void Activate()
	{
		this.m_MusicAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_MusicClip, this.m_MusicPositionForward.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_MusicAudioObject.OnComplete += this.HandleMusicOnComplete;
		for (int i = 0; i < this.m_Speakers.Count; i++)
		{
			this.m_Speakers[i].DOKill(false);
			this.m_Speakers[i].DOScale(1.025f, 0.225f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo)
				.SetDelay(2f);
		}
		this.m_IsActive = true;
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00034A80 File Offset: 0x00032C80
	private void HandleMusicOnComplete(object sender, EventArgs e)
	{
		this.m_MusicAudioObject.OnComplete -= this.HandleMusicOnComplete;
		this.ClearLobbyMusic();
		for (int i = 0; i < this.m_Speakers.Count; i++)
		{
			this.m_Speakers[i].DOKill(false);
			this.m_Speakers[i].localScale = Vector3.one;
		}
		base.Dispose();
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00006AA6 File Offset: 0x00004CA6
	private void ClearLobbyMusic()
	{
		if (this.m_MusicAudioObject != null)
		{
			this.m_MusicAudioObject.Clear();
			this.m_MusicAudioObject = null;
		}
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00034AF8 File Offset: 0x00032CF8
	protected override void OnDisposed()
	{
		this.ClearLobbyMusic();
		this.m_MusicAudioObject = null;
		this.m_MusicClip = null;
		for (int i = 0; i < this.m_Speakers.Count; i++)
		{
			this.m_Speakers[i].DOKill(false);
		}
		base.OnDisposed();
	}

	// Token: 0x040003A7 RID: 935
	[Header("Music")]
	[SerializeField]
	private Transform m_MusicPositionLeft;

	// Token: 0x040003A8 RID: 936
	[SerializeField]
	private Transform m_MusicPositionRight;

	// Token: 0x040003A9 RID: 937
	[SerializeField]
	private Transform m_MusicPositionForward;

	// Token: 0x040003AA RID: 938
	[SerializeField]
	private Transform m_MusicPositionBack;

	// Token: 0x040003AB RID: 939
	[SerializeField]
	private List<Transform> m_Speakers;

	// Token: 0x040003AC RID: 940
	private AudioObject m_MusicAudioObject;

	// Token: 0x040003AD RID: 941
	private AudioClip m_MusicClip;
}

using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000221 RID: 545
public class AudioPlayer : Interactable
{
	// Token: 0x0600155D RID: 5469 RVA: 0x000116E2 File Offset: 0x0000F8E2
	public override void Init()
	{
		base.Init();
	}

	// Token: 0x0600155E RID: 5470 RVA: 0x0007D364 File Offset: 0x0007B564
	public override void OnInteract()
	{
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_AudioClip, base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		if (this.m_EnableAnimation && this.m_AudioPlayer != null)
		{
			this.m_AudioPlayer.DOScale(1.01f, 0.2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
			base.StartCoroutine(this.HandleAudioClipOnComplete(this.m_AudioClip.length));
		}
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x0007D3F0 File Offset: 0x0007B5F0
	private IEnumerator HandleAudioClipOnComplete(float delay)
	{
		yield return new WaitForSeconds(delay);
		this.KillAudioTween();
		this.m_AudioPlayer.localScale = Vector3.one;
		yield break;
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x000116EA File Offset: 0x0000F8EA
	private void KillAudioTween()
	{
		this.m_AudioPlayer.DOKill(false);
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x000116F9 File Offset: 0x0000F8F9
	protected override void OnDisposed()
	{
		this.KillAudioTween();
		base.OnDisposed();
	}

	// Token: 0x0400133D RID: 4925
	[Header("Audio Player Options")]
	[SerializeField]
	private Transform m_AudioPlayer;

	// Token: 0x0400133E RID: 4926
	[SerializeField]
	private AudioClip m_AudioClip;

	// Token: 0x0400133F RID: 4927
	[SerializeField]
	private bool m_EnableAnimation = true;
}

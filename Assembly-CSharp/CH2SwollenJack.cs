using System;
using S13Audio;
using TMG.Core;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class CH2SwollenJack : TMGMonoBehaviour
{
	// Token: 0x17000055 RID: 85
	// (get) Token: 0x060005FB RID: 1531 RVA: 0x000075C7 File Offset: 0x000057C7
	public Transform Hat
	{
		get
		{
			return this.m_Hat;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x060005FC RID: 1532 RVA: 0x000075CF File Offset: 0x000057CF
	public Interactable Valve
	{
		get
		{
			return this.m_Valve;
		}
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x000393AC File Offset: 0x000375AC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_AudioSwitch = base.GetComponentInChildren<S13Switch>();
		this.m_Hit = GameManager.Instance.GetAudioClip("Audio/SFX/Characters/SwollenSearchers/CH3_SWOLLEN_SEARCHER_HIT");
		this.m_IdleClip = GameManager.Instance.GetAudioClip("Audio/SFX/Characters/SwollenSearchers/CH3_SWOLLEN_SEARCHER_IDLE");
		base.transform.SetParent(null);
		this.m_SplatDecal.SetActive(false);
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x000075D7 File Offset: 0x000057D7
	public void PlayAudio()
	{
		this.m_ActiveAudio = GameManager.Instance.AudioManager.PlayAtPosition(this.m_IdleClip, this.m_EyeLocation.position, AudioObjectType.SOUND_EFFECT, -1, false, base.transform);
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x00039410 File Offset: 0x00037610
	public void Kill(bool isSilent = false)
	{
		this.m_InkExplosion.shape.skinnedMeshRenderer = this.m_Renderer as SkinnedMeshRenderer;
		this.m_InkDrops.shape.skinnedMeshRenderer = this.m_Renderer as SkinnedMeshRenderer;
		this.m_Renderer.enabled = false;
		this.Explode(false);
		this.m_InkRain.Stop();
		this.m_InkPuddle.Stop();
		this.m_InkPuddle.transform.SetParent(null);
		global::UnityEngine.Object.Destroy(this.m_InkPuddle.gameObject, 5f);
		this.m_InkExplosionEffects.transform.SetParent(null);
		global::UnityEngine.Object.Destroy(this.m_InkExplosionEffects, 5f);
		this.m_SplatDecal.SetActive(true);
		this.m_SplatDecal.transform.SetParent(null);
		base.Dispose();
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x000394EC File Offset: 0x000376EC
	private void Explode(bool isSilent = false)
	{
		if (!isSilent)
		{
			this.m_AudioSwitch.Play("death");
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_Hit, this.m_EyeLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
			this.m_InkExplosion.Emit(15);
			this.m_InkDrops.Emit(10);
		}
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x00007608 File Offset: 0x00005808
	public void Show()
	{
		this.m_AudioSwitch.Play("appear");
		this.m_Animator.SetBool("IsHiding", false);
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x0000762B File Offset: 0x0000582B
	public void Hide()
	{
		this.m_AudioSwitch.Play("hide");
		this.m_Animator.SetBool("IsHiding", true);
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x0000764E File Offset: 0x0000584E
	private void ClearAudio()
	{
		if (this.m_ActiveAudio != null)
		{
			this.m_ActiveAudio.Clear();
			this.m_ActiveAudio = null;
		}
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x00007673 File Offset: 0x00005873
	protected override void OnDisposed()
	{
		this.ClearAudio();
		this.m_Hit = null;
		this.m_AudioSwitch = null;
		base.OnDisposed();
	}

	// Token: 0x04000499 RID: 1177
	[SerializeField]
	private Transform m_EyeLocation;

	// Token: 0x0400049A RID: 1178
	[SerializeField]
	private Transform m_Hat;

	// Token: 0x0400049B RID: 1179
	[SerializeField]
	private Interactable m_Valve;

	// Token: 0x0400049C RID: 1180
	[SerializeField]
	private Animator m_Animator;

	// Token: 0x0400049D RID: 1181
	[SerializeField]
	private Renderer m_Renderer;

	// Token: 0x0400049E RID: 1182
	[Header("Particles")]
	[SerializeField]
	private GameObject m_InkExplosionEffects;

	// Token: 0x0400049F RID: 1183
	[SerializeField]
	private ParticleSystem m_InkRain;

	// Token: 0x040004A0 RID: 1184
	[SerializeField]
	private ParticleSystem m_InkPuddle;

	// Token: 0x040004A1 RID: 1185
	[SerializeField]
	private ParticleSystem m_InkExplosion;

	// Token: 0x040004A2 RID: 1186
	[SerializeField]
	private ParticleSystem m_InkDrops;

	// Token: 0x040004A3 RID: 1187
	[Header("Decal")]
	[SerializeField]
	private GameObject m_SplatDecal;

	// Token: 0x040004A4 RID: 1188
	private AudioObject m_ActiveAudio;

	// Token: 0x040004A5 RID: 1189
	private AudioClip m_IdleClip;

	// Token: 0x040004A6 RID: 1190
	private S13Switch m_AudioSwitch;

	// Token: 0x040004A7 RID: 1191
	private AudioClip m_Hit;
}

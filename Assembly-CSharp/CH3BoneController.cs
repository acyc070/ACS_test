using System;
using TMG.Core;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class CH3BoneController : TMGMonoBehaviour
{
	// Token: 0x1700005D RID: 93
	// (get) Token: 0x06000683 RID: 1667 RVA: 0x00007707 File Offset: 0x00005907
	private BorisAi m_Boris
	{
		get
		{
			return GameManager.Instance.CharacterManager.Boris;
		}
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x00007C65 File Offset: 0x00005E65
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Bone.SetActive(false);
		this.m_PickupClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_genericpickup");
		this.m_TakeBoneClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_boristakesbone");
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x0003C2D4 File Offset: 0x0003A4D4
	public void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HasBorisBone)
		{
			this.m_Bone.gameObject.SetActive(true);
			this.m_Bone.transform.SetParent(this.m_Boris.Mouth);
			this.m_Bone.transform.localPosition = Vector3.zero;
			this.m_Bone.transform.localEulerAngles = Vector3.zero;
			base.Dispose();
			return;
		}
		this.m_Bone.SetActive(true);
		this.m_Bone.OnInteracted += this.HandleBoneOnInteracted;
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x0003C380 File Offset: 0x0003A580
	private void HandleBoneOnInteracted(object sender, EventArgs e)
	{
		this.m_Bone.OnInteracted -= this.HandleBoneOnInteracted;
		this.m_Bone.SetActive(false);
		GameManager.Instance.AudioManager.Play(this.m_PickupClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Bone.gameObject.SetActive(false);
		this.m_Bone.transform.SetParent(this.m_Boris.Mouth);
		this.m_Bone.transform.localPosition = Vector3.zero;
		this.m_Bone.transform.localEulerAngles = Vector3.zero;
		this.m_Boris.Interact.SetActive(true);
		this.m_Boris.Interact.OnInteracted += this.HandleBorisOnInteracted;
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x0003C44C File Offset: 0x0003A64C
	private void HandleBorisOnInteracted(object sender, EventArgs e)
	{
		this.m_Boris.Interact.OnInteracted -= this.HandleBorisOnInteracted;
		this.m_Boris.Interact.SetActive(false);
		GameManager.Instance.AudioManager.Play(this.m_TakeBoneClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Bone.gameObject.SetActive(true);
		GameManager.Instance.AchievementManager.SetAchievement(AchievementName.KNICK_KNACK_PADDYWHACK);
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.HasBorisBone = true;
		base.Dispose();
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x0003C4E4 File Offset: 0x0003A6E4
	protected override void OnDisposed()
	{
		this.m_PickupClip = null;
		this.m_TakeBoneClip = null;
		if (this.m_Boris)
		{
			this.m_Boris.Interact.OnInteracted -= this.HandleBorisOnInteracted;
		}
		if (this.m_Bone)
		{
			this.m_Bone.OnInteracted -= this.HandleBoneOnInteracted;
		}
		base.OnDisposed();
	}

	// Token: 0x0400051C RID: 1308
	[Header("Interactables")]
	[SerializeField]
	private Interactable m_Bone;

	// Token: 0x0400051D RID: 1309
	private AudioClip m_PickupClip;

	// Token: 0x0400051E RID: 1310
	private AudioClip m_TakeBoneClip;
}

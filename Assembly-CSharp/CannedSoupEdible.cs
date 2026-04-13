using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000226 RID: 550
public class CannedSoupEdible : Interactable
{
	// Token: 0x06001578 RID: 5496 RVA: 0x00011781 File Offset: 0x0000F981
	public override void OnInteract()
	{
		this.PlayEatSound();
		base.Dispose();
	}

	// Token: 0x06001579 RID: 5497 RVA: 0x0007D9A8 File Offset: 0x0007BBA8
	public void PlayEatSound()
	{
		GameManager.Instance.Heal();
		if (this.m_AudioClips == null || this.m_AudioClips.Count <= 0)
		{
			return;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_AudioClips.Count);
		GameManager.Instance.AudioManager.Play(this.m_AudioClips[num], AudioObjectType.SOUND_EFFECT, 0, false);
	}

	// Token: 0x0600157A RID: 5498 RVA: 0x0007DA10 File Offset: 0x0007BC10
	public int SetID(int CurrentIDCount)
	{
		if (this.ID != -1)
		{
			return this.ID;
		}
		return this.ID = ++CurrentIDCount;
	}

	// Token: 0x0600157B RID: 5499 RVA: 0x0001178F File Offset: 0x0000F98F
	public int GetID()
	{
		if (this.ID != -1)
		{
			return this.ID;
		}
		return -1;
	}

	// Token: 0x0600157C RID: 5500 RVA: 0x000117A5 File Offset: 0x0000F9A5
	public void ResetID()
	{
		this.ID = -1;
	}

	// Token: 0x0400135A RID: 4954
	[Header("ID")]
	[SerializeField]
	private int ID = -1;

	// Token: 0x0400135B RID: 4955
	[Header("Sounds")]
	[SerializeField]
	private List<AudioClip> m_AudioClips;

	// Token: 0x0400135C RID: 4956
	private static ItemIDManager m_idManager;
}

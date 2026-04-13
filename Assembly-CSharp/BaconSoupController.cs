using System;
using System.Collections.Generic;
using TMG.Data;
using UnityEngine;

// Token: 0x020001C7 RID: 455
public class BaconSoupController : BaseController
{
	// Token: 0x0600136C RID: 4972 RVA: 0x0001002F File Offset: 0x0000E22F
	public override void Init()
	{
		base.Init();
	}

	// Token: 0x0600136D RID: 4973 RVA: 0x00076F48 File Offset: 0x00075148
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		if (this.m_Chapter == Chapters.ONE)
		{
			this.LoadBaconSoupCollected(GameManager.Instance.GameData.CH1AchievementData.BaconSoup);
			this.m_AchievementAssetKey = AchievementName.A_TASTE_OF_HOME;
			this.m_AchievementDataVO = GameManager.Instance.GameData.CH1AchievementData;
		}
		else if (this.m_Chapter == Chapters.TWO)
		{
			this.LoadBaconSoupCollected(GameManager.Instance.GameData.CH2AchievementData.BaconSoup);
			this.m_AchievementAssetKey = AchievementName.CANADIAN_BACON;
			this.m_AchievementDataVO = GameManager.Instance.GameData.CH2AchievementData;
		}
		else if (this.m_Chapter == Chapters.THREE)
		{
			this.LoadBaconSoupCollected(GameManager.Instance.GameData.CH3AchievementData.BaconSoup);
			this.m_AchievementAssetKey = AchievementName.BRING_HOME_THE_BACON;
			this.m_AchievementDataVO = GameManager.Instance.GameData.CH3AchievementData;
		}
		else if (this.m_Chapter == Chapters.FOUR)
		{
			this.LoadBaconSoupCollected(GameManager.Instance.GameData.CH4AchievementData.BaconSoup);
			this.m_AchievementAssetKey = AchievementName.JUST_LIKE_MOM_USED_TO_MAKE;
			this.m_AchievementDataVO = GameManager.Instance.GameData.CH4AchievementData;
		}
		else if (this.m_Chapter == Chapters.FIVE)
		{
			this.LoadBaconSoupCollected(GameManager.Instance.GameData.CH5AchievementData.BaconSoup);
			this.m_AchievementAssetKey = AchievementName.NO_NEED_FOR_A_SPOON;
			this.m_AchievementDataVO = GameManager.Instance.GameData.CH5AchievementData;
		}
		for (int i = 0; i < this.m_BaconSoups.Count; i++)
		{
			this.m_BaconSoups[i].OnInteracted += this.HandleCannedSoupOnInteracted;
		}
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x000770F8 File Offset: 0x000752F8
	private void HandleCannedSoupOnInteracted(object sender, EventArgs e)
	{
		CannedSoupEdible cannedSoupEdible = (CannedSoupEdible)sender;
		cannedSoupEdible.OnInteracted -= this.HandleCannedSoupOnInteracted;
		int id = cannedSoupEdible.GetID();
		if (this.m_BaconSoups.Contains(cannedSoupEdible))
		{
			this.m_BaconSoups.Remove(cannedSoupEdible);
			this.m_AchievementDataVO.BaconSoup.Add(id);
		}
		if (this.m_BaconSoups.Count <= 0)
		{
			GameManager.Instance.AchievementManager.SetAchievement(this.m_AchievementAssetKey);
			this.CheckAllBaconSoupAchievements();
			base.Dispose();
		}
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x00077188 File Offset: 0x00075388
	private void CheckAllBaconSoupAchievements()
	{
		if (GameManager.Instance.AchievementManager.GetAchievement(AchievementName.A_TASTE_OF_HOME) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.CANADIAN_BACON) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.BRING_HOME_THE_BACON) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.JUST_LIKE_MOM_USED_TO_MAKE) && GameManager.Instance.AchievementManager.GetAchievement(AchievementName.NO_NEED_FOR_A_SPOON))
		{
			GameManager.Instance.AchievementManager.SetAchievement(AchievementName.MASTER_OF_BACON);
		}
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x00077214 File Offset: 0x00075414
	public void LoadBaconSoupCollected(List<int> _BaconSoupIDsCollected)
	{
		if (!GameManager.Instance.AchievementManager.GetAchievement(this.m_AchievementAssetKey))
		{
			for (int i = this.m_BaconSoups.Count - 1; i > -1; i--)
			{
				CannedSoupEdible cannedSoupEdible = this.m_BaconSoups[i];
				if (_BaconSoupIDsCollected.Contains(cannedSoupEdible.GetID()))
				{
					cannedSoupEdible.Dispose();
					this.m_BaconSoups.RemoveAt(i);
				}
			}
		}
	}

	// Token: 0x06001371 RID: 4977 RVA: 0x00006F06 File Offset: 0x00005106
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000F7A RID: 3962
	[Header("Chapter")]
	[SerializeField]
	private Chapters m_Chapter;

	// Token: 0x04000F7B RID: 3963
	[Header("Bacon Soups")]
	[SerializeField]
	private List<CannedSoupEdible> m_BaconSoups;

	// Token: 0x04000F7C RID: 3964
	private AchievementName m_AchievementAssetKey;

	// Token: 0x04000F7D RID: 3965
	private AchievementSaveData m_AchievementDataVO;
}

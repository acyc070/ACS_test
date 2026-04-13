using System;
using System.Collections.Generic;

// Token: 0x020000DA RID: 218
[Serializable]
public class CH3DataVO : ChapterDataVO
{
	// Token: 0x060008C5 RID: 2245 RVA: 0x0004A8FC File Offset: 0x00048AFC
	public CH3DataVO()
	{
		this.SetObject(ref this.GearTask, new int[] { 0, 1, 2 });
		this.SetObject(ref this.ThickInkTask, new int[] { 0, 1, 2 });
		this.SetObject(ref this.PowerCoreTask, new int[] { 0, 1, 2 });
		this.SetObject(ref this.CutoutTask, new int[]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15
		});
		this.SetObject(ref this.HeartTask, new int[] { 0, 1, 2, 3, 4 });
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x0004AA60 File Offset: 0x00048C60
	private void SetObject(ref ObjectiveIDDataVO data, params int[] ids)
	{
		List<ObjectDataVO> list = new List<ObjectDataVO>();
		for (int i = 0; i < ids.Length; i++)
		{
			list.Add(new ObjectDataVO
			{
				ID = i,
				IsComplete = false
			});
		}
		data.Object = list.ToArray();
	}

	// Token: 0x0400070A RID: 1802
	public int InternecionValue;

	// Token: 0x0400070B RID: 1803
	public int LiftFloor;

	// Token: 0x0400070C RID: 1804
	public List<int> SqueakyToys = new List<int>();

	// Token: 0x0400070D RID: 1805
	public int Toy;

	// Token: 0x0400070E RID: 1806
	public bool ChoseDevilsPath;

	// Token: 0x0400070F RID: 1807
	public bool HasTommyGun;

	// Token: 0x04000710 RID: 1808
	public bool HasBorisBone;

	// Token: 0x04000711 RID: 1809
	public bool IsSpeakeasyComplete;

	// Token: 0x04000712 RID: 1810
	public bool IsHenryUnlocked;

	// Token: 0x04000713 RID: 1811
	public bool UsedAxe;

	// Token: 0x04000714 RID: 1812
	public bool IsProjectionistKilled;

	// Token: 0x04000715 RID: 1813
	public ObjectiveSaveDataVO AccountingRoom = new ObjectiveSaveDataVO();

	// Token: 0x04000716 RID: 1814
	public ObjectiveSaveDataVO SafehouseObjective = new ObjectiveSaveDataVO();

	// Token: 0x04000717 RID: 1815
	public ObjectiveSaveDataVO DarkHallwayObjective = new ObjectiveSaveDataVO();

	// Token: 0x04000718 RID: 1816
	public ObjectiveSaveDataVO HeavenlyToysObjective = new ObjectiveSaveDataVO();

	// Token: 0x04000719 RID: 1817
	public ObjectiveSaveDataVO AliceRevealObjective = new ObjectiveSaveDataVO();

	// Token: 0x0400071A RID: 1818
	public ObjectiveSaveDataVO DecisionObjective = new ObjectiveSaveDataVO();

	// Token: 0x0400071B RID: 1819
	public ObjectiveSaveDataVO BorisJumpscareObjective = new ObjectiveSaveDataVO();

	// Token: 0x0400071C RID: 1820
	public ObjectiveSaveDataVO PosterPiperObjective = new ObjectiveSaveDataVO();

	// Token: 0x0400071D RID: 1821
	public ObjectiveSaveDataVO EnterLiftObjective = new ObjectiveSaveDataVO();

	// Token: 0x0400071E RID: 1822
	public ObjectiveSaveDataVO AliceLairObjective = new ObjectiveSaveDataVO();

	// Token: 0x0400071F RID: 1823
	public ObjectiveSaveDataVO AliceTasksObjective = new ObjectiveSaveDataVO();

	// Token: 0x04000720 RID: 1824
	public ObjectiveIDDataVO GearTask = new ObjectiveIDDataVO();

	// Token: 0x04000721 RID: 1825
	public ObjectiveIDDataVO ThickInkTask = new ObjectiveIDDataVO();

	// Token: 0x04000722 RID: 1826
	public ObjectiveIDDataVO PowerCoreTask = new ObjectiveIDDataVO();

	// Token: 0x04000723 RID: 1827
	public ObjectiveIDDataVO CutoutTask = new ObjectiveIDDataVO();

	// Token: 0x04000724 RID: 1828
	public ObjectiveSaveDataVO ButcherGangTask = new ObjectiveSaveDataVO();

	// Token: 0x04000725 RID: 1829
	public ObjectiveIDDataVO HeartTask = new ObjectiveIDDataVO();
}

using System;
using System.Collections;
using I2.Loc;
using TMG.Core;
using UnityEngine;

// Token: 0x0200016A RID: 362
public abstract class AbstractChapterController : TMGMonoBehaviour
{
	// Token: 0x06000ED2 RID: 3794 RVA: 0x0000D019 File Offset: 0x0000B219
	protected void StartChapter()
	{
		base.StartCoroutine(this.LoadChapter());
	}

	// Token: 0x06000ED3 RID: 3795 RVA: 0x00068540 File Offset: 0x00066740
	private IEnumerator LoadChapter()
	{
		yield return new WaitForSeconds(1f);
		yield return new WaitForEndOfFrame();
		this.SetupSimpleCulling();
		this.InitializeChapter();
		yield break;
	}

	// Token: 0x06000ED4 RID: 3796
	public abstract void InitializeChapter();

	// Token: 0x06000ED5 RID: 3797 RVA: 0x0000D028 File Offset: 0x0000B228
	private void SetupSimpleCulling()
	{
		if (this.m_overrideCullingDistance)
		{
			this.SetupCullingOverrideDistance(this.m_cullingDistance);
		}
		if (this.simpleCullSupportPrefab)
		{
			global::UnityEngine.Object.Instantiate<GameObject>(this.simpleCullSupportPrefab);
		}
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x0006855C File Offset: 0x0006675C
	public void SetupCullingOverrideDistance(float newDistance)
	{
		SimpleCull simpleCull = global::UnityEngine.Object.FindObjectOfType<SimpleCull>();
		if (simpleCull)
		{
			simpleCull.overrideCullingDistance = true;
			simpleCull.cullingDistance = newDistance;
		}
		else
		{
			Debug.LogError("[" + base.GetType().ToString() + "] Unable to find SimpleCull instance...", this);
		}
	}

	// Token: 0x06000ED7 RID: 3799 RVA: 0x000685B0 File Offset: 0x000667B0
	public override void Init()
	{
		base.Init();
		if (AbstractChapterController.localizationParamsManager == null)
		{
			AbstractChapterController.localizationParamsManager = new AbstractChapterController.LocalizationSupport();
			if (!LocalizationManager.ParamManagers.Contains(AbstractChapterController.localizationParamsManager))
			{
				Debug.Log("<color=green>-- Adding Localization Support object for Globals replacement --</color>", this);
				LocalizationManager.ParamManagers.Add(AbstractChapterController.localizationParamsManager);
				LocalizationManager.LocalizeAll(true);
			}
		}
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000C5C RID: 3164
	[Header("< Culling Settings >")]
	[SerializeField]
	private bool m_overrideCullingDistance;

	// Token: 0x04000C5D RID: 3165
	[SerializeField]
	private float m_cullingDistance;

	// Token: 0x04000C5E RID: 3166
	[SerializeField]
	private GameObject simpleCullSupportPrefab;

	// Token: 0x04000C5F RID: 3167
	protected static ILocalizationParamsManager localizationParamsManager;

	// Token: 0x0200016B RID: 363
	protected class LocalizationSupport : ILocalizationParamsManager
	{
		// Token: 0x06000EDA RID: 3802 RVA: 0x0000D05D File Offset: 0x0000B25D
		public string GetParameterValue(string Param)
		{
			if (Param != null)
			{
				if (Param == "N")
				{
					return "\n";
				}
			}
			return null;
		}
	}
}

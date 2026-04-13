using System;
using TMG.Core;
using UnityEngine;

namespace TMG.UI
{
	// Token: 0x020002CD RID: 717
	public class UILayer : TMGMonoBehaviour
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06001AEF RID: 6895 RVA: 0x00015C19 File Offset: 0x00013E19
		// (set) Token: 0x06001AF0 RID: 6896 RVA: 0x00015C21 File Offset: 0x00013E21
		public string Name { get; private set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06001AF1 RID: 6897 RVA: 0x00015C2A File Offset: 0x00013E2A
		// (set) Token: 0x06001AF2 RID: 6898 RVA: 0x00015C32 File Offset: 0x00013E32
		public float Order { get; private set; }

		// Token: 0x06001AF3 RID: 6899 RVA: 0x00090D94 File Offset: 0x0008EF94
		public static UILayer Create(string layerName, float layerOrder, Transform layerParent)
		{
			UILayer uilayer = new GameObject
			{
				name = "[UI Layer] - " + layerName
			}.AddComponent<UILayer>();
			uilayer.Name = layerName;
			uilayer.Order = layerOrder;
			uilayer.Init(layerParent);
			return uilayer;
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x00090DD8 File Offset: 0x0008EFD8
		public void Init(Transform parent)
		{
			this.m_RectTransform = base.gameObject.AddComponent<RectTransform>();
			this.m_RectTransform.SetParent(parent);
			this.m_RectTransform.localPosition = new Vector3(0f, 0f, this.Order);
			this.m_RectTransform.localEulerAngles = Vector3.zero;
			this.m_RectTransform.localScale = Vector3.one;
			this.m_RectTransform.pivot = new Vector2(0.5f, 0.5f);
			this.m_RectTransform.anchorMax = new Vector2(1f, 1f);
			this.m_RectTransform.anchorMin = new Vector2(0f, 0f);
			this.m_RectTransform.offsetMax = new Vector2(0f, 0f);
			this.m_RectTransform.offsetMin = new Vector2(0f, 0f);
		}

		// Token: 0x04001788 RID: 6024
		public bool isActive;

		// Token: 0x0400178B RID: 6027
		private RectTransform m_RectTransform;
	}
}

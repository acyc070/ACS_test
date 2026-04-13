using System;
using System.Collections.Generic;
using TMG.Controls;
using TMG.Core;
using UnityEngine;

namespace TMG.UI
{
	// Token: 0x020002CA RID: 714
	public class UIManager : TMGMonoBehaviour
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06001AD9 RID: 6873 RVA: 0x00015BBD File Offset: 0x00013DBD
		// (set) Token: 0x06001ADA RID: 6874 RVA: 0x00015BC5 File Offset: 0x00013DC5
		public Camera Camera { get; private set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06001ADB RID: 6875 RVA: 0x00015BCE File Offset: 0x00013DCE
		// (set) Token: 0x06001ADC RID: 6876 RVA: 0x00015BD6 File Offset: 0x00013DD6
		public Dictionary<string, UILayer> UILayers { get; private set; }

		// Token: 0x06001ADD RID: 6877 RVA: 0x000902FC File Offset: 0x0008E4FC
		public static UIManager Create(object _data = null)
		{
			return new GameObject("[UI MANAGER]").AddComponent<UIManager>();
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x0009031C File Offset: 0x0008E51C
		public override void Init()
		{
			base.Init();
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			GameObject.FindGameObjectWithTag("UIVisualControls").transform.SetParent(base.transform);
			this.Camera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
			this.UILayers = new Dictionary<string, UILayer>();
			this.UILayers.Add("VIEW", UILayer.Create("VIEW", 0f, base.transform));
			this.UILayers.Add("BORDERS", UILayer.Create("BORDERS", -20f, base.transform));
			this.UILayers.Add("CROSSHAIR", UILayer.Create("CROSSHAIR", -40f, base.transform));
			this.UILayers.Add("MODAL", UILayer.Create("MODAL", -80f, base.transform));
			this.UILayers.Add("PAUSE", UILayer.Create("PAUSE", -260f, base.transform));
			this.UILayers.Add("OBJECTIVE", UILayer.Create("OBJECTIVE", -120f, base.transform));
			this.UILayers.Add("NOTIFICATIONS", UILayer.Create("NOTIFICATIONS", -140f, base.transform));
			this.UILayers.Add("PROMPT", UILayer.Create("PROMPT", -160f, base.transform));
			this.UILayers.Add("LOADER", UILayer.Create("LOADER", -180f, base.transform));
			this.UILayers.Add("BLOCKER", UILayer.Create("BLOCKER", -200f, base.transform));
			this.UILayers.Add("CHAPTERTITLE", UILayer.Create("CHAPTERTITLE", -220f, base.transform));
			this.UILayers.Add("SUBTITLES", UILayer.Create("SUBTITLES", -240f, base.transform));
			this.UILayers.Add("ASYNC LOADER", UILayer.Create("ASYNC LOADER", -300f, base.transform));
			this.UILayers.Add("ERROR", UILayer.Create("ERROR", -800f, base.transform));
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x0009057C File Offset: 0x0008E77C
		public void Update()
		{
			if (GameManager.Instance.isPauseReady && PlayerInput.Pause())
			{
				if (!GameManager.Instance.isPaused)
				{
					GameManager.Instance.Pause();
				}
				else
				{
					GameManager.Instance.Unpause();
				}
			}
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x000905CC File Offset: 0x0008E7CC
		public T Show<T>(string assetKey, string layer, object data = null)
		{
			GameObject gameObject = global::UnityEngine.Object.Instantiate<GameObject>(GameManager.Instance.AssetManager.GetAsset<GameObject>(assetKey));
			UILayer uilayer = this.UILayers[layer];
			gameObject.transform.position = uilayer.transform.position;
			gameObject.transform.eulerAngles = uilayer.transform.eulerAngles;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.SetParent(uilayer.transform);
			T component = gameObject.GetComponent<T>();
			(component as BaseUIController).InitController(data);
			(component as BaseUIController).PlayIn();
			return component;
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x000061D6 File Offset: 0x000043D6
		protected override void OnDisposed()
		{
			base.OnDisposed();
		}
	}
}

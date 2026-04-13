using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TMG.Core;
using UnityEngine;

namespace TMG.AssetBundles
{
	// Token: 0x02000247 RID: 583
	public class AssetBundleManager : TMGAbstractDisposable
	{
		// Token: 0x060016A9 RID: 5801 RVA: 0x000126CD File Offset: 0x000108CD
		public AssetBundleManager()
		{
			Caching.ClearCache();
			this.AssetBundles = new Dictionary<string, AssetBundle>();
		}

		// Token: 0x1400009D RID: 157
		// (add) Token: 0x060016AA RID: 5802 RVA: 0x00080A80 File Offset: 0x0007EC80
		// (remove) Token: 0x060016AB RID: 5803 RVA: 0x00080AB8 File Offset: 0x0007ECB8
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnLoaded;

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x000126E6 File Offset: 0x000108E6
		// (set) Token: 0x060016AD RID: 5805 RVA: 0x000126EE File Offset: 0x000108EE
		public Dictionary<string, AssetBundle> AssetBundles { get; private set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x000126F7 File Offset: 0x000108F7
		// (set) Token: 0x060016AF RID: 5807 RVA: 0x000126FF File Offset: 0x000108FF
		public AssetBundle LoadedAssetBundle { get; private set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x00012708 File Offset: 0x00010908
		// (set) Token: 0x060016B1 RID: 5809 RVA: 0x00012710 File Offset: 0x00010910
		public bool HasAssetBundle { get; private set; }

		// Token: 0x060016B2 RID: 5810 RVA: 0x00080AF0 File Offset: 0x0007ECF0
		public IEnumerator GetAssetBundle(string assetBundleName)
		{
			this.HasAssetBundle = false;
			AssetBundleCreateRequest assetBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, assetBundleName));
			yield return assetBundleRequest;
			this.LoadedAssetBundle = assetBundleRequest.assetBundle;
			if (this.LoadedAssetBundle == null)
			{
				this.HasAssetBundle = false;
			}
			else if (!this.AssetBundles.ContainsKey(assetBundleName))
			{
				this.AssetBundles.Add(assetBundleName, this.LoadedAssetBundle);
				this.HasAssetBundle = true;
			}
			this.OnLoaded.Send(this);
			yield break;
		}

		// Token: 0x060016B3 RID: 5811 RVA: 0x0000D746 File Offset: 0x0000B946
		protected override void OnDisposed()
		{
			base.OnDisposed();
		}
	}
}

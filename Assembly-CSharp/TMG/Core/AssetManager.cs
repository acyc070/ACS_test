using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMG.Core
{
	// Token: 0x02000249 RID: 585
	public class AssetManager : TMGAbstractDisposable
	{
		// Token: 0x060016BB RID: 5819 RVA: 0x00080C30 File Offset: 0x0007EE30
		public T GetSprite<T>(string lookupKey, string assetKey) where T : global::UnityEngine.Object
		{
			int hashCode = assetKey.GetHashCode();
			if (!this.m_SpriteAssets.ContainsKey(hashCode))
			{
				this.m_SpriteAssets.Add(hashCode, Resources.LoadAll(lookupKey));
			}
			for (int i = 0; i < this.m_SpriteAssets[hashCode].Length; i++)
			{
				if (this.m_SpriteAssets[hashCode][i].name == assetKey)
				{
					return (T)((object)this.m_SpriteAssets[hashCode][i]);
				}
			}
			return (T)((object)null);
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x00080CC0 File Offset: 0x0007EEC0
		public T GetAsset<T>(string assetKey) where T : global::UnityEngine.Object
		{
			int hashCode = assetKey.GetHashCode();
			if (!this.m_Assets.ContainsKey(hashCode))
			{
				this.m_Assets.Add(hashCode, Resources.Load<T>(assetKey));
			}
			return (T)((object)this.m_Assets[hashCode]);
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x0001275A File Offset: 0x0001095A
		public T CreateAsset<T>(string assetKey) where T : Component
		{
			return global::UnityEngine.Object.Instantiate<T>(this.GetAsset<T>(assetKey));
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x00080D10 File Offset: 0x0007EF10
		public T[] GetAssets<T>(string assetKey) where T : global::UnityEngine.Object
		{
			int hashCode = assetKey.GetHashCode();
			if (!this.m_AssetsLists.ContainsKey(hashCode))
			{
				this.m_AssetsLists.Add(hashCode, Resources.LoadAll<T>(assetKey));
			}
			return (T[])this.m_AssetsLists[hashCode];
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x00080D5C File Offset: 0x0007EF5C
		protected override void OnDisposed()
		{
			if (this.m_Assets != null)
			{
				this.m_Assets.Clear();
				this.m_Assets = null;
			}
			if (this.m_AssetsLists != null)
			{
				this.m_AssetsLists.Clear();
				this.m_AssetsLists = null;
			}
			if (this.m_SpriteAssets != null)
			{
				this.m_SpriteAssets.Clear();
				this.m_SpriteAssets = null;
			}
			base.OnDisposed();
		}

		// Token: 0x04001420 RID: 5152
		private Dictionary<int, global::UnityEngine.Object> m_Assets = new Dictionary<int, global::UnityEngine.Object>();

		// Token: 0x04001421 RID: 5153
		private Dictionary<int, global::UnityEngine.Object[]> m_AssetsLists = new Dictionary<int, global::UnityEngine.Object[]>();

		// Token: 0x04001422 RID: 5154
		private Dictionary<int, global::UnityEngine.Object[]> m_SpriteAssets = new Dictionary<int, global::UnityEngine.Object[]>();
	}
}

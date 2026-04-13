using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200005C RID: 92
	public class GenericPrefabProxy : MonoBehaviour
	{
		// Token: 0x06000355 RID: 853 RVA: 0x0002A998 File Offset: 0x00028B98
		private void Awake()
		{
			if (this.prefab == null)
			{
				return;
			}
			GameObject gameObject = global::UnityEngine.Object.Instantiate<GameObject>(this.prefab, base.transform);
			gameObject.gameObject.name = this.prefab.name;
			global::UnityEngine.Object.Destroy(this);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000051DF File Offset: 0x000033DF
		private void OnDestroy()
		{
			this.prefab = null;
		}

		// Token: 0x040001CC RID: 460
		public GameObject prefab;
	}
}

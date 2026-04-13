using System;
using System.Collections.Generic;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000063 RID: 99
	public class S13ObjectContainer : MonoBehaviour
	{
		// Token: 0x06000370 RID: 880 RVA: 0x0002AE20 File Offset: 0x00029020
		private void Awake()
		{
			foreach (GameObject gameObject in this.objectList)
			{
				if (!gameObject.Equals(null))
				{
					this.objectDictionary.Add(gameObject.name, gameObject);
				}
			}
			S13AudioManager.Instance.audioEvents.oc = this;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0002AEA8 File Offset: 0x000290A8
		public void Play(string objectName)
		{
			GameObject @object = this.GetObject(objectName);
			if (@object == null)
			{
				return;
			}
			foreach (S13AudioSource s13AudioSource in @object.GetComponentsInChildren<S13AudioSource>())
			{
				s13AudioSource.Play();
			}
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0002AEF0 File Offset: 0x000290F0
		public void Stop(string objectName)
		{
			GameObject @object = this.GetObject(objectName);
			if (@object == null)
			{
				return;
			}
			foreach (S13AudioSource s13AudioSource in @object.GetComponentsInChildren<S13AudioSource>())
			{
				s13AudioSource.Stop(false);
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0002AF38 File Offset: 0x00029138
		public void Enable(string objectName)
		{
			GameObject @object = this.GetObject(objectName);
			if (@object == null)
			{
				return;
			}
			if (@object.activeInHierarchy)
			{
				return;
			}
			@object.SetActive(true);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0002AF70 File Offset: 0x00029170
		public void Disable(string objectName)
		{
			GameObject @object = this.GetObject(objectName);
			if (@object == null)
			{
				return;
			}
			if (!@object.activeInHierarchy)
			{
				return;
			}
			@object.SetActive(false);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0002AFA8 File Offset: 0x000291A8
		public void Destroy(string objectName, bool ignoreFades = true)
		{
			GameObject @object = this.GetObject(objectName);
			if (@object == null)
			{
				return;
			}
			foreach (S13AudioSource s13AudioSource in @object.GetComponentsInChildren<S13AudioSource>())
			{
				s13AudioSource.Stop(ignoreFades);
				S13AudioManager.Instance.PruneIDFromSoundBank(s13AudioSource.name);
			}
			this.objectDictionary.Remove(objectName);
			this.objectList.Remove(@object);
			global::UnityEngine.Object.Destroy(@object);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0002B020 File Offset: 0x00029220
		private GameObject GetObject(string objectName)
		{
			if (this.objectDictionary.ContainsKey(objectName))
			{
				return this.objectDictionary[objectName];
			}
			return null;
		}

		// Token: 0x040001E7 RID: 487
		public List<GameObject> objectList = new List<GameObject>();

		// Token: 0x040001E8 RID: 488
		private Dictionary<string, GameObject> objectDictionary = new Dictionary<string, GameObject>();
	}
}

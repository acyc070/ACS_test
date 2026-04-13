using System;
using System.Collections.Generic;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000064 RID: 100
	public class S13Switch : MonoBehaviour
	{
		// Token: 0x06000378 RID: 888 RVA: 0x0002B054 File Offset: 0x00029254
		private void Awake()
		{
			foreach (S13AudioContainer s13AudioContainer in this.audioContainers)
			{
				S13AudioSource component = s13AudioContainer.obj.GetComponent<S13AudioSource>();
				if (component == null)
				{
					Debug.LogError("object assigned to S13Switch does not contain a S13AudioSource", s13AudioContainer.obj);
				}
				else
				{
					this.sources.Add(s13AudioContainer.id, component);
				}
			}
			this.defaultID = this.audioContainers[0].id;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0002B0E4 File Offset: 0x000292E4
		public void Play(string id)
		{
			if (this.sources.ContainsKey(id))
			{
				this.sources[id].Play();
			}
			else
			{
				Debug.Log("Audio Source with ID: " + id + ", not Found on " + base.gameObject.name, base.gameObject);
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00005456 File Offset: 0x00003656
		public void Play()
		{
			this.Play(this.defaultID);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00005464 File Offset: 0x00003664
		public void Stop(string id)
		{
			if (this.sources.ContainsKey(id))
			{
				this.sources[id].Stop(false);
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00005489 File Offset: 0x00003689
		public void Stop()
		{
			this.Stop(this.defaultID);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00005497 File Offset: 0x00003697
		public bool Contains(string id)
		{
			return this.sources.ContainsKey(id);
		}

		// Token: 0x040001E9 RID: 489
		[Tooltip("Assign Default Sound Source to 1st slot")]
		public S13AudioContainer[] audioContainers;

		// Token: 0x040001EA RID: 490
		private string defaultID = string.Empty;

		// Token: 0x040001EB RID: 491
		private Dictionary<string, S13AudioSource> sources = new Dictionary<string, S13AudioSource>();
	}
}

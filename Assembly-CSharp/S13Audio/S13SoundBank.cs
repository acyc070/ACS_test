using System;
using System.Collections.Generic;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000055 RID: 85
	public class S13SoundBank : MonoBehaviour
	{
		// Token: 0x1700004A RID: 74
		public S13AudioSource this[string soundId]
		{
			get
			{
				S13AudioSource s13AudioSource = null;
				if (this._data.ContainsKey(soundId))
				{
					s13AudioSource = this._data[soundId];
				}
				return s13AudioSource;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000338 RID: 824 RVA: 0x000050A6 File Offset: 0x000032A6
		public Dictionary<string, S13AudioSource>.KeyCollection SoundIDs
		{
			get
			{
				return this._data.Keys;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0002A248 File Offset: 0x00028448
		private void Awake()
		{
			int num = 0;
			num += this.RegisterSounds(this.sounds);
			num += this.RegisterSounds(base.GetComponentsInChildren<S13AudioSource>());
			Debug.Log(string.Concat(new object[] { base.name, ": Initialized sound bank with ", num, " sounds." }));
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000050B3 File Offset: 0x000032B3
		public void RemoveSoundFromBank(string soundIdToRemove)
		{
			this._data.Remove(soundIdToRemove);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0002A2A8 File Offset: 0x000284A8
		private int RegisterSounds(S13AudioSource[] sounds)
		{
			int num = 0;
			foreach (S13AudioSource s13AudioSource in sounds)
			{
				if (!this._data.ContainsKey(s13AudioSource.name))
				{
					this._data.Add(s13AudioSource.name, s13AudioSource);
					num++;
				}
				else
				{
					Debug.LogError(base.name + ": A sound with the name '" + s13AudioSource.name + "' already exists; sound was not added to the sound bank.");
				}
			}
			return num;
		}

		// Token: 0x040001AC RID: 428
		public string soundBankId;

		// Token: 0x040001AD RID: 429
		public S13AudioSource[] sounds;

		// Token: 0x040001AE RID: 430
		private Dictionary<string, S13AudioSource> _data = new Dictionary<string, S13AudioSource>();
	}
}

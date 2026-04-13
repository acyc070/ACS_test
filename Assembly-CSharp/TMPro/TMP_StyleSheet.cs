using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000621 RID: 1569
	[Serializable]
	public class TMP_StyleSheet : ScriptableObject
	{
		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06002BF9 RID: 11257 RVA: 0x00106EBC File Offset: 0x001050BC
		public static TMP_StyleSheet instance
		{
			get
			{
				if (TMP_StyleSheet.s_Instance == null)
				{
					TMP_StyleSheet.s_Instance = TMP_Settings.defaultStyleSheet;
					if (TMP_StyleSheet.s_Instance == null)
					{
						TMP_StyleSheet.s_Instance = Resources.Load("Style Sheets/TMP Default Style Sheet") as TMP_StyleSheet;
					}
					if (TMP_StyleSheet.s_Instance == null)
					{
						return null;
					}
					TMP_StyleSheet.s_Instance.LoadStyleDictionaryInternal();
				}
				return TMP_StyleSheet.s_Instance;
			}
		}

		// Token: 0x06002BFA RID: 11258 RVA: 0x0001F6D0 File Offset: 0x0001D8D0
		public static TMP_StyleSheet LoadDefaultStyleSheet()
		{
			return TMP_StyleSheet.instance;
		}

		// Token: 0x06002BFB RID: 11259 RVA: 0x0001F6D7 File Offset: 0x0001D8D7
		public static TMP_Style GetStyle(int hashCode)
		{
			return TMP_StyleSheet.instance.GetStyleInternal(hashCode);
		}

		// Token: 0x06002BFC RID: 11260 RVA: 0x00106F28 File Offset: 0x00105128
		private TMP_Style GetStyleInternal(int hashCode)
		{
			TMP_Style tmp_Style;
			if (this.m_StyleDictionary.TryGetValue(hashCode, out tmp_Style))
			{
				return tmp_Style;
			}
			return null;
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x00106F4C File Offset: 0x0010514C
		public void UpdateStyleDictionaryKey(int old_key, int new_key)
		{
			if (this.m_StyleDictionary.ContainsKey(old_key))
			{
				TMP_Style tmp_Style = this.m_StyleDictionary[old_key];
				this.m_StyleDictionary.Add(new_key, tmp_Style);
				this.m_StyleDictionary.Remove(old_key);
			}
		}

		// Token: 0x06002BFE RID: 11262 RVA: 0x0001F6E4 File Offset: 0x0001D8E4
		public static void RefreshStyles()
		{
			TMP_StyleSheet.s_Instance.LoadStyleDictionaryInternal();
		}

		// Token: 0x06002BFF RID: 11263 RVA: 0x00106F94 File Offset: 0x00105194
		private void LoadStyleDictionaryInternal()
		{
			this.m_StyleDictionary.Clear();
			for (int i = 0; i < this.m_StyleList.Count; i++)
			{
				this.m_StyleList[i].RefreshStyle();
				if (!this.m_StyleDictionary.ContainsKey(this.m_StyleList[i].hashCode))
				{
					this.m_StyleDictionary.Add(this.m_StyleList[i].hashCode, this.m_StyleList[i]);
				}
			}
		}

		// Token: 0x0400301B RID: 12315
		private static TMP_StyleSheet s_Instance;

		// Token: 0x0400301C RID: 12316
		[SerializeField]
		private List<TMP_Style> m_StyleList = new List<TMP_Style>(1);

		// Token: 0x0400301D RID: 12317
		private Dictionary<int, TMP_Style> m_StyleDictionary = new Dictionary<int, TMP_Style>();
	}
}

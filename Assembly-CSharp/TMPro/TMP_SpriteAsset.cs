using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200061F RID: 1567
	public class TMP_SpriteAsset : TMP_Asset
	{
		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06002BEA RID: 11242 RVA: 0x0001F62C File Offset: 0x0001D82C
		public static TMP_SpriteAsset defaultSpriteAsset
		{
			get
			{
				if (TMP_SpriteAsset.m_defaultSpriteAsset == null)
				{
					TMP_SpriteAsset.m_defaultSpriteAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/Default Sprite Asset");
				}
				return TMP_SpriteAsset.m_defaultSpriteAsset;
			}
		}

		// Token: 0x06002BEB RID: 11243 RVA: 0x00002482 File Offset: 0x00000682
		private void OnEnable()
		{
		}

		// Token: 0x06002BEC RID: 11244 RVA: 0x00106D8C File Offset: 0x00104F8C
		private Material GetDefaultSpriteMaterial()
		{
			ShaderUtilities.GetShaderPropertyIDs();
			Shader shader = Shader.Find("TextMeshPro/Sprite");
			Material material = new Material(shader);
			material.SetTexture(ShaderUtilities.ID_MainTex, this.spriteSheet);
			material.hideFlags = HideFlags.HideInHierarchy;
			return material;
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x00106DCC File Offset: 0x00104FCC
		public int GetSpriteIndex(int hashCode)
		{
			for (int i = 0; i < this.spriteInfoList.Count; i++)
			{
				if (this.spriteInfoList[i].hashCode == hashCode)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x04003011 RID: 12305
		public static TMP_SpriteAsset m_defaultSpriteAsset;

		// Token: 0x04003012 RID: 12306
		public Texture spriteSheet;

		// Token: 0x04003013 RID: 12307
		public List<TMP_Sprite> spriteInfoList;

		// Token: 0x04003014 RID: 12308
		private List<Sprite> m_sprites;
	}
}

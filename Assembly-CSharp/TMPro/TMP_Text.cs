using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x02000630 RID: 1584
	public class TMP_Text : MaskableGraphic
	{
		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06002C57 RID: 11351 RVA: 0x0001FB2C File Offset: 0x0001DD2C
		// (set) Token: 0x06002C58 RID: 11352 RVA: 0x00107A28 File Offset: 0x00105C28
		public string text
		{
			get
			{
				return this.m_text;
			}
			set
			{
				if (this.m_text == value)
				{
					return;
				}
				this.m_text = value;
				this.m_inputSource = TMP_Text.TextInputSources.String;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06002C59 RID: 11353 RVA: 0x0001FB34 File Offset: 0x0001DD34
		// (set) Token: 0x06002C5A RID: 11354 RVA: 0x0001FB3C File Offset: 0x0001DD3C
		public bool isRightToLeftText
		{
			get
			{
				return this.m_isRightToLeft;
			}
			set
			{
				if (this.m_isRightToLeft == value)
				{
					return;
				}
				this.m_isRightToLeft = value;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06002C5B RID: 11355 RVA: 0x0001FB73 File Offset: 0x0001DD73
		// (set) Token: 0x06002C5C RID: 11356 RVA: 0x00107A78 File Offset: 0x00105C78
		public TMP_FontAsset font
		{
			get
			{
				return this.m_fontAsset;
			}
			set
			{
				if (this.m_fontAsset == value)
				{
					return;
				}
				this.m_fontAsset = value;
				this.LoadFontAsset();
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06002C5D RID: 11357 RVA: 0x0001FB7B File Offset: 0x0001DD7B
		// (set) Token: 0x06002C5E RID: 11358 RVA: 0x0001FB83 File Offset: 0x0001DD83
		public virtual Material fontSharedMaterial
		{
			get
			{
				return this.m_sharedMaterial;
			}
			set
			{
				if (this.m_sharedMaterial == value)
				{
					return;
				}
				this.SetSharedMaterial(value);
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06002C5F RID: 11359 RVA: 0x0001FBB8 File Offset: 0x0001DDB8
		// (set) Token: 0x06002C60 RID: 11360 RVA: 0x0001FBC0 File Offset: 0x0001DDC0
		public virtual Material[] fontSharedMaterials
		{
			get
			{
				return this.GetSharedMaterials();
			}
			set
			{
				this.SetSharedMaterials(value);
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06002C61 RID: 11361 RVA: 0x0001FBE3 File Offset: 0x0001DDE3
		// (set) Token: 0x06002C62 RID: 11362 RVA: 0x00107AC8 File Offset: 0x00105CC8
		public Material fontMaterial
		{
			get
			{
				return this.GetMaterial(this.m_sharedMaterial);
			}
			set
			{
				if (this.m_sharedMaterial != null && this.m_sharedMaterial.GetInstanceID() == value.GetInstanceID())
				{
					return;
				}
				this.m_sharedMaterial = value;
				this.m_padding = this.GetPaddingForMaterial();
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06002C63 RID: 11363 RVA: 0x0001FBF1 File Offset: 0x0001DDF1
		// (set) Token: 0x06002C64 RID: 11364 RVA: 0x0001FBC0 File Offset: 0x0001DDC0
		public virtual Material[] fontMaterials
		{
			get
			{
				return this.GetMaterials(this.m_fontSharedMaterials);
			}
			set
			{
				this.SetSharedMaterials(value);
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06002C65 RID: 11365 RVA: 0x0001FBFF File Offset: 0x0001DDFF
		// (set) Token: 0x06002C66 RID: 11366 RVA: 0x0001FC07 File Offset: 0x0001DE07
		public override Color color
		{
			get
			{
				return this.m_fontColor;
			}
			set
			{
				if (this.m_fontColor == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_fontColor = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06002C67 RID: 11367 RVA: 0x0001FC2F File Offset: 0x0001DE2F
		// (set) Token: 0x06002C68 RID: 11368 RVA: 0x0001FC3C File Offset: 0x0001DE3C
		public float alpha
		{
			get
			{
				return this.m_fontColor.a;
			}
			set
			{
				if (this.m_fontColor.a == value)
				{
					return;
				}
				this.m_fontColor.a = value;
				this.m_havePropertiesChanged = true;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06002C69 RID: 11369 RVA: 0x0001FC69 File Offset: 0x0001DE69
		// (set) Token: 0x06002C6A RID: 11370 RVA: 0x0001FC71 File Offset: 0x0001DE71
		public bool enableVertexGradient
		{
			get
			{
				return this.m_enableVertexGradient;
			}
			set
			{
				if (this.m_enableVertexGradient == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_enableVertexGradient = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06002C6B RID: 11371 RVA: 0x0001FC94 File Offset: 0x0001DE94
		// (set) Token: 0x06002C6C RID: 11372 RVA: 0x0001FC9C File Offset: 0x0001DE9C
		public VertexGradient colorGradient
		{
			get
			{
				return this.m_fontColorGradient;
			}
			set
			{
				this.m_havePropertiesChanged = true;
				this.m_fontColorGradient = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06002C6D RID: 11373 RVA: 0x0001FCB2 File Offset: 0x0001DEB2
		// (set) Token: 0x06002C6E RID: 11374 RVA: 0x0001FCBA File Offset: 0x0001DEBA
		public TMP_ColorGradient colorGradientPreset
		{
			get
			{
				return this.m_fontColorGradientPreset;
			}
			set
			{
				this.m_havePropertiesChanged = true;
				this.m_fontColorGradientPreset = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06002C6F RID: 11375 RVA: 0x0001FCD0 File Offset: 0x0001DED0
		// (set) Token: 0x06002C70 RID: 11376 RVA: 0x0001FCD8 File Offset: 0x0001DED8
		public TMP_SpriteAsset spriteAsset
		{
			get
			{
				return this.m_spriteAsset;
			}
			set
			{
				this.m_spriteAsset = value;
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06002C71 RID: 11377 RVA: 0x0001FCE1 File Offset: 0x0001DEE1
		// (set) Token: 0x06002C72 RID: 11378 RVA: 0x0001FCE9 File Offset: 0x0001DEE9
		public bool tintAllSprites
		{
			get
			{
				return this.m_tintAllSprites;
			}
			set
			{
				if (this.m_tintAllSprites == value)
				{
					return;
				}
				this.m_tintAllSprites = value;
				this.m_havePropertiesChanged = true;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06002C73 RID: 11379 RVA: 0x0001FD0C File Offset: 0x0001DF0C
		// (set) Token: 0x06002C74 RID: 11380 RVA: 0x0001FD14 File Offset: 0x0001DF14
		public bool overrideColorTags
		{
			get
			{
				return this.m_overrideHtmlColors;
			}
			set
			{
				if (this.m_overrideHtmlColors == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_overrideHtmlColors = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06002C75 RID: 11381 RVA: 0x0001FD37 File Offset: 0x0001DF37
		// (set) Token: 0x06002C76 RID: 11382 RVA: 0x0001FD72 File Offset: 0x0001DF72
		public Color32 faceColor
		{
			get
			{
				if (this.m_sharedMaterial == null)
				{
					return this.m_faceColor;
				}
				this.m_faceColor = this.m_sharedMaterial.GetColor(ShaderUtilities.ID_FaceColor);
				return this.m_faceColor;
			}
			set
			{
				if (this.m_faceColor.Compare(value))
				{
					return;
				}
				this.SetFaceColor(value);
				this.m_havePropertiesChanged = true;
				this.m_faceColor = value;
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06002C77 RID: 11383 RVA: 0x0001FDA7 File Offset: 0x0001DFA7
		// (set) Token: 0x06002C78 RID: 11384 RVA: 0x0001FDE2 File Offset: 0x0001DFE2
		public Color32 outlineColor
		{
			get
			{
				if (this.m_sharedMaterial == null)
				{
					return this.m_outlineColor;
				}
				this.m_outlineColor = this.m_sharedMaterial.GetColor(ShaderUtilities.ID_OutlineColor);
				return this.m_outlineColor;
			}
			set
			{
				if (this.m_outlineColor.Compare(value))
				{
					return;
				}
				this.SetOutlineColor(value);
				this.m_havePropertiesChanged = true;
				this.m_outlineColor = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06002C79 RID: 11385 RVA: 0x0001FE11 File Offset: 0x0001E011
		// (set) Token: 0x06002C7A RID: 11386 RVA: 0x0001FE47 File Offset: 0x0001E047
		public float outlineWidth
		{
			get
			{
				if (this.m_sharedMaterial == null)
				{
					return this.m_outlineWidth;
				}
				this.m_outlineWidth = this.m_sharedMaterial.GetFloat(ShaderUtilities.ID_OutlineWidth);
				return this.m_outlineWidth;
			}
			set
			{
				if (this.m_outlineWidth == value)
				{
					return;
				}
				this.SetOutlineThickness(value);
				this.m_havePropertiesChanged = true;
				this.m_outlineWidth = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06002C7B RID: 11387 RVA: 0x0001FE71 File Offset: 0x0001E071
		// (set) Token: 0x06002C7C RID: 11388 RVA: 0x00107B2C File Offset: 0x00105D2C
		public float fontSize
		{
			get
			{
				return this.m_fontSize;
			}
			set
			{
				if (this.m_fontSize == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_fontSize = value;
				if (!this.m_enableAutoSizing)
				{
					this.m_fontSizeBase = this.m_fontSize;
				}
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06002C7D RID: 11389 RVA: 0x0001FE79 File Offset: 0x0001E079
		public float fontScale
		{
			get
			{
				return this.m_fontScale;
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06002C7E RID: 11390 RVA: 0x0001FE81 File Offset: 0x0001E081
		// (set) Token: 0x06002C7F RID: 11391 RVA: 0x0001FE89 File Offset: 0x0001E089
		public int fontWeight
		{
			get
			{
				return this.m_fontWeight;
			}
			set
			{
				if (this.m_fontWeight == value)
				{
					return;
				}
				this.m_fontWeight = value;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06002C80 RID: 11392 RVA: 0x00107B80 File Offset: 0x00105D80
		public float pixelsPerUnit
		{
			get
			{
				Canvas canvas = base.canvas;
				if (!canvas)
				{
					return 1f;
				}
				if (!this.font)
				{
					return canvas.scaleFactor;
				}
				if (this.m_currentFontAsset == null || this.m_currentFontAsset.fontInfo.PointSize <= 0f || this.m_fontSize <= 0f)
				{
					return 1f;
				}
				return this.m_fontSize / this.m_currentFontAsset.fontInfo.PointSize;
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06002C81 RID: 11393 RVA: 0x0001FEB2 File Offset: 0x0001E0B2
		// (set) Token: 0x06002C82 RID: 11394 RVA: 0x0001FEBA File Offset: 0x0001E0BA
		public bool enableAutoSizing
		{
			get
			{
				return this.m_enableAutoSizing;
			}
			set
			{
				if (this.m_enableAutoSizing == value)
				{
					return;
				}
				this.m_enableAutoSizing = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06002C83 RID: 11395 RVA: 0x0001FEDC File Offset: 0x0001E0DC
		// (set) Token: 0x06002C84 RID: 11396 RVA: 0x0001FEE4 File Offset: 0x0001E0E4
		public float fontSizeMin
		{
			get
			{
				return this.m_fontSizeMin;
			}
			set
			{
				if (this.m_fontSizeMin == value)
				{
					return;
				}
				this.m_fontSizeMin = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06002C85 RID: 11397 RVA: 0x0001FF06 File Offset: 0x0001E106
		// (set) Token: 0x06002C86 RID: 11398 RVA: 0x0001FF0E File Offset: 0x0001E10E
		public float fontSizeMax
		{
			get
			{
				return this.m_fontSizeMax;
			}
			set
			{
				if (this.m_fontSizeMax == value)
				{
					return;
				}
				this.m_fontSizeMax = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06002C87 RID: 11399 RVA: 0x0001FF30 File Offset: 0x0001E130
		// (set) Token: 0x06002C88 RID: 11400 RVA: 0x0001FF38 File Offset: 0x0001E138
		public FontStyles fontStyle
		{
			get
			{
				return this.m_fontStyle;
			}
			set
			{
				if (this.m_fontStyle == value)
				{
					return;
				}
				this.m_fontStyle = value;
				this.m_havePropertiesChanged = true;
				this.checkPaddingRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06002C89 RID: 11401 RVA: 0x0001FF68 File Offset: 0x0001E168
		public bool isUsingBold
		{
			get
			{
				return this.m_isUsingBold;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06002C8A RID: 11402 RVA: 0x0001FF70 File Offset: 0x0001E170
		// (set) Token: 0x06002C8B RID: 11403 RVA: 0x0001FF78 File Offset: 0x0001E178
		public TextAlignmentOptions alignment
		{
			get
			{
				return this.m_textAlignment;
			}
			set
			{
				if (this.m_textAlignment == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_textAlignment = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06002C8C RID: 11404 RVA: 0x0001FF9B File Offset: 0x0001E19B
		// (set) Token: 0x06002C8D RID: 11405 RVA: 0x0001FFA3 File Offset: 0x0001E1A3
		public float characterSpacing
		{
			get
			{
				return this.m_characterSpacing;
			}
			set
			{
				if (this.m_characterSpacing == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_characterSpacing = value;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06002C8E RID: 11406 RVA: 0x0001FFD3 File Offset: 0x0001E1D3
		// (set) Token: 0x06002C8F RID: 11407 RVA: 0x0001FFDB File Offset: 0x0001E1DB
		public float lineSpacing
		{
			get
			{
				return this.m_lineSpacing;
			}
			set
			{
				if (this.m_lineSpacing == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_lineSpacing = value;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002C90 RID: 11408 RVA: 0x0002000B File Offset: 0x0001E20B
		// (set) Token: 0x06002C91 RID: 11409 RVA: 0x00020013 File Offset: 0x0001E213
		public float paragraphSpacing
		{
			get
			{
				return this.m_paragraphSpacing;
			}
			set
			{
				if (this.m_paragraphSpacing == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_paragraphSpacing = value;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002C92 RID: 11410 RVA: 0x00020043 File Offset: 0x0001E243
		// (set) Token: 0x06002C93 RID: 11411 RVA: 0x0002004B File Offset: 0x0001E24B
		public float characterWidthAdjustment
		{
			get
			{
				return this.m_charWidthMaxAdj;
			}
			set
			{
				if (this.m_charWidthMaxAdj == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_charWidthMaxAdj = value;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06002C94 RID: 11412 RVA: 0x0002007B File Offset: 0x0001E27B
		// (set) Token: 0x06002C95 RID: 11413 RVA: 0x00020083 File Offset: 0x0001E283
		public bool enableWordWrapping
		{
			get
			{
				return this.m_enableWordWrapping;
			}
			set
			{
				if (this.m_enableWordWrapping == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.m_isCalculateSizeRequired = true;
				this.m_enableWordWrapping = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06002C96 RID: 11414 RVA: 0x000200BA File Offset: 0x0001E2BA
		// (set) Token: 0x06002C97 RID: 11415 RVA: 0x000200C2 File Offset: 0x0001E2C2
		public float wordWrappingRatios
		{
			get
			{
				return this.m_wordWrappingRatios;
			}
			set
			{
				if (this.m_wordWrappingRatios == value)
				{
					return;
				}
				this.m_wordWrappingRatios = value;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06002C98 RID: 11416 RVA: 0x000200F2 File Offset: 0x0001E2F2
		// (set) Token: 0x06002C99 RID: 11417 RVA: 0x000200FA File Offset: 0x0001E2FA
		public bool enableAdaptiveJustification
		{
			get
			{
				return this.m_enableAdaptiveJustification;
			}
			set
			{
				if (this.m_enableAdaptiveJustification == value)
				{
					return;
				}
				this.m_enableAdaptiveJustification = value;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06002C9A RID: 11418 RVA: 0x0002012A File Offset: 0x0001E32A
		// (set) Token: 0x06002C9B RID: 11419 RVA: 0x00020132 File Offset: 0x0001E332
		public TextOverflowModes OverflowMode
		{
			get
			{
				return this.m_overflowMode;
			}
			set
			{
				if (this.m_overflowMode == value)
				{
					return;
				}
				this.m_overflowMode = value;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06002C9C RID: 11420 RVA: 0x00020162 File Offset: 0x0001E362
		// (set) Token: 0x06002C9D RID: 11421 RVA: 0x0002016A File Offset: 0x0001E36A
		public bool enableKerning
		{
			get
			{
				return this.m_enableKerning;
			}
			set
			{
				if (this.m_enableKerning == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_enableKerning = value;
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06002C9E RID: 11422 RVA: 0x0002019A File Offset: 0x0001E39A
		// (set) Token: 0x06002C9F RID: 11423 RVA: 0x000201A2 File Offset: 0x0001E3A2
		public bool extraPadding
		{
			get
			{
				return this.m_enableExtraPadding;
			}
			set
			{
				if (this.m_enableExtraPadding == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_enableExtraPadding = value;
				this.UpdateMeshPadding();
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06002CA0 RID: 11424 RVA: 0x000201CB File Offset: 0x0001E3CB
		// (set) Token: 0x06002CA1 RID: 11425 RVA: 0x000201D3 File Offset: 0x0001E3D3
		public bool richText
		{
			get
			{
				return this.m_isRichText;
			}
			set
			{
				if (this.m_isRichText == value)
				{
					return;
				}
				this.m_isRichText = value;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_isInputParsingRequired = true;
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06002CA2 RID: 11426 RVA: 0x0002020A File Offset: 0x0001E40A
		// (set) Token: 0x06002CA3 RID: 11427 RVA: 0x00020212 File Offset: 0x0001E412
		public bool parseCtrlCharacters
		{
			get
			{
				return this.m_parseCtrlCharacters;
			}
			set
			{
				if (this.m_parseCtrlCharacters == value)
				{
					return;
				}
				this.m_parseCtrlCharacters = value;
				this.m_havePropertiesChanged = true;
				this.m_isCalculateSizeRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
				this.m_isInputParsingRequired = true;
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06002CA4 RID: 11428 RVA: 0x00020249 File Offset: 0x0001E449
		// (set) Token: 0x06002CA5 RID: 11429 RVA: 0x00020251 File Offset: 0x0001E451
		public bool isOverlay
		{
			get
			{
				return this.m_isOverlay;
			}
			set
			{
				if (this.m_isOverlay == value)
				{
					return;
				}
				this.m_isOverlay = value;
				this.SetShaderDepth();
				this.m_havePropertiesChanged = true;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06002CA6 RID: 11430 RVA: 0x0002027A File Offset: 0x0001E47A
		// (set) Token: 0x06002CA7 RID: 11431 RVA: 0x00020282 File Offset: 0x0001E482
		public bool isOrthographic
		{
			get
			{
				return this.m_isOrthographic;
			}
			set
			{
				if (this.m_isOrthographic == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isOrthographic = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06002CA8 RID: 11432 RVA: 0x000202A5 File Offset: 0x0001E4A5
		// (set) Token: 0x06002CA9 RID: 11433 RVA: 0x000202AD File Offset: 0x0001E4AD
		public bool enableCulling
		{
			get
			{
				return this.m_isCullingEnabled;
			}
			set
			{
				if (this.m_isCullingEnabled == value)
				{
					return;
				}
				this.m_isCullingEnabled = value;
				this.SetCulling();
				this.m_havePropertiesChanged = true;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06002CAA RID: 11434 RVA: 0x000202D0 File Offset: 0x0001E4D0
		// (set) Token: 0x06002CAB RID: 11435 RVA: 0x000202D8 File Offset: 0x0001E4D8
		public bool ignoreVisibility
		{
			get
			{
				return this.m_ignoreCulling;
			}
			set
			{
				if (this.m_ignoreCulling == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_ignoreCulling = value;
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06002CAC RID: 11436 RVA: 0x000202F5 File Offset: 0x0001E4F5
		// (set) Token: 0x06002CAD RID: 11437 RVA: 0x000202FD File Offset: 0x0001E4FD
		public TextureMappingOptions horizontalMapping
		{
			get
			{
				return this.m_horizontalMapping;
			}
			set
			{
				if (this.m_horizontalMapping == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_horizontalMapping = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06002CAE RID: 11438 RVA: 0x00020320 File Offset: 0x0001E520
		// (set) Token: 0x06002CAF RID: 11439 RVA: 0x00020328 File Offset: 0x0001E528
		public TextureMappingOptions verticalMapping
		{
			get
			{
				return this.m_verticalMapping;
			}
			set
			{
				if (this.m_verticalMapping == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_verticalMapping = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06002CB0 RID: 11440 RVA: 0x0002034B File Offset: 0x0001E54B
		// (set) Token: 0x06002CB1 RID: 11441 RVA: 0x00020353 File Offset: 0x0001E553
		public TextRenderFlags renderMode
		{
			get
			{
				return this.m_renderMode;
			}
			set
			{
				if (this.m_renderMode == value)
				{
					return;
				}
				this.m_renderMode = value;
				this.m_havePropertiesChanged = true;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06002CB2 RID: 11442 RVA: 0x00020370 File Offset: 0x0001E570
		// (set) Token: 0x06002CB3 RID: 11443 RVA: 0x00020378 File Offset: 0x0001E578
		public int maxVisibleCharacters
		{
			get
			{
				return this.m_maxVisibleCharacters;
			}
			set
			{
				if (this.m_maxVisibleCharacters == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_maxVisibleCharacters = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06002CB4 RID: 11444 RVA: 0x0002039B File Offset: 0x0001E59B
		// (set) Token: 0x06002CB5 RID: 11445 RVA: 0x000203A3 File Offset: 0x0001E5A3
		public int maxVisibleWords
		{
			get
			{
				return this.m_maxVisibleWords;
			}
			set
			{
				if (this.m_maxVisibleWords == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_maxVisibleWords = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06002CB6 RID: 11446 RVA: 0x000203C6 File Offset: 0x0001E5C6
		// (set) Token: 0x06002CB7 RID: 11447 RVA: 0x000203CE File Offset: 0x0001E5CE
		public int maxVisibleLines
		{
			get
			{
				return this.m_maxVisibleLines;
			}
			set
			{
				if (this.m_maxVisibleLines == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.m_maxVisibleLines = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002CB8 RID: 11448 RVA: 0x000203F8 File Offset: 0x0001E5F8
		// (set) Token: 0x06002CB9 RID: 11449 RVA: 0x00020400 File Offset: 0x0001E600
		public bool useMaxVisibleDescender
		{
			get
			{
				return this.m_useMaxVisibleDescender;
			}
			set
			{
				if (this.m_useMaxVisibleDescender == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002CBA RID: 11450 RVA: 0x00020423 File Offset: 0x0001E623
		// (set) Token: 0x06002CBB RID: 11451 RVA: 0x0002042B File Offset: 0x0001E62B
		public int pageToDisplay
		{
			get
			{
				return this.m_pageToDisplay;
			}
			set
			{
				if (this.m_pageToDisplay == value)
				{
					return;
				}
				this.m_havePropertiesChanged = true;
				this.m_pageToDisplay = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002CBC RID: 11452 RVA: 0x0001DFBF File Offset: 0x0001C1BF
		// (set) Token: 0x06002CBD RID: 11453 RVA: 0x0002044E File Offset: 0x0001E64E
		public virtual Vector4 margin
		{
			get
			{
				return this.m_margin;
			}
			set
			{
				if (this.m_margin == value)
				{
					return;
				}
				this.m_margin = value;
				this.ComputeMarginSize();
				this.m_havePropertiesChanged = true;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002CBE RID: 11454 RVA: 0x0002047C File Offset: 0x0001E67C
		public TMP_TextInfo textInfo
		{
			get
			{
				return this.m_textInfo;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06002CBF RID: 11455 RVA: 0x00020484 File Offset: 0x0001E684
		// (set) Token: 0x06002CC0 RID: 11456 RVA: 0x0002048C File Offset: 0x0001E68C
		public bool havePropertiesChanged
		{
			get
			{
				return this.m_havePropertiesChanged;
			}
			set
			{
				if (this.m_havePropertiesChanged == value)
				{
					return;
				}
				this.m_havePropertiesChanged = value;
				this.m_isInputParsingRequired = true;
				this.SetAllDirty();
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06002CC1 RID: 11457 RVA: 0x000204AF File Offset: 0x0001E6AF
		// (set) Token: 0x06002CC2 RID: 11458 RVA: 0x000204B7 File Offset: 0x0001E6B7
		public bool isUsingLegacyAnimationComponent
		{
			get
			{
				return this.m_isUsingLegacyAnimationComponent;
			}
			set
			{
				this.m_isUsingLegacyAnimationComponent = value;
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06002CC3 RID: 11459 RVA: 0x0001E096 File Offset: 0x0001C296
		public new Transform transform
		{
			get
			{
				if (this.m_transform == null)
				{
					this.m_transform = base.GetComponent<Transform>();
				}
				return this.m_transform;
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06002CC4 RID: 11460 RVA: 0x000204C0 File Offset: 0x0001E6C0
		public new RectTransform rectTransform
		{
			get
			{
				if (this.m_rectTransform == null)
				{
					this.m_rectTransform = base.GetComponent<RectTransform>();
				}
				return this.m_rectTransform;
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06002CC5 RID: 11461 RVA: 0x000204E5 File Offset: 0x0001E6E5
		// (set) Token: 0x06002CC6 RID: 11462 RVA: 0x000204ED File Offset: 0x0001E6ED
		public virtual bool autoSizeTextContainer { get; set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06002CC7 RID: 11463 RVA: 0x0001E3B6 File Offset: 0x0001C5B6
		public virtual Mesh mesh
		{
			get
			{
				return this.m_mesh;
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06002CC8 RID: 11464 RVA: 0x000204F6 File Offset: 0x0001E6F6
		// (set) Token: 0x06002CC9 RID: 11465 RVA: 0x000204FE File Offset: 0x0001E6FE
		public bool isVolumetricText
		{
			get
			{
				return this.m_isVolumetricText;
			}
			set
			{
				if (this.m_isVolumetricText == value)
				{
					return;
				}
				this.m_havePropertiesChanged = value;
				this.m_textInfo.ResetVertexLayout(value);
				this.m_isInputParsingRequired = true;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06002CCA RID: 11466 RVA: 0x00107C14 File Offset: 0x00105E14
		public Bounds bounds
		{
			get
			{
				if (this.m_mesh == null)
				{
					return default(Bounds);
				}
				return this.GetCompoundBounds();
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06002CCB RID: 11467 RVA: 0x00107C44 File Offset: 0x00105E44
		public Bounds textBounds
		{
			get
			{
				if (this.m_textInfo == null)
				{
					return default(Bounds);
				}
				return this.GetTextBounds();
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06002CCC RID: 11468 RVA: 0x00020533 File Offset: 0x0001E733
		public float flexibleHeight
		{
			get
			{
				return this.m_flexibleHeight;
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06002CCD RID: 11469 RVA: 0x0002053B File Offset: 0x0001E73B
		public float flexibleWidth
		{
			get
			{
				return this.m_flexibleWidth;
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06002CCE RID: 11470 RVA: 0x00020543 File Offset: 0x0001E743
		public float minHeight
		{
			get
			{
				return this.m_minHeight;
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06002CCF RID: 11471 RVA: 0x0002054B File Offset: 0x0001E74B
		public float minWidth
		{
			get
			{
				return this.m_minWidth;
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06002CD0 RID: 11472 RVA: 0x00020553 File Offset: 0x0001E753
		public virtual float preferredWidth
		{
			get
			{
				if (!this.m_isPreferredWidthDirty)
				{
					return this.m_preferredWidth;
				}
				this.m_preferredWidth = this.GetPreferredWidth();
				return this.m_preferredWidth;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06002CD1 RID: 11473 RVA: 0x00020579 File Offset: 0x0001E779
		public virtual float preferredHeight
		{
			get
			{
				if (!this.m_isPreferredHeightDirty)
				{
					return this.m_preferredHeight;
				}
				this.m_preferredHeight = this.GetPreferredHeight();
				return this.m_preferredHeight;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06002CD2 RID: 11474 RVA: 0x0002059F File Offset: 0x0001E79F
		public virtual float renderedWidth
		{
			get
			{
				return this.GetRenderedWidth();
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06002CD3 RID: 11475 RVA: 0x000205A7 File Offset: 0x0001E7A7
		public virtual float renderedHeight
		{
			get
			{
				return this.GetRenderedHeight();
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06002CD4 RID: 11476 RVA: 0x000205AF File Offset: 0x0001E7AF
		public int layoutPriority
		{
			get
			{
				return this.m_layoutPriority;
			}
		}

		// Token: 0x06002CD5 RID: 11477 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void LoadFontAsset()
		{
		}

		// Token: 0x06002CD6 RID: 11478 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetSharedMaterial(Material mat)
		{
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x000124F9 File Offset: 0x000106F9
		protected virtual Material GetMaterial(Material mat)
		{
			return null;
		}

		// Token: 0x06002CD8 RID: 11480 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetFontBaseMaterial(Material mat)
		{
		}

		// Token: 0x06002CD9 RID: 11481 RVA: 0x000124F9 File Offset: 0x000106F9
		protected virtual Material[] GetSharedMaterials()
		{
			return null;
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetSharedMaterials(Material[] materials)
		{
		}

		// Token: 0x06002CDB RID: 11483 RVA: 0x000124F9 File Offset: 0x000106F9
		protected virtual Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		// Token: 0x06002CDC RID: 11484 RVA: 0x00107370 File Offset: 0x00105570
		protected virtual Material CreateMaterialInstance(Material source)
		{
			Material material = new Material(source);
			material.shaderKeywords = source.shaderKeywords;
			Material material2 = material;
			material2.name += " (Instance)";
			return material;
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x00107C6C File Offset: 0x00105E6C
		protected void SetVertexColorGradient(TMP_ColorGradient gradient)
		{
			if (gradient == null)
			{
				return;
			}
			this.m_fontColorGradient.bottomLeft = gradient.bottomLeft;
			this.m_fontColorGradient.bottomRight = gradient.bottomRight;
			this.m_fontColorGradient.topLeft = gradient.topLeft;
			this.m_fontColorGradient.topRight = gradient.topRight;
			this.SetVerticesDirty();
		}

		// Token: 0x06002CDE RID: 11486 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetFaceColor(Color32 color)
		{
		}

		// Token: 0x06002CDF RID: 11487 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetOutlineColor(Color32 color)
		{
		}

		// Token: 0x06002CE0 RID: 11488 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetOutlineThickness(float thickness)
		{
		}

		// Token: 0x06002CE1 RID: 11489 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetShaderDepth()
		{
		}

		// Token: 0x06002CE2 RID: 11490 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetCulling()
		{
		}

		// Token: 0x06002CE3 RID: 11491 RVA: 0x0001993C File Offset: 0x00017B3C
		protected virtual float GetPaddingForMaterial()
		{
			return 0f;
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x0001993C File Offset: 0x00017B3C
		protected virtual float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		// Token: 0x06002CE5 RID: 11493 RVA: 0x000124F9 File Offset: 0x000106F9
		protected virtual Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		// Token: 0x06002CE6 RID: 11494 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void ForceMeshUpdate()
		{
		}

		// Token: 0x06002CE7 RID: 11495 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void ForceMeshUpdate(bool ignoreActiveState)
		{
		}

		// Token: 0x06002CE8 RID: 11496 RVA: 0x000205B7 File Offset: 0x0001E7B7
		internal void SetTextInternal(string text)
		{
			this.m_text = text;
			this.m_renderMode = TextRenderFlags.DontRender;
			this.m_isInputParsingRequired = true;
			this.ForceMeshUpdate();
			this.m_renderMode = TextRenderFlags.Render;
		}

		// Token: 0x06002CE9 RID: 11497 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void UpdateGeometry(Mesh mesh, int index)
		{
		}

		// Token: 0x06002CEA RID: 11498 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		// Token: 0x06002CEB RID: 11499 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void UpdateVertexData()
		{
		}

		// Token: 0x06002CEC RID: 11500 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void SetVertices(Vector3[] vertices)
		{
		}

		// Token: 0x06002CED RID: 11501 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void UpdateMeshPadding()
		{
		}

		// Token: 0x06002CEE RID: 11502 RVA: 0x000205DF File Offset: 0x0001E7DF
		public new void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
			base.CrossFadeColor(targetColor, duration, ignoreTimeScale, useAlpha);
			this.InternalCrossFadeColor(targetColor, duration, ignoreTimeScale, useAlpha);
		}

		// Token: 0x06002CEF RID: 11503 RVA: 0x000205F7 File Offset: 0x0001E7F7
		public new void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
			base.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
			this.InternalCrossFadeAlpha(alpha, duration, ignoreTimeScale);
		}

		// Token: 0x06002CF0 RID: 11504 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		// Token: 0x06002CF1 RID: 11505 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		// Token: 0x06002CF2 RID: 11506 RVA: 0x00107CD0 File Offset: 0x00105ED0
		protected void ParseInputText()
		{
			this.m_isInputParsingRequired = false;
			switch (this.m_inputSource)
			{
			case TMP_Text.TextInputSources.Text:
			case TMP_Text.TextInputSources.String:
				this.StringToCharArray(this.m_text, ref this.m_char_buffer);
				break;
			case TMP_Text.TextInputSources.SetText:
				this.SetTextArrayToCharArray(this.m_input_CharArray, ref this.m_char_buffer);
				break;
			}
			this.SetArraySizes(this.m_char_buffer);
		}

		// Token: 0x06002CF3 RID: 11507 RVA: 0x0002060B File Offset: 0x0001E80B
		public void SetText(string text)
		{
			this.m_inputSource = TMP_Text.TextInputSources.SetCharArray;
			this.StringToCharArray(text, ref this.m_char_buffer);
			this.m_isInputParsingRequired = true;
			this.m_havePropertiesChanged = true;
			this.m_isCalculateSizeRequired = true;
			this.SetVerticesDirty();
			this.SetLayoutDirty();
		}

		// Token: 0x06002CF4 RID: 11508 RVA: 0x00020642 File Offset: 0x0001E842
		public void SetText(string text, float arg0)
		{
			this.SetText(text, arg0, 255f, 255f);
		}

		// Token: 0x06002CF5 RID: 11509 RVA: 0x00020656 File Offset: 0x0001E856
		public void SetText(string text, float arg0, float arg1)
		{
			this.SetText(text, arg0, arg1, 255f);
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x00107D48 File Offset: 0x00105F48
		public void SetText(string text, float arg0, float arg1, float arg2)
		{
			if (text == this.old_text && arg0 == this.old_arg0 && arg1 == this.old_arg1 && arg2 == this.old_arg2)
			{
				return;
			}
			this.old_text = text;
			this.old_arg1 = 255f;
			this.old_arg2 = 255f;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (c == '{')
				{
					if (text[i + 2] == ':')
					{
						num = (int)(text[i + 3] - '0');
					}
					int num3 = (int)(text[i + 1] - '0');
					if (num3 != 0)
					{
						if (num3 != 1)
						{
							if (num3 == 2)
							{
								this.old_arg2 = arg2;
								this.AddFloatToCharArray(arg2, ref num2, num);
							}
						}
						else
						{
							this.old_arg1 = arg1;
							this.AddFloatToCharArray(arg1, ref num2, num);
						}
					}
					else
					{
						this.old_arg0 = arg0;
						this.AddFloatToCharArray(arg0, ref num2, num);
					}
					if (text[i + 2] == ':')
					{
						i += 4;
					}
					else
					{
						i += 2;
					}
				}
				else
				{
					this.m_input_CharArray[num2] = c;
					num2++;
				}
			}
			this.m_input_CharArray[num2] = '\0';
			this.m_charArray_Length = num2;
			this.m_inputSource = TMP_Text.TextInputSources.SetText;
			this.m_isInputParsingRequired = true;
			this.m_havePropertiesChanged = true;
			this.m_isCalculateSizeRequired = true;
			this.SetVerticesDirty();
			this.SetLayoutDirty();
		}

		// Token: 0x06002CF7 RID: 11511 RVA: 0x00020666 File Offset: 0x0001E866
		public void SetText(StringBuilder text)
		{
			this.m_inputSource = TMP_Text.TextInputSources.SetCharArray;
			this.StringBuilderToIntArray(text, ref this.m_char_buffer);
			this.m_isInputParsingRequired = true;
			this.m_havePropertiesChanged = true;
			this.m_isCalculateSizeRequired = true;
			this.SetVerticesDirty();
			this.SetLayoutDirty();
		}

		// Token: 0x06002CF8 RID: 11512 RVA: 0x00107EC8 File Offset: 0x001060C8
		public void SetCharArray(char[] charArray)
		{
			if (charArray == null || charArray.Length == 0)
			{
				return;
			}
			if (this.m_char_buffer.Length <= charArray.Length)
			{
				int num = Mathf.NextPowerOfTwo(charArray.Length + 1);
				this.m_char_buffer = new int[num];
			}
			int num2 = 0;
			int i = 0;
			while (i < charArray.Length)
			{
				if (charArray[i] != '\\' || i >= charArray.Length - 1)
				{
					goto IL_00BC;
				}
				int num3 = (int)charArray[i + 1];
				if (num3 != 110)
				{
					if (num3 != 114)
					{
						if (num3 != 116)
						{
							goto IL_00BC;
						}
						this.m_char_buffer[num2] = 9;
						i++;
						num2++;
					}
					else
					{
						this.m_char_buffer[num2] = 13;
						i++;
						num2++;
					}
				}
				else
				{
					this.m_char_buffer[num2] = 10;
					i++;
					num2++;
				}
				IL_00CB:
				i++;
				continue;
				IL_00BC:
				this.m_char_buffer[num2] = (int)charArray[i];
				num2++;
				goto IL_00CB;
			}
			this.m_char_buffer[num2] = 0;
			this.m_inputSource = TMP_Text.TextInputSources.SetCharArray;
			this.m_havePropertiesChanged = true;
			this.m_isInputParsingRequired = true;
		}

		// Token: 0x06002CF9 RID: 11513 RVA: 0x00107FCC File Offset: 0x001061CC
		protected void SetTextArrayToCharArray(char[] charArray, ref int[] charBuffer)
		{
			if (charArray == null || this.m_charArray_Length == 0)
			{
				return;
			}
			if (charBuffer.Length <= this.m_charArray_Length)
			{
				int num = ((this.m_charArray_Length <= 1024) ? Mathf.NextPowerOfTwo(this.m_charArray_Length + 1) : (this.m_charArray_Length + 256));
				charBuffer = new int[num];
			}
			int num2 = 0;
			for (int i = 0; i < this.m_charArray_Length; i++)
			{
				if (char.IsHighSurrogate(charArray[i]) && char.IsLowSurrogate(charArray[i + 1]))
				{
					charBuffer[num2] = char.ConvertToUtf32(charArray[i], charArray[i + 1]);
					i++;
					num2++;
				}
				else
				{
					charBuffer[num2] = (int)charArray[i];
					num2++;
				}
			}
			charBuffer[num2] = 0;
		}

		// Token: 0x06002CFA RID: 11514 RVA: 0x00108094 File Offset: 0x00106294
		protected void StringToCharArray(string text, ref int[] chars)
		{
			if (text == null)
			{
				chars[0] = 0;
				return;
			}
			if (chars == null || chars.Length <= text.Length)
			{
				int num = ((text.Length <= 1024) ? Mathf.NextPowerOfTwo(text.Length + 1) : (text.Length + 256));
				chars = new int[num];
			}
			int num2 = 0;
			int i = 0;
			while (i < text.Length)
			{
				if (this.m_inputSource != TMP_Text.TextInputSources.Text || text[i] != '\\' || text.Length <= i + 1)
				{
					goto IL_01DB;
				}
				int num3 = (int)text[i + 1];
				switch (num3)
				{
				case 114:
					if (!this.m_parseCtrlCharacters)
					{
						goto IL_01DB;
					}
					chars[num2] = 13;
					i++;
					num2++;
					break;
				default:
					if (num3 != 85)
					{
						if (num3 != 92)
						{
							if (num3 != 110)
							{
								goto IL_01DB;
							}
							if (!this.m_parseCtrlCharacters)
							{
								goto IL_01DB;
							}
							chars[num2] = 10;
							i++;
							num2++;
						}
						else
						{
							if (!this.m_parseCtrlCharacters)
							{
								goto IL_01DB;
							}
							if (text.Length <= i + 2)
							{
								goto IL_01DB;
							}
							chars[num2] = (int)text[i + 1];
							chars[num2 + 1] = (int)text[i + 2];
							i += 2;
							num2 += 2;
						}
					}
					else
					{
						if (text.Length <= i + 9)
						{
							goto IL_01DB;
						}
						chars[num2] = this.GetUTF32(i + 2);
						i += 9;
						num2++;
					}
					break;
				case 116:
					if (!this.m_parseCtrlCharacters)
					{
						goto IL_01DB;
					}
					chars[num2] = 9;
					i++;
					num2++;
					break;
				case 117:
					if (text.Length <= i + 5)
					{
						goto IL_01DB;
					}
					chars[num2] = (int)((ushort)this.GetUTF16(i + 2));
					i += 5;
					num2++;
					break;
				}
				IL_0234:
				i++;
				continue;
				IL_01DB:
				if (char.IsHighSurrogate(text[i]) && char.IsLowSurrogate(text[i + 1]))
				{
					chars[num2] = char.ConvertToUtf32(text[i], text[i + 1]);
					i++;
					num2++;
					goto IL_0234;
				}
				chars[num2] = (int)text[i];
				num2++;
				goto IL_0234;
			}
			chars[num2] = 0;
		}

		// Token: 0x06002CFB RID: 11515 RVA: 0x001082EC File Offset: 0x001064EC
		protected void StringBuilderToIntArray(StringBuilder text, ref int[] chars)
		{
			if (text == null)
			{
				chars[0] = 0;
				return;
			}
			if (chars == null || chars.Length <= text.Length)
			{
				int num = ((text.Length <= 1024) ? Mathf.NextPowerOfTwo(text.Length + 1) : (text.Length + 256));
				chars = new int[num];
			}
			int num2 = 0;
			int i = 0;
			while (i < text.Length)
			{
				if (!this.m_parseCtrlCharacters || text[i] != '\\' || text.Length <= i + 1)
				{
					goto IL_019B;
				}
				int num3 = (int)text[i + 1];
				switch (num3)
				{
				case 114:
					chars[num2] = 13;
					i++;
					num2++;
					break;
				default:
					if (num3 != 85)
					{
						if (num3 != 92)
						{
							if (num3 != 110)
							{
								goto IL_019B;
							}
							chars[num2] = 10;
							i++;
							num2++;
						}
						else
						{
							if (text.Length <= i + 2)
							{
								goto IL_019B;
							}
							chars[num2] = (int)text[i + 1];
							chars[num2 + 1] = (int)text[i + 2];
							i += 2;
							num2 += 2;
						}
					}
					else
					{
						if (text.Length <= i + 9)
						{
							goto IL_019B;
						}
						chars[num2] = this.GetUTF32(i + 2);
						i += 9;
						num2++;
					}
					break;
				case 116:
					chars[num2] = 9;
					i++;
					num2++;
					break;
				case 117:
					if (text.Length <= i + 5)
					{
						goto IL_019B;
					}
					chars[num2] = (int)((ushort)this.GetUTF16(i + 2));
					i += 5;
					num2++;
					break;
				}
				IL_01F4:
				i++;
				continue;
				IL_019B:
				if (char.IsHighSurrogate(text[i]) && char.IsLowSurrogate(text[i + 1]))
				{
					chars[num2] = char.ConvertToUtf32(text[i], text[i + 1]);
					i++;
					num2++;
					goto IL_01F4;
				}
				chars[num2] = (int)text[i];
				num2++;
				goto IL_01F4;
			}
			chars[num2] = 0;
		}

		// Token: 0x06002CFC RID: 11516 RVA: 0x00108504 File Offset: 0x00106704
		protected void AddFloatToCharArray(float number, ref int index, int precision)
		{
			if (number < 0f)
			{
				this.m_input_CharArray[index++] = '-';
				number = -number;
			}
			number += this.k_Power[Mathf.Min(9, precision)];
			int num = (int)number;
			this.AddIntToCharArray(num, ref index, precision);
			if (precision > 0)
			{
				this.m_input_CharArray[index++] = '.';
				number -= (float)num;
				for (int i = 0; i < precision; i++)
				{
					number *= 10f;
					int num2 = (int)number;
					this.m_input_CharArray[index++] = (char)(num2 + 48);
					number -= (float)num2;
				}
			}
		}

		// Token: 0x06002CFD RID: 11517 RVA: 0x001085AC File Offset: 0x001067AC
		protected void AddIntToCharArray(int number, ref int index, int precision)
		{
			if (number < 0)
			{
				this.m_input_CharArray[index++] = '-';
				number = -number;
			}
			int num = index;
			do
			{
				this.m_input_CharArray[num++] = (char)(number % 10 + 48);
				number /= 10;
			}
			while (number > 0);
			int num2 = num;
			while (index + 1 < num)
			{
				num--;
				char c = this.m_input_CharArray[index];
				this.m_input_CharArray[index] = this.m_input_CharArray[num];
				this.m_input_CharArray[num] = c;
				index++;
			}
			index = num2;
		}

		// Token: 0x06002CFE RID: 11518 RVA: 0x0000D270 File Offset: 0x0000B470
		protected virtual int SetArraySizes(int[] chars)
		{
			return 0;
		}

		// Token: 0x06002CFF RID: 11519 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void GenerateTextMesh()
		{
		}

		// Token: 0x06002D00 RID: 11520 RVA: 0x0010863C File Offset: 0x0010683C
		public Vector2 GetPreferredValues()
		{
			if (this.m_isInputParsingRequired || this.m_isTextTruncated)
			{
				this.m_isCalculatingPreferredValues = true;
				this.ParseInputText();
			}
			float preferredWidth = this.GetPreferredWidth();
			float preferredHeight = this.GetPreferredHeight();
			return new Vector2(preferredWidth, preferredHeight);
		}

		// Token: 0x06002D01 RID: 11521 RVA: 0x00108684 File Offset: 0x00106884
		public Vector2 GetPreferredValues(float width, float height)
		{
			if (this.m_isInputParsingRequired || this.m_isTextTruncated)
			{
				this.m_isCalculatingPreferredValues = true;
				this.ParseInputText();
			}
			Vector2 vector = new Vector2(width, height);
			float preferredWidth = this.GetPreferredWidth(vector);
			float preferredHeight = this.GetPreferredHeight(vector);
			return new Vector2(preferredWidth, preferredHeight);
		}

		// Token: 0x06002D02 RID: 11522 RVA: 0x001086D4 File Offset: 0x001068D4
		public Vector2 GetPreferredValues(string text)
		{
			this.m_isCalculatingPreferredValues = true;
			this.StringToCharArray(text, ref this.m_char_buffer);
			this.SetArraySizes(this.m_char_buffer);
			Vector2 vector = TMP_Text.k_LargePositiveVector2;
			float preferredWidth = this.GetPreferredWidth(vector);
			float preferredHeight = this.GetPreferredHeight(vector);
			return new Vector2(preferredWidth, preferredHeight);
		}

		// Token: 0x06002D03 RID: 11523 RVA: 0x00108720 File Offset: 0x00106920
		public Vector2 GetPreferredValues(string text, float width, float height)
		{
			this.m_isCalculatingPreferredValues = true;
			this.StringToCharArray(text, ref this.m_char_buffer);
			this.SetArraySizes(this.m_char_buffer);
			Vector2 vector = new Vector2(width, height);
			float preferredWidth = this.GetPreferredWidth(vector);
			float preferredHeight = this.GetPreferredHeight(vector);
			return new Vector2(preferredWidth, preferredHeight);
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x00108770 File Offset: 0x00106970
		protected float GetPreferredWidth()
		{
			float num = ((!this.m_enableAutoSizing) ? this.m_fontSize : this.m_fontSizeMax);
			Vector2 vector = TMP_Text.k_LargePositiveVector2;
			if (this.m_isInputParsingRequired || this.m_isTextTruncated)
			{
				this.m_isCalculatingPreferredValues = true;
				this.ParseInputText();
			}
			float x = this.CalculatePreferredValues(num, vector).x;
			this.m_isPreferredWidthDirty = false;
			return x;
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x001087DC File Offset: 0x001069DC
		protected float GetPreferredWidth(Vector2 margin)
		{
			float num = ((!this.m_enableAutoSizing) ? this.m_fontSize : this.m_fontSizeMax);
			return this.CalculatePreferredValues(num, margin).x;
		}

		// Token: 0x06002D06 RID: 11526 RVA: 0x00108818 File Offset: 0x00106A18
		protected float GetPreferredHeight()
		{
			float num = ((!this.m_enableAutoSizing) ? this.m_fontSize : this.m_fontSizeMax);
			Vector2 vector = new Vector2((this.m_marginWidth == 0f) ? TMP_Text.k_LargePositiveFloat : this.m_marginWidth, TMP_Text.k_LargePositiveFloat);
			if (this.m_isInputParsingRequired || this.m_isTextTruncated)
			{
				this.m_isCalculatingPreferredValues = true;
				this.ParseInputText();
			}
			float y = this.CalculatePreferredValues(num, vector).y;
			this.m_isPreferredHeightDirty = false;
			return y;
		}

		// Token: 0x06002D07 RID: 11527 RVA: 0x001088AC File Offset: 0x00106AAC
		protected float GetPreferredHeight(Vector2 margin)
		{
			float num = ((!this.m_enableAutoSizing) ? this.m_fontSize : this.m_fontSizeMax);
			return this.CalculatePreferredValues(num, margin).y;
		}

		// Token: 0x06002D08 RID: 11528 RVA: 0x001088E8 File Offset: 0x00106AE8
		public Vector2 GetRenderedValues()
		{
			return this.GetTextBounds().size;
		}

		// Token: 0x06002D09 RID: 11529 RVA: 0x00108908 File Offset: 0x00106B08
		protected float GetRenderedWidth()
		{
			return this.GetRenderedValues().x;
		}

		// Token: 0x06002D0A RID: 11530 RVA: 0x00108924 File Offset: 0x00106B24
		protected float GetRenderedHeight()
		{
			return this.GetRenderedValues().y;
		}

		// Token: 0x06002D0B RID: 11531 RVA: 0x00108940 File Offset: 0x00106B40
		protected virtual Vector2 CalculatePreferredValues(float defaultFontSize, Vector2 marginSize)
		{
			if (this.m_fontAsset == null || this.m_fontAsset.characterDictionary == null)
			{
				Debug.LogWarning("Can't Generate Mesh! No Font Asset has been assigned to Object ID: " + base.GetInstanceID());
				return Vector2.zero;
			}
			if (this.m_char_buffer == null || this.m_char_buffer.Length == 0 || this.m_char_buffer[0] == 0)
			{
				return Vector2.zero;
			}
			this.m_currentFontAsset = this.m_fontAsset;
			this.m_currentMaterial = this.m_sharedMaterial;
			this.m_currentMaterialIndex = 0;
			this.m_materialReferenceStack.SetDefault(new MaterialReference(0, this.m_currentFontAsset, null, this.m_currentMaterial, this.m_padding));
			int totalCharacterCount = this.m_totalCharacterCount;
			if (this.m_internalCharacterInfo == null || totalCharacterCount > this.m_internalCharacterInfo.Length)
			{
				this.m_internalCharacterInfo = new TMP_CharacterInfo[(totalCharacterCount <= 1024) ? Mathf.NextPowerOfTwo(totalCharacterCount) : (totalCharacterCount + 256)];
			}
			this.m_fontScale = defaultFontSize / this.m_currentFontAsset.fontInfo.PointSize * ((!this.m_isOrthographic) ? 0.1f : 1f);
			this.m_fontScaleMultiplier = 1f;
			float num = defaultFontSize / this.m_fontAsset.fontInfo.PointSize * this.m_fontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
			float num2 = this.m_fontScale;
			this.m_currentFontSize = defaultFontSize;
			this.m_sizeStack.SetDefault(this.m_currentFontSize);
			this.m_style = this.m_fontStyle;
			this.m_baselineOffset = 0f;
			this.m_styleStack.Clear();
			this.m_lineOffset = 0f;
			this.m_lineHeight = 0f;
			float num3 = this.m_currentFontAsset.fontInfo.LineHeight - (this.m_currentFontAsset.fontInfo.Ascender - this.m_currentFontAsset.fontInfo.Descender);
			this.m_cSpacing = 0f;
			this.m_monoSpacing = 0f;
			this.m_xAdvance = 0f;
			float num4 = 0f;
			this.tag_LineIndent = 0f;
			this.tag_Indent = 0f;
			this.m_indentStack.SetDefault(0f);
			this.tag_NoParsing = false;
			this.m_characterCount = 0;
			this.m_firstCharacterOfLine = 0;
			this.m_maxLineAscender = TMP_Text.k_LargeNegativeFloat;
			this.m_maxLineDescender = TMP_Text.k_LargePositiveFloat;
			this.m_lineNumber = 0;
			float x = marginSize.x;
			this.m_marginLeft = 0f;
			this.m_marginRight = 0f;
			this.m_width = -1f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			this.m_maxAscender = 0f;
			this.m_maxDescender = 0f;
			bool flag = true;
			bool flag2 = false;
			WordWrapState wordWrapState = default(WordWrapState);
			this.SaveWordWrappingState(ref wordWrapState, 0, 0);
			WordWrapState wordWrapState2 = default(WordWrapState);
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			while (this.m_char_buffer[num10] != 0)
			{
				int num11 = this.m_char_buffer[num10];
				this.m_textElementType = TMP_TextElementType.Character;
				this.m_currentMaterialIndex = this.m_textInfo.characterInfo[this.m_characterCount].materialReferenceIndex;
				this.m_currentFontAsset = this.m_materialReferences[this.m_currentMaterialIndex].fontAsset;
				int currentMaterialIndex = this.m_currentMaterialIndex;
				if (!this.m_isRichText || num11 != 60)
				{
					goto IL_03AD;
				}
				this.m_isParsingText = true;
				if (!this.ValidateHtmlTag(this.m_char_buffer, num10 + 1, out num9))
				{
					goto IL_03AD;
				}
				num10 = num9;
				if (this.m_textElementType != TMP_TextElementType.Character)
				{
					goto IL_03AD;
				}
				IL_11C1:
				num10++;
				continue;
				IL_03AD:
				this.m_isParsingText = false;
				bool isUsingAlternateTypeface = this.m_textInfo.characterInfo[this.m_characterCount].isUsingAlternateTypeface;
				float num12 = 1f;
				if (this.m_textElementType == TMP_TextElementType.Character)
				{
					if ((this.m_style & FontStyles.UpperCase) == FontStyles.UpperCase)
					{
						if (char.IsLower((char)num11))
						{
							num11 = (int)char.ToUpper((char)num11);
						}
					}
					else if ((this.m_style & FontStyles.LowerCase) == FontStyles.LowerCase)
					{
						if (char.IsUpper((char)num11))
						{
							num11 = (int)char.ToLower((char)num11);
						}
					}
					else if (((this.m_fontStyle & FontStyles.SmallCaps) == FontStyles.SmallCaps || (this.m_style & FontStyles.SmallCaps) == FontStyles.SmallCaps) && char.IsLower((char)num11))
					{
						num12 = 0.8f;
						num11 = (int)char.ToUpper((char)num11);
					}
				}
				if (this.m_textElementType == TMP_TextElementType.Sprite)
				{
					TMP_Sprite tmp_Sprite = this.m_currentSpriteAsset.spriteInfoList[this.m_spriteIndex];
					if (tmp_Sprite == null)
					{
						goto IL_11C1;
					}
					num11 = 57344 + this.m_spriteIndex;
					this.m_currentFontAsset = this.m_fontAsset;
					float num13 = this.m_currentFontSize / this.m_fontAsset.fontInfo.PointSize * this.m_fontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
					num2 = this.m_fontAsset.fontInfo.Ascender / tmp_Sprite.height * tmp_Sprite.scale * num13;
					this.m_cached_TextElement = tmp_Sprite;
					this.m_internalCharacterInfo[this.m_characterCount].elementType = TMP_TextElementType.Sprite;
					this.m_currentMaterialIndex = currentMaterialIndex;
				}
				else if (this.m_textElementType == TMP_TextElementType.Character)
				{
					this.m_cached_TextElement = this.m_textInfo.characterInfo[this.m_characterCount].textElement;
					if (this.m_cached_TextElement == null)
					{
						goto IL_11C1;
					}
					this.m_currentMaterialIndex = this.m_textInfo.characterInfo[this.m_characterCount].materialReferenceIndex;
					this.m_fontScale = this.m_currentFontSize * num12 / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
					num2 = this.m_fontScale * this.m_fontScaleMultiplier * this.m_cached_TextElement.scale;
					this.m_internalCharacterInfo[this.m_characterCount].elementType = TMP_TextElementType.Character;
				}
				float num14 = num2;
				if (num11 == 173)
				{
					num2 = 0f;
				}
				this.m_internalCharacterInfo[this.m_characterCount].character = (char)num11;
				if (this.m_enableKerning && this.m_characterCount >= 1)
				{
					int character = (int)this.m_internalCharacterInfo[this.m_characterCount - 1].character;
					KerningPairKey kerningPairKey = new KerningPairKey(character, num11);
					KerningPair kerningPair;
					this.m_currentFontAsset.kerningDictionary.TryGetValue(kerningPairKey.key, out kerningPair);
					if (kerningPair != null)
					{
						this.m_xAdvance += kerningPair.XadvanceOffset * num2;
					}
				}
				float num15 = 0f;
				if (this.m_monoSpacing != 0f)
				{
					num15 = this.m_monoSpacing / 2f - (this.m_cached_TextElement.width / 2f + this.m_cached_TextElement.xOffset) * num2;
					this.m_xAdvance += num15;
				}
				float num16;
				if (this.m_textElementType == TMP_TextElementType.Character && !isUsingAlternateTypeface && ((this.m_style & FontStyles.Bold) == FontStyles.Bold || (this.m_fontStyle & FontStyles.Bold) == FontStyles.Bold))
				{
					num16 = 1f + this.m_currentFontAsset.boldSpacing * 0.01f;
				}
				else
				{
					num16 = 1f;
				}
				this.m_internalCharacterInfo[this.m_characterCount].baseLine = 0f - this.m_lineOffset + this.m_baselineOffset;
				float num17 = this.m_currentFontAsset.fontInfo.Ascender * ((this.m_textElementType != TMP_TextElementType.Character) ? this.m_internalCharacterInfo[this.m_characterCount].scale : num2) + this.m_baselineOffset;
				this.m_internalCharacterInfo[this.m_characterCount].ascender = num17 - this.m_lineOffset;
				this.m_maxLineAscender = ((num17 <= this.m_maxLineAscender) ? this.m_maxLineAscender : num17);
				float num18 = this.m_currentFontAsset.fontInfo.Descender * ((this.m_textElementType != TMP_TextElementType.Character) ? this.m_internalCharacterInfo[this.m_characterCount].scale : num2) + this.m_baselineOffset;
				float num19 = (this.m_internalCharacterInfo[this.m_characterCount].descender = num18 - this.m_lineOffset);
				this.m_maxLineDescender = ((num18 >= this.m_maxLineDescender) ? this.m_maxLineDescender : num18);
				if ((this.m_style & FontStyles.Subscript) == FontStyles.Subscript || (this.m_style & FontStyles.Superscript) == FontStyles.Superscript)
				{
					float num20 = (num17 - this.m_baselineOffset) / this.m_currentFontAsset.fontInfo.SubSize;
					num17 = this.m_maxLineAscender;
					this.m_maxLineAscender = ((num20 <= this.m_maxLineAscender) ? this.m_maxLineAscender : num20);
					float num21 = (num18 - this.m_baselineOffset) / this.m_currentFontAsset.fontInfo.SubSize;
					num18 = this.m_maxLineDescender;
					this.m_maxLineDescender = ((num21 >= this.m_maxLineDescender) ? this.m_maxLineDescender : num21);
				}
				if (this.m_lineNumber == 0)
				{
					this.m_maxAscender = ((this.m_maxAscender <= num17) ? num17 : this.m_maxAscender);
				}
				if (num11 == 9 || !char.IsWhiteSpace((char)num11) || this.m_textElementType == TMP_TextElementType.Sprite)
				{
					float num22 = ((this.m_width == -1f) ? (x + 0.0001f - this.m_marginLeft - this.m_marginRight) : Mathf.Min(x + 0.0001f - this.m_marginLeft - this.m_marginRight, this.m_width));
					num7 = this.m_xAdvance + this.m_cached_TextElement.xAdvance * ((num11 == 173) ? num14 : num2);
					if (num7 > num22 && this.enableWordWrapping && this.m_characterCount != this.m_firstCharacterOfLine)
					{
						if (num8 == wordWrapState2.previous_WordBreak || flag)
						{
							if (!this.m_isCharacterWrappingEnabled)
							{
								this.m_isCharacterWrappingEnabled = true;
							}
							else
							{
								flag2 = true;
							}
						}
						num10 = this.RestoreWordWrappingState(ref wordWrapState2);
						num8 = num10;
						if (this.m_char_buffer[num10] == 173)
						{
							this.m_isTextTruncated = true;
							this.m_char_buffer[num10] = 45;
							this.CalculatePreferredValues(defaultFontSize, marginSize);
							return Vector2.zero;
						}
						if (this.m_lineNumber > 0 && !TMP_Math.Approximately(this.m_maxLineAscender, this.m_startOfLineAscender) && this.m_lineHeight == 0f)
						{
							float num23 = this.m_maxLineAscender - this.m_startOfLineAscender;
							this.m_lineOffset += num23;
							wordWrapState2.lineOffset = this.m_lineOffset;
							wordWrapState2.previousLineAscender = this.m_maxLineAscender;
						}
						float num24 = this.m_maxLineAscender - this.m_lineOffset;
						float num25 = this.m_maxLineDescender - this.m_lineOffset;
						this.m_maxDescender = ((this.m_maxDescender >= num25) ? num25 : this.m_maxDescender);
						this.m_firstCharacterOfLine = this.m_characterCount;
						num5 += this.m_xAdvance;
						if (this.m_enableWordWrapping)
						{
							num6 = this.m_maxAscender - this.m_maxDescender;
						}
						else
						{
							num6 = Mathf.Max(num6, num24 - num25);
						}
						this.SaveWordWrappingState(ref wordWrapState, num10, this.m_characterCount - 1);
						this.m_lineNumber++;
						if (this.m_lineHeight == 0f)
						{
							float num26 = this.m_internalCharacterInfo[this.m_characterCount].ascender - this.m_internalCharacterInfo[this.m_characterCount].baseLine;
							float num27 = 0f - this.m_maxLineDescender + num26 + (num3 + this.m_lineSpacing + this.m_lineSpacingDelta) * num;
							this.m_lineOffset += num27;
							this.m_startOfLineAscender = num26;
						}
						else
						{
							this.m_lineOffset += this.m_lineHeight + this.m_lineSpacing * num;
						}
						this.m_maxLineAscender = TMP_Text.k_LargeNegativeFloat;
						this.m_maxLineDescender = TMP_Text.k_LargePositiveFloat;
						this.m_xAdvance = this.tag_Indent;
						goto IL_11C1;
					}
				}
				if (this.m_lineNumber > 0 && !TMP_Math.Approximately(this.m_maxLineAscender, this.m_startOfLineAscender) && this.m_lineHeight == 0f && !this.m_isNewPage)
				{
					float num28 = this.m_maxLineAscender - this.m_startOfLineAscender;
					num19 -= num28;
					this.m_lineOffset += num28;
					this.m_startOfLineAscender += num28;
					wordWrapState2.lineOffset = this.m_lineOffset;
					wordWrapState2.previousLineAscender = this.m_startOfLineAscender;
				}
				if (num11 == 9)
				{
					float num29 = this.m_currentFontAsset.fontInfo.TabWidth * num2;
					float num30 = Mathf.Ceil(this.m_xAdvance / num29) * num29;
					this.m_xAdvance = ((num30 <= this.m_xAdvance) ? (this.m_xAdvance + num29) : num30);
				}
				else if (this.m_monoSpacing != 0f)
				{
					this.m_xAdvance += this.m_monoSpacing - num15 + (this.m_characterSpacing + this.m_currentFontAsset.normalSpacingOffset) * num2 + this.m_cSpacing;
				}
				else
				{
					this.m_xAdvance += (this.m_cached_TextElement.xAdvance * num16 + this.m_characterSpacing + this.m_currentFontAsset.normalSpacingOffset) * num2 + this.m_cSpacing;
				}
				if (num11 == 13)
				{
					num4 = Mathf.Max(num4, num5 + this.m_xAdvance);
					num5 = 0f;
					this.m_xAdvance = this.tag_Indent;
				}
				if (num11 == 10 || this.m_characterCount == totalCharacterCount - 1)
				{
					if (this.m_lineNumber > 0 && !TMP_Math.Approximately(this.m_maxLineAscender, this.m_startOfLineAscender) && this.m_lineHeight == 0f)
					{
						float num31 = this.m_maxLineAscender - this.m_startOfLineAscender;
						num19 -= num31;
						this.m_lineOffset += num31;
					}
					float num32 = this.m_maxLineDescender - this.m_lineOffset;
					this.m_maxDescender = ((this.m_maxDescender >= num32) ? num32 : this.m_maxDescender);
					this.m_firstCharacterOfLine = this.m_characterCount + 1;
					if (num11 == 10 && this.m_characterCount != totalCharacterCount - 1)
					{
						num4 = Mathf.Max(num4, num5 + num7);
						num5 = 0f;
					}
					else
					{
						num5 = Mathf.Max(num4, num5 + num7);
					}
					num6 = this.m_maxAscender - this.m_maxDescender;
					if (num11 == 10)
					{
						this.SaveWordWrappingState(ref wordWrapState, num10, this.m_characterCount);
						this.SaveWordWrappingState(ref wordWrapState2, num10, this.m_characterCount);
						this.m_lineNumber++;
						if (this.m_lineHeight == 0f)
						{
							float num27 = 0f - this.m_maxLineDescender + num17 + (num3 + this.m_lineSpacing + this.m_paragraphSpacing + this.m_lineSpacingDelta) * num;
							this.m_lineOffset += num27;
						}
						else
						{
							this.m_lineOffset += this.m_lineHeight + (this.m_lineSpacing + this.m_paragraphSpacing) * num;
						}
						this.m_maxLineAscender = TMP_Text.k_LargeNegativeFloat;
						this.m_maxLineDescender = TMP_Text.k_LargePositiveFloat;
						this.m_startOfLineAscender = num17;
						this.m_xAdvance = this.tag_LineIndent + this.tag_Indent;
					}
				}
				if (this.m_enableWordWrapping || this.m_overflowMode == TextOverflowModes.Truncate || this.m_overflowMode == TextOverflowModes.Ellipsis)
				{
					if ((char.IsWhiteSpace((char)num11) || num11 == 45 || num11 == 173) && !this.m_isNonBreakingSpace && num11 != 160 && num11 != 8209 && num11 != 8239 && num11 != 8288)
					{
						this.SaveWordWrappingState(ref wordWrapState2, num10, this.m_characterCount);
						this.m_isCharacterWrappingEnabled = false;
						flag = false;
					}
					else if (((num11 > 4352 && num11 < 4607) || (num11 > 11904 && num11 < 40959) || (num11 > 43360 && num11 < 43391) || (num11 > 44032 && num11 < 55295) || (num11 > 63744 && num11 < 64255) || (num11 > 65072 && num11 < 65103) || (num11 > 65280 && num11 < 65519)) && !this.m_isNonBreakingSpace)
					{
						if (flag || flag2 || (!TMP_Settings.linebreakingRules.leadingCharacters.ContainsKey(num11) && this.m_characterCount < totalCharacterCount - 1 && !TMP_Settings.linebreakingRules.followingCharacters.ContainsKey((int)this.m_internalCharacterInfo[this.m_characterCount + 1].character)))
						{
							this.SaveWordWrappingState(ref wordWrapState2, num10, this.m_characterCount);
							this.m_isCharacterWrappingEnabled = false;
							flag = false;
						}
					}
					else if (flag || this.m_isCharacterWrappingEnabled || flag2)
					{
						this.SaveWordWrappingState(ref wordWrapState2, num10, this.m_characterCount);
					}
				}
				this.m_characterCount++;
				goto IL_11C1;
			}
			this.m_isCharacterWrappingEnabled = false;
			num5 += ((this.m_margin.x <= 0f) ? 0f : this.m_margin.x);
			num5 += ((this.m_margin.z <= 0f) ? 0f : this.m_margin.z);
			num6 += ((this.m_margin.y <= 0f) ? 0f : this.m_margin.y);
			num6 += ((this.m_margin.w <= 0f) ? 0f : this.m_margin.w);
			num5 = (float)((int)(num5 * 100f + 1f)) / 100f;
			num6 = (float)((int)(num6 * 100f + 1f)) / 100f;
			return new Vector2(num5, num6);
		}

		// Token: 0x06002D0C RID: 11532 RVA: 0x00109C20 File Offset: 0x00107E20
		protected virtual Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		// Token: 0x06002D0D RID: 11533 RVA: 0x00109C38 File Offset: 0x00107E38
		protected Bounds GetTextBounds()
		{
			if (this.m_textInfo == null)
			{
				return default(Bounds);
			}
			Extents extents = new Extents(TMP_Text.k_LargePositiveVector2, TMP_Text.k_LargeNegativeVector2);
			for (int i = 0; i < this.m_textInfo.characterCount; i++)
			{
				if (this.m_textInfo.characterInfo[i].isVisible)
				{
					extents.min.x = Mathf.Min(extents.min.x, this.m_textInfo.characterInfo[i].bottomLeft.x);
					extents.min.y = Mathf.Min(extents.min.y, this.m_textInfo.characterInfo[i].descender);
					extents.max.x = Mathf.Max(extents.max.x, this.m_textInfo.characterInfo[i].xAdvance);
					extents.max.y = Mathf.Max(extents.max.y, this.m_textInfo.characterInfo[i].ascender);
				}
			}
			Vector2 vector;
			vector.x = extents.max.x - extents.min.x;
			vector.y = extents.max.y - extents.min.y;
			Vector2 vector2 = (extents.min + extents.max) / 2f;
			return new Bounds(vector2, vector);
		}

		// Token: 0x06002D0E RID: 11534 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void AdjustLineOffset(int startIndex, int endIndex, float offset)
		{
		}

		// Token: 0x06002D0F RID: 11535 RVA: 0x00109DEC File Offset: 0x00107FEC
		protected void ResizeLineExtents(int size)
		{
			size = ((size <= 1024) ? Mathf.NextPowerOfTwo(size + 1) : (size + 256));
			TMP_LineInfo[] array = new TMP_LineInfo[size];
			for (int i = 0; i < size; i++)
			{
				if (i < this.m_textInfo.lineInfo.Length)
				{
					array[i] = this.m_textInfo.lineInfo[i];
				}
				else
				{
					array[i].lineExtents.min = TMP_Text.k_LargePositiveVector2;
					array[i].lineExtents.max = TMP_Text.k_LargeNegativeVector2;
					array[i].ascender = TMP_Text.k_LargeNegativeFloat;
					array[i].descender = TMP_Text.k_LargePositiveFloat;
				}
			}
			this.m_textInfo.lineInfo = array;
		}

		// Token: 0x06002D10 RID: 11536 RVA: 0x000124F9 File Offset: 0x000106F9
		public virtual TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		// Token: 0x06002D11 RID: 11537 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void ComputeMarginSize()
		{
		}

		// Token: 0x06002D12 RID: 11538 RVA: 0x00109EC8 File Offset: 0x001080C8
		protected int GetArraySizes(int[] chars)
		{
			int num = 0;
			this.m_totalCharacterCount = 0;
			this.m_isUsingBold = false;
			this.m_isParsingText = false;
			int num2 = 0;
			while (chars[num2] != 0)
			{
				int num3 = chars[num2];
				if (this.m_isRichText && num3 == 60 && this.ValidateHtmlTag(chars, num2 + 1, out num))
				{
					num2 = num;
					if ((this.m_style & FontStyles.Bold) == FontStyles.Bold)
					{
						this.m_isUsingBold = true;
					}
				}
				else
				{
					if (!char.IsWhiteSpace((char)num3))
					{
					}
					this.m_totalCharacterCount++;
				}
				num2++;
			}
			return this.m_totalCharacterCount;
		}

		// Token: 0x06002D13 RID: 11539 RVA: 0x00109F64 File Offset: 0x00108164
		protected void SaveWordWrappingState(ref WordWrapState state, int index, int count)
		{
			state.currentFontAsset = this.m_currentFontAsset;
			state.currentSpriteAsset = this.m_currentSpriteAsset;
			state.currentMaterial = this.m_currentMaterial;
			state.currentMaterialIndex = this.m_currentMaterialIndex;
			state.previous_WordBreak = index;
			state.total_CharacterCount = count;
			state.visible_CharacterCount = this.m_lineVisibleCharacterCount;
			state.visible_LinkCount = this.m_textInfo.linkCount;
			state.firstCharacterIndex = this.m_firstCharacterOfLine;
			state.firstVisibleCharacterIndex = this.m_firstVisibleCharacterOfLine;
			state.lastVisibleCharIndex = this.m_lastVisibleCharacterOfLine;
			state.fontStyle = this.m_style;
			state.fontScale = this.m_fontScale;
			state.fontScaleMultiplier = this.m_fontScaleMultiplier;
			state.currentFontSize = this.m_currentFontSize;
			state.xAdvance = this.m_xAdvance;
			state.maxCapHeight = this.m_maxCapHeight;
			state.maxAscender = this.m_maxAscender;
			state.maxDescender = this.m_maxDescender;
			state.maxLineAscender = this.m_maxLineAscender;
			state.maxLineDescender = this.m_maxLineDescender;
			state.previousLineAscender = this.m_startOfLineAscender;
			state.preferredWidth = this.m_preferredWidth;
			state.preferredHeight = this.m_preferredHeight;
			state.meshExtents = this.m_meshExtents;
			state.lineNumber = this.m_lineNumber;
			state.lineOffset = this.m_lineOffset;
			state.baselineOffset = this.m_baselineOffset;
			state.vertexColor = this.m_htmlColor;
			state.tagNoParsing = this.tag_NoParsing;
			state.colorStack = this.m_colorStack;
			state.sizeStack = this.m_sizeStack;
			state.fontWeightStack = this.m_fontWeightStack;
			state.styleStack = this.m_styleStack;
			state.actionStack = this.m_actionStack;
			state.materialReferenceStack = this.m_materialReferenceStack;
			if (this.m_lineNumber < this.m_textInfo.lineInfo.Length)
			{
				state.lineInfo = this.m_textInfo.lineInfo[this.m_lineNumber];
			}
		}

		// Token: 0x06002D14 RID: 11540 RVA: 0x0010A158 File Offset: 0x00108358
		protected int RestoreWordWrappingState(ref WordWrapState state)
		{
			int previous_WordBreak = state.previous_WordBreak;
			this.m_currentFontAsset = state.currentFontAsset;
			this.m_currentSpriteAsset = state.currentSpriteAsset;
			this.m_currentMaterial = state.currentMaterial;
			this.m_currentMaterialIndex = state.currentMaterialIndex;
			this.m_characterCount = state.total_CharacterCount + 1;
			this.m_lineVisibleCharacterCount = state.visible_CharacterCount;
			this.m_textInfo.linkCount = state.visible_LinkCount;
			this.m_firstCharacterOfLine = state.firstCharacterIndex;
			this.m_firstVisibleCharacterOfLine = state.firstVisibleCharacterIndex;
			this.m_lastVisibleCharacterOfLine = state.lastVisibleCharIndex;
			this.m_style = state.fontStyle;
			this.m_fontScale = state.fontScale;
			this.m_fontScaleMultiplier = state.fontScaleMultiplier;
			this.m_currentFontSize = state.currentFontSize;
			this.m_xAdvance = state.xAdvance;
			this.m_maxCapHeight = state.maxCapHeight;
			this.m_maxAscender = state.maxAscender;
			this.m_maxDescender = state.maxDescender;
			this.m_maxLineAscender = state.maxLineAscender;
			this.m_maxLineDescender = state.maxLineDescender;
			this.m_startOfLineAscender = state.previousLineAscender;
			this.m_preferredWidth = state.preferredWidth;
			this.m_preferredHeight = state.preferredHeight;
			this.m_meshExtents = state.meshExtents;
			this.m_lineNumber = state.lineNumber;
			this.m_lineOffset = state.lineOffset;
			this.m_baselineOffset = state.baselineOffset;
			this.m_htmlColor = state.vertexColor;
			this.tag_NoParsing = state.tagNoParsing;
			this.m_colorStack = state.colorStack;
			this.m_sizeStack = state.sizeStack;
			this.m_fontWeightStack = state.fontWeightStack;
			this.m_styleStack = state.styleStack;
			this.m_actionStack = state.actionStack;
			this.m_materialReferenceStack = state.materialReferenceStack;
			if (this.m_lineNumber < this.m_textInfo.lineInfo.Length)
			{
				this.m_textInfo.lineInfo[this.m_lineNumber] = state.lineInfo;
			}
			return previous_WordBreak;
		}

		// Token: 0x06002D15 RID: 11541 RVA: 0x0010A354 File Offset: 0x00108554
		protected virtual void SaveGlyphVertexInfo(float padding, float style_padding, Color32 vertexColor)
		{
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.position = this.m_textInfo.characterInfo[this.m_characterCount].bottomLeft;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.position = this.m_textInfo.characterInfo[this.m_characterCount].topLeft;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.position = this.m_textInfo.characterInfo[this.m_characterCount].topRight;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.position = this.m_textInfo.characterInfo[this.m_characterCount].bottomRight;
			vertexColor.a = ((this.m_fontColor32.a >= vertexColor.a) ? vertexColor.a : this.m_fontColor32.a);
			if (!this.m_enableVertexGradient)
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = vertexColor;
			}
			else if (!this.m_overrideHtmlColors && !this.m_htmlColor.CompareRGB(this.m_fontColor32))
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = vertexColor;
			}
			else if (this.m_fontColorGradientPreset != null)
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = this.m_fontColorGradientPreset.bottomLeft * vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = this.m_fontColorGradientPreset.topLeft * vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = this.m_fontColorGradientPreset.topRight * vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = this.m_fontColorGradientPreset.bottomRight * vertexColor;
			}
			else
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = this.m_fontColorGradient.bottomLeft * vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = this.m_fontColorGradient.topLeft * vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = this.m_fontColorGradient.topRight * vertexColor;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = this.m_fontColorGradient.bottomRight * vertexColor;
			}
			if (!this.m_isSDFShader)
			{
				style_padding = 0f;
			}
			FaceInfo fontInfo = this.m_currentFontAsset.fontInfo;
			Vector2 vector;
			vector.x = (this.m_cached_TextElement.x - padding - style_padding) / fontInfo.AtlasWidth;
			vector.y = 1f - (this.m_cached_TextElement.y + padding + style_padding + this.m_cached_TextElement.height) / fontInfo.AtlasHeight;
			Vector2 vector2;
			vector2.x = vector.x;
			vector2.y = 1f - (this.m_cached_TextElement.y - padding - style_padding) / fontInfo.AtlasHeight;
			Vector2 vector3;
			vector3.x = (this.m_cached_TextElement.x + padding + style_padding + this.m_cached_TextElement.width) / fontInfo.AtlasWidth;
			vector3.y = vector2.y;
			Vector2 vector4;
			vector4.x = vector3.x;
			vector4.y = vector.y;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.uv = vector;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.uv = vector2;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.uv = vector3;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.uv = vector4;
		}

		// Token: 0x06002D16 RID: 11542 RVA: 0x0010A924 File Offset: 0x00108B24
		protected virtual void SaveSpriteVertexInfo(Color32 vertexColor)
		{
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.position = this.m_textInfo.characterInfo[this.m_characterCount].bottomLeft;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.position = this.m_textInfo.characterInfo[this.m_characterCount].topLeft;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.position = this.m_textInfo.characterInfo[this.m_characterCount].topRight;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.position = this.m_textInfo.characterInfo[this.m_characterCount].bottomRight;
			if (this.m_tintAllSprites)
			{
				this.m_tintSprite = true;
			}
			Color32 color = ((!this.m_tintSprite) ? this.m_spriteColor : this.m_spriteColor.Multiply(vertexColor));
			color.a = ((color.a >= this.m_fontColor32.a) ? this.m_fontColor32.a : (color.a = ((color.a >= vertexColor.a) ? vertexColor.a : color.a)));
			if (!this.m_enableVertexGradient)
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = color;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = color;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = color;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = color;
			}
			else if (!this.m_overrideHtmlColors && !this.m_htmlColor.CompareRGB(this.m_fontColor32))
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = color;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = color;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = color;
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = color;
			}
			else if (this.m_fontColorGradientPreset != null)
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradientPreset.bottomLeft));
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradientPreset.topLeft));
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradientPreset.topRight));
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradientPreset.bottomRight));
			}
			else
			{
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradient.bottomLeft));
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradient.topLeft));
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradient.topRight));
				this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.color = ((!this.m_tintSprite) ? color : color.Multiply(this.m_fontColorGradient.bottomRight));
			}
			Vector2 vector = new Vector2(this.m_cached_TextElement.x / (float)this.m_currentSpriteAsset.spriteSheet.width, this.m_cached_TextElement.y / (float)this.m_currentSpriteAsset.spriteSheet.height);
			Vector2 vector2 = new Vector2(vector.x, (this.m_cached_TextElement.y + this.m_cached_TextElement.height) / (float)this.m_currentSpriteAsset.spriteSheet.height);
			Vector2 vector3 = new Vector2((this.m_cached_TextElement.x + this.m_cached_TextElement.width) / (float)this.m_currentSpriteAsset.spriteSheet.width, vector2.y);
			Vector2 vector4 = new Vector2(vector3.x, vector.y);
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BL.uv = vector;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TL.uv = vector2;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_TR.uv = vector3;
			this.m_textInfo.characterInfo[this.m_characterCount].vertex_BR.uv = vector4;
		}

		// Token: 0x06002D17 RID: 11543 RVA: 0x0010AF88 File Offset: 0x00109188
		protected virtual void FillCharacterVertexBuffers(int i, int index_X4)
		{
			int materialReferenceIndex = this.m_textInfo.characterInfo[i].materialReferenceIndex;
			index_X4 = this.m_textInfo.meshInfo[materialReferenceIndex].vertexCount;
			TMP_CharacterInfo[] characterInfo = this.m_textInfo.characterInfo;
			this.m_textInfo.characterInfo[i].vertexIndex = index_X4;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[index_X4] = characterInfo[i].vertex_BL.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[1 + index_X4] = characterInfo[i].vertex_TL.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[2 + index_X4] = characterInfo[i].vertex_TR.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[3 + index_X4] = characterInfo[i].vertex_BR.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[index_X4] = characterInfo[i].vertex_BL.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[1 + index_X4] = characterInfo[i].vertex_TL.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[2 + index_X4] = characterInfo[i].vertex_TR.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[3 + index_X4] = characterInfo[i].vertex_BR.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[index_X4] = characterInfo[i].vertex_BL.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[1 + index_X4] = characterInfo[i].vertex_TL.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[2 + index_X4] = characterInfo[i].vertex_TR.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[3 + index_X4] = characterInfo[i].vertex_BR.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[index_X4] = characterInfo[i].vertex_BL.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[1 + index_X4] = characterInfo[i].vertex_TL.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[2 + index_X4] = characterInfo[i].vertex_TR.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[3 + index_X4] = characterInfo[i].vertex_BR.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertexCount = index_X4 + 4;
		}

		// Token: 0x06002D18 RID: 11544 RVA: 0x0010B338 File Offset: 0x00109538
		protected virtual void FillCharacterVertexBuffers(int i, int index_X4, bool isVolumetric)
		{
			int materialReferenceIndex = this.m_textInfo.characterInfo[i].materialReferenceIndex;
			index_X4 = this.m_textInfo.meshInfo[materialReferenceIndex].vertexCount;
			TMP_CharacterInfo[] characterInfo = this.m_textInfo.characterInfo;
			this.m_textInfo.characterInfo[i].vertexIndex = index_X4;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[index_X4] = characterInfo[i].vertex_BL.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[1 + index_X4] = characterInfo[i].vertex_TL.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[2 + index_X4] = characterInfo[i].vertex_TR.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[3 + index_X4] = characterInfo[i].vertex_BR.position;
			if (isVolumetric)
			{
				Vector3 vector = new Vector3(0f, 0f, this.m_fontSize * this.m_fontScale);
				this.m_textInfo.meshInfo[materialReferenceIndex].vertices[4 + index_X4] = characterInfo[i].vertex_BL.position + vector;
				this.m_textInfo.meshInfo[materialReferenceIndex].vertices[5 + index_X4] = characterInfo[i].vertex_TL.position + vector;
				this.m_textInfo.meshInfo[materialReferenceIndex].vertices[6 + index_X4] = characterInfo[i].vertex_TR.position + vector;
				this.m_textInfo.meshInfo[materialReferenceIndex].vertices[7 + index_X4] = characterInfo[i].vertex_BR.position + vector;
			}
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[index_X4] = characterInfo[i].vertex_BL.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[1 + index_X4] = characterInfo[i].vertex_TL.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[2 + index_X4] = characterInfo[i].vertex_TR.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[3 + index_X4] = characterInfo[i].vertex_BR.uv;
			if (isVolumetric)
			{
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[4 + index_X4] = characterInfo[i].vertex_BL.uv;
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[5 + index_X4] = characterInfo[i].vertex_TL.uv;
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[6 + index_X4] = characterInfo[i].vertex_TR.uv;
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[7 + index_X4] = characterInfo[i].vertex_BR.uv;
			}
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[index_X4] = characterInfo[i].vertex_BL.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[1 + index_X4] = characterInfo[i].vertex_TL.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[2 + index_X4] = characterInfo[i].vertex_TR.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[3 + index_X4] = characterInfo[i].vertex_BR.uv2;
			if (isVolumetric)
			{
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[4 + index_X4] = characterInfo[i].vertex_BL.uv2;
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[5 + index_X4] = characterInfo[i].vertex_TL.uv2;
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[6 + index_X4] = characterInfo[i].vertex_TR.uv2;
				this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[7 + index_X4] = characterInfo[i].vertex_BR.uv2;
			}
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[index_X4] = characterInfo[i].vertex_BL.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[1 + index_X4] = characterInfo[i].vertex_TL.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[2 + index_X4] = characterInfo[i].vertex_TR.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[3 + index_X4] = characterInfo[i].vertex_BR.color;
			if (isVolumetric)
			{
				Color32 color = new Color32(byte.MaxValue, byte.MaxValue, 128, byte.MaxValue);
				this.m_textInfo.meshInfo[materialReferenceIndex].colors32[4 + index_X4] = color;
				this.m_textInfo.meshInfo[materialReferenceIndex].colors32[5 + index_X4] = color;
				this.m_textInfo.meshInfo[materialReferenceIndex].colors32[6 + index_X4] = color;
				this.m_textInfo.meshInfo[materialReferenceIndex].colors32[7 + index_X4] = color;
			}
			this.m_textInfo.meshInfo[materialReferenceIndex].vertexCount = index_X4 + (isVolumetric ? 8 : 4);
		}

		// Token: 0x06002D19 RID: 11545 RVA: 0x0010AF88 File Offset: 0x00109188
		protected virtual void FillSpriteVertexBuffers(int i, int index_X4)
		{
			int materialReferenceIndex = this.m_textInfo.characterInfo[i].materialReferenceIndex;
			index_X4 = this.m_textInfo.meshInfo[materialReferenceIndex].vertexCount;
			TMP_CharacterInfo[] characterInfo = this.m_textInfo.characterInfo;
			this.m_textInfo.characterInfo[i].vertexIndex = index_X4;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[index_X4] = characterInfo[i].vertex_BL.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[1 + index_X4] = characterInfo[i].vertex_TL.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[2 + index_X4] = characterInfo[i].vertex_TR.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertices[3 + index_X4] = characterInfo[i].vertex_BR.position;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[index_X4] = characterInfo[i].vertex_BL.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[1 + index_X4] = characterInfo[i].vertex_TL.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[2 + index_X4] = characterInfo[i].vertex_TR.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs0[3 + index_X4] = characterInfo[i].vertex_BR.uv;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[index_X4] = characterInfo[i].vertex_BL.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[1 + index_X4] = characterInfo[i].vertex_TL.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[2 + index_X4] = characterInfo[i].vertex_TR.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].uvs2[3 + index_X4] = characterInfo[i].vertex_BR.uv2;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[index_X4] = characterInfo[i].vertex_BL.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[1 + index_X4] = characterInfo[i].vertex_TL.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[2 + index_X4] = characterInfo[i].vertex_TR.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].colors32[3 + index_X4] = characterInfo[i].vertex_BR.color;
			this.m_textInfo.meshInfo[materialReferenceIndex].vertexCount = index_X4 + 4;
		}

		// Token: 0x06002D1A RID: 11546 RVA: 0x0010BA60 File Offset: 0x00109C60
		protected virtual void DrawUnderlineMesh(Vector3 start, Vector3 end, ref int index, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor)
		{
			if (this.m_cached_Underline_GlyphInfo == null)
			{
				if (!TMP_Settings.warningsDisabled)
				{
					Debug.LogWarning("Unable to add underline since the Font Asset doesn't contain the underline character.", this);
				}
				return;
			}
			int num = index + 12;
			if (num > this.m_textInfo.meshInfo[0].vertices.Length)
			{
				this.m_textInfo.meshInfo[0].ResizeMeshInfo(num / 4);
			}
			start.y = Mathf.Min(start.y, end.y);
			end.y = Mathf.Min(start.y, end.y);
			float num2 = this.m_cached_Underline_GlyphInfo.width / 2f * maxScale;
			if (end.x - start.x < this.m_cached_Underline_GlyphInfo.width * maxScale)
			{
				num2 = (end.x - start.x) / 2f;
			}
			float num3 = this.m_padding * startScale / maxScale;
			float num4 = this.m_padding * endScale / maxScale;
			float height = this.m_cached_Underline_GlyphInfo.height;
			Vector3[] vertices = this.m_textInfo.meshInfo[0].vertices;
			vertices[index] = start + new Vector3(0f, 0f - (height + this.m_padding) * maxScale, 0f);
			vertices[index + 1] = start + new Vector3(0f, this.m_padding * maxScale, 0f);
			vertices[index + 2] = vertices[index + 1] + new Vector3(num2, 0f, 0f);
			vertices[index + 3] = vertices[index] + new Vector3(num2, 0f, 0f);
			vertices[index + 4] = vertices[index + 3];
			vertices[index + 5] = vertices[index + 2];
			vertices[index + 6] = end + new Vector3(-num2, this.m_padding * maxScale, 0f);
			vertices[index + 7] = end + new Vector3(-num2, -(height + this.m_padding) * maxScale, 0f);
			vertices[index + 8] = vertices[index + 7];
			vertices[index + 9] = vertices[index + 6];
			vertices[index + 10] = end + new Vector3(0f, this.m_padding * maxScale, 0f);
			vertices[index + 11] = end + new Vector3(0f, -(height + this.m_padding) * maxScale, 0f);
			Vector2[] uvs = this.m_textInfo.meshInfo[0].uvs0;
			Vector2 vector = new Vector2((this.m_cached_Underline_GlyphInfo.x - num3) / this.m_fontAsset.fontInfo.AtlasWidth, 1f - (this.m_cached_Underline_GlyphInfo.y + this.m_padding + this.m_cached_Underline_GlyphInfo.height) / this.m_fontAsset.fontInfo.AtlasHeight);
			Vector2 vector2 = new Vector2(vector.x, 1f - (this.m_cached_Underline_GlyphInfo.y - this.m_padding) / this.m_fontAsset.fontInfo.AtlasHeight);
			Vector2 vector3 = new Vector2((this.m_cached_Underline_GlyphInfo.x - num3 + this.m_cached_Underline_GlyphInfo.width / 2f) / this.m_fontAsset.fontInfo.AtlasWidth, vector2.y);
			Vector2 vector4 = new Vector2(vector3.x, vector.y);
			Vector2 vector5 = new Vector2((this.m_cached_Underline_GlyphInfo.x + num4 + this.m_cached_Underline_GlyphInfo.width / 2f) / this.m_fontAsset.fontInfo.AtlasWidth, vector2.y);
			Vector2 vector6 = new Vector2(vector5.x, vector.y);
			Vector2 vector7 = new Vector2((this.m_cached_Underline_GlyphInfo.x + num4 + this.m_cached_Underline_GlyphInfo.width) / this.m_fontAsset.fontInfo.AtlasWidth, vector2.y);
			Vector2 vector8 = new Vector2(vector7.x, vector.y);
			uvs[index] = vector;
			uvs[1 + index] = vector2;
			uvs[2 + index] = vector3;
			uvs[3 + index] = vector4;
			uvs[4 + index] = new Vector2(vector3.x - vector3.x * 0.001f, vector.y);
			uvs[5 + index] = new Vector2(vector3.x - vector3.x * 0.001f, vector2.y);
			uvs[6 + index] = new Vector2(vector3.x + vector3.x * 0.001f, vector2.y);
			uvs[7 + index] = new Vector2(vector3.x + vector3.x * 0.001f, vector.y);
			uvs[8 + index] = vector6;
			uvs[9 + index] = vector5;
			uvs[10 + index] = vector7;
			uvs[11 + index] = vector8;
			float num5 = (vertices[index + 2].x - start.x) / (end.x - start.x);
			float num6 = Mathf.Abs(sdfScale);
			Vector2[] uvs2 = this.m_textInfo.meshInfo[0].uvs2;
			uvs2[index] = this.PackUV(0f, 0f, num6);
			uvs2[1 + index] = this.PackUV(0f, 1f, num6);
			uvs2[2 + index] = this.PackUV(num5, 1f, num6);
			uvs2[3 + index] = this.PackUV(num5, 0f, num6);
			float num7 = (vertices[index + 4].x - start.x) / (end.x - start.x);
			num5 = (vertices[index + 6].x - start.x) / (end.x - start.x);
			uvs2[4 + index] = this.PackUV(num7, 0f, num6);
			uvs2[5 + index] = this.PackUV(num7, 1f, num6);
			uvs2[6 + index] = this.PackUV(num5, 1f, num6);
			uvs2[7 + index] = this.PackUV(num5, 0f, num6);
			num7 = (vertices[index + 8].x - start.x) / (end.x - start.x);
			num5 = (vertices[index + 6].x - start.x) / (end.x - start.x);
			uvs2[8 + index] = this.PackUV(num7, 0f, num6);
			uvs2[9 + index] = this.PackUV(num7, 1f, num6);
			uvs2[10 + index] = this.PackUV(1f, 1f, num6);
			uvs2[11 + index] = this.PackUV(1f, 0f, num6);
			Color32[] colors = this.m_textInfo.meshInfo[0].colors32;
			colors[index] = underlineColor;
			colors[1 + index] = underlineColor;
			colors[2 + index] = underlineColor;
			colors[3 + index] = underlineColor;
			colors[4 + index] = underlineColor;
			colors[5 + index] = underlineColor;
			colors[6 + index] = underlineColor;
			colors[7 + index] = underlineColor;
			colors[8 + index] = underlineColor;
			colors[9 + index] = underlineColor;
			colors[10 + index] = underlineColor;
			colors[11 + index] = underlineColor;
			index += 12;
		}

		// Token: 0x06002D1B RID: 11547 RVA: 0x0002069D File Offset: 0x0001E89D
		protected void GetSpecialCharacters(TMP_FontAsset fontAsset)
		{
			if (!fontAsset.characterDictionary.TryGetValue(95, out this.m_cached_Underline_GlyphInfo))
			{
			}
			if (!fontAsset.characterDictionary.TryGetValue(8230, out this.m_cached_Ellipsis_GlyphInfo))
			{
			}
		}

		// Token: 0x06002D1C RID: 11548 RVA: 0x0010C3F8 File Offset: 0x0010A5F8
		protected TMP_FontAsset GetFontAssetForWeight(int fontWeight)
		{
			bool flag = (this.m_style & FontStyles.Italic) == FontStyles.Italic || (this.m_fontStyle & FontStyles.Italic) == FontStyles.Italic;
			int num = fontWeight / 100;
			TMP_FontAsset tmp_FontAsset;
			if (flag)
			{
				tmp_FontAsset = this.m_currentFontAsset.fontWeights[num].italicTypeface;
			}
			else
			{
				tmp_FontAsset = this.m_currentFontAsset.fontWeights[num].regularTypeface;
			}
			return tmp_FontAsset;
		}

		// Token: 0x06002D1D RID: 11549 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void SetActiveSubMeshes(bool state)
		{
		}

		// Token: 0x06002D1E RID: 11550 RVA: 0x0010C464 File Offset: 0x0010A664
		protected Vector2 PackUV(float x, float y, float scale)
		{
			Vector2 vector;
			vector.x = Mathf.Floor(x * 511f);
			vector.y = Mathf.Floor(y * 511f);
			vector.x = vector.x * 4096f + vector.y;
			vector.y = scale;
			return vector;
		}

		// Token: 0x06002D1F RID: 11551 RVA: 0x0010C4BC File Offset: 0x0010A6BC
		protected float PackUV(float x, float y)
		{
			double num = Math.Floor((double)(x * 511f));
			double num2 = Math.Floor((double)(y * 511f));
			return (float)(num * 4096.0 + num2);
		}

		// Token: 0x06002D20 RID: 11552 RVA: 0x0010C4F4 File Offset: 0x0010A6F4
		protected int HexToInt(char hex)
		{
			switch (hex)
			{
			case '0':
				return 0;
			case '1':
				return 1;
			case '2':
				return 2;
			case '3':
				return 3;
			case '4':
				return 4;
			case '5':
				return 5;
			case '6':
				return 6;
			case '7':
				return 7;
			case '8':
				return 8;
			case '9':
				return 9;
			default:
				switch (hex)
				{
				case 'a':
					return 10;
				case 'b':
					return 11;
				case 'c':
					return 12;
				case 'd':
					return 13;
				case 'e':
					return 14;
				case 'f':
					return 15;
				default:
					return 15;
				}
				break;
			case 'A':
				return 10;
			case 'B':
				return 11;
			case 'C':
				return 12;
			case 'D':
				return 13;
			case 'E':
				return 14;
			case 'F':
				return 15;
			}
		}

		// Token: 0x06002D21 RID: 11553 RVA: 0x0010C5C8 File Offset: 0x0010A7C8
		protected int GetUTF16(int i)
		{
			int num = this.HexToInt(this.m_text[i]) * 4096;
			num += this.HexToInt(this.m_text[i + 1]) * 256;
			num += this.HexToInt(this.m_text[i + 2]) * 16;
			return num + this.HexToInt(this.m_text[i + 3]);
		}

		// Token: 0x06002D22 RID: 11554 RVA: 0x0010C640 File Offset: 0x0010A840
		protected int GetUTF32(int i)
		{
			int num = 0;
			num += this.HexToInt(this.m_text[i]) * 268435456;
			num += this.HexToInt(this.m_text[i + 1]) * 16777216;
			num += this.HexToInt(this.m_text[i + 2]) * 1048576;
			num += this.HexToInt(this.m_text[i + 3]) * 65536;
			num += this.HexToInt(this.m_text[i + 4]) * 4096;
			num += this.HexToInt(this.m_text[i + 5]) * 256;
			num += this.HexToInt(this.m_text[i + 6]) * 16;
			return num + this.HexToInt(this.m_text[i + 7]);
		}

		// Token: 0x06002D23 RID: 11555 RVA: 0x0010C730 File Offset: 0x0010A930
		protected Color32 HexCharsToColor(char[] hexChars, int tagCount)
		{
			if (tagCount == 7)
			{
				byte b = (byte)(this.HexToInt(hexChars[1]) * 16 + this.HexToInt(hexChars[2]));
				byte b2 = (byte)(this.HexToInt(hexChars[3]) * 16 + this.HexToInt(hexChars[4]));
				byte b3 = (byte)(this.HexToInt(hexChars[5]) * 16 + this.HexToInt(hexChars[6]));
				return new Color32(b, b2, b3, byte.MaxValue);
			}
			if (tagCount == 9)
			{
				byte b4 = (byte)(this.HexToInt(hexChars[1]) * 16 + this.HexToInt(hexChars[2]));
				byte b5 = (byte)(this.HexToInt(hexChars[3]) * 16 + this.HexToInt(hexChars[4]));
				byte b6 = (byte)(this.HexToInt(hexChars[5]) * 16 + this.HexToInt(hexChars[6]));
				byte b7 = (byte)(this.HexToInt(hexChars[7]) * 16 + this.HexToInt(hexChars[8]));
				return new Color32(b4, b5, b6, b7);
			}
			if (tagCount == 13)
			{
				byte b8 = (byte)(this.HexToInt(hexChars[7]) * 16 + this.HexToInt(hexChars[8]));
				byte b9 = (byte)(this.HexToInt(hexChars[9]) * 16 + this.HexToInt(hexChars[10]));
				byte b10 = (byte)(this.HexToInt(hexChars[11]) * 16 + this.HexToInt(hexChars[12]));
				return new Color32(b8, b9, b10, byte.MaxValue);
			}
			if (tagCount == 15)
			{
				byte b11 = (byte)(this.HexToInt(hexChars[7]) * 16 + this.HexToInt(hexChars[8]));
				byte b12 = (byte)(this.HexToInt(hexChars[9]) * 16 + this.HexToInt(hexChars[10]));
				byte b13 = (byte)(this.HexToInt(hexChars[11]) * 16 + this.HexToInt(hexChars[12]));
				byte b14 = (byte)(this.HexToInt(hexChars[13]) * 16 + this.HexToInt(hexChars[14]));
				return new Color32(b11, b12, b13, b14);
			}
			return new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}

		// Token: 0x06002D24 RID: 11556 RVA: 0x0010C914 File Offset: 0x0010AB14
		protected Color32 HexCharsToColor(char[] hexChars, int startIndex, int length)
		{
			if (length == 7)
			{
				byte b = (byte)(this.HexToInt(hexChars[startIndex + 1]) * 16 + this.HexToInt(hexChars[startIndex + 2]));
				byte b2 = (byte)(this.HexToInt(hexChars[startIndex + 3]) * 16 + this.HexToInt(hexChars[startIndex + 4]));
				byte b3 = (byte)(this.HexToInt(hexChars[startIndex + 5]) * 16 + this.HexToInt(hexChars[startIndex + 6]));
				return new Color32(b, b2, b3, byte.MaxValue);
			}
			if (length == 9)
			{
				byte b4 = (byte)(this.HexToInt(hexChars[startIndex + 1]) * 16 + this.HexToInt(hexChars[startIndex + 2]));
				byte b5 = (byte)(this.HexToInt(hexChars[startIndex + 3]) * 16 + this.HexToInt(hexChars[startIndex + 4]));
				byte b6 = (byte)(this.HexToInt(hexChars[startIndex + 5]) * 16 + this.HexToInt(hexChars[startIndex + 6]));
				byte b7 = (byte)(this.HexToInt(hexChars[startIndex + 7]) * 16 + this.HexToInt(hexChars[startIndex + 8]));
				return new Color32(b4, b5, b6, b7);
			}
			return new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}

		// Token: 0x06002D25 RID: 11557 RVA: 0x0010CA2C File Offset: 0x0010AC2C
		protected float ConvertToFloat(char[] chars, int startIndex, int length, int decimalPointIndex)
		{
			if (startIndex == 0)
			{
				return -9999f;
			}
			int num = startIndex + length - 1;
			float num2 = 0f;
			float num3 = 1f;
			decimalPointIndex = ((decimalPointIndex <= 0) ? (num + 1) : decimalPointIndex);
			if (chars[startIndex] == '-')
			{
				startIndex++;
				num3 = -1f;
			}
			if (chars[startIndex] == '+' || chars[startIndex] == '%')
			{
				startIndex++;
			}
			for (int i = startIndex; i < num + 1; i++)
			{
				if (!char.IsDigit(chars[i]) && chars[i] != '.')
				{
					return -9999f;
				}
				int num4 = decimalPointIndex - i;
				switch (num4 + 3)
				{
				case 0:
					num2 += (float)(chars[i] - '0') * 0.001f;
					break;
				case 1:
					num2 += (float)(chars[i] - '0') * 0.01f;
					break;
				case 2:
					num2 += (float)(chars[i] - '0') * 0.1f;
					break;
				case 4:
					num2 += (float)(chars[i] - '0');
					break;
				case 5:
					num2 += (float)((chars[i] - '0') * '\n');
					break;
				case 6:
					num2 += (float)((chars[i] - '0') * 'd');
					break;
				case 7:
					num2 += (float)((chars[i] - '0') * 'Ϩ');
					break;
				}
			}
			return num2 * num3;
		}

		// Token: 0x06002D26 RID: 11558 RVA: 0x0010CB88 File Offset: 0x0010AD88
		protected bool ValidateHtmlTag(int[] chars, int startIndex, out int endIndex)
		{
			int num = 0;
			byte b = 0;
			TagUnits tagUnits = TagUnits.Pixels;
			TagType tagType = TagType.None;
			int num2 = 0;
			this.m_xmlAttribute[num2].nameHashCode = 0;
			this.m_xmlAttribute[num2].valueType = TagType.None;
			this.m_xmlAttribute[num2].valueHashCode = 0;
			this.m_xmlAttribute[num2].valueStartIndex = 0;
			this.m_xmlAttribute[num2].valueLength = 0;
			this.m_xmlAttribute[num2].valueDecimalIndex = 0;
			endIndex = startIndex;
			bool flag = false;
			bool flag2 = false;
			int num3 = startIndex;
			while (num3 < chars.Length && chars[num3] != 0 && num < this.m_htmlTag.Length && chars[num3] != 60)
			{
				if (chars[num3] == 62)
				{
					flag2 = true;
					endIndex = num3;
					this.m_htmlTag[num] = '\0';
					break;
				}
				this.m_htmlTag[num] = (char)chars[num3];
				num++;
				if (b == 1)
				{
					if (tagType == TagType.None)
					{
						if (chars[num3] == 43 || chars[num3] == 45 || char.IsDigit((char)chars[num3]))
						{
							tagType = TagType.NumericalValue;
							this.m_xmlAttribute[num2].valueType = TagType.NumericalValue;
							this.m_xmlAttribute[num2].valueStartIndex = num - 1;
							XML_TagAttribute[] xmlAttribute = this.m_xmlAttribute;
							int num4 = num2;
							xmlAttribute[num4].valueLength = xmlAttribute[num4].valueLength + 1;
						}
						else if (chars[num3] == 35)
						{
							tagType = TagType.ColorValue;
							this.m_xmlAttribute[num2].valueType = TagType.ColorValue;
							this.m_xmlAttribute[num2].valueStartIndex = num - 1;
							XML_TagAttribute[] xmlAttribute2 = this.m_xmlAttribute;
							int num5 = num2;
							xmlAttribute2[num5].valueLength = xmlAttribute2[num5].valueLength + 1;
						}
						else if (chars[num3] == 34)
						{
							tagType = TagType.StringValue;
							this.m_xmlAttribute[num2].valueType = TagType.StringValue;
							this.m_xmlAttribute[num2].valueStartIndex = num;
						}
						else
						{
							tagType = TagType.StringValue;
							this.m_xmlAttribute[num2].valueType = TagType.StringValue;
							this.m_xmlAttribute[num2].valueStartIndex = num - 1;
							this.m_xmlAttribute[num2].valueHashCode = ((this.m_xmlAttribute[num2].valueHashCode << 5) + this.m_xmlAttribute[num2].valueHashCode) ^ chars[num3];
							XML_TagAttribute[] xmlAttribute3 = this.m_xmlAttribute;
							int num6 = num2;
							xmlAttribute3[num6].valueLength = xmlAttribute3[num6].valueLength + 1;
						}
					}
					else if (tagType == TagType.NumericalValue)
					{
						if (chars[num3] == 46)
						{
							this.m_xmlAttribute[num2].valueDecimalIndex = num - 1;
						}
						if (chars[num3] == 112 || chars[num3] == 101 || chars[num3] == 37 || chars[num3] == 32)
						{
							b = 2;
							tagType = TagType.None;
							num2++;
							this.m_xmlAttribute[num2].nameHashCode = 0;
							this.m_xmlAttribute[num2].valueType = TagType.None;
							this.m_xmlAttribute[num2].valueHashCode = 0;
							this.m_xmlAttribute[num2].valueStartIndex = 0;
							this.m_xmlAttribute[num2].valueLength = 0;
							this.m_xmlAttribute[num2].valueDecimalIndex = 0;
							if (chars[num3] == 101)
							{
								tagUnits = TagUnits.FontUnits;
							}
							else if (chars[num3] == 37)
							{
								tagUnits = TagUnits.Percentage;
							}
						}
						else if (b != 2)
						{
							XML_TagAttribute[] xmlAttribute4 = this.m_xmlAttribute;
							int num7 = num2;
							xmlAttribute4[num7].valueLength = xmlAttribute4[num7].valueLength + 1;
						}
					}
					else if (tagType == TagType.ColorValue)
					{
						if (chars[num3] != 32)
						{
							XML_TagAttribute[] xmlAttribute5 = this.m_xmlAttribute;
							int num8 = num2;
							xmlAttribute5[num8].valueLength = xmlAttribute5[num8].valueLength + 1;
						}
						else
						{
							b = 2;
							tagType = TagType.None;
							num2++;
							this.m_xmlAttribute[num2].nameHashCode = 0;
							this.m_xmlAttribute[num2].valueType = TagType.None;
							this.m_xmlAttribute[num2].valueHashCode = 0;
							this.m_xmlAttribute[num2].valueStartIndex = 0;
							this.m_xmlAttribute[num2].valueLength = 0;
							this.m_xmlAttribute[num2].valueDecimalIndex = 0;
						}
					}
					else if (tagType == TagType.StringValue)
					{
						if (chars[num3] != 34)
						{
							this.m_xmlAttribute[num2].valueHashCode = ((this.m_xmlAttribute[num2].valueHashCode << 5) + this.m_xmlAttribute[num2].valueHashCode) ^ chars[num3];
							XML_TagAttribute[] xmlAttribute6 = this.m_xmlAttribute;
							int num9 = num2;
							xmlAttribute6[num9].valueLength = xmlAttribute6[num9].valueLength + 1;
						}
						else
						{
							b = 2;
							tagType = TagType.None;
							num2++;
							this.m_xmlAttribute[num2].nameHashCode = 0;
							this.m_xmlAttribute[num2].valueType = TagType.None;
							this.m_xmlAttribute[num2].valueHashCode = 0;
							this.m_xmlAttribute[num2].valueStartIndex = 0;
							this.m_xmlAttribute[num2].valueLength = 0;
							this.m_xmlAttribute[num2].valueDecimalIndex = 0;
						}
					}
				}
				if (chars[num3] == 61)
				{
					b = 1;
				}
				if (b == 0 && chars[num3] == 32)
				{
					if (flag)
					{
						return false;
					}
					flag = true;
					b = 2;
					tagType = TagType.None;
					num2++;
					this.m_xmlAttribute[num2].nameHashCode = 0;
					this.m_xmlAttribute[num2].valueType = TagType.None;
					this.m_xmlAttribute[num2].valueHashCode = 0;
					this.m_xmlAttribute[num2].valueStartIndex = 0;
					this.m_xmlAttribute[num2].valueLength = 0;
					this.m_xmlAttribute[num2].valueDecimalIndex = 0;
				}
				if (b == 0)
				{
					this.m_xmlAttribute[num2].nameHashCode = (this.m_xmlAttribute[num2].nameHashCode << 3) - this.m_xmlAttribute[num2].nameHashCode + chars[num3];
				}
				if (b == 2 && chars[num3] == 32)
				{
					b = 0;
				}
				num3++;
			}
			if (!flag2)
			{
				return false;
			}
			if (this.tag_NoParsing && this.m_xmlAttribute[0].nameHashCode != 53822163 && this.m_xmlAttribute[0].nameHashCode != 49429939)
			{
				return false;
			}
			if (this.m_xmlAttribute[0].nameHashCode == 53822163 || this.m_xmlAttribute[0].nameHashCode == 49429939)
			{
				this.tag_NoParsing = false;
				return true;
			}
			if (this.m_htmlTag[0] == '#' && num == 7)
			{
				this.m_htmlColor = this.HexCharsToColor(this.m_htmlTag, num);
				this.m_colorStack.Add(this.m_htmlColor);
				return true;
			}
			if (this.m_htmlTag[0] == '#' && num == 9)
			{
				this.m_htmlColor = this.HexCharsToColor(this.m_htmlTag, num);
				this.m_colorStack.Add(this.m_htmlColor);
				return true;
			}
			int nameHashCode = this.m_xmlAttribute[0].nameHashCode;
			switch (nameHashCode)
			{
			case 83:
				break;
			default:
				switch (nameHashCode)
				{
				case 115:
					break;
				default:
					switch (nameHashCode)
					{
					case 412:
						break;
					default:
						if (nameHashCode != 426)
						{
							if (nameHashCode != 427)
							{
								switch (nameHashCode)
								{
								case 444:
									goto IL_0E11;
								default:
									if (nameHashCode != -1885698441)
									{
										if (nameHashCode != -1883544150)
										{
											if (nameHashCode != -1847322671)
											{
												if (nameHashCode != -1831660941)
												{
													float num11;
													if (nameHashCode != -1690034531)
													{
														if (nameHashCode == -1668324918)
														{
															goto IL_2D27;
														}
														if (nameHashCode == -1632103439)
														{
															goto IL_2D6B;
														}
														if (nameHashCode == -1616441709)
														{
															goto IL_2D49;
														}
														if (nameHashCode != -884817987)
														{
															if (nameHashCode != -855002522)
															{
																if (nameHashCode != -842693512)
																{
																	if (nameHashCode != -842656867)
																	{
																		if (nameHashCode != -445573839)
																		{
																			if (nameHashCode != -445537194)
																			{
																				if (nameHashCode != -330774850)
																				{
																					if (nameHashCode != 66)
																					{
																						if (nameHashCode != 73)
																						{
																							if (nameHashCode == 98)
																							{
																								goto IL_0D84;
																							}
																							if (nameHashCode != 105)
																							{
																								if (nameHashCode == 395)
																								{
																									break;
																								}
																								if (nameHashCode == 402 || nameHashCode == 434)
																								{
																									this.m_style &= (FontStyles)(-3);
																									return true;
																								}
																								if (nameHashCode != 4556)
																								{
																									if (nameHashCode != 4728)
																									{
																										if (nameHashCode != 4742)
																										{
																											if (nameHashCode == 6380)
																											{
																												goto IL_1284;
																											}
																											if (nameHashCode == 6552)
																											{
																												goto IL_0E61;
																											}
																											if (nameHashCode != 6566)
																											{
																												if (nameHashCode != 20677)
																												{
																													if (nameHashCode != 20849)
																													{
																														if (nameHashCode != 20863)
																														{
																															if (nameHashCode == 22501)
																															{
																																goto IL_133E;
																															}
																															if (nameHashCode == 22673)
																															{
																																goto IL_0ED3;
																															}
																															if (nameHashCode != 22687)
																															{
																																int num10;
																																if (nameHashCode != 28511)
																																{
																																	if (nameHashCode != 30266)
																																	{
																																		if (nameHashCode != 31169)
																																		{
																																			if (nameHashCode != 31191)
																																			{
																																				if (nameHashCode != 32745)
																																				{
																																					if (nameHashCode == 41311)
																																					{
																																						goto IL_1751;
																																					}
																																					if (nameHashCode == 43066)
																																					{
																																						goto IL_1E47;
																																					}
																																					if (nameHashCode == 43969)
																																					{
																																						goto IL_1439;
																																					}
																																					if (nameHashCode == 43991)
																																					{
																																						goto IL_13F8;
																																					}
																																					if (nameHashCode != 45545)
																																					{
																																						if (nameHashCode != 141358)
																																						{
																																							if (nameHashCode != 143113)
																																							{
																																								if (nameHashCode != 144016)
																																								{
																																									if (nameHashCode != 145592)
																																									{
																																										if (nameHashCode == 154158)
																																										{
																																											goto IL_1A70;
																																										}
																																										if (nameHashCode == 155913)
																																										{
																																											goto IL_1F79;
																																										}
																																										if (nameHashCode == 156816)
																																										{
																																											goto IL_1442;
																																										}
																																										if (nameHashCode != 158392)
																																										{
																																											if (nameHashCode != 186285)
																																											{
																																												if (nameHashCode != 186622)
																																												{
																																													if (nameHashCode != 192323)
																																													{
																																														if (nameHashCode != 230446)
																																														{
																																															TMP_Style tmp_Style;
																																															if (nameHashCode != 233057)
																																															{
																																																if (nameHashCode != 237918)
																																																{
																																																	if (nameHashCode == 275917)
																																																	{
																																																		goto IL_1FE0;
																																																	}
																																																	if (nameHashCode == 276254)
																																																	{
																																																		goto IL_1DFC;
																																																	}
																																																	if (nameHashCode == 280416)
																																																	{
																																																		return false;
																																																	}
																																																	if (nameHashCode == 281955)
																																																	{
																																																		goto IL_2215;
																																																	}
																																																	if (nameHashCode == 320078)
																																																	{
																																																		goto IL_1D3D;
																																																	}
																																																	if (nameHashCode == 322689)
																																																	{
																																																		goto IL_2108;
																																																	}
																																																	if (nameHashCode != 327550)
																																																	{
																																																		if (nameHashCode != 976214)
																																																		{
																																																			if (nameHashCode != 982252)
																																																			{
																																																				if (nameHashCode != 1022986)
																																																				{
																																																					if (nameHashCode != 1027847)
																																																					{
																																																						if (nameHashCode == 1065846)
																																																						{
																																																							goto IL_204E;
																																																						}
																																																						if (nameHashCode == 1071884)
																																																						{
																																																							goto IL_25DA;
																																																						}
																																																						if (nameHashCode == 1112618)
																																																						{
																																																							goto IL_2186;
																																																						}
																																																						if (nameHashCode != 1117479)
																																																						{
																																																							if (nameHashCode != 1286342)
																																																							{
																																																								if (nameHashCode != 1356515)
																																																								{
																																																									if (nameHashCode != 1441524)
																																																									{
																																																										if (nameHashCode != 1482398)
																																																										{
																																																											if (nameHashCode != 1524585)
																																																											{
																																																												if (nameHashCode != 1619421)
																																																												{
																																																													if (nameHashCode == 1750458)
																																																													{
																																																														return false;
																																																													}
																																																													if (nameHashCode == 1913798)
																																																													{
																																																														goto IL_31EB;
																																																													}
																																																													if (nameHashCode == 1983971)
																																																													{
																																																														goto IL_2438;
																																																													}
																																																													if (nameHashCode == 2068980)
																																																													{
																																																														goto IL_25ED;
																																																													}
																																																													if (nameHashCode == 2109854)
																																																													{
																																																														goto IL_2D7C;
																																																													}
																																																													if (nameHashCode == 2152041)
																																																													{
																																																														goto IL_2508;
																																																													}
																																																													if (nameHashCode != 2246877)
																																																													{
																																																														if (nameHashCode != 6815845)
																																																														{
																																																															if (nameHashCode != 6886018)
																																																															{
																																																																if (nameHashCode != 6971027)
																																																																{
																																																																	if (nameHashCode != 7011901)
																																																																	{
																																																																		if (nameHashCode != 7054088)
																																																																		{
																																																																			if (nameHashCode == 7443301)
																																																																			{
																																																																				goto IL_3250;
																																																																			}
																																																																			if (nameHashCode == 7513474)
																																																																			{
																																																																				goto IL_24FB;
																																																																			}
																																																																			if (nameHashCode == 7598483)
																																																																			{
																																																																				goto IL_26E5;
																																																																			}
																																																																			if (nameHashCode == 7639357)
																																																																			{
																																																																				goto IL_2EA6;
																																																																			}
																																																																			if (nameHashCode != 7681544)
																																																																			{
																																																																				if (nameHashCode != 9133802)
																																																																				{
																																																																					if (nameHashCode != 10723418)
																																																																					{
																																																																						if (nameHashCode != 11642281)
																																																																						{
																																																																							if (nameHashCode == 13526026)
																																																																							{
																																																																								goto IL_2D38;
																																																																							}
																																																																							if (nameHashCode == 15115642)
																																																																							{
																																																																								goto IL_31E2;
																																																																							}
																																																																							if (nameHashCode != 16034505)
																																																																							{
																																																																								if (nameHashCode != 47840323)
																																																																								{
																																																																									if (nameHashCode != 50348802)
																																																																									{
																																																																										if (nameHashCode == 52232547)
																																																																										{
																																																																											goto IL_2D49;
																																																																										}
																																																																										if (nameHashCode != 54741026)
																																																																										{
																																																																											if (nameHashCode != 72669687 && nameHashCode != 103415287)
																																																																											{
																																																																												if (nameHashCode != 343615334 && nameHashCode != 374360934)
																																																																												{
																																																																													if (nameHashCode != 457225591)
																																																																													{
																																																																														if (nameHashCode != 514803617)
																																																																														{
																																																																															if (nameHashCode != 551025096)
																																																																															{
																																																																																if (nameHashCode == 566686826)
																																																																																{
																																																																																	goto IL_2D38;
																																																																																}
																																																																																if (nameHashCode == 730022849)
																																																																																{
																																																																																	goto IL_2D17;
																																																																																}
																																																																																if (nameHashCode != 766244328)
																																																																																{
																																																																																	if (nameHashCode == 781906058)
																																																																																	{
																																																																																		goto IL_2D38;
																																																																																	}
																																																																																	if (nameHashCode == 1100728678)
																																																																																	{
																																																																																		goto IL_2EBE;
																																																																																	}
																																																																																	if (nameHashCode == 1109349752)
																																																																																	{
																																																																																		goto IL_30FA;
																																																																																	}
																																																																																	if (nameHashCode == 1109386397)
																																																																																	{
																																																																																		goto IL_26F8;
																																																																																	}
																																																																																	if (nameHashCode == 1897350193)
																																																																																	{
																																																																																		goto IL_31D5;
																																																																																	}
																																																																																	if (nameHashCode == 1897386838)
																																																																																	{
																																																																																		goto IL_27E6;
																																																																																	}
																																																																																	if (nameHashCode != 2012149182)
																																																																																	{
																																																																																		return false;
																																																																																	}
																																																																																	goto IL_10B7;
																																																																																}
																																																																															}
																																																																															this.m_style |= FontStyles.SmallCaps;
																																																																															return true;
																																																																														}
																																																																														IL_2D17:
																																																																														this.m_style |= FontStyles.LowerCase;
																																																																														return true;
																																																																													}
																																																																													goto IL_1252;
																																																																												}
																																																																												else
																																																																												{
																																																																													if (this.m_currentMaterial.GetTexture(ShaderUtilities.ID_MainTex).GetInstanceID() != this.m_materialReferenceStack.PreviousItem().material.GetTexture(ShaderUtilities.ID_MainTex).GetInstanceID())
																																																																													{
																																																																														return false;
																																																																													}
																																																																													MaterialReference materialReference = this.m_materialReferenceStack.Remove();
																																																																													this.m_currentMaterial = materialReference.material;
																																																																													this.m_currentMaterialIndex = materialReference.index;
																																																																													return true;
																																																																												}
																																																																											}
																																																																											else
																																																																											{
																																																																												num10 = this.m_xmlAttribute[0].valueHashCode;
																																																																												if (num10 != 764638571 && num10 != 523367755)
																																																																												{
																																																																													Material material;
																																																																													if (MaterialReferenceManager.TryGetMaterial(num10, out material))
																																																																													{
																																																																														if (this.m_currentFontAsset.atlas.GetInstanceID() != material.GetTexture(ShaderUtilities.ID_MainTex).GetInstanceID())
																																																																														{
																																																																															return false;
																																																																														}
																																																																														this.m_currentMaterial = material;
																																																																														this.m_currentMaterialIndex = MaterialReference.AddMaterialReference(this.m_currentMaterial, this.m_currentFontAsset, this.m_materialReferences, this.m_materialReferenceIndexLookup);
																																																																														this.m_materialReferenceStack.Add(this.m_materialReferences[this.m_currentMaterialIndex]);
																																																																													}
																																																																													else
																																																																													{
																																																																														material = Resources.Load<Material>(TMP_Settings.defaultFontAssetPath + new string(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength));
																																																																														if (material == null)
																																																																														{
																																																																															return false;
																																																																														}
																																																																														if (this.m_currentFontAsset.atlas.GetInstanceID() != material.GetTexture(ShaderUtilities.ID_MainTex).GetInstanceID())
																																																																														{
																																																																															return false;
																																																																														}
																																																																														MaterialReferenceManager.AddFontMaterial(num10, material);
																																																																														this.m_currentMaterial = material;
																																																																														this.m_currentMaterialIndex = MaterialReference.AddMaterialReference(this.m_currentMaterial, this.m_currentFontAsset, this.m_materialReferences, this.m_materialReferenceIndexLookup);
																																																																														this.m_materialReferenceStack.Add(this.m_materialReferences[this.m_currentMaterialIndex]);
																																																																													}
																																																																													return true;
																																																																												}
																																																																												if (this.m_currentFontAsset.atlas.GetInstanceID() != this.m_currentMaterial.GetTexture(ShaderUtilities.ID_MainTex).GetInstanceID())
																																																																												{
																																																																													return false;
																																																																												}
																																																																												this.m_currentMaterial = this.m_materialReferences[0].material;
																																																																												this.m_currentMaterialIndex = 0;
																																																																												this.m_materialReferenceStack.Add(this.m_materialReferences[0]);
																																																																												return true;
																																																																											}
																																																																										}
																																																																									}
																																																																									this.m_baselineOffset = 0f;
																																																																									return true;
																																																																								}
																																																																								goto IL_2D49;
																																																																							}
																																																																						}
																																																																						num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																																						if (num11 == -9999f || num11 == 0f)
																																																																						{
																																																																							return false;
																																																																						}
																																																																						if (tagUnits == TagUnits.Pixels)
																																																																						{
																																																																							this.m_baselineOffset = num11;
																																																																							return true;
																																																																						}
																																																																						if (tagUnits != TagUnits.FontUnits)
																																																																						{
																																																																							return tagUnits != TagUnits.Percentage && false;
																																																																						}
																																																																						this.m_baselineOffset = num11 * this.m_fontScale * this.m_fontAsset.fontInfo.Ascender;
																																																																						return true;
																																																																					}
																																																																					IL_31E2:
																																																																					this.tag_NoParsing = true;
																																																																					return true;
																																																																				}
																																																																				IL_2D38:
																																																																				this.m_style |= FontStyles.UpperCase;
																																																																				return true;
																																																																			}
																																																																		}
																																																																		this.m_monoSpacing = 0f;
																																																																		return true;
																																																																	}
																																																																	IL_2EA6:
																																																																	this.m_marginLeft = 0f;
																																																																	this.m_marginRight = 0f;
																																																																	return true;
																																																																}
																																																																IL_26E5:
																																																																this.tag_Indent = this.m_indentStack.Remove();
																																																																return true;
																																																															}
																																																															IL_24FB:
																																																															this.m_cSpacing = 0f;
																																																															return true;
																																																														}
																																																														IL_3250:
																																																														if (this.m_isParsingText)
																																																														{
																																																															Debug.Log(string.Concat(new object[]
																																																															{
																																																																"Action ID: [",
																																																																this.m_actionStack.CurrentItem(),
																																																																"] Last character index: ",
																																																																this.m_characterCount - 1
																																																															}));
																																																														}
																																																														this.m_actionStack.Remove();
																																																														return true;
																																																													}
																																																												}
																																																												int valueHashCode = this.m_xmlAttribute[0].valueHashCode;
																																																												TMP_SpriteAsset tmp_SpriteAsset;
																																																												if (this.m_xmlAttribute[0].valueType == TagType.None || this.m_xmlAttribute[0].valueType == TagType.NumericalValue)
																																																												{
																																																													if (this.m_defaultSpriteAsset == null)
																																																													{
																																																														if (TMP_Settings.defaultSpriteAsset != null)
																																																														{
																																																															this.m_defaultSpriteAsset = TMP_Settings.defaultSpriteAsset;
																																																														}
																																																														else
																																																														{
																																																															this.m_defaultSpriteAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/Default Sprite Asset");
																																																														}
																																																													}
																																																													this.m_currentSpriteAsset = this.m_defaultSpriteAsset;
																																																													if (this.m_currentSpriteAsset == null)
																																																													{
																																																														return false;
																																																													}
																																																												}
																																																												else if (MaterialReferenceManager.TryGetSpriteAsset(valueHashCode, out tmp_SpriteAsset))
																																																												{
																																																													this.m_currentSpriteAsset = tmp_SpriteAsset;
																																																												}
																																																												else
																																																												{
																																																													if (tmp_SpriteAsset == null)
																																																													{
																																																														tmp_SpriteAsset = Resources.Load<TMP_SpriteAsset>(TMP_Settings.defaultSpriteAssetPath + new string(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength));
																																																													}
																																																													if (tmp_SpriteAsset == null)
																																																													{
																																																														return false;
																																																													}
																																																													MaterialReferenceManager.AddSpriteAsset(valueHashCode, tmp_SpriteAsset);
																																																													this.m_currentSpriteAsset = tmp_SpriteAsset;
																																																												}
																																																												if (this.m_xmlAttribute[0].valueType == TagType.NumericalValue)
																																																												{
																																																													int num12 = (int)this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																													if (num12 == -9999)
																																																													{
																																																														return false;
																																																													}
																																																													if (num12 > this.m_currentSpriteAsset.spriteInfoList.Count - 1)
																																																													{
																																																														return false;
																																																													}
																																																													this.m_spriteIndex = num12;
																																																												}
																																																												else if (this.m_xmlAttribute[1].nameHashCode == 43347 || this.m_xmlAttribute[1].nameHashCode == 30547)
																																																												{
																																																													int spriteIndex = this.m_currentSpriteAsset.GetSpriteIndex(this.m_xmlAttribute[1].valueHashCode);
																																																													if (spriteIndex == -1)
																																																													{
																																																														return false;
																																																													}
																																																													this.m_spriteIndex = spriteIndex;
																																																												}
																																																												else
																																																												{
																																																													if (this.m_xmlAttribute[1].nameHashCode != 295562 && this.m_xmlAttribute[1].nameHashCode != 205930)
																																																													{
																																																														return false;
																																																													}
																																																													int num13 = (int)this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[1].valueStartIndex, this.m_xmlAttribute[1].valueLength, this.m_xmlAttribute[1].valueDecimalIndex);
																																																													if (num13 == -9999)
																																																													{
																																																														return false;
																																																													}
																																																													if (num13 > this.m_currentSpriteAsset.spriteInfoList.Count - 1)
																																																													{
																																																														return false;
																																																													}
																																																													this.m_spriteIndex = num13;
																																																												}
																																																												this.m_currentMaterialIndex = MaterialReference.AddMaterialReference(this.m_currentSpriteAsset.material, this.m_currentSpriteAsset, this.m_materialReferences, this.m_materialReferenceIndexLookup);
																																																												this.m_spriteColor = TMP_Text.s_colorWhite;
																																																												this.m_tintSprite = false;
																																																												if (this.m_xmlAttribute[1].nameHashCode == 45819 || this.m_xmlAttribute[1].nameHashCode == 33019)
																																																												{
																																																													this.m_tintSprite = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[1].valueStartIndex, this.m_xmlAttribute[1].valueLength, this.m_xmlAttribute[1].valueDecimalIndex) != 0f;
																																																												}
																																																												else if (this.m_xmlAttribute[2].nameHashCode == 45819 || this.m_xmlAttribute[2].nameHashCode == 33019)
																																																												{
																																																													this.m_tintSprite = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[2].valueStartIndex, this.m_xmlAttribute[2].valueLength, this.m_xmlAttribute[2].valueDecimalIndex) != 0f;
																																																												}
																																																												if (this.m_xmlAttribute[1].nameHashCode == 281955 || this.m_xmlAttribute[1].nameHashCode == 192323)
																																																												{
																																																													this.m_spriteColor = this.HexCharsToColor(this.m_htmlTag, this.m_xmlAttribute[1].valueStartIndex, this.m_xmlAttribute[1].valueLength);
																																																												}
																																																												else if (this.m_xmlAttribute[2].nameHashCode == 281955 || this.m_xmlAttribute[2].nameHashCode == 192323)
																																																												{
																																																													this.m_spriteColor = this.HexCharsToColor(this.m_htmlTag, this.m_xmlAttribute[2].valueStartIndex, this.m_xmlAttribute[2].valueLength);
																																																												}
																																																												this.m_xmlAttribute[1].nameHashCode = 0;
																																																												this.m_xmlAttribute[2].nameHashCode = 0;
																																																												this.m_textElementType = TMP_TextElementType.Sprite;
																																																												return true;
																																																											}
																																																											IL_2508:
																																																											num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																											if (num11 == -9999f || num11 == 0f)
																																																											{
																																																												return false;
																																																											}
																																																											if (tagUnits != TagUnits.Pixels)
																																																											{
																																																												if (tagUnits != TagUnits.FontUnits)
																																																												{
																																																													if (tagUnits == TagUnits.Percentage)
																																																													{
																																																														return false;
																																																													}
																																																												}
																																																												else
																																																												{
																																																													this.m_monoSpacing = num11;
																																																													this.m_monoSpacing *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																																																												}
																																																											}
																																																											else
																																																											{
																																																												this.m_monoSpacing = num11;
																																																											}
																																																											return true;
																																																										}
																																																										IL_2D7C:
																																																										num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																										if (num11 == -9999f || num11 == 0f)
																																																										{
																																																											return false;
																																																										}
																																																										this.m_marginLeft = num11;
																																																										if (tagUnits != TagUnits.Pixels)
																																																										{
																																																											if (tagUnits != TagUnits.FontUnits)
																																																											{
																																																												if (tagUnits == TagUnits.Percentage)
																																																												{
																																																													this.m_marginLeft = (this.m_marginWidth - ((this.m_width == -1f) ? 0f : this.m_width)) * this.m_marginLeft / 100f;
																																																												}
																																																											}
																																																											else
																																																											{
																																																												this.m_marginLeft *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																																																											}
																																																										}
																																																										this.m_marginLeft = ((this.m_marginLeft < 0f) ? 0f : this.m_marginLeft);
																																																										this.m_marginRight = this.m_marginLeft;
																																																										return true;
																																																									}
																																																									IL_25ED:
																																																									num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																									if (num11 == -9999f || num11 == 0f)
																																																									{
																																																										return false;
																																																									}
																																																									if (tagUnits != TagUnits.Pixels)
																																																									{
																																																										if (tagUnits != TagUnits.FontUnits)
																																																										{
																																																											if (tagUnits == TagUnits.Percentage)
																																																											{
																																																												this.tag_Indent = this.m_marginWidth * num11 / 100f;
																																																											}
																																																										}
																																																										else
																																																										{
																																																											this.tag_Indent = num11;
																																																											this.tag_Indent *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																																																										}
																																																									}
																																																									else
																																																									{
																																																										this.tag_Indent = num11;
																																																									}
																																																									this.m_indentStack.Add(this.tag_Indent);
																																																									this.m_xAdvance = this.tag_Indent;
																																																									return true;
																																																								}
																																																								IL_2438:
																																																								num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																								if (num11 == -9999f || num11 == 0f)
																																																								{
																																																									return false;
																																																								}
																																																								if (tagUnits != TagUnits.Pixels)
																																																								{
																																																									if (tagUnits != TagUnits.FontUnits)
																																																									{
																																																										if (tagUnits == TagUnits.Percentage)
																																																										{
																																																											return false;
																																																										}
																																																									}
																																																									else
																																																									{
																																																										this.m_cSpacing = num11;
																																																										this.m_cSpacing *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																																																									}
																																																								}
																																																								else
																																																								{
																																																									this.m_cSpacing = num11;
																																																								}
																																																								return true;
																																																							}
																																																							IL_31EB:
																																																							int valueHashCode2 = this.m_xmlAttribute[0].valueHashCode;
																																																							if (this.m_isParsingText)
																																																							{
																																																								this.m_actionStack.Add(valueHashCode2);
																																																								Debug.Log(string.Concat(new object[] { "Action ID: [", valueHashCode2, "] First character index: ", this.m_characterCount }));
																																																							}
																																																							return true;
																																																						}
																																																					}
																																																					this.m_width = -1f;
																																																					return true;
																																																				}
																																																				IL_2186:
																																																				tmp_Style = TMP_StyleSheet.GetStyle(this.m_xmlAttribute[0].valueHashCode);
																																																				if (tmp_Style == null)
																																																				{
																																																					int num14 = this.m_styleStack.CurrentItem();
																																																					tmp_Style = TMP_StyleSheet.GetStyle(num14);
																																																					this.m_styleStack.Remove();
																																																				}
																																																				if (tmp_Style == null)
																																																				{
																																																					return false;
																																																				}
																																																				for (int i = 0; i < tmp_Style.styleClosingTagArray.Length; i++)
																																																				{
																																																					if (tmp_Style.styleClosingTagArray[i] == 60)
																																																					{
																																																						this.ValidateHtmlTag(tmp_Style.styleClosingTagArray, i + 1, out i);
																																																					}
																																																				}
																																																				return true;
																																																			}
																																																			IL_25DA:
																																																			this.m_htmlColor = this.m_colorStack.Remove();
																																																			return true;
																																																		}
																																																		IL_204E:
																																																		this.m_lineJustification = this.m_textAlignment;
																																																		return true;
																																																	}
																																																}
																																																num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																																if (num11 == -9999f || num11 == 0f)
																																																{
																																																	return false;
																																																}
																																																if (tagUnits != TagUnits.Pixels)
																																																{
																																																	if (tagUnits == TagUnits.FontUnits)
																																																	{
																																																		return false;
																																																	}
																																																	if (tagUnits == TagUnits.Percentage)
																																																	{
																																																		this.m_width = this.m_marginWidth * num11 / 100f;
																																																	}
																																																}
																																																else
																																																{
																																																	this.m_width = num11;
																																																}
																																																return true;
																																															}
																																															IL_2108:
																																															tmp_Style = TMP_StyleSheet.GetStyle(this.m_xmlAttribute[0].valueHashCode);
																																															if (tmp_Style == null)
																																															{
																																																return false;
																																															}
																																															this.m_styleStack.Add(tmp_Style.hashCode);
																																															for (int j = 0; j < tmp_Style.styleOpeningTagArray.Length; j++)
																																															{
																																																if (tmp_Style.styleOpeningTagArray[j] == 60 && !this.ValidateHtmlTag(tmp_Style.styleOpeningTagArray, j + 1, out j))
																																																{
																																																	return false;
																																																}
																																															}
																																															return true;
																																														}
																																														IL_1D3D:
																																														num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																														if (num11 == -9999f || num11 == 0f)
																																														{
																																															return false;
																																														}
																																														if (tagUnits == TagUnits.Pixels)
																																														{
																																															this.m_xAdvance += num11;
																																															return true;
																																														}
																																														if (tagUnits != TagUnits.FontUnits)
																																														{
																																															return tagUnits != TagUnits.Percentage && false;
																																														}
																																														this.m_xAdvance += num11 * this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																																														return true;
																																													}
																																													IL_2215:
																																													if (this.m_htmlTag[6] == '#' && num == 13)
																																													{
																																														this.m_htmlColor = this.HexCharsToColor(this.m_htmlTag, num);
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (this.m_htmlTag[6] == '#' && num == 15)
																																													{
																																														this.m_htmlColor = this.HexCharsToColor(this.m_htmlTag, num);
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													int valueHashCode3 = this.m_xmlAttribute[0].valueHashCode;
																																													if (valueHashCode3 == -36881330)
																																													{
																																														this.m_htmlColor = new Color32(160, 32, 240, byte.MaxValue);
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 == 125395)
																																													{
																																														this.m_htmlColor = Color.red;
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 == 3573310)
																																													{
																																														this.m_htmlColor = Color.blue;
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 == 26556144)
																																													{
																																														this.m_htmlColor = new Color32(byte.MaxValue, 128, 0, byte.MaxValue);
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 == 117905991)
																																													{
																																														this.m_htmlColor = Color.black;
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 == 121463835)
																																													{
																																														this.m_htmlColor = Color.green;
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 == 140357351)
																																													{
																																														this.m_htmlColor = Color.white;
																																														this.m_colorStack.Add(this.m_htmlColor);
																																														return true;
																																													}
																																													if (valueHashCode3 != 554054276)
																																													{
																																														return false;
																																													}
																																													this.m_htmlColor = Color.yellow;
																																													this.m_colorStack.Add(this.m_htmlColor);
																																													return true;
																																												}
																																												IL_1DFC:
																																												if (this.m_xmlAttribute[0].valueLength != 3)
																																												{
																																													return false;
																																												}
																																												this.m_htmlColor.a = (byte)(this.HexToInt(this.m_htmlTag[7]) * 16 + this.HexToInt(this.m_htmlTag[8]));
																																												return true;
																																											}
																																											IL_1FE0:
																																											int valueHashCode4 = this.m_xmlAttribute[0].valueHashCode;
																																											if (valueHashCode4 == -523808257)
																																											{
																																												this.m_lineJustification = TextAlignmentOptions.Justified;
																																												return true;
																																											}
																																											if (valueHashCode4 == -458210101)
																																											{
																																												this.m_lineJustification = TextAlignmentOptions.Center;
																																												return true;
																																											}
																																											if (valueHashCode4 == 3774683)
																																											{
																																												this.m_lineJustification = TextAlignmentOptions.Left;
																																												return true;
																																											}
																																											if (valueHashCode4 != 136703040)
																																											{
																																												return false;
																																											}
																																											this.m_lineJustification = TextAlignmentOptions.Right;
																																											return true;
																																										}
																																									}
																																									this.m_currentFontSize = this.m_sizeStack.Remove();
																																									this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																									return true;
																																								}
																																								IL_1442:
																																								this.m_isNonBreakingSpace = false;
																																								return true;
																																							}
																																							IL_1F79:
																																							if (this.m_isParsingText)
																																							{
																																								this.m_textInfo.linkInfo[this.m_textInfo.linkCount].linkTextLength = this.m_characterCount - this.m_textInfo.linkInfo[this.m_textInfo.linkCount].linkTextfirstCharacterIndex;
																																								this.m_textInfo.linkCount++;
																																							}
																																							return true;
																																						}
																																						IL_1A70:
																																						MaterialReference materialReference2 = this.m_materialReferenceStack.Remove();
																																						this.m_currentFontAsset = materialReference2.fontAsset;
																																						this.m_currentMaterial = materialReference2.material;
																																						this.m_currentMaterialIndex = materialReference2.index;
																																						this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																						return true;
																																					}
																																				}
																																				num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																																				if (num11 == -9999f || num11 == 0f)
																																				{
																																					return false;
																																				}
																																				if (tagUnits != TagUnits.Pixels)
																																				{
																																					if (tagUnits == TagUnits.FontUnits)
																																					{
																																						this.m_currentFontSize = this.m_fontSize * num11;
																																						this.m_sizeStack.Add(this.m_currentFontSize);
																																						this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																						return true;
																																					}
																																					if (tagUnits != TagUnits.Percentage)
																																					{
																																						return false;
																																					}
																																					this.m_currentFontSize = this.m_fontSize * num11 / 100f;
																																					this.m_sizeStack.Add(this.m_currentFontSize);
																																					this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																					return true;
																																				}
																																				else
																																				{
																																					if (this.m_htmlTag[5] == '+')
																																					{
																																						this.m_currentFontSize = this.m_fontSize + num11;
																																						this.m_sizeStack.Add(this.m_currentFontSize);
																																						this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																						return true;
																																					}
																																					if (this.m_htmlTag[5] == '-')
																																					{
																																						this.m_currentFontSize = this.m_fontSize + num11;
																																						this.m_sizeStack.Add(this.m_currentFontSize);
																																						this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																						return true;
																																					}
																																					this.m_currentFontSize = num11;
																																					this.m_sizeStack.Add(this.m_currentFontSize);
																																					this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																					return true;
																																				}
																																			}
																																			IL_13F8:
																																			if (this.m_overflowMode == TextOverflowModes.Page)
																																			{
																																				this.m_xAdvance = this.tag_LineIndent + this.tag_Indent;
																																				this.m_lineOffset = 0f;
																																				this.m_pageNumber++;
																																				this.m_isNewPage = true;
																																			}
																																			return true;
																																		}
																																		IL_1439:
																																		this.m_isNonBreakingSpace = true;
																																		return true;
																																	}
																																	IL_1E47:
																																	if (this.m_isParsingText)
																																	{
																																		int linkCount = this.m_textInfo.linkCount;
																																		if (linkCount + 1 > this.m_textInfo.linkInfo.Length)
																																		{
																																			TMP_TextInfo.Resize<TMP_LinkInfo>(ref this.m_textInfo.linkInfo, linkCount + 1);
																																		}
																																		this.m_textInfo.linkInfo[linkCount].textComponent = this;
																																		this.m_textInfo.linkInfo[linkCount].hashCode = this.m_xmlAttribute[0].valueHashCode;
																																		this.m_textInfo.linkInfo[linkCount].linkTextfirstCharacterIndex = this.m_characterCount;
																																		this.m_textInfo.linkInfo[linkCount].linkIdFirstCharacterIndex = startIndex + this.m_xmlAttribute[0].valueStartIndex;
																																		this.m_textInfo.linkInfo[linkCount].linkIdLength = this.m_xmlAttribute[0].valueLength;
																																		this.m_textInfo.linkInfo[linkCount].SetLinkID(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength);
																																	}
																																	return true;
																																}
																																IL_1751:
																																int valueHashCode5 = this.m_xmlAttribute[0].valueHashCode;
																																int nameHashCode2 = this.m_xmlAttribute[1].nameHashCode;
																																num10 = this.m_xmlAttribute[1].valueHashCode;
																																if (valueHashCode5 == 764638571 || valueHashCode5 == 523367755)
																																{
																																	this.m_currentFontAsset = this.m_materialReferences[0].fontAsset;
																																	this.m_currentMaterial = this.m_materialReferences[0].material;
																																	this.m_currentMaterialIndex = 0;
																																	this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																	this.m_materialReferenceStack.Add(this.m_materialReferences[0]);
																																	return true;
																																}
																																TMP_FontAsset tmp_FontAsset;
																																if (!MaterialReferenceManager.TryGetFontAsset(valueHashCode5, out tmp_FontAsset))
																																{
																																	tmp_FontAsset = Resources.Load<TMP_FontAsset>(TMP_Settings.defaultFontAssetPath + new string(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength));
																																	if (tmp_FontAsset == null)
																																	{
																																		return false;
																																	}
																																	MaterialReferenceManager.AddFontAsset(tmp_FontAsset);
																																}
																																if (nameHashCode2 == 0 && num10 == 0)
																																{
																																	this.m_currentMaterial = tmp_FontAsset.material;
																																	this.m_currentMaterialIndex = MaterialReference.AddMaterialReference(this.m_currentMaterial, tmp_FontAsset, this.m_materialReferences, this.m_materialReferenceIndexLookup);
																																	this.m_materialReferenceStack.Add(this.m_materialReferences[this.m_currentMaterialIndex]);
																																}
																																else
																																{
																																	if (nameHashCode2 != 103415287 && nameHashCode2 != 72669687)
																																	{
																																		return false;
																																	}
																																	Material material;
																																	if (MaterialReferenceManager.TryGetMaterial(num10, out material))
																																	{
																																		this.m_currentMaterial = material;
																																		this.m_currentMaterialIndex = MaterialReference.AddMaterialReference(this.m_currentMaterial, tmp_FontAsset, this.m_materialReferences, this.m_materialReferenceIndexLookup);
																																		this.m_materialReferenceStack.Add(this.m_materialReferences[this.m_currentMaterialIndex]);
																																	}
																																	else
																																	{
																																		material = Resources.Load<Material>(TMP_Settings.defaultFontAssetPath + new string(this.m_htmlTag, this.m_xmlAttribute[1].valueStartIndex, this.m_xmlAttribute[1].valueLength));
																																		if (material == null)
																																		{
																																			return false;
																																		}
																																		MaterialReferenceManager.AddFontMaterial(num10, material);
																																		this.m_currentMaterial = material;
																																		this.m_currentMaterialIndex = MaterialReference.AddMaterialReference(this.m_currentMaterial, tmp_FontAsset, this.m_materialReferences, this.m_materialReferenceIndexLookup);
																																		this.m_materialReferenceStack.Add(this.m_materialReferences[this.m_currentMaterialIndex]);
																																	}
																																}
																																this.m_currentFontAsset = tmp_FontAsset;
																																this.m_fontScale = this.m_currentFontSize / this.m_currentFontAsset.fontInfo.PointSize * this.m_currentFontAsset.fontInfo.Scale * ((!this.m_isOrthographic) ? 0.1f : 1f);
																																return true;
																															}
																														}
																														if ((this.m_style & FontStyles.Superscript) == FontStyles.Superscript)
																														{
																															if ((this.m_style & FontStyles.Subscript) == FontStyles.Subscript)
																															{
																																this.m_fontScaleMultiplier = ((this.m_currentFontAsset.fontInfo.SubSize <= 0f) ? 1f : this.m_currentFontAsset.fontInfo.SubSize);
																																this.m_baselineOffset = this.m_currentFontAsset.fontInfo.SubscriptOffset * this.m_fontScale * this.m_fontScaleMultiplier;
																															}
																															else
																															{
																																this.m_baselineOffset = 0f;
																																this.m_fontScaleMultiplier = 1f;
																															}
																															this.m_style &= (FontStyles)(-129);
																														}
																														return true;
																													}
																													IL_0ED3:
																													if ((this.m_style & FontStyles.Subscript) == FontStyles.Subscript)
																													{
																														if ((this.m_style & FontStyles.Superscript) == FontStyles.Superscript)
																														{
																															this.m_fontScaleMultiplier = ((this.m_currentFontAsset.fontInfo.SubSize <= 0f) ? 1f : this.m_currentFontAsset.fontInfo.SubSize);
																															this.m_baselineOffset = this.m_currentFontAsset.fontInfo.SuperscriptOffset * this.m_fontScale * this.m_fontScaleMultiplier;
																														}
																														else
																														{
																															this.m_baselineOffset = 0f;
																															this.m_fontScaleMultiplier = 1f;
																														}
																														this.m_style &= (FontStyles)(-257);
																													}
																													return true;
																												}
																												IL_133E:
																												this.m_isIgnoringAlignment = false;
																												return true;
																											}
																										}
																										this.m_fontScaleMultiplier = ((this.m_currentFontAsset.fontInfo.SubSize <= 0f) ? 1f : this.m_currentFontAsset.fontInfo.SubSize);
																										this.m_baselineOffset = this.m_currentFontAsset.fontInfo.SuperscriptOffset * this.m_fontScale * this.m_fontScaleMultiplier;
																										this.m_style |= FontStyles.Superscript;
																										return true;
																									}
																									IL_0E61:
																									this.m_fontScaleMultiplier = ((this.m_currentFontAsset.fontInfo.SubSize <= 0f) ? 1f : this.m_currentFontAsset.fontInfo.SubSize);
																									this.m_baselineOffset = this.m_currentFontAsset.fontInfo.SubscriptOffset * this.m_fontScale * this.m_fontScaleMultiplier;
																									this.m_style |= FontStyles.Subscript;
																									return true;
																								}
																								IL_1284:
																								num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																								if (num11 == -9999f)
																								{
																									return false;
																								}
																								if (tagUnits == TagUnits.Pixels)
																								{
																									this.m_xAdvance = num11;
																									return true;
																								}
																								if (tagUnits == TagUnits.FontUnits)
																								{
																									this.m_xAdvance = num11 * this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																									return true;
																								}
																								if (tagUnits != TagUnits.Percentage)
																								{
																									return false;
																								}
																								this.m_xAdvance = this.m_marginWidth * num11 / 100f;
																								return true;
																							}
																						}
																						this.m_style |= FontStyles.Italic;
																						return true;
																					}
																					IL_0D84:
																					this.m_style |= FontStyles.Bold;
																					this.m_fontWeightInternal = 700;
																					this.m_fontWeightStack.Add(700);
																					return true;
																				}
																				IL_10B7:
																				num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																				if (num11 == -9999f || num11 == 0f)
																				{
																					return false;
																				}
																				if ((this.m_fontStyle & FontStyles.Bold) == FontStyles.Bold)
																				{
																					return true;
																				}
																				this.m_style &= (FontStyles)(-2);
																				int num15 = (int)num11;
																				if (num15 != 100)
																				{
																					if (num15 != 200)
																					{
																						if (num15 != 300)
																						{
																							if (num15 != 400)
																							{
																								if (num15 != 500)
																								{
																									if (num15 != 600)
																									{
																										if (num15 != 700)
																										{
																											if (num15 != 800)
																											{
																												if (num15 == 900)
																												{
																													this.m_fontWeightInternal = 900;
																												}
																											}
																											else
																											{
																												this.m_fontWeightInternal = 800;
																											}
																										}
																										else
																										{
																											this.m_fontWeightInternal = 700;
																											this.m_style |= FontStyles.Bold;
																										}
																									}
																									else
																									{
																										this.m_fontWeightInternal = 600;
																									}
																								}
																								else
																								{
																									this.m_fontWeightInternal = 500;
																								}
																							}
																							else
																							{
																								this.m_fontWeightInternal = 400;
																							}
																						}
																						else
																						{
																							this.m_fontWeightInternal = 300;
																						}
																					}
																					else
																					{
																						this.m_fontWeightInternal = 200;
																					}
																				}
																				else
																				{
																					this.m_fontWeightInternal = 100;
																				}
																				this.m_fontWeightStack.Add(this.m_fontWeightInternal);
																				return true;
																			}
																			IL_27E6:
																			this.tag_LineIndent = 0f;
																			return true;
																		}
																		IL_31D5:
																		this.m_lineHeight = 0f;
																		return true;
																	}
																	IL_26F8:
																	num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																	if (num11 == -9999f || num11 == 0f)
																	{
																		return false;
																	}
																	if (tagUnits != TagUnits.Pixels)
																	{
																		if (tagUnits != TagUnits.FontUnits)
																		{
																			if (tagUnits == TagUnits.Percentage)
																			{
																				this.tag_LineIndent = this.m_marginWidth * num11 / 100f;
																			}
																		}
																		else
																		{
																			this.tag_LineIndent = num11;
																			this.tag_LineIndent *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																		}
																	}
																	else
																	{
																		this.tag_LineIndent = num11;
																	}
																	this.m_xAdvance += this.tag_LineIndent;
																	return true;
																}
																IL_30FA:
																num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
																if (num11 == -9999f || num11 == 0f)
																{
																	return false;
																}
																this.m_lineHeight = num11;
																if (tagUnits != TagUnits.Pixels)
																{
																	if (tagUnits != TagUnits.FontUnits)
																	{
																		if (tagUnits == TagUnits.Percentage)
																		{
																			this.m_lineHeight = this.m_fontAsset.fontInfo.LineHeight * this.m_lineHeight / 100f * this.m_fontScale;
																		}
																	}
																	else
																	{
																		this.m_lineHeight *= this.m_fontAsset.fontInfo.LineHeight * this.m_fontScale;
																	}
																}
																return true;
															}
															IL_2EBE:
															num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
															if (num11 == -9999f || num11 == 0f)
															{
																return false;
															}
															this.m_marginLeft = num11;
															if (tagUnits != TagUnits.Pixels)
															{
																if (tagUnits != TagUnits.FontUnits)
																{
																	if (tagUnits == TagUnits.Percentage)
																	{
																		this.m_marginLeft = (this.m_marginWidth - ((this.m_width == -1f) ? 0f : this.m_width)) * this.m_marginLeft / 100f;
																	}
																}
																else
																{
																	this.m_marginLeft *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
																}
															}
															this.m_marginLeft = ((this.m_marginLeft < 0f) ? 0f : this.m_marginLeft);
															return true;
														}
													}
													num11 = this.ConvertToFloat(this.m_htmlTag, this.m_xmlAttribute[0].valueStartIndex, this.m_xmlAttribute[0].valueLength, this.m_xmlAttribute[0].valueDecimalIndex);
													if (num11 == -9999f || num11 == 0f)
													{
														return false;
													}
													this.m_marginRight = num11;
													if (tagUnits != TagUnits.Pixels)
													{
														if (tagUnits != TagUnits.FontUnits)
														{
															if (tagUnits == TagUnits.Percentage)
															{
																this.m_marginRight = (this.m_marginWidth - ((this.m_width == -1f) ? 0f : this.m_width)) * this.m_marginRight / 100f;
															}
														}
														else
														{
															this.m_marginRight *= this.m_fontScale * this.m_fontAsset.fontInfo.TabWidth / (float)this.m_fontAsset.tabSize;
														}
													}
													this.m_marginRight = ((this.m_marginRight < 0f) ? 0f : this.m_marginRight);
													return true;
												}
												IL_2D49:
												this.m_style &= (FontStyles)(-17);
												return true;
											}
											IL_2D6B:
											this.m_style &= (FontStyles)(-33);
											return true;
										}
										IL_2D27:
										this.m_style &= (FontStyles)(-9);
										return true;
									}
									IL_1252:
									this.m_fontWeightInternal = this.m_fontWeightStack.Remove();
									if (this.m_fontWeightInternal == 400)
									{
										this.m_style &= (FontStyles)(-2);
									}
									return true;
								case 446:
									goto IL_0E42;
								}
							}
							if ((this.m_fontStyle & FontStyles.Bold) != FontStyles.Bold)
							{
								this.m_style &= (FontStyles)(-2);
								this.m_fontWeightInternal = this.m_fontWeightStack.Remove();
							}
							return true;
						}
						return true;
					case 414:
						goto IL_0E42;
					}
					IL_0E11:
					if ((this.m_fontStyle & FontStyles.Strikethrough) != FontStyles.Strikethrough)
					{
						this.m_style &= (FontStyles)(-65);
					}
					return true;
					IL_0E42:
					if ((this.m_fontStyle & FontStyles.Underline) != FontStyles.Underline)
					{
						this.m_style &= (FontStyles)(-5);
					}
					return true;
				case 117:
					goto IL_0E32;
				}
				break;
			case 85:
				goto IL_0E32;
			}
			this.m_style |= FontStyles.Strikethrough;
			return true;
			IL_0E32:
			this.m_style |= FontStyles.Underline;
			return true;
		}

		// Token: 0x04003089 RID: 12425
		[SerializeField]
		protected string m_text;

		// Token: 0x0400308A RID: 12426
		[SerializeField]
		protected bool m_isRightToLeft;

		// Token: 0x0400308B RID: 12427
		[SerializeField]
		protected TMP_FontAsset m_fontAsset;

		// Token: 0x0400308C RID: 12428
		protected TMP_FontAsset m_currentFontAsset;

		// Token: 0x0400308D RID: 12429
		protected bool m_isSDFShader;

		// Token: 0x0400308E RID: 12430
		[SerializeField]
		protected Material m_sharedMaterial;

		// Token: 0x0400308F RID: 12431
		protected Material m_currentMaterial;

		// Token: 0x04003090 RID: 12432
		protected MaterialReference[] m_materialReferences = new MaterialReference[32];

		// Token: 0x04003091 RID: 12433
		protected Dictionary<int, int> m_materialReferenceIndexLookup = new Dictionary<int, int>();

		// Token: 0x04003092 RID: 12434
		protected TMP_XmlTagStack<MaterialReference> m_materialReferenceStack = new TMP_XmlTagStack<MaterialReference>(new MaterialReference[16]);

		// Token: 0x04003093 RID: 12435
		protected int m_currentMaterialIndex;

		// Token: 0x04003094 RID: 12436
		[SerializeField]
		protected Material[] m_fontSharedMaterials;

		// Token: 0x04003095 RID: 12437
		[SerializeField]
		protected Material m_fontMaterial;

		// Token: 0x04003096 RID: 12438
		[SerializeField]
		protected Material[] m_fontMaterials;

		// Token: 0x04003097 RID: 12439
		protected bool m_isMaterialDirty;

		// Token: 0x04003098 RID: 12440
		[FormerlySerializedAs("m_fontColor")]
		[SerializeField]
		protected Color32 m_fontColor32 = Color.white;

		// Token: 0x04003099 RID: 12441
		[SerializeField]
		protected Color m_fontColor = Color.white;

		// Token: 0x0400309A RID: 12442
		protected static Color32 s_colorWhite = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		// Token: 0x0400309B RID: 12443
		[SerializeField]
		protected bool m_enableVertexGradient;

		// Token: 0x0400309C RID: 12444
		[SerializeField]
		protected VertexGradient m_fontColorGradient = new VertexGradient(Color.white);

		// Token: 0x0400309D RID: 12445
		[SerializeField]
		protected TMP_ColorGradient m_fontColorGradientPreset;

		// Token: 0x0400309E RID: 12446
		protected TMP_SpriteAsset m_spriteAsset;

		// Token: 0x0400309F RID: 12447
		[SerializeField]
		protected bool m_tintAllSprites;

		// Token: 0x040030A0 RID: 12448
		protected bool m_tintSprite;

		// Token: 0x040030A1 RID: 12449
		protected Color32 m_spriteColor;

		// Token: 0x040030A2 RID: 12450
		[SerializeField]
		protected bool m_overrideHtmlColors;

		// Token: 0x040030A3 RID: 12451
		[SerializeField]
		protected Color32 m_faceColor = Color.white;

		// Token: 0x040030A4 RID: 12452
		[SerializeField]
		protected Color32 m_outlineColor = Color.black;

		// Token: 0x040030A5 RID: 12453
		protected float m_outlineWidth;

		// Token: 0x040030A6 RID: 12454
		[SerializeField]
		protected float m_fontSize = 36f;

		// Token: 0x040030A7 RID: 12455
		protected float m_currentFontSize;

		// Token: 0x040030A8 RID: 12456
		[SerializeField]
		protected float m_fontSizeBase = 36f;

		// Token: 0x040030A9 RID: 12457
		protected TMP_XmlTagStack<float> m_sizeStack = new TMP_XmlTagStack<float>(new float[16]);

		// Token: 0x040030AA RID: 12458
		[SerializeField]
		protected int m_fontWeight = 400;

		// Token: 0x040030AB RID: 12459
		protected int m_fontWeightInternal;

		// Token: 0x040030AC RID: 12460
		protected TMP_XmlTagStack<int> m_fontWeightStack = new TMP_XmlTagStack<int>(new int[16]);

		// Token: 0x040030AD RID: 12461
		[SerializeField]
		protected bool m_enableAutoSizing;

		// Token: 0x040030AE RID: 12462
		protected float m_maxFontSize;

		// Token: 0x040030AF RID: 12463
		protected float m_minFontSize;

		// Token: 0x040030B0 RID: 12464
		[SerializeField]
		protected float m_fontSizeMin;

		// Token: 0x040030B1 RID: 12465
		[SerializeField]
		protected float m_fontSizeMax;

		// Token: 0x040030B2 RID: 12466
		[SerializeField]
		protected FontStyles m_fontStyle;

		// Token: 0x040030B3 RID: 12467
		protected FontStyles m_style;

		// Token: 0x040030B4 RID: 12468
		protected bool m_isUsingBold;

		// Token: 0x040030B5 RID: 12469
		[SerializeField]
		[FormerlySerializedAs("m_lineJustification")]
		protected TextAlignmentOptions m_textAlignment;

		// Token: 0x040030B6 RID: 12470
		protected TextAlignmentOptions m_lineJustification;

		// Token: 0x040030B7 RID: 12471
		protected Vector3[] m_textContainerLocalCorners = new Vector3[4];

		// Token: 0x040030B8 RID: 12472
		[SerializeField]
		protected float m_characterSpacing;

		// Token: 0x040030B9 RID: 12473
		protected float m_cSpacing;

		// Token: 0x040030BA RID: 12474
		protected float m_monoSpacing;

		// Token: 0x040030BB RID: 12475
		[SerializeField]
		protected float m_lineSpacing;

		// Token: 0x040030BC RID: 12476
		protected float m_lineSpacingDelta;

		// Token: 0x040030BD RID: 12477
		protected float m_lineHeight;

		// Token: 0x040030BE RID: 12478
		[SerializeField]
		protected float m_lineSpacingMax;

		// Token: 0x040030BF RID: 12479
		[SerializeField]
		protected float m_paragraphSpacing;

		// Token: 0x040030C0 RID: 12480
		[SerializeField]
		protected float m_charWidthMaxAdj;

		// Token: 0x040030C1 RID: 12481
		protected float m_charWidthAdjDelta;

		// Token: 0x040030C2 RID: 12482
		[SerializeField]
		protected bool m_enableWordWrapping;

		// Token: 0x040030C3 RID: 12483
		protected bool m_isCharacterWrappingEnabled;

		// Token: 0x040030C4 RID: 12484
		protected bool m_isNonBreakingSpace;

		// Token: 0x040030C5 RID: 12485
		protected bool m_isIgnoringAlignment;

		// Token: 0x040030C6 RID: 12486
		[SerializeField]
		protected float m_wordWrappingRatios = 0.4f;

		// Token: 0x040030C7 RID: 12487
		[SerializeField]
		protected bool m_enableAdaptiveJustification;

		// Token: 0x040030C8 RID: 12488
		protected float m_adaptiveJustificationThreshold = 10f;

		// Token: 0x040030C9 RID: 12489
		[SerializeField]
		protected TextOverflowModes m_overflowMode;

		// Token: 0x040030CA RID: 12490
		protected bool m_isTextTruncated;

		// Token: 0x040030CB RID: 12491
		[SerializeField]
		protected bool m_enableKerning;

		// Token: 0x040030CC RID: 12492
		[SerializeField]
		protected bool m_enableExtraPadding;

		// Token: 0x040030CD RID: 12493
		[SerializeField]
		protected bool checkPaddingRequired;

		// Token: 0x040030CE RID: 12494
		[SerializeField]
		protected bool m_isRichText = true;

		// Token: 0x040030CF RID: 12495
		[SerializeField]
		protected bool m_parseCtrlCharacters = true;

		// Token: 0x040030D0 RID: 12496
		protected bool m_isOverlay;

		// Token: 0x040030D1 RID: 12497
		[SerializeField]
		protected bool m_isOrthographic;

		// Token: 0x040030D2 RID: 12498
		[SerializeField]
		protected bool m_isCullingEnabled;

		// Token: 0x040030D3 RID: 12499
		[SerializeField]
		protected bool m_ignoreCulling = true;

		// Token: 0x040030D4 RID: 12500
		[SerializeField]
		protected TextureMappingOptions m_horizontalMapping;

		// Token: 0x040030D5 RID: 12501
		[SerializeField]
		protected TextureMappingOptions m_verticalMapping;

		// Token: 0x040030D6 RID: 12502
		protected TextRenderFlags m_renderMode = TextRenderFlags.Render;

		// Token: 0x040030D7 RID: 12503
		protected int m_maxVisibleCharacters = 99999;

		// Token: 0x040030D8 RID: 12504
		protected int m_maxVisibleWords = 99999;

		// Token: 0x040030D9 RID: 12505
		protected int m_maxVisibleLines = 99999;

		// Token: 0x040030DA RID: 12506
		[SerializeField]
		protected bool m_useMaxVisibleDescender = true;

		// Token: 0x040030DB RID: 12507
		[SerializeField]
		protected int m_pageToDisplay = 1;

		// Token: 0x040030DC RID: 12508
		protected bool m_isNewPage;

		// Token: 0x040030DD RID: 12509
		[SerializeField]
		protected Vector4 m_margin = new Vector4(0f, 0f, 0f, 0f);

		// Token: 0x040030DE RID: 12510
		protected float m_marginLeft;

		// Token: 0x040030DF RID: 12511
		protected float m_marginRight;

		// Token: 0x040030E0 RID: 12512
		protected float m_marginWidth;

		// Token: 0x040030E1 RID: 12513
		protected float m_marginHeight;

		// Token: 0x040030E2 RID: 12514
		protected float m_width = -1f;

		// Token: 0x040030E3 RID: 12515
		[SerializeField]
		protected TMP_TextInfo m_textInfo;

		// Token: 0x040030E4 RID: 12516
		[SerializeField]
		protected bool m_havePropertiesChanged;

		// Token: 0x040030E5 RID: 12517
		[SerializeField]
		protected bool m_isUsingLegacyAnimationComponent;

		// Token: 0x040030E6 RID: 12518
		protected Transform m_transform;

		// Token: 0x040030E7 RID: 12519
		protected RectTransform m_rectTransform;

		// Token: 0x040030E9 RID: 12521
		protected Mesh m_mesh;

		// Token: 0x040030EA RID: 12522
		[SerializeField]
		protected bool m_isVolumetricText;

		// Token: 0x040030EB RID: 12523
		protected float m_flexibleHeight = -1f;

		// Token: 0x040030EC RID: 12524
		protected float m_flexibleWidth = -1f;

		// Token: 0x040030ED RID: 12525
		protected float m_minHeight;

		// Token: 0x040030EE RID: 12526
		protected float m_minWidth;

		// Token: 0x040030EF RID: 12527
		protected float m_preferredWidth;

		// Token: 0x040030F0 RID: 12528
		protected float m_renderedWidth;

		// Token: 0x040030F1 RID: 12529
		protected bool m_isPreferredWidthDirty;

		// Token: 0x040030F2 RID: 12530
		protected float m_preferredHeight;

		// Token: 0x040030F3 RID: 12531
		protected float m_renderedHeight;

		// Token: 0x040030F4 RID: 12532
		protected bool m_isPreferredHeightDirty;

		// Token: 0x040030F5 RID: 12533
		protected bool m_isCalculatingPreferredValues;

		// Token: 0x040030F6 RID: 12534
		protected int m_layoutPriority;

		// Token: 0x040030F7 RID: 12535
		protected bool m_isCalculateSizeRequired;

		// Token: 0x040030F8 RID: 12536
		protected bool m_isLayoutDirty;

		// Token: 0x040030F9 RID: 12537
		protected bool m_verticesAlreadyDirty;

		// Token: 0x040030FA RID: 12538
		protected bool m_layoutAlreadyDirty;

		// Token: 0x040030FB RID: 12539
		protected bool m_isAwake;

		// Token: 0x040030FC RID: 12540
		[SerializeField]
		protected bool m_isInputParsingRequired;

		// Token: 0x040030FD RID: 12541
		[SerializeField]
		protected TMP_Text.TextInputSources m_inputSource;

		// Token: 0x040030FE RID: 12542
		protected string old_text;

		// Token: 0x040030FF RID: 12543
		protected float old_arg0;

		// Token: 0x04003100 RID: 12544
		protected float old_arg1;

		// Token: 0x04003101 RID: 12545
		protected float old_arg2;

		// Token: 0x04003102 RID: 12546
		protected float m_fontScale;

		// Token: 0x04003103 RID: 12547
		protected float m_fontScaleMultiplier;

		// Token: 0x04003104 RID: 12548
		protected char[] m_htmlTag = new char[128];

		// Token: 0x04003105 RID: 12549
		protected XML_TagAttribute[] m_xmlAttribute = new XML_TagAttribute[8];

		// Token: 0x04003106 RID: 12550
		protected float tag_LineIndent;

		// Token: 0x04003107 RID: 12551
		protected float tag_Indent;

		// Token: 0x04003108 RID: 12552
		protected TMP_XmlTagStack<float> m_indentStack = new TMP_XmlTagStack<float>(new float[16]);

		// Token: 0x04003109 RID: 12553
		protected bool tag_NoParsing;

		// Token: 0x0400310A RID: 12554
		protected bool m_isParsingText;

		// Token: 0x0400310B RID: 12555
		protected int[] m_char_buffer;

		// Token: 0x0400310C RID: 12556
		private TMP_CharacterInfo[] m_internalCharacterInfo;

		// Token: 0x0400310D RID: 12557
		protected char[] m_input_CharArray = new char[256];

		// Token: 0x0400310E RID: 12558
		private int m_charArray_Length;

		// Token: 0x0400310F RID: 12559
		protected int m_totalCharacterCount;

		// Token: 0x04003110 RID: 12560
		protected int m_characterCount;

		// Token: 0x04003111 RID: 12561
		protected int m_firstCharacterOfLine;

		// Token: 0x04003112 RID: 12562
		protected int m_firstVisibleCharacterOfLine;

		// Token: 0x04003113 RID: 12563
		protected int m_lastCharacterOfLine;

		// Token: 0x04003114 RID: 12564
		protected int m_lastVisibleCharacterOfLine;

		// Token: 0x04003115 RID: 12565
		protected int m_lineNumber;

		// Token: 0x04003116 RID: 12566
		protected int m_lineVisibleCharacterCount;

		// Token: 0x04003117 RID: 12567
		protected int m_pageNumber;

		// Token: 0x04003118 RID: 12568
		protected float m_maxAscender;

		// Token: 0x04003119 RID: 12569
		protected float m_maxCapHeight;

		// Token: 0x0400311A RID: 12570
		protected float m_maxDescender;

		// Token: 0x0400311B RID: 12571
		protected float m_maxLineAscender;

		// Token: 0x0400311C RID: 12572
		protected float m_maxLineDescender;

		// Token: 0x0400311D RID: 12573
		protected float m_startOfLineAscender;

		// Token: 0x0400311E RID: 12574
		protected float m_lineOffset;

		// Token: 0x0400311F RID: 12575
		protected Extents m_meshExtents;

		// Token: 0x04003120 RID: 12576
		protected Color32 m_htmlColor = new Color(255f, 255f, 255f, 128f);

		// Token: 0x04003121 RID: 12577
		protected TMP_XmlTagStack<Color32> m_colorStack = new TMP_XmlTagStack<Color32>(new Color32[16]);

		// Token: 0x04003122 RID: 12578
		protected float m_tabSpacing;

		// Token: 0x04003123 RID: 12579
		protected float m_spacing;

		// Token: 0x04003124 RID: 12580
		protected TMP_XmlTagStack<int> m_styleStack = new TMP_XmlTagStack<int>(new int[16]);

		// Token: 0x04003125 RID: 12581
		protected TMP_XmlTagStack<int> m_actionStack = new TMP_XmlTagStack<int>(new int[16]);

		// Token: 0x04003126 RID: 12582
		protected float m_padding;

		// Token: 0x04003127 RID: 12583
		protected float m_baselineOffset;

		// Token: 0x04003128 RID: 12584
		protected float m_xAdvance;

		// Token: 0x04003129 RID: 12585
		protected TMP_TextElementType m_textElementType;

		// Token: 0x0400312A RID: 12586
		protected TMP_TextElement m_cached_TextElement;

		// Token: 0x0400312B RID: 12587
		protected TMP_Glyph m_cached_Underline_GlyphInfo;

		// Token: 0x0400312C RID: 12588
		protected TMP_Glyph m_cached_Ellipsis_GlyphInfo;

		// Token: 0x0400312D RID: 12589
		protected TMP_SpriteAsset m_defaultSpriteAsset;

		// Token: 0x0400312E RID: 12590
		protected TMP_SpriteAsset m_currentSpriteAsset;

		// Token: 0x0400312F RID: 12591
		protected int m_spriteCount;

		// Token: 0x04003130 RID: 12592
		protected int m_spriteIndex;

		// Token: 0x04003131 RID: 12593
		protected InlineGraphicManager m_inlineGraphics;

		// Token: 0x04003132 RID: 12594
		protected bool m_ignoreActiveState;

		// Token: 0x04003133 RID: 12595
		private readonly float[] k_Power = new float[] { 0.5f, 0.05f, 0.005f, 0.0005f, 5E-05f, 5E-06f, 5E-07f, 5E-08f, 5E-09f, 5E-10f };

		// Token: 0x04003134 RID: 12596
		protected static Vector2 k_LargePositiveVector2 = new Vector2(2.1474836E+09f, 2.1474836E+09f);

		// Token: 0x04003135 RID: 12597
		protected static Vector2 k_LargeNegativeVector2 = new Vector2(-2.1474836E+09f, -2.1474836E+09f);

		// Token: 0x04003136 RID: 12598
		protected static float k_LargePositiveFloat = 32768f;

		// Token: 0x04003137 RID: 12599
		protected static float k_LargeNegativeFloat = -32768f;

		// Token: 0x04003138 RID: 12600
		protected static int k_LargePositiveInt = int.MaxValue;

		// Token: 0x04003139 RID: 12601
		protected static int k_LargeNegativeInt = -2147483647;

		// Token: 0x02000631 RID: 1585
		protected enum TextInputSources
		{
			// Token: 0x0400313B RID: 12603
			Text,
			// Token: 0x0400313C RID: 12604
			SetText,
			// Token: 0x0400313D RID: 12605
			SetCharArray,
			// Token: 0x0400313E RID: 12606
			String
		}
	}
}

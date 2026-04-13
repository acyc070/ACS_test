using System;
using System.Linq;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000656 RID: 1622
	public static class ShaderUtilities
	{
		// Token: 0x06002D9F RID: 11679 RVA: 0x00112908 File Offset: 0x00110B08
		public static void GetShaderPropertyIDs()
		{
			if (!ShaderUtilities.isInitialized)
			{
				ShaderUtilities.isInitialized = true;
				ShaderUtilities.ID_MainTex = Shader.PropertyToID("_MainTex");
				ShaderUtilities.ID_FaceTex = Shader.PropertyToID("_FaceTex");
				ShaderUtilities.ID_FaceColor = Shader.PropertyToID("_FaceColor");
				ShaderUtilities.ID_FaceDilate = Shader.PropertyToID("_FaceDilate");
				ShaderUtilities.ID_Shininess = Shader.PropertyToID("_FaceShininess");
				ShaderUtilities.ID_UnderlayColor = Shader.PropertyToID("_UnderlayColor");
				ShaderUtilities.ID_UnderlayOffsetX = Shader.PropertyToID("_UnderlayOffsetX");
				ShaderUtilities.ID_UnderlayOffsetY = Shader.PropertyToID("_UnderlayOffsetY");
				ShaderUtilities.ID_UnderlayDilate = Shader.PropertyToID("_UnderlayDilate");
				ShaderUtilities.ID_UnderlaySoftness = Shader.PropertyToID("_UnderlaySoftness");
				ShaderUtilities.ID_WeightNormal = Shader.PropertyToID("_WeightNormal");
				ShaderUtilities.ID_WeightBold = Shader.PropertyToID("_WeightBold");
				ShaderUtilities.ID_OutlineTex = Shader.PropertyToID("_OutlineTex");
				ShaderUtilities.ID_OutlineWidth = Shader.PropertyToID("_OutlineWidth");
				ShaderUtilities.ID_OutlineSoftness = Shader.PropertyToID("_OutlineSoftness");
				ShaderUtilities.ID_OutlineColor = Shader.PropertyToID("_OutlineColor");
				ShaderUtilities.ID_GradientScale = Shader.PropertyToID("_GradientScale");
				ShaderUtilities.ID_ScaleX = Shader.PropertyToID("_ScaleX");
				ShaderUtilities.ID_ScaleY = Shader.PropertyToID("_ScaleY");
				ShaderUtilities.ID_PerspectiveFilter = Shader.PropertyToID("_PerspectiveFilter");
				ShaderUtilities.ID_TextureWidth = Shader.PropertyToID("_TextureWidth");
				ShaderUtilities.ID_TextureHeight = Shader.PropertyToID("_TextureHeight");
				ShaderUtilities.ID_BevelAmount = Shader.PropertyToID("_Bevel");
				ShaderUtilities.ID_LightAngle = Shader.PropertyToID("_LightAngle");
				ShaderUtilities.ID_EnvMap = Shader.PropertyToID("_Cube");
				ShaderUtilities.ID_EnvMatrix = Shader.PropertyToID("_EnvMatrix");
				ShaderUtilities.ID_EnvMatrixRotation = Shader.PropertyToID("_EnvMatrixRotation");
				ShaderUtilities.ID_GlowColor = Shader.PropertyToID("_GlowColor");
				ShaderUtilities.ID_GlowOffset = Shader.PropertyToID("_GlowOffset");
				ShaderUtilities.ID_GlowPower = Shader.PropertyToID("_GlowPower");
				ShaderUtilities.ID_GlowOuter = Shader.PropertyToID("_GlowOuter");
				ShaderUtilities.ID_MaskCoord = Shader.PropertyToID("_MaskCoord");
				ShaderUtilities.ID_ClipRect = Shader.PropertyToID("_ClipRect");
				ShaderUtilities.ID_UseClipRect = Shader.PropertyToID("_UseClipRect");
				ShaderUtilities.ID_MaskSoftnessX = Shader.PropertyToID("_MaskSoftnessX");
				ShaderUtilities.ID_MaskSoftnessY = Shader.PropertyToID("_MaskSoftnessY");
				ShaderUtilities.ID_VertexOffsetX = Shader.PropertyToID("_VertexOffsetX");
				ShaderUtilities.ID_VertexOffsetY = Shader.PropertyToID("_VertexOffsetY");
				ShaderUtilities.ID_StencilID = Shader.PropertyToID("_Stencil");
				ShaderUtilities.ID_StencilOp = Shader.PropertyToID("_StencilOp");
				ShaderUtilities.ID_StencilComp = Shader.PropertyToID("_StencilComp");
				ShaderUtilities.ID_StencilReadMask = Shader.PropertyToID("_StencilReadMask");
				ShaderUtilities.ID_StencilWriteMask = Shader.PropertyToID("_StencilWriteMask");
				ShaderUtilities.ID_ShaderFlags = Shader.PropertyToID("_ShaderFlags");
				ShaderUtilities.ID_ScaleRatio_A = Shader.PropertyToID("_ScaleRatioA");
				ShaderUtilities.ID_ScaleRatio_B = Shader.PropertyToID("_ScaleRatioB");
				ShaderUtilities.ID_ScaleRatio_C = Shader.PropertyToID("_ScaleRatioC");
			}
		}

		// Token: 0x06002DA0 RID: 11680 RVA: 0x00112BE8 File Offset: 0x00110DE8
		public static void UpdateShaderRatios(Material mat, bool isBold)
		{
			bool flag = !mat.shaderKeywords.Contains(ShaderUtilities.Keyword_Ratios);
			float @float = mat.GetFloat(ShaderUtilities.ID_GradientScale);
			float float2 = mat.GetFloat(ShaderUtilities.ID_FaceDilate);
			float float3 = mat.GetFloat(ShaderUtilities.ID_OutlineWidth);
			float float4 = mat.GetFloat(ShaderUtilities.ID_OutlineSoftness);
			float num = (isBold ? (mat.GetFloat(ShaderUtilities.ID_WeightBold) * 2f / @float) : (mat.GetFloat(ShaderUtilities.ID_WeightNormal) * 2f / @float));
			float num2 = Mathf.Max(1f, num + float2 + float3 + float4);
			float num3 = ((!flag) ? 1f : ((@float - ShaderUtilities.m_clamp) / (@float * num2)));
			mat.SetFloat(ShaderUtilities.ID_ScaleRatio_A, num3);
			if (mat.HasProperty(ShaderUtilities.ID_GlowOffset))
			{
				float float5 = mat.GetFloat(ShaderUtilities.ID_GlowOffset);
				float float6 = mat.GetFloat(ShaderUtilities.ID_GlowOuter);
				float num4 = (num + float2) * (@float - ShaderUtilities.m_clamp);
				num2 = Mathf.Max(1f, float5 + float6);
				float num5 = ((!flag) ? 1f : (Mathf.Max(0f, @float - ShaderUtilities.m_clamp - num4) / (@float * num2)));
				mat.SetFloat(ShaderUtilities.ID_ScaleRatio_B, num5);
			}
			if (mat.HasProperty(ShaderUtilities.ID_UnderlayOffsetX))
			{
				float float7 = mat.GetFloat(ShaderUtilities.ID_UnderlayOffsetX);
				float float8 = mat.GetFloat(ShaderUtilities.ID_UnderlayOffsetY);
				float float9 = mat.GetFloat(ShaderUtilities.ID_UnderlayDilate);
				float float10 = mat.GetFloat(ShaderUtilities.ID_UnderlaySoftness);
				float num6 = (num + float2) * (@float - ShaderUtilities.m_clamp);
				num2 = Mathf.Max(1f, Mathf.Max(Mathf.Abs(float7), Mathf.Abs(float8)) + float9 + float10);
				float num7 = ((!flag) ? 1f : (Mathf.Max(0f, @float - ShaderUtilities.m_clamp - num6) / (@float * num2)));
				mat.SetFloat(ShaderUtilities.ID_ScaleRatio_C, num7);
			}
		}

		// Token: 0x06002DA1 RID: 11681 RVA: 0x00020B80 File Offset: 0x0001ED80
		public static Vector4 GetFontExtent(Material material)
		{
			return Vector4.zero;
		}

		// Token: 0x06002DA2 RID: 11682 RVA: 0x00112DFC File Offset: 0x00110FFC
		public static bool IsMaskingEnabled(Material material)
		{
			return !(material == null) && material.HasProperty(ShaderUtilities.ID_ClipRect) && (material.shaderKeywords.Contains(ShaderUtilities.Keyword_MASK_SOFT) || material.shaderKeywords.Contains(ShaderUtilities.Keyword_MASK_HARD) || material.shaderKeywords.Contains(ShaderUtilities.Keyword_MASK_TEX));
		}

		// Token: 0x06002DA3 RID: 11683 RVA: 0x00112E6C File Offset: 0x0011106C
		public static float GetPadding(Material material, bool enableExtraPadding, bool isBold)
		{
			if (!ShaderUtilities.isInitialized)
			{
				ShaderUtilities.GetShaderPropertyIDs();
			}
			if (material == null)
			{
				return 0f;
			}
			int num = ((!enableExtraPadding) ? 0 : 4);
			if (!material.HasProperty(ShaderUtilities.ID_GradientScale))
			{
				return (float)num;
			}
			Vector4 vector = Vector4.zero;
			Vector4 zero = Vector4.zero;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			ShaderUtilities.UpdateShaderRatios(material, isBold);
			string[] shaderKeywords = material.shaderKeywords;
			if (material.HasProperty(ShaderUtilities.ID_ScaleRatio_A))
			{
				num5 = material.GetFloat(ShaderUtilities.ID_ScaleRatio_A);
			}
			if (material.HasProperty(ShaderUtilities.ID_FaceDilate))
			{
				num2 = material.GetFloat(ShaderUtilities.ID_FaceDilate) * num5;
			}
			if (material.HasProperty(ShaderUtilities.ID_OutlineSoftness))
			{
				num3 = material.GetFloat(ShaderUtilities.ID_OutlineSoftness) * num5;
			}
			if (material.HasProperty(ShaderUtilities.ID_OutlineWidth))
			{
				num4 = material.GetFloat(ShaderUtilities.ID_OutlineWidth) * num5;
			}
			float num10 = num4 + num3 + num2;
			if (material.HasProperty(ShaderUtilities.ID_GlowOffset) && shaderKeywords.Contains(ShaderUtilities.Keyword_Glow))
			{
				if (material.HasProperty(ShaderUtilities.ID_ScaleRatio_B))
				{
					num6 = material.GetFloat(ShaderUtilities.ID_ScaleRatio_B);
				}
				num8 = material.GetFloat(ShaderUtilities.ID_GlowOffset) * num6;
				num9 = material.GetFloat(ShaderUtilities.ID_GlowOuter) * num6;
			}
			num10 = Mathf.Max(num10, num2 + num8 + num9);
			if (material.HasProperty(ShaderUtilities.ID_UnderlaySoftness) && shaderKeywords.Contains(ShaderUtilities.Keyword_Underlay))
			{
				if (material.HasProperty(ShaderUtilities.ID_ScaleRatio_C))
				{
					num7 = material.GetFloat(ShaderUtilities.ID_ScaleRatio_C);
				}
				float num11 = material.GetFloat(ShaderUtilities.ID_UnderlayOffsetX) * num7;
				float num12 = material.GetFloat(ShaderUtilities.ID_UnderlayOffsetY) * num7;
				float num13 = material.GetFloat(ShaderUtilities.ID_UnderlayDilate) * num7;
				float num14 = material.GetFloat(ShaderUtilities.ID_UnderlaySoftness) * num7;
				vector.x = Mathf.Max(vector.x, num2 + num13 + num14 - num11);
				vector.y = Mathf.Max(vector.y, num2 + num13 + num14 - num12);
				vector.z = Mathf.Max(vector.z, num2 + num13 + num14 + num11);
				vector.w = Mathf.Max(vector.w, num2 + num13 + num14 + num12);
			}
			vector.x = Mathf.Max(vector.x, num10);
			vector.y = Mathf.Max(vector.y, num10);
			vector.z = Mathf.Max(vector.z, num10);
			vector.w = Mathf.Max(vector.w, num10);
			vector.x += (float)num;
			vector.y += (float)num;
			vector.z += (float)num;
			vector.w += (float)num;
			vector.x = Mathf.Min(vector.x, 1f);
			vector.y = Mathf.Min(vector.y, 1f);
			vector.z = Mathf.Min(vector.z, 1f);
			vector.w = Mathf.Min(vector.w, 1f);
			zero.x = ((zero.x >= vector.x) ? zero.x : vector.x);
			zero.y = ((zero.y >= vector.y) ? zero.y : vector.y);
			zero.z = ((zero.z >= vector.z) ? zero.z : vector.z);
			zero.w = ((zero.w >= vector.w) ? zero.w : vector.w);
			float @float = material.GetFloat(ShaderUtilities.ID_GradientScale);
			vector *= @float;
			num10 = Mathf.Max(vector.x, vector.y);
			num10 = Mathf.Max(vector.z, num10);
			num10 = Mathf.Max(vector.w, num10);
			return num10 + 0.5f;
		}

		// Token: 0x06002DA4 RID: 11684 RVA: 0x001132F4 File Offset: 0x001114F4
		public static float GetPadding(Material[] materials, bool enableExtraPadding, bool isBold)
		{
			if (!ShaderUtilities.isInitialized)
			{
				ShaderUtilities.GetShaderPropertyIDs();
			}
			if (materials == null)
			{
				return 0f;
			}
			int num = ((!enableExtraPadding) ? 0 : 4);
			if (!materials[0].HasProperty(ShaderUtilities.ID_GradientScale))
			{
				return (float)num;
			}
			Vector4 vector = Vector4.zero;
			Vector4 zero = Vector4.zero;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10;
			for (int i = 0; i < materials.Length; i++)
			{
				ShaderUtilities.UpdateShaderRatios(materials[i], isBold);
				string[] shaderKeywords = materials[i].shaderKeywords;
				if (materials[i].HasProperty(ShaderUtilities.ID_ScaleRatio_A))
				{
					num5 = materials[i].GetFloat(ShaderUtilities.ID_ScaleRatio_A);
				}
				if (materials[i].HasProperty(ShaderUtilities.ID_FaceDilate))
				{
					num2 = materials[i].GetFloat(ShaderUtilities.ID_FaceDilate) * num5;
				}
				if (materials[i].HasProperty(ShaderUtilities.ID_OutlineSoftness))
				{
					num3 = materials[i].GetFloat(ShaderUtilities.ID_OutlineSoftness) * num5;
				}
				if (materials[i].HasProperty(ShaderUtilities.ID_OutlineWidth))
				{
					num4 = materials[i].GetFloat(ShaderUtilities.ID_OutlineWidth) * num5;
				}
				num10 = num4 + num3 + num2;
				if (materials[i].HasProperty(ShaderUtilities.ID_GlowOffset) && shaderKeywords.Contains(ShaderUtilities.Keyword_Glow))
				{
					if (materials[i].HasProperty(ShaderUtilities.ID_ScaleRatio_B))
					{
						num6 = materials[i].GetFloat(ShaderUtilities.ID_ScaleRatio_B);
					}
					num8 = materials[i].GetFloat(ShaderUtilities.ID_GlowOffset) * num6;
					num9 = materials[i].GetFloat(ShaderUtilities.ID_GlowOuter) * num6;
				}
				num10 = Mathf.Max(num10, num2 + num8 + num9);
				if (materials[i].HasProperty(ShaderUtilities.ID_UnderlaySoftness) && shaderKeywords.Contains(ShaderUtilities.Keyword_Underlay))
				{
					if (materials[i].HasProperty(ShaderUtilities.ID_ScaleRatio_C))
					{
						num7 = materials[i].GetFloat(ShaderUtilities.ID_ScaleRatio_C);
					}
					float num11 = materials[i].GetFloat(ShaderUtilities.ID_UnderlayOffsetX) * num7;
					float num12 = materials[i].GetFloat(ShaderUtilities.ID_UnderlayOffsetY) * num7;
					float num13 = materials[i].GetFloat(ShaderUtilities.ID_UnderlayDilate) * num7;
					float num14 = materials[i].GetFloat(ShaderUtilities.ID_UnderlaySoftness) * num7;
					vector.x = Mathf.Max(vector.x, num2 + num13 + num14 - num11);
					vector.y = Mathf.Max(vector.y, num2 + num13 + num14 - num12);
					vector.z = Mathf.Max(vector.z, num2 + num13 + num14 + num11);
					vector.w = Mathf.Max(vector.w, num2 + num13 + num14 + num12);
				}
				vector.x = Mathf.Max(vector.x, num10);
				vector.y = Mathf.Max(vector.y, num10);
				vector.z = Mathf.Max(vector.z, num10);
				vector.w = Mathf.Max(vector.w, num10);
				vector.x += (float)num;
				vector.y += (float)num;
				vector.z += (float)num;
				vector.w += (float)num;
				vector.x = Mathf.Min(vector.x, 1f);
				vector.y = Mathf.Min(vector.y, 1f);
				vector.z = Mathf.Min(vector.z, 1f);
				vector.w = Mathf.Min(vector.w, 1f);
				zero.x = ((zero.x >= vector.x) ? zero.x : vector.x);
				zero.y = ((zero.y >= vector.y) ? zero.y : vector.y);
				zero.z = ((zero.z >= vector.z) ? zero.z : vector.z);
				zero.w = ((zero.w >= vector.w) ? zero.w : vector.w);
			}
			float @float = materials[0].GetFloat(ShaderUtilities.ID_GradientScale);
			vector *= @float;
			num10 = Mathf.Max(vector.x, vector.y);
			num10 = Mathf.Max(vector.z, num10);
			num10 = Mathf.Max(vector.w, num10);
			return num10 + 0.25f;
		}

		// Token: 0x04003236 RID: 12854
		public static int ID_MainTex;

		// Token: 0x04003237 RID: 12855
		public static int ID_FaceTex;

		// Token: 0x04003238 RID: 12856
		public static int ID_FaceColor;

		// Token: 0x04003239 RID: 12857
		public static int ID_FaceDilate;

		// Token: 0x0400323A RID: 12858
		public static int ID_Shininess;

		// Token: 0x0400323B RID: 12859
		public static int ID_UnderlayColor;

		// Token: 0x0400323C RID: 12860
		public static int ID_UnderlayOffsetX;

		// Token: 0x0400323D RID: 12861
		public static int ID_UnderlayOffsetY;

		// Token: 0x0400323E RID: 12862
		public static int ID_UnderlayDilate;

		// Token: 0x0400323F RID: 12863
		public static int ID_UnderlaySoftness;

		// Token: 0x04003240 RID: 12864
		public static int ID_WeightNormal;

		// Token: 0x04003241 RID: 12865
		public static int ID_WeightBold;

		// Token: 0x04003242 RID: 12866
		public static int ID_OutlineTex;

		// Token: 0x04003243 RID: 12867
		public static int ID_OutlineWidth;

		// Token: 0x04003244 RID: 12868
		public static int ID_OutlineSoftness;

		// Token: 0x04003245 RID: 12869
		public static int ID_OutlineColor;

		// Token: 0x04003246 RID: 12870
		public static int ID_GradientScale;

		// Token: 0x04003247 RID: 12871
		public static int ID_ScaleX;

		// Token: 0x04003248 RID: 12872
		public static int ID_ScaleY;

		// Token: 0x04003249 RID: 12873
		public static int ID_PerspectiveFilter;

		// Token: 0x0400324A RID: 12874
		public static int ID_TextureWidth;

		// Token: 0x0400324B RID: 12875
		public static int ID_TextureHeight;

		// Token: 0x0400324C RID: 12876
		public static int ID_BevelAmount;

		// Token: 0x0400324D RID: 12877
		public static int ID_GlowColor;

		// Token: 0x0400324E RID: 12878
		public static int ID_GlowOffset;

		// Token: 0x0400324F RID: 12879
		public static int ID_GlowPower;

		// Token: 0x04003250 RID: 12880
		public static int ID_GlowOuter;

		// Token: 0x04003251 RID: 12881
		public static int ID_LightAngle;

		// Token: 0x04003252 RID: 12882
		public static int ID_EnvMap;

		// Token: 0x04003253 RID: 12883
		public static int ID_EnvMatrix;

		// Token: 0x04003254 RID: 12884
		public static int ID_EnvMatrixRotation;

		// Token: 0x04003255 RID: 12885
		public static int ID_MaskCoord;

		// Token: 0x04003256 RID: 12886
		public static int ID_ClipRect;

		// Token: 0x04003257 RID: 12887
		public static int ID_MaskSoftnessX;

		// Token: 0x04003258 RID: 12888
		public static int ID_MaskSoftnessY;

		// Token: 0x04003259 RID: 12889
		public static int ID_VertexOffsetX;

		// Token: 0x0400325A RID: 12890
		public static int ID_VertexOffsetY;

		// Token: 0x0400325B RID: 12891
		public static int ID_UseClipRect;

		// Token: 0x0400325C RID: 12892
		public static int ID_StencilID;

		// Token: 0x0400325D RID: 12893
		public static int ID_StencilOp;

		// Token: 0x0400325E RID: 12894
		public static int ID_StencilComp;

		// Token: 0x0400325F RID: 12895
		public static int ID_StencilReadMask;

		// Token: 0x04003260 RID: 12896
		public static int ID_StencilWriteMask;

		// Token: 0x04003261 RID: 12897
		public static int ID_ShaderFlags;

		// Token: 0x04003262 RID: 12898
		public static int ID_ScaleRatio_A;

		// Token: 0x04003263 RID: 12899
		public static int ID_ScaleRatio_B;

		// Token: 0x04003264 RID: 12900
		public static int ID_ScaleRatio_C;

		// Token: 0x04003265 RID: 12901
		public static string Keyword_Bevel = "BEVEL_ON";

		// Token: 0x04003266 RID: 12902
		public static string Keyword_Glow = "GLOW_ON";

		// Token: 0x04003267 RID: 12903
		public static string Keyword_Underlay = "UNDERLAY_ON";

		// Token: 0x04003268 RID: 12904
		public static string Keyword_Ratios = "RATIOS_OFF";

		// Token: 0x04003269 RID: 12905
		public static string Keyword_MASK_SOFT = "MASK_SOFT";

		// Token: 0x0400326A RID: 12906
		public static string Keyword_MASK_HARD = "MASK_HARD";

		// Token: 0x0400326B RID: 12907
		public static string Keyword_MASK_TEX = "MASK_TEX";

		// Token: 0x0400326C RID: 12908
		public static string Keyword_Outline = "OUTLINE_ON";

		// Token: 0x0400326D RID: 12909
		public static string ShaderTag_ZTestMode = "unity_GUIZTestMode";

		// Token: 0x0400326E RID: 12910
		public static string ShaderTag_CullMode = "_CullMode";

		// Token: 0x0400326F RID: 12911
		private static float m_clamp = 1f;

		// Token: 0x04003270 RID: 12912
		public static bool isInitialized;
	}
}

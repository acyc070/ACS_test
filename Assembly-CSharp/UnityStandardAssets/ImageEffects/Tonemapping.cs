using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200065A RID: 1626
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Color Adjustments/Tonemapping")]
	public class Tonemapping : VPostEffectsBase
	{
		// Token: 0x06002DCC RID: 11724 RVA: 0x001160A8 File Offset: 0x001142A8
		public override bool CheckResources()
		{
			base.CheckSupport(false, true);
			this.tonemapMaterial = base.CheckShaderAndCreateMaterial(this.tonemapper, this.tonemapMaterial);
			if (!this.curveTex && this.type == Tonemapping.TonemapperType.UserCurve)
			{
				this.curveTex = new Texture2D(256, 1, TextureFormat.ARGB32, false, true);
				this.curveTex.filterMode = FilterMode.Bilinear;
				this.curveTex.wrapMode = TextureWrapMode.Clamp;
				this.curveTex.hideFlags = HideFlags.DontSave;
			}
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06002DCD RID: 11725 RVA: 0x00116144 File Offset: 0x00114344
		public float UpdateCurve()
		{
			float num = 1f;
			if (this.remapCurve.keys.Length < 1)
			{
				this.remapCurve = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(2f, 1f)
				});
			}
			if (this.remapCurve != null)
			{
				if (this.remapCurve.length > 0)
				{
					num = this.remapCurve[this.remapCurve.length - 1].time;
				}
				for (float num2 = 0f; num2 <= 1f; num2 += 0.003921569f)
				{
					float num3 = this.remapCurve.Evaluate(num2 * 1f * num);
					this.curveTex.SetPixel((int)Mathf.Floor(num2 * 255f), 0, new Color(num3, num3, num3));
				}
				this.curveTex.Apply();
			}
			return 1f / num;
		}

		// Token: 0x06002DCE RID: 11726 RVA: 0x00116254 File Offset: 0x00114454
		private void OnDisable()
		{
			if (this.rt)
			{
				global::UnityEngine.Object.DestroyImmediate(this.rt);
				this.rt = null;
			}
			if (this.tonemapMaterial)
			{
				global::UnityEngine.Object.DestroyImmediate(this.tonemapMaterial);
				this.tonemapMaterial = null;
			}
			if (this.curveTex)
			{
				global::UnityEngine.Object.DestroyImmediate(this.curveTex);
				this.curveTex = null;
			}
		}

		// Token: 0x06002DCF RID: 11727 RVA: 0x001162C8 File Offset: 0x001144C8
		private bool CreateInternalRenderTexture()
		{
			if (this.rt)
			{
				return false;
			}
			this.rtFormat = ((!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGHalf)) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.RGHalf);
			this.rt = new RenderTexture(1, 1, 0, this.rtFormat);
			this.rt.hideFlags = HideFlags.DontSave;
			return true;
		}

		// Token: 0x06002DD0 RID: 11728 RVA: 0x00116324 File Offset: 0x00114524
		[ImageEffectTransformsToLDR]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			this.exposureAdjustment = ((this.exposureAdjustment >= 0.001f) ? this.exposureAdjustment : 0.001f);
			if (this.type == Tonemapping.TonemapperType.UserCurve)
			{
				float num = this.UpdateCurve();
				this.tonemapMaterial.SetFloat("_RangeScale", num);
				this.tonemapMaterial.SetTexture("_Curve", this.curveTex);
				Graphics.Blit(source, destination, this.tonemapMaterial, 4);
				return;
			}
			if (this.type == Tonemapping.TonemapperType.SimpleReinhard)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 6);
				return;
			}
			if (this.type == Tonemapping.TonemapperType.Hable)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 5);
				return;
			}
			if (this.type == Tonemapping.TonemapperType.Photographic)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 8);
				return;
			}
			if (this.type == Tonemapping.TonemapperType.OptimizedHejiDawson)
			{
				this.tonemapMaterial.SetFloat("_ExposureAdjustment", 0.5f * this.exposureAdjustment);
				Graphics.Blit(source, destination, this.tonemapMaterial, 7);
				return;
			}
			bool flag = this.CreateInternalRenderTexture();
			RenderTexture temporary = RenderTexture.GetTemporary((int)this.adaptiveTextureSize, (int)this.adaptiveTextureSize, 0, this.rtFormat);
			Graphics.Blit(source, temporary);
			int num2 = (int)Mathf.Log((float)temporary.width * 1f, 2f);
			int num3 = 2;
			RenderTexture[] array = new RenderTexture[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i] = RenderTexture.GetTemporary(temporary.width / num3, temporary.width / num3, 0, this.rtFormat);
				num3 *= 2;
			}
			RenderTexture renderTexture = array[num2 - 1];
			Graphics.Blit(temporary, array[0], this.tonemapMaterial, 1);
			if (this.type == Tonemapping.TonemapperType.AdaptiveReinhardAutoWhite)
			{
				for (int j = 0; j < num2 - 1; j++)
				{
					Graphics.Blit(array[j], array[j + 1], this.tonemapMaterial, 9);
					renderTexture = array[j + 1];
				}
			}
			else if (this.type == Tonemapping.TonemapperType.AdaptiveReinhard)
			{
				for (int k = 0; k < num2 - 1; k++)
				{
					Graphics.Blit(array[k], array[k + 1]);
					renderTexture = array[k + 1];
				}
			}
			this.adaptionSpeed = ((this.adaptionSpeed >= 0.001f) ? this.adaptionSpeed : 0.001f);
			this.tonemapMaterial.SetFloat("_AdaptionSpeed", this.adaptionSpeed);
			this.rt.MarkRestoreExpected();
			Graphics.Blit(renderTexture, this.rt, this.tonemapMaterial, (!flag) ? 2 : 3);
			this.middleGrey = ((this.middleGrey >= 0.001f) ? this.middleGrey : 0.001f);
			this.tonemapMaterial.SetVector("_HdrParams", new Vector4(this.middleGrey, this.middleGrey, this.middleGrey, this.white * this.white));
			this.tonemapMaterial.SetTexture("_SmallTex", this.rt);
			if (this.type == Tonemapping.TonemapperType.AdaptiveReinhard)
			{
				Graphics.Blit(source, destination, this.tonemapMaterial, 0);
			}
			else if (this.type == Tonemapping.TonemapperType.AdaptiveReinhardAutoWhite)
			{
				Graphics.Blit(source, destination, this.tonemapMaterial, 10);
			}
			else
			{
				Debug.LogError("No valid adaptive tonemapper type found!");
				Graphics.Blit(source, destination);
			}
			for (int l = 0; l < num2; l++)
			{
				RenderTexture.ReleaseTemporary(array[l]);
			}
			RenderTexture.ReleaseTemporary(temporary);
		}

		// Token: 0x0400329E RID: 12958
		public Tonemapping.TonemapperType type = Tonemapping.TonemapperType.Photographic;

		// Token: 0x0400329F RID: 12959
		public Tonemapping.AdaptiveTexSize adaptiveTextureSize = Tonemapping.AdaptiveTexSize.Square256;

		// Token: 0x040032A0 RID: 12960
		public AnimationCurve remapCurve;

		// Token: 0x040032A1 RID: 12961
		private Texture2D curveTex;

		// Token: 0x040032A2 RID: 12962
		public float exposureAdjustment = 1.5f;

		// Token: 0x040032A3 RID: 12963
		public float middleGrey = 0.4f;

		// Token: 0x040032A4 RID: 12964
		public float white = 2f;

		// Token: 0x040032A5 RID: 12965
		public float adaptionSpeed = 1.5f;

		// Token: 0x040032A6 RID: 12966
		public Shader tonemapper;

		// Token: 0x040032A7 RID: 12967
		public bool validRenderTextureFormat = true;

		// Token: 0x040032A8 RID: 12968
		private Material tonemapMaterial;

		// Token: 0x040032A9 RID: 12969
		private RenderTexture rt;

		// Token: 0x040032AA RID: 12970
		private RenderTextureFormat rtFormat = RenderTextureFormat.ARGBHalf;

		// Token: 0x0200065B RID: 1627
		public enum TonemapperType
		{
			// Token: 0x040032AC RID: 12972
			SimpleReinhard,
			// Token: 0x040032AD RID: 12973
			UserCurve,
			// Token: 0x040032AE RID: 12974
			Hable,
			// Token: 0x040032AF RID: 12975
			Photographic,
			// Token: 0x040032B0 RID: 12976
			OptimizedHejiDawson,
			// Token: 0x040032B1 RID: 12977
			AdaptiveReinhard,
			// Token: 0x040032B2 RID: 12978
			AdaptiveReinhardAutoWhite
		}

		// Token: 0x0200065C RID: 1628
		public enum AdaptiveTexSize
		{
			// Token: 0x040032B4 RID: 12980
			Square16 = 16,
			// Token: 0x040032B5 RID: 12981
			Square32 = 32,
			// Token: 0x040032B6 RID: 12982
			Square64 = 64,
			// Token: 0x040032B7 RID: 12983
			Square128 = 128,
			// Token: 0x040032B8 RID: 12984
			Square256 = 256,
			// Token: 0x040032B9 RID: 12985
			Square512 = 512,
			// Token: 0x040032BA RID: 12986
			Square1024 = 1024
		}
	}
}

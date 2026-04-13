using System;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x02000623 RID: 1571
	[ExecuteInEditMode]
	public class TMP_SubMeshUI : MaskableGraphic, ITextElement, IClippable, IMaskable, IMaterialModifier
	{
		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06002C24 RID: 11300 RVA: 0x0001F8CA File Offset: 0x0001DACA
		// (set) Token: 0x06002C25 RID: 11301 RVA: 0x0001F8D2 File Offset: 0x0001DAD2
		public TMP_FontAsset fontAsset
		{
			get
			{
				return this.m_fontAsset;
			}
			set
			{
				this.m_fontAsset = value;
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06002C26 RID: 11302 RVA: 0x0001F8DB File Offset: 0x0001DADB
		// (set) Token: 0x06002C27 RID: 11303 RVA: 0x0001F8E3 File Offset: 0x0001DAE3
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

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06002C28 RID: 11304 RVA: 0x0001F8EC File Offset: 0x0001DAEC
		public override Texture mainTexture
		{
			get
			{
				if (this.sharedMaterial != null)
				{
					return this.sharedMaterial.mainTexture;
				}
				return null;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06002C29 RID: 11305 RVA: 0x0001F90C File Offset: 0x0001DB0C
		// (set) Token: 0x06002C2A RID: 11306 RVA: 0x001073D8 File Offset: 0x001055D8
		public override Material material
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
				this.m_material = value;
				this.m_sharedMaterial = value;
				this.m_padding = this.GetPaddingForMaterial();
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06002C2B RID: 11307 RVA: 0x0001F91A File Offset: 0x0001DB1A
		// (set) Token: 0x06002C2C RID: 11308 RVA: 0x0001F922 File Offset: 0x0001DB22
		public Material sharedMaterial
		{
			get
			{
				return this.m_sharedMaterial;
			}
			set
			{
				this.SetSharedMaterial(value);
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06002C2D RID: 11309 RVA: 0x0001F92B File Offset: 0x0001DB2B
		// (set) Token: 0x06002C2E RID: 11310 RVA: 0x00107438 File Offset: 0x00105638
		public Material fallbackMaterial
		{
			get
			{
				return this.m_fallbackMaterial;
			}
			set
			{
				if (this.m_fallbackMaterial == value)
				{
					return;
				}
				if (this.m_fallbackMaterial != null && this.m_fallbackMaterial != value)
				{
					TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				}
				this.m_fallbackMaterial = value;
				TMP_MaterialManager.AddFallbackMaterialReference(this.m_fallbackMaterial);
				this.SetSharedMaterial(this.m_fallbackMaterial);
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06002C2F RID: 11311 RVA: 0x0001F933 File Offset: 0x0001DB33
		// (set) Token: 0x06002C30 RID: 11312 RVA: 0x0001F93B File Offset: 0x0001DB3B
		public Material fallbackSourceMaterial
		{
			get
			{
				return this.m_fallbackSourceMaterial;
			}
			set
			{
				this.m_fallbackSourceMaterial = value;
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06002C31 RID: 11313 RVA: 0x0001F944 File Offset: 0x0001DB44
		public override Material materialForRendering
		{
			get
			{
				if (this.m_sharedMaterial == null)
				{
					return null;
				}
				return this.GetModifiedMaterial(this.m_sharedMaterial);
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06002C32 RID: 11314 RVA: 0x0001F965 File Offset: 0x0001DB65
		// (set) Token: 0x06002C33 RID: 11315 RVA: 0x0001F96D File Offset: 0x0001DB6D
		public bool isDefaultMaterial
		{
			get
			{
				return this.m_isDefaultMaterial;
			}
			set
			{
				this.m_isDefaultMaterial = value;
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06002C34 RID: 11316 RVA: 0x0001F976 File Offset: 0x0001DB76
		// (set) Token: 0x06002C35 RID: 11317 RVA: 0x0001F97E File Offset: 0x0001DB7E
		public float padding
		{
			get
			{
				return this.m_padding;
			}
			set
			{
				this.m_padding = value;
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06002C36 RID: 11318 RVA: 0x0001F987 File Offset: 0x0001DB87
		public new CanvasRenderer canvasRenderer
		{
			get
			{
				if (this.m_canvasRenderer == null)
				{
					this.m_canvasRenderer = base.GetComponent<CanvasRenderer>();
				}
				return this.m_canvasRenderer;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06002C37 RID: 11319 RVA: 0x0001F9AC File Offset: 0x0001DBAC
		// (set) Token: 0x06002C38 RID: 11320 RVA: 0x0001F9DD File Offset: 0x0001DBDD
		public Mesh mesh
		{
			get
			{
				if (this.m_mesh == null)
				{
					this.m_mesh = new Mesh();
					this.m_mesh.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_mesh;
			}
			set
			{
				this.m_mesh = value;
			}
		}

		// Token: 0x06002C39 RID: 11321 RVA: 0x001074A4 File Offset: 0x001056A4
		public static TMP_SubMeshUI AddSubTextObject(TextMeshProUGUI textComponent, MaterialReference materialReference)
		{
			GameObject gameObject = new GameObject("TMP UI SubObject [" + materialReference.material.name + "]");
			gameObject.transform.SetParent(textComponent.transform, false);
			gameObject.layer = textComponent.gameObject.layer;
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.sizeDelta = Vector2.zero;
			rectTransform.pivot = textComponent.rectTransform.pivot;
			TMP_SubMeshUI tmp_SubMeshUI = gameObject.AddComponent<TMP_SubMeshUI>();
			tmp_SubMeshUI.m_canvasRenderer = tmp_SubMeshUI.canvasRenderer;
			tmp_SubMeshUI.m_TextComponent = textComponent;
			tmp_SubMeshUI.m_materialReferenceIndex = materialReference.index;
			tmp_SubMeshUI.m_fontAsset = materialReference.fontAsset;
			tmp_SubMeshUI.m_spriteAsset = materialReference.spriteAsset;
			tmp_SubMeshUI.m_isDefaultMaterial = materialReference.isDefaultMaterial;
			tmp_SubMeshUI.SetSharedMaterial(materialReference.material);
			return tmp_SubMeshUI;
		}

		// Token: 0x06002C3A RID: 11322 RVA: 0x0001F9E6 File Offset: 0x0001DBE6
		protected override void OnEnable()
		{
			if (!this.m_isRegisteredForEvents)
			{
				this.m_isRegisteredForEvents = true;
			}
			this.m_ShouldRecalculateStencil = true;
			this.RecalculateClipping();
			this.RecalculateMasking();
		}

		// Token: 0x06002C3B RID: 11323 RVA: 0x0010758C File Offset: 0x0010578C
		protected override void OnDisable()
		{
			TMP_UpdateRegistry.UnRegisterCanvasElementForRebuild(this);
			if (this.m_MaskMaterial != null)
			{
				TMP_MaterialManager.ReleaseStencilMaterial(this.m_MaskMaterial);
				this.m_MaskMaterial = null;
			}
			if (this.m_fallbackMaterial != null)
			{
				TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				this.m_fallbackMaterial = null;
			}
			base.OnDisable();
		}

		// Token: 0x06002C3C RID: 11324 RVA: 0x001075EC File Offset: 0x001057EC
		protected override void OnDestroy()
		{
			if (this.m_mesh != null)
			{
				global::UnityEngine.Object.DestroyImmediate(this.m_mesh);
			}
			if (this.m_MaskMaterial != null)
			{
				TMP_MaterialManager.ReleaseStencilMaterial(this.m_MaskMaterial);
			}
			if (this.m_fallbackMaterial != null)
			{
				TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				this.m_fallbackMaterial = null;
			}
			this.m_isRegisteredForEvents = false;
			this.RecalculateClipping();
		}

		// Token: 0x06002C3D RID: 11325 RVA: 0x0001FA0D File Offset: 0x0001DC0D
		protected override void OnTransformParentChanged()
		{
			if (!this.IsActive())
			{
				return;
			}
			this.m_ShouldRecalculateStencil = true;
			this.RecalculateClipping();
			this.RecalculateMasking();
		}

		// Token: 0x06002C3E RID: 11326 RVA: 0x00107664 File Offset: 0x00105864
		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			Material material = baseMaterial;
			if (this.m_ShouldRecalculateStencil)
			{
				this.m_StencilValue = TMP_MaterialManager.GetStencilID(base.gameObject);
				this.m_ShouldRecalculateStencil = false;
			}
			if (this.m_StencilValue > 0)
			{
				material = TMP_MaterialManager.GetStencilMaterial(baseMaterial, this.m_StencilValue);
				if (this.m_MaskMaterial != null)
				{
					TMP_MaterialManager.ReleaseStencilMaterial(this.m_MaskMaterial);
				}
				this.m_MaskMaterial = material;
			}
			return material;
		}

		// Token: 0x06002C3F RID: 11327 RVA: 0x001076D4 File Offset: 0x001058D4
		public float GetPaddingForMaterial()
		{
			return ShaderUtilities.GetPadding(this.m_sharedMaterial, this.m_TextComponent.extraPadding, this.m_TextComponent.isUsingBold);
		}

		// Token: 0x06002C40 RID: 11328 RVA: 0x00107704 File Offset: 0x00105904
		public float GetPaddingForMaterial(Material mat)
		{
			return ShaderUtilities.GetPadding(mat, this.m_TextComponent.extraPadding, this.m_TextComponent.isUsingBold);
		}

		// Token: 0x06002C41 RID: 11329 RVA: 0x0001FA2E File Offset: 0x0001DC2E
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
			this.m_padding = ShaderUtilities.GetPadding(this.m_sharedMaterial, isExtraPadding, isUsingBold);
		}

		// Token: 0x06002C42 RID: 11330 RVA: 0x00002482 File Offset: 0x00000682
		public override void SetAllDirty()
		{
		}

		// Token: 0x06002C43 RID: 11331 RVA: 0x0001FA43 File Offset: 0x0001DC43
		public override void SetVerticesDirty()
		{
			if (!this.IsActive())
			{
				return;
			}
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.havePropertiesChanged = true;
				this.m_TextComponent.SetVerticesDirty();
			}
		}

		// Token: 0x06002C44 RID: 11332 RVA: 0x00002482 File Offset: 0x00000682
		public override void SetLayoutDirty()
		{
		}

		// Token: 0x06002C45 RID: 11333 RVA: 0x0001FA79 File Offset: 0x0001DC79
		public override void SetMaterialDirty()
		{
			this.m_materialDirty = true;
			this.UpdateMaterial();
		}

		// Token: 0x06002C46 RID: 11334 RVA: 0x0001FA88 File Offset: 0x0001DC88
		public void SetPivotDirty()
		{
			if (!this.IsActive())
			{
				return;
			}
			base.rectTransform.pivot = this.m_TextComponent.rectTransform.pivot;
		}

		// Token: 0x06002C47 RID: 11335 RVA: 0x00002482 File Offset: 0x00000682
		protected override void UpdateGeometry()
		{
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x0001FAB1 File Offset: 0x0001DCB1
		public override void Rebuild(CanvasUpdate update)
		{
			if (update == CanvasUpdate.PreRender)
			{
				if (!this.m_materialDirty)
				{
					return;
				}
				this.UpdateMaterial();
				this.m_materialDirty = false;
			}
		}

		// Token: 0x06002C49 RID: 11337 RVA: 0x0001E1AA File Offset: 0x0001C3AA
		public void RefreshMaterial()
		{
			this.UpdateMaterial();
		}

		// Token: 0x06002C4A RID: 11338 RVA: 0x00107730 File Offset: 0x00105930
		protected override void UpdateMaterial()
		{
			if (this.m_canvasRenderer == null)
			{
				this.m_canvasRenderer = this.canvasRenderer;
			}
			this.m_canvasRenderer.materialCount = 1;
			this.m_canvasRenderer.SetMaterial(this.materialForRendering, 0);
			this.m_canvasRenderer.SetTexture(this.mainTexture);
		}

		// Token: 0x06002C4B RID: 11339 RVA: 0x0001E4B4 File Offset: 0x0001C6B4
		public override void RecalculateClipping()
		{
			base.RecalculateClipping();
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x0001E4BC File Offset: 0x0001C6BC
		public override void RecalculateMasking()
		{
			this.m_ShouldRecalculateStencil = true;
			this.SetMaterialDirty();
		}

		// Token: 0x06002C4D RID: 11341 RVA: 0x0001F91A File Offset: 0x0001DB1A
		private Material GetMaterial()
		{
			return this.m_sharedMaterial;
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x0010778C File Offset: 0x0010598C
		private Material GetMaterial(Material mat)
		{
			if (this.m_material == null || this.m_material.GetInstanceID() != mat.GetInstanceID())
			{
				this.m_material = this.CreateMaterialInstance(mat);
			}
			this.m_sharedMaterial = this.m_material;
			this.m_padding = this.GetPaddingForMaterial();
			this.SetVerticesDirty();
			this.SetMaterialDirty();
			return this.m_sharedMaterial;
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x00107370 File Offset: 0x00105570
		private Material CreateMaterialInstance(Material source)
		{
			Material material = new Material(source);
			material.shaderKeywords = source.shaderKeywords;
			Material material2 = material;
			material2.name += " (Instance)";
			return material;
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x0001FAD3 File Offset: 0x0001DCD3
		private Material GetSharedMaterial()
		{
			if (this.m_canvasRenderer == null)
			{
				this.m_canvasRenderer = base.GetComponent<CanvasRenderer>();
			}
			return this.m_canvasRenderer.GetMaterial();
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x0001FAFD File Offset: 0x0001DCFD
		private void SetSharedMaterial(Material mat)
		{
			this.m_sharedMaterial = mat;
			this.m_Material = this.m_sharedMaterial;
			this.m_padding = this.GetPaddingForMaterial();
			this.SetMaterialDirty();
		}

		// Token: 0x06002C52 RID: 11346 RVA: 0x0001FB24 File Offset: 0x0001DD24
		int ITextElement.GetInstanceID()
		{
			return base.GetInstanceID();
		}

		// Token: 0x0400302B RID: 12331
		[SerializeField]
		private TMP_FontAsset m_fontAsset;

		// Token: 0x0400302C RID: 12332
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset;

		// Token: 0x0400302D RID: 12333
		[SerializeField]
		private Material m_material;

		// Token: 0x0400302E RID: 12334
		[SerializeField]
		private Material m_sharedMaterial;

		// Token: 0x0400302F RID: 12335
		private Material m_fallbackMaterial;

		// Token: 0x04003030 RID: 12336
		private Material m_fallbackSourceMaterial;

		// Token: 0x04003031 RID: 12337
		[SerializeField]
		private bool m_isDefaultMaterial;

		// Token: 0x04003032 RID: 12338
		[SerializeField]
		private float m_padding;

		// Token: 0x04003033 RID: 12339
		[SerializeField]
		private CanvasRenderer m_canvasRenderer;

		// Token: 0x04003034 RID: 12340
		private Mesh m_mesh;

		// Token: 0x04003035 RID: 12341
		[SerializeField]
		private TextMeshProUGUI m_TextComponent;

		// Token: 0x04003036 RID: 12342
		[NonSerialized]
		private bool m_isRegisteredForEvents;

		// Token: 0x04003037 RID: 12343
		private bool m_materialDirty;

		// Token: 0x04003038 RID: 12344
		[SerializeField]
		private int m_materialReferenceIndex;
	}
}

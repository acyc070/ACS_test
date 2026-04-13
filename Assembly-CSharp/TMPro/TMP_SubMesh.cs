using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000622 RID: 1570
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	public class TMP_SubMesh : MonoBehaviour
	{
		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06002C01 RID: 11265 RVA: 0x0001F6F0 File Offset: 0x0001D8F0
		// (set) Token: 0x06002C02 RID: 11266 RVA: 0x0001F6F8 File Offset: 0x0001D8F8
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

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06002C03 RID: 11267 RVA: 0x0001F701 File Offset: 0x0001D901
		// (set) Token: 0x06002C04 RID: 11268 RVA: 0x0001F709 File Offset: 0x0001D909
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

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06002C05 RID: 11269 RVA: 0x0001F712 File Offset: 0x0001D912
		// (set) Token: 0x06002C06 RID: 11270 RVA: 0x00107024 File Offset: 0x00105224
		public Material material
		{
			get
			{
				return this.GetMaterial(this.m_sharedMaterial);
			}
			set
			{
				if (this.m_sharedMaterial.GetInstanceID() == value.GetInstanceID())
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

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06002C07 RID: 11271 RVA: 0x0001F720 File Offset: 0x0001D920
		// (set) Token: 0x06002C08 RID: 11272 RVA: 0x0001F728 File Offset: 0x0001D928
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

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06002C09 RID: 11273 RVA: 0x0001F731 File Offset: 0x0001D931
		// (set) Token: 0x06002C0A RID: 11274 RVA: 0x00107070 File Offset: 0x00105270
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

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06002C0B RID: 11275 RVA: 0x0001F739 File Offset: 0x0001D939
		// (set) Token: 0x06002C0C RID: 11276 RVA: 0x0001F741 File Offset: 0x0001D941
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

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06002C0D RID: 11277 RVA: 0x0001F74A File Offset: 0x0001D94A
		// (set) Token: 0x06002C0E RID: 11278 RVA: 0x0001F752 File Offset: 0x0001D952
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

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06002C0F RID: 11279 RVA: 0x0001F75B File Offset: 0x0001D95B
		// (set) Token: 0x06002C10 RID: 11280 RVA: 0x0001F763 File Offset: 0x0001D963
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

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06002C11 RID: 11281 RVA: 0x0001F76C File Offset: 0x0001D96C
		public Renderer renderer
		{
			get
			{
				if (this.m_renderer == null)
				{
					this.m_renderer = base.GetComponent<Renderer>();
				}
				return this.m_renderer;
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06002C12 RID: 11282 RVA: 0x0001F791 File Offset: 0x0001D991
		public MeshFilter meshFilter
		{
			get
			{
				if (this.m_meshFilter == null)
				{
					this.m_meshFilter = base.GetComponent<MeshFilter>();
				}
				return this.m_meshFilter;
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06002C13 RID: 11283 RVA: 0x001070DC File Offset: 0x001052DC
		// (set) Token: 0x06002C14 RID: 11284 RVA: 0x0001F7B6 File Offset: 0x0001D9B6
		public Mesh mesh
		{
			get
			{
				if (this.m_mesh == null)
				{
					this.m_mesh = new Mesh();
					this.m_mesh.hideFlags = HideFlags.HideAndDontSave;
					this.meshFilter.mesh = this.m_mesh;
				}
				return this.m_mesh;
			}
			set
			{
				this.m_mesh = value;
			}
		}

		// Token: 0x06002C15 RID: 11285 RVA: 0x0010712C File Offset: 0x0010532C
		private void OnEnable()
		{
			if (!this.m_isRegisteredForEvents)
			{
				this.m_isRegisteredForEvents = true;
			}
			this.meshFilter.sharedMesh = this.mesh;
			if (this.m_sharedMaterial != null)
			{
				this.m_sharedMaterial.SetVector(ShaderUtilities.ID_ClipRect, new Vector4(-10000f, -10000f, 10000f, 10000f));
			}
		}

		// Token: 0x06002C16 RID: 11286 RVA: 0x0001F7BF File Offset: 0x0001D9BF
		private void OnDisable()
		{
			this.m_meshFilter.sharedMesh = null;
			if (this.m_fallbackMaterial != null)
			{
				TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				this.m_fallbackMaterial = null;
			}
		}

		// Token: 0x06002C17 RID: 11287 RVA: 0x00107198 File Offset: 0x00105398
		private void OnDestroy()
		{
			if (this.m_mesh != null)
			{
				global::UnityEngine.Object.DestroyImmediate(this.m_mesh);
			}
			if (this.m_fallbackMaterial != null)
			{
				TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				this.m_fallbackMaterial = null;
			}
			this.m_isRegisteredForEvents = false;
		}

		// Token: 0x06002C18 RID: 11288 RVA: 0x001071EC File Offset: 0x001053EC
		public static TMP_SubMesh AddSubTextObject(TextMeshPro textComponent, MaterialReference materialReference)
		{
			GameObject gameObject = new GameObject("TMP SubMesh [" + materialReference.material.name + "]");
			TMP_SubMesh tmp_SubMesh = gameObject.AddComponent<TMP_SubMesh>();
			gameObject.transform.SetParent(textComponent.transform, false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			gameObject.layer = textComponent.gameObject.layer;
			tmp_SubMesh.m_meshFilter = gameObject.GetComponent<MeshFilter>();
			tmp_SubMesh.m_TextComponent = textComponent;
			tmp_SubMesh.m_fontAsset = materialReference.fontAsset;
			tmp_SubMesh.m_spriteAsset = materialReference.spriteAsset;
			tmp_SubMesh.m_isDefaultMaterial = materialReference.isDefaultMaterial;
			tmp_SubMesh.SetSharedMaterial(materialReference.material);
			tmp_SubMesh.renderer.sortingLayerID = textComponent.renderer.sortingLayerID;
			tmp_SubMesh.renderer.sortingOrder = textComponent.renderer.sortingOrder;
			return tmp_SubMesh;
		}

		// Token: 0x06002C19 RID: 11289 RVA: 0x0001F7F0 File Offset: 0x0001D9F0
		public void DestroySelf()
		{
			global::UnityEngine.Object.Destroy(base.gameObject, 1f);
		}

		// Token: 0x06002C1A RID: 11290 RVA: 0x001072E8 File Offset: 0x001054E8
		private Material GetMaterial(Material mat)
		{
			if (this.m_renderer == null)
			{
				this.m_renderer = base.GetComponent<Renderer>();
			}
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

		// Token: 0x06002C1B RID: 11291 RVA: 0x00107370 File Offset: 0x00105570
		private Material CreateMaterialInstance(Material source)
		{
			Material material = new Material(source);
			material.shaderKeywords = source.shaderKeywords;
			Material material2 = material;
			material2.name += " (Instance)";
			return material;
		}

		// Token: 0x06002C1C RID: 11292 RVA: 0x0001F802 File Offset: 0x0001DA02
		private Material GetSharedMaterial()
		{
			if (this.m_renderer == null)
			{
				this.m_renderer = base.GetComponent<Renderer>();
			}
			return this.m_renderer.sharedMaterial;
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x0001F82C File Offset: 0x0001DA2C
		private void SetSharedMaterial(Material mat)
		{
			this.m_sharedMaterial = mat;
			this.m_padding = this.GetPaddingForMaterial();
			this.SetMaterialDirty();
		}

		// Token: 0x06002C1E RID: 11294 RVA: 0x001073A8 File Offset: 0x001055A8
		public float GetPaddingForMaterial()
		{
			return ShaderUtilities.GetPadding(this.m_sharedMaterial, this.m_TextComponent.extraPadding, this.m_TextComponent.isUsingBold);
		}

		// Token: 0x06002C1F RID: 11295 RVA: 0x0001F847 File Offset: 0x0001DA47
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
			this.m_padding = ShaderUtilities.GetPadding(this.m_sharedMaterial, isExtraPadding, isUsingBold);
		}

		// Token: 0x06002C20 RID: 11296 RVA: 0x0001F85C File Offset: 0x0001DA5C
		public void SetVerticesDirty()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.havePropertiesChanged = true;
				this.m_TextComponent.SetVerticesDirty();
			}
		}

		// Token: 0x06002C21 RID: 11297 RVA: 0x0001F892 File Offset: 0x0001DA92
		public void SetMaterialDirty()
		{
			this.UpdateMaterial();
		}

		// Token: 0x06002C22 RID: 11298 RVA: 0x0001F89A File Offset: 0x0001DA9A
		protected void UpdateMaterial()
		{
			if (this.m_renderer == null)
			{
				this.m_renderer = this.renderer;
			}
			this.m_renderer.sharedMaterial = this.m_sharedMaterial;
		}

		// Token: 0x0400301E RID: 12318
		[SerializeField]
		private TMP_FontAsset m_fontAsset;

		// Token: 0x0400301F RID: 12319
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset;

		// Token: 0x04003020 RID: 12320
		[SerializeField]
		private Material m_material;

		// Token: 0x04003021 RID: 12321
		[SerializeField]
		private Material m_sharedMaterial;

		// Token: 0x04003022 RID: 12322
		private Material m_fallbackMaterial;

		// Token: 0x04003023 RID: 12323
		private Material m_fallbackSourceMaterial;

		// Token: 0x04003024 RID: 12324
		[SerializeField]
		private bool m_isDefaultMaterial;

		// Token: 0x04003025 RID: 12325
		[SerializeField]
		private float m_padding;

		// Token: 0x04003026 RID: 12326
		[SerializeField]
		private Renderer m_renderer;

		// Token: 0x04003027 RID: 12327
		[SerializeField]
		private MeshFilter m_meshFilter;

		// Token: 0x04003028 RID: 12328
		private Mesh m_mesh;

		// Token: 0x04003029 RID: 12329
		[SerializeField]
		private TextMeshPro m_TextComponent;

		// Token: 0x0400302A RID: 12330
		[NonSerialized]
		private bool m_isRegisteredForEvents;
	}
}

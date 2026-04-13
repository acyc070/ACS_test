using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro
{
	// Token: 0x020005E7 RID: 1511
	public struct MaterialReference
	{
		// Token: 0x0600299E RID: 10654 RVA: 0x000EDA70 File Offset: 0x000EBC70
		public MaterialReference(int index, TMP_FontAsset fontAsset, TMP_SpriteAsset spriteAsset, Material material, float padding)
		{
			this.index = index;
			this.fontAsset = fontAsset;
			this.spriteAsset = spriteAsset;
			this.material = material;
			this.isDefaultMaterial = material.GetInstanceID() == fontAsset.material.GetInstanceID();
			this.isFallbackMaterial = false;
			this.fallbackMaterial = null;
			this.padding = padding;
			this.referenceCount = 0;
		}

		// Token: 0x0600299F RID: 10655 RVA: 0x000EDADC File Offset: 0x000EBCDC
		public static bool Contains(MaterialReference[] materialReferences, TMP_FontAsset fontAsset)
		{
			int instanceID = fontAsset.GetInstanceID();
			int num = 0;
			while (num < materialReferences.Length && materialReferences[num].fontAsset != null)
			{
				if (materialReferences[num].fontAsset.GetInstanceID() == instanceID)
				{
					return true;
				}
				num++;
			}
			return false;
		}

		// Token: 0x060029A0 RID: 10656 RVA: 0x000EDB38 File Offset: 0x000EBD38
		public static int AddMaterialReference(Material material, TMP_FontAsset fontAsset, MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			int instanceID = material.GetInstanceID();
			int num = 0;
			if (materialReferenceIndexLookup.TryGetValue(instanceID, out num))
			{
				return num;
			}
			num = materialReferenceIndexLookup.Count;
			materialReferenceIndexLookup[instanceID] = num;
			materialReferences[num].index = num;
			materialReferences[num].fontAsset = fontAsset;
			materialReferences[num].spriteAsset = null;
			materialReferences[num].material = material;
			materialReferences[num].isDefaultMaterial = instanceID == fontAsset.material.GetInstanceID();
			materialReferences[num].referenceCount = 0;
			return num;
		}

		// Token: 0x060029A1 RID: 10657 RVA: 0x000EDBD4 File Offset: 0x000EBDD4
		public static int AddMaterialReference(Material material, TMP_SpriteAsset spriteAsset, MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			int instanceID = material.GetInstanceID();
			int num = 0;
			if (materialReferenceIndexLookup.TryGetValue(instanceID, out num))
			{
				return num;
			}
			num = materialReferenceIndexLookup.Count;
			materialReferenceIndexLookup[instanceID] = num;
			materialReferences[num].index = num;
			materialReferences[num].fontAsset = materialReferences[0].fontAsset;
			materialReferences[num].spriteAsset = spriteAsset;
			materialReferences[num].material = material;
			materialReferences[num].isDefaultMaterial = true;
			materialReferences[num].referenceCount = 0;
			return num;
		}

		// Token: 0x04002E9C RID: 11932
		public int index;

		// Token: 0x04002E9D RID: 11933
		public TMP_FontAsset fontAsset;

		// Token: 0x04002E9E RID: 11934
		public TMP_SpriteAsset spriteAsset;

		// Token: 0x04002E9F RID: 11935
		public Material material;

		// Token: 0x04002EA0 RID: 11936
		public bool isDefaultMaterial;

		// Token: 0x04002EA1 RID: 11937
		public bool isFallbackMaterial;

		// Token: 0x04002EA2 RID: 11938
		public Material fallbackMaterial;

		// Token: 0x04002EA3 RID: 11939
		public float padding;

		// Token: 0x04002EA4 RID: 11940
		public int referenceCount;
	}
}

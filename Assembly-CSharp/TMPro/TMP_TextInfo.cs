using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000633 RID: 1587
	[Serializable]
	public class TMP_TextInfo
	{
		// Token: 0x06002D29 RID: 11561 RVA: 0x0010FEC0 File Offset: 0x0010E0C0
		public TMP_TextInfo()
		{
			this.characterInfo = new TMP_CharacterInfo[8];
			this.wordInfo = new TMP_WordInfo[16];
			this.linkInfo = new TMP_LinkInfo[0];
			this.lineInfo = new TMP_LineInfo[2];
			this.pageInfo = new TMP_PageInfo[16];
			this.meshInfo = new TMP_MeshInfo[1];
		}

		// Token: 0x06002D2A RID: 11562 RVA: 0x0010FF20 File Offset: 0x0010E120
		public TMP_TextInfo(TMP_Text textComponent)
		{
			this.textComponent = textComponent;
			this.characterInfo = new TMP_CharacterInfo[8];
			this.wordInfo = new TMP_WordInfo[4];
			this.linkInfo = new TMP_LinkInfo[0];
			this.lineInfo = new TMP_LineInfo[2];
			this.pageInfo = new TMP_PageInfo[16];
			this.meshInfo = new TMP_MeshInfo[1];
			this.meshInfo[0].mesh = textComponent.mesh;
			this.materialCount = 1;
		}

		// Token: 0x06002D2B RID: 11563 RVA: 0x0010FFA4 File Offset: 0x0010E1A4
		public void Clear()
		{
			this.characterCount = 0;
			this.spaceCount = 0;
			this.wordCount = 0;
			this.linkCount = 0;
			this.lineCount = 0;
			this.pageCount = 0;
			this.spriteCount = 0;
			for (int i = 0; i < this.meshInfo.Length; i++)
			{
				this.meshInfo[i].vertexCount = 0;
			}
		}

		// Token: 0x06002D2C RID: 11564 RVA: 0x00110010 File Offset: 0x0010E210
		public void ClearMeshInfo(bool updateMesh)
		{
			for (int i = 0; i < this.meshInfo.Length; i++)
			{
				this.meshInfo[i].Clear(updateMesh);
			}
		}

		// Token: 0x06002D2D RID: 11565 RVA: 0x00110048 File Offset: 0x0010E248
		public void ClearAllMeshInfo()
		{
			for (int i = 0; i < this.meshInfo.Length; i++)
			{
				this.meshInfo[i].Clear(true);
			}
		}

		// Token: 0x06002D2E RID: 11566 RVA: 0x00110080 File Offset: 0x0010E280
		public void ResetVertexLayout(bool isVolumetric)
		{
			for (int i = 0; i < this.meshInfo.Length; i++)
			{
				this.meshInfo[i].ResizeMeshInfo(0, isVolumetric);
			}
		}

		// Token: 0x06002D2F RID: 11567 RVA: 0x001100BC File Offset: 0x0010E2BC
		public void ClearUnusedVertices(MaterialReference[] materials)
		{
			for (int i = 0; i < this.meshInfo.Length; i++)
			{
				int num = 0;
				this.meshInfo[i].ClearUnusedVertices(num);
			}
		}

		// Token: 0x06002D30 RID: 11568 RVA: 0x001100F8 File Offset: 0x0010E2F8
		public void ClearLineInfo()
		{
			if (this.lineInfo == null)
			{
				this.lineInfo = new TMP_LineInfo[2];
			}
			for (int i = 0; i < this.lineInfo.Length; i++)
			{
				this.lineInfo[i].characterCount = 0;
				this.lineInfo[i].spaceCount = 0;
				this.lineInfo[i].width = 0f;
				this.lineInfo[i].ascender = TMP_TextInfo.k_InfinityVectorNegative.x;
				this.lineInfo[i].descender = TMP_TextInfo.k_InfinityVectorPositive.x;
				this.lineInfo[i].lineExtents.min = TMP_TextInfo.k_InfinityVectorPositive;
				this.lineInfo[i].lineExtents.max = TMP_TextInfo.k_InfinityVectorNegative;
				this.lineInfo[i].maxAdvance = 0f;
			}
		}

		// Token: 0x06002D31 RID: 11569 RVA: 0x001101F4 File Offset: 0x0010E3F4
		public TMP_MeshInfo[] CopyMeshInfoVertexData()
		{
			if (this.m_CachedMeshInfo == null || this.m_CachedMeshInfo.Length != this.meshInfo.Length)
			{
				this.m_CachedMeshInfo = new TMP_MeshInfo[this.meshInfo.Length];
				for (int i = 0; i < this.m_CachedMeshInfo.Length; i++)
				{
					int num = this.meshInfo[i].vertices.Length;
					this.m_CachedMeshInfo[i].vertices = new Vector3[num];
					this.m_CachedMeshInfo[i].uvs0 = new Vector2[num];
					this.m_CachedMeshInfo[i].uvs2 = new Vector2[num];
					this.m_CachedMeshInfo[i].colors32 = new Color32[num];
				}
			}
			for (int j = 0; j < this.m_CachedMeshInfo.Length; j++)
			{
				int num2 = this.meshInfo[j].vertices.Length;
				if (this.m_CachedMeshInfo[j].vertices.Length != num2)
				{
					this.m_CachedMeshInfo[j].vertices = new Vector3[num2];
					this.m_CachedMeshInfo[j].uvs0 = new Vector2[num2];
					this.m_CachedMeshInfo[j].uvs2 = new Vector2[num2];
					this.m_CachedMeshInfo[j].colors32 = new Color32[num2];
				}
				Array.Copy(this.meshInfo[j].vertices, this.m_CachedMeshInfo[j].vertices, num2);
				Array.Copy(this.meshInfo[j].uvs0, this.m_CachedMeshInfo[j].uvs0, num2);
				Array.Copy(this.meshInfo[j].uvs2, this.m_CachedMeshInfo[j].uvs2, num2);
				Array.Copy(this.meshInfo[j].colors32, this.m_CachedMeshInfo[j].colors32, num2);
			}
			return this.m_CachedMeshInfo;
		}

		// Token: 0x06002D32 RID: 11570 RVA: 0x00110408 File Offset: 0x0010E608
		public static void Resize<T>(ref T[] array, int size)
		{
			int num = ((size <= 1024) ? Mathf.NextPowerOfTwo(size) : (size + 256));
			Array.Resize<T>(ref array, num);
		}

		// Token: 0x06002D33 RID: 11571 RVA: 0x000206D2 File Offset: 0x0001E8D2
		public static void Resize<T>(ref T[] array, int size, bool isBlockAllocated)
		{
			if (isBlockAllocated)
			{
				size = ((size <= 1024) ? Mathf.NextPowerOfTwo(size) : (size + 256));
			}
			if (size == array.Length)
			{
				return;
			}
			Array.Resize<T>(ref array, size);
		}

		// Token: 0x04003148 RID: 12616
		private static Vector2 k_InfinityVectorPositive = new Vector2(1000000f, 1000000f);

		// Token: 0x04003149 RID: 12617
		private static Vector2 k_InfinityVectorNegative = new Vector2(-1000000f, -1000000f);

		// Token: 0x0400314A RID: 12618
		public TMP_Text textComponent;

		// Token: 0x0400314B RID: 12619
		public int characterCount;

		// Token: 0x0400314C RID: 12620
		public int spriteCount;

		// Token: 0x0400314D RID: 12621
		public int spaceCount;

		// Token: 0x0400314E RID: 12622
		public int wordCount;

		// Token: 0x0400314F RID: 12623
		public int linkCount;

		// Token: 0x04003150 RID: 12624
		public int lineCount;

		// Token: 0x04003151 RID: 12625
		public int pageCount;

		// Token: 0x04003152 RID: 12626
		public int materialCount;

		// Token: 0x04003153 RID: 12627
		public TMP_CharacterInfo[] characterInfo;

		// Token: 0x04003154 RID: 12628
		public TMP_WordInfo[] wordInfo;

		// Token: 0x04003155 RID: 12629
		public TMP_LinkInfo[] linkInfo;

		// Token: 0x04003156 RID: 12630
		public TMP_LineInfo[] lineInfo;

		// Token: 0x04003157 RID: 12631
		public TMP_PageInfo[] pageInfo;

		// Token: 0x04003158 RID: 12632
		public TMP_MeshInfo[] meshInfo;

		// Token: 0x04003159 RID: 12633
		private TMP_MeshInfo[] m_CachedMeshInfo;
	}
}

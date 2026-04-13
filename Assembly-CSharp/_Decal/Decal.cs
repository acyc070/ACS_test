using System;
using UnityEngine;

namespace _Decal
{
	// Token: 0x02000595 RID: 1429
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteInEditMode]
	public class Decal : MonoBehaviour
	{
		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060027D2 RID: 10194 RVA: 0x0001C8BE File Offset: 0x0001AABE
		public Texture texture
		{
			get
			{
				return (!this.material) ? null : this.material.mainTexture;
			}
		}

		// Token: 0x060027D3 RID: 10195 RVA: 0x0001C8E1 File Offset: 0x0001AAE1
		private void OnEnable()
		{
			if (Application.isPlaying)
			{
				base.enabled = false;
				this.DeserializeMeshData();
			}
		}

		// Token: 0x060027D4 RID: 10196 RVA: 0x0001C8FA File Offset: 0x0001AAFA
		private void Start()
		{
			base.transform.hasChanged = false;
		}

		// Token: 0x060027D5 RID: 10197 RVA: 0x0001C908 File Offset: 0x0001AB08
		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		}

		// Token: 0x060027D6 RID: 10198 RVA: 0x000E780C File Offset: 0x000E5A0C
		public GameObject[] ForceBuild()
		{
			return new GameObject[0];
		}

		// Token: 0x060027D7 RID: 10199 RVA: 0x000E7824 File Offset: 0x000E5A24
		private void DeserializeMeshData()
		{
			Mesh mesh = base.GetComponent<MeshFilter>().sharedMesh;
			if (mesh != null)
			{
				return;
			}
			if (this.vertices == null || this.vertices.Length == 0)
			{
				return;
			}
			mesh = new Mesh();
			mesh.vertices = this.vertices;
			mesh.normals = this.normals;
			mesh.uv = this.uv;
			mesh.uv2 = this.uv2;
			mesh.triangles = this.triangles;
			base.GetComponent<MeshFilter>().sharedMesh = mesh;
		}

		// Token: 0x060027D8 RID: 10200 RVA: 0x000E78B4 File Offset: 0x000E5AB4
		private void SerializeMeshData()
		{
			Mesh sharedMesh = base.GetComponent<MeshFilter>().sharedMesh;
			if (sharedMesh == null)
			{
				Debug.LogWarning("Unable to serialize Decal mesh data, as there is no mesh.", this);
				return;
			}
			this.vertices = sharedMesh.vertices;
			this.normals = sharedMesh.normals;
			this.uv = sharedMesh.uv;
			this.uv2 = sharedMesh.uv2;
			this.triangles = sharedMesh.triangles;
		}

		// Token: 0x04001FC1 RID: 8129
		public Material material;

		// Token: 0x04001FC2 RID: 8130
		public Sprite sprite;

		// Token: 0x04001FC3 RID: 8131
		public float maxAngle = 90f;

		// Token: 0x04001FC4 RID: 8132
		public float pushDistance = 0.0001f;

		// Token: 0x04001FC5 RID: 8133
		public LayerMask affectedLayers = -1;

		// Token: 0x04001FC6 RID: 8134
		[SerializeField]
		private Vector3[] vertices;

		// Token: 0x04001FC7 RID: 8135
		[SerializeField]
		private Vector3[] normals;

		// Token: 0x04001FC8 RID: 8136
		[SerializeField]
		private Vector2[] uv;

		// Token: 0x04001FC9 RID: 8137
		[SerializeField]
		private Vector2[] uv2;

		// Token: 0x04001FCA RID: 8138
		[SerializeField]
		private int[] triangles;
	}
}

using System;
using UnityEngine;

// Token: 0x020002E9 RID: 745
[ExecuteInEditMode]
public class AmplifyPostProcess : MonoBehaviour
{
	// Token: 0x06001B99 RID: 7065 RVA: 0x000161CA File Offset: 0x000143CA
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, this.PostProcessMat);
	}

	// Token: 0x0400180A RID: 6154
	public Material PostProcessMat;
}

using System;
using UnityEngine;

// Token: 0x020002EA RID: 746
[ExecuteInEditMode]
public class BrightnessImageEffect : MonoBehaviour
{
	// Token: 0x06001B9B RID: 7067 RVA: 0x000161D9 File Offset: 0x000143D9
	public void SetBrightness(float _ammount)
	{
		this.PostProcessMat.SetFloat("_Brightness", _ammount);
	}

	// Token: 0x06001B9C RID: 7068 RVA: 0x000161EC File Offset: 0x000143EC
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, this.PostProcessMat);
	}

	// Token: 0x0400180B RID: 6155
	public Material PostProcessMat;
}

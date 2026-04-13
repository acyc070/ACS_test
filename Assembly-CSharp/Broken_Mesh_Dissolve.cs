using System;
using System.Collections;
using TMG.Core;
using UnityEngine;

// Token: 0x0200020F RID: 527
public class Broken_Mesh_Dissolve : TMGMonoBehaviour
{
	// Token: 0x06001542 RID: 5442 RVA: 0x0007CC3C File Offset: 0x0007AE3C
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Renderers = base.GetComponentsInChildren<MeshRenderer>();
		this.m_MaterialProperties = new MaterialPropertyBlock();
		for (int i = 0; i < this.m_Renderers.Length; i++)
		{
			if (i == 0)
			{
				this.m_MaterialProperties.SetTexture("_MainTex", this.m_Renderers[i].sharedMaterial.mainTexture);
			}
			this.m_Renderers[i].sharedMaterial = GameManager.Instance.AssetManager.GetAsset<Material>("DissolveMaterial");
			this.m_Renderers[i].SetPropertyBlock(this.m_MaterialProperties);
		}
	}

	// Token: 0x06001543 RID: 5443 RVA: 0x000115A0 File Offset: 0x0000F7A0
	public override void OnEnable()
	{
		base.OnEnable();
		base.StartCoroutine(this.FadeOut());
	}

	// Token: 0x06001544 RID: 5444 RVA: 0x0007CCDC File Offset: 0x0007AEDC
	private IEnumerator FadeOut()
	{
		yield return new WaitForSeconds(15f);
		while (this.m_FadeAmmount < 1f)
		{
			if (!base.IsDisposed || !GameManager.Instance.isPaused)
			{
				this.m_MaterialProperties.SetFloat("_Dissolve", this.m_FadeAmmount += Time.deltaTime / 2f);
				for (int i = 0; i < this.m_Renderers.Length; i++)
				{
					this.m_Renderers[i].SetPropertyBlock(this.m_MaterialProperties);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		base.Dispose();
		yield break;
	}

	// Token: 0x040012BC RID: 4796
	private MeshRenderer[] m_Renderers;

	// Token: 0x040012BD RID: 4797
	private MaterialPropertyBlock m_MaterialProperties;

	// Token: 0x040012BE RID: 4798
	private float m_FadeAmmount;
}

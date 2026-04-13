using System;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x0200007F RID: 127
public class CH1MovingPictures : TMGMonoBehaviour
{
	// Token: 0x0600046B RID: 1131 RVA: 0x000062B0 File Offset: 0x000044B0
	public override void Init()
	{
		base.Init();
		this.m_NextIndex = this.GetNextIndex();
		this.m_Mesh.material.mainTexture = this.m_Textures[this.m_CurrentIndex];
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00030330 File Offset: 0x0002E530
	public void Update()
	{
		if (!this.m_Mesh.isVisible)
		{
			if (!this.m_IsImageChanged)
			{
				this.m_ResetTimer += Time.deltaTime;
				if (this.m_ResetTimer > this.m_TimerMax)
				{
					this.m_IsImageChanged = true;
					this.m_ResetTimer = 0f;
					while (this.m_NextIndex == this.m_CurrentIndex)
					{
						this.m_NextIndex = this.GetNextIndex();
					}
					this.m_CurrentIndex = this.m_NextIndex;
					this.m_Mesh.material.mainTexture = this.m_Textures[this.m_CurrentIndex];
				}
			}
		}
		else if (this.m_IsImageChanged)
		{
			this.m_IsImageChanged = false;
			this.m_ResetTimer = 0f;
		}
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x000062E5 File Offset: 0x000044E5
	private int GetNextIndex()
	{
		return global::UnityEngine.Random.Range(0, this.m_Textures.Count - 1);
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040002EE RID: 750
	[SerializeField]
	private MeshRenderer m_Mesh;

	// Token: 0x040002EF RID: 751
	[Header("Textures")]
	[SerializeField]
	private List<Texture> m_Textures;

	// Token: 0x040002F0 RID: 752
	private float m_ResetTimer;

	// Token: 0x040002F1 RID: 753
	private float m_TimerMax = 2f;

	// Token: 0x040002F2 RID: 754
	private bool m_IsImageChanged;

	// Token: 0x040002F3 RID: 755
	private int m_CurrentIndex;

	// Token: 0x040002F4 RID: 756
	private int m_NextIndex;
}

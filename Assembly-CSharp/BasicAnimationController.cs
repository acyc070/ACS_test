using System;
using System.Collections;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

// Token: 0x020001C9 RID: 457
public class BasicAnimationController : TMGMonoBehaviour
{
	// Token: 0x0600137C RID: 4988 RVA: 0x000772FC File Offset: 0x000754FC
	public override void Init()
	{
		base.Init();
		if (this.m_IsAuto)
		{
			this.GetAnimators(base.gameObject);
			Animator[] componentsInChildren = base.GetComponentsInChildren<Animator>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].updateMode = AnimatorUpdateMode.Normal;
			}
		}
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x00077344 File Offset: 0x00075544
	public void Play()
	{
		for (int i = 0; i < this.m_Animators.Count; i++)
		{
			this.m_Animators[i].speed = 1f;
		}
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x00077384 File Offset: 0x00075584
	public void Stop()
	{
		for (int i = 0; i < this.m_Animators.Count; i++)
		{
			this.m_Animators[i].speed = 0f;
		}
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x000773C4 File Offset: 0x000755C4
	private void GetAnimators(GameObject go)
	{
		Animator[] componentsInChildren = base.GetComponentsInChildren<Animator>();
		if (componentsInChildren != null)
		{
			foreach (Animator animator in componentsInChildren)
			{
				if (!this.m_Animators.Contains(animator))
				{
					this.m_Animators.Add(animator);
				}
			}
		}
		IEnumerator enumerator = go.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				this.GetAnimators(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000F81 RID: 3969
	[SerializeField]
	private List<Animator> m_Animators = new List<Animator>();

	// Token: 0x04000F82 RID: 3970
	[SerializeField]
	private bool m_IsAuto;
}

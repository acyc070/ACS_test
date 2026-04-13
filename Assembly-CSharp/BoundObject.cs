using System;
using UnityEngine;

// Token: 0x020005A3 RID: 1443
public class BoundObject : MonoBehaviour
{
	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06002817 RID: 10263 RVA: 0x0001CBB7 File Offset: 0x0001ADB7
	public bool includeLightsInBounds
	{
		get
		{
			return this._includeLightsInBounds;
		}
	}

	// Token: 0x06002818 RID: 10264 RVA: 0x0001CBBF File Offset: 0x0001ADBF
	private void OnValidate()
	{
		this.bounds.center = base.transform.position;
		this.bounds.size = base.transform.localScale;
	}

	// Token: 0x06002819 RID: 10265 RVA: 0x000E8698 File Offset: 0x000E6898
	private void OnDrawGizmosSelected()
	{
		if (Application.isPlaying)
		{
			return;
		}
		Gizmos.color = ((!this.includeLightsInBounds) ? Color.cyan : Color.yellow);
		Gizmos.DrawWireCube(this.bounds.center, this.bounds.size);
	}

	// Token: 0x04002008 RID: 8200
	[SerializeField]
	private bool _includeLightsInBounds = true;

	// Token: 0x04002009 RID: 8201
	[HideInInspector]
	public Bounds bounds = default(Bounds);
}

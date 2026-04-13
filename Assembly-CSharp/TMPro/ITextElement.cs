using System;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x02000624 RID: 1572
	public interface ITextElement
	{
		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06002C53 RID: 11347
		Material sharedMaterial { get; }

		// Token: 0x06002C54 RID: 11348
		void Rebuild(CanvasUpdate update);

		// Token: 0x06002C55 RID: 11349
		int GetInstanceID();
	}
}

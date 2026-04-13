using System;
using I2.Loc;
using TMG.Core;
using UnityEngine;

// Token: 0x02000203 RID: 515
public class AudioLogDataVO : TMGAbstractDisposable
{
	// Token: 0x06001517 RID: 5399 RVA: 0x0000D746 File Offset: 0x0000B946
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04001295 RID: 4757
	public LocalizedString Name;

	// Token: 0x04001296 RID: 4758
	public LocalizedString Log;

	// Token: 0x04001297 RID: 4759
	public string NameString = string.Empty;

	// Token: 0x04001298 RID: 4760
	public string LogString = string.Empty;

	// Token: 0x04001299 RID: 4761
	public Vector3 LogWorldPosition;
}

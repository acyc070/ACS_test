using System;
using TMG.Core;

// Token: 0x020002BE RID: 702
public class AttentionDataVO : TMGAbstractDisposable
{
	// Token: 0x06001A8F RID: 6799 RVA: 0x00015849 File Offset: 0x00013A49
	public AttentionDataVO(string header, string message)
	{
		this.Header = header;
		this.Message = message;
	}

	// Token: 0x06001A90 RID: 6800 RVA: 0x0000D746 File Offset: 0x0000B946
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04001740 RID: 5952
	public string Header;

	// Token: 0x04001741 RID: 5953
	public string Message;
}

using System;

namespace TMG.Core
{
	// Token: 0x020001EC RID: 492
	public abstract class TMGAbstractDisposable : IDisposable
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06001495 RID: 5269 RVA: 0x00010E51 File Offset: 0x0000F051
		// (set) Token: 0x06001496 RID: 5270 RVA: 0x00010E59 File Offset: 0x0000F059
		public bool IsDisposed { get; private set; }

		// Token: 0x06001497 RID: 5271 RVA: 0x00010E62 File Offset: 0x0000F062
		public void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			this.OnDisposed();
			this.IsDisposed = true;
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void OnDisposed()
		{
		}
	}
}

using System;

namespace S13Audio
{
	// Token: 0x02000018 RID: 24
	public interface IEnvelopeDetection
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600005D RID: 93
		// (set) Token: 0x0600005C RID: 92
		float[] Buffer { get; set; }

		// Token: 0x17000006 RID: 6
		float this[int index] { get; }

		// Token: 0x0600005F RID: 95
		void Reset();
	}
}

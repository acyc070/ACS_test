using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200002D RID: 45
	public class S13ShuffleImpl
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00022E6C File Offset: 0x0002106C
		public S13ShuffleImpl(S13Range range, bool shuffleOnInit = true, bool avoidLastPlayed = true)
		{
			this._avoidLastPlayed = avoidLastPlayed;
			if (range.Length == 0)
			{
				Debug.LogWarning("ShuffleImpl: Invalid range length.");
			}
			this._randomOrder = new int[range.Length];
			for (int i = 0; i < range.Length; i++)
			{
				this._randomOrder[i] = range.Start + i;
			}
			this._index = 0;
			if (shuffleOnInit)
			{
				this.Shuffle();
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00022EF0 File Offset: 0x000210F0
		public void Shuffle()
		{
			float[] array = new float[this._randomOrder.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = global::UnityEngine.Random.value;
			}
			int num = this._randomOrder[this._randomOrder.Length - 1];
			Array.Sort<float, int>(array, this._randomOrder);
			if (this._avoidLastPlayed && num.Equals(this._randomOrder[0]))
			{
				Array.Reverse(this._randomOrder);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00022F70 File Offset: 0x00021170
		public int Next(bool reshuffle = true)
		{
			if (this._randomOrder.Length == 0)
			{
				return 0;
			}
			int num = this._randomOrder[this._index];
			if (++this._index >= this._randomOrder.Length)
			{
				this._index = 0;
				if (reshuffle)
				{
					this.Shuffle();
				}
			}
			return num;
		}

		// Token: 0x040000BE RID: 190
		private int[] _randomOrder;

		// Token: 0x040000BF RID: 191
		private int _index;

		// Token: 0x040000C0 RID: 192
		private bool _avoidLastPlayed = true;
	}
}

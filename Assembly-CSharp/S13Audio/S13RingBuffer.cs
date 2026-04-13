using System;

namespace S13Audio
{
	// Token: 0x0200001C RID: 28
	public class S13RingBuffer<T> where T : struct
	{
		// Token: 0x06000074 RID: 116 RVA: 0x0002245C File Offset: 0x0002065C
		public S13RingBuffer(int length)
		{
			this._length = length;
			this._maxLength = length;
			this._data = new T[this._maxLength];
			this._writeCursor = (this._readCursor = 0);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000028E0 File Offset: 0x00000AE0
		// (set) Token: 0x06000076 RID: 118 RVA: 0x000028E8 File Offset: 0x00000AE8
		public int Length
		{
			get
			{
				return this._length;
			}
			set
			{
				if (value < 0)
				{
					this._length = 0;
				}
				else if (value <= this.MaxLength)
				{
					this._length = value;
				}
				else
				{
					this._length = this.MaxLength;
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002921 File Offset: 0x00000B21
		public int MaxLength
		{
			get
			{
				return this._maxLength;
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000224A0 File Offset: 0x000206A0
		public void Write(T data)
		{
			this._data[this._writeCursor] = data;
			this._writeCursor = ((++this._writeCursor < this._length) ? this._writeCursor : 0);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000224F0 File Offset: 0x000206F0
		public T Read()
		{
			T t = this._data[this._readCursor];
			this._readCursor = ((++this._readCursor < this._length) ? this._readCursor : 0);
			return t;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00022540 File Offset: 0x00020740
		public void Clear(T clearVal)
		{
			for (int i = 0; i < this._length; i++)
			{
				this._data[i] = clearVal;
			}
		}

		// Token: 0x0400007B RID: 123
		private T[] _data;

		// Token: 0x0400007C RID: 124
		private int _length;

		// Token: 0x0400007D RID: 125
		private int _maxLength;

		// Token: 0x0400007E RID: 126
		private int _writeCursor;

		// Token: 0x0400007F RID: 127
		private int _readCursor;
	}
}

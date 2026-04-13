using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro
{
	// Token: 0x0200061B RID: 1563
	internal class TMP_ObjectPool<T> where T : new()
	{
		// Token: 0x06002BC3 RID: 11203 RVA: 0x0001F42C File Offset: 0x0001D62C
		public TMP_ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06002BC4 RID: 11204 RVA: 0x0001F44D File Offset: 0x0001D64D
		// (set) Token: 0x06002BC5 RID: 11205 RVA: 0x0001F455 File Offset: 0x0001D655
		public int countAll { get; private set; }

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06002BC6 RID: 11206 RVA: 0x0001F45E File Offset: 0x0001D65E
		public int countActive
		{
			get
			{
				return this.countAll - this.countInactive;
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06002BC7 RID: 11207 RVA: 0x0001F46D File Offset: 0x0001D66D
		public int countInactive
		{
			get
			{
				return this.m_Stack.Count;
			}
		}

		// Token: 0x06002BC8 RID: 11208 RVA: 0x00106BB8 File Offset: 0x00104DB8
		public T Get()
		{
			T t;
			if (this.m_Stack.Count == 0)
			{
				t = new T();
				this.countAll++;
			}
			else
			{
				t = this.m_Stack.Pop();
			}
			if (this.m_ActionOnGet != null)
			{
				this.m_ActionOnGet(t);
			}
			return t;
		}

		// Token: 0x06002BC9 RID: 11209 RVA: 0x00106C14 File Offset: 0x00104E14
		public void Release(T element)
		{
			if (this.m_Stack.Count > 0 && object.ReferenceEquals(this.m_Stack.Peek(), element))
			{
				Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
			}
			if (this.m_ActionOnRelease != null)
			{
				this.m_ActionOnRelease(element);
			}
			this.m_Stack.Push(element);
		}

		// Token: 0x04002FF2 RID: 12274
		private readonly Stack<T> m_Stack = new Stack<T>();

		// Token: 0x04002FF3 RID: 12275
		private readonly UnityAction<T> m_ActionOnGet;

		// Token: 0x04002FF4 RID: 12276
		private readonly UnityAction<T> m_ActionOnRelease;
	}
}

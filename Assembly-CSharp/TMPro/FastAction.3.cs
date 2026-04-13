using System;
using System.Collections.Generic;

namespace TMPro
{
	// Token: 0x020005E0 RID: 1504
	public class FastAction<A, B>
	{
		// Token: 0x06002963 RID: 10595 RVA: 0x0001DA38 File Offset: 0x0001BC38
		public void Add(Action<A, B> rhs)
		{
			if (this.lookup.ContainsKey(rhs))
			{
				return;
			}
			this.lookup[rhs] = this.delegates.AddLast(rhs);
		}

		// Token: 0x06002964 RID: 10596 RVA: 0x000ED42C File Offset: 0x000EB62C
		public void Remove(Action<A, B> rhs)
		{
			LinkedListNode<Action<A, B>> linkedListNode;
			if (this.lookup.TryGetValue(rhs, out linkedListNode))
			{
				this.lookup.Remove(rhs);
				this.delegates.Remove(linkedListNode);
			}
		}

		// Token: 0x06002965 RID: 10597 RVA: 0x000ED468 File Offset: 0x000EB668
		public void Call(A a, B b)
		{
			for (LinkedListNode<Action<A, B>> linkedListNode = this.delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value(a, b);
			}
		}

		// Token: 0x04002E87 RID: 11911
		private LinkedList<Action<A, B>> delegates = new LinkedList<Action<A, B>>();

		// Token: 0x04002E88 RID: 11912
		private Dictionary<Action<A, B>, LinkedListNode<Action<A, B>>> lookup = new Dictionary<Action<A, B>, LinkedListNode<Action<A, B>>>();
	}
}

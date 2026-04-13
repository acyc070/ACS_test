using System;
using System.Collections.Generic;

namespace TMPro
{
	// Token: 0x020005DF RID: 1503
	public class FastAction<A>
	{
		// Token: 0x0600295F RID: 10591 RVA: 0x0001D9EE File Offset: 0x0001BBEE
		public void Add(Action<A> rhs)
		{
			if (this.lookup.ContainsKey(rhs))
			{
				return;
			}
			this.lookup[rhs] = this.delegates.AddLast(rhs);
		}

		// Token: 0x06002960 RID: 10592 RVA: 0x000ED3B8 File Offset: 0x000EB5B8
		public void Remove(Action<A> rhs)
		{
			LinkedListNode<Action<A>> linkedListNode;
			if (this.lookup.TryGetValue(rhs, out linkedListNode))
			{
				this.lookup.Remove(rhs);
				this.delegates.Remove(linkedListNode);
			}
		}

		// Token: 0x06002961 RID: 10593 RVA: 0x000ED3F4 File Offset: 0x000EB5F4
		public void Call(A a)
		{
			for (LinkedListNode<Action<A>> linkedListNode = this.delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value(a);
			}
		}

		// Token: 0x04002E85 RID: 11909
		private LinkedList<Action<A>> delegates = new LinkedList<Action<A>>();

		// Token: 0x04002E86 RID: 11910
		private Dictionary<Action<A>, LinkedListNode<Action<A>>> lookup = new Dictionary<Action<A>, LinkedListNode<Action<A>>>();
	}
}

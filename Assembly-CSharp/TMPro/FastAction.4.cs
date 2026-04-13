using System;
using System.Collections.Generic;

namespace TMPro
{
	// Token: 0x020005E1 RID: 1505
	public class FastAction<A, B, C>
	{
		// Token: 0x06002967 RID: 10599 RVA: 0x0001DA82 File Offset: 0x0001BC82
		public void Add(Action<A, B, C> rhs)
		{
			if (this.lookup.ContainsKey(rhs))
			{
				return;
			}
			this.lookup[rhs] = this.delegates.AddLast(rhs);
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x000ED4A0 File Offset: 0x000EB6A0
		public void Remove(Action<A, B, C> rhs)
		{
			LinkedListNode<Action<A, B, C>> linkedListNode;
			if (this.lookup.TryGetValue(rhs, out linkedListNode))
			{
				this.lookup.Remove(rhs);
				this.delegates.Remove(linkedListNode);
			}
		}

		// Token: 0x06002969 RID: 10601 RVA: 0x000ED4DC File Offset: 0x000EB6DC
		public void Call(A a, B b, C c)
		{
			for (LinkedListNode<Action<A, B, C>> linkedListNode = this.delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value(a, b, c);
			}
		}

		// Token: 0x04002E89 RID: 11913
		private LinkedList<Action<A, B, C>> delegates = new LinkedList<Action<A, B, C>>();

		// Token: 0x04002E8A RID: 11914
		private Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>> lookup = new Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>>();
	}
}

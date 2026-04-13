using System;
using System.Collections.Generic;

namespace TMPro
{
	// Token: 0x020005DE RID: 1502
	public class FastAction
	{
		// Token: 0x0600295B RID: 10587 RVA: 0x0001D9A4 File Offset: 0x0001BBA4
		public void Add(Action rhs)
		{
			if (this.lookup.ContainsKey(rhs))
			{
				return;
			}
			this.lookup[rhs] = this.delegates.AddLast(rhs);
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x000ED344 File Offset: 0x000EB544
		public void Remove(Action rhs)
		{
			LinkedListNode<Action> linkedListNode;
			if (this.lookup.TryGetValue(rhs, out linkedListNode))
			{
				this.lookup.Remove(rhs);
				this.delegates.Remove(linkedListNode);
			}
		}

		// Token: 0x0600295D RID: 10589 RVA: 0x000ED380 File Offset: 0x000EB580
		public void Call()
		{
			for (LinkedListNode<Action> linkedListNode = this.delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value();
			}
		}

		// Token: 0x04002E83 RID: 11907
		private LinkedList<Action> delegates = new LinkedList<Action>();

		// Token: 0x04002E84 RID: 11908
		private Dictionary<Action, LinkedListNode<Action>> lookup = new Dictionary<Action, LinkedListNode<Action>>();
	}
}

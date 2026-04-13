using System;
using System.Collections.Generic;
using TMG.Core;
using UnityEngine;

namespace Ai
{
	// Token: 0x0200018E RID: 398
	public class AiGlobalNetwork : TMGAbstractDisposable
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x0000DA52 File Offset: 0x0000BC52
		public float NodeNearbyDistance
		{
			get
			{
				return 10f;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x0000DA59 File Offset: 0x0000BC59
		// (set) Token: 0x0600100B RID: 4107 RVA: 0x0000DA61 File Offset: 0x0000BC61
		public List<BaseAiController> ConnectedAi { get; private set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600100C RID: 4108 RVA: 0x0000DA6A File Offset: 0x0000BC6A
		// (set) Token: 0x0600100D RID: 4109 RVA: 0x0000DA72 File Offset: 0x0000BC72
		public List<PathfinderNode> GlobalPathNodeList { get; private set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600100E RID: 4110 RVA: 0x0000DA7B File Offset: 0x0000BC7B
		// (set) Token: 0x0600100F RID: 4111 RVA: 0x0000DA83 File Offset: 0x0000BC83
		public List<Ch4_SoundBasedAI> ListeningAi { get; private set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06001010 RID: 4112 RVA: 0x0000DA8C File Offset: 0x0000BC8C
		// (set) Token: 0x06001011 RID: 4113 RVA: 0x0000DA94 File Offset: 0x0000BC94
		public List<Transform> AllyTargets { get; private set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06001012 RID: 4114 RVA: 0x0000DA9D File Offset: 0x0000BC9D
		// (set) Token: 0x06001013 RID: 4115 RVA: 0x0000DAA5 File Offset: 0x0000BCA5
		public Vector3 SoundLocation { get; private set; }

		// Token: 0x06001014 RID: 4116 RVA: 0x0006ADEC File Offset: 0x00068FEC
		public static AiGlobalNetwork Create()
		{
			AiGlobalNetwork aiGlobalNetwork = new AiGlobalNetwork();
			aiGlobalNetwork.ResetConnectedAi();
			aiGlobalNetwork.ResetNodeList();
			aiGlobalNetwork.ResetSoundAi();
			aiGlobalNetwork.ResetAllyTargets();
			return aiGlobalNetwork;
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x0000DAAE File Offset: 0x0000BCAE
		public void RebuildPathing()
		{
			this.m_IsBuilt = false;
			this.BuildPathing();
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0006AE18 File Offset: 0x00069018
		public void BuildPathing()
		{
			if (this.m_IsBuilt)
			{
				return;
			}
			this.ResetNodeList();
			foreach (PathfinderNode pathfinderNode in Resources.FindObjectsOfTypeAll<PathfinderNode>())
			{
				this.GlobalPathNodeList.Add(pathfinderNode);
			}
			bool flag = false;
			for (int j = 0; j < this.GlobalPathNodeList.Count; j++)
			{
				PathfinderNode pathfinderNode2 = this.GlobalPathNodeList[j];
				if (!flag)
				{
					pathfinderNode2.Init(j);
					if (j >= this.GlobalPathNodeList.Count - 1)
					{
						j = -1;
						flag = true;
					}
				}
				else
				{
					pathfinderNode2.RegisterNearbyNodes(this.GlobalPathNodeList);
				}
			}
			this.m_IsBuilt = true;
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x0006AED4 File Offset: 0x000690D4
		public List<PathfinderNode> SolvePath(Vector3 currentPosition, Vector3 targetPosition)
		{
			PathfinderNode pathfinderNode = this.FindStartNode(currentPosition);
			PathfinderNode pathfinderNode2 = this.FindEndNode(targetPosition);
			if (!pathfinderNode)
			{
				Debug.LogWarning("[UNABLE TO SOLVE PATH] - Pathfinding needs to be rebuilt!");
				return null;
			}
			if (!pathfinderNode2)
			{
				return null;
			}
			List<PathfinderNode> list = new List<PathfinderNode>();
			List<PathfinderNode> list2 = new List<PathfinderNode>();
			List<PathfinderNode> list3 = new List<PathfinderNode>();
			List<int> list4 = new List<int>();
			list2.Add(pathfinderNode);
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			while (!flag)
			{
				if (list2.Count > 0)
				{
					for (int i = 0; i < list2.Count; i++)
					{
						PathfinderNode pathfinderNode3 = list2[i];
						pathfinderNode3.NodeScore = num;
						list3.Add(pathfinderNode3);
						list4.Add(pathfinderNode3.ID);
						if (pathfinderNode3.ID == pathfinderNode2.ID)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						num++;
						if (num > 1000)
						{
							flag = true;
							flag2 = true;
						}
						list2 = this.FindClosestNearNodes(list2, list4);
					}
				}
				else
				{
					flag = true;
					flag2 = true;
				}
			}
			if (!flag2)
			{
				bool flag3 = false;
				PathfinderNode pathfinderNode4 = pathfinderNode2;
				list.Add(pathfinderNode2);
				while (!flag3)
				{
					if (list3.Count == 0)
					{
						flag3 = true;
					}
					else
					{
						bool flag4 = false;
						if (pathfinderNode2 == pathfinderNode)
						{
							flag4 = true;
							flag3 = true;
						}
						else
						{
							for (int j = 0; j < list3.Count; j++)
							{
								PathfinderNode pathfinderNode5 = list3[j];
								if (pathfinderNode4.ConnectedNodeIDs.Contains(pathfinderNode5.ID) && pathfinderNode5.NodeScore == pathfinderNode4.NodeScore - 1)
								{
									list.Add(pathfinderNode5);
									pathfinderNode4 = pathfinderNode5;
									flag4 = true;
									if (pathfinderNode5 == pathfinderNode)
									{
										flag3 = true;
									}
								}
							}
						}
						if (!flag4 && !flag3)
						{
							Debug.LogWarning(string.Concat(new object[] { "[UNABLE TO SOLVE PATH] - Path found, but somehow un-solveable? Node: ", pathfinderNode2.name, "|", pathfinderNode.name, "C:", flag4, "S:", flag3 }));
							flag3 = true;
						}
					}
				}
				list.Reverse();
			}
			else
			{
				Debug.LogWarning("[UNABLE TO SOLVE PATH] - No path to end node " + pathfinderNode2.name);
			}
			return list;
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0006B130 File Offset: 0x00069330
		private PathfinderNode FindStartNode(Vector3 currentPosition)
		{
			PathfinderNode pathfinderNode = null;
			float num = -1f;
			for (int i = 0; i < this.GlobalPathNodeList.Count; i++)
			{
				PathfinderNode pathfinderNode2 = this.GlobalPathNodeList[i];
				if (pathfinderNode2)
				{
					if (pathfinderNode2.ConnectedNodes.Count != 0)
					{
						float num2 = Vector3.Distance(pathfinderNode2.Position, currentPosition);
						if (num2 < num || num < 0f)
						{
							pathfinderNode = pathfinderNode2;
							num = num2;
						}
					}
				}
			}
			return pathfinderNode;
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x0006B1C4 File Offset: 0x000693C4
		public PathfinderNode FindEndNode(Vector3 targetPosition)
		{
			PathfinderNode pathfinderNode = null;
			float num = -1f;
			for (int i = 0; i < this.GlobalPathNodeList.Count; i++)
			{
				PathfinderNode pathfinderNode2 = this.GlobalPathNodeList[i];
				if (pathfinderNode2)
				{
					if (pathfinderNode2.ConnectedNodes.Count != 0)
					{
						float num2 = Vector3.Distance(pathfinderNode2.Position, targetPosition);
						Vector3 vector = targetPosition + Vector3.up * 2f;
						Vector3 vector2 = pathfinderNode2.Position + Vector3.up * 2f;
						if (!Physics.Linecast(vector, vector2, LayerMask.GetMask(new string[] { "Default" }), QueryTriggerInteraction.Ignore) && (num2 < num || num < 0f))
						{
							pathfinderNode = pathfinderNode2;
							num = num2;
						}
					}
				}
			}
			return pathfinderNode;
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x0006B2AC File Offset: 0x000694AC
		private List<PathfinderNode> FindClosestNearNodes(List<PathfinderNode> OpenNodes, List<int> ScoredNodes)
		{
			List<PathfinderNode> list = new List<PathfinderNode>();
			for (int i = 0; i < OpenNodes.Count; i++)
			{
				for (int j = 0; j < OpenNodes[i].ConnectedNodes.Count; j++)
				{
					if (!list.Contains(OpenNodes[i].ConnectedNodes[j]) && !ScoredNodes.Contains(OpenNodes[i].ConnectedNodes[j].ID))
					{
						list.Add(OpenNodes[i].ConnectedNodes[j]);
					}
				}
			}
			return list;
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0006B350 File Offset: 0x00069550
		public void CheckCombatStatus()
		{
			CombatStatus combatStatus = CombatStatus.Idle;
			if (GameManager.Instance.Player.CurrentStatus == CombatStatus.Hiding)
			{
				combatStatus = CombatStatus.Hiding;
			}
			for (int i = 0; i < this.ConnectedAi.Count; i++)
			{
				BaseAiController baseAiController = this.ConnectedAi[i];
				if (baseAiController.CurrentTarget && GameManager.Instance.Player.CurrentStatus != CombatStatus.Hiding)
				{
					combatStatus = CombatStatus.InCombat;
				}
			}
			GameManager.Instance.Player.SetCombatStatus(combatStatus);
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x0006B3D8 File Offset: 0x000695D8
		public void RemoveNode(PathfinderNode node)
		{
			for (int i = 0; i < this.GlobalPathNodeList.Count; i++)
			{
				PathfinderNode pathfinderNode = this.GlobalPathNodeList[i];
				for (int j = pathfinderNode.ConnectedNodes.Count - 1; j > -1; j--)
				{
					PathfinderNode pathfinderNode2 = pathfinderNode.ConnectedNodes[j];
					if (pathfinderNode2.Equals(node))
					{
						pathfinderNode.ConnectedNodes.Remove(pathfinderNode2);
					}
				}
			}
			if (this.GlobalPathNodeList.Contains(node))
			{
				this.GlobalPathNodeList.Remove(node);
			}
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0006B470 File Offset: 0x00069670
		public void SetNoiseLocation(Vector3 position)
		{
			this.SoundLocation = position;
			if (this.ListeningAi != null)
			{
				for (int i = 0; i < this.ListeningAi.Count; i++)
				{
					this.ListeningAi[i].SetNoiseLocation(this.SoundLocation);
				}
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0000DABD File Offset: 0x0000BCBD
		public void AddSoundAi(Ch4_SoundBasedAI ai)
		{
			if (this.ListeningAi != null && !this.ListeningAi.Contains(ai))
			{
				this.ListeningAi.Add(ai);
			}
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0000DAE7 File Offset: 0x0000BCE7
		public void RemoveSoundAi(Ch4_SoundBasedAI ai)
		{
			if (this.ListeningAi != null && this.ListeningAi.Contains(ai))
			{
				this.ListeningAi.Remove(ai);
			}
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0000DB12 File Offset: 0x0000BD12
		public void ClearSoundAi()
		{
			if (this.ListeningAi != null)
			{
				this.ListeningAi.Clear();
				this.ListeningAi = null;
			}
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0006B4C4 File Offset: 0x000696C4
		public void ClearAndDisposeSoundAi()
		{
			if (this.ListeningAi != null)
			{
				for (int i = 0; i < this.ListeningAi.Count; i++)
				{
					Ch4_SoundBasedAI ch4_SoundBasedAI = this.ListeningAi[i];
					if (ch4_SoundBasedAI)
					{
						ch4_SoundBasedAI.Dispose();
					}
				}
				this.ListeningAi.Clear();
				this.ListeningAi = null;
			}
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0000DB31 File Offset: 0x0000BD31
		private void ResetSoundAi()
		{
			this.ClearSoundAi();
			this.ListeningAi = new List<Ch4_SoundBasedAI>();
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0000DB44 File Offset: 0x0000BD44
		public void AddAi(BaseAiController ai)
		{
			if (!this.ConnectedAi.Contains(ai))
			{
				this.ConnectedAi.Add(ai);
			}
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0000DB63 File Offset: 0x0000BD63
		public void RemoveAi(BaseAiController ai)
		{
			if (this.ConnectedAi.Contains(ai))
			{
				this.ConnectedAi.Remove(ai);
			}
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x0006B528 File Offset: 0x00069728
		public void ClearAllAi()
		{
			List<BaseAiController> list = new List<BaseAiController>(this.ConnectedAi);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Dispose();
			}
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0000DB83 File Offset: 0x0000BD83
		private void ResetConnectedAi()
		{
			this.ClearConnectedAi();
			this.ConnectedAi = new List<BaseAiController>();
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x0000DB96 File Offset: 0x0000BD96
		private void ClearConnectedAi()
		{
			if (this.ConnectedAi != null)
			{
				this.ConnectedAi.Clear();
				this.ConnectedAi = null;
			}
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0000DBB5 File Offset: 0x0000BDB5
		private void ResetNodeList()
		{
			this.ClearNodeList();
			this.GlobalPathNodeList = new List<PathfinderNode>();
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
		private void ClearNodeList()
		{
			if (this.GlobalPathNodeList != null)
			{
				this.GlobalPathNodeList.Clear();
				this.GlobalPathNodeList = null;
			}
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x0000DBE7 File Offset: 0x0000BDE7
		public void AddAllyTarget(Transform target)
		{
			if (this.AllyTargets == null)
			{
				this.ResetAllyTargets();
			}
			if (!this.AllyTargets.Contains(target))
			{
				this.AllyTargets.Add(target);
			}
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0000DC17 File Offset: 0x0000BE17
		public void RemoveAllyTarget(Transform target)
		{
			if (this.AllyTargets.Contains(target))
			{
				this.AllyTargets.Remove(target);
			}
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x0000DC37 File Offset: 0x0000BE37
		public bool CheckAllyTarget(Transform target)
		{
			return this.AllyTargets != null && this.AllyTargets.Contains(target);
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x0006B564 File Offset: 0x00069764
		public void CleanAllyTargets()
		{
			if (this.AllyTargets != null)
			{
				for (int i = this.AllyTargets.Count - 1; i >= 0; i--)
				{
					if (this.AllyTargets[i] == null)
					{
						this.AllyTargets.RemoveAt(i);
					}
				}
			}
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x0000DC58 File Offset: 0x0000BE58
		private void ResetAllyTargets()
		{
			this.AllyTargets = new List<Transform>();
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x0000DC65 File Offset: 0x0000BE65
		protected override void OnDisposed()
		{
			this.ClearConnectedAi();
			this.ClearNodeList();
			base.OnDisposed();
		}

		// Token: 0x04000D2F RID: 3375
		private bool m_IsBuilt;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai
{
	// Token: 0x02000191 RID: 401
	public class AiThoughtMachine : AiThoughtMachineBehaviour
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x0000DC88 File Offset: 0x0000BE88
		// (set) Token: 0x06001032 RID: 4146 RVA: 0x0000DC90 File Offset: 0x0000BE90
		public bool IsActive { get; private set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x0000DC99 File Offset: 0x0000BE99
		// (set) Token: 0x06001034 RID: 4148 RVA: 0x0000DCA1 File Offset: 0x0000BEA1
		public AiThought CurrentThought { get; private set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06001035 RID: 4149 RVA: 0x0000DCAA File Offset: 0x0000BEAA
		// (set) Token: 0x06001036 RID: 4150 RVA: 0x0000DCB2 File Offset: 0x0000BEB2
		public AiThought PreviousThought { get; private set; }

		// Token: 0x06001037 RID: 4151 RVA: 0x0000DCBB File Offset: 0x0000BEBB
		public override void Activate()
		{
			base.Activate();
			this.IsActive = true;
			this.InitThoughtMachine();
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0000DCD0 File Offset: 0x0000BED0
		private void InitThoughtMachine()
		{
			this.ClearThoughtCoroutines();
			this.m_ThoughtCoroutines = new List<IEnumerator>();
			this.m_ThoughtIndexCount = Enum.GetValues(typeof(AiThought)).Length;
			this.InitThoughtCoroutines();
			this.TriggerNextThoughtCoroutine();
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0006B5C0 File Offset: 0x000697C0
		private void InitThoughtCoroutines()
		{
			this.m_ThoughtCoroutines.Clear();
			this.m_ThoughtCoroutinesIndex = -1;
			for (int i = 0; i < this.m_ThoughtIndexCount; i++)
			{
				AiThought aiThought = (AiThought)i;
				string text = "T_Enter" + aiThought.ToString();
				string text2 = "T_" + aiThought.ToString();
				this.m_ThoughtCoroutines.Add(this.OnEnterThought(i, text, text2));
			}
			this.m_ThoughtCoroutines.Add(this.ResetThoughtCoroutines());
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0000DD09 File Offset: 0x0000BF09
		private void TriggerNextThoughtCoroutine()
		{
			this.m_ThoughtCoroutinesIndex++;
			base.StartCoroutine(this.m_ThoughtCoroutines[this.m_ThoughtCoroutinesIndex]);
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x0006B650 File Offset: 0x00069850
		private IEnumerator Thoughts()
		{
			while (!base.IsDisposed)
			{
				for (int i = 0; i < this.m_ThoughtCoroutines.Count; i++)
				{
					yield return base.StartCoroutine(this.m_ThoughtCoroutines[i]);
				}
				yield return new WaitForEndOfFrame();
			}
			yield break;
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x0006B66C File Offset: 0x0006986C
		private IEnumerator OnEnterThought(int _currentThought, string _enter, string _behaviour)
		{
			bool hasEnteredThought = true;
			while (this.CurrentThought == (AiThought)_currentThought)
			{
				while (GameManager.Instance.isPaused)
				{
					yield return null;
				}
				if (!this.IsActive || base.IsDisposed)
				{
					yield break;
				}
				if (hasEnteredThought)
				{
					base.Invoke(_enter, 0f);
					hasEnteredThought = false;
				}
				base.Invoke(_behaviour, 0f);
				if (this.CurrentThought == AiThought.Die || _currentThought == 10)
				{
					yield break;
				}
				yield return new WaitForEndOfFrame();
			}
			this.TriggerNextThoughtCoroutine();
			yield break;
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0006B69C File Offset: 0x0006989C
		private IEnumerator ResetThoughtCoroutines()
		{
			this.InitThoughtCoroutines();
			this.TriggerNextThoughtCoroutine();
			yield return null;
			yield break;
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0000DD31 File Offset: 0x0000BF31
		public void SetThought(int _index)
		{
			this.SetThought((AiThought)_index);
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x0000DD3A File Offset: 0x0000BF3A
		public void SetThought(AiThought _thought)
		{
			if (_thought != this.CurrentThought)
			{
				this.PreviousThought = this.CurrentThought;
				this.CurrentThought = _thought;
			}
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x0000DD5B File Offset: 0x0000BF5B
		public void RevertToPreviousThought()
		{
			this.SetThought(this.PreviousThought);
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x0000DD69 File Offset: 0x0000BF69
		public bool IsInThought(int _index)
		{
			return this.IsInThought((AiThought)_index);
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0000DD72 File Offset: 0x0000BF72
		public bool IsInThought(AiThought _thought)
		{
			return _thought == this.CurrentThought;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x0000DD7D File Offset: 0x0000BF7D
		public bool WasInThought(int _index)
		{
			return this.WasInThought((AiThought)_index);
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x0000DD86 File Offset: 0x0000BF86
		public bool WasInThought(AiThought _thought)
		{
			return _thought == this.PreviousThought;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x0000DD91 File Offset: 0x0000BF91
		public void StartStateMachine()
		{
			this.IsActive = true;
			this.TriggerNextThoughtCoroutine();
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0000DDA0 File Offset: 0x0000BFA0
		public void StopStateMachine()
		{
			this.IsActive = false;
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x0000DDA9 File Offset: 0x0000BFA9
		private void ClearThoughtCoroutines()
		{
			if (this.m_ThoughtCoroutines != null)
			{
				this.m_ThoughtCoroutines.Clear();
				this.m_ThoughtCoroutines = null;
			}
		}

		// Token: 0x04000D49 RID: 3401
		[Header("Debug Options")]
		[SerializeField]
		protected bool m_CanDebug = true;

		// Token: 0x04000D4D RID: 3405
		private const string m_ThoughtEnterPrefix = "T_Enter";

		// Token: 0x04000D4E RID: 3406
		private const string m_ThoughtBehaviourPrefix = "T_";

		// Token: 0x04000D4F RID: 3407
		private List<IEnumerator> m_ThoughtCoroutines;

		// Token: 0x04000D50 RID: 3408
		private int m_ThoughtCoroutinesIndex;

		// Token: 0x04000D51 RID: 3409
		private int m_ThoughtIndexCount;
	}
}

using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000058 RID: 88
	public class GUISwitchLoopControl : MonoBehaviour
	{
		// Token: 0x06000344 RID: 836 RVA: 0x0002A4CC File Offset: 0x000286CC
		private void Start()
		{
			this._audioManager = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
			if (this._audioManager == null)
			{
				Debug.LogError(base.name + ": AudioManager not found.");
			}
			this._loopSwitch = this.loopSwitchSetting.GetComponent<S13ObjectLoopSwitch>();
			this._currentSegment = 0;
			this._numSegments = this._loopSwitch.audioSegments.Length;
			this._isPlaying = this._loopSwitch.playOnAwake;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0002A548 File Offset: 0x00028748
		private void OnGUI()
		{
			GUI.BeginGroup(this.controlRect);
			GUI.Box(new Rect(0f, 0f, this.controlRect.width, this.controlRect.height), string.Empty);
			GUI.enabled = !this._isPlaying;
			if (GUI.Button(new Rect(10f, 5f, 160f, 30f), "Play Music"))
			{
				this._loopSwitch.Play();
				this._isPlaying = true;
			}
			GUI.enabled = this._isPlaying;
			if (GUI.Button(new Rect(220f, 5f, 160f, 30f), "Switch to next Track"))
			{
				this._currentSegment = ((++this._currentSegment < this._numSegments) ? this._currentSegment : 0);
				this._loopSwitch.TransitionToSegment(this._currentSegment);
			}
			if (GUI.Button(new Rect(430f, 5f, 160f, 30f), "Stop Music"))
			{
				this._loopSwitch.Stop(false);
				this._isPlaying = false;
			}
			GUI.EndGroup();
		}

		// Token: 0x040001B5 RID: 437
		public GameObject loopSwitchSetting;

		// Token: 0x040001B6 RID: 438
		public Rect controlRect = new Rect(300f, 40f, 600f, 40f);

		// Token: 0x040001B7 RID: 439
		private S13AudioManager _audioManager;

		// Token: 0x040001B8 RID: 440
		private S13ObjectLoopSwitch _loopSwitch;

		// Token: 0x040001B9 RID: 441
		private int _currentSegment;

		// Token: 0x040001BA RID: 442
		private int _numSegments;

		// Token: 0x040001BB RID: 443
		private bool _isPlaying;
	}
}

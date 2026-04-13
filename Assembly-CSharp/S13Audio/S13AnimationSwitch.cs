using System;
using System.Collections.Generic;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200005D RID: 93
	public class S13AnimationSwitch : MonoBehaviour
	{
		// Token: 0x06000358 RID: 856 RVA: 0x0002A9E8 File Offset: 0x00028BE8
		private void Start()
		{
			this.animator = base.GetComponentInParent<Animator>();
			if (this.animator == null)
			{
				this.Log("parent object of S13AnimationSwitch does not contain an Animator", base.gameObject, true, false);
				base.gameObject.SetActive(false);
			}
			this.Refresh();
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0002AA38 File Offset: 0x00028C38
		private void AddAnimationEvent(ref Animator animator, string clipName, ContainerFunction functionType, int frame, string id)
		{
			if (animator == null)
			{
				this.Log("Animator not found, AddAnimationEvent Cancelled", base.gameObject, false, false);
			}
			if (clipName == string.Empty || id == string.Empty)
			{
				this.Log("Clip name and id cannot be blank, AddAnimationEvent Cancelled", base.gameObject, false, false);
			}
			AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
			for (int i = 0; i < animationClips.Length; i++)
			{
				if (animationClips[i] != null && animationClips[i].name == clipName)
				{
					AnimationEvent animationEvent = new AnimationEvent();
					AnimationEvent[] events = animationClips[i].events;
					animationEvent.time = (float)frame / 30f;
					animationEvent.stringParameter = id;
					animationEvent.functionName = functionType.ToString();
					for (int j = 0; j < animationClips[i].events.Length; j++)
					{
						if (events[j].functionName.ToUpper() == functionType.ToString() && events[j].time == animationEvent.time)
						{
							this.Log("This event already exists on the clip.", base.gameObject, false, false);
							return;
						}
					}
					animationClips[i].AddEvent(animationEvent);
					break;
				}
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0002AB90 File Offset: 0x00028D90
		private void ClearAnimationEvents(string clipName)
		{
			AnimationClip[] animationClips = this.animator.runtimeAnimatorController.animationClips;
			for (int i = 0; i < animationClips.Length; i++)
			{
				if (animationClips[i] != null && animationClips[i].name == clipName)
				{
					this.Log("Clearing events from " + clipName, base.gameObject, false, false);
					animationClips[i].events = new AnimationEvent[0];
					return;
				}
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000051FB File Offset: 0x000033FB
		private void Log(string message, GameObject gameObject, bool raiseWarning = false, bool raiseError = false)
		{
			if (this.debug)
			{
				if (raiseWarning)
				{
					Debug.LogWarning(message, gameObject);
				}
				else if (raiseError)
				{
					Debug.LogError(message, gameObject);
				}
				else
				{
					Debug.Log(message, gameObject);
				}
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00005234 File Offset: 0x00003434
		public bool Contains(string id)
		{
			return this.sources != null && this.sources.ContainsKey(id);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0002AC0C File Offset: 0x00028E0C
		public void Clear()
		{
			for (int i = 0; i < this.audioContainers.Length; i++)
			{
				this.ClearAnimationEvents(this.audioContainers[i].animationClipName);
			}
			this.sources.Clear();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0002AC54 File Offset: 0x00028E54
		public void Refresh()
		{
			S13AnimationAudioContainer[] array = this.audioContainers;
			int i = 0;
			while (i < array.Length)
			{
				S13AnimationAudioContainer s13AnimationAudioContainer = array[i];
				if (s13AnimationAudioContainer.functionType != ContainerFunction.PlaySwitch && s13AnimationAudioContainer.functionType != ContainerFunction.StopSwitch)
				{
					goto IL_00D3;
				}
				if (s13AnimationAudioContainer.audioSourceObject == null)
				{
					this.Log("Audio Container " + s13AnimationAudioContainer.id + " is missing an audioObject reference.", base.gameObject, true, false);
				}
				else
				{
					S13AudioSource component = s13AnimationAudioContainer.audioSourceObject.GetComponent<S13AudioSource>();
					if (!(component == null))
					{
						this.sources.Add(s13AnimationAudioContainer.id, component);
						this.Log("Adding " + s13AnimationAudioContainer.id, component.gameObject, false, false);
						goto IL_00D3;
					}
					this.Log("object assigned to S13Switch does not contain a S13AudioSource", s13AnimationAudioContainer.audioSourceObject, true, false);
				}
				IL_011C:
				i++;
				continue;
				IL_00D3:
				for (int j = 0; j < s13AnimationAudioContainer.frame.Length; j++)
				{
					this.AddAnimationEvent(ref this.animator, s13AnimationAudioContainer.animationClipName, s13AnimationAudioContainer.functionType, s13AnimationAudioContainer.frame[j], s13AnimationAudioContainer.id);
				}
				goto IL_011C;
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0002AD8C File Offset: 0x00028F8C
		public void PlaySwitch(string id)
		{
			if (this.sources == null)
			{
				return;
			}
			if (this.sources.ContainsKey(id))
			{
				this.Log("ID FOUND, " + base.gameObject.name + " is playing " + id, base.gameObject, false, false);
				this.sources[id].Play();
			}
			else
			{
				this.Log("Audio Source with ID: " + id + ", not Found on " + base.gameObject.name, base.gameObject, false, false);
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000524F File Offset: 0x0000344F
		public void StopSwitch(string id)
		{
			if (this.sources == null)
			{
				return;
			}
			if (this.sources.ContainsKey(id))
			{
				this.sources[id].Stop(false);
			}
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00005280 File Offset: 0x00003480
		public void PlayLoadedSound(string id)
		{
			S13AudioManager.Instance.PlayAudio(id);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000528D File Offset: 0x0000348D
		public void StopLoadedSound(string id)
		{
			S13AudioManager.Instance.StopAudio(id, false);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000529B File Offset: 0x0000349B
		public void TriggerAudioEvent(string id)
		{
			S13AudioManager.Instance.InvokeEvent(id, 0f);
		}

		// Token: 0x040001CD RID: 461
		public S13AnimationAudioContainer[] audioContainers;

		// Token: 0x040001CE RID: 462
		private Animator animator;

		// Token: 0x040001CF RID: 463
		private Dictionary<string, S13AudioSource> sources = new Dictionary<string, S13AudioSource>();

		// Token: 0x040001D0 RID: 464
		[SerializeField]
		private bool debug;
	}
}

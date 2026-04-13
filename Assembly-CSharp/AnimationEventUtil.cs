using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public static class AnimationEventUtil
{
	// Token: 0x06001AF6 RID: 6902 RVA: 0x00090FE0 File Offset: 0x0008F1E0
	public static void AddAnimationEvent(ref Animator animator, string clipName, string functionName, int frame)
	{
		AnimationClip animationClip = null;
		for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
		{
			if (animator.runtimeAnimatorController.animationClips[i].name == clipName)
			{
				animationClip = animator.runtimeAnimatorController.animationClips[i];
				break;
			}
		}
		if (animationClip != null)
		{
			float num = (float)frame / 30f;
			AnimationEvent animationEvent = AnimationEventUtil.AddEvent(functionName, num);
			AnimationEvent[] events = animationClip.events;
			bool flag = true;
			foreach (AnimationEvent animationEvent2 in events)
			{
				if (animationEvent2.functionName == functionName && animationEvent2.time == num)
				{
					return;
				}
			}
			if (flag)
			{
				animationClip.AddEvent(animationEvent);
			}
		}
	}

	// Token: 0x06001AF7 RID: 6903 RVA: 0x000910BC File Offset: 0x0008F2BC
	private static AnimationEvent AddEvent(string functionName, float time)
	{
		return new AnimationEvent
		{
			functionName = functionName,
			time = time
		};
	}

	// Token: 0x06001AF8 RID: 6904 RVA: 0x000910E0 File Offset: 0x0008F2E0
	public static AnimationEventController AddEventController(ref Animator animator)
	{
		AnimationEventController animationEventController = animator.gameObject.GetComponent<AnimationEventController>();
		if (animationEventController == null)
		{
			animationEventController = animator.gameObject.AddComponent<AnimationEventController>();
		}
		return animationEventController;
	}
}

using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000342 RID: 834
	public static class DOTweenProShortcuts
	{
		// Token: 0x06001CFD RID: 7421 RVA: 0x00096A74 File Offset: 0x00094C74
		static DOTweenProShortcuts()
		{
			SpiralPlugin spiralPlugin = new SpiralPlugin();
		}

		// Token: 0x06001CFE RID: 7422 RVA: 0x00096A88 File Offset: 0x00094C88
		public static Tweener DOSpiral(this Transform target, float duration, Vector3? axis = null, SpiralMode mode = SpiralMode.Expand, float speed = 1f, float frequency = 10f, float depth = 0f, bool snapping = false)
		{
			if (Mathf.Approximately(speed, 0f))
			{
				speed = 1f;
			}
			if (axis == null || axis == Vector3.zero)
			{
				axis = new Vector3?(Vector3.forward);
			}
			TweenerCore<Vector3, Vector3, SpiralOptions> tweenerCore = DOTween.To<Vector3, Vector3, SpiralOptions>(SpiralPlugin.Get(), () => target.localPosition, delegate(Vector3 x)
			{
				target.localPosition = x;
			}, axis.Value, duration).SetTarget(target);
			tweenerCore.plugOptions.mode = mode;
			tweenerCore.plugOptions.speed = speed;
			tweenerCore.plugOptions.frequency = frequency;
			tweenerCore.plugOptions.depth = depth;
			tweenerCore.plugOptions.snapping = snapping;
			return tweenerCore;
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x00096B74 File Offset: 0x00094D74
		public static Tweener DOSpiral(this Rigidbody target, float duration, Vector3? axis = null, SpiralMode mode = SpiralMode.Expand, float speed = 1f, float frequency = 10f, float depth = 0f, bool snapping = false)
		{
			if (Mathf.Approximately(speed, 0f))
			{
				speed = 1f;
			}
			if (axis == null || axis == Vector3.zero)
			{
				axis = new Vector3?(Vector3.forward);
			}
			TweenerCore<Vector3, Vector3, SpiralOptions> tweenerCore = DOTween.To<Vector3, Vector3, SpiralOptions>(SpiralPlugin.Get(), () => target.position, new DOSetter<Vector3>(target.MovePosition), axis.Value, duration).SetTarget(target);
			tweenerCore.plugOptions.mode = mode;
			tweenerCore.plugOptions.speed = speed;
			tweenerCore.plugOptions.frequency = frequency;
			tweenerCore.plugOptions.depth = depth;
			tweenerCore.plugOptions.snapping = snapping;
			return tweenerCore;
		}
	}
}

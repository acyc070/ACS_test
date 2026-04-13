using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x0200033E RID: 830
	public static class DOTweenModuleUtils
	{
		// Token: 0x06001CD7 RID: 7383 RVA: 0x00016C77 File Offset: 0x00014E77
		public static void Init()
		{
			if (DOTweenModuleUtils._initialized)
			{
				return;
			}
			DOTweenModuleUtils._initialized = true;
			DOTweenExternalCommand.SetOrientationOnPath += DOTweenModuleUtils.Physics.SetOrientationOnPath;
		}

		// Token: 0x0400188A RID: 6282
		private static bool _initialized;

		// Token: 0x0200033F RID: 831
		public static class Physics
		{
			// Token: 0x06001CD8 RID: 7384 RVA: 0x00016CAC File Offset: 0x00014EAC
			public static void SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
			{
				if (options.isRigidbody)
				{
					((Rigidbody)t.target).rotation = newRot;
				}
				else
				{
					trans.rotation = newRot;
				}
			}

			// Token: 0x06001CD9 RID: 7385 RVA: 0x00016CD7 File Offset: 0x00014ED7
			public static bool HasRigidbody2D(Component target)
			{
				return target.GetComponent<Rigidbody2D>() != null;
			}

			// Token: 0x06001CDA RID: 7386 RVA: 0x00016CE5 File Offset: 0x00014EE5
			public static bool HasRigidbody(Component target)
			{
				return target.GetComponent<Rigidbody>() != null;
			}

			// Token: 0x06001CDB RID: 7387 RVA: 0x000957BC File Offset: 0x000939BC
			public static TweenerCore<Vector3, Path, PathOptions> CreateDOTweenPathTween(MonoBehaviour target, bool tweenRigidbody, bool isLocal, Path path, float duration, PathMode pathMode)
			{
				Rigidbody rigidbody = ((!tweenRigidbody) ? null : target.GetComponent<Rigidbody>());
				TweenerCore<Vector3, Path, PathOptions> tweenerCore;
				if (tweenRigidbody && rigidbody != null)
				{
					tweenerCore = ((!isLocal) ? rigidbody.DOPath(path, duration, pathMode) : rigidbody.DOLocalPath(path, duration, pathMode));
				}
				else
				{
					tweenerCore = ((!isLocal) ? target.transform.DOPath(path, duration, pathMode) : target.transform.DOLocalPath(path, duration, pathMode));
				}
				return tweenerCore;
			}
		}
	}
}

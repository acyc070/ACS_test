using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	// Token: 0x02000340 RID: 832
	[AddComponentMenu("DOTween/DOTween Animation")]
	public class DOTweenAnimation : ABSAnimationComponent
	{
		// Token: 0x06001CDD RID: 7389 RVA: 0x00016CF3 File Offset: 0x00014EF3
		private void Awake()
		{
			if (!this.isActive || !this.isValid)
			{
				return;
			}
			if (this.animationType != DOTweenAnimationType.Move || !this.useTargetAsV3)
			{
				this.CreateTween();
				this._tweenCreated = true;
			}
		}

		// Token: 0x06001CDE RID: 7390 RVA: 0x00016D30 File Offset: 0x00014F30
		private void Start()
		{
			if (this._tweenCreated || !this.isActive || !this.isValid)
			{
				return;
			}
			this.CreateTween();
			this._tweenCreated = true;
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x00016D61 File Offset: 0x00014F61
		private void OnDestroy()
		{
			if (this.tween != null && this.tween.IsActive())
			{
				this.tween.Kill(false);
			}
			this.tween = null;
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x00095938 File Offset: 0x00093B38
		public void CreateTween()
		{
			GameObject tweenGO = this.GetTweenGO();
			if (this.target == null || tweenGO == null)
			{
				if (this.targetIsSelf && this.target == null)
				{
					Debug.LogWarning(string.Format("{0} :: This DOTweenAnimation's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically", base.gameObject.name), base.gameObject);
				}
				else
				{
					Debug.LogWarning(string.Format("{0} :: This DOTweenAnimation's target/GameObject is unset: the tween will not be created.", base.gameObject.name), base.gameObject);
				}
				return;
			}
			if (this.forcedTargetType != TargetType.Unset)
			{
				this.targetType = this.forcedTargetType;
			}
			if (this.targetType == TargetType.Unset)
			{
				this.targetType = DOTweenAnimation.TypeToDOTargetType(this.target.GetType());
			}
			switch (this.animationType)
			{
			case DOTweenAnimationType.Move:
				if (this.useTargetAsV3)
				{
					this.isRelative = false;
					if (this.endValueTransform == null)
					{
						Debug.LogWarning(string.Format("{0} :: This tween's TO target is NULL, a Vector3 of (0,0,0) will be used instead", base.gameObject.name), base.gameObject);
						this.endValueV3 = Vector3.zero;
					}
					else if (this.targetType == TargetType.RectTransform)
					{
						RectTransform rectTransform = this.endValueTransform as RectTransform;
						if (rectTransform == null)
						{
							Debug.LogWarning(string.Format("{0} :: This tween's TO target should be a RectTransform, a Vector3 of (0,0,0) will be used instead", base.gameObject.name), base.gameObject);
							this.endValueV3 = Vector3.zero;
						}
						else
						{
							RectTransform rectTransform2 = this.target as RectTransform;
							if (rectTransform2 == null)
							{
								Debug.LogWarning(string.Format("{0} :: This tween's target and TO target are not of the same type. Please reassign the values", base.gameObject.name), base.gameObject);
							}
							else
							{
								this.endValueV3 = DOTweenModuleUI.Utils.SwitchToRectTransform(rectTransform, rectTransform2);
							}
						}
					}
					else
					{
						this.endValueV3 = this.endValueTransform.position;
					}
				}
				switch (this.targetType)
				{
				case TargetType.RectTransform:
					this.tween = ((RectTransform)this.target).DOAnchorPos3D(this.endValueV3, this.duration, this.optionalBool0);
					break;
				case TargetType.Rigidbody:
					this.tween = ((Rigidbody)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
					break;
				case TargetType.Rigidbody2D:
					this.tween = ((Rigidbody2D)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
					break;
				case TargetType.Transform:
					this.tween = ((Transform)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
					break;
				}
				break;
			case DOTweenAnimationType.LocalMove:
				this.tween = tweenGO.transform.DOLocalMove(this.endValueV3, this.duration, this.optionalBool0);
				break;
			case DOTweenAnimationType.Rotate:
			{
				TargetType targetType = this.targetType;
				if (targetType != TargetType.Transform)
				{
					if (targetType != TargetType.Rigidbody)
					{
						if (targetType == TargetType.Rigidbody2D)
						{
							this.tween = ((Rigidbody2D)this.target).DORotate(this.endValueFloat, this.duration);
						}
					}
					else
					{
						this.tween = ((Rigidbody)this.target).DORotate(this.endValueV3, this.duration, this.optionalRotationMode);
					}
				}
				else
				{
					this.tween = ((Transform)this.target).DORotate(this.endValueV3, this.duration, this.optionalRotationMode);
				}
				break;
			}
			case DOTweenAnimationType.LocalRotate:
				this.tween = tweenGO.transform.DOLocalRotate(this.endValueV3, this.duration, this.optionalRotationMode);
				break;
			case DOTweenAnimationType.Scale:
				this.tween = tweenGO.transform.DOScale((!this.optionalBool0) ? this.endValueV3 : new Vector3(this.endValueFloat, this.endValueFloat, this.endValueFloat), this.duration);
				break;
			case DOTweenAnimationType.Color:
				this.isRelative = false;
				switch (this.targetType)
				{
				case TargetType.Image:
					this.tween = ((Image)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.Light:
					this.tween = ((Light)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.Renderer:
					this.tween = ((Renderer)this.target).material.DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.SpriteRenderer:
					this.tween = ((SpriteRenderer)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.Text:
					this.tween = ((Text)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.TextMeshPro:
					this.tween = ((TextMeshPro)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.TextMeshProUGUI:
					this.tween = ((TextMeshProUGUI)this.target).DOColor(this.endValueColor, this.duration);
					break;
				}
				break;
			case DOTweenAnimationType.Fade:
				this.isRelative = false;
				switch (this.targetType)
				{
				case TargetType.CanvasGroup:
					this.tween = ((CanvasGroup)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.Image:
					this.tween = ((Image)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.Light:
					this.tween = ((Light)this.target).DOIntensity(this.endValueFloat, this.duration);
					break;
				case TargetType.Renderer:
					this.tween = ((Renderer)this.target).material.DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.SpriteRenderer:
					this.tween = ((SpriteRenderer)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.Text:
					this.tween = ((Text)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.TextMeshPro:
					this.tween = ((TextMeshPro)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.TextMeshProUGUI:
					this.tween = ((TextMeshProUGUI)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				}
				break;
			case DOTweenAnimationType.Text:
			{
				TargetType targetType2 = this.targetType;
				if (targetType2 == TargetType.Text)
				{
					this.tween = ((Text)this.target).DOText(this.endValueString, this.duration, this.optionalBool0, this.optionalScrambleMode, this.optionalString);
				}
				TargetType targetType3 = this.targetType;
				if (targetType3 != TargetType.TextMeshProUGUI)
				{
					if (targetType3 == TargetType.TextMeshPro)
					{
						this.tween = ((TextMeshPro)this.target).DOText(this.endValueString, this.duration, this.optionalBool0, this.optionalScrambleMode, this.optionalString);
					}
				}
				else
				{
					this.tween = ((TextMeshProUGUI)this.target).DOText(this.endValueString, this.duration, this.optionalBool0, this.optionalScrambleMode, this.optionalString);
				}
				break;
			}
			case DOTweenAnimationType.PunchPosition:
			{
				TargetType targetType4 = this.targetType;
				if (targetType4 != TargetType.Transform)
				{
					if (targetType4 == TargetType.RectTransform)
					{
						this.tween = ((RectTransform)this.target).DOPunchAnchorPos(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
					}
				}
				else
				{
					this.tween = ((Transform)this.target).DOPunchPosition(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				break;
			}
			case DOTweenAnimationType.PunchRotation:
				this.tween = tweenGO.transform.DOPunchRotation(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.PunchScale:
				this.tween = tweenGO.transform.DOPunchScale(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.ShakePosition:
			{
				TargetType targetType5 = this.targetType;
				if (targetType5 != TargetType.Transform)
				{
					if (targetType5 == TargetType.RectTransform)
					{
						this.tween = ((RectTransform)this.target).DOShakeAnchorPos(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0, true);
					}
				}
				else
				{
					this.tween = ((Transform)this.target).DOShakePosition(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0, true);
				}
				break;
			}
			case DOTweenAnimationType.ShakeRotation:
				this.tween = tweenGO.transform.DOShakeRotation(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, true);
				break;
			case DOTweenAnimationType.ShakeScale:
				this.tween = tweenGO.transform.DOShakeScale(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, true);
				break;
			case DOTweenAnimationType.CameraAspect:
				this.tween = ((Camera)this.target).DOAspect(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraBackgroundColor:
				this.tween = ((Camera)this.target).DOColor(this.endValueColor, this.duration);
				break;
			case DOTweenAnimationType.CameraFieldOfView:
				this.tween = ((Camera)this.target).DOFieldOfView(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraOrthoSize:
				this.tween = ((Camera)this.target).DOOrthoSize(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraPixelRect:
				this.tween = ((Camera)this.target).DOPixelRect(this.endValueRect, this.duration);
				break;
			case DOTweenAnimationType.CameraRect:
				this.tween = ((Camera)this.target).DORect(this.endValueRect, this.duration);
				break;
			case DOTweenAnimationType.UIWidthHeight:
				this.tween = ((RectTransform)this.target).DOSizeDelta((!this.optionalBool0) ? this.endValueV2 : new Vector2(this.endValueFloat, this.endValueFloat), this.duration, false);
				break;
			}
			if (this.tween == null)
			{
				return;
			}
			if (this.isFrom)
			{
				((Tweener)this.tween).From(this.isRelative);
			}
			else
			{
				this.tween.SetRelative(this.isRelative);
			}
			GameObject gameObject = ((!this.targetIsSelf && this.tweenTargetIsTargetGO) ? this.targetGO : base.gameObject);
			this.tween.SetTarget(gameObject).SetDelay(this.delay).SetLoops(this.loops, this.loopType)
				.SetAutoKill(this.autoKill)
				.OnKill(delegate
				{
					this.tween = null;
				});
			if (this.isSpeedBased)
			{
				this.tween.SetSpeedBased<Tween>();
			}
			if (this.easeType == Ease.INTERNAL_Custom)
			{
				this.tween.SetEase(this.easeCurve);
			}
			else
			{
				this.tween.SetEase(this.easeType);
			}
			if (!string.IsNullOrEmpty(this.id))
			{
				this.tween.SetId(this.id);
			}
			this.tween.SetUpdate(this.isIndependentUpdate);
			if (this.hasOnStart)
			{
				if (this.onStart != null)
				{
					this.tween.OnStart(new TweenCallback(this.onStart.Invoke));
				}
			}
			else
			{
				this.onStart = null;
			}
			if (this.hasOnPlay)
			{
				if (this.onPlay != null)
				{
					this.tween.OnPlay(new TweenCallback(this.onPlay.Invoke));
				}
			}
			else
			{
				this.onPlay = null;
			}
			if (this.hasOnUpdate)
			{
				if (this.onUpdate != null)
				{
					this.tween.OnUpdate(new TweenCallback(this.onUpdate.Invoke));
				}
			}
			else
			{
				this.onUpdate = null;
			}
			if (this.hasOnStepComplete)
			{
				if (this.onStepComplete != null)
				{
					this.tween.OnStepComplete(new TweenCallback(this.onStepComplete.Invoke));
				}
			}
			else
			{
				this.onStepComplete = null;
			}
			if (this.hasOnComplete)
			{
				if (this.onComplete != null)
				{
					this.tween.OnComplete(new TweenCallback(this.onComplete.Invoke));
				}
			}
			else
			{
				this.onComplete = null;
			}
			if (this.hasOnRewind)
			{
				if (this.onRewind != null)
				{
					this.tween.OnRewind(new TweenCallback(this.onRewind.Invoke));
				}
			}
			else
			{
				this.onRewind = null;
			}
			if (this.autoPlay)
			{
				this.tween.Play<Tween>();
			}
			else
			{
				this.tween.Pause<Tween>();
			}
			if (this.hasOnTweenCreated && this.onTweenCreated != null)
			{
				this.onTweenCreated.Invoke();
			}
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x00016D91 File Offset: 0x00014F91
		public override void DOPlay()
		{
			DOTween.Play(base.gameObject);
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x00016D9F File Offset: 0x00014F9F
		public override void DOPlayBackwards()
		{
			DOTween.PlayBackwards(base.gameObject);
		}

		// Token: 0x06001CE3 RID: 7395 RVA: 0x00016DAD File Offset: 0x00014FAD
		public override void DOPlayForward()
		{
			DOTween.PlayForward(base.gameObject);
		}

		// Token: 0x06001CE4 RID: 7396 RVA: 0x00016DBB File Offset: 0x00014FBB
		public override void DOPause()
		{
			DOTween.Pause(base.gameObject);
		}

		// Token: 0x06001CE5 RID: 7397 RVA: 0x00016DC9 File Offset: 0x00014FC9
		public override void DOTogglePause()
		{
			DOTween.TogglePause(base.gameObject);
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x000967BC File Offset: 0x000949BC
		public override void DORewind()
		{
			this._playCount = -1;
			DOTweenAnimation[] components = base.gameObject.GetComponents<DOTweenAnimation>();
			for (int i = components.Length - 1; i > -1; i--)
			{
				Tween tween = components[i].tween;
				if (tween != null && tween.IsInitialized())
				{
					components[i].tween.Rewind(true);
				}
			}
		}

		// Token: 0x06001CE7 RID: 7399 RVA: 0x0009681C File Offset: 0x00094A1C
		public override void DORestart(bool fromHere = false)
		{
			this._playCount = -1;
			if (this.tween == null)
			{
				if (Debugger.logPriority > 1)
				{
					Debugger.LogNullTween(this.tween);
				}
				return;
			}
			if (fromHere && this.isRelative)
			{
				this.ReEvaluateRelativeTween();
			}
			DOTween.Restart(base.gameObject, true, -1f);
		}

		// Token: 0x06001CE8 RID: 7400 RVA: 0x00016DD7 File Offset: 0x00014FD7
		public override void DOComplete()
		{
			DOTween.Complete(base.gameObject, false);
		}

		// Token: 0x06001CE9 RID: 7401 RVA: 0x00016DE6 File Offset: 0x00014FE6
		public override void DOKill()
		{
			DOTween.Kill(base.gameObject, false);
			this.tween = null;
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x00016DFC File Offset: 0x00014FFC
		public void DOPlayById(string id)
		{
			DOTween.Play(base.gameObject, id);
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x00016E0B File Offset: 0x0001500B
		public void DOPlayAllById(string id)
		{
			DOTween.Play(id);
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x00016E14 File Offset: 0x00015014
		public void DOPauseAllById(string id)
		{
			DOTween.Pause(id);
		}

		// Token: 0x06001CED RID: 7405 RVA: 0x00016E1D File Offset: 0x0001501D
		public void DOPlayBackwardsById(string id)
		{
			DOTween.PlayBackwards(base.gameObject, id);
		}

		// Token: 0x06001CEE RID: 7406 RVA: 0x00016E2C File Offset: 0x0001502C
		public void DOPlayBackwardsAllById(string id)
		{
			DOTween.PlayBackwards(id);
		}

		// Token: 0x06001CEF RID: 7407 RVA: 0x00016E35 File Offset: 0x00015035
		public void DOPlayForwardById(string id)
		{
			DOTween.PlayForward(base.gameObject, id);
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x00016E44 File Offset: 0x00015044
		public void DOPlayForwardAllById(string id)
		{
			DOTween.PlayForward(id);
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x0009687C File Offset: 0x00094A7C
		public void DOPlayNext()
		{
			DOTweenAnimation[] components = base.GetComponents<DOTweenAnimation>();
			while (this._playCount < components.Length - 1)
			{
				this._playCount++;
				DOTweenAnimation dotweenAnimation = components[this._playCount];
				if (dotweenAnimation != null && dotweenAnimation.tween != null && !dotweenAnimation.tween.IsPlaying() && !dotweenAnimation.tween.IsComplete())
				{
					dotweenAnimation.tween.Play<Tween>();
					break;
				}
			}
		}

		// Token: 0x06001CF2 RID: 7410 RVA: 0x00016E4D File Offset: 0x0001504D
		public void DORewindAndPlayNext()
		{
			this._playCount = -1;
			DOTween.Rewind(base.gameObject, true);
			this.DOPlayNext();
		}

		// Token: 0x06001CF3 RID: 7411 RVA: 0x00016E69 File Offset: 0x00015069
		public void DORewindAllById(string id)
		{
			this._playCount = -1;
			DOTween.Rewind(id, true);
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x00016E7A File Offset: 0x0001507A
		public void DORestartById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(base.gameObject, id, true, -1f);
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x00016E96 File Offset: 0x00015096
		public void DORestartAllById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(id, true, -1f);
		}

		// Token: 0x06001CF6 RID: 7414 RVA: 0x00096904 File Offset: 0x00094B04
		public List<Tween> GetTweens()
		{
			List<Tween> list = new List<Tween>();
			DOTweenAnimation[] components = base.GetComponents<DOTweenAnimation>();
			foreach (DOTweenAnimation dotweenAnimation in components)
			{
				list.Add(dotweenAnimation.tween);
			}
			return list;
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x0009694C File Offset: 0x00094B4C
		public static TargetType TypeToDOTargetType(Type t)
		{
			string text = t.ToString();
			int num = text.LastIndexOf(".");
			if (num != -1)
			{
				text = text.Substring(num + 1);
			}
			if (text.IndexOf("Renderer") != -1 && text != "SpriteRenderer")
			{
				text = "Renderer";
			}
			return (TargetType)Enum.Parse(typeof(TargetType), text);
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x00016EAC File Offset: 0x000150AC
		public Tween CreateEditorPreview()
		{
			if (Application.isPlaying)
			{
				return null;
			}
			this.CreateTween();
			return this.tween;
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x00016EC6 File Offset: 0x000150C6
		private GameObject GetTweenGO()
		{
			return (!this.targetIsSelf) ? this.targetGO : base.gameObject;
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x000969BC File Offset: 0x00094BBC
		private void ReEvaluateRelativeTween()
		{
			GameObject tweenGO = this.GetTweenGO();
			if (tweenGO == null)
			{
				Debug.LogWarning(string.Format("{0} :: This DOTweenAnimation's target/GameObject is unset: the tween will not be created.", base.gameObject.name), base.gameObject);
				return;
			}
			if (this.animationType == DOTweenAnimationType.Move)
			{
				((Tweener)this.tween).ChangeEndValue(tweenGO.transform.position + this.endValueV3, true);
			}
			else if (this.animationType == DOTweenAnimationType.LocalMove)
			{
				((Tweener)this.tween).ChangeEndValue(tweenGO.transform.localPosition + this.endValueV3, true);
			}
		}

		// Token: 0x0400188C RID: 6284
		public bool targetIsSelf = true;

		// Token: 0x0400188D RID: 6285
		public GameObject targetGO;

		// Token: 0x0400188E RID: 6286
		public bool tweenTargetIsTargetGO = true;

		// Token: 0x0400188F RID: 6287
		public float delay;

		// Token: 0x04001890 RID: 6288
		public float duration = 1f;

		// Token: 0x04001891 RID: 6289
		public Ease easeType = Ease.OutQuad;

		// Token: 0x04001892 RID: 6290
		public AnimationCurve easeCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001893 RID: 6291
		public LoopType loopType;

		// Token: 0x04001894 RID: 6292
		public int loops = 1;

		// Token: 0x04001895 RID: 6293
		public string id = string.Empty;

		// Token: 0x04001896 RID: 6294
		public bool isRelative;

		// Token: 0x04001897 RID: 6295
		public bool isFrom;

		// Token: 0x04001898 RID: 6296
		public bool isIndependentUpdate;

		// Token: 0x04001899 RID: 6297
		public bool autoKill = true;

		// Token: 0x0400189A RID: 6298
		public bool isActive = true;

		// Token: 0x0400189B RID: 6299
		public bool isValid;

		// Token: 0x0400189C RID: 6300
		public Component target;

		// Token: 0x0400189D RID: 6301
		public DOTweenAnimationType animationType;

		// Token: 0x0400189E RID: 6302
		public TargetType targetType;

		// Token: 0x0400189F RID: 6303
		public TargetType forcedTargetType;

		// Token: 0x040018A0 RID: 6304
		public bool autoPlay = true;

		// Token: 0x040018A1 RID: 6305
		public bool useTargetAsV3;

		// Token: 0x040018A2 RID: 6306
		public float endValueFloat;

		// Token: 0x040018A3 RID: 6307
		public Vector3 endValueV3;

		// Token: 0x040018A4 RID: 6308
		public Vector2 endValueV2;

		// Token: 0x040018A5 RID: 6309
		public Color endValueColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x040018A6 RID: 6310
		public string endValueString = string.Empty;

		// Token: 0x040018A7 RID: 6311
		public Rect endValueRect = new Rect(0f, 0f, 0f, 0f);

		// Token: 0x040018A8 RID: 6312
		public Transform endValueTransform;

		// Token: 0x040018A9 RID: 6313
		public bool optionalBool0;

		// Token: 0x040018AA RID: 6314
		public float optionalFloat0;

		// Token: 0x040018AB RID: 6315
		public int optionalInt0;

		// Token: 0x040018AC RID: 6316
		public RotateMode optionalRotationMode;

		// Token: 0x040018AD RID: 6317
		public ScrambleMode optionalScrambleMode;

		// Token: 0x040018AE RID: 6318
		public string optionalString;

		// Token: 0x040018AF RID: 6319
		private bool _tweenCreated;

		// Token: 0x040018B0 RID: 6320
		private int _playCount = -1;
	}
}

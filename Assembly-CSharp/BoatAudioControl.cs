using System;
using System.Collections;
using S13Audio;
using TMG.Core;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class BoatAudioControl : TMGMonoBehaviour
{
	// Token: 0x06000034 RID: 52 RVA: 0x00002662 File Offset: 0x00000862
	public override void Init()
	{
		if (this.m_boatSwitch == null)
		{
			this.m_boatSwitch = base.GetComponent<S13Switch>();
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002681 File Offset: 0x00000881
	public override void InitOnComplete()
	{
		if (this.m_boatSwitch == null)
		{
			Debug.LogError("S13Switch not found by BoatAudioControl");
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00021A74 File Offset: 0x0001FC74
	public void EngineOn()
	{
		base.StopAllCoroutines();
		this.m_boatSwitch.Stop("engine_idle_loop");
		this.m_boatSwitch.Stop("engine_stop");
		this.m_boatSwitch.Play("control_start");
		this.PlayAudioDelayed("engine_start", this.engineStartPlayDelay);
		this.PlayAudioDelayed("engine_idle_loop", this.engineIdlePlayDelay);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00021ADC File Offset: 0x0001FCDC
	public void EngineOff()
	{
		base.StopAllCoroutines();
		this.m_boatSwitch.Stop("engine_start");
		this.m_boatSwitch.Play("control_stop");
		this.PlayAudioDelayed("engine_stop", this.engineStopPlayDelay);
		this.StopAudioDelayed("engine_work_loop", this.engineWorkStopDelay);
		this.StopAudioDelayed("engine_idle_loop", this.engineIdleStopDelay);
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00021B44 File Offset: 0x0001FD44
	public void ThrottleOn()
	{
		base.StopAllCoroutines();
		this.m_boatSwitch.Stop("engine_work_off");
		this.m_boatSwitch.Play("control_forward");
		this.PlayAudioDelayed("engine_work_on", this.engineWorkOnPlayDelay);
		this.StopAudioDelayed("engine_idle_loop", this.engineIdleLoopStopDelay);
		this.PlayAudioDelayed("engine_work_loop", this.engineWorkLoopPlayDelay);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00021BAC File Offset: 0x0001FDAC
	public void ThrottleOff()
	{
		base.StopAllCoroutines();
		this.m_boatSwitch.Play("control_back");
		this.PlayAudioDelayed("engine_work_off", this.engineWorkOffPlayDelay);
		this.StopAudioDelayed("engine_work_loop", this.engineWorkLoopStopDelay);
		this.PlayAudioDelayed("engine_idle_loop", this.engineIdleLoopPlayDelay);
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00021C04 File Offset: 0x0001FE04
	private void PlayAudioDelayed(string soundId, float delayTime)
	{
		this.m_delayCoroutine = S13AudioUtil.WaitForDuration(delayTime, true, delegate
		{
			this.m_boatSwitch.Play(soundId);
		});
		base.StartCoroutine(this.m_delayCoroutine);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00021C4C File Offset: 0x0001FE4C
	private void StopAudioDelayed(string soundId, float delayTime)
	{
		this.m_delayCoroutine = S13AudioUtil.WaitForDuration(delayTime, true, delegate
		{
			this.m_boatSwitch.Stop(soundId);
		});
		base.StartCoroutine(this.m_delayCoroutine);
	}

	// Token: 0x0600003C RID: 60 RVA: 0x0000269E File Offset: 0x0000089E
	protected override void OnDisposed()
	{
		this.m_boatSwitch = null;
		this.m_delayCoroutine = null;
	}

	// Token: 0x0400003E RID: 62
	[SerializeField]
	private S13Switch m_boatSwitch;

	// Token: 0x0400003F RID: 63
	[Space]
	[Header("EngineOn")]
	public float engineStartPlayDelay = 0.3f;

	// Token: 0x04000040 RID: 64
	public float engineIdlePlayDelay = 4.1f;

	// Token: 0x04000041 RID: 65
	[Space]
	[Header("EngineOff")]
	public float engineStopPlayDelay = 0.3f;

	// Token: 0x04000042 RID: 66
	public float engineWorkStopDelay = 0.6f;

	// Token: 0x04000043 RID: 67
	public float engineIdleStopDelay = 0.6f;

	// Token: 0x04000044 RID: 68
	[Space]
	[Header("ThrottleOn")]
	public float engineWorkOnPlayDelay = 0.3f;

	// Token: 0x04000045 RID: 69
	public float engineWorkLoopPlayDelay = 1.9f;

	// Token: 0x04000046 RID: 70
	public float engineIdleLoopStopDelay = 0.6f;

	// Token: 0x04000047 RID: 71
	[Space]
	[Header("ThrottleOff")]
	public float engineWorkOffPlayDelay = 0.3f;

	// Token: 0x04000048 RID: 72
	public float engineIdleLoopPlayDelay = 1.4f;

	// Token: 0x04000049 RID: 73
	public float engineWorkLoopStopDelay = 0.6f;

	// Token: 0x0400004A RID: 74
	private IEnumerator m_delayCoroutine;
}

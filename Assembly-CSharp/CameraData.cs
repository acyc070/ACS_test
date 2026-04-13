using System;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000351 RID: 849
internal class CameraData
{
	// Token: 0x06001D73 RID: 7539 RVA: 0x000172AA File Offset: 0x000154AA
	public CameraData(Camera Camera)
	{
		this.sceneCamera = Camera.name == "SceneCamera";
		this.previewCamera = Camera.name == "Preview Camera";
	}

	// Token: 0x06001D74 RID: 7540 RVA: 0x000992A8 File Offset: 0x000974A8
	public void Initialize(Camera Camera, DynamicDecals System)
	{
		this.maskBuffer = new CommandBuffer();
		this.maskBuffer.name = "Dynamic Decals - Masking";
		this.projectionBuffer = new CommandBuffer();
		this.projectionBuffer.name = "Dynamic Decals - Projection";
		this.maskCulling = new CullingGroup();
		this.projectionCulling = new CullingGroup();
		this.maskCulling.targetCamera = Camera;
		this.projectionCulling.targetCamera = Camera;
		this.enabled = true;
		this.InitializeRenderingMethod(Camera);
	}

	// Token: 0x06001D75 RID: 7541 RVA: 0x00099328 File Offset: 0x00097528
	public void Terminate(Camera Camera)
	{
		this.RestoreDepthTextureMode(Camera);
		this.TerminateRenderingMethod(Camera);
		if (this.maskCulling != null)
		{
			this.maskCulling.Dispose();
			this.maskCulling = null;
		}
		if (this.projectionCulling != null)
		{
			this.projectionCulling.Dispose();
			this.maskCulling = null;
		}
		this.enabled = false;
	}

	// Token: 0x06001D76 RID: 7542 RVA: 0x00099384 File Offset: 0x00097584
	public void InitializeRenderingMethod(Camera Camera)
	{
		if (this.method == RenderingMethod.ForwardLow && (this.sceneCamera || this.previewCamera))
		{
			this.method = RenderingMethod.ForwardHigh;
		}
		switch (this.method)
		{
		case RenderingMethod.ForwardLow:
			Camera.AddCommandBuffer(CameraEvent.AfterDepthNormalsTexture, this.maskBuffer);
			this.customDTM = CustomDepthTextureMode.None;
			this.desiredDTM = new DepthTextureMode?(DepthTextureMode.DepthNormals);
			this.SetDepthTextureMode(Camera);
			break;
		case RenderingMethod.ForwardHigh:
			Camera.AddCommandBuffer(CameraEvent.AfterDepthTexture, this.maskBuffer);
			this.customDTM = CustomDepthTextureMode.Normal;
			this.desiredDTM = new DepthTextureMode?(DepthTextureMode.Depth);
			this.SetDepthTextureMode(Camera);
			break;
		case RenderingMethod.ForwardForced:
			Camera.AddCommandBuffer(CameraEvent.BeforeForwardOpaque, this.maskBuffer);
			this.customDTM = CustomDepthTextureMode.Normal;
			this.desiredDTM = new DepthTextureMode?(DepthTextureMode.Depth);
			this.SetDepthTextureMode(Camera);
			break;
		case RenderingMethod.Deferred:
			Camera.AddCommandBuffer(CameraEvent.BeforeReflections, this.maskBuffer);
			Camera.AddCommandBuffer(CameraEvent.BeforeReflections, this.projectionBuffer);
			this.customDTM = CustomDepthTextureMode.None;
			this.RestoreDepthTextureMode(Camera);
			break;
		}
	}

	// Token: 0x06001D77 RID: 7543 RVA: 0x00099490 File Offset: 0x00097690
	public void TerminateRenderingMethod(Camera Camera)
	{
		if (Camera != null)
		{
			switch (this.method)
			{
			case RenderingMethod.ForwardLow:
				if (this.maskBuffer != null)
				{
					Camera.RemoveCommandBuffer(CameraEvent.AfterDepthNormalsTexture, this.maskBuffer);
				}
				break;
			case RenderingMethod.ForwardHigh:
				if (this.maskBuffer != null)
				{
					Camera.RemoveCommandBuffer(CameraEvent.AfterDepthTexture, this.maskBuffer);
				}
				break;
			case RenderingMethod.ForwardForced:
				if (this.maskBuffer != null)
				{
					Camera.RemoveCommandBuffer(CameraEvent.BeforeForwardOpaque, this.maskBuffer);
				}
				break;
			case RenderingMethod.Deferred:
				if (this.maskBuffer != null)
				{
					Camera.RemoveCommandBuffer(CameraEvent.BeforeReflections, this.maskBuffer);
				}
				if (this.projectionBuffer != null)
				{
					Camera.RemoveCommandBuffer(CameraEvent.BeforeReflections, this.projectionBuffer);
				}
				break;
			}
		}
	}

	// Token: 0x06001D78 RID: 7544 RVA: 0x0009955C File Offset: 0x0009775C
	public void UpdateRenderingMethod(Camera Camera, DynamicDecals System)
	{
		RenderingMethod renderingMethod;
		if (System.renderingPath == SystemPath.Deferred)
		{
			if (System.Settings.forceForward)
			{
				renderingMethod = RenderingMethod.ForwardForced;
			}
			else
			{
				renderingMethod = RenderingMethod.Deferred;
			}
		}
		else if (System.Settings.highPrecision)
		{
			renderingMethod = RenderingMethod.ForwardHigh;
		}
		else
		{
			renderingMethod = RenderingMethod.ForwardLow;
		}
		if (this.method != renderingMethod)
		{
			this.TerminateRenderingMethod(Camera);
			this.method = renderingMethod;
			this.InitializeRenderingMethod(Camera);
		}
	}

	// Token: 0x06001D79 RID: 7545 RVA: 0x000995D0 File Offset: 0x000977D0
	public void SetDepthTextureMode(Camera Camera)
	{
		if (this.desiredDTM != null)
		{
			if (Camera.depthTextureMode != this.desiredDTM)
			{
				if (this.originalDTM == null)
				{
					this.originalDTM = new DepthTextureMode?(Camera.depthTextureMode);
				}
				else
				{
					Camera.depthTextureMode = this.originalDTM.Value;
				}
				Camera.depthTextureMode |= this.desiredDTM.Value;
			}
		}
		else
		{
			this.RestoreDepthTextureMode(Camera);
		}
	}

	// Token: 0x06001D7A RID: 7546 RVA: 0x000172DE File Offset: 0x000154DE
	public void RestoreDepthTextureMode(Camera Camera)
	{
		if (this.originalDTM != null && Camera != null)
		{
			Camera.depthTextureMode = this.originalDTM.Value;
		}
	}

	// Token: 0x040018EE RID: 6382
	public RenderingMethod method;

	// Token: 0x040018EF RID: 6383
	public CommandBuffer maskBuffer;

	// Token: 0x040018F0 RID: 6384
	public CommandBuffer projectionBuffer;

	// Token: 0x040018F1 RID: 6385
	public CullingGroup maskCulling;

	// Token: 0x040018F2 RID: 6386
	public CullingGroup projectionCulling;

	// Token: 0x040018F3 RID: 6387
	public bool enabled;

	// Token: 0x040018F4 RID: 6388
	public bool sceneCamera;

	// Token: 0x040018F5 RID: 6389
	public bool previewCamera;

	// Token: 0x040018F6 RID: 6390
	public CustomDepthTextureMode customDTM;

	// Token: 0x040018F7 RID: 6391
	public DepthTextureMode? originalDTM;

	// Token: 0x040018F8 RID: 6392
	public DepthTextureMode? desiredDTM;
}

using System;
using TMG.Core;
using UnityEngine;

// Token: 0x020000E2 RID: 226
public class CH3CheckerPiece : TMGMonoBehaviour
{
	// Token: 0x17000073 RID: 115
	// (get) Token: 0x060008EB RID: 2283 RVA: 0x00009263 File Offset: 0x00007463
	// (set) Token: 0x060008EC RID: 2284 RVA: 0x0000926B File Offset: 0x0000746B
	public bool isPromoted { get; private set; }

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x060008ED RID: 2285 RVA: 0x00009274 File Offset: 0x00007474
	// (set) Token: 0x060008EE RID: 2286 RVA: 0x0000927C File Offset: 0x0000747C
	public bool isCaptured { get; private set; }

	// Token: 0x060008EF RID: 2287 RVA: 0x0004B0C4 File Offset: 0x000492C4
	public void Initialize(CH3CheckerBoardSpace checkerBoardSpace, Transform parent, bool _isWhite)
	{
		this.CheckerBoardSpace = checkerBoardSpace;
		this.PieceColor = ((!_isWhite) ? CheckerPieceColor.BLACK : CheckerPieceColor.WHITE);
		base.transform.SetParent(parent);
		base.transform.localPosition = this.CheckerBoardSpace.Position;
		base.transform.localEulerAngles = Vector3.zero;
		this.m_CheckerPiece = GameObject.CreatePrimitive(PrimitiveType.Cube);
		this.m_CheckerPiece.transform.SetParent(base.transform);
		this.m_CheckerPiece.transform.localPosition = Vector3.zero;
		this.m_CheckerPiece.transform.localEulerAngles = Vector3.zero;
		this.m_CheckerPiece.transform.localScale = new Vector3(0.2f, 0.04f, 0.2f);
		this.m_CheckerPiece.GetComponent<MeshRenderer>().material.color = ((!_isWhite) ? Color.black : Color.yellow);
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x00009285 File Offset: 0x00007485
	public void Capture(float delay)
	{
		this.isCaptured = true;
		this.CheckerBoardSpace.CheckerPiece = null;
		global::UnityEngine.Object.Destroy(this.m_CheckerPiece, delay);
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x0004B1B8 File Offset: 0x000493B8
	public void Promote()
	{
		if (this.isPromoted)
		{
			return;
		}
		this.isPromoted = true;
		this.m_CheckerPiece.transform.localScale += new Vector3(0f, 0.05f, 0f);
		this.m_CheckerPiece.GetComponent<MeshRenderer>().material.color = ((this.PieceColor != CheckerPieceColor.WHITE) ? Color.red : Color.green);
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x000092A6 File Offset: 0x000074A6
	public void Reset(CH3CheckerBoardSpace originCheckerBoardSpace)
	{
		this.CheckerBoardSpace = originCheckerBoardSpace;
		base.transform.localPosition = this.CheckerBoardSpace.Position;
		this.m_CheckerPiece.SetActive(true);
		this.isCaptured = false;
		this.isPromoted = false;
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x0400074A RID: 1866
	public CH3CheckerBoardSpace CheckerBoardSpace;

	// Token: 0x0400074B RID: 1867
	public CheckerPieceColor PieceColor;

	// Token: 0x0400074E RID: 1870
	private GameObject m_CheckerPiece;

	// Token: 0x0400074F RID: 1871
	private GameObject m_PromotedCheckerPiece;
}

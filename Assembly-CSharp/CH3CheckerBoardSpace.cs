using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class CH3CheckerBoardSpace
{
	// Token: 0x1700005E RID: 94
	// (get) Token: 0x06000696 RID: 1686 RVA: 0x00007CC0 File Offset: 0x00005EC0
	public bool isEmpty
	{
		get
		{
			return this.CheckerPiece == null;
		}
	}

	// Token: 0x0400052F RID: 1327
	public List<CH3CheckerBoardSpace> ConnectedSpaces;

	// Token: 0x04000530 RID: 1328
	public CH3CheckerPiece CheckerPiece;

	// Token: 0x04000531 RID: 1329
	public Vector3 Position;

	// Token: 0x04000532 RID: 1330
	public int Row;

	// Token: 0x04000533 RID: 1331
	public int Column;

	// Token: 0x04000534 RID: 1332
	public bool isJumping;
}

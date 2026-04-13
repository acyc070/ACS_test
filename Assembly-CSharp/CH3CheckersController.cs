using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public class CH3CheckersController : BaseController
{
	// Token: 0x06000698 RID: 1688 RVA: 0x00007CFE File Offset: 0x00005EFE
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.InitBoard();
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x00007D0C File Offset: 0x00005F0C
	private void Update()
	{
		if (this.m_IsPlaying)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			this.m_IsPlaying = true;
			this.Play();
		}
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x0003CBCC File Offset: 0x0003ADCC
	private void InitBoard()
	{
		List<CH3CheckerBoardSpace> newBoardSpaces = this.GetNewBoardSpaces();
		bool flag = false;
		int num = 0;
		for (int i = 0; i < newBoardSpaces.Count; i++)
		{
			CH3CheckerBoardSpace ch3CheckerBoardSpace = newBoardSpaces[i];
			ch3CheckerBoardSpace.Column = num;
			if (flag)
			{
				if (ch3CheckerBoardSpace.Row < 3 || ch3CheckerBoardSpace.Row > 4)
				{
					bool flag2 = ch3CheckerBoardSpace.Row < 3;
					ch3CheckerBoardSpace.CheckerPiece = this.CreateCheckerPiece(ch3CheckerBoardSpace, flag2);
					((!flag2) ? this.m_BlackPieces : this.m_WhitePieces).Add(ch3CheckerBoardSpace.CheckerPiece);
				}
				if (!this.m_BoardSpaces.ContainsKey(ch3CheckerBoardSpace.Row))
				{
					this.m_BoardSpaces.Add(ch3CheckerBoardSpace.Row, new List<CH3CheckerBoardSpace>());
				}
				this.m_BoardSpaces[ch3CheckerBoardSpace.Row].Add(ch3CheckerBoardSpace);
			}
			flag = !flag;
			num++;
			if (num >= 8)
			{
				num = 0;
				flag = !flag;
			}
		}
		this.GenerateConnectedSpaces();
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x0003CCD4 File Offset: 0x0003AED4
	private CH3CheckerBoardSpace CreateCheckerBoardSpace(Vector3 position, int row, int column)
	{
		return new CH3CheckerBoardSpace
		{
			Position = position,
			Row = row,
			Column = column
		};
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x0003CD00 File Offset: 0x0003AF00
	private CH3CheckerPiece CreateCheckerPiece(CH3CheckerBoardSpace boardSpace, bool isWhite)
	{
		CH3CheckerPiece ch3CheckerPiece = new GameObject("CheckerPiece_" + ((!isWhite) ? "Black" : "White")).AddComponent<CH3CheckerPiece>();
		ch3CheckerPiece.Initialize(boardSpace, this.m_BoardSpaceParent, isWhite);
		return ch3CheckerPiece;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x0003CD48 File Offset: 0x0003AF48
	private List<CH3CheckerBoardSpace> GetNewBoardSpaces()
	{
		List<CH3CheckerBoardSpace> list = new List<CH3CheckerBoardSpace>();
		Vector3 vector = new Vector3(1.05f, 0f, -1.05f);
		for (int i = 0; i < 8; i++)
		{
			vector.x = 1.05f - (float)i * 0.3f;
			vector.z = -1.05f;
			for (int j = 0; j < 8; j++)
			{
				list.Add(this.CreateCheckerBoardSpace(vector, i, j));
				vector.z += 0.3f;
			}
		}
		return list;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x0003CDDC File Offset: 0x0003AFDC
	private void GenerateConnectedSpaces()
	{
		foreach (int num in this.m_BoardSpaces.Keys)
		{
			for (int i = 0; i < this.m_BoardSpaces[num].Count; i++)
			{
				int num2 = num - 1;
				int num3 = num + 1;
				int num4 = this.m_BoardSpaces[num][i].Column - 1;
				int num5 = this.m_BoardSpaces[num][i].Column + 1;
				List<CH3CheckerBoardSpace> list = new List<CH3CheckerBoardSpace>();
				if (num2 >= 0)
				{
					if (num4 >= 0)
					{
						foreach (CH3CheckerBoardSpace ch3CheckerBoardSpace in this.m_BoardSpaces[num2])
						{
							if (ch3CheckerBoardSpace.Column == num4)
							{
								list.Add(ch3CheckerBoardSpace);
							}
						}
					}
					if (num5 < 8)
					{
						foreach (CH3CheckerBoardSpace ch3CheckerBoardSpace2 in this.m_BoardSpaces[num2])
						{
							if (ch3CheckerBoardSpace2.Column == num5)
							{
								list.Add(ch3CheckerBoardSpace2);
							}
						}
					}
				}
				if (num3 < 8)
				{
					if (num4 >= 0)
					{
						foreach (CH3CheckerBoardSpace ch3CheckerBoardSpace3 in this.m_BoardSpaces[num3])
						{
							if (ch3CheckerBoardSpace3.Column == num4)
							{
								list.Add(ch3CheckerBoardSpace3);
							}
						}
					}
					if (num5 < 8)
					{
						foreach (CH3CheckerBoardSpace ch3CheckerBoardSpace4 in this.m_BoardSpaces[num3])
						{
							if (ch3CheckerBoardSpace4.Column == num5)
							{
								list.Add(ch3CheckerBoardSpace4);
							}
						}
					}
				}
				this.m_BoardSpaces[num][i].ConnectedSpaces = list;
			}
		}
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00007D33 File Offset: 0x00005F33
	private void Play()
	{
		this.m_IsWhiteTurn = !this.m_IsWhiteTurn;
		this.PlayNextMove().OnComplete(new TweenCallback(this.TurnOnComplete));
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00007D5C File Offset: 0x00005F5C
	private void TurnOnComplete()
	{
		this._capture = 0;
		this.Play();
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x0003D0B0 File Offset: 0x0003B2B0
	private Dictionary<bool, List<List<CH3CheckerBoardSpace>>> GetPotentialMoves()
	{
		Dictionary<bool, List<List<CH3CheckerBoardSpace>>> dictionary = new Dictionary<bool, List<List<CH3CheckerBoardSpace>>>();
		((!this.m_IsWhiteTurn) ? this.m_BlackPieces : this.m_WhitePieces).Shuffle<CH3CheckerPiece>();
		for (int i = 0; i < ((!this.m_IsWhiteTurn) ? this.m_BlackPieces : this.m_WhitePieces).Count; i++)
		{
			CH3CheckerPiece ch3CheckerPiece = ((!this.m_IsWhiteTurn) ? this.m_BlackPieces : this.m_WhitePieces)[i];
			if (!ch3CheckerPiece.isCaptured)
			{
				List<List<CH3CheckerBoardSpace>> list = new List<List<CH3CheckerBoardSpace>>();
				list = this.GetPotentialBoardSpaces(ch3CheckerPiece.CheckerBoardSpace);
				if (list.Count > 0)
				{
					for (int j = 0; j < list.Count; j++)
					{
						list[j].Insert(0, ch3CheckerPiece.CheckerBoardSpace);
					}
					List<List<CH3CheckerBoardSpace>> list2 = new List<List<CH3CheckerBoardSpace>>();
					List<List<CH3CheckerBoardSpace>> list3 = new List<List<CH3CheckerBoardSpace>>();
					for (int k = 0; k < list.Count; k++)
					{
						if (list[k][1].isJumping)
						{
							list3.Add(list[k]);
						}
						else
						{
							list2.Add(list[k]);
						}
					}
					if (list2.Count > 0)
					{
						if (!dictionary.ContainsKey(false))
						{
							dictionary.Add(false, new List<List<CH3CheckerBoardSpace>>());
						}
						foreach (List<CH3CheckerBoardSpace> list4 in list2)
						{
							dictionary[false].Add(list4);
						}
					}
					if (list3.Count > 0)
					{
						if (!dictionary.ContainsKey(true))
						{
							dictionary.Add(true, new List<List<CH3CheckerBoardSpace>>());
						}
						foreach (List<CH3CheckerBoardSpace> list5 in list3)
						{
							dictionary[true].Add(list5);
						}
					}
				}
			}
		}
		return dictionary;
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x0003D2F0 File Offset: 0x0003B4F0
	private List<List<CH3CheckerBoardSpace>> GetPotentialBoardSpaces(CH3CheckerBoardSpace startingBoardSpace)
	{
		List<List<CH3CheckerBoardSpace>> list = new List<List<CH3CheckerBoardSpace>>();
		int num = startingBoardSpace.Row + ((startingBoardSpace.CheckerPiece.PieceColor != CheckerPieceColor.WHITE) ? (-1) : 1);
		if (!startingBoardSpace.CheckerPiece.isPromoted && (!this.m_BoardSpaces.ContainsKey(num) || num < 0 || num >= 8))
		{
			return list;
		}
		if (startingBoardSpace.ConnectedSpaces.Count <= 0)
		{
			return list;
		}
		for (int i = 0; i < startingBoardSpace.ConnectedSpaces.Count; i++)
		{
			if (startingBoardSpace.CheckerPiece.isPromoted)
			{
				if (!startingBoardSpace.ConnectedSpaces[i].isEmpty)
				{
					if (startingBoardSpace.ConnectedSpaces[i].CheckerPiece.PieceColor != startingBoardSpace.CheckerPiece.PieceColor)
					{
						int num2 = startingBoardSpace.ConnectedSpaces[i].Row + ((startingBoardSpace.ConnectedSpaces[i].Row <= startingBoardSpace.Row) ? (-1) : 1);
						int num3 = startingBoardSpace.ConnectedSpaces[i].Column + ((startingBoardSpace.ConnectedSpaces[i].Column <= startingBoardSpace.Column) ? (-1) : 1);
						List<CH3CheckerBoardSpace> list2 = new List<CH3CheckerBoardSpace>();
						CH3CheckerBoardSpace ch3CheckerBoardSpace = this.CheckJumpBoardSpace(startingBoardSpace.ConnectedSpaces[i], num3, num2);
						if (ch3CheckerBoardSpace != null)
						{
							ch3CheckerBoardSpace.isJumping = true;
							list2.Add(ch3CheckerBoardSpace);
							bool flag = true;
							while (flag)
							{
								int num4 = 0;
								foreach (CH3CheckerBoardSpace ch3CheckerBoardSpace2 in ch3CheckerBoardSpace.ConnectedSpaces)
								{
									if (!ch3CheckerBoardSpace2.isEmpty && ch3CheckerBoardSpace2.CheckerPiece.PieceColor != startingBoardSpace.CheckerPiece.PieceColor)
									{
										num2 = ch3CheckerBoardSpace2.Row + ((ch3CheckerBoardSpace2.Row <= ch3CheckerBoardSpace.Row) ? (-1) : 1);
										num3 = ch3CheckerBoardSpace2.Column + ((ch3CheckerBoardSpace2.Column <= ch3CheckerBoardSpace.Column) ? (-1) : 1);
										CH3CheckerBoardSpace ch3CheckerBoardSpace3 = this.CheckJumpBoardSpace(ch3CheckerBoardSpace2, num3, num2);
										if (ch3CheckerBoardSpace3 != null)
										{
											ch3CheckerBoardSpace3.isJumping = true;
											list2.Add(ch3CheckerBoardSpace3);
											ch3CheckerBoardSpace = ch3CheckerBoardSpace3;
											break;
										}
										flag = false;
									}
									else
									{
										num4++;
										if (num4 >= ch3CheckerBoardSpace.ConnectedSpaces.Count)
										{
											flag = false;
										}
									}
								}
							}
							list.Add(list2);
						}
					}
				}
				else
				{
					list.Add(new List<CH3CheckerBoardSpace> { startingBoardSpace.ConnectedSpaces[i] });
				}
			}
			else if (startingBoardSpace.ConnectedSpaces[i].Row == num)
			{
				if (!startingBoardSpace.ConnectedSpaces[i].isEmpty)
				{
					if (startingBoardSpace.ConnectedSpaces[i].CheckerPiece.PieceColor != startingBoardSpace.CheckerPiece.PieceColor)
					{
						int num5 = startingBoardSpace.ConnectedSpaces[i].Row + ((startingBoardSpace.ConnectedSpaces[i].Row <= startingBoardSpace.Row) ? (-1) : 1);
						int num6 = startingBoardSpace.ConnectedSpaces[i].Column + ((startingBoardSpace.ConnectedSpaces[i].Column <= startingBoardSpace.Column) ? (-1) : 1);
						List<CH3CheckerBoardSpace> list3 = new List<CH3CheckerBoardSpace>();
						CH3CheckerBoardSpace ch3CheckerBoardSpace4 = this.CheckJumpBoardSpace(startingBoardSpace.ConnectedSpaces[i], num6, num5);
						if (ch3CheckerBoardSpace4 != null)
						{
							ch3CheckerBoardSpace4.isJumping = true;
							list3.Add(ch3CheckerBoardSpace4);
							list.Add(list3);
						}
					}
				}
				else
				{
					list.Add(new List<CH3CheckerBoardSpace> { startingBoardSpace.ConnectedSpaces[i] });
				}
			}
		}
		list.Shuffle<List<CH3CheckerBoardSpace>>();
		return list;
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x0003D6F4 File Offset: 0x0003B8F4
	private CH3CheckerBoardSpace CheckJumpBoardSpace(CH3CheckerBoardSpace jumpedBoardSpace, int column, int row)
	{
		CH3CheckerBoardSpace ch3CheckerBoardSpace = null;
		for (int i = 0; i < jumpedBoardSpace.ConnectedSpaces.Count; i++)
		{
			if (jumpedBoardSpace.ConnectedSpaces[i].Column == column && jumpedBoardSpace.ConnectedSpaces[i].Row == row && jumpedBoardSpace.ConnectedSpaces[i].isEmpty)
			{
				ch3CheckerBoardSpace = jumpedBoardSpace.ConnectedSpaces[i];
				this._capture++;
				jumpedBoardSpace.CheckerPiece.Capture((float)this._capture * 0.25f);
				break;
			}
		}
		return ch3CheckerBoardSpace;
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x0003D79C File Offset: 0x0003B99C
	private Sequence PlayNextMove()
	{
		Sequence sequence = DOTween.Sequence();
		Dictionary<bool, List<List<CH3CheckerBoardSpace>>> potentialMoves = this.GetPotentialMoves();
		if (potentialMoves.Count <= 0)
		{
			Debug.Log("Zero potential moves, something wrong!");
		}
		List<CH3CheckerBoardSpace> moves = new List<CH3CheckerBoardSpace>();
		bool flag = potentialMoves.ContainsKey(true);
		int num = global::UnityEngine.Random.Range(0, potentialMoves[flag].Count - 1);
		moves = potentialMoves[flag][num];
		float num2 = 0f;
		if (moves.Count <= 0)
		{
			Debug.Log("No Available Moves...");
			return sequence;
		}
		CH3CheckerPiece piece = moves[0].CheckerPiece;
		for (int i = 1; i < moves.Count; i++)
		{
			Vector3 position = moves[i].Position;
			sequence.Insert(num2, piece.transform.DOLocalMoveX(position.x, 0.25f, false).SetEase(Ease.InOutQuad));
			sequence.Insert(num2, piece.transform.DOLocalMoveZ(position.z, 0.25f, false).SetEase(Ease.InOutQuad));
			sequence.Insert(num2, piece.transform.DOLocalMoveY(position.y + 0.2f, 0.125f, false).SetEase(Ease.InQuad));
			sequence.Insert(num2 + 0.125f, piece.transform.DOLocalMoveY(position.y, 0.125f, false).SetEase(Ease.OutQuad));
			num2 += 0.25f;
		}
		sequence.InsertCallback(num2, delegate
		{
			for (int j = 0; j < moves.Count; j++)
			{
				moves[j].isJumping = false;
				if (j < moves.Count - 1)
				{
					moves[j].CheckerPiece = null;
				}
				else
				{
					foreach (CH3CheckerPiece ch3CheckerPiece in ((!this.m_IsWhiteTurn) ? this.m_BlackPieces : this.m_WhitePieces))
					{
						if (ch3CheckerPiece.Equals(piece))
						{
							if (moves[j].Row == 0 || moves[j].Row == 7)
							{
								ch3CheckerPiece.Promote();
							}
							ch3CheckerPiece.CheckerBoardSpace = moves[j];
							moves[j].CheckerPiece = ch3CheckerPiece;
							break;
						}
					}
				}
			}
		});
		return sequence;
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x00006F06 File Offset: 0x00005106
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000535 RID: 1333
	private const int BOARD_ARRAY = 8;

	// Token: 0x04000536 RID: 1334
	private const int WHITE_MOVE_DIRECTION = 1;

	// Token: 0x04000537 RID: 1335
	private const int BLACK_MOVE_DICECTION = -1;

	// Token: 0x04000538 RID: 1336
	private const float BOARD_START_POSITION = 1.05f;

	// Token: 0x04000539 RID: 1337
	private const float BOARD_POSITION_PADDING = 0.3f;

	// Token: 0x0400053A RID: 1338
	private const float PIECE_MOVE_SPEED = 0.25f;

	// Token: 0x0400053B RID: 1339
	private const float PIECE_MOVE_SPEED_HALF = 0.125f;

	// Token: 0x0400053C RID: 1340
	[SerializeField]
	private Transform m_BoardSpaceParent;

	// Token: 0x0400053D RID: 1341
	private Dictionary<int, List<CH3CheckerBoardSpace>> m_BoardSpaces = new Dictionary<int, List<CH3CheckerBoardSpace>>();

	// Token: 0x0400053E RID: 1342
	private List<CH3CheckerPiece> m_WhitePieces = new List<CH3CheckerPiece>();

	// Token: 0x0400053F RID: 1343
	private List<CH3CheckerPiece> m_BlackPieces = new List<CH3CheckerPiece>();

	// Token: 0x04000540 RID: 1344
	private bool m_IsPlaying;

	// Token: 0x04000541 RID: 1345
	private bool m_IsWhiteTurn = true;

	// Token: 0x04000542 RID: 1346
	private int m_ActivePieceIndex;

	// Token: 0x04000543 RID: 1347
	private int _capture;
}

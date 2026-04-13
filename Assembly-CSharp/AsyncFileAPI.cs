using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using TMG.Data;
using UnityEngine;

// Token: 0x02000596 RID: 1430
public static class AsyncFileAPI
{
	// Token: 0x140000D4 RID: 212
	// (add) Token: 0x060027D9 RID: 10201 RVA: 0x000E7924 File Offset: 0x000E5B24
	// (remove) Token: 0x060027DA RID: 10202 RVA: 0x000E7958 File Offset: 0x000E5B58
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event Action OnFileWriteErrorEvent;

	// Token: 0x140000D5 RID: 213
	// (add) Token: 0x060027DB RID: 10203 RVA: 0x000E798C File Offset: 0x000E5B8C
	// (remove) Token: 0x060027DC RID: 10204 RVA: 0x000E79C0 File Offset: 0x000E5BC0
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event Action OnFileWrittenEvent;

	// Token: 0x060027DD RID: 10205 RVA: 0x000E79F4 File Offset: 0x000E5BF4
	public static void SaveData(GameData gameData, string fileName)
	{
		if (AsyncFileAPI._started)
		{
			global::UnityEngine.Debug.LogError("SaveData call already in progress on file '" + AsyncFileAPI._fileName + "'...");
			return;
		}
		AsyncFileAPI._fileName = fileName;
		AsyncFileAPI._data = gameData;
		AsyncFileAPI._thread = new Thread(new ThreadStart(AsyncFileAPI.ThreadedSave));
		AsyncFileAPI._thread.Start();
	}

	// Token: 0x060027DE RID: 10206 RVA: 0x000E7A64 File Offset: 0x000E5C64
	private static void ThreadedSave()
	{
		AsyncFileAPI._started = true;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		byte[] array;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			binaryFormatter.Serialize(memoryStream, AsyncFileAPI._data);
			array = memoryStream.ToArray();
		}
		AsyncFileAPI.manualEvent = new ManualResetEvent(false);
		FileStream fileStream = new FileStream(AsyncFileAPI._fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, true);
		fileStream.BeginWrite(array, 0, array.Length, new AsyncCallback(AsyncFileAPI.EndWriteCallback), new AsyncFileAPI.State(fileStream, array, AsyncFileAPI.manualEvent));
		AsyncFileAPI.manualEvent.WaitOne();
		if (AsyncFileAPI.OnFileWrittenEvent != null)
		{
			AsyncFileAPI.OnFileWrittenEvent();
		}
		AsyncFileAPI._started = false;
	}

	// Token: 0x060027DF RID: 10207 RVA: 0x000E7B20 File Offset: 0x000E5D20
	private static void EndWriteCallback(IAsyncResult asyncResult)
	{
		AsyncFileAPI.State state = (AsyncFileAPI.State)asyncResult.AsyncState;
		FileStream fstream = state.FStream;
		fstream.EndWrite(asyncResult);
		fstream.Position = 0L;
		asyncResult = fstream.BeginRead(state.ReadArray, 0, state.ReadArray.Length, new AsyncCallback(AsyncFileAPI.EndReadCallback), state);
	}

	// Token: 0x060027E0 RID: 10208 RVA: 0x000E7B74 File Offset: 0x000E5D74
	private static void EndReadCallback(IAsyncResult asyncResult)
	{
		AsyncFileAPI.State state = (AsyncFileAPI.State)asyncResult.AsyncState;
		int num = state.FStream.EndRead(asyncResult);
		int i = 0;
		while (i < num)
		{
			if (state.ReadArray[i] != state.WriteArray[i++])
			{
				Console.WriteLine("Error writing data.");
				global::UnityEngine.Debug.LogError("Error writing data.");
				state.FStream.Close();
				return;
			}
		}
		state.FStream.Close();
		state.ManualEvent.Set();
	}

	// Token: 0x04001FCD RID: 8141
	public static Thread _thread;

	// Token: 0x04001FCE RID: 8142
	private static bool _started;

	// Token: 0x04001FCF RID: 8143
	private static string _fileName;

	// Token: 0x04001FD0 RID: 8144
	private static GameData _data;

	// Token: 0x04001FD1 RID: 8145
	private static ManualResetEvent manualEvent;

	// Token: 0x02000597 RID: 1431
	private class State
	{
		// Token: 0x060027E2 RID: 10210 RVA: 0x0001C929 File Offset: 0x0001AB29
		public State(FileStream fStream, byte[] writeArray, ManualResetEvent manualEvent)
		{
			this.fStream = fStream;
			this.writeArray = writeArray;
			this.manualEvent = manualEvent;
			this.readArray = new byte[writeArray.Length];
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x060027E3 RID: 10211 RVA: 0x0001C954 File Offset: 0x0001AB54
		public FileStream FStream
		{
			get
			{
				return this.fStream;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x060027E4 RID: 10212 RVA: 0x0001C95C File Offset: 0x0001AB5C
		public byte[] WriteArray
		{
			get
			{
				return this.writeArray;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060027E5 RID: 10213 RVA: 0x0001C964 File Offset: 0x0001AB64
		public byte[] ReadArray
		{
			get
			{
				return this.readArray;
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x060027E6 RID: 10214 RVA: 0x0001C96C File Offset: 0x0001AB6C
		public ManualResetEvent ManualEvent
		{
			get
			{
				return this.manualEvent;
			}
		}

		// Token: 0x04001FD3 RID: 8147
		private FileStream fStream;

		// Token: 0x04001FD4 RID: 8148
		private byte[] writeArray;

		// Token: 0x04001FD5 RID: 8149
		private byte[] readArray;

		// Token: 0x04001FD6 RID: 8150
		private ManualResetEvent manualEvent;
	}
}

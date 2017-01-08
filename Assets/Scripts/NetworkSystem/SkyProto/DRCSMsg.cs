using UnityEngine;
using System.Collections;
using SkyWarProto;

public class DRCSMsg : CSMsg, IMsg {
	
	#region IMsg implementation

	public DrError.ErrorType Pack (DrWriteBuf dstBuf, uint cutVer = 0u)
	{
		return base.pack(dstBuf, cutVer);
	}

	public DrError.ErrorType Unpack (byte[] data, int len, uint curVer = 0u)
	{
		int used = 0;
		return base.unpack(data, len, ref used, curVer);
	}

	public uint Sequence {
		get {
			return stHead.uiSeq;
		}
		set {
			stHead.uiSeq = value;
		}
	}

	public ushort Id {
		get {
			return stHead.unMsgID;
		}
		set {
			stHead.unMsgID = value;
		}
	}

	#endregion




}

using UnityEngine;
using System.Collections;

public interface IMsg {

	uint Sequence {get;set;}

	ushort Id {get;set;}

	DrError.ErrorType Pack(DrWriteBuf dstBuf, uint cutVer = 0);
	DrError.ErrorType Unpack(byte[] data, int len, uint curVer = 0);

}

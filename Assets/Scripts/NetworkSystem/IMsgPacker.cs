using UnityEngine;
using System.Collections;

public interface IMsgPacker {

	byte[] Pack(IMsg msg, out int len);
	IMsg Unpack(byte[] data, int len);

}

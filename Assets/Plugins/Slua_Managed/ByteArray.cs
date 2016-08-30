

namespace SLua
{
	[CustomLuaClass]
	//ByteArray
	public class ByteArray
	{
		public byte[] data = null;

		public ByteArray()
		{
			//
		}

		public ByteArray(byte[] d)
		{
			this.data = d;
		}
	}
}


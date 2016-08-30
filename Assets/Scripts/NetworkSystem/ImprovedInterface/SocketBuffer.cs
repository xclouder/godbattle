using Debug = UnityEngine.Debug;
using System;
using System.Collections;

public class SocketBuffer {

	private byte[] m_buffer;
	public int BufferSize {get; private set;}

	public SocketBuffer(int bufferSize)
	{
		m_buffer = new byte[bufferSize];
		BufferSize = bufferSize;
	}

	public int ProducePosition{get; private set;}
	public int ConsumePosition{get; private set;}

	public int RawAvailableSpace {

		get {
			if (ProducePosition < ConsumePosition)
			{
				return  ConsumePosition - ProducePosition;
			}

			return BufferSize - ProducePosition;
		}

	}

	public int AvailableSpace {get {
		return BufferSize - m_availableDataLen;
	}}

	public bool HasAvailableData
	{
		get {
			return AvailableDataLength > 0;
		}
	}

	public bool AddData(byte[] data)
	{
		Debug.Assert(data != null);

		var dataLen = data.Length;
		Debug.Assert(dataLen > 0);

		if (dataLen > BufferSize)
			throw new System.Exception("Out of buffer size, please adjust your bufferSize to send so big data");

		var space = AvailableSpace;
		if (space < dataLen)
		{
			return false;
		}


		//copy data
		int remainingSpace = 0;
		if (ProducePosition >= ConsumePosition)
		{
			remainingSpace = BufferSize - ProducePosition;
		}
		else
		{
			remainingSpace = ConsumePosition - ProducePosition;
		}

		if (remainingSpace < dataLen)
		{
			Array.Copy(data, 0, m_buffer, ProducePosition, remainingSpace);
			Array.Copy(data, remainingSpace, m_buffer, 0, dataLen - remainingSpace);
		}
		else
		{
			Array.Copy(data, 0, m_buffer, ProducePosition, dataLen);
		}


		SetBytesProduced(dataLen);

		return true;
	}

	public byte[] RawBuffer
	{
		get {
			return m_buffer;
		}
	}

	/// <summary>
	/// 由于使用了Circle Array，取数据的时候可能存在buffer数据位于数组的尾部和头部，这时为了防止copy数组，将数据分两次取出来:
	/// 1) consume pos -> array end
	/// 2) array head -> produce pos
	/// </summary>
	/// <value>The length of the current picking data.</value>
	public int CurrentPickingDataLength
	{
		get { 
			if (ProducePosition <= ConsumePosition)
				return BufferSize - ConsumePosition;
			else
				return ProducePosition - ConsumePosition;
		}
	}

	private int m_availableDataLen;
	public int AvailableDataLength
	{
		get { 
			return m_availableDataLen;
		}
	}

	public void SetBytesUsed(int bytesUsed)
	{
		Debug.Assert(m_availableDataLen >= bytesUsed);

		m_availableDataLen -= bytesUsed;
		ConsumePosition += bytesUsed;
		if (ConsumePosition >= BufferSize)
			ConsumePosition -= BufferSize;
	}

	public void SetBytesProduced(int bytesProduced)
	{
		Debug.Assert(AvailableSpace >= bytesProduced);

		m_availableDataLen += bytesProduced;
		ProducePosition += bytesProduced;
		if (ProducePosition >= BufferSize)
			ProducePosition -= BufferSize;
	}

}

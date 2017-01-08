using UnityEngine;
using System.Collections;
using System;

public class DrWriteBuf
{
    private byte[] begin;
    private int position;
    private int length;

    public DrWriteBuf()
    {
        begin = null;
        position = 0;
        length = 0;
    }

    public DrWriteBuf(byte[] buffer, int size)
    {
        begin = buffer;
        position = 0;
        length = size;
    }

    public void Set(byte[] ptr, int len, int pos = 0)
    {
        begin = ptr;
        position = pos;
        length = 0;

        if (null != begin)
        {
            length = len;
        }
    }

    public void SetPosition(int pos)
    {
        position = pos;
    }

    public byte[] GetBeginPtr()
    {
        return begin;
    }

    public int GetUsedSize()
    {
        return position;
    }

    public void WriteBytes(byte[] bytes)
    {
        System.Buffer.BlockCopy(bytes, 0, begin, position, bytes.Length);

        position += bytes.Length;
    }

    public void WriteBytes(byte[] bytes, int len)
    {
        System.Buffer.BlockCopy(bytes, 0, begin, position, len);

        position += len;
    }

    public DrError.ErrorType WriteInt8(sbyte src)
    {
        return WriteUInt8((byte)src);
    }

    public DrError.ErrorType WriteUInt8(byte src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        if (sizeof(byte) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        begin[position++] = src;

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType WriteInt16(short src)
    {
        return WriteUInt16((ushort)src);
    }

    public DrError.ErrorType WriteUInt16(ushort src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        if (sizeof(ushort) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        WriteBytes(BitConverter.GetBytes(src));

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType WriteInt32(int src)
    {
        return WriteUInt32((uint)src);
    }

    public DrError.ErrorType WriteUInt32(uint src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        if (sizeof(uint) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        WriteBytes(BitConverter.GetBytes(src));

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType WriteInt64(long src)
    {
        return WriteUInt64((ulong)src);
    }

    public DrError.ErrorType WriteUInt64(ulong src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        if (sizeof(ulong) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        WriteBytes(BitConverter.GetBytes(src));

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType WriteString(string src, int max)
    {
        if (src.Length + 1 > max)
        {
            return DrError.ErrorType.DR_ERR_STR_LEN_TOO_BIG;
        }

        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        if (sizeof(int) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        WriteInt32(src.Length);
        WriteBytes(System.Text.Encoding.Default.GetBytes(src));

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType WriteCString(byte[] src, Int32 count)
    {
        if (null == begin)
        {
            return DrError.ErrorType.DR_ERR_ARG_POINTER_IS_NULL;
        }

        if (count > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        for (int i = 0; i < count; i++)
        {
            begin[position++] = src[i];
        }

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType WriteWString(Int16[] src, Int32 count)
    {
        if (null == begin)
        {
            return DrError.ErrorType.DR_ERR_ARG_POINTER_IS_NULL;
        }

        if ((2 * count) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_WRITE;
        }

        for (int i = 0; i < count; i++)
        {
            byte[] buffer = BitConverter.GetBytes(src[i]);
            for (int j = 0; j < buffer.GetLength(0); j++)
            {
                begin[position++] = buffer[j];
            }
        }

        return DrError.ErrorType.DR_NO_ERROR;
    }
}

public class DrReadBuf
{
    private byte[] begin;
    private int position;
    private int length;

    public DrReadBuf()
    {
        begin = null;
        position = 0;
        length = 0;
    }

    public DrReadBuf(byte[] buffer, int size)
    {
        begin = buffer;
        position = 0;
        length = size;
    }

    public void Set(byte[] buffer, int size, int pos = 0)
    {
        begin = buffer;
        position = pos;
        length = size;
    }

    public int GetUsedSize()
    {
        return position;
    }

    public byte[] ReadBytes(int len)
    {
        byte[] bytes = new byte[len];
        for (int i = position, j = 0; j < len; ++i, ++j)
        {
            bytes[j] = begin[i];
        }

        position += len;

        return bytes;
    }

    public DrError.ErrorType ReadInt8(ref sbyte src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(byte) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = (sbyte)begin[position++];

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadUInt8(ref byte src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(byte) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = begin[position++];

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadInt16(ref short src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(short) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = BitConverter.ToInt16(ReadBytes(sizeof(short)), 0);

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadUInt16(ref ushort src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(ushort) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = BitConverter.ToUInt16(ReadBytes(sizeof(ushort)), 0);

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadInt32(ref int src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(int) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = BitConverter.ToInt32(ReadBytes(sizeof(int)), 0);

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadUInt32(ref uint src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(uint) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = BitConverter.ToUInt32(ReadBytes(sizeof(uint)), 0);

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadInt64(ref long src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(long) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = BitConverter.ToInt64(ReadBytes(sizeof(long)), 0);

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadUInt64(ref ulong src)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(ulong) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = BitConverter.ToUInt64(ReadBytes(sizeof(ulong)), 0);

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadString(ref string src, int max)
    {
        if (position > length)
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        if (sizeof(int) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        int len = BitConverter.ToInt32(ReadBytes(sizeof(int)), 0);


        if (len > max)
        {
            return DrError.ErrorType.DR_ERR_STR_LEN_TOO_SMALL;
        }

        if (len > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        src = System.Text.Encoding.Default.GetString(ReadBytes(len));

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadCString(ref byte[] dest, Int32 count)
    {
        if (null == begin || count > dest.GetLength(0))
        {
            return DrError.ErrorType.DR_ERR_ARG_POINTER_IS_NULL;
        }

        if (null == dest || 0 == dest.GetLength(0))
        {
            return DrError.ErrorType.DR_ERR_ARG_POINTER_IS_NULL;
        }

        if (count > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        for (int i = 0; i < count; i++)
        {
            dest[i] = begin[position++];
        }

        return DrError.ErrorType.DR_NO_ERROR;
    }

    public DrError.ErrorType ReadWString(ref Int16[] dest, Int32 count)
    {
        if (null == begin || count > dest.GetLength(0))
        {
            return DrError.ErrorType.DR_ERR_ARG_POINTER_IS_NULL;
        }

        if (null == dest || 0 == dest.GetLength(0))
        {
            return DrError.ErrorType.DR_ERR_ARG_POINTER_IS_NULL;
        }

        if ((2 * count) > (length - position))
        {
            return DrError.ErrorType.DR_ERR_SHORT_BUF_FOR_READ;
        }

        for (int i = 0; i < count; i++)
        {
            dest[i] = BitConverter.ToInt16(begin, position);
            position += sizeof(Int16);
        }

        return DrError.ErrorType.DR_NO_ERROR;
    }
}

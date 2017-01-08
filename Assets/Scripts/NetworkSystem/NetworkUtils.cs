using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class OverheadTimer
{
    private float m_ThresTime;

    private float m_StartTime;
    private float m_DeltaTime;

    public float deltaTime
    {
        get
        {
            return m_DeltaTime;
        }
    }

    public OverheadTimer()
    {
        this.m_ThresTime = 0f;
        this.m_StartTime = 0f;
        this.m_DeltaTime = 0f;
    }

    public OverheadTimer(float thresTime)
    {
        this.m_ThresTime = thresTime;
        this.m_StartTime = 0f;
        this.m_DeltaTime = 0f;
    }

    public void Start()
    {
        m_StartTime = Time.realtimeSinceStartup;
        m_DeltaTime = 0f;
    }

    public void Count()
    {
        m_DeltaTime = (Time.realtimeSinceStartup - m_StartTime) * 1000f;
    }

    public void End()
    {
        m_DeltaTime = (Time.realtimeSinceStartup - m_StartTime) * 1000f;
    }

    public void LogWarning(string protocalName)
    {
        if (m_DeltaTime >= m_ThresTime)
        {
            Debug.LogWarning("NetProfile::Protocal " + protocalName + " cost " + m_DeltaTime + " ms!");
        }
    }
}

public class NetworkConfig
{
    public const int SocketBufferSize = 1024 * 1024;                             // socket缓冲区大小
    public const int MaxPacketSize = 1024 * 128;                               // 单次数据包最大的长度
    public readonly static int PacketHeaderSize = Marshal.SizeOf(typeof(NetMsgHead));   // 数据包头大小
    public const float MaxTimeOut = 15.0f;                                      // 消息超时时间
    public const byte MaxReTryTimes = 3;                                        // 消息发送重试次数
}

public struct NetMsgHead
{
    public ushort unMsgLen;
    public byte byCmd;
    public byte byFlag;
    public uint uiUid;
}
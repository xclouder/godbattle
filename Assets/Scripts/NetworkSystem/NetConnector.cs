using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;

public delegate void ConnectEventHandler(NetResult result);

public delegate void ReconnectEventHandler(NetResult result);

public delegate void DisconnectEventHandler(NetResult result);

public delegate void ConnectorErrorEventHandler(NetResult result, string errorStr);

public delegate void ReceivedDataHandler();

public enum NetResult
{
    UnknownError = -1,
    NoError = 0,
    ParseIPError,
    NoBufferSpaceValid,
    InvalidIpAddress,
    ConnectError,
    ReadDataError,
    WriteDataError,
    SocketClosed,
}

public class NetThread
{
    private Thread m_Thread;
    private bool m_TerminateFlag;
    private System.Object m_TerminateFlagMutex;
    protected NetConnection m_NetConnection;
    protected NetConnector m_NetConnector;
    protected int m_Seq;

    public void Run()
    {
        m_Thread.Start(this);
    }

    public void Close()
    {
        SetTerminateFlag();
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
        }
        else
        {
            m_Thread.Abort();
        }
    }

    protected static void ThreadProc(object obj)
    {
        NetThread me = (NetThread)obj;
        me.Main();
    }

    protected virtual void Main()
    {

    }

    public void WaitTermination()
    {
        m_Thread.Join();
    }

    public void SetTerminateFlag()
    {
        lock (m_TerminateFlagMutex)
        {
            m_TerminateFlag = true;
        }
    }

    protected bool IsTerminateFlagSet()
    {
        lock (m_TerminateFlagMutex)
        {
            return m_TerminateFlag;
        }
    }

    public NetThread(NetConnection net, NetConnector client, int seq)
    {
        m_Thread = new Thread(ThreadProc);
        m_TerminateFlag = false;
        m_NetConnection = net;
        m_NetConnector = client;
        m_Seq = seq;
        m_TerminateFlagMutex = new System.Object();
    }
}

class SenderThread : NetThread
{
    public SenderThread(NetConnection netconnection, NetConnector tcpClient, int seq)
        : base(netconnection, tcpClient, seq)
    {
    }

    protected override void Main()
    {
        while (!IsTerminateFlagSet())
        {
            bool sleep = true;
            if (m_NetConnector.IsConnected)
            {
                CQueueSenderData pkg;
                if (m_NetConnection.DequeueRequestMsg(m_Seq, out pkg))
                {
                    sleep = false;
                    try
                    {
                        m_NetConnector.WriteData(pkg.data, 0, pkg.size);
                    }
                    catch (IOException e)
                    {
                        Debug.LogError("CNetSys:SenderThread, Main: " + e.StackTrace);
                        Debug.LogError("CNetSys:SenderThread, Main: " + e.InnerException.Message);
                    }
                }
            }
            if (sleep)
            {
                Thread.Sleep(10);
            }
        }
    }
}

class ReceiverThread : NetThread
{
    private byte[] m_recBuf;
    private int m_recBufOffset;
    private DrReadBuf m_HeadReader = new DrReadBuf();

    public int GetPackLen()
    {
        m_HeadReader.Set(m_recBuf, NetworkConfig.MaxPacketSize, 0);
        NetMsgHead head;
        head.unMsgLen = 0;
        head.byCmd = 0;
        head.byFlag = 0;
        head.uiUid = 0;
        m_HeadReader.ReadUInt16(ref head.unMsgLen);
        head.unMsgLen = (ushort)System.Net.IPAddress.NetworkToHostOrder((short)(head.unMsgLen));
        m_HeadReader.ReadUInt8(ref head.byCmd);
        m_HeadReader.ReadUInt8(ref head.byFlag);
        m_HeadReader.ReadUInt32(ref head.uiUid);
        head.uiUid = (uint)System.Net.IPAddress.NetworkToHostOrder((int)(head.uiUid));
        return (int)head.unMsgLen;
    }

    public ReceiverThread(NetConnection netSys, NetConnector netClient, int seq)
        : base(netSys, netClient, seq)
    {
        m_recBuf = new byte[NetworkConfig.SocketBufferSize];
        m_recBufOffset = 0;
    }

    protected override void Main()
    {
        while (!IsTerminateFlagSet())
        {
            try
            {
                bool sleep = true;
                if (ReadFromStream())
                {
                    sleep = false;
                }
                if (ScanPackets())
                {
                    sleep = false;
                }
                if (sleep)
                {
                    Thread.Sleep(0);
                }
            }
            catch (Exception e)
            {
                Thread.Sleep(0);
            }
        }
    }

    protected bool ReadFromStream()
    {
        int len = m_NetConnector.ReadData(m_recBuf, m_recBufOffset, m_recBuf.Length - m_recBufOffset);

        if (len == 0)
        {
            CQueueEntry entry = new CQueueEntry();
            entry.m_eType = CQueueEntry.EQuequeEntry.close;
            this.m_NetConnection.EnqueueRespondMsg(entry, m_Seq);
            return false;
        }
        else if (len < 0)
        {
            return false;
        }
        else
        {
			Debug.Log("READ FROM SOCKET LEN:" + len);
            m_recBufOffset += len;
            return true;
        }
    }

    protected bool ScanPackets()
    {
        bool packetFound = false;
        bool has = false;
        do
        {
            packetFound = false;
            if (m_recBufOffset >= NetworkConfig.PacketHeaderSize)
            {
                int Len = GetPackLen();
				Debug.LogWarning("NEED PACK SIZE:" + Len);
                if (Len <= m_recBufOffset - NetworkConfig.PacketHeaderSize && Len > 0)
                {
                    CQueueEntry entry = new CQueueEntry();
                    entry.data = new byte[Len];
                    entry.m_eType = CQueueEntry.EQuequeEntry.data;
                    Buffer.BlockCopy(m_recBuf, (int)NetworkConfig.PacketHeaderSize, entry.data, 0, Len);

                    m_NetConnection.EnqueueRespondMsg(entry, m_Seq);
                    Buffer.BlockCopy(m_recBuf, (int)(Len + NetworkConfig.PacketHeaderSize), m_recBuf, 0, (int)(m_recBufOffset - Len - NetworkConfig.PacketHeaderSize));
                    m_recBufOffset -= (int)(Len + NetworkConfig.PacketHeaderSize);
                    packetFound = true;
                    has = true;
                }
            }
        }
        while (packetFound && !IsTerminateFlagSet());
        return has;
    }
}

public class NetConnector
{
    public event ConnectEventHandler ConnectEvent;
    public event ReconnectEventHandler ReconnectEvent;
    public event DisconnectEventHandler DisconnectEvent;
    //public event ReceivedDataHandler ReceivedDataEvent;
    public event ConnectorErrorEventHandler ErrorEvent;

    private Socket m_Socket = null;
    private string m_URL = "";
    private int m_Port = 0;
    private bool m_IsConnecting = false;
    private IPEndPoint m_IPEndPoint = null;
    public static NetConnector CreateNetConnector(string url, int port)
    {
        NetConnector connector = new NetConnector();
        if (connector.OnCreate(url, port) == false)
            return null;
        return connector;
    }

    public static void DestroyNetConnector(NetConnector connector)
    {
        connector.OnDestory();
    }

    public bool OnCreate(string url, int port)
    {
        lock (this)
        {
            m_Port = port;
            m_URL = url;
            IPAddress ip = null;
            if (IPAddress.TryParse(url, out ip) == false)
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(url);
                if (hostEntry.AddressList.Length > 0)
                {
                    ip = hostEntry.AddressList[0];
                }
                else
                {
                    if (ErrorEvent != null)
                    {
                        ErrorEvent(NetResult.InvalidIpAddress, "Invalid parse IP address " + url);
                        return false;
                    }
                }
            }
            m_IPEndPoint = new IPEndPoint(ip, m_Port);
            m_Socket = new Socket(m_IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            m_Socket.NoDelay = true;
            m_Socket.Blocking = true;
            m_Socket.ReceiveBufferSize = NetworkConfig.SocketBufferSize;
            m_Socket.SendBufferSize = NetworkConfig.SocketBufferSize;
            return true;
        }
    }

    public void OnDestory()
    {
        m_IsConnecting = false;
        if (m_Socket != null)
        {
            m_Socket.Close();
            m_Socket = null;
        }
    }

    public bool IsConnected
    {
        get {
            if (m_Socket != null)
            {
                return m_Socket.Connected;
            }
            return false;
        }
    }

    public NetResult Connect(int timeout = 0)
    {
        lock (this)
        {
            if (IsConnected || m_IsConnecting)
            {
                return NetResult.NoError;
            }

            m_IsConnecting = true;
            m_Socket.ReceiveTimeout = timeout;
            m_Socket.SendTimeout = timeout;
            m_Socket.BeginConnect(m_IPEndPoint, ConnectCallback, m_Socket);
            return NetResult.NoError;
        }
    }

    private NetResult ConnectCallbackImpl(IAsyncResult asyncresult)
    {
        NetResult result = NetResult.UnknownError;
        var socket = asyncresult.AsyncState as Socket;
        if (m_Socket != socket)
        {
            if (socket != null)
            {
                socket.Close();
                socket = null;
            }
            return result;
        }
        m_IsConnecting = false;
        try
        {
            if (socket.Connected)
            {
                result = NetResult.NoError;
                socket.EndConnect(asyncresult);
            }
            else
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(NetResult.ConnectError, "Connecting to " + m_URL + ":" + m_Port.ToString() + " failed!");
                }
            }
        }
        catch (Exception ex)
        {
            result = NetResult.ConnectError;
            if (ex is SocketException)
            {
                SocketException socketExcept = (SocketException)ex;
                if (socketExcept.ErrorCode == 10055)//No buffer space available. iphone4
                {
                    result = NetResult.NoError;
                    return result;
                }
            }
            if (ErrorEvent != null)
            {
                ErrorEvent(NetResult.ConnectError, "net connect callback: exception " + ex.Message);
            }
        }
        return result;
    }

    private void ConnectCallback(IAsyncResult asyncresult)
    {
        NetResult result = ConnectCallbackImpl(asyncresult);
        if (ConnectEvent != null)
        {
            ConnectEvent(result);
        }
    }

    private void ReconnectCallback(IAsyncResult asyncresult)
    {
        NetResult result = ConnectCallbackImpl(asyncresult);
        if (ReconnectEvent != null)
        {
            ReconnectEvent(result);
        }
    }

    public void Reconnect(int timeout = 0)
    {
        lock (this)
        {
            Disconnect();
            OnCreate(m_URL, m_Port);

            m_IsConnecting = true;
            m_Socket.ReceiveTimeout = timeout;
            m_Socket.SendTimeout = timeout;
            m_Socket.BeginConnect(m_IPEndPoint, ReconnectCallback, m_Socket);
        }
    }

    public void Disconnect()
    {
        lock (this)
        {
            OnDestory();
            if (DisconnectEvent != null)
            {
                DisconnectEvent(NetResult.NoError);
            }
        }
    }

    public void WriteData(byte[] data, int off, int len)
    {
        lock (this)
        {
            if (m_Socket != null && IsConnected)
            {
                try
                {
                    m_Socket.Send(data, off, len, SocketFlags.None);
                }
                catch (System.Exception ex)
                {
                    ErrorEvent(NetResult.WriteDataError, "Socket exception: " + ex);
                }
            }
            else
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(NetResult.SocketClosed, "write data error: socket closed");
                }
            }
        }
    }

    public int ReadData(byte[] buff, int off, int len)
    {
        lock (this)
        {
            int rlen = -1;

            if (m_Socket != null && IsConnected)
            {
                try
                {
					
                    if (m_Socket != null && m_Socket.Connected && m_Socket.Poll(0, SelectMode.SelectRead))
                    {
                        rlen = m_Socket.Receive(buff, off, len, SocketFlags.None);
						Debug.Log("!!!!!!!!READ DATA, rlen:" + rlen);
                    }
					else
					{
//						Debug.Log("socket.Poll nothing");
					}
                }
                catch (System.Exception ex)
                {
					Debug.LogError("Socket exception: " + ex);
                    if (ErrorEvent != null)
                    {
						
                        ErrorEvent(NetResult.ReadDataError, "Socket exception: " + ex);
                        rlen = 0;
                    }
                }
            }
            else
            {
				Debug.LogError("read data error: socket closed");
                if (ErrorEvent != null)
                {
					
                    ErrorEvent(NetResult.SocketClosed, "read data error: socket closed");
                    rlen = 0;
                }
            }

//			Debug.Log("return rlen:" + rlen);
            return rlen;
        }

    }
}
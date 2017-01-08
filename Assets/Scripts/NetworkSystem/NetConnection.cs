using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQueueEntry
{
    public enum EQuequeEntry
    {
        data,
        close,
    };
    public EQuequeEntry m_eType;
    public byte[] data;
};

public struct CQueueSenderData
{
    public byte[] data;
    public int size;
};


public enum NetConnectionType
{
    Unknown = 0,
    LoginServer = 1,
    GameServer = 2,
}

public enum CSMsgResult
{
    NoError = 0,
    NetworkError = 1,
    InternalError = 2,
    MsgTimeOut = 3,
    PingTimeOut = 4,
    NoNetWork = 5,
}

public enum NetExceptionProcessType
{
    NO_PROCESS,
    USER_PROCESS,
}

public interface INetConnectionEvent
{
    //���ӳɹ�
    void OnConnected(NetConnection connector, NetResult result);

    //�����ɹ�
    void OnReconnected(NetConnection connector, NetResult result);

    //�Ͽ�����
    void OnDisconnected(NetConnection connector, NetResult result);

    //���ӳ���
    void OnConnectError(NetConnection connector, NetResult result, string ErrorStr);

    //���ӳ�ʱ
    void OnConnectTimeOut(NetConnection connector);

    //��������
    void OnTryReconnectSrv(NetConnection connector);
}

//����Э�����ص�������������
public delegate void MsgProcessCallback(CSMsgResult result, IMsg msg);

public class NetConnection
{
    private INetConnectionEvent m_EventHandler;

    private NetConnector m_NetConnector;

    //��Ϣ�����ֵ�
    private Dictionary<uint, MsgProcessCallback> m_MsgHandlerMap = new Dictionary<uint, MsgProcessCallback>();

    //seq�ذ��ֵ�
    struct SeqCallbackData
    {
        public ushort m_msgID;
        public MsgProcessCallback m_failCallback;
        public MsgProcessCallback m_Callback;
        public object m_Sender;
    }
    private Dictionary<uint, SeqCallbackData> m_SeqMsgMap = new Dictionary<uint, SeqCallbackData>();

    //���������ͻ���ʱ����,��������ʱ��
    private long m_TimeOffsetmSec = 0;

    //����+���е��ܺ�ʱ
    private int m_SendTimeOffsetmSec = 0;

    private float m_HeartTime = 1000.0f;//��ʼΪ������

    private DrWriteBuf m_TdrSendBufferWriter;// ��������ʹ�õ�Writer���������л�����
    private byte[] m_SendBufferArray;// ���з��͵�����ʹ�õ�Bufferk

    private NetConnectionType m_ConnectorType = NetConnectionType.Unknown;

    //�����������ӱ�ʶ
    private bool m_bTryReconnecting = false;
    public int m_ConnectionSeq = 0;
    private uint m_MsgSeq = 0;
    //�����߳�
    private ReceiverThread m_ReceiverThread;
    //�����߳� 
    private SenderThread m_SenderThread;

    //�յ������ݰ�����
    private Queue<CQueueEntry> m_QueueRecvPack = new Queue<CQueueEntry>();
    //׼�����͵����ݰ�����
    private Queue<CQueueSenderData> m_QueueSendPack = new Queue<CQueueSenderData>();
//	public static IMsg CSPkgInstance = GenerateCSPkg();

    //�Ƿ���������״̬
    public bool isConnected
    {
        get
        {
            if (m_NetConnector != null)
            {
                return m_NetConnector.IsConnected;
            }
            return false;
        }
    }

    //�Ƿ����ڳ�������������
    public bool isTryReConnecting
    {
        get
        {
            return m_bTryReconnecting;
        }
        set
        {
            m_bTryReconnecting = value;
        }
    }

    //���캯��
    public NetConnection(NetConnectionType type, INetConnectionEvent eventHandler)
    {
        this.m_ConnectorType = type;
        this.m_EventHandler = eventHandler;

        this.m_SendBufferArray = new byte[NetworkConfig.MaxPacketSize];
        this.m_TdrSendBufferWriter = new DrWriteBuf(m_SendBufferArray, NetworkConfig.MaxPacketSize);

        this.m_TimeOffsetmSec = 0;
        this.m_SendTimeOffsetmSec = 0;
    }

    #region �ӿڲ���
    //�������ͣ�GameSvr�����ӻ��������㲥�Ĵ�����
    public NetConnectionType connectorType
    {
        get
        {
            return m_ConnectorType;
        }
    }

    public long timeOffsetmSec
    {
        get
        {
            return m_TimeOffsetmSec;
        }
    }

    public int sendTimeOffsetmSec
    {
        get
        {
            return m_SendTimeOffsetmSec;
        }
    }

    public void Initialize()
    {
    }

    public void UnInitialize()
    {
    }

    public bool Create(string url, int port)
    {
        if (m_NetConnector != null)
        {
            Disconnect();
            m_NetConnector = null;
        }
        return CreateConnection(url, port);
    }

    //����
    public void Reconnect()
    {
        if (!isConnected)
        {
            m_NetConnector.Reconnect();
        }
    }

    //�Ͽ�
    public void Disconnect()
    {
        if (m_NetConnector != null)
        {
            SetTerminateFlag();
            m_NetConnector.Disconnect();
            NetConnector.DestroyNetConnector(m_NetConnector);
            m_NetConnector = null;
        }
    }

    public void RegisterMsgHandler(uint uiRecvMsgID, MsgProcessCallback callback)
    {
		Debug.Log(">>RegisterMsgHandler:" + uiRecvMsgID);

        if (m_MsgHandlerMap.ContainsKey(uiRecvMsgID))
        {
            m_MsgHandlerMap[uiRecvMsgID] += callback;
        }
        else
        {
            m_MsgHandlerMap[uiRecvMsgID] = callback;
        }
    }

    public void UnRegisterMsgHandler(uint uiRecvMsgID, MsgProcessCallback callback)
    {
        if (m_MsgHandlerMap.ContainsKey(uiRecvMsgID))
        {
            m_MsgHandlerMap[uiRecvMsgID] -= callback;
            if (m_MsgHandlerMap[uiRecvMsgID] == null)
            {
                m_MsgHandlerMap.Remove(uiRecvMsgID);
            }
        }
    }

    public MsgProcessCallback GetMsgHandler(uint uiCmdID)
    {
        MsgProcessCallback callback = null;
        m_MsgHandlerMap.TryGetValue(uiCmdID, out callback);

        return callback;
    }

    //Ԥ�ȹ�����������Э���������ݴ洢����������Ч��
//	private static IMsg GenerateCSPkg()
//    {
////        CSMsg pkg = new CSMsg();
////        return pkg;
//
//		//TODO
//		return null;
//    }

//    void WriteCSMsgHeader(ushort msgLen)
//    {
//        //д��ͷ
//        m_TdrSendBufferWriter.SetPosition(0);
//        NetMsgHead head;
//        head.unMsgLen = (ushort)System.Net.IPAddress.HostToNetworkOrder((short)msgLen);
//        head.byCmd = 0;
//        head.byFlag = 0;
//
//        m_TdrSendBufferWriter.WriteUInt16(head.unMsgLen);
//        m_TdrSendBufferWriter.WriteUInt8(head.byCmd);
//        m_TdrSendBufferWriter.WriteUInt8(head.byFlag);
//
//		//TODO solve this
////        m_TdrSendBufferWriter.WriteUInt32(head.uiUid);
//    }


	private IMsgPacker m_msgPacker;
	public void SendCSMsg(IMsg msg, MsgProcessCallback callback = null, object sender = null, MsgProcessCallback fail_callback = null)
    {
        if (!isConnected)
        {
            Debug.LogError("Lose Connected!!!");
            return;
        }

        m_MsgSeq++;
		msg.Sequence = m_MsgSeq;

		int pkgLen = 0;
		byte[] pkgData = m_msgPacker.Pack(msg, out pkgLen);

		if (pkgLen > 0)
        {

			SendData(pkgData, pkgLen);
			if (callback != null)
			{
				SeqCallbackData data = new SeqCallbackData();
				data.m_Callback = callback;
				data.m_Sender = sender;

				//TODO
				//					data.m_msgID = ?
				data.m_failCallback = fail_callback;
				m_SeqMsgMap.Add(m_MsgSeq, data);
			}
        }
        else
        {
            Debug.LogError("pack msg data error!");
        }
    }

    public void RemoveSeqMsg(object sender)
    {
        var enm = m_SeqMsgMap.GetEnumerator();
        List<uint> toRemoveList = null;
        while(enm.MoveNext())
        {
            if (enm.Current.Value.m_Sender == sender)
            {
                toRemoveList.Add(enm.Current.Key);
            }
        }
        for (int i = 0; i < toRemoveList.Count; ++i)
        {
            m_SeqMsgMap.Remove(toRemoveList[i]);
        }
    }

    //ÿһ֡tick�����鳬ʱ����ʱ��������
    public void Update()
    {
        if (isConnected)
        {
            //Heart();
            HandleReceiveMsg();
        }
        else
        {

            if (isTryReConnecting)
            {
                return;
            }

            if (m_EventHandler != null)
            {
                m_EventHandler.OnTryReconnectSrv(this);
            }
        }
    }

    #endregion

    #region �ڲ�����
    private void OnCreateConnection(string url, int port)
    {
        if (m_NetConnector == null)
        {
            m_NetConnector = NetConnector.CreateNetConnector(url, port);

            if (m_NetConnector != null)
            {
                //Add Event handler
                m_NetConnector.ConnectEvent -= _OnConnect;
                m_NetConnector.ConnectEvent += _OnConnect;

                m_NetConnector.ReconnectEvent -= _OnReconnect;
                m_NetConnector.ReconnectEvent += _OnReconnect;

                m_NetConnector.DisconnectEvent -= _OnDisconnect;
                m_NetConnector.DisconnectEvent += _OnDisconnect;

                m_NetConnector.ErrorEvent -= _OnConnectError;
                m_NetConnector.ErrorEvent += _OnConnectError;
            }
        }
    }

    private bool CreateConnection(string url, int port)
    {
		Debug.LogWarning(">>Create Connection");

        m_ConnectionSeq++;
        OnCreateConnection(url, port);

        if (m_NetConnector != null)
        {
            //Start Connecting
            NetResult ret = m_NetConnector.Connect();
            if (ret == NetResult.NoError)
            {
                return true;
            }
        }
        return false;
    }

    protected void StartReceiveThread()
    {
        if (m_NetConnector == null)
        {
            return;
        }

        m_ReceiverThread = new ReceiverThread(this, m_NetConnector, m_ConnectionSeq);
        m_ReceiverThread.Run();
    }

    protected void StartSendThread()
    {
        if (m_NetConnector == null)
        {
            return;
        }

        // todo
        m_SenderThread = new SenderThread(this, m_NetConnector, m_ConnectionSeq);
        m_SenderThread.Run();
    }

    public void EnqueueRespondMsg(CQueueEntry msg, int seq)
    {
        if (seq != m_ConnectionSeq)
        {
            Debug.Log("enqueue msg but seq not match," + seq + "," + m_ConnectionSeq);
            return;
        }

        lock (m_QueueRecvPack)
        {
            m_QueueRecvPack.Enqueue(msg);
        }
    }

    private void HandleReceiveMsg()
    {
        lock (m_QueueRecvPack)
        {
            while (m_QueueRecvPack.Count > 0)
            {
				CQueueEntry entry = m_QueueRecvPack.Dequeue();
				if (entry.m_eType == CQueueEntry.EQuequeEntry.data)
				{
					IMsg msg = m_msgPacker.Unpack(entry.data, entry.data.Length);
					if (msg != null)
					{
						MsgProcessCallback callback = null;
						if (m_MsgHandlerMap.TryGetValue(msg.Id, out callback))
						{
							Debug.Log("notify msg.id:" + msg.Id);
							callback(CSMsgResult.NoError, msg);
						}

						SeqCallbackData data;
						if (m_SeqMsgMap.TryGetValue(msg.Sequence, out data))
						{
							Debug.Log("seq msg.id:" + msg.Id);
							data.m_Callback(CSMsgResult.NoError, msg);
						}
						else
						{
							if (data.m_failCallback != null)
							{
								data.m_failCallback(CSMsgResult.InternalError, msg);
							}
						}
						m_SeqMsgMap.Remove(msg.Sequence);
					}
					else
					{
						Debug.LogError("msg invalid");
					}
				}
				else if (entry.m_eType == CQueueEntry.EQuequeEntry.close)
                {
                    Disconnect();
                }
			}   
            
        }
    }

    private void SetTerminateFlag()
    {
        if (m_SenderThread != null)
        {
            m_SenderThread.SetTerminateFlag();
            m_SenderThread = null;
        }

        if (m_ReceiverThread != null)
        {
            m_ReceiverThread.SetTerminateFlag();
            m_ReceiverThread = null;
        }
    }

    public void WaitTermination()
    {
        if (m_SenderThread != null)
            m_SenderThread.WaitTermination();
        if (m_ReceiverThread != null)
            m_ReceiverThread.WaitTermination();
    }

    public bool DequeueRequestMsg(int seq, out CQueueSenderData data)
    {
        data.size = 0;
        data.data = null;
        if (seq != m_ConnectionSeq)
        {
            return false;
        }
        lock (m_QueueSendPack)
        {
            if (m_QueueSendPack.Count > 0)
            {
                data = m_QueueSendPack.Dequeue();
                return true;
            }
        }
        return false;
    }

    public void clearQueue()
    {
        lock (m_QueueRecvPack)
        {
            m_QueueRecvPack.Clear();
        }
        lock (m_QueueSendPack)
        {
            m_QueueSendPack.Clear();
        }
    }

    private void SendData(byte[] data, int pkgSize)
    {
        if (isConnected)
        {
            lock (m_QueueSendPack)
            {
                CQueueSenderData senderData;
                senderData.data = data;
                senderData.size = pkgSize;
                m_QueueSendPack.Enqueue(senderData);
            }
        }
        else
        {
            Debug.LogError("SendData Error: unconnected network");
        }
    }

    //����Э��ֱ�ӷ�����������
    private void Heart()
    {
        m_HeartTime += Time.deltaTime;
        if (m_HeartTime < 10.0f)
        {
            return;
        }
        m_HeartTime = 0f;
        ////ReqestSyncTime();
    }

    ////private void ReqestSyncTime()
    ////{
    ////}

    #endregion

    #region �ص�����

    protected void _OnConnect(NetResult result)
    {
        if (result == NetResult.NoError)
        {
            StartReceiveThread();
            StartSendThread();
        }
        if (m_EventHandler != null)
        {
            m_EventHandler.OnConnected(this, result);
        }
    }

    protected void _OnReconnect(NetResult result)
    {
        if (m_EventHandler != null)
        {
            m_EventHandler.OnReconnected(this, result);
        }
    }

    protected void _OnDisconnect(NetResult result)
    {
        if (m_EventHandler != null)
        {
            m_EventHandler.OnDisconnected(this, result);
        }
    }

    protected void _OnConnectError(NetResult result, string errorString)
    {
        if (m_EventHandler != null)
        {
            m_EventHandler.OnConnectError(this, result, errorString);
        }
    }

    #endregion
}

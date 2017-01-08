using System;
using System.Collections;
using System.Collections.Generic;
namespace SkyWarProto {

public class ProInt
{

    public int iIDPro = 0;
    public int iValInt = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProInt.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProInt.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iIDPro);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iValInt);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProInt.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProInt.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iIDPro);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iValInt);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class ProString
{

    public int iIDPro = 0;
    public string szValStr = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProString.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProString.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iIDPro);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szValStr, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProString.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProString.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iIDPro);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szValStr, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class ProList
{

    public short nProIntRef = 0;
    public List<ProInt> astProInt = new List<ProInt>();
    public short nProStringRef = 0;
    public List<ProString> astProString = new List<ProString>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProList.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProList.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nProIntRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nProIntRef; ++i)
            {
                ret = this.astProInt[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nProStringRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nProStringRef; ++i)
            {
                ret = this.astProString[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProList.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProList.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nProIntRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astProInt.Clear();
            for (int i = 0; i < this.nProIntRef; ++i)
            {
                this.astProInt.Add(new ProInt());
                ret = this.astProInt[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nProStringRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astProString.Clear();
            for (int i = 0; i < this.nProStringRef; ++i)
            {
                this.astProString.Add(new ProString());
                ret = this.astProString[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class RoleInfo
{

    public uint uiUid = 0;
    public string szName = "";
    public int iMapLevel = 0;
    public short nMoneyListRef = 0;
    public List<int> aiMoneyList = new List<int>();
    public int iCompleteGateID = 0;
    public int iExp = 0;
    public int iLevel = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)RoleInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)RoleInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteUInt32(this.uiUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iMapLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nMoneyListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nMoneyListRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiMoneyList[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCompleteGateID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)RoleInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)RoleInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMapLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nMoneyListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiMoneyList.Clear();
            for (int i = 0; i < this.nMoneyListRef; ++i)
            {
                this.aiMoneyList.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiMoneyList[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCompleteGateID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class MapBuilding
{

    public int iUidBuilding = 0;
    public int iLevel = 0;
    public int iRecycle = 0;
    public int iX = 0;
    public int iY = 0;
    public uint uiTimeUpdateStart = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)MapBuilding.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)MapBuilding.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iRecycle);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeUpdateStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)MapBuilding.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)MapBuilding.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iRecycle);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeUpdateStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class MapBuildingMgr
{

    public short nMapBuildingListRef = 0;
    public List<MapBuilding> astMapBuildingList = new List<MapBuilding>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)MapBuildingMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)MapBuildingMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nMapBuildingListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nMapBuildingListRef; ++i)
            {
                ret = this.astMapBuildingList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)MapBuildingMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)MapBuildingMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nMapBuildingListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astMapBuildingList.Clear();
            for (int i = 0; i < this.nMapBuildingListRef; ++i)
            {
                this.astMapBuildingList.Add(new MapBuilding());
                ret = this.astMapBuildingList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class GoodInfo
{

    public int iUidGood = 0;
    public int iCfgID = 0;
    public int iCount = 0;
    public uint uiSubjoinPro = 0;
    public int iRefCount = 0;
    public int iType = 0;
    public int iMakeUid = 0;
    public string szMakeName = "";
    public uint uiTimeMake = 0;
    public int iCustom = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GoodInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GoodInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiSubjoinPro);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iRefCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iMakeUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szMakeName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeMake);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCustom);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GoodInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GoodInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiSubjoinPro);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iRefCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMakeUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szMakeName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeMake);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCustom);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BackPacketMgr
{

    public short nObjGoodListRef = 0;
    public List<GoodInfo> astObjGoodList = new List<GoodInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BackPacketMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BackPacketMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nObjGoodListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nObjGoodListRef; ++i)
            {
                ret = this.astObjGoodList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BackPacketMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BackPacketMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nObjGoodListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astObjGoodList.Clear();
            for (int i = 0; i < this.nObjGoodListRef; ++i)
            {
                this.astObjGoodList.Add(new GoodInfo());
                ret = this.astObjGoodList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class EquipMakeInfo
{

    public int iCfgIDEquip = 0;
    public int iExp = 0;
    public int iQuality = 0;
    public uint uiTimeLastMake = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipMakeInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipMakeInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iQuality);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeLastMake);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipMakeInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipMakeInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iQuality);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeLastMake);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class EquipMakeInfoMgr
{

    public short nEquipMakeInfoListRef = 0;
    public List<EquipMakeInfo> astEquipMakeInfoList = new List<EquipMakeInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipMakeInfoMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipMakeInfoMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nEquipMakeInfoListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nEquipMakeInfoListRef; ++i)
            {
                ret = this.astEquipMakeInfoList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipMakeInfoMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipMakeInfoMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nEquipMakeInfoListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astEquipMakeInfoList.Clear();
            for (int i = 0; i < this.nEquipMakeInfoListRef; ++i)
            {
                this.astEquipMakeInfoList.Add(new EquipMakeInfo());
                ret = this.astEquipMakeInfoList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class EquipQueueInfo
{

    public int iCfgIDEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipQueueInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipQueueInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipQueueInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipQueueInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BuildingMakeInfo
{

    public int iUidBuilding = 0;
    public int iResourceCount = 0;
    public uint uiTimeMakeStart = 0;
    public int iLevelUnlockGrid = 0;
    public short nMakeQueueRef = 0;
    public List<EquipQueueInfo> astMakeQueue = new List<EquipQueueInfo>();
    public short nCompleteQueueRef = 0;
    public List<GoodInfo> astCompleteQueue = new List<GoodInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BuildingMakeInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BuildingMakeInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iResourceCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeMakeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iLevelUnlockGrid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nMakeQueueRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nMakeQueueRef; ++i)
            {
                ret = this.astMakeQueue[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nCompleteQueueRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nCompleteQueueRef; ++i)
            {
                ret = this.astCompleteQueue[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BuildingMakeInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BuildingMakeInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iResourceCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeMakeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iLevelUnlockGrid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nMakeQueueRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astMakeQueue.Clear();
            for (int i = 0; i < this.nMakeQueueRef; ++i)
            {
                this.astMakeQueue.Add(new EquipQueueInfo());
                ret = this.astMakeQueue[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nCompleteQueueRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astCompleteQueue.Clear();
            for (int i = 0; i < this.nCompleteQueueRef; ++i)
            {
                this.astCompleteQueue.Add(new GoodInfo());
                ret = this.astCompleteQueue[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BuildingMakeInfoMgr
{

    public short nBuildingMakeInfoListRef = 0;
    public List<BuildingMakeInfo> astBuildingMakeInfoList = new List<BuildingMakeInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BuildingMakeInfoMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BuildingMakeInfoMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nBuildingMakeInfoListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nBuildingMakeInfoListRef; ++i)
            {
                ret = this.astBuildingMakeInfoList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BuildingMakeInfoMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BuildingMakeInfoMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nBuildingMakeInfoListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astBuildingMakeInfoList.Clear();
            for (int i = 0; i < this.nBuildingMakeInfoListRef; ++i)
            {
                this.astBuildingMakeInfoList.Add(new BuildingMakeInfo());
                ret = this.astBuildingMakeInfoList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class HeroInfo
{

    public int iUidHero = 0;
    public int iCfgID = 0;
    public int iLevel = 0;
    public int iStarLevel = 0;
    public int iHP = 0;
    public uint uiTimeLastRefreshHP = 0;
    public int iVIT = 0;
    public uint uiTimeLastRefreshVIT = 0;
    public int iExp = 0;
    public int iDemandRate = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iHP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeLastRefreshHP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iVIT);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeLastRefreshVIT);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iDemandRate);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iHP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeLastRefreshHP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iVIT);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeLastRefreshVIT);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iDemandRate);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class HeroMgr
{

    public short nHeroListRef = 0;
    public List<HeroInfo> astHeroList = new List<HeroInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroListRef; ++i)
            {
                ret = this.astHeroList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astHeroList.Clear();
            for (int i = 0; i < this.nHeroListRef; ++i)
            {
                this.astHeroList.Add(new HeroInfo());
                ret = this.astHeroList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProSystem
{

    public short nproListIntRef = 0;
    public List<int> aiproListInt = new List<int>();
    public short nproListPerRef = 0;
    public List<int> aiproListPer = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProSystem.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProSystem.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nproListIntRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nproListIntRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiproListInt[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nproListPerRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nproListPerRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiproListPer[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProSystem.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProSystem.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nproListIntRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiproListInt.Clear();
            for (int i = 0; i < this.nproListIntRef; ++i)
            {
                this.aiproListInt.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiproListInt[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nproListPerRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiproListPer.Clear();
            for (int i = 0; i < this.nproListPerRef; ++i)
            {
                this.aiproListPer.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiproListPer[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class HeroInfoEx
{

    public int iUid = 0;
    public short ncurProRef = 0;
    public List<int> aicurPro = new List<int>();
    public short nmaxProRef = 0;
    public List<int> aimaxPro = new List<int>();
    public short nproSystemRef = 0;
    public List<ProSystem> astproSystem = new List<ProSystem>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroInfoEx.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroInfoEx.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.ncurProRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.ncurProRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aicurPro[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nmaxProRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nmaxProRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aimaxPro[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nproSystemRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nproSystemRef; ++i)
            {
                ret = this.astproSystem[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroInfoEx.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroInfoEx.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.ncurProRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aicurPro.Clear();
            for (int i = 0; i < this.ncurProRef; ++i)
            {
                this.aicurPro.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aicurPro[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nmaxProRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aimaxPro.Clear();
            for (int i = 0; i < this.nmaxProRef; ++i)
            {
                this.aimaxPro.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aimaxPro[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nproSystemRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astproSystem.Clear();
            for (int i = 0; i < this.nproSystemRef; ++i)
            {
                this.astproSystem.Add(new ProSystem());
                ret = this.astproSystem[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class HeroInfoExMgr
{

    public short nHeroListRef = 0;
    public List<HeroInfoEx> astHeroList = new List<HeroInfoEx>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroInfoExMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroInfoExMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroListRef; ++i)
            {
                ret = this.astHeroList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroInfoExMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroInfoExMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astHeroList.Clear();
            for (int i = 0; i < this.nHeroListRef; ++i)
            {
                this.astHeroList.Add(new HeroInfoEx());
                ret = this.astHeroList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class DemandUnit
{

    public int iUidHero = 0;
    public GoodInfo stDemandGood = new GoodInfo();
    public short nDemandRewardsRef = 0;
    public List<GoodInfo> astDemandRewards = new List<GoodInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)DemandUnit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)DemandUnit.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stDemandGood.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nDemandRewardsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nDemandRewardsRef; ++i)
            {
                ret = this.astDemandRewards[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)DemandUnit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)DemandUnit.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stDemandGood.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nDemandRewardsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astDemandRewards.Clear();
            for (int i = 0; i < this.nDemandRewardsRef; ++i)
            {
                this.astDemandRewards.Add(new GoodInfo());
                ret = this.astDemandRewards[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class TroopsInfo
{

    public int iUidTroops = 0;
    public string szName = "";
    public short nUidHeroRef = 0;
    public List<int> aiUidHero = new List<int>();
    public int ieState = 0;
    public uint uiTimeStart = 0;
    public int iGateID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nUidHeroRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nUidHeroRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiUidHero[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ieState);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iGateID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nUidHeroRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiUidHero.Clear();
            for (int i = 0; i < this.nUidHeroRef; ++i)
            {
                this.aiUidHero.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiUidHero[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieState);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iGateID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class TroopsMgr
{

    public short nTroopsListRef = 0;
    public List<TroopsInfo> astTroopsList = new List<TroopsInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nTroopsListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nTroopsListRef; ++i)
            {
                ret = this.astTroopsList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nTroopsListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astTroopsList.Clear();
            for (int i = 0; i < this.nTroopsListRef; ++i)
            {
                this.astTroopsList.Add(new TroopsInfo());
                ret = this.astTroopsList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class TroopsPositionInfo
{

    public int iUidTroops = 0;
    public short nUidHeroRef = 0;
    public List<int> aiUidHero = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsPositionInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsPositionInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nUidHeroRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nUidHeroRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiUidHero[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsPositionInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsPositionInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nUidHeroRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiUidHero.Clear();
            for (int i = 0; i < this.nUidHeroRef; ++i)
            {
                this.aiUidHero.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiUidHero[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class TroopsPositionMgr
{

    public short nTroopsPositionListRef = 0;
    public List<TroopsPositionInfo> astTroopsPositionList = new List<TroopsPositionInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsPositionMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsPositionMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nTroopsPositionListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nTroopsPositionListRef; ++i)
            {
                ret = this.astTroopsPositionList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsPositionMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsPositionMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nTroopsPositionListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astTroopsPositionList.Clear();
            for (int i = 0; i < this.nTroopsPositionListRef; ++i)
            {
                this.astTroopsPositionList.Add(new TroopsPositionInfo());
                ret = this.astTroopsPositionList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class EquipGrooveInfo
{

    public int iUidGroove = 0;
    public int iUidEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipGrooveInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipGrooveInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidGroove);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)EquipGrooveInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)EquipGrooveInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidGroove);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class HeroEquipInfo
{

    public int iUidHero = 0;
    public int iSelContainerID = 0;
    public short nGrooveListRef = 0;
    public List<EquipGrooveInfo> astGrooveList = new List<EquipGrooveInfo>();
    public short nGrooveList2Ref = 0;
    public List<EquipGrooveInfo> astGrooveList2 = new List<EquipGrooveInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroEquipInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroEquipInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iSelContainerID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nGrooveListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nGrooveListRef; ++i)
            {
                ret = this.astGrooveList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nGrooveList2Ref);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nGrooveList2Ref; ++i)
            {
                ret = this.astGrooveList2[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroEquipInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroEquipInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSelContainerID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nGrooveListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astGrooveList.Clear();
            for (int i = 0; i < this.nGrooveListRef; ++i)
            {
                this.astGrooveList.Add(new EquipGrooveInfo());
                ret = this.astGrooveList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nGrooveList2Ref);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astGrooveList2.Clear();
            for (int i = 0; i < this.nGrooveList2Ref; ++i)
            {
                this.astGrooveList2.Add(new EquipGrooveInfo());
                ret = this.astGrooveList2[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class HeroEquipMgr
{

    public short nHeroEquipListRef = 0;
    public List<HeroEquipInfo> astHeroEquipList = new List<HeroEquipInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroEquipMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroEquipMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroEquipListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroEquipListRef; ++i)
            {
                ret = this.astHeroEquipList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroEquipMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroEquipMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroEquipListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astHeroEquipList.Clear();
            for (int i = 0; i < this.nHeroEquipListRef; ++i)
            {
                this.astHeroEquipList.Add(new HeroEquipInfo());
                ret = this.astHeroEquipList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class RecruitInfo
{

    public int iType = 0;
    public int iTotalRecruitTimes = 0;
    public int iRecruitTimes = 0;
    public uint uiNextRecruitTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)RecruitInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)RecruitInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iTotalRecruitTimes);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iRecruitTimes);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextRecruitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)RecruitInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)RecruitInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iTotalRecruitTimes);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iRecruitTimes);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextRecruitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class SoulStoneInfo
{

    public int iid = 0;
    public int inum = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)SoulStoneInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)SoulStoneInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.inum);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)SoulStoneInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)SoulStoneInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.inum);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class HeroExp
{

    public int iUidHero = 0;
    public int iExp = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroExp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroExp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)HeroExp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)HeroExp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iExp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class TroopsExp
{

    public int iExpRewardRole = 0;
    public short nHeroExpListRef = 0;
    public List<HeroExp> astHeroExpList = new List<HeroExp>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsExp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsExp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iExpRewardRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroExpListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroExpListRef; ++i)
            {
                ret = this.astHeroExpList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)TroopsExp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)TroopsExp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iExpRewardRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroExpListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astHeroExpList.Clear();
            for (int i = 0; i < this.nHeroExpListRef; ++i)
            {
                this.astHeroExpList.Add(new HeroExp());
                ret = this.astHeroExpList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class OrderUnit
{

    public int iOrderID = 0;
    public int iOrderNameID = 0;
    public short nOrderRewardsRef = 0;
    public List<GoodInfo> astOrderRewards = new List<GoodInfo>();
    public short nOrderDemandsRef = 0;
    public List<GoodInfo> astOrderDemands = new List<GoodInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)OrderUnit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)OrderUnit.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iOrderID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iOrderNameID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nOrderRewardsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nOrderRewardsRef; ++i)
            {
                ret = this.astOrderRewards[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nOrderDemandsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nOrderDemandsRef; ++i)
            {
                ret = this.astOrderDemands[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)OrderUnit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)OrderUnit.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iOrderID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iOrderNameID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nOrderRewardsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astOrderRewards.Clear();
            for (int i = 0; i < this.nOrderRewardsRef; ++i)
            {
                this.astOrderRewards.Add(new GoodInfo());
                ret = this.astOrderRewards[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nOrderDemandsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astOrderDemands.Clear();
            for (int i = 0; i < this.nOrderDemandsRef; ++i)
            {
                this.astOrderDemands.Add(new GoodInfo());
                ret = this.astOrderDemands[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class Position
{

    public int ix = 0;
    public int iy = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)Position.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)Position.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ix);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iy);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)Position.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)Position.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ix);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iy);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class MapBlockItem
{

    public int ix = 0;
    public int iy = 0;
    public int iuidBatHero = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)MapBlockItem.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)MapBlockItem.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ix);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iy);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iuidBatHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)MapBlockItem.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)MapBlockItem.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ix);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iy);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidBatHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BuffInfo
{

    public int iuidBuff = 0;
    public int icfgID = 0;
    public int ifatherHero = 0;
    public int iselfHero = 0;
    public int itriggerHero = 0;
    public int iisGood = 0;
    public int iround = 0;
    public short nconditionRef = 0;
    public List<int> aicondition = new List<int>();
    public int icdCur = 0;
    public int icdMax = 0;
    public int ilayerCount = 0;
    public int ilayerMax = 0;
    public short neEffectParRef = 0;
    public List<int> aieEffectPar = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BuffInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BuffInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ifatherHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iselfHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.itriggerHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iisGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iround);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nconditionRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nconditionRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aicondition[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icdCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icdMax);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ilayerCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ilayerMax);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.neEffectParRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.neEffectParRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aieEffectPar[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BuffInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BuffInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ifatherHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iselfHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.itriggerHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iisGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iround);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nconditionRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aicondition.Clear();
            for (int i = 0; i < this.nconditionRef; ++i)
            {
                this.aicondition.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aicondition[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icdCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icdMax);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ilayerCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ilayerMax);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.neEffectParRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aieEffectPar.Clear();
            for (int i = 0; i < this.neEffectParRef; ++i)
            {
                this.aieEffectPar.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aieEffectPar[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatHero
{

    public int iuidBatHero = 0;
    public int icfgID = 0;
    public int ilevel = 0;
    public int iStarLevel = 0;
    public int iMaxRecoverHp = 0;
    public HeroInfoEx stInfoEx = new HeroInfoEx();
    public int imasterUid = 0;
    public int istate = 0;
    public int icampUid = 0;
    public Position stpos = new Position();
    public int ieAISta = 0;
    public short nselAttackUidRef = 0;
    public List<int> aiselAttackUid = new List<int>();
    public short nbuffListRef = 0;
    public List<BuffInfo> astbuffList = new List<BuffInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatHero.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatHero.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidBatHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ilevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iMaxRecoverHp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stInfoEx.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.imasterUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.istate);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icampUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stpos.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ieAISta);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nselAttackUidRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nselAttackUidRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiselAttackUid[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbuffListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbuffListRef; ++i)
            {
                ret = this.astbuffList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatHero.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatHero.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidBatHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ilevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMaxRecoverHp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stInfoEx.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.imasterUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.istate);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icampUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stpos.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieAISta);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nselAttackUidRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiselAttackUid.Clear();
            for (int i = 0; i < this.nselAttackUidRef; ++i)
            {
                this.aiselAttackUid.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiselAttackUid[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbuffListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astbuffList.Clear();
            for (int i = 0; i < this.nbuffListRef; ++i)
            {
                this.astbuffList.Add(new BuffInfo());
                ret = this.astbuffList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatPlayer
{

    public int ieRobot = 0;
    public int iuidRole = 0;
    public string szname = "";
    public string szclanName = "";
    public int ieAuto = 0;
    public int iexistHero = 0;
    public short nbatHeroListRef = 0;
    public List<int> aibatHeroList = new List<int>();
    public short nheroListRef = 0;
    public List<int> aiheroList = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatPlayer.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatPlayer.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ieRobot);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iuidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szname, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szclanName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ieAuto);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iexistHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbatHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbatHeroListRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aibatHeroList[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nheroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nheroListRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiheroList[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatPlayer.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatPlayer.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieRobot);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szname, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szclanName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieAuto);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iexistHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbatHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aibatHeroList.Clear();
            for (int i = 0; i < this.nbatHeroListRef; ++i)
            {
                this.aibatHeroList.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aibatHeroList[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nheroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiheroList.Clear();
            for (int i = 0; i < this.nheroListRef; ++i)
            {
                this.aiheroList.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiheroList[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatTroops
{

    public int ihp = 0;
    public int ihpMax = 0;
    public short nplayersRef = 0;
    public List<BatPlayer> astplayers = new List<BatPlayer>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatTroops.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatTroops.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ihp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ihpMax);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nplayersRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nplayersRef; ++i)
            {
                ret = this.astplayers[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatTroops.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatTroops.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ihp);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ihpMax);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nplayersRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astplayers.Clear();
            for (int i = 0; i < this.nplayersRef; ++i)
            {
                this.astplayers.Add(new BatPlayer());
                ret = this.astplayers[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BattleMgr
{

    public int ibatType = 0;
    public int imapData = 0;
    public int iendState = 0;
    public int iwinCampUid = 0;
    public int iroundIDCur = 0;
    public uint uirandomStart = 0;
    public uint uirandomCur = 0;
    public uint uiUIDBiologyNext = 0;
    public uint uiUIDBufferNext = 0;
    public short ntroopsRef = 0;
    public List<BatTroops> asttroops = new List<BatTroops>();
    public short nmapBlockRef = 0;
    public List<MapBlockItem> astmapBlock = new List<MapBlockItem>();
    public short nherosRef = 0;
    public List<BatHero> astheros = new List<BatHero>();
    public short nactionOrderRef = 0;
    public List<int> aiactionOrder = new List<int>();
    public int icurActionBatHeroID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BattleMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BattleMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ibatType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.imapData);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iendState);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iwinCampUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iroundIDCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uirandomStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uirandomCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiUIDBiologyNext);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiUIDBufferNext);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.ntroopsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.ntroopsRef; ++i)
            {
                ret = this.asttroops[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nmapBlockRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nmapBlockRef; ++i)
            {
                ret = this.astmapBlock[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nherosRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nherosRef; ++i)
            {
                ret = this.astheros[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nactionOrderRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nactionOrderRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiactionOrder[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icurActionBatHeroID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BattleMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BattleMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ibatType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.imapData);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iendState);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iwinCampUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iroundIDCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uirandomStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uirandomCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiUIDBiologyNext);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiUIDBufferNext);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.ntroopsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            asttroops.Clear();
            for (int i = 0; i < this.ntroopsRef; ++i)
            {
                this.asttroops.Add(new BatTroops());
                ret = this.asttroops[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nmapBlockRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astmapBlock.Clear();
            for (int i = 0; i < this.nmapBlockRef; ++i)
            {
                this.astmapBlock.Add(new MapBlockItem());
                ret = this.astmapBlock[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nherosRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astheros.Clear();
            for (int i = 0; i < this.nherosRef; ++i)
            {
                this.astheros.Add(new BatHero());
                ret = this.astheros[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nactionOrderRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiactionOrder.Clear();
            for (int i = 0; i < this.nactionOrderRef; ++i)
            {
                this.aiactionOrder.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiactionOrder[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icurActionBatHeroID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatInitHero
{

    public int iuidHero = 0;
    public int icfgID = 0;
    public int ilevel = 0;
    public int iStarLevel = 0;
    public int iuidPos = 0;
    public HeroInfoEx stInfoEx = new HeroInfoEx();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatInitHero.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatInitHero.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ilevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iuidPos);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stInfoEx.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatInitHero.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatInitHero.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ilevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidPos);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stInfoEx.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatInitPlayer
{

    public int ieRobot = 0;
    public int iuidRole = 0;
    public string szname = "";
    public string szclanName = "";
    public int ieAuto = 0;
    public short nheroListRef = 0;
    public List<BatInitHero> astheroList = new List<BatInitHero>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatInitPlayer.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatInitPlayer.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ieRobot);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iuidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szname, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szclanName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ieAuto);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nheroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nheroListRef; ++i)
            {
                ret = this.astheroList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatInitPlayer.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatInitPlayer.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieRobot);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szname, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szclanName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieAuto);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nheroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astheroList.Clear();
            for (int i = 0; i < this.nheroListRef; ++i)
            {
                this.astheroList.Add(new BatInitHero());
                ret = this.astheroList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatInitTroops
{

    public short nplayersRef = 0;
    public List<BatInitPlayer> astplayers = new List<BatInitPlayer>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatInitTroops.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatInitTroops.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nplayersRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nplayersRef; ++i)
            {
                ret = this.astplayers[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatInitTroops.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatInitTroops.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nplayersRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astplayers.Clear();
            for (int i = 0; i < this.nplayersRef; ++i)
            {
                this.astplayers.Add(new BatInitPlayer());
                ret = this.astplayers[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BattleInitMgr
{

    public int ibatType = 0;
    public short ntroopsRef = 0;
    public List<BatInitTroops> asttroops = new List<BatInitTroops>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BattleInitMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BattleInitMgr.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ibatType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.ntroopsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.ntroopsRef; ++i)
            {
                ret = this.asttroops[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BattleInitMgr.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BattleInitMgr.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ibatType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.ntroopsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            asttroops.Clear();
            for (int i = 0; i < this.ntroopsRef; ++i)
            {
                this.asttroops.Add(new BatInitTroops());
                ret = this.asttroops[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatLogRound
{

    public int iid = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogRound.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogRound.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogRound.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogRound.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatLogBuffPassivity
{

    public int iuidBuff = 0;
    public int icfgIDBuff = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffPassivity.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffPassivity.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icfgIDBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffPassivity.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffPassivity.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icfgIDBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatLogBuffPassivityAdd
{

    public int iuidHero = 0;
    public short nbuffListRef = 0;
    public List<BatLogBuffPassivity> astbuffList = new List<BatLogBuffPassivity>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffPassivityAdd.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffPassivityAdd.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbuffListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbuffListRef; ++i)
            {
                ret = this.astbuffList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffPassivityAdd.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffPassivityAdd.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbuffListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astbuffList.Clear();
            for (int i = 0; i < this.nbuffListRef; ++i)
            {
                this.astbuffList.Add(new BatLogBuffPassivity());
                ret = this.astbuffList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatLogAffected
{

    public int iuidHero = 0;
    public int ibuffEffectCfgID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogAffected.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogAffected.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ibuffEffectCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogAffected.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogAffected.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ibuffEffectCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatLogBuffTigger
{

    public int iuidBuff = 0;
    public int icfgID = 0;
    public int ifatherHero = 0;
    public int icarrierHero = 0;
    public int iround = 0;
    public int icdCur = 0;
    public int ilayerCount = 0;
    public int itriggerHero = 0;
    public short naffectedListRef = 0;
    public List<BatLogAffected> astaffectedList = new List<BatLogAffected>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffTigger.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffTigger.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ifatherHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icarrierHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iround);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.icdCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ilayerCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.itriggerHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.naffectedListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.naffectedListRef; ++i)
            {
                ret = this.astaffectedList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffTigger.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffTigger.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ifatherHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icarrierHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iround);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.icdCur);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ilayerCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.itriggerHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.naffectedListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astaffectedList.Clear();
            for (int i = 0; i < this.naffectedListRef; ++i)
            {
                this.astaffectedList.Add(new BatLogAffected());
                ret = this.astaffectedList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class BatLogBuffRemove
{

    public int iuidHero = 0;
    public int iuidBuff = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffRemove.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffRemove.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogBuffRemove.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogBuffRemove.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidBuff);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatLogHeroProEdit
{

    public int iuidHero = 0;
    public int ieProID = 0;
    public int ivalue = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogHeroProEdit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogHeroProEdit.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ieProID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ivalue);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogHeroProEdit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogHeroProEdit.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieProID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ivalue);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatLogCampProEdit
{

    public int iuidHero = 0;
    public int ieProID = 0;
    public int ivalue = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogCampProEdit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogCampProEdit.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ieProID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.ivalue);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatLogCampProEdit.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatLogCampProEdit.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieProID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.ivalue);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatOrder
{

    public int ieLogType = 0;
    public int iindex = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatOrder.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatOrder.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ieLogType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iindex);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatOrder.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatOrder.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieLogType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iindex);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BatHeroAction
{

    public int iuidHero = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatHeroAction.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatHeroAction.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BatHeroAction.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BatHeroAction.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iuidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class BattleLog
{

    public BattleMgr stbattleData = new BattleMgr();
    public short nbuffPassivityRef = 0;
    public List<BatLogBuffPassivityAdd> astbuffPassivity = new List<BatLogBuffPassivityAdd>();
    public int iWinCampID = 0;
    public short nroundRef = 0;
    public List<BatLogRound> astround = new List<BatLogRound>();
    public short nbuffTiggerRef = 0;
    public List<BatLogBuffTigger> astbuffTigger = new List<BatLogBuffTigger>();
    public short nbuffRemoveRef = 0;
    public List<BatLogBuffRemove> astbuffRemove = new List<BatLogBuffRemove>();
    public short nheroProEditRef = 0;
    public List<BatLogHeroProEdit> astheroProEdit = new List<BatLogHeroProEdit>();
    public short ncampProEditRef = 0;
    public List<BatLogCampProEdit> astcampProEdit = new List<BatLogCampProEdit>();
    public short nheroActionRef = 0;
    public List<BatHeroAction> astheroAction = new List<BatHeroAction>();
    public short nbatOrderRef = 0;
    public List<BatOrder> astbatOrder = new List<BatOrder>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BattleLog.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BattleLog.VERSION.CURRVERSION;
        }

        {
            ret = this.stbattleData.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbuffPassivityRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbuffPassivityRef; ++i)
            {
                ret = this.astbuffPassivity[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iWinCampID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nroundRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nroundRef; ++i)
            {
                ret = this.astround[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbuffTiggerRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbuffTiggerRef; ++i)
            {
                ret = this.astbuffTigger[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbuffRemoveRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbuffRemoveRef; ++i)
            {
                ret = this.astbuffRemove[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nheroProEditRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nheroProEditRef; ++i)
            {
                ret = this.astheroProEdit[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.ncampProEditRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.ncampProEditRef; ++i)
            {
                ret = this.astcampProEdit[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nheroActionRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nheroActionRef; ++i)
            {
                ret = this.astheroAction[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nbatOrderRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nbatOrderRef; ++i)
            {
                ret = this.astbatOrder[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)BattleLog.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)BattleLog.VERSION.CURRVERSION;
        }

        {
            ret = this.stbattleData.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbuffPassivityRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astbuffPassivity.Clear();
            for (int i = 0; i < this.nbuffPassivityRef; ++i)
            {
                this.astbuffPassivity.Add(new BatLogBuffPassivityAdd());
                ret = this.astbuffPassivity[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iWinCampID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nroundRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astround.Clear();
            for (int i = 0; i < this.nroundRef; ++i)
            {
                this.astround.Add(new BatLogRound());
                ret = this.astround[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbuffTiggerRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astbuffTigger.Clear();
            for (int i = 0; i < this.nbuffTiggerRef; ++i)
            {
                this.astbuffTigger.Add(new BatLogBuffTigger());
                ret = this.astbuffTigger[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbuffRemoveRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astbuffRemove.Clear();
            for (int i = 0; i < this.nbuffRemoveRef; ++i)
            {
                this.astbuffRemove.Add(new BatLogBuffRemove());
                ret = this.astbuffRemove[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nheroProEditRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astheroProEdit.Clear();
            for (int i = 0; i < this.nheroProEditRef; ++i)
            {
                this.astheroProEdit.Add(new BatLogHeroProEdit());
                ret = this.astheroProEdit[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.ncampProEditRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astcampProEdit.Clear();
            for (int i = 0; i < this.ncampProEditRef; ++i)
            {
                this.astcampProEdit.Add(new BatLogCampProEdit());
                ret = this.astcampProEdit[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nheroActionRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astheroAction.Clear();
            for (int i = 0; i < this.nheroActionRef; ++i)
            {
                this.astheroAction.Add(new BatHeroAction());
                ret = this.astheroAction[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nbatOrderRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astbatOrder.Clear();
            for (int i = 0; i < this.nbatOrderRef; ++i)
            {
                this.astbatOrder.Add(new BatOrder());
                ret = this.astbatOrder[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class GameObjShowSize
{

    public int iMempool = 0;
    public int iRoleData = 0;
    public int iCSMsgBody = 0;
    public int iBattleLog = 0;
    public int iCS_MSGID_CREATE_REQ = 0;
    public int iSS_MSGID_FETCHROLE_RSP = 0;
    public int iSS_MSGID_CREATEROLE_RSP = 0;
    public short nAllLOGINMsgRef = 0;
    public List<int> aiAllLOGINMsg = new List<int>();
    public short nOtherRef = 0;
    public List<int> aiOther = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GameObjShowSize.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GameObjShowSize.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iMempool);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iRoleData);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCSMsgBody);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iBattleLog);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCS_MSGID_CREATE_REQ);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iSS_MSGID_FETCHROLE_RSP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iSS_MSGID_CREATEROLE_RSP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nAllLOGINMsgRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nAllLOGINMsgRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiAllLOGINMsg[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nOtherRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nOtherRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiOther[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GameObjShowSize.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GameObjShowSize.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMempool);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iRoleData);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCSMsgBody);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iBattleLog);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCS_MSGID_CREATE_REQ);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSS_MSGID_FETCHROLE_RSP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSS_MSGID_CREATEROLE_RSP);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nAllLOGINMsgRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiAllLOGINMsg.Clear();
            for (int i = 0; i < this.nAllLOGINMsgRef; ++i)
            {
                this.aiAllLOGINMsg.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiAllLOGINMsg[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nOtherRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiOther.Clear();
            for (int i = 0; i < this.nOtherRef; ++i)
            {
                this.aiOther.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiOther[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class CSLoginReq
{

    public string szToken = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteString(this.szToken, (int)ENUMGAME.MAX_TOKEN_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadString(ref this.szToken, (int)ENUMGAME.MAX_TOKEN_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginRsp
{

    public short nResult = 0;
    public string szName = "";
    public uint uiUid = 0;
    public int iMapLevel = 0;
    public int iMoneyGold = 0;
    public int iMoneyDiamond = 0;
    public uint uiCurServerTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iMapLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iMoneyGold);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iMoneyDiamond);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiCurServerTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiUid);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMapLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMoneyGold);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMoneyDiamond);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiCurServerTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSCreateReq
{

    public string szName = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCreateReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCreateReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCreateReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCreateReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSCreateRsp
{

    public short nResult = 0;
    public string szName = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCreateRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCreateRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCreateRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCreateRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginActorRsp
{

    public RoleInfo stRoleInfo = new RoleInfo();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginActorRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginActorRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stRoleInfo.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginActorRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginActorRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stRoleInfo.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginMapBuildMgrRsp
{

    public MapBuildingMgr stMapBuildingMgr = new MapBuildingMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginMapBuildMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginMapBuildMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stMapBuildingMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginMapBuildMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginMapBuildMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stMapBuildingMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginBuildingMakeInfoMgrRsp
{

    public BuildingMakeInfoMgr stBuildingMakeInfoMgr = new BuildingMakeInfoMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginBuildingMakeInfoMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginBuildingMakeInfoMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stBuildingMakeInfoMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginBuildingMakeInfoMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginBuildingMakeInfoMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stBuildingMakeInfoMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginBackPacketMgrRsp
{

    public BackPacketMgr stBackPacketMgr = new BackPacketMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginBackPacketMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginBackPacketMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stBackPacketMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginBackPacketMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginBackPacketMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stBackPacketMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginEquipMakeInfoMgrRsp
{

    public EquipMakeInfoMgr stEquipMakeInfoMgr = new EquipMakeInfoMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginEquipMakeInfoMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginEquipMakeInfoMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stEquipMakeInfoMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginEquipMakeInfoMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginEquipMakeInfoMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stEquipMakeInfoMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginHeroMgrRsp
{

    public HeroMgr stHeroMgr = new HeroMgr();
    public HeroEquipMgr stHeroEquipMgr = new HeroEquipMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginHeroMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginHeroMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stHeroMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stHeroEquipMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginHeroMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginHeroMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stHeroMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stHeroEquipMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginTroopsMgrRsp
{

    public TroopsMgr stTroopsMgr = new TroopsMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginTroopsMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginTroopsMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stTroopsMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginTroopsMgrRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginTroopsMgrRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stTroopsMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginOrderListRsp
{

    public short nOrderListRef = 0;
    public List<OrderUnit> astOrderList = new List<OrderUnit>();
    public uint uiNextNewOrderTime = 0;
    public uint uiNextSubmitTime = 0;
    public uint uiNextRefreshTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginOrderListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginOrderListRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nOrderListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nOrderListRef; ++i)
            {
                ret = this.astOrderList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextNewOrderTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextSubmitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextRefreshTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginOrderListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginOrderListRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nOrderListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astOrderList.Clear();
            for (int i = 0; i < this.nOrderListRef; ++i)
            {
                this.astOrderList.Add(new OrderUnit());
                ret = this.astOrderList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextNewOrderTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextSubmitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextRefreshTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginDemandListRsp
{

    public short nDemandListRef = 0;
    public List<DemandUnit> astDemandList = new List<DemandUnit>();
    public uint uiNextUpdateTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginDemandListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginDemandListRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nDemandListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nDemandListRef; ++i)
            {
                ret = this.astDemandList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextUpdateTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginDemandListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginDemandListRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nDemandListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astDemandList.Clear();
            for (int i = 0; i < this.nDemandListRef; ++i)
            {
                this.astDemandList.Add(new DemandUnit());
                ret = this.astDemandList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextUpdateTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSLoginEnterGameRsp
{

    public int iNull = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginEnterGameRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginEnterGameRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSLoginEnterGameRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSLoginEnterGameRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSNotifyRsp
{

    public int iResult = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSNotifyRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSNotifyRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSNotifyRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSNotifyRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSRpcNotifyRsp
{

    public int iKey = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSRpcNotifyRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSRpcNotifyRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iKey);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSRpcNotifyRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSRpcNotifyRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iKey);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSAutoResponsePacketRsp
{

    public int iMsgIDSour = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSAutoResponsePacketRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSAutoResponsePacketRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iMsgIDSour);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSAutoResponsePacketRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSAutoResponsePacketRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iMsgIDSour);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingBuildReq
{

    public int iUidBuilding = 0;
    public int iX = 0;
    public int iY = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingBuildReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingBuildReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingBuildReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingBuildReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingBuildRsp
{

    public int iIsBuilding = 0;
    public MapBuilding stInfo = new MapBuilding();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingBuildRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingBuildRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iIsBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stInfo.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingBuildRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingBuildRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iIsBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stInfo.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingRecycleReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingRecycleReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingRecycleReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingRecycleReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingRecycleReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingRecycleRsp
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingRecycleRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingRecycleRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingRecycleRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingRecycleRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingMoveReq
{

    public int iUidBuilding = 0;
    public int iX = 0;
    public int iY = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingMoveReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingMoveReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingMoveReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingMoveReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingMoveRsp
{

    public int iUidBuilding = 0;
    public int iX = 0;
    public int iY = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingMoveRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingMoveRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingMoveRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingMoveRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingUpLevelReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingUpLevelRsp
{

    public short nResult = 0;
    public int iUidBuilding = 0;
    public uint uiTimeUpLevelStart = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeUpLevelStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeUpLevelStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingUpLevelCompleteReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelCompleteReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelCompleteReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelCompleteReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelCompleteReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSBuildingUpLevelCompleteRsp
{

    public short nResult = 0;
    public int iUidBuilding = 0;
    public int iCurLevel = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelCompleteRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelCompleteRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCurLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSBuildingUpLevelCompleteRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSBuildingUpLevelCompleteRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCurLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSImUpLevelReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSImUpLevelRsp
{

    public int iUidBuilding = 0;
    public int iCurLevel = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCurLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCurLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSCancelUpLevelReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSCancelUpLevelRsp
{

    public int iUidBuilding = 0;
    public int iCurLevel = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCurLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCurLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipMakeReq
{

    public int iUidBuilding = 0;
    public int iCfgIDEquip = 0;
    public int iLockBuildingCfgID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipMakeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipMakeReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iLockBuildingCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipMakeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipMakeReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iLockBuildingCfgID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipMakeRsp
{

    public int iUidBuilding = 0;
    public int iCfgIDEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSImMakeReq
{

    public int iUidBuilding = 0;
    public int iCfgIDEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImMakeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImMakeReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImMakeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImMakeReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSImMakeRsp
{

    public int iUidBuilding = 0;
    public int iUidEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSImMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSImMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSCancelMakeReq
{

    public int iUidBuilding = 0;
    public int iIdx = 0;
    public int iCfgIDEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelMakeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelMakeReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelMakeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelMakeReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgIDEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSCancelMakeRsp
{

    public int iUidBuilding = 0;
    public int iIdx = 0;
    public uint uiTimeMakeStart = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeMakeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSCancelMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSCancelMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeMakeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipGetCompleteReq
{

    public int iUidBuilding = 0;
    public int iUidGood = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipGetCompleteReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipGetCompleteReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipGetCompleteReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipGetCompleteReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipGetCompleteRsp
{

    public int iUidBuilding = 0;
    public int iUidGood = 0;
    public BackPacketMgr stBackPacketMgr = new BackPacketMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipGetCompleteRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipGetCompleteRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stBackPacketMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipGetCompleteRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipGetCompleteRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stBackPacketMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpDataBuildingRsp
{

    public BuildingMakeInfoMgr stBuildingMakeInfoMgr = new BuildingMakeInfoMgr();
    public EquipMakeInfoMgr stEquipMakeInfoMgr = new EquipMakeInfoMgr();
    public short nUpdateSignRef = 0;
    public List<int> aiUpdateSign = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpDataBuildingRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpDataBuildingRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stBuildingMakeInfoMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stEquipMakeInfoMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nUpdateSignRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nUpdateSignRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiUpdateSign[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpDataBuildingRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpDataBuildingRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stBuildingMakeInfoMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stEquipMakeInfoMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nUpdateSignRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiUpdateSign.Clear();
            for (int i = 0; i < this.nUpdateSignRef; ++i)
            {
                this.aiUpdateSign.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiUpdateSign[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class CSRefreshMakeInfoReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSRefreshMakeInfoReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSRefreshMakeInfoReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSRefreshMakeInfoReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSRefreshMakeInfoReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSRefreshMakeInfoRsp
{

    public int iEmpty = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSRefreshMakeInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSRefreshMakeInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iEmpty);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSRefreshMakeInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSRefreshMakeInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEmpty);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSResourceGetReq
{

    public int iUidBuilding = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceGetReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceGetReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceGetReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceGetReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSResourceGetRsp
{

    public int iUidBuilding = 0;
    public int iResType = 0;
    public int iResCount = 0;
    public uint uiTimeMakeStart = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceGetRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceGetRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iResType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iResCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeMakeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceGetRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceGetRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iResType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iResCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeMakeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSResourceBuyReq
{

    public GoodInfo stGetGood = new GoodInfo();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceBuyReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceBuyReq.VERSION.CURRVERSION;
        }

        {
            ret = this.stGetGood.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceBuyReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceBuyReq.VERSION.CURRVERSION;
        }

        {
            ret = this.stGetGood.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSResourceBuyRsp
{

    public GoodInfo stGetGood = new GoodInfo();
    public ProInt stProList = new ProInt();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceBuyRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceBuyRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stGetGood.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSResourceBuyRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSResourceBuyRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stGetGood.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipSellReq
{

    public GoodInfo stGood = new GoodInfo();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSellReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSellReq.VERSION.CURRVERSION;
        }

        {
            ret = this.stGood.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSellReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSellReq.VERSION.CURRVERSION;
        }

        {
            ret = this.stGood.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipSellRsp
{

    public int iNull = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSellRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSellRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSellRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSellRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSGoodUSEReq
{

    public int iUidGood = 0;
    public int iUseCount = 0;
    public int iObjectType = 0;
    public int iUidObject = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGoodUSEReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGoodUSEReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUseCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iObjectType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGoodUSEReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGoodUSEReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUseCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iObjectType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSGoodUSERsp
{

    public int iCfgGood = 0;
    public int iUseCount = 0;
    public int iObjectType = 0;
    public int iUidObject = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGoodUSERsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGoodUSERsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iCfgGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUseCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iObjectType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGoodUSERsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGoodUSERsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCfgGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUseCount);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iObjectType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class ProRole
{

    public int iUidRole = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProRole.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProRole.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProRole.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProRole.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjRoleRsp
{

    public short nRolesRef = 0;
    public List<ProRole> astRoles = new List<ProRole>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjRoleRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjRoleRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nRolesRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nRolesRef; ++i)
            {
                ret = this.astRoles[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjRoleRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjRoleRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nRolesRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astRoles.Clear();
            for (int i = 0; i < this.nRolesRef; ++i)
            {
                this.astRoles.Add(new ProRole());
                ret = this.astRoles[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProMapBuilding
{

    public int iUidMapBuilding = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProMapBuilding.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProMapBuilding.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidMapBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProMapBuilding.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProMapBuilding.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidMapBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjMapBuildingRsp
{

    public int iUidRole = 0;
    public short nMapBuildingsRef = 0;
    public List<ProMapBuilding> astMapBuildings = new List<ProMapBuilding>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjMapBuildingRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjMapBuildingRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nMapBuildingsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nMapBuildingsRef; ++i)
            {
                ret = this.astMapBuildings[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjMapBuildingRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjMapBuildingRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nMapBuildingsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astMapBuildings.Clear();
            for (int i = 0; i < this.nMapBuildingsRef; ++i)
            {
                this.astMapBuildings.Add(new ProMapBuilding());
                ret = this.astMapBuildings[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProEquipMake
{

    public int iUidMapBuilding = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProEquipMake.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProEquipMake.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidMapBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProEquipMake.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProEquipMake.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidMapBuilding);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjEquipMakeRsp
{

    public int iUidRole = 0;
    public short nEquipMakesRef = 0;
    public List<ProEquipMake> astEquipMakes = new List<ProEquipMake>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjEquipMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjEquipMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nEquipMakesRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nEquipMakesRef; ++i)
            {
                ret = this.astEquipMakes[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjEquipMakeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjEquipMakeRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nEquipMakesRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astEquipMakes.Clear();
            for (int i = 0; i < this.nEquipMakesRef; ++i)
            {
                this.astEquipMakes.Add(new ProEquipMake());
                ret = this.astEquipMakes[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProResource
{

    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProResource.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProResource.VERSION.CURRVERSION;
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProResource.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProResource.VERSION.CURRVERSION;
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjResourceRsp
{

    public int iUidRole = 0;
    public ProResource stResources = new ProResource();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjResourceRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjResourceRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stResources.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjResourceRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjResourceRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stResources.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class ProGood
{

    public int iUidGood = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProGood.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProGood.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProGood.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProGood.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidGood);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjBackpackRsp
{

    public int iUidRole = 0;
    public short nGoodsRef = 0;
    public List<ProGood> astGoods = new List<ProGood>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjBackpackRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjBackpackRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nGoodsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nGoodsRef; ++i)
            {
                ret = this.astGoods[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjBackpackRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjBackpackRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nGoodsRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astGoods.Clear();
            for (int i = 0; i < this.nGoodsRef; ++i)
            {
                this.astGoods.Add(new ProGood());
                ret = this.astGoods[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProEquipMakeInfo
{

    public int iUidEquipMakeInfo = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProEquipMakeInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProEquipMakeInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquipMakeInfo);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProEquipMakeInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProEquipMakeInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquipMakeInfo);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjEquipMakeInfoRsp
{

    public int iUidRole = 0;
    public short nEquipMakeInfosRef = 0;
    public List<ProEquipMakeInfo> astEquipMakeInfos = new List<ProEquipMakeInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjEquipMakeInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjEquipMakeInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nEquipMakeInfosRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nEquipMakeInfosRef; ++i)
            {
                ret = this.astEquipMakeInfos[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjEquipMakeInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjEquipMakeInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nEquipMakeInfosRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astEquipMakeInfos.Clear();
            for (int i = 0; i < this.nEquipMakeInfosRef; ++i)
            {
                this.astEquipMakeInfos.Add(new ProEquipMakeInfo());
                ret = this.astEquipMakeInfos[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProHeroInfo
{

    public int iUidHero = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProHeroInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProHeroInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProHeroInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProHeroInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjHeroInfoRsp
{

    public int iUidRole = 0;
    public short nHeroListRef = 0;
    public List<ProHeroInfo> astHeroList = new List<ProHeroInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjHeroInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjHeroInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroListRef; ++i)
            {
                ret = this.astHeroList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjHeroInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjHeroInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astHeroList.Clear();
            for (int i = 0; i < this.nHeroListRef; ++i)
            {
                this.astHeroList.Add(new ProHeroInfo());
                ret = this.astHeroList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class ProTroopsInfo
{

    public int iUidTroops = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProTroopsInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProTroopsInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)ProTroopsInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)ProTroopsInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateObjTroopsInfoRsp
{

    public int iUidRole = 0;
    public short nTroopsListRef = 0;
    public List<ProTroopsInfo> astTroopsList = new List<ProTroopsInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjTroopsInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjTroopsInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nTroopsListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nTroopsListRef; ++i)
            {
                ret = this.astTroopsList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateObjTroopsInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateObjTroopsInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidRole);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nTroopsListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astTroopsList.Clear();
            for (int i = 0; i < this.nTroopsListRef; ++i)
            {
                this.astTroopsList.Add(new ProTroopsInfo());
                ret = this.astTroopsList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class GameObjInfo
{

    public int ieGameObjType = 0;
    public int iUidObject = 0;
    public ProList stProList = new ProList();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GameObjInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GameObjInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ieGameObjType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GameObjInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GameObjInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieGameObjType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stProList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class GameObjRemoveInfo
{

    public int ieGameObjType = 0;
    public int iUidObject = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GameObjRemoveInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GameObjRemoveInfo.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ieGameObjType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)GameObjRemoveInfo.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)GameObjRemoveInfo.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ieGameObjType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidObject);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSUpdateGameObjeRsp
{

    public short nobjUpdateRef = 0;
    public List<GameObjInfo> astobjUpdate = new List<GameObjInfo>();
    public short nobjRemoveRef = 0;
    public List<GameObjRemoveInfo> astobjRemove = new List<GameObjRemoveInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateGameObjeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateGameObjeRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nobjUpdateRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nobjUpdateRef; ++i)
            {
                ret = this.astobjUpdate[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteInt16(this.nobjRemoveRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nobjRemoveRef; ++i)
            {
                ret = this.astobjRemove[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSUpdateGameObjeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSUpdateGameObjeRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nobjUpdateRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astobjUpdate.Clear();
            for (int i = 0; i < this.nobjUpdateRef; ++i)
            {
                this.astobjUpdate.Add(new GameObjInfo());
                ret = this.astobjUpdate[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadInt16(ref this.nobjRemoveRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astobjRemove.Clear();
            for (int i = 0; i < this.nobjRemoveRef; ++i)
            {
                this.astobjRemove.Add(new GameObjRemoveInfo());
                ret = this.astobjRemove[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class CSHeroRefreshVITReq
{

    public int iUidHero = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRefreshVITReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRefreshVITReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRefreshVITReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRefreshVITReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroRefreshHpReq
{

    public int iUidHero = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRefreshHpReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRefreshHpReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRefreshHpReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRefreshHpReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroStarUpLevelReq
{

    public int iUidHero = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroStarUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroStarUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroStarUpLevelReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroStarUpLevelReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroStarUpLevelRsp
{

    public int iUidHero = 0;
    public int iCurStarLevel = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroStarUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroStarUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iCurStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroStarUpLevelRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroStarUpLevelRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iCurStarLevel);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipPutOnReq
{

    public int iUidHero = 0;
    public int iEquipIdx = 0;
    public int iUidEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOnReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOnReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOnReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOnReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipPutOnRsp
{

    public int iUidHero = 0;
    public int iEquipIdx = 0;
    public int iUidEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOnRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOnRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOnRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOnRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipPutOffReq
{

    public int iUidHero = 0;
    public int iEquipIdx = 0;
    public int iUidEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOffReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOffReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOffReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOffReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipPutOffRsp
{

    public int iUidHero = 0;
    public int iEquipIdx = 0;
    public int iUidEquip = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOffRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOffRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipPutOffRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipPutOffRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquip);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipSwitchReq
{

    public int iUidHero = 0;
    public int iEquipIdx = 0;
    public int iUidEquipDest = 0;
    public int iUidEquipSour = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquipDest);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquipSour);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquipDest);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquipSour);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipSwitchRsp
{

    public int iUidHero = 0;
    public int iEquipIdx = 0;
    public int iUidEquipDest = 0;
    public int iUidEquipSour = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquipDest);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidEquipSour);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iEquipIdx);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquipDest);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidEquipSour);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipSwitchAllReq
{

    public int iUidHero = 0;
    public int iSelContainerID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchAllReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchAllReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iSelContainerID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchAllReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchAllReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSelContainerID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSEquipSwitchAllRsp
{

    public int iUidHero = 0;
    public int iSelContainerID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchAllRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchAllRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iSelContainerID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSEquipSwitchAllRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSEquipSwitchAllRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSelContainerID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDemandNewListReq
{

    public int iNull = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandNewListReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandNewListReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandNewListReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandNewListReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDemandNewListRsp
{

    public short nDemandListRef = 0;
    public List<DemandUnit> astDemandList = new List<DemandUnit>();
    public uint uiNextUpdateTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandNewListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandNewListRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nDemandListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nDemandListRef; ++i)
            {
                ret = this.astDemandList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextUpdateTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandNewListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandNewListRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nDemandListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astDemandList.Clear();
            for (int i = 0; i < this.nDemandListRef; ++i)
            {
                this.astDemandList.Add(new DemandUnit());
                ret = this.astDemandList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextUpdateTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDemandSubmitReq
{

    public int iUidHero = 0;
    public int iSubmitType = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandSubmitReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandSubmitReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iSubmitType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandSubmitReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandSubmitReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidHero);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSubmitType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDemandSubmitRsp
{

    public BackPacketMgr stDemandList = new BackPacketMgr();
    public uint uiNextUpdateTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandSubmitRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandSubmitRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stDemandList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextUpdateTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDemandSubmitRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDemandSubmitRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stDemandList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextUpdateTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroRecruitInfoReq
{

    public int iNull = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitInfoReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitInfoReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitInfoReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitInfoReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroRecruitInfoRsp
{

    public short nHeroRecruitInfoRef = 0;
    public List<RecruitInfo> astHeroRecruitInfo = new List<RecruitInfo>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroRecruitInfoRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroRecruitInfoRef; ++i)
            {
                ret = this.astHeroRecruitInfo[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitInfoRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitInfoRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroRecruitInfoRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astHeroRecruitInfo.Clear();
            for (int i = 0; i < this.nHeroRecruitInfoRef; ++i)
            {
                this.astHeroRecruitInfo.Add(new RecruitInfo());
                ret = this.astHeroRecruitInfo[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class CSHeroRecruitReq
{

    public int iType = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroRecruitRsp
{

    public int iHeroRecurited = 0;
    public SoulStoneInfo stSoulStone = new SoulStoneInfo();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iHeroRecurited);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stSoulStone.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iHeroRecurited);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stSoulStone.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroRecruitListReq
{

    public int iType = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitListReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitListReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitListReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitListReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSHeroRecruitListRsp
{

    public short nHeroRecuritListRef = 0;
    public List<int> aiHeroRecuritList = new List<int>();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitListRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nHeroRecuritListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nHeroRecuritListRef; ++i)
            {
                ret = dstBuf.WriteInt32(this.aiHeroRecuritList[i]);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSHeroRecruitListRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSHeroRecruitListRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nHeroRecuritListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            aiHeroRecuritList.Clear();
            for (int i = 0; i < this.nHeroRecuritListRef; ++i)
            {
                this.aiHeroRecuritList.Add(new Int32());
                int val = 0;
                ret = srcBuf.ReadInt32(ref val);
                this.aiHeroRecuritList[i] = val;
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        return ret;
    }

};

public class CSGMReq
{

    public string szCmd = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGMReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGMReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteString(this.szCmd, (int)ENUMGAME. MAX_GMCMDREQ_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGMReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGMReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadString(ref this.szCmd, (int)ENUMGAME. MAX_GMCMDREQ_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSGMRsp
{

    public string szCmd = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGMRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGMRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteString(this.szCmd, (int)ENUMGAME. MAX_GMCMDRSP_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSGMRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSGMRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadString(ref this.szCmd, (int)ENUMGAME. MAX_GMCMDRSP_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSTroopsEditReq
{

    public TroopsPositionMgr stTroopsPositionMgr = new TroopsPositionMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsEditReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsEditReq.VERSION.CURRVERSION;
        }

        {
            ret = this.stTroopsPositionMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsEditReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsEditReq.VERSION.CURRVERSION;
        }

        {
            ret = this.stTroopsPositionMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSTroopsEditRsp
{

    public short nResult = 0;
    public TroopsPositionMgr stTroopsPositionMgr = new TroopsPositionMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsEditRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsEditRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stTroopsPositionMgr.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsEditRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsEditRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nResult);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stTroopsPositionMgr.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSTroopsRenameReq
{

    public int iUidTroops = 0;
    public string szName = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsRenameReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsRenameReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsRenameReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsRenameReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSTroopsRenameRsp
{

    public int iUidTroops = 0;
    public string szName = "";

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsRenameRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsRenameRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteString(this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSTroopsRenameRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSTroopsRenameRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadString(ref this.szName, (int)ENUMGAME.MAX_NAME_LEN);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsChallengeReq
{

    public int iUidTroops = 0;
    public int iUidDungeons = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsChallengeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsChallengeReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsChallengeReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsChallengeReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsChallengeRsp
{

    public int ibSuccess = 0;
    public int iUidTroops = 0;
    public int iUidDungeons = 0;
    public uint uiTimeStart = 0;
    public BackPacketMgr stRewardGoods = new BackPacketMgr();
    public TroopsExp stExpRewardHero = new TroopsExp();
    public BattleLog stbattleLog = new BattleLog();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsChallengeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsChallengeRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.ibSuccess);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stRewardGoods.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stExpRewardHero.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stbattleLog.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsChallengeRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsChallengeRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.ibSuccess);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stRewardGoods.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stExpRewardHero.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stbattleLog.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsPatrolReq
{

    public int iUidTroops = 0;
    public int iUidDungeons = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsPatrolRsp
{

    public int iUidTroops = 0;
    public int iUidDungeons = 0;
    public uint uiTimeStart = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidDungeons);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsPatrolCompleteRep
{

    public int iUidTroops = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolCompleteRep.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolCompleteRep.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolCompleteRep.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolCompleteRep.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsPatrolCompleteRsp
{

    public int iUidTroops = 0;
    public uint uiTimeStart = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolCompleteRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolCompleteRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsPatrolCompleteRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsPatrolCompleteRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsGetBoxReq
{

    public int iUidTroops = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsGetBoxReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsGetBoxReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsGetBoxReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsGetBoxReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSDungeonsGetBoxRsp
{

    public int iUidTroops = 0;
    public uint uiTimeStart = 0;
    public BackPacketMgr stRewardGoods = new BackPacketMgr();
    public TroopsExp stExpRewardHero = new TroopsExp();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsGetBoxRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsGetBoxRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stRewardGoods.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stExpRewardHero.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSDungeonsGetBoxRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSDungeonsGetBoxRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUidTroops);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiTimeStart);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stRewardGoods.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stExpRewardHero.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSOrderGetNewReq
{

    public int iNull = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderGetNewReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderGetNewReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderGetNewReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderGetNewReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iNull);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSOrderGetNewRsp
{

    public short nOrderListRef = 0;
    public List<OrderUnit> astOrderList = new List<OrderUnit>();
    public uint uiNextNewOrderTime = 0;
    public uint uiNextSubmitTime = 0;
    public uint uiNextRefreshTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderGetNewRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderGetNewRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt16(this.nOrderListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            for (int i = 0; i < this.nOrderListRef; ++i)
            {
                ret = this.astOrderList[i].pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextNewOrderTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextSubmitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextRefreshTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderGetNewRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderGetNewRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt16(ref this.nOrderListRef);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            astOrderList.Clear();
            for (int i = 0; i < this.nOrderListRef; ++i)
            {
                this.astOrderList.Add(new OrderUnit());
                ret = this.astOrderList[i].unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextNewOrderTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextSubmitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextRefreshTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSOrderRefreshReq
{

    public int iOrderID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderRefreshReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderRefreshReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iOrderID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderRefreshReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderRefreshReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iOrderID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSOrderRefreshRsp
{

    public OrderUnit stOrder = new OrderUnit();
    public uint uiNextRefreshTime = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderRefreshRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderRefreshRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stOrder.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextRefreshTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderRefreshRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderRefreshRsp.VERSION.CURRVERSION;
        }

        {
            ret = this.stOrder.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextRefreshTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSOrderSubmitReq
{

    public int iSubmitType = 0;
    public int iOrderID = 0;

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderSubmitReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderSubmitReq.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iSubmitType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iOrderID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderSubmitReq.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderSubmitReq.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSubmitType);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iOrderID);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSOrderSubmitRsp
{

    public int iSubmitStatus = 0;
    public uint uiNextSubmitTime = 0;
    public BackPacketMgr stOrderList = new BackPacketMgr();

    private enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct()
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        // no need to set default value

        return ret;
    }

    public DrError.ErrorType pack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderSubmitRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderSubmitRsp.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iSubmitStatus);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt32(this.uiNextSubmitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stOrderList.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public DrError.ErrorType unpack(byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSOrderSubmitRsp.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSOrderSubmitRsp.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iSubmitStatus);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiNextSubmitTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stOrderList.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

}

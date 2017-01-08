using System;
using System.Collections;
using System.Collections.Generic;
namespace SkyWarProto {

public enum CSMSGID
{
    CS_MSGID_MIN = 0,
    CS_MSGID_LOGIN_REQ = 1,
    CS_MSGID_LOGIN_RSP = 2,
    CS_MSGID_CREATE_REQ = 3,
    CS_MSGID_CREATE_RSP = 4,
    CS_MSGID_NOTIFY_RSP = 8,
    CS_MSGID_RPC_NOTIFY_RSP = 9,
    CS_MSGID_AUTORESPONSEPACKET_RSP = 12,
    CS_MSGID_LOGINACTOR_RSP = 22,
    CS_MSGID_LOGINMAPBUILDMGR_RSP = 24,
    CS_MSGID_LOGINBUILDINGMAKEINFOMGR_RSP = 26,
    CS_MSGID_LOGINBACKPACKETMGR_RSP = 28,
    CS_MSGID_LOGINEQUIPMAKEINFOMGR_RSP = 30,
    CS_MSGID_LOGINENTERGAME_RSP = 32,
    CS_MSGID_LOGINHEROMGR_RSP = 34,
    CS_MSGID_LOGINTROOPSMGR_RSP = 36,
    CS_MSGID_LOGINORDERLIST_RSP = 37,
    CS_MSGID_LOGINDEMANDLIST_RSP = 38,
    CS_MSGID_BUILDINGBUILD_REQ = 41,
    CS_MSGID_BUILDINGBUILD_RSP = 42,
    CS_MSGID_BUILDINGRECYCLE_REQ = 43,
    CS_MSGID_BUILDINGRECYCLE_RSP = 44,
    CS_MSGID_BUILDINGMOVE_REQ = 45,
    CS_MSGID_BUILDINGMOVE_RSP = 46,
    CS_MSGID_BUILDINGUPLEVEL_REQ = 47,
    CS_MSGID_BUILDINGUPLEVEL_RSP = 48,
    CS_MSGID_IMUPLEVEL_REQ = 49,
    CS_MSGID_IMUPLEVEL_RSP = 50,
    CS_MSGID_CANCELUPLEVEL_REQ = 51,
    CS_MSGID_CANCELUPLEVEL_RSP = 52,
    CS_MSGID_BUILDINGUPLEVELCOMPLETE_REQ = 53,
    CS_MSGID_BUILDINGUPLEVELCOMPLETE_RSP = 54,
    CS_MSGID_EQUIPMAKE_REQ = 71,
    CS_MSGID_EQUIPMAKE_RSP = 72,
    CS_MSGID_IMMAKE_REQ = 73,
    CS_MSGID_IMMAKE_RSP = 74,
    CS_MSGID_CANCELMAKE_REQ = 75,
    CS_MSGID_CANCELMAKE_RSP = 76,
    CS_MSGID_EQUIPGETCOMPLETE_REQ = 77,
    CS_MSGID_EQUIPGETCOMPLETE_RSP = 78,
    CS_MSGID_UPDATABUILDING_RSP = 80,
    CS_MSGID_REFRESH_MAKEINFO_REQ = 81,
    CS_MSGID_REFRESH_MAKEINFO_RSP = 82,
    CS_MSGID_RESOURCEGET_REQ = 101,
    CS_MSGID_RESOURCEGET_RSP = 102,
    CS_MSGID_RESOURCEBUY_REQ = 103,
    CS_MSGID_RESOURCEBUY_RSP = 104,
    CS_MSGID_EQUIPSELL_REQ = 121,
    CS_MSGID_EQUIPSELL_RSP = 122,
    CS_MSGID_GOODUSE_REQ = 129,
    CS_MSGID_GOODUSE_RSP = 130,
    CS_UPDATEOBJ_ROLE_RSP = 152,
    CS_UPDATEOBJ_MAPBUILDING_RSP = 154,
    CS_UPDATEOBJ_EQUIPMAKE_RSP = 156,
    CS_UPDATEOBJ_RESOURCE_RSP = 158,
    CS_UPDATEOBJ_BACKPACK_RSP = 160,
    CS_UPDATEOBJ_EQUIPMAKEINFO_RSP = 162,
    CS_UPDATEOBJ_HEROINFO_RSP = 164,
    CS_UPDATEOBJ_TROOPSINFO_RSP = 166,
    CS_UPDATEGAMEOBJE_RSP = 170,
    CS_MSGID_HERO_REFRESHVIT_REQ = 201,
    CS_MSGID_HERO_REFRESHHP_REQ = 203,
    CS_MSGID_HERO_STARUPLEVEL_REQ = 205,
    CS_MSGID_HERO_STARUPLEVEL_RSP = 206,
    CS_MSGID_EQUIP_PUTON_REQ = 231,
    CS_MSGID_EQUIP_PUTON_RSP = 232,
    CS_MSGID_EQUIP_PUTOFF_REQ = 233,
    CS_MSGID_EQUIP_PUTOFF_RSP = 234,
    CS_MSGID_EQUIP_SWITCH_REQ = 235,
    CS_MSGID_EQUIP_SWITCH_RSP = 236,
    CS_MSGID_EQUIP_SWITCHALL_REQ = 237,
    CS_MSGID_EQUIP_SWITCHALL_RSP = 238,
    CS_MSGID_DEMAND_NEW_LIST_REQ = 251,
    CS_MSGID_DEMAND_NEW_LIST_RSP = 252,
    CS_MSGID_DEMAND_SUBMIT_REQ = 253,
    CS_MSGID_DEMAND_SUBMIT_RSP = 254,
    CS_MSGID_TROOPS_EDIT_REQ = 301,
    CS_MSGID_TROOPS_EDIT_RSP = 302,
    CS_MSGID_TROOPS_RENAME_REQ = 303,
    CS_MSGID_TROOPS_RENAME_RSP = 304,
    CS_MSGID_DUNGEONS_CHALLENGE_REQ = 351,
    CS_MSGID_DUNGEONS_CHALLENGE_RSP = 352,
    CS_MSGID_DUNGEONS_PATROL_REQ = 353,
    CS_MSGID_DUNGEONS_PATROL_RSP = 354,
    CS_MSGID_DUNGEONS_PATROLCOMPLETE_REQ = 355,
    CS_MSGID_DUNGEONS_PATROLCOMPLETE_RSP = 356,
    CS_MSGID_DUNGEONS_GETBOX_REQ = 357,
    CS_MSGID_DUNGEONS_GETBOX_RSP = 358,
    CS_HERO_RECRUIT_INFO_REQ = 371,
    CS_HERO_RECRUIT_INFO_RSP = 372,
    CS_HERO_RECRUIT_REQ = 373,
    CS_HERO_RECRUIT_RSP = 374,
    CS_HERO_RECRUIT_LIST_REQ = 375,
    CS_HERO_RECRUIT_LIST_RSP = 376,
    CS_GM_REQ = 391,
    CS_GM_RSP = 392,
    CS_ORDER_LIST_REQ = 401,
    CS_ORDER_LIST_RSP = 402,
    CS_ORDER_REFRESH_REQ = 403,
    CS_ORDER_REFRESH_RSP = 404,
    CS_ORDER_SUBMIT_REQ = 405,
    CS_ORDER_SUBMIT_RSP = 406,
    CS_ORDER_GET_NEW_REQ = 407,
    CS_ORDER_GET_NEW_RSP = 408,
    CS_MSGID_MAX = 512,
};

public class CSMsgHead
{

    public uint uiLen = 0;
    public byte bFlag = 0;
    public ushort unMsgID = 0;
    public uint uiUid = 0;
    public uint uiSeq = 0;

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

        if (0 == cutVer || (uint)CSMsgHead.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSMsgHead.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteUInt32(this.uiLen);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt8(this.bFlag);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteUInt16(this.unMsgID);
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
            ret = dstBuf.WriteUInt32(this.uiSeq);
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

        if (0 == cutVer || (uint)CSMsgHead.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSMsgHead.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadUInt32(ref this.uiLen);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt8(ref this.bFlag);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadUInt16(ref this.unMsgID);
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
            ret = srcBuf.ReadUInt32(ref this.uiSeq);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

public class CSMsgBody
{

    public CSLoginReq stLoginReq;
    public CSLoginRsp stLoginRsp;
    public CSCreateReq stCreateReq;
    public CSCreateRsp stCreateRsp;
    public CSNotifyRsp stNotifyRsp;
    public CSRpcNotifyRsp stRpcNotifyRsp;
    public CSAutoResponsePacketRsp stAutoResponsePacketRsp;
    public CSLoginActorRsp stLoginActorRsp;
    public CSLoginMapBuildMgrRsp stLoginMapBuildMgrRsp;
    public CSLoginBuildingMakeInfoMgrRsp stLoginBuildingMakeInfoMgrRsp;
    public CSLoginBackPacketMgrRsp stLoginBackpacketMgrRsp;
    public CSLoginEquipMakeInfoMgrRsp stLoginEquipMakeinfoMgrRsp;
    public CSLoginEnterGameRsp stLoginEnterGameRsp;
    public CSLoginHeroMgrRsp stLoginHeroMgrRsp;
    public CSLoginTroopsMgrRsp stLoginTroopsMgrRsp;
    public CSLoginOrderListRsp stLoginOrderListRsp;
    public CSLoginDemandListRsp stLoginDemandListRsp;
    public CSBuildingBuildReq stBuildingBuildReq;
    public CSBuildingBuildRsp stBuildingBuildRsp;
    public CSBuildingRecycleReq stBuildingRecycleReq;
    public CSBuildingRecycleRsp stBuildingRecycleRsp;
    public CSBuildingMoveReq stBuildingMoveReq;
    public CSBuildingMoveRsp stBuildingMoveRsp;
    public CSBuildingUpLevelReq stBuildingUpLevelReq;
    public CSBuildingUpLevelRsp stBuildingUpLevelRsp;
    public CSImUpLevelReq stImUpLevelReq;
    public CSImUpLevelRsp stImUpLevelRsp;
    public CSCancelUpLevelReq stCancelUpLevelReq;
    public CSCancelUpLevelRsp stCancelUpLevelRsp;
    public CSBuildingUpLevelCompleteReq stBuildingUpLevelCompleteReq;
    public CSBuildingUpLevelCompleteRsp stBuildingUpLevelCompleteRsp;
    public CSEquipMakeReq stEquipMakeReq;
    public CSEquipMakeRsp stEquipMakeRsp;
    public CSImMakeReq stImMakeReq;
    public CSImMakeRsp stImMakeRsp;
    public CSCancelMakeReq stCancelMakeReq;
    public CSCancelMakeRsp stCancelMakeRsp;
    public CSEquipGetCompleteReq stEquipGetCompleteReq;
    public CSEquipGetCompleteRsp stEquipGetCompleteRsp;
    public CSUpDataBuildingRsp stUpDataBuildingRsp;
    public CSRefreshMakeInfoReq stRefreshMakeInfoReq;
    public CSRefreshMakeInfoRsp stRefreshMakeInfoRsp;
    public CSResourceGetReq stResourceGetReq;
    public CSResourceGetRsp stResourceGetRsp;
    public CSResourceBuyReq stResourceBuyReq;
    public CSResourceBuyRsp stResourceBuyRsp;
    public CSEquipSellReq stEquipSellReq;
    public CSEquipSellRsp stEquipSellRsp;
    public CSGoodUSEReq stGoodUSEReq;
    public CSGoodUSERsp stGoodUSERsp;
    public CSUpdateObjRoleRsp stUpdateObjRoleRsp;
    public CSUpdateObjMapBuildingRsp stUpdateObjMapBuildingRsp;
    public CSUpdateObjEquipMakeRsp stUpdateObjEquipMakeRsp;
    public CSUpdateObjResourceRsp stUpdateObjResourceRsp;
    public CSUpdateObjBackpackRsp stUpdateObjBackpackRsp;
    public CSUpdateObjEquipMakeInfoRsp stUpdateObjEquipMakeInfoRsp;
    public CSUpdateObjHeroInfoRsp stUpdateObjHeroInfoRsp;
    public CSUpdateObjTroopsInfoRsp stUpdateObjTroopsInfoRsp;
    public CSUpdateGameObjeRsp stUpdateGameObjeRsp;
    public CSHeroRefreshVITReq stHeroRefreshVITReq;
    public CSHeroRefreshHpReq stHeroRefreshHpReq;
    public CSHeroStarUpLevelReq stHeroStarUpLevelReq;
    public CSHeroStarUpLevelRsp stHeroStarUpLevelRsp;
    public CSEquipPutOnReq stEquipPutOnReq;
    public CSEquipPutOnRsp stEquipPutOnRsp;
    public CSEquipPutOffReq stEquipPutOffReq;
    public CSEquipPutOffRsp stEquipPutOffRsp;
    public CSEquipSwitchReq stEquipSwitchReq;
    public CSEquipSwitchRsp stEquipSwitchRsp;
    public CSEquipSwitchAllReq stEquipSwitchAllReq;
    public CSEquipSwitchAllRsp stEquipSwitchAllRsp;
    public CSDemandNewListReq stDemandNewListReq;
    public CSDemandNewListRsp stDemandNewListRsp;
    public CSDemandSubmitReq stDemandSubmitReq;
    public CSDemandSubmitRsp stDemandSubmitRsp;
    public CSTroopsEditReq stTroopsEditReq;
    public CSTroopsEditRsp stTroopsEditRsp;
    public CSTroopsRenameReq stTroopsRenameReq;
    public CSTroopsRenameRsp stTroopsRenameRsp;
    public CSDungeonsChallengeReq stDungeonsChallengeReq;
    public CSDungeonsChallengeRsp stDungeonsChallengeRsp;
    public CSDungeonsPatrolReq stDungeonsPatrolReq;
    public CSDungeonsPatrolRsp stDungeonsPatrolRsp;
    public CSDungeonsPatrolCompleteRep stDungeonsPatrolCompleteRep;
    public CSDungeonsPatrolCompleteRsp stDungeonsPatrolCompleteRsp;
    public CSDungeonsGetBoxReq stDungeonsGetBoxReq;
    public CSDungeonsGetBoxRsp stDungeonsGetBoxRsp;
    public CSHeroRecruitInfoReq stHeroRecruitInfoReq;
    public CSHeroRecruitInfoRsp stHeroRecruitInfoRsp;
    public CSHeroRecruitReq stHeroRecruitReq;
    public CSHeroRecruitRsp stHeroRecruitRsp;
    public CSHeroRecruitListReq stHeroRecruitListReq;
    public CSHeroRecruitListRsp stHeroRecruitListRsp;
    public CSGMReq stGMReq;
    public CSGMRsp stGMRsp;
    public CSOrderRefreshReq stOrderRefreshReq;
    public CSOrderRefreshRsp stOrderRefreshRsp;
    public CSOrderSubmitReq stOrderSubmitReq;
    public CSOrderSubmitRsp stOrderSubmitRsp;
    public CSOrderGetNewReq stOrderGetNewReq;
    public CSOrderGetNewRsp stOrderGetNewRsp;

    public enum VERSION
    {
        BASEVERSION = 1,
        CURRVERSION = 1,
    };


    public DrError.ErrorType construct(int selector)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;
        if ((int)CSMSGID.CS_MSGID_LOGIN_REQ == selector)
        {
            {
                if (null == this.stLoginReq)
                {
                    this.stLoginReq = new CSLoginReq();
                }
                this.stLoginReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGIN_RSP == selector)
        {
            {
                if (null == this.stLoginRsp)
                {
                    this.stLoginRsp = new CSLoginRsp();
                }
                this.stLoginRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CREATE_REQ == selector)
        {
            {
                if (null == this.stCreateReq)
                {
                    this.stCreateReq = new CSCreateReq();
                }
                this.stCreateReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CREATE_RSP == selector)
        {
            {
                if (null == this.stCreateRsp)
                {
                    this.stCreateRsp = new CSCreateRsp();
                }
                this.stCreateRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_NOTIFY_RSP == selector)
        {
            {
                if (null == this.stNotifyRsp)
                {
                    this.stNotifyRsp = new CSNotifyRsp();
                }
                this.stNotifyRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RPC_NOTIFY_RSP == selector)
        {
            {
                if (null == this.stRpcNotifyRsp)
                {
                    this.stRpcNotifyRsp = new CSRpcNotifyRsp();
                }
                this.stRpcNotifyRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_AUTORESPONSEPACKET_RSP == selector)
        {
            {
                if (null == this.stAutoResponsePacketRsp)
                {
                    this.stAutoResponsePacketRsp = new CSAutoResponsePacketRsp();
                }
                this.stAutoResponsePacketRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINACTOR_RSP == selector)
        {
            {
                if (null == this.stLoginActorRsp)
                {
                    this.stLoginActorRsp = new CSLoginActorRsp();
                }
                this.stLoginActorRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINMAPBUILDMGR_RSP == selector)
        {
            {
                if (null == this.stLoginMapBuildMgrRsp)
                {
                    this.stLoginMapBuildMgrRsp = new CSLoginMapBuildMgrRsp();
                }
                this.stLoginMapBuildMgrRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINBUILDINGMAKEINFOMGR_RSP == selector)
        {
            {
                if (null == this.stLoginBuildingMakeInfoMgrRsp)
                {
                    this.stLoginBuildingMakeInfoMgrRsp = new CSLoginBuildingMakeInfoMgrRsp();
                }
                this.stLoginBuildingMakeInfoMgrRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINBACKPACKETMGR_RSP == selector)
        {
            {
                if (null == this.stLoginBackpacketMgrRsp)
                {
                    this.stLoginBackpacketMgrRsp = new CSLoginBackPacketMgrRsp();
                }
                this.stLoginBackpacketMgrRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINEQUIPMAKEINFOMGR_RSP == selector)
        {
            {
                if (null == this.stLoginEquipMakeinfoMgrRsp)
                {
                    this.stLoginEquipMakeinfoMgrRsp = new CSLoginEquipMakeInfoMgrRsp();
                }
                this.stLoginEquipMakeinfoMgrRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINENTERGAME_RSP == selector)
        {
            {
                if (null == this.stLoginEnterGameRsp)
                {
                    this.stLoginEnterGameRsp = new CSLoginEnterGameRsp();
                }
                this.stLoginEnterGameRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINHEROMGR_RSP == selector)
        {
            {
                if (null == this.stLoginHeroMgrRsp)
                {
                    this.stLoginHeroMgrRsp = new CSLoginHeroMgrRsp();
                }
                this.stLoginHeroMgrRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINTROOPSMGR_RSP == selector)
        {
            {
                if (null == this.stLoginTroopsMgrRsp)
                {
                    this.stLoginTroopsMgrRsp = new CSLoginTroopsMgrRsp();
                }
                this.stLoginTroopsMgrRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINORDERLIST_RSP == selector)
        {
            {
                if (null == this.stLoginOrderListRsp)
                {
                    this.stLoginOrderListRsp = new CSLoginOrderListRsp();
                }
                this.stLoginOrderListRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINDEMANDLIST_RSP == selector)
        {
            {
                if (null == this.stLoginDemandListRsp)
                {
                    this.stLoginDemandListRsp = new CSLoginDemandListRsp();
                }
                this.stLoginDemandListRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGBUILD_REQ == selector)
        {
            {
                if (null == this.stBuildingBuildReq)
                {
                    this.stBuildingBuildReq = new CSBuildingBuildReq();
                }
                this.stBuildingBuildReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGBUILD_RSP == selector)
        {
            {
                if (null == this.stBuildingBuildRsp)
                {
                    this.stBuildingBuildRsp = new CSBuildingBuildRsp();
                }
                this.stBuildingBuildRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGRECYCLE_REQ == selector)
        {
            {
                if (null == this.stBuildingRecycleReq)
                {
                    this.stBuildingRecycleReq = new CSBuildingRecycleReq();
                }
                this.stBuildingRecycleReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGRECYCLE_RSP == selector)
        {
            {
                if (null == this.stBuildingRecycleRsp)
                {
                    this.stBuildingRecycleRsp = new CSBuildingRecycleRsp();
                }
                this.stBuildingRecycleRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGMOVE_REQ == selector)
        {
            {
                if (null == this.stBuildingMoveReq)
                {
                    this.stBuildingMoveReq = new CSBuildingMoveReq();
                }
                this.stBuildingMoveReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGMOVE_RSP == selector)
        {
            {
                if (null == this.stBuildingMoveRsp)
                {
                    this.stBuildingMoveRsp = new CSBuildingMoveRsp();
                }
                this.stBuildingMoveRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVEL_REQ == selector)
        {
            {
                if (null == this.stBuildingUpLevelReq)
                {
                    this.stBuildingUpLevelReq = new CSBuildingUpLevelReq();
                }
                this.stBuildingUpLevelReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVEL_RSP == selector)
        {
            {
                if (null == this.stBuildingUpLevelRsp)
                {
                    this.stBuildingUpLevelRsp = new CSBuildingUpLevelRsp();
                }
                this.stBuildingUpLevelRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMUPLEVEL_REQ == selector)
        {
            {
                if (null == this.stImUpLevelReq)
                {
                    this.stImUpLevelReq = new CSImUpLevelReq();
                }
                this.stImUpLevelReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMUPLEVEL_RSP == selector)
        {
            {
                if (null == this.stImUpLevelRsp)
                {
                    this.stImUpLevelRsp = new CSImUpLevelRsp();
                }
                this.stImUpLevelRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELUPLEVEL_REQ == selector)
        {
            {
                if (null == this.stCancelUpLevelReq)
                {
                    this.stCancelUpLevelReq = new CSCancelUpLevelReq();
                }
                this.stCancelUpLevelReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELUPLEVEL_RSP == selector)
        {
            {
                if (null == this.stCancelUpLevelRsp)
                {
                    this.stCancelUpLevelRsp = new CSCancelUpLevelRsp();
                }
                this.stCancelUpLevelRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVELCOMPLETE_REQ == selector)
        {
            {
                if (null == this.stBuildingUpLevelCompleteReq)
                {
                    this.stBuildingUpLevelCompleteReq = new CSBuildingUpLevelCompleteReq();
                }
                this.stBuildingUpLevelCompleteReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVELCOMPLETE_RSP == selector)
        {
            {
                if (null == this.stBuildingUpLevelCompleteRsp)
                {
                    this.stBuildingUpLevelCompleteRsp = new CSBuildingUpLevelCompleteRsp();
                }
                this.stBuildingUpLevelCompleteRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPMAKE_REQ == selector)
        {
            {
                if (null == this.stEquipMakeReq)
                {
                    this.stEquipMakeReq = new CSEquipMakeReq();
                }
                this.stEquipMakeReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPMAKE_RSP == selector)
        {
            {
                if (null == this.stEquipMakeRsp)
                {
                    this.stEquipMakeRsp = new CSEquipMakeRsp();
                }
                this.stEquipMakeRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMMAKE_REQ == selector)
        {
            {
                if (null == this.stImMakeReq)
                {
                    this.stImMakeReq = new CSImMakeReq();
                }
                this.stImMakeReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMMAKE_RSP == selector)
        {
            {
                if (null == this.stImMakeRsp)
                {
                    this.stImMakeRsp = new CSImMakeRsp();
                }
                this.stImMakeRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELMAKE_REQ == selector)
        {
            {
                if (null == this.stCancelMakeReq)
                {
                    this.stCancelMakeReq = new CSCancelMakeReq();
                }
                this.stCancelMakeReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELMAKE_RSP == selector)
        {
            {
                if (null == this.stCancelMakeRsp)
                {
                    this.stCancelMakeRsp = new CSCancelMakeRsp();
                }
                this.stCancelMakeRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPGETCOMPLETE_REQ == selector)
        {
            {
                if (null == this.stEquipGetCompleteReq)
                {
                    this.stEquipGetCompleteReq = new CSEquipGetCompleteReq();
                }
                this.stEquipGetCompleteReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPGETCOMPLETE_RSP == selector)
        {
            {
                if (null == this.stEquipGetCompleteRsp)
                {
                    this.stEquipGetCompleteRsp = new CSEquipGetCompleteRsp();
                }
                this.stEquipGetCompleteRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_UPDATABUILDING_RSP == selector)
        {
            {
                if (null == this.stUpDataBuildingRsp)
                {
                    this.stUpDataBuildingRsp = new CSUpDataBuildingRsp();
                }
                this.stUpDataBuildingRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_REFRESH_MAKEINFO_REQ == selector)
        {
            {
                if (null == this.stRefreshMakeInfoReq)
                {
                    this.stRefreshMakeInfoReq = new CSRefreshMakeInfoReq();
                }
                this.stRefreshMakeInfoReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_REFRESH_MAKEINFO_RSP == selector)
        {
            {
                if (null == this.stRefreshMakeInfoRsp)
                {
                    this.stRefreshMakeInfoRsp = new CSRefreshMakeInfoRsp();
                }
                this.stRefreshMakeInfoRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEGET_REQ == selector)
        {
            {
                if (null == this.stResourceGetReq)
                {
                    this.stResourceGetReq = new CSResourceGetReq();
                }
                this.stResourceGetReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEGET_RSP == selector)
        {
            {
                if (null == this.stResourceGetRsp)
                {
                    this.stResourceGetRsp = new CSResourceGetRsp();
                }
                this.stResourceGetRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEBUY_REQ == selector)
        {
            {
                if (null == this.stResourceBuyReq)
                {
                    this.stResourceBuyReq = new CSResourceBuyReq();
                }
                this.stResourceBuyReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEBUY_RSP == selector)
        {
            {
                if (null == this.stResourceBuyRsp)
                {
                    this.stResourceBuyRsp = new CSResourceBuyRsp();
                }
                this.stResourceBuyRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPSELL_REQ == selector)
        {
            {
                if (null == this.stEquipSellReq)
                {
                    this.stEquipSellReq = new CSEquipSellReq();
                }
                this.stEquipSellReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPSELL_RSP == selector)
        {
            {
                if (null == this.stEquipSellRsp)
                {
                    this.stEquipSellRsp = new CSEquipSellRsp();
                }
                this.stEquipSellRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_GOODUSE_REQ == selector)
        {
            {
                if (null == this.stGoodUSEReq)
                {
                    this.stGoodUSEReq = new CSGoodUSEReq();
                }
                this.stGoodUSEReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_GOODUSE_RSP == selector)
        {
            {
                if (null == this.stGoodUSERsp)
                {
                    this.stGoodUSERsp = new CSGoodUSERsp();
                }
                this.stGoodUSERsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_ROLE_RSP == selector)
        {
            {
                if (null == this.stUpdateObjRoleRsp)
                {
                    this.stUpdateObjRoleRsp = new CSUpdateObjRoleRsp();
                }
                this.stUpdateObjRoleRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_MAPBUILDING_RSP == selector)
        {
            {
                if (null == this.stUpdateObjMapBuildingRsp)
                {
                    this.stUpdateObjMapBuildingRsp = new CSUpdateObjMapBuildingRsp();
                }
                this.stUpdateObjMapBuildingRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_EQUIPMAKE_RSP == selector)
        {
            {
                if (null == this.stUpdateObjEquipMakeRsp)
                {
                    this.stUpdateObjEquipMakeRsp = new CSUpdateObjEquipMakeRsp();
                }
                this.stUpdateObjEquipMakeRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_RESOURCE_RSP == selector)
        {
            {
                if (null == this.stUpdateObjResourceRsp)
                {
                    this.stUpdateObjResourceRsp = new CSUpdateObjResourceRsp();
                }
                this.stUpdateObjResourceRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_BACKPACK_RSP == selector)
        {
            {
                if (null == this.stUpdateObjBackpackRsp)
                {
                    this.stUpdateObjBackpackRsp = new CSUpdateObjBackpackRsp();
                }
                this.stUpdateObjBackpackRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_EQUIPMAKEINFO_RSP == selector)
        {
            {
                if (null == this.stUpdateObjEquipMakeInfoRsp)
                {
                    this.stUpdateObjEquipMakeInfoRsp = new CSUpdateObjEquipMakeInfoRsp();
                }
                this.stUpdateObjEquipMakeInfoRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_HEROINFO_RSP == selector)
        {
            {
                if (null == this.stUpdateObjHeroInfoRsp)
                {
                    this.stUpdateObjHeroInfoRsp = new CSUpdateObjHeroInfoRsp();
                }
                this.stUpdateObjHeroInfoRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_TROOPSINFO_RSP == selector)
        {
            {
                if (null == this.stUpdateObjTroopsInfoRsp)
                {
                    this.stUpdateObjTroopsInfoRsp = new CSUpdateObjTroopsInfoRsp();
                }
                this.stUpdateObjTroopsInfoRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEGAMEOBJE_RSP == selector)
        {
            {
                if (null == this.stUpdateGameObjeRsp)
                {
                    this.stUpdateGameObjeRsp = new CSUpdateGameObjeRsp();
                }
                this.stUpdateGameObjeRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_REFRESHVIT_REQ == selector)
        {
            {
                if (null == this.stHeroRefreshVITReq)
                {
                    this.stHeroRefreshVITReq = new CSHeroRefreshVITReq();
                }
                this.stHeroRefreshVITReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_REFRESHHP_REQ == selector)
        {
            {
                if (null == this.stHeroRefreshHpReq)
                {
                    this.stHeroRefreshHpReq = new CSHeroRefreshHpReq();
                }
                this.stHeroRefreshHpReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_STARUPLEVEL_REQ == selector)
        {
            {
                if (null == this.stHeroStarUpLevelReq)
                {
                    this.stHeroStarUpLevelReq = new CSHeroStarUpLevelReq();
                }
                this.stHeroStarUpLevelReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_STARUPLEVEL_RSP == selector)
        {
            {
                if (null == this.stHeroStarUpLevelRsp)
                {
                    this.stHeroStarUpLevelRsp = new CSHeroStarUpLevelRsp();
                }
                this.stHeroStarUpLevelRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTON_REQ == selector)
        {
            {
                if (null == this.stEquipPutOnReq)
                {
                    this.stEquipPutOnReq = new CSEquipPutOnReq();
                }
                this.stEquipPutOnReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTON_RSP == selector)
        {
            {
                if (null == this.stEquipPutOnRsp)
                {
                    this.stEquipPutOnRsp = new CSEquipPutOnRsp();
                }
                this.stEquipPutOnRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTOFF_REQ == selector)
        {
            {
                if (null == this.stEquipPutOffReq)
                {
                    this.stEquipPutOffReq = new CSEquipPutOffReq();
                }
                this.stEquipPutOffReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTOFF_RSP == selector)
        {
            {
                if (null == this.stEquipPutOffRsp)
                {
                    this.stEquipPutOffRsp = new CSEquipPutOffRsp();
                }
                this.stEquipPutOffRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCH_REQ == selector)
        {
            {
                if (null == this.stEquipSwitchReq)
                {
                    this.stEquipSwitchReq = new CSEquipSwitchReq();
                }
                this.stEquipSwitchReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCH_RSP == selector)
        {
            {
                if (null == this.stEquipSwitchRsp)
                {
                    this.stEquipSwitchRsp = new CSEquipSwitchRsp();
                }
                this.stEquipSwitchRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCHALL_REQ == selector)
        {
            {
                if (null == this.stEquipSwitchAllReq)
                {
                    this.stEquipSwitchAllReq = new CSEquipSwitchAllReq();
                }
                this.stEquipSwitchAllReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCHALL_RSP == selector)
        {
            {
                if (null == this.stEquipSwitchAllRsp)
                {
                    this.stEquipSwitchAllRsp = new CSEquipSwitchAllRsp();
                }
                this.stEquipSwitchAllRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_NEW_LIST_REQ == selector)
        {
            {
                if (null == this.stDemandNewListReq)
                {
                    this.stDemandNewListReq = new CSDemandNewListReq();
                }
                this.stDemandNewListReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_NEW_LIST_RSP == selector)
        {
            {
                if (null == this.stDemandNewListRsp)
                {
                    this.stDemandNewListRsp = new CSDemandNewListRsp();
                }
                this.stDemandNewListRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_SUBMIT_REQ == selector)
        {
            {
                if (null == this.stDemandSubmitReq)
                {
                    this.stDemandSubmitReq = new CSDemandSubmitReq();
                }
                this.stDemandSubmitReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_SUBMIT_RSP == selector)
        {
            {
                if (null == this.stDemandSubmitRsp)
                {
                    this.stDemandSubmitRsp = new CSDemandSubmitRsp();
                }
                this.stDemandSubmitRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_EDIT_REQ == selector)
        {
            {
                if (null == this.stTroopsEditReq)
                {
                    this.stTroopsEditReq = new CSTroopsEditReq();
                }
                this.stTroopsEditReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_EDIT_RSP == selector)
        {
            {
                if (null == this.stTroopsEditRsp)
                {
                    this.stTroopsEditRsp = new CSTroopsEditRsp();
                }
                this.stTroopsEditRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_RENAME_REQ == selector)
        {
            {
                if (null == this.stTroopsRenameReq)
                {
                    this.stTroopsRenameReq = new CSTroopsRenameReq();
                }
                this.stTroopsRenameReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_RENAME_RSP == selector)
        {
            {
                if (null == this.stTroopsRenameRsp)
                {
                    this.stTroopsRenameRsp = new CSTroopsRenameRsp();
                }
                this.stTroopsRenameRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_CHALLENGE_REQ == selector)
        {
            {
                if (null == this.stDungeonsChallengeReq)
                {
                    this.stDungeonsChallengeReq = new CSDungeonsChallengeReq();
                }
                this.stDungeonsChallengeReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_CHALLENGE_RSP == selector)
        {
            {
                if (null == this.stDungeonsChallengeRsp)
                {
                    this.stDungeonsChallengeRsp = new CSDungeonsChallengeRsp();
                }
                this.stDungeonsChallengeRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROL_REQ == selector)
        {
            {
                if (null == this.stDungeonsPatrolReq)
                {
                    this.stDungeonsPatrolReq = new CSDungeonsPatrolReq();
                }
                this.stDungeonsPatrolReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROL_RSP == selector)
        {
            {
                if (null == this.stDungeonsPatrolRsp)
                {
                    this.stDungeonsPatrolRsp = new CSDungeonsPatrolRsp();
                }
                this.stDungeonsPatrolRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROLCOMPLETE_REQ == selector)
        {
            {
                if (null == this.stDungeonsPatrolCompleteRep)
                {
                    this.stDungeonsPatrolCompleteRep = new CSDungeonsPatrolCompleteRep();
                }
                this.stDungeonsPatrolCompleteRep.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROLCOMPLETE_RSP == selector)
        {
            {
                if (null == this.stDungeonsPatrolCompleteRsp)
                {
                    this.stDungeonsPatrolCompleteRsp = new CSDungeonsPatrolCompleteRsp();
                }
                this.stDungeonsPatrolCompleteRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_GETBOX_REQ == selector)
        {
            {
                if (null == this.stDungeonsGetBoxReq)
                {
                    this.stDungeonsGetBoxReq = new CSDungeonsGetBoxReq();
                }
                this.stDungeonsGetBoxReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_GETBOX_RSP == selector)
        {
            {
                if (null == this.stDungeonsGetBoxRsp)
                {
                    this.stDungeonsGetBoxRsp = new CSDungeonsGetBoxRsp();
                }
                this.stDungeonsGetBoxRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_INFO_REQ == selector)
        {
            {
                if (null == this.stHeroRecruitInfoReq)
                {
                    this.stHeroRecruitInfoReq = new CSHeroRecruitInfoReq();
                }
                this.stHeroRecruitInfoReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_INFO_RSP == selector)
        {
            {
                if (null == this.stHeroRecruitInfoRsp)
                {
                    this.stHeroRecruitInfoRsp = new CSHeroRecruitInfoRsp();
                }
                this.stHeroRecruitInfoRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_REQ == selector)
        {
            {
                if (null == this.stHeroRecruitReq)
                {
                    this.stHeroRecruitReq = new CSHeroRecruitReq();
                }
                this.stHeroRecruitReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_RSP == selector)
        {
            {
                if (null == this.stHeroRecruitRsp)
                {
                    this.stHeroRecruitRsp = new CSHeroRecruitRsp();
                }
                this.stHeroRecruitRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_LIST_REQ == selector)
        {
            {
                if (null == this.stHeroRecruitListReq)
                {
                    this.stHeroRecruitListReq = new CSHeroRecruitListReq();
                }
                this.stHeroRecruitListReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_LIST_RSP == selector)
        {
            {
                if (null == this.stHeroRecruitListRsp)
                {
                    this.stHeroRecruitListRsp = new CSHeroRecruitListRsp();
                }
                this.stHeroRecruitListRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_GM_REQ == selector)
        {
            {
                if (null == this.stGMReq)
                {
                    this.stGMReq = new CSGMReq();
                }
                this.stGMReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_GM_RSP == selector)
        {
            {
                if (null == this.stGMRsp)
                {
                    this.stGMRsp = new CSGMRsp();
                }
                this.stGMRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_REFRESH_REQ == selector)
        {
            {
                if (null == this.stOrderRefreshReq)
                {
                    this.stOrderRefreshReq = new CSOrderRefreshReq();
                }
                this.stOrderRefreshReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_REFRESH_RSP == selector)
        {
            {
                if (null == this.stOrderRefreshRsp)
                {
                    this.stOrderRefreshRsp = new CSOrderRefreshRsp();
                }
                this.stOrderRefreshRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_SUBMIT_REQ == selector)
        {
            {
                if (null == this.stOrderSubmitReq)
                {
                    this.stOrderSubmitReq = new CSOrderSubmitReq();
                }
                this.stOrderSubmitReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_SUBMIT_RSP == selector)
        {
            {
                if (null == this.stOrderSubmitRsp)
                {
                    this.stOrderSubmitRsp = new CSOrderSubmitRsp();
                }
                this.stOrderSubmitRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_GET_NEW_REQ == selector)
        {
            {
                if (null == this.stOrderGetNewReq)
                {
                    this.stOrderGetNewReq = new CSOrderGetNewReq();
                }
                this.stOrderGetNewReq.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_GET_NEW_RSP == selector)
        {
            {
                if (null == this.stOrderGetNewRsp)
                {
                    this.stOrderGetNewRsp = new CSOrderGetNewRsp();
                }
                this.stOrderGetNewRsp.construct();
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        return ret;
    }

    public DrError.ErrorType pack(int selector, byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrWriteBuf dstBuf = new DrWriteBuf(buffer, size);

        DrError.ErrorType ret = pack(selector, dstBuf, cutVer);

        usedSize = dstBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType pack(int selector, DrWriteBuf dstBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSMsgBody.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSMsgBody.VERSION.CURRVERSION;
        }

        if ((int)CSMSGID.CS_MSGID_LOGIN_REQ == selector)
        {
            {
                ret = this.stLoginReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGIN_RSP == selector)
        {
            {
                ret = this.stLoginRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CREATE_REQ == selector)
        {
            {
                ret = this.stCreateReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CREATE_RSP == selector)
        {
            {
                ret = this.stCreateRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_NOTIFY_RSP == selector)
        {
            {
                ret = this.stNotifyRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RPC_NOTIFY_RSP == selector)
        {
            {
                ret = this.stRpcNotifyRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_AUTORESPONSEPACKET_RSP == selector)
        {
            {
                ret = this.stAutoResponsePacketRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINACTOR_RSP == selector)
        {
            {
                ret = this.stLoginActorRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINMAPBUILDMGR_RSP == selector)
        {
            {
                ret = this.stLoginMapBuildMgrRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINBUILDINGMAKEINFOMGR_RSP == selector)
        {
            {
                ret = this.stLoginBuildingMakeInfoMgrRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINBACKPACKETMGR_RSP == selector)
        {
            {
                ret = this.stLoginBackpacketMgrRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINEQUIPMAKEINFOMGR_RSP == selector)
        {
            {
                ret = this.stLoginEquipMakeinfoMgrRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINENTERGAME_RSP == selector)
        {
            {
                ret = this.stLoginEnterGameRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINHEROMGR_RSP == selector)
        {
            {
                ret = this.stLoginHeroMgrRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINTROOPSMGR_RSP == selector)
        {
            {
                ret = this.stLoginTroopsMgrRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINORDERLIST_RSP == selector)
        {
            {
                ret = this.stLoginOrderListRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINDEMANDLIST_RSP == selector)
        {
            {
                ret = this.stLoginDemandListRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGBUILD_REQ == selector)
        {
            {
                ret = this.stBuildingBuildReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGBUILD_RSP == selector)
        {
            {
                ret = this.stBuildingBuildRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGRECYCLE_REQ == selector)
        {
            {
                ret = this.stBuildingRecycleReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGRECYCLE_RSP == selector)
        {
            {
                ret = this.stBuildingRecycleRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGMOVE_REQ == selector)
        {
            {
                ret = this.stBuildingMoveReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGMOVE_RSP == selector)
        {
            {
                ret = this.stBuildingMoveRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVEL_REQ == selector)
        {
            {
                ret = this.stBuildingUpLevelReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVEL_RSP == selector)
        {
            {
                ret = this.stBuildingUpLevelRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMUPLEVEL_REQ == selector)
        {
            {
                ret = this.stImUpLevelReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMUPLEVEL_RSP == selector)
        {
            {
                ret = this.stImUpLevelRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELUPLEVEL_REQ == selector)
        {
            {
                ret = this.stCancelUpLevelReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELUPLEVEL_RSP == selector)
        {
            {
                ret = this.stCancelUpLevelRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVELCOMPLETE_REQ == selector)
        {
            {
                ret = this.stBuildingUpLevelCompleteReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVELCOMPLETE_RSP == selector)
        {
            {
                ret = this.stBuildingUpLevelCompleteRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPMAKE_REQ == selector)
        {
            {
                ret = this.stEquipMakeReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPMAKE_RSP == selector)
        {
            {
                ret = this.stEquipMakeRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMMAKE_REQ == selector)
        {
            {
                ret = this.stImMakeReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMMAKE_RSP == selector)
        {
            {
                ret = this.stImMakeRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELMAKE_REQ == selector)
        {
            {
                ret = this.stCancelMakeReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELMAKE_RSP == selector)
        {
            {
                ret = this.stCancelMakeRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPGETCOMPLETE_REQ == selector)
        {
            {
                ret = this.stEquipGetCompleteReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPGETCOMPLETE_RSP == selector)
        {
            {
                ret = this.stEquipGetCompleteRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_UPDATABUILDING_RSP == selector)
        {
            {
                ret = this.stUpDataBuildingRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_REFRESH_MAKEINFO_REQ == selector)
        {
            {
                ret = this.stRefreshMakeInfoReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_REFRESH_MAKEINFO_RSP == selector)
        {
            {
                ret = this.stRefreshMakeInfoRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEGET_REQ == selector)
        {
            {
                ret = this.stResourceGetReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEGET_RSP == selector)
        {
            {
                ret = this.stResourceGetRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEBUY_REQ == selector)
        {
            {
                ret = this.stResourceBuyReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEBUY_RSP == selector)
        {
            {
                ret = this.stResourceBuyRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPSELL_REQ == selector)
        {
            {
                ret = this.stEquipSellReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPSELL_RSP == selector)
        {
            {
                ret = this.stEquipSellRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_GOODUSE_REQ == selector)
        {
            {
                ret = this.stGoodUSEReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_GOODUSE_RSP == selector)
        {
            {
                ret = this.stGoodUSERsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_ROLE_RSP == selector)
        {
            {
                ret = this.stUpdateObjRoleRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_MAPBUILDING_RSP == selector)
        {
            {
                ret = this.stUpdateObjMapBuildingRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_EQUIPMAKE_RSP == selector)
        {
            {
                ret = this.stUpdateObjEquipMakeRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_RESOURCE_RSP == selector)
        {
            {
                ret = this.stUpdateObjResourceRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_BACKPACK_RSP == selector)
        {
            {
                ret = this.stUpdateObjBackpackRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_EQUIPMAKEINFO_RSP == selector)
        {
            {
                ret = this.stUpdateObjEquipMakeInfoRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_HEROINFO_RSP == selector)
        {
            {
                ret = this.stUpdateObjHeroInfoRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_TROOPSINFO_RSP == selector)
        {
            {
                ret = this.stUpdateObjTroopsInfoRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEGAMEOBJE_RSP == selector)
        {
            {
                ret = this.stUpdateGameObjeRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_REFRESHVIT_REQ == selector)
        {
            {
                ret = this.stHeroRefreshVITReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_REFRESHHP_REQ == selector)
        {
            {
                ret = this.stHeroRefreshHpReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_STARUPLEVEL_REQ == selector)
        {
            {
                ret = this.stHeroStarUpLevelReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_STARUPLEVEL_RSP == selector)
        {
            {
                ret = this.stHeroStarUpLevelRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTON_REQ == selector)
        {
            {
                ret = this.stEquipPutOnReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTON_RSP == selector)
        {
            {
                ret = this.stEquipPutOnRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTOFF_REQ == selector)
        {
            {
                ret = this.stEquipPutOffReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTOFF_RSP == selector)
        {
            {
                ret = this.stEquipPutOffRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCH_REQ == selector)
        {
            {
                ret = this.stEquipSwitchReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCH_RSP == selector)
        {
            {
                ret = this.stEquipSwitchRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCHALL_REQ == selector)
        {
            {
                ret = this.stEquipSwitchAllReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCHALL_RSP == selector)
        {
            {
                ret = this.stEquipSwitchAllRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_NEW_LIST_REQ == selector)
        {
            {
                ret = this.stDemandNewListReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_NEW_LIST_RSP == selector)
        {
            {
                ret = this.stDemandNewListRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_SUBMIT_REQ == selector)
        {
            {
                ret = this.stDemandSubmitReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_SUBMIT_RSP == selector)
        {
            {
                ret = this.stDemandSubmitRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_EDIT_REQ == selector)
        {
            {
                ret = this.stTroopsEditReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_EDIT_RSP == selector)
        {
            {
                ret = this.stTroopsEditRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_RENAME_REQ == selector)
        {
            {
                ret = this.stTroopsRenameReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_RENAME_RSP == selector)
        {
            {
                ret = this.stTroopsRenameRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_CHALLENGE_REQ == selector)
        {
            {
                ret = this.stDungeonsChallengeReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_CHALLENGE_RSP == selector)
        {
            {
                ret = this.stDungeonsChallengeRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROL_REQ == selector)
        {
            {
                ret = this.stDungeonsPatrolReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROL_RSP == selector)
        {
            {
                ret = this.stDungeonsPatrolRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROLCOMPLETE_REQ == selector)
        {
            {
                ret = this.stDungeonsPatrolCompleteRep.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROLCOMPLETE_RSP == selector)
        {
            {
                ret = this.stDungeonsPatrolCompleteRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_GETBOX_REQ == selector)
        {
            {
                ret = this.stDungeonsGetBoxReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_GETBOX_RSP == selector)
        {
            {
                ret = this.stDungeonsGetBoxRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_INFO_REQ == selector)
        {
            {
                ret = this.stHeroRecruitInfoReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_INFO_RSP == selector)
        {
            {
                ret = this.stHeroRecruitInfoRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_REQ == selector)
        {
            {
                ret = this.stHeroRecruitReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_RSP == selector)
        {
            {
                ret = this.stHeroRecruitRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_LIST_REQ == selector)
        {
            {
                ret = this.stHeroRecruitListReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_LIST_RSP == selector)
        {
            {
                ret = this.stHeroRecruitListRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_GM_REQ == selector)
        {
            {
                ret = this.stGMReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_GM_RSP == selector)
        {
            {
                ret = this.stGMRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_REFRESH_REQ == selector)
        {
            {
                ret = this.stOrderRefreshReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_REFRESH_RSP == selector)
        {
            {
                ret = this.stOrderRefreshRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_SUBMIT_REQ == selector)
        {
            {
                ret = this.stOrderSubmitReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_SUBMIT_RSP == selector)
        {
            {
                ret = this.stOrderSubmitRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_GET_NEW_REQ == selector)
        {
            {
                ret = this.stOrderGetNewReq.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_GET_NEW_RSP == selector)
        {
            {
                ret = this.stOrderGetNewRsp.pack(dstBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        
        return ret;
    }

    public DrError.ErrorType unpack(int selector, byte[] buffer, int size, ref int usedSize, uint cutVer = 0)
    {
        DrReadBuf srcBuf = new DrReadBuf(buffer, size);

        DrError.ErrorType ret = unpack(selector, srcBuf, cutVer);

        usedSize = srcBuf.GetUsedSize();

        return ret;
    }

    public DrError.ErrorType unpack(int selector, DrReadBuf srcBuf, uint cutVer = 0)
    {
        DrError.ErrorType ret = DrError.ErrorType.DR_NO_ERROR;

        if (0 == cutVer || (uint)CSMsgBody.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSMsgBody.VERSION.CURRVERSION;
        }

        if ((int)CSMSGID.CS_MSGID_LOGIN_REQ == selector)
        {
            {
                ret = this.stLoginReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGIN_RSP == selector)
        {
            {
                ret = this.stLoginRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CREATE_REQ == selector)
        {
            {
                ret = this.stCreateReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CREATE_RSP == selector)
        {
            {
                ret = this.stCreateRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_NOTIFY_RSP == selector)
        {
            {
                ret = this.stNotifyRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RPC_NOTIFY_RSP == selector)
        {
            {
                ret = this.stRpcNotifyRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_AUTORESPONSEPACKET_RSP == selector)
        {
            {
                ret = this.stAutoResponsePacketRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINACTOR_RSP == selector)
        {
            {
                ret = this.stLoginActorRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINMAPBUILDMGR_RSP == selector)
        {
            {
                ret = this.stLoginMapBuildMgrRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINBUILDINGMAKEINFOMGR_RSP == selector)
        {
            {
                ret = this.stLoginBuildingMakeInfoMgrRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINBACKPACKETMGR_RSP == selector)
        {
            {
                ret = this.stLoginBackpacketMgrRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINEQUIPMAKEINFOMGR_RSP == selector)
        {
            {
                ret = this.stLoginEquipMakeinfoMgrRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINENTERGAME_RSP == selector)
        {
            {
                ret = this.stLoginEnterGameRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINHEROMGR_RSP == selector)
        {
            {
                ret = this.stLoginHeroMgrRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINTROOPSMGR_RSP == selector)
        {
            {
                ret = this.stLoginTroopsMgrRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINORDERLIST_RSP == selector)
        {
            {
                ret = this.stLoginOrderListRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_LOGINDEMANDLIST_RSP == selector)
        {
            {
                ret = this.stLoginDemandListRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGBUILD_REQ == selector)
        {
            {
                ret = this.stBuildingBuildReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGBUILD_RSP == selector)
        {
            {
                ret = this.stBuildingBuildRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGRECYCLE_REQ == selector)
        {
            {
                ret = this.stBuildingRecycleReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGRECYCLE_RSP == selector)
        {
            {
                ret = this.stBuildingRecycleRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGMOVE_REQ == selector)
        {
            {
                ret = this.stBuildingMoveReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGMOVE_RSP == selector)
        {
            {
                ret = this.stBuildingMoveRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVEL_REQ == selector)
        {
            {
                ret = this.stBuildingUpLevelReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVEL_RSP == selector)
        {
            {
                ret = this.stBuildingUpLevelRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMUPLEVEL_REQ == selector)
        {
            {
                ret = this.stImUpLevelReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMUPLEVEL_RSP == selector)
        {
            {
                ret = this.stImUpLevelRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELUPLEVEL_REQ == selector)
        {
            {
                ret = this.stCancelUpLevelReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELUPLEVEL_RSP == selector)
        {
            {
                ret = this.stCancelUpLevelRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVELCOMPLETE_REQ == selector)
        {
            {
                ret = this.stBuildingUpLevelCompleteReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_BUILDINGUPLEVELCOMPLETE_RSP == selector)
        {
            {
                ret = this.stBuildingUpLevelCompleteRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPMAKE_REQ == selector)
        {
            {
                ret = this.stEquipMakeReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPMAKE_RSP == selector)
        {
            {
                ret = this.stEquipMakeRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMMAKE_REQ == selector)
        {
            {
                ret = this.stImMakeReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_IMMAKE_RSP == selector)
        {
            {
                ret = this.stImMakeRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELMAKE_REQ == selector)
        {
            {
                ret = this.stCancelMakeReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_CANCELMAKE_RSP == selector)
        {
            {
                ret = this.stCancelMakeRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPGETCOMPLETE_REQ == selector)
        {
            {
                ret = this.stEquipGetCompleteReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPGETCOMPLETE_RSP == selector)
        {
            {
                ret = this.stEquipGetCompleteRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_UPDATABUILDING_RSP == selector)
        {
            {
                ret = this.stUpDataBuildingRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_REFRESH_MAKEINFO_REQ == selector)
        {
            {
                ret = this.stRefreshMakeInfoReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_REFRESH_MAKEINFO_RSP == selector)
        {
            {
                ret = this.stRefreshMakeInfoRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEGET_REQ == selector)
        {
            {
                ret = this.stResourceGetReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEGET_RSP == selector)
        {
            {
                ret = this.stResourceGetRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEBUY_REQ == selector)
        {
            {
                ret = this.stResourceBuyReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_RESOURCEBUY_RSP == selector)
        {
            {
                ret = this.stResourceBuyRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPSELL_REQ == selector)
        {
            {
                ret = this.stEquipSellReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIPSELL_RSP == selector)
        {
            {
                ret = this.stEquipSellRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_GOODUSE_REQ == selector)
        {
            {
                ret = this.stGoodUSEReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_GOODUSE_RSP == selector)
        {
            {
                ret = this.stGoodUSERsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_ROLE_RSP == selector)
        {
            {
                ret = this.stUpdateObjRoleRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_MAPBUILDING_RSP == selector)
        {
            {
                ret = this.stUpdateObjMapBuildingRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_EQUIPMAKE_RSP == selector)
        {
            {
                ret = this.stUpdateObjEquipMakeRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_RESOURCE_RSP == selector)
        {
            {
                ret = this.stUpdateObjResourceRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_BACKPACK_RSP == selector)
        {
            {
                ret = this.stUpdateObjBackpackRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_EQUIPMAKEINFO_RSP == selector)
        {
            {
                ret = this.stUpdateObjEquipMakeInfoRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_HEROINFO_RSP == selector)
        {
            {
                ret = this.stUpdateObjHeroInfoRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEOBJ_TROOPSINFO_RSP == selector)
        {
            {
                ret = this.stUpdateObjTroopsInfoRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_UPDATEGAMEOBJE_RSP == selector)
        {
            {
                ret = this.stUpdateGameObjeRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_REFRESHVIT_REQ == selector)
        {
            {
                ret = this.stHeroRefreshVITReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_REFRESHHP_REQ == selector)
        {
            {
                ret = this.stHeroRefreshHpReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_STARUPLEVEL_REQ == selector)
        {
            {
                ret = this.stHeroStarUpLevelReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_HERO_STARUPLEVEL_RSP == selector)
        {
            {
                ret = this.stHeroStarUpLevelRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTON_REQ == selector)
        {
            {
                ret = this.stEquipPutOnReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTON_RSP == selector)
        {
            {
                ret = this.stEquipPutOnRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTOFF_REQ == selector)
        {
            {
                ret = this.stEquipPutOffReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_PUTOFF_RSP == selector)
        {
            {
                ret = this.stEquipPutOffRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCH_REQ == selector)
        {
            {
                ret = this.stEquipSwitchReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCH_RSP == selector)
        {
            {
                ret = this.stEquipSwitchRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCHALL_REQ == selector)
        {
            {
                ret = this.stEquipSwitchAllReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_EQUIP_SWITCHALL_RSP == selector)
        {
            {
                ret = this.stEquipSwitchAllRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_NEW_LIST_REQ == selector)
        {
            {
                ret = this.stDemandNewListReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_NEW_LIST_RSP == selector)
        {
            {
                ret = this.stDemandNewListRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_SUBMIT_REQ == selector)
        {
            {
                ret = this.stDemandSubmitReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DEMAND_SUBMIT_RSP == selector)
        {
            {
                ret = this.stDemandSubmitRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_EDIT_REQ == selector)
        {
            {
                ret = this.stTroopsEditReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_EDIT_RSP == selector)
        {
            {
                ret = this.stTroopsEditRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_RENAME_REQ == selector)
        {
            {
                ret = this.stTroopsRenameReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_TROOPS_RENAME_RSP == selector)
        {
            {
                ret = this.stTroopsRenameRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_CHALLENGE_REQ == selector)
        {
            {
                ret = this.stDungeonsChallengeReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_CHALLENGE_RSP == selector)
        {
            {
                ret = this.stDungeonsChallengeRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROL_REQ == selector)
        {
            {
                ret = this.stDungeonsPatrolReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROL_RSP == selector)
        {
            {
                ret = this.stDungeonsPatrolRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROLCOMPLETE_REQ == selector)
        {
            {
                ret = this.stDungeonsPatrolCompleteRep.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_PATROLCOMPLETE_RSP == selector)
        {
            {
                ret = this.stDungeonsPatrolCompleteRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_GETBOX_REQ == selector)
        {
            {
                ret = this.stDungeonsGetBoxReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_MSGID_DUNGEONS_GETBOX_RSP == selector)
        {
            {
                ret = this.stDungeonsGetBoxRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_INFO_REQ == selector)
        {
            {
                ret = this.stHeroRecruitInfoReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_INFO_RSP == selector)
        {
            {
                ret = this.stHeroRecruitInfoRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_REQ == selector)
        {
            {
                ret = this.stHeroRecruitReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_RSP == selector)
        {
            {
                ret = this.stHeroRecruitRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_LIST_REQ == selector)
        {
            {
                ret = this.stHeroRecruitListReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_HERO_RECRUIT_LIST_RSP == selector)
        {
            {
                ret = this.stHeroRecruitListRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_GM_REQ == selector)
        {
            {
                ret = this.stGMReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_GM_RSP == selector)
        {
            {
                ret = this.stGMRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_REFRESH_REQ == selector)
        {
            {
                ret = this.stOrderRefreshReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_REFRESH_RSP == selector)
        {
            {
                ret = this.stOrderRefreshRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_SUBMIT_REQ == selector)
        {
            {
                ret = this.stOrderSubmitReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_SUBMIT_RSP == selector)
        {
            {
                ret = this.stOrderSubmitRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_GET_NEW_REQ == selector)
        {
            {
                ret = this.stOrderGetNewReq.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        else if ((int)CSMSGID.CS_ORDER_GET_NEW_RSP == selector)
        {
            {
                ret = this.stOrderGetNewRsp.unpack(srcBuf, cutVer);
                if (DrError.ErrorType.DR_NO_ERROR != ret)
                {
                    return ret;
                }
            }
        }
        return ret;
    }

};

public class CSMsg
{

    public CSMsgHead stHead = new CSMsgHead();
    public CSMsgBody stBody = new CSMsgBody();

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

        if (0 == cutVer || (uint)CSMsg.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSMsg.VERSION.CURRVERSION;
        }

        {
            ret = this.stHead.pack(dstBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stBody.pack(this.stHead.unMsgID,  dstBuf, cutVer);
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

        if (0 == cutVer || (uint)CSMsg.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)CSMsg.VERSION.CURRVERSION;
        }

        {
            ret = this.stHead.unpack(srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = this.stBody.unpack(this.stHead.unMsgID,  srcBuf, cutVer);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

}

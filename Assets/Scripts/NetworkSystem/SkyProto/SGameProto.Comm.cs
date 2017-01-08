using System;
using System.Collections;
using System.Collections.Generic;
namespace SkyWarProto {

public enum ENUMGAME
{
    DEV_PROTO_VER = 151,
    MAX_TOKEN_LEN = 1024,
    MAX_MAPBUILDING_LEN = 100,
    MAX_MAKELENGTH_LEN = 5,
    MAX_GOODCOUNT_LEN = 400,
    MAX_BACKPACKET_LEN = 2,
    MAX_EQUIPCOUNT_LEN = 400,
    MAX_NAME_LEN = 128,
    MAX_MONEYTYPE_LEN = 30,
    MAX_UPDATEOBJCOUNT_LEN = 30,
    MAX_PROUPDATE_LEN = 50,
    MAX_HEROLIST_LEN = 100,
    MAX_TROOPS_LEN = 20,
    MAX_TROOPSPLAYER_LEN = 6,
    MAX_RECRUIT_INFO_LEN = 10,
    MAX_HERO_RECRUIT_LIST_LEN = 10,
    MAX_EQUIPGROOVE_LEN = 10,
    ACTOR_REFRESH_BASE = 10,
    ACTOR_REFRESH_LEN = 48,
    ACTOR_REFRESH_TIME_UINT = 1,
    ACTOR_REFRESH_CDTIME_UINT = 1,
    RATEDROP_HERO_MIN = 1,
    RATEDROP_HERO_MAX = 999,
    RATEDROP_ITEM_MIN = 10000,
    RATEDROP_ITEM_MAX = 99999,
    RATEDROP_EQUIPMENT_MIN = 100000,
    RATEDROP_EQUIPMENT_MAX = 9999999,
    RATEDROP_SELF_MIN = 10000000,
    RATEDROP_SELF_MAX = 99999999,
    MAX_REWARDGOOD_LEN = 30,
    MAX_GMCMDREQ_LEN = 128,
    MAX_GMCMDRSP_LEN = 2048,
    MAX_ORDER_LIST_LEN = 12,
    MAX_ORDER_REWARD_LEN = 2,
    MAX_ORDER_DEMAND_LEN = 12,
    MAX_HERO_DEMAND_LEN = 12,
    MAX_HERO_DEMAND_RATE_LEN = 6,
    MAX_HERO_DEMAND_REWARD_LEN = 2,
    EQUIP_INIT_QUALITY = 1,
    MAX_UPDATEGAMEOBJ_LEN = 50,
    MAX_BATTROOPS_LEN = 2,
    MAX_BATROLE_LEN = 2,
    MAX_BATROLEBATHERO_LEN = 6,
    MAX_BATHERO_LEN = 24,
    MAX_BATPROSYSTEM_LEN = 8,
    MAX_BATPROTYPE_LEN = 11,
    MAX_BATBUFFER_LEN = 8,
    MAX_BATBUFFERCONTINUE_LEN = 8,
    MAX_BATLOCATION_LEN = 24,
    MAX_BUFFEFFECTPAR_LEN = 1,
    MAX_BATLOG_LEN = 2000,
    MAX_BATLOG_Round_LEN = 20,
    MAX_BATLOG_BuffPassivity_LEN = 4,
    MAX_BATLOG_BuffTigger_LEN = 400,
    MAX_BATLOG_BuffAffected_LEN = 24,
    MAX_BATLOG_BuffRemove_LEN = 400,
    MAX_BATLOG_HeroProEdit_LEN = 600,
    MAX_SHOWSIZE_LEN = 50,
};

public enum ENUMGAMEOBJTYPE
{
    EGAMEOBJTYPE_NULL = 0,
    EGAMEOBJTYPE_ROLE = 1,
    EGAMEOBJTYPE_MAPBUILDING = 2,
    EGAMEOBJTYPE_EQUIPMAKEINFO = 3,
    EGAMEOBJTYPE_BUILDINGMAKE = 4,
    EGAMEOBJTYPE_BACKPACKEQUIP = 5,
    EGAMEOBJTYPE_HEROINFO = 6,
    EGAMEOBJTYPE_TROOPSINFO = 7,
    EGAMEOBJTYPE_HEROEQUIPINFO = 8,
    EGAMEOBJTYPE_RESOURCE = 9,
    EGAMEOBJTYPE_DUNGECONS = 11,
    EGAMEOBJTYPE_ORDERLIST = 12,
    EGAMEOBJTYPE_ASKBUY = 13,
};

public enum ENUMTROOPSSTATE
{
    ETROOPSSTA_FREE = 0,
    EMONEYTYPE_CHALLENGE = 1,
    EMONEYTYPE_PATROL = 2,
    EMONEYTYPE_PATROLCOMPLETE = 3,
};

public enum ENUMMONEYTYPE
{
    EMONEYTYPE_COIN = 0,
    EMONEYTYPE_CRYSTALS = 1,
    EMONEYTYPE_IRON = 2,
    EMONEYTYPE_OIL = 3,
    EMONEYTYPE_ALUFER = 4,
    EMONEYTYPE_LEATHER = 5,
    EMONEYTYPE_ANTIMATTER = 6,
    EMONEYTYPE_GEMS = 20,
    EMONEYTYPE_MAX = 30,
};

public enum ENUMGOODTYPE
{
    EGOODTYPE_RES = 1,
    EGOODTYPE_EQUIP = 2,
};

public enum ENUMSLOT
{
    ESLOT_CAP = 0,
    ESLOT_CLOTHES = 1,
    ESLOT_PANTS = 2,
    ESLOT_SHOE = 3,
    ESLOT_EARRINGS_0 = 4,
    ESLOT_NECKLACE = 5,
    ESLOT_BRACELET_0 = 6,
    ESLOT_WEAPON_0 = 7,
};

public enum ENUMREWARDGOODTEAMTYPE
{
    EREWARDGTT_RESOURCE = 0,
    EREWARDGTT_HERO = 1,
    EREWARDGTT_EQUIP = 2,
    EREWARDGTT_GOOD = 3,
    EREWARDGTT_List = 9,
    EREWARDGTT_MAX = 10,
};

public enum ENUMITEMSUBTYPE
{
    EITEMSUBTYPE_box = 0,
    EITEMSUBTYPE_blood = 1,
    EITEMSUBTYPE_exp = 2,
};

public enum ENUMPROPERTY
{
    EPRO_SYSTEM_MIN = 0,
    EPRO_SYSTEM_CURSERVERTIME = 1,
    EPRO_SYSTEM_MAX = 1000,
    EPRO_ROLE_MIN = 1001,
    EPRO_ROLE_UID = 1002,
    EPRO_ROLE_NAME = 1003,
    EPRO_ROLE_MAPLEVEL = 1004,
    EPRO_ROLE_COMPLETEGATEID = 1005,
    EPRO_ROLE_EXP = 1006,
    EPRO_ROLE_LEVEL = 1007,
    EPRO_ROLE_MAX = 2000,
    EPRO_MAPBLD_MIN = 2001,
    EPRO_MAPBLD_UID = 2011,
    EPRO_MAPBLD_LEVEL = 2012,
    EPRO_MAPBLD_Recycle = 2013,
    EPRO_MAPBLD_X = 2014,
    EPRO_MAPBLD_Y = 2015,
    EPRO_MAPBLD_TimeUpdateStart = 2016,
    EPRO_MAPBLD_MAX = 3000,
    EPRO_EQUIPMAKEINFO_MIN = 3001,
    EPRO_EQUIPMAKEINFO_CfgIDEquip = 3011,
    EPRO_EQUIPMAKEINFO_Exp = 3012,
    EPRO_EQUIPMAKEINFO_Quality = 3013,
    EPRO_EQUIPMAKEINFO_TimeLastMake = 3014,
    EPRO_EQUIPMAKEINFO_MAX = 4000,
    EPRO_EQUIPMAKE_MIN = 4001,
    EPRO_EQUIPMAKE_ResourceCount = 4011,
    EPRO_EQUIPMAKE_TimeMakeStart = 4012,
    EPRO_EQUIPMAKE_LevelUnlockGrid = 4013,
    EPRO_EQUIPMAKE_MAX = 5000,
    EPRO_BACKPACK_MIN = 5001,
    EPRO_BACKPACK_UidGood = 5011,
    EPRO_BACKPACK_CfgID = 5012,
    EPRO_BACKPACK_Count = 5013,
    EPRO_BACKPACK_SubjoinPro = 5014,
    EPRO_BACKPACK_RefCount = 5015,
    EPRO_BACKPACK_MAX = 6000,
    EPRO_HERO_MIN = 6001,
    EPRO_HERO_UID = 6002,
    EPRO_HERO_CONFIGID = 6003,
    EPRO_HERO_LEVEL = 6004,
    EPRO_HERO_STARLEVEL = 6005,
    EPRO_HERO_HP = 6006,
    EPRO_HERO_TimeLastRefreshHP = 6007,
    EPRO_HERO_VIT = 6008,
    EPRO_HERO_TimeLastRefreshVIT = 6009,
    EPRO_HERO_Exp = 6010,
    EPRO_HERO_MAX = 7000,
    EPRO_TROOPS_MIN = 7001,
    EPRO_TROOPS_UID = 7002,
    EPRO_TROOPS_NAME = 7003,
    EPRO_TROOPS_ESTATE = 7004,
    EPRO_TROOPS_TIMESTART = 7005,
    EPRO_TROOPS_GATEID = 7006,
    EPRO_TROOPS_MAX = 8000,
    EPRO_HEROEQUIP_MIN = 8001,
    EPRO_HEROEQUIP_MAX = 9000,
    EPRO_ROLE_MONEY_MIN = 9001,
    EPRO_ROLE_MONEY_CONIN = 10000,
    EPRO_ROLE_MONEY_CRYSTALS = 10001,
    EPRO_ROLE_MONEY_IRON = 10002,
    EPRO_ROLE_MONEY_OIL = 10003,
    EPRO_ROLE_MONEY_ALUFER = 10004,
    EPRO_ROLE_MONEY_LEATHER = 10005,
    EPRO_ROLE_MONEY_ANTIMATTER = 10006,
    EPRO_ROLE_MONEY_GEMS = 10020,
    EPRO_ROLE_HERO_EXP = 10028,
    EPRO_ROLE_ROLE_EXP = 10029,
    EPRO_ROLE_MONEY_MAX = 11000,
    EPRO_DUNGEONS_MIN = 11001,
    EPRO_DUNGEONS_MAX = 12000,
    EPRO_ORDERLIST_MIN = 12001,
    EPRO_ORDERLIST_MAX = 13000,
    EPRO_ASKBUY_MIN = 13001,
    EPRO_ASKBUY_MAX = 14000,
};

public enum ENUMHERORECRUITTYPE
{
    HERO_RECRUIT_BY_GOLD = 1,
    HERO_RECRUIT_BY_DIAMOND = 2,
    HERO_RECRUIT_BY_DIAMOND_HALF = 3,
    HERO_RECRUIT_BY_DIAMOND_FREE = 4,
};

public enum ENUMACTORREFRESHTYPE
{
    ACTOR_REFRESH_BY_DAY = 1,
    ACTOR_REFRESH_BY_WEEK = 2,
    ACTOR_REFRESH_BY_MONTH = 3,
    ACTOR_REFRESH_BY_LAST = 4,
    ACTOR_REFRESH_BY_HOUR = 5,
    ACTOR_REFRESH_BY_USE = 6,
};

public enum ENUMACTORREFRESH
{
    GOLD_HERO_RECRUIT = 10,
    DIAMOND_FREE_HERO_RECRUIT = 20,
    DIAMOND_HALF_HERO_RECRUIT = 30,
    ORDER_NEWORDER_REFRESH = 70,
    ORDER_REFRESH = 71,
    ORDER_SUBMIT_REFRESH = 72,
    DEMAND_REFRESH = 80,
};

public enum ENUMPROSYSTEM
{
    EPROSYSTEM_BASELEVEL = 0,
    EPROSYSTEM_HEROTYPE = 1,
    EPROSYSTEM_HEROQUALITY = 2,
    EPROSYSTEM_WAKEUP = 3,
    EPROSYSTEM_COMBINE = 4,
    EPROSYSTEM_EQUIP = 5,
    EPROSYSTEM_EQUIPSUIT = 6,
    EPROSYSTEM_SKILL = 7,
    EPROSYSTEM_MAX = 8,
};

public enum ENUMPROTYPE
{
    EPROTYPE_HP = 0,
    EPROTYPE_ATTACK = 1,
    EPROTYPE_SKILLATTACK = 2,
    EPROTYPE_PHYSICSDEFENSE = 3,
    EPROTYPE_SKILLDEFENSE = 4,
    EPROTYPE_CRITICAL = 5,
    EPROTYPE_HIT = 6,
    EPROTYPE_DODGE = 7,
    EPROTYPE_SPEED = 8,
    EPROTYPE_VIT = 9,
    EPROTYPE_POWER = 10,
    EPROTYPE_MAX = 11,
};

public enum ENUMBATTYPE
{
    EBATTYPE_DUNGEON_PVE = 1,
    EBATTYPE_ARENA_1V1 = 2,
    EBATTYPE_ARENA_2V2 = 3,
    EBATTYPE_MAP_PVE = 4,
    EBATTYPE_MAP_PVP_1V1 = 5,
    EBATTYPE_MAP_PVP_2v2 = 6,
};

public enum ENUMBATCAMP
{
    EBATCAMP_A = 0,
    EBATCAMP_B = 1,
};

public enum ENUMBATENDSTA
{
    EBATENDSTA_PROCESS = 1,
    EBATENDSTA_End = 2,
};

public enum ENUMBATHEROSTA
{
    EBATHEROSTA_EXIST = 1,
    EBATHEROSTA_ACTION = 2,
    EBATHEROSTA_DISARM = 4,
    EBATHEROSTA_SILENCE = 8,
    EBATHEROSTA_DISORDER = 16,
};

public enum ENUMBATAISTA
{
    EBATAISTA_WaitAction = 1,
    EBATAISTA_SelSkill = 2,
    EBATAISTA_SelObject = 3,
    EBATAISTA_UseSkill = 4,
};

public enum ENUMBATIDENTITY
{
    EBATIDENTITY_ROLE = 0,
    EBATIDENTITY_ROBOT = 1,
};

public enum ENUMBATOPERATION
{
    EBATOPERATION_HAND = 0,
    EBATOPERATION_AUTO = 1,
    EBATOPERATION_AI = 2,
};

public enum ENUMBATLOGTYPE
{
    EBATLOGTYPE_ROUND = 0,
    EBATLOGTYPE_BuffTigger = 1,
    EBATLOGTYPE_BuffRemove = 2,
    EBATLOGTYPE_HeroProEdit = 3,
    EBATLOGTYPE_CampProEdit = 4,
    EBATLOGTYPE_HeroAction = 5,
};

public enum ENUMBUFFUSETYPE
{
    EBUFFUSETYPE_ACTIVE = 0,
    EBUFFUSETYPE_PASSIVE = 1,
};

public enum ENUMBUFFCONDITION
{
    EBUFFCONDITION_Null = 1,
    EBUFFCONDITION_ATTACK = 2,
    EBUFFCONDITION_SKILLATTACK = 3,
    EBUFFCONDITION_BEATTACKED = 4,
    EBUFFCONDITION_BESKILLATTACKED = 5,
    EBUFFCONDITION_CRITICAL = 6,
    EBUFFCONDITION_DODGE = 7,
    EBUFFCONDITION_HPPERLOW = 8,
    EBUFFCONDITION_HPLOW = 9,
    EBUFFCONDITION_StartAction = 10,
    EBUFFCONDITION_BEHURT = 11,
    EBUFFCONDITION_EveryRound = 12,
    EBUFFCONDITION_StartActionBegin = 13,
    EBUFFCONDITION_SelObjBegin = 14,
};

public enum ENUMTARGETTYPE
{
    ETARGETTYPE_FIREND = 1,
    ETARGETTYPE_FIRENDEXCLUDESELF = 2,
    ETARGETTYPE_FIRENDFRONT = 3,
    ETARGETTYPE_FIRENDBACK = 4,
    ETARGETTYPE_FIRENDAll = 5,
    ETARGETTYPE_NEAR = 7,
    ETARGETTYPE_ENEMY = 8,
    ETARGETTYPE_ENEMYFRONT = 9,
    ETARGETTYPE_ENEMYBACK = 10,
    ETARGETTYPE_ENEMYAll = 11,
    ETARGETTYPE_SELF = 13,
    ETARGETTYPE_BUFFTIRGET = 14,
    ETARGETTYPE_FATHERBUFFCARRY = 15,
};

public enum ENUMEFFECTTYPE
{
    EEFFECTTYPE_PRO = 1,
    EEFFECTTYPE_ADDBUFF = 2,
    EEFFECTTYPE_DISARM = 3,
    EEFFECTTYPE_SILENCE = 4,
    EEFFECTTYPE_DIZZINESS = 5,
    EEFFECTTYPE_DISORDER = 6,
    EEFFECTTYPE_perShield = 7,
    EEFFECTTYPE_Shield = 8,
    EEFFECTTYPE_AttPer = 9,
    EEFFECTTYPE_reboundhurt = 10,
};

public enum ENUMPROCIRCULATION_TYPE
{
    ENUMPROCIRCULATION_TYPE_CurVal = 0,
    ENUMPROCIRCULATION_TYPE_CurPer = 1,
    ENUMPROCIRCULATION_TYPE_MaxVal = 2,
    ENUMPROCIRCULATION_TYPE_MaxPer = 3,
};

public enum ENUMEFFECT_PROSUBTYPE
{
    ENUMEFFECT_PROSUBTYPE_ProBegin = 1,
    ENUMEFFECT_PROSUBTYPE_ProEnd = 44,
};

public enum ENUMRPCNOTIFY
{
    ENUM_RPCNOTIFY_SPACESHIP_UPLEVEL = 1,
};

public enum ENUMDEMANDSUBMITTYPE
{
    ENUM_DEMAND_SUBMIT_NORMAL = 1,
    ENUM_DEMAND_SUBMIT_REFUSE = 2,
};

public class Object
{

    public int iID = 0;
    public int iLevel = 0;
    public int iPosX = 0;
    public int iPosY = 0;
    public int iUpgradeTime = 0;

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

        if (0 == cutVer || (uint)Object.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)Object.VERSION.CURRVERSION;
        }

        {
            ret = dstBuf.WriteInt32(this.iID);
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
            ret = dstBuf.WriteInt32(this.iPosX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iPosY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = dstBuf.WriteInt32(this.iUpgradeTime);
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

        if (0 == cutVer || (uint)Object.VERSION.CURRVERSION < cutVer)
        {
            cutVer = (uint)Object.VERSION.CURRVERSION;
        }

        {
            ret = srcBuf.ReadInt32(ref this.iID);
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
            ret = srcBuf.ReadInt32(ref this.iPosX);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iPosY);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        {
            ret = srcBuf.ReadInt32(ref this.iUpgradeTime);
            if (DrError.ErrorType.DR_NO_ERROR != ret)
            {
                return ret;
            }
        }

        return ret;
    }

};

}

﻿using System.Runtime.Serialization;

namespace IqOptionApiDotNet.Models
{
    public enum ActivePair : int
    {
        ALL = 0,
        EURRUB = 9,
        COMMBK = 13,
        DAIM = 14,
        DBFRA = 15,
        EOAN = 16,
        BPLON = 23,
        GAZPROM = 27,
        ROSNEFT = 28,
        SBERS = 29,
        YAHOO = 40,
        AIG = 41,
        BOA = 42,
        VERIZON = 56,
        WMART = 57,
        DAX30 = 66,
        DJIA = 67,
        FTSE = 68,
        NSDQ = 69,
        NK = 70,
        SP = 71,
        BTCX = 73,

        [EnumMember(Value = "EURUSD-OTC")] EURUSD_OTC = 76,
        [EnumMember(Value = "EURGBP-OTC")] EURGBP_OTC = 77,
        [EnumMember(Value = "USDCHF-OTC")] USDCHF_OTC = 78,
        [EnumMember(Value = "EURJPY-OTC")] EURJPY_OTC = 79,
        [EnumMember(Value = "NZDUSD-OTC")] NZDUSD_OTC = 80,
        [EnumMember(Value = "GBPUSD-OTC")] GBPUSD_OTC = 81,
        [EnumMember(Value = "EURRUB-OTC")] EURRUB_OTC = 82,
        [EnumMember(Value = "USDRUB-OTC")] USDRUB_OTC = 83,
        [EnumMember(Value = "GBPJPY-OTC")] GBPJPY_OTC = 84,
        [EnumMember(Value = "USDJPY-OTC")] USDJPY_OTC = 85,
        [EnumMember(Value = "AUDCAD-OTC")] AUDCAD_OTC = 86,

        YANDEX = 95,

        PAN = 97,


        [EnumMember(Value = "GBPCHF")] GBPCHF = 103,
        [EnumMember(Value = "GBPAUD")] GBPAUD = 104,

        BMW = 110,
        LUFTHANSA = 111,

        SMI_INDEX = 166,
        SSE_INDEX = 169,
        HANG_SENG = 170,

        SPASX200 = 208,
        TOPIX500 = 209,
        DX = 210,

        SIN_FAKE = 213,

        BRENT_OIL_JUL_16 = 215,

        NTDOY = 218,
        USDTRY = 220,

        #region [Crypto]

        [EnumMember(Value = "BTCUSD")] BTCUSD = 816,
        [EnumMember(Value = "XRPUSD")] XRPUSD = 817,
        [EnumMember(Value = "ETHUSD")] ETHUSD = 818,
        [EnumMember(Value = "LTCUSD")] LTCUSD = 819,
        [EnumMember(Value = "DSHUSD")] DSHUSD = 821,
        [EnumMember(Value = "BCHUSD")] BCHUSD = 824,
        [EnumMember(Value = "OMGUSD")] OMGUSD = 825,
        [EnumMember(Value = "ZECUSD")] ZECUSD = 826,
        [EnumMember(Value = "ETCUSD")] ETCUSD = 829,
        [EnumMember(Value = "BTCUSD-L")] BTCUSD_L = 830,
        [EnumMember(Value = "ETHUSD-L")] ETHUSD_L = 831,
        [EnumMember(Value = "LTCUSD-L")] LTCUSD_L = 834,
        [EnumMember(Value = "BCHUSD-L")] BCHUSD_L = 836,
        [EnumMember(Value = "QTMUSD")] QTMUSD = 845,
        [EnumMember(Value = "XLMUSD")] XLMUSD = 847,
        [EnumMember(Value = "TRXUSD")] TRXUSD = 858,
        [EnumMember(Value = "EOSUSD")] EOSUSD = 864,
        [EnumMember(Value = "IOTUSD-L")] IOTUSD_L = 1116,
        [EnumMember(Value = "XLMUSD-L")] XLMUSD_L = 1117,
        [EnumMember(Value = "NEOUSD-L")] NEOUSD_L = 1118,
        [EnumMember(Value = "ADAUSD-L")] ADAUSD_L = 1119,
        [EnumMember(Value = "XEMUSD-L")] XEMUSD_L = 1120,
        [EnumMember(Value = "TRXUSD-L")] TRXUSD_L = 1242,
        [EnumMember(Value = "EOSUSD-L")] EOSUSD_L = 1244,

        #endregion

        #region [Forex]

        [EnumMember(Value = "EURUSD")] EURUSD = 1,
        [EnumMember(Value = "EURGBP")] EURGBP = 2,
        [EnumMember(Value = "GBPJPY")] GBPJPY = 3,
        [EnumMember(Value = "EURJPY")] EURJPY = 4,
        [EnumMember(Value = "GBPUSD")] GBPUSD = 5,
        [EnumMember(Value = "USDJPY")] USDJPY = 6,
        [EnumMember(Value = "AUDCAD")] AUDCAD = 7,
        [EnumMember(Value = "NZDUSD")] NZDUSD = 8,
        [EnumMember(Value = "USDRUB")] USDRUB = 10,
        [EnumMember(Value = "USDCHF")] USDCHF = 72,
        [EnumMember(Value = "AUDUSD")] AUDUSD = 99,
        [EnumMember(Value = "USDCAD")] USDCAD = 100,
        [EnumMember(Value = "AUDJPY")] AUDJPY = 101,
        [EnumMember(Value = "GBPCAD")] GBPCAD = 102,
        [EnumMember(Value = "EURCAD")] EURCAD = 105,
        [EnumMember(Value = "CHFJPY")] CHFJPY = 106,
        [EnumMember(Value = "CADCHF")] CADCHF = 107,
        [EnumMember(Value = "EURAUD")] EURAUD = 108,
        [EnumMember(Value = "USDNOK")] USDNOK = 168,
        [EnumMember(Value = "EURNZD")] EURNZD = 212,
        [EnumMember(Value = "USDSEK")] USDSEK = 219,
        [EnumMember(Value = "USDPLN")] USDPLN = 866,
        [EnumMember(Value = "AUDCHF")] AUDCHF = 943,
        [EnumMember(Value = "AUDNZD")] AUDNZD = 944,
        [EnumMember(Value = "CADJPY")] CADJPY = 945,
        [EnumMember(Value = "EURCHF")] EURCHF = 946,
        [EnumMember(Value = "GBPNZD")] GBPNZD = 947,
        [EnumMember(Value = "NZDCAD")] NZDCAD = 948,
        [EnumMember(Value = "NZDJPY")] NZDJPY = 949,
        [EnumMember(Value = "EURNOK")] EURNOK = 951,
        [EnumMember(Value = "CHFSGD")] CHFSGD = 952,
        [EnumMember(Value = "EURSGD")] EURSGD = 955,
        [EnumMember(Value = "AUDNOK")] AUDNOK = 986,
        [EnumMember(Value = "AUDSEK")] AUDSEK = 988,
        [EnumMember(Value = "AUDSGD")] AUDSGD = 989,
        [EnumMember(Value = "CADNOK")] CADNOK = 993,
        [EnumMember(Value = "CADPLN")] CADPLN = 994,
        [EnumMember(Value = "EURDKK")] EURDKK = 1007,
        [EnumMember(Value = "EURMXN")] EURMXN = 1008,
        [EnumMember(Value = "EURZAR")] EURZAR = 1011,
        [EnumMember(Value = "NOKJPY")] NOKJPY = 1024,
        [EnumMember(Value = "NOKSEK")] NOKSEK = 1025,
        [EnumMember(Value = "NZDSGD")] NZDSGD = 1031,
        [EnumMember(Value = "SEKJPY")] SEKJPY = 1038,
        [EnumMember(Value = "SGDJPY")] SGDJPY = 1041,
        [EnumMember(Value = "USDDKK")] USDDKK = 1045,
        [EnumMember(Value = "NZDCHF")] NZDCHF = 1048,
        [EnumMember(Value = "USDCZK")] USDCZK = 1050,
        [EnumMember(Value = "USDHUF")] USDHUF = 1051,

        #endregion

        #region [CFDs]

        [EnumMember(Value = "AMAZON")] AMAZON = 31,
        [EnumMember(Value = "APPLE")] APPLE = 32,
        [EnumMember(Value = "BAIDU")] BAIDU = 33,
        [EnumMember(Value = "CISCO")] CISCO = 34,
        [EnumMember(Value = "FACEBOOK")] FACEBOOK = 35,
        [EnumMember(Value = "GOOGLE")] GOOGLE = 36,
        [EnumMember(Value = "INTEL")] INTEL = 37,
        [EnumMember(Value = "MSFT")] MSFT = 38,
        [EnumMember(Value = "CITI")] CITI = 45,
        [EnumMember(Value = "COKE")] COKE = 46,
        [EnumMember(Value = "GE")] GE = 48,
        [EnumMember(Value = "GM")] GM = 49,
        [EnumMember(Value = "GS")] GS = 50,
        [EnumMember(Value = "JPM")] JPM = 51,
        [EnumMember(Value = "MCDON")] MCDON = 52,
        [EnumMember(Value = "MORSTAN")] MORSTAN = 53,
        [EnumMember(Value = "NIKE")] NIKE = 54,
        [EnumMember(Value = "XAUUSD")] XAUUSD = 74,
        [EnumMember(Value = "XAGUSD")] XAGUSD = 75,
        [EnumMember(Value = "ALIBABA")] ALIBABA = 87,
        [EnumMember(Value = "TWITTER")] TWITTER = 113,
        [EnumMember(Value = "FERRARI")] FERRARI = 133,
        [EnumMember(Value = "TESLA")] TESLA = 167,
        [EnumMember(Value = "MMM:US")] MMM_US = 252,
        [EnumMember(Value = "ABT:US")] ABT_US = 253,
        [EnumMember(Value = "ABBV:US")] ABBV_US = 254,
        [EnumMember(Value = "ACN:US")] ACN_US = 255,
        [EnumMember(Value = "ATVI:US")] ATVI_US = 256,
        [EnumMember(Value = "ADBE:US")] ADBE_US = 258,
        [EnumMember(Value = "AAP:US")] AAP_US = 259,
        [EnumMember(Value = "AA:US")] AA_US = 269,
        [EnumMember(Value = "MO:US")] MO_US = 278,
        [EnumMember(Value = "AMGN:US")] AMGN_US = 290,
        [EnumMember(Value = "T:US")] T_US = 303,
        [EnumMember(Value = "ADSK:US")] ADSK_US = 304,
        [EnumMember(Value = "BAC:US")] BAC_US = 313,
        [EnumMember(Value = "BBY:US")] BBY_US = 320,
        [EnumMember(Value = "BA:US")] BA_US = 324,
        [EnumMember(Value = "BMY:US")] BMY_US = 328,
        [EnumMember(Value = "CAT:US")] CAT_US = 338,
        [EnumMember(Value = "CTL:US")] CTL_US = 344,
        [EnumMember(Value = "CVX:US")] CVX_US = 349,
        [EnumMember(Value = "CTAS:US")] CTAS_US = 356,
        [EnumMember(Value = "CTXS:US")] CTXS_US = 360,
        [EnumMember(Value = "CL:US")] CL_US = 365,
        [EnumMember(Value = "CMCSA:US")] CMCSA_US = 366,
        [EnumMember(Value = "CXO:US")] CXO_US = 369,
        [EnumMember(Value = "COP:US")] COP_US = 370,
        [EnumMember(Value = "ED:US")] ED_US = 371,
        [EnumMember(Value = "COST:US")] COST_US = 374,
        [EnumMember(Value = "CVS:US")] CVS_US = 379,
        [EnumMember(Value = "DHI:US")] DHI_US = 380,
        [EnumMember(Value = "DHR:US")] DHR_US = 381,
        [EnumMember(Value = "DRI:US")] DRI_US = 382,
        [EnumMember(Value = "DVA:US")] DVA_US = 383,
        [EnumMember(Value = "DAL:US")] DAL_US = 386,
        [EnumMember(Value = "DVN:US")] DVN_US = 388,
        [EnumMember(Value = "DLR:US")] DLR_US = 390,
        [EnumMember(Value = "DFS:US")] DFS_US = 391,
        [EnumMember(Value = "DISCA:US")] DISCA_US = 392,
        [EnumMember(Value = "DOV:US")] DOV_US = 397,
        [EnumMember(Value = "DTE:US")] DTE_US = 400,
        [EnumMember(Value = "ETFC:US")] ETFC_US = 404,
        [EnumMember(Value = "EMN:US")] EMN_US = 405,
        [EnumMember(Value = "EBAY:US")] EBAY_US = 407,
        [EnumMember(Value = "ECL:US")] ECL_US = 408,
        [EnumMember(Value = "EIX:US")] EIX_US = 409,
        [EnumMember(Value = "EMR:US")] EMR_US = 413,
        [EnumMember(Value = "ETR:US")] ETR_US = 415,
        [EnumMember(Value = "EQT:US")] EQT_US = 417,
        [EnumMember(Value = "EFX:US")] EFX_US = 418,
        [EnumMember(Value = "EQR:US")] EQR_US = 420,
        [EnumMember(Value = "ESS:US")] ESS_US = 421,
        [EnumMember(Value = "EXPD:US")] EXPD_US = 426,
        [EnumMember(Value = "EXR:US")] EXR_US = 428,
        [EnumMember(Value = "XOM:US")] XOM_US = 429,
        [EnumMember(Value = "FFIV:US")] FFIV_US = 430,
        [EnumMember(Value = "FRT:US")] FRT_US = 433,
        [EnumMember(Value = "FIS:US")] FIS_US = 435,
        [EnumMember(Value = "FITB:US")] FITB_US = 436,
        [EnumMember(Value = "FSLR:US")] FSLR_US = 437,
        [EnumMember(Value = "FE:US")] FE_US = 438,
        [EnumMember(Value = "FISV:US")] FISV_US = 439,
        [EnumMember(Value = "FLS:US")] FLS_US = 441,
        [EnumMember(Value = "FMC:US")] FMC_US = 443,
        [EnumMember(Value = "FBHS:US")] FBHS_US = 448,
        [EnumMember(Value = "FCX:US")] FCX_US = 450,
        [EnumMember(Value = "GILD:US")] GILD_US = 460,
        [EnumMember(Value = "HAS:US")] HAS_US = 471,
        [EnumMember(Value = "HON:US")] HON_US = 480,
        [EnumMember(Value = "IBM:US")] IBM_US = 491,
        [EnumMember(Value = "KHC:US")] KHC_US = 513,
        [EnumMember(Value = "LMT:US")] LMT_US = 528,
        [EnumMember(Value = "MA:US")] MA_US = 542,
        [EnumMember(Value = "MDT:US")] MDT_US = 548,
        [EnumMember(Value = "MU:US")] MU_US = 553,
        [EnumMember(Value = "NFLX:US")] NFLX_US = 569,
        [EnumMember(Value = "NEE:US")] NEE_US = 575,
        [EnumMember(Value = "NVDA:US")] NVDA_US = 586,
        [EnumMember(Value = "PYPL:US")] PYPL_US = 597,
        [EnumMember(Value = "PFE:US")] PFE_US = 603,
        [EnumMember(Value = "PM:US")] PM_US = 605,
        [EnumMember(Value = "PG:US")] PG_US = 617,
        [EnumMember(Value = "QCOM:US")] QCOM_US = 626,
        [EnumMember(Value = "DGX:US")] DGX_US = 628,
        [EnumMember(Value = "RTN:US")] RTN_US = 630,
        [EnumMember(Value = "CRM:US")] CRM_US = 645,
        [EnumMember(Value = "SLB:US")] SLB_US = 647,
        [EnumMember(Value = "SBUX:US")] SBUX_US = 666,
        [EnumMember(Value = "SYK:US")] SYK_US = 670,
        [EnumMember(Value = "DIS:US")] DIS_US = 689,
        [EnumMember(Value = "VZ:US")] VZ_US = 723,
        [EnumMember(Value = "V:US")] V_US = 726,
        [EnumMember(Value = "WMT:US")] WMT_US = 729,
        [EnumMember(Value = "WBA:US")] WBA_US = 730,
        [EnumMember(Value = "SNAP")] SNAP = 756,
        [EnumMember(Value = "AMD")] AMD = 760,
        [EnumMember(Value = "ALGN")] ALGN = 761,
        [EnumMember(Value = "ANSS")] ANSS = 762,
        [EnumMember(Value = "DRE")] DRE = 772,
        [EnumMember(Value = "IDXX")] IDXX = 775,
        [EnumMember(Value = "RMD")] RMD = 781,
        [EnumMember(Value = "SU")] SU = 783,
        [EnumMember(Value = "TFX")] TFX = 784,
        [EnumMember(Value = "TMUS")] TMUS = 785,
        [EnumMember(Value = "QQQ")] QQQ = 796,
        [EnumMember(Value = "SPY")] SPY = 808,
        [EnumMember(Value = "DBX")] DBX = 889,
        [EnumMember(Value = "SPOT")] SPOT = 891,
        [EnumMember(Value = "LLOYL-CHIX")] LLOYL_CHIX = 894,
        [EnumMember(Value = "VODL-CHIX")] VODL_CHIX = 895,
        [EnumMember(Value = "BARCL-CHIX")] BARCL_CHIX = 896,
        [EnumMember(Value = "TSCOL-CHIX")] TSCOL_CHIX = 897,
        [EnumMember(Value = "BPL-CHIX")] BPL_CHIX = 898,
        [EnumMember(Value = "HSBAL-CHIX")] HSBAL_CHIX = 899,
        [EnumMember(Value = "RBSL-CHIX")] RBSL_CHIX = 900,
        [EnumMember(Value = "BLTL-CHIX")] BLTL_CHIX = 901,
        [EnumMember(Value = "MRWL-CHIX")] MRWL_CHIX = 902,
        [EnumMember(Value = "STANL-CHIX")] STANL_CHIX = 903,
        [EnumMember(Value = "RRL-CHIX")] RRL_CHIX = 904,
        [EnumMember(Value = "MKSL-CHIX")] MKSL_CHIX = 905,
        [EnumMember(Value = "BATSL-CHIX")] BATSL_CHIX = 906,
        [EnumMember(Value = "ULVRL-CHIX")] ULVRL_CHIX = 908,
        [EnumMember(Value = "EZJL-CHIX")] EZJL_CHIX = 909,
        [EnumMember(Value = "ADSD-CHIX")] ADSD_CHIX = 910,
        [EnumMember(Value = "ALVD-CHIX")] ALVD_CHIX = 911,
        [EnumMember(Value = "BAYND-CHIX")] BAYND_CHIX = 912,
        [EnumMember(Value = "BMWD-CHIX")] BMWD_CHIX = 913,
        [EnumMember(Value = "CBKD-CHIX")] CBKD_CHIX = 914,
        [EnumMember(Value = "COND-CHIX")] COND_CHIX = 915,
        [EnumMember(Value = "DAID-CHIX")] DAID_CHIX = 916,
        [EnumMember(Value = "DBKD-CHIX")] DBKD_CHIX = 917,
        [EnumMember(Value = "DPWD-CHIX")] DPWD_CHIX = 919,
        [EnumMember(Value = "DTED-CHIX")] DTED_CHIX = 920,
        [EnumMember(Value = "EOAND-CHIX")] EOAND_CHIX = 921,
        [EnumMember(Value = "MRKD-CHIX")] MRKD_CHIX = 922,
        [EnumMember(Value = "TKAD-CHIX")] TKAD_CHIX = 924,
        [EnumMember(Value = "VOW3D-CHIX")] VOW3D_CHIX = 925,
        [EnumMember(Value = "ENELM-CHIX")] ENELM_CHIX = 926,
        [EnumMember(Value = "ENIM-CHIX")] ENIM_CHIX = 927,
        [EnumMember(Value = "FCAM-CHIX")] FCAM_CHIX = 928,
        [EnumMember(Value = "PIRCM-CHIX")] PIRCM_CHIX = 929,
        [EnumMember(Value = "PSTM-CHIX")] PSTM_CHIX = 930,
        [EnumMember(Value = "TITM-CHIX")] TITM_CHIX = 931,
        [EnumMember(Value = "UCGM-CHIX")] UCGM_CHIX = 932,
        [EnumMember(Value = "SANE-CHIX")] SANE_CHIX = 937,
        [EnumMember(Value = "BBVAE-CHIX")] BBVAE_CHIX = 938,
        [EnumMember(Value = "TEFE-CHIX")] TEFE_CHIX = 939,
        [EnumMember(Value = "AIRP-CHIX")] AIRP_CHIX = 940,
        [EnumMember(Value = "HEIOA-CHIX")] HEIOA_CHIX = 941,
        [EnumMember(Value = "ORP-CHIX")] ORP_CHIX = 942,
        [EnumMember(Value = "JUVEM")] JUVEM = 958,
        [EnumMember(Value = "MANU")] MANU = 966,
        [EnumMember(Value = "UKOUSD")] UKOUSD = 969,
        [EnumMember(Value = "USOUSD")] USOUSD = 971,
        [EnumMember(Value = "EEM")] EEM = 1203,
        [EnumMember(Value = "FXI")] FXI = 1204,
        [EnumMember(Value = "IWM")] IWM = 1205,
        [EnumMember(Value = "GDX")] GDX = 1206,
        [EnumMember(Value = "XOP")] XOP = 1209,
        [EnumMember(Value = "XLK")] XLK = 1210,
        [EnumMember(Value = "XLE")] XLE = 1211,
        [EnumMember(Value = "XLU")] XLU = 1212,
        [EnumMember(Value = "IEMG")] IEMG = 1213,
        [EnumMember(Value = "XLY")] XLY = 1214,
        [EnumMember(Value = "IYR")] IYR = 1215,
        [EnumMember(Value = "SQQQ")] SQQQ = 1216,
        [EnumMember(Value = "SMH")] SMH = 1218,
        [EnumMember(Value = "EWJ")] EWJ = 1219,
        [EnumMember(Value = "XLB")] XLB = 1221,
        [EnumMember(Value = "DIA")] DIA = 1222,
        [EnumMember(Value = "TLT")] TLT = 1223,
        [EnumMember(Value = "SDS")] SDS = 1224,
        [EnumMember(Value = "EWW")] EWW = 1225,
        [EnumMember(Value = "XME")] XME = 1227,
        [EnumMember(Value = "QID")] QID = 1229,
        [EnumMember(Value = "ACB")] ACB = 1288,
        [EnumMember(Value = "CGC")] CGC = 1289,
        [EnumMember(Value = "CRON")] CRON = 1290,
        [EnumMember(Value = "GWPH")] GWPH = 1291,
        [EnumMember(Value = "MJ")] MJ = 1292,
        [EnumMember(Value = "TLRY")] TLRY = 1293,
        [EnumMember(Value = "BUD")] BUD = 1294,
        [EnumMember(Value = "LYFT")] LYFT = 1313,
        [EnumMember(Value = "PINS")] PINS = 1315,
        [EnumMember(Value = "ZM")] ZM = 1316,
        [EnumMember(Value = "UBER")] UBER = 1334,
        [EnumMember(Value = "MELI")] MELI = 1335,
        [EnumMember(Value = "BYND")] BYND = 1336,
        [EnumMember(Value = "WORK")] WORK = 1343,
        [EnumMember(Value = "FDJP")] FDJP = 1350,
        [EnumMember(Value = "VIAC")] VIAC = 1352,
        [EnumMember(Value = "TFC")] TFC = 1353

        #endregion
    }
}
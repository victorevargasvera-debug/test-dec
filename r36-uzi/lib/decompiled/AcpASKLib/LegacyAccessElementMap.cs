// Decompiled with JetBrains decompiler
// Type: AcpASKLib.LegacyAccessElementMap
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System.Collections.Generic;

#nullable disable
namespace AcpASKLib;

public static class LegacyAccessElementMap
{
  public static Dictionary<AccessElementLegacyIDType, AccessElementIDType> map = new Dictionary<AccessElementLegacyIDType, AccessElementIDType>();
  public static Dictionary<AccessElementLegacyIDType, AccessElementIDType[]> map1 = new Dictionary<AccessElementLegacyIDType, AccessElementIDType[]>();

  internal static Dictionary<AccessElementLegacyIDType, AccessElementIDType> LegacyFieldMap
  {
    get => LegacyAccessElementMap.map;
  }

  static LegacyAccessElementMap()
  {
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_TYPE_II_SYS_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_SYS_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_TYPE_II_CNCT_TONE_ELEMENT, AccessElementIDType.TRK_SYS_GEN_TYPE_II_CNCT_TONE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_ASTRO_25_HOME_SYS_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_SYS_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_ASTRO_25_HOME_WACN_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_ASTRO_25_HOME_WACN_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_ASTRO_25_UNIT_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_UNIT_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_HPD_HOME_SYS_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_HPD_HOME_SYS_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_HPD_HOME_WACN_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_HPD_HOME_WACN_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_HPD_UNIT_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_HPD_UNIT_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_COV_TYPE_ELEMENT, AccessElementIDType.TRK_SYS_GEN_COV_TYPE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_GEN_SITE_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_SITE_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ADV_SPLINTER_CHAN_ELEMENT, AccessElementIDType.TRK_SYS_II_SPLINTER_CHAN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_SITE_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_SITE_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.HOLDER_FOR_TRK_SYS_GEN_GEOFENCE_MODE_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_GEOFENCE_MODE_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CID_DIS_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CID_DIS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CID_BW_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CID_BW_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CID_TX_OFFSET_SIGN_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CID_TX_OFFSET_SIGN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CID_BASE_FX_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CID_BASE_FX_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CID_CHAN_SPACING_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CID_CHAN_SPACING_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CID_TX_OFFSET_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CID_TX_OFFSET_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CC_800_CHAN_ID_NUM_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CC_800_CHAN_ID_NUM_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CC_800_RX_FREQ_ELEMENT, AccessElementIDType.TRK_SYS_CC_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CC_OBT_RX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_SYS_CC_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CC_OBT_TX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_SYS_CC_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_CC_OBT_CHAN_BW_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_CC_OBT_CHAN_BW_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_ASTRO_25_OMNI_RFSS_ID_ELEMENT, AccessElementIDType.TRK_SYS_ASTRO_25_OMNI_RFSS_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_TYPE_II_CC_800_RX_FREQ_ELEMENT, AccessElementIDType.TRK_SYS_CC_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_TYPE_II_CC_OBT_RX_FREQ_ELEMENT, AccessElementIDType.TRK_SYS_CC_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_TYPE_II_CC_OBT_TX_FREQ_ELEMENT, AccessElementIDType.TRK_SYS_CC_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_TYPE_II_IND_ID_ELEMENT, AccessElementIDType.TRK_SYS_GEN_UNIT_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_BAND_PLAN_CID_ELEMENT, AccessElementIDType.TRK_SYS_BAND_PLAN_CID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_BAND_PLAN_BW_ELEMENT, AccessElementIDType.TRK_SYS_BAND_PLAN_BW_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_BAND_PLAN_TX_OFFSET_SIGN_ELEMENT, AccessElementIDType.TRK_SYS_BAND_PLAN_TX_OFFSET_SIGN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_BAND_PLAN_TX_OFFSET_ELEMENT, AccessElementIDType.TRK_SYS_BAND_PLAN_TX_OFFSET_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_BAND_PLAN_CHAN_SPACING_ELEMENT, AccessElementIDType.TRK_SYS_BAND_PLAN_CHAN_SPACING_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_BAND_PLAN_BASE_FX_ELEMENT, AccessElementIDType.TRK_SYS_BAND_PLAN_BASE_FX_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_STAC_CHAN_TX_ELEMENT, AccessElementIDType.TRK_SYS_STAC_CHAN_TX_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_STAC_CHAN_RX_ELEMENT, AccessElementIDType.TRK_SYS_STAC_CHAN_RX_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_STAC_CHAN_BW_ELEMENT, AccessElementIDType.TRK_SYS_STAC_CHAN_BW_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_GEN_AG_ELEMENT, AccessElementIDType.TRK_PER_AG_AG_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_GEN_SZ_CODE_ELEMENT, AccessElementIDType.TRK_PER_GEN_SZ_CODE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_GEN_PFI_FLT_ID_ELEMENT, AccessElementIDType.TRK_PER_GEN_PFI_FLT_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.HOLDER_FOR_TRK_PER_GEN_TX_MODE_ELEMENT, AccessElementIDType.TRK_PER_GEN_TX_MODE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.HOLDER_FOR_TRK_PER_GEN_TIME_OUT_TIMER_ELEMENT, AccessElementIDType.TRK_PER_GEN_TIME_OUT_TIMER_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_EM_REVERT_INDV_ID_ELEMENT, AccessElementIDType.TRK_PER_EM_REVERT_INDV_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_ER_DEF_EMER_SZ_CODE_ELEMENT, AccessElementIDType.TRK_PER_ER_DEF_EMER_SZ_CODE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_ER_FLT_ID_ELEMENT, AccessElementIDType.TRK_PER_ER_FLT_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_ER_TYPE_II_DEF_AG_ELEMENT, AccessElementIDType.TRK_PER_ER_TYPE_II_DEF_AG_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_ER_TYPE_II_DEF_TG_ELEMENT, AccessElementIDType.TRK_PER_ER_TYPE_II_DEF_TG_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_ER_SF_ELEMENT, AccessElementIDType.TRK_PER_ER_SF_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_AG_CHAN_EN_ELEMENT, AccessElementIDType.TRK_PER_AG_AG_FS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_FLT_WIDE_CHAN_EN_ELEMENT, AccessElementIDType.TRK_PER_FS_800_FLT_WIDE_CHAN_EN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_AG_TYPE_II_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_FLT_WIDE_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_FS_800_FLT_WIDE_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_FS_TYPE_ELEMENT, AccessElementIDType.TRK_PER_GEN_FS_TYPE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_AG_ASTRO_25_FS_CHAN_ID_ELEMENT, AccessElementIDType.TRK_PER_FS_800_AG_ASTRO_25_FS_CHAN_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_800_AG_ASTRO_25_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_AG_CHAN_EN_ELEMENT, AccessElementIDType.TRK_PER_AG_AG_FS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_AG_RX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_AG_TX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_RX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_TX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_AG_FS_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_RX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_GEN_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_TX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_GEN_FS_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_BW_ELEMENT, AccessElementIDType.TRK_PER_FS_OBT_BW_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FS_OBT_TYPE_ELEMENT, AccessElementIDType.TRK_PER_GEN_FS_TYPE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_SF_FS_CHAN_EN_ELEMENT, AccessElementIDType.TRK_PER_SF_FS_CHAN_EN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_SF_FS_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_SF_FS_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_SF_ELEMENT, AccessElementIDType.TRK_PER_SF_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_OBT_ASTRO_25_FS_EN_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_EN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_OBT_TYPE_II_FS_EN_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_EN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_FS_CHAN_EN_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_EN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_OBT_FS_RX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_OBT_FS_TX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_800_FS_TYPE_II_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_FS_RX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_FS_TX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_TX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_ASTRO_25_FS_CHAN_ID_ELEMENT, AccessElementIDType.TRK_PER_TG_ASTRO_25_FS_CHAN_ID_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_FS_BW_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_BW_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_STRAP_ELEMENT, AccessElementIDType.TRK_PER_TG_STRAP_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_ASTRO_25_ELEMENT, AccessElementIDType.TRK_PER_TG_TG_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_TYPE_II_ELEMENT, AccessElementIDType.TRK_PER_TG_TG_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_ASTRO_25_FS_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_ASTRO_25_FS_TX_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_TG_FS_RX_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_KEY_SEL_ELEMENT, AccessElementIDType.TRK_PER_TG_KEY_SEL_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_WAC_AMSS_STS_EN_ELEMENT, AccessElementIDType.TRK_PER_WAC_AMSS_STS_EN_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_WAC_AMSS_FS_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_WAC_AMSS_FS_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_WAC_AMSS_OBT_FS_RX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_WAC_AMSS_OBT_FS_RX_OSW_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_WAC_AMSS_OBT_FS_TX_OSW_CHAN_INCR_ELEMENT, AccessElementIDType.TRK_PER_WAC_AMSS_OBT_FS_TX_OSW_CHAN_INCR_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.HOLDER_FOR_TRK_PER_CALL_PAGE_ASTRO_ALERTING_TONE_TABLE_ELEMENT, AccessElementIDType.TRK_PER_CALL_PAGE_ASTRO_ALERTING_TONE_TABLE_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_SYS_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_CTRL_CHAN_OBT_TBL_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_SYS_CTRL_CHAN_OBT_TBL_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_CHAN_800MHZ_TBL_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_SYS_CHAN_800MHZ_TBL_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_APCO_CHAN_800MHZ_TBL_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_SYS_APCO_CHAN_800MHZ_TBL_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_SYS_APCO_CTRL_CHAN_OBT_TBL_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_SYS_APCO_CTRL_CHAN_OBT_TBL_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_PER_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_TG_TBL_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_PER_TG_TBL_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.TRK_PER_SF_TBL_FUNCTIONS_ELEMENT, AccessElementIDType.TRK_PER_SF_TBL_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.CLONING_FUNCTIONS_ELEMENT, AccessElementIDType.CLONING_FUNCTIONS_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.WRITE_PROTECT_RADIO_ELEMENT, AccessElementIDType.WRITE_PROTECT_RADIO_ELEMENT);
    LegacyAccessElementMap.map.Add(AccessElementLegacyIDType.OTAP_ELEMENT, AccessElementIDType.OTAP_ELEMENT);
  }
}

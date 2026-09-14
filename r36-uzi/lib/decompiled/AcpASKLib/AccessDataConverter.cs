// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessDataConverter
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpASKLib;

public static class AccessDataConverter
{
  internal static AccessRecordData ConvertLegacyAccessRecordData(
    AccessRecordData legacyAccRecData,
    bool otapEnabled)
  {
    AccessRecordData accessRecordData = (AccessRecordData) null;
    if (legacyAccRecData != null)
    {
      byte[] byteArray = AccessDataConverter.ConvertLegacyFieldCode(legacyAccRecData.FieldCode);
      if (otapEnabled)
        AccessDataConverter.SetOTAPEnabledBit(ref byteArray);
      Dictionary<ushort, FieldValueRangeRecSet> rg = AccessDataConverter.ConvertLegacyRanges(legacyAccRecData.Ranges);
      accessRecordData = new AccessRecordData(legacyAccRecData.PrimaryKey, byteArray, rg);
    }
    return accessRecordData;
  }

  internal static byte[] ConvertLegacyFieldCode(byte[] legacyFc)
  {
    byte[] byteArray = (byte[]) null;
    Dictionary<AccessElementIDType, AccessElementIDType> dictionary = new Dictionary<AccessElementIDType, AccessElementIDType>();
    if (legacyFc != null)
    {
      byteArray = new byte[24];
      for (int index = 0; index < legacyFc.Length; ++index)
        byteArray[index] = (byte) 0;
      for (int id = 1; id <= 8 * legacyFc.Length; ++id)
      {
        if (AccessDataConverter.IsBitSet(id, legacyFc))
        {
          AccessElementLegacyIDType key = (AccessElementLegacyIDType) id;
          if (key <= AccessElementLegacyIDType.HOLDER_FOR_TRK_PER_GEN_TIME_OUT_TIMER_ELEMENT)
          {
            AccessElementIDType legacyField = LegacyAccessElementMap.LegacyFieldMap[key];
            if (!dictionary.ContainsKey(legacyField))
              dictionary.Add(legacyField, legacyField);
          }
          else
            break;
        }
      }
      foreach (KeyValuePair<AccessElementIDType, AccessElementIDType> keyValuePair in dictionary)
        AccessDataConverter.SetBit(keyValuePair.Value, ref byteArray);
      AccessDataConverter.SetBit(AccessElementIDType.TRK_SYS_ASTRO_25_CID_CHAN_TYPE_ELEMENT, ref byteArray);
    }
    return byteArray;
  }

  internal static Dictionary<ushort, FieldValueRangeRecSet> ConvertLegacyRanges(
    Dictionary<ushort, FieldValueRangeRecSet> legacyRanges)
  {
    Dictionary<ushort, FieldValueRangeRecSet> dictionary = (Dictionary<ushort, FieldValueRangeRecSet>) null;
    if (legacyRanges != null)
    {
      dictionary = new Dictionary<ushort, FieldValueRangeRecSet>();
      foreach (FieldValueRangeRecSet valueRangeRecSet1 in legacyRanges.Values)
      {
        AccessElementIDType fieldIndex = AccessDataConverter.GetFieldIndex((AccessElementLegacyIDType) valueRangeRecSet1.OwnerID);
        FieldValueRangeRecSet valueRangeRecSet2 = dictionary.ContainsKey((ushort) fieldIndex) ? dictionary[(ushort) fieldIndex] : new FieldValueRangeRecSet((ushort) fieldIndex);
        foreach (AccessFieldValueRange accessFieldValueRange1 in (Collection<AccessFieldValueRange>) valueRangeRecSet1)
        {
          AccessFieldValueRange accessFieldValueRange2 = new AccessFieldValueRange((int) fieldIndex, accessFieldValueRange1.Minimum, accessFieldValueRange1.Maximum);
          valueRangeRecSet2.Add(accessFieldValueRange2);
        }
        if (!dictionary.ContainsKey((ushort) fieldIndex))
          dictionary.Add((ushort) fieldIndex, valueRangeRecSet2);
      }
    }
    return dictionary;
  }

  private static bool IsBitSet(int id, byte[] byteArray)
  {
    bool flag = false;
    if (id > 0 && id <= 8 * byteArray.Length)
    {
      int num1 = id - 1;
      int index = num1 / 8;
      int num2 = num1 % 8;
      flag = ((int) byteArray[index] & 1 << num2) > 0;
    }
    return flag;
  }

  private static void SetBit(AccessElementIDType elementId, ref byte[] byteArray)
  {
    int num1 = (int) (elementId - 1);
    int index = num1 / 8;
    int num2 = num1 % 8;
    byteArray[index] += (byte) (1 << num2);
  }

  internal static void SetOTAPEnabledBit(ref byte[] byteArray)
  {
    AccessDataConverter.SetBit(AccessElementIDType.OTAP_ELEMENT, ref byteArray);
  }

  internal static AccessElementIDType GetFieldIndex(AccessElementLegacyIDType legacyId)
  {
    return LegacyAccessElementMap.LegacyFieldMap.ContainsKey(legacyId) ? LegacyAccessElementMap.LegacyFieldMap[legacyId] : throw new Exception("Invalid Legacy Field ID");
  }
}

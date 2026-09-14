// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessRecordData
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System.Collections.Generic;

#nullable disable
namespace AcpASKLib;

public class AccessRecordData
{
  private int primaryKey;
  private byte[] fieldCode;
  private Dictionary<ushort, FieldValueRangeRecSet> ranges;

  internal AccessRecordData(int pK, byte[] fc, Dictionary<ushort, FieldValueRangeRecSet> rg)
  {
    this.primaryKey = pK;
    this.fieldCode = fc;
    this.ranges = rg;
  }

  internal int PrimaryKey
  {
    get => this.primaryKey;
    set => this.primaryKey = value;
  }

  internal byte[] FieldCode
  {
    get => this.fieldCode;
    set => this.fieldCode = value;
  }

  internal Dictionary<ushort, FieldValueRangeRecSet> Ranges
  {
    get => this.ranges;
    set => this.ranges = value;
  }
}

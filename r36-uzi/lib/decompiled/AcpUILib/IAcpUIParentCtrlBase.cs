// Decompiled with JetBrains decompiler
// Type: AcpUILib.IAcpUIParentCtrlBase
// Assembly: AcpUILib, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 6F9E0BB6-7C96-4FCD-AD4F-151E6FD8321B
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUILib.dll

using AcpBusinessLayer;

#nullable disable
namespace AcpUILib;

public interface IAcpUIParentCtrlBase
{
  IAcpUIChildCtrlBase MyLabelCtrl { get; set; }

  IAcpUIChildCtrlBase MyCopyButtonCtrl { get; set; }

  AcpFieldBase MyBLObject { get; set; }

  bool AreValuesEqual { get; set; }
}

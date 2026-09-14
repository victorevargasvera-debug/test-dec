// Decompiled with JetBrains decompiler
// Type: AcpASKLib.IKeyDataRecord
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

#nullable disable
namespace AcpASKLib;

public interface IKeyDataRecord
{
  byte KeyType { get; set; }

  int SystemID { get; set; }

  bool Editable { get; set; }

  bool IsSelected { get; set; }
}

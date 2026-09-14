// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AcpSecurityException
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using System;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AcpSecurityException : Exception
{
  public AcpSecurityException()
    : base(AcpResources.Key_Not_Found)
  {
  }

  public AcpSecurityException(string message)
    : base(message)
  {
  }

  public AcpSecurityException(string message, Exception innerException)
    : base(message, innerException)
  {
  }
}

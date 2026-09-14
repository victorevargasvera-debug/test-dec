// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommandLineCPS.CruncherOperation
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;

#nullable disable
namespace MackinawCPS.CommandLineCPS;

public class CruncherOperation
{
  internal CruncherData cruncherData;
  internal AstroDeviceInfo deviceInfo;

  internal CruncherOperation.Operation Type { get; set; }

  internal CruncherOperation()
  {
    this.Type = CruncherOperation.Operation.NONE;
    this.inputFile = (string) null;
    this.sourceFile = (string) null;
    this.password = (string) null;
    this.targetFile = (string) null;
    this.IsEncryptedPwd = false;
  }

  internal string inputFile { get; set; }

  internal string password { get; set; }

  internal string sourceFile { get; set; }

  internal string targetFile { get; set; }

  internal string targetArchive { get; set; }

  internal ASTROFirmware fwPackageDesc { get; set; }

  internal string fwPackagePath { get; set; }

  internal bool IsEncryptedPwd { get; set; }

  public enum Operation
  {
    NONE,
    READ,
    WRITE,
    ARCHIVECLONE,
    NONECLONEWRITE,
    UPGRADE,
    CREATE,
    IMPORT,
    CONVERTCXF,
  }
}

// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpFileHeader
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

#nullable disable
namespace AcpFileHandlerLib;

[Serializable]
public class AcpFileHeader : ISerializable
{
  private string modelNumber = string.Empty;
  private string serialNumber = string.Empty;
  private string flashCode = string.Empty;
  private string versionNumber = string.Empty;
  private string fileInfo = string.Empty;

  public AcpFileHeader()
  {
  }

  public string ModelNumber
  {
    get => this.modelNumber;
    set => this.modelNumber = value;
  }

  public string SerialNumber
  {
    get => this.serialNumber;
    set => this.serialNumber = value;
  }

  public string FlashCode
  {
    get => this.flashCode;
    set => this.flashCode = value;
  }

  public string VersionNumber
  {
    get => this.versionNumber;
    set => this.versionNumber = value;
  }

  public string FileInfo
  {
    get => this.fileInfo;
    set => this.fileInfo = value;
  }

  [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
  public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    if (info == null)
      throw new ArgumentNullException(nameof (info));
    info.AddValue("Model Number", (object) this.modelNumber);
    info.AddValue("Serial Number", (object) this.serialNumber);
    info.AddValue("Flash Code", (object) this.flashCode);
    info.AddValue("Version Number", (object) this.versionNumber);
    info.AddValue("File Information", (object) this.fileInfo);
  }

  protected AcpFileHeader(SerializationInfo info, StreamingContext context)
  {
    this.modelNumber = info != null ? info.GetString("Model Number") : throw new ArgumentNullException(nameof (info));
    this.serialNumber = info.GetString("Serial Number");
    this.flashCode = info.GetString("Flash Code");
    this.versionNumber = info.GetString("Version Number");
    this.fileInfo = info.GetString("File Information");
  }
}

// Decompiled with JetBrains decompiler
// Type: ACPBrowser.FileService
// Assembly: ACPBrowser, Version=1.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 8594EB5B-A9B7-4EA3-AB9A-BDF8416D55ED
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\ACPBrowser.dll

using System.IO;

#nullable disable
namespace ACPBrowser;

public class FileService : IFileService
{
  public bool Exists(string path) => File.Exists(path);
}

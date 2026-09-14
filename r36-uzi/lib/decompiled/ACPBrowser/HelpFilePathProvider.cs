// Decompiled with JetBrains decompiler
// Type: ACPBrowser.HelpFilePathProvider
// Assembly: ACPBrowser, Version=1.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 8594EB5B-A9B7-4EA3-AB9A-BDF8416D55ED
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\ACPBrowser.dll

using System.IO;

#nullable disable
namespace ACPBrowser;

public class HelpFilePathProvider
{
  private readonly IFileService fileService;
  public const string Prefix = "file:///";
  private const string indexPath = "index.html";
  private const string apxFamilyPath = "apxfamily.htm";

  public HelpFilePathProvider(IFileService fileService) => this.fileService = fileService;

  public string BuildPathForCPSHelp(string fragment)
  {
    string empty = string.Empty;
    string str = Path.Combine(Utility.HelpRootDir, "apxfamily.htm");
    if (fragment != null && this.fileService.Exists(Utility.HelpRootDir + fragment))
      return $"file:///{str}#{fragment}";
    string path = str ?? "";
    return this.fileService.Exists(path) ? "file:///" + path : (string) null;
  }

  public string BuildPathForCPSHelpDITA(string fragment)
  {
    string path = Path.Combine(Utility.HelpRootDir, "index.html");
    if (!this.fileService.Exists(path))
      return (string) null;
    return fragment == null ? "file:///" + path : $"file:///{path}{fragment}";
  }

  public string BuildPathForMovies(string fragment)
  {
    string empty = string.Empty;
    if (fragment != null)
    {
      string path = Utility.HelpRootDir + fragment;
      string str = Path.Combine(Utility.HelpRootDir, "zzTutorials\\APX_MH_PRJ\\APXMovie.htm#..\\..\\");
      if (this.fileService.Exists(path))
        return $"file:///{str}{fragment}";
    }
    string path1 = Path.Combine(Utility.HelpRootDir, "apxfamily.htm") ?? "";
    return this.fileService.Exists(path1) ? "file:///" + path1 : (string) null;
  }

  public string BuildPathForCPSTutorials(string tutorialName)
  {
    string empty = string.Empty;
    if (tutorialName != null)
    {
      string path = Utility.TutorialRootDir + tutorialName;
      if (this.fileService.Exists(path))
        return "file:///" + path;
    }
    string path1 = Path.Combine(Utility.TutorialRootDir, "Tutorial_Home\\Homepage.htm") ?? "";
    return this.fileService.Exists(path1) ? "file:///" + path1 : (string) null;
  }

  public static string BuildPathForHelpByTagContextMenu(string fileName)
  {
    string str1 = Path.Combine(Utility.HelpRootDir, "index.html");
    if (string.IsNullOrEmpty(fileName))
      return (string) null;
    string str2 = fileName.Replace(".html", string.Empty);
    return $"file:///{str1}#{str2}";
  }

  public static string BuildPathForHelpByFileContextMenu(string fileName)
  {
    string str = Path.Combine(Utility.HelpRootDir, "index.html");
    return string.IsNullOrEmpty(fileName) ? (string) null : $"file:///{str}?file={fileName}";
  }

  public string BuildPathForHelpByFileName(string fileName)
  {
    if (fileName == null)
      return (string) null;
    string path = Path.Combine(Utility.HelpRootDir, fileName);
    return this.fileService.Exists(path) ? "file:///" + path : (string) null;
  }
}

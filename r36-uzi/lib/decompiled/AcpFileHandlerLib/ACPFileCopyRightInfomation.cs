// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.ACPFileCopyRightInfomation
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace AcpFileHandlerLib;

public class ACPFileCopyRightInfomation
{
  private static ACPFileCopyRightInfomation instance;
  private const string pattern = "^Copyright \\(c\\) \\d{4} Motorola Solutions, Inc\\. All Rights Reserved ";
  private const int ExpectedByteLength_MaxLimitation = 64 /*0x40*/;

  private ACPFileCopyRightInfomation()
  {
  }

  public static ACPFileCopyRightInfomation Instance
  {
    get
    {
      if (ACPFileCopyRightInfomation.instance == null)
        ACPFileCopyRightInfomation.instance = new ACPFileCopyRightInfomation();
      return ACPFileCopyRightInfomation.instance;
    }
  }

  public string CopyRightInformation
  {
    get
    {
      return $"Copyright (c) {DateTime.Now.Year.ToString()} Motorola Solutions, Inc. All Rights Reserved ";
    }
  }

  public int SkipCopyRightInfoIfHas(Stream fs)
  {
    int copyRightInfoLength = this.GetCopyRightInfoLength(fs);
    return fs.CanSeek ? (int) fs.Seek((long) copyRightInfoLength, SeekOrigin.Begin) : 0;
  }

  public byte[] SkipCopyRightInfoIfHas(byte[] fileBytes)
  {
    int copyRightInfoLength = this.GetCopyRightInfoLength(fileBytes);
    byte[] destinationArray = new byte[fileBytes.Length - copyRightInfoLength];
    Array.Copy((Array) fileBytes, copyRightInfoLength, (Array) destinationArray, 0, destinationArray.Length);
    return destinationArray;
  }

  private int GetCopyRightInfoLength(byte[] fileBytes)
  {
    int count = fileBytes.Length > 64 /*0x40*/ ? 64 /*0x40*/ : fileBytes.Length;
    return this.GetCopyRightLenghtIfMatchPattern(Encoding.UTF8.GetString(fileBytes, 0, count));
  }

  private int GetCopyRightInfoLength(Stream fs)
  {
    fs.Seek(0L, SeekOrigin.Begin);
    int count1 = fs.Length > 64L /*0x40*/ ? 64 /*0x40*/ : (int) fs.Length;
    byte[] numArray = new byte[count1];
    int count2 = fs.Read(numArray, 0, count1);
    return this.GetCopyRightLenghtIfMatchPattern(Encoding.UTF8.GetString(numArray, 0, count2));
  }

  private int GetCopyRightLenghtIfMatchPattern(string copyRightToCheck)
  {
    if (string.IsNullOrEmpty(copyRightToCheck))
      return 0;
    Match match = new Regex("^Copyright \\(c\\) \\d{4} Motorola Solutions, Inc\\. All Rights Reserved ", RegexOptions.Compiled).Match(copyRightToCheck);
    return !match.Success ? 0 : Encoding.UTF8.GetBytes(match.Value).Length;
  }
}

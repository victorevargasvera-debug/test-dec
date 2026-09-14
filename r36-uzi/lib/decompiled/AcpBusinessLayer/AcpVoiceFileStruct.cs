// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpVoiceFileStruct
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using ACPVoiceAnnouncementLib;
using System;
using System.IO;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public struct AcpVoiceFileStruct : IComparable, IComparable<AcpVoiceFileStruct>
{
  public MemoryStream voiceData;
  public int compressionParam;
  public MotVoiceFileCompressionCode compressionType;
  public string voicefile;
  public uint hashcode;

  public AcpVoiceFileStruct(string voicefile)
  {
    try
    {
      ACPMotVoiceAnnouncementFileClass announcementFileClass = ACPMotVoiceAnnouncementFileClass.LoadFromFile(voicefile);
      if (announcementFileClass != null)
      {
        this.compressionParam = announcementFileClass.CompressionParam;
        this.compressionType = announcementFileClass.CompressionType;
        this.hashcode = announcementFileClass.CheckSum32;
        this.voiceData = new MemoryStream(announcementFileClass.VoiceData, 0, announcementFileClass.VoiceData.Length, true, true);
        this.voicefile = voicefile;
      }
      else
      {
        this.compressionParam = 6;
        this.compressionType = (MotVoiceFileCompressionCode) 1;
        this.voiceData = new MemoryStream();
        this.voicefile = "";
        this.hashcode = 0U;
      }
    }
    catch
    {
      this.compressionParam = 6;
      this.compressionType = (MotVoiceFileCompressionCode) 1;
      this.voiceData = new MemoryStream();
      this.voicefile = "";
      this.hashcode = 0U;
    }
  }

  public int CompareTo(object obj)
  {
    int num = -1;
    if (obj != null)
      num = this.CompareTo((AcpVoiceFileStruct) obj);
    return num;
  }

  public static AcpVoiceFileStruct Parse(string vaVal)
  {
    AcpVoiceFileStruct acpVoiceFileStruct = new AcpVoiceFileStruct();
    if (vaVal != null && vaVal != string.Empty)
    {
      acpVoiceFileStruct.compressionType = (MotVoiceFileCompressionCode) 1;
      acpVoiceFileStruct.compressionParam = 6;
      byte[] byteArray = VAUtilities.StrToByteArray(vaVal);
      acpVoiceFileStruct.voiceData = new MemoryStream(byteArray, 0, byteArray.Length, true, true);
      acpVoiceFileStruct.hashcode = acpVoiceFileStruct.GetHashCode();
    }
    return acpVoiceFileStruct;
  }

  public int getVoiceFileDuration()
  {
    int num1 = 20;
    int num2 = 0;
    int num3 = 0;
    if (this.compressionType == 1)
    {
      num3 = (int) this.voiceData.Length - 6;
      num1 = 20;
      switch (this.compressionParam)
      {
        case 0:
          num2 = 13;
          break;
        case 1:
          num2 = 14;
          break;
        case 2:
          num2 = 16 /*0x10*/;
          break;
        case 3:
          num2 = 18;
          break;
        case 4:
          num2 = 20;
          break;
        case 5:
          num2 = 21;
          break;
        case 6:
          num2 = 27;
          break;
        case 7:
          num2 = 32 /*0x20*/;
          break;
      }
    }
    return num3 > 0 && num2 > 0 ? num1 * (num3 / num2) : 0;
  }

  public int CompareTo(AcpVoiceFileStruct vaObj)
  {
    int num = -1;
    if (this.voiceData != null && vaObj.voiceData != null && this.voiceData.Length == vaObj.voiceData.Length)
    {
      byte[] buffer1 = this.voiceData.GetBuffer();
      byte[] buffer2 = vaObj.voiceData.GetBuffer();
      num = 0;
      for (int index = 0; (long) index < this.voiceData.Length; ++index)
      {
        if ((int) buffer1[index] != (int) buffer2[index])
        {
          num = -1;
          break;
        }
      }
    }
    return num;
  }

  public uint GetHashCode()
  {
    return this.voiceData != null ? ACPMotVoiceAnnouncementFileClass.CalculateHashcode(this.voiceData.GetBuffer(), 0, (int) this.voiceData.Length) : 0U;
  }

  public override string ToString()
  {
    string str = string.Empty;
    if (this.voiceData != null)
      str = VAUtilities.ByteArrayToStr(this.voiceData.GetBuffer(), (int) this.voiceData.Length);
    return str;
  }
}

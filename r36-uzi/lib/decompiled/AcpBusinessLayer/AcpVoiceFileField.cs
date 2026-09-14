// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpVoiceFileField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using ACPVoiceAnnouncementLib;
using System;
using System.IO;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpVoiceFileField : AcpField<AcpVoiceFileStruct>
{
  protected AcpVoiceFileField()
  {
  }

  public AcpVoiceFileField(FeatureSection parent, string name, string uiLabel)
    : base(parent, name, uiLabel)
  {
  }

  public override void SetValue(AcpVoiceFileStruct newValue)
  {
    try
    {
      if (this.Parent != null && this.ParentNode != null && this.Parent.ParentRecset != null && this.VoiceData != null)
        ((Recordset) this.Parent.ParentRecset).DecrementCumulativeMax(this.ParentNode);
      base.SetValue(newValue);
      if (this.Parent == null || this.ParentNode == null || this.Parent.ParentRecset == null || this.VoiceData == null)
        return;
      ((Recordset) this.Parent.ParentRecset).IncrementCumulativeMax(this.ParentNode);
    }
    catch
    {
    }
  }

  public override string ToString()
  {
    string str = string.Empty;
    if (this.Value.voiceData != null)
      str = VAUtilities.ByteArrayToStr(this.Value.voiceData.GetBuffer(), (int) this.Value.voiceData.Length);
    return str;
  }

  public MemoryStream VoiceData
  {
    get => this.Value.voiceData;
    set
    {
      AcpVoiceFileStruct acpVoiceFileStruct = this.Value;
      if (acpVoiceFileStruct.voiceData != null && this.Name != "BookmarkURL")
      {
        value.WriteTo((Stream) acpVoiceFileStruct.voiceData);
      }
      else
      {
        acpVoiceFileStruct.voiceData = new MemoryStream();
        value.WriteTo((Stream) acpVoiceFileStruct.voiceData);
      }
      acpVoiceFileStruct.hashcode = acpVoiceFileStruct.GetHashCode();
      acpVoiceFileStruct.compressionType = (MotVoiceFileCompressionCode) 1;
      acpVoiceFileStruct.compressionParam = 6;
      this.SetValueNoConstraints(acpVoiceFileStruct);
    }
  }

  public MotVoiceFileCompressionCode CompressionType => this.Value.compressionType;

  public int CompressionParam => this.Value.compressionParam;

  public uint Hashcode => this.Value.hashcode;
}

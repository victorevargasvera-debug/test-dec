// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessFieldValueRange
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.ComponentModel;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessFieldValueRange : ICloneable, INotifyPropertyChanged
{
  private int m_fieldID;
  private uint? m_min;
  private uint? m_max;
  private bool m_IsValid = true;
  private string m_ErrorMsg = string.Empty;

  public AccessFieldValueRange()
  {
  }

  public AccessFieldValueRange(int field_id, uint? min, uint? max)
  {
    this.m_fieldID = field_id;
    this.m_min = min;
    this.m_max = max;
  }

  public int FieldID
  {
    get => this.m_fieldID;
    set => this.m_fieldID = value;
  }

  public uint? Minimum
  {
    get => this.m_min;
    set
    {
      this.m_min = value;
      this.FirePropertyChanged(nameof (Minimum));
    }
  }

  public uint? Maximum
  {
    get => this.m_max;
    set
    {
      this.m_max = value;
      this.FirePropertyChanged(nameof (Maximum));
    }
  }

  public bool IsValid
  {
    get => this.m_IsValid;
    set
    {
      this.m_IsValid = value;
      this.FirePropertyChanged(nameof (IsValid));
    }
  }

  public string ErrorMsg
  {
    get => this.m_ErrorMsg;
    set
    {
      this.m_ErrorMsg = value;
      this.FirePropertyChanged(nameof (ErrorMsg));
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public void FirePropertyChanged(string name)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));
  }

  public object Clone() => (object) (AccessFieldValueRange) this.MemberwiseClone();
}

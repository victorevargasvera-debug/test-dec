// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessOperation
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.ComponentModel;
using System.Xml.Serialization;

#nullable disable
namespace AcpASKLib;

[XmlType("Operation")]
[Serializable]
public class AccessOperation : AccessElement, IOperationAccessLevel, INotifyPropertyChanged
{
  private bool bValue;

  public AccessOperation() => this.bValue = false;

  public AccessOperation(
    string strName,
    string strUiName,
    int id,
    AccessElementIDType elemId,
    bool value)
    : base(strName, strUiName, id, elemId)
  {
    this.bValue = value;
  }

  [XmlIgnore]
  public bool AccessLevel
  {
    get => this.bValue;
    set
    {
      this.bValue = value;
      this.NotifyPropertyChanged(nameof (AccessLevel));
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  private void NotifyPropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }
}

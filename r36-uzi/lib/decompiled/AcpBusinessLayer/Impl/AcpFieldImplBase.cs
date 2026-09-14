// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.Impl.AcpFieldImplBase
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using System.Collections.Generic;

#nullable disable
namespace AcpBusinessLayer.Impl;

internal class AcpFieldImplBase
{
  private AcpFieldImplBase()
  {
    this.DifferentiatedUserView = DifferentiatedUserViewType.Full;
    this.FieldId = -1;
  }

  internal AcpFieldImplBase(string uiName)
    : this()
  {
    this.UIName = uiName;
    this.LegacyUINames = (ISet<string>) new HashSet<string>();
  }

  internal string UIName { get; private set; }

  internal ISet<string> LegacyUINames { get; private set; }

  internal string NewUiExpanderAndName { get; set; }

  internal string Name { get; set; }

  internal ValueSetterConstraint ValueSetter { get; set; }

  internal StateConstraint IsValid { get; set; }

  internal StateConstraint IsApplicable { get; set; }

  internal StateConstraint IsVisible { get; set; }

  internal StateConstraint IsEditable { get; set; }

  internal DifferentiatedUserViewType DifferentiatedUserView { get; set; }

  internal bool TieredOut { get; set; }

  internal bool DefaultSetByTiering { get; set; }

  internal int GuiVersion { get; set; }

  internal int DataTransferOrder { get; set; }

  internal int FieldId { get; set; }

  internal bool Protected { get; set; }

  internal bool IgnoreOnCompare { get; set; }

  internal bool IgnoreOnPrint { get; set; }

  internal bool IsMasked { get; set; }

  internal bool CustomViewVisibility { get; set; }

  internal bool KeyNameField { get; set; }
}

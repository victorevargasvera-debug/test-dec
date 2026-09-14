// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.FieldTaskBase
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib.UndoRedo;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class FieldTaskBase : UndoableTask
{
  protected internal AcpFieldBase field;

  public override void LaunchUI() => UndoManager.GoToSection(this.field.Parent);
}

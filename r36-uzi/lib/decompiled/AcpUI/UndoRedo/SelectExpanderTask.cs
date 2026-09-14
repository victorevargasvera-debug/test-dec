// Decompiled with JetBrains decompiler
// Type: AcpUI.UndoRedo.SelectExpanderTask
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI.UndoRedo;

internal class SelectExpanderTask : UndoableTask
{
  private Expander expander;

  protected SelectExpanderTask()
  {
  }

  internal SelectExpanderTask(Expander expander)
  {
    this.expander = expander;
    this.Description = AcpResources.Select_Expander.AcpStringFormat(expander.Header);
    this.Seamless = true;
  }

  public override void Do()
  {
    this.expander.Visibility = Visibility.Visible;
    this.expander.IsExpanded = true;
    this.expander.Focus();
    base.Do();
  }

  public override void Undo()
  {
    this.expander.IsExpanded = false;
    this.expander.Visibility = Visibility.Collapsed;
    base.Undo();
  }
}

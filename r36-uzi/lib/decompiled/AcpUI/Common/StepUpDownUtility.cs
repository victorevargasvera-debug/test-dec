// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.StepUpDownUtility
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using System;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

#nullable disable
namespace AcpUI.Common;

public static class StepUpDownUtility
{
  internal static void OnClick(object sender, AcpFieldBase myBLObject)
  {
    RepeatButton repeatButton = sender as RepeatButton;
    IAcpRangeField acpRangeField = myBLObject as IAcpRangeField;
    if (repeatButton == null || acpRangeField == null)
      return;
    if (repeatButton.Name.Equals("DownClick", StringComparison.Ordinal))
      acpRangeField.StepDown();
    else
      acpRangeField.StepUp();
  }

  internal static void OnKeyPress(KeyEventArgs keyEventArgs, AcpFieldBase myBLObject)
  {
    IAcpRangeField acpRangeField = myBLObject as IAcpRangeField;
    switch (keyEventArgs.Key)
    {
      case Key.Up:
        acpRangeField.StepUp();
        keyEventArgs.Handled = true;
        break;
      case Key.Down:
        acpRangeField.StepDown();
        keyEventArgs.Handled = true;
        break;
    }
  }
}

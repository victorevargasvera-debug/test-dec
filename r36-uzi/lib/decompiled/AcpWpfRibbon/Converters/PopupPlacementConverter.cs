// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Converters.PopupPlacementConverter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfRibbon.Converters;

public class PopupPlacementConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    ePopupPlacement ePopupPlacement = (ePopupPlacement) value;
    if (targetType == typeof (string))
      return (object) ePopupPlacement.ToString();
    if (targetType == typeof (PlacementMode))
    {
      switch (ePopupPlacement)
      {
        case ePopupPlacement.Right:
          return (object) PlacementMode.Right;
        case ePopupPlacement.Left:
          return (object) PlacementMode.Left;
        case ePopupPlacement.Bottom:
          return (object) PlacementMode.Bottom;
        case ePopupPlacement.Top:
          return (object) PlacementMode.Top;
        case ePopupPlacement.Custom:
          return (object) PlacementMode.Absolute;
      }
    }
    return (object) null;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    switch ((PlacementMode) value)
    {
      case PlacementMode.Bottom:
        return (object) ePopupPlacement.Bottom;
      case PlacementMode.Right:
        return (object) ePopupPlacement.Right;
      case PlacementMode.Left:
        return (object) ePopupPlacement.Left;
      case PlacementMode.Top:
        return (object) ePopupPlacement.Top;
      default:
        return (object) ePopupPlacement.Custom;
    }
  }
}

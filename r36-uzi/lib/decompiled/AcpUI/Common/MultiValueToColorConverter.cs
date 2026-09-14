// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.MultiValueToColorConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace AcpUI.Common;

public class MultiValueToColorConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    Brush brush = AcpColorKeyBrush.GetBrushFromColorKey(typeof (Hyperlink), AcpColorKeys.HyperlinkForFeatureGroupForeground) ?? (Brush) Brushes.Black;
    if (values[0] is bool && (bool) values[0])
      brush = AcpColorKeyBrush.GetBrushFromColorKey(typeof (AcpExpander), AcpColorKeys.AcpExpanderInValidForeground) ?? (Brush) Brushes.Red;
    return (object) brush;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetTypes,
    object parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException("Method not implemented");
  }
}

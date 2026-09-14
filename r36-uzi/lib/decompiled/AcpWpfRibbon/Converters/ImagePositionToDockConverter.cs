// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Converters.ImagePositionToDockConverter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfRibbon.Converters;

public class ImagePositionToDockConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    eButtonImagePosition buttonImagePosition = (eButtonImagePosition) value;
    if (targetType == typeof (string))
      return (object) buttonImagePosition.ToString();
    if (targetType == typeof (Dock))
    {
      switch (buttonImagePosition)
      {
        case eButtonImagePosition.Left:
          return (object) Dock.Left;
        case eButtonImagePosition.Top:
          return (object) Dock.Top;
        case eButtonImagePosition.Bottom:
          return (object) Dock.Bottom;
        case eButtonImagePosition.Right:
          return (object) Dock.Right;
      }
    }
    return (object) null;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) (eButtonImagePosition) Enum.Parse(typeof (eButtonImagePosition), value.ToString());
  }
}

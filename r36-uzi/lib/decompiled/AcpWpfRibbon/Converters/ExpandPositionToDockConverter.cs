// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Converters.ExpandPositionToDockConverter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace DevComponents.WpfRibbon.Converters;

public class ExpandPositionToDockConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    eExpandPosition eExpandPosition = (eExpandPosition) value;
    if (targetType == typeof (string))
      return (object) eExpandPosition.ToString();
    if (targetType == typeof (Dock))
    {
      switch (eExpandPosition)
      {
        case eExpandPosition.Left:
          return (object) Dock.Left;
        case eExpandPosition.Right:
          return (object) Dock.Right;
        case eExpandPosition.Top:
          return (object) Dock.Top;
        case eExpandPosition.Bottom:
          return (object) Dock.Bottom;
      }
    }
    return (object) null;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) (eExpandPosition) Enum.Parse(typeof (eExpandPosition), value.ToString());
  }
}

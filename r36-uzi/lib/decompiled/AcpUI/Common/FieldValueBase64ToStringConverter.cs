// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.FieldValueBase64ToStringConverter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

#nullable disable
namespace AcpUI.Common;

public class FieldValueBase64ToStringConverter : IMultiValueConverter
{
  private const int bookmarkUrlRecsetId = 4237;
  private const string urlInnerSectionName = "URLTableInnerSection";
  private const string bookmarkUrlFieldName = "BookmarkURL";

  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    object s;
    try
    {
      s = (object) (string) values[0];
      string str = (string) values[1];
      if (!FeatureManager.IsInitialized)
        return s;
      IAcpFeatureNode acpFeatureNode = FeatureManager.GetFeature(4237)[0];
      object obj1 = acpFeatureNode?.GetType()?.GetProperty("URLTableInnerSection")?.GetValue((object) acpFeatureNode);
      object obj2 = obj1?.GetType()?.GetProperty("BookmarkURL")?.GetValue(obj1);
      if (obj2 == null)
        return s;
      string uiName = (obj2 as IAcpField).UIName;
      if (str == uiName)
      {
        try
        {
          return (object) Encoding.ASCII.GetString(System.Convert.FromBase64String((string) s));
        }
        catch (FormatException ex)
        {
        }
      }
    }
    catch
    {
      s = values[0];
    }
    return s;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetTypes,
    object parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}

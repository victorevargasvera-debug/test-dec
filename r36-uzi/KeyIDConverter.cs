// Decompiled with JetBrains decompiler
// Type: MackinawCPS.KeyIDConverter
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpASKLib;
using CommonResources;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class KeyIDConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    ObservableCollection<SystemKeyData> observableCollection = new ObservableCollection<SystemKeyData>();
    string str1 = (string) null;
    if (values[1] != null)
    {
      string str2 = values[1].ToString();
      if (str2 == AppResources.Adv_System_Key_Column_Header_ID)
        str1 = KeyType.ADVANCED_SYSTEM_KEY.ToString();
      else if (str2 == AppResources.Adv_WACN_Key_Column_Header_ID)
        str1 = KeyType.ADVANCED_WACN_KEY.ToString();
      else if (str2 == AppResources.None_Id)
        str1 = KeyType.NONE.ToString();
      foreach (SystemKeyData systemKeyData in (Collection<SystemKeyData>) values[0])
      {
        if (systemKeyData.Type.ToString() == str1)
          observableCollection.Add(systemKeyData);
      }
    }
    return (object) observableCollection;
  }

  public object[] ConvertBack(
    object value,
    Type[] targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object[]) null;
  }
}

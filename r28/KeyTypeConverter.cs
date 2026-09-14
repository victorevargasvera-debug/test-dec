// Decompiled with JetBrains decompiler
// Type: MackinawCPS.KeyTypeConverter
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpASKLib;
using CommonResources;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace MackinawCPS;

public class KeyTypeConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    Collection<KeyType> collection1 = new Collection<KeyType>();
    Collection<string> collection2 = new Collection<string>();
    if (((Collection<SystemKeyData>) value).Count > 0)
    {
      foreach (SystemKeyData systemKeyData in (Collection<SystemKeyData>) value)
      {
        if (!collection1.Contains(systemKeyData.Type) && systemKeyData.Type != KeyType.ADVANCED_CONV_SYSTEM_KEY)
          collection1.Add(systemKeyData.Type);
      }
      foreach (KeyType keyType in collection1)
      {
        switch (keyType)
        {
          case KeyType.ADVANCED_SYSTEM_KEY:
            collection2.Add(AppResources.Adv_System_Key_Column_Header_ID);
            break;
          case KeyType.ADVANCED_WACN_KEY:
            collection2.Add(AppResources.Adv_WACN_Key_Column_Header_ID);
            break;
          case KeyType.NONE:
            collection2.Add(AppResources.None_Id);
            break;
        }
      }
    }
    return (object) collection2;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) null;
  }
}

// Decompiled with JetBrains decompiler
// Type: MackinawCPS.BluetoothPANIPAddressRule
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using System.Globalization;
using System.Net;
using System.Windows.Controls;

#nullable disable
namespace MackinawCPS;

public class BluetoothPANIPAddressRule : ValidationRule
{
  public override ValidationResult Validate(object value, CultureInfo cultureInfo)
  {
    if (value == null)
      return new ValidationResult(false, (object) null);
    return BluetoothPANIPAddressRule.IsValidBluetoothPANIPAddress(value.ToString()) ? ValidationResult.ValidResult : new ValidationResult(false, (object) null);
  }

  public static bool IsValidBluetoothPANIPAddress(string strIPAddress)
  {
    bool flag;
    try
    {
      IPAddress address;
      if (IPAddress.TryParse(strIPAddress, out address))
      {
        if (address.GetAddressBytes()[3] != (byte) 1)
        {
          flag = false;
        }
        else
        {
          string[] strArray = strIPAddress.Split('.');
          flag = strArray.Length == 4 && (!(strArray[1] != "0") || !strArray[1].StartsWith("0")) && (!(strArray[2] != "0") || !strArray[2].StartsWith("0")) && !strArray[3].StartsWith("0");
        }
      }
      else
        flag = false;
    }
    catch
    {
      flag = false;
    }
    return flag;
  }
}

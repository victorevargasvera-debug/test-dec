// Decompiled with JetBrains decompiler
// Type: AcpUI.Masks.CommonMasks
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

#nullable disable
namespace AcpUI.Masks;

public static class CommonMasks
{
  internal static bool IsTextHex(string text)
  {
    foreach (char objA in text.ToCharArray())
    {
      if (!object.Equals((object) objA, (object) 'A') && !object.Equals((object) objA, (object) 'a') && !object.Equals((object) objA, (object) 'B') && !object.Equals((object) objA, (object) 'b') && !object.Equals((object) objA, (object) 'C') && !object.Equals((object) objA, (object) 'c') && !object.Equals((object) objA, (object) 'D') && !object.Equals((object) objA, (object) 'd') && !object.Equals((object) objA, (object) 'E') && !object.Equals((object) objA, (object) 'e') && !object.Equals((object) objA, (object) 'F') && !object.Equals((object) objA, (object) 'f'))
        return false;
    }
    return true;
  }

  internal static bool IsTextLetter(string text)
  {
    foreach (char c in text.ToCharArray())
    {
      if (!char.IsLetter(c))
        return false;
    }
    return true;
  }

  internal static bool IsTextDigit(string text)
  {
    foreach (char c in text.ToCharArray())
    {
      if (!char.IsDigit(c))
        return false;
    }
    return true;
  }

  internal static bool IsTextPeriod(string text)
  {
    foreach (int objA in text.ToCharArray())
    {
      if (!object.Equals((object) (char) objA, (object) '.'))
        return false;
    }
    return true;
  }

  internal static bool IsTextDigitOrPeriod(string text)
  {
    foreach (char ch in text.ToCharArray())
    {
      if (!char.IsDigit(ch) && !object.Equals((object) ch, (object) '.'))
        return false;
    }
    return true;
  }
}

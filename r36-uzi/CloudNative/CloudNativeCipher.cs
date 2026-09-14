// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNative.CloudNativeCipher
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace MackinawCPS.CloudNative;

public static class CloudNativeCipher
{
  private const int Iterations = 600000;
  private const int KeySize = 32 /*0x20*/;

  public static string Encrypt(string plainText)
  {
    byte[] bytes1 = Encoding.UTF8.GetBytes(CloudNativeParameters.CloudNativeHeaders.BridgeHash);
    byte[] bytes2 = Encoding.UTF8.GetBytes(CloudNativeParameters.CloudNativeHeaders.Nonce);
    return CloudNativeCipher.Encrypt(plainText, bytes1, bytes2);
  }

  public static string Encrypt(string plainText, byte[] serviceHash, byte[] nonce)
  {
    byte[] bytes = new Rfc2898DeriveBytes(serviceHash, nonce, 600000, HashAlgorithmName.SHA256).GetBytes(32 /*0x20*/);
    return Convert.ToBase64String(AesGcm.AesGcmEncrypt(Encoding.UTF8.GetBytes(plainText), bytes));
  }

  public static string Decrypt(string cipherText)
  {
    byte[] bytes1 = Encoding.UTF8.GetBytes(CloudNativeParameters.CloudNativeHeaders.BridgeHash);
    byte[] bytes2 = Encoding.UTF8.GetBytes(CloudNativeParameters.CloudNativeHeaders.Nonce);
    return CloudNativeCipher.Decrypt(cipherText, bytes1, bytes2);
  }

  public static string Decrypt(string cipherText, byte[] serviceHash, byte[] nonce)
  {
    byte[] bytes = new Rfc2898DeriveBytes(serviceHash, nonce, 600000, HashAlgorithmName.SHA256).GetBytes(32 /*0x20*/);
    return Encoding.UTF8.GetString(AesGcm.AesGcmDecrypt(Convert.FromBase64String(cipherText), bytes));
  }
}

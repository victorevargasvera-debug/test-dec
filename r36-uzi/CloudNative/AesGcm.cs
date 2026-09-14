// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNative.AesGcm
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

#nullable disable
namespace MackinawCPS.CloudNative;

public static class AesGcm
{
  private const int NonceByteSize = 12;
  private const int TagByteSize = 16 /*0x10*/;
  private const int TagBitSize = 128 /*0x80*/;
  private const int ZeroOffset = 0;

  public static byte[] AesGenerateNonce()
  {
    byte[] data = new byte[12];
    new RNGCryptoServiceProvider().GetBytes(data);
    return data;
  }

  public static byte[] AesGcmDecrypt(byte[] payload, byte[] key)
  {
    byte[] numArray1 = new byte[payload.Length - 12];
    byte[] numArray2 = new byte[12];
    Buffer.BlockCopy((Array) payload, 0, (Array) numArray2, 0, 12);
    Buffer.BlockCopy((Array) payload, 12, (Array) numArray1, 0, payload.Length - 12);
    return AesGcm.AesGcmDecrypt(numArray1, key, numArray2);
  }

  public static byte[] AesGcmDecrypt(byte[] payload, byte[] key, byte[] nonce)
  {
    GcmBlockCipher gcmBlockCipher = new GcmBlockCipher((IBlockCipher) new AesEngine());
    gcmBlockCipher.Init(false, (ICipherParameters) new AeadParameters(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key), 128 /*0x80*/, nonce));
    byte[] numArray = new byte[gcmBlockCipher.GetOutputSize(payload.Length)];
    int outOff = gcmBlockCipher.ProcessBytes(payload, 0, payload.Length, numArray, 0);
    gcmBlockCipher.DoFinal(numArray, outOff);
    return ((IEnumerable<byte>) numArray).Take<byte>(payload.Length - 16 /*0x10*/).ToArray<byte>();
  }

  public static byte[] AesGcmEncrypt(byte[] payload, byte[] key)
  {
    return AesGcm.AesGcmEncrypt(payload, key, AesGcm.AesGenerateNonce());
  }

  public static byte[] AesGcmEncrypt(byte[] payload, byte[] key, byte[] nonce)
  {
    GcmBlockCipher gcmBlockCipher = new GcmBlockCipher((IBlockCipher) new AesEngine());
    gcmBlockCipher.Init(true, (ICipherParameters) new AeadParameters(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key), 128 /*0x80*/, nonce));
    byte[] numArray = new byte[gcmBlockCipher.GetOutputSize(payload.Length)];
    int outOff = gcmBlockCipher.ProcessBytes(payload, 0, payload.Length, numArray, 0);
    gcmBlockCipher.DoFinal(numArray, outOff);
    return ((IEnumerable<byte>) nonce).Concat<byte>((IEnumerable<byte>) numArray).ToArray<byte>();
  }
}

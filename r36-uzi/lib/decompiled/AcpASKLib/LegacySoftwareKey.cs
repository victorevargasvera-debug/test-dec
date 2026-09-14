// Decompiled with JetBrains decompiler
// Type: AcpASKLib.LegacySoftwareKey
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using AcpCommonResources;
using AcpCryptoLib;
using AcpUtility;
using System;
using System.Collections.ObjectModel;
using System.IO;

#nullable disable
namespace AcpASKLib;

public class LegacySoftwareKey
{
  private const int HEADER_LENGTH = 3;
  private const int MAX_BLK_CHAR = 256 /*0x0100*/;
  private const int MAX_ID_CHAR = 3;
  private const int CHANNEL_CHAR = 2;
  private const int MAX_CHANNEL_NO = 8;
  private const byte BLOCKNO01 = 1;
  private const byte BLOCKNO03 = 3;
  private const byte BLOCKNOEND = 255 /*0xFF*/;
  private const int UNMAXSYSTEMIDDEC = 65535 /*0xFFFF*/;
  private const int UNMINSYSTEMIDDEC = 1;

  internal int readASystemKey(string sFileName, Collection<StatusMsg> status)
  {
    BlockHeader header = new BlockHeader();
    byte[] numArray = new byte[256 /*0x0100*/];
    bool bIsFirst = true;
    bool flag1 = false;
    int num1 = 0;
    bool flag2 = true;
    if (File.Exists(sFileName))
    {
      try
      {
        using (FileStream fs = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
        {
          fs.Seek(0L, SeekOrigin.Begin);
          AcpSmartNetAlgorithm snCryptor = new AcpSmartNetAlgorithm();
          while (!flag1)
          {
            int num2 = (int) this.readLasSafBlock(snCryptor, fs, header, numArray, bIsFirst);
            bIsFirst = false;
            if (num2 < 3)
            {
              flag2 = false;
              break;
            }
            switch (header.specifier)
            {
              case 1:
                continue;
              case 3:
                num1 = this.UnPackSystemBlock(numArray).SystemID;
                continue;
              case byte.MaxValue:
                flag1 = true;
                continue;
              default:
                flag2 = false;
                flag1 = true;
                continue;
            }
          }
          fs.Close();
          if (flag2 && num1 >= 1)
          {
            if (num1 <= (int) ushort.MaxValue)
              goto label_21;
          }
          num1 = 0;
          status?.Add(new StatusMsg(AskStatusType.Error, AcpResources.Invalid_System_ID.AcpStringFormat((object) sFileName), 3758129165U /*0xE000800D*/));
        }
      }
      catch (Exception ex)
      {
        num1 = 0;
        status?.Add(new StatusMsg(AskStatusType.Error, AcpResources.Error_Reading_File.AcpStringFormat((object) ex.Message), 3758129165U /*0xE000800D*/));
      }
    }
    else
      status?.Add(new StatusMsg(AskStatusType.Error, AcpResources.File_Not_Opened.AcpStringFormat((object) sFileName), 2684387337U /*0xA0008009*/));
label_21:
    return num1;
  }

  private ushort readLasSafBlock(
    AcpSmartNetAlgorithm snCryptor,
    FileStream fs,
    BlockHeader header,
    byte[] blockBuffer,
    bool bIsFirst)
  {
    ushort num1 = 0;
    ushort num2 = 0;
    byte num3 = 0;
    int num4 = 0;
    while (num1 == (ushort) 0 && num4 != -1)
    {
      num4 = fs.ReadByte();
      byte num5 = (byte) num4;
      num1 = (ushort) snCryptor.DecryptChar(num5, ref num3, bIsFirst);
      bIsFirst = false;
    }
    if (num1 != (ushort) 0)
    {
      header.specifier = num3;
      ++num2;
      num1 = (ushort) 0;
    }
    else
      header.specifier = (byte) 0;
    byte num6;
    for (; num1 == (ushort) 0 && num4 != -1; num1 = (ushort) snCryptor.DecryptChar(num6, ref num3, bIsFirst))
    {
      num4 = fs.ReadByte();
      num6 = (byte) num4;
    }
    if (num1 != (ushort) 0)
    {
      header.sequence = num3;
      ++num2;
      num1 = (ushort) 0;
    }
    else
      header.sequence = (byte) 0;
    byte num7;
    for (; num1 == (ushort) 0 && num4 != -1; num1 = (ushort) snCryptor.DecryptChar(num7, ref num3, bIsFirst))
    {
      num4 = fs.ReadByte();
      num7 = (byte) num4;
    }
    if (num1 != (ushort) 0)
    {
      header.length = num3;
      ++num2;
      num1 = (ushort) 0;
    }
    else
      header.length = (byte) 0;
    ushort index;
    for (index = (ushort) 0; (int) index < (int) header.length; ++index)
    {
      byte num8;
      for (; num1 == (ushort) 0 && num4 != -1; num1 = (ushort) snCryptor.DecryptChar(num8, ref num3, bIsFirst))
      {
        num4 = fs.ReadByte();
        num8 = (byte) num4;
      }
      if (num1 != (ushort) 0)
      {
        num1 = (ushort) 0;
        blockBuffer[(int) index] = num3;
        ++num2;
      }
      else
        blockBuffer[(int) index] = (byte) 0;
    }
    for (; index < (ushort) 256 /*0x0100*/; ++index)
      blockBuffer[(int) index] = (byte) 0;
    return num2;
  }

  private Block03 UnPackSystemBlock(byte[] sys_block_buffer)
  {
    Block03 block03 = (Block03) null;
    if (sys_block_buffer != null && sys_block_buffer.Length >= 3)
      block03 = new Block03((int) sys_block_buffer[2] + ((int) sys_block_buffer[1] << 8));
    return block03;
  }
}

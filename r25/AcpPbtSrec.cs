// Decompiled with JetBrains decompiler
// Type: MackinawCPS.AcpPbtSrec
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using MULTIINTPBT6Lib;
using System;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace MackinawCPS;

public class AcpPbtSrec
{
  public const ushort SrecLineDataSize = 28;

  internal bool ConvertPBTFileToSrec(string pbtFileName, string configFileName)
  {
    bool srec = false;
    if (File.Exists(pbtFileName) && File.Exists(configFileName))
    {
      new Pbt6Class().PBTMain2(configFileName, pbtFileName, 3U);
      srec = true;
    }
    return srec;
  }

  internal bool GeneratePBTFromPackedImage(byte[] packedDataArr, string pbtFileName)
  {
    bool pbtFromPackedImage = false;
    bool flag = false;
    FileStream output = (FileStream) null;
    try
    {
      output = new FileStream(pbtFileName, FileMode.Append, FileAccess.Write);
      if (output != null)
      {
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output, Encoding.UTF8);
        if (binaryWriter != null && packedDataArr != null && packedDataArr.GetLength(0) > 0)
        {
          int length = packedDataArr.GetLength(0);
          ushort twoByteVal1;
          uint packedDataIndex;
          for (uint index1 = 0; (long) index1 < (long) length; index1 = packedDataIndex + (uint) twoByteVal1)
          {
            ushort twoByteVal2 = this.GetTwoByteVal(packedDataArr, index1);
            uint index2 = index1 + 2U;
            if (twoByteVal2 == (ushort) 0)
            {
              flag = true;
              break;
            }
            ushort twoByteVal3 = this.GetTwoByteVal(packedDataArr, index2);
            uint index3 = index2 + 2U;
            twoByteVal1 = this.GetTwoByteVal(packedDataArr, index3);
            packedDataIndex = index3 + 2U;
            char[] chArray = new char[(IntPtr) this.CalculateIshItemPbtSize(twoByteVal1)];
            this.CreateIshItemPbtArray(ref chArray, packedDataArr, twoByteVal2, twoByteVal3, twoByteVal1, packedDataIndex);
            if (chArray.Length <= 0)
            {
              flag = true;
              break;
            }
            int index4 = Array.FindIndex<char>(chArray, new Predicate<char>(AcpPbtSrec.IsNulChar));
            if (index4 > 0)
              Array.Resize<char>(ref chArray, index4);
            binaryWriter.Write(chArray);
          }
          if (!flag)
            pbtFromPackedImage = true;
        }
      }
    }
    finally
    {
      output?.Dispose();
    }
    return pbtFromPackedImage;
  }

  private static bool IsNulChar(char a) => a == char.MinValue;

  internal void GeneratePBTFromPackedImage(byte[] packedDataArr, ref byte[] pbtByteDataArr)
  {
    char[] array = new char[0];
    if (packedDataArr != null && packedDataArr.GetLength(0) > 0)
    {
      int length1 = packedDataArr.GetLength(0);
      ushort twoByteVal1;
      uint packedDataIndex;
      for (uint index1 = 0; (long) index1 < (long) length1; index1 = packedDataIndex + (uint) twoByteVal1)
      {
        ushort twoByteVal2 = this.GetTwoByteVal(packedDataArr, index1);
        uint index2 = index1 + 2U;
        if (twoByteVal2 == (ushort) 0)
        {
          Array.Clear((Array) array, 0, array.Length);
          Array.Resize<char>(ref array, 0);
          break;
        }
        ushort twoByteVal3 = this.GetTwoByteVal(packedDataArr, index2);
        uint index3 = index2 + 2U;
        twoByteVal1 = this.GetTwoByteVal(packedDataArr, index3);
        packedDataIndex = index3 + 2U;
        char[] ishItemPbtArr = new char[(IntPtr) this.CalculateIshItemPbtSize(twoByteVal1)];
        this.CreateIshItemPbtArray(ref ishItemPbtArr, packedDataArr, twoByteVal2, twoByteVal3, twoByteVal1, packedDataIndex);
        if (ishItemPbtArr.Length <= 0)
        {
          Array.Clear((Array) pbtByteDataArr, 0, pbtByteDataArr.Length);
          Array.Resize<byte>(ref pbtByteDataArr, 0);
          Array.Clear((Array) array, 0, array.Length);
          Array.Resize<char>(ref array, 0);
          break;
        }
        int length2 = array.GetLength(0);
        int newSize = array.GetLength(0) + ishItemPbtArr.GetLength(0);
        Array.Resize<char>(ref array, newSize);
        ishItemPbtArr.CopyTo((Array) array, length2);
      }
    }
    if (array == null || array.GetLength(0) <= 0)
      return;
    Array.Resize<byte>(ref pbtByteDataArr, array.GetLength(0));
    int newSize1 = 0;
    for (int index = 0; index < array.GetLength(0); ++index)
    {
      if (array[index] != char.MinValue)
        pbtByteDataArr[newSize1++] = Convert.ToByte(array[index]);
    }
    Array.Resize<byte>(ref pbtByteDataArr, newSize1);
  }

  private ushort GetTwoByteVal(byte[] data, uint index)
  {
    ushort twoByteVal = 0;
    if ((long) data.GetLength(0) > (long) (index + 1U))
      twoByteVal = (ushort) ((uint) (ushort) ((uint) (ushort) data[(IntPtr) index] << 8) | (uint) data[(IntPtr) (index + 1U)]);
    return twoByteVal;
  }

  private uint CalculateIshItemPbtSize(ushort ishDataSize)
  {
    uint num1 = (uint) ishDataSize / 28U;
    if ((int) ishDataSize % 28 != 0)
      ++num1;
    uint num2 = 72;
    uint num3 = num1 * num2;
    return num3 + (uint) ((double) num3 * 0.1) + 40U;
  }

  private void CreateIshItemPbtArray(
    ref char[] ishItemPbtArr,
    byte[] packedDataArr,
    ushort ishType,
    ushort ishID,
    ushort ishDataLen,
    uint packedDataIndex)
  {
    CultureInfo provider = new CultureInfo("en-us");
    char ch1 = '\r';
    char ch2 = '\n';
    int num = 0;
    char[] charArray1 = $"TYPE = 0x{ishType.ToString("x", (IFormatProvider) provider)}{(object) ch1}{(object) ch2}".ToCharArray();
    charArray1.CopyTo((Array) ishItemPbtArr, 0);
    int index1 = num + charArray1.GetLength(0);
    char[] charArray2 = $"ID = 0x{ishID.ToString("x", (IFormatProvider) provider)}{(object) ch1}{(object) ch2}".ToCharArray();
    charArray2.CopyTo((Array) ishItemPbtArr, index1);
    int index2 = index1 + charArray2.GetLength(0);
    uint address = 0;
    for (int index3 = (int) ishDataLen; index3 > 0; index3 -= 28)
    {
      uint dataLen = index3 < 28 ? (uint) index3 : 28U;
      char[] pSRecLine = new char[(IntPtr) (uint) (12 + 2 * (int) dataLen + 4)];
      this.BuildPBTSR3Line(ref pSRecLine, packedDataArr, packedDataIndex, dataLen, address);
      if (pSRecLine.Length <= 0)
      {
        Array.Clear((Array) ishItemPbtArr, 0, ishItemPbtArr.Length);
        Array.Resize<char>(ref ishItemPbtArr, 0);
        break;
      }
      pSRecLine.CopyTo((Array) ishItemPbtArr, index2);
      packedDataIndex += dataLen;
      address += dataLen;
      index2 += pSRecLine.GetLength(0);
    }
    if (ishItemPbtArr.Length <= 0)
      return;
    $"END_ITEM{(object) ch1}{(object) ch2}".ToCharArray().CopyTo((Array) ishItemPbtArr, index2);
  }

  private void BuildPBTSR3Line(
    ref char[] pSRecLine,
    byte[] data,
    uint dataIndex,
    uint dataLen,
    uint address)
  {
    byte num1 = 0;
    uint num2 = 0;
    try
    {
      char[] chArray1 = pSRecLine;
      int num3 = (int) num2;
      uint num4 = (uint) (num3 + 1);
      uint index1 = (uint) num3;
      chArray1[(IntPtr) index1] = 'S';
      char[] chArray2 = pSRecLine;
      int num5 = (int) num4;
      uint pos1 = (uint) (num5 + 1);
      uint index2 = (uint) num5;
      chArray2[(IntPtr) index2] = '3';
      byte byteToWrite1 = (byte) (4 + (int) dataLen + 1);
      byte num6 = (byte) ((uint) num1 + (uint) byteToWrite1);
      this.WriteSRByte(ref pSRecLine, pos1, byteToWrite1, (byte) 16 /*0x10*/);
      uint pos2 = pos1 + 2U;
      for (int index3 = 0; index3 < 4; ++index3)
      {
        byte byteToWrite2 = (byte) (address << index3 * 8 >> 24);
        num6 += byteToWrite2;
        this.WriteSRByte(ref pSRecLine, pos2, byteToWrite2, (byte) 16 /*0x10*/);
        pos2 += 2U;
      }
      for (int index4 = 0; (long) index4 < (long) dataLen; ++index4)
      {
        byte byteToWrite3 = data[(long) dataIndex + (long) index4];
        num6 += byteToWrite3;
        this.WriteSRByte(ref pSRecLine, pos2, byteToWrite3, (byte) 16 /*0x10*/);
        pos2 += 2U;
      }
      byte byteToWrite4 = ~num6;
      this.WriteSRByte(ref pSRecLine, pos2, byteToWrite4, (byte) 16 /*0x10*/);
      uint num7 = pos2 + 2U;
      char[] chArray3 = pSRecLine;
      int num8 = (int) num7;
      uint index5 = (uint) (num8 + 1);
      uint index6 = (uint) num8;
      chArray3[(IntPtr) index6] = '\r';
      pSRecLine[(IntPtr) index5] = '\n';
    }
    catch (IndexOutOfRangeException ex)
    {
      Array.Clear((Array) pSRecLine, 0, pSRecLine.Length);
      Array.Resize<char>(ref pSRecLine, 0);
    }
  }

  private void WriteSRByte(ref char[] pSRecLine, uint pos, byte byteToWrite, byte baseFormat)
  {
    uint index1 = pos;
    uint num1 = (uint) byteToWrite / (uint) baseFormat;
    pSRecLine[(IntPtr) index1] = num1 > 9U ? (char) (65 + (int) num1 - 10) : (char) (48 /*0x30*/ + (int) num1);
    uint index2 = index1 + 1U;
    uint num2 = (uint) byteToWrite % (uint) baseFormat;
    pSRecLine[(IntPtr) index2] = num2 > 9U ? (char) (65 + (int) num2 - 10) : (char) (48 /*0x30*/ + (int) num2);
  }

  internal void ConvertPackedImageToSrec(
    byte[] packedDataArr,
    string configFileName,
    ref byte[] srecOut)
  {
    if (!File.Exists(configFileName))
      return;
    byte[] pbtByteDataArr = new byte[0];
    this.GeneratePBTFromPackedImage(packedDataArr, ref pbtByteDataArr);
    if (pbtByteDataArr != null && pbtByteDataArr.GetLength(0) > 0)
    {
      sbyte[] numArray1 = new sbyte[pbtByteDataArr.GetLength(0)];
      int num = 0;
      for (int index = 0; index < pbtByteDataArr.GetLength(0); ++index)
      {
        if (pbtByteDataArr[index] != (byte) 0)
          numArray1[num++] = Convert.ToSByte(pbtByteDataArr[index]);
      }
      object dataFileInfo = (object) numArray1;
      sbyte[] numArray2 = (sbyte[]) new Pbt6Class().PBTMainSA2(configFileName, ref dataFileInfo, 3U);
      if (numArray2 != null && numArray2.GetLength(0) > 0)
      {
        Array.Resize<byte>(ref srecOut, numArray2.GetLength(0));
        for (int index = 0; index < numArray2.GetLength(0); ++index)
          srecOut[index] = Convert.ToByte(numArray2[index]);
      }
    }
  }

  internal bool prependS0Line(
    ref byte[] buffer,
    string fixedStr,
    string partPsdtId,
    string optionalUsageStr,
    string version)
  {
    bool flag = false;
    try
    {
      string s = fixedStr + partPsdtId + version + optionalUsageStr;
      char[] pSRecLine = new char[8 + (fixedStr.Length + partPsdtId.Length + version.Length + optionalUsageStr.Length) * 2 + 2 + 2];
      ASCIIEncoding asciiEncoding = new ASCIIEncoding();
      byte[] bytes1 = asciiEncoding.GetBytes(s);
      this.BuildS0Line(ref pSRecLine, bytes1, 0U, (uint) bytes1.Length, 0U);
      if (pSRecLine.Length > 0)
      {
        byte[] bytes2 = asciiEncoding.GetBytes(pSRecLine);
        byte[] numArray = new byte[buffer.Length];
        Array.Copy((Array) buffer, (Array) numArray, numArray.Length);
        Array.Resize<byte>(ref buffer, buffer.Length + bytes2.Length);
        Array.Copy((Array) bytes2, (Array) buffer, bytes2.Length);
        Array.Copy((Array) numArray, 0, (Array) buffer, bytes2.Length, numArray.Length);
        flag = true;
      }
    }
    catch (Exception ex)
    {
      flag = false;
    }
    return flag;
  }

  private void BuildS0Line(
    ref char[] pSRecLine,
    byte[] data,
    uint dataIndex,
    uint dataLen,
    uint address)
  {
    byte num1 = 0;
    uint num2 = 0;
    try
    {
      char[] chArray1 = pSRecLine;
      int num3 = (int) num2;
      uint num4 = (uint) (num3 + 1);
      uint index1 = (uint) num3;
      chArray1[(IntPtr) index1] = 'S';
      char[] chArray2 = pSRecLine;
      int num5 = (int) num4;
      uint pos1 = (uint) (num5 + 1);
      uint index2 = (uint) num5;
      chArray2[(IntPtr) index2] = '0';
      byte byteToWrite1 = (byte) (2 + (int) dataLen + 1);
      byte num6 = (byte) ((uint) num1 + (uint) byteToWrite1);
      this.WriteSRByte(ref pSRecLine, pos1, byteToWrite1, (byte) 16 /*0x10*/);
      uint pos2 = pos1 + 2U;
      for (int index3 = 0; index3 < 2; ++index3)
      {
        byte byteToWrite2 = (byte) (address << index3 * 8 >> 8);
        num6 += byteToWrite2;
        this.WriteSRByte(ref pSRecLine, pos2, byteToWrite2, (byte) 16 /*0x10*/);
        pos2 += 2U;
      }
      for (int index4 = 0; (long) index4 < (long) dataLen; ++index4)
      {
        byte byteToWrite3 = data[(long) dataIndex + (long) index4];
        num6 += byteToWrite3;
        this.WriteSRByte(ref pSRecLine, pos2, byteToWrite3, (byte) 16 /*0x10*/);
        pos2 += 2U;
      }
      byte byteToWrite4 = ~num6;
      this.WriteSRByte(ref pSRecLine, pos2, byteToWrite4, (byte) 16 /*0x10*/);
      uint num7 = pos2 + 2U;
      char[] chArray3 = pSRecLine;
      int num8 = (int) num7;
      uint index5 = (uint) (num8 + 1);
      uint index6 = (uint) num8;
      chArray3[(IntPtr) index6] = '\r';
      pSRecLine[(IntPtr) index5] = '\n';
    }
    catch (IndexOutOfRangeException ex)
    {
      Array.Clear((Array) pSRecLine, 0, pSRecLine.Length);
      Array.Resize<char>(ref pSRecLine, 0);
    }
  }
}

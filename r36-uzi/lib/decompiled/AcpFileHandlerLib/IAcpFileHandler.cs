// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.IAcpFileHandler
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using Motorola.Common.BinarySerializer;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace AcpFileHandlerLib;

public interface IAcpFileHandler
{
  void WriteFileSafely<T>(T writeBuffer, AcpFileHeader fileHeader, string filePath, bool encrypt);

  void WriteFile(
    byte[] writeBuffer,
    string filePath,
    bool encrypt,
    FileMode fileMode,
    string mutexName);

  void ReadFileSafely<T>(
    out T readBuffer,
    out AcpFileHeader fileHeader,
    string filePath,
    bool decrypt,
    IEnumerable<BinarySerializerTypeInfo> allowedTypes);

  void ReadFile(out byte[] readBuffer, string filePath, bool decrypt, string mutexName = null);

  AcpFileHeader ReadHeaderSafely(string filePath);

  byte[] EncodeStringToByteArray(string str);

  string DecodeByteArrayToString(byte[] bytes);
}

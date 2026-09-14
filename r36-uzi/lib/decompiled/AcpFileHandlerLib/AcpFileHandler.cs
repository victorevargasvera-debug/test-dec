// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpFileHandler
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using AcpCryptoLib;
using AcpExceptionLib;
using Motorola.Common.BinarySerializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

#nullable disable
namespace AcpFileHandlerLib;

public class AcpFileHandler : IAcpFileHandler
{
  private readonly IEnumerable<BinarySerializerTypeInfo> _allowedCodeplugTypes;
  private static readonly HashSet<BinarySerializerTypeInfo> _allowedHeaderTypes = new HashSet<BinarySerializerTypeInfo>()
  {
    new BinarySerializerTypeInfo("AcpFileHandlerLib.AcpFileHeader", "AcpFileHandlerLib")
  };
  private static JsonSerializerSettings _headerOptions = new JsonSerializerSettings()
  {
    Formatting = Formatting.Indented,
    SerializationBinder = (ISerializationBinder) AcpFileHeaderSecureSerializationBinder.Instance
  };
  private static JsonSerializerSettings _codeplugOptions = new JsonSerializerSettings()
  {
    Formatting = Formatting.Indented,
    TypeNameHandling = TypeNameHandling.Objects,
    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
    PreserveReferencesHandling = PreserveReferencesHandling.None,
    ContractResolver = (IContractResolver) ConverterContractResolver.Instance
  };

  public AcpFileHandler()
  {
  }

  public AcpFileHandler(
    IEnumerable<BinarySerializerTypeInfo> allowedCodeplugTypes)
  {
    this._allowedCodeplugTypes = allowedCodeplugTypes;
    AcpFileHandler._codeplugOptions.SerializationBinder = (ISerializationBinder) new McFileSecureSerializationBinder(allowedCodeplugTypes);
  }

  public void WriteFileSafely<T>(
    T writeBuffer,
    AcpFileHeader fileHeader,
    string filePath,
    bool encrypt)
  {
    if ((object) writeBuffer == null)
      throw AcpException.CreateNewException("FH_Internal_Error", "writeBuffer cannot be null.", (AcpException.SeverityLevel) 0, (Exception) null);
    try
    {
      byte[] bytes = Encoding.UTF8.GetBytes(ACPFileCopyRightInfomation.Instance.CopyRightInformation);
      using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
      {
        fileStream.Write(bytes, 0, bytes.Length);
        using (MemoryStream memoryStream = new MemoryStream())
        {
          AcpFileHandler.ObjectToJsonStreamCompressed((Stream) memoryStream, (object) fileHeader, AcpFileHandler._headerOptions);
          if (Environment.OSVersion.Platform != PlatformID.Unix && AcpFileHandler.IsDiskStorageFull(filePath, memoryStream.Length))
            throw AcpException.CreateNewException("FH_Write_Disk_Full", "Not enough free space on the disk", (AcpException.SeverityLevel) 0, (Exception) null);
          int position = (int) memoryStream.Position;
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream, Encoding.UTF8, true))
            binaryWriter.Write(position);
          memoryStream.WriteTo((Stream) fileStream);
          if (encrypt)
          {
            using (AcpCryptoStream crypto = new AcpCryptoStream())
              AcpFileHandler.ObjectToJsonStreamCompressed((Stream) AcpFileHandler.Encrypt(fileStream, crypto), (object) writeBuffer, AcpFileHandler._codeplugOptions);
          }
          else
            AcpFileHandler.ObjectToJsonStreamCompressed((Stream) fileStream, (object) writeBuffer, AcpFileHandler._codeplugOptions);
        }
      }
    }
    catch (UnauthorizedAccessException ex)
    {
      throw AcpException.CreateNewException("FH_Write_Access_Denied", "Cannot write to read-only file, or access denied when writing file", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (IOException ex)
    {
      throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (JsonException ex)
    {
      throw AcpException.CreateNewException("FH_Write_File_Fail", "Error happen while serializing to JSON, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (Exception ex)
    {
      if (!(ex is AcpException))
        throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
      throw;
    }
  }

  public void WriteFile(
    byte[] writeBuffer,
    string filePath,
    bool encrypt,
    FileMode fileMode,
    string mutexName = null)
  {
    if (writeBuffer == null)
      throw AcpException.CreateNewException("FH_Internal_Error", "writeBuffer cannot be null.", (AcpException.SeverityLevel) 0, (Exception) null);
    if (AcpFileHandler.IsDiskStorageFull(filePath, (long) writeBuffer.Length) && mutexName == null)
      throw AcpException.CreateNewException("FH_Write_Disk_Full", "Not enough free space on the disk", (AcpException.SeverityLevel) 0, (Exception) null);
    try
    {
      Mutex mutex = (Mutex) null;
      using (Stream output = mutexName == null ? (Stream) new FileStream(filePath, fileMode, FileAccess.Write) : this.CreateMemoryMappedFileStream(filePath, mutexName, out mutex))
      {
        if (output == null)
          throw AcpException.CreateNewException("FH_Internal_Error", "Stream object could not be created", (AcpException.SeverityLevel) 0, (Exception) null);
        using (BinaryWriter binaryWriter = new BinaryWriter(output, Encoding.UTF8))
        {
          byte[] buffer = writeBuffer;
          if (encrypt && fileMode != FileMode.Append)
            buffer = AcpFileHandler.Encrypt(writeBuffer);
          if (mutexName != null)
          {
            binaryWriter.Write(buffer.Length);
            binaryWriter.Write(buffer);
          }
          else
            binaryWriter.Write(buffer);
        }
        mutex?.ReleaseMutex();
      }
    }
    catch (UnauthorizedAccessException ex)
    {
      throw AcpException.CreateNewException("FH_Write_Access_Denied", "Cannot write to read-only file, or access denied when writing file", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (IOException ex)
    {
      throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (Exception ex)
    {
      if (!(ex is AcpException))
        throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
      throw;
    }
  }

  public void ReadFileSafely<T>(
    out T readBuffer,
    out AcpFileHeader fileHeader,
    string filePath,
    bool decrypt,
    IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    fileHeader = (AcpFileHeader) null;
    readBuffer = default (T);
    if (!File.Exists(filePath))
      throw AcpException.CreateNewException("FH_File_Not_Found", "The file does not exist.", (AcpException.SeverityLevel) 0, (Exception) null);
    try
    {
      try
      {
        this.ReadJsonCodeplugData<T>(out readBuffer, filePath, out fileHeader, decrypt, allowedTypes);
      }
      catch (Exception ex)
      {
        this.ReadBinaryCodeplugData<T>(out readBuffer, filePath, out fileHeader, decrypt, allowedTypes);
      }
    }
    catch (SerializationException ex)
    {
      throw AcpException.CreateNewException("FH_Header_Read_Fail", "Deserialization fail due to corrupted or invalid file header format.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw AcpException.CreateNewException("FH_File_Missing_Header", "The file does not contain file header", (AcpException.SeverityLevel) 0, (Exception) null);
    }
    catch (IOException ex)
    {
      throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (Exception ex)
    {
      if (!(ex is AcpException))
        throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
      throw;
    }
  }

  public void ReadFile(out byte[] readBuffer, string filePath, bool decrypt, string mutexName = null)
  {
    readBuffer = (byte[]) null;
    if (mutexName != null)
    {
      Mutex mutex;
      using (Stream mappedFileStream = this.CreateMemoryMappedFileStream(filePath, mutexName, out mutex))
      {
        AcpFileHandler.ReadData(out readBuffer, mappedFileStream, decrypt);
        mutex.ReleaseMutex();
      }
    }
    else
    {
      if (!File.Exists(filePath))
        throw AcpException.CreateNewException("FH_File_Not_Found", "The file does not exist.", (AcpException.SeverityLevel) 0, (Exception) null);
      try
      {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
          if (fileStream == null)
            throw AcpException.CreateNewException("FH_Internal_Error", "FileStream object could not be created", (AcpException.SeverityLevel) 0, (Exception) null);
          AcpFileHandler.ReadData(out readBuffer, (Stream) fileStream, decrypt);
        }
      }
      catch (IOException ex)
      {
        throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
      }
      catch (Exception ex)
      {
        if (!(ex is AcpException))
          throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
        throw;
      }
    }
  }

  public AcpFileHeader ReadHeaderSafely(string filePath)
  {
    byte[] fileBytesWithoutCopyRights = File.Exists(filePath) ? ACPFileCopyRightInfomation.Instance.SkipCopyRightInfoIfHas(File.ReadAllBytes(filePath)) : throw AcpException.CreateNewException("FH_File_Not_Found", "The file does not exist.", (AcpException.SeverityLevel) 0, (Exception) null);
    try
    {
      try
      {
        return this.ReadJsonHeaderFromBytes(fileBytesWithoutCopyRights);
      }
      catch (Exception ex)
      {
        return this.ReadHeaderFromBytes(fileBytesWithoutCopyRights);
      }
    }
    catch (SerializationException ex)
    {
      throw AcpException.CreateNewException("FH_Header_Read_Fail", "Deserialization fail due to corrupted or invalid file header format.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw AcpException.CreateNewException("FH_File_Missing_Header", "The deserialized data type doesn't match the AcpFileHeader type.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (IOException ex)
    {
      throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (Exception ex)
    {
      throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
    }
  }

  private static BinarySerializerVerificationResult Verify(
    byte[] bytesToVerify,
    IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    BinarySerializerVerificationResult verificationResult = new Motorola.Common.BinarySerializer.BinarySerializer().Parse(bytesToVerify).Verify(allowedTypes);
    return !verificationResult.CheckFailed ? verificationResult : throw new SerializationException("File might be corrupted");
  }

  public byte[] EncodeStringToByteArray(string str) => new UTF8Encoding().GetBytes(str);

  public string DecodeByteArrayToString(byte[] bytes) => new UTF8Encoding().GetString(bytes);

  public static CryptoStream Encrypt(FileStream fs, AcpCryptoStream crypto)
  {
    try
    {
      return (CryptoStream) crypto.GetWriter((Stream) fs);
    }
    catch (Exception ex)
    {
      throw AcpException.CreateNewException("FH_File_Encryption_Fail", "Encryption fail", (AcpException.SeverityLevel) 0, ex);
    }
  }

  public static byte[] Encrypt(byte[] plainData)
  {
    try
    {
      return new AcpEncryptDecrypt().Encrypt(plainData);
    }
    catch (Exception ex)
    {
      throw AcpException.CreateNewException("FH_File_Encryption_Fail", "Encryption fail", (AcpException.SeverityLevel) 0, ex);
    }
  }

  public static CryptoStream Decrypt(FileStream fs, AcpCryptoStream crypto)
  {
    try
    {
      return (CryptoStream) crypto.GetReader((Stream) fs);
    }
    catch (Exception ex)
    {
      throw AcpException.CreateNewException("FH_File_Decryption_Fail", "Decryption fail", (AcpException.SeverityLevel) 0, ex);
    }
  }

  public static byte[] Decrypt(byte[] encryptedData)
  {
    try
    {
      return new AcpEncryptDecrypt().Decrypt(encryptedData);
    }
    catch (Exception ex)
    {
      throw AcpException.CreateNewException("FH_File_Decryption_Fail", "Decryption fail", (AcpException.SeverityLevel) 0, ex);
    }
  }

  public static bool IsDiskStorageFull(string filePath, long dataSize)
  {
    uint lpSectorsPerCluster;
    uint lpBytesPerSector;
    uint lpNumberOfFreeClusters;
    NativeMethods.GetDiskFreeSpace(Directory.GetDirectoryRoot(filePath), out lpSectorsPerCluster, out lpBytesPerSector, out lpNumberOfFreeClusters, out uint _);
    return (long) lpNumberOfFreeClusters * (long) lpSectorsPerCluster * (long) lpBytesPerSector < dataSize + 256L /*0x0100*/;
  }

  private void ReadJsonCodeplugData<T>(
    out T readBuffer,
    string filePath,
    out AcpFileHeader fileHeader,
    bool decrypt,
    IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
      ACPFileCopyRightInfomation.Instance.SkipCopyRightInfoIfHas((Stream) fileStream);
      using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream, Encoding.UTF8, true))
      {
        int count = binaryReader.ReadInt32();
        using (MemoryStream memoryStream = new MemoryStream(binaryReader.ReadBytes(count)))
        {
          fileHeader = AcpFileHandler.JsonStreamToObjectDecompressed<AcpFileHeader>((Stream) memoryStream, AcpFileHandler._headerOptions);
          if (decrypt)
          {
            using (AcpCryptoStream crypto = new AcpCryptoStream())
              readBuffer = AcpFileHandler.JsonStreamToObjectDecompressed<T>((Stream) AcpFileHandler.Decrypt(fileStream, crypto), AcpFileHandler._codeplugOptions);
          }
          else
            readBuffer = AcpFileHandler.JsonStreamToObjectDecompressed<T>((Stream) fileStream, AcpFileHandler._codeplugOptions);
        }
      }
    }
  }

  private void ReadBinaryCodeplugData<T>(
    out T readBuffer,
    string filePath,
    out AcpFileHeader fileHeader,
    bool decrypt,
    IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    try
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        if (fs == null)
          throw AcpException.CreateNewException("FH_Internal_Error", "FileStream object could not be created", (AcpException.SeverityLevel) 0, (Exception) null);
        ACPFileCopyRightInfomation.Instance.SkipCopyRightInfoIfHas((Stream) fs);
        fileHeader = AcpFileHandler.BinaryFormatterStreamToObject<AcpFileHeader>((Stream) fs, (IEnumerable<BinarySerializerTypeInfo>) AcpFileHandler._allowedHeaderTypes);
        if (decrypt)
        {
          using (AcpCryptoStream crypto = new AcpCryptoStream())
            readBuffer = AcpFileHandler.BinaryFormatterStreamToObject<T>((Stream) AcpFileHandler.Decrypt(fs, crypto), allowedTypes);
        }
        else
          readBuffer = AcpFileHandler.BinaryFormatterStreamToObject<T>((Stream) fs, allowedTypes);
      }
    }
    catch (SerializationException ex)
    {
      throw AcpException.CreateNewException("FH_Header_Read_Fail", "Deserialization fail due to corrupted or invalid file format.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw AcpException.CreateNewException("FH_File_Missing_Header", "The file does not contain file header", (AcpException.SeverityLevel) 0, (Exception) null);
    }
    catch (IOException ex)
    {
      throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (Exception ex)
    {
      if (!(ex is AcpException))
        throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
      throw;
    }
  }

  private AcpFileHeader ReadHeaderFromBytes(byte[] fileBytesWithoutCopyRights)
  {
    try
    {
      using (MemoryStream memoryStream = new MemoryStream(fileBytesWithoutCopyRights))
        return AcpFileHandler.BinaryFormatterStreamToObject<AcpFileHeader>((Stream) memoryStream, (IEnumerable<BinarySerializerTypeInfo>) AcpFileHandler._allowedHeaderTypes);
    }
    catch (SerializationException ex)
    {
      throw AcpException.CreateNewException("FH_Header_Read_Fail", "Deserialization fail due to corrupted or invalid file header format.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw AcpException.CreateNewException("FH_File_Missing_Header", "The deserialized data type doesn't match the AcpFileHeader type.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (IOException ex)
    {
      throw AcpException.CreateNewException("FH_Open_IO_Error", "I/O error occurs, See more information in the inner exception.", (AcpException.SeverityLevel) 0, (Exception) ex);
    }
    catch (Exception ex)
    {
      throw AcpException.CreateNewException("FH_Internal_Error", "See more information in the inner exception.", (AcpException.SeverityLevel) 0, ex);
    }
  }

  private AcpFileHeader ReadJsonHeaderFromBytes(byte[] fileBytesWithoutCopyRights)
  {
    using (MemoryStream input = new MemoryStream(fileBytesWithoutCopyRights))
    {
      using (BinaryReader binaryReader = new BinaryReader((Stream) input, Encoding.UTF8, true))
      {
        int count = binaryReader.ReadInt32();
        using (MemoryStream memoryStream = new MemoryStream(binaryReader.ReadBytes(count)))
          return AcpFileHandler.JsonStreamToObjectDecompressed<AcpFileHeader>((Stream) memoryStream, AcpFileHandler._headerOptions);
      }
    }
  }

  private static void ReadData(out byte[] readBuffer, Stream stream, bool decrypt)
  {
    using (BinaryReader binaryReader = new BinaryReader(stream, Encoding.UTF8))
    {
      if (binaryReader == null)
        throw AcpException.CreateNewException("FH_Internal_Error", "BinaryReader object could not be created", (AcpException.SeverityLevel) 0, (Exception) null);
      byte[] encryptedData;
      if (stream is MemoryMappedViewStream)
      {
        int count = binaryReader.ReadInt32();
        encryptedData = binaryReader.ReadBytes(count);
        if (encryptedData.Length != count)
          throw AcpException.CreateNewException("FH_Read_File_Fail", "Number of bytes read is not the same as expected.", (AcpException.SeverityLevel) 0, (Exception) null);
      }
      else
      {
        long count = stream.Length - stream.Position;
        encryptedData = binaryReader.ReadBytes((int) count);
        if ((long) encryptedData.Length != count)
          throw AcpException.CreateNewException("FH_Read_File_Fail", "Number of bytes read is not the same as expected.", (AcpException.SeverityLevel) 0, (Exception) null);
      }
      readBuffer = decrypt ? AcpFileHandler.Decrypt(encryptedData) : encryptedData;
    }
  }

  private static void ReadAllBytes(Stream fs, byte[] fileBytes, int numBytesToRead)
  {
    int offset = 0;
    int num;
    while ((num = fs.Read(fileBytes, offset, numBytesToRead - offset)) > 0)
      offset += num;
  }

  private static void ObjectToJsonStreamCompressed(
    Stream stream,
    object obj,
    JsonSerializerSettings options)
  {
    using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Compress, true))
    {
      using (StreamWriter streamWriter = new StreamWriter((Stream) gzipStream, Encoding.UTF8, 128 /*0x80*/, true))
      {
        using (JsonTextWriter jsonTextWriter = new JsonTextWriter((TextWriter) streamWriter))
          JsonSerializer.Create(options).Serialize((JsonWriter) jsonTextWriter, obj);
      }
    }
  }

  private static T JsonStreamToObjectDecompressed<T>(Stream stream, JsonSerializerSettings options)
  {
    using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress, true))
    {
      using (StreamReader reader1 = new StreamReader((Stream) gzipStream))
      {
        using (JsonTextReader reader2 = new JsonTextReader((TextReader) reader1))
          return JsonSerializer.Create(options).Deserialize<T>((JsonReader) reader2);
      }
    }
  }

  public static T BinaryFormatterStreamToObject<T>(
    Stream stream,
    IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    using (BinaryReader stream1 = new BinaryReader(stream, Encoding.UTF8, true))
      return (T) new Motorola.Common.BinarySerializer.BinarySerializer().Parse(stream1).Deserialize(allowedTypes);
  }

  private Stream CreateMemoryMappedFileStream(string filePath, string mutexName, out Mutex mutex)
  {
    MemoryMappedFile memoryMappedFile = MemoryMappedFile.OpenExisting(filePath);
    mutex = Mutex.OpenExisting(mutexName);
    mutex.WaitOne();
    return (Stream) memoryMappedFile.CreateViewStream(0L, 0L);
  }
}

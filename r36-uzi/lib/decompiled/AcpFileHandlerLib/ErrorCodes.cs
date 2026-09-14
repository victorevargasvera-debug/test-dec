// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.ErrorCodes
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

#nullable disable
namespace AcpFileHandlerLib;

internal static class ErrorCodes
{
  internal const string FileNotFoundErrorCode = "FH_File_Not_Found";
  internal const string HeaderReadFailErrorCode = "FH_Header_Read_Fail";
  internal const string MissingHeaderErrorCode = "FH_File_Missing_Header";
  internal const string InternalErrorErrorCode = "FH_Internal_Error";
  internal const string OpenIOErrorErrorCode = "FH_Open_IO_Error";
  internal const string OutOfMemoryErrorCode = "FH_Out_Of_Memory";
  internal const string ReadFileFailErrorCode = "FH_Read_File_Fail";
  internal const string WriteAccessDeniedErrorCode = "FH_Write_Access_Denied";
  internal const string WriteDiskFullErrorCode = "FH_Write_Disk_Full";
  internal const string WriteFileFailErrorCode = "FH_Write_File_Fail";
  internal const string FileTypeNotValidErrorCode = "FH_Type_Not_Valid";
  internal const string FileEncryptionFailErrorCode = "FH_File_Encryption_Fail";
  internal const string FileDecryptionFailErrorCode = "FH_File_Decryption_Fail";
  internal const string FileDialogOpenFailErrorCode = "FH_Show_Dialog_Fail";
}

// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpExceptionNumbers
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace AcpFileHandlerLib;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class AcpExceptionNumbers
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal AcpExceptionNumbers()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (AcpExceptionNumbers.resourceMan == null)
        AcpExceptionNumbers.resourceMan = new ResourceManager("AcpFileHandlerLib.AcpExceptionNumbers", typeof (AcpExceptionNumbers).Assembly);
      return AcpExceptionNumbers.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => AcpExceptionNumbers.resourceCulture;
    set => AcpExceptionNumbers.resourceCulture = value;
  }

  internal static string FH_File_Decryption_Fail
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_File_Decryption_Fail), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_File_Encryption_Fail
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_File_Encryption_Fail), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_File_Missing_Header
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_File_Missing_Header), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_File_Not_Found
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_File_Not_Found), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Header_Read_Fail
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Header_Read_Fail), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Internal_Error
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Internal_Error), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Open_IO_Error
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Open_IO_Error), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Out_Of_Memory
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Out_Of_Memory), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Read_File_Fail
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Read_File_Fail), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Show_Dialog_Fail
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Show_Dialog_Fail), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Type_Not_Valid
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Type_Not_Valid), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Write_Access_Denied
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Write_Access_Denied), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Write_Disk_Full
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Write_Disk_Full), AcpExceptionNumbers.resourceCulture);
    }
  }

  internal static string FH_Write_File_Fail
  {
    get
    {
      return AcpExceptionNumbers.ResourceManager.GetString(nameof (FH_Write_File_Fail), AcpExceptionNumbers.resourceCulture);
    }
  }
}

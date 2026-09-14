// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CloudNative.CloudNativeUtility
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpFileHandlerLib;
using CodeplugExchangeLibrary;
using CommonResources;
using Microsoft.Win32;
using Motorola.CommonCPS.RadioManagement.CommonBase.Utility;
using Newtonsoft.Json;
using SpecialFeatures.CxfHandler;
using SpecialFeatures.Flashport.FlashRadio;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace MackinawCPS.CloudNative;

public class CloudNativeUtility
{
  private const string FileUrlSuffix = "/file";
  private const string PublishUrlSuffix = "/publish";
  private readonly HttpClient _httpClient;

  public CloudNativeUtility(HttpClient httpClient) => this._httpClient = httpClient;

  public void ParseCloudNativeParameters(string[] cmdArgs)
  {
    try
    {
      CloudNativeParameters.RcCpsBridgeGetSessionUrl = Encoding.UTF8.GetString(Convert.FromBase64String(cmdArgs[2].Trim().Split(':')[1].Trim('/')));
      if (string.IsNullOrEmpty(CloudNativeParameters.RcCpsBridgeGetSessionUrl))
        return;
      CloudNativeParameters.CloudNativeHeaders = this.GetHead();
      if (!this.ValidateCloudNativeHeaders())
      {
        int num = (int) MessageBox.Show(AppResources.RcCpsEditFailed);
        Environment.Exit(0);
      }
      CloudNativeParameters.CloudNativeJobWrapper = this.GetParameters();
      CloudNativeParameters.RcCpsBridgeGetFileUrl = CloudNativeParameters.RcCpsBridgeGetSessionUrl + "/file";
      CloudNativeParameters.RcCpsBridgePostSessionUrl = CloudNativeParameters.RcCpsBridgeGetSessionUrl + "/publish";
      CloudNativeParameters.CloudNativeCodeplugBytes = this.DownloadCloudNativeCodeplugBytes();
    }
    catch
    {
      int num = (int) MessageBox.Show(AppResources.RcCpsEditFailed);
      Environment.Exit(0);
    }
  }

  public CloudNativeHeaders GetHead()
  {
    HttpResponseMessage result = this._httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, CloudNativeParameters.RcCpsBridgeGetSessionUrl)).Result;
    return result.IsSuccessStatusCode ? new CloudNativeHeaders(result.Headers) : throw new Exception();
  }

  public CloudNativeJobWrapper GetParameters()
  {
    HttpResponseMessage result = this._httpClient.GetAsync($"{CloudNativeParameters.RcCpsBridgeGetSessionUrl}?processId={Process.GetCurrentProcess().Id}").Result;
    if (!result.IsSuccessStatusCode)
      throw new Exception();
    CloudNativeJobWrapper parameters = JsonConvert.DeserializeObject<CloudNativeJobWrapper>(result.Content.ReadAsStringAsync().Result);
    parameters.CxfPassword = CloudNativeCipher.Decrypt(parameters.CxfPassword);
    return parameters;
  }

  public byte[] DownloadCloudNativeCodeplugBytes()
  {
    HttpResponseMessage result = this._httpClient.GetAsync(CloudNativeParameters.RcCpsBridgeGetFileUrl).Result;
    if (!result.IsSuccessStatusCode)
      throw new Exception();
    return result.Content.ReadAsByteArrayAsync().Result;
  }

  public void OpenCodeplugForCloudNativeMode()
  {
    string empty = string.Empty;
    int num = this.OpenCodeplug(ref empty) ? 1 : 0;
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    if (num != 0)
      mainWindow.HandleInValidFieldBackwardCompatibilityForMCFile();
    mainWindow.WindowMain_AllowDrop((object) null, (MouseEventArgs) null);
  }

  private bool OpenCodeplug(ref string errorMsg)
  {
    Cursor overrideCursor = Mouse.OverrideCursor;
    bool fileOpened = false;
    MemoryCleaner.CleanGarbageFromMemory();
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    try
    {
      Mouse.OverrideCursor = Cursors.Wait;
      MemoryStream memoryStream = new MemoryStream();
      memoryStream.Write(CloudNativeParameters.CloudNativeCodeplugBytes, 0, CloudNativeParameters.CloudNativeCodeplugBytes.Length);
      using (CodeplugExchangeFile cxfFile = CxfFileHandler.OpenStreamAndValidatePassword((Stream) memoryStream, CloudNativeParameters.CloudNativeJobWrapper.CxfPassword))
      {
        if (cxfFile != null && cxfFile.IsFileValid)
        {
          mainWindow.InitCodeplugOpen();
          fileOpened = CxfFileHandler.OpenCodeplugFile(cxfFile.GetCodeplugBytes());
          CxfFileHandler.AssignFirmwareVersionToRadioInfo(cxfFile);
        }
        if (fileOpened)
        {
          mainWindow.IsCxfEditingMode = true;
          CodeplugVersionUpdater.SetCodeplugVersion();
          mainWindow.ResolveUnpack();
        }
        Mouse.OverrideCursor = overrideCursor;
        mainWindow.HandleFileOpening((string) null, ref errorMsg, false, false, ref fileOpened, mainWindow, new AcpFileHeader());
      }
    }
    catch (Exception ex)
    {
      WindowMain.HandleException(out errorMsg, false, out fileOpened, ex);
    }
    finally
    {
      mainWindow.HandleFinally(overrideCursor, (string) null);
    }
    mainWindow.WindowMain_AllowDrop((object) null, (MouseEventArgs) null);
    return fileOpened;
  }

  public async Task<bool> PostResultAsync(string encryptedPassword)
  {
    bool successStatusCode;
    using (MultipartFormDataContent content1 = new MultipartFormDataContent())
    {
      StringContent content2 = new StringContent(JsonConvert.SerializeObject((object) new CloudNativePayload()
      {
        CxfPassword = encryptedPassword,
        TemplateName = CloudNativeParameters.CloudNativeJobWrapper.NewTemplateName
      }));
      content1.Add((HttpContent) content2, "publishRequest");
      StreamContent content3 = new StreamContent((Stream) CloudNativeParameters.CloudNativeCodeplugMemoryStream);
      content3.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
      content1.Add((HttpContent) content3, "newCxfFile", "newCxfFile.cxf");
      HttpResponseMessage result;
      try
      {
        result = this._httpClient.PostAsync(CloudNativeParameters.RcCpsBridgePostSessionUrl, (HttpContent) content1).Result;
      }
      catch
      {
        throw new Exception();
      }
      successStatusCode = result.IsSuccessStatusCode;
    }
    return successStatusCode;
  }

  public bool SaveCodeplugBytes(string modelNumber, string codeplugVersion, string firmwareVersion)
  {
    return SaveCxfHandler.SaveCodeplugBytes(new NetworkCredential("", CloudNativeParameters.CloudNativeJobWrapper.CxfPassword).SecurePassword, modelNumber, codeplugVersion, firmwareVersion, out CloudNativeParameters.CloudNativeCodeplugMemoryStream);
  }

  private bool ValidateCloudNativeHeaders()
  {
    string str = (string) null;
    string installationPath = this.FindRcCpsBridgeInstallationPath();
    if (installationPath == null)
      return false;
    byte[] buffer = System.IO.File.ReadAllBytes(installationPath.Trim('"'));
    using (SHA384 shA384 = SHA384.Create())
      str = Convert.ToBase64String(shA384.ComputeHash(buffer));
    return str.Equals(CloudNativeParameters.CloudNativeHeaders.BridgeHash);
  }

  private string FindRcCpsBridgeInstallationPath()
  {
    using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
    {
      using (RegistryKey registryKey2 = registryKey1.OpenSubKey("SYSTEM\\ControlSet001\\Services\\RC-CPS Bridge", false))
        return registryKey2 == null || registryKey2.GetValue("ImagePath") == null ? (string) null : registryKey2.GetValue("ImagePath").ToString().Replace(".exe", ".dll");
    }
  }
}

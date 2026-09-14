// Decompiled with JetBrains decompiler
// Type: AcpUI.CustomView.PageFunctionCustomViewWizard
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using AcpCommonResources;
using AcpFileHandlerLib;
using AcpUtility;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;

#nullable disable
namespace AcpUI.CustomView;

public partial class PageFunctionCustomViewWizard : 
  PageFunctionCustomViewWizardBase,
  IComponentConnector
{
  private CustomViewCreationInfo custViewInfo;
  internal RadioButton RadBtnPreDefinedView;
  internal AcpComboBox CmbBoxPreDefinedView;
  internal RadioButton RadBtnCustomView;
  internal AcpTextBox TxtBoxCustomView;
  internal AcpButton BtnCustomView;
  private bool _contentLoaded;

  public PageFunctionCustomViewWizard(CustomViewCreationInfo info)
  {
    this.InitializeComponent();
    this.RadBtnPreDefinedView.IsChecked = new bool?(true);
    this.custViewInfo = info;
    if (!Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith("ar"))
      return;
    this.TxtBoxCustomView.FlowDirection = FlowDirection.LeftToRight;
    this.TxtBoxCustomView.TextAlignment = TextAlignment.Right;
  }

  private void OnBrowse(object sender, RoutedEventArgs e)
  {
    AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
    acpOpenFileDialog.Filter = "Custom Views (*.xml)|*.xml";
    acpOpenFileDialog.MultiSelect = false;
    bool? nullable = acpOpenFileDialog.ShowDialog();
    bool flag = true;
    if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
      return;
    string fileName = acpOpenFileDialog.FileName;
    if (fileName == null)
      return;
    this.TxtBoxCustomView.Text = fileName;
  }

  private void OnOK(object sender, RoutedEventArgs e)
  {
    Window parent = (Window) this.Parent;
    this.custViewInfo.CustomViewFileName = this.TxtBoxCustomView.Text;
    string path = (string) null;
    bool? isChecked1 = this.RadBtnPreDefinedView.IsChecked;
    bool flag1 = true;
    if (isChecked1.GetValueOrDefault() == flag1 & isChecked1.HasValue)
    {
      this.custViewInfo.CustomViewFileBaseline = this.CmbBoxPreDefinedView.Text;
    }
    else
    {
      this.custViewInfo.CustomViewFileBaseline = AcpResources.Custom_View_File;
      path = this.TxtBoxCustomView.Text;
      if (string.IsNullOrEmpty(path))
      {
        int num = (int) MessageBox.Show(AcpResources.Enter_Full_Path_Custom_View_File);
        this.TxtBoxCustomView.Focus();
        return;
      }
      if (!path.EndsWith(".xml"))
      {
        int num = (int) MessageBox.Show(AcpResources.Not_Valid_Custom_View_File.AcpStringFormat((object) path));
        this.TxtBoxCustomView.Text = string.Empty;
        this.TxtBoxCustomView.Focus();
        return;
      }
      if (!File.Exists(path))
      {
        int num = (int) MessageBox.Show(AcpResources.Does_Not_Exist.AcpStringFormat((object) path));
        this.TxtBoxCustomView.Text = string.Empty;
        this.TxtBoxCustomView.Focus();
        return;
      }
    }
    if (this.custViewInfo.CustomViewFileBaseline == AcpResources.Basic_View)
      AppInfoManager.CustomViewBaseView = DifferentiatedUserViewType.Basic;
    else if (this.custViewInfo.CustomViewFileBaseline == AcpResources.Intermediate_View)
      AppInfoManager.CustomViewBaseView = DifferentiatedUserViewType.Intermediate;
    else if (this.custViewInfo.CustomViewFileBaseline == AcpResources.Full_View)
      AppInfoManager.CustomViewBaseView = DifferentiatedUserViewType.Full;
    else if (this.custViewInfo.CustomViewFileBaseline == AcpResources.Expert_View)
      AppInfoManager.CustomViewBaseView = DifferentiatedUserViewType.Secret;
    else if (this.custViewInfo.CustomViewFileBaseline == AcpResources.Custom_View_File)
      AppInfoManager.CustomViewBaseView = DifferentiatedUserViewType.Custom;
    if (AppInfoManager.DefaultDocument != null)
    {
      bool? isChecked2 = this.RadBtnPreDefinedView.IsChecked;
      bool flag2 = true;
      if (isChecked2.GetValueOrDefault() == flag2 & isChecked2.HasValue)
      {
        foreach (IAcpRecordset feature in AppInfoManager.DefaultDocument.Features)
        {
          feature.CalculateVisibility(true);
          this.SetCustomViewVisibility(feature);
        }
        parent.DialogResult = new bool?(true);
      }
      else
      {
        try
        {
          if (!AppInfoManager.DefaultDocument.ImportFromXml(this.TxtBoxCustomView.Text, XmlFileType.CustomView))
          {
            parent.DialogResult = new bool?(false);
            string message;
            if (AppInfoManager.IsCustomViewLanguageMismatch)
              message = AcpResources.Error_Reading_Custom_View_File_LangMismatch.AcpStringFormat((object) path);
            else
              message = AcpResources.Error_Reading_Custom_View_File.AcpStringFormat((object) path);
            AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, message);
          }
          else
            parent.DialogResult = new bool?(true);
        }
        catch (Exception ex)
        {
          AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, $"{AcpResources.Error_Reading_Custom_View_File.AcpStringFormat((object) path)} - {ex.Message}");
        }
      }
    }
    else
    {
      parent.DialogResult = new bool?(false);
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Error_Opening_Default_Codeplug);
    }
    this.OnReturn(new ReturnEventArgs<CustomViewCreationInfo>(this.custViewInfo));
    parent.Close();
  }

  private void OnRadBtnCheck(object sender, RoutedEventArgs e)
  {
    RadioButton radioButton = (RadioButton) sender;
    bool flag = radioButton.IsChecked.Value;
    if (radioButton.Name == "RadBtnPreDefinedView" & flag)
    {
      this.CmbBoxPreDefinedView.IsEnabled = true;
      this.TxtBoxCustomView.IsEnabled = false;
      this.BtnCustomView.IsEnabled = false;
    }
    else
    {
      if (!(radioButton.Name == "RadBtnCustomView" & flag))
        return;
      this.CmbBoxPreDefinedView.IsEnabled = false;
      this.TxtBoxCustomView.IsEnabled = true;
      this.BtnCustomView.IsEnabled = true;
    }
  }

  private void SetCustomViewVisibility(IAcpRecordset recset)
  {
    if (recset.Count == 0)
      return;
    foreach (IAcpFeatureSection featureSections in recset[0].FeatureSectionsCollection)
    {
      if (featureSections.HasEmbeddedRecset)
        this.SetCustomViewVisibility(featureSections.EmbeddedRecset);
      foreach (IAcpField fields in featureSections.FieldsCollection)
        fields.CustomViewVisibility = fields.DifferentiatedUserView <= AppInfoManager.CustomViewBaseView;
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/customview/pagefunctioncustomviewwizard.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.RadBtnPreDefinedView = (RadioButton) target;
        this.RadBtnPreDefinedView.Checked += new RoutedEventHandler(this.OnRadBtnCheck);
        break;
      case 2:
        this.CmbBoxPreDefinedView = (AcpComboBox) target;
        break;
      case 3:
        this.RadBtnCustomView = (RadioButton) target;
        this.RadBtnCustomView.Checked += new RoutedEventHandler(this.OnRadBtnCheck);
        break;
      case 4:
        this.TxtBoxCustomView = (AcpTextBox) target;
        break;
      case 5:
        this.BtnCustomView = (AcpButton) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}

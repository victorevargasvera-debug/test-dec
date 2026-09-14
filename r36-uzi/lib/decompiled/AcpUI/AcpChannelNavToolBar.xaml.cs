// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpChannelNavToolBar
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public partial class AcpChannelNavToolBar : UserControl, IComponentConnector
{
  private CollectionView myCollectionView;
  private AcpPageFeature myOwner;
  internal AcpLabel RecNavLbl;
  internal AcpButton RecNavBtnFirst;
  internal Image RecNavBtnFirstImage;
  internal AcpButton RecNavBtnPrevious;
  internal Image RecNavBtnPreviousImage;
  internal AcpButton RecNavBtnNext;
  internal Image RecNavBtnNextImage;
  internal AcpButton RecNavBtnLast;
  internal Image RecNavBtnLastImage;
  private bool _contentLoaded;

  public CollectionView MyCollectionView
  {
    get => this.myCollectionView;
    set => this.myCollectionView = value;
  }

  public AcpPageFeature MyOwner
  {
    get => this.myOwner;
    set => this.myOwner = value;
  }

  public virtual void OnClick(object sender, RoutedEventArgs e)
  {
    AcpButton acpButton = (AcpButton) sender;
    AcpChannelNavToolBar parent = (AcpChannelNavToolBar) ((FrameworkElement) acpButton.Parent).Parent;
    string name = acpButton.Name;
    CollectionView myCollectionView = parent.MyCollectionView;
    AcpPageFeature myOwner = parent.MyOwner;
    if (myCollectionView == null)
      return;
    int currentPosition = myCollectionView.CurrentPosition;
    IAcpFeatureNode currentItem = (IAcpFeatureNode) myCollectionView.CurrentItem;
    int count = myCollectionView.Count;
    if (currentItem != null)
    {
      switch (name)
      {
        case "RecNavBtnFirst":
          myCollectionView.MoveCurrentToFirst();
          myOwner.DataContext = myCollectionView.GetItemAt(0);
          this.RefreshChanDataSource(myCollectionView);
          break;
        case "RecNavBtnPrevious":
          myCollectionView.MoveCurrentToPrevious();
          if (myCollectionView.IsCurrentBeforeFirst)
            myCollectionView.MoveCurrentToNext();
          else
            this.RefreshChanDataSource(myCollectionView);
          if (currentPosition != 0)
          {
            myOwner.DataContext = myCollectionView.GetItemAt(currentPosition - 1);
            break;
          }
          break;
        case "RecNavBtnNext":
          myCollectionView.MoveCurrentToNext();
          if (myCollectionView.IsCurrentAfterLast)
            myCollectionView.MoveCurrentToPrevious();
          else
            this.RefreshChanDataSource(myCollectionView);
          if (currentPosition < count - 1)
          {
            myOwner.DataContext = myCollectionView.GetItemAt(currentPosition + 1);
            break;
          }
          break;
        case "RecNavBtnLast":
          myCollectionView.MoveCurrentToLast();
          myOwner.DataContext = myCollectionView.GetItemAt(count - 1);
          this.RefreshChanDataSource(myCollectionView);
          break;
      }
    }
    this.OnUpdateChanNavBar(myCollectionView);
  }

  private void RefreshChanDataSource(CollectionView collectionVw)
  {
    if (collectionVw == null || collectionVw.IsCurrentBeforeFirst || collectionVw.IsCurrentAfterLast)
      return;
    object currentItem = collectionVw.CurrentItem;
    collectionVw.MoveCurrentTo((object) null);
    collectionVw.MoveCurrentTo(currentItem);
  }

  public void OnUpdateChanNavBar(CollectionView myCollect)
  {
    int num = myCollect.CurrentPosition + 1;
    int count = myCollect.Count;
    this.RecNavLbl.Content = (object) $"{num.ToString()} of {count.ToString()}";
    this.RecNavLbl.VerticalAlignment = VerticalAlignment.Center;
    this.RecNavLbl.FontWeight = FontWeights.Black;
    this.RecNavLbl.FontWeight = FontWeights.Bold;
    this.RecNavLbl.FontSize = 12.0;
    this.RecNavLbl.Background = (Brush) Brushes.White;
  }

  public AcpChannelNavToolBar() => this.InitializeComponent();

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acpchannelnavtoolbar.xaml", UriKind.Relative));
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
        this.RecNavLbl = (AcpLabel) target;
        break;
      case 2:
        this.RecNavBtnFirst = (AcpButton) target;
        break;
      case 3:
        this.RecNavBtnFirstImage = (Image) target;
        break;
      case 4:
        this.RecNavBtnPrevious = (AcpButton) target;
        break;
      case 5:
        this.RecNavBtnPreviousImage = (Image) target;
        break;
      case 6:
        this.RecNavBtnNext = (AcpButton) target;
        break;
      case 7:
        this.RecNavBtnNextImage = (Image) target;
        break;
      case 8:
        this.RecNavBtnLast = (AcpButton) target;
        break;
      case 9:
        this.RecNavBtnLastImage = (Image) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}

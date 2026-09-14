// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.QatCustomizeButton
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class QatCustomizeButton : ButtonDropDown
{
  static QatCustomizeButton()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (QatCustomizeButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (QatCustomizeButton)));
  }

  public QatCustomizeButton() => Ribbon.SetIsCustomizable((FrameworkElement) this, false);

  public override void OnApplyTemplate()
  {
    if (this.Header == null)
    {
      Path path = new Path();
      path.SnapsToDevicePixels = true;
      PathGeometry pathGeometry = new PathGeometry();
      PathFigure pathFigure1 = new PathFigure(new System.Windows.Point(0.0, 3.0), (IEnumerable<PathSegment>) new PathSegment[2]
      {
        (PathSegment) new LineSegment(new System.Windows.Point(2.5, 6.0), false),
        (PathSegment) new LineSegment(new System.Windows.Point(5.0, 3.0), false)
      }, true);
      pathGeometry.Figures.Add(pathFigure1);
      PathFigure pathFigure2 = new PathFigure(new System.Windows.Point(0.0, 0.5), (IEnumerable<PathSegment>) new PathSegment[1]
      {
        (PathSegment) new LineSegment(new System.Windows.Point(5.0, 0.5), true)
      }, false);
      pathGeometry.Figures.Add(pathFigure2);
      path.Data = (Geometry) pathGeometry;
      Binding binding = new Binding("Foreground");
      binding.Source = (object) this;
      path.SetBinding(Shape.FillProperty, (BindingBase) binding);
      path.SetBinding(Shape.StrokeProperty, (BindingBase) binding);
      path.VerticalAlignment = VerticalAlignment.Center;
      path.HorizontalAlignment = HorizontalAlignment.Center;
      if (this.GetTemplateChild("PART_ButtonContent") is ContentPresenter templateChild)
        templateChild.Margin = new Thickness(2.0, 1.0, 2.0, 1.0);
      this.Header = (object) path;
    }
    if (this.Items.Count == 0)
    {
      Ribbon ribbon = this.GetRibbon();
      if (ribbon != null)
      {
        this.FontSize = ribbon.FontSize;
        TextBlock newItem1 = new TextBlock();
        newItem1.MinWidth = 190.0;
        newItem1.Text = ribbon.SystemText.QatCustomizeMenuLabel;
        newItem1.FontWeight = FontWeights.Bold;
        newItem1.Background = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.QatCustomizeMenuLabelBackground)) as Brush;
        newItem1.Padding = new Thickness(6.0, 2.0, 2.0, 2.0);
        this.Items.Add((object) newItem1);
        Separator newItem2 = new Separator();
        newItem2.Padding = new Thickness(0.0);
        newItem2.Margin = new Thickness(0.0);
        this.Items.Add((object) newItem2);
        ButtonDropDown buttonDropDown1 = new ButtonDropDown();
        Ribbon.SetIsCustomizable((FrameworkElement) buttonDropDown1, false);
        if (ribbon.IsQuickAccessToolbarBelow)
          buttonDropDown1.Header = (object) ribbon.SystemText.QatPlaceAboveRibbonText;
        else
          buttonDropDown1.Header = (object) ribbon.SystemText.QatPlaceBelowRibbonText;
        buttonDropDown1.Role = eButtonRole.MenuItem;
        buttonDropDown1.Name = Ribbon.SystemQatChangePlacementMenuItem;
        buttonDropDown1.Click += new RoutedEventHandler(this.QatChangePlacement);
        this.Items.Add((object) buttonDropDown1);
        this.Items.Add((object) new Separator());
        ButtonDropDown buttonDropDown2 = new ButtonDropDown();
        Ribbon.SetIsCustomizable((FrameworkElement) buttonDropDown2, false);
        buttonDropDown2.Role = eButtonRole.MenuItem;
        buttonDropDown2.Name = Ribbon.SystemQatMinMaxRibbonMenuItem;
        if (ribbon.IsMinimized)
          buttonDropDown2.Header = (object) ribbon.SystemText.MaximizeRibbonText;
        else
          buttonDropDown2.Header = (object) ribbon.SystemText.MinimizeRibbonText;
        buttonDropDown2.Click += new RoutedEventHandler(this.QatMinMaxRibbon);
        this.Items.Add((object) buttonDropDown2);
      }
    }
    base.OnApplyTemplate();
  }

  private void QatChangePlacement(object sender, RoutedEventArgs e)
  {
    this.GetRibbon()?.ChangeQatPlacement();
  }

  private void MoreCommandsClick(object sender, RoutedEventArgs e)
  {
    this.GetRibbon()?.OnQatDialogCustomize();
  }

  private void QatMinMaxRibbon(object sender, RoutedEventArgs e)
  {
    this.GetRibbon()?.ToggleRibbonMinimized();
  }

  protected override void OnPopupOpened(RoutedEventArgs e)
  {
    Ribbon ribbon = this.GetRibbon();
    if (ribbon != null)
    {
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is ButtonDropDown && ((FrameworkElement) obj).Name == Ribbon.SystemQatMinMaxRibbonMenuItem)
        {
          ButtonDropDown buttonDropDown = (ButtonDropDown) obj;
          if (ribbon.IsMinimized)
            buttonDropDown.Header = (object) ribbon.SystemText.MaximizeRibbonText;
          else
            buttonDropDown.Header = (object) ribbon.SystemText.MinimizeRibbonText;
        }
        else if (obj is ButtonDropDown && ((FrameworkElement) obj).Name == Ribbon.SystemQatChangePlacementMenuItem)
        {
          ButtonDropDown buttonDropDown = (ButtonDropDown) obj;
          if (ribbon.IsQuickAccessToolbarBelow)
            buttonDropDown.Header = (object) ribbon.SystemText.QatPlaceAboveRibbonText;
          else
            buttonDropDown.Header = (object) ribbon.SystemText.QatPlaceBelowRibbonText;
        }
      }
    }
    base.OnPopupOpened(e);
  }

  private Ribbon GetRibbon()
  {
    if (this.Parent is Ribbon)
      return this.Parent as Ribbon;
    DependencyObject ribbon = (DependencyObject) this;
    while (ribbon != null)
    {
      ribbon = !(ribbon is Visual) ? LogicalTreeHelper.GetParent(ribbon) : VisualTreeHelper.GetParent(ribbon);
      if (ribbon is Ribbon)
        return ribbon as Ribbon;
    }
    return (Ribbon) null;
  }
}

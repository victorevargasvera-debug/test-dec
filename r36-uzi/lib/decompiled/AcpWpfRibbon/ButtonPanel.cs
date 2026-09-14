// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class ButtonPanel : Panel
{
  public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (eButtonPanelOrientation), typeof (ButtonPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) eButtonPanelOrientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty FixedWidthProperty = DependencyProperty.Register(nameof (FixedWidth), typeof (double), typeof (ButtonPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty FixedHeightProperty = DependencyProperty.Register(nameof (FixedHeight), typeof (double), typeof (ButtonPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
  private bool m_AutoLayoutEnabled = true;
  private const double HeightClosenessFactor = 1.5;
  private int m_ButtonDropDownCount;
  private Size m_LastCalculatedSize;
  private Size m_RealCalculatedSize;
  private List<Gallery> m_Galleries = new List<Gallery>();

  static ButtonPanel()
  {
    KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof (ButtonPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Local));
    KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof (ButtonPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Local));
    Control.IsTabStopProperty.OverrideMetadata(typeof (ButtonPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
  }

  public virtual ButtonPanel Copy(bool deepCopy) => CloningMachine.Clone(this, deepCopy);

  [Category("Layout")]
  public eButtonPanelOrientation Orientation
  {
    get => (eButtonPanelOrientation) this.GetValue(ButtonPanel.OrientationProperty);
    set => this.SetValue(ButtonPanel.OrientationProperty, (object) value);
  }

  [Category("Layout")]
  public double FixedWidth
  {
    get => (double) this.GetValue(ButtonPanel.FixedWidthProperty);
    set => this.SetValue(ButtonPanel.FixedWidthProperty, (object) value);
  }

  [Category("Layout")]
  public double FixedHeight
  {
    get => (double) this.GetValue(ButtonPanel.FixedHeightProperty);
    set => this.SetValue(ButtonPanel.FixedHeightProperty, (object) value);
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    if (this.Children.Count == 0 && this.IsDesignMode)
      return new Size(32.0, 24.0);
    Size size = !this.m_AutoLayoutEnabled ? this.MeasureDefault(availableSize) : this.MeasureAutoLayout(availableSize);
    RibbonBar templatedParent = this.TemplatedParent as RibbonBar;
    if (this.IsItemsHost && templatedParent != null)
    {
      templatedParent.LastPanelMeasureSize = size;
      this.m_LastCalculatedSize = size;
      if (size.Width > availableSize.Width)
        templatedParent.MeasureNeedCollapse = true;
    }
    return size;
  }

  private Size MeasureDefault(Size availableSize) => this.MeasureDefault(availableSize, true);

  private Size MeasureDefault(Size availableSize, bool childrenMeasure)
  {
    this.m_ButtonDropDownCount = 0;
    Size size1 = new Size(0.0, 0.0);
    UIElementCollection internalChildren = this.InternalChildren;
    int count = internalChildren.Count;
    bool flag1 = this.Orientation == eButtonPanelOrientation.Horizontal;
    Size measureSize = this.GetMeasureSize(availableSize);
    Size availableSize1 = new Size(double.PositiveInfinity, double.PositiveInfinity);
    bool flag2 = !double.IsPositiveInfinity(availableSize.Height) && !double.IsInfinity(availableSize.Height) && !double.IsNaN(availableSize.Height);
    Size size2 = flag1 ? measureSize : new Size(measureSize.Height, measureSize.Width);
    Size size3 = new Size(0.0, 0.0);
    for (int index = 0; index < count; ++index)
    {
      UIElement uiElement = internalChildren[index];
      if (uiElement != null && uiElement.Visibility != Visibility.Collapsed)
      {
        if (uiElement is ButtonDropDown buttonDropDown)
        {
          ++this.m_ButtonDropDownCount;
          if (childrenMeasure && buttonDropDown.AutoSizeBag != null)
          {
            buttonDropDown.AutoSizeBag.RestoreSettings();
            buttonDropDown.AutoSizeBag = (ElementAutoSizeBag) null;
          }
        }
        if (childrenMeasure)
        {
          if (uiElement is Gallery)
          {
            if ((uiElement as Gallery).IsCollapsible)
            {
              ((Gallery) uiElement).IsCollapsed = false;
              uiElement.Measure(new Size(availableSize1.Width, availableSize.Height));
            }
            else
              uiElement.Measure(availableSize1);
          }
          else
            uiElement.Measure(availableSize1);
        }
        Size size4 = flag1 ? uiElement.DesiredSize : new Size(uiElement.DesiredSize.Height, uiElement.DesiredSize.Width);
        size4.Width = Math.Round(size4.Width);
        size4.Height = Math.Round(size4.Height);
        if (LayoutHelpers.GreaterThan(size3.Width + size4.Width, size2.Width))
        {
          size1.Height += size3.Height;
          size1.Width = Math.Max(size1.Width, size3.Width);
          size3 = size4;
        }
        else
        {
          size3.Width += size4.Width;
          if (LayoutHelpers.GreaterThan(size4.Height, size3.Height))
            size3.Height = size4.Height;
        }
      }
    }
    size1.Height += size3.Height;
    size1.Width = Math.Max(size3.Width, size1.Width);
    Size size5 = flag1 ? size1 : new Size(size1.Height, size1.Width);
    this.m_RealCalculatedSize = size5;
    if (flag2)
      size5.Height = availableSize.Height;
    return size5;
  }

  private void CreatePropertyBag(ButtonDropDown b)
  {
    if (b.AutoSizeBag != null)
      return;
    ElementAutoSizeBag autoSizeBag = AutoSizeBagFactory.CreateAutoSizeBag(b);
    autoSizeBag.RecordSetting((UIElement) b);
    b.AutoSizeBag = autoSizeBag;
  }

  private Size MeasureAutoLayout(Size availableSize)
  {
    if (!this.IsSecondMeasurePass && this.IsRibbonBarPanelMeasure || this.m_ButtonDropDownCount < 2 && !this.HasGallery || !this.IsRibbonBarPanelMeasure)
      return this.MeasureDefault(availableSize);
    Size availableSize1 = new Size(1000.0, availableSize.Height);
    UIElementCollection internalChildren = this.InternalChildren;
    int capacity = internalChildren.Count - 1;
    double height1 = availableSize.Height;
    int num1 = 0;
    List<ButtonDropDown> buttonDropDownList = new List<ButtonDropDown>(capacity);
    if (this.HasGallery)
    {
      foreach (Gallery gallery in this.m_Galleries)
      {
        if (RibbonBar.GetMinAutoSizeHint((UIElement) gallery) != eAutoSizeHint.NoAutoSize && gallery.Visibility == Visibility.Visible && double.IsNaN(gallery.Width))
        {
          double width1 = availableSize.Width;
          Size size1 = this.DesiredSize;
          double width2 = size1.Width;
          double num2 = width1 - width2;
          size1 = gallery.DesiredSize;
          double val1_1 = size1.Width + num2;
          double width3;
          if (gallery.MinWidth > 0.0)
          {
            width3 = Math.Max(val1_1, gallery.MinWidth);
          }
          else
          {
            double val1_2 = val1_1;
            double minContainerWidth = gallery.GetMinContainerWidth();
            size1 = gallery.DesiredSize;
            double width4 = size1.Width;
            double val2 = minContainerWidth + width4 - gallery.PanelWidth;
            width3 = Math.Max(val1_2, val2);
          }
          gallery.Measure(new Size(width3, availableSize.Height));
          Size size2 = this.MeasureDefault(availableSize, false);
          if (size2.Width <= availableSize.Width || LayoutHelpers.IsClose(size2.Width, availableSize.Width))
          {
            size1 = size2;
            return size1;
          }
        }
      }
    }
    for (int index = capacity; index >= 0; --index)
    {
      if (!(internalChildren[index] is ButtonDropDown buttonDropDown))
      {
        internalChildren[index].Measure(availableSize1);
      }
      else
      {
        eAutoSizeHint minAutoSizeHint = RibbonBar.GetMinAutoSizeHint((UIElement) buttonDropDown);
        if (minAutoSizeHint == eAutoSizeHint.NoAutoSize)
          buttonDropDown.Measure(availableSize1);
        else if ((buttonDropDown.ImagePosition == eButtonImagePosition.Top || buttonDropDown.ImagePosition == eButtonImagePosition.Bottom) && buttonDropDown.HasImage && buttonDropDown.PartVisibility == eButtonPartVisibility.ImageAndHeader && buttonDropDown.HasHeader)
        {
          this.CreatePropertyBag(buttonDropDown);
          if (minAutoSizeHint == eAutoSizeHint.Small)
            buttonDropDownList.Add(buttonDropDown);
          buttonDropDown.ImagePosition = eButtonImagePosition.Left;
          buttonDropDown.UseSmallImage = true;
          if (buttonDropDown.ExpandPosition == eExpandPosition.Bottom || buttonDropDown.ExpandPosition == eExpandPosition.Top)
            buttonDropDown.ExpandPosition = eExpandPosition.Right;
          buttonDropDown.Measure(availableSize1);
          ++num1;
          if (height1 != double.PositiveInfinity)
            height1 -= buttonDropDown.DesiredSize.Height;
          if (num1 == 3 || LayoutHelpers.GreaterThan(0.0, height1) || index == 0)
          {
            num1 = 0;
            height1 = availableSize.Height;
            Size size = this.MeasureDefault(availableSize, false);
            if (size.Width <= availableSize.Width || LayoutHelpers.IsClose(size.Width, availableSize.Width) || index == 0 && buttonDropDownList.Count == 0)
              return size;
          }
          ++availableSize1.Width;
        }
        else if (minAutoSizeHint == eAutoSizeHint.Small && (buttonDropDown.ImagePosition == eButtonImagePosition.Left || buttonDropDown.ImagePosition == eButtonImagePosition.Right) && buttonDropDown.HasImage && buttonDropDown.PartVisibility == eButtonPartVisibility.ImageAndHeader && buttonDropDown.HasHeader)
          buttonDropDownList.Add(buttonDropDown);
        else if (buttonDropDown is Gallery)
          buttonDropDown.Measure(new Size(double.PositiveInfinity, availableSize1.Height));
        else
          buttonDropDown.Measure(availableSize1);
      }
    }
    if (this.HasGallery)
    {
      foreach (Gallery gallery in this.m_Galleries)
      {
        if (gallery.Visibility == Visibility.Visible && gallery.IsCollapsible)
        {
          gallery.IsCollapsed = true;
          gallery.Measure(availableSize1);
          Size size = this.MeasureDefault(availableSize, false);
          if (size.Width <= availableSize.Width || LayoutHelpers.IsClose(size.Width, availableSize.Width))
            return size;
        }
      }
    }
    if (buttonDropDownList.Count == 0)
      return this.MeasureDefault(availableSize, false);
    double height2 = availableSize.Height;
    int num3 = 0;
    int num4 = buttonDropDownList.Count - 1;
    for (int index = 0; index <= num4; ++index)
    {
      ButtonDropDown b = buttonDropDownList[index];
      this.CreatePropertyBag(b);
      b.PartVisibility = eButtonPartVisibility.ImageOnly;
      b.Measure(availableSize1);
      ++num3;
      if (height2 != double.PositiveInfinity)
        height2 -= b.DesiredSize.Height;
      Size size = this.MeasureDefault(availableSize, false);
      if (size.Width <= availableSize.Width || LayoutHelpers.IsClose(size.Width, availableSize.Width) || index == num4)
        return size;
      ++availableSize1.Width;
    }
    if (this.IsItemsHost && this.TemplatedParent is RibbonBar)
      ((RibbonBar) this.TemplatedParent).MeasureNeedCollapse = true;
    return this.m_LastCalculatedSize;
  }

  private bool IsSecondMeasurePass
  {
    get
    {
      RibbonBar templatedParent = this.TemplatedParent as RibbonBar;
      return this.IsItemsHost && templatedParent != null && templatedParent.IsSecondMeasurePass;
    }
  }

  private bool IsRibbonBarPanelMeasure
  {
    get
    {
      RibbonBar templatedParent = this.TemplatedParent as RibbonBar;
      return this.IsItemsHost && templatedParent != null && templatedParent.IsRibbonBarPanelMeasure;
    }
  }

  private Size GetMeasureSize(Size availableSize)
  {
    double fixedWidth = this.FixedWidth;
    double fixedHeight = this.FixedHeight;
    Size measureSize = availableSize;
    if (!double.IsNaN(fixedWidth) && !LayoutHelpers.IsZero(fixedWidth))
      measureSize.Width = fixedWidth;
    if (!double.IsNaN(fixedHeight) && !LayoutHelpers.IsZero(fixedHeight))
      measureSize.Height = fixedHeight;
    return measureSize;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    return this.Children.Count == 0 && this.IsDesignMode ? finalSize : this.ArrangeInternal(new Rect(finalSize));
  }

  private bool GetResizeGallery(UIElement elem)
  {
    return elem is Gallery && ((Gallery) elem).IsCollapsible && !((Gallery) elem).IsCollapsed;
  }

  protected virtual Size ArrangeInternal(Rect finalRect)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    int lineEnd1 = internalChildren.Count - 1;
    Size size1 = finalRect.Size;
    bool horizontal = this.Orientation == eButtonPanelOrientation.Horizontal;
    Size lineSize = new Size(0.0, 0.0);
    int lineStart = 0;
    int num = 0;
    System.Windows.Point location = finalRect.Location;
    bool useLineSize = this.HorizontalAlignment == HorizontalAlignment.Stretch;
    if (this.VerticalAlignment == VerticalAlignment.Center)
      location.Y += (size1.Height - this.m_RealCalculatedSize.Height) / 2.0;
    else if (this.VerticalAlignment == VerticalAlignment.Bottom)
      location.Y += size1.Height - this.m_RealCalculatedSize.Height;
    for (int index = 0; index <= lineEnd1; ++index)
    {
      UIElement elem = internalChildren[index];
      if (elem != null)
      {
        Size size2;
        ref Size local = ref size2;
        Size desiredSize = elem.DesiredSize;
        double width = Math.Round(desiredSize.Width);
        desiredSize = elem.DesiredSize;
        double height = Math.Round(desiredSize.Height);
        local = new Size(width, height);
        if (this.GetResizeGallery(elem))
          size2.Height = size1.Height;
        if (horizontal && LayoutHelpers.GreaterThan(lineSize.Width + size2.Width, size1.Width) || !horizontal && LayoutHelpers.GreaterThan(lineSize.Height + size2.Height, size1.Height))
        {
          int lineEnd2 = index - 1;
          if (!horizontal && lineEnd2 - lineStart == 0 && lineSize.Height * 1.5 >= size1.Height)
            lineSize.Height = size1.Height;
          this.ArrangeSingleLine(location, lineStart, lineEnd2, lineSize, horizontal, useLineSize);
          if (horizontal)
            location.Y += lineSize.Height;
          else
            location.X += lineSize.Width;
          lineStart = index;
          num = index;
          lineSize = new Size(0.0, 0.0);
        }
        if (horizontal)
        {
          lineSize.Width += size2.Width;
          lineSize.Height = Math.Max(size2.Height, lineSize.Height);
        }
        else
        {
          lineSize.Height += size2.Height;
          lineSize.Width = Math.Max(size2.Width, lineSize.Width);
        }
      }
    }
    if (lineStart <= lineEnd1)
    {
      if (!horizontal && num - lineStart == 0 && lineSize.Height * 1.5 >= size1.Height)
        lineSize.Height = size1.Height;
      this.ArrangeSingleLine(location, lineStart, lineEnd1, lineSize, horizontal, useLineSize);
    }
    return size1;
  }

  private void ArrangeSingleLine(
    System.Windows.Point currentLocation,
    int lineStart,
    int lineEnd,
    Size lineSize,
    bool horizontal,
    bool useLineSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    for (int index = lineStart; index <= lineEnd; ++index)
    {
      UIElement elem = internalChildren[index];
      if (elem != null)
      {
        Rect finalRect = Rect.Empty;
        if (horizontal)
        {
          finalRect = new Rect(currentLocation.X, currentLocation.Y, elem.DesiredSize.Width, useLineSize ? lineSize.Height : elem.DesiredSize.Height);
          if (this.GetResizeGallery(elem))
            finalRect.Height = lineSize.Height;
          currentLocation.X += finalRect.Width;
        }
        else
        {
          finalRect = new Rect(currentLocation.X, currentLocation.Y, useLineSize ? lineSize.Width : elem.DesiredSize.Width, elem.DesiredSize.Height);
          if (lineEnd - lineStart == 0 && elem.DesiredSize.Height * 1.5 >= lineSize.Height)
            finalRect.Height = lineSize.Height;
          if (this.GetResizeGallery(elem))
            finalRect.Height = lineSize.Height;
          currentLocation.Y += finalRect.Height;
        }
        finalRect.Width = Math.Round(finalRect.Width);
        finalRect.Height = Math.Round(finalRect.Height);
        elem.Arrange(finalRect);
      }
    }
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  protected override void OnVisualChildrenChanged(
    DependencyObject visualAdded,
    DependencyObject visualRemoved)
  {
    base.OnVisualChildrenChanged(visualAdded, visualRemoved);
    if (visualRemoved is ButtonDropDown)
    {
      ButtonDropDown buttonDropDown = visualRemoved as ButtonDropDown;
      if (buttonDropDown.AutoSizeBag != null)
      {
        buttonDropDown.AutoSizeBag.RestoreSettings();
        buttonDropDown.AutoSizeBag = (ElementAutoSizeBag) null;
      }
      if (!(buttonDropDown is Gallery))
        return;
      this.m_Galleries.Remove(buttonDropDown as Gallery);
    }
    else
    {
      if (!(visualAdded is Gallery))
        return;
      this.m_Galleries.Add(visualAdded as Gallery);
    }
  }

  private bool HasGallery => this.m_Galleries.Count > 0;
}

// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.GalleryScrollViewer
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class GalleryScrollViewer : Canvas
{
  public static readonly DependencyProperty VerticalOffsetProperty;
  public static readonly RoutedCommand LineDownCommand;
  public static readonly RoutedCommand LineUpCommand;
  private bool m_Animation = true;
  private const double DefaultAnimationDuration = 190.0;

  static GalleryScrollViewer()
  {
    UIElement.FocusableProperty.OverrideMetadata(typeof (GalleryScrollViewer), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    GalleryScrollViewer.VerticalOffsetProperty = DependencyProperty.Register(nameof (VerticalOffset), typeof (double), typeof (GalleryScrollViewer), (PropertyMetadata) new FrameworkPropertyMetadata((object) 0.0, new PropertyChangedCallback(GalleryScrollViewer.OnVerticalOffsetChanged)));
    GalleryScrollViewer.LineDownCommand = new RoutedCommand("LineDown", typeof (GalleryScrollViewer));
    GalleryScrollViewer.LineUpCommand = new RoutedCommand("LineUp", typeof (GalleryScrollViewer));
    CommandManager.RegisterClassCommandBinding(typeof (GalleryScrollViewer), new CommandBinding((ICommand) GalleryScrollViewer.LineUpCommand, new ExecutedRoutedEventHandler(GalleryScrollViewer.OnScrollCommand), new CanExecuteRoutedEventHandler(GalleryScrollViewer.OnQueryScrollCommand)));
    CommandManager.RegisterClassInputBinding(typeof (GalleryScrollViewer), new InputBinding((ICommand) GalleryScrollViewer.LineUpCommand, (InputGesture) new KeyGesture(Key.Up)));
    CommandManager.RegisterClassCommandBinding(typeof (GalleryScrollViewer), new CommandBinding((ICommand) GalleryScrollViewer.LineDownCommand, new ExecutedRoutedEventHandler(GalleryScrollViewer.OnScrollCommand), new CanExecuteRoutedEventHandler(GalleryScrollViewer.OnQueryScrollCommand)));
    CommandManager.RegisterClassInputBinding(typeof (GalleryScrollViewer), new InputBinding((ICommand) GalleryScrollViewer.LineDownCommand, (InputGesture) new KeyGesture(Key.Down)));
  }

  protected override Size MeasureOverride(Size constraint)
  {
    if (this.VerticalOffset != 0.0)
    {
      if (this.HasAnimatedProperties)
        this.BeginAnimation(GalleryScrollViewer.VerticalOffsetProperty, (AnimationTimeline) null);
      this.VerticalOffset = 0.0;
    }
    CommandManager.InvalidateRequerySuggested();
    Gallery templatedParent = this.TemplatedParent as Gallery;
    Size availableSize = new Size(templatedParent != null ? templatedParent.SuggestedContainerWidth : 200.0, double.PositiveInfinity);
    if (!double.IsInfinity(constraint.Width) && !double.IsNaN(constraint.Width))
      availableSize.Width = constraint.Width;
    Size size = new Size();
    foreach (UIElement internalChild in this.InternalChildren)
    {
      if (internalChild != null)
      {
        internalChild.Measure(availableSize);
        size = internalChild.DesiredSize;
      }
    }
    return !double.IsNaN(this.Width) ? new Size() : new Size(size.Width, 0.0);
  }

  private static void OnQueryScrollCommand(object target, CanExecuteRoutedEventArgs args)
  {
    GalleryScrollViewer galleryScrollViewer = (GalleryScrollViewer) target;
    if (args.Command == GalleryScrollViewer.LineUpCommand)
    {
      args.CanExecute = galleryScrollViewer.CanScrollUp;
    }
    else
    {
      if (args.Command != GalleryScrollViewer.LineDownCommand)
        return;
      args.CanExecute = galleryScrollViewer.CanScrollDown;
    }
  }

  private bool CanScrollUp => this.VerticalOffset != 0.0;

  private bool CanScrollDown
  {
    get
    {
      return this.InternalChildren.Count <= 0 || this.InternalChildren[0].RenderSize.Height + this.VerticalOffset > this.RenderSize.Height;
    }
  }

  private static void OnScrollCommand(object target, ExecutedRoutedEventArgs args)
  {
    GalleryScrollViewer galleryScrollViewer = (GalleryScrollViewer) target;
    if (args.Command == GalleryScrollViewer.LineUpCommand)
    {
      galleryScrollViewer.LineUp();
    }
    else
    {
      if (args.Command != GalleryScrollViewer.LineDownCommand)
        return;
      galleryScrollViewer.LineDown();
    }
  }

  private void LineDown() => this.Animate(this.VerticalOffset - this.GetSingleLineOffset());

  private void LineUp()
  {
    this.Animate(Math.Min(0.0, this.VerticalOffset + this.GetSingleLineOffset()));
  }

  private double GetSingleLineOffset()
  {
    double singleLineOffset = 38.0;
    if (this.InternalChildren.Count == 0 || !(this.InternalChildren[0] is Panel))
      return singleLineOffset;
    Panel internalChild = this.InternalChildren[0] as Panel;
    double verticalOffset = this.VerticalOffset;
    for (int index = 0; index < internalChild.Children.Count; ++index)
    {
      Rect layoutSlot = LayoutInformation.GetLayoutSlot(internalChild.Children[index] as FrameworkElement);
      if (layoutSlot.Y + verticalOffset >= 0.0)
      {
        singleLineOffset = layoutSlot.Height;
        break;
      }
    }
    return singleLineOffset;
  }

  protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
  {
    if (e.NewFocus != null && e.NewFocus is UIElement && this.InternalChildren.Count > 0 && this.InternalChildren[0] is Panel)
    {
      UIElement newFocus = e.NewFocus as UIElement;
      if ((this.InternalChildren[0] as Panel).Children.Contains(newFocus))
        this.BringIntoView(newFocus);
    }
    base.OnGotKeyboardFocus(e);
  }

  private void BringIntoView(UIElement elem)
  {
    if (elem == null || !(elem is FrameworkElement))
      return;
    this.Animate(-LayoutInformation.GetLayoutSlot(elem as FrameworkElement).Top);
  }

  private void Animate(double newVerticalOffset)
  {
    if (this.AnimationEnabled)
    {
      double val1 = 190.0;
      double num = Math.Abs(this.VerticalOffset - newVerticalOffset);
      if (num < 60.0)
        val1 *= num / 60.0;
      double a = Math.Max(val1, 100.0);
      if (a >= 50.0)
      {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(Math.Round(a));
        DoubleAnimation animation = new DoubleAnimation(newVerticalOffset, new Duration(timeSpan));
        this.BeginAnimation(GalleryScrollViewer.VerticalOffsetProperty, (AnimationTimeline) animation, HandoffBehavior.Compose);
      }
      else
        this.VerticalOffset = newVerticalOffset;
    }
    else
      this.VerticalOffset = newVerticalOffset;
  }

  private bool AnimationEnabled
  {
    get
    {
      return SystemParameters.PowerLineStatus == PowerLineStatus.Online && SystemParameters.ClientAreaAnimation && RenderCapability.Tier > 0 && this.IsEnabled && this.m_Animation;
    }
  }

  internal bool Animation
  {
    get => this.m_Animation;
    set => this.m_Animation = value;
  }

  private static void OnVerticalOffsetChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((GalleryScrollViewer) d).SetVerticalOffset((double) e.NewValue);
  }

  public double VerticalOffset
  {
    get => (double) this.GetValue(GalleryScrollViewer.VerticalOffsetProperty);
    set => this.SetValue(GalleryScrollViewer.VerticalOffsetProperty, (object) value);
  }

  private void SetVerticalOffset(double value)
  {
    foreach (UIElement internalChild in this.InternalChildren)
      Canvas.SetTop(internalChild, value);
    CommandManager.InvalidateRequerySuggested();
  }
}

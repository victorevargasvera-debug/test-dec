// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommandLineCPS.MyMessageBox
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System.Windows;

#nullable disable
namespace MackinawCPS.CommandLineCPS;

public class MyMessageBox
{
  internal static MessageBoxResult Show(string messageBoxText, MessageBoxResult defaultResult = MessageBoxResult.OK)
  {
    return (bool) Application.Current.Properties[(object) "CommandLineCPS"] ? defaultResult : MessageBox.Show(messageBoxText);
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxResult defaultResult = MessageBoxResult.OK)
  {
    return (bool) Application.Current.Properties[(object) "CommandLineCPS"] ? defaultResult : MessageBox.Show(messageBoxText, caption);
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxButton button,
    MessageBoxResult defaultResult = MessageBoxResult.OK)
  {
    if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      return MessageBox.Show(messageBoxText, caption, button);
    MessageBoxResult messageBoxResult = defaultResult;
    switch (button)
    {
      case MessageBoxButton.OK:
      case MessageBoxButton.OKCancel:
        switch (defaultResult)
        {
          case MessageBoxResult.Yes:
            messageBoxResult = MessageBoxResult.OK;
            break;
          case MessageBoxResult.No:
            messageBoxResult = MessageBoxResult.Cancel;
            break;
        }
        break;
      case MessageBoxButton.YesNoCancel:
      case MessageBoxButton.YesNo:
        if (defaultResult == MessageBoxResult.OK)
        {
          messageBoxResult = MessageBoxResult.Yes;
          break;
        }
        break;
    }
    return messageBoxResult;
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxButton button,
    MessageBoxImage icon,
    MessageBoxResult defaultResult)
  {
    if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
    MessageBoxResult messageBoxResult = defaultResult;
    switch (button)
    {
      case MessageBoxButton.OK:
      case MessageBoxButton.OKCancel:
        switch (defaultResult)
        {
          case MessageBoxResult.Yes:
            messageBoxResult = MessageBoxResult.OK;
            break;
          case MessageBoxResult.No:
            messageBoxResult = MessageBoxResult.Cancel;
            break;
        }
        break;
      case MessageBoxButton.YesNoCancel:
      case MessageBoxButton.YesNo:
        if (defaultResult == MessageBoxResult.OK)
        {
          messageBoxResult = MessageBoxResult.Yes;
          break;
        }
        break;
    }
    return messageBoxResult;
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxButton button,
    MessageBoxImage icon,
    MessageBoxResult defaultResult,
    MessageBoxOptions options)
  {
    if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
    MessageBoxResult messageBoxResult = defaultResult;
    switch (button)
    {
      case MessageBoxButton.OK:
      case MessageBoxButton.OKCancel:
        switch (defaultResult)
        {
          case MessageBoxResult.Yes:
            messageBoxResult = MessageBoxResult.OK;
            break;
          case MessageBoxResult.No:
            messageBoxResult = MessageBoxResult.Cancel;
            break;
        }
        break;
      case MessageBoxButton.YesNoCancel:
      case MessageBoxButton.YesNo:
        if (defaultResult == MessageBoxResult.OK)
        {
          messageBoxResult = MessageBoxResult.Yes;
          break;
        }
        break;
    }
    return messageBoxResult;
  }
}

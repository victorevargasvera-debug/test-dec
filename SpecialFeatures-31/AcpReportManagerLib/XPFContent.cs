// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.XPFContent
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

internal class XPFContent
{
  private string a;

  internal XPFContent(string contentPath) => this.a = contentPath;

  internal IDocumentPaginatorSource LoadViewableFixedContent(string documentName)
  {
    XpsDocument xpsDocument = (XpsDocument) null;
    IDocumentPaginatorSource documentPaginatorSource = (IDocumentPaginatorSource) null;
    try
    {
      xpsDocument = new XpsDocument(documentName, FileAccess.Read, CompressionOption.NotCompressed);
      documentPaginatorSource = (IDocumentPaginatorSource) xpsDocument.GetFixedDocumentSequence();
    }
    finally
    {
      short num1 = -19557;
      int num2 = (int) num1;
      num1 = (short) -19557;
      int num3 = (int) num1;
      int num4;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_7:
          if (xpsDocument != null)
          {
            num1 = (short) 1;
            num4 = (int) (IntPtr) num1;
            break;
          }
          goto label_10;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 2;
          num4 = (int) (IntPtr) num1;
          break;
      }
      while (true)
      {
        switch (num4)
        {
          case 0:
            goto label_10;
          case 1:
            xpsDocument.Close();
            num1 = (short) 0;
            num4 = (int) (IntPtr) num1;
            continue;
          case 2:
            goto label_5;
          default:
            goto label_7;
        }
label_6:;
      }
label_5:
      switch (0)
      {
        case 0:
          goto label_7;
        default:
          goto label_6;
      }
label_10:;
    }
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
    return documentPaginatorSource;
  }
}

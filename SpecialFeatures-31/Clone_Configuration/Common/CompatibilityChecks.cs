// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.CompatibilityChecks
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using ConstraintHelper;
using Motorola.CommonCPS.RadioManagement.SharedServices;
using Motorola.CommonCPS.Server.EntityModel;
using SpecialFeatures.Flashport.FlashRadio;
using System;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class CompatibilityChecks
{
  private CodeplugData a;
  private CodeplugData b;
  private bool c = true;

  internal CompatibilityChecks(
    string srcUsedFlashcode,
    string srcPurchasedFlashcode,
    string radioFlashcode,
    string srcModelNumber,
    string radioModelNumber)
  {
    this.c = UtilityMack.IsPortable();
    this.a(srcUsedFlashcode, srcPurchasedFlashcode, radioFlashcode, srcModelNumber, radioModelNumber);
  }

  public CompatibilityChecks(APXTemplate srcData, APXCodeplug targetData, string targetModelNumber)
  {
    this.c = ((Template) srcData).ModelNumber[0] == 'H';
    this.a(srcData, targetData, targetModelNumber);
  }

  private void a(string A_0, string A_1, string A_2, string A_3, string A_4)
  {
    short num1 = -6058;
    int num2 = (int) num1;
    num1 = (short) -6058;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        this.a = new CodeplugData();
        this.a.usedFlashcode = A_0;
        this.a.modelNumber = A_3;
        this.a.purchasedFlashcode = A_1;
        this.b = new CodeplugData();
        this.b.purchasedFlashcode = A_2;
        this.b.modelNumber = A_4;
        break;
      default:
        goto case 1;
    }
  }

  private void a(APXTemplate A_0, APXCodeplug A_1, string A_2)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        APXRadioSystem[] entityCollections1;
        int index;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 15438;
            int num3 = (int) num2;
            num2 = (short) 15438;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                break;
              default:
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 0;
                this.a = new CodeplugData();
                this.a._data = new APXCodeplug();
                this.a.modelNumber = ((Template) A_0).ModelNumber;
                this.a.purchasedFlashcode = FlashcodeFormatter.FormatFlashcodeString(A_0.AstroPurchasedFlashCode, A_0.AstroPurchasedFlashCode.Length);
                this.a.usedFlashcode = FlashcodeFormatter.FormatFlashcodeString(A_0.AstroEnableFlashCode, A_0.AstroEnableFlashCode.Length);
                this.a._data.AllowInvalidFrequency = A_0.AllowInvalidFrequency;
                entityCollections1 = RMCExportInterface.GetInstance().XMLToEntityCollections<APXRadioSystem>(A_0.RadioSystems);
                index = 0;
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                goto label_2;
            }
            break;
          default:
            while (true)
            {
              APXDataProfile[] entityCollections2;
              switch (num1)
              {
                case 0:
                case 1:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  entityCollections2 = RMCExportInterface.GetInstance().XMLToEntityCollections<APXDataProfile>(A_0.DataProfiles);
                  index = 0;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                case 7:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (index < entityCollections2.Length)
                  {
                    this.a._data.APXDataProfiles.Add(entityCollections2[index]);
                    ++index;
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (index >= entityCollections1.Length)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_9;
                case 6:
                  goto label_16;
                default:
                  goto label_3;
              }
label_2:;
            }
label_16:
            this.a.recSetCounts = AstroRecSetCounts.LoadRecSetItemsFromXml(A_0.RecSetCounts);
            this.b = new CodeplugData();
            this.b._data = A_1;
            this.b.modelNumber = A_2;
            this.b.purchasedFlashcode = FlashcodeFormatter.FormatFlashcodeString(A_1.AstroPurchasedFlashCode, A_1.AstroPurchasedFlashCode.Length);
            this.b.recSetCounts = AstroRecSetCounts.LoadRecSetItemsFromXml(A_1.RecSetCounts);
            return;
        }
label_9:
        this.a._data.APXRadioSystems.Add(entityCollections1[index]);
        ++index;
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto label_2;
    }
  }

  public bool PerfomChecks(ref string stsErrorMsg)
  {
    short num1;
    int num2;
    bool flag;
    switch (0)
    {
      case 0:
label_5:
        stsErrorMsg = "";
        flag = AllowCloning.ModelNumberCheck(this.a.modelNumber, this.b.modelNumber, this.c, ref stsErrorMsg);
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) -11028;
          int num3 = (int) num1;
          num1 = (short) -11028;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
label_6:
              if (flag)
              {
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_9;
            default:
              num1 = (short) 0;
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              switch (num2)
              {
                case 0:
                  goto label_9;
                case 1:
                  stsErrorMsg = AppResources.Failure_due_to_mismatch_of_Codeplug_Used_FLASHcode_and_Radio_Purchased_FLASHcode;
                  flag = AllowCloning.AllowClone(this.a, this.b, this.c, ref stsErrorMsg);
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 2:
                  goto label_6;
                default:
                  goto label_5;
              }
          }
        }
label_9:
        return flag;
    }
  }
}

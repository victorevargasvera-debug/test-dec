// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.RadioOperationValidator
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.Flashport.FlashRadio;
using SpecialFeatures.RadioFeatureSet;
using SpecialFeatures.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace SpecialFeatures.Comms;

public static class RadioOperationValidator
{
  public static List<ValidationField> PopulateWriteValidationFields(PbaObject xpbaCodeplug)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = -23985;
        switch ((short) -23985 == num2 ? 1 : 0)
        {
          case 0:
          case 2:
label_11:
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            break;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            switch (0)
            {
              case 0:
                goto label_5;
            }
            break;
        }
        byte[] numArray;
        ProtectionOption protectionOption;
        IshItemCollection ishItemCollection;
        IshHeader ishHeader;
        List<DataPartition>.Enumerator enumerator1;
        List<ValidationField> validationFieldList;
        while (true)
        {
          bool flag1;
          bool flag2;
          switch (num1)
          {
            case 0:
              if (ishItemCollection.ContainsHeader(ishHeader))
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 13;
            case 1:
              protectionOption = ProtectionOption.LEGACY_SW;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              goto case 5;
            case 3:
              int index = 6;
              int num3 = 3;
              int num4 = (int) numArray[index];
              flag2 = 1 == (num4 & 8) >> num3;
              flag1 = 1 == (num4 & 4) >> 2;
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              validationFieldList = new List<ValidationField>();
              enumerator1 = xpbaCodeplug.CodeplugData.DataPartitions.GetEnumerator();
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              IshItem ishItem = ishItemCollection[ishHeader];
              numArray = ((IshItem) ref ishItem).Data;
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (numArray != null)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 8:
              if (flag1)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 9:
              if (!flag2)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 10:
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              protectionOption = ProtectionOption.HARDWARE;
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              if (!flag1)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_11;
            case 13:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              goto label_17;
            case 15:
              if (flag2)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_11;
            default:
              goto label_5;
          }
label_4:;
        }
label_17:
        try
        {
          num2 = (short) 0;
          int num5 = (int) (IntPtr) num2;
          while (true)
          {
            DataPartition current1;
            int num6;
            ValidationField validationField1;
            List<DataBlock>.Enumerator enumerator2;
            switch (num5)
            {
              case 0:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 1:
                try
                {
                  num2 = (short) 17;
                  int num7 = (int) (IntPtr) num2;
                  while (true)
                  {
                    DataBlock current2;
                    int sourceIndex;
                    ushort blockType;
                    ValidationField validationField2;
                    int num8;
                    ValidationField validationField3;
                    int num9;
                    ValidationField validationField4;
                    ValidationField validationField5;
                    ValidationField validationField6;
                    ValidationField validationField7;
                    ValidationField validationField8;
                    ValidationField validationField9;
                    ValidationField validationField10;
                    ValidationField validationField11;
                    ValidationField validationField12;
                    ValidationField validationField13;
                    int A_0;
                    int index;
                    ValidationField validationField14;
                    TrkSysBandPlan A_2;
                    ValidationField validationField15;
                    ValidationField validationField16;
                    ValidationField validationField17;
                    switch (num7)
                    {
                      case 0:
                        if (1 != num8 >> 6)
                        {
                          num2 = (short) 55;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 60;
                      case 1:
                        validationField16.Content = new byte[(long) (validationField16.LengthInBits / 8U) + (validationField16.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField16.Content, 0, validationField16.Content.Length);
                        validationFieldList.Add(validationField16);
                        num8 = (int) validationField16.Content[0] & 64 /*0x40*/;
                        num2 = (short) 53;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 2:
                        validationField11.Content = new byte[(long) (validationField11.LengthInBits / 8U) + (validationField11.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField11.Content, 0, validationField11.Content.Length);
                        validationFieldList.Add(validationField11);
                        validationField12 = new ValidationField();
                        validationField12.BlockType = current2.BlockType;
                        validationField12.BlockID = current2.BlockID;
                        validationField12.LengthInBits = 7U;
                        validationField12.PartitionID = current1.PartitionID;
                        sourceIndex = 161;
                        validationField12.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 12;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 4:
                        if (protectionOption == ProtectionOption.HARDWARE)
                        {
                          num2 = (short) 66;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 33;
                      case 6:
                        validationField17 = new ValidationField();
                        validationField17.BlockType = current2.BlockType;
                        validationField17.BlockID = current2.BlockID;
                        validationField17.LengthInBits = 528U;
                        validationField17.PartitionID = current1.PartitionID;
                        sourceIndex = 2;
                        validationField17.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 54;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 7:
                        validationField3.Content = new byte[(long) (validationField3.LengthInBits / 8U) + (validationField3.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField3.Content, 0, validationField3.Content.Length);
                        validationFieldList.Add(validationField3);
                        num9 = (int) validationField3.Content[0];
                        validationField4 = new ValidationField();
                        validationField4.BlockType = current2.BlockType;
                        validationField4.BlockID = current2.BlockID;
                        validationField4.LengthInBits = 16U /*0x10*/;
                        validationField4.PartitionID = current1.PartitionID;
                        sourceIndex = 106;
                        validationField4.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 46;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 8:
                        goto label_108;
                      case 9:
                        if (blockType != (ushort) 3852)
                        {
                          num2 = (short) 43;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        validationField13 = new ValidationField();
                        validationField13.BlockType = current2.BlockType;
                        validationField13.BlockID = current2.BlockID;
                        validationField13.LengthInBits = 16U /*0x10*/;
                        validationField13.PartitionID = current1.PartitionID;
                        sourceIndex = 59;
                        validationField13.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 51;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 11:
                        validationField3 = new ValidationField();
                        validationField3.BlockType = current2.BlockType;
                        validationField3.BlockID = current2.BlockID;
                        validationField3.LengthInBits = 8U;
                        validationField3.PartitionID = current1.PartitionID;
                        sourceIndex = 124;
                        validationField3.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 7;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 12:
                        validationField12.Content = new byte[(long) (validationField12.LengthInBits / 8U) + (validationField12.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField12.Content, 0, validationField12.Content.Length);
                        validationFieldList.Add(validationField12);
                        num2 = (short) 24;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 13:
                        if (blockType != (ushort) 1029)
                        {
                          num2 = (short) 26;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        validationField16 = new ValidationField();
                        validationField16.BlockType = current2.BlockType;
                        validationField16.BlockID = current2.BlockID;
                        validationField16.LengthInBits = 1U;
                        validationField16.PartitionID = current1.PartitionID;
                        sourceIndex = 1;
                        validationField16.OffsetInBits = (uint) (sourceIndex * 8 + 1);
                        num2 = (short) 1;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 14:
                        validationFieldList.Add(validationField4);
                        num2 = (short) 40;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 16 /*0x10*/:
                        num2 = (short) 15;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 17:
                        switch (0)
                        {
                          case 0:
                            break;
                          default:
                            continue;
                        }
                        break;
                      case 18:
                        validationField5.Content = new byte[(long) (validationField5.LengthInBits / 8U) + (validationField5.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField5.Content, 0, validationField5.Content.Length);
                        num2 = (short) 32 /*0x20*/;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 19:
                        if (index < validationField13.Content.Length)
                        {
                          byte num10 = validationField13.Content[index];
                          A_0 |= (int) num10 << 8 * (validationField13.Content.Length - index - 1);
                          ++index;
                          num2 = (short) 41;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        num2 = (short) 63 /*0x3F*/;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 20:
                        if (current2.LegthInBits - 24 > 8)
                        {
                          num2 = (short) 27;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        break;
                      case 21:
                        num2 = (short) 36;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 22:
                        validationField14.Content = new byte[(long) (validationField14.LengthInBits / 8U) + (validationField14.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField14.Content, 0, validationField14.Content.Length);
                        validationFieldList.Add(validationField13);
                        validationFieldList.Add(validationField14);
                        validationField1 = validationField14;
                        A_2 = (TrkSysBandPlan) null;
                        num2 = (short) 35;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 23:
                        if (blockType != (ushort) 1026)
                        {
                          num2 = (short) 16 /*0x10*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        validationField2 = new ValidationField();
                        validationField2.BlockType = current2.BlockType;
                        validationField2.BlockID = current2.BlockID;
                        validationField2.LengthInBits = 1U;
                        validationField2.PartitionID = current1.PartitionID;
                        sourceIndex = 21;
                        validationField2.OffsetInBits = (uint) (sourceIndex * 8 + 3);
                        num2 = (short) 30;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 26:
                        num2 = (short) 9;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 27:
                        validationField9 = new ValidationField();
                        validationField9.BlockType = current2.BlockType;
                        validationField9.BlockID = current2.BlockID;
                        validationField9.LengthInBits = (uint) (current2.LegthInBits - 24 - 8);
                        validationField9.PartitionID = current1.PartitionID;
                        sourceIndex = 2;
                        validationField9.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 38;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 28:
                        num2 = (short) 64 /*0x40*/;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 29:
                        if (protectionOption == ProtectionOption.HARDWARE)
                        {
                          num2 = (short) 21;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 40;
                      case 30:
                        validationField2.Content = new byte[(long) (validationField2.LengthInBits / 8U) + (validationField2.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField2.Content, 0, validationField2.Content.Length);
                        validationFieldList.Add(validationField2);
                        num8 = 0;
                        num2 = (short) 44;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 31 /*0x1F*/:
                        validationField10.Content = new byte[(long) (validationField10.LengthInBits / 8U) + (validationField10.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField10.Content, 0, validationField10.Content.Length);
                        validationFieldList.Add(validationField10);
                        validationField11 = new ValidationField();
                        validationField11.BlockType = current2.BlockType;
                        validationField11.BlockID = current2.BlockID;
                        validationField11.LengthInBits = 272U;
                        validationField11.PartitionID = current1.PartitionID;
                        sourceIndex = 23;
                        validationField11.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 2;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 32 /*0x20*/:
                        if (protectionOption == ProtectionOption.HARDWARE)
                        {
                          num2 = (short) 37;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 34;
                      case 33:
                        validationField7 = new ValidationField();
                        validationField7.BlockType = current2.BlockType;
                        validationField7.BlockID = current2.BlockID;
                        validationField7.LengthInBits = 1U;
                        validationField7.PartitionID = current1.PartitionID;
                        sourceIndex = 19;
                        validationField7.OffsetInBits = (uint) (sourceIndex * 8 + 1);
                        num2 = (short) 49;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 34:
                        validationField6 = new ValidationField();
                        validationField6.BlockType = current2.BlockType;
                        validationField6.BlockID = current2.BlockID;
                        validationField6.LengthInBits = 1U;
                        validationField6.PartitionID = current1.PartitionID;
                        sourceIndex = 97;
                        validationField6.OffsetInBits = (uint) (sourceIndex * 8 + 4);
                        num2 = (short) 58;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 35:
                        if (RadioOperationValidator.a(A_0, (int) validationField14.Content[0], out A_2))
                        {
                          num2 = (short) 59;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        break;
                      case 36:
                        if (num9 == 0)
                        {
                          num2 = (short) 14;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 40;
                      case 37:
                        num2 = (short) 39;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 38:
                        validationField9.Content = new byte[(long) (validationField9.LengthInBits / 8U) + (validationField9.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField9.Content, 0, validationField9.Content.Length);
                        validationField9.AutoFill = true;
                        validationFieldList.Add(validationField9);
                        num2 = (short) 3;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 39:
                        if (num9 == 1)
                        {
                          num2 = (short) 48 /*0x30*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 34;
                      case 40:
                        validationField5 = new ValidationField();
                        validationField5.BlockType = current2.BlockType;
                        validationField5.BlockID = current2.BlockID;
                        validationField5.LengthInBits = 24U;
                        validationField5.PartitionID = current1.PartitionID;
                        sourceIndex = 121;
                        validationField5.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 18;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 41:
                      case 42:
                        num2 = (short) 19;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 43:
                        num2 = (short) 10;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 44:
                        if (protectionOption == ProtectionOption.HARDWARE)
                        {
                          num2 = (short) 11;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 33;
                      case 45:
                        validationField15.Content = new byte[(long) (validationField15.LengthInBits / 8U) + (validationField15.LengthInBits % 8U == 0U ? 0L : 1L)];
                        validationField15.Content[0] = Convert.ToByte(0);
                        validationField15.BypassMissing = true;
                        validationFieldList.Add(validationField15);
                        num2 = (short) 5;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 46:
                        validationField4.Content = new byte[(long) (validationField4.LengthInBits / 8U) + (validationField4.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField4.Content, 0, validationField4.Content.Length);
                        num2 = (short) 29;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 47:
                        validationField9.Content = new byte[(long) (validationField9.LengthInBits / 8U) + (validationField9.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField9.Content, 0, validationField9.Content.Length);
                        validationField9.AutoFill = true;
                        validationFieldList.Add(validationField9);
                        num2 = (short) 20;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 48 /*0x30*/:
                        validationFieldList.Add(validationField5);
                        num2 = (short) 34;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 49:
                        validationField7.Content = new byte[(long) (validationField7.LengthInBits / 8U) + (validationField7.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField7.Content, 0, validationField7.Content.Length);
                        num8 = (int) validationField7.Content[0] & 64 /*0x40*/;
                        num2 = (short) 0;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 50:
                        if (blockType <= (ushort) 1026)
                        {
                          num2 = (short) 28;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        num2 = (short) 13;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 51:
                        validationField13.Content = new byte[(long) (validationField13.LengthInBits / 8U) + (validationField13.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField13.Content, 0, validationField13.Content.Length);
                        A_0 = 0;
                        index = 0;
                        num2 = (short) 42;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 52:
                        num2 = (short) 23;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 53:
                        int num11 = 1 == num8 >> 6 ? 1 : 0;
                        ValidationField validationField18 = new ValidationField();
                        validationField18.BlockType = current2.BlockType;
                        validationField18.BlockID = current2.BlockID;
                        validationField18.LengthInBits = 1U;
                        validationField18.PartitionID = current1.PartitionID;
                        sourceIndex = 1;
                        validationField18.OffsetInBits = (uint) (sourceIndex * 8);
                        validationField18.Content = new byte[(long) (validationField18.LengthInBits / 8U) + (validationField18.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField18.Content, 0, validationField18.Content.Length);
                        validationFieldList.Add(validationField18);
                        num8 = (int) validationField18.Content[0] & 128 /*0x80*/;
                        bool flag3 = 1 == num8 >> 7;
                        ValidationField validationField19 = new ValidationField();
                        validationField19.BlockType = current2.BlockType;
                        validationField19.BlockID = current2.BlockID;
                        validationField19.LengthInBits = 1U;
                        validationField19.PartitionID = current1.PartitionID;
                        sourceIndex = 1;
                        validationField19.OffsetInBits = (uint) (sourceIndex * 8 + 2);
                        validationField19.Content = new byte[(long) (validationField19.LengthInBits / 8U) + (validationField19.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField19.Content, 0, validationField19.Content.Length);
                        validationFieldList.Add(validationField19);
                        num8 = (int) validationField19.Content[0] & 32 /*0x20*/;
                        bool flag4 = 1 == num8 >> 5;
                        int num12 = flag3 ? 1 : 0;
                        if ((num11 | num12 | (flag4 ? 1 : 0)) != 0)
                        {
                          num2 = (short) 6;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        break;
                      case 54:
                        validationField17.Content = new byte[(long) (validationField17.LengthInBits / 8U) + (validationField17.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField17.Content, 0, validationField17.Content.Length);
                        validationFieldList.Add(validationField17);
                        num2 = (short) 25;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 55:
                        validationFieldList.Add(validationField7);
                        num2 = (short) 60;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 58:
                        validationField6.Content = new byte[(long) (validationField6.LengthInBits / 8U) + (validationField6.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField6.Content, 0, validationField6.Content.Length);
                        num2 = (short) 4;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 59:
                        validationField15 = new ValidationField();
                        validationField15.BlockType = current2.BlockType;
                        validationField15.BlockID = current2.BlockID;
                        validationField15.LengthInBits = 1U;
                        validationField15.PartitionID = current1.PartitionID;
                        sourceIndex = 70;
                        validationField15.OffsetInBits = (uint) (sourceIndex * 8 + 5);
                        num2 = (short) 45;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 60:
                        ValidationField validationField20 = new ValidationField();
                        validationField20.BlockType = current2.BlockType;
                        validationField20.BlockID = current2.BlockID;
                        validationField20.LengthInBits = 1U;
                        validationField20.PartitionID = current1.PartitionID;
                        sourceIndex = 19;
                        validationField20.OffsetInBits = (uint) (sourceIndex * 8 + 6);
                        validationField20.Content = new byte[1];
                        validationField20.Content[0] = (byte) 0;
                        validationFieldList.Add(validationField20);
                        num2 = (short) 56;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 61:
                        num2 = (short) 8;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 62:
                        validationField8.Content = new byte[(long) (validationField8.LengthInBits / 8U) + (validationField8.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField8.Content, 0, validationField8.Content.Length);
                        validationFieldList.Add(validationField8);
                        num2 = (short) 57;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 63 /*0x3F*/:
                        num6 = (int) current2.BlockID + 1;
                        validationField14 = new ValidationField();
                        validationField14.BlockType = current2.BlockType;
                        validationField14.BlockID = current2.BlockID;
                        validationField14.LengthInBits = 8U;
                        validationField14.PartitionID = current1.PartitionID;
                        sourceIndex = 1;
                        validationField14.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 22;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 64 /*0x40*/:
                        switch (blockType)
                        {
                          case 900:
                            validationField10 = new ValidationField();
                            validationField10.BlockType = current2.BlockType;
                            validationField10.BlockID = current2.BlockID;
                            validationField10.LengthInBits = 176U /*0xB0*/;
                            validationField10.PartitionID = current1.PartitionID;
                            sourceIndex = 1;
                            validationField10.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 31 /*0x1F*/;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          case 901:
                            validationField8 = new ValidationField();
                            validationField8.BlockType = current2.BlockType;
                            validationField8.BlockID = current2.BlockID;
                            validationField8.LengthInBits = 104U;
                            validationField8.PartitionID = current1.PartitionID;
                            sourceIndex = 1;
                            validationField8.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 62;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          case 902:
                            break;
                          case 903:
                            validationField9 = new ValidationField();
                            validationField9.BlockType = current2.BlockType;
                            validationField9.BlockID = current2.BlockID;
                            validationField9.LengthInBits = 7U;
                            validationField9.PartitionID = current1.PartitionID;
                            sourceIndex = 1;
                            validationField9.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 47;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          default:
                            num2 = (short) 52;
                            num7 = (int) (IntPtr) num2;
                            continue;
                        }
                        break;
                      case 65:
                        if (enumerator2.MoveNext())
                        {
                          current2 = enumerator2.Current;
                          sourceIndex = 0;
                          blockType = current2.BlockType;
                          num2 = (short) 50;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        }
                        num2 = (short) 61;
                        num7 = (int) (IntPtr) num2;
                        continue;
                      case 66:
                        validationFieldList.Add(validationField6);
                        num2 = (short) 33;
                        num7 = (int) (IntPtr) num2;
                        continue;
                    }
                    num2 = (short) 65;
                    num7 = (int) (IntPtr) num2;
                  }
                }
                finally
                {
                  enumerator2.Dispose();
                }
label_108:
                num5 = 2;
                continue;
              case 2:
                if (num6 > 0)
                {
                  num2 = (short) 5;
                  num5 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 3:
                num2 = (short) 4;
                num5 = (int) (IntPtr) num2;
                continue;
              case 4:
                goto label_129;
              case 5:
                ValidationField validationField21 = new ValidationField(validationField1);
                validationField21.BlockID = (ushort) num6;
                validationField21.Content = new byte[1];
                validationField21.Content[0] = Convert.ToByte(0);
                validationField21.BypassMissing = true;
                validationFieldList.Add(validationField21);
                num2 = (short) 6;
                num5 = (int) (IntPtr) num2;
                continue;
              case 7:
                if (enumerator1.MoveNext())
                {
                  current1 = enumerator1.Current;
                  num6 = 0;
                  validationField1 = (ValidationField) null;
                  enumerator2 = current1.DataBlocks.GetEnumerator();
                  num2 = (short) 1;
                  num5 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 3;
                num5 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 7;
            num5 = (int) (IntPtr) num2;
          }
        }
        finally
        {
          enumerator1.Dispose();
        }
label_129:
        return validationFieldList;
label_5:
        numArray = (byte[]) null;
        protectionOption = ProtectionOption.UNSPECIFIED;
        ishItemCollection = xpbaCodeplug.GetCodeplugInIshItemCollection();
        // ISSUE: explicit constructor call
        ((IshHeader) ref ishHeader).\u002Ector((byte) 212, (ushort) 901, (ushort) 0);
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto label_4;
    }
  }

  private static bool a(int A_0, int A_1, out TrkSysBandPlan A_2)
  {
    short num1 = 27141;
    int num2 = (int) num1;
    num1 = (short) 27141;
    int num3 = (int) num1;
    bool flag;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_31:
        return flag;
      default:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        A_2 = (TrkSysBandPlan) null;
        flag = false;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) (FeatureManager.GetFeature(2064) as TrunkingSystemRecset)).GetEnumerator();
        try
        {
          num4 = (short) 7;
          int num5 = (int) (IntPtr) num4;
          while (true)
          {
            Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem current;
            switch (num5)
            {
              case 0:
                if (!enumerator.MoveNext())
                {
                  num4 = (short) 3;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                current = (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator.Current;
                num4 = (short) 6;
                num5 = (int) (IntPtr) num4;
                continue;
              case 1:
                num4 = (short) 11;
                num5 = (int) (IntPtr) num4;
                continue;
              case 2:
                if (((AcpField<int>) current.General.TrkSysGeneralSystemType_A9252).Value == A_1)
                {
                  num4 = (short) 10;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                break;
              case 3:
                num4 = (short) 9;
                num5 = (int) (IntPtr) num4;
                continue;
              case 4:
                A_2 = new TrkSysBandPlan(((AcpField<int>) current.General.TrkSysGeneralSystemType_A9252).Value, ((AcpField<int>) current.General.TrkSysGeneralSystemID_A9239).Value, current.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128.Value);
                flag = true;
                num4 = (short) 8;
                num5 = (int) (IntPtr) num4;
                continue;
              case 5:
                num4 = (short) 2;
                num5 = (int) (IntPtr) num4;
                continue;
              case 6:
                if (((AcpField<int>) current.General.TrkSysGeneralSystemID_A9239).Value == A_0)
                {
                  num4 = (short) 5;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                break;
              case 7:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 8:
              case 9:
                goto label_31;
              case 10:
                ((FeatureSection) current.TypeIIChannelSetup).SetConstraints();
                num4 = (short) 12;
                num5 = (int) (IntPtr) num4;
                continue;
              case 11:
                if (!AcpField<bool>.op_Implicit(current.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128))
                {
                  num4 = (short) 4;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                break;
              case 12:
                if (((AcpFieldBase) current.TypeIIChannelSetup.TrkSysTypeIIChannelSetupShuffledBandPlan_A9128).IsVisible.Invoke((IAcpFeatureSection) current.TypeIIChannelSetup))
                {
                  num4 = (short) 1;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                break;
            }
            num4 = (short) 0;
            num5 = (int) (IntPtr) num4;
          }
        }
        finally
        {
          short num6 = 0;
          int num7 = (int) (IntPtr) num6;
          while (true)
          {
            switch (num7)
            {
              case 0:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 1:
                enumerator.Dispose();
                num6 = (short) 2;
                num7 = (int) (IntPtr) num6;
                continue;
              case 2:
                goto label_30;
            }
            if (enumerator != null)
            {
              num6 = (short) 1;
              num7 = (int) (IntPtr) num6;
            }
            else
              break;
          }
label_30:;
        }
    }
  }

  public static List<ValidationField> PopulateUpgradeValidationFields(PbaObject xpbaCodeplug)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 12676;
        IshItemCollection ishItemCollection;
        IshHeader ishHeader;
        switch ((short) 12676 == num2 ? 1 : 0)
        {
          case 0:
          case 2:
label_7:
            if (ishItemCollection.ContainsHeader(ishHeader))
            {
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              break;
            }
            goto label_46;
          default:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            switch (0)
            {
              case 0:
                goto label_6;
            }
            break;
        }
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 0;
              IshItem ishItem = ishItemCollection[ishHeader];
              byte[] data = ((IshItem) ref ishItem).Data;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_7;
            case 2:
              goto label_10;
            case 3:
              goto label_46;
            default:
              goto label_6;
          }
label_5:;
        }
label_10:
        List<DataPartition>.Enumerator enumerator1;
        List<ValidationField> validationFieldList;
        try
        {
          num2 = (short) 2;
          int num3 = (int) (IntPtr) num2;
          while (true)
          {
            DataPartition current1;
            List<DataBlock>.Enumerator enumerator2;
            switch (num3)
            {
              case 0:
                try
                {
                  num2 = (short) 14;
                  int num4 = (int) (IntPtr) num2;
                  while (true)
                  {
                    DataBlock current2;
                    int sourceIndex;
                    ushort blockType;
                    ValidationField validationField1;
                    ValidationField validationField2;
                    ValidationField validationField3;
                    ValidationField validationField4;
                    ValidationField validationField5;
                    switch (num4)
                    {
                      case 0:
                        num2 = (short) 3;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 1:
                        validationField5.Content = new byte[(long) (validationField5.LengthInBits / 8U) + (validationField5.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField5.Content, 0, validationField5.Content.Length);
                        validationField5.BypassMissing = true;
                        validationFieldList.Add(validationField5);
                        num2 = (short) 19;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 2:
                        validationField2.Content = new byte[(long) (validationField2.LengthInBits / 8U) + (validationField2.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField2.Content, 0, validationField2.Content.Length);
                        validationFieldList.Add(validationField2);
                        num2 = (short) 5;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 3:
                        if (blockType == (ushort) 1026)
                        {
                          num2 = (short) 17;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        }
                        break;
                      case 4:
                        validationField3.Content = new byte[(long) (validationField3.LengthInBits / 8U) + (validationField3.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField3.Content, 0, validationField3.Content.Length);
                        validationFieldList.Add(validationField3);
                        validationField4 = new ValidationField();
                        validationField4.BlockType = current2.BlockType;
                        validationField4.BlockID = current2.BlockID;
                        validationField4.LengthInBits = 272U;
                        validationField4.PartitionID = current1.PartitionID;
                        sourceIndex = 23;
                        validationField4.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 13;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 6:
                        validationField5 = new ValidationField();
                        validationField5.BlockType = current2.BlockType;
                        validationField5.BlockID = current2.BlockID;
                        validationField5.LengthInBits = (uint) (current2.LegthInBits - 24 - 8);
                        validationField5.PartitionID = current1.PartitionID;
                        sourceIndex = 2;
                        validationField5.OffsetInBits = (uint) (sourceIndex * 8);
                        num2 = (short) 1;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 8:
                        switch (blockType)
                        {
                          case 900:
                            validationField3 = new ValidationField();
                            validationField3.BlockType = current2.BlockType;
                            validationField3.BlockID = current2.BlockID;
                            validationField3.LengthInBits = 176U /*0xB0*/;
                            validationField3.PartitionID = current1.PartitionID;
                            sourceIndex = 1;
                            validationField3.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 4;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 901:
                            validationField2 = new ValidationField();
                            validationField2.BlockType = current2.BlockType;
                            validationField2.BlockID = current2.BlockID;
                            validationField2.LengthInBits = 104U;
                            validationField2.PartitionID = current1.PartitionID;
                            sourceIndex = 1;
                            validationField2.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 2;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          case 902:
                            break;
                          case 903:
                            validationField5 = new ValidationField();
                            validationField5.BlockType = current2.BlockType;
                            validationField5.BlockID = current2.BlockID;
                            validationField5.LengthInBits = 7U;
                            validationField5.PartitionID = current1.PartitionID;
                            sourceIndex = 1;
                            validationField5.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 18;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          default:
                            num2 = (short) 0;
                            num4 = (int) (IntPtr) num2;
                            continue;
                        }
                        break;
                      case 9:
                        goto label_14;
                      case 11:
                        validationField1.Content = new byte[(long) (validationField1.LengthInBits / 8U) + (validationField1.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField1.Content, 0, validationField1.Content.Length);
                        validationFieldList.Add(validationField1);
                        num2 = (short) 10;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 12:
                        num2 = (short) 9;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 13:
                        validationField4.Content = new byte[(long) (validationField4.LengthInBits / 8U) + (validationField4.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField4.Content, 0, validationField4.Content.Length);
                        validationFieldList.Add(validationField4);
                        num2 = (short) 7;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 14:
                        switch (0)
                        {
                          case 0:
                            break;
                          default:
                            continue;
                        }
                        break;
                      case 15:
                        if (current2.LegthInBits - 24 > 8)
                        {
                          num2 = (short) 6;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        }
                        break;
                      case 16 /*0x10*/:
                        if (enumerator2.MoveNext())
                        {
                          current2 = enumerator2.Current;
                          sourceIndex = 0;
                          blockType = current2.BlockType;
                          num2 = (short) 8;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        }
                        num2 = (short) 12;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 17:
                        validationField1 = new ValidationField();
                        validationField1.BlockType = current2.BlockType;
                        validationField1.BlockID = current2.BlockID;
                        validationField1.LengthInBits = 1U;
                        validationField1.PartitionID = current1.PartitionID;
                        sourceIndex = 21;
                        validationField1.OffsetInBits = (uint) (sourceIndex * 8 + 3);
                        num2 = (short) 11;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      case 18:
                        validationField5.Content = new byte[(long) (validationField5.LengthInBits / 8U) + (validationField5.LengthInBits % 8U == 0U ? 0L : 1L)];
                        Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField5.Content, 0, validationField5.Content.Length);
                        validationField5.BypassMissing = true;
                        validationFieldList.Add(validationField5);
                        num2 = (short) 15;
                        num4 = (int) (IntPtr) num2;
                        continue;
                    }
                    num2 = (short) 16 /*0x10*/;
                    num4 = (int) (IntPtr) num2;
                  }
                }
                finally
                {
                  enumerator2.Dispose();
                }
              case 1:
                num2 = (short) 4;
                num3 = (int) (IntPtr) num2;
                continue;
              case 2:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 3:
                if (enumerator1.MoveNext())
                {
                  current1 = enumerator1.Current;
                  enumerator2 = current1.DataBlocks.GetEnumerator();
                  num2 = (short) 0;
                  num3 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 1;
                num3 = (int) (IntPtr) num2;
                continue;
              case 4:
                goto label_47;
            }
label_14:
            num3 = 3;
          }
        }
        finally
        {
          enumerator1.Dispose();
        }
label_47:
        return validationFieldList;
label_6:
        ishItemCollection = xpbaCodeplug.GetCodeplugInIshItemCollection();
        // ISSUE: explicit constructor call
        ((IshHeader) ref ishHeader).\u002Ector((byte) 212, (ushort) 901, (ushort) 0);
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto label_5;
label_46:
        validationFieldList = new List<ValidationField>();
        enumerator1 = xpbaCodeplug.CodeplugData.DataPartitions.GetEnumerator();
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto label_5;
    }
  }

  public static List<ValidationInfo> PopulateUpgradeValidationInfos(
    PbaObject xpbaCodeplug,
    APXCodeplug currentcp,
    bool bRefresh)
  {
    int A_1 = 4;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 5528;
    int num2 = (int) num1;
    num1 = (short) 5528;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        List<ValidationInfo> validationInfoList = new List<ValidationInfo>();
        ValidationMethod validationMethod = (ValidationMethod) 1;
        if (!bRefresh || bRefresh && (currentcp.ExtendedFlags & 1) == 0)
          validationMethod = (ValidationMethod) 4;
        validationInfoList.Add(new ValidationInfo(RptMgrErrorHandler.b("풆\uE688\uED8A歷\uF88E\uF090\uE192\uF094솖ﲘ\uE99A\uEE9C\uF69E캠춢", A_1), ((Codeplug) currentcp).FirmwareVersion, validationMethod));
        return validationInfoList;
      default:
        goto case 1;
    }
  }

  public static List<ValidationInfo> PopulateLPValidationInfos(
    PbaObject xpbaCodeplug,
    APXCodeplug currentcp)
  {
    int A_1 = 18;
    short num1 = -21163;
    int num2 = (int) num1;
    num1 = (short) -21163;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        List<ValidationInfo> validationInfoList = new List<ValidationInfo>();
        ValidationMethod validationMethod = (ValidationMethod) 2;
        validationInfoList.Add(new ValidationInfo(RptMgrErrorHandler.b("요\uF896ﾘ\uEF9A\uEA9Cﺞ펠욢\uF3A4슦\uDBA8\uD8AA쒬삮\uDFB0", A_1), ((Codeplug) currentcp).FirmwareVersion, validationMethod));
        return validationInfoList;
      default:
        goto case 1;
    }
  }

  public static List<ValidationInfo> PopulateValidationInfosForRegularWrite(
    PbaObject xpbaCodeplug,
    APXCodeplug currentcp)
  {
    int A_1 = 10;
    List<ValidationInfo> validationInfoList = new List<ValidationInfo>();
    short num1;
    if (new Regex(RptMgrErrorHandler.b("ꖌ펎\uF590뢒즔릖얘ﾚ뚜쎞辠ﾢ솤貦肨", A_1)).Match(((Codeplug) currentcp).FirmwareVersion).Success)
    {
      num1 = (short) -10322;
      int num2 = (int) num1;
      num1 = (short) -10322;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          ValidationMethod validationMethod = (ValidationMethod) 0;
          validationInfoList.Add(new ValidationInfo(RptMgrErrorHandler.b("\uDE8C\uE08E\uF790\uE792\uE294\uF696\uEB98ﺚ쮜爵펠킢첤좦잨", A_1), ((Codeplug) currentcp).FirmwareVersion, validationMethod));
          return validationInfoList;
      }
    }
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    ValidationMethod validationMethod1 = (ValidationMethod) 1;
    validationInfoList.Add(new ValidationInfo(RptMgrErrorHandler.b("\uDE8C\uE08E\uF790\uE792\uE294\uF696\uEB98ﺚ쮜爵펠킢첤좦잨", A_1), RptMgrErrorHandler.b("\uDF8C뾎ꦐ붒ꖔꞖ래ꮚ궜놞醠鎢", A_1), validationMethod1));
    return validationInfoList;
  }

  public static ValidationField PopulateLanguageSettingValidationField(PbaObject xpbaCodeplug)
  {
    switch (0)
    {
      default:
        if (false)
          ;
        ValidationField validationField1;
        using (List<DataPartition>.Enumerator enumerator1 = xpbaCodeplug.CodeplugData.DataPartitions.GetEnumerator())
        {
          int num1 = 4;
          while (true)
          {
            short num2;
            DataPartition current1;
            List<DataBlock>.Enumerator enumerator2;
            switch (num1)
            {
              case 0:
                goto label_3;
              case 1:
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                num2 = (short) -8492;
                int num3 = (int) num2;
                num2 = (short) -8492;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    try
                    {
                      num2 = (short) 3;
                      int num5 = (int) (IntPtr) num2;
                      while (true)
                      {
                        ValidationField validationField2;
                        DataBlock current2;
                        int sourceIndex;
                        switch (num5)
                        {
                          case 0:
                            num2 = (short) 1;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          case 1:
                            goto label_7;
                          case 2:
                            if (enumerator2.MoveNext())
                            {
                              current2 = enumerator2.Current;
                              sourceIndex = 0;
                              num2 = (short) 6;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            }
                            num2 = (short) 0;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          case 3:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                          case 4:
                            validationField2 = new ValidationField();
                            validationField2.BlockType = current2.BlockType;
                            validationField2.BlockID = current2.BlockID;
                            validationField2.LengthInBits = 8U;
                            validationField2.PartitionID = current1.PartitionID;
                            sourceIndex = 56;
                            validationField2.OffsetInBits = (uint) (sourceIndex * 8);
                            num2 = (short) 7;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          case 5:
                            goto label_28;
                          case 6:
                            if (current2.BlockType == (ushort) 1026)
                            {
                              num2 = (short) 4;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            }
                            break;
                          case 7:
                            validationField2.Content = new byte[(long) (validationField2.LengthInBits / 8U) + (validationField2.LengthInBits % 8U == 0U ? 0L : 1L)];
                            Array.Copy((Array) current2.PacketValue, sourceIndex, (Array) validationField2.Content, 0, validationField2.Content.Length);
                            validationField1 = validationField2;
                            num2 = (short) 5;
                            num5 = (int) (IntPtr) num2;
                            continue;
                        }
                        num2 = (short) 2;
                        num5 = (int) (IntPtr) num2;
                      }
                    }
                    finally
                    {
                      enumerator2.Dispose();
                    }
                }
                break;
              case 3:
                if (!enumerator1.MoveNext())
                {
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                current1 = enumerator1.Current;
                enumerator2 = current1.DataBlocks.GetEnumerator();
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              case 4:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
            }
label_7:
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
          }
        }
label_3:
        return (ValidationField) null;
label_28:
        return validationField1;
    }
  }

  internal static void CheckAndReviseBlockList(List<IshHeader> blockList)
  {
    int num1;
    int index1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        index1 = 0;
        num2 = (short) 9;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          IshHeader block;
          switch (num1)
          {
            case 0:
              List<IshHeader> ishHeaderList1 = blockList;
              int index2 = index1;
              block = blockList[index1];
              int ishType1 = (int) ((IshHeader) ref block).IshType;
              block = blockList[index1];
              int ishId1 = (int) ((IshHeader) ref block).IshID;
              IshHeader ishHeader1 = new IshHeader((byte) 212, (ushort) ishType1, (ushort) ishId1);
              ishHeaderList1[index2] = ishHeader1;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              block = blockList[index1];
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
            case 5:
label_18:
              ++index1;
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (index1 >= blockList.Count)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              block = blockList[index1];
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (((IshHeader) ref block).IshType >= (ushort) 900)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 2;
            case 6:
              if (((IshHeader) ref block).IshType >= (ushort) 1000)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 7:
            case 9:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              block = blockList[index1];
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              goto label_25;
            case 11:
              List<IshHeader> ishHeaderList2 = blockList;
              int index3 = index1;
              block = blockList[index1];
              int ishType2 = (int) ((IshHeader) ref block).IshType;
              block = blockList[index1];
              int ishId2 = (int) ((IshHeader) ref block).IshID;
              IshHeader ishHeader2 = new IshHeader((byte) 208 /*0xD0*/, (ushort) ishType2, (ushort) ishId2);
              ishHeaderList2[index3] = ishHeader2;
              goto label_24;
            case 12:
              num2 = (short) 0;
              if (((IshHeader) ref block).IshType <= (ushort) 3999)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 13:
              num2 = (short) 29250;
              int num3 = (int) num2;
              num2 = (short) 29250;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_24;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (((IshHeader) ref block).IshType <= (ushort) 999)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_18;
              }
            default:
              goto label_2;
          }
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          block = blockList[index1];
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
label_24:
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
        }
label_25:
        break;
    }
  }

  internal static void CompareRadioParams(
    RadioParams codeplug,
    RadioParams radio,
    COMMS_OP writeType)
  {
    int num1 = 18;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 16 /*0x10*/;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_6;
        case 2:
          if (!string.IsNullOrEmpty(radio.ModelNumber))
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 15;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          goto label_24;
        case 5:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (!string.Equals(codeplug.ModelNumber, radio.ModelNumber))
          {
            num2 = (short) 13;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 6:
          num2 = (short) -780;
          int num3 = (int) num2;
          num2 = (short) -780;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_33;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              if (writeType != COMMS_OP.OTAP_READ_WRITE)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_24;
          }
        case 7:
          if (writeType != COMMS_OP.BLUETOOTH_CLONE)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_42;
        case 8:
          goto label_33;
        case 9:
          goto label_5;
        case 10:
          num2 = (short) 17;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          if (!string.IsNullOrEmpty(radio.SerialNumber))
          {
            num2 = (short) 22;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 12:
          if (string.IsNullOrEmpty(codeplug.SerialNumber))
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 14:
          num2 = (short) 23;
          num1 = (int) (IntPtr) num2;
          continue;
        case 15:
          goto label_17;
        case 16 /*0x10*/:
          if (writeType == COMMS_OP.BLUETOOTH_READ_WRITE)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 17:
          if (writeType != COMMS_OP.USB_READ_WRITE)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_24;
        case 18:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 19:
          goto label_38;
        case 20:
          if (writeType != COMMS_OP.OTAP_CLONE)
          {
            num2 = (short) 14;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_37;
        case 21:
          num2 = (short) 20;
          num1 = (int) (IntPtr) num2;
          continue;
        case 22:
          if (!string.Equals(codeplug.SerialNumber, radio.SerialNumber))
          {
            num2 = (short) 21;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_46;
        case 23:
          if (writeType != COMMS_OP.USB_CLONE)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_50;
        default:
label_3:
          if (string.IsNullOrEmpty(codeplug.ModelNumber))
          {
            num2 = (short) 19;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      num2 = (short) 12;
      num1 = (int) (IntPtr) num2;
    }
label_5:
    throw new ArgumentNullException(AppResources.The_Serial_Number_of_radio_is_NullOrEmpty);
label_6:
    throw new ArgumentNullException(AppResources.The_Serial_Number_of_codeplug_is_NullOrEmpty);
label_50:
    return;
label_17:
    num2 = (short) 0;
    throw new ArgumentNullException(AppResources.The_Model_Number_of_radio_is_NullOrEmpty);
label_46:
    return;
label_42:
    return;
label_24:
    throw new Exception(AppResources.Invalid_radio_model_number);
label_37:
    return;
label_33:
    throw new Exception(AppResources.Invalid_radio_serial_number);
label_38:
    throw new Exception(AppResources.The_Model_Number_of_codeplug_is_NullOrEmpty);
  }

  internal static bool FlashCodeMatch(string radioFlashInfo, string codeplgFlashInfo)
  {
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = false;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              flag = true;
              break;
            case 1:
              num2 = (short) 26086;
              int num3 = (int) num2;
              num2 = (short) 26086;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  goto label_9;
              }
              break;
            case 2:
              num2 = (short) 0;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (RadioOperationValidator.a(radioFlashInfo) == Encoding.ASCII.GetString(Convert.FromBase64String(codeplgFlashInfo)))
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            default:
              goto label_2;
          }
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
        }
label_9:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        return flag;
    }
  }

  private static string a(string A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        byte[] sourceArray;
        int sourceIndex;
        byte[] numArray;
        int index;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            sourceArray = Convert.FromBase64String(A_0);
            sourceIndex = 2;
            numArray = new byte[24];
            index = 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                case 7:
                  goto label_16;
                case 1:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 3:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  num2 = (short) 0;
                  Array.Copy((Array) sourceArray, sourceIndex, (Array) numArray, 0, 12);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (index < 24)
                  {
                    numArray[index] = (byte) 0;
                    ++index;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 6:
                  if (sourceArray.Length == 16 /*0x10*/)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  Array.Copy((Array) sourceArray, sourceIndex, (Array) numArray, 0, 24);
                  num2 = (short) -12045;
                  int num3 = (int) num2;
                  num2 = (short) -12045;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                default:
                  goto label_3;
              }
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
            }
label_16:
            return FlashcodeFormatter.FormatFlashcodeString(numArray, numArray.Length);
        }
    }
  }

  internal static void RadioFlashCodeCheck(PbaObject xpbaCodeplug, COMMS_OP WriteType)
  {
    int num1;
    string base64String;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        base64String = Convert.ToBase64String(ParseDataHelper.GetFDB(xpbaCodeplug));
        num2 = (short) 0;
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 1;
              if (num2 == (short) 0)
                break;
              break;
            case 1:
              if (!RadioOperationValidator.FlashCodeMatch(base64String, ParseDataHelper.getCodeplugFlashCode()))
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_23;
            case 2:
              if (WriteType != COMMS_OP.USB_READ_WRITE)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 3:
label_19:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (WriteType != COMMS_OP.OTAP_READ_WRITE)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 6:
              if (WriteType != COMMS_OP.USB_CLONE)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_17;
            case 7:
              if (WriteType == COMMS_OP.BLUETOOTH_READ_WRITE)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 8:
              num2 = (short) 18897;
              int num3 = (int) num2;
              num2 = (short) 18897;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_19;
                default:
                  goto label_9;
              }
            case 9:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
        }
label_23:
        break;
label_9:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        throw new Exception(AppResources.FlashCode_mismatch_cannot_write_to_radio);
label_17:
        break;
label_13:
        break;
    }
  }

  internal static bool PerformCompatibilityChecks(
    PbaObject pba,
    string cpgModelNumber,
    string radioModelNumber,
    ref string stsErrMsg)
  {
    short num1 = 9995;
    int num2 = (int) num1;
    num1 = (short) 9995;
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
        string flashcodeFromFbd = ParseDataHelper.GetRadioFlashcodeFromFBD(ParseDataHelper.GetFDB(pba));
        string flasHcodeA8132Value = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).FLASHport.RadInfoFLASHportFLASHcode_A8132Value;
        return new CompatibilityChecks(FeatureSetConstraints.getUsedFcodeValue(), flasHcodeA8132Value, flashcodeFromFbd, cpgModelNumber, radioModelNumber).PerfomChecks(ref stsErrMsg);
      default:
        goto case 1;
    }
  }

  internal static bool Is800MHzBandEnabledInRadio(RadioParams curRadioParms, PbaObject pba)
  {
    short num1 = -29451;
    int num2 = (int) num1;
    num1 = (short) -29451;
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
        string flashcodeFromFbd = ParseDataHelper.GetRadioFlashcodeFromFBD(ParseDataHelper.GetFDB(pba));
        return RadioAccessValidator.Is800MHzBandEnabled(curRadioParms.ModelNumber, flashcodeFromFbd);
      default:
        goto case 1;
    }
  }

  public static bool IsRadioConvOnly(string modelNumber, string flashCode, bool fromCodeplug)
  {
    short num1 = -5725;
    int num2 = (int) num1;
    num1 = (short) -5725;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        return RadioAccessValidator.IsConvOnly(modelNumber, flashCode, fromCodeplug);
      default:
        goto case 1;
    }
  }
}

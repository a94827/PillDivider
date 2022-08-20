using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FreeLibSet.Forms;
using FreeLibSet.Core;
using FreeLibSet.Config;

namespace PillDivider
{
  public partial class MainForm : Form
  {
    #region �����������

    public MainForm()
    {
      InitializeComponent();
      Icon = WinFormsTools.AppIcon;

      efpForm = new EFPFormProvider(this);

      efpMode = new EFPRadioButtons(efpForm, rbPill);

      efpGrammage = new EFPDoubleEditBox(efpForm, edGrammage);
      efpGrammage.Minimum = 0.001;
      efpGrammage.EnabledEx = efpMode[0].CheckedEx;

      efpConcentration = new EFPDoubleEditBox(efpForm, edConcentartion);
      efpConcentration.Minimum = 0.001;
      efpConcentration.EnabledEx = efpMode[1].CheckedEx;

      efpDoze = new EFPDoubleEditBox(efpForm, edDoze);
      efpDoze.Minimum = 0.000001;

      efpDozeMU = new EFPListComboBox(efpForm, cbDozeMU);
      efpDozeMU.Codes = new string[] { "��/��" };
      efpDozeMU.SelectedIndex = 0;
      efpDozeMU.CanBeEmpty = false;

      efpMass = new EFPDoubleEditBox(efpForm, edMass);
      efpMass.Minimum = 1;

      EFPButton efpOk = new EFPButton(efpForm, btnOk);
      efpOk.Click += new EventHandler(efpOk_Click);

      try
      {
        LoadValues();
      }
      catch { }
    }

    #endregion

    #region ����

    EFPFormProvider efpForm;
    EFPRadioButtons efpMode;
    EFPDoubleEditBox efpGrammage;
    EFPDoubleEditBox efpConcentration;
    EFPDoubleEditBox efpDoze;
    EFPListComboBox efpDozeMU;
    EFPDoubleEditBox efpMass;

    #endregion

    #region ������

    void efpOk_Click(object sender, EventArgs args)
    {
      if (!efpForm.ValidateForm())
        return;

      try
      {
        SaveValues();
      }
      catch { }

      double doze; // � ��/�
      switch (efpDozeMU.SelectedIndex)
      {
        case 0:
          doze = efpDoze.Value / 1000.0;
          break;
        default:
          throw new BugException("����������� ������� ���������");
      }

      double mass = efpMass.Value;
      double doze2 = doze * mass;

      StringBuilder sb = new StringBuilder();
      sb.Append("��� ��������� � ������ ");
      sb.Append(mass);
      sb.Append(" �. ��������� ���� ");
      sb.Append(doze2);
      sb.Append(" ��.");
      sb.Append(Environment.NewLine);

      if (efpMode.SelectedIndex == 0)
      {
        // ��������
        double grammage = efpGrammage.Value; // � ��
        double pillCount = doze * mass / grammage;

        sb.Append("��� ���������� ");
        sb.Append(pillCount.ToString("0.0##"));
        sb.Append(" ��������");

        if (pillCount < 1.0)
        {
          double x1 = Math.Round(1.0 / pillCount, 0, MidpointRounding.AwayFromZero);
          double pc2 = 1.0 / x1;
          double dev = Math.Abs(pillCount - pc2) / pillCount * 100;
          if (dev <= 20.0)
          {
            sb.Append(" (1/");
            sb.Append(x1);
            sb.Append(" ��������");
            if (dev > 1.0)
            {
              sb.Append(" � ��������� ");
              sb.Append(dev.ToString("0"));
              sb.Append("%");
            }
            sb.Append(")");
          }
        }
      }
      else
      {
        // ��������
        double concentration = efpConcentration.Value; // � ��/��
        double volume = doze * mass / concentration;

        sb.Append("��� ���������� ");
        sb.Append(volume.ToString("0.0##"));
        sb.Append(" �� ��������");
      }

      EFPApp.MessageBox(sb.ToString(), "���������");
    }

    #endregion

    #region �������� �������� ����� �������� ������

    const string RegKeyName = @"HKEY_CURRENT_USER\SOFTWARE\a94827\PillDivider";

    private void SaveValues()
    {
      using (RegistryCfg cfg = new RegistryCfg(RegKeyName, false))
      {
        cfg.SetInt("�����", efpMode.SelectedIndex);
        cfg.SetDouble("����������", efpGrammage.Value);
        cfg.SetDouble("������������", efpConcentration.Value);
        cfg.SetDouble("���������", efpDoze.Value);
        cfg.SetString("��������������", efpDozeMU.SelectedCode);
        cfg.SetDouble("�����", efpMass.Value);
      }
    }

    private void LoadValues()
    {
      using (RegistryCfg cfg = new RegistryCfg(RegKeyName, true))
      {
        efpMode.SelectedIndex = cfg.GetInt("�����");
        efpGrammage.Value = cfg.GetDouble("����������");
        efpConcentration.Value = cfg.GetDouble("������������");
        efpDoze.Value = cfg.GetDouble("���������");
        efpDozeMU.SelectedCode = cfg.GetString("��������������");
        if (efpDozeMU.SelectedIndex < 0)
          efpDozeMU.SelectedIndex = 0;
        efpMass.Value = cfg.GetDouble("�����");
      }
    }

    #endregion
  }
}
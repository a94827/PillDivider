using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AgeyevAV.ExtForms;
using AgeyevAV;
using AgeyevAV.Config;

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

      efpGrammage = new EFPNumEditBox(efpForm, edGrammage);
      efpGrammage.Minimum = 0.001m;
      efpGrammage.EnabledEx = efpMode[0].CheckedEx;

      efpConcentration = new EFPNumEditBox(efpForm, edConcentartion);
      efpConcentration.Minimum = 0.001m;
      efpConcentration.EnabledEx = efpMode[1].CheckedEx;

      efpDoze = new EFPNumEditBox(efpForm, edDoze);
      efpDoze.Minimum = 0.000001m;

      efpDozeMU = new EFPListComboBox(efpForm, cbDozeMU);
      efpDozeMU.Codes = new string[] { "��/��" };
      efpDozeMU.SelectedIndex = 0;
      efpDozeMU.CanBeEmpty = false;

      efpMass = new EFPNumEditBox(efpForm, edMass);
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
    EFPNumEditBox efpGrammage;
    EFPNumEditBox efpConcentration;
    EFPNumEditBox efpDoze;
    EFPListComboBox efpDozeMU;
    EFPNumEditBox efpMass;

    #endregion

    #region ������

    void efpOk_Click(object Sender, EventArgs Args)
    {
      if (!efpForm.ValidateForm())
        return;

      try
      {
        SaveValues();
      }
      catch { }

      double Doze; // � ��/�
      switch (efpDozeMU.SelectedIndex)
      {
        case 0:
          Doze = efpDoze.DoubleValue / 1000.0;
          break;
        default:
          throw new BugException("����������� ������� ���������");
      }

      double Mass = efpMass.DoubleValue;
      double Doze2 = Doze * Mass;

      StringBuilder sb = new StringBuilder();
      sb.Append("��� ��������� � ������ ");
      sb.Append(Mass);
      sb.Append(" �. ��������� ���� ");
      sb.Append(Doze2);
      sb.Append(" ��.");
      sb.Append(Environment.NewLine);

      if (efpMode.SelectedIndex == 0)
      {
        // ��������
        double Grammage = efpGrammage.DoubleValue; // � ��
        double PillCount = Doze * Mass / Grammage;

        sb.Append("��� ���������� ");
        sb.Append(PillCount.ToString("0.0##"));
        sb.Append(" ��������");

        if (PillCount < 1.0)
        {
          double x1 = Math.Round(1.0 / PillCount, 0, MidpointRounding.AwayFromZero);
          double pc2 = 1.0 / x1;
          double dev = Math.Abs(PillCount - pc2) / PillCount * 100;
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
        double Concentration = efpConcentration.DoubleValue; // � ��/��
        double Volume = Doze * Mass / Concentration;

        sb.Append("��� ���������� ");
        sb.Append(Volume.ToString("0.0##"));
        sb.Append(" �� ��������");
      }

      EFPApp.MessageBox(sb.ToString(), "���������");
    }

    #endregion

    #region �������� �������� ����� �������� ������

    const string RegKeyName = @"HKEY_CURRENT_USER\SOFTWARE\a94827\PillDivider";

    private void SaveValues()
    {
      using (RegistryCfg Cfg = new RegistryCfg(RegKeyName, false))
      {
        Cfg.SetInt("�����", efpMode.SelectedIndex);
        Cfg.SetDouble("����������", efpGrammage.DoubleValue);
        Cfg.SetDouble("������������", efpConcentration.DoubleValue);
        Cfg.SetDouble("���������", efpDoze.DoubleValue);
        Cfg.SetString("��������������", efpDozeMU.SelectedCode);
        Cfg.SetDouble("�����", efpMass.DoubleValue);
      }
    }

    private void LoadValues()
    {
      using (RegistryCfg Cfg = new RegistryCfg(RegKeyName, true))
      {
        efpMode.SelectedIndex = Cfg.GetInt("�����");
        efpGrammage.DoubleValue = Cfg.GetDouble("����������");
        efpConcentration.DoubleValue = Cfg.GetDouble("������������");
        efpDoze.DoubleValue = Cfg.GetDouble("���������");
        efpDozeMU.SelectedCode = Cfg.GetString("��������������");
        if (efpDozeMU.SelectedIndex < 0)
          efpDozeMU.SelectedIndex = 0;
        efpMass.DoubleValue = Cfg.GetDouble("�����");
      }
    }

    #endregion
  }
}
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
    #region Конструктор

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
      efpDozeMU.Codes = new string[] { "мг/кг" };
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

    #region Поля

    EFPFormProvider efpForm;
    EFPRadioButtons efpMode;
    EFPNumEditBox efpGrammage;
    EFPNumEditBox efpConcentration;
    EFPNumEditBox efpDoze;
    EFPListComboBox efpDozeMU;
    EFPNumEditBox efpMass;

    #endregion

    #region Расчет

    void efpOk_Click(object Sender, EventArgs Args)
    {
      if (!efpForm.ValidateForm())
        return;

      try
      {
        SaveValues();
      }
      catch { }

      double Doze; // в мг/г
      switch (efpDozeMU.SelectedIndex)
      {
        case 0:
          Doze = efpDoze.DoubleValue / 1000.0;
          break;
        default:
          throw new BugException("Неизвестная единица измерения");
      }

      double Mass = efpMass.DoubleValue;
      double Doze2 = Doze * Mass;

      StringBuilder sb = new StringBuilder();
      sb.Append("Для животного с массой ");
      sb.Append(Mass);
      sb.Append(" г. требуется доза ");
      sb.Append(Doze2);
      sb.Append(" мг.");
      sb.Append(Environment.NewLine);

      if (efpMode.SelectedIndex == 0)
      {
        // таблетка
        double Grammage = efpGrammage.DoubleValue; // в мг
        double PillCount = Doze * Mass / Grammage;

        sb.Append("Это составляет ");
        sb.Append(PillCount.ToString("0.0##"));
        sb.Append(" таблетки");

        if (PillCount < 1.0)
        {
          double x1 = Math.Round(1.0 / PillCount, 0, MidpointRounding.AwayFromZero);
          double pc2 = 1.0 / x1;
          double dev = Math.Abs(PillCount - pc2) / PillCount * 100;
          if (dev <= 20.0)
          {
            sb.Append(" (1/");
            sb.Append(x1);
            sb.Append(" таблетки");
            if (dev > 1.0)
            {
              sb.Append(" с точностью ");
              sb.Append(dev.ToString("0"));
              sb.Append("%");
            }
            sb.Append(")");
          }
        }
      }
      else
      {
        // Жидкость
        double Concentration = efpConcentration.DoubleValue; // в мг/мл
        double Volume = Doze * Mass / Concentration;

        sb.Append("Это составляет ");
        sb.Append(Volume.ToString("0.0##"));
        sb.Append(" мл раствора");
      }

      EFPApp.MessageBox(sb.ToString(), "Результат");
    }

    #endregion

    #region Хранение значение между сеансами работы

    const string RegKeyName = @"HKEY_CURRENT_USER\SOFTWARE\a94827\PillDivider";

    private void SaveValues()
    {
      using (RegistryCfg Cfg = new RegistryCfg(RegKeyName, false))
      {
        Cfg.SetInt("Режим", efpMode.SelectedIndex);
        Cfg.SetDouble("Грамматура", efpGrammage.DoubleValue);
        Cfg.SetDouble("Концентрация", efpConcentration.DoubleValue);
        Cfg.SetDouble("Дозировка", efpDoze.DoubleValue);
        Cfg.SetString("ЕдИзмДозировки", efpDozeMU.SelectedCode);
        Cfg.SetDouble("Масса", efpMass.DoubleValue);
      }
    }

    private void LoadValues()
    {
      using (RegistryCfg Cfg = new RegistryCfg(RegKeyName, true))
      {
        efpMode.SelectedIndex = Cfg.GetInt("Режим");
        efpGrammage.DoubleValue = Cfg.GetDouble("Грамматура");
        efpConcentration.DoubleValue = Cfg.GetDouble("Концентрация");
        efpDoze.DoubleValue = Cfg.GetDouble("Дозировка");
        efpDozeMU.SelectedCode = Cfg.GetString("ЕдИзмДозировки");
        if (efpDozeMU.SelectedIndex < 0)
          efpDozeMU.SelectedIndex = 0;
        efpMass.DoubleValue = Cfg.GetDouble("Масса");
      }
    }

    #endregion
  }
}
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
    #region Конструктор

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
      efpDozeMU.Codes = new string[] { "мг/кг" };
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

    #region Поля

    EFPFormProvider efpForm;
    EFPRadioButtons efpMode;
    EFPDoubleEditBox efpGrammage;
    EFPDoubleEditBox efpConcentration;
    EFPDoubleEditBox efpDoze;
    EFPListComboBox efpDozeMU;
    EFPDoubleEditBox efpMass;

    #endregion

    #region Расчет

    void efpOk_Click(object sender, EventArgs args)
    {
      if (!efpForm.ValidateForm())
        return;

      try
      {
        SaveValues();
      }
      catch { }

      double doze; // в мг/г
      switch (efpDozeMU.SelectedIndex)
      {
        case 0:
          doze = efpDoze.Value / 1000.0;
          break;
        default:
          throw new BugException("Неизвестная единица измерения");
      }

      double mass = efpMass.Value;
      double doze2 = doze * mass;

      StringBuilder sb = new StringBuilder();
      sb.Append("Для животного с массой ");
      sb.Append(mass);
      sb.Append(" г. требуется доза ");
      sb.Append(doze2);
      sb.Append(" мг.");
      sb.Append(Environment.NewLine);

      if (efpMode.SelectedIndex == 0)
      {
        // таблетка
        double grammage = efpGrammage.Value; // в мг
        double pillCount = doze * mass / grammage;

        sb.Append("Это составляет ");
        sb.Append(pillCount.ToString("0.0##"));
        sb.Append(" таблетки");

        if (pillCount < 1.0)
        {
          double x1 = Math.Round(1.0 / pillCount, 0, MidpointRounding.AwayFromZero);
          double pc2 = 1.0 / x1;
          double dev = Math.Abs(pillCount - pc2) / pillCount * 100;
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
        double concentration = efpConcentration.Value; // в мг/мл
        double volume = doze * mass / concentration;

        sb.Append("Это составляет ");
        sb.Append(volume.ToString("0.0##"));
        sb.Append(" мл раствора");
      }

      EFPApp.MessageBox(sb.ToString(), "Результат");
    }

    #endregion

    #region Хранение значение между сеансами работы

    const string RegKeyName = @"HKEY_CURRENT_USER\SOFTWARE\a94827\PillDivider";

    private void SaveValues()
    {
      using (RegistryCfg cfg = new RegistryCfg(RegKeyName, false))
      {
        cfg.SetInt("Режим", efpMode.SelectedIndex);
        cfg.SetDouble("Грамматура", efpGrammage.Value);
        cfg.SetDouble("Концентрация", efpConcentration.Value);
        cfg.SetDouble("Дозировка", efpDoze.Value);
        cfg.SetString("ЕдИзмДозировки", efpDozeMU.SelectedCode);
        cfg.SetDouble("Масса", efpMass.Value);
      }
    }

    private void LoadValues()
    {
      using (RegistryCfg cfg = new RegistryCfg(RegKeyName, true))
      {
        efpMode.SelectedIndex = cfg.GetInt("Режим");
        efpGrammage.Value = cfg.GetDouble("Грамматура");
        efpConcentration.Value = cfg.GetDouble("Концентрация");
        efpDoze.Value = cfg.GetDouble("Дозировка");
        efpDozeMU.SelectedCode = cfg.GetString("ЕдИзмДозировки");
        if (efpDozeMU.SelectedIndex < 0)
          efpDozeMU.SelectedIndex = 0;
        efpMass.Value = cfg.GetDouble("Масса");
      }
    }

    #endregion
  }
}
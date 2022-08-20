namespace PillDivider
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label4 = new System.Windows.Forms.Label();
      this.edMass = new FreeLibSet.Controls.DoubleEditBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cbDozeMU = new System.Windows.Forms.ComboBox();
      this.edDoze = new FreeLibSet.Controls.DoubleEditBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnOk = new System.Windows.Forms.Button();
      this.edGrammage = new FreeLibSet.Controls.DoubleEditBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.edConcentartion = new FreeLibSet.Controls.DoubleEditBox();
      this.label7 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.rbPill = new System.Windows.Forms.RadioButton();
      this.rbLiquid = new System.Windows.Forms.RadioButton();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(227, 142);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 20);
      this.label4.TabIndex = 12;
      this.label4.Text = "г";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edMass
      // 
      this.edMass.Location = new System.Drawing.Point(142, 144);
      this.edMass.Name = "edMass";
      this.edMass.Size = new System.Drawing.Size(79, 20);
      this.edMass.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(6, 144);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(132, 20);
      this.label5.TabIndex = 10;
      this.label5.Text = "Вес животного";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cbDozeMU
      // 
      this.cbDozeMU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDozeMU.FormattingEnabled = true;
      this.cbDozeMU.Items.AddRange(new object[] {
            "мг/кг"});
      this.cbDozeMU.Location = new System.Drawing.Point(227, 118);
      this.cbDozeMU.Name = "cbDozeMU";
      this.cbDozeMU.Size = new System.Drawing.Size(87, 21);
      this.cbDozeMU.TabIndex = 9;
      // 
      // edDoze
      // 
      this.edDoze.Location = new System.Drawing.Point(142, 118);
      this.edDoze.Name = "edDoze";
      this.edDoze.Size = new System.Drawing.Size(79, 20);
      this.edDoze.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(6, 118);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(132, 20);
      this.label3.TabIndex = 7;
      this.label3.Text = "Дозировка";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(229, 66);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "мг";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnOk);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 170);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(344, 40);
      this.panel1.TabIndex = 2;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(8, 8);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(88, 24);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "O&K";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // edGrammage
      // 
      this.edGrammage.Location = new System.Drawing.Point(142, 66);
      this.edGrammage.Name = "edGrammage";
      this.edGrammage.Size = new System.Drawing.Size(79, 20);
      this.edGrammage.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(6, 66);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(132, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Грамматура таблетки";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.panel2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.edGrammage);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.edConcentartion);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.edDoze);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.cbDozeMU);
      this.groupBox1.Controls.Add(this.edMass);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(344, 210);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Исходные данные";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(6, 92);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(132, 20);
      this.label6.TabIndex = 4;
      this.label6.Text = "Концентрация ДВ";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // edConcentartion
      // 
      this.edConcentartion.Location = new System.Drawing.Point(142, 92);
      this.edConcentartion.Name = "edConcentartion";
      this.edConcentartion.Size = new System.Drawing.Size(79, 20);
      this.edConcentartion.TabIndex = 5;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(229, 91);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(79, 20);
      this.label7.TabIndex = 6;
      this.label7.Text = "мг/мл";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.rbLiquid);
      this.panel2.Controls.Add(this.rbPill);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(3, 16);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(338, 35);
      this.panel2.TabIndex = 0;
      // 
      // rbPill
      // 
      this.rbPill.AutoSize = true;
      this.rbPill.Location = new System.Drawing.Point(9, 11);
      this.rbPill.Name = "rbPill";
      this.rbPill.Size = new System.Drawing.Size(73, 17);
      this.rbPill.TabIndex = 0;
      this.rbPill.TabStop = true;
      this.rbPill.Text = "Таблетка";
      this.rbPill.UseVisualStyleBackColor = true;
      // 
      // rbLiquid
      // 
      this.rbLiquid.AutoSize = true;
      this.rbLiquid.Location = new System.Drawing.Point(141, 11);
      this.rbLiquid.Name = "rbLiquid";
      this.rbLiquid.Size = new System.Drawing.Size(67, 17);
      this.rbLiquid.TabIndex = 1;
      this.rbLiquid.TabStop = true;
      this.rbLiquid.Text = "Раствор";
      this.rbLiquid.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(344, 210);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "Делитель таблетки";
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private FreeLibSet.Controls.DoubleEditBox edMass;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbDozeMU;
    private FreeLibSet.Controls.DoubleEditBox edDoze;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnOk;
    private FreeLibSet.Controls.DoubleEditBox edGrammage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label6;
    private FreeLibSet.Controls.DoubleEditBox edConcentartion;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.RadioButton rbLiquid;
    private System.Windows.Forms.RadioButton rbPill;
  }
}
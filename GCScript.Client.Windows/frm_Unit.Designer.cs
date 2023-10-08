namespace GCScript.Client.Windows
{
    partial class frm_Unit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Unit));
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            btn_SearchCnpj = new DevExpress.XtraEditors.SimpleButton();
            chk_ClearFields = new DevExpress.XtraEditors.CheckEdit();
            btn_Create = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            cmb_Operators = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            cmb_Companies = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txt_Name = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            txt_Username = new DevExpress.XtraEditors.TextEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            txt_Password = new DevExpress.XtraEditors.TextEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            txt_CNPJ = new DevExpress.XtraEditors.TextEdit();
            chk_DoNotInformCnpj = new DevExpress.XtraEditors.CheckEdit();
            ssm_Main = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(pi_Loading), true, true);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chk_ClearFields.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Operators.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Companies.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_Name.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_Username.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_Password.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_CNPJ.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chk_DoNotInformCnpj.Properties).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F) });
            tablePanel1.Controls.Add(btn_SearchCnpj);
            tablePanel1.Controls.Add(chk_ClearFields);
            tablePanel1.Controls.Add(btn_Create);
            tablePanel1.Controls.Add(labelControl1);
            tablePanel1.Controls.Add(cmb_Operators);
            tablePanel1.Controls.Add(labelControl2);
            tablePanel1.Controls.Add(cmb_Companies);
            tablePanel1.Controls.Add(labelControl3);
            tablePanel1.Controls.Add(txt_Name);
            tablePanel1.Controls.Add(labelControl4);
            tablePanel1.Controls.Add(txt_Username);
            tablePanel1.Controls.Add(labelControl5);
            tablePanel1.Controls.Add(txt_Password);
            tablePanel1.Controls.Add(labelControl6);
            tablePanel1.Controls.Add(txt_CNPJ);
            tablePanel1.Controls.Add(chk_DoNotInformCnpj);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 0F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F) });
            tablePanel1.Size = new System.Drawing.Size(348, 349);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // btn_SearchCnpj
            // 
            tablePanel1.SetColumn(btn_SearchCnpj, 2);
            btn_SearchCnpj.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_SearchCnpj.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_SearchCnpj.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_SearchCnpj.ImageOptions.SvgImage");
            btn_SearchCnpj.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            btn_SearchCnpj.Location = new System.Drawing.Point(299, 120);
            btn_SearchCnpj.Name = "btn_SearchCnpj";
            tablePanel1.SetRow(btn_SearchCnpj, 6);
            btn_SearchCnpj.Size = new System.Drawing.Size(36, 20);
            btn_SearchCnpj.TabIndex = 16;
            btn_SearchCnpj.Click += btn_SearchCnpj_Click;
            // 
            // chk_ClearFields
            // 
            tablePanel1.SetColumn(chk_ClearFields, 0);
            tablePanel1.SetColumnSpan(chk_ClearFields, 2);
            chk_ClearFields.Dock = System.Windows.Forms.DockStyle.Fill;
            chk_ClearFields.EditValue = true;
            chk_ClearFields.Location = new System.Drawing.Point(13, 276);
            chk_ClearFields.Name = "chk_ClearFields";
            chk_ClearFields.Properties.Caption = "Limpar campos após cadastro";
            tablePanel1.SetRow(chk_ClearFields, 13);
            chk_ClearFields.Size = new System.Drawing.Size(282, 16);
            chk_ClearFields.TabIndex = 15;
            // 
            // btn_Create
            // 
            tablePanel1.SetColumn(btn_Create, 0);
            tablePanel1.SetColumnSpan(btn_Create, 3);
            btn_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_Create.Location = new System.Drawing.Point(13, 296);
            btn_Create.Name = "btn_Create";
            tablePanel1.SetRow(btn_Create, 14);
            btn_Create.Size = new System.Drawing.Size(322, 40);
            btn_Create.TabIndex = 6;
            btn_Create.Text = "CADASTRAR";
            btn_Create.Click += btn_Create_Click;
            // 
            // labelControl1
            // 
            tablePanel1.SetColumn(labelControl1, 0);
            labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl1.Location = new System.Drawing.Point(14, 13);
            labelControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl1.Name = "labelControl1";
            tablePanel1.SetRow(labelControl1, 1);
            labelControl1.Size = new System.Drawing.Size(137, 17);
            labelControl1.TabIndex = 3;
            labelControl1.Text = "Operadora";
            // 
            // cmb_Operators
            // 
            tablePanel1.SetColumn(cmb_Operators, 0);
            tablePanel1.SetColumnSpan(cmb_Operators, 3);
            cmb_Operators.Dock = System.Windows.Forms.DockStyle.Fill;
            cmb_Operators.Location = new System.Drawing.Point(13, 32);
            cmb_Operators.Name = "cmb_Operators";
            cmb_Operators.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmb_Operators.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            tablePanel1.SetRow(cmb_Operators, 2);
            cmb_Operators.Size = new System.Drawing.Size(322, 20);
            cmb_Operators.TabIndex = 0;
            // 
            // labelControl2
            // 
            tablePanel1.SetColumn(labelControl2, 0);
            labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl2.Location = new System.Drawing.Point(14, 57);
            labelControl2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl2.Name = "labelControl2";
            tablePanel1.SetRow(labelControl2, 3);
            labelControl2.Size = new System.Drawing.Size(137, 17);
            labelControl2.TabIndex = 4;
            labelControl2.Text = "Empresa";
            // 
            // cmb_Companies
            // 
            tablePanel1.SetColumn(cmb_Companies, 0);
            tablePanel1.SetColumnSpan(cmb_Companies, 3);
            cmb_Companies.Dock = System.Windows.Forms.DockStyle.Fill;
            cmb_Companies.Location = new System.Drawing.Point(13, 76);
            cmb_Companies.Name = "cmb_Companies";
            cmb_Companies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmb_Companies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            tablePanel1.SetRow(cmb_Companies, 4);
            cmb_Companies.Size = new System.Drawing.Size(322, 20);
            cmb_Companies.TabIndex = 1;
            // 
            // labelControl3
            // 
            tablePanel1.SetColumn(labelControl3, 0);
            labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl3.Location = new System.Drawing.Point(14, 145);
            labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl3.Name = "labelControl3";
            tablePanel1.SetRow(labelControl3, 7);
            labelControl3.Size = new System.Drawing.Size(137, 17);
            labelControl3.TabIndex = 5;
            labelControl3.Text = "Nome";
            // 
            // txt_Name
            // 
            tablePanel1.SetColumn(txt_Name, 0);
            tablePanel1.SetColumnSpan(txt_Name, 3);
            txt_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_Name.EditValue = "";
            txt_Name.Location = new System.Drawing.Point(13, 164);
            txt_Name.Name = "txt_Name";
            txt_Name.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txt_Name.Properties.MaxLength = 64;
            tablePanel1.SetRow(txt_Name, 8);
            txt_Name.Size = new System.Drawing.Size(322, 20);
            txt_Name.TabIndex = 3;
            txt_Name.KeyPress += txt_Name_KeyPress;
            txt_Name.Validating += txt_Name_Validating;
            // 
            // labelControl4
            // 
            tablePanel1.SetColumn(labelControl4, 0);
            labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl4.Location = new System.Drawing.Point(14, 189);
            labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl4.Name = "labelControl4";
            tablePanel1.SetRow(labelControl4, 9);
            labelControl4.Size = new System.Drawing.Size(137, 17);
            labelControl4.TabIndex = 6;
            labelControl4.Text = "Usuario";
            // 
            // txt_Username
            // 
            tablePanel1.SetColumn(txt_Username, 0);
            tablePanel1.SetColumnSpan(txt_Username, 3);
            txt_Username.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_Username.Location = new System.Drawing.Point(13, 208);
            txt_Username.Name = "txt_Username";
            txt_Username.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            txt_Username.Properties.MaxLength = 64;
            tablePanel1.SetRow(txt_Username, 10);
            txt_Username.Size = new System.Drawing.Size(322, 20);
            txt_Username.TabIndex = 4;
            txt_Username.KeyPress += txt_Username_KeyPress;
            // 
            // labelControl5
            // 
            tablePanel1.SetColumn(labelControl5, 0);
            labelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl5.Location = new System.Drawing.Point(14, 233);
            labelControl5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl5.Name = "labelControl5";
            tablePanel1.SetRow(labelControl5, 11);
            labelControl5.Size = new System.Drawing.Size(137, 17);
            labelControl5.TabIndex = 7;
            labelControl5.Text = "Senha";
            // 
            // txt_Password
            // 
            tablePanel1.SetColumn(txt_Password, 0);
            tablePanel1.SetColumnSpan(txt_Password, 3);
            txt_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_Password.Location = new System.Drawing.Point(13, 252);
            txt_Password.Name = "txt_Password";
            txt_Password.Properties.MaxLength = 64;
            tablePanel1.SetRow(txt_Password, 12);
            txt_Password.Size = new System.Drawing.Size(322, 20);
            txt_Password.TabIndex = 5;
            txt_Password.KeyPress += txt_Password_KeyPress;
            // 
            // labelControl6
            // 
            labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(241, 241, 241);
            labelControl6.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(labelControl6, 0);
            labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl6.Location = new System.Drawing.Point(14, 101);
            labelControl6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl6.Name = "labelControl6";
            tablePanel1.SetRow(labelControl6, 5);
            labelControl6.Size = new System.Drawing.Size(137, 17);
            labelControl6.TabIndex = 11;
            labelControl6.Text = "CNPJ";
            // 
            // txt_CNPJ
            // 
            tablePanel1.SetColumn(txt_CNPJ, 0);
            tablePanel1.SetColumnSpan(txt_CNPJ, 3);
            txt_CNPJ.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_CNPJ.Location = new System.Drawing.Point(13, 120);
            txt_CNPJ.Name = "txt_CNPJ";
            txt_CNPJ.Properties.MaxLength = 18;
            tablePanel1.SetRow(txt_CNPJ, 6);
            txt_CNPJ.Size = new System.Drawing.Size(322, 20);
            txt_CNPJ.TabIndex = 2;
            txt_CNPJ.Leave += txt_CNPJ_Leave;
            // 
            // chk_DoNotInformCnpj
            // 
            tablePanel1.SetColumn(chk_DoNotInformCnpj, 1);
            tablePanel1.SetColumnSpan(chk_DoNotInformCnpj, 2);
            chk_DoNotInformCnpj.Dock = System.Windows.Forms.DockStyle.Fill;
            chk_DoNotInformCnpj.Location = new System.Drawing.Point(156, 100);
            chk_DoNotInformCnpj.Name = "chk_DoNotInformCnpj";
            chk_DoNotInformCnpj.Properties.Caption = "Não informar o CNPJ";
            chk_DoNotInformCnpj.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Far;
            tablePanel1.SetRow(chk_DoNotInformCnpj, 5);
            chk_DoNotInformCnpj.Size = new System.Drawing.Size(179, 16);
            chk_DoNotInformCnpj.TabIndex = 15;
            chk_DoNotInformCnpj.TabStop = false;
            chk_DoNotInformCnpj.CheckedChanged += chk_DoNotInformCnpj_CheckedChanged;
            // 
            // ssm_Main
            // 
            ssm_Main.ClosingDelay = 500;
            // 
            // frm_Unit
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(348, 349);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("frm_Unit.IconOptions.Icon");
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(350, 459);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(350, 359);
            Name = "frm_Unit";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Cadastrar Unidade";
            Load += frm_Unit_Load;
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chk_ClearFields.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Operators.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Companies.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_Name.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_Username.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_Password.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_CNPJ.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chk_DoNotInformCnpj.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Operators;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.TextEdit txt_CNPJ;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private DevExpress.XtraEditors.TextEdit txt_Username;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Companies;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btn_Create;
        private DevExpress.XtraEditors.CheckEdit chk_ClearFields;
        private DevExpress.XtraEditors.CheckEdit chk_DoNotInformCnpj;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssm_Main;
        private DevExpress.XtraEditors.SimpleButton btn_SearchCnpj;
    }
}
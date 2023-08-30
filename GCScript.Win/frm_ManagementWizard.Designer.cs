namespace GCScript.Win
{
    partial class frm_ManagementWizard
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
            tbc_Main = new DevExpress.XtraTab.XtraTabControl();
            tbp_Home = new DevExpress.XtraTab.XtraTabPage();
            tablePanel5 = new DevExpress.Utils.Layout.TablePanel();
            tablePanel8 = new DevExpress.Utils.Layout.TablePanel();
            dte_Home_Start = new DevExpress.XtraEditors.DateEdit();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            labelControl9 = new DevExpress.XtraEditors.LabelControl();
            dte_Home_End = new DevExpress.XtraEditors.DateEdit();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            cmb_Home_Company = new DevExpress.XtraEditors.ComboBoxEdit();
            tablePanel6 = new DevExpress.Utils.Layout.TablePanel();
            btn_Home_Next = new DevExpress.XtraEditors.SimpleButton();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            lbl_Home_NumberOfDays = new DevExpress.XtraEditors.LabelControl();
            tbp_ImportData = new DevExpress.XtraTab.XtraTabPage();
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            txt_ImportData_CNPJForAll = new DevExpress.XtraEditors.TextEdit();
            cmb_ImportData_OperatorForAll = new DevExpress.XtraEditors.ComboBoxEdit();
            chk_ImportData_OperatorForAll = new DevExpress.XtraEditors.CheckEdit();
            chk_ImportData_CNPJForAll = new DevExpress.XtraEditors.CheckEdit();
            tlp_ImportData_Footer = new DevExpress.Utils.Layout.TablePanel();
            btn_ImportData_Next = new DevExpress.XtraEditors.SimpleButton();
            btn_ImportData_Back = new DevExpress.XtraEditors.SimpleButton();
            lbl_ImportData_Title = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txt_ImportData_FilePath = new DevExpress.XtraEditors.TextEdit();
            btn_ImportData_SelectFile = new DevExpress.XtraEditors.SimpleButton();
            tbp_ImportBalance = new DevExpress.XtraTab.XtraTabPage();
            tablePanel3 = new DevExpress.Utils.Layout.TablePanel();
            tablePanel4 = new DevExpress.Utils.Layout.TablePanel();
            btn_ImportBalance_Next = new DevExpress.XtraEditors.SimpleButton();
            btn_ImportBalance_Back = new DevExpress.XtraEditors.SimpleButton();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txt_ImportBalance_FilePath = new DevExpress.XtraEditors.TextEdit();
            btn_ImportBalance_SelectFile = new DevExpress.XtraEditors.SimpleButton();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            txt_ImportBalance_FileSATPath = new DevExpress.XtraEditors.TextEdit();
            btn_ImportBalance_SelectFileSAT = new DevExpress.XtraEditors.SimpleButton();
            ssm_Main = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(pi_Loading), true, true);
            ((System.ComponentModel.ISupportInitialize)tbc_Main).BeginInit();
            tbc_Main.SuspendLayout();
            tbp_Home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel5).BeginInit();
            tablePanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel8).BeginInit();
            tablePanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dte_Home_Start.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dte_Home_Start.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dte_Home_End.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dte_Home_End.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Home_Company.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel6).BeginInit();
            tablePanel6.SuspendLayout();
            tbp_ImportData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_ImportData_CNPJForAll.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_ImportData_OperatorForAll.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chk_ImportData_OperatorForAll.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chk_ImportData_CNPJForAll.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tlp_ImportData_Footer).BeginInit();
            tlp_ImportData_Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_ImportData_FilePath.Properties).BeginInit();
            tbp_ImportBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel3).BeginInit();
            tablePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel4).BeginInit();
            tablePanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_ImportBalance_FilePath.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_ImportBalance_FileSATPath.Properties).BeginInit();
            SuspendLayout();
            // 
            // tbc_Main
            // 
            tbc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            tbc_Main.Location = new System.Drawing.Point(0, 0);
            tbc_Main.Margin = new System.Windows.Forms.Padding(0);
            tbc_Main.Name = "tbc_Main";
            tbc_Main.SelectedTabPage = tbp_Home;
            tbc_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            tbc_Main.Size = new System.Drawing.Size(498, 318);
            tbc_Main.TabIndex = 0;
            tbc_Main.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tbp_Home, tbp_ImportData, tbp_ImportBalance });
            // 
            // tbp_Home
            // 
            tbp_Home.Controls.Add(tablePanel5);
            tbp_Home.Name = "tbp_Home";
            tbp_Home.Size = new System.Drawing.Size(496, 316);
            tbp_Home.Text = "xtraTabPage1";
            // 
            // tablePanel5
            // 
            tablePanel5.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            tablePanel5.Controls.Add(tablePanel8);
            tablePanel5.Controls.Add(labelControl7);
            tablePanel5.Controls.Add(cmb_Home_Company);
            tablePanel5.Controls.Add(tablePanel6);
            tablePanel5.Controls.Add(labelControl5);
            tablePanel5.Controls.Add(labelControl6);
            tablePanel5.Controls.Add(lbl_Home_NumberOfDays);
            tablePanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel5.Location = new System.Drawing.Point(0, 0);
            tablePanel5.Name = "tablePanel5";
            tablePanel5.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F) });
            tablePanel5.Size = new System.Drawing.Size(496, 316);
            tablePanel5.TabIndex = 3;
            // 
            // tablePanel8
            // 
            tablePanel5.SetColumn(tablePanel8, 0);
            tablePanel8.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            tablePanel5.SetColumnSpan(tablePanel8, 2);
            tablePanel8.Controls.Add(dte_Home_Start);
            tablePanel8.Controls.Add(labelControl8);
            tablePanel8.Controls.Add(labelControl9);
            tablePanel8.Controls.Add(dte_Home_End);
            tablePanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel8.Location = new System.Drawing.Point(0, 114);
            tablePanel8.Margin = new System.Windows.Forms.Padding(0);
            tablePanel8.Name = "tablePanel8";
            tablePanel5.SetRow(tablePanel8, 5);
            tablePanel8.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel8.Size = new System.Drawing.Size(496, 26);
            tablePanel8.TabIndex = 2;
            // 
            // dte_Home_Start
            // 
            tablePanel8.SetColumn(dte_Home_Start, 1);
            dte_Home_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            dte_Home_Start.EditValue = null;
            dte_Home_Start.Location = new System.Drawing.Point(27, 3);
            dte_Home_Start.Name = "dte_Home_Start";
            dte_Home_Start.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            dte_Home_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dte_Home_Start.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dte_Home_Start.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            tablePanel8.SetRow(dte_Home_Start, 0);
            dte_Home_Start.Size = new System.Drawing.Size(215, 20);
            dte_Home_Start.TabIndex = 3;
            dte_Home_Start.EditValueChanged += dte_Home_Start_EditValueChanged;
            // 
            // labelControl8
            // 
            tablePanel8.SetColumn(labelControl8, 0);
            labelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl8.Location = new System.Drawing.Point(3, 3);
            labelControl8.Name = "labelControl8";
            tablePanel8.SetRow(labelControl8, 0);
            labelControl8.Size = new System.Drawing.Size(18, 20);
            labelControl8.TabIndex = 2;
            labelControl8.Text = "De:";
            // 
            // labelControl9
            // 
            tablePanel8.SetColumn(labelControl9, 2);
            labelControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl9.Location = new System.Drawing.Point(248, 3);
            labelControl9.Name = "labelControl9";
            tablePanel8.SetRow(labelControl9, 0);
            labelControl9.Size = new System.Drawing.Size(24, 20);
            labelControl9.TabIndex = 2;
            labelControl9.Text = "Até:";
            // 
            // dte_Home_End
            // 
            tablePanel8.SetColumn(dte_Home_End, 3);
            dte_Home_End.Dock = System.Windows.Forms.DockStyle.Fill;
            dte_Home_End.EditValue = null;
            dte_Home_End.Location = new System.Drawing.Point(278, 3);
            dte_Home_End.Name = "dte_Home_End";
            dte_Home_End.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            dte_Home_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dte_Home_End.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dte_Home_End.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            tablePanel8.SetRow(dte_Home_End, 0);
            dte_Home_End.Size = new System.Drawing.Size(215, 20);
            dte_Home_End.TabIndex = 3;
            dte_Home_End.EditValueChanged += dte_Home_End_EditValueChanged;
            // 
            // labelControl7
            // 
            tablePanel5.SetColumn(labelControl7, 0);
            labelControl7.Location = new System.Drawing.Point(5, 100);
            labelControl7.Margin = new System.Windows.Forms.Padding(5, 5, 1, 1);
            labelControl7.Name = "labelControl7";
            tablePanel5.SetRow(labelControl7, 4);
            labelControl7.Size = new System.Drawing.Size(102, 13);
            labelControl7.TabIndex = 2;
            labelControl7.Text = "Periodo da compra";
            // 
            // cmb_Home_Company
            // 
            tablePanel5.SetColumn(cmb_Home_Company, 0);
            tablePanel5.SetColumnSpan(cmb_Home_Company, 2);
            cmb_Home_Company.Dock = System.Windows.Forms.DockStyle.Fill;
            cmb_Home_Company.Location = new System.Drawing.Point(3, 72);
            cmb_Home_Company.Name = "cmb_Home_Company";
            cmb_Home_Company.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmb_Home_Company.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            tablePanel5.SetRow(cmb_Home_Company, 3);
            cmb_Home_Company.Size = new System.Drawing.Size(490, 20);
            cmb_Home_Company.TabIndex = 5;
            cmb_Home_Company.SelectedIndexChanged += cmb_Home_Company_SelectedIndexChanged;
            // 
            // tablePanel6
            // 
            tablePanel5.SetColumn(tablePanel6, 0);
            tablePanel6.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F) });
            tablePanel5.SetColumnSpan(tablePanel6, 2);
            tablePanel6.Controls.Add(btn_Home_Next);
            tablePanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel6.Location = new System.Drawing.Point(0, 276);
            tablePanel6.Margin = new System.Windows.Forms.Padding(0);
            tablePanel6.Name = "tablePanel6";
            tablePanel5.SetRow(tablePanel6, 8);
            tablePanel6.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel6.Size = new System.Drawing.Size(496, 40);
            tablePanel6.TabIndex = 4;
            // 
            // btn_Home_Next
            // 
            tablePanel6.SetColumn(btn_Home_Next, 3);
            btn_Home_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_Home_Next.Enabled = false;
            btn_Home_Next.Location = new System.Drawing.Point(401, 5);
            btn_Home_Next.Margin = new System.Windows.Forms.Padding(5);
            btn_Home_Next.Name = "btn_Home_Next";
            tablePanel6.SetRow(btn_Home_Next, 0);
            btn_Home_Next.Size = new System.Drawing.Size(90, 30);
            btn_Home_Next.TabIndex = 1;
            btn_Home_Next.Text = "Next >";
            btn_Home_Next.Click += btn_Home_Next_Click;
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl5.Appearance.Options.UseFont = true;
            tablePanel5.SetColumn(labelControl5, 0);
            tablePanel5.SetColumnSpan(labelControl5, 2);
            labelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl5.Location = new System.Drawing.Point(15, 3);
            labelControl5.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            labelControl5.Name = "labelControl5";
            tablePanel5.SetRow(labelControl5, 0);
            labelControl5.Size = new System.Drawing.Size(478, 24);
            labelControl5.TabIndex = 3;
            labelControl5.Text = "Definições iniciais";
            // 
            // labelControl6
            // 
            tablePanel5.SetColumn(labelControl6, 0);
            labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl6.Location = new System.Drawing.Point(5, 55);
            labelControl6.Margin = new System.Windows.Forms.Padding(5, 5, 1, 1);
            labelControl6.Name = "labelControl6";
            tablePanel5.SetRow(labelControl6, 2);
            labelControl6.Size = new System.Drawing.Size(242, 13);
            labelControl6.TabIndex = 2;
            labelControl6.Text = "Nome da Empresa";
            // 
            // lbl_Home_NumberOfDays
            // 
            lbl_Home_NumberOfDays.Appearance.Options.UseTextOptions = true;
            lbl_Home_NumberOfDays.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tablePanel5.SetColumn(lbl_Home_NumberOfDays, 1);
            lbl_Home_NumberOfDays.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_Home_NumberOfDays.Location = new System.Drawing.Point(253, 100);
            lbl_Home_NumberOfDays.Margin = new System.Windows.Forms.Padding(5, 5, 5, 1);
            lbl_Home_NumberOfDays.Name = "lbl_Home_NumberOfDays";
            tablePanel5.SetRow(lbl_Home_NumberOfDays, 4);
            lbl_Home_NumberOfDays.Size = new System.Drawing.Size(238, 13);
            lbl_Home_NumberOfDays.TabIndex = 2;
            lbl_Home_NumberOfDays.Text = "Dias: 0";
            // 
            // tbp_ImportData
            // 
            tbp_ImportData.Controls.Add(tablePanel1);
            tbp_ImportData.Name = "tbp_ImportData";
            tbp_ImportData.Size = new System.Drawing.Size(496, 316);
            tbp_ImportData.Text = "xtraTabPage1";
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F) });
            tablePanel1.Controls.Add(txt_ImportData_CNPJForAll);
            tablePanel1.Controls.Add(cmb_ImportData_OperatorForAll);
            tablePanel1.Controls.Add(chk_ImportData_OperatorForAll);
            tablePanel1.Controls.Add(chk_ImportData_CNPJForAll);
            tablePanel1.Controls.Add(tlp_ImportData_Footer);
            tablePanel1.Controls.Add(lbl_ImportData_Title);
            tablePanel1.Controls.Add(labelControl1);
            tablePanel1.Controls.Add(txt_ImportData_FilePath);
            tablePanel1.Controls.Add(btn_ImportData_SelectFile);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F) });
            tablePanel1.Size = new System.Drawing.Size(496, 316);
            tablePanel1.TabIndex = 2;
            // 
            // txt_ImportData_CNPJForAll
            // 
            tablePanel1.SetColumn(txt_ImportData_CNPJForAll, 0);
            tablePanel1.SetColumnSpan(txt_ImportData_CNPJForAll, 4);
            txt_ImportData_CNPJForAll.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_ImportData_CNPJForAll.Location = new System.Drawing.Point(3, 116);
            txt_ImportData_CNPJForAll.Name = "txt_ImportData_CNPJForAll";
            tablePanel1.SetRow(txt_ImportData_CNPJForAll, 5);
            txt_ImportData_CNPJForAll.Size = new System.Drawing.Size(193, 20);
            txt_ImportData_CNPJForAll.TabIndex = 8;
            // 
            // cmb_ImportData_OperatorForAll
            // 
            tablePanel1.SetColumn(cmb_ImportData_OperatorForAll, 4);
            tablePanel1.SetColumnSpan(cmb_ImportData_OperatorForAll, 6);
            cmb_ImportData_OperatorForAll.Dock = System.Windows.Forms.DockStyle.Fill;
            cmb_ImportData_OperatorForAll.Location = new System.Drawing.Point(201, 116);
            cmb_ImportData_OperatorForAll.Name = "cmb_ImportData_OperatorForAll";
            cmb_ImportData_OperatorForAll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmb_ImportData_OperatorForAll.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            tablePanel1.SetRow(cmb_ImportData_OperatorForAll, 5);
            cmb_ImportData_OperatorForAll.Size = new System.Drawing.Size(292, 20);
            cmb_ImportData_OperatorForAll.TabIndex = 7;
            // 
            // chk_ImportData_OperatorForAll
            // 
            tablePanel1.SetColumn(chk_ImportData_OperatorForAll, 4);
            tablePanel1.SetColumnSpan(chk_ImportData_OperatorForAll, 3);
            chk_ImportData_OperatorForAll.Dock = System.Windows.Forms.DockStyle.Fill;
            chk_ImportData_OperatorForAll.Location = new System.Drawing.Point(201, 95);
            chk_ImportData_OperatorForAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            chk_ImportData_OperatorForAll.Name = "chk_ImportData_OperatorForAll";
            chk_ImportData_OperatorForAll.Properties.Caption = "Operadora para todos";
            tablePanel1.SetRow(chk_ImportData_OperatorForAll, 4);
            chk_ImportData_OperatorForAll.Size = new System.Drawing.Size(144, 18);
            chk_ImportData_OperatorForAll.TabIndex = 6;
            chk_ImportData_OperatorForAll.CheckedChanged += chk_ImportData_OperatorForAll_CheckedChanged;
            // 
            // chk_ImportData_CNPJForAll
            // 
            tablePanel1.SetColumn(chk_ImportData_CNPJForAll, 0);
            tablePanel1.SetColumnSpan(chk_ImportData_CNPJForAll, 3);
            chk_ImportData_CNPJForAll.Dock = System.Windows.Forms.DockStyle.Fill;
            chk_ImportData_CNPJForAll.Location = new System.Drawing.Point(3, 95);
            chk_ImportData_CNPJForAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            chk_ImportData_CNPJForAll.Name = "chk_ImportData_CNPJForAll";
            chk_ImportData_CNPJForAll.Properties.Caption = "CNPJ para todos";
            tablePanel1.SetRow(chk_ImportData_CNPJForAll, 4);
            chk_ImportData_CNPJForAll.Size = new System.Drawing.Size(143, 18);
            chk_ImportData_CNPJForAll.TabIndex = 5;
            chk_ImportData_CNPJForAll.CheckedChanged += chk_ImportData_CNPJForAll_CheckedChanged;
            // 
            // tlp_ImportData_Footer
            // 
            tablePanel1.SetColumn(tlp_ImportData_Footer, 0);
            tlp_ImportData_Footer.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F) });
            tablePanel1.SetColumnSpan(tlp_ImportData_Footer, 10);
            tlp_ImportData_Footer.Controls.Add(btn_ImportData_Next);
            tlp_ImportData_Footer.Controls.Add(btn_ImportData_Back);
            tlp_ImportData_Footer.Dock = System.Windows.Forms.DockStyle.Fill;
            tlp_ImportData_Footer.Location = new System.Drawing.Point(0, 276);
            tlp_ImportData_Footer.Margin = new System.Windows.Forms.Padding(0);
            tlp_ImportData_Footer.Name = "tlp_ImportData_Footer";
            tablePanel1.SetRow(tlp_ImportData_Footer, 9);
            tlp_ImportData_Footer.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tlp_ImportData_Footer.Size = new System.Drawing.Size(496, 40);
            tlp_ImportData_Footer.TabIndex = 4;
            // 
            // btn_ImportData_Next
            // 
            tlp_ImportData_Footer.SetColumn(btn_ImportData_Next, 3);
            btn_ImportData_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportData_Next.Enabled = false;
            btn_ImportData_Next.Location = new System.Drawing.Point(401, 5);
            btn_ImportData_Next.Margin = new System.Windows.Forms.Padding(5);
            btn_ImportData_Next.Name = "btn_ImportData_Next";
            tlp_ImportData_Footer.SetRow(btn_ImportData_Next, 0);
            btn_ImportData_Next.Size = new System.Drawing.Size(90, 30);
            btn_ImportData_Next.TabIndex = 1;
            btn_ImportData_Next.Text = "Next >";
            btn_ImportData_Next.Click += btn_ImportData_Next_Click;
            // 
            // btn_ImportData_Back
            // 
            tlp_ImportData_Footer.SetColumn(btn_ImportData_Back, 2);
            btn_ImportData_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportData_Back.Location = new System.Drawing.Point(301, 5);
            btn_ImportData_Back.Margin = new System.Windows.Forms.Padding(5);
            btn_ImportData_Back.Name = "btn_ImportData_Back";
            tlp_ImportData_Footer.SetRow(btn_ImportData_Back, 0);
            btn_ImportData_Back.Size = new System.Drawing.Size(90, 30);
            btn_ImportData_Back.TabIndex = 1;
            btn_ImportData_Back.Text = "< Back";
            btn_ImportData_Back.Click += btn_ImportData_Back_Click;
            // 
            // lbl_ImportData_Title
            // 
            lbl_ImportData_Title.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbl_ImportData_Title.Appearance.Options.UseFont = true;
            tablePanel1.SetColumn(lbl_ImportData_Title, 0);
            tablePanel1.SetColumnSpan(lbl_ImportData_Title, 4);
            lbl_ImportData_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_ImportData_Title.Location = new System.Drawing.Point(15, 3);
            lbl_ImportData_Title.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            lbl_ImportData_Title.Name = "lbl_ImportData_Title";
            tablePanel1.SetRow(lbl_ImportData_Title, 0);
            lbl_ImportData_Title.Size = new System.Drawing.Size(181, 24);
            lbl_ImportData_Title.TabIndex = 3;
            lbl_ImportData_Title.Text = "Importar Dados";
            // 
            // labelControl1
            // 
            tablePanel1.SetColumn(labelControl1, 0);
            tablePanel1.SetColumnSpan(labelControl1, 3);
            labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl1.Location = new System.Drawing.Point(3, 53);
            labelControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            labelControl1.Name = "labelControl1";
            tablePanel1.SetRow(labelControl1, 2);
            labelControl1.Size = new System.Drawing.Size(143, 13);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Arquivo de compra";
            // 
            // txt_ImportData_FilePath
            // 
            tablePanel1.SetColumn(txt_ImportData_FilePath, 0);
            tablePanel1.SetColumnSpan(txt_ImportData_FilePath, 8);
            txt_ImportData_FilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_ImportData_FilePath.Location = new System.Drawing.Point(3, 69);
            txt_ImportData_FilePath.Name = "txt_ImportData_FilePath";
            txt_ImportData_FilePath.Properties.ReadOnly = true;
            tablePanel1.SetRow(txt_ImportData_FilePath, 3);
            txt_ImportData_FilePath.Size = new System.Drawing.Size(391, 20);
            txt_ImportData_FilePath.TabIndex = 0;
            txt_ImportData_FilePath.EditValueChanged += txt_ImportData_FilePath_EditValueChanged;
            // 
            // btn_ImportData_SelectFile
            // 
            tablePanel1.SetColumn(btn_ImportData_SelectFile, 8);
            tablePanel1.SetColumnSpan(btn_ImportData_SelectFile, 2);
            btn_ImportData_SelectFile.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportData_SelectFile.Location = new System.Drawing.Point(400, 69);
            btn_ImportData_SelectFile.Name = "btn_ImportData_SelectFile";
            tablePanel1.SetRow(btn_ImportData_SelectFile, 3);
            btn_ImportData_SelectFile.Size = new System.Drawing.Size(93, 20);
            btn_ImportData_SelectFile.TabIndex = 1;
            btn_ImportData_SelectFile.Text = "Selecionar";
            btn_ImportData_SelectFile.Click += btn_ImportData_SelectFile_Click;
            // 
            // tbp_ImportBalance
            // 
            tbp_ImportBalance.Controls.Add(tablePanel3);
            tbp_ImportBalance.Name = "tbp_ImportBalance";
            tbp_ImportBalance.Size = new System.Drawing.Size(496, 316);
            tbp_ImportBalance.Text = "xtraTabPage2";
            // 
            // tablePanel3
            // 
            tablePanel3.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F) });
            tablePanel3.Controls.Add(tablePanel4);
            tablePanel3.Controls.Add(labelControl2);
            tablePanel3.Controls.Add(labelControl3);
            tablePanel3.Controls.Add(txt_ImportBalance_FilePath);
            tablePanel3.Controls.Add(btn_ImportBalance_SelectFile);
            tablePanel3.Controls.Add(labelControl4);
            tablePanel3.Controls.Add(txt_ImportBalance_FileSATPath);
            tablePanel3.Controls.Add(btn_ImportBalance_SelectFileSAT);
            tablePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel3.Location = new System.Drawing.Point(0, 0);
            tablePanel3.Name = "tablePanel3";
            tablePanel3.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F) });
            tablePanel3.Size = new System.Drawing.Size(496, 316);
            tablePanel3.TabIndex = 3;
            // 
            // tablePanel4
            // 
            tablePanel3.SetColumn(tablePanel4, 0);
            tablePanel4.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F) });
            tablePanel3.SetColumnSpan(tablePanel4, 2);
            tablePanel4.Controls.Add(btn_ImportBalance_Next);
            tablePanel4.Controls.Add(btn_ImportBalance_Back);
            tablePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel4.Location = new System.Drawing.Point(0, 276);
            tablePanel4.Margin = new System.Windows.Forms.Padding(0);
            tablePanel4.Name = "tablePanel4";
            tablePanel3.SetRow(tablePanel4, 7);
            tablePanel4.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel4.Size = new System.Drawing.Size(496, 40);
            tablePanel4.TabIndex = 4;
            // 
            // btn_ImportBalance_Next
            // 
            tablePanel4.SetColumn(btn_ImportBalance_Next, 3);
            btn_ImportBalance_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportBalance_Next.Enabled = false;
            btn_ImportBalance_Next.Location = new System.Drawing.Point(401, 5);
            btn_ImportBalance_Next.Margin = new System.Windows.Forms.Padding(5);
            btn_ImportBalance_Next.Name = "btn_ImportBalance_Next";
            tablePanel4.SetRow(btn_ImportBalance_Next, 0);
            btn_ImportBalance_Next.Size = new System.Drawing.Size(90, 30);
            btn_ImportBalance_Next.TabIndex = 1;
            btn_ImportBalance_Next.Text = "Next >";
            // 
            // btn_ImportBalance_Back
            // 
            tablePanel4.SetColumn(btn_ImportBalance_Back, 2);
            btn_ImportBalance_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportBalance_Back.Location = new System.Drawing.Point(301, 5);
            btn_ImportBalance_Back.Margin = new System.Windows.Forms.Padding(5);
            btn_ImportBalance_Back.Name = "btn_ImportBalance_Back";
            tablePanel4.SetRow(btn_ImportBalance_Back, 0);
            btn_ImportBalance_Back.Size = new System.Drawing.Size(90, 30);
            btn_ImportBalance_Back.TabIndex = 1;
            btn_ImportBalance_Back.Text = "< Back";
            btn_ImportBalance_Back.Click += btn_ImportBalance_Back_Click;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl2.Appearance.Options.UseFont = true;
            tablePanel3.SetColumn(labelControl2, 0);
            tablePanel3.SetColumnSpan(labelControl2, 2);
            labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl2.Location = new System.Drawing.Point(15, 3);
            labelControl2.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            labelControl2.Name = "labelControl2";
            tablePanel3.SetRow(labelControl2, 0);
            labelControl2.Size = new System.Drawing.Size(478, 24);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Importar Saldos";
            // 
            // labelControl3
            // 
            tablePanel3.SetColumn(labelControl3, 0);
            labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl3.Location = new System.Drawing.Point(5, 55);
            labelControl3.Margin = new System.Windows.Forms.Padding(5, 5, 1, 1);
            labelControl3.Name = "labelControl3";
            tablePanel3.SetRow(labelControl3, 2);
            labelControl3.Size = new System.Drawing.Size(390, 14);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Arquivo";
            // 
            // txt_ImportBalance_FilePath
            // 
            tablePanel3.SetColumn(txt_ImportBalance_FilePath, 0);
            txt_ImportBalance_FilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_ImportBalance_FilePath.Location = new System.Drawing.Point(3, 73);
            txt_ImportBalance_FilePath.Name = "txt_ImportBalance_FilePath";
            txt_ImportBalance_FilePath.Properties.ReadOnly = true;
            tablePanel3.SetRow(txt_ImportBalance_FilePath, 3);
            txt_ImportBalance_FilePath.Size = new System.Drawing.Size(390, 20);
            txt_ImportBalance_FilePath.TabIndex = 0;
            txt_ImportBalance_FilePath.EditValueChanged += txt_ImportBalance_FilePath_EditValueChanged;
            // 
            // btn_ImportBalance_SelectFile
            // 
            tablePanel3.SetColumn(btn_ImportBalance_SelectFile, 1);
            btn_ImportBalance_SelectFile.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportBalance_SelectFile.Location = new System.Drawing.Point(399, 73);
            btn_ImportBalance_SelectFile.Name = "btn_ImportBalance_SelectFile";
            tablePanel3.SetRow(btn_ImportBalance_SelectFile, 3);
            btn_ImportBalance_SelectFile.Size = new System.Drawing.Size(94, 14);
            btn_ImportBalance_SelectFile.TabIndex = 1;
            btn_ImportBalance_SelectFile.Text = "Selecionar";
            btn_ImportBalance_SelectFile.Click += btn_ImportBalance_SelectFile_Click;
            // 
            // labelControl4
            // 
            tablePanel3.SetColumn(labelControl4, 0);
            labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl4.Location = new System.Drawing.Point(5, 95);
            labelControl4.Margin = new System.Windows.Forms.Padding(5, 5, 1, 1);
            labelControl4.Name = "labelControl4";
            tablePanel3.SetRow(labelControl4, 4);
            labelControl4.Size = new System.Drawing.Size(390, 14);
            labelControl4.TabIndex = 2;
            labelControl4.Text = "Arquivo SAT (Temporário)";
            // 
            // txt_ImportBalance_FileSATPath
            // 
            tablePanel3.SetColumn(txt_ImportBalance_FileSATPath, 0);
            txt_ImportBalance_FileSATPath.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_ImportBalance_FileSATPath.Location = new System.Drawing.Point(3, 113);
            txt_ImportBalance_FileSATPath.Name = "txt_ImportBalance_FileSATPath";
            txt_ImportBalance_FileSATPath.Properties.ReadOnly = true;
            tablePanel3.SetRow(txt_ImportBalance_FileSATPath, 5);
            txt_ImportBalance_FileSATPath.Size = new System.Drawing.Size(390, 20);
            txt_ImportBalance_FileSATPath.TabIndex = 0;
            // 
            // btn_ImportBalance_SelectFileSAT
            // 
            tablePanel3.SetColumn(btn_ImportBalance_SelectFileSAT, 1);
            btn_ImportBalance_SelectFileSAT.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_ImportBalance_SelectFileSAT.Location = new System.Drawing.Point(399, 113);
            btn_ImportBalance_SelectFileSAT.Name = "btn_ImportBalance_SelectFileSAT";
            tablePanel3.SetRow(btn_ImportBalance_SelectFileSAT, 5);
            btn_ImportBalance_SelectFileSAT.Size = new System.Drawing.Size(94, 14);
            btn_ImportBalance_SelectFileSAT.TabIndex = 1;
            btn_ImportBalance_SelectFileSAT.Text = "Selecionar";
            btn_ImportBalance_SelectFileSAT.Click += btn_ImportBalance_SelectFileSAT_Click;
            // 
            // ssm_Main
            // 
            ssm_Main.ClosingDelay = 500;
            // 
            // frm_ManagementWizard
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(498, 318);
            Controls.Add(tbc_Main);
            Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_ManagementWizard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "GCScript Benefits";
            Load += frm_ManagementImportData_Load;
            ((System.ComponentModel.ISupportInitialize)tbc_Main).EndInit();
            tbc_Main.ResumeLayout(false);
            tbp_Home.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablePanel5).EndInit();
            tablePanel5.ResumeLayout(false);
            tablePanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel8).EndInit();
            tablePanel8.ResumeLayout(false);
            tablePanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dte_Home_Start.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dte_Home_Start.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dte_Home_End.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dte_Home_End.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Home_Company.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel6).EndInit();
            tablePanel6.ResumeLayout(false);
            tbp_ImportData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txt_ImportData_CNPJForAll.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_ImportData_OperatorForAll.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chk_ImportData_OperatorForAll.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chk_ImportData_CNPJForAll.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tlp_ImportData_Footer).EndInit();
            tlp_ImportData_Footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txt_ImportData_FilePath.Properties).EndInit();
            tbp_ImportBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablePanel3).EndInit();
            tablePanel3.ResumeLayout(false);
            tablePanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel4).EndInit();
            tablePanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txt_ImportBalance_FilePath.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_ImportBalance_FileSATPath.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tbc_Main;
        private DevExpress.XtraTab.XtraTabPage tbp_ImportData;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.TextEdit txt_ImportData_FilePath;
        private DevExpress.XtraEditors.SimpleButton btn_ImportData_SelectFile;
        private DevExpress.XtraTab.XtraTabPage tbp_ImportBalance;
        private DevExpress.Utils.Layout.TablePanel tlp_ImportData_Footer;
        private DevExpress.XtraEditors.LabelControl lbl_ImportData_Title;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_ImportData_Next;
        private DevExpress.Utils.Layout.TablePanel tablePanel3;
        private DevExpress.Utils.Layout.TablePanel tablePanel4;
        private DevExpress.XtraEditors.SimpleButton btn_ImportBalance_Next;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_ImportBalance_FilePath;
        private DevExpress.XtraEditors.SimpleButton btn_ImportBalance_SelectFile;
        private DevExpress.XtraEditors.SimpleButton btn_ImportBalance_Back;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_ImportBalance_FileSATPath;
        private DevExpress.XtraEditors.SimpleButton btn_ImportBalance_SelectFileSAT;
        private DevExpress.XtraTab.XtraTabPage tbp_Home;
        private DevExpress.Utils.Layout.TablePanel tablePanel5;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Home_Company;
        private DevExpress.Utils.Layout.TablePanel tablePanel6;
        private DevExpress.XtraEditors.SimpleButton btn_Home_Next;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btn_ImportData_Back;
        private DevExpress.XtraEditors.DateEdit dte_Home_Start;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit dte_Home_End;
        private DevExpress.Utils.Layout.TablePanel tablePanel8;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssm_Main;
        private DevExpress.XtraEditors.LabelControl lbl_Home_NumberOfDays;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.CheckEdit chk_ImportData_CNPJForAll;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_ImportData_OperatorForAll;
        private DevExpress.XtraEditors.CheckEdit chk_ImportData_OperatorForAll;
        private DevExpress.XtraEditors.TextEdit txt_ImportData_CNPJForAll;
    }
}
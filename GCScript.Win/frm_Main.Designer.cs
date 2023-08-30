namespace GCScript.Win
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            pnl_Login = new DevExpress.XtraEditors.PanelControl();
            btn_Management = new DevExpress.XtraEditors.SimpleButton();
            lbl_Password = new DevExpress.XtraEditors.LabelControl();
            txt_Password = new DevExpress.XtraEditors.TextEdit();
            svg_User = new DevExpress.XtraEditors.SvgImageBox();
            lbl_Username = new DevExpress.XtraEditors.LabelControl();
            txt_Username = new DevExpress.XtraEditors.TextEdit();
            btn_LogIn = new DevExpress.XtraEditors.SimpleButton();
            pnl_Main = new DevExpress.XtraEditors.PanelControl();
            tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            pnl_Container = new DevExpress.XtraEditors.PanelControl();
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            svg_Shortcut = new DevExpress.XtraEditors.SvgImageBox();
            lbl_Credits = new DevExpress.XtraEditors.LabelControl();
            lbl_LoggedInUser = new DevExpress.XtraEditors.LabelControl();
            acc_Sidebar = new DevExpress.XtraBars.Navigation.AccordionControl();
            acce_Data = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            acce_Management = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            acce_Tools = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ssm_Main = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(pi_Loading), true, true);
            tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            tablePanel3 = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)pnl_Login).BeginInit();
            pnl_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_Password.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svg_User).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_Username.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnl_Main).BeginInit();
            pnl_Main.SuspendLayout();
            tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnl_Container).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgImageBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svg_Shortcut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)acc_Sidebar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel2).BeginInit();
            tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel3).BeginInit();
            tablePanel3.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_Login
            // 
            pnl_Login.Controls.Add(tablePanel2);
            pnl_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_Login.Location = new System.Drawing.Point(0, 0);
            pnl_Login.Name = "pnl_Login";
            pnl_Login.Size = new System.Drawing.Size(798, 468);
            pnl_Login.TabIndex = 0;
            // 
            // btn_Management
            // 
            tablePanel3.SetColumn(btn_Management, 2);
            btn_Management.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_Management.Location = new System.Drawing.Point(292, 416);
            btn_Management.Margin = new System.Windows.Forms.Padding(1);
            btn_Management.Name = "btn_Management";
            tablePanel3.SetRow(btn_Management, 7);
            btn_Management.Size = new System.Drawing.Size(89, 22);
            btn_Management.TabIndex = 6;
            btn_Management.Text = "Management";
            btn_Management.Click += btn_Management_Click;
            // 
            // lbl_Password
            // 
            lbl_Password.Appearance.Options.UseFont = true;
            tablePanel3.SetColumn(lbl_Password, 1);
            lbl_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_Password.Location = new System.Drawing.Point(92, 196);
            lbl_Password.Margin = new System.Windows.Forms.Padding(1);
            lbl_Password.Name = "lbl_Password";
            tablePanel3.SetRow(lbl_Password, 3);
            lbl_Password.Size = new System.Drawing.Size(198, 13);
            lbl_Password.TabIndex = 5;
            lbl_Password.Text = "Password";
            // 
            // txt_Password
            // 
            tablePanel3.SetColumn(txt_Password, 1);
            txt_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_Password.EditValue = "";
            txt_Password.Location = new System.Drawing.Point(92, 211);
            txt_Password.Margin = new System.Windows.Forms.Padding(1);
            txt_Password.Name = "txt_Password";
            txt_Password.Properties.Appearance.Options.UseFont = true;
            txt_Password.Properties.Appearance.Options.UseTextOptions = true;
            txt_Password.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txt_Password.Properties.UseSystemPasswordChar = true;
            tablePanel3.SetRow(txt_Password, 4);
            txt_Password.Size = new System.Drawing.Size(198, 20);
            txt_Password.TabIndex = 1;
            txt_Password.KeyPress += txt_Password_KeyPress;
            // 
            // svg_User
            // 
            tablePanel2.SetColumn(svg_User, 0);
            svg_User.Dock = System.Windows.Forms.DockStyle.Fill;
            svg_User.Location = new System.Drawing.Point(11, 10);
            svg_User.Margin = new System.Windows.Forms.Padding(0);
            svg_User.Name = "svg_User";
            tablePanel2.SetRow(svg_User, 0);
            svg_User.Size = new System.Drawing.Size(386, 443);
            svg_User.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            svg_User.SvgImage = Properties.Resources.gcscript;
            svg_User.TabIndex = 2;
            svg_User.Text = "svgImageBox1";
            // 
            // lbl_Username
            // 
            lbl_Username.Appearance.Options.UseFont = true;
            tablePanel3.SetColumn(lbl_Username, 1);
            lbl_Username.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_Username.Location = new System.Drawing.Point(92, 159);
            lbl_Username.Margin = new System.Windows.Forms.Padding(1);
            lbl_Username.Name = "lbl_Username";
            tablePanel3.SetRow(lbl_Username, 1);
            lbl_Username.Size = new System.Drawing.Size(198, 13);
            lbl_Username.TabIndex = 0;
            lbl_Username.Text = "Username";
            // 
            // txt_Username
            // 
            tablePanel3.SetColumn(txt_Username, 1);
            txt_Username.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_Username.EditValue = "";
            txt_Username.Location = new System.Drawing.Point(92, 174);
            txt_Username.Margin = new System.Windows.Forms.Padding(1);
            txt_Username.Name = "txt_Username";
            txt_Username.Properties.Appearance.Options.UseFont = true;
            txt_Username.Properties.Appearance.Options.UseTextOptions = true;
            txt_Username.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tablePanel3.SetRow(txt_Username, 2);
            txt_Username.Size = new System.Drawing.Size(198, 20);
            txt_Username.TabIndex = 0;
            txt_Username.KeyPress += txt_Username_KeyPress;
            // 
            // btn_LogIn
            // 
            tablePanel3.SetColumn(btn_LogIn, 1);
            btn_LogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_LogIn.Location = new System.Drawing.Point(92, 233);
            btn_LogIn.Margin = new System.Windows.Forms.Padding(1);
            btn_LogIn.Name = "btn_LogIn";
            tablePanel3.SetRow(btn_LogIn, 5);
            btn_LogIn.Size = new System.Drawing.Size(198, 23);
            btn_LogIn.TabIndex = 2;
            btn_LogIn.Text = "LogIn";
            btn_LogIn.Click += btn_LogIn_Click;
            // 
            // pnl_Main
            // 
            pnl_Main.Controls.Add(tlp_Main);
            pnl_Main.Controls.Add(acc_Sidebar);
            pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_Main.Location = new System.Drawing.Point(0, 0);
            pnl_Main.Name = "pnl_Main";
            pnl_Main.Size = new System.Drawing.Size(798, 468);
            pnl_Main.TabIndex = 2;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlp_Main.Controls.Add(pnl_Container, 0, 0);
            tlp_Main.Controls.Add(tablePanel1, 0, 1);
            tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            tlp_Main.Location = new System.Drawing.Point(52, 2);
            tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tlp_Main.Size = new System.Drawing.Size(744, 464);
            tlp_Main.TabIndex = 0;
            // 
            // pnl_Container
            // 
            pnl_Container.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnl_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_Container.Location = new System.Drawing.Point(0, 0);
            pnl_Container.Margin = new System.Windows.Forms.Padding(0);
            pnl_Container.Name = "pnl_Container";
            pnl_Container.Size = new System.Drawing.Size(744, 444);
            pnl_Container.TabIndex = 1;
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 155F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 15F) });
            tablePanel1.Controls.Add(svgImageBox1);
            tablePanel1.Controls.Add(labelControl6);
            tablePanel1.Controls.Add(svg_Shortcut);
            tablePanel1.Controls.Add(lbl_Credits);
            tablePanel1.Controls.Add(lbl_LoggedInUser);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 444);
            tablePanel1.Margin = new System.Windows.Forms.Padding(0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel1.Size = new System.Drawing.Size(744, 20);
            tablePanel1.TabIndex = 2;
            // 
            // svgImageBox1
            // 
            tablePanel1.SetColumn(svgImageBox1, 0);
            svgImageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            svgImageBox1.Location = new System.Drawing.Point(1, 1);
            svgImageBox1.Margin = new System.Windows.Forms.Padding(1);
            svgImageBox1.Name = "svgImageBox1";
            tablePanel1.SetRow(svgImageBox1, 0);
            svgImageBox1.Size = new System.Drawing.Size(18, 18);
            svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            svgImageBox1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageBox1.SvgImage");
            svgImageBox1.TabIndex = 4;
            svgImageBox1.Text = "svgImageBox1";
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Options.UseTextOptions = true;
            labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tablePanel1.SetColumn(labelControl6, 3);
            labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl6.Location = new System.Drawing.Point(574, 2);
            labelControl6.Margin = new System.Windows.Forms.Padding(0, 2, 5, 0);
            labelControl6.Name = "labelControl6";
            tablePanel1.SetRow(labelControl6, 0);
            labelControl6.Size = new System.Drawing.Size(150, 18);
            labelControl6.TabIndex = 2;
            labelControl6.Text = "Atalhos";
            // 
            // svg_Shortcut
            // 
            tablePanel1.SetColumn(svg_Shortcut, 4);
            svg_Shortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            svg_Shortcut.Location = new System.Drawing.Point(730, 1);
            svg_Shortcut.Margin = new System.Windows.Forms.Padding(1, 1, 5, 1);
            svg_Shortcut.Name = "svg_Shortcut";
            tablePanel1.SetRow(svg_Shortcut, 0);
            svg_Shortcut.Size = new System.Drawing.Size(9, 18);
            svg_Shortcut.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            svg_Shortcut.SvgImage = Properties.Resources.off;
            svg_Shortcut.TabIndex = 3;
            svg_Shortcut.Text = "svgImageBox1";
            // 
            // lbl_Credits
            // 
            lbl_Credits.Appearance.Options.UseTextOptions = true;
            lbl_Credits.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tablePanel1.SetColumn(lbl_Credits, 2);
            lbl_Credits.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_Credits.Location = new System.Drawing.Point(170, 0);
            lbl_Credits.Margin = new System.Windows.Forms.Padding(0);
            lbl_Credits.Name = "lbl_Credits";
            tablePanel1.SetRow(lbl_Credits, 0);
            lbl_Credits.Size = new System.Drawing.Size(404, 20);
            lbl_Credits.TabIndex = 0;
            lbl_Credits.Text = "Direitos Reservados © 2023 - GCScript";
            // 
            // lbl_LoggedInUser
            // 
            lbl_LoggedInUser.Appearance.Options.UseTextOptions = true;
            lbl_LoggedInUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            tablePanel1.SetColumn(lbl_LoggedInUser, 1);
            lbl_LoggedInUser.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_LoggedInUser.Location = new System.Drawing.Point(25, 2);
            lbl_LoggedInUser.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
            lbl_LoggedInUser.Name = "lbl_LoggedInUser";
            tablePanel1.SetRow(lbl_LoggedInUser, 0);
            lbl_LoggedInUser.Size = new System.Drawing.Size(145, 18);
            lbl_LoggedInUser.TabIndex = 0;
            // 
            // acc_Sidebar
            // 
            acc_Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            acc_Sidebar.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { acce_Data, acce_Management, acce_Tools });
            acc_Sidebar.Location = new System.Drawing.Point(2, 2);
            acc_Sidebar.Name = "acc_Sidebar";
            acc_Sidebar.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            acc_Sidebar.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            acc_Sidebar.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            acc_Sidebar.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            acc_Sidebar.Size = new System.Drawing.Size(50, 464);
            acc_Sidebar.TabIndex = 1;
            // 
            // acce_Data
            // 
            acce_Data.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("acce_Data.ImageOptions.SvgImage");
            acce_Data.Name = "acce_Data";
            acce_Data.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            acce_Data.Text = "Data";
            acce_Data.Click += acce_Data_Click;
            // 
            // acce_Management
            // 
            acce_Management.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("acce_Management.ImageOptions.SvgImage");
            acce_Management.Name = "acce_Management";
            acce_Management.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            acce_Management.Text = "Management";
            acce_Management.Click += acce_Management_Click;
            // 
            // acce_Tools
            // 
            acce_Tools.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("acce_Tools.ImageOptions.SvgImage");
            acce_Tools.Name = "acce_Tools";
            acce_Tools.Text = "Tools";
            // 
            // ssm_Main
            // 
            ssm_Main.ClosingDelay = 500;
            // 
            // tablePanel2
            // 
            tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            tablePanel2.Controls.Add(tablePanel3);
            tablePanel2.Controls.Add(svg_User);
            tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel2.Location = new System.Drawing.Point(2, 2);
            tablePanel2.Name = "tablePanel2";
            tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel2.Size = new System.Drawing.Size(794, 464);
            tablePanel2.TabIndex = 7;
            tablePanel2.UseSkinIndents = true;
            // 
            // tablePanel3
            // 
            tablePanel2.SetColumn(tablePanel3, 1);
            tablePanel3.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel3.Controls.Add(lbl_Username);
            tablePanel3.Controls.Add(btn_Management);
            tablePanel3.Controls.Add(txt_Username);
            tablePanel3.Controls.Add(btn_LogIn);
            tablePanel3.Controls.Add(txt_Password);
            tablePanel3.Controls.Add(lbl_Password);
            tablePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel3.Location = new System.Drawing.Point(399, 12);
            tablePanel3.Name = "tablePanel3";
            tablePanel2.SetRow(tablePanel3, 0);
            tablePanel3.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F) });
            tablePanel3.Size = new System.Drawing.Size(382, 439);
            tablePanel3.TabIndex = 3;
            // 
            // frm_Main
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(798, 468);
            Controls.Add(pnl_Login);
            Controls.Add(pnl_Main);
            IconOptions.SvgImage = Properties.Resources.gcscript_benefits;
            MinimumSize = new System.Drawing.Size(800, 500);
            Name = "frm_Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "GCScript Benefits";
            Load += frm_Main_Load;
            ((System.ComponentModel.ISupportInitialize)pnl_Login).EndInit();
            pnl_Login.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txt_Password.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)svg_User).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_Username.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnl_Main).EndInit();
            pnl_Main.ResumeLayout(false);
            tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnl_Container).EndInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgImageBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svg_Shortcut).EndInit();
            ((System.ComponentModel.ISupportInitialize)acc_Sidebar).EndInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel2).EndInit();
            tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablePanel3).EndInit();
            tablePanel3.ResumeLayout(false);
            tablePanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnl_Login;
        private DevExpress.XtraEditors.SvgImageBox svg_User;
        private DevExpress.XtraEditors.LabelControl lbl_Username;
        private DevExpress.XtraEditors.TextEdit txt_Username;
        private DevExpress.XtraEditors.SimpleButton btn_LogIn;
        private DevExpress.XtraEditors.PanelControl pnl_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private DevExpress.XtraBars.Navigation.AccordionControl acc_Sidebar;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acce_Tools;
        private DevExpress.XtraEditors.LabelControl lbl_Credits;
        private DevExpress.XtraEditors.PanelControl pnl_Container;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acce_Data;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acce_Management;
        private DevExpress.XtraEditors.LabelControl lbl_Password;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssm_Main;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SvgImageBox svg_Shortcut;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private DevExpress.XtraEditors.LabelControl lbl_LoggedInUser;
        private DevExpress.XtraEditors.SimpleButton btn_Management;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.Utils.Layout.TablePanel tablePanel3;
    }
}
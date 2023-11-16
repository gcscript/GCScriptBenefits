namespace GCScript.Client.Windows
{
    partial class frm_RiocardBalanceTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_RiocardBalanceTools));
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            lbl_Title1 = new DevExpress.XtraEditors.LabelControl();
            txt_FilePath1 = new DevExpress.XtraEditors.TextEdit();
            btn_SelectFile1 = new DevExpress.XtraEditors.SimpleButton();
            lbl_Title2 = new DevExpress.XtraEditors.LabelControl();
            txt_FilePath2 = new DevExpress.XtraEditors.TextEdit();
            btn_SelectFile2 = new DevExpress.XtraEditors.SimpleButton();
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            chk_1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_FilePath1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_FilePath2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chk_1.Properties).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 150F) });
            tablePanel1.Controls.Add(chk_1);
            tablePanel1.Controls.Add(lbl_Title1);
            tablePanel1.Controls.Add(txt_FilePath1);
            tablePanel1.Controls.Add(btn_SelectFile1);
            tablePanel1.Controls.Add(lbl_Title2);
            tablePanel1.Controls.Add(txt_FilePath2);
            tablePanel1.Controls.Add(btn_SelectFile2);
            tablePanel1.Controls.Add(btn_Save);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel1.Size = new System.Drawing.Size(498, 185);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // lbl_Title1
            // 
            tablePanel1.SetColumn(lbl_Title1, 0);
            lbl_Title1.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_Title1.Location = new System.Drawing.Point(13, 12);
            lbl_Title1.Name = "lbl_Title1";
            tablePanel1.SetRow(lbl_Title1, 0);
            lbl_Title1.Size = new System.Drawing.Size(393, 13);
            lbl_Title1.TabIndex = 0;
            lbl_Title1.Text = "lbl_Title1";
            // 
            // txt_FilePath1
            // 
            tablePanel1.SetColumn(txt_FilePath1, 0);
            txt_FilePath1.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_FilePath1.EditValue = "";
            txt_FilePath1.Location = new System.Drawing.Point(13, 29);
            txt_FilePath1.Name = "txt_FilePath1";
            txt_FilePath1.Properties.ReadOnly = true;
            tablePanel1.SetRow(txt_FilePath1, 1);
            txt_FilePath1.Size = new System.Drawing.Size(393, 20);
            txt_FilePath1.TabIndex = 3;
            txt_FilePath1.TabStop = false;
            txt_FilePath1.EditValueChanged += txt_RiocardFilePath_EditValueChanged;
            // 
            // btn_SelectFile1
            // 
            tablePanel1.SetColumn(btn_SelectFile1, 1);
            btn_SelectFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_SelectFile1.Location = new System.Drawing.Point(410, 29);
            btn_SelectFile1.Name = "btn_SelectFile1";
            tablePanel1.SetRow(btn_SelectFile1, 1);
            btn_SelectFile1.Size = new System.Drawing.Size(75, 23);
            btn_SelectFile1.TabIndex = 4;
            btn_SelectFile1.Text = "Selecionar";
            btn_SelectFile1.Click += btn_SelectFile1_Click;
            // 
            // lbl_Title2
            // 
            tablePanel1.SetColumn(lbl_Title2, 0);
            lbl_Title2.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_Title2.Location = new System.Drawing.Point(13, 56);
            lbl_Title2.Name = "lbl_Title2";
            tablePanel1.SetRow(lbl_Title2, 2);
            lbl_Title2.Size = new System.Drawing.Size(393, 13);
            lbl_Title2.TabIndex = 1;
            lbl_Title2.Text = "lbl_Title2";
            // 
            // txt_FilePath2
            // 
            tablePanel1.SetColumn(txt_FilePath2, 0);
            txt_FilePath2.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_FilePath2.EditValue = "";
            txt_FilePath2.Location = new System.Drawing.Point(13, 73);
            txt_FilePath2.Name = "txt_FilePath2";
            txt_FilePath2.Properties.ReadOnly = true;
            tablePanel1.SetRow(txt_FilePath2, 3);
            txt_FilePath2.Size = new System.Drawing.Size(393, 20);
            txt_FilePath2.TabIndex = 3;
            txt_FilePath2.TabStop = false;
            txt_FilePath2.EditValueChanged += txt_SatFilePath_EditValueChanged;
            // 
            // btn_SelectFile2
            // 
            tablePanel1.SetColumn(btn_SelectFile2, 1);
            btn_SelectFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_SelectFile2.Location = new System.Drawing.Point(410, 73);
            btn_SelectFile2.Name = "btn_SelectFile2";
            tablePanel1.SetRow(btn_SelectFile2, 3);
            btn_SelectFile2.Size = new System.Drawing.Size(75, 23);
            btn_SelectFile2.TabIndex = 5;
            btn_SelectFile2.Text = "Selecionar";
            btn_SelectFile2.Click += btn_SelectFile2_Click;
            // 
            // btn_Save
            // 
            tablePanel1.SetColumn(btn_Save, 0);
            tablePanel1.SetColumnSpan(btn_Save, 2);
            btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_Save.Enabled = false;
            btn_Save.Location = new System.Drawing.Point(13, 122);
            btn_Save.Name = "btn_Save";
            tablePanel1.SetRow(btn_Save, 5);
            btn_Save.Size = new System.Drawing.Size(472, 50);
            btn_Save.TabIndex = 6;
            btn_Save.Text = "Salvar";
            btn_Save.Click += btn_Save_Click;
            // 
            // chk_1
            // 
            tablePanel1.SetColumn(chk_1, 0);
            chk_1.Location = new System.Drawing.Point(13, 100);
            chk_1.Name = "chk_1";
            chk_1.Properties.Caption = "chk_1";
            tablePanel1.SetRow(chk_1, 4);
            chk_1.Size = new System.Drawing.Size(393, 18);
            chk_1.TabIndex = 7;
            // 
            // frm_RiocardBalanceTools
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(498, 185);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("frm_RiocardBalanceTools.IconOptions.Icon");
            MinimumSize = new System.Drawing.Size(500, 195);
            Name = "frm_RiocardBalanceTools";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Riocard Balance Tools";
            Load += frm_RiocardBalanceTools_Load;
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txt_FilePath1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_FilePath2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chk_1.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.SimpleButton btn_SelectFile2;
        private DevExpress.XtraEditors.SimpleButton btn_SelectFile1;
        private DevExpress.XtraEditors.TextEdit txt_FilePath2;
        private DevExpress.XtraEditors.LabelControl lbl_Title2;
        private DevExpress.XtraEditors.LabelControl lbl_Title1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txt_FilePath1;
        private DevExpress.XtraEditors.CheckEdit chk_1;
    }
}
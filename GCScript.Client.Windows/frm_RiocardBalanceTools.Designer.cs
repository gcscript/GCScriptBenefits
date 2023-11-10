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
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            btn_SelectSatFile = new DevExpress.XtraEditors.SimpleButton();
            btn_SelectRiocardFile = new DevExpress.XtraEditors.SimpleButton();
            txt_SatFilePath = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txt_RiocardFilePath = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_SatFilePath.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_RiocardFilePath.Properties).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 150F) });
            tablePanel1.Controls.Add(btn_Save);
            tablePanel1.Controls.Add(btn_SelectSatFile);
            tablePanel1.Controls.Add(btn_SelectRiocardFile);
            tablePanel1.Controls.Add(txt_SatFilePath);
            tablePanel1.Controls.Add(labelControl2);
            tablePanel1.Controls.Add(labelControl1);
            tablePanel1.Controls.Add(txt_RiocardFilePath);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel1.Size = new System.Drawing.Size(498, 163);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // btn_Save
            // 
            tablePanel1.SetColumn(btn_Save, 0);
            tablePanel1.SetColumnSpan(btn_Save, 2);
            btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_Save.Location = new System.Drawing.Point(13, 100);
            btn_Save.Name = "btn_Save";
            tablePanel1.SetRow(btn_Save, 4);
            btn_Save.Size = new System.Drawing.Size(472, 50);
            btn_Save.TabIndex = 6;
            btn_Save.Text = "Salvar";
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_SelectSatFile
            // 
            tablePanel1.SetColumn(btn_SelectSatFile, 1);
            btn_SelectSatFile.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_SelectSatFile.Location = new System.Drawing.Point(410, 73);
            btn_SelectSatFile.Name = "btn_SelectSatFile";
            tablePanel1.SetRow(btn_SelectSatFile, 3);
            btn_SelectSatFile.Size = new System.Drawing.Size(75, 23);
            btn_SelectSatFile.TabIndex = 5;
            btn_SelectSatFile.Text = "Selecionar";
            btn_SelectSatFile.Click += btn_SelectSatFile_Click;
            // 
            // btn_SelectRiocardFile
            // 
            tablePanel1.SetColumn(btn_SelectRiocardFile, 1);
            btn_SelectRiocardFile.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_SelectRiocardFile.Location = new System.Drawing.Point(410, 29);
            btn_SelectRiocardFile.Name = "btn_SelectRiocardFile";
            tablePanel1.SetRow(btn_SelectRiocardFile, 1);
            btn_SelectRiocardFile.Size = new System.Drawing.Size(75, 23);
            btn_SelectRiocardFile.TabIndex = 4;
            btn_SelectRiocardFile.Text = "Selecionar";
            btn_SelectRiocardFile.Click += btn_SelectRiocardFile_Click;
            // 
            // txt_SatFilePath
            // 
            tablePanel1.SetColumn(txt_SatFilePath, 0);
            txt_SatFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_SatFilePath.EditValue = "";
            txt_SatFilePath.Location = new System.Drawing.Point(13, 73);
            txt_SatFilePath.Name = "txt_SatFilePath";
            tablePanel1.SetRow(txt_SatFilePath, 3);
            txt_SatFilePath.Size = new System.Drawing.Size(393, 20);
            txt_SatFilePath.TabIndex = 3;
            // 
            // labelControl2
            // 
            tablePanel1.SetColumn(labelControl2, 0);
            labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl2.Location = new System.Drawing.Point(13, 56);
            labelControl2.Name = "labelControl2";
            tablePanel1.SetRow(labelControl2, 2);
            labelControl2.Size = new System.Drawing.Size(393, 13);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Saldos SAT (.csv)";
            // 
            // labelControl1
            // 
            tablePanel1.SetColumn(labelControl1, 0);
            labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl1.Location = new System.Drawing.Point(13, 12);
            labelControl1.Name = "labelControl1";
            tablePanel1.SetRow(labelControl1, 0);
            labelControl1.Size = new System.Drawing.Size(393, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Dados Riocard (.txt)";
            // 
            // txt_RiocardFilePath
            // 
            tablePanel1.SetColumn(txt_RiocardFilePath, 0);
            txt_RiocardFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            txt_RiocardFilePath.EditValue = "";
            txt_RiocardFilePath.Location = new System.Drawing.Point(13, 29);
            txt_RiocardFilePath.Name = "txt_RiocardFilePath";
            tablePanel1.SetRow(txt_RiocardFilePath, 1);
            txt_RiocardFilePath.Size = new System.Drawing.Size(393, 20);
            txt_RiocardFilePath.TabIndex = 3;
            // 
            // frm_RiocardBalanceTools
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(498, 163);
            Controls.Add(tablePanel1);
            IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("frm_RiocardBalanceTools.IconOptions.Icon");
            MinimumSize = new System.Drawing.Size(500, 195);
            Name = "frm_RiocardBalanceTools";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Riocard Balance Tools";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txt_SatFilePath.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_RiocardFilePath.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.SimpleButton btn_SelectSatFile;
        private DevExpress.XtraEditors.SimpleButton btn_SelectRiocardFile;
        private DevExpress.XtraEditors.TextEdit txt_SatFilePath;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txt_RiocardFilePath;
    }
}
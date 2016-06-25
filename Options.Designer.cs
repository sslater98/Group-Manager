namespace GroupManager
{
    partial class Options
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tblpanelFileLocation = new System.Windows.Forms.TableLayoutPanel();
            this.txtbxPath = new System.Windows.Forms.TextBox();
            this.lblOutputFileLocation = new System.Windows.Forms.Label();
            this.lblCurrentPath = new System.Windows.Forms.Label();
            this.txtbxCurrentPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblpanelFileLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnSaveSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 429);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(3, 3);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(88, 56);
            this.btnSaveSettings.TabIndex = 0;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(3, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 54);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tblpanelFileLocation
            // 
            this.tblpanelFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tblpanelFileLocation.ColumnCount = 2;
            this.tblpanelFileLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.79279F));
            this.tblpanelFileLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.20721F));
            this.tblpanelFileLocation.Controls.Add(this.txtbxPath, 1, 0);
            this.tblpanelFileLocation.Controls.Add(this.lblOutputFileLocation, 0, 0);
            this.tblpanelFileLocation.Controls.Add(this.lblCurrentPath, 0, 1);
            this.tblpanelFileLocation.Controls.Add(this.txtbxCurrentPath, 1, 1);
            this.tblpanelFileLocation.Location = new System.Drawing.Point(206, 12);
            this.tblpanelFileLocation.Name = "tblpanelFileLocation";
            this.tblpanelFileLocation.RowCount = 2;
            this.tblpanelFileLocation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpanelFileLocation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpanelFileLocation.Size = new System.Drawing.Size(589, 100);
            this.tblpanelFileLocation.TabIndex = 1;
            // 
            // txtbxPath
            // 
            this.txtbxPath.Location = new System.Drawing.Point(78, 3);
            this.txtbxPath.Name = "txtbxPath";
            this.txtbxPath.Size = new System.Drawing.Size(500, 20);
            this.txtbxPath.TabIndex = 0;
            // 
            // lblOutputFileLocation
            // 
            this.lblOutputFileLocation.AutoSize = true;
            this.lblOutputFileLocation.Location = new System.Drawing.Point(3, 0);
            this.lblOutputFileLocation.Name = "lblOutputFileLocation";
            this.lblOutputFileLocation.Size = new System.Drawing.Size(32, 13);
            this.lblOutputFileLocation.TabIndex = 1;
            this.lblOutputFileLocation.Text = "Path:";
            // 
            // lblCurrentPath
            // 
            this.lblCurrentPath.AutoSize = true;
            this.lblCurrentPath.Location = new System.Drawing.Point(3, 50);
            this.lblCurrentPath.Name = "lblCurrentPath";
            this.lblCurrentPath.Size = new System.Drawing.Size(69, 26);
            this.lblCurrentPath.TabIndex = 2;
            this.lblCurrentPath.Text = "Default Save Location";
            // 
            // txtbxCurrentPath
            // 
            this.txtbxCurrentPath.Location = new System.Drawing.Point(78, 53);
            this.txtbxCurrentPath.Name = "txtbxCurrentPath";
            this.txtbxCurrentPath.Size = new System.Drawing.Size(500, 20);
            this.txtbxCurrentPath.TabIndex = 3;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 453);
            this.Controls.Add(this.tblpanelFileLocation);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Options";
            this.Text = "Options";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblpanelFileLocation.ResumeLayout(false);
            this.tblpanelFileLocation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tblpanelFileLocation;
        private System.Windows.Forms.TextBox txtbxPath;
        private System.Windows.Forms.Label lblOutputFileLocation;
        private System.Windows.Forms.Label lblCurrentPath;
        private System.Windows.Forms.TextBox txtbxCurrentPath;
    }
}
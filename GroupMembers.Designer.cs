namespace GroupManager
{
    partial class GroupMembers
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
      this.lblMgrTitle = new System.Windows.Forms.Label();
      this.lstbxGMCurrentMembers = new System.Windows.Forms.ListBox();
      this.lblGroupName = new System.Windows.Forms.Label();
      this.lblShowGrpName = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.58907F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.410935F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 567F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
      this.tableLayoutPanel1.Controls.Add(this.lblMgrTitle, 2, 4);
      this.tableLayoutPanel1.Controls.Add(this.lstbxGMCurrentMembers, 2, 5);
      this.tableLayoutPanel1.Controls.Add(this.lblGroupName, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.lblShowGrpName, 2, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.78761F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.21239F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 319F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 565F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 686);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // lblMgrTitle
      // 
      this.lblMgrTitle.AutoSize = true;
      this.lblMgrTitle.Location = new System.Drawing.Point(9, 62);
      this.lblMgrTitle.Name = "lblMgrTitle";
      this.lblMgrTitle.Size = new System.Drawing.Size(55, 13);
      this.lblMgrTitle.TabIndex = 5;
      this.lblMgrTitle.Text = "lblMgrTitle";
      // 
      // lstbxGMCurrentMembers
      // 
      this.lstbxGMCurrentMembers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstbxGMCurrentMembers.FormattingEnabled = true;
      this.lstbxGMCurrentMembers.Location = new System.Drawing.Point(9, 97);
      this.lstbxGMCurrentMembers.Name = "lstbxGMCurrentMembers";
      this.lstbxGMCurrentMembers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.lstbxGMCurrentMembers.Size = new System.Drawing.Size(561, 559);
      this.lstbxGMCurrentMembers.TabIndex = 4;
      // 
      // lblGroupName
      // 
      this.lblGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lblGroupName.AutoSize = true;
      this.lblGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGroupName.Location = new System.Drawing.Point(9, -288);
      this.lblGroupName.Name = "lblGroupName";
      this.lblGroupName.Size = new System.Drawing.Size(88, 319);
      this.lblGroupName.TabIndex = 0;
      this.lblGroupName.Text = "Group Name";
      this.lblGroupName.Click += new System.EventHandler(this.lblGroupName_Click);
      // 
      // lblShowGrpName
      // 
      this.lblShowGrpName.AutoSize = true;
      this.lblShowGrpName.Location = new System.Drawing.Point(8, 31);
      this.lblShowGrpName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblShowGrpName.Name = "lblShowGrpName";
      this.lblShowGrpName.Size = new System.Drawing.Size(83, 13);
      this.lblShowGrpName.TabIndex = 6;
      this.lblShowGrpName.Text = "lblShowGrName";
      // 
      // GroupMembers
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(598, 686);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "GroupMembers";
      this.Text = "GroupMembers";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.ListBox lstbxGMCurrentMembers;
        private System.Windows.Forms.Label lblMgrTitle;
    private System.Windows.Forms.Label lblShowGrpName;
  }
}
    using System.Drawing;

namespace GroupManager
{
    partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.btnExit = new System.Windows.Forms.Button();
      this.lblRunning = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.lblInstructions = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutGroupManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fileLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.btnClearGroupList = new System.Windows.Forms.Button();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnSelectAllGroups = new System.Windows.Forms.Button();
      this.chkbxSaveGrpInfo = new System.Windows.Forms.CheckBox();
      this.chkbxExpdGrps = new System.Windows.Forms.CheckBox();
      this.btnUnselectAll = new System.Windows.Forms.Button();
      this.chkbxListofGroupsToSelectFrom = new System.Windows.Forms.CheckedListBox();
      this.btnShowMembers = new System.Windows.Forms.Button();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.btnAddSelected = new System.Windows.Forms.Button();
      this.lblMultMatchNames = new System.Windows.Forms.Label();
      this.btnResolveNames = new System.Windows.Forms.Button();
      this.btnClearPotential = new System.Windows.Forms.Button();
      this.lblPotentialMatches = new System.Windows.Forms.Label();
      this.lstbxPeople = new System.Windows.Forms.ListBox();
      this.lblErr = new System.Windows.Forms.Label();
      this.btnGrpCheck = new System.Windows.Forms.Button();
      this.lblSuccess = new System.Windows.Forms.Label();
      this.rtbFindThese = new System.Windows.Forms.RichTextBox();
      this.lblGroup = new System.Windows.Forms.Label();
      this.txtGroupName = new System.Windows.Forms.TextBox();
      this.lblAddPeopletoFindInstructions = new System.Windows.Forms.Label();
      this.rtbResolvedOK = new System.Windows.Forms.RichTextBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
      this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.btnClearGroupList);
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
      this.splitContainer1.Panel2.Controls.Add(this.btnSelectAllGroups);
      this.splitContainer1.Panel2.Controls.Add(this.chkbxSaveGrpInfo);
      this.splitContainer1.Panel2.Controls.Add(this.chkbxExpdGrps);
      this.splitContainer1.Panel2.Controls.Add(this.btnUnselectAll);
      this.splitContainer1.Panel2.Controls.Add(this.chkbxListofGroupsToSelectFrom);
      this.splitContainer1.Panel2.Controls.Add(this.btnShowMembers);
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
      this.splitContainer1.Panel2.Controls.Add(this.lblPotentialMatches);
      this.splitContainer1.Panel2.Controls.Add(this.lstbxPeople);
      this.splitContainer1.Panel2.Controls.Add(this.lblErr);
      this.splitContainer1.Panel2.Controls.Add(this.btnGrpCheck);
      this.splitContainer1.Panel2.Controls.Add(this.lblSuccess);
      this.splitContainer1.Panel2.Controls.Add(this.rtbFindThese);
      this.splitContainer1.Panel2.Controls.Add(this.lblGroup);
      this.splitContainer1.Panel2.Controls.Add(this.txtGroupName);
      this.splitContainer1.Panel2.Controls.Add(this.lblAddPeopletoFindInstructions);
      this.splitContainer1.Panel2.Controls.Add(this.rtbResolvedOK);
      this.splitContainer1.Size = new System.Drawing.Size(1547, 884);
      this.splitContainer1.SplitterDistance = 361;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel3.Controls.Add(this.btnExit, 0, 1);
      this.tableLayoutPanel3.Controls.Add(this.lblRunning, 0, 0);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 761);
      this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(361, 123);
      this.tableLayoutPanel3.TabIndex = 2;
      // 
      // btnExit
      // 
      this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnExit.BackColor = System.Drawing.SystemColors.Control;
      this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnExit.Location = new System.Drawing.Point(38, 68);
      this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(104, 48);
      this.btnExit.TabIndex = 0;
      this.btnExit.Text = "Exit";
      this.btnExit.UseVisualStyleBackColor = false;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // lblRunning
      // 
      this.lblRunning.AutoSize = true;
      this.lblRunning.Location = new System.Drawing.Point(4, 0);
      this.lblRunning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblRunning.Name = "lblRunning";
      this.lblRunning.Size = new System.Drawing.Size(46, 17);
      this.lblRunning.TabIndex = 1;
      this.lblRunning.Text = "label1";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.Cornsilk;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.lblInstructions, 0, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(363, 727);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // lblInstructions
      // 
      this.lblInstructions.AutoSize = true;
      this.lblInstructions.Location = new System.Drawing.Point(4, 0);
      this.lblInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblInstructions.Name = "lblInstructions";
      this.lblInstructions.Size = new System.Drawing.Size(80, 17);
      this.lblInstructions.TabIndex = 2;
      this.lblInstructions.Text = "Instructions";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.optionsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(4, 8);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(180, 28);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(170, 6);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutGroupManagerToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
      this.helpToolStripMenuItem.Text = "Help";
      this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
      // 
      // aboutGroupManagerToolStripMenuItem
      // 
      this.aboutGroupManagerToolStripMenuItem.Name = "aboutGroupManagerToolStripMenuItem";
      this.aboutGroupManagerToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
      this.aboutGroupManagerToolStripMenuItem.Text = "About Group Manager";
      this.aboutGroupManagerToolStripMenuItem.Click += new System.EventHandler(this.aboutGroupManagerToolStripMenuItem_Click);
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileLocationsToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
      this.optionsToolStripMenuItem.Text = "Options";
      // 
      // fileLocationsToolStripMenuItem
      // 
      this.fileLocationsToolStripMenuItem.Name = "fileLocationsToolStripMenuItem";
      this.fileLocationsToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
      this.fileLocationsToolStripMenuItem.Text = "File Locations";
      this.fileLocationsToolStripMenuItem.Click += new System.EventHandler(this.fileLocationsToolStripMenuItem_Click);
      // 
      // btnClearGroupList
      // 
      this.btnClearGroupList.Location = new System.Drawing.Point(341, 95);
      this.btnClearGroupList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnClearGroupList.Name = "btnClearGroupList";
      this.btnClearGroupList.Size = new System.Drawing.Size(124, 34);
      this.btnClearGroupList.TabIndex = 22;
      this.btnClearGroupList.Text = "Clear List";
      this.btnClearGroupList.UseVisualStyleBackColor = true;
      this.btnClearGroupList.Click += new System.EventHandler(this.btnClearGroupList_Click);
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.ColumnCount = 3;
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
      this.tableLayoutPanel4.Controls.Add(this.btnAdd, 0, 1);
      this.tableLayoutPanel4.Controls.Add(this.btnDelete, 1, 1);
      this.tableLayoutPanel4.Location = new System.Drawing.Point(908, 725);
      this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 3;
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.51351F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.48649F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
      this.tableLayoutPanel4.Size = new System.Drawing.Size(265, 159);
      this.tableLayoutPanel4.TabIndex = 21;
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.btnAdd.Enabled = false;
      this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnAdd.Location = new System.Drawing.Point(3, 59);
      this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(119, 86);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Everyone?  Everyone-e-e-!";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.btnDelete.Location = new System.Drawing.Point(129, 61);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(117, 82);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnSelectAllGroups
      // 
      this.btnSelectAllGroups.Enabled = false;
      this.btnSelectAllGroups.Location = new System.Drawing.Point(200, 97);
      this.btnSelectAllGroups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnSelectAllGroups.Name = "btnSelectAllGroups";
      this.btnSelectAllGroups.Size = new System.Drawing.Size(135, 32);
      this.btnSelectAllGroups.TabIndex = 20;
      this.btnSelectAllGroups.Text = "Select All Groups";
      this.btnSelectAllGroups.UseVisualStyleBackColor = true;
      this.btnSelectAllGroups.Click += new System.EventHandler(this.btnSelectAllGroups_Click);
      // 
      // chkbxSaveGrpInfo
      // 
      this.chkbxSaveGrpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.chkbxSaveGrpInfo.AutoSize = true;
      this.chkbxSaveGrpInfo.Location = new System.Drawing.Point(40, 370);
      this.chkbxSaveGrpInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.chkbxSaveGrpInfo.Name = "chkbxSaveGrpInfo";
      this.chkbxSaveGrpInfo.Size = new System.Drawing.Size(130, 21);
      this.chkbxSaveGrpInfo.TabIndex = 19;
      this.chkbxSaveGrpInfo.Text = "Save group info";
      this.chkbxSaveGrpInfo.UseVisualStyleBackColor = true;
      // 
      // chkbxExpdGrps
      // 
      this.chkbxExpdGrps.AutoSize = true;
      this.chkbxExpdGrps.Location = new System.Drawing.Point(251, 370);
      this.chkbxExpdGrps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.chkbxExpdGrps.Name = "chkbxExpdGrps";
      this.chkbxExpdGrps.Size = new System.Drawing.Size(180, 21);
      this.chkbxExpdGrps.TabIndex = 18;
      this.chkbxExpdGrps.Text = "Expand member groups";
      this.chkbxExpdGrps.UseVisualStyleBackColor = true;
      this.chkbxExpdGrps.CheckedChanged += new System.EventHandler(this.chkbxExpdGrps_CheckedChanged);
      // 
      // btnUnselectAll
      // 
      this.btnUnselectAll.Enabled = false;
      this.btnUnselectAll.Location = new System.Drawing.Point(40, 97);
      this.btnUnselectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnUnselectAll.Name = "btnUnselectAll";
      this.btnUnselectAll.Size = new System.Drawing.Size(155, 33);
      this.btnUnselectAll.TabIndex = 17;
      this.btnUnselectAll.Text = "Unselect All Groups";
      this.btnUnselectAll.UseVisualStyleBackColor = true;
      this.btnUnselectAll.Click += new System.EventHandler(this.button1_Click);
      // 
      // chkbxListofGroupsToSelectFrom
      // 
      this.chkbxListofGroupsToSelectFrom.CheckOnClick = true;
      this.chkbxListofGroupsToSelectFrom.FormattingEnabled = true;
      this.chkbxListofGroupsToSelectFrom.HorizontalScrollbar = true;
      this.chkbxListofGroupsToSelectFrom.Location = new System.Drawing.Point(40, 138);
      this.chkbxListofGroupsToSelectFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.chkbxListofGroupsToSelectFrom.Name = "chkbxListofGroupsToSelectFrom";
      this.chkbxListofGroupsToSelectFrom.ScrollAlwaysVisible = true;
      this.chkbxListofGroupsToSelectFrom.Size = new System.Drawing.Size(421, 225);
      this.chkbxListofGroupsToSelectFrom.Sorted = true;
      this.chkbxListofGroupsToSelectFrom.TabIndex = 15;
      this.chkbxListofGroupsToSelectFrom.ThreeDCheckBoxes = true;
      this.chkbxListofGroupsToSelectFrom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkbxListofGroupsToSelectFrom_MouseDown);
      // 
      // btnShowMembers
      // 
      this.btnShowMembers.Location = new System.Drawing.Point(299, 1);
      this.btnShowMembers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnShowMembers.Name = "btnShowMembers";
      this.btnShowMembers.Size = new System.Drawing.Size(163, 39);
      this.btnShowMembers.TabIndex = 14;
      this.btnShowMembers.Text = "Show Members";
      this.btnShowMembers.UseVisualStyleBackColor = true;
      this.btnShowMembers.Click += new System.EventHandler(this.btnShowMembers_Click);
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.78947F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.210526F));
      this.tableLayoutPanel2.Controls.Add(this.btnAddSelected, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.lblMultMatchNames, 0, 3);
      this.tableLayoutPanel2.Controls.Add(this.btnResolveNames, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.btnClearPotential, 0, 2);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(908, 129);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 4;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.85057F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.14943F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 194F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 274F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(268, 590);
      this.tableLayoutPanel2.TabIndex = 13;
      // 
      // btnAddSelected
      // 
      this.btnAddSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.btnAddSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnAddSelected.Location = new System.Drawing.Point(3, 64);
      this.btnAddSelected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnAddSelected.Name = "btnAddSelected";
      this.btnAddSelected.Size = new System.Drawing.Size(250, 52);
      this.btnAddSelected.TabIndex = 1;
      this.btnAddSelected.Text = "Add Selected Names";
      this.btnAddSelected.UseVisualStyleBackColor = true;
      this.btnAddSelected.Click += new System.EventHandler(this.btnAddSelected_Click);
      // 
      // lblMultMatchNames
      // 
      this.lblMultMatchNames.AutoSize = true;
      this.lblMultMatchNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMultMatchNames.ForeColor = System.Drawing.SystemColors.Highlight;
      this.lblMultMatchNames.Location = new System.Drawing.Point(4, 315);
      this.lblMultMatchNames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMultMatchNames.Name = "lblMultMatchNames";
      this.lblMultMatchNames.Size = new System.Drawing.Size(248, 160);
      this.lblMultMatchNames.TabIndex = 2;
      this.lblMultMatchNames.Text = "All names should be in the list to the left (Resolved Successfully).  If names ar" +
    "e still missing, find them in the \'Potential Group Members\' list and click the A" +
    "dd Selected Names button (above)";
      this.lblMultMatchNames.Visible = false;
      // 
      // btnResolveNames
      // 
      this.btnResolveNames.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.btnResolveNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnResolveNames.Location = new System.Drawing.Point(3, 5);
      this.btnResolveNames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnResolveNames.Name = "btnResolveNames";
      this.btnResolveNames.Size = new System.Drawing.Size(250, 48);
      this.btnResolveNames.TabIndex = 0;
      this.btnResolveNames.Text = "Resolve Names";
      this.btnResolveNames.UseVisualStyleBackColor = true;
      this.btnResolveNames.Click += new System.EventHandler(this.btnResolve_Click);
      // 
      // btnClearPotential
      // 
      this.btnClearPotential.Location = new System.Drawing.Point(3, 123);
      this.btnClearPotential.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnClearPotential.Name = "btnClearPotential";
      this.btnClearPotential.Size = new System.Drawing.Size(250, 55);
      this.btnClearPotential.TabIndex = 3;
      this.btnClearPotential.Text = "Clear Potential List";
      this.btnClearPotential.UseVisualStyleBackColor = true;
      this.btnClearPotential.Click += new System.EventHandler(this.btnClearPotential_Click);
      // 
      // lblPotentialMatches
      // 
      this.lblPotentialMatches.AutoSize = true;
      this.lblPotentialMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPotentialMatches.Location = new System.Drawing.Point(551, 105);
      this.lblPotentialMatches.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPotentialMatches.Name = "lblPotentialMatches";
      this.lblPotentialMatches.Size = new System.Drawing.Size(224, 24);
      this.lblPotentialMatches.TabIndex = 12;
      this.lblPotentialMatches.Text = "Potential Group Members";
      // 
      // lstbxPeople
      // 
      this.lstbxPeople.FormattingEnabled = true;
      this.lstbxPeople.HorizontalScrollbar = true;
      this.lstbxPeople.ItemHeight = 16;
      this.lstbxPeople.Location = new System.Drawing.Point(469, 134);
      this.lstbxPeople.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.lstbxPeople.Name = "lstbxPeople";
      this.lstbxPeople.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.lstbxPeople.ScrollAlwaysVisible = true;
      this.lstbxPeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.lstbxPeople.Size = new System.Drawing.Size(411, 228);
      this.lstbxPeople.Sorted = true;
      this.lstbxPeople.TabIndex = 4;
      this.lstbxPeople.SelectedIndexChanged += new System.EventHandler(this.lstbxPeople_SelectedIndexChanged);
      this.lstbxPeople.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstbxPeople_KeyDown);
      this.lstbxPeople.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstbxPeople_MouseDown);
      // 
      // lblErr
      // 
      this.lblErr.AutoSize = true;
      this.lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
      this.lblErr.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblErr.Location = new System.Drawing.Point(491, 7);
      this.lblErr.Name = "lblErr";
      this.lblErr.Size = new System.Drawing.Size(365, 20);
      this.lblErr.TabIndex = 8;
      this.lblErr.Text = "Type a group name and click Check Group";
      // 
      // btnGrpCheck
      // 
      this.btnGrpCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGrpCheck.Location = new System.Drawing.Point(40, 0);
      this.btnGrpCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnGrpCheck.Name = "btnGrpCheck";
      this.btnGrpCheck.Size = new System.Drawing.Size(165, 39);
      this.btnGrpCheck.TabIndex = 1;
      this.btnGrpCheck.Text = "Check Group";
      this.btnGrpCheck.UseVisualStyleBackColor = true;
      this.btnGrpCheck.Click += new System.EventHandler(this.btnGrpCheck_Click);
      this.btnGrpCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnGrpCheck_Click);
      // 
      // lblSuccess
      // 
      this.lblSuccess.AutoSize = true;
      this.lblSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSuccess.Location = new System.Drawing.Point(477, 414);
      this.lblSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSuccess.Name = "lblSuccess";
      this.lblSuccess.Size = new System.Drawing.Size(176, 20);
      this.lblSuccess.TabIndex = 6;
      this.lblSuccess.Text = "Resolved successfully";
      // 
      // rtbFindThese
      // 
      this.rtbFindThese.Location = new System.Drawing.Point(40, 437);
      this.rtbFindThese.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rtbFindThese.Name = "rtbFindThese";
      this.rtbFindThese.Size = new System.Drawing.Size(421, 441);
      this.rtbFindThese.TabIndex = 3;
      this.rtbFindThese.Text = "rtbFindThese";
      this.rtbFindThese.TextChanged += new System.EventHandler(this.rtbFindThese_TextChanged);
      this.rtbFindThese.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbFindThese_MouseDown);
      // 
      // lblGroup
      // 
      this.lblGroup.AutoSize = true;
      this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGroup.Location = new System.Drawing.Point(36, 43);
      this.lblGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblGroup.Name = "lblGroup";
      this.lblGroup.Size = new System.Drawing.Size(55, 20);
      this.lblGroup.TabIndex = 3;
      this.lblGroup.Text = "Group";
      // 
      // txtGroupName
      // 
      this.txtGroupName.Location = new System.Drawing.Point(40, 66);
      this.txtGroupName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.txtGroupName.Name = "txtGroupName";
      this.txtGroupName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
      this.txtGroupName.Size = new System.Drawing.Size(420, 22);
      this.txtGroupName.TabIndex = 0;
      this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
      // 
      // lblAddPeopletoFindInstructions
      // 
      this.lblAddPeopletoFindInstructions.AutoSize = true;
      this.lblAddPeopletoFindInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAddPeopletoFindInstructions.Location = new System.Drawing.Point(36, 410);
      this.lblAddPeopletoFindInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblAddPeopletoFindInstructions.Name = "lblAddPeopletoFindInstructions";
      this.lblAddPeopletoFindInstructions.Size = new System.Drawing.Size(264, 20);
      this.lblAddPeopletoFindInstructions.TabIndex = 1;
      this.lblAddPeopletoFindInstructions.Text = "People to Add (type names below)";
      // 
      // rtbResolvedOK
      // 
      this.rtbResolvedOK.Location = new System.Drawing.Point(481, 442);
      this.rtbResolvedOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rtbResolvedOK.Name = "rtbResolvedOK";
      this.rtbResolvedOK.Size = new System.Drawing.Size(399, 441);
      this.rtbResolvedOK.TabIndex = 5;
      this.rtbResolvedOK.Text = "";
      this.rtbResolvedOK.TextChanged += new System.EventHandler(this.rtbResolvedOK_TextChanged);
      this.rtbResolvedOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbResolvedOK_MouseDown);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "Group Manager 1.0";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(406, 891);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(872, 38);
      this.progressBar1.TabIndex = 1;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1665, 929);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.splitContainer1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Form1";
      this.Text = "Group Manager";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblAddPeopletoFindInstructions;
        private System.Windows.Forms.RichTextBox rtbResolvedOK;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.RichTextBox rtbFindThese;
        private System.Windows.Forms.Button btnGrpCheck;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstbxPeople;
        private System.Windows.Forms.Label lblPotentialMatches;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnResolveNames;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutGroupManagerToolStripMenuItem;
        private System.Windows.Forms.Button btnShowMembers;
        private System.Windows.Forms.CheckedListBox chkbxListofGroupsToSelectFrom;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.CheckBox chkbxExpdGrps;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox chkbxSaveGrpInfo;
        private System.Windows.Forms.Button btnSelectAllGroups;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileLocationsToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblMultMatchNames;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblRunning;
    private System.Windows.Forms.Button btnClearGroupList;
    private System.Windows.Forms.Button btnClearPotential;
    private System.Windows.Forms.ProgressBar progressBar1;
  }
}


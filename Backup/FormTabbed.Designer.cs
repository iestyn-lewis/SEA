namespace SEA
{
    partial class FormTabbed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTabbed));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAnalysisFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdApplyFilterLib = new System.Windows.Forms.Button();
            this.lblMaxCompounds = new System.Windows.Forms.Label();
            this.txtMaxCompounds = new System.Windows.Forms.TextBox();
            this.lblMinCompounds = new System.Windows.Forms.Label();
            this.txtMinCompounds = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSubsFiltProps = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubsProps = new System.Windows.Forms.Label();
            this.lstSubsLib = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExLowCutoff = new System.Windows.Forms.TextBox();
            this.txtExHighCutoff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExcludeText = new System.Windows.Forms.TextBox();
            this.cmdApplyFilterRes = new System.Windows.Forms.Button();
            this.cmdApplyAllFilterRes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExSDsBelow = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbExSDsAbove = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblFilteredResultProperties = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblResultProperties = new System.Windows.Forms.Label();
            this.btnBrowseAssayResults = new System.Windows.Forms.Button();
            this.lstAssayResults = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStopAnalysis = new System.Windows.Forms.Button();
            this.btnPerformAnalysis = new System.Windows.Forms.Button();
            this.pgAnalysis = new System.Windows.Forms.ProgressBar();
            this.lvStatistics = new System.Windows.Forms.ListView();
            this.statName = new System.Windows.Forms.ColumnHeader();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnViewFile = new System.Windows.Forms.Button();
            this.lstAnalysisResults = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblAnalysisProgress = new System.Windows.Forms.Label();
            this.txtEntryName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadAnalysisFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadAnalysisFileToolStripMenuItem
            // 
            this.loadAnalysisFileToolStripMenuItem.Name = "loadAnalysisFileToolStripMenuItem";
            this.loadAnalysisFileToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.loadAnalysisFileToolStripMenuItem.Text = "Load Analysis File...";
            this.loadAnalysisFileToolStripMenuItem.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            this.analysisToolStripMenuItem.Visible = false;
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.contentsToolStripMenuItem.Text = "Contents";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabTabs
            // 
            this.tabTabs.Controls.Add(this.tabPage1);
            this.tabTabs.Controls.Add(this.tabPage2);
            this.tabTabs.Controls.Add(this.tabPage3);
            this.tabTabs.Controls.Add(this.tabPage4);
            this.tabTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTabs.Location = new System.Drawing.Point(0, 24);
            this.tabTabs.Name = "tabTabs";
            this.tabTabs.SelectedIndex = 0;
            this.tabTabs.Size = new System.Drawing.Size(715, 470);
            this.tabTabs.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lstSubsLib);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Substructure Libraries";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtEntryName);
            this.groupBox3.Controls.Add(this.cmdApplyFilterLib);
            this.groupBox3.Controls.Add(this.lblMaxCompounds);
            this.groupBox3.Controls.Add(this.txtMaxCompounds);
            this.groupBox3.Controls.Add(this.lblMinCompounds);
            this.groupBox3.Controls.Add(this.txtMinCompounds);
            this.groupBox3.Location = new System.Drawing.Point(11, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 173);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // cmdApplyFilterLib
            // 
            this.cmdApplyFilterLib.Location = new System.Drawing.Point(22, 132);
            this.cmdApplyFilterLib.Name = "cmdApplyFilterLib";
            this.cmdApplyFilterLib.Size = new System.Drawing.Size(75, 23);
            this.cmdApplyFilterLib.TabIndex = 18;
            this.cmdApplyFilterLib.Text = "Apply";
            this.cmdApplyFilterLib.UseVisualStyleBackColor = true;
            this.cmdApplyFilterLib.Click += new System.EventHandler(this.cmdApplyFilterLib_Click);
            // 
            // lblMaxCompounds
            // 
            this.lblMaxCompounds.AutoSize = true;
            this.lblMaxCompounds.Location = new System.Drawing.Point(92, 64);
            this.lblMaxCompounds.Name = "lblMaxCompounds";
            this.lblMaxCompounds.Size = new System.Drawing.Size(153, 13);
            this.lblMaxCompounds.TabIndex = 17;
            this.lblMaxCompounds.Text = "Maximum compounds per entry";
            // 
            // txtMaxCompounds
            // 
            this.txtMaxCompounds.Location = new System.Drawing.Point(22, 61);
            this.txtMaxCompounds.Name = "txtMaxCompounds";
            this.txtMaxCompounds.Size = new System.Drawing.Size(58, 20);
            this.txtMaxCompounds.TabIndex = 16;
            // 
            // lblMinCompounds
            // 
            this.lblMinCompounds.AutoSize = true;
            this.lblMinCompounds.Location = new System.Drawing.Point(92, 34);
            this.lblMinCompounds.Name = "lblMinCompounds";
            this.lblMinCompounds.Size = new System.Drawing.Size(150, 13);
            this.lblMinCompounds.TabIndex = 15;
            this.lblMinCompounds.Text = "Minimum compounds per entry";
            // 
            // txtMinCompounds
            // 
            this.txtMinCompounds.Location = new System.Drawing.Point(22, 31);
            this.txtMinCompounds.Name = "txtMinCompounds";
            this.txtMinCompounds.Size = new System.Drawing.Size(58, 20);
            this.txtMinCompounds.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSubsFiltProps);
            this.groupBox2.Location = new System.Drawing.Point(319, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 174);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtered Properties";
            // 
            // lblSubsFiltProps
            // 
            this.lblSubsFiltProps.AutoSize = true;
            this.lblSubsFiltProps.Location = new System.Drawing.Point(21, 31);
            this.lblSubsFiltProps.Name = "lblSubsFiltProps";
            this.lblSubsFiltProps.Size = new System.Drawing.Size(63, 13);
            this.lblSubsFiltProps.TabIndex = 1;
            this.lblSubsFiltProps.Text = "No filter set.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSubsProps);
            this.groupBox1.Location = new System.Drawing.Point(319, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 174);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // lblSubsProps
            // 
            this.lblSubsProps.AutoSize = true;
            this.lblSubsProps.Location = new System.Drawing.Point(21, 28);
            this.lblSubsProps.Name = "lblSubsProps";
            this.lblSubsProps.Size = new System.Drawing.Size(97, 13);
            this.lblSubsProps.TabIndex = 0;
            this.lblSubsProps.Text = "No library selected.";
            // 
            // lstSubsLib
            // 
            this.lstSubsLib.FormattingEnabled = true;
            this.lstSubsLib.Location = new System.Drawing.Point(11, 20);
            this.lstSubsLib.Name = "lstSubsLib";
            this.lstSubsLib.Size = new System.Drawing.Size(281, 173);
            this.lstSubsLib.TabIndex = 9;
            this.lstSubsLib.SelectedIndexChanged += new System.EventHandler(this.lstSubsLib_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.btnBrowseAssayResults);
            this.tabPage2.Controls.Add(this.lstAssayResults);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Assay Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtExLowCutoff);
            this.groupBox4.Controls.Add(this.txtExHighCutoff);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtExcludeText);
            this.groupBox4.Controls.Add(this.cmdApplyFilterRes);
            this.groupBox4.Controls.Add(this.cmdApplyAllFilterRes);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cmbExSDsBelow);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cmbExSDsAbove);
            this.groupBox4.Location = new System.Drawing.Point(13, 214);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(289, 201);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Exclude    <";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Exclude    >";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Exclude";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Exclude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Exclude";
            // 
            // txtExLowCutoff
            // 
            this.txtExLowCutoff.Location = new System.Drawing.Point(82, 125);
            this.txtExLowCutoff.Name = "txtExLowCutoff";
            this.txtExLowCutoff.Size = new System.Drawing.Size(44, 20);
            this.txtExLowCutoff.TabIndex = 14;
            // 
            // txtExHighCutoff
            // 
            this.txtExHighCutoff.Location = new System.Drawing.Point(82, 102);
            this.txtExHighCutoff.Name = "txtExHighCutoff";
            this.txtExHighCutoff.Size = new System.Drawing.Size(44, 20);
            this.txtExHighCutoff.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "in second column";
            // 
            // txtExcludeText
            // 
            this.txtExcludeText.Location = new System.Drawing.Point(82, 20);
            this.txtExcludeText.Name = "txtExcludeText";
            this.txtExcludeText.Size = new System.Drawing.Size(100, 20);
            this.txtExcludeText.TabIndex = 9;
            // 
            // cmdApplyFilterRes
            // 
            this.cmdApplyFilterRes.Location = new System.Drawing.Point(19, 160);
            this.cmdApplyFilterRes.Name = "cmdApplyFilterRes";
            this.cmdApplyFilterRes.Size = new System.Drawing.Size(75, 23);
            this.cmdApplyFilterRes.TabIndex = 8;
            this.cmdApplyFilterRes.Text = "Apply";
            this.cmdApplyFilterRes.UseVisualStyleBackColor = true;
            this.cmdApplyFilterRes.Click += new System.EventHandler(this.cmdApplyFilterRes_Click);
            // 
            // cmdApplyAllFilterRes
            // 
            this.cmdApplyAllFilterRes.Location = new System.Drawing.Point(115, 160);
            this.cmdApplyAllFilterRes.Name = "cmdApplyAllFilterRes";
            this.cmdApplyAllFilterRes.Size = new System.Drawing.Size(89, 23);
            this.cmdApplyAllFilterRes.TabIndex = 7;
            this.cmdApplyAllFilterRes.Text = "Apply to All";
            this.cmdApplyAllFilterRes.UseVisualStyleBackColor = true;
            this.cmdApplyAllFilterRes.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SDs BELOW the mean";
            // 
            // cmbExSDsBelow
            // 
            this.cmbExSDsBelow.FormattingEnabled = true;
            this.cmbExSDsBelow.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3"});
            this.cmbExSDsBelow.Location = new System.Drawing.Point(82, 75);
            this.cmbExSDsBelow.Name = "cmbExSDsBelow";
            this.cmbExSDsBelow.Size = new System.Drawing.Size(44, 21);
            this.cmbExSDsBelow.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SDs ABOVE the mean";
            // 
            // cmbExSDsAbove
            // 
            this.cmbExSDsAbove.FormattingEnabled = true;
            this.cmbExSDsAbove.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3"});
            this.cmbExSDsAbove.Location = new System.Drawing.Point(82, 48);
            this.cmbExSDsAbove.Name = "cmbExSDsAbove";
            this.cmbExSDsAbove.Size = new System.Drawing.Size(44, 21);
            this.cmbExSDsAbove.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblFilteredResultProperties);
            this.groupBox5.Location = new System.Drawing.Point(330, 219);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(349, 196);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filtered Properties";
            // 
            // lblFilteredResultProperties
            // 
            this.lblFilteredResultProperties.AutoSize = true;
            this.lblFilteredResultProperties.Location = new System.Drawing.Point(18, 24);
            this.lblFilteredResultProperties.Name = "lblFilteredResultProperties";
            this.lblFilteredResultProperties.Size = new System.Drawing.Size(63, 13);
            this.lblFilteredResultProperties.TabIndex = 1;
            this.lblFilteredResultProperties.Text = "No filter set.";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblResultProperties);
            this.groupBox6.Location = new System.Drawing.Point(330, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(349, 174);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Properties";
            // 
            // lblResultProperties
            // 
            this.lblResultProperties.AutoSize = true;
            this.lblResultProperties.Location = new System.Drawing.Point(18, 28);
            this.lblResultProperties.Name = "lblResultProperties";
            this.lblResultProperties.Size = new System.Drawing.Size(97, 13);
            this.lblResultProperties.TabIndex = 0;
            this.lblResultProperties.Text = "No assay selected.";
            // 
            // btnBrowseAssayResults
            // 
            this.btnBrowseAssayResults.Location = new System.Drawing.Point(209, 184);
            this.btnBrowseAssayResults.Name = "btnBrowseAssayResults";
            this.btnBrowseAssayResults.Size = new System.Drawing.Size(93, 24);
            this.btnBrowseAssayResults.TabIndex = 6;
            this.btnBrowseAssayResults.Text = "Browse...";
            this.btnBrowseAssayResults.UseVisualStyleBackColor = true;
            this.btnBrowseAssayResults.Click += new System.EventHandler(this.btnBrowseAssayResults_Click);
            // 
            // lstAssayResults
            // 
            this.lstAssayResults.FormattingEnabled = true;
            this.lstAssayResults.Location = new System.Drawing.Point(13, 18);
            this.lstAssayResults.Name = "lstAssayResults";
            this.lstAssayResults.Size = new System.Drawing.Size(289, 160);
            this.lstAssayResults.TabIndex = 5;
            this.lstAssayResults.SelectedIndexChanged += new System.EventHandler(this.lstAssayResults_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblAnalysisProgress);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnStopAnalysis);
            this.tabPage3.Controls.Add(this.btnPerformAnalysis);
            this.tabPage3.Controls.Add(this.pgAnalysis);
            this.tabPage3.Controls.Add(this.lvStatistics);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(707, 444);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Analysis Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "The checked analyses will be run.";
            // 
            // btnStopAnalysis
            // 
            this.btnStopAnalysis.Location = new System.Drawing.Point(447, 199);
            this.btnStopAnalysis.Name = "btnStopAnalysis";
            this.btnStopAnalysis.Size = new System.Drawing.Size(235, 25);
            this.btnStopAnalysis.TabIndex = 3;
            this.btnStopAnalysis.Text = "Stop Analysis";
            this.btnStopAnalysis.UseVisualStyleBackColor = true;
            this.btnStopAnalysis.Click += new System.EventHandler(this.btnStopAnalysis_Click);
            // 
            // btnPerformAnalysis
            // 
            this.btnPerformAnalysis.Location = new System.Drawing.Point(19, 199);
            this.btnPerformAnalysis.Name = "btnPerformAnalysis";
            this.btnPerformAnalysis.Size = new System.Drawing.Size(235, 25);
            this.btnPerformAnalysis.TabIndex = 2;
            this.btnPerformAnalysis.Text = "Run Analysis";
            this.btnPerformAnalysis.UseVisualStyleBackColor = true;
            this.btnPerformAnalysis.Click += new System.EventHandler(this.btnPerformAnalysis_Click);
            // 
            // pgAnalysis
            // 
            this.pgAnalysis.Location = new System.Drawing.Point(19, 234);
            this.pgAnalysis.Name = "pgAnalysis";
            this.pgAnalysis.Size = new System.Drawing.Size(662, 30);
            this.pgAnalysis.TabIndex = 1;
            // 
            // lvStatistics
            // 
            this.lvStatistics.CheckBoxes = true;
            this.lvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.statName});
            this.lvStatistics.GridLines = true;
            this.lvStatistics.Location = new System.Drawing.Point(18, 32);
            this.lvStatistics.Name = "lvStatistics";
            this.lvStatistics.Size = new System.Drawing.Size(663, 151);
            this.lvStatistics.TabIndex = 0;
            this.lvStatistics.UseCompatibleStateImageBehavior = false;
            this.lvStatistics.View = System.Windows.Forms.View.Details;
            // 
            // statName
            // 
            this.statName.Text = "Name";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnSaveFile);
            this.tabPage4.Controls.Add(this.btnViewFile);
            this.tabPage4.Controls.Add(this.lstAnalysisResults);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(707, 444);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Post-Analysis";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(317, 48);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(146, 24);
            this.btnSaveFile.TabIndex = 18;
            this.btnSaveFile.Text = "Save Selected File...";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnViewFile
            // 
            this.btnViewFile.Location = new System.Drawing.Point(317, 18);
            this.btnViewFile.Name = "btnViewFile";
            this.btnViewFile.Size = new System.Drawing.Size(146, 24);
            this.btnViewFile.TabIndex = 17;
            this.btnViewFile.Text = "View Selected File";
            this.btnViewFile.UseVisualStyleBackColor = true;
            this.btnViewFile.Click += new System.EventHandler(this.btnViewFile_Click);
            // 
            // lstAnalysisResults
            // 
            this.lstAnalysisResults.FormattingEnabled = true;
            this.lstAnalysisResults.Location = new System.Drawing.Point(18, 18);
            this.lstAnalysisResults.Name = "lstAnalysisResults";
            this.lstAnalysisResults.Size = new System.Drawing.Size(281, 108);
            this.lstAnalysisResults.TabIndex = 16;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblAnalysisProgress
            // 
            this.lblAnalysisProgress.AutoSize = true;
            this.lblAnalysisProgress.Location = new System.Drawing.Point(16, 279);
            this.lblAnalysisProgress.Name = "lblAnalysisProgress";
            this.lblAnalysisProgress.Size = new System.Drawing.Size(101, 13);
            this.lblAnalysisProgress.TabIndex = 5;
            this.lblAnalysisProgress.Text = "Analysis not started.";
            // 
            // txtEntryName
            // 
            this.txtEntryName.Location = new System.Drawing.Point(22, 90);
            this.txtEntryName.Name = "txtEntryName";
            this.txtEntryName.Size = new System.Drawing.Size(100, 20);
            this.txtEntryName.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Entry name";
            // 
            // FormTabbed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 516);
            this.Controls.Add(this.tabTabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTabbed";
            this.Text = "SEA - Substructure Enrichment Analysis";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lstSubsLib;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMaxCompounds;
        private System.Windows.Forms.TextBox txtMaxCompounds;
        private System.Windows.Forms.Label lblMinCompounds;
        private System.Windows.Forms.TextBox txtMinCompounds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBrowseAssayResults;
        private System.Windows.Forms.ListBox lstAssayResults;
        private System.Windows.Forms.ToolStripMenuItem loadAnalysisFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ListView lvStatistics;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnViewFile;
        private System.Windows.Forms.ListBox lstAnalysisResults;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar pgAnalysis;
        private System.Windows.Forms.Button cmdApplyAllFilterRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExSDsBelow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbExSDsAbove;
        private System.Windows.Forms.Button btnPerformAnalysis;
        private System.Windows.Forms.Button btnStopAnalysis;
        private System.Windows.Forms.Label lblSubsProps;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblResultProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader statName;
        private System.Windows.Forms.Button cmdApplyFilterLib;
        private System.Windows.Forms.Button cmdApplyFilterRes;
        private System.Windows.Forms.Label lblFilteredResultProperties;
        private System.Windows.Forms.Label lblSubsFiltProps;
        private System.Windows.Forms.TextBox txtExLowCutoff;
        private System.Windows.Forms.TextBox txtExHighCutoff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExcludeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAnalysisProgress;
        private System.Windows.Forms.TextBox txtEntryName;
        private System.Windows.Forms.Label label10;
    }
}
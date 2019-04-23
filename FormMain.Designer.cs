namespace SEA
{
    partial class FormMain
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lstSubsLib = new System.Windows.Forms.ListBox();
            this.lblSubsLib = new System.Windows.Forms.Label();
            this.lblAssayResult = new System.Windows.Forms.Label();
            this.lstAssayResults = new System.Windows.Forms.ListBox();
            this.btnBrowseAssayResults = new System.Windows.Forms.Button();
            this.txtMinCompounds = new System.Windows.Forms.TextBox();
            this.lblMinCompounds = new System.Windows.Forms.Label();
            this.lblMaxCompounds = new System.Windows.Forms.Label();
            this.txtMaxCompounds = new System.Windows.Forms.TextBox();
            this.btnPerformAnalysis = new System.Windows.Forms.Button();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.lblViewResults = new System.Windows.Forms.Label();
            this.lstAnalysisResults = new System.Windows.Forms.ListBox();
            this.btnViewFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnSaveAllFiles = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNewAnalysis = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // lstSubsLib
            // 
            this.lstSubsLib.FormattingEnabled = true;
            this.lstSubsLib.Location = new System.Drawing.Point(20, 43);
            this.lstSubsLib.Name = "lstSubsLib";
            this.lstSubsLib.Size = new System.Drawing.Size(281, 160);
            this.lstSubsLib.TabIndex = 0;
            this.lstSubsLib.SelectedIndexChanged += new System.EventHandler(this.lstSubsLib_SelectedIndexChanged);
            // 
            // lblSubsLib
            // 
            this.lblSubsLib.AutoSize = true;
            this.lblSubsLib.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubsLib.Location = new System.Drawing.Point(17, 14);
            this.lblSubsLib.Name = "lblSubsLib";
            this.lblSubsLib.Size = new System.Drawing.Size(242, 16);
            this.lblSubsLib.TabIndex = 1;
            this.lblSubsLib.Text = "1.  Select one substructure library:";
            // 
            // lblAssayResult
            // 
            this.lblAssayResult.AutoSize = true;
            this.lblAssayResult.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssayResult.Location = new System.Drawing.Point(349, 14);
            this.lblAssayResult.Name = "lblAssayResult";
            this.lblAssayResult.Size = new System.Drawing.Size(307, 16);
            this.lblAssayResult.TabIndex = 3;
            this.lblAssayResult.Text = "2.  Browse for one or more assay result files:";
            // 
            // lstAssayResults
            // 
            this.lstAssayResults.FormattingEnabled = true;
            this.lstAssayResults.Location = new System.Drawing.Point(352, 43);
            this.lstAssayResults.Name = "lstAssayResults";
            this.lstAssayResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstAssayResults.Size = new System.Drawing.Size(290, 160);
            this.lstAssayResults.TabIndex = 2;
            // 
            // btnBrowseAssayResults
            // 
            this.btnBrowseAssayResults.Location = new System.Drawing.Point(352, 218);
            this.btnBrowseAssayResults.Name = "btnBrowseAssayResults";
            this.btnBrowseAssayResults.Size = new System.Drawing.Size(146, 24);
            this.btnBrowseAssayResults.TabIndex = 4;
            this.btnBrowseAssayResults.Text = "Browse...";
            this.btnBrowseAssayResults.UseVisualStyleBackColor = true;
            this.btnBrowseAssayResults.Click += new System.EventHandler(this.btnBrowseAssayResults_Click);
            // 
            // txtMinCompounds
            // 
            this.txtMinCompounds.Location = new System.Drawing.Point(20, 196);
            this.txtMinCompounds.Name = "txtMinCompounds";
            this.txtMinCompounds.Size = new System.Drawing.Size(58, 20);
            this.txtMinCompounds.TabIndex = 5;
            this.txtMinCompounds.Visible = false;
            // 
            // lblMinCompounds
            // 
            this.lblMinCompounds.AutoSize = true;
            this.lblMinCompounds.Location = new System.Drawing.Point(90, 199);
            this.lblMinCompounds.Name = "lblMinCompounds";
            this.lblMinCompounds.Size = new System.Drawing.Size(211, 13);
            this.lblMinCompounds.TabIndex = 6;
            this.lblMinCompounds.Text = "Minimum compounds per substructure entry";
            this.lblMinCompounds.Visible = false;
            // 
            // lblMaxCompounds
            // 
            this.lblMaxCompounds.AutoSize = true;
            this.lblMaxCompounds.Location = new System.Drawing.Point(90, 229);
            this.lblMaxCompounds.Name = "lblMaxCompounds";
            this.lblMaxCompounds.Size = new System.Drawing.Size(214, 13);
            this.lblMaxCompounds.TabIndex = 8;
            this.lblMaxCompounds.Text = "Maximum compounds per substructure entry";
            this.lblMaxCompounds.Visible = false;
            // 
            // txtMaxCompounds
            // 
            this.txtMaxCompounds.Location = new System.Drawing.Point(20, 226);
            this.txtMaxCompounds.Name = "txtMaxCompounds";
            this.txtMaxCompounds.Size = new System.Drawing.Size(58, 20);
            this.txtMaxCompounds.TabIndex = 7;
            this.txtMaxCompounds.Visible = false;
            // 
            // btnPerformAnalysis
            // 
            this.btnPerformAnalysis.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerformAnalysis.Location = new System.Drawing.Point(20, 281);
            this.btnPerformAnalysis.Name = "btnPerformAnalysis";
            this.btnPerformAnalysis.Size = new System.Drawing.Size(281, 24);
            this.btnPerformAnalysis.TabIndex = 10;
            this.btnPerformAnalysis.Text = "3.  Perform the analysis";
            this.btnPerformAnalysis.UseVisualStyleBackColor = true;
            this.btnPerformAnalysis.Click += new System.EventHandler(this.btnPerformAnalysis_Click);
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(352, 281);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(290, 23);
            this.prgBar.TabIndex = 11;
            // 
            // lblViewResults
            // 
            this.lblViewResults.AutoSize = true;
            this.lblViewResults.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewResults.Location = new System.Drawing.Point(17, 332);
            this.lblViewResults.Name = "lblViewResults";
            this.lblViewResults.Size = new System.Drawing.Size(239, 16);
            this.lblViewResults.TabIndex = 12;
            this.lblViewResults.Text = "4.  View and save analysis results:";
            // 
            // lstAnalysisResults
            // 
            this.lstAnalysisResults.FormattingEnabled = true;
            this.lstAnalysisResults.Location = new System.Drawing.Point(23, 365);
            this.lstAnalysisResults.Name = "lstAnalysisResults";
            this.lstAnalysisResults.Size = new System.Drawing.Size(281, 108);
            this.lstAnalysisResults.TabIndex = 13;
            // 
            // btnViewFile
            // 
            this.btnViewFile.Location = new System.Drawing.Point(352, 365);
            this.btnViewFile.Name = "btnViewFile";
            this.btnViewFile.Size = new System.Drawing.Size(146, 24);
            this.btnViewFile.TabIndex = 14;
            this.btnViewFile.Text = "View Selected File";
            this.btnViewFile.UseVisualStyleBackColor = true;
            this.btnViewFile.Click += new System.EventHandler(this.btnViewFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(352, 395);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(146, 24);
            this.btnSaveFile.TabIndex = 15;
            this.btnSaveFile.Text = "Save Selected File...";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnSaveAllFiles
            // 
            this.btnSaveAllFiles.Location = new System.Drawing.Point(352, 423);
            this.btnSaveAllFiles.Name = "btnSaveAllFiles";
            this.btnSaveAllFiles.Size = new System.Drawing.Size(146, 24);
            this.btnSaveAllFiles.TabIndex = 16;
            this.btnSaveAllFiles.Text = "Save All Files...";
            this.btnSaveAllFiles.UseVisualStyleBackColor = true;
            this.btnSaveAllFiles.Visible = false;
            this.btnSaveAllFiles.Click += new System.EventHandler(this.btnSaveAllFiles_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(538, 370);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(103, 102);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Text = "SEA Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNewAnalysis
            // 
            this.btnNewAnalysis.Location = new System.Drawing.Point(352, 453);
            this.btnNewAnalysis.Name = "btnNewAnalysis";
            this.btnNewAnalysis.Size = new System.Drawing.Size(146, 24);
            this.btnNewAnalysis.TabIndex = 18;
            this.btnNewAnalysis.Text = "New Analysis";
            this.btnNewAnalysis.UseVisualStyleBackColor = true;
            this.btnNewAnalysis.Click += new System.EventHandler(this.btnNewAnalysis_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 498);
            this.Controls.Add(this.btnNewAnalysis);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnSaveAllFiles);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnViewFile);
            this.Controls.Add(this.lstAnalysisResults);
            this.Controls.Add(this.lblViewResults);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.btnPerformAnalysis);
            this.Controls.Add(this.lblMaxCompounds);
            this.Controls.Add(this.txtMaxCompounds);
            this.Controls.Add(this.lblMinCompounds);
            this.Controls.Add(this.txtMinCompounds);
            this.Controls.Add(this.btnBrowseAssayResults);
            this.Controls.Add(this.lblAssayResult);
            this.Controls.Add(this.lstAssayResults);
            this.Controls.Add(this.lblSubsLib);
            this.Controls.Add(this.lstSubsLib);
            this.Name = "FormMain";
            this.Text = "SEA 0.85";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lstSubsLib;
        private System.Windows.Forms.Label lblSubsLib;
        private System.Windows.Forms.Label lblAssayResult;
        private System.Windows.Forms.ListBox lstAssayResults;
        private System.Windows.Forms.Button btnBrowseAssayResults;
        private System.Windows.Forms.TextBox txtMinCompounds;
        private System.Windows.Forms.Label lblMinCompounds;
        private System.Windows.Forms.Label lblMaxCompounds;
        private System.Windows.Forms.TextBox txtMaxCompounds;
        private System.Windows.Forms.Button btnPerformAnalysis;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Label lblViewResults;
        private System.Windows.Forms.ListBox lstAnalysisResults;
        private System.Windows.Forms.Button btnViewFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnSaveAllFiles;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnNewAnalysis;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


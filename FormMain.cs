using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SEA
{
    /// <summary>
    /// FormMain is the primary user interface for the SEA program
    /// </summary>
    public partial class FormMain : Form
    {
        // special directories which must be present
        string _appPath;
        string _subLibPath;
        string _outputPath;
        string _statisticsFile;
        string _functionsDir;
        static string OUTPUT_DIR = "Output";
        static string SUBSTRUCTURE_DIR = "Substructure Libraries";
        static string STATISTICS_DIR = "Statistics";
        static string STATISTICS_FILE = "statistics.txt";
        static string FUNCTIONS_DIR = "Functions";
        static string HELP_DIR = "Help";

        // member objects
        StatisticsCollection _stats;

        // GUI states - each state dims or undims a set of user widgets
        private const int STATE_START = 0;
        private const int STATE_SUB_FILE_SELECTED = 1;
        private const int STATE_RESULT_FILES_LOADED = 2;
        private const int STATE_ANALYSIS_RUNNING = 3;
        private const int STATE_ANALYSIS_DONE = 4;

        /// <summary>
        /// Constructor for the FormMain form
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            // set application paths
            _appPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            _subLibPath = _appPath + "\\" + SUBSTRUCTURE_DIR;
            _outputPath = _appPath + "\\" + OUTPUT_DIR;
            _statisticsFile = _appPath + "\\" + STATISTICS_DIR + "\\" + STATISTICS_FILE;
            _functionsDir = _appPath + "\\" + STATISTICS_DIR + "\\" + FUNCTIONS_DIR;

            // init controls
            lstSubsLib.DisplayMember = "NameNoExt";
            lstAssayResults.DisplayMember = "NameNoExt";
            lstAnalysisResults.DisplayMember = "NameNoExt";

            // fill substructure library listbox with list of available files
            DirectoryInfo di = new DirectoryInfo(_subLibPath);
            FileInfo[] rgFiles = di.GetFiles("*.txt");
            foreach (FileInfo fi in rgFiles)
            {
                lstSubsLib.Items.Add(new FileInfoExtended(fi));
            }

            _stats = new StatisticsCollection();

            SetGUIItems(STATE_START);
        }

        /// <summary>
        /// reset all GUI items to their start state
        /// </summary>
        private void SetGUIItemsStart()
        {
            lblSubsLib.Enabled = true;
            lstSubsLib.Enabled = true;

            txtMaxCompounds.Enabled = false;
            txtMinCompounds.Enabled = false;
            lblMinCompounds.Enabled = false;
            lblMaxCompounds.Enabled = false;

            lblAssayResult.Enabled = false;
            lstAssayResults.Enabled = false;
            btnBrowseAssayResults.Enabled = false;

            btnPerformAnalysis.Enabled = false;
            prgBar.Visible = false;

            lblViewResults.Enabled = false;
            lstAnalysisResults.Enabled = false;
            btnViewFile.Enabled = false;
            btnSaveFile.Enabled = false;
            btnSaveAllFiles.Enabled = false;

            btnNewAnalysis.Enabled = false;
        }

        /// <summary>
        /// Set the GUI items to a prescribed state
        /// </summary>
        /// <param name="state"></param>
        private void SetGUIItems(int state)
        {
            SetGUIItemsStart();
            switch (state)
            {
                case STATE_START:
                    break;
                case STATE_SUB_FILE_SELECTED:
                    txtMaxCompounds.Enabled = true;
                    txtMinCompounds.Enabled = true;
                    lblMinCompounds.Enabled = true;
                    lblMaxCompounds.Enabled = true;

                    lblAssayResult.Enabled = true;
                    lstAssayResults.Enabled = true;
                    btnBrowseAssayResults.Enabled = true;
                    break;

                case STATE_RESULT_FILES_LOADED:
                    SetGUIItems(STATE_SUB_FILE_SELECTED);
                    btnPerformAnalysis.Enabled = true;
                    prgBar.Visible = false;
                    break;
                case STATE_ANALYSIS_RUNNING:
                    SetGUIItems(STATE_RESULT_FILES_LOADED);
                    prgBar.Visible = true;
                    break;
                case STATE_ANALYSIS_DONE:

                    lblSubsLib.Enabled = false;
                    lstSubsLib.Enabled = false;

                    lblViewResults.Enabled = true;
                    lstAnalysisResults.Enabled = true;
                    btnViewFile.Enabled = true;
                    btnSaveFile.Enabled = true;
                    btnSaveAllFiles.Enabled = true;
                    btnNewAnalysis.Enabled = true;

                    break;
                default:
                    break;
            }
        }

        private void lstSubsLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if no items are currently selected, enable the next step.  Otherwise, do not do anything.
            if (lstAssayResults.Items.Count == 0)
            {
                SetGUIItems(STATE_SUB_FILE_SELECTED);
            }
        }

        /// <summary>
        /// Browse for assay result file(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseAssayResults_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            DialogResult dlgRes = openFileDialog1.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                lstAssayResults.Items.Clear();
                string[] files = openFileDialog1.FileNames;
                foreach (string file in files)
                {
                    lstAssayResults.Items.Add(new FileInfoExtended(file));
                }
                if (lstAssayResults.Items.Count > 0)
                {
                    SetGUIItems(STATE_RESULT_FILES_LOADED);
                }
            }           
        }

        /// <summary>
        /// Perform the analysis.  Many try-catch blocks provide error handling for each step of the process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPerformAnalysis_Click(object sender, EventArgs e)
        {
            // set this flag to false at any step to halt processing
            bool bContinue = true;
            this.Cursor = Cursors.WaitCursor;
            FileInfoExtended fi = (FileInfoExtended)lstSubsLib.SelectedItem;
            // init SubstructureLibrary
            SubstructureLibrary library = new SubstructureLibrary(fi.NameNoExt);
            try
            {
                library.LoadFromFile(fi.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the substructure library file: \r\n" + ex.Message + "\r\nThe file may not be in the correct format.");
                bContinue = false;
            }
            if (bContinue)
            {
                // read statistics from file
                // set up the StatisticsCollection and load from file
                try
                {
                    _stats.LoadFromFile(_statisticsFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while reading the statistics file: \r\n" + ex.Message + "\r\nThe file may not be in the correct format.");
                    bContinue = false;
                }

                if (bContinue)
                {
                    // init all Assay Results
                    Hashtable hsResults = new Hashtable();
                    try
                    {
                        foreach (FileInfoExtended item in lstAssayResults.Items)
                        {
                            hsResults.Add(item.NameNoExt, new AssayResults(item.NameNoExt, item.FullName));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while opening the assay result files: \r\n" + ex.Message + "\r\nThe file(s) may not have the correct format.");
                        bContinue = false;
                    }
                    // init analysis and run
                    if (bContinue)
                    {
                        try
                        {
                            SEAAnalysis analysis = new SEAAnalysis(library, hsResults, _stats, _functionsDir);
                            analysis.Run();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while running the analysis: \r\n" + ex.Message + "\r\nMake sure that R and the R DCOM connector are installed.");
                            bContinue = false;
                        }
                        if (bContinue)
                        {
                            // output library data
                            try
                            {
                                library.WriteAllAssayAnalysisFiles(_outputPath);
                                library.WriteSummaryFile(_outputPath + "\\Analysis Summary.txt");
                                // fill lstbox with analysis result files
                                lstAnalysisResults.Items.Add(new FileInfoExtended(_outputPath + "\\Analysis Summary.txt"));
                                foreach (string assayName in hsResults.Keys)
                                {
                                    lstAnalysisResults.Items.Add(new FileInfoExtended(_outputPath + "\\" + assayName + ".txt"));
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Sorry, an error occurred while writing the analysis files to disk.  This usually means you have some of these files open in Excel.  Close the analysis files, then try running the analysis again.");
                            }
                            SetGUIItems(STATE_ANALYSIS_DONE);
                        }  // bcontinue
                    }  // bcontinue
                }  // bcontinue
            } // bcontinue
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// View the selected item in a viewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewFile_Click(object sender, EventArgs e)
        {
            if (lstAnalysisResults.SelectedItem != null)
            {
                try
                {
                    System.Diagnostics.Process.Start("excel.exe", "\"" + ((FileInfoExtended)lstAnalysisResults.SelectedItem).FullName + "\"");
                }
                catch (Exception ex)
                    // fall back if Excel is not installed
                {
                    System.Diagnostics.Process.Start("\"" + ((FileInfoExtended)lstAnalysisResults.SelectedItem).FullName + "\"");
                }
            }
        }

        private void btnNewAnalysis_Click(object sender, EventArgs e)
        {
            // ask the user if they want to start a new analysis, then clear out the form for the next analysis
            DialogResult dr = MessageBox.Show("Press OK to clear the results of this analysis and begin a new one.", "Confirm New Analysis", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                // clear analysis files and set GUI back to a starting state
                lstAnalysisResults.Items.Clear();
                SetGUIItems(STATE_RESULT_FILES_LOADED);
            }
        }

        /// <summary>
        /// Save the selected file to a user-defined location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (lstAnalysisResults.SelectedItem != null)
            {
                FileInfoExtended fi = (FileInfoExtended)lstAnalysisResults.SelectedItem;
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog1.FileName = fi.Name;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    File.Copy(fi.FullName, saveFileDialog1.FileName);
                }
            }
        }

        /// <summary>
        /// Save all files to a defined location - not yet implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAllFiles_Click(object sender, EventArgs e)
        {
            foreach(FileInfoExtended fi in lstAnalysisResults.Items) 
            {

            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // simply open the help page in a browser
            System.Diagnostics.Process.Start("\"" + _appPath + "\\" + HELP_DIR + "\\help.htm" + "\"");
        }
    }
}
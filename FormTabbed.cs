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
    public partial class FormTabbed : Form
    {
        private SEAEnvironment _env;
        // set to true if the user presses the cancel button, and picked up by the 
        // analysis loop
        private bool _cancelAnalysis;

        public FormTabbed()
        {
            InitializeComponent();
            _env = new SEAEnvironment();

            // init controls
            lstSubsLib.DisplayMember = "NameNoExt";
            lstAssayResults.DisplayMember = "NameNoExt";
            lstAnalysisResults.DisplayMember = "NameNoExt";

            // fill substructure library listbox with list of available files
            DirectoryInfo di = new DirectoryInfo(_env.subLibPath);
            FileInfo[] rgFiles = di.GetFiles("*.*");
            foreach (FileInfo fi in rgFiles)
            {
                lstSubsLib.Items.Add(new FileInfoExtended(fi));
            }

            // fill statistics box with list of statistics
            try
            {
                _env.ReloadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the statistics file: \r\n" + ex.Message + "\r\nThe file may not be in the correct format.");
            }

            foreach (StatisticsEntry ent in _env.stats.Entries)
            {
                lvStatistics.Items.Add(new ListViewItem(ent.Name));
                lvStatistics.Items[lvStatistics.Items.Count - 1].Checked = ent.Perform;
            }
            lvStatistics.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        /// <summary>
        /// Display information about the current substructure library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubsLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           //try
           // {
                _env.subsLib.LoadFromFile(((FileInfoExtended)lstSubsLib.SelectedItem).FullName);
                lblSubsProps.Text = _env.subsLib.propertyString;
                lblSubsFiltProps.Text = "No filter.";
          //  }
           // catch (Exception ex)
            //{
           //     MessageBox.Show("An error occurred while processing the substructure library file: \r\n" + ex.Message + "\r\nThe file may not be in the correct format.");
           // }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Browse for assay results and then return the files.  The Assay results will be loaded on open
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
                // load files into Assay Result files
                this.Cursor = Cursors.WaitCursor;
                // init all Assay Results
                Hashtable hs = _env.AssayResultsHash;
                hs.Clear();
                foreach (string file in files)
                {
                    FileInfoExtended item = new FileInfoExtended(file);
                    try
                    {
                        hs.Add(item.NameNoExt, new AssayResults(item.NameNoExt, item.FullName));
                        lstAssayResults.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not load the file: \r\n" + item.FullName + "\r\n" + ex.Message + "\r\nThe files may not have the correct format.  Help->Contents for more information.");
                    }
 
                }
                this.Cursor = Cursors.Default;
            }           
        }

        /// <summary>
        /// Perform the analysis.  Many try-catch blocks provide error handling for each step of the process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPerformAnalysis_Click(object sender, EventArgs e)
        {
            // reset GUI elements
            pgAnalysis.Value = 0;
            lstAnalysisResults.Items.Clear();
            // TODO - check to see if files are open so we don't get all the way through an analysis and then
            // find we can't open the file

            // TODO - all of this exception checking should be done in the SEAEnvironment class
            // set this flag to false at any step to halt processing
            bool bContinue = true;
            this.Cursor = Cursors.WaitCursor;
            FileInfoExtended fi = (FileInfoExtended)lstSubsLib.SelectedItem;
            // init SubstructureLibrary
            SubstructureLibrary library = _env.subsLib.FilteredLibrary;
            if (bContinue)
            {
                // set status of statistics based on checked/unchecked
                foreach(ListViewItem li in lvStatistics.Items) {
                    _env.stats.Item(li.Text).Perform = li.Checked;
                }
                try
                {
                    lblAnalysisProgress.Text = "Preparing analysis...";
                    Application.DoEvents();
                    _env.PrepAnalysisInteractive();
                    _cancelAnalysis = false;
                    lblAnalysisProgress.Text = "Running analysis...";
                    // call the runinteractive method repeatedly to update the progress bar
                    int i = 0;
                    while(i != -1) {
                        Application.DoEvents();
                        pgAnalysis.Value = i > pgAnalysis.Maximum ? pgAnalysis.Maximum : i;
                        Application.DoEvents();
                        if (!_cancelAnalysis)
                        {
                            i = _env.RunAnalysisInteractive();
                            // don't know if this is strictly necessary to let the form
                            // process a press of the Cancel button
                            System.Windows.Forms.Application.DoEvents();
                        } else {
                            // cancelled
                            i = -1;
                            lblAnalysisProgress.Text = "Analysis cancelled.";
                            pgAnalysis.Value = 0;
                            bContinue = false;
                        }
                    }
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
                        lblAnalysisProgress.Text = "Writing files...";
                        Application.DoEvents();
                        library.WriteAllAssayAnalysisFiles(_env.OutputPath);
                        library.WriteSummaryFile(_env.OutputPath + "\\Analysis Summary.txt");
                        // fill lstbox with analysis result files
                        lstAnalysisResults.Items.Add(new FileInfoExtended(_env.OutputPath + "\\Analysis Summary.txt"));
                        foreach (string assayName in _env.AssayResultsHash.Keys)
                        {
                            lstAnalysisResults.Items.Add(new FileInfoExtended(_env.OutputPath + "\\" + assayName + ".txt"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sorry, an error occurred while writing the analysis files to disk.  This usually means you have some of these files open in Excel.  Close the analysis files, then try running the analysis again.");
                    }
                }  // bcontinue
            }  // bcontinue
            lblAnalysisProgress.Text = bContinue ? "Analysis complete." : "Analysis cancelled.";
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

        private void btnStopAnalysis_Click(object sender, EventArgs e)
        {
            _cancelAnalysis = true;
        }

        /// <summary>
        /// When the selected index is changed, load the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAssayResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssayResults ar = SelectedAssayResult();
            // set the property string
            lblResultProperties.Text = ar.propertyString + "\r\nLibrary Coverage: " + ar.Coverage(_env.subsLib.FilteredLibrary);
            if (ar.FilteredResults != ar) {
                lblFilteredResultProperties.Text = ar.FilteredResults.propertyString + "\r\nLibrary Coverage: " + ar.FilteredResults.Coverage(_env.subsLib);
                // set filter
                AssayResultsFilter arf = ar.Filter;
                txtExcludeText.Text = arf.ExcludeString;
                txtExHighCutoff.Text = arf.HighCutoff == arf.DEFAULT_CUTOFF ? "" : arf.HighCutoff.ToString();
                txtExLowCutoff.Text = arf.LowCutoff == -arf.DEFAULT_CUTOFF ? "" : arf.LowCutoff.ToString();
                cmbExSDsAbove.SelectedText = arf.HighSDCutoff == arf.DEFAULT_CUTOFF ? "" : arf.HighSDCutoff.ToString();
                cmbExSDsBelow.Text = arf.LowSDCutoff == arf.DEFAULT_CUTOFF ? "" : arf.LowSDCutoff.ToString();
            } else {
                lblFilteredResultProperties.Text = "No filter.";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abt = new AboutBox1();
            abt.ShowDialog();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // simply open the help page in a browser
            System.Diagnostics.Process.Start("\"" +  _env.helpPath + "\\help.htm" + "\"");
        }

        private void cmdApplyFilterLib_Click(object sender, EventArgs e)
        {
            SubstructureLibraryFilter filt = new SubstructureLibraryFilter();
            if (txtMaxCompounds.Text != "") filt.MaxCompounds = Convert.ToInt32(txtMaxCompounds.Text);
            if (txtMinCompounds.Text != "") filt.MinCompounds = Convert.ToInt32(txtMinCompounds.Text);
            filt.EntryName = txtEntryName.Text;
            _env.ApplySubstructureLibraryFilter(filt);
            lblSubsFiltProps.Text = _env.subsLib.FilteredLibrary.propertyString;
        }

        /// <summary>
        /// Apply the filter to the selected result set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdApplyFilterRes_Click(object sender, EventArgs e)
        {
            AssayResults ar = SelectedAssayResult();
            if (SelectedAssayResult() != null)
            {
                AssayResultsFilter arf = new AssayResultsFilter();
                // TODO implement checking of box values
                try
                {
                    if (txtExcludeText.Text != "") arf.ExcludeString = txtExcludeText.Text;
                    if (txtExHighCutoff.Text != "") arf.HighCutoff = Convert.ToInt32(txtExHighCutoff.Text);
                    if (txtExLowCutoff.Text != "") arf.LowCutoff = Convert.ToInt32(txtExLowCutoff.Text);
                    if (cmbExSDsBelow.SelectedItem !=null) if (cmbExSDsBelow.SelectedItem.ToString() != "") arf.LowSDCutoff = Convert.ToInt32(cmbExSDsBelow.SelectedItem.ToString());
                    if (cmbExSDsAbove.SelectedItem != null) if (cmbExSDsAbove.SelectedItem.ToString() != "") arf.HighSDCutoff = Convert.ToInt32(cmbExSDsAbove.SelectedItem.ToString());
                    ar.ApplyFilter(arf);
                    lblFilteredResultProperties.Text = ar.FilteredResults.propertyString + "\r\nLibrary Coverage: " + ar.FilteredResults.Coverage(_env.subsLib.FilteredLibrary);
                } catch (Exception ex) {
                    MessageBox.Show("One or more filter parameters was not in the correct format.");
                }
            }                
        }

        private AssayResults SelectedAssayResult() {
            // convenience function to return the currently selected AssayResult
            AssayResults ret = null;
            if (lstAssayResults.SelectedItem != null) {
                ret = _env.AssayResultsItem(((FileInfoExtended)lstAssayResults.SelectedItem).NameNoExt);
            }
            return ret;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
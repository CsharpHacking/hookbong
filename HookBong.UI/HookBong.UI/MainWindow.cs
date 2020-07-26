using HookBong.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HookBong.UI
{
    public partial class MainWindow : Form
    {
        public List<Process> Processes;

        public MainWindow()
        {
            InitializeComponent();

            Processes = Process.GetProcesses().ToList();
            foreach (var process in Processes)
                processList.Items.Add($"{process.ProcessName} [{process.Id}]");
        }

        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {
            analyzeButton.Enabled = true;
            currentProcessLabel.Text = $"Current Process: {((ListBox)sender).SelectedItem}";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Processes = Process.GetProcesses().ToList();
            processList.Items.Clear();

            foreach (var process in Processes)
                processList.Items.Add($"{process.ProcessName} [{process.Id}]");
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            analysisGrid.Rows.Clear();
            var targetProcess = Processes[processList.SelectedIndex];
            var analysisEngine = new ProcessAnalyzer(targetProcess);
            foreach (var entry in analysisEngine.AnalyzeFull())
                analysisGrid.Rows.Add(entry.Location, entry.ModuleName, entry.Type, entry.OriginalData, entry.PatchedData, entry.AdditionalInfo);
        }

        private void Searchbox_textChanged(object sender, EventArgs e)
        {
            Processes = Process.GetProcesses().Where(p => p.ProcessName.IndexOf(SearchBox.Text,StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            processList.Items.Clear();
            foreach (var process in Processes)
                processList.Items.Add($"{process.ProcessName} [{process.Id}]");
        }
    }
}

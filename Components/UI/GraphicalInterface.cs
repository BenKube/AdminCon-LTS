using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AdminCon_CLI_dotnetEdition.Components.Command;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Global;
using AdminCon_CLI_dotnetEdition.Components.Processes;
using AdminCon_CLI_dotnetEdition.Components.Sound;
using AdminCon_CLI_dotnetEdition.Components.SystemUtils;
using Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security;

using Microsoft.VisualBasic.Devices;
/* AdminCon 8.0 Command Line Interface Edition - Source Code - GraphicalInterface.cs
 * Intro: The graphical interface.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.UI
{
    /// <summary>
    /// The graphical interface.
    /// </summary>
    public partial class GraphicalInterface : Form
    {
        private Daemon PerfMon;
        private List<Process> ProcessResultList;
        private readonly ProcessAlgorithms ProcessAlgorithms = new ProcessAlgorithms();
        public GraphicalInterface()
        {
            InitializeComponent();
        }
        private void GUI_Load(Object sender, EventArgs e)
        {
            this.PerfMon = Daemon.GetInstance();
            this.ProcessResultList = new List<Process>(Process.GetProcesses());
            this.searchProcessTextBox.Text = "Search Process:";
            AutoResizeColumns(this.dataGridView);

            //Performance Test: NOT_PASSED, requires further invetigation.
            //this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            RefreshData();
            this.timeTicker.Start();
        }

        private void RefreshData()
        {
            this.dataGridView.Rows.Clear();
            foreach (Process process in ProcessResultList)
            {
                Int32 index = this.dataGridView.Rows.Add();
                try
                {
                    this.dataGridView.Rows[index].Cells[0].Value = process.Id;
                    this.dataGridView.Rows[index].Cells[1].Value = process.ProcessName;
                    this.dataGridView.Rows[index].Cells[2].Value = ProcessAlgorithms.GetProcessLocation(process);
                    this.dataGridView.Rows[index].Cells[3].Value = Math.Round((ProcessAlgorithms.GetProcessMemoryUsage(process.Id) / 1024), 1);
                    this.dataGridView.Rows[index].Cells[4].Value = ProcessAlgorithms.GetProcessHostUserName(process.Id);
                }
                catch (Exception)
                {
                    index--;
                    continue;
                }
            }
        }
        private void searchProcessTextBox_Enter(Object sender, EventArgs e)
        {
            this.searchProcessTextBox.ForeColor = Color.Black;
            this.searchProcessTextBox.Text = String.Empty;
        }

        private void searchProcessTextBox_Leave(Object sender, EventArgs e)
        {
            this.searchProcessTextBox.ForeColor = Color.DimGray;
        }

        //Update dgview in another thread
        public delegate void DGViewRefreshDelegate();
        public delegate void DGViewSearchDelegate();
        DGViewRefreshDelegate DGViewUpdate_RefreshButton;
        DGViewSearchDelegate DGViewUpdate_SearchButton;
        public void DGVUpdate_Search()
        {
            this.DGViewUpdate_SearchButton = new DGViewSearchDelegate(RefreshData);
        }
        public void DGVUpdate_Refresh()
        {
            this.DGViewUpdate_RefreshButton = new DGViewRefreshDelegate(RefreshData);
        }

        private void UsageBarUpdate()
        {
            this.ramUsageTargetLabel.Text = "" + ((new ComputerInfo().TotalPhysicalMemory / 1048576)) + "MB";
            Double cpuUsageInPercentage = Math.Round(PerfMon.CPU_Usage, 2);
            Double ramUsageInPercentage = Math.Round((PerfMon.Memory_Usage / (new ComputerInfo().TotalPhysicalMemory / 1024) * 100), 2);
            StringBuilder cpuUsageDisplayBuilder = new StringBuilder();
            StringBuilder ramUsageDisplayBuilder = new StringBuilder();
            for (Int32 i = 0; i < (Int32)cpuUsageInPercentage; i++)
            {
                cpuUsageDisplayBuilder.Append('▉');
            }
            for (Int32 i = 0; i < (Int32)ramUsageInPercentage; i++)
            {
                ramUsageDisplayBuilder.Append('▉');
            }

            //▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉ 100%
            this.cpuUsageBar.Text = cpuUsageDisplayBuilder.ToString() + ' ' + cpuUsageInPercentage + '%';
            if (ramUsageInPercentage < 0.1 || ramUsageInPercentage > 100)
            {
                this.ramUsageBar.Text = "Waiting for Analyzing...";
            }
            else this.ramUsageBar.Text = ramUsageDisplayBuilder.ToString() + ' ' + ramUsageInPercentage + $"% - {(Int32)(PerfMon.Memory_Usage / 1024)}MB";
        }
        private void timeTicker_Tick(Object sender, EventArgs e)
        {
            UsageBarUpdate();
        }
        private void AutoResizeColumns(DataGridView dgView)
        {
            Int32 width = 0;
            for(int  i = 0; i < dgView.Columns.Count;i++)
            {
                dgView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                width += dgView.Columns[i].Width;
            }
            if(width > dgView.Size.Width)
            {
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            dgView.Columns[1].Frozen = true;
        }

        private void searchButton_Click(Object sender, EventArgs e)
        {
            this.stateLabel.Text = "Complete";
            this.ProcessResultList.Clear();
            Process[] allProcesses = Process.GetProcesses();
            for (Int32 i = 0; i < allProcesses.Length; i++)
            {
                try
                {
                    if (allProcesses[i].ProcessName.ToUpper().Contains(this.searchProcessTextBox.Text.ToUpper()) ||
                        allProcesses[i].ProcessName.ToUpper().Equals(this.searchProcessTextBox.Text.ToUpper()) ||
                        allProcesses[i].MainModule.FileName.ToUpper().Contains(this.searchProcessTextBox.Text.ToUpper()) ||
                        allProcesses[i].MainModule.FileName.ToUpper().Equals(this.searchProcessTextBox.Text.ToUpper()) ||
                        ProcessAlgorithms.GetProcessHostUserName(allProcesses[i].Id).ToUpper().Contains(this.searchProcessTextBox.Text.ToUpper()) ||
                        ProcessAlgorithms.GetProcessHostUserName(allProcesses[i].Id).ToUpper().Equals(this.searchProcessTextBox.Text.ToUpper()))
                    {
                        this.ProcessResultList.Add(allProcesses[i]);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            this.RefreshData();
            Console.Beep(1000, 500); Console.Beep(1000, 500);
        }

        private void refreshdgViewButton_Click(Object sender, EventArgs e)
        {
            this.stateLabel.Text = "Refreshed.";
            this.ProcessResultList = new List<Process>(Process.GetProcesses());
            this.RefreshData();
            Console.Beep(1000, 500); Console.Beep(1000, 500);
        }

        private Boolean FullScreen = false;
        private void fullScreenPictureBox_Click(Object sender, EventArgs e)
        {
            if (!FullScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
            this.FullScreen = !FullScreen;
        }
    }
}
//Program Entry @ Program.cs
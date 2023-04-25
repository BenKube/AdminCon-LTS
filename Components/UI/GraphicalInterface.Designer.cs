/* AdminCon 8.0 Command Line Interface Edition - Source Code - GraphicalInterface.Designer.cs
 * Intro: Winform designer
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
using System;

namespace AdminCon_CLI_dotnetEdition.Components.UI
{
    partial class GraphicalInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(Boolean disposing)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicalInterface));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchProcessTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.timeTicker = new System.Windows.Forms.Timer(this.components);
            this.cpuUsageLabel = new System.Windows.Forms.Label();
            this.ramUsageLabel = new System.Windows.Forms.Label();
            this.cpuUsageBar = new System.Windows.Forms.TextBox();
            this.ramUsageBar = new System.Windows.Forms.TextBox();
            this.cpuUsageTargetLabel = new System.Windows.Forms.Label();
            this.ramUsageTargetLabel = new System.Windows.Forms.Label();
            this.refreshdgViewButton = new System.Windows.Forms.Button();
            this.stateLabel = new System.Windows.Forms.Label();
            this.fullScreenPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullScreenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeight = 29;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pName,
            this.path,
            this.memUsage,
            this.userName});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1147, 326);
            this.dataGridView.TabIndex = 0;
            // 
            // pid
            // 
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            this.pid.DefaultCellStyle = dataGridViewCellStyle16;
            this.pid.HeaderText = "PID";
            this.pid.MinimumWidth = 6;
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Width = 125;
            // 
            // pName
            // 
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            this.pName.DefaultCellStyle = dataGridViewCellStyle17;
            this.pName.HeaderText = "PNAME";
            this.pName.MinimumWidth = 6;
            this.pName.Name = "pName";
            this.pName.ReadOnly = true;
            this.pName.Width = 125;
            // 
            // path
            // 
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Lime;
            this.path.DefaultCellStyle = dataGridViewCellStyle18;
            this.path.HeaderText = "PATH";
            this.path.MinimumWidth = 6;
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Width = 125;
            // 
            // memUsage
            // 
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Yellow;
            this.memUsage.DefaultCellStyle = dataGridViewCellStyle19;
            this.memUsage.HeaderText = "Memory Usage(MB)";
            this.memUsage.MinimumWidth = 6;
            this.memUsage.Name = "memUsage";
            this.memUsage.ReadOnly = true;
            this.memUsage.Width = 125;
            // 
            // userName
            // 
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.userName.DefaultCellStyle = dataGridViewCellStyle20;
            this.userName.HeaderText = "User Name";
            this.userName.MinimumWidth = 6;
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Width = 125;
            // 
            // searchProcessTextBox
            // 
            this.searchProcessTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchProcessTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchProcessTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchProcessTextBox.Location = new System.Drawing.Point(921, 345);
            this.searchProcessTextBox.Name = "searchProcessTextBox";
            this.searchProcessTextBox.Size = new System.Drawing.Size(238, 22);
            this.searchProcessTextBox.TabIndex = 2;
            this.searchProcessTextBox.Text = "Search Process:";
            this.searchProcessTextBox.Enter += new System.EventHandler(this.searchProcessTextBox_Enter);
            this.searchProcessTextBox.Leave += new System.EventHandler(this.searchProcessTextBox_Leave);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchButton.Location = new System.Drawing.Point(840, 344);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // timeTicker
            // 
            this.timeTicker.Interval = 1000;
            this.timeTicker.Tick += new System.EventHandler(this.timeTicker_Tick);
            // 
            // cpuUsageLabel
            // 
            this.cpuUsageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cpuUsageLabel.AutoSize = true;
            this.cpuUsageLabel.BackColor = System.Drawing.Color.Transparent;
            this.cpuUsageLabel.ForeColor = System.Drawing.Color.Cyan;
            this.cpuUsageLabel.Location = new System.Drawing.Point(12, 416);
            this.cpuUsageLabel.Name = "cpuUsageLabel";
            this.cpuUsageLabel.Size = new System.Drawing.Size(82, 16);
            this.cpuUsageLabel.TabIndex = 5;
            this.cpuUsageLabel.Text = "CPU Usage:";
            // 
            // ramUsageLabel
            // 
            this.ramUsageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ramUsageLabel.AutoSize = true;
            this.ramUsageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ramUsageLabel.ForeColor = System.Drawing.Color.Lime;
            this.ramUsageLabel.Location = new System.Drawing.Point(12, 465);
            this.ramUsageLabel.Name = "ramUsageLabel";
            this.ramUsageLabel.Size = new System.Drawing.Size(84, 16);
            this.ramUsageLabel.TabIndex = 6;
            this.ramUsageLabel.Text = "RAM Usage:";
            // 
            // cpuUsageBar
            // 
            this.cpuUsageBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cpuUsageBar.BackColor = System.Drawing.Color.Silver;
            this.cpuUsageBar.ForeColor = System.Drawing.Color.Blue;
            this.cpuUsageBar.Location = new System.Drawing.Point(100, 416);
            this.cpuUsageBar.Name = "cpuUsageBar";
            this.cpuUsageBar.ReadOnly = true;
            this.cpuUsageBar.Size = new System.Drawing.Size(766, 22);
            this.cpuUsageBar.TabIndex = 7;
            // 
            // ramUsageBar
            // 
            this.ramUsageBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ramUsageBar.BackColor = System.Drawing.Color.Silver;
            this.ramUsageBar.ForeColor = System.Drawing.Color.Green;
            this.ramUsageBar.Location = new System.Drawing.Point(100, 465);
            this.ramUsageBar.Name = "ramUsageBar";
            this.ramUsageBar.ReadOnly = true;
            this.ramUsageBar.Size = new System.Drawing.Size(766, 22);
            this.ramUsageBar.TabIndex = 8;
            // 
            // cpuUsageTargetLabel
            // 
            this.cpuUsageTargetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cpuUsageTargetLabel.AutoSize = true;
            this.cpuUsageTargetLabel.BackColor = System.Drawing.Color.Transparent;
            this.cpuUsageTargetLabel.ForeColor = System.Drawing.Color.Cyan;
            this.cpuUsageTargetLabel.Location = new System.Drawing.Point(870, 421);
            this.cpuUsageTargetLabel.Name = "cpuUsageTargetLabel";
            this.cpuUsageTargetLabel.Size = new System.Drawing.Size(40, 16);
            this.cpuUsageTargetLabel.TabIndex = 9;
            this.cpuUsageTargetLabel.Text = "100%";
            // 
            // ramUsageTargetLabel
            // 
            this.ramUsageTargetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ramUsageTargetLabel.AutoSize = true;
            this.ramUsageTargetLabel.BackColor = System.Drawing.Color.Transparent;
            this.ramUsageTargetLabel.ForeColor = System.Drawing.Color.Lime;
            this.ramUsageTargetLabel.Location = new System.Drawing.Point(870, 471);
            this.ramUsageTargetLabel.Name = "ramUsageTargetLabel";
            this.ramUsageTargetLabel.Size = new System.Drawing.Size(19, 16);
            this.ramUsageTargetLabel.TabIndex = 10;
            this.ramUsageTargetLabel.Text = "---";
            // 
            // refreshdgViewButton
            // 
            this.refreshdgViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshdgViewButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.refreshdgViewButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.refreshdgViewButton.Location = new System.Drawing.Point(759, 345);
            this.refreshdgViewButton.Name = "refreshdgViewButton";
            this.refreshdgViewButton.Size = new System.Drawing.Size(75, 23);
            this.refreshdgViewButton.TabIndex = 11;
            this.refreshdgViewButton.Text = "Refresh";
            this.refreshdgViewButton.UseVisualStyleBackColor = false;
            this.refreshdgViewButton.Click += new System.EventHandler(this.refreshdgViewButton_Click);
            // 
            // stateLabel
            // 
            this.stateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.stateLabel.Location = new System.Drawing.Point(15, 346);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 25);
            this.stateLabel.TabIndex = 13;
            // 
            // fullScreenPictureBox
            // 
            this.fullScreenPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fullScreenPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("fullScreenPictureBox.Image")));
            this.fullScreenPictureBox.Location = new System.Drawing.Point(1144, 506);
            this.fullScreenPictureBox.Name = "fullScreenPictureBox";
            this.fullScreenPictureBox.Size = new System.Drawing.Size(25, 25);
            this.fullScreenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fullScreenPictureBox.TabIndex = 12;
            this.fullScreenPictureBox.TabStop = false;
            this.fullScreenPictureBox.Click += new System.EventHandler(this.fullScreenPictureBox_Click);
            // 
            // GraphicalInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1171, 532);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.fullScreenPictureBox);
            this.Controls.Add(this.refreshdgViewButton);
            this.Controls.Add(this.ramUsageTargetLabel);
            this.Controls.Add(this.cpuUsageTargetLabel);
            this.Controls.Add(this.ramUsageBar);
            this.Controls.Add(this.cpuUsageBar);
            this.Controls.Add(this.ramUsageLabel);
            this.Controls.Add(this.cpuUsageLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchProcessTextBox);
            this.Controls.Add(this.dataGridView);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphicalInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminCon - Graphical Interface";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullScreenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox searchProcessTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Timer timeTicker;
        private System.Windows.Forms.Label cpuUsageLabel;
        private System.Windows.Forms.Label ramUsageLabel;
        private System.Windows.Forms.TextBox cpuUsageBar;
        private System.Windows.Forms.TextBox ramUsageBar;
        private System.Windows.Forms.Label cpuUsageTargetLabel;
        private System.Windows.Forms.Label ramUsageTargetLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn memUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.Button refreshdgViewButton;
        private System.Windows.Forms.PictureBox fullScreenPictureBox;
        private System.Windows.Forms.Label stateLabel;
    }
}
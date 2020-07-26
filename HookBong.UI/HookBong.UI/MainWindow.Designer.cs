namespace HookBong.UI
{
    partial class MainWindow
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
            System.Windows.Forms.Label processListLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.processList = new System.Windows.Forms.ListBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.analysisGrid = new System.Windows.Forms.DataGridView();
            this.currentProcessLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.VirtualAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HookType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatchedData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            processListLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.analysisGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // processListLabel
            // 
            processListLabel.AutoSize = true;
            processListLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            processListLabel.Location = new System.Drawing.Point(46, 9);
            processListLabel.Name = "processListLabel";
            processListLabel.Size = new System.Drawing.Size(122, 26);
            processListLabel.TabIndex = 1;
            processListLabel.Text = "Process List";
            // 
            // processList
            // 
            this.processList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.processList.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processList.FormattingEnabled = true;
            this.processList.HorizontalScrollbar = true;
            this.processList.ItemHeight = 20;
            this.processList.Location = new System.Drawing.Point(13, 70);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(218, 424);
            this.processList.TabIndex = 0;
            this.processList.SelectedIndexChanged += new System.EventHandler(this.processList_SelectedIndexChanged);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.analyzeButton.Enabled = false;
            this.analyzeButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzeButton.Location = new System.Drawing.Point(12, 497);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(219, 51);
            this.analyzeButton.TabIndex = 2;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // analysisGrid
            // 
            this.analysisGrid.AllowUserToAddRows = false;
            this.analysisGrid.AllowUserToDeleteRows = false;
            this.analysisGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.analysisGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VirtualAddress,
            this.ModuleName,
            this.HookType,
            this.OriginalData,
            this.PatchedData,
            this.AdditionalInfo});
            this.analysisGrid.Location = new System.Drawing.Point(237, 44);
            this.analysisGrid.Name = "analysisGrid";
            this.analysisGrid.ReadOnly = true;
            this.analysisGrid.Size = new System.Drawing.Size(799, 561);
            this.analysisGrid.TabIndex = 3;
            // 
            // currentProcessLabel
            // 
            this.currentProcessLabel.AutoSize = true;
            this.currentProcessLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentProcessLabel.Location = new System.Drawing.Point(233, 12);
            this.currentProcessLabel.Name = "currentProcessLabel";
            this.currentProcessLabel.Size = new System.Drawing.Size(192, 22);
            this.currentProcessLabel.TabIndex = 4;
            this.currentProcessLabel.Text = "Current Process: None";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(12, 554);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(219, 51);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBox.Location = new System.Drawing.Point(13, 44);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(218, 20);
            this.SearchBox.TabIndex = 6;
            this.SearchBox.TextChanged += new System.EventHandler(this.Searchbox_textChanged);
            // 
            // VirtualAddress
            // 
            this.VirtualAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VirtualAddress.DefaultCellStyle = dataGridViewCellStyle1;
            this.VirtualAddress.HeaderText = "Virtual Address";
            this.VirtualAddress.Name = "VirtualAddress";
            this.VirtualAddress.ReadOnly = true;
            this.VirtualAddress.Width = 102;
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ModuleName.HeaderText = "Module Name";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.ReadOnly = true;
            this.ModuleName.Width = 98;
            // 
            // HookType
            // 
            this.HookType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HookType.DefaultCellStyle = dataGridViewCellStyle3;
            this.HookType.HeaderText = "HookType";
            this.HookType.Name = "HookType";
            this.HookType.ReadOnly = true;
            this.HookType.Width = 82;
            // 
            // OriginalData
            // 
            this.OriginalData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalData.DefaultCellStyle = dataGridViewCellStyle4;
            this.OriginalData.HeaderText = "Original Data";
            this.OriginalData.Name = "OriginalData";
            this.OriginalData.ReadOnly = true;
            // 
            // PatchedData
            // 
            this.PatchedData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchedData.DefaultCellStyle = dataGridViewCellStyle5;
            this.PatchedData.HeaderText = "Patched Data";
            this.PatchedData.Name = "PatchedData";
            this.PatchedData.ReadOnly = true;
            // 
            // AdditionalInfo
            // 
            this.AdditionalInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdditionalInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.AdditionalInfo.HeaderText = "Additional Information";
            this.AdditionalInfo.Name = "AdditionalInfo";
            this.AdditionalInfo.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 617);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.currentProcessLabel);
            this.Controls.Add(this.analysisGrid);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(processListLabel);
            this.Controls.Add(this.processList);
            this.Name = "MainWindow";
            this.Text = "HookBong";
            ((System.ComponentModel.ISupportInitialize)(this.analysisGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox processList;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.DataGridView analysisGrid;
        private System.Windows.Forms.Label currentProcessLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn VirtualAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HookType;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatchedData;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalInfo;
    }
}
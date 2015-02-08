namespace Codenesium.TemplateGenerator.UserControls
{
    partial class Templates
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxTemplates = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxProjects = new MetroFramework.Controls.MetroComboBox();
            this.labelOutputDirectory = new MetroFramework.Controls.MetroLabel();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.buttonSelectOutputDirectory = new MetroFramework.Controls.MetroButton();
            this.folderBrowserDialogDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabelTemplateDescription = new MetroFramework.Controls.MetroLink();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 150);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Parameters";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(12, 79);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Template";
            // 
            // comboBoxTemplates
            // 
            this.comboBoxTemplates.FormattingEnabled = true;
            this.comboBoxTemplates.ItemHeight = 23;
            this.comboBoxTemplates.Location = new System.Drawing.Point(12, 104);
            this.comboBoxTemplates.Name = "comboBoxTemplates";
            this.comboBoxTemplates.Size = new System.Drawing.Size(305, 29);
            this.comboBoxTemplates.TabIndex = 5;
            this.comboBoxTemplates.UseSelectable = true;
            this.comboBoxTemplates.SelectedIndexChanged += new System.EventHandler(this.comboBoxTemplates_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 11);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(50, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Project";
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.ItemHeight = 23;
            this.comboBoxProjects.Location = new System.Drawing.Point(12, 36);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(305, 29);
            this.comboBoxProjects.TabIndex = 7;
            this.comboBoxProjects.UseSelectable = true;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(12, 436);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(110, 19);
            this.labelOutputDirectory.TabIndex = 11;
            this.labelOutputDirectory.Text = "Output Directory:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(692, 470);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 29);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(12, 401);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(107, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Output Directory";
            // 
            // buttonSelectOutputDirectory
            // 
            this.buttonSelectOutputDirectory.Location = new System.Drawing.Point(125, 397);
            this.buttonSelectOutputDirectory.Name = "buttonSelectOutputDirectory";
            this.buttonSelectOutputDirectory.Size = new System.Drawing.Size(75, 29);
            this.buttonSelectOutputDirectory.TabIndex = 14;
            this.buttonSelectOutputDirectory.Text = "Select";
            this.buttonSelectOutputDirectory.UseSelectable = true;
            this.buttonSelectOutputDirectory.Click += new System.EventHandler(this.buttonSelectOutputDirectory_Click);
            // 
            // dataGridViewParameters
            // 
            this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dataGridViewParameters.Location = new System.Drawing.Point(12, 175);
            this.dataGridViewParameters.Name = "dataGridViewParameters";
            this.dataGridViewParameters.Size = new System.Drawing.Size(773, 194);
            this.dataGridViewParameters.TabIndex = 15;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.Width = 170;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // linkLabelTemplateDescription
            // 
            this.linkLabelTemplateDescription.Location = new System.Drawing.Point(12, 476);
            this.linkLabelTemplateDescription.Name = "linkLabelTemplateDescription";
            this.linkLabelTemplateDescription.Size = new System.Drawing.Size(132, 23);
            this.linkLabelTemplateDescription.TabIndex = 16;
            this.linkLabelTemplateDescription.Text = "Template Description";
            this.linkLabelTemplateDescription.UseSelectable = true;
            // 
            // Templates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelTemplateDescription);
            this.Controls.Add(this.dataGridViewParameters);
            this.Controls.Add(this.buttonSelectOutputDirectory);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelOutputDirectory);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.comboBoxTemplates);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Templates";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox comboBoxTemplates;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBoxProjects;
        private MetroFramework.Controls.MetroLabel labelOutputDirectory;
        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton buttonSelectOutputDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDirectory;
        private System.Windows.Forms.DataGridView dataGridViewParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private MetroFramework.Controls.MetroLink linkLabelTemplateDescription;
    }
}

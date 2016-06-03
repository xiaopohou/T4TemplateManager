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
            this.components = new System.ComponentModel.Container();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxTemplates = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxProjects = new MetroFramework.Controls.MetroComboBox();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.folderBrowserDialogDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabelViewTemplate = new MetroFramework.Controls.MetroLink();
            this.treeViewParameters = new System.Windows.Forms.TreeView();
            this.textBoxParameterValue = new MetroFramework.Controls.MetroTextBox();
            this.textBoxParameterKey = new MetroFramework.Controls.MetroTextBox();
            this.contextMenuStripNodeOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMapToDatabaseField = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMenu = new MetroFramework.Controls.MetroButton();
            this.contextMenuStripParameterOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemLoadFromStoredProcedure = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopyToAllTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
            this.contextMenuStripNodeOptions.SuspendLayout();
            this.contextMenuStripParameterOptions.SuspendLayout();
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
            this.comboBoxTemplates.Size = new System.Drawing.Size(200, 29);
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
            this.comboBoxProjects.Size = new System.Drawing.Size(200, 29);
            this.comboBoxProjects.TabIndex = 7;
            this.comboBoxProjects.UseSelectable = true;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(724, 336);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 29);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridViewParameters
            // 
            this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dataGridViewParameters.Location = new System.Drawing.Point(12, 175);
            this.dataGridViewParameters.Name = "dataGridViewParameters";
            this.dataGridViewParameters.Size = new System.Drawing.Size(422, 135);
            this.dataGridViewParameters.TabIndex = 15;
            this.dataGridViewParameters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParameters_CellValueChanged);
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
            // linkLabelViewTemplate
            // 
            this.linkLabelViewTemplate.ForeColor = System.Drawing.Color.Blue;
            this.linkLabelViewTemplate.Location = new System.Drawing.Point(216, 107);
            this.linkLabelViewTemplate.Name = "linkLabelViewTemplate";
            this.linkLabelViewTemplate.Size = new System.Drawing.Size(75, 23);
            this.linkLabelViewTemplate.Style = MetroFramework.MetroColorStyle.Blue;
            this.linkLabelViewTemplate.TabIndex = 16;
            this.linkLabelViewTemplate.Text = "View";
            this.linkLabelViewTemplate.UseCustomForeColor = true;
            this.linkLabelViewTemplate.UseSelectable = true;
            this.linkLabelViewTemplate.Click += new System.EventHandler(this.linkLabelViewTemplate_Click);
            // 
            // treeViewParameters
            // 
            this.treeViewParameters.Location = new System.Drawing.Point(463, 36);
            this.treeViewParameters.Name = "treeViewParameters";
            this.treeViewParameters.Size = new System.Drawing.Size(341, 222);
            this.treeViewParameters.TabIndex = 17;
            this.treeViewParameters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewParameters_AfterSelect);
            this.treeViewParameters.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewParameters_MouseUp);
            // 
            // textBoxParameterValue
            // 
            // 
            // 
            // 
            this.textBoxParameterValue.CustomButton.Image = null;
            this.textBoxParameterValue.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.textBoxParameterValue.CustomButton.Name = "";
            this.textBoxParameterValue.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxParameterValue.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxParameterValue.CustomButton.TabIndex = 1;
            this.textBoxParameterValue.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxParameterValue.CustomButton.UseSelectable = true;
            this.textBoxParameterValue.CustomButton.Visible = false;
            this.textBoxParameterValue.Lines = new string[0];
            this.textBoxParameterValue.Location = new System.Drawing.Point(509, 297);
            this.textBoxParameterValue.MaxLength = 32767;
            this.textBoxParameterValue.Name = "textBoxParameterValue";
            this.textBoxParameterValue.PasswordChar = '\0';
            this.textBoxParameterValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxParameterValue.SelectedText = "";
            this.textBoxParameterValue.SelectionLength = 0;
            this.textBoxParameterValue.SelectionStart = 0;
            this.textBoxParameterValue.Size = new System.Drawing.Size(295, 23);
            this.textBoxParameterValue.TabIndex = 18;
            this.textBoxParameterValue.UseSelectable = true;
            this.textBoxParameterValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxParameterValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxParameterValue.TextChanged += new System.EventHandler(this.textBoxParameterValue_TextChanged);
            // 
            // textBoxParameterKey
            // 
            // 
            // 
            // 
            this.textBoxParameterKey.CustomButton.Image = null;
            this.textBoxParameterKey.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.textBoxParameterKey.CustomButton.Name = "";
            this.textBoxParameterKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxParameterKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxParameterKey.CustomButton.TabIndex = 1;
            this.textBoxParameterKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxParameterKey.CustomButton.UseSelectable = true;
            this.textBoxParameterKey.CustomButton.Visible = false;
            this.textBoxParameterKey.Lines = new string[0];
            this.textBoxParameterKey.Location = new System.Drawing.Point(509, 270);
            this.textBoxParameterKey.MaxLength = 32767;
            this.textBoxParameterKey.Name = "textBoxParameterKey";
            this.textBoxParameterKey.PasswordChar = '\0';
            this.textBoxParameterKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxParameterKey.SelectedText = "";
            this.textBoxParameterKey.SelectionLength = 0;
            this.textBoxParameterKey.SelectionStart = 0;
            this.textBoxParameterKey.Size = new System.Drawing.Size(295, 23);
            this.textBoxParameterKey.TabIndex = 19;
            this.textBoxParameterKey.UseSelectable = true;
            this.textBoxParameterKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxParameterKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxParameterKey.TextChanged += new System.EventHandler(this.textBoxParameterKey_TextChanged);
            // 
            // contextMenuStripNodeOptions
            // 
            this.contextMenuStripNodeOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAddItem,
            this.toolStripMenuItemDeleteItem,
            this.toolStripMenuItemMapToDatabaseField});
            this.contextMenuStripNodeOptions.Name = "contextMenuStripNodeOptions";
            this.contextMenuStripNodeOptions.Size = new System.Drawing.Size(164, 70);
            this.contextMenuStripNodeOptions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripNodeOptions_Opening);
            // 
            // toolStripMenuAddItem
            // 
            this.toolStripMenuAddItem.Name = "toolStripMenuAddItem";
            this.toolStripMenuAddItem.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuAddItem.Text = "Add Item";
            this.toolStripMenuAddItem.Click += new System.EventHandler(this.toolStripMenuAddItem_Click);
            // 
            // toolStripMenuItemDeleteItem
            // 
            this.toolStripMenuItemDeleteItem.Name = "toolStripMenuItemDeleteItem";
            this.toolStripMenuItemDeleteItem.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemDeleteItem.Text = "Delete Item";
            this.toolStripMenuItemDeleteItem.Click += new System.EventHandler(this.toolStripMenuItemDeleteItem_Click);
            // 
            // toolStripMenuItemMapToDatabaseField
            // 
            this.toolStripMenuItemMapToDatabaseField.Name = "toolStripMenuItemMapToDatabaseField";
            this.toolStripMenuItemMapToDatabaseField.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemMapToDatabaseField.Text = "Map to Database";
            this.toolStripMenuItemMapToDatabaseField.Click += new System.EventHandler(this.toolStripMenuItemMapToDatabaseField_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.ContextMenuStrip = this.contextMenuStripParameterOptions;
            this.buttonMenu.Location = new System.Drawing.Point(463, 3);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(95, 29);
            this.buttonMenu.TabIndex = 21;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseSelectable = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // contextMenuStripParameterOptions
            // 
            this.contextMenuStripParameterOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoadFromStoredProcedure,
            this.loadFromTableToolStripMenuItem,
            this.toolStripMenuItemCopyToAllTemplates});
            this.contextMenuStripParameterOptions.Name = "contextMenuStripParameterOptions";
            this.contextMenuStripParameterOptions.Size = new System.Drawing.Size(224, 70);
            this.contextMenuStripParameterOptions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripParameterOptions_Opening);
            // 
            // toolStripMenuItemLoadFromStoredProcedure
            // 
            this.toolStripMenuItemLoadFromStoredProcedure.Name = "toolStripMenuItemLoadFromStoredProcedure";
            this.toolStripMenuItemLoadFromStoredProcedure.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemLoadFromStoredProcedure.Text = "Load from Stored Procedure";
            this.toolStripMenuItemLoadFromStoredProcedure.Click += new System.EventHandler(this.toolStripMenuItemLoadFromStoredProcedure_Click);
            // 
            // loadFromTableToolStripMenuItem
            // 
            this.loadFromTableToolStripMenuItem.Name = "loadFromTableToolStripMenuItem";
            this.loadFromTableToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.loadFromTableToolStripMenuItem.Text = "Load from Table";
            this.loadFromTableToolStripMenuItem.Click += new System.EventHandler(this.loadFromTableToolStripMenuItem_Click);
            // 
            // toolStripMenuItemCopyToAllTemplates
            // 
            this.toolStripMenuItemCopyToAllTemplates.Name = "toolStripMenuItemCopyToAllTemplates";
            this.toolStripMenuItemCopyToAllTemplates.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemCopyToAllTemplates.Text = "Copy to All Templates";
            this.toolStripMenuItemCopyToAllTemplates.Click += new System.EventHandler(this.toolStripMenuItemCopyToAllTemplates_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(460, 273);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(29, 19);
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "Key";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(460, 298);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(41, 19);
            this.metroLabel5.TabIndex = 23;
            this.metroLabel5.Text = "Value";
            // 
            // Templates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.textBoxParameterKey);
            this.Controls.Add(this.textBoxParameterValue);
            this.Controls.Add(this.treeViewParameters);
            this.Controls.Add(this.linkLabelViewTemplate);
            this.Controls.Add(this.dataGridViewParameters);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.comboBoxTemplates);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Templates";
            this.Size = new System.Drawing.Size(819, 545);
            this.Load += new System.EventHandler(this.Templates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
            this.contextMenuStripNodeOptions.ResumeLayout(false);
            this.contextMenuStripParameterOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox comboBoxTemplates;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBoxProjects;
        private MetroFramework.Controls.MetroButton buttonSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDirectory;
        private System.Windows.Forms.DataGridView dataGridViewParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private MetroFramework.Controls.MetroLink linkLabelViewTemplate;
        private System.Windows.Forms.TreeView treeViewParameters;
        private MetroFramework.Controls.MetroTextBox textBoxParameterValue;
        private MetroFramework.Controls.MetroTextBox textBoxParameterKey;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNodeOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMapToDatabaseField;
        private MetroFramework.Controls.MetroButton buttonMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripParameterOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadFromStoredProcedure;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyToAllTemplates;
        private System.Windows.Forms.ToolStripMenuItem loadFromTableToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
    }
}

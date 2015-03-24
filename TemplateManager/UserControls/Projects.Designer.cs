namespace Codenesium.TemplateGenerator.UserControls
{
    partial class Projects
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
            this.comboBoxProjects = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBoxName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.buttonCreate = new MetroFramework.Controls.MetroButton();
            this.checkedListBoxTemplates = new System.Windows.Forms.CheckedListBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.ItemHeight = 23;
            this.comboBoxProjects.Location = new System.Drawing.Point(12, 36);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(200, 29);
            this.comboBoxProjects.TabIndex = 0;
            this.comboBoxProjects.UseSelectable = true;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(50, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Project";
            // 
            // textBoxName
            // 
            this.textBoxName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxName.Lines = new string[0];
            this.textBoxName.Location = new System.Drawing.Point(12, 101);
            this.textBoxName.MaxLength = 32767;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PasswordChar = '\0';
            this.textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxName.SelectedText = "";
            this.textBoxName.Size = new System.Drawing.Size(198, 23);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(12, 79);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Name";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(724, 336);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(231, 36);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 29);
            this.buttonCreate.TabIndex = 5;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseSelectable = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // checkedListBoxTemplates
            // 
            this.checkedListBoxTemplates.FormattingEnabled = true;
            this.checkedListBoxTemplates.Location = new System.Drawing.Point(371, 51);
            this.checkedListBoxTemplates.Name = "checkedListBoxTemplates";
            this.checkedListBoxTemplates.Size = new System.Drawing.Size(272, 214);
            this.checkedListBoxTemplates.TabIndex = 6;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(371, 29);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Templates";
            // 
            // Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.checkedListBoxTemplates);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.comboBoxProjects);
            this.Name = "Projects";
            this.Size = new System.Drawing.Size(819, 384);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox comboBoxProjects;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox textBoxName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroButton buttonCreate;
        private System.Windows.Forms.CheckedListBox checkedListBoxTemplates;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}

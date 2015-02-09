namespace Codenesium.TemplateGenerator.UserControls
{
    partial class Generation
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
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxProjects = new MetroFramework.Controls.MetroComboBox();
            this.buttonGenerate = new MetroFramework.Controls.MetroButton();
            this.textBoxResult = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(17, 23);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(50, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Project";
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.ItemHeight = 23;
            this.comboBoxProjects.Location = new System.Drawing.Point(17, 48);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(305, 29);
            this.comboBoxProjects.TabIndex = 9;
            this.comboBoxProjects.UseSelectable = true;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(247, 103);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 11;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseSelectable = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Lines = new string[0];
            this.textBoxResult.Location = new System.Drawing.Point(364, 103);
            this.textBoxResult.MaxLength = 32767;
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.PasswordChar = '\0';
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxResult.SelectedText = "";
            this.textBoxResult.Size = new System.Drawing.Size(391, 332);
            this.textBoxResult.TabIndex = 12;
            this.textBoxResult.UseSelectable = true;
            // 
            // Generation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboBoxProjects);
            this.Name = "Generation";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBoxProjects;
        private MetroFramework.Controls.MetroButton buttonGenerate;
        private MetroFramework.Controls.MetroTextBox textBoxResult;
    }
}

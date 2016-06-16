namespace Codenesium.TemplateGenerator.Forms
{
    partial class FormMapToDatabase
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
            this.comboBoxFields = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxFields
            // 
            this.comboBoxFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFields.FormattingEnabled = true;
            this.comboBoxFields.Location = new System.Drawing.Point(23, 88);
            this.comboBoxFields.Name = "comboBoxFields";
            this.comboBoxFields.Size = new System.Drawing.Size(254, 21);
            this.comboBoxFields.TabIndex = 0;
            this.comboBoxFields.SelectedIndexChanged += new System.EventHandler(this.comboBoxFields_SelectedIndexChanged);
            this.comboBoxFields.SelectionChangeCommitted += new System.EventHandler(this.comboBoxFields_SelectionChangeCommitted);
            // 
            // FormMapToDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 156);
            this.Controls.Add(this.comboBoxFields);
            this.Name = "FormMapToDatabase";
            this.Text = "Database Mapping";
            this.Activated += new System.EventHandler(this.FormMapToDatabase_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFields;
    }
}
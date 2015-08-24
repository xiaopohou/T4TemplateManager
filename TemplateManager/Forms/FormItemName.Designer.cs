namespace Codenesium.TemplateGenerator.Forms
{
    partial class FormItemName
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
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.textBoxValue = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(248, 114);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Lines = new string[0];
            this.textBoxValue.Location = new System.Drawing.Point(23, 63);
            this.textBoxValue.MaxLength = 2000000;
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.PasswordChar = '\0';
            this.textBoxValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxValue.SelectedText = "";
            this.textBoxValue.Size = new System.Drawing.Size(300, 20);
            this.textBoxValue.TabIndex = 3;
            this.textBoxValue.UseSelectable = true;
            this.textBoxValue.WordWrap = false;
            // 
            // FormItemName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 166);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxValue);
            this.Name = "FormItemName";
            this.Text = "Item Name";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroTextBox textBoxValue;

    }
}
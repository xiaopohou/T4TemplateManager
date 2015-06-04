namespace Codenesium.TemplateGenerator.Forms
{
    partial class FormTextViewer
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
            this.richTextBoxViewer = new System.Windows.Forms.RichTextBox();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // richTextBoxViewer
            // 
            this.richTextBoxViewer.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxViewer.Location = new System.Drawing.Point(20, 60);
            this.richTextBoxViewer.Name = "richTextBoxViewer";
            this.richTextBoxViewer.Size = new System.Drawing.Size(1109, 718);
            this.richTextBoxViewer.TabIndex = 0;
            this.richTextBoxViewer.Text = "";
            this.richTextBoxViewer.WordWrap = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(1029, 793);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 29);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormTextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 836);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.richTextBoxViewer);
            this.MaximizeBox = false;
            this.Name = "FormTextViewer";
            this.Load += new System.EventHandler(this.FormTextViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxViewer;
        private MetroFramework.Controls.MetroButton buttonSave;
    }
}
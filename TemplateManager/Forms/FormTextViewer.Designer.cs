﻿namespace Codenesium.TemplateGenerator.Forms
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
            this.SuspendLayout();
            // 
            // richTextBoxViewer
            // 
            this.richTextBoxViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxViewer.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxViewer.Name = "richTextBoxViewer";
            this.richTextBoxViewer.Size = new System.Drawing.Size(941, 610);
            this.richTextBoxViewer.TabIndex = 0;
            this.richTextBoxViewer.Text = "";
            // 
            // FormTextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 610);
            this.Controls.Add(this.richTextBoxViewer);
            this.Name = "FormTextViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTextViewer";
            this.Load += new System.EventHandler(this.FormTextViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxViewer;
    }
}
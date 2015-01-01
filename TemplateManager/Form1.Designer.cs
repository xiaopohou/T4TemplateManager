﻿namespace Codenesium.TemplateGenerator
{
    partial class Form1
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
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.comboBoxMenu = new System.Windows.Forms.ComboBox();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxErrorsAndWarnings = new System.Windows.Forms.TextBox();
            this.comboBoxDatabaseInterface = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.panelCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(575, 64);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(530, 165);
            this.textBoxOutput.TabIndex = 1;
            this.textBoxOutput.WordWrap = false;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(472, 446);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 2;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // comboBoxMenu
            // 
            this.comboBoxMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMenu.FormattingEnabled = true;
            this.comboBoxMenu.Items.AddRange(new object[] {
            "Business Object",
            "Interface",
            "MSSQL Select Query"});
            this.comboBoxMenu.Location = new System.Drawing.Point(13, 40);
            this.comboBoxMenu.Name = "comboBoxMenu";
            this.comboBoxMenu.Size = new System.Drawing.Size(534, 21);
            this.comboBoxMenu.TabIndex = 3;
            this.comboBoxMenu.SelectedIndexChanged += new System.EventHandler(this.comboBoxMenu_SelectedIndexChanged);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Controls.Add(this.label1);
            this.panelCanvas.Controls.Add(this.textBoxParameters);
            this.panelCanvas.Location = new System.Drawing.Point(13, 148);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(534, 292);
            this.panelCanvas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parameters";
            // 
            // textBoxParameters
            // 
            this.textBoxParameters.Location = new System.Drawing.Point(3, 16);
            this.textBoxParameters.Multiline = true;
            this.textBoxParameters.Name = "textBoxParameters";
            this.textBoxParameters.Size = new System.Drawing.Size(526, 358);
            this.textBoxParameters.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Errors and Warnings";
            // 
            // textBoxErrorsAndWarnings
            // 
            this.textBoxErrorsAndWarnings.Location = new System.Drawing.Point(579, 275);
            this.textBoxErrorsAndWarnings.Multiline = true;
            this.textBoxErrorsAndWarnings.Name = "textBoxErrorsAndWarnings";
            this.textBoxErrorsAndWarnings.Size = new System.Drawing.Size(530, 165);
            this.textBoxErrorsAndWarnings.TabIndex = 5;
            this.textBoxErrorsAndWarnings.WordWrap = false;
            // 
            // comboBoxDatabaseInterface
            // 
            this.comboBoxDatabaseInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabaseInterface.FormattingEnabled = true;
            this.comboBoxDatabaseInterface.Items.AddRange(new object[] {
            "NONE",
            "MSSQL"});
            this.comboBoxDatabaseInterface.Location = new System.Drawing.Point(12, 84);
            this.comboBoxDatabaseInterface.Name = "comboBoxDatabaseInterface";
            this.comboBoxDatabaseInterface.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDatabaseInterface.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Template";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Database Interface";
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(165, 82);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(109, 23);
            this.buttonTestConnection.TabIndex = 10;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 510);
            this.Controls.Add(this.buttonTestConnection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDatabaseInterface);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxErrorsAndWarnings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.comboBoxMenu);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.textBoxOutput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCanvas.ResumeLayout(false);
            this.panelCanvas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.ComboBox comboBoxMenu;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxErrorsAndWarnings;
        private System.Windows.Forms.ComboBox comboBoxDatabaseInterface;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTestConnection;
    }
}


namespace Codenesium.TemplateGenerator.Forms
{
    partial class MainForm
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
            this.panelMain = new MetroFramework.Controls.MetroPanel();
            this.buttonProjects = new MetroFramework.Controls.MetroButton();
            this.buttonTemplates = new MetroFramework.Controls.MetroButton();
            this.buttonDataInterfaces = new MetroFramework.Controls.MetroButton();
            this.buttonGeneration = new MetroFramework.Controls.MetroButton();
            this.labelStatus = new MetroFramework.Controls.MetroLabel();
            this.buttonRefresh = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.HorizontalScrollbarBarColor = true;
            this.panelMain.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMain.HorizontalScrollbarSize = 10;
            this.panelMain.Location = new System.Drawing.Point(23, 100);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(819, 385);
            this.panelMain.TabIndex = 2;
            this.panelMain.VerticalScrollbarBarColor = true;
            this.panelMain.VerticalScrollbarHighlightOnWheel = false;
            this.panelMain.VerticalScrollbarSize = 10;
            // 
            // buttonProjects
            // 
            this.buttonProjects.Location = new System.Drawing.Point(24, 64);
            this.buttonProjects.Name = "buttonProjects";
            this.buttonProjects.Size = new System.Drawing.Size(100, 29);
            this.buttonProjects.TabIndex = 3;
            this.buttonProjects.Text = "Projects";
            this.buttonProjects.UseSelectable = true;
            this.buttonProjects.Click += new System.EventHandler(this.buttonProject_Click);
            // 
            // buttonTemplates
            // 
            this.buttonTemplates.Location = new System.Drawing.Point(142, 64);
            this.buttonTemplates.Name = "buttonTemplates";
            this.buttonTemplates.Size = new System.Drawing.Size(100, 29);
            this.buttonTemplates.TabIndex = 4;
            this.buttonTemplates.Text = "Templates";
            this.buttonTemplates.UseSelectable = true;
            this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
            // 
            // buttonDataInterfaces
            // 
            this.buttonDataInterfaces.Location = new System.Drawing.Point(260, 64);
            this.buttonDataInterfaces.Name = "buttonDataInterfaces";
            this.buttonDataInterfaces.Size = new System.Drawing.Size(100, 29);
            this.buttonDataInterfaces.TabIndex = 5;
            this.buttonDataInterfaces.Text = "Data Interfaces";
            this.buttonDataInterfaces.UseSelectable = true;
            this.buttonDataInterfaces.Click += new System.EventHandler(this.buttonDataInterfaces_Click);
            // 
            // buttonGeneration
            // 
            this.buttonGeneration.Location = new System.Drawing.Point(377, 64);
            this.buttonGeneration.Name = "buttonGeneration";
            this.buttonGeneration.Size = new System.Drawing.Size(100, 29);
            this.buttonGeneration.TabIndex = 6;
            this.buttonGeneration.Text = "Generation";
            this.buttonGeneration.UseSelectable = true;
            this.buttonGeneration.Click += new System.EventHandler(this.buttonGeneration_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelStatus.Location = new System.Drawing.Point(23, 648);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(72, 19);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Response";
            this.labelStatus.UseCustomForeColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(742, 65);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 29);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseSelectable = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 510);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonGeneration);
            this.Controls.Add(this.buttonDataInterfaces);
            this.Controls.Add(this.buttonTemplates);
            this.Controls.Add(this.buttonProjects);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "Codenesium T4 Template Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelMain;
        private MetroFramework.Controls.MetroButton buttonProjects;
        private MetroFramework.Controls.MetroButton buttonTemplates;
        private MetroFramework.Controls.MetroButton buttonDataInterfaces;
        private MetroFramework.Controls.MetroButton buttonGeneration;
        private MetroFramework.Controls.MetroLabel labelStatus;
        private MetroFramework.Controls.MetroButton buttonRefresh;


    }
}
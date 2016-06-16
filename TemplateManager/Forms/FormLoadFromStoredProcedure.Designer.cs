namespace Codenesium.TemplateGenerator.Forms
{
    partial class FormLoadFromStoredProcedure
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
            this.comboBoxStoredProcedure = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxDataInterface = new System.Windows.Forms.ComboBox();
            this.buttonRefresh = new MetroFramework.Controls.MetroButton();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.comboBoxSchemas = new System.Windows.Forms.ComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // comboBoxStoredProcedure
            // 
            this.comboBoxStoredProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoredProcedure.FormattingEnabled = true;
            this.comboBoxStoredProcedure.Location = new System.Drawing.Point(23, 195);
            this.comboBoxStoredProcedure.Name = "comboBoxStoredProcedure";
            this.comboBoxStoredProcedure.Size = new System.Drawing.Size(254, 21);
            this.comboBoxStoredProcedure.TabIndex = 1;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 173);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(118, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Stored Procedures";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Data Interface";
            // 
            // comboBoxDataInterface
            // 
            this.comboBoxDataInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataInterface.FormattingEnabled = true;
            this.comboBoxDataInterface.Location = new System.Drawing.Point(23, 94);
            this.comboBoxDataInterface.Name = "comboBoxDataInterface";
            this.comboBoxDataInterface.Size = new System.Drawing.Size(254, 21);
            this.comboBoxDataInterface.TabIndex = 9;
            this.comboBoxDataInterface.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataInterface_SelectedIndexChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(292, 187);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 29);
            this.buttonRefresh.TabIndex = 11;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseSelectable = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(292, 258);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 29);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseSelectable = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxSchemas
            // 
            this.comboBoxSchemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSchemas.FormattingEnabled = true;
            this.comboBoxSchemas.Location = new System.Drawing.Point(23, 142);
            this.comboBoxSchemas.Name = "comboBoxSchemas";
            this.comboBoxSchemas.Size = new System.Drawing.Size(254, 21);
            this.comboBoxSchemas.TabIndex = 13;
            this.comboBoxSchemas.SelectedIndexChanged += new System.EventHandler(this.comboBoxSchemas_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 120);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(55, 19);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "Schema";
            // 
            // FormLoadFromStoredProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 323);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.comboBoxSchemas);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.comboBoxDataInterface);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboBoxStoredProcedure);
            this.Name = "FormLoadFromStoredProcedure";
            this.Text = "Load Fields from Stored Procedure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStoredProcedure;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox comboBoxDataInterface;
        private MetroFramework.Controls.MetroButton buttonRefresh;
        private MetroFramework.Controls.MetroButton buttonSave;
        private System.Windows.Forms.ComboBox comboBoxSchemas;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}
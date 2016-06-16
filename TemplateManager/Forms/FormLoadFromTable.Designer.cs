namespace Codenesium.TemplateGenerator.Forms
{
    partial class FormLoadFromTable
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
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxDataInterface = new System.Windows.Forms.ComboBox();
            this.buttonRefresh = new MetroFramework.Controls.MetroButton();
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxSchemas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(23, 209);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(254, 21);
            this.comboBoxTable.TabIndex = 1;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 187);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(46, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Tables";
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
            this.buttonRefresh.Location = new System.Drawing.Point(292, 201);
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
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 130);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(55, 19);
            this.metroLabel2.TabIndex = 16;
            this.metroLabel2.Text = "Schema";
            // 
            // comboBoxSchemas
            // 
            this.comboBoxSchemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSchemas.FormattingEnabled = true;
            this.comboBoxSchemas.Location = new System.Drawing.Point(23, 152);
            this.comboBoxSchemas.Name = "comboBoxSchemas";
            this.comboBoxSchemas.Size = new System.Drawing.Size(254, 21);
            this.comboBoxSchemas.TabIndex = 15;
            this.comboBoxSchemas.SelectedIndexChanged += new System.EventHandler(this.comboBoxSchemas_SelectedIndexChanged);
            // 
            // FormLoadFromTable
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
            this.Controls.Add(this.comboBoxTable);
            this.Name = "FormLoadFromTable";
            this.Text = "Load Fields from Table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTable;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox comboBoxDataInterface;
        private MetroFramework.Controls.MetroButton buttonRefresh;
        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ComboBox comboBoxSchemas;
    }
}
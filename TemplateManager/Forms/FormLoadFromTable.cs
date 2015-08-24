using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codenesium.TemplateGenerator.Classes.Generation;
using Codenesium.TemplateGenerator.Classes.Mediation;
using Codenesium.GenerationLibrary.Database;
using System.Xml.Linq;
namespace Codenesium.TemplateGenerator.Forms
{
    public partial class FormLoadFromTable : MetroFramework.Forms.MetroForm
    {
        ProjectTemplate _projectTemplate;
        public FormLoadFromTable(ProjectTemplate projectTemplate)
        {
            InitializeComponent();
            this._projectTemplate = projectTemplate;
            LoadForm();
        
        }

        public void LoadForm()
        {
            comboBoxDataInterface.Items.Clear();
            foreach(string key in  ProjectContainer.GetInstance().ConnectionStrings.Keys)
            {
                comboBoxDataInterface.Items.Add(key);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void LoadTables()
        {
            if (comboBoxDataInterface.SelectedIndex > -1)
            {
                comboBoxTable.Items.Clear();
                string connectionString = ProjectContainer.GetInstance().ConnectionStrings[comboBoxDataInterface.SelectedItem.ToString()];
                MSSQL mssqlInterface = new MSSQL(connectionString);
                mssqlInterface.TestConnection();
                if (mssqlInterface.ConnectionTestResult)
                {
                    comboBoxTable.Items.AddRange(MSSQL.GetTableListAsStrings(connectionString).ToArray()); 
                }
                else
                {
                    MessageBox.Show("Unable to connect to SQL Server", "Error");
                }
            }
        }

        private void comboBoxDataInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
           
            string table = comboBoxTable.SelectedItem.ToString();
            string connectionString = ProjectContainer.GetInstance().ConnectionStrings[comboBoxDataInterface.SelectedItem.ToString()];
            XElement fields = Codenesium.GenerationLibrary.Database.MSSQL.GetFieldListFromTable(table,connectionString);
            this._projectTemplate.ParametersTree.Elements("root").Elements("children").FirstOrDefault().Add(fields);
            this.Close();
        }
    }
}

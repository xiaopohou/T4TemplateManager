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
    public partial class FormLoadFromStoredProcedure : MetroFramework.Forms.MetroForm
    {
        ProjectTemplate _projectTemplate;
        public FormLoadFromStoredProcedure(ProjectTemplate projectTemplate)
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
            LoadStoredProcedures();
        }

        private void LoadStoredProcedures()
        {
            if (comboBoxDataInterface.SelectedIndex > -1 && comboBoxSchemas.SelectedIndex > -1)
            {
                comboBoxStoredProcedure.Items.Clear();
                string connectionString = ProjectContainer.GetInstance().ConnectionStrings[comboBoxDataInterface.SelectedItem.ToString()];
                MSSQL mssqlInterface = new MSSQL(connectionString);
                mssqlInterface.TestConnection();
                if (mssqlInterface.ConnectionTestResult)
                {
                    List<string> storedProcedureList = MSSQL.GetStoredProcedureList(comboBoxSchemas.SelectedText, connectionString);
                    foreach(string item in storedProcedureList)
                    {
                        comboBoxStoredProcedure.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to connect to SQL Server", "Error");
                }
            }
        }

        private void LoadSchemas()
        {
          
            if(comboBoxDataInterface.SelectedIndex > -1)
            {
                comboBoxSchemas.Items.Clear();
                string connectionString = ProjectContainer.GetInstance().ConnectionStrings[comboBoxDataInterface.SelectedItem.ToString()];
                MSSQL mssqlInterface = new MSSQL(connectionString);
                mssqlInterface.TestConnection();
                if (mssqlInterface.ConnectionTestResult)
                {
                    List<string> schemaList = MSSQL.GetSchemaList(connectionString);
                    foreach (string item in schemaList)
                    {
                        comboBoxSchemas.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to connect to SQL Server", "Error");
                }
            }
        }

        private void comboBoxDataInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStoredProcedures();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {

            string storedProcedure = comboBoxStoredProcedure.SelectedItem.ToString();
            string schema = comboBoxSchemas.SelectedItem.ToString();
            string connectionString = ProjectContainer.GetInstance().ConnectionStrings[comboBoxDataInterface.SelectedItem.ToString()];
            XElement fields = Codenesium.GenerationLibrary.Database.MSSQL.GetFieldListFromStoredProcedure(storedProcedure, schema,connectionString);
            this._projectTemplate.ParametersTree.Elements("root").Elements("children").FirstOrDefault().RemoveAll();
            this._projectTemplate.ParametersTree.Elements("root").Elements("children").FirstOrDefault().Add(fields);
            this.Close();
        }

        private void comboBoxSchemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStoredProcedures();
        }
    }
}

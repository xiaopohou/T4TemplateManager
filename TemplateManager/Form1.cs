using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using System.CodeDom.Compiler;

namespace Codenesium.TemplateGenerator
{
    public partial class Form1 : Form
    {
        delegate void SetStatusCallback();
        List<string> Messages;
        Classes.Generation.TemplateContainer TemplateContainer;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTemplate.SelectedIndex > -1)
            {
                textBoxParameters.Clear();
                Classes.Generation.Template template = (Classes.Generation.Template)comboBoxTemplate.SelectedItem; 

                if(template.DataInterface != String.Empty)
                {
                    comboBoxDatabaseInterface.SelectedItem = template.DataInterface;
                    checkBoxAllTables.Checked = template.PerTableTemplate;
                }

                Dictionary<string, string> parameters = Classes.Generation.Parameter.ParseParametersFromTemplate(template.TemplateText);

                foreach (string key in parameters.Keys)
                {
                    if(key.Length > 2 && key.ToUpper().Substring(0,2) == "CN")
                    {
                        continue; //skip parameters that are special. Built in parameters are prefixed with CN
                    }
                    //If the user has defaul values specified in the template.xml file load those. If not leave the paraemter blank
                    if (template.Parameters.Keys.Contains(key))
                    {
                        textBoxParameters.Text += key + "=" + template.Parameters[key] + Environment.NewLine;
                    }
                    else
                    {
                        textBoxParameters.Text += key + "=" + Environment.NewLine;
                    }
                }

            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
             Classes.Generation.Template template = (Classes.Generation.Template)comboBoxTemplate.SelectedItem;
            if (checkBoxAllTables.Checked)
            {
                ProcessAllTables(template);
                //MessageBox.Show("Generation Complete!");
            }
            else
            {
                ProcessTemplate(template);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Messages = new List<string>();
            textBoxFilename.Text = ConfigurationManager.AppSettings["outputDirectory"];
            this.TemplateContainer = new Classes.Generation.TemplateContainer();
            LoadTemplates();
            SetComboboxes();  
        }

        private void ProcessTemplate(Classes.Generation.Template  template)
        {
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            Dictionary<string, string> parameters = Classes.Generation.Parameter.ParseParameters(textBoxParameters.Text);
            generator.DatabaseInterface = comboBoxDatabaseInterface.Text;
            generator.Contents = template.TemplateText;
            generator.Parameters = parameters;
            generator.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
            generator.ExecuteTemplateCustomHost();
            textBoxOutput.Text = generator.ExecutionResult.TransformedText;
            textBoxErrorsAndWarnings.Text = generator.ExecutionResult.ErrorMessage;
        }

        private void ProcessAllTables(Classes.Generation.Template template)
        {
            Classes.Database.MSSQL MSSQLManager = new Classes.Database.MSSQL(ConfigurationManager.AppSettings["connectionString"]);
            List<Interfaces.IDatabaseTable> tableList = MSSQLManager.GetTableList();
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            Dictionary<string, string> parameters = Classes.Generation.Parameter.ParseParameters(textBoxParameters.Text);
            Task[] tasks = new Task[tableList.Count];
            for(int i=0; i < tableList.Count; i++)
            {
                parameters["DatabaseTable"] = tableList[i].Name;

                generator.DatabaseInterface = comboBoxDatabaseInterface.Text;
                generator.Contents = template.TemplateText;
                generator.Parameters = parameters;
                generator.ConnectionString = ConfigurationManager.AppSettings["connectionString"];

            //    Action action = new Action(generator.ExecuteTemplateCustomHost);
            //    tasks[i] = Task.Factory.StartNew(action)
            //        .ContinueWith(antecedant => ProcessResult(template, generator.ExecutionResult, tableList[i]));      

                generator.ExecuteTemplateCustomHost();

                ProcessResult(template, generator.ExecutionResult, tableList[i]);
            }
            //try
            //{
            //    //Task.WaitAll(tasks);
            //}
            //catch(Exception ex)
            //{

            //}


        }

        private void ProcessResult(Classes.Generation.Template template, Classes.Generation.TemplateExecutionResult result,Interfaces.IDatabaseTable table)
        {
            if (!String.IsNullOrEmpty(template.OutputDirectory))
            {
                if (!String.IsNullOrEmpty(template.Filename))
                {
                    string filename = String.Empty;
                    if (template.Filename.ToUpper() == "REPOSITORY")
                    {
                        filename = Path.Combine(template.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToRepositoryName(table.Name)) + template.FileExtension;
                    }
                    else if (template.Filename.ToUpper() == "REPOSITORYINTERFACE")
                    {
                        filename = Path.Combine(template.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToRepositoryInterfaceName(table.Name)) + template.FileExtension;
                    }
                    else if (template.Filename.ToUpper() == "BASICOBJECT")
                    {
                        filename = Path.Combine(template.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToBasicObjectName(table.Name)) + template.FileExtension;
                    }
                    else if (template.Filename.ToUpper() == "BASICOBJECTINTERFACE")
                    {
                        filename = Path.Combine(template.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToBasicObjectInterfaceName(table.Name)) + template.FileExtension;
                    }
                    else
                    {
                        filename = Path.Combine(template.OutputDirectory, table.Name + template.FileExtension);
                    }
                    if (checkBoxSaveToDisk.Checked)
                    {
                        File.WriteAllText(filename, result.TransformedText);
                    }
                }
            }
        }


        private void SetComboboxes()
        {
            if (comboBoxDatabaseInterface.Items.Count > 0)
            {
                comboBoxDatabaseInterface.SelectedIndex = 0;
            }
            if (comboBoxTemplate.Items.Count > 0)
            {
                comboBoxTemplate.SelectedIndex = 0;
            }
        }


        private void LoadTemplates()
        {
            comboBoxTemplate.Items.Clear();
            this.TemplateContainer = Classes.Generation.TemplateContainer.Factory(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "templates.xml"));
            comboBoxTemplate.DataSource = this.TemplateContainer.TemplateList;
            comboBoxTemplate.DisplayMember = "Name";
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            Classes.Database.MSSQL MSSQLManager = new Classes.Database.MSSQL(ConfigurationManager.AppSettings["connectionString"]);

            this.AddMessage ("Starting Connection Test");
            Action action = new Action(MSSQLManager.TestConnection);
            Task.Factory.StartNew(action)
                .ContinueWith(antecedant => this.AddMessage ("Connection Result=" + MSSQLManager.ConnectionTestResult.ToString()))
                .ContinueWith(antecedant => UpdateStatus());


        }

        #region updateStatusRegion
        private void UpdateStatus()
        {
            if (this.textBoxOutput.InvokeRequired)
            {
                SetStatusCallback d = new SetStatusCallback(UpdateStatus);
                this.Invoke(d, new object[] { });
            }
            else
            {
                textBoxOutput.Lines = this.Messages.ToArray();
                textBoxOutput.SelectionStart = textBoxOutput.TextLength;
                textBoxOutput.ScrollToCaret();
            }
        }

        private void AddMessage(string message)
        {
            this.Messages.Add(message);
            this.UpdateStatus();
        }

        #endregion

        private void buttonSaveToDisk_Click(object sender, EventArgs e)
        {
            File.WriteAllText(textBoxFilename.Text, textBoxOutput.Text);
        }

        private void buttonViewTemplate_Click(object sender, EventArgs e)
        {
            Classes.Generation.Template template = (Classes.Generation.Template)comboBoxTemplate.SelectedItem;
            Forms.FormTextViewer viewer = new Forms.FormTextViewer(template.TemplateText);
            viewer.ShowDialog();
        }

    }
}


    

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
                string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates", comboBoxTemplate.Text);
                string contents = File.ReadAllText(path);

                Dictionary<string, string> parameters = Classes.Generation.Parameter.ParseParametersFromTemplate(contents);

                foreach (string key in parameters.Keys)
                {
                    textBoxParameters.Text += key + "=" + Environment.NewLine;
                }

            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            Classes.Generation.Template template = (Classes.Generation.Template)comboBoxTemplate.SelectedItem;
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            Classes.Generation.TemplateExecutionResult result = generator.ExecuteTemplateCustomHost(template.TemplateText, textBoxParameters.Text, comboBoxDatabaseInterface.Text, ConfigurationManager.AppSettings["connectionString"]);
            textBoxOutput.Text = result.TransformedText;
            textBoxErrorsAndWarnings.Text = result.ErrorMessage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Messages = new List<string>();
            textBoxFilename.Text = ConfigurationManager.AppSettings["outputDirectory"];
            this.TemplateContainer = new Classes.Generation.TemplateContainer();
            LoadTemplates();
            SetComboboxes();  
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

    }
}


    

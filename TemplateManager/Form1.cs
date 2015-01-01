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
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMenu.SelectedIndex > -1)
            {
                textBoxParameters.Clear();
                string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates", comboBoxMenu.Text);
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
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates", comboBoxMenu.Text);
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            Classes.Generation.TemplateExecutionResult result = generator.ExecuteTemplateCustomHost(path, textBoxParameters.Text, comboBoxDatabaseInterface.Text, ConfigurationManager.AppSettings["connectionString"]);
            textBoxOutput.Text = result.TransformedText;
            textBoxErrorsAndWarnings.Text = result.ErrorMessage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Messages = new List<string>();
            LoadTemplates();
            if (comboBoxDatabaseInterface.Items.Count > 0)
            {
                comboBoxDatabaseInterface.SelectedIndex = 0;
            }
            if (comboBoxMenu.Items.Count > 0)
            {
                comboBoxMenu.SelectedIndex = 0;
            }
        }

        private void LoadTemplates()
        {
            comboBoxMenu.Items.Clear();
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates");
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".tt")
                    {
                        comboBoxMenu.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the template directory. It should be in the same directory as the executable. The error returned was" + ex.ToString());
            }

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

    }
}

    

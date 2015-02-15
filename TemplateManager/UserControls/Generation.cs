using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codenesium.TemplateGenerator.Classes.Generation;
using System.IO;
using Codenesium.TemplateGenerator.Classes.Mediation;
namespace Codenesium.TemplateGenerator.UserControls
{
    public partial class Generation : UserControl
    {
        private Project _selectedProject;
        delegate void SetStatusCallback(object sender, MessageEventArgs me);
        public Generation()
        {
            InitializeComponent();
            LoadForm();
            ProjectContainer.GetInstance().Reload += ProjectChanged;
            FormMediator.GetInstance().GenerationScreenEvent += GenerationScreenEventHandler;
            FormMediator.GetInstance().GenerationCompleteEvent += GenerationCompleteHandler;
        }

        private void ProjectChanged(object sender, EventArgs e)
        {
            LoadForm();
        }


        private void GenerationScreenEventHandler(object sender, MessageEventArgs me)
        {

            if (textBoxResult.InvokeRequired)
            {
                SetStatusCallback callback = new SetStatusCallback(GenerationScreenEventHandler);
                this.Invoke(callback, this, me);
            }
            else
            {
                textBoxResult.Text += me.Message;
            }
        }


        private void GenerationCompleteHandler(object sender, MessageEventArgs me)
        {

            if (progressSpinnerGeneration.InvokeRequired)
            {
                SetStatusCallback callback = new SetStatusCallback(GenerationCompleteHandler);
                this.Invoke(callback, this, me);
            }
            else
            {
                progressSpinnerGeneration.Visible = false;
            }
        }
        
        private void LoadForm()
        {
            int currentSelectedProject = comboBoxProjects.SelectedIndex;
            comboBoxProjects.DataSource = new BindingList<Project>(ProjectContainer.GetInstance().ProjectList);
            comboBoxProjects.DisplayMember = "Name";
            if (currentSelectedProject == -1 && comboBoxProjects.Items.Count > 0)
            {
                comboBoxProjects.SelectedIndex = 0;
            }
            else
            {
                comboBoxProjects.SelectedIndex = currentSelectedProject;
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
            if (comboBoxProjects.SelectedIndex > -1)
            {
                this._selectedProject = (Project)comboBoxProjects.SelectedItem;
                progressSpinnerGeneration.Visible = true;
                Action action = new Action(StartGeneration);
                Task generate = new Task(action);
                generate.Start();
            }
        }

        private void StartGeneration()
        {

            Classes.Mediation.FormMediator.GetInstance().SendMessage("Starting Generation");
            Dictionary<string, string> tempParameters = new Dictionary<string, string>();

            try
            {
                foreach (ProjectTemplate projectTemplate in this._selectedProject.ProjectTemplateList)
                {

                    foreach (string key in projectTemplate.Parameters.Keys)
                    {
                        if (projectTemplate.Parameters[key].ToUpper() == "PROMPT")
                        {
                            Forms.ParameterPrompt formParameterPrompt = new Forms.ParameterPrompt(key);
                            formParameterPrompt.ShowDialog();
                            tempParameters[key] = formParameterPrompt.Value;
                        }
                        else
                        {
                            tempParameters[key] = projectTemplate.Parameters[key];
                        }
                    }


                    string connectionString = String.Empty;
                    if (projectTemplate.Parameters.ContainsKey("ConnectionString"))
                    {
                        connectionString = ProjectContainer.GetInstance().ConnectionStrings[projectTemplate.Parameters["ConnectionString"]];
                    }

                    FormMediator.GetInstance().AddGenerationScreenMessage(ProcessTemplate(tempParameters, TemplateContainer.GetInstance().TemplateList.ToList().Where(x => x.Name == projectTemplate.TemplateName).FirstOrDefault(),
                      connectionString));
                }
                Classes.Mediation.FormMediator.GetInstance().SendMessage("Generation Complete");
            }
            catch(Exception ex)
            {
                Classes.Mediation.FormMediator.GetInstance().SendMessage("Exception in Generation");
                FormMediator.GetInstance().AddGenerationScreenMessage(ex.ToString());
            }

            Classes.Mediation.FormMediator.GetInstance().GenerationComplete();
            

        }

        private string ProcessTemplate(Dictionary<string, string> parameters, Template template, string connectionString)
        {
            string response = string.Empty;
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            generator.Template = template;
            generator.Parameters = parameters;

            if (parameters.ContainsKey("DataInterface"))
            {
                generator.DataInterface = Classes.Database.DataInterface.ParseDataInterfaceEnum(parameters["DataInterface"]);
            }
            else
            {
                generator.DataInterface = Classes.Database.DATAINTERFACE.NONE;
            }
            generator.ConnectionString = connectionString;

            if(parameters.ContainsKey("OutputDirectory"))
            {
                generator.OutputDirectory = parameters["OutputDirectory"];
            }


            if (parameters.ContainsKey("OutputFormat"))
            {
                if (parameters["OutputFormat"].ToUpper() == "DISK")
                {
                    generator.WriteToDisk = true;
                }
            }


            if (parameters.ContainsKey("AllTables"))
            {
                Classes.Database.MSSQL MSSQLManager = new Classes.Database.MSSQL(connectionString);
                List<Interfaces.IDatabaseTable> tableList = MSSQLManager.GetTableList();

                foreach (Interfaces.IDatabaseTable table in tableList)
                {
                    generator.Parameters["DatabaseTable"] = table.Name;
                    generator.ExecuteTemplateCustomHost();
                }
            }
            else
            {
                if (parameters.ContainsKey("DatabaseTable"))
                {
                    generator.Parameters["DatabaseTable"] = parameters["DatabaseTable"];
                }
                generator.ExecuteTemplateCustomHost();
            }


            if (parameters.ContainsKey("OutputFormat"))
            {
                if (parameters["OutputFormat"].ToUpper() == "SCREEN")
                {
                    response += generator.ExecutionResult.TransformedText;
                }
            }

            response += generator.ExecutionResult.ErrorMessage;

            if(!String.IsNullOrEmpty(generator.ExecutionResult.ErrorMessage))
            {
                Classes.Mediation.FormMediator.GetInstance().SendError("Error processing template:" + template.Name);
            }
            return response;
        }



        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

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

namespace Codenesium.TemplateGenerator.UserControls
{
    public partial class Generation : UserControl
    {
        public Generation()
        {
            InitializeComponent();
            LoadForm();
            ProjectContainer.GetInstance().Reload += ProjectChanged;
        }

        private void ProjectChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            comboBoxProjects.DataSource = new BindingList<Project>(ProjectContainer.GetInstance().ProjectList);
            comboBoxProjects.DisplayMember = "Name";
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
            if(comboBoxProjects.SelectedIndex > -1)
            {
                Project project = (Project)comboBoxProjects.SelectedItem;


                Dictionary<string, string> tempParameters = new Dictionary<string, string>();
                foreach(ProjectTemplate projectTemplate in project.ProjectTemplateList)
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
                    projectTemplate.Parameters = tempParameters;


                    textBoxResult.Text += ProcessTemplate(projectTemplate,TemplateContainer.GetInstance().TemplateList.ToList().Where(x => x.Name == projectTemplate.TemplateName).FirstOrDefault(),
                        project.ConnectionStrings[projectTemplate.Parameters["ConnectionString"]]);       
                }
            }
        }


       
        private string ProcessTemplate(ProjectTemplate projectTemplate,Template template,string connectionString)
        {
            string response = string.Empty;
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            generator.Template = template;
            generator.Parameters = projectTemplate.Parameters;
            generator.DataInterface = Classes.Database.DataInterface.ParseDataInterfaceEnum(projectTemplate.Parameters["DataInterface"]);
            generator.ConnectionString = connectionString;
            generator.OutputDirectory = projectTemplate.Parameters["OutputDirectory"];

            if (projectTemplate.Parameters.ContainsKey("OutputFormat"))
            {
                if (projectTemplate.Parameters["OutputFormat"].ToUpper() == "DISK")
                {
                    generator.WriteToDisk = true;
                }
            }


            if (projectTemplate.Parameters.ContainsKey("AllTables"))
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

                generator.Parameters["DatabaseTable"] = projectTemplate.Parameters["DatabaseTable"];
                generator.ExecuteTemplateCustomHost();
            }


            if(projectTemplate.Parameters.ContainsKey("OutputFormat"))
            {
                if(projectTemplate.Parameters["OutputFormat"].ToUpper() == "SCREEN")
                {
                    response += generator.ExecutionResult.TransformedText;
                }
            }
            
            response += generator.ExecutionResult.ErrorMessage;
            return response;
        }



        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

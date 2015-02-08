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
            if(comboBoxProjects.SelectedIndex > -1)
            {
                Project project = (Project)comboBoxProjects.SelectedItem;
               
                foreach(ProjectTemplate projectTemplate in project.ProjectTemplateList)
                {
                    ProcessTemplate(projectTemplate,TemplateContainer.GetInstance().TemplateList.ToList().Where(x => x.Name == projectTemplate.TemplateName).FirstOrDefault(),
                        project.ConnectionStrings[projectTemplate.Parameters["ConnectionString"]]);       
                }
            }
        }


       
        private void ProcessTemplate(ProjectTemplate projectTemplate,Template template,string connectionString)
        {
            Classes.Generation.Generator generator = new Classes.Generation.Generator();
            generator.Template = template;
            generator.Parameters = projectTemplate.Parameters;
            generator.DataInterface = Classes.Database.DataInterface.ParseDataInterfaceEnum(projectTemplate.Parameters["DataInterface"]);
            generator.ConnectionString = connectionString;
            generator.OutputDirectory = projectTemplate.OutputDirectory;

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


            //textBoxResult.Text = generator.ExecutionResult.TransformedText;
            //textBoxResult.Text += generator.ExecutionResult.ErrorMessage;
        }
    }
}

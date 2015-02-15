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

namespace Codenesium.TemplateGenerator.UserControls
{
    public partial class Templates : UserControl
    {
        public Templates()
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
            ClearFields();
            int currentSelectedProject = comboBoxProjects.SelectedIndex;
            comboBoxProjects.DataSource = new BindingList<Project>(ProjectContainer.GetInstance().ProjectList);
            comboBoxProjects.DisplayMember = "Name";
            comboBoxProjects.ValueMember = "ID";

            if (currentSelectedProject == -1 && comboBoxProjects.Items.Count > 0)
            {
                comboBoxProjects.SelectedIndex = 0;
            }
            else
            {
                comboBoxProjects.SelectedIndex = currentSelectedProject;
            }
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedIndex > -1)
            {
                ClearFields();
                Project project = (Project)comboBoxProjects.SelectedItem;
                comboBoxTemplates.DataSource = new BindingList<ProjectTemplate>(project.ProjectTemplateList);
                comboBoxTemplates.DisplayMember = "TemplateName";
            }
        }

        private void ClearFields()
        {
            dataGridViewParameters.Rows.Clear();
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            if (comboBoxTemplates.SelectedIndex > -1)
            {
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name.ToUpper() == projectTemplate.TemplateName.ToUpper()).FirstOrDefault();

                Dictionary<string, string> parameters = Classes.Generation.Parameter.ParseParametersFromTemplate(template.TemplateText);
                foreach (string key in parameters.Keys)
                {
                    if (key.Length > 2 && key.ToUpper().Substring(0, 2) == "CN")
                    {
                        continue; //skip parameters that are special. Built in parameters are prefixed with CN
                    }
                    //If the user has defaul values specified in the template.xml file load those. If not leave the paraemter blank

                    int index = -1;
                    if (projectTemplate.Parameters.ContainsKey(key))
                    {
                        index = dataGridViewParameters.Rows.Add(key, projectTemplate.Parameters[key]);
                    }
                    else
                    {
                        index = dataGridViewParameters.Rows.Add(key, "");
                    }
                    dataGridViewParameters.Rows[index].Cells["key"].Style.ForeColor = Color.Green;
                }


                //if we have extra parameters that are not used by the template but are generation specific we add those here
                foreach (string key in projectTemplate.Parameters.Keys)
                {
                    if (!parameters.ContainsKey(key))
                    {
                        int index = dataGridViewParameters.Rows.Add(key, projectTemplate.Parameters[key]);
                        dataGridViewParameters.Rows[index].Cells["key"].Style.ForeColor = Color.Blue;
                    }
                }

            }
        }

        public Dictionary<string,string> ConvertGridToDictionary()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridViewParameters.Rows)
            {

                string key = (row.Cells["key"].Value ?? String.Empty).ToString();
                string value = (row.Cells["value"].Value ?? String.Empty).ToString();
                if (key != String.Empty)
                {
                    parameters.Add(key, value);
                }
            }

            return parameters;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(comboBoxProjects.SelectedIndex > -1)
            {
                if(comboBoxTemplates.SelectedIndex > -1)
                {
                    Dictionary<string, string> parameters = ConvertGridToDictionary();
                    ProjectTemplate template = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                    Project project = (Project)comboBoxProjects.SelectedItem;
                    template.Parameters = parameters;

                    int index = project.ProjectTemplateList.FindIndex(x => x.TemplateName == template.TemplateName);
                    project.ProjectTemplateList[index] = template;

                    ProjectContainer.GetInstance().Save(ProjectContainer.GetInstance().FileLocation);
                    ProjectContainer.GetInstance().Load(ProjectContainer.GetInstance().FileLocation);
                    LoadForm();
                    Classes.Mediation.FormMediator.GetInstance().SendMessage("Project Template Saved");
                }
            }
        }

        private void linkLabelViewTemplate_Click(object sender, EventArgs e)
        {
            if(comboBoxTemplates.SelectedIndex > -1)
            {
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name.ToUpper() == projectTemplate.TemplateName.ToUpper()).FirstOrDefault();
                Forms.FormTextViewer textViewer = new Forms.FormTextViewer(template.TemplateText);
                textViewer.ShowDialog();
            }        
        }
    }
}

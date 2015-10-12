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
    public partial class Projects : UserControl
    {
        public Projects()
        {
            InitializeComponent();
            LoadForm();
            ProjectContainer.GetInstance().Reload += ProjectChanged;
        }

        private void ProjectChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ClearFields();
            Forms.FormItemName projectName = new Forms.FormItemName("Project Name");
            projectName.ShowDialog();
            if(projectName.Saved)
            {
                Create(projectName.Value);
            }
        }

        public void ClearFields()
        {
            textBoxName.Clear();
            comboBoxProjects.SelectedIndex = -1;
            UncheckAll();
        }

        private void LoadForm()
        {
            checkedListBoxTemplates.Items.Clear();//checkedlistbox doesn't support databinding
            foreach(Template template in TemplateContainer.GetInstance().TemplateList)
            {
                checkedListBoxTemplates.Items.Add(template.Name);
            }

            int currentSelectedProject = comboBoxProjects.SelectedIndex;
            comboBoxProjects.DataSource = new BindingList<string>(ProjectContainer.GetInstance().ProjectList.Select(x => x.Name).ToList());

            if (currentSelectedProject == -1 && comboBoxProjects.Items.Count > 0)
            {
                comboBoxProjects.SelectedIndex = 0;
            }
            else
            {
                comboBoxProjects.SelectedIndex = currentSelectedProject;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Save();
            }
        }

        private bool Validate()
        {
            if(String.IsNullOrEmpty(textBoxName.Text))
            {
                Classes.Mediation.FormMediator.GetInstance().SendError("Project Name is Required");
                return false;
            }
            return true;
        }

        private void Create(string projectName)
        {
            List<ProjectTemplate> templateList = new List<ProjectTemplate>();
            foreach (var item in checkedListBoxTemplates.CheckedItems)
            {
                ProjectTemplate projectTemplate = new ProjectTemplate();
                projectTemplate.TemplateName = item.ToString();
                projectTemplate.ScreenParameters["OutputDirectory"] = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "projects", textBoxName.Text, "Output");
                projectTemplate.ParametersTree = new System.Xml.Linq.XElement("parameterTree", "");
                System.Xml.Linq.XElement root = new System.Xml.Linq.XElement("root");
                root.SetAttributeValue("name", "root");
                root.Add(new System.Xml.Linq.XElement("children"));
                projectTemplate.ParametersTree.Add(root);
                templateList.Add(projectTemplate);
            }
            Project project = new Project();
            project.Name = projectName;
            project.ProjectTemplateList.Clear();
            project.ProjectTemplateList.AddRange(templateList);
            ProjectContainer.GetInstance().UpdateProject(project);
            ProjectContainer.GetInstance().Save();
            ProjectContainer.GetInstance().Reload(this, EventArgs.Empty);
            Classes.Mediation.FormMediator.GetInstance().SendMessage("Project Created");
        }
        private void Save()
        {
            if(comboBoxProjects.SelectedIndex > -1)
            {
                Project project = ProjectContainer.GetInstance().ProjectList.FirstOrDefault(x => x.Name == comboBoxProjects.SelectedItem.ToString());
                   
                List<string> checkedItems = new List<string>();
                foreach (var item in checkedListBoxTemplates.CheckedItems)
                {
                    checkedItems.Add(item.ToString());
                }
        
                project.ProjectTemplateList.RemoveAll(x => !checkedItems.Contains(x.TemplateName)); //if we unchecked a template remove it                   
                project.Name = textBoxName.Text;

                foreach(string templateName in checkedItems)
                {
                    if(!project.ProjectTemplateList.Any(x => x.TemplateName == templateName)) //iterate the list of checked items. If we're missing a template add it.
                    {
                        ProjectTemplate projectTemplate = new ProjectTemplate();
                        projectTemplate.ScreenParameters["OutputDirectory"] = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "projects", textBoxName.Text, "Output");
                        projectTemplate.ParametersTree = new System.Xml.Linq.XElement("parameterTree", "");
                        System.Xml.Linq.XElement root = new System.Xml.Linq.XElement("root");
                        root.SetAttributeValue("name", "root");
                        root.Add(new System.Xml.Linq.XElement("children"));
                        projectTemplate.ParametersTree.Add(root);
                        projectTemplate.TemplateName = templateName;
                        project.ProjectTemplateList.Add(projectTemplate);
                    }
                }
                    
                ProjectContainer.GetInstance().UpdateProject(project);
                ProjectContainer.GetInstance().Save();
                ProjectContainer.GetInstance().Reload(this, EventArgs.Empty);
                Classes.Mediation.FormMediator.GetInstance().SendMessage("Project Updated");
            }
        }

        private void UncheckAll()
        {
            for(int i=0; i < checkedListBoxTemplates.Items.Count;i++)
            {
                checkedListBoxTemplates.SetItemChecked(i, false);
            }
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedIndex > -1)
            {
                UncheckAll();

                textBoxName.Text = comboBoxProjects.SelectedItem.ToString();

                Project project = ProjectContainer.GetInstance().ProjectList.FirstOrDefault(x => x.Name == comboBoxProjects.SelectedItem.ToString());

                foreach(ProjectTemplate template in project.ProjectTemplateList.ToList())
                {
                    int index = checkedListBoxTemplates.FindStringExact(template.TemplateName);
                    if(index > -1)
                    {
                        checkedListBoxTemplates.SetItemChecked(index, true);
                    }
                }
            }
        }
    }
}

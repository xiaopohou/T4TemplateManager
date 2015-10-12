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
        delegate void GenerationCompleteCallBack();
        private Dictionary<string, string> _generationResults;
        public Generation()
        {
            InitializeComponent();
            LoadForm();
            ProjectContainer.GetInstance().Reload += ProjectChanged;
            this._generationResults = new Dictionary<string, string>();
        }

        private void ProjectChanged(object sender, EventArgs e)
        {
            LoadForm();
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
            this.tabControlOutput.Controls.Clear();
            if (comboBoxProjects.SelectedIndex > -1)
            {
                ProjectContainer.GetInstance().Load();
                TemplateContainer.GetInstance().Load();
                this._selectedProject = (Project)comboBoxProjects.SelectedItem;
                progressSpinnerGeneration.Visible = true;
                Action action = new Action(StartGeneration);
                Task generate = Task.Factory.StartNew(action).ContinueWith(x => GenerationComplete());
            }
        }

        private void GenerationComplete()
        {
            if (tabControlOutput.InvokeRequired || progressSpinnerGeneration.InvokeRequired)
            {
                GenerationCompleteCallBack d = new GenerationCompleteCallBack(GenerationComplete);
                this.Invoke(d);
            }
            else
            {
                foreach (string key in this._generationResults.Keys)
                {
                    TabPage newPage = new TabPage(key);
                    TextBox output = new TextBox();
                    output.ScrollBars = ScrollBars.Both;
                    output.Text = this._generationResults[key];
                    output.Multiline = true;
                    output.Dock = DockStyle.Fill;
                    newPage.Controls.Add(output);
                    tabControlOutput.TabPages.Add(newPage);
                }

                progressSpinnerGeneration.Visible = false;
            }
        }
        private void StartGeneration()
        {
            Classes.Mediation.FormMediator.GetInstance().SendMessage("Starting Generation");
            try
            {
               this._generationResults.Clear();
               Project project =ProjectContainer.GetInstance().ProjectList.ToList().Where(x => x == this._selectedProject).FirstOrDefault();
               Classes.Generation.GenerationParameterManager parameterManager = new GenerationParameterManager();
               parameterManager.TransformParameters(project);
               string workingDirectory = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "WorkingDirectory");
               Classes.Generation.GenerationManager generationManager = new GenerationManager();

                foreach (ProjectTemplate projectTemplate in project.ProjectTemplateList)
                {
                    Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name == projectTemplate.TemplateName).FirstOrDefault();
                    List<TemplateExecutionResult> results = generationManager.ExecuteForEachTemplate(workingDirectory, template, projectTemplate.TransformedParameters, projectTemplate.ParametersTree);

                    string resultDisplay = String.Empty;
                    foreach (TemplateExecutionResult result in results)
                    {
                        resultDisplay += result.TransformedText;
                        resultDisplay += result.ErrorMessage + Environment.NewLine;
                    }
                    this._generationResults[template.Name] = resultDisplay;
                    FormMediator.GetInstance().AddGenerationScreenMessage(resultDisplay);
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

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

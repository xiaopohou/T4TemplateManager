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
                textBoxResult.Text += me.Message + Environment.NewLine; ;
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
                ProjectContainer.GetInstance().Load();
                TemplateContainer.GetInstance().Load();
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
            try
            {
           
               Project project =ProjectContainer.GetInstance().ProjectList.ToList().Where(x => x == this._selectedProject).FirstOrDefault();
               Classes.Generation.GenerationParameterManager parameterManager = new GenerationParameterManager();
               parameterManager.TransformParameters(project);

                Classes.Generation.GenerationManager generationManager = new GenerationManager();

                foreach (ProjectTemplate projectTemplate in project.ProjectTemplateList)
                {
                    Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name == projectTemplate.TemplateName).FirstOrDefault();
                    List<TemplateExecutionResult> results = generationManager.ExecuteForEachTemplate(template, projectTemplate.TransformedParameters, projectTemplate.ParametersTree);


                    string resultDisplay = String.Empty;
                    foreach (TemplateExecutionResult result in results)
                    {
                        resultDisplay += result.TransformedText;
                        resultDisplay += result.ErrorMessage + Environment.NewLine;
                        resultDisplay += "-------------------------------------------------------------";
                    }
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

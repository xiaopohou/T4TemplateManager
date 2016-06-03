using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Codenesium.GenerationLibrary.Database;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class GenerationParameterManager
    {
        public void TransformParameters(Project project)
        {
            TransformPromptParameters(project);
            TransformDirectoryParameters(project);
            TransformFileParameterTree(project);
        }

        private void TransformPromptParameters(Project project)
        {
            foreach (ProjectTemplate projectTemplate in project.ProjectTemplateList)
            {
                foreach (string key in projectTemplate.ScreenParameters.Keys)
                {
                    if (projectTemplate.ScreenParameters[key].ToString().ToUpper() == "PROMPT")
                    {
                        projectTemplate.TransformedParameters[key] = TranformPromptParameter(key,projectTemplate.TemplateName);
                    }
                    else
                    {
                        projectTemplate.TransformedParameters[key] = projectTemplate.ScreenParameters[key];
                    }
                }
            }
        }

        //this sucks so bad but we will have to fix it later...
        private string TranformPromptParameter(string key,string templateName)
        {
            Forms.ParameterPrompt formParameterPrompt = new Forms.ParameterPrompt(key,templateName);
            formParameterPrompt.ShowDialog();
            return formParameterPrompt.Value;
        }

       
        private void TransformFileParameterTree(Project project)
        {
            foreach (ProjectTemplate projectTemplate in project.ProjectTemplateList)
            {
                projectTemplate.TransformedParameters["TREEPARAMETER"] = projectTemplate.ParametersTree.ToString();
            }
        }

        private void TransformDirectoryParameters(Project project)
        {
            foreach (ProjectTemplate projectTemplate in project.ProjectTemplateList)
            {
                foreach (string key in projectTemplate.ScreenParameters.Keys)
                {
                    if (key == "ASSETSFILE")
                    {
                        projectTemplate.TransformedParameters[key] = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "assets", project.Name, projectTemplate.ScreenParameters[key].ToString());
                    }
                    if (key == "OUTPUTDIRECTORY")
                    {
                        projectTemplate.TransformedParameters[key] = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "output", project.Name, projectTemplate.ScreenParameters[key].ToString());
                    }
                }
            }
        }
    }
}

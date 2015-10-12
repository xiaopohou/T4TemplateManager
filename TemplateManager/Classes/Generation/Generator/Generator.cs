using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class Generator
    {
        private Template _template { get; set; }
        private Dictionary<string, object> _parameters { get; set; }
        private string _workingDirectory{get;set;}
        public Generator(Template template, Dictionary<string, object> parameters,string workingDirectory)
        {
            this._template = template;
            this._parameters = parameters;
            this._workingDirectory = workingDirectory;
        }

        private TextTemplatingSession CreateSession(Dictionary<string, object> parameters)
        {
            TextTemplatingSession session = new TextTemplatingSession();
            foreach (string key in parameters.Keys)
            {
                session.Add(key, parameters[key]);
            }
            return session;
        }

        private string WriteTemplateToDisk(string workingDirectory, string templateText)
        {
            if (!Directory.Exists(workingDirectory))
            {
                Directory.CreateDirectory(workingDirectory);
            }
            //write the template to file to read back later and processed
            string path = Path.Combine(workingDirectory, Classes.Utility.RandomNumber.GetRandomNumber().ToString() + "temp.tt");
            File.WriteAllText(path, templateText.Trim());
            return path;
        }

        private string GetErrors(Classes.Generation.CustomGenerationHost host)
        {
            string result = String.Empty;
            foreach (CompilerError item in host.Errors)
            {
                if (!item.IsWarning)
                {
                    result += item.ToString() + Environment.NewLine;
                }
            }
            return result;
        }

        public TemplateExecutionResult ExecuteTemplateCustomHost()
        {
            try
            {
                TemplateExecutionResult result = new TemplateExecutionResult();
                Engine engine = new Engine();
                Classes.Generation.CustomGenerationHost host = new Classes.Generation.CustomGenerationHost();
                host.TemplateFileValue = WriteTemplateToDisk(this._workingDirectory, this._template.TemplateText);
                host.Session = CreateSession(this._parameters);

                result.TransformedText = engine.ProcessTemplate(this._template.TemplateText, host).Trim();
                result.ErrorMessage = GetErrors(host);
                result.Success = true;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

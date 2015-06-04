using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Codenesium.GenerationLibrary.Generation;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class ProjectTemplate
    {
        public string TemplateName { get;set; }
        public Dictionary<string, object> ScreenParameters; //shown in the screen
        public Dictionary<string, object> TransformedParameters; //processed to replace prompt and connectionString placeholders
        public XElement ParametersTree;
        
        public ProjectTemplate()
        {
            this.TemplateName = String.Empty;
            this.ScreenParameters = new Dictionary<string, object>();
            this.TransformedParameters = new Dictionary<string, object>();
        }

        public XElement Export()
        {
            XElement response = new XElement("projectTemplate");
            response.Add(new XElement("templateName", this.TemplateName));

            XElement parameters = new XElement("parameters");
            foreach(string key in this.ScreenParameters.Keys)
            {
                XElement item = new XElement("parameter");
                item.Add(new XElement("key", key));
                item.Add(new XElement("value", this.ScreenParameters[key]));
                parameters.Add(item);
            }
            response.Add(this.ParametersTree);

            response.Add(parameters);
            return response;
        }
    }
}

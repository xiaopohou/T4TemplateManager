using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class ProjectTemplate
    {
        public string TemplateName { get;set; }
        public Dictionary<string, string> Parameters;
        public ProjectTemplate()
        {
            this.TemplateName = String.Empty;
            this.Parameters = new Dictionary<string, string>();
        }

        public XElement Export()
        {
            XElement response = new XElement("projectTemplate");
            response.Add(new XElement("templateName", this.TemplateName));

            XElement parameters = new XElement("parameters");
            foreach(string key in this.Parameters.Keys)
            {
                XElement item = new XElement("parameter");
                item.Add(new XElement("key", key));
                item.Add(new XElement("value", this.Parameters[key]));
                parameters.Add(item);
            }

            response.Add(parameters);
            return response;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class Project
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<ProjectTemplate> ProjectTemplateList { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; }

        public Project()
        {
            this.ID = Guid.Empty;
            this.Name = String.Empty;
            this.ProjectTemplateList = new List<ProjectTemplate>();
            this.ConnectionStrings = new Dictionary<string, string>();
        }

        public XElement Export()
        {
            XElement response = new XElement("project");
            response.Add(new XElement("id", this.ID.ToString()));
            response.Add(new XElement("name", this.Name));

            XElement projectTemplates = new XElement("projectTemplates");
            foreach(ProjectTemplate template in this.ProjectTemplateList)
            {
                projectTemplates.Add(template.Export());
            }
            response.Add(projectTemplates);


            XElement parameters = new XElement("connectionStrings");
            foreach (string key in this.ConnectionStrings.Keys)
            {
                XElement item = new XElement("connectionString");
                item.Add(new XElement("key", key));
                item.Add(new XElement("value", this.ConnectionStrings[key]));
                parameters.Add(item);
            }
            response.Add(parameters);

            return response;
        }
    }
}

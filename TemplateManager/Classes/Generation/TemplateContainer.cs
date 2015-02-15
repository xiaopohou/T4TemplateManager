using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class TemplateContainer
    {
        public string FileLocation = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), TemplateContainer.Filename);
        public List<Template> TemplateList{get;set;}
        public static string Filename = "templates.xml";
        private static TemplateContainer _templateContainer;

        public  static TemplateContainer GetInstance()
        {
            if(_templateContainer == null)
            {
                _templateContainer = new TemplateContainer();
            }
            return _templateContainer;
        }

        private TemplateContainer()
        {
            this.TemplateList = new List<Template>();
        }

        public bool Load(string filename)
        {
            try
            {
                XDocument xDoc = XDocument.Load(filename);

                this.TemplateList = (from template in xDoc.Root.Element("templates").Descendants("template")
                                          select new Template
                                          {
                                              Name = (string)template.Element("name").Value ?? string.Empty,
                                              Description = (string)template.Element("description").Value ?? string.Empty,
                                              TemplateText = (string)template.Element("templateText").Value ?? string.Empty,
                                              FileExtension = (string)template.Element("fileExtension").Value ?? string.Empty,
                                              PerTableTemplate = Convert.ToBoolean(template.Element("perTableTemplate").Value),
                                              Parameters = (from p in template.Element("parameters").Descendants("parameter")
                                                            select p.Element("name").Value).ToList()

                                          }).ToList<Template>();
                    return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}

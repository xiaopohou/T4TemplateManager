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
        public string TemplateRootDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "templates");
        public List<Template> TemplateList{get;set;}
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

        public bool Load(string templatesRootPath)
        {
            this.TemplateList = new List<Template>();
            try
            {

                string[] directories = Directory.GetDirectories(templatesRootPath);

                foreach (string directory in directories)
                {
                    XDocument xDoc = XDocument.Load(Path.Combine(directory,"template.xml"));

                    string templateText = File.ReadAllText(Path.Combine(directory, "template.tt"));

                    Template template = (from t in xDoc.Root.Descendants("template")
                                         select new Template
                                         {
                                             Name = (string)t.Element("name").Value ?? string.Empty,
                                             Description = (string)t.Element("description").Value ?? string.Empty,
                                             FileExtension = (string)t.Element("fileExtension").Value ?? string.Empty,
                                             PerTableTemplate = Convert.ToBoolean(t.Element("perTableTemplate").Value),
                                             TemplateText = templateText
                                         }).FirstOrDefault();
                    this.TemplateList.Add(template);
                  
                }
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}

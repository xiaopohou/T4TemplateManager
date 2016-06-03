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
        public string TemplateRootDirectory { get; set; }
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
            this.TemplateRootDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "templates");
        }

        public void Load()
        {
            this.TemplateList = new List<Template>();
            try
            {
                TemplateFixer templateFixer = new TemplateFixer();
                templateFixer.FixTemplates(Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "templates")); //copy and rename ttt templates

                if(!Directory.Exists(TemplateRootDirectory))
                {
                    Directory.CreateDirectory(TemplateRootDirectory);
                }

                string[] directories = Directory.GetDirectories(TemplateRootDirectory);

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
                                             TemplateText = templateText
                                         }).FirstOrDefault();
                    this.TemplateList.Add(template);
                  
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

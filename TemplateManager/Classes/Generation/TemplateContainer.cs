using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class TemplateContainer
    {
        public List<Template> TemplateList{get;set;}

        public TemplateContainer()
        {
            this.TemplateList = new List<Template>();
        }

        public static TemplateContainer Factory(string filename)
        {
            TemplateContainer container = new TemplateContainer();

            try
            {
                XDocument xDoc = XDocument.Load(filename);

                container.TemplateList = (from template in xDoc.Descendants("template")
                                          select new Template
                                          {
                                              Name = (string)template.Element("name").Value ?? string.Empty,
                                              OutputDirectory = (string)template.Element("outputDirectory").Value ?? string.Empty,
                                              TemplateText = (string)template.Element("templateText").Value ?? string.Empty,
                                              Filename = (string)template.Element("fileName").Value ?? string.Empty,
                                              FileExtension = (string)template.Element("fileExtension").Value ?? string.Empty,
                                              PerTableTemplate = Convert.ToBoolean(template.Element("perTableTemplate").Value),
                                              DataInterface = template.Element("dataInterface").Value ?? string.Empty,
                                              Parameters = (from p in template.Element("parameters").Descendants("parameter")
                                                            select new 
                                                            {
                                                                key = (string)p.Element("key").Value ?? string.Empty,
                                                                value = (string)p.Element("value").Value ?? string.Empty
                                                            }).ToDictionary(pair => pair.key,pair => pair.value)
                                          }).ToList<Template>();
            }
            catch(Exception ex)
            {
                throw;
            }
            return container;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Codenesium.TemplateGenerator.Classes.Generation;
using Codenesium.GenerationLibrary;
using Codenesium.GenerationLibrary.Generation;
namespace Codenesium.TemplateGenerator.Classes.Generation.Parameters
{
    public class ParameterTreeParser
    {
        public List<Parameter> Parameters;

        public ParameterTreeParser()
        {
            this.Parameters = new List<Parameter>();
        }

        public XElement Traverse(XElement xParameter)
        {
            try
            {
                XElement newParameter = new XElement("parameter");
                bool children = xParameter.Elements("children").Any();
                if (children)
                {
                    foreach (XElement child in xParameter.Elements("children").Elements("parameter"))
                    {
                        newParameter.Add(Traverse(child));
                    }

           
                }
                else
                {
                    newParameter.Add(new XElement("key", xParameter.Element("key").Value));
                    newParameter.Add(new XElement("value", xParameter.Element("value").Value));
                }
                return newParameter;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

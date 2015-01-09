using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class Template
    {
        public string Name { get; set; }
        public string TemplateText{ get; set; }
        public string OutputDirectory{ get; set; }
        public string Filename { get; set; }
        public string FileExtension { get; set; }
        public string DataInterface { get; set; }
        public bool PerTableTemplate { get; set; }
        public Dictionary<string, string> Parameters;

        public Template()
        {
            this.Name = String.Empty;
            this.TemplateText = String.Empty;
            this.OutputDirectory = String.Empty;
            this.Filename = String.Empty;
            this.FileExtension = string.Empty;
            this.PerTableTemplate = false;
            this.DataInterface = String.Empty;
            this.Parameters = new Dictionary<string, string>();
        }
    }
}

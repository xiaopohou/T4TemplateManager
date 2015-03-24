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
        public string FileExtension { get; set; }
        public bool PerTableTemplate { get; set; }
        public string Description { get; set; }


        public Template()
        {
            this.Name = String.Empty;
            this.TemplateText = String.Empty;
            this.FileExtension = string.Empty;
            this.PerTableTemplate = false;
            this.Description = String.Empty;
        }
    }
}

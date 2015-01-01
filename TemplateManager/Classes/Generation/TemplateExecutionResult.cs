using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Generation
{

    /// <summary>
    /// This class is returned when you execute a template. Result is whether the execution succeeded. 
    /// TransformedText is the response from the template.
    /// ErrorMessage is the exception information if there was an exception.
    /// </summary>
    public class TemplateExecutionResult
    {
       public bool Success { get; set; }
       public string TransformedText { get; set; }
       public string ErrorMessage { get; set; }
    }
}

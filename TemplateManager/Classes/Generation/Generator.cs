using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class Generator
    {

        public string Contents { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string DatabaseInterface { get; set; }
        public string ConnectionString { get; set; }
        public TemplateExecutionResult ExecutionResult { get; set; }
        /// <summary>
        /// This function takes a prepared T4 template and executes it returning the result.
        /// We expect a T4 template here. Since I want to be able to pass these at runtime we just have to hope you're sending a valid file.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public TemplateExecutionResult ExecuteTemplate(dynamic template)
        {
            TemplateExecutionResult result = new TemplateExecutionResult();
            try
            {
                result.Success = true;
                result.TransformedText = template.TransformText();
                return result;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "Error transforming text:" + ex.ToString();
                return result;
            }
        }

        

        public void ExecuteTemplateCustomHost()
        {
            try
            {
                TemplateExecutionResult result = new TemplateExecutionResult();
                Engine engine = new Engine();
                Classes.Generation.CustomGenerationHost host = new Classes.Generation.CustomGenerationHost();
                TextTemplatingSession session = new TextTemplatingSession();
                string tempPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Classes.Utility.RandomNumber.GetRandomNumber().ToString() + "temp.tt");
                File.WriteAllText(tempPath, this.Contents.Trim());
                host.TemplateFileValue = tempPath;

                if (this.DatabaseInterface == "MSSQL")
                {
                    //We're going to load fields and tables by default if it's possible
                    Classes.Database.MSSQL MSSQLInterface = new Classes.Database.MSSQL(this.ConnectionString);
                    if (this.Parameters.Keys.Contains("DatabaseTable"))
                    {
                        List<Interfaces.IDatabaseField> fieldList = MSSQLInterface.GetFieldList(this.Parameters["DatabaseTable"]);
                        session.Add("CNFieldList", fieldList);
                    }
                    List<Interfaces.IDatabaseTable> tableList = MSSQLInterface.GetTableList();
                    session.Add("CNTableList", tableList);
                }

                //add all other parameters
                foreach (string key in this.Parameters.Keys)
                {
                    session.Add(key, this.Parameters[key]);
                }

                host.Session = session;
                result.TransformedText = engine.ProcessTemplate(this.Contents, host).Trim();

                foreach (CompilerError item in host.Errors)
                {
                    result.ErrorMessage += item.ToString() + Environment.NewLine;
                }
                result.Success = true;
                File.Delete(tempPath);
                this.ExecutionResult = result;
            }
            catch(Exception ex)
            {
                throw;
            }
            }

       
    }
}

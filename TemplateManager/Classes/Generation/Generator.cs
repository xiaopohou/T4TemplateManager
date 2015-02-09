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
using Codenesium.TemplateGenerator.Classes.Database;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class Generator
    {
        public string OutputDirectory { get; set; }
        public Template @Template { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public  DATAINTERFACE DataInterface { get; set; }
        public string ConnectionString { get; set; }
        public TemplateExecutionResult ExecutionResult { get; set; }
        public bool WriteToDisk { get; set; }
        public Generator()
        {
            this.Parameters = new Dictionary<string, string>();
            this.DataInterface = DATAINTERFACE.NONE;
            this.ConnectionString = String.Empty;
            this.ExecutionResult = null;
            this.OutputDirectory = String.Empty;
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
                File.WriteAllText(tempPath, this.Template.TemplateText.Trim());
                host.TemplateFileValue = tempPath;
                if (this.DataInterface == DATAINTERFACE.MSSQL)
                {
                    //We're going to load fields and tables by default if it's possible
                    Classes.Database.MSSQL MSSQLInterface = new Classes.Database.MSSQL(this.ConnectionString);
                    if (this.Parameters.Keys.Contains("DatabaseTable"))
                    {
                        List<Interfaces.IDatabaseField> fieldList = MSSQLInterface.GetFieldList(this.Parameters["DatabaseTable"]);
                        Interfaces.IDatabaseTable table = MSSQLInterface.GetTableList().Where(x => x.Name == this.Parameters["DatabaseTable"]).FirstOrDefault();
                        session.Add("CNTable", table);
                    }
                    List<Interfaces.IDatabaseTable> tableList = MSSQLInterface.GetTableList();
                    session.Add("CNTableList", tableList);
                }
                else if (this.DataInterface == DATAINTERFACE.FILE)
                {
                    throw new NotImplementedException();
                }
                else if (this.DataInterface == DATAINTERFACE.NONE)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }

                //add all other parameters
                foreach (string key in this.Parameters.Keys)
                {
                    session.Add(key, this.Parameters[key]);
                }

                host.Session = session;
                result.TransformedText = engine.ProcessTemplate(this.Template.TemplateText, host).Trim();

                foreach (CompilerError item in host.Errors)
                {
                    if (!item.IsWarning)
                    {
                        result.ErrorMessage += item.ToString() + Environment.NewLine;
                    }
                }
                result.Success = true;
                File.Delete(tempPath);

                this.ExecutionResult = result;

                if (this.WriteToDisk)
                {
                    if (this.Parameters.ContainsKey("DatabaseTable"))
                    {
                        this.ProcessResult(this.Parameters["DatabaseTable"]);
                    }
                    else
                    {
                        this.ProcessResult("output");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ProcessResult(string table)
        {
            if (!String.IsNullOrEmpty(this.OutputDirectory))
            {
                if (!Directory.Exists(this.OutputDirectory))
                {
                    Directory.CreateDirectory(this.OutputDirectory);
                }

                if (!String.IsNullOrEmpty(this.Template.Name))
                {
                    string filename = String.Empty;
                    if (this.Template.Name.ToUpper() == "TEMPLATEBOREPOSITORY")
                    {
                        filename = Path.Combine(this.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToRepositoryName(table)) + this.Template.FileExtension;
                    }
                    else if (this.Template.Name.ToUpper() == "TEMPLATEBOREPOSITORYINTERFACE")
                    {
                        filename = Path.Combine(this.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToRepositoryInterfaceName(table)) + this.Template.FileExtension;
                    }
                    else if (this.Template.Name.ToUpper() == "TEMPLATEBOOBJECT")
                    {
                        filename = Path.Combine(this.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToBasicObjectName(table)) + this.Template.FileExtension;
                    }
                    else if (this.Template.Name.ToUpper() == "TEMPLATEBOINTERFACE")
                    {
                        filename = Path.Combine(this.OutputDirectory, Classes.Generation.Helpers.CommonHelper.ConvertTableNameToBasicObjectInterfaceName(table)) + this.Template.FileExtension;
                    }
                    else
                    {
                        filename = Path.Combine(this.OutputDirectory, table + this.Template.FileExtension);
                    }
                    File.WriteAllText(filename, this.ExecutionResult.TransformedText);

                }
            }
        }
    }
}

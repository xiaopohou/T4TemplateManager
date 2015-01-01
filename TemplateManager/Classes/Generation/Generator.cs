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

namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class Generator
    {
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

        /// <summary>
        /// This function makes a comma separated list of parameters like you would see in a .NET function prototype
        /// Example string param1,int param2,long param3
        /// </summary>
        /// <param name="fieldList"></param>
        /// <returns></returns>
        public static string GenerateFunctionParameterList(List<Interfaces.IDatabaseField> fieldList)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fieldList)
            {
                switch (field.FieldType)
                {
                    case DbType.String:
                        {
                            response += "string";
                            break;
                        }
                    case DbType.DateTime:
                        {
                            response += "DateTime?";
                            break;
                        }
                    case DbType.Int32:
                        {
                            response += "int";
                            break;
                        }
                    case DbType.Int64:
                        {
                            response += "long";
                            break;
                        }
                    case DbType.Boolean:
                        {
                            response += "bool";
                            break;
                        }
                    case DbType.Decimal:
                        {
                            response += "decimal";
                            break;
                        }
                }
                response += " " + field.Name + ",";
            }
            return response.Remove(response.Length-1,1);
        }

        /// <summary>
        /// Utility function to convert underscore to camelCase. I see underscores between parameters a lot in sql databases.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertUnderscoreToCamelCase(string value)
        {
            string response = String.Empty;
            string[] split = value.Split('_');
            if (split.Length == 1)
            {
                response = value[0].ToString().ToUpper() + value.Substring(1);
            }
            else
            {
                foreach (string item in split)
                {
                    response += item[0].ToString().ToUpper() + item.Substring(1);
                }
            }
            return response;
        }

        /// <summary>
        /// This function generates the property declaration for a field. This violates the open/closed principle but I'm not sure I care.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GenerateSQLFieldProperty(Interfaces.IDatabaseField field)
        {
            string response = String.Empty;
            switch (field.FieldType)
            {
                case DbType.String:
                    {
                        response =  "public string " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "public DateTime? " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "public TimeSpan? " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "public int " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Int64:
                    {
                        response = "public long " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "public bool " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "public decimal " + ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
            }
            return response; 
        }

        public TemplateExecutionResult ExecuteTemplateCustomHost(string path, string parametersString, string databaseInterface, string connectionString)
        {

            TemplateExecutionResult result = new TemplateExecutionResult();
            Engine engine = new Engine();
            string contents = File.ReadAllText(path);
            Classes.Generation.CustomGenerationHost host = new Classes.Generation.CustomGenerationHost();
            host.TemplateFileValue = path;
            TextTemplatingSession session = new TextTemplatingSession();
            Dictionary<string, string> parameters = Classes.Generation.Parameter.ParseParameters(parametersString);

            if (databaseInterface == "MSSQL")
            {
                //We're going to load fields and tables by default if it's possible
                Classes.Database.MSSQL MSSQLInterface = new Classes.Database.MSSQL(connectionString);
                if (parameters.Keys.Contains("DatabaseTable"))
                {
                    List<Interfaces.IDatabaseField> fieldList = MSSQLInterface.GetFieldList(parameters["DatabaseTable"]);
                    session.Add("FieldList", fieldList);
                }
                List<Interfaces.IDatabaseTable> tableList = MSSQLInterface.GetTableList();
                session.Add("TableList", tableList);
            }

            //add all other parameters
            foreach (string key in parameters.Keys)
            {
                session.Add(key, parameters[key]);
            }

            host.Session = session;
            result.TransformedText = engine.ProcessTemplate(contents, host);
           
            foreach (CompilerError item in host.Errors)
            {
                result.ErrorMessage += item.ToString() + Environment.NewLine;
            }
            result.Success = true;
            return result;
        }
    }
}

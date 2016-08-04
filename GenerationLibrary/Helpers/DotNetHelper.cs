using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Codenesium.GenerationLibrary.Generation.Helpers
{
    public class DotNetHelper
    {
        public static string GenerateInterfacePropertyForList(List<Interfaces.IDatabaseField> fields)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                response += GenerateInterfaceFieldProperty(field) + Environment.NewLine;
            }
            return response;
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
                if (field.Name.ToUpper() == "ID" || field.Name.ToUpper() == "RECORDSTATUS")
                {
                    continue;
                }

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
                    case DbType.Double:
                        {
                            response += "double";
                            break;
                        }
                }
                response += " " + field.Name + ",";
            }
            return response.Remove(response.Length - 1, 1);
        }

        public static string GenerateInterfaceFieldProperty(Interfaces.IDatabaseField field)
        {
            string response = String.Empty;
            switch (field.FieldType)
            {
                case DbType.String:
                    {
                        response = "string " + field.Name + "{get;set;}";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "DateTime? " + field.Name+ "{get;set;}";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "TimeSpan? " + field.Name + "{get;set;}";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "int " + field.Name + "{get;set;}";
                        break;
                    }
                case DbType.Int64:
                    {
                        response = "long " + field.Name + "{get;set;}";
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "bool " + field.Name + "{get;set;}";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "decimal " + field.Name + "{get;set;}";
                        break;
                    }
                case DbType.Double:
                    {
                        response = "double " + field.Name + "{get;set;}";
                        break;
                    }
            }
            return response;
        }

        /// <summary>
        /// This function generates the property declaration for a field. This violates the open/closed principle but I'm not sure I care.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GenerateFieldProperty(string name,DbType fieldType)
        {
            string response = String.Empty;
            switch (fieldType)
            {
                case DbType.AnsiString:
                case DbType.StringFixedLength:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                    {
                        response = "public string " +name+ "{get; set;}";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "public DateTime? " +name+ "{get; set;}";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "public TimeSpan? " +name+ "{get; set;}";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "public int " +name+ "{get; set;}";
                        break;
                    }
                case DbType.Int64:
                    {
                        response = "public long " +name+ "{get; set;}";
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "public bool " +name+ "{get; set;}";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "public decimal " +name+ "{get; set;}";
                        break;
                    }
                case DbType.Double:
                    {
                        response = "public double " +name+ "{get; set;}";
                        break;
                    }
                default:
                    {
                       
                        throw new NotImplementedException();
                    }
            }
            return response;
        }

        public static string GenerateFieldConversion(DbType fieldType,string data)
        {
            string response = String.Empty;
            switch (fieldType)
            {
                case DbType.AnsiString:
                case DbType.StringFixedLength:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                    {
                        response = "(string)" + data;
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "DateTime.Parse(" + data + ")";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "TimeSpan.Parse(" + data + ")";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "Convert.ToInt32(" + data + ")" ;
                        break;

                    }
                case DbType.Int64:
                    {
                        response = "(long)" + data;
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "(bool)" + data ;
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "decimal.Parse(" + data + ")" ;
                        break;
                    }
                case DbType.Double:
                    {
                        response = "double.Parse(" + data + ")";
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
            return response;
        }

        public static string GenerateFieldPropertyType(DbType fieldType)
        {
            string response = String.Empty;
            switch (fieldType)
            {
                case DbType.AnsiString:
                case DbType.StringFixedLength:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                    {
                        response = "string";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "DateTime?";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "TimeSpan?";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "int";
                        break;
                    }
                case DbType.Int64:
                    {
                        response = "long";
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "bool";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "decimal";
                        break;
                    }
                case DbType.Double:
                    {
                        response = "double";
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
            return response;
        }


        public static string GenerateFieldAssignments(List<GenerationParameter> fields, string leftObject, string rightObject,bool uppercaseLeftField,bool upperCaseRightField)
        {
            string response = String.Empty;
            foreach (GenerationParameter field in fields)
            {

                string leftField = String.Empty;
                string rightField = String.Empty;

                leftField  = field.Name;
                rightField = field.Name;

                if(uppercaseLeftField)
                {
                    leftField = leftField.ToUpperCaseFirstLeter();
                }
                if(upperCaseRightField)
                {
                   rightField = rightField.ToUpperCaseFirstLeter();
                }

                response += GenerateFieldAssignment(leftField, rightField, leftObject, rightObject) + ";" + Environment.NewLine;
            }
            return response;
        }

        public static string GenerateFieldAssignment(string leftFieldName,string rightFieldName, string leftObject, string rightObject)
        {

            string processedLeftSide = String.Empty;

            string processedRightSide = String.Empty;
            if(String.IsNullOrEmpty(leftObject))
            {
                processedLeftSide = leftFieldName;
            }
            else
            {
                processedLeftSide = leftObject + "." + leftFieldName;
            }

            if (String.IsNullOrEmpty(rightObject))
            {
                processedRightSide = rightFieldName;
            }
            else
            {
                processedRightSide = rightObject + "." + rightFieldName;
            }

            return processedLeftSide + " = " + processedRightSide;


        }

        public static string GenerateFieldAssignmentsLeftSideNoCamelCase(List<Interfaces.IDatabaseField> fields, string recordName, string queryName)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                if (field.Name.ToUpper() == "RECORDSTATUS")
                {
                    continue;
                }
                response += GenerateFieldAssignmentLeftSideNoCamelCase(field, recordName, queryName) + ";" + Environment.NewLine;
            }
            return response;
        }

        public static string GenerateFieldAssignmentLeftSideNoCamelCase(Interfaces.IDatabaseField field, string recordName, string queryName)
        {
            string response = String.Empty;
            switch (field.FieldType)
            {
                default:
                    {
                        response = recordName + "." +   field.Name + " = " + queryName + "." + field.Name;
                        break;
                    }
            }
            return response;
        }

        public static string GenerateReverseFieldAssignmentsLeftSideNoCamelCase(List<Interfaces.IDatabaseField> fields, string recordName, string queryName)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                if (field.Name.ToUpper() == "RECORDSTATUS")
                {
                    continue;
                }
                response += GenerateReverseFieldAssignmentLeftSideNoCamelCase(field, recordName, queryName) + ";" + Environment.NewLine;
            }
            return response;
        }

        public static string GenerateReverseFieldAssignmentLeftSideNoCamelCase(Interfaces.IDatabaseField field, string recordName, string queryName)
        {
            string response = String.Empty;

            switch (field.FieldType)
            {
                case DbType.String:
                    {
                        response = recordName + "." + field.Name + " = (string)" + queryName + "." + field.Name;
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = recordName + "." + field.Name + " = " + queryName + "." + field.Name;
                        break;
                    }
                case DbType.Binary:
                    {
                        response = recordName + "." + field.Name + " = (TimeSpan)" + queryName + "." + field.Name;
                        break;
                    }
                case DbType.Int32:
                    {
                        response = recordName + "." + field.Name + " = (int)" + queryName + "." + field.Name;
                        break;
                    }
                case DbType.Int64:
                    {
                        response = recordName + "." + field.Name + " = (long)" + queryName + "." + field.Name;
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = recordName + "." + field.Name + " = Convert.ToBoolean(" + queryName + "." + field.Name;
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = recordName + "." + field.Name + " = (decimal)" + queryName + "." + field.Name;
                        break;
                    }
                case DbType.Double:
                    {
                        response = recordName + "." + field.Name + " = (double)" + queryName + "." + field.Name;
                        break;
                    }
            }
            return response;
        }

        public static string GenerateFieldAssignmentsSimple(List<GenerationParameter> fields, string recordName)
        {
            string response = String.Empty;
            foreach (GenerationParameter field in fields)
            {
                if (field.Name.ToUpper() == "RECORDSTATUS")
                {
                    continue;
                }
                response += GenerateFieldAssignmentSimple(field, recordName) + ";" + Environment.NewLine;
            }
            return response;
        }


        public static string GenerateFieldAssignmentSimple(GenerationParameter field, string recordName)
        {
            return recordName + "." + field.Name + " = " + field.Name;
        }

        public static string GenerateSQLinqFields(List<Interfaces.IDatabaseField> fields, string tableName)
        {
            string response = String.Empty;
            for (int i = 0; i < fields.Count; i++)
            {
                response += GenerateSQLinqField(fields[i], tableName);
                if (i == fields.Count - 1)
                {
                    response += Environment.NewLine;
                }
                else
                {
                    response += "," + Environment.NewLine;
                }
            }

            return response;
        }

        public static string GenerateSQLinqField(Interfaces.IDatabaseField field, string tableName)
        {
            //linq_fields += this._field_list[i].Name + " = (string)(" + LinqAbbreviation(this._table_name) + "." + this._field_list[i].Name + " ?? \"\")";
            string response = String.Empty;
            switch (field.FieldType)
            {
                case DbType.String:
                    {
                        response = field.Name + " = (string)" + LinqAbbreviation(tableName) + "." + field.Name + @" ?? """"";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = field.Name + " = (DateTime)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Binary:
                    {
                        response = field.Name + " = (TimeSpan)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Int32:
                    {
                        response = field.Name + " = (int)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Int64:
                    {
                        response = field.Name + " = (long)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = field.Name + " = Convert.ToBoolean(" + LinqAbbreviation(tableName) + "." + field.Name + @")";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = field.Name + " = (decimal)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Double:
                    {
                        response = field.Name + " = (double)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
            }
            return response;
        }

        public static string LinqAbbreviation(string tableName)
        {
            if (tableName.Length < 3)
            {
                return tableName.ToLower();
            }
            else
            {
                return tableName.ToLower().Substring(0, 3);
            }
        }
    }
}

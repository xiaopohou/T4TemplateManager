﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Codenesium.TemplateGenerator.Classes.Generation.Helpers
{
   public  class DotNetHelper
    {
        public static string GenerateFieldPropertyForList(List<Interfaces.IDatabaseField> fields)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                response += GenerateFieldProperty(field) + Environment.NewLine;
            }
            return response;
        }



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
                        response = "string " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "DateTime? " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "TimeSpan? " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "int " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Int64:
                    {
                        response = "long " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "bool " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "decimal " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
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
        public static string GenerateFieldProperty(Interfaces.IDatabaseField field)
        {
            string response = String.Empty;
            switch (field.FieldType)
            {
                case DbType.String:
                    {
                        response = "public string " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = "public DateTime? " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Binary:
                    {
                        response = "public TimeSpan? " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Int32:
                    {
                        response = "public int " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Int64:
                    {
                        response = "public long " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = "public bool " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = "public decimal " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + "{get;set;}";
                        break;
                    }
            }
            return response;
        }


        public static string GenerateFieldAssignments(List<Interfaces.IDatabaseField> fields, string recordName, string queryName)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                if (field.Name.ToUpper() == "ID" || field.Name.ToUpper() == "RECORDSTATUS")
                {
                    continue;
                }
                response += GenerateFieldAssignment(field, recordName, queryName) + ";" + Environment.NewLine;
            }
            return response;
        }
        public static string GenerateFieldAssignment(Interfaces.IDatabaseField field, string recordName, string queryName)
        {
            string response = String.Empty;
            switch (field.FieldType)
            {
                case DbType.DateTime:
                    {
                        response =  recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (DateTime)" + queryName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name);
                        break;
                    }
                default:
                    {
                        response =  recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = " + queryName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name);
                        break;
                    }
            }
            return response;

        }




        public static string GenerateFieldAssignmentsLeftSideNoCamelCase(List<Interfaces.IDatabaseField> fields, string recordName, string queryName)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                if (field.Name.ToUpper() == "ID" || field.Name.ToUpper() == "RECORDSTATUS")
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
                case DbType.DateTime:
                    {
                        response = recordName + "." + field.Name + " = (DateTime)" + queryName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name);
                        break;
                    }
                default:
                    {
                        response = recordName + "." + field.Name + " = " + queryName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name);
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
                if (field.Name.ToUpper() == "ID" || field.Name.ToUpper() == "RECORDSTATUS")
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
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (string)" + queryName + "." + field.Name;
                         break;
                     }
                 case DbType.DateTime:
                     {
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (DateTime)" + queryName + "." + field.Name;
                         break;
                     }
                 case DbType.Binary:
                     {
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (TimeSpan)" + queryName + "." + field.Name;
                         break;
                     }
                 case DbType.Int32:
                     {
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (int)" + queryName + "." + field.Name;
                         break;
                     }
                 case DbType.Int64:
                     {
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (long)" + queryName + "." + field.Name;
                         break;
                     }
                 case DbType.Boolean:
                     {
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = Convert.ToBoolean(" + queryName + "." + field.Name;
                         break;
                     }
                 case DbType.Decimal:
                     {
                         response = recordName + "." + CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (decimal)" + queryName + "." + field.Name;
                         break;
                     }
             }
                    return response;

        }


        public static string GenerateFieldAssignmentsSimple(List<Interfaces.IDatabaseField> fields, string recordName)
        {
            string response = String.Empty;
            foreach (Interfaces.IDatabaseField field in fields)
            {
                if (field.Name.ToUpper() == "ID" || field.Name.ToUpper() == "RECORDSTATUS")
                {
                    continue;
                }
                response += GenerateFieldAssignmentSimple(field, recordName) + ";" + Environment.NewLine;
            }
            return response;
        }

        public static string GenerateFieldAssignmentSimple(Interfaces.IDatabaseField field, string recordName)
        {
            return recordName + "." + field.Name + " = " + CommonHelper.ConvertUnderscoreToCamelCase(field.Name);
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
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (string)" + LinqAbbreviation(tableName) + "." + field.Name + @" ?? """"";
                        break;
                    }
                case DbType.DateTime:
                    {
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (DateTime)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Binary:
                    {
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (TimeSpan)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Int32:
                    {
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (int)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Int64:
                    {
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (long)" + LinqAbbreviation(tableName) + "." + field.Name;
                        break;
                    }
                case DbType.Boolean:
                    {
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = Convert.ToBoolean(" + LinqAbbreviation(tableName) + "." + field.Name + @")";
                        break;
                    }
                case DbType.Decimal:
                    {
                        response = CommonHelper.ConvertUnderscoreToCamelCase(field.Name) + " = (decimal)" + LinqAbbreviation(tableName) + "." + field.Name;
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
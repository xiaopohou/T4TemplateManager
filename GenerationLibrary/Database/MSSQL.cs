using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Codenesium.GenerationLibrary.Interfaces;
using Codenesium.GenerationLibrary.Generation;
namespace Codenesium.GenerationLibrary.Database
{
    public class MSSQL
    {
        public bool ConnectionTestResult { get; set; }
        public string ConnectionString { get;set;}

        public MSSQL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Test if we can open a SQL connection
        /// </summary>
        /// <param name="connecitonString"></param>
        /// <returns></returns>
        public void TestConnection()
        {
            this.ConnectionTestResult = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                  
                    conn.Open();
                    this.ConnectionTestResult = true;
                }
            }
            catch(Exception ex)
            {
                this.ConnectionTestResult = false;
            }
        }

        /// <summary>
        /// This function connects to a MSSQL database and retrieves the field list for a given table.
        /// There is no error handling. Handle it upstream.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static XElement GetFieldListForTable(string table, string schema, string connectionString)
        {
            XElement fieldList = new XElement("fields");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"select COLUMN_NAME,
                                                        DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, 
                                                       NUMERIC_PRECISION, DATETIME_PRECISION, 
                                                       CASE IS_NULLABLE
	                                                   WHEN 'NO' THEN 'FALSE'
	                                                   WHEN 'YES' THEN 'TRUE'
	                                                   END  AS IS_NULLABLE
                                                from INFORMATION_SCHEMA.COLUMNS
                                                where TABLE_NAME=@table
                                                AND TABLE_SCHEMA=@schema
                                                ORDER BY COLUMN_NAME", conn);

                command.Parameters.AddWithValue("table",table);
                command.Parameters.AddWithValue("schema", schema);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    XElement item = new XElement("field");
                    item.Add(new XElement("COLUMN_NAME", (string)reader["COLUMN_NAME"]));
                    item.Add(new XElement("IS_NULLABLE", (string)reader["IS_NULLABLE"]));
                    item.Add(new XElement("DATA_TYPE", (string)reader["DATA_TYPE"]));
                    item.Add(new XElement("MAX_LENGTH", reader["CHARACTER_MAXIMUM_LENGTH"].ToString() ?? ""));
                    fieldList.Add(item);

                }
            }
            return fieldList;
        }

        public static List<MSSQLField> GetFieldListFromXML(string xml)
        {
            List<MSSQLField> fieldList = new List<MSSQLField>();
            XDocument xDoc = XDocument.Parse(xml);

            fieldList = (from f in xDoc.Descendants("fields")
                         select new  MSSQLField
                         {
                             Name =  f.Element("fieldName").Value,
                             PrettyName =  f.Element("prettyName").Value,
                             SQLFieldType =  f.Element("type").Value,
                             FieldType = ParseType(f.Element("type").Value),
                             MaxLength = Convert.ToInt32(f.Element("length").Value) ,

                         }).ToList<MSSQLField>();


            return fieldList;
        }

        public static List<String> GetStoredProcedureList(string connectionString,string schema)
        {
            List<string> response = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT [ROUTINE_NAME] 
FROM [INFORMATION_SCHEMA].[ROUTINES]
WHERE [ROUTINE_TYPE] = 'PROCEDURE'
 and Left(Routine_Name, 3) NOT IN ('sp_','dt_',  'xp_', 'ms_') 
AND SPECIFIC_SCHEMA=@schema
ORDER BY ROUTINE_NAME", conn);

                command.Parameters.AddWithValue("schema", schema);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    response.Add(reader["ROUTINE_NAME"].ToString());
                }
            }
            return response;
        }

        public static List<String> GetSchemaList(string connectionString)
        {
            List<string> response = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA", conn);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    response.Add(reader["SCHEMA_NAME"].ToString());
                }
            }
            return response;
        }




        public static XElement GetFieldListFromTable(string tableName,string schema ,string connectionString)
        {
            XElement fieldList = new XElement("fields");
            fieldList.SetAttributeValue("name", "fields");
            XElement children = new XElement("children");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT  *
                                                    FROM INFORMATION_SCHEMA.COLUMNS
                                                    where table_name =@tableName
                                                    and table_schema=@schema
                                                    ORDER BY COLUMN_NAME", conn);
                command.Parameters.AddWithValue("tableName", tableName);
                command.Parameters.AddWithValue("schema", schema);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                 XElement field = new XElement("field");
                    field.SetAttributeValue("name", reader["COLUMN_NAME"].ToString().Replace("@", ""));
                    field.SetAttributeValue("type", "databaseField");
                    field.SetAttributeValue("value", "");

                    XElement fieldChildren = new XElement("children");

                    XElement nameAttribute = new XElement("attribute");
                    nameAttribute.SetAttributeValue("name", "Name");
                    nameAttribute.SetAttributeValue("value", reader["COLUMN_NAME"].ToString().Replace("@", ""));
                    fieldChildren.Add(nameAttribute);

                    XElement dataTypeAttribute = new XElement("attribute");
                    dataTypeAttribute.SetAttributeValue("name", "DataType");
                    dataTypeAttribute.SetAttributeValue("value", reader["DATA_TYPE"].ToString());
                    fieldChildren.Add(dataTypeAttribute);

                    XElement numericPrecisionAttribute = new XElement("attribute");
                    numericPrecisionAttribute.SetAttributeValue("name", "NumericPrecision");
                    numericPrecisionAttribute.SetAttributeValue("value",  reader["NUMERIC_PRECISION"].ToString());
                    fieldChildren.Add(numericPrecisionAttribute);

                    XElement maxLengthAttribute = new XElement("attribute");
                    maxLengthAttribute.SetAttributeValue("name", "MaxLength");
                    maxLengthAttribute.SetAttributeValue("value", reader["CHARACTER_MAXIMUM_LENGTH"].ToString());
                    fieldChildren.Add(maxLengthAttribute);

                    XElement mappedDatabaseFieldName = new XElement("attribute");
                    mappedDatabaseFieldName.SetAttributeValue("name", "MappedDatabaseFieldName");
                    mappedDatabaseFieldName.SetAttributeValue("value", reader["COLUMN_NAME"].ToString());
                    fieldChildren.Add(mappedDatabaseFieldName);

                    XElement mappedDatabaseFieldType = new XElement("attribute");
                    mappedDatabaseFieldType.SetAttributeValue("name", "MappedDatabaseFieldType");
                    mappedDatabaseFieldType.SetAttributeValue("value", reader["DATA_TYPE"].ToString());
                    fieldChildren.Add(mappedDatabaseFieldType);

                    XElement mappedDatabaseFieldLength = new XElement("attribute");
                    mappedDatabaseFieldLength.SetAttributeValue("name", "MappedDatabaseFieldLength");
                    mappedDatabaseFieldLength.SetAttributeValue("value", reader["CHARACTER_MAXIMUM_LENGTH"].ToString());
                    fieldChildren.Add(mappedDatabaseFieldLength);

                    XElement BOObjectTypeAttribute = new XElement("attribute");
                    BOObjectTypeAttribute.SetAttributeValue("name", "BOObjectType");
                    BOObjectTypeAttribute.SetAttributeValue("value", "");
                    fieldChildren.Add(BOObjectTypeAttribute);

                    XElement isBooleanAttribute = new XElement("attribute");
                    isBooleanAttribute.SetAttributeValue("name", "IsBoolean");
                    isBooleanAttribute.SetAttributeValue("value", "false");
                    fieldChildren.Add(isBooleanAttribute);

                    field.Add(fieldChildren);
                    children.Add(field);
                   
                }
                fieldList.Add(children);
            }
            return fieldList;
            
        }

        public static XElement GetFieldListFromStoredProcedure(string storedProcedureName, string schema ,string connectionString)
        {
            XElement fieldList = new XElement("fields");
            fieldList.SetAttributeValue("name", "fields");
            XElement children = new XElement("children");
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT  *
                                                    FROM INFORMATION_SCHEMA.PARAMETERS 
                                                    where specific_name = @storedProcedureName
                                                    and specific_schema=@schema", conn);

                command.Parameters.AddWithValue("storedProcedureName", storedProcedureName);
                command.Parameters.AddWithValue("schema", schema);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    XElement field = new XElement("field");
                    field.SetAttributeValue("name", reader["PARAMETER_NAME"].ToString().Replace("@", ""));
                    field.SetAttributeValue("type", "databaseField");
                    field.SetAttributeValue("value", "");

                    XElement fieldChildren = new XElement("children");

                    XElement nameAttribute = new XElement("attribute");
                    nameAttribute.SetAttributeValue("name", "Name");
                    nameAttribute.SetAttributeValue("value", reader["PARAMETER_NAME"].ToString().Replace("@", ""));
                    fieldChildren.Add(nameAttribute);

                    XElement dataTypeAttribute = new XElement("attribute");
                    dataTypeAttribute.SetAttributeValue("name", "DataType");
                    dataTypeAttribute.SetAttributeValue("value", reader["DATA_TYPE"].ToString());
                    fieldChildren.Add(dataTypeAttribute);

                    XElement numericPrecisionAttribute = new XElement("attribute");
                    numericPrecisionAttribute.SetAttributeValue("name", "NumericPrecision");
                    numericPrecisionAttribute.SetAttributeValue("value",  reader["NUMERIC_PRECISION"].ToString());
                    fieldChildren.Add(numericPrecisionAttribute);

                    XElement parameterModeAttribute = new XElement("attribute");
                    parameterModeAttribute.SetAttributeValue("name", "Mode");
                    parameterModeAttribute.SetAttributeValue("value", reader["PARAMETER_MODE"].ToString());
                    fieldChildren.Add(parameterModeAttribute);

                    XElement maxLengthAttribute = new XElement("attribute");
                    maxLengthAttribute.SetAttributeValue("name", "MaxLength");
                    maxLengthAttribute.SetAttributeValue("value", reader["CHARACTER_MAXIMUM_LENGTH"].ToString());
                    fieldChildren.Add(maxLengthAttribute);

                    XElement mappedDatabaseFieldName = new XElement("attribute");
                    mappedDatabaseFieldName.SetAttributeValue("name", "MappedDatabaseFieldName");
                    mappedDatabaseFieldName.SetAttributeValue("value", "");
                    fieldChildren.Add(mappedDatabaseFieldName);

                    XElement mappedDatabaseFieldType = new XElement("attribute");
                    mappedDatabaseFieldType.SetAttributeValue("name", "MappedDatabaseFieldType");
                    mappedDatabaseFieldType.SetAttributeValue("value", "");
                    fieldChildren.Add(mappedDatabaseFieldType);

                    XElement mappedDatabaseFieldLength = new XElement("attribute");
                    mappedDatabaseFieldLength.SetAttributeValue("name", "MappedDatabaseFieldLength");
                    mappedDatabaseFieldLength.SetAttributeValue("value", "");
                    fieldChildren.Add(mappedDatabaseFieldLength);

                    XElement BOObjectTypeAttribute = new XElement("attribute");
                    BOObjectTypeAttribute.SetAttributeValue("name", "BOObjectType");
                    BOObjectTypeAttribute.SetAttributeValue("value", "");
                    fieldChildren.Add(BOObjectTypeAttribute);

                    XElement isBooleanAttribute = new XElement("attribute");
                    isBooleanAttribute.SetAttributeValue("name", "IsBoolean");
                    isBooleanAttribute.SetAttributeValue("value", "false");
                    fieldChildren.Add(isBooleanAttribute);

                    field.Add(fieldChildren);
                    children.Add(field);
                   
                }
                fieldList.Add(children);
            }
            return fieldList;
        }

        /// <summary>
        /// This function returns the table list using the connection string from the app settings
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static XElement GetTableList(string connectionString,string schema)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT TABLE_NAME FROM information_schema.tables where table_Schema=@schema ", conn);
                command.Parameters.AddWithValue("schema", schema);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    XElement table = new XElement("tableName", (string)reader["TABLE_NAME"]);
                    return table;
                }
            }
            return null;
        }

        public static List<string> GetTableListAsStrings(string connectionString,string schema)
        {
            List<string> tables = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT TABLE_NAME FROM information_schema.tables 
                WHERE TABLE_SCHEMA=@schema ORDER BY TABLE_NAME", conn);
                command.Parameters.AddWithValue("schema", schema);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tables.Add( (string)reader["TABLE_NAME"]);
                 
                }
            }
              return tables;
        }




        /// <summary>
        /// Reference http://msdn.microsoft.com/en-us/library/cc716729%28v=vs.110%29.aspx
        /// This function converts a MSSQL field type to a .NET DbType
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DbType ParseType(string name)
        {
            DbType fieldType = 0;
            switch (name.ToUpper())
            {
                case "BIGINT":
                    fieldType = DbType.Int64;
                    break;
                case "BIT":
                    fieldType = DbType.Boolean;
                    break;
                case "NTEXT":
                case "NVARCHAR":
                case "VARCHAR":
                case "TEXT":
                    fieldType = DbType.String;
                    break;
                case "NCHAR":
                    fieldType = DbType.StringFixedLength;
                    break;
                case "CHAR":
                    fieldType = DbType.StringFixedLength;
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    fieldType = DbType.DateTime;
                    break;
                case "DATETIME2":
                    fieldType = DbType.DateTime2;
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                    fieldType = DbType.Decimal;
                    break;
                case "FLOAT":
                    fieldType = DbType.Double;
                    break;
                case "BINARY":
                case "VARBINARY":
                case "TIMESTAMP":
                case "IMAGE":
                    fieldType = DbType.Binary;
                    break;
                case "INT":
                    fieldType = DbType.Int32;
                    break;
                case "NUMERIC":
                    fieldType = DbType.Decimal;
                    break;
                case "REAL":
                    fieldType = DbType.Single;
                    break;
                case "SMALLINT":
                    fieldType = DbType.Int16;
                    break;
                case "TINYINT":
                    fieldType = DbType.Byte;
                    break;
            }
            return fieldType;
        }
    }
}

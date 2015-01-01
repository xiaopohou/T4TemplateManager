using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Codenesium.TemplateGenerator.Classes.Database
{
    public class MSSQL : Interfaces.IDatabaseInterface
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
        public List<Interfaces.IDatabaseField> GetFieldList(string table)
        {
            List<Interfaces.IDatabaseField> fieldList = new List<Interfaces.IDatabaseField>();
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, 
                                                       NUMERIC_PRECISION, DATETIME_PRECISION, 
                                                       CASE IS_NULLABLE
	                                                   WHEN 'NO' THEN 'FALSE'
	                                                   WHEN 'YES' THEN 'TRUE'
	                                                   END  AS IS_NULLABLE
                                                from INFORMATION_SCHEMA.COLUMNS
                                                where TABLE_NAME=@table", conn);

                command.Parameters.AddWithValue("table",table);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Classes.DataType.MSSQLField field = new Classes.DataType.MSSQLField();
                    field.Name = (string)reader["COLUMN_NAME"];
                    field.FieldType = this.ParseType((string)reader["DATA_TYPE"]);
                    field.IsNull = Boolean.Parse((string)reader["IS_NULLABLE"]);
                    field.SQLFieldType = (string)reader["DATA_TYPE"];
                    fieldList.Add(field);
                }
            }
            return fieldList;
        }

        /// <summary>
        /// This function returns the table list using the connection string from the app settings
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public List<Interfaces.IDatabaseTable> GetTableList()
        {
            List<Interfaces.IDatabaseTable> tableList = new List<Interfaces.IDatabaseTable>();
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT * FROM information_schema.tables", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Classes.DataType.MSSQLTable table = new Classes.DataType.MSSQLTable();
                    table.Name = (string)reader["TABLE_NAME"];
                    table.FieldList = this.GetFieldList(table.Name);
                    tableList.Add(table);  
                }
            }
            return tableList;
        }



        /// <summary>
        /// Reference http://msdn.microsoft.com/en-us/library/cc716729%28v=vs.110%29.aspx
        /// This function converts a MSSQL field type to a .NET DbType
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DbType ParseType(string name)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Generation.Helpers
{
    public class CommonHelper
    {

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

        public static string ConvertTableNameToRepositoryName(string tableName)
        {            
            string objectName = String.Empty;
            if (tableName.ToUpper().Substring(0, 2) == "CN")
            {
                string strippedName = tableName.Replace("cn", "").Replace("CN", "");
                string fixedStrippedName = strippedName.Substring(0, 1).ToUpper() + strippedName.Substring(1, strippedName.Length - 1);
                objectName = "CN" + fixedStrippedName + "Repository";
            }
            else
            {
                objectName = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1, tableName.Length - 1) + "Repository";
            }
            return objectName;
        }

        public static string ConvertTableNameToRepositoryInterfaceName(string tableName)
        {
            string objectName = String.Empty;
            if (tableName.ToUpper().Substring(0, 2) == "CN")
            {
                string strippedName = tableName.Replace("cn", "").Replace("CN", "");
                string fixedStrippedName = strippedName.Substring(0, 1).ToUpper() + strippedName.Substring(1, strippedName.Length - 1);
                objectName = "ICN" + fixedStrippedName + "Repository";
            }
            else
            {
                objectName = "I" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1, tableName.Length - 1) + "Repository";
            }
            return objectName;
        }

        public static string ConvertTableNameToBasicObjectName(string tableName)
        {
            string objectName = String.Empty;
            if (tableName.ToUpper().Substring(0, 2) == "CN")
            {
                string strippedName = tableName.Replace("cn", "").Replace("CN", "");
                string fixedStrippedName = strippedName.Substring(0, 1).ToUpper() + strippedName.Substring(1, strippedName.Length - 1);
                objectName = "CN" + fixedStrippedName;
            }
            else
            {
                objectName = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1, tableName.Length - 1);
            }
            return objectName;
        }

        public static string ConvertTableNameToBasicObjectInterfaceName(string tableName)
        {
            string objectName = String.Empty;
            if (tableName.ToUpper().Substring(0, 2) == "CN")
            {
                string strippedName = tableName.Replace("cn", "").Replace("CN", "");
                string fixedStrippedName = strippedName.Substring(0, 1).ToUpper() + strippedName.Substring(1, strippedName.Length - 1);
                objectName = "ICN" + fixedStrippedName;
            }
            else
            {
                objectName = "I" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1, tableName.Length - 1);
            }
            return objectName;
        }
    }
}

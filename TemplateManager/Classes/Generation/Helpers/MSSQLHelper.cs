using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Generation.Helpers
{
    public class MSSQLHelper
    {

        public static string GenerateSelectAllQuery(Interfaces.IDatabaseTable table)
        {

            string response = "SELECT " + Environment.NewLine;

            for(int i =0; i < table.FieldList.Count;i++)
            {
                response += "[" + table.FieldList[i].Name + "]";
                
                if(i < table.FieldList.Count -1 )
                {
                    response += ",";
                }
                
                response += Environment.NewLine;
            }

           
            response += "FROM [" + table.Name + "]" + Environment.NewLine;
            response += "WHERE[ID] = @id" + Environment.NewLine;
            return response;


        }
    }
}

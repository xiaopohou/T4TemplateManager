using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Database
{

    public enum DATAINTERFACE
    {
        MSSQL,
        FILE,
        NONE
    }

    public static class DataInterface
    {
        public static string ToString(this DATAINTERFACE value) //ext method
        {
            switch(value)
            {
                case DATAINTERFACE.MSSQL:
                    {
                        return "MSSQL";
                    }
                case DATAINTERFACE.FILE:
                    {
                        return "FILE";
                    }
                case DATAINTERFACE.NONE:
                    {
                        return "NONE";
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public static DATAINTERFACE ParseDataInterfaceEnum(string value)
        {
            switch (value.ToUpper())
            {
                case "MSSQL":
                    {
                        return DATAINTERFACE.MSSQL;
                    }
                 case "FILE":
                    {
                        return DATAINTERFACE.FILE;
                    }
                 case "NONE":
                    {
                        return DATAINTERFACE.NONE;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}

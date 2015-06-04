using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Codenesium.GenerationLibrary.Interfaces;
namespace Codenesium.GenerationLibrary.Database
{
    /// <summary>
    /// This class should be self explanatory. We have added the SQLFieldType in case we need MSSQL specific info for a template
    /// </summary>
    [Serializable]
    public  class MSSQLField : IDatabaseField
    {
        public string Name { get; set; }
        public string PrettyName { get; set; }
        public int MaxLength { get; set; }
        public bool IsNull { get; set; }
        public DbType FieldType { get; set; }
        public string SQLFieldType { get; set; } //TODO: change this to be a SQLDBType
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codenesium.GenerationLibrary.Interfaces;
namespace Codenesium.GenerationLibrary.Database
{
    [Serializable]
    public class MSSQLTable : IDatabaseTable
    {
        public string Name { get; set; }
        public List<IDatabaseField> FieldList { get; set; }
        public MSSQLTable()
        {
            this.FieldList = new List<IDatabaseField>();
            this.Name = String.Empty;
        }
    }
}

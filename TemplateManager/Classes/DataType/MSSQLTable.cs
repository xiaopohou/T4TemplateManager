using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.DataType
{
    [Serializable]
    public class MSSQLTable : Interfaces.IDatabaseTable
    {
        public string Name { get; set; }
        public List<Interfaces.IDatabaseField> FieldList { get; set; }
        public MSSQLTable()
        {
            this.FieldList = new List<Interfaces.IDatabaseField>();
            this.Name = String.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Codenesium.TemplateGenerator.Interfaces
{
    interface IDatabaseInterface
    {
        string ConnectionString { get; set; }
        List<Interfaces.IDatabaseField> GetFieldList(string table);
        List<Interfaces.IDatabaseTable> GetTableList();
        DbType ParseType(string name);
    }
}

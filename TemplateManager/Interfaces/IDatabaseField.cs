using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Codenesium.TemplateGenerator.Interfaces
{

    /// <summary>
    /// This is the field interface that all database system fields should be converted to.
    /// </summary>
    public interface IDatabaseField
    {
        string Name { get; set; }
        int MaxLength { get; set; }
        bool IsNull { get; set; }
        DbType FieldType {get; set;}
    }
}

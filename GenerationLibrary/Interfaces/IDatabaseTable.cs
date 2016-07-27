using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.GenerationLibrary.Interfaces
{
    public interface IDatabaseTable
    {
       string Name { get; set; }
       List<Interfaces.IDatabaseField> FieldList { get; set; }
    }
}

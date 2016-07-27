using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Codenesium.GenerationLibrary.Interfaces
{
    interface IDatabaseInterface
    {
        string ConnectionString { get; set; }
        List<Interfaces.IDatabaseTable> GetTableList();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ModuleExample.Services
{
    public class TableService : ITableService
    {
        public void GetTable()
        {
            Console.WriteLine("This is a table");
        }
    }
}

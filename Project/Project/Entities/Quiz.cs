using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Entities
{
    public class Quiz
    {
        private DataTable dataTable;

        public Quiz(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }

    }
}

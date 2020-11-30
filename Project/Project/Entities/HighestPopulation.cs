using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class HighestPopulation
    {
        public static void GetTopFive(DataTable dt, int numberOfColumn, int numberOfRows)
        {
            dt.DefaultView.Sort = "Population (2020) desc";
            int totalColumnsToReserve = numberOfColumn;
            for (int i = dt.Columns.Count - 1; i >= totalColumnsToReserve; i--)
            {
                dt.Columns.RemoveAt(i);
            }

            int totalRowsToReserve = numberOfRows;
            for (int i = dt.Rows.Count - 1; i >= totalRowsToReserve; i--)
            {
                dt.Rows.RemoveAt(i);
            }
        }
    }



}

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
        public static void GetTopPopulation(DataTable dt, int numberOfColumn, int numberOfRows)
        {
            dt.DefaultView.Sort = "Population (2020) desc";

            for (int i = dt.Columns.Count - 1; i >= numberOfColumn; i--)
            {
                dt.Columns.RemoveAt(i);
            }

            for (int i = dt.Rows.Count - 1; i >= numberOfRows; i--)
            {
                dt.Rows.RemoveAt(i);
            }
        }
    }



}

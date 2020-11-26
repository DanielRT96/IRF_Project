using Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = GetCsvData.ConvertCSVtoDataTable("population_by_country_2020.csv");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchValue = textBox1.Text;

            int rowIndex = -1;

            DataGridViewRow row = dataGridView1.Rows.Cast<DataGridViewRow>()
                                                    .Where(r => r.Cells["Country (or dependency)"].Value.ToString().Equals(searchValue))
                                                    .First();

            rowIndex = row.Index;
            dataGridView1.Rows[rowIndex].Selected = true;


            //string rowFilter = string.Format("[{0}] = '{1}'", "Country (or dependency)", searchValue);
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

    }
}

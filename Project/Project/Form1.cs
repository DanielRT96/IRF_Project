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
        DataTable csv = GetCsvData.ConvertCSVtoDataTable("population_by_country_2020.csv");
        public Form1()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            dataGridView1.DataSource = csv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchValue = textBox1.Text;

                if (searchValue == "")
                {
                    return;
                } else
                {
                    DataTable selectedTable = csv.AsEnumerable()
                                                    .Where(r => r.Field<string>("Country (or dependency)") == searchValue)
                                                    .CopyToDataTable();

                    dataGridView1.DataSource = selectedTable;
                }
            }
        }
    }
}

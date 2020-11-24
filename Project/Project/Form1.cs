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
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines("population_by_country_2020.csv");
            if (lines.Length > 0)
            {
                string firstLine = lines[0];

                string[] headerLabels = firstLine.Split(',');

                foreach(string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {

                        dr[headerWord] = dataWords[columnIndex++];
                    }

                    dt.Rows.Add(dr);
                }
            }
            if(dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
            }

        }
    }
}

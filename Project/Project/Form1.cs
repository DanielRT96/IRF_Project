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
        List<HighestPopulation> MostPopulatedCountries = new List<HighestPopulation>();
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
            MostPopulatedCountries.Clear();

            MostPopulatedCountries.Add(new HighestPopulation() { Country = "China", Population = 100 });
            MostPopulatedCountries.Add(new HighestPopulation() { Country = "Hungary", Population = 10 });
            MostPopulatedCountries.Add(new HighestPopulation() { Country = "Germany", Population = 100 });

            dataGridView1.DataSource = MostPopulatedCountries;

            chart1.DataSource = csv;

            var series = chart1.Series[0];
            series.XValueMember = "Country";
            series.YValueMembers = "Population";
            series.BorderWidth = 2;

            var legend = chart1.Legends[0];
            legend.Enabled = false;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
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
                    DataTable selectedCountry = csv.AsEnumerable()
                                                    .Where(r => r.Field<string>("Country (or dependency)") == searchValue)
                                                    .CopyToDataTable();

                    dataGridView1.DataSource = selectedCountry;
                }

                textBox1.Text = "";
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ...
        }
    }
}

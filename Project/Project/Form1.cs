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
        Quiz quiz;
        int getTopPop;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            this.quiz = new Quiz(csv);
        }

        private void LoadData()
        {

            changePanel(panel2);
            dataGridView2.DataSource = csv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getTopPop = (int)numericUpDown1.Value;
            changePanel(panel1);

            DataTable highestPopluation = csv.Copy();
            HighestPopulation.GetTopPopulation(highestPopluation, 2, getTopPop);

            dataGridView1.DataSource = highestPopluation;
            chart1.DataSource = highestPopluation;

            var series = chart1.Series[0];
            series.XValueMember = "Country (or dependency)";
            series.YValueMembers = "Population (2020)";
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

                try
                {
                    DataTable selectedCountry = csv.AsEnumerable()
                            .Where(r => r.Field<string>("Country (or dependency)") == searchValue)
                            .CopyToDataTable();

                    dataGridView2.DataSource = selectedCountry;
                } 
                catch
                {
                    MessageBox.Show("Invalid input!");
                }
      
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newPanel = quiz.generateQuestion();
            this.Controls.Add(newPanel);
            changePanel(newPanel);
        }

        private void changePanel(Panel chosenPanel)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    c.Visible = false;
                }
            }
            chosenPanel.Visible = true;
        }

    }
}

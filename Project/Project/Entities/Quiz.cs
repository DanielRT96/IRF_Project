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

        public Panel generateQuestion()
        {
            Random randomGen = new Random();
            var panel = new Panel();
            var questionText = "What is the population of ";

            var selectedRow = randomGen.Next(1, this.dataTable.Rows.Count - 1);
            var country = (string)this.dataTable.Rows[selectedRow]["Country (or dependency)"];

            var questionLabel = new Label
            {
                Location = new System.Drawing.Point(250, 100),
                Name = "label2",
                Size = new System.Drawing.Size(400, 20),
                Text = questionText + country + "?",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
            };

            panel.Controls.Add(questionLabel);
            panel.Location = new System.Drawing.Point(15, 51);
            panel.Name = "panel3";
            panel.Size = new System.Drawing.Size(776, 396);
            panel.TabIndex = 9;

            return panel;
        }
    }
}

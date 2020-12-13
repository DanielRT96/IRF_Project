using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

            var selectedRow = randomGen.Next(0, this.dataTable.Rows.Count - 1);
            var country = (string)dataTable.Rows[selectedRow]["Country (or dependency)"];

            var questionLabel = new Label
            {
                Location = new Point(150, 100),
                Name = "label2",
                Size = new Size(600, 80),
                Text = questionText + country + "?",
                Font = new Font("Verdana", 20F, FontStyle.Regular, GraphicsUnit.Point, 238)
        };

            panel.Controls.Add(questionLabel);

            var answer = (int)dataTable.Rows[selectedRow]["Population (2020)"];
            var correnctAnswerIndex = randomGen.Next(0, 3);

            for (int i = 0; i < 3; i++)
            {
                var answerButton = new Button
                {
                    Location = new Point(150 + 200 * i, 200),
                    Name = "button" + (4 + i),
                    Size = new Size(100, 30),
                    Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Text = correnctAnswerIndex == i ? answer.ToString() : Convert.ToString(randomGen.Next(Convert.ToInt32(answer * 0.8), Convert.ToInt32(answer * 1.2))),
                };
                answerButton.Click += new EventHandler(CheckCorrectAnswer);

                void CheckCorrectAnswer(object sender, EventArgs e)
                {
                    Button button = sender as Button;
                    if(answer == Convert.ToInt32(answerButton.Text))
                    {
                        button.BackColor = Color.Green;
                        button.ForeColor = Color.White;
                    }
                    else
                    {
                        button.BackColor = Color.Red;
                        button.ForeColor = Color.White;
                    }
                }
                panel.Controls.Add(answerButton);
            }

            panel.Location = new Point(15, 51);
            panel.Name = "panel3";
            panel.Size = new Size(780, 400);

            return panel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form2 : Form
    {
        Label firstClicked = null;
        List<string> icons = new List<string>
        {
             "!", "!", "N", "N", ",", ",", "k", "k",
              "b", "b", "v", "v", "w", "w", "z", "z"
        };

        Label secondClicked = null;

        Random random = new Random();
        List<Label> cells = new List<Label>();
        Panel panel = new Panel();
        int Columns, Rows;
        TableLayoutPanel table;
        int size = 1;

        public Form2()
        {
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            size = 30;
            Columns = 2; Rows = 3;
            CREATE_TABLE(Columns, Rows);
            AssignIconsToSquares();

        }
        private void CREATE_TABLE(int Columns, int Rows)
        {
            // panel = new Panel();
            panel.Controls.Clear();
            table = new TableLayoutPanel(); //важно:
            table.Dock = DockStyle.Fill;
            table.BackColor = Color.CornflowerBlue;


            panel.Width = Convert.ToInt32(this.Width * 0.9f);
            panel.Height = Convert.ToInt32(this.Height * 0.95f);
            //границы
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            table.Location = new System.Drawing.Point(0, 0);
            table.Visible = true;
            table.ColumnCount = Convert.ToInt32(Columns);
            table.RowCount = Convert.ToInt32(Rows);

            int width = 100 / table.ColumnCount;
            int height = 100 / table.RowCount;

            //  table.Font = new Font("Webdings", 48);

            // добавляем колонки и строки
            for (int col = 0; col < table.ColumnCount; col++)
            {
                // добавляем колонку
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

                for (int row = 0; row < table.RowCount; row++)
                {
                    // добавляем строку
                    if (col == 0)
                    {
                        table.RowStyles.Add(new RowStyle(SizeType.Percent, height));
                    }


                    var label = new Label();
                    label.AutoSize = false;
                    label.Font = new Font("Webdings", size);
                    label.Name = ("label" + row + col).ToString();
                    label.Text = 'с'.ToString();
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += new System.EventHandler(this.label_Click);
                    cells.Add(label);
                    table.Controls.Add(label, col, row);
                    

                }

            }
            Controls.Add(panel);
            panel.Controls.Add(table);


        }
        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;


                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"");
                //player.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();


            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;


            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {

            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }


            MessageBox.Show("Вы сопоставили  все иконки!", "Поздравляю");
            Close();
        }

      
        private void AssignIconsToSquares()
        {

            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

    }
}

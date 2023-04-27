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
    public partial class Form3 : Form
    {
        List<Label> cells = new List<Label>();
        Panel panel = new Panel();
        int Columns, Rows;
        TableLayoutPanel table;
        int size = 1;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            size = 60;
            Columns = 6; Rows = 7;
            CREATE_TABLE(Columns, Rows);

        }
        private void CREATE_TABLE(int Columns, int Rows)
        {
            // panel = new Panel();
            panel.Controls.Clear();
            table = new TableLayoutPanel(); //важно:
            table.Dock = DockStyle.Fill;
            table.BackColor = Color.CornflowerBlue;


            panel.Width = Convert.ToInt32(this.Width * 0.99f);
            panel.Height = Convert.ToInt32(this.Height * 0.99f);
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
                    cells.Add(label);
                    table.Controls.Add(label, col, row);

                }

            }
            Controls.Add(panel);
            panel.Controls.Add(table);


        }

    }
}

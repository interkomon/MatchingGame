using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MatchingGame
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            StreamReader sr = File.OpenText("data.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listBox1.Items.Add(line);
            }
            sr.Close();
        }
    }
}

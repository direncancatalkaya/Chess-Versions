using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public static List<Board> Games = new List<Board>();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Board cb = new Board{GameName = "asdfg",CreatingTime = DateTime.Now.ToShortDateString()};
            cb.NewGame();
            Games.Add(cb);
            listBox1.DataSource = null;
            listBox1.DataSource = Games;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3 frm3 = new Form3(listBox1.SelectedItem as Board);
            frm3.ShowDialog();
        }
    }
}

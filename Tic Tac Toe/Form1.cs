using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The game was made by a junior developer GG");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn)
                button.Text = "X";
            else
                button.Text = "O";
            turn = !turn;
            button.Enabled = false;
            turn_count++;
            winner();
        }
        private void winner()
        {
            bool winnerMatch = false;
            string win = "";

            //horizontal
            if (a1.Text == a2.Text && a2.Text == a3.Text && !a1.Enabled)
                winnerMatch = true;
            if (b1.Text == b2.Text && b2.Text == b3.Text && !b1.Enabled)
                winnerMatch = true;
            if (c1.Text == c2.Text && c2.Text == c3.Text && !c1.Enabled)
                winnerMatch = true;

            //vertical
            if (a1.Text == b1.Text && b1.Text == c1.Text && !a1.Enabled)
                winnerMatch = true;
            if (a2.Text == b2.Text && b2.Text == c2.Text && !a2.Enabled)
                winnerMatch = true;
            if (a3.Text == b3.Text && b3.Text == c3.Text && !a3.Enabled)
                winnerMatch = true;

            if (a1.Text == b2.Text && b2.Text == c3.Text && !a1.Enabled)
                winnerMatch = true;
            if (a3.Text == b2.Text && b2.Text == c1.Text && !a3.Enabled)
                winnerMatch = true;

            if (winnerMatch)
            {
                DisableButton();
                if (turn)
                    win = "X";
                else
                    win = "Y";
                MessageBox.Show("The winner is " + win);
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Its Draw");
            }
        }
        private void DisableButton()
        {
            try
            {
                foreach (var i in Controls)
                {
                    Button button = (Button)i;
                    button.Enabled = false;
                }
            }
            catch { }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (var i in Controls)
                {
                    Button button = (Button)i;
                    button.Enabled = true;
                    button.Text = "";
                }
            }
            catch { }
        }
    }
}

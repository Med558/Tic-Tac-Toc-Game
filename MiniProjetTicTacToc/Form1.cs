using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjetTicTacToc
{
    
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jeux Tic Tac Toc pour le mini projet C#","Tic Tac Toc about");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();

        }

        private void checkForWinner()
        {
            bool winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text )&&(!A1.Enabled)) winner = true;
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) winner = true;
            else if ((C1.Text == A2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) winner = true;
          else  if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) winner = true;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled)) winner = true;

            if (winner)
            {
                disableButton();
                string name = "";
                if (turn)
                {
                    name = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();

                }
                else
                {
                    name = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(name + " à gagner");
                disable();
            }
            else
            {
                if (turn_count == 9) { 
                   eg_count.Text = (Int32.Parse(eg_count.Text) + 1).ToString();

                MessageBox.Show(" Fin du jeux sans gangnant");
                    disable();
                    
                }
            }
        }

        public void disableButton()
        {
            try { 
            foreach (Control c in Controls) {
                Button b = (Button)c;
                    b.Enabled = false;
            }
            }
            catch { }
        }

        public void restart()
        {
            turn = true;
            turn_count = 0;
            
                foreach (Control c in Controls)
            {
                try
                {
                    
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    }
            catch { }
        }
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled) {
                if (turn) b.Text = "X";
                else b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                 b.Text = "";
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            eg_count.Text = "0";
            restart();

        }

        public void disable()
        {
            
            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;
                    b.Enabled = false;
                  
                }
                catch { }
            }
        }
    }
}

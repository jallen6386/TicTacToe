using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool turn = true; // true = X turn; false = O turn
        int turn_count = 0;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By John", "Tic Tac Toe About");
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
            bool there_is_a_winner = false;

            //horizontal checks
            if ((UxA1.Text == UxA2.Text) && (UxA2.Text == UxA3.Text) && (!UxA1.Enabled))
                there_is_a_winner = true;
            else if ((UxB1.Text == UxB2.Text) && (UxB2.Text == UxB3.Text) && (!UxB1.Enabled))
                there_is_a_winner = true;
            else if ((UxC1.Text == UxC2.Text) && (UxC2.Text == UxC3.Text) && (!UxC1.Enabled))
                there_is_a_winner = true;

            //vertical checks
            else if ((UxA1.Text == UxB1.Text) && (UxB1.Text == UxC1.Text) && (!UxA1.Enabled))
                there_is_a_winner = true;
            else if ((UxA2.Text == UxB2.Text) && (UxB2.Text == UxC2.Text) && (!UxA2.Enabled))
                there_is_a_winner = true;
            else if ((UxA3.Text == UxB3.Text) && (UxB3.Text == UxC3.Text) && (!UxA3.Enabled))
                there_is_a_winner = true;

            //diagonal checks
            else if ((UxA1.Text == UxB2.Text) && (UxB2.Text == UxC3.Text) && (!UxA1.Enabled))
                there_is_a_winner = true;
            else if ((UxA3.Text == UxB2.Text) && (UxB2.Text == UxC1.Text) && (!UxC1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " Wins!", "Congratulations!");
            }//end if
            else
            {
                if(turn_count == 9)
                    MessageBox.Show("Draw!", "Bummer!");
            }

        }// End checkForWinner

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }//end try
            catch { }
        }

    }
}

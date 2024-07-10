using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tigtagtoe
{
    public partial class Form3 : Form
    {
        bool turn = false;
        int turn_counting = 0;
        private Button[] LeftArr;
        public void set_new()
        {
            foreach (Control button_set in Controls)
            {
                if (button_set is Button)
                {
                    button_set.Text = " ";
                }
            }
        }
        public void disable_button()
        {
            foreach (Control button_set in Controls)
            {
                if (button_set is Button)
                {
                    button_set.Enabled = false;
                }
            }
        }
        public Form3()
        {
            InitializeComponent();
            LeftArr = new Button[]
            {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };
            set_new();
        }
        bool end_now = false;
        public void winner_checker()
        {

            string winner_string = string.Empty;
            //horizontal
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Enabled == false))
            {
                end_now = true;
            }
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (button4.Enabled == false))
            {
                end_now = true;
            }
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (button7.Enabled == false))
            {
                end_now = true;
            }
            //vertical
            if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (button1.Enabled == false))
            {
                end_now = true;
            }
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (button2.Enabled == false))
            {
                end_now = true;
            }
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Enabled == false))
            {
                end_now = true;
            }

            if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (button1.Enabled == false))
            {
                end_now = true;
            }
            else if ((button7.Text == button5.Text) && (button5.Text == button3.Text) && (button7.Enabled == false))
            {
                end_now = true;
            }

            if (end_now == true)
            {
                //if (turn_counting == 9)
                //{ turn = !turn; }
                if (turn == true)
                {
                    winner_string = "winner is X";
                    disable_button();
                }
                else if (turn == false)
                {
                    winner_string = "winner is O";
                    disable_button();
                }
                disable_button();
                MessageBox.Show(winner_string);
                disable_button();
            }
            else
            {
                if (turn_counting == 9)
                { winner_string = "Draw"; disable_button(); MessageBox.Show(winner_string); }

            }
            //MessageBox.Show(turn_counting.ToString());


        }
        public void button_game(object sender, MouseEventArgs e)
        {
            if (turn)
            {
                Button button_click = (Button)sender;
                button_click.Text = "O";
                button_click.Enabled = false;
                LeftArr = LeftArr.Where(val => val != button_click).ToArray();
            }
            else
            {
                Button button_click = (Button)sender;
                button_click.Text = "X";
                button_click.Enabled = false;
                LeftArr = LeftArr.Where(val => val != button_click).ToArray();
            }
            turn = !turn;
            turn_counting++;
            winner_checker();
        }

        private void Hover_mouse(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                if (turn)
                {
                    button.Text = "O";
                }
                else
                {
                    button.Text += "X";
                }
            }
        }

        private void Mouse_leave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                button.Text = " ";
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

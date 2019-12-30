using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public int player = 2;
        public int turns = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;

        public bool onturn = true;






        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void A00_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
            {
                /*  if (player % 2 == 0)
                  {
                      btn.Text = "X";
                      player++;
                      turns++;
                  }
                  else
                  {
                      btn.Text = "O";
                      player++;
                      turns++;

                  }*/
                if (onturn == true)
                {
                    btn.Text = "X";
                }
                else
                {
                    btn.Text = "0";

                }
                turns++;
                onturn = !onturn;
            }
                if (checkdraw()==true && checkwinner() == false) {
                    MessageBox.Show("Match Draw");
                     sd++;
                    newgame();
                }
                if (checkwinner() == true)
                {
                    if (btn.Text == "X")
                    {
                        s1++;
                        MessageBox.Show("Player 1 Win!!!!!");
                        newgame();

                    }
                    else
                    {
                        s2++;
                        MessageBox.Show("Player 2 Win!!!!!");
                        newgame();

                    }
                }
            if (onturn==false)
            {
                CPU().PerformClick();
            }

            
          
        }

        public Button CPU()
        {
            Button b = null;
            b = CPUTryWinorDefend("0");
            if (b!=null)
            {
                return b;
            }
            else
            {
                b = CPUTryWinorDefend("X");
                if (b != null)
                {
                    return b;
                }
                else
                {
                    return CPUMoveRandom();
                }
            }
        } 

        public Button CPUTryWinorDefend(string s)
        {
            Button b = null;

            if (A00.Text == A01.Text && A00.Text == s && A02.Text == "")
            {
                return A02;
            }
            else if (A00.Text == A02.Text && A00.Text == s && A01.Text == "")

            {
                return A01;
            }
            else if (A01.Text == A02.Text && A01.Text == A22.Text && A00.Text == "")
            {
                return A00;
            }


            else if (A10.Text == A12.Text && A10.Text == s && A11.Text == "")
            {
                return A11;
            }
            else if (A10.Text == A11.Text && A10.Text ==s && A02.Text == "")
            {
                return A02;
            }
            else if (A12.Text == A11.Text && A11.Text == s && A10.Text == "")
            {
                return A10;
            }


            else if (A20.Text == A22.Text && A20.Text == s && A21.Text == "")
            {
                return A21;
            }

            else if (A20.Text == A21.Text && A20.Text == s && A22.Text == "")
            {
                return A22;
            }


            else if (A22.Text == A21.Text && A22.Text == s && A20.Text == "")
            {
                return A20;
            }


            else if (A00.Text == A10.Text && A00.Text == s && A20.Text == "")
            {
                return A20;
            }


            else if (A00.Text == A20.Text && A00.Text == s && A10.Text == "")
            {
                return A10;
            }


            else if (A20.Text == A10.Text && A10.Text == s && A00.Text == "")
            {
                return A00;
            }


            else if (A21.Text == A11.Text && A11.Text == s && A01.Text == "")
            {
                return A01;
            }


            else if (A21.Text == A01.Text && A01.Text == s && A11.Text == "")
            {
                return A11;
            }


            else if (A01.Text == A11.Text && A11.Text == s && A21.Text == "")
            {
                return A21;
            }



            else if (A22.Text == A02.Text && A02.Text == s && A12.Text == "")
            {
                return A12;
            }


            else if (A02.Text == A12.Text && A01.Text == s && A22.Text == "")
            {
                return A22;
            }


            else if (A00.Text == A11.Text && A11.Text == s && A22.Text == "")
            {
                return A22;
            }


            else if (A22.Text == A00.Text && A22.Text == s && A11.Text == "")
            {
                return A11;
            }
            //done
            else if (A22.Text == A11.Text && A11.Text == s && A00.Text == "")
            {
                return A00;
            }


            else if (A20.Text == A11.Text && A11.Text == s && A02.Text == "")
            {
                return A02;
            }


            else if (A20.Text == A02.Text && A02.Text == s && A11.Text == "")
            {
                return A11;
            }



            else if (A02.Text == A11.Text && A11.Text == s && A20.Text == "")
            {
                return A20;
            }


            else
            {
                return null;
            }

        }
        public Button CPUMoveRandom()
        {
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                    {
                        return b;
                    }
                }
            }
            return null;
        }
        void newgame()
        {
            player = 2;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
            p1.Text = "" + s1;
            p2.Text = "" + s2;
            ss.Text = "" + sd;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            newgame();
        }
        bool checkdraw()
        {
            if (turns == 9)
                return true;
            else
                return false;
        }
        bool checkwinner()
        {
            if (A00.Text == A01.Text &&  A01.Text == A02.Text && A00.Text!="")
            {
                return true;
            }
            else if (A10.Text == A11.Text && A11.Text == A12.Text && A10.Text != "")
            {
                return true;
            }
            else if (A20.Text == A21.Text && A21.Text == A22.Text && A20.Text != "")
            {
                return true;
            }


             if (A00.Text == A10.Text &&  A10.Text == A20.Text && A00.Text!="")
            {
                return true;
            }
            else if (A11.Text == A01.Text && A11.Text == A21.Text && A01.Text != "")
            {
                return true;
            }
            else if (A02.Text == A12.Text && A12.Text == A22.Text && A02.Text != "")
            {
                return true;
            }


            if (A00.Text == A11.Text && A11.Text == A22.Text && A00.Text != "")
            {
                return true;
            }
          
            else if (A02.Text == A11.Text && A11.Text == A20.Text && A02.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p1.Text =""+ s1;
            p2.Text = "" + s2;
            ss.Text = "" + sd;
             
        }

        private void button11_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            newgame();
        }
    }
}

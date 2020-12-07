using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace G15
{
    public partial class FormGame15 : Form
    {
        Game game;
        public FormGame15()
        {
            InitializeComponent();
            game = new Game(4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int pos = Convert.ToInt32(((Button)sender).Tag);
            game.Addlist(pos);
            game.shift(pos);
            
            refresh();
            if(game.chekc_nmb())
            {
                MessageBox.Show("You win", "Congritulation");
            }
        }
        Button button(int pos)
        {
            switch (pos)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;

            }


        }
        private void FormGame15_Load(object sender, EventArgs e)
        {
            start_game0();
        }
        private void menu_start_Click(object sender, EventArgs e)
        {
           // start_game0();
            start_game();
        }
        private void start_game0()
        {
            game.start();
            
            refresh();
        }
        private void start_game()
        {
            game.start();

          
                for (int i = 0; i < 50; i++)
            {
                    game.shift_rand();
                for (int q = 0; q < 16; q++)
                {
                    button(q).Update();
                }
                   
                    Thread.Sleep(100);
                refresh();
            }

                //refresh();
            
        }
        private void refresh()
        {
            for(int pos=0;pos<16;pos++)
            {
                button(pos).Text = game.get_number(pos).ToString();
                button(pos).Visible = (game.get_number(pos) >0);
            }       

        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w = Game.list.Count;

            for (int i = 0; i < w; i++)
            {
                game.sborka();
                for (int q = 0; q < 16; q++)
                {
                    button(q).Update();
                }

                Thread.Sleep(100);
                refresh();
            }

            refresh();
          
        }
    }
 
    }


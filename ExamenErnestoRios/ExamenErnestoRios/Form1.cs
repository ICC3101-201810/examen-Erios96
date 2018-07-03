using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenErnestoRios
{
    public partial class Form1 : Form
    {
        Main main;
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        int speed = 5;
        int ghost1x = 8;
        int ghost1y = 8;
        int ghost2x = 8;
        int ghost2y = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            main = new Main();
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.BringToFront();
            label2.Visible = false;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.pacman_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                pacman.Image = Properties.Resources.pacman_right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                pacman.Image = Properties.Resources.pacman_up;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                pacman.Image = Properties.Resources.pacman_down;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Puntaje" + score;

            if(goleft)
            {
                pacman.Left -= speed;
            }
            if (goright)
            {
                pacman.Left += speed;
            }
            if (goup)
            {
                pacman.Top -= speed;
            }
            if (godown)
            {
                pacman.Top += speed;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "ghost")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "GAME OVER";
                        label2.Visible = true;
                        timer1.Stop();
                    }
                }
                if(x is PictureBox && x.Tag == "guinda")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        score += 10;
                    }
                }
                if (x is PictureBox && x.Tag == "uva")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        score += 15;
                    }
                }
            }

            pinkGhost.Left += ghost1x;
            pinkGhost.Top += ghost1y;
            redGhost.Left += ghost2x;
            redGhost.Top += ghost2y;
            if(pinkGhost.Left < 1 || pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2)
            {
                ghost1x = -ghost1x;
            }
            if (pinkGhost.Top < 1 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2)
            {
                ghost1y = -ghost1y;
            }
            if(redGhost.Left < 1 || redGhost.Left + redGhost.Width > ClientSize.Width - 2)
            {
                ghost2x = -ghost2x;
            }
            if (redGhost.Top < 1 || redGhost.Top + redGhost.Height > ClientSize.Height - 2)
            {
                ghost2y = -ghost2y;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //No se por que textbox y el boton no me dejan usar las flechas para juagar
            //Pero si se elimian estas herramientas las teclas si funcionan y el pacman se mueve
            string usuario = textBox1.Text;
            panel1.Hide();
            textBox1.Hide();
            button1.Hide();
            timer1.Start();
            
        }
    }
}

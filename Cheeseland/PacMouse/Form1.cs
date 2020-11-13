using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMouse
{
    public partial class game : Form
    {
        bool goup;
        bool godown;
        bool goleft;
        bool goright;

        bool gameover = true;

        int speed = 5;

        int cat1 = 6;
        int cat2 = 6;
        int cat3 = 6;

        int score = 0;

        public game()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && gameover==true)
            {
                goleft = true;
                mouse.Image = Properties.Resources.mouseLeft;
            }

            if (e.KeyCode == Keys.Down && gameover == true)
            {
                godown = true;
                mouse.Image = Properties.Resources.mouse;
            }

            if (e.KeyCode == Keys.Right && gameover == true)
            {
                goright = true;
                mouse.Image = Properties.Resources.mouseRight;
            }

            if (e.KeyCode == Keys.Up && gameover == true)
            {
                goup= true;
                mouse.Image = Properties.Resources.mouseUp;
            }

            if(e.KeyCode == Keys.Space)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "cheese")
                    {
                        x.Visible = true;
                        score = 0;
                        label2.Visible = false;
                        gameover = true;
                        mouse.Left = 17;
                        mouse.Top = 210;
                    }
                }
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score;

            //Aici se realizează mișcarea șoricelului cu ajutorul săgeților.
            //Variabilele de tip bool goleft, goright, goup, godown sunt declarate anterior.
            //Pentru cele 4 variabile sunt declarate funcțiile keyisup și keyisdown.
            //În funția keyisdown variabilele iau valoarea true dacă se apăsă tastele.
            //În funția keyisup variabilele iau valoarea false dacă nu mai sunt apăsate tastele.
            if (goleft)
            {
                mouse.Left -= speed;
            }

            if (goright)
            {
                mouse.Left += speed;
            }

            if(goup)
            {
                mouse.Top -= speed;
            }

            if (godown)
            {
                mouse.Top += speed;
            }

            //Se declară mișcarea inițială a pisicilor pe lateral.
            redCat.Left += cat1;
            orangeCat.Left += cat2;
            pinkCat.Left += cat3;

            //Dacă pisica roșie atinge unul dintre pereții laterali, viteza devine negativă,
            //astfel pisica merge în direcția opusă.
            if(redCat.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                cat1 = -cat1;
            }
            else if (redCat.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                cat1 = -cat1;
            }

            //Același lucru se întâmplă si pentru pisica portocalie.
            if (orangeCat.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                cat2 = -cat2;
            }
            else if (orangeCat.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                cat2 = -cat2;
            }

            //Același lucru se întâmplă si pentru pisica roz.
            if (pinkCat.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                cat3 = -cat3;
            }
            else if (pinkCat.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                cat3 = -cat3;
            }

            //În funcția foreach se verifică fiecare control x.
            foreach (Control x in this.Controls)
            {
                //Dacă x este un control de tip PictureBox și are tag-ul wall sau cat,
                //adică reprezintă un perete sau o pisică, și șoricelul îl atinge
                //jocul se termină, poziția șoricelului fiind resetată la cea de start
                //și aparând label-ul cu textul Game Over.
                if( x is PictureBox && x.Tag == "wall" || x.Tag =="cat")
                {
                    if(((PictureBox)x).Bounds.IntersectsWith(mouse.Bounds))
                    {
                        mouse.Left = 17;
                        mouse.Top = 210;
                        label2.Text = "Game Over";
                        label2.Visible = true;
                        gameover = false;
                    }
                    //În caz contrar, dacă valoarea scorului ajunge la 69
                    //jocul se termină, poziția șoricelului fiind resetată la cea de start
                    //și aparând label-ul cu textul You Won.
                    else if (score == 69)
                    {
                        mouse.Left = 17;
                        mouse.Top = 210;
                        label2.Text = "You Won";
                        label2.Visible = true;
                        label1.Text = "Score: " + score;
                        gameover = false;
                    }
                }
                //Dacă x este un control de tip PictureBox și are tag-ul cheese și x este vizibil,
                //și șoricelul îl atinge, atunci acesta devine invizibil pentru a putea fi
                //resetat jocul ulterior la apăsarea butonului Play Again, 
                //scorul crește.
                if (x is PictureBox && x.Tag == "cheese")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(mouse.Bounds) && x.Visible==true)
                    {
                        x.Visible = false;
                        score++;
                    }
                }
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "cheese")
                {
                    x.Visible = true;
                    score = 0;
                    label2.Visible = false;
                    gameover = true;
                    mouse.Left = 17;
                    mouse.Top = 210;
                }
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            rules r = new rules();
            r.ShowDialog();
        }

        //private void Button1_Click(object sender, EventArgs e)
        //{
           // Application.Restart();
       // }
    }
}

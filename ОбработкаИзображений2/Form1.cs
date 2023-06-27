using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ОбработкаИзображений2
{
    public partial class Form1 : Form
    {
        public static String pic = @"..\..\imgonline-com-ua-Resize-BumrOViEOCWNm.jpg";
        public static Bitmap Gauss = new Bitmap(pic);
        public static Bitmap Sobel = new Bitmap(pic);
        public Form1()
        {
            for (int x = 0; x < Gauss.Width; x++)
            {
                for (int y = 0; y < Gauss.Height; y++)
                {
                    Color c = Gauss.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    Gauss.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    Sobel.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            InitializeComponent();
            Bitmap b = new Bitmap(pic);
            pictureBox1.Image = b;
            int[] mas = new int[256];



            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    mas[gray] += 1;
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i+1, mas[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);


            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);
            pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);


            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);


                    if (gray + numericUpDown4.Value >= 255)
                    {
                        b.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else if (gray + numericUpDown4.Value <= 0)
                    {
                        b.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        b.SetPixel(x, y, Color.FromArgb(gray + (int)(numericUpDown4.Value), gray + (int)(numericUpDown4.Value), gray + (int)(numericUpDown4.Value)));
                    }
                }
            }
            pictureBox1.Image = b;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);

            int Q1 = (int)numericUpDown6.Value;
            int Q2 = (int)numericUpDown7.Value;


            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    if (gray < Q1) gray = 0;
                    else if (gray > Q2) gray = 255;
                    else gray = (byte)(255 * (gray - Q1) / (Q2 - Q1));

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = b;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);


            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);


                    if (gray > numericUpDown5.Value)
                    {
                        b.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                
                    else
                    {
                        b.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBox1.Image = b;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);


            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    
                    Color c = b.GetPixel(x, y);
                    int red = (c.R < (byte)(numericUpDown1.Value)) ? c.R : 255 - c.R;
                    int green = (c.G < (byte)(numericUpDown2.Value)) ? c.G : 255 - c.G;
                    int blue = (c.B < (byte)(numericUpDown3.Value)) ? c.B : 255 - c.B;

                    b.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    

                }
            }
            pictureBox1.Image = b;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);

            int Q1 = (int)numericUpDown6.Value;
            int Q2 = (int)numericUpDown7.Value;


            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    gray = (byte)(Q1 + gray * (Q2 - Q1) / 255);

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = b;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);

            float gamma = (checkBox1.Checked) ? (float)numericUpDown8.Value : 1 / (float)numericUpDown8.Value;

            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    gray = (byte)(255 * (Math.Pow((float)gray / 255, gamma)));

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = b;


        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button9.BackColor = colorDialog1.Color;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button10.BackColor = colorDialog1.Color;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button11.BackColor = colorDialog1.Color;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button12.BackColor = colorDialog1.Color;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button13.BackColor = colorDialog1.Color;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);

            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    if (gray <= numericUpDown9.Value) b.SetPixel(x, y, button9.BackColor);
                    else if (gray <= numericUpDown10.Value) b.SetPixel(x, y, button10.BackColor);
                    else if (gray <= numericUpDown11.Value) b.SetPixel(x, y, button11.BackColor);
                    else if (gray <= numericUpDown12.Value) b.SetPixel(x, y, button12.BackColor);
                    else b.SetPixel(x, y, button13.BackColor);

                }
            }
            pictureBox1.Image = b;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);
            int N = (int)numericUpDown13.Value;

            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    for (int i = 1; i <= N; i++)
                    {
                        if (gray <= i * 255/N && gray >= (i-1) * 255 / N)
                        {
                            gray = (byte)(((i * 255 / N) + ((i - 1) * 255 / N)) / 2);
                            b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                        }
                        
                    }


                }
            }
            pictureBox1.Image = b;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);

            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    gray = (byte)(1.0/64 * gray * (255 - gray));

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));


                }
            }
            pictureBox1.Image = b;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(Gauss);

            for (int x = 1; x < b.Width - 1; x++)
            {
                for (int y = 1; y < b.Height - 1; y++)
                {

                    Color a1 = Gauss.GetPixel(x - 1, y - 1);
                    Color a2 = Gauss.GetPixel(x, y - 1);
                    Color a3 = Gauss.GetPixel(x+1, y+1);
                    Color a4 = Gauss.GetPixel(x - 1, y);
                    Color a5 = Gauss.GetPixel(x, y);
                    Color a6 = Gauss.GetPixel(x + 1, y);
                    Color a7 = Gauss.GetPixel(x - 1, y + 1);
                    Color a8 = Gauss.GetPixel(x, y + 1);
                    Color a9 = Gauss.GetPixel(x + 1, y + 1);

                    byte gray = (byte)((a1.R + 2 * a2.R + a3.R + 2 * a4.R + 4 * a5.R + 2 * a6.R + a7.R + 2 * a8.R + a9.R) / 16);
                    

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));


                }
            }
                        
            pictureBox1.Image = b;
            Gauss = b;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(Gauss);

            for (int x = 1; x < b.Width - 1; x++)
            {
                for (int y = 1; y < b.Height - 1; y++)
                {

                    Color a1 = Sobel.GetPixel(x - 1, y - 1);
                    Color a2 = Sobel.GetPixel(x, y - 1);
                    Color a3 = Sobel.GetPixel(x + 1, y + 1);
                    Color a4 = Sobel.GetPixel(x - 1, y);
                    Color a5 = Sobel.GetPixel(x, y);
                    Color a6 = Sobel.GetPixel(x + 1, y);
                    Color a7 = Sobel.GetPixel(x - 1, y + 1);
                    Color a8 = Sobel.GetPixel(x, y + 1);
                    Color a9 = Sobel.GetPixel(x + 1, y + 1);

                    int p = -1 * a1.R + a3.R - 2 * a4.R + 2 * a6.R - a7.R + a9.R;
                    int q = a1.R + 2 * a2.R + a3.R - a7.R - 2 * a8.R - a9.R;

                    byte gray = (byte)(Math.Sqrt(Math.Pow(p,2) + Math.Pow(q,2)));

                    b.SetPixel(x, y, Color.FromArgb(gray, gray, gray));


                }
            }

            pictureBox1.Image = b;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pic);
            for (int x = 0; x < Gauss.Width; x++)
            {
                for (int y = 0; y < Gauss.Height; y++)
                {
                    Color c = b.GetPixel(x, y);

                    byte gray = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

                    Gauss.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = Gauss;
        }
    }
}

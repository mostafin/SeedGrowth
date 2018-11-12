using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace SeedGrown
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker = new BackgroundWorker();
        Bitmap bitmap;
        Graphics graphics;
        SeedGrowth seed;
        PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }
        
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            seed.Iterate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".bmp";
            save.FileName = "bitmapa";
            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName, ImageFormat.Bmp);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.Text == "losowe z promieniem R")
            {
                label6.Visible = true;           
                textBox3.Visible = true;          
            }
            else
            {
                label6.Visible = false;
                textBox3.Visible = false;
            }

            if(comboBox3.Text == "równomierne")
            {
                label8.Visible = true;
                label9.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
            }
            else
            {
                label8.Visible = false;
                label9.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
            }

            if (comboBox3.Text == "losowe" || comboBox3.Text == "losowe z promieniem R")
            {
                label7.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label7.Visible = false;
                textBox4.Visible = false;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            seed.stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pictureBox = pictureBox1;
            pictureBox1.Height = Convert.ToInt32(textBox2.Text);
            pictureBox1.Width = Convert.ToInt32(textBox1.Text);

            
            int size1 = (1 * Convert.ToInt32(textBox1.Text) / 3);
            int size2 = (1 * Convert.ToInt32(textBox2.Text) / 3);

            this.Height = Convert.ToInt32(1.1 *pictureBox1.Height);
            this.Width = Convert.ToInt32(1.35 * pictureBox1.Width);
            //int size1 = Convert.ToInt32(textBox1.Text);
            //int size2 = Convert.ToInt32(textBox2.Text);

            bitmap = new Bitmap(size1, size2);
            graphics = Graphics.FromImage(bitmap);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


            if (comboBox3.Text == "losowe z promieniem R")
                seed = new SeedGrowth(size1, size2, comboBox1.Text, comboBox2.Text, Convert.ToInt32(textBox4.Text), Convert.ToDouble(textBox3.Text), pictureBox1, bitmap);

            else if (comboBox3.Text == "równomierne")
                seed = new SeedGrowth(size1, size2, comboBox1.Text, comboBox2.Text, pictureBox1, bitmap, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
            else if (comboBox3.Text == "przez klikniecie")
                seed = new SeedGrowth(size1, size2, comboBox1.Text, comboBox2.Text, pictureBox1, bitmap);
            else
                seed = new SeedGrowth(size1, size2, comboBox1.Text, comboBox2.Text, Convert.ToInt32(textBox4.Text), pictureBox1, bitmap);
        }
       
    }
};

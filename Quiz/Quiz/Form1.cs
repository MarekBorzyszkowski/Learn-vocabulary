using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        string[] lines, lang;
        int[] Nums;
        int elemIndex = 0, correct = 0;
        bool toCorrect = false;

        private void randQueueGen()
        {
            Random rnd = new Random();
            int[] nums = new int[lines.Length - 1];
            for (int i = 0; i < lines.Length - 1; i++)
            {
                nums[i] = i + 1;
            }
            Nums = nums.OrderBy(x => rnd.Next()).ToArray();
        }

        private void endBoard()
        {
            MessageBox.Show("Your score : " + correct.ToString() +
                " / " + (lines.Length - 1).ToString());
            resetValues();
            return;
        }

        private void resetValues()
        {
            openFileDialog1.FileName = "openFileDialog1";
            button2.Visible = false;
            button1.Visible = true;
            label1.Text = "";
            label2.Text = "";
            label4.Text = "";
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            elemIndex = 0;
            correct = 0;
            toCorrect = false;
            Nums = null;
            lines = null;
            lang = null;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            button3.Visible = true;
            checkBox1.Visible = true;
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "openFileDialog1")
            {
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName == "openFileDialog1")
                {
                    MessageBox.Show("Choose a .txt file with words \n for quiz or create one");
                    return;
                }
            }
            //textBox1.Text = openFileDialog1.FileName;
            try
            {
                lines = File.ReadAllLines(@openFileDialog1.FileName, Encoding.UTF32);
            }
            catch(Exception a)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            //MessageBox.Show(lines[0]+"\n"+lines[2]);
            //MessageBox.Show(lines.Length.ToString());
            lang = lines[0].Split(' ');
            if (checkBox1.Checked == true)
            {
                Reverse();
            }
            button2.Visible = true;
            button1.Visible = false;
            label4.Text = "1 / " + (lines.Length - 1).ToString();
            label4.Visible = true;
            label1.Text = lang[0];
            label2.Text = lang[1];
            label1.Visible = true;
            label2.Visible = true;
            randQueueGen();
            elemIndex = 0;
            lang = lines[Nums[elemIndex]].Split(' ');
            if (checkBox1.Checked == true)
            {
                Reverse();
            }
            textBox1.Text = lang[0];
            textBox1.Visible = true;
            textBox2.Visible = true;
            progressBar1.Visible = true;
            button3.Visible = false;
            checkBox1.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        //    MessageBox.Show("Dziala");

            if (e.Control == true && e.KeyCode == Keys.R)
                {
                MessageBox.Show("Dziala");

                if (button2.Visible == true)
                {
                    button2.PerformClick();
                }
            }
        }

        private void Reverse()
        {
            string a = lang[0];
            lang[0] = lang[1];
            lang[1] = a;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Nums[elemIndex];
            if (textBox2.Text == lang[1])
            {
                
                progressBar1.Increment(100 / (lines.Length - 1));
                if (!toCorrect)
                {
                    correct++;
                }
                toCorrect = false;
                MessageBox.Show("Correct!");
                if (elemIndex+1 == lines.Length - 1)
                {
                    endBoard();
                    return;
                }
                elemIndex++;
                label4.Text = (elemIndex + 1).ToString() + " / " + (lines.Length - 1).ToString();
                lang = lines[Nums[elemIndex]].Split(' ');
                if (checkBox1.Checked == true)
                {
                    Reverse();
                }
                textBox1.Text = lang[0];
                label3.Visible = false;
                textBox3.Visible = false;
                textBox2.Text = "";
            }
            else
            {

                toCorrect = true;
                MessageBox.Show("Not correct :(");
                textBox3.Text = lang[1];
                label3.Visible = true;
                textBox3.Visible = true;
            }
        }
    }
}


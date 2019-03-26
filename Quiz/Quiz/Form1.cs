using System;
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
        //bool haveFile = false;
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
            String[] lines = File.ReadAllLines(@openFileDialog1.FileName, Encoding.UTF32);
            //MessageBox.Show(lines[0]+"\n"+lines[2]);
            //MessageBox.Show(lines.Length.ToString());
            button2.Visible = true;
            button1.Visible = false;
            label4.Text = "0 / " + (lines.Length-1).ToString();
            label4.Visible = true;
            label1.Text = "Pl";
            label2.Text = "En";
            label1.Visible = true;
            label2.Visible = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            //FileStream a = new FileStream(openFileDialog1.FileName,FileMode.Open, FileAccess.Read);
            String[] lines = File.ReadAllLines(@openFileDialog1.FileName, Encoding.UTF8);
            MessageBox.Show(lines[0]+"\n"+lines[3]);
            MessageBox.Show(lines.Length.ToString());
        }
    }
}
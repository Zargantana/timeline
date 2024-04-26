using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B64Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlgresult = openFileDialog1.ShowDialog();

            if ((dlgresult == DialogResult.OK) || (dlgresult == DialogResult.Yes))
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            byte[] FileContents = System.IO.File.ReadAllBytes(textBox1.Text);
            //byte[] FileContents = System.IO.File.ReadAllBytes(SelectFileAnimation1());
            textBox2.Text = System.Convert.ToBase64String(FileContents);
        }
    }
}

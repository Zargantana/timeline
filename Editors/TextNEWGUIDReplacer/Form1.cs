using System;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TextNEWGUIDReplacer
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
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            string contents = System.IO.File.ReadAllText(textBox1.Text);

            string[] separators = { "[NEWGUID]" };
            string[] parts = contents.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 1)
            {
                contents += parts[0];
                for (int i = 1; i < parts.Length; i++)
                {
                    contents += Guid.NewGuid().ToString() + parts[i];
                }
            }
            System.IO.File.WriteAllText(textBox1.Text + ".replaced", contents);
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            string contents = System.IO.File.ReadAllText(textBox1.Text);

            int i, j = 0;
            string beginning, ending;
            while (true)
            {
                i = contents.IndexOf("[NEWGUID]", j, contents.Length);
                if (i == -1) break;
                beginning = contents.Substring(0, i);
                ending = contents.Substring(i + 9);
                contents = beginning + Guid.NewGuid().ToString() + ending;
            }


            System.IO.File.WriteAllText(textBox1.Text + ".replaced", contents);
        }
    }
}

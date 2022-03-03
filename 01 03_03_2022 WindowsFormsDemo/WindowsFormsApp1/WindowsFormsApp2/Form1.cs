using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string filePath = @"./MyFiles/MyData.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWirte_Click(object sender, EventArgs e)
        {
            File.AppendAllText(filePath, "hello dora\n");
            ShowTableFromTxt();
        }

        private void btnreadAlltext_Click(object sender, EventArgs e)
        {
            label1.Text = File.ReadAllText(filePath);
        }

        private void btnReactLinmes_Click(object sender, EventArgs e)
        {
            ShowTableFromTxt();
        }

        private void ShowTableFromTxt()
        {
            string[] lines = File.ReadAllLines(filePath);
            int counter = 1;
            label1.Text = "";

            foreach (var line in lines)
            {
                label1.Text += counter++ + ". " + line + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTableFromTxt();
        }
    }
}

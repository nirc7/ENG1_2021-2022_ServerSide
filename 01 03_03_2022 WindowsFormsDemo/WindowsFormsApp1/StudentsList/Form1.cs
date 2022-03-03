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

namespace StudentsList
{
    public partial class Form1 : Form
    {
        List<Student> ls = new List<Student>();
        string path = "MyStudentsData.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Student s = new Student() { Name="avi", Grade=100};
            ls.Add(new Student()
            {
                Name = txtName.Text,
                Grade = int.Parse(txtGrade.Text)
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var stu in ls)
            {
                File.AppendAllText(path, stu.ToString() + "\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] data = line.Split(',');
                ls.Add(new Student()
                {
                    Name = data[0],
                    Grade = int.Parse(data[1])
                });
            }
        }
    }
}

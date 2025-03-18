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

namespace BestDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (RoleCheck() == "admin")
            {
                button4.Visible = true;
            }
        }
        private string RoleCheck()
        {
            string role = null;
            string line;
            StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\text.txt");
            // "C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\text.txt"
            // DataRoleWay
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                role = line;
                line = sr.ReadLine();
            }
            sr.Close();
            Console.ReadLine();


            return role;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BestDB1 BD1 = new BestDB1();
            BD1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BestDBTFacultet BD2 = new BestDBTFacultet();
            BD2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BestDBKafedra BD3 = new BestDBKafedra();
            BD3.ShowDialog();
        }
    }
}

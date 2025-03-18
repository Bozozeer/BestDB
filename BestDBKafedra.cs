using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestDB
{
    public partial class BestDBKafedra : Form
    {
        public Helper HelperExemp = new Helper();

        static string connectionString = Helper.getConnectionString();
        public BestDBKafedra()
        {
            InitializeComponent();
            LoadRecords();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddFormKafedra ADS = new AddFormKafedra();
            ADS.ShowDialog();
            //int id = Convert.ToInt32(idTxt.Text);
            //string first_name = first_nameTxt.Text;
            //string last_name = last_nameTxt.Text;

            //AddRecord(id, first_name, last_name);
            //MessageBox.Show("Запись успешно добавлена!", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //LoadRecords();
        }

        public void LoadRecords()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM kafedra";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            UpdateFormKafedra fm2 = new UpdateFormKafedra();
            fm2.ShowDialog();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            DeleteFormKafedra fm4 = new DeleteFormKafedra();
            fm4.ShowDialog();
            /*
            int id = Convert.ToInt32(idTxt.Text);
            if (int.TryParse(idTxt.Text, out id))
            {
                DeleteRecord(id);
                MessageBox.Show("Запись успешно удалена!", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный ID записи!", "Ошибка удаления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void BestDB1_Load(object sender, EventArgs e)
        {
            if (RoleCheck() == "admin" || RoleCheck() == "teacher")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        private string RoleCheck()
        {
            string role = null;
            string line;
            StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\text.txt");
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SearchFormKafedra sf = new SearchFormKafedra();
            sf.Owner = this;
            sf.Show();
        }
    }
}

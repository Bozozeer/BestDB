using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestDB
{
    public partial class ForgotThePassword : Form
    {
        public Helper HelperExemp = new Helper();
        string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;

        static int attempt;
        public ForgotThePassword()
        {
            InitializeDatabaseConnection();
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT help_word FROM account";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void InitializeDatabaseConnection()
        {

            connection = new OleDbConnection(connectionString);
        }

        private bool AuthCheck(string help_word)
        {
            int result;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT login, password, help_word FROM account WHERE help_word=@help_word;";

                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@help_word", help_word);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            string lgn = reader.GetString(0);
                            string passwd = reader.GetString(1);
                            string Hp_Wd = reader.GetString(2);
                            if (Hp_Wd == help_word)
                            {
                                MessageBox.Show($"Ваш логин: {lgn}, ваш пароль: {passwd}");
                                return true;
                            }

                        }
                    }
                    else if (attempt == 5)
                    {
                        MessageBox.Show("Вы превысили кол-во попыток", "Выход", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                }
                attempt++;
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AuthCheck(textBox1.Text))
            {

            }
            else
            {
                MessageBox.Show("Неверные учётные данные", "Ошибка");
            }

        }

        private void ForgotThePassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (AuthCheck(textBox1.Text))
            {

            }
            else
            {
                MessageBox.Show("Неверные учётные данные", "Ошибка");
            }

        }
    }
}

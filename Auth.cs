using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace BestDB
{
    
    public partial class Auth : Form
    {
        public Helper HelperExemp = new Helper();
        string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;
        
        static int attempt;
        public Auth()
        {
            InitializeDatabaseConnection();
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT login, password FROM account";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void InitializeDatabaseConnection()
        {
            
            connection = new OleDbConnection(connectionString);
        }
        private bool AuthCheck(string login, string password)
        {
            int result;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT login, password, role FROM account WHERE login=@login AND password=@passwd;";

                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@passwd", password);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            string log = reader.GetString(0);
                            string passwd = reader.GetString(1);
                            string role = reader.GetString(2);
                            if(log == login & passwd == password)
                            {
                                UserAuthTxt(role);
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
            if(AuthCheck(loginTxt.Text, passwordTxt.Text))
            {
                this.Hide();
                var Form1 = new Main();
                Form1.Closed += (s, args) => this.Close();
                Form1.Show();

                //Form1 fm1 = new Form1();
                //fm1.ShowDialog();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Неверные учётные данные", "Ошибка");
            }
            
        }

        private void loginTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void passwordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {

        }
        private static void UserAuthTxt(string role)
        {

            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\text.txt");
                // C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\text.txt
                // "C:\\Users\\yusup\\Desktop\\BestDB\\text.txt"
                // "D:\\Games\\Программы\\BestDB\\text.txt"
                sw.WriteLine($"{role}");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForgotThePassword ftp = new ForgotThePassword();
            ftp.ShowDialog();
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }
    }
}

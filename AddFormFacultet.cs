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
    public partial class AddFormFacultet : Form
    {
        public Helper HelperExemp = new Helper();
        static string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;

        public AddFormFacultet()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadData();
            DisplayRecord(currentRecordIndex);
        }

        private void InitializeDatabaseConnection()
        {
            connection = new OleDbConnection(connectionString);
        }

        private void LoadData()
        {
            string query = "SELECT * FROM facultet";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void DisplayRecord(int index)
        {
            if (dataTable.Rows.Count > 0)
            {
                short_nameTxt.Text = dataTable.Rows[index]["short_name"].ToString();
                name_facultetTxt.Text = dataTable.Rows[index]["name_facultet"].ToString();
            }
        }

        public static void AddRecord(string short_name, string name_facultet)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO facultet (short_name, name_facultet) VALUES (@short_name, @name_facultet)";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@short_name", short_name);
                command.Parameters.AddWithValue("@name_facultet", name_facultet);

                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (currentRecordIndex > 0)
            {
                currentRecordIndex--;
                DisplayRecord(currentRecordIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentRecordIndex < dataTable.Rows.Count - 1)
            {
                currentRecordIndex++;
                DisplayRecord(currentRecordIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string short_name = short_nameTxt.Text;
            string name_facultet = name_facultetTxt.Text;

            AddRecord(short_name, name_facultet);
        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void idTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void AddFormFacultet_Load(object sender, EventArgs e)
        {

        }
    }
}

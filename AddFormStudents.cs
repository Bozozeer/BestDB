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
    public partial class AddFormStudents : Form
    {
        public Helper HelperExemp = new Helper();
        static string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;

        public AddFormStudents()
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
            string query = "SELECT * FROM student";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void DisplayRecord(int index)
        {
            if (dataTable.Rows.Count > 0)
            {
                idTxt.Text = dataTable.Rows[index]["id"].ToString();
                first_nameTxt.Text = dataTable.Rows[index]["first_name"].ToString();
                last_nameTxt.Text = dataTable.Rows[index]["last_name"].ToString();
                facultetTxt.Text = dataTable.Rows[index]["facultet"].ToString();
            }
        }

        public static void AddRecord(int id, string first_name, string last_name, string facultet)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO student ([id], [first_name], [last_name], [facultet]) VALUES (@id, @first_name, @last_name, @facultet)";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@facultet", facultet);

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
            int id = Convert.ToInt32(idTxt.Text);
            string first_name = first_nameTxt.Text;
            string last_name = last_nameTxt.Text;
            string facultet = facultetTxt.Text;

            AddRecord(id, first_name, last_name, facultet);
        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void idTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void AddFormStudents_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void first_nameTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

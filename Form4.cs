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
    public partial class Form4 : Form
    {
        public Helper HelperExemp = new Helper();
        static string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;

        public Form4()
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
            string query = "SELECT * FROM account";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void DisplayRecord(int index)
        {
            if (dataTable.Rows.Count > 0)
            {
                idTxt.Text = dataTable.Rows[index]["id"].ToString();
                textBox1.Text = dataTable.Rows[index]["login"].ToString();
                textBox2.Text = dataTable.Rows[index]["password"].ToString();
                textBox3.Text = dataTable.Rows[index]["role"].ToString();
                textBox4.Text = dataTable.Rows[index]["help_word"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public static void DeleteRecord(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM [account] WHERE [id] = @id";

                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно удалена!", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTxt.Text);
            if (int.TryParse(idTxt.Text, out id))
            {
                DeleteRecord(id);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный ID записи!", "Ошибка удаления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

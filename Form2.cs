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
    public partial class Form2 : Form
    {
        public Helper HelperExemp = new Helper();
        static string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;
        public Form2()
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
            if(dataTable.Rows.Count > 0)
            {
                idTxt.Text = dataTable.Rows[index]["id"].ToString();
                loginTxt.Text = dataTable.Rows[index]["login"].ToString();
                passwordTxt.Text = dataTable.Rows[index]["password"].ToString();
                roleTxt.Text = dataTable.Rows[index]["role"].ToString();
                helpTxt.Text = dataTable.Rows[index]["help_word"].ToString();
            }
        }

        private void UpdateRecord(int id, string login, string password, string role, string help_word)
        {
            string query = "UPDATE account SET [login] = @login, [password] = @password, [role] = @role, [help_word] = @help_word WHERE [id] = @id";
            using(OleDbCommand command = new OleDbCommand(query, connection))
            {

                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@help_word", help_word);
                command.Parameters.AddWithValue("@id", id);

                try 
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно обновлена!", "Обновление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить запись!", "Неудачное обновление записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении записи: {ex.Message}", "Ошибка обновления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                { 
                    connection.Close(); 
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(currentRecordIndex > 0)
            {
                currentRecordIndex--;
                DisplayRecord(currentRecordIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(currentRecordIndex < dataTable.Rows.Count - 1)
            {
                currentRecordIndex++;
                DisplayRecord(currentRecordIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTxt.Text);
            string login = Convert.ToString(loginTxt.Text);
            string password = Convert.ToString(passwordTxt.Text);
            string role = Convert.ToString(roleTxt.Text);
            string help_word = Convert.ToString(helpTxt.Text);

            UpdateRecord(id, login, password, role, help_word);
         //   Form1.LoadRecords();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void first_nameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void last_nameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void idTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}

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
    public partial class UpdateFormKafedra : Form
    {
        public Helper HelperExemp = new Helper();
        static string connectionString = Helper.getConnectionString();
        private OleDbConnection connection;
        private int currentRecordIndex = 0;
        private DataTable dataTable;
        public UpdateFormKafedra()
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
            string query = "SELECT * FROM kafedra";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void DisplayRecord(int index)
        {
            if (dataTable.Rows.Count > 0)
            {
                idTxt.Text = dataTable.Rows[index]["id"].ToString();
                short_nameTxt.Text = dataTable.Rows[index]["short_name"].ToString();
                name_kafedraTxt.Text = dataTable.Rows[index]["name_kafedra"].ToString();
                facultetTxt.Text = dataTable.Rows[index]["facultet"].ToString();
            }
        }

        private void UpdateRecord(int id, string short_name, string name_kafedra, string facultet)
        {
            string query = "UPDATE kafedra SET short_name = @short_name, name_kafedra = @name_kafedra, facultet = @facultet WHERE id = @id";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {

                command.Parameters.AddWithValue("@short_name", short_name);
                command.Parameters.AddWithValue("@name_kafedra", name_kafedra);
                command.Parameters.AddWithValue("@facultet", facultet);
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

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTxt.Text);
            string short_name = short_nameTxt.Text;
            string name_kafedra = name_kafedraTxt.Text;
            string facultet = facultetTxt.Text;

            UpdateRecord(id, short_name, name_kafedra, facultet);
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
    }
}

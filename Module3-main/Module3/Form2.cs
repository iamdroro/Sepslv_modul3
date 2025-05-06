using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2
{
    public partial class Form2 : Form
    {
        static bool IsEdit = false;
        static string Name = "";
        public Form2(DataRow DataRow)
        {
            InitializeComponent();
            IsEdit = true;
            this.CenterToScreen();
            GetTypes();
            comboBox1.SelectedItem = DataRow[0].ToString();
            textBox2.Text = DataRow[1].ToString();
            textBox3.Text = DataRow[2].ToString();
            textBox4.Text = DataRow[3].ToString();
            textBox5.Text = DataRow[4].ToString();
            textBox6.Text = DataRow[5].ToString();
            textBox7.Text = DataRow[6].ToString();
            textBox1.Text = DataRow[7].ToString();
            Name = DataRow[1].ToString();
        }

        private void GetTypes()
        {
            string ConnStr = "Server=PC310-08;DataBase=test11;Trusted_Connection=True;Encrypt=false;";
            using (SqlConnection Connection = new SqlConnection(ConnStr))
            {
                Connection.Open();
                using (SqlCommand Cmd = new SqlCommand("select DISTINCT Тип_партнера FROM Partners_import", Connection))
                using (SqlDataAdapter Adapter = new SqlDataAdapter(Cmd))
                {
                    DataTable Dt = new DataTable();
                    Adapter.Fill(Dt);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        comboBox1.Items.Add($"{Dt.Rows[i][0]}");
                    }
                }
            }

        }

        public Form2()
        {
            InitializeComponent();
            this.CenterToScreen();
            GetTypes();
            IsEdit = false;
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не все поля заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (int.Parse(textBox1.Text) < 0)
            {
                MessageBox.Show("Рейтинг должен быть положительным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (IsEdit)
            {
                string ConnStr = "Server=PC310-08;DataBase=test11;Trusted_Connection=True;Encrypt=false;";
                using (SqlConnection Connection = new SqlConnection(ConnStr))
                {
                    Connection.Open();
                    using (SqlCommand Cmd = new SqlCommand("UPDATE Partners_import set Тип_партнера = @value1, Наименование_партнера = @value2, Директор= @value3, Электронная_почта_партнера= @value4, Телефон_партнера= @value5, Юридический_адрес_партнера=@value6, ИНН= @value7, Рейтинг = @value8 Where Наименование_партнера = @name", Connection))
                    {
                        Cmd.Parameters.AddWithValue("@value1", comboBox1.SelectedItem.ToString());
                        Cmd.Parameters.AddWithValue("@value2", textBox2.Text);
                        Cmd.Parameters.AddWithValue("@value3", textBox3.Text);
                        Cmd.Parameters.AddWithValue("@value4", textBox4.Text);
                        Cmd.Parameters.AddWithValue("@value5", textBox5.Text);
                        Cmd.Parameters.AddWithValue("@value6", textBox6.Text);
                        Cmd.Parameters.AddWithValue("@value7", textBox7.Text);
                        Cmd.Parameters.AddWithValue("@value8", textBox1.Text);
                        Cmd.Parameters.AddWithValue("@name", Name);
                        Cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                string ConnStr = "Server=PC310-08;DataBase=test11;Trusted_Connection=True;Encrypt=false;";
                using (SqlConnection Connection = new SqlConnection(ConnStr))
                {
                    Connection.Open();
                    using (SqlCommand Cmd = new SqlCommand("INSERT INTO Partners_import Values(@value1, @value2, @value3, @value4, @value5, @value6,@value7,@value8)", Connection))
                    {
                        Cmd.Parameters.AddWithValue("@value1", comboBox1.SelectedItem.ToString());
                        Cmd.Parameters.AddWithValue("@value2", textBox2.Text);
                        Cmd.Parameters.AddWithValue("@value3", textBox3.Text);
                        Cmd.Parameters.AddWithValue("@value4", textBox4.Text);
                        Cmd.Parameters.AddWithValue("@value5", textBox5.Text);
                        Cmd.Parameters.AddWithValue("@value6", textBox6.Text);
                        Cmd.Parameters.AddWithValue("@value7", textBox7.Text);
                        Cmd.Parameters.AddWithValue("@value8", textBox1.Text);
                        Cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

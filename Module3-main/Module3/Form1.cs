using Microsoft.Data.SqlClient;
using System.Data;

namespace Module2
{

    public partial class Form1 : Form
    {
        DataTable Material_type_import = new DataTable();
        DataTable Partner_products_import = new DataTable();
        DataTable Partners_import = new DataTable();
        DataTable Product_type_import = new DataTable();
        DataTable Products_import = new DataTable();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            string ConnStr = "Server=PC310-08;DataBase=test11;Trusted_Connection=True;Encrypt=false;";
            using (SqlConnection Connection = new SqlConnection(ConnStr))
            {
                Connection.Open();
                using (SqlCommand Cmd = new SqlCommand("select * FROM Material_type_import", Connection))
                using (SqlDataAdapter Adapter = new SqlDataAdapter(Cmd))
                    Adapter.Fill(Material_type_import);

                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM Partner_products_import", Connection))
                using (SqlDataAdapter Adapter = new SqlDataAdapter(Cmd))
                    Adapter.Fill(Partner_products_import);

                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM Partners_import", Connection))
                using (SqlDataAdapter Adapter = new SqlDataAdapter(Cmd))
                    Adapter.Fill(Partners_import);

                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM Product_type_import", Connection))
                using (SqlDataAdapter Adapter = new SqlDataAdapter(Cmd))
                    Adapter.Fill(Product_type_import);

                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM Products_import", Connection))
                using (SqlDataAdapter Adapter = new SqlDataAdapter(Cmd))
                    Adapter.Fill(Products_import);
            }
            for (int i = 0; i < Partners_import.Rows.Count; i++)
            {
                int CountSale = 0;

                for (int j = 0; j < Partner_products_import.Rows.Count; j++)
                {
                    string Partner = Partner_products_import.Rows[j][1].ToString();
                    string Deal = Partners_import.Rows[i][1].ToString();
                    if (Partner == Deal)
                        CountSale += int.Parse(Partner_products_import.Rows[j][2].ToString());
                }
                int Discount = 0;
                if (CountSale <= 10000) Discount = 0;
                else if (10000 < CountSale && CountSale <= 50000) Discount = 5;
                else if (50000 < CountSale && CountSale <= 300000) Discount = 10;
                else if (300000 <= CountSale) Discount = 15;

                Label label = new Label()
                {

                    Text = $"{Partners_import.Rows[i][0]} | {Partners_import.Rows[i][1]}\n{Partners_import.Rows[i][2]}\n{Partners_import.Rows[i][4]}\nРейтинг: {Partners_import.Rows[i][7]}",
                    Height = 170,
                    Width = flowLayoutPanel1.Width-10,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = Partners_import.Rows[i],
                    Padding = new Padding(15),
                    Font = new Font("Segou UI", 15),
                    Margin = new Padding(5)
                };
                flowLayoutPanel1.Controls.Add(label);
                flowLayoutPanel1.AutoSize = false;

                Label label1 = new Label()
                {
                    Text = $"{Discount}%\n{Partners_import.Rows[i][2]}",
                    Tag = Partners_import.Rows[i],
                    AutoSize = false,
                    Font = new Font("Segou UI", 15),
                    Location = new Point(label.Width - 140,30),
                    Padding = new Padding(0),
                   
                    Parent = label
                };

            }

        }

        private void Label_Click (object? sender, EventArgs e)
        {
            this.Hide( );
            new Form2((DataRow) ((Label) sender).Tag).Show( );
        }

        private void Form1_FormClosing (object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click (object sender, EventArgs e)
        {
            this.Hide( );
            new Form2( ).Show( );
        }
    }
}

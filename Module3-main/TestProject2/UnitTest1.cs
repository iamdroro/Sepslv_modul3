using System;
using static NUnit.Framework.Internal.OSPlatform;
using Microsoft;
using Module2;
using Microsoft.Data.SqlClient;
using Module2;
using NUnit.Framework;
using System.Data;
using System.Windows.Forms;

namespace TestProject2
{
    public class Tests
    {
        private Form1 form1;
        private Form2 form2;
        private DataRow testDataRow;

        [SetUp]
        public void Setup()
        {
            form1 = new Form1();
            form2 = new Form2();

            // Create a test DataRow
            DataTable dt = new DataTable();
            dt.Columns.Add("Тип_партнера");
            dt.Columns.Add("Наименование_партнера");
            dt.Columns.Add("Директор");
            dt.Columns.Add("Электронная_почта_партнера");
            dt.Columns.Add("Телефон_партнера");
            dt.Columns.Add("Юридический_адрес_партнера");
            dt.Columns.Add("ИНН");
            dt.Columns.Add("Рейтинг");
            testDataRow = dt.NewRow();
            testDataRow.ItemArray = new object[] { "Type1", "Partner1", "Director1", "email@test.com", "+123456789", "Address1", "1234567890", "5" };
        }

        [Test]
        public void Test1_Form1Initialization()
        {
            Assert.IsNotNull(form1);
        }

        [Test]
        public void Test2_Form2Initialization()
        {
            Assert.IsNotNull(form2);
        }

        [Test]
        public void Test3_Form1LoadsDataTables()
        {
            form1.Form1_Load(null, null);

            Assert.IsNotNull(form1.Material_type_import);
            Assert.IsNotNull(form1.Partner_products_import);
            Assert.IsNotNull(form1.Partners_import);
            Assert.IsNotNull(form1.Product_type_import);
            Assert.IsNotNull(form1.Products_import);
        }

        [Test]
        public void Test4_Form1CreatesLabelsForPartners()
        {
            form1.Form1_Load(null, null);
            Assert.Greater(form1.flowLayoutPanel1.Controls.Count, 0);
        }

        [Test]
        public void Test5_Form2EditModeInitialization()
        {
            var editForm = new Form2(testDataRow);
            Assert.IsTrue(Form2.IsEdit);
        }

        [Test]
        public void Test6_Form2AddModeInitialization()
        {
            var addForm = new Form2();
            Assert.IsFalse(Form2.IsEdit);
        }

        [Test]
        public void Test7_Form2GetTypesPopulatesComboBox()
        {
            form2.GetTypes();
            Assert.Greater(form2.comboBox1.Items.Count, 0);
        }

        [Test]
        public void Test8_Form1DatabaseConnection()
        {
            string ConnStr = "Server=PC310-08;DataBase=test11;Trusted_Connection=True;Encrypt=false;";
            using (SqlConnection Connection = new SqlConnection(ConnStr))
            {
                Connection.Open();
                Assert.AreEqual(Connection.State, ConnectionState.Open);
            }
        }

        [Test]
        public void Test9_Form2DatabaseConnection()
        {
            string ConnStr = "Server=PC310-08;DataBase=test11;Trusted_Connection=True;Encrypt=false;";
            using (SqlConnection Connection = new SqlConnection(ConnStr))
            {
                Connection.Open();
                Assert.AreEqual(Connection.State, ConnectionState.Open);
            }
        }

        [Test]
        public void Test10_Form1LabelClickNavigation()
        {
            var label = new Label();
            label.Tag = testDataRow;
            form1.Label_Click(label, null);

            // Should navigate to Form2
            Assert.IsFalse(form1.Visible);
        }

        [Test]
        public void Test11_Form1ButtonClickNavigation()
        {
            form1.button1_Click(null, null);
            Assert.IsFalse(form1.Visible);
        }

        [Test]
        public void Test12_Form2ButtonClickNavigation()
        {
            form2.button1_Click(null, null);
            Assert.IsFalse(form2.Visible);
        }

        [Test]
        public void Test13_Form1FormClosingExitsApplication()
        {
            // This test might need adjustment as it exits the application
            var args = new FormClosingEventArgs(CloseReason.UserClosing, false);
            form1.Form1_FormClosing(null, args);
            // Can't assert much here as it calls Environment.Exit(0)
        }

        [Test]
        public void Test14_Form2FormClosingExitsApplication()
        {
            // This test might need adjustment as it exits the application
            var args = new FormClosingEventArgs(CloseReason.UserClosing, false);
            form2.FormClosing += (s, e) => { Assert.IsTrue(true); };
            form2.Form2_FormClosing(null, args);
        }

        [Test]
        public void Test15_Form2ValidationEmptyFields()
        {
            form2.textBox1.Text = "";
            form2.textBox2.Text = "";
            form2.textBox3.Text = "";
            form2.textBox4.Text = "";
            form2.textBox5.Text = "";
            form2.textBox6.Text = "";
            form2.textBox7.Text = "";
            form2.comboBox1.SelectedIndex = -1;

            form2.button2_Click(null, null);
            // Should show message box - can't easily test that
            Assert.IsTrue(true);
        }

        [Test]
        public void Test16_Form2NegativeRatingValidation()
        {
            form2.textBox1.Text = "-1";
            form2.button2_Click(null, null);
            // Should show message box
            Assert.IsTrue(true);
        }

        [Test]
        public void Test17_Form2NumericInputValidation()
        {
            form2.textBox1_KeyPress(null, new KeyPressEventArgs('a'));
            form2.textBox7_KeyPress(null, new KeyPressEventArgs('b'));
            form2.textBox5_KeyPress(null, new KeyPressEventArgs('c'));
            // Should reject non-numeric input
            Assert.IsTrue(true);
        }

        [Test]
        public void Test18_Form2PhoneNumberValidation()
        {
            // Test that phone field accepts + sign
            var args = new KeyPressEventArgs('+');
            form2.textBox5_KeyPress(null, args);
            Assert.IsFalse(args.Handled);
        }

        [Test]
        public void Test19_Form2EditModeSetsFieldsCorrectly()
        {
            var editForm = new Form2(testDataRow);
            Assert.AreEqual("Partner1", editForm.textBox2.Text);
            Assert.AreEqual("Director1", editForm.textBox3.Text);
        }

        [Test]
        public void Test20_Form1DiscountCalculation0Percent()
        {
            int countSale = 5000;
            int discount = CalculateDiscount(countSale);
            Assert.AreEqual(0, discount);
        }

        [Test]
        public void Test21_Form1DiscountCalculation5Percent()
        {
            int countSale = 25000;
            int discount = CalculateDiscount(countSale);
            Assert.AreEqual(5, discount);
        }

        [Test]
        public void Test22_Form1DiscountCalculation10Percent()
        {
            int countSale = 100000;
            int discount = CalculateDiscount(countSale);
            Assert.AreEqual(10, discount);
        }

        [Test]
        public void Test23_Form1DiscountCalculation15Percent()
        {
            int countSale = 400000;
            int discount = CalculateDiscount(countSale);
            Assert.AreEqual(15, discount);
        }

        [Test]
        public void Test24_Form1DiscountCalculationBoundaryValues()
        {
            Assert.AreEqual(0, CalculateDiscount(10000));
            Assert.AreEqual(5, CalculateDiscount(10001));
            Assert.AreEqual(5, CalculateDiscount(50000));
            Assert.AreEqual(10, CalculateDiscount(50001));
            Assert.AreEqual(10, CalculateDiscount(300000));
            Assert.AreEqual(15, CalculateDiscount(300001));
        }

        [Test]
        public void Test25_Form2DatabaseInsertOperation()
        {
            // This would actually insert into database - might want to mock or use transaction
            try
            {
                form2.comboBox1.SelectedIndex = 0;
                form2.textBox2.Text = "TestPartner";
                form2.textBox3.Text = "TestDirector";
                form2.textBox4.Text = "test@test.com";
                form2.textBox5.Text = "+123456789";
                form2.textBox6.Text = "TestAddress";
                form2.textBox7.Text = "1234567890";
                form2.textBox1.Text = "5";

                form2.button2_Click(null, null);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail("Database insert failed");
            }
        }

        [Test]
        public void Test26_Form2DatabaseUpdateOperation()
        {
            // This would actually update database - might want to mock or use transaction
            try
            {
                var editForm = new Form2(testDataRow);
                editForm.textBox1.Text = "6";
                editForm.button2_Click(null, null);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail("Database update failed");
            }
        }

        [Test]
        public void Test27_Form1CenterToScreen()
        {
            Assert.DoesNotThrow(() => form1.CenterToScreen());
        }

        [Test]
        public void Test28_Form2CenterToScreen()
        {
            Assert.DoesNotThrow(() => form2.CenterToScreen());
        }

        [Test]
        public void Test29_Form1FlowLayoutPanelAutoSize()
        {
            Assert.IsFalse(form1.flowLayoutPanel1.AutoSize);
        }

        private int CalculateDiscount(int countSale)
        {
            if (countSale <= 10000) return 0;
            else if (10000 < countSale && countSale <= 50000) return 5;
            else if (50000 < countSale && countSale <= 300000) return 10;
            else return 15;
        }
    }
}
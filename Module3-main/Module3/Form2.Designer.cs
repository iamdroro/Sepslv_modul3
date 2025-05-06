namespace Module2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            comboBox1 = new ComboBox();
            label8 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(434, 114);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 1;
            label1.Text = "Тип партнёра";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(434, 170);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 3;
            label2.Text = "ФИО партнёра";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(278, 193);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(403, 27);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(415, 225);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 5;
            label3.Text = "ФИО директора";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(278, 248);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(403, 27);
            textBox3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(377, 288);
            label4.Name = "label4";
            label4.Size = new Size(220, 20);
            label4.TabIndex = 7;
            label4.Text = "Электронная почта партнёра";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(278, 311);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(403, 27);
            textBox4.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(417, 352);
            label5.Name = "label5";
            label5.Size = new Size(143, 20);
            label5.TabIndex = 9;
            label5.Text = "Телефон партнёра";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(278, 375);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(403, 27);
            textBox5.TabIndex = 8;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(390, 409);
            label6.Name = "label6";
            label6.Size = new Size(213, 20);
            label6.TabIndex = 11;
            label6.Text = "Физический адрес партнёра";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(278, 432);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(403, 27);
            textBox6.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(449, 466);
            label7.Name = "label7";
            label7.Size = new Size(43, 20);
            label7.TabIndex = 13;
            label7.Text = "ИНН";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(278, 489);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(403, 27);
            textBox7.TabIndex = 12;
            textBox7.KeyPress += textBox7_KeyPress;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(278, 139);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(403, 28);
            comboBox1.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.Location = new Point(410, 519);
            label8.Name = "label8";
            label8.Size = new Size(137, 20);
            label8.TabIndex = 16;
            label8.Text = "Рейтинг партнера";
            label8.Click += label8_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(278, 541);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(403, 27);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(103, 186, 128);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(839, 3);
            button1.Name = "button1";
            button1.Size = new Size(132, 57);
            button1.TabIndex = 17;
            button1.Text = "<--- Назад";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(103, 186, 128);
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(341, 26);
            button2.Name = "button2";
            button2.Size = new Size(291, 72);
            button2.TabIndex = 18;
            button2.Text = "Сохранить нового партнёра";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 232, 211);
            ClientSize = new Size(973, 579);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(textBox7);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Мастер Пол | Редактирование/Добавление";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
        private ComboBox comboBox1;
        private Label label8;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
    }
}
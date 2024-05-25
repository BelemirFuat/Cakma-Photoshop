namespace cakmaPhotoshopV2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label2 = new Label();
            comboBox3 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(823, 833);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(829, 45);
            label1.Name = "label1";
            label1.Size = new Size(122, 29);
            label1.TabIndex = 1;
            label1.Text = "Tool Seçin";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Bahnschrift", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nokta Seçici", "Bölge Seçici" });
            comboBox1.Location = new Point(829, 103);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(202, 32);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Bahnschrift", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Mean filter", "Median filter", "Gaussian filter", "Kenar filtreleme ile keskinleştirme", "Konvolüsyon yöntemi ile netleştirme" });
            comboBox2.Location = new Point(829, 217);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(202, 32);
            comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(829, 160);
            label2.Name = "label2";
            label2.Size = new Size(135, 29);
            label2.TabIndex = 3;
            label2.Text = "Filtre Seçin";
            // 
            // comboBox3
            // 
            comboBox3.Font = new Font("Bahnschrift", 12F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "3x3", "5x5", "7x7", "9x9", "11x11", "13x13" });
            comboBox3.Location = new Point(829, 332);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(202, 32);
            comboBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(829, 275);
            label3.Name = "label3";
            label3.Size = new Size(152, 29);
            label3.TabIndex = 5;
            label3.Text = "Şablon Seçin";
            // 
            // button1
            // 
            button1.Font = new Font("Bahnschrift", 14.25F);
            button1.Location = new Point(829, 421);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(216, 85);
            button1.TabIndex = 7;
            button1.Text = "Resim Yükleyin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Bahnschrift", 14.25F);
            button2.Location = new Point(829, 537);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(216, 85);
            button2.TabIndex = 8;
            button2.Text = "Seçili filtreyi Uygulayın";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Bahnschrift", 14.25F);
            button3.Location = new Point(829, 653);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(216, 85);
            button3.TabIndex = 9;
            button3.Text = "Tüm noktaları temizleyin";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(943, 781);
            label4.Name = "label4";
            label4.Size = new Size(0, 29);
            label4.TabIndex = 10;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Items.AddRange(new object[] { "Tıklanan Noktalar" });
            listBox1.Location = new Point(2327, 70);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(157, 664);
            listBox1.TabIndex = 11;
            listBox1.Visible = false;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Items.AddRange(new object[] { "Kenarlar" });
            listBox2.Location = new Point(2168, 70);
            listBox2.Margin = new Padding(3, 4, 3, 4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(416, 664);
            listBox2.TabIndex = 12;
            listBox2.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(2226, 22);
            label5.Name = "label5";
            label5.Size = new Size(203, 29);
            label5.TabIndex = 13;
            label5.Text = "Tıklanan Noktalar";
            label5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(2415, 22);
            label6.Name = "label6";
            label6.Size = new Size(107, 29);
            label6.TabIndex = 14;
            label6.Text = "Kenarlar";
            label6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(2373, 752);
            label7.Name = "label7";
            label7.Size = new Size(203, 29);
            label7.TabIndex = 15;
            label7.Text = "Tıklanan Noktalar";
            label7.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(1051, 0);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(746, 833);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1801, 839);
            Controls.Add(pictureBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseClick += Form1_MouseClick;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private ComboBox comboBox3;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label5;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox2;
    }
}

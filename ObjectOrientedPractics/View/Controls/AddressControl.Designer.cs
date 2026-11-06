namespace ObjectOrientedPractics.View.Controls
{
    partial class AddressControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            TitleLabel = new Label();
            label1 = new Label();
            IndexTextBox = new TextBox();
            label2 = new Label();
            CountryTextBox = new TextBox();
            label3 = new Label();
            CityTextBox = new TextBox();
            label4 = new Label();
            StreetTextBox = new TextBox();
            label5 = new Label();
            BuildingTextBox = new TextBox();
            label6 = new Label();
            ApartmentTextBox = new TextBox();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(3, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(101, 15);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Delivery Address";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 26);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "Post Index:";
            // 
            // IndexTextBox
            // 
            IndexTextBox.Location = new Point(73, 23);
            IndexTextBox.Name = "IndexTextBox";
            IndexTextBox.Size = new Size(113, 23);
            IndexTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 60);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Country:";
            // 
            // CountryTextBox
            // 
            CountryTextBox.Location = new Point(73, 57);
            CountryTextBox.Name = "CountryTextBox";
            CountryTextBox.Size = new Size(231, 23);
            CountryTextBox.TabIndex = 4;
            CountryTextBox.TextChanged += CountryTextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(324, 60);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 5;
            label3.Text = "City:";
            // 
            // CityTextBox
            // 
            CityTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CityTextBox.Location = new Point(361, 57);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(180, 23);
            CityTextBox.TabIndex = 6;
            CityTextBox.TextChanged += CityTextBox_TextChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 98);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 7;
            label4.Text = "Street:";
            // 
            // StreetTextBox
            // 
            StreetTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StreetTextBox.Location = new Point(73, 95);
            StreetTextBox.Name = "StreetTextBox";
            StreetTextBox.Size = new Size(468, 23);
            StreetTextBox.TabIndex = 8;
            StreetTextBox.TextChanged += StreetTextBox_TextChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 139);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 9;
            label5.Text = "Building:";
            // 
            // BuildingTextBox
            // 
            BuildingTextBox.Location = new Point(73, 136);
            BuildingTextBox.Name = "BuildingTextBox";
            BuildingTextBox.Size = new Size(113, 23);
            BuildingTextBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(212, 139);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 11;
            label6.Text = "Apartment:";
            // 
            // ApartmentTextBox
            // 
            ApartmentTextBox.Location = new Point(285, 136);
            ApartmentTextBox.Name = "ApartmentTextBox";
            ApartmentTextBox.Size = new Size(81, 23);
            ApartmentTextBox.TabIndex = 12;
            ApartmentTextBox.TextChanged += ApartmentTextBox_TextChanged;
            // 
            // AddressControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ApartmentTextBox);
            Controls.Add(label6);
            Controls.Add(BuildingTextBox);
            Controls.Add(label5);
            Controls.Add(StreetTextBox);
            Controls.Add(label4);
            Controls.Add(CityTextBox);
            Controls.Add(label3);
            Controls.Add(CountryTextBox);
            Controls.Add(label2);
            Controls.Add(IndexTextBox);
            Controls.Add(label1);
            Controls.Add(TitleLabel);
            Name = "AddressControl";
            Size = new Size(579, 163);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label label1;
        private TextBox IndexTextBox;
        private Label label2;
        private TextBox CountryTextBox;
        private Label label3;
        private TextBox CityTextBox;
        private Label label4;
        private TextBox StreetTextBox;
        private Label label5;
        private TextBox BuildingTextBox;
        private Label label6;
        private TextBox ApartmentTextBox;
    }
}

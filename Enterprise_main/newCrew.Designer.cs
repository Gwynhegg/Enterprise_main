namespace Enterprise_main
{
    partial class newCrew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_crew = new System.Windows.Forms.Label();
            this.Crew = new System.Windows.Forms.ComboBox();
            this.Variants = new System.Windows.Forms.DataGridView();
            this.first = new System.Windows.Forms.RadioButton();
            this.second = new System.Windows.Forms.RadioButton();
            this.third = new System.Windows.Forms.RadioButton();
            this.Hire = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Variants)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_crew
            // 
            this.txt_crew.AutoSize = true;
            this.txt_crew.Location = new System.Drawing.Point(12, 30);
            this.txt_crew.Name = "txt_crew";
            this.txt_crew.Size = new System.Drawing.Size(166, 13);
            this.txt_crew.TabIndex = 0;
            this.txt_crew.Text = "Вы хотите добавить в команду:";
            // 
            // Crew
            // 
            this.Crew.FormattingEnabled = true;
            this.Crew.Items.AddRange(new object[] {
            "Менеджера",
            "Программиста",
            "Дизайнера",
            "Сценариста",
            "Саунд-дизайнера"});
            this.Crew.Location = new System.Drawing.Point(222, 27);
            this.Crew.Name = "Crew";
            this.Crew.Size = new System.Drawing.Size(135, 21);
            this.Crew.TabIndex = 1;
            this.Crew.TextChanged += new System.EventHandler(this.Crew_TextChanged);
            // 
            // Variants
            // 
            this.Variants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Variants.ColumnHeadersVisible = false;
            this.Variants.Location = new System.Drawing.Point(12, 54);
            this.Variants.Name = "Variants";
            this.Variants.RowHeadersVisible = false;
            this.Variants.Size = new System.Drawing.Size(345, 83);
            this.Variants.TabIndex = 2;
            // 
            // first
            // 
            this.first.AutoSize = true;
            this.first.Location = new System.Drawing.Point(15, 163);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(85, 17);
            this.first.TabIndex = 3;
            this.first.TabStop = true;
            this.first.Text = "Выбрать #1";
            this.first.UseVisualStyleBackColor = true;
            this.first.CheckedChanged += new System.EventHandler(this.first_CheckedChanged);
            // 
            // second
            // 
            this.second.AutoSize = true;
            this.second.Location = new System.Drawing.Point(145, 163);
            this.second.Name = "second";
            this.second.Size = new System.Drawing.Size(85, 17);
            this.second.TabIndex = 4;
            this.second.TabStop = true;
            this.second.Text = "Выбрать #2";
            this.second.UseVisualStyleBackColor = true;
            this.second.CheckedChanged += new System.EventHandler(this.second_CheckedChanged);
            // 
            // third
            // 
            this.third.AutoSize = true;
            this.third.Location = new System.Drawing.Point(272, 163);
            this.third.Name = "third";
            this.third.Size = new System.Drawing.Size(85, 17);
            this.third.TabIndex = 5;
            this.third.TabStop = true;
            this.third.Text = "Выбрать #3";
            this.third.UseVisualStyleBackColor = true;
            this.third.CheckedChanged += new System.EventHandler(this.third_CheckedChanged);
            // 
            // Hire
            // 
            this.Hire.Location = new System.Drawing.Point(125, 186);
            this.Hire.Name = "Hire";
            this.Hire.Size = new System.Drawing.Size(127, 34);
            this.Hire.TabIndex = 6;
            this.Hire.Text = "НАНЯТЬ";
            this.Hire.UseVisualStyleBackColor = true;
            this.Hire.Click += new System.EventHandler(this.Hire_Click);
            // 
            // newCrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 227);
            this.Controls.Add(this.Hire);
            this.Controls.Add(this.third);
            this.Controls.Add(this.second);
            this.Controls.Add(this.first);
            this.Controls.Add(this.Variants);
            this.Controls.Add(this.Crew);
            this.Controls.Add(this.txt_crew);
            this.Name = "newCrew";
            this.Text = "newCrew";
            ((System.ComponentModel.ISupportInitialize)(this.Variants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_crew;
        private System.Windows.Forms.ComboBox Crew;
        private System.Windows.Forms.DataGridView Variants;
        private System.Windows.Forms.RadioButton first;
        private System.Windows.Forms.RadioButton second;
        private System.Windows.Forms.RadioButton third;
        private System.Windows.Forms.Button Hire;
    }
}
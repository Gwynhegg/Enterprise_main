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
            this.Hire = new System.Windows.Forms.Button();
            this.btn_third = new System.Windows.Forms.Button();
            this.btn_second = new System.Windows.Forms.Button();
            this.btn_first = new System.Windows.Forms.Button();
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
            "Manager",
            "Designer",
            "ScreenWriter",
            "SoundDesigner",
            "Programmer"});
            this.Crew.Location = new System.Drawing.Point(222, 22);
            this.Crew.Name = "Crew";
            this.Crew.Size = new System.Drawing.Size(135, 21);
            this.Crew.TabIndex = 1;
            this.Crew.TextChanged += new System.EventHandler(this.Crew_TextChanged);
            // 
            // Hire
            // 
            this.Hire.Location = new System.Drawing.Point(230, 328);
            this.Hire.Name = "Hire";
            this.Hire.Size = new System.Drawing.Size(127, 34);
            this.Hire.TabIndex = 6;
            this.Hire.Text = "НАНЯТЬ";
            this.Hire.UseVisualStyleBackColor = true;
            this.Hire.Click += new System.EventHandler(this.Hire_Click);
            // 
            // btn_third
            // 
            this.btn_third.Location = new System.Drawing.Point(454, 283);
            this.btn_third.Name = "btn_third";
            this.btn_third.Size = new System.Drawing.Size(75, 23);
            this.btn_third.TabIndex = 2;
            this.btn_third.Text = "Выбрать";
            this.btn_third.UseVisualStyleBackColor = true;
            this.btn_third.Click += new System.EventHandler(this.btn_third_Click);
            // 
            // btn_second
            // 
            this.btn_second.Location = new System.Drawing.Point(254, 283);
            this.btn_second.Name = "btn_second";
            this.btn_second.Size = new System.Drawing.Size(75, 23);
            this.btn_second.TabIndex = 1;
            this.btn_second.Text = "Выбрать";
            this.btn_second.UseVisualStyleBackColor = true;
            this.btn_second.Click += new System.EventHandler(this.btn_second_Click);
            // 
            // btn_first
            // 
            this.btn_first.Location = new System.Drawing.Point(60, 283);
            this.btn_first.Name = "btn_first";
            this.btn_first.Size = new System.Drawing.Size(75, 23);
            this.btn_first.TabIndex = 0;
            this.btn_first.Text = "Выбрать";
            this.btn_first.UseVisualStyleBackColor = true;
            this.btn_first.Click += new System.EventHandler(this.btn_first_Click);
            // 
            // newCrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 370);
            this.Controls.Add(this.btn_third);
            this.Controls.Add(this.btn_second);
            this.Controls.Add(this.btn_first);
            this.Controls.Add(this.Hire);
            this.Controls.Add(this.Crew);
            this.Controls.Add(this.txt_crew);
            this.Name = "newCrew";
            this.Text = "newCrew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_crew;
        private System.Windows.Forms.ComboBox Crew;
        private System.Windows.Forms.Button Hire;
        private System.Windows.Forms.Button btn_third;
        private System.Windows.Forms.Button btn_second;
        private System.Windows.Forms.Button btn_first;
    }
}
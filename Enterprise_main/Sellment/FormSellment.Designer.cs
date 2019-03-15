namespace Enterprise_main
{
    partial class form_Sellment
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
            this.this_Population = new System.Windows.Forms.Label();
            this.this_Rating = new System.Windows.Forms.Label();
            this.this_Sellment = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.txt_Population = new System.Windows.Forms.Label();
            this.txt_Rating = new System.Windows.Forms.Label();
            this.txt_Sellment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // this_Population
            // 
            this.this_Population.AutoSize = true;
            this.this_Population.Location = new System.Drawing.Point(12, 32);
            this.this_Population.Name = "this_Population";
            this.this_Population.Size = new System.Drawing.Size(35, 13);
            this.this_Population.TabIndex = 0;
            this.this_Population.Text = "label1";
            // 
            // this_Rating
            // 
            this.this_Rating.AutoSize = true;
            this.this_Rating.Location = new System.Drawing.Point(171, 32);
            this.this_Rating.Name = "this_Rating";
            this.this_Rating.Size = new System.Drawing.Size(35, 13);
            this.this_Rating.TabIndex = 1;
            this.this_Rating.Text = "label1";
            // 
            // this_Sellment
            // 
            this.this_Sellment.AutoSize = true;
            this.this_Sellment.Location = new System.Drawing.Point(341, 32);
            this.this_Sellment.Name = "this_Sellment";
            this.this_Sellment.Size = new System.Drawing.Size(35, 13);
            this.this_Sellment.TabIndex = 2;
            this.this_Sellment.Text = "label1";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(377, 235);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "OK";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // txt_Population
            // 
            this.txt_Population.AutoSize = true;
            this.txt_Population.Location = new System.Drawing.Point(12, 9);
            this.txt_Population.Name = "txt_Population";
            this.txt_Population.Size = new System.Drawing.Size(65, 13);
            this.txt_Population.TabIndex = 4;
            this.txt_Population.Text = "Популяция:";
            // 
            // txt_Rating
            // 
            this.txt_Rating.AutoSize = true;
            this.txt_Rating.Location = new System.Drawing.Point(171, 9);
            this.txt_Rating.Name = "txt_Rating";
            this.txt_Rating.Size = new System.Drawing.Size(79, 13);
            this.txt_Rating.TabIndex = 5;
            this.txt_Rating.Text = "Рейтинг игры:";
            // 
            // txt_Sellment
            // 
            this.txt_Sellment.AutoSize = true;
            this.txt_Sellment.Location = new System.Drawing.Point(341, 9);
            this.txt_Sellment.Name = "txt_Sellment";
            this.txt_Sellment.Size = new System.Drawing.Size(56, 13);
            this.txt_Sellment.TabIndex = 6;
            this.txt_Sellment.Text = "Продажи:";
            // 
            // form_Sellment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 270);
            this.Controls.Add(this.txt_Sellment);
            this.Controls.Add(this.txt_Rating);
            this.Controls.Add(this.txt_Population);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.this_Sellment);
            this.Controls.Add(this.this_Rating);
            this.Controls.Add(this.this_Population);
            this.Name = "form_Sellment";
            this.Text = "FormSellment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label this_Population;
        private System.Windows.Forms.Label this_Rating;
        private System.Windows.Forms.Label this_Sellment;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label txt_Population;
        private System.Windows.Forms.Label txt_Rating;
        private System.Windows.Forms.Label txt_Sellment;
    }
}
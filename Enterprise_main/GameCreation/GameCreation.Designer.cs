namespace Enterprise_main
{
     partial class form_GameCreation
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
            this.txt_genre = new System.Windows.Forms.Label();
            this.Genre = new System.Windows.Forms.ComboBox();
            this.txt_size = new System.Windows.Forms.Label();
            this.GameSize = new System.Windows.Forms.ComboBox();
            this.txt_name = new System.Windows.Forms.Label();
            this.GameName = new System.Windows.Forms.TextBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_genre
            // 
            this.txt_genre.AutoSize = true;
            this.txt_genre.Location = new System.Drawing.Point(18, 9);
            this.txt_genre.Name = "txt_genre";
            this.txt_genre.Size = new System.Drawing.Size(213, 13);
            this.txt_genre.TabIndex = 0;
            this.txt_genre.Text = "Начните создание игры с выбора жанра";
            // 
            // Genre
            // 
            this.Genre.FormattingEnabled = true;
            this.Genre.Items.AddRange(new object[] {
            "RPG",
            "Shooter",
            "Horror",
            "Strategy",
            "Simulator",
            "Arcade"});
            this.Genre.Location = new System.Drawing.Point(57, 39);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(121, 21);
            this.Genre.TabIndex = 1;
            this.Genre.TextChanged += new System.EventHandler(this.Genre_TextChanged);
            // 
            // txt_size
            // 
            this.txt_size.AutoSize = true;
            this.txt_size.Location = new System.Drawing.Point(34, 77);
            this.txt_size.Name = "txt_size";
            this.txt_size.Size = new System.Drawing.Size(165, 13);
            this.txt_size.TabIndex = 2;
            this.txt_size.Text = "Теперь выберите размер игры";
            this.txt_size.Visible = false;
            // 
            // GameSize
            // 
            this.GameSize.FormattingEnabled = true;
            this.GameSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.GameSize.Location = new System.Drawing.Point(57, 113);
            this.GameSize.Name = "GameSize";
            this.GameSize.Size = new System.Drawing.Size(121, 21);
            this.GameSize.TabIndex = 3;
            this.GameSize.Visible = false;
            this.GameSize.TextChanged += new System.EventHandler(this.Size_TextChanged);
            // 
            // txt_name
            // 
            this.txt_name.AutoSize = true;
            this.txt_name.Location = new System.Drawing.Point(16, 161);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(215, 13);
            this.txt_name.TabIndex = 4;
            this.txt_name.Text = "И наконец, укажите имя вашего проекта";
            this.txt_name.Visible = false;
            // 
            // GameName
            // 
            this.GameName.Location = new System.Drawing.Point(57, 201);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(121, 20);
            this.GameName.TabIndex = 5;
            this.GameName.Visible = false;
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(48, 246);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(141, 52);
            this.btn_Create.TabIndex = 6;
            this.btn_Create.Text = "CREATE";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Visible = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // form_GameCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 310);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.GameName);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.GameSize);
            this.Controls.Add(this.txt_size);
            this.Controls.Add(this.Genre);
            this.Controls.Add(this.txt_genre);
            this.Name = "form_GameCreation";
            this.Text = "GameCreation";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_genre;
        private System.Windows.Forms.ComboBox Genre;
        private System.Windows.Forms.Label txt_size;
        private System.Windows.Forms.ComboBox GameSize;
        private System.Windows.Forms.Label txt_name;
        private System.Windows.Forms.TextBox GameName;
        private System.Windows.Forms.Button btn_Create;
    }
}
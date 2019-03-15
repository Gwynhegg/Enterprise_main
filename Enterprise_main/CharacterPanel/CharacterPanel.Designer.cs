namespace Enterprise_main
{
    partial class CharacterPanel
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
            this.txt_Speciality = new System.Windows.Forms.Label();
            this.this_Speciality = new System.Windows.Forms.Label();
            this.txt_Coding = new System.Windows.Forms.Label();
            this.txt_Design = new System.Windows.Forms.Label();
            this.this_Skill = new System.Windows.Forms.Label();
            this.this_Coding = new System.Windows.Forms.Label();
            this.txt_Fatigue = new System.Windows.Forms.Label();
            this.txt_Performance = new System.Windows.Forms.Label();
            this.this_Fatigue = new System.Windows.Forms.Label();
            this.this_Performance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Speciality
            // 
            this.txt_Speciality.AutoSize = true;
            this.txt_Speciality.Location = new System.Drawing.Point(12, 9);
            this.txt_Speciality.Name = "txt_Speciality";
            this.txt_Speciality.Size = new System.Drawing.Size(88, 13);
            this.txt_Speciality.TabIndex = 0;
            this.txt_Speciality.Text = "Специальность:";
            // 
            // this_Speciality
            // 
            this.this_Speciality.AutoSize = true;
            this.this_Speciality.Location = new System.Drawing.Point(12, 24);
            this.this_Speciality.Name = "this_Speciality";
            this.this_Speciality.Size = new System.Drawing.Size(0, 13);
            this.this_Speciality.TabIndex = 1;
            // 
            // txt_Coding
            // 
            this.txt_Coding.AutoSize = true;
            this.txt_Coding.Location = new System.Drawing.Point(74, 44);
            this.txt_Coding.Name = "txt_Coding";
            this.txt_Coding.Size = new System.Drawing.Size(46, 13);
            this.txt_Coding.TabIndex = 2;
            this.txt_Coding.Text = "Кодинг:";
            // 
            // txt_Design
            // 
            this.txt_Design.AutoSize = true;
            this.txt_Design.Location = new System.Drawing.Point(12, 44);
            this.txt_Design.Name = "txt_Design";
            this.txt_Design.Size = new System.Drawing.Size(49, 13);
            this.txt_Design.TabIndex = 3;
            this.txt_Design.Text = "Дизайн:";
            // 
            // this_Skill
            // 
            this.this_Skill.AutoSize = true;
            this.this_Skill.Location = new System.Drawing.Point(12, 61);
            this.this_Skill.Name = "this_Skill";
            this.this_Skill.Size = new System.Drawing.Size(0, 13);
            this.this_Skill.TabIndex = 4;
            // 
            // this_Coding
            // 
            this.this_Coding.AutoSize = true;
            this.this_Coding.Enabled = false;
            this.this_Coding.Location = new System.Drawing.Point(77, 61);
            this.this_Coding.Name = "this_Coding";
            this.this_Coding.Size = new System.Drawing.Size(0, 13);
            this.this_Coding.TabIndex = 5;
            // 
            // txt_Fatigue
            // 
            this.txt_Fatigue.AutoSize = true;
            this.txt_Fatigue.Location = new System.Drawing.Point(12, 79);
            this.txt_Fatigue.Name = "txt_Fatigue";
            this.txt_Fatigue.Size = new System.Drawing.Size(64, 13);
            this.txt_Fatigue.TabIndex = 6;
            this.txt_Fatigue.Text = "Усталость:";
            // 
            // txt_Performance
            // 
            this.txt_Performance.AutoSize = true;
            this.txt_Performance.Location = new System.Drawing.Point(12, 113);
            this.txt_Performance.Name = "txt_Performance";
            this.txt_Performance.Size = new System.Drawing.Size(118, 13);
            this.txt_Performance.TabIndex = 7;
            this.txt_Performance.Text = "Производительность:";
            // 
            // this_Fatigue
            // 
            this.this_Fatigue.AutoSize = true;
            this.this_Fatigue.Location = new System.Drawing.Point(12, 95);
            this.this_Fatigue.Name = "this_Fatigue";
            this.this_Fatigue.Size = new System.Drawing.Size(0, 13);
            this.this_Fatigue.TabIndex = 8;
            // 
            // this_Performance
            // 
            this.this_Performance.AutoSize = true;
            this.this_Performance.Location = new System.Drawing.Point(12, 129);
            this.this_Performance.Name = "this_Performance";
            this.this_Performance.Size = new System.Drawing.Size(0, 13);
            this.this_Performance.TabIndex = 9;
            // 
            // CharacterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(140, 160);
            this.Controls.Add(this.this_Performance);
            this.Controls.Add(this.this_Fatigue);
            this.Controls.Add(this.txt_Performance);
            this.Controls.Add(this.txt_Fatigue);
            this.Controls.Add(this.this_Coding);
            this.Controls.Add(this.this_Skill);
            this.Controls.Add(this.txt_Design);
            this.Controls.Add(this.txt_Coding);
            this.Controls.Add(this.this_Speciality);
            this.Controls.Add(this.txt_Speciality);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CharacterPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CharacterPanel";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_Speciality;
        private System.Windows.Forms.Label this_Speciality;
        private System.Windows.Forms.Label txt_Coding;
        private System.Windows.Forms.Label txt_Design;
        private System.Windows.Forms.Label this_Skill;
        private System.Windows.Forms.Label this_Coding;
        private System.Windows.Forms.Label txt_Fatigue;
        private System.Windows.Forms.Label txt_Performance;
        private System.Windows.Forms.Label this_Fatigue;
        private System.Windows.Forms.Label this_Performance;
    }
}
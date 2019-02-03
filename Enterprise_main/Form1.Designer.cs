namespace Enterprise_main
{
    partial class form_Enterprise
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_createFirm = new System.Windows.Forms.Button();
            this.txt_nameofFirm = new System.Windows.Forms.TextBox();
            this.txt_startBudget = new System.Windows.Forms.TextBox();
            this.txt_Budget = new System.Windows.Forms.Label();
            this.txt_currName = new System.Windows.Forms.Label();
            this.run_of_time = new System.Windows.Forms.Timer(this.components);
            this.txt_currReadiness = new System.Windows.Forms.Label();
            this.txt_currentData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_createFirm
            // 
            this.btn_createFirm.Location = new System.Drawing.Point(224, 12);
            this.btn_createFirm.Name = "btn_createFirm";
            this.btn_createFirm.Size = new System.Drawing.Size(126, 23);
            this.btn_createFirm.TabIndex = 0;
            this.btn_createFirm.Text = "Create Enterprise";
            this.btn_createFirm.UseVisualStyleBackColor = true;
            this.btn_createFirm.Click += new System.EventHandler(this.btn_createFirm_Click);
            // 
            // txt_nameofFirm
            // 
            this.txt_nameofFirm.Location = new System.Drawing.Point(12, 12);
            this.txt_nameofFirm.Name = "txt_nameofFirm";
            this.txt_nameofFirm.Size = new System.Drawing.Size(100, 20);
            this.txt_nameofFirm.TabIndex = 1;
            // 
            // txt_startBudget
            // 
            this.txt_startBudget.Location = new System.Drawing.Point(118, 12);
            this.txt_startBudget.Name = "txt_startBudget";
            this.txt_startBudget.Size = new System.Drawing.Size(100, 20);
            this.txt_startBudget.TabIndex = 2;
            // 
            // txt_Budget
            // 
            this.txt_Budget.AutoSize = true;
            this.txt_Budget.Location = new System.Drawing.Point(12, 51);
            this.txt_Budget.Name = "txt_Budget";
            this.txt_Budget.Size = new System.Drawing.Size(35, 13);
            this.txt_Budget.TabIndex = 3;
            this.txt_Budget.Text = "label1";
            // 
            // txt_currName
            // 
            this.txt_currName.AutoSize = true;
            this.txt_currName.Location = new System.Drawing.Point(115, 51);
            this.txt_currName.Name = "txt_currName";
            this.txt_currName.Size = new System.Drawing.Size(35, 13);
            this.txt_currName.TabIndex = 4;
            this.txt_currName.Text = "label1";
            // 
            // run_of_time
            // 
            this.run_of_time.Interval = 200;
            this.run_of_time.Tick += new System.EventHandler(this.run_of_time_Tick);
            // 
            // txt_currReadiness
            // 
            this.txt_currReadiness.AutoSize = true;
            this.txt_currReadiness.Location = new System.Drawing.Point(221, 51);
            this.txt_currReadiness.Name = "txt_currReadiness";
            this.txt_currReadiness.Size = new System.Drawing.Size(35, 13);
            this.txt_currReadiness.TabIndex = 5;
            this.txt_currReadiness.Text = "label1";
            // 
            // txt_currentData
            // 
            this.txt_currentData.AutoSize = true;
            this.txt_currentData.Location = new System.Drawing.Point(467, 12);
            this.txt_currentData.Name = "txt_currentData";
            this.txt_currentData.Size = new System.Drawing.Size(35, 13);
            this.txt_currentData.TabIndex = 6;
            this.txt_currentData.Text = "label1";
            // 
            // form_Enterprise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 320);
            this.Controls.Add(this.txt_currentData);
            this.Controls.Add(this.txt_currReadiness);
            this.Controls.Add(this.txt_currName);
            this.Controls.Add(this.txt_Budget);
            this.Controls.Add(this.txt_startBudget);
            this.Controls.Add(this.txt_nameofFirm);
            this.Controls.Add(this.btn_createFirm);
            this.Name = "form_Enterprise";
            this.Text = "Enterprise";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createFirm;
        private System.Windows.Forms.TextBox txt_nameofFirm;
        private System.Windows.Forms.TextBox txt_startBudget;
        private System.Windows.Forms.Label txt_Budget;
        private System.Windows.Forms.Label txt_currName;
        private System.Windows.Forms.Timer run_of_time;
        private System.Windows.Forms.Label txt_currReadiness;
        private System.Windows.Forms.Label txt_currentData;
    }
}


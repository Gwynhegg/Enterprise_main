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
            this.txt_currentData = new System.Windows.Forms.Label();
            this.crewTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CurrProject = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.currReadiness = new System.Windows.Forms.ProgressBar();
            this.btn_HireCrew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_createFirm
            // 
            this.btn_createFirm.Location = new System.Drawing.Point(248, 12);
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
            this.txt_nameofFirm.Size = new System.Drawing.Size(124, 20);
            this.txt_nameofFirm.TabIndex = 1;
            this.txt_nameofFirm.Text = "Введите имя фирмы...";
            this.txt_nameofFirm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_nameofFirm_MouseClick);
            // 
            // txt_startBudget
            // 
            this.txt_startBudget.Location = new System.Drawing.Point(142, 12);
            this.txt_startBudget.Name = "txt_startBudget";
            this.txt_startBudget.Size = new System.Drawing.Size(100, 20);
            this.txt_startBudget.TabIndex = 2;
            this.txt_startBudget.Text = "Введите бюджет...";
            this.txt_startBudget.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_startBudget_MouseClick);
            this.txt_startBudget.TextChanged += new System.EventHandler(this.txt_startBudget_TextChanged);
            // 
            // txt_Budget
            // 
            this.txt_Budget.AutoSize = true;
            this.txt_Budget.Location = new System.Drawing.Point(115, 60);
            this.txt_Budget.Name = "txt_Budget";
            this.txt_Budget.Size = new System.Drawing.Size(0, 13);
            this.txt_Budget.TabIndex = 3;
            // 
            // txt_currName
            // 
            this.txt_currName.AutoSize = true;
            this.txt_currName.Location = new System.Drawing.Point(117, 35);
            this.txt_currName.Name = "txt_currName";
            this.txt_currName.Size = new System.Drawing.Size(0, 13);
            this.txt_currName.TabIndex = 4;
            // 
            // run_of_time
            // 
            this.run_of_time.Interval = 200;
            this.run_of_time.Tick += new System.EventHandler(this.run_of_time_Tick);
            // 
            // txt_currentData
            // 
            this.txt_currentData.AutoSize = true;
            this.txt_currentData.Location = new System.Drawing.Point(455, 35);
            this.txt_currentData.Name = "txt_currentData";
            this.txt_currentData.Size = new System.Drawing.Size(0, 13);
            this.txt_currentData.TabIndex = 6;
            // 
            // crewTable
            // 
            this.crewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crewTable.Location = new System.Drawing.Point(15, 108);
            this.crewTable.Name = "crewTable";
            this.crewTable.Size = new System.Drawing.Size(531, 200);
            this.crewTable.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название фирмы:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Текущий бюджет:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Текущий проект:";
            this.label3.Visible = false;
            // 
            // txt_CurrProject
            // 
            this.txt_CurrProject.AutoSize = true;
            this.txt_CurrProject.Location = new System.Drawing.Point(111, 84);
            this.txt_CurrProject.Name = "txt_CurrProject";
            this.txt_CurrProject.Size = new System.Drawing.Size(0, 13);
            this.txt_CurrProject.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Готовность:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Количество дней:";
            this.label5.Visible = false;
            // 
            // currReadiness
            // 
            this.currReadiness.Location = new System.Drawing.Point(446, 79);
            this.currReadiness.Name = "currReadiness";
            this.currReadiness.Size = new System.Drawing.Size(100, 23);
            this.currReadiness.TabIndex = 14;
            this.currReadiness.Visible = false;
            // 
            // btn_HireCrew
            // 
            this.btn_HireCrew.Location = new System.Drawing.Point(248, 50);
            this.btn_HireCrew.Name = "btn_HireCrew";
            this.btn_HireCrew.Size = new System.Drawing.Size(75, 23);
            this.btn_HireCrew.TabIndex = 15;
            this.btn_HireCrew.Text = "Нанять";
            this.btn_HireCrew.UseVisualStyleBackColor = true;
            this.btn_HireCrew.Visible = false;
            this.btn_HireCrew.Click += new System.EventHandler(this.btn_HireCrew_Click);
            // 
            // form_Enterprise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 320);
            this.Controls.Add(this.btn_HireCrew);
            this.Controls.Add(this.currReadiness);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_CurrProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crewTable);
            this.Controls.Add(this.txt_currentData);
            this.Controls.Add(this.txt_currName);
            this.Controls.Add(this.txt_Budget);
            this.Controls.Add(this.txt_startBudget);
            this.Controls.Add(this.txt_nameofFirm);
            this.Controls.Add(this.btn_createFirm);
            this.Name = "form_Enterprise";
            this.Text = "Enterprise";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crewTable)).EndInit();
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
        private System.Windows.Forms.Label txt_currentData;
        private System.Windows.Forms.DataGridView crewTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txt_CurrProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar currReadiness;
        private System.Windows.Forms.Button btn_HireCrew;
    }
}


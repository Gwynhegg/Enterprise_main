using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_main
{
    public partial class newCrew : Form
    {
        Random r;
        private string typeOf="";
        private int sum_width;
        private int num;

        public newCrew()
        {
            InitializeComponent();
           r = new Random();
            sum_width = (this.Width - 50) / 3;
        }

        private void createWorker(Point point, string type, int i)
        {
            Panel crew1 = new Panel();
            crew1.Name = "WorkerPanel"+i;
            crew1.Location = point;
            crew1.Height = this.Height - 150;
            crew1.Width = (this.Width-50)/3;
            crew1.BackColor = Color.DarkOrange;
            Label name = new Label();
            crew1.Controls.Add(name);
            name.Location = new Point(10, 10);
            name.Text = type +" №"+(i+1);
            Label salary = new Label();
            crew1.Controls.Add(salary);
            salary.Name = "Salary";
            salary.Location = new Point(10, 120);
            salary.Text = "Зарплата:" + "\n";
            Label Skill = new Label();
            Skill.Name = "Skill";
            crew1.Controls.Add(Skill);
            Skill.Location = new Point(10, 70);
            if (type == "Programmer")
            {
                Label codeSkill = new Label();
                crew1.Controls.Add(codeSkill);
                codeSkill.Name = "codeSkill";
                codeSkill.Location = new Point(10, 50);
                codeSkill.Text = r.Next(40,60).ToString();
                Skill.Text = r.Next(10,20).ToString();
                salary.Text += ((Int32.Parse(codeSkill.Text) + Int32.Parse(Skill.Text)) * 10).ToString();
            }
            else
            {
                Skill.Text = r.Next(40,60).ToString();
                salary.Text += ((Int32.Parse(Skill.Text)) * 10).ToString();
            }

            this.Controls.Add(crew1);
        }

        private void Crew_TextChanged(object sender, EventArgs e)
        {
            btn_first.Visible = true;
            btn_second.Visible = true;
            btn_third.Visible = true;

            Crew.Enabled = false;
           for (int i = 0; i < 3; i++)
            {
                createWorker(new Point(i * sum_width + 10 * (i + 1), 70), Crew.Text, i);
            }
        }

        private void Hire_Click(object sender, EventArgs e)
        {
            //Указываем тип сотрудника для передачи на главную форму
            if (Crew.Text != "")
            {
                typeOf = Crew.Text;
                this.Close();
            }
            else MessageBox.Show("Выберите сотрудника для найма", "ERROR", MessageBoxButtons.OK);
        }

        public string getType()
        {
            return typeOf;
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            num = 0;
            this.Controls["WorkerPanel0"].BackColor = Color.Orange;
            this.Controls["WorkerPanel1"].BackColor = Color.DarkOrange;
            this.Controls["WorkerPanel2"].BackColor = Color.DarkOrange;
        }

        private void btn_second_Click(object sender, EventArgs e)
        {
            num = 1;
            this.Controls["WorkerPanel1"].BackColor = Color.Orange;
            this.Controls["WorkerPanel0"].BackColor = Color.DarkOrange;
            this.Controls["WorkerPanel2"].BackColor = Color.DarkOrange;
        }

        private void btn_third_Click(object sender, EventArgs e)
        {
            num = 2;
            this.Controls["WorkerPanel2"].BackColor = Color.Orange;
            this.Controls["WorkerPanel1"].BackColor = Color.DarkOrange;
            this.Controls["WorkerPanel0"].BackColor = Color.DarkOrange;
        }

        //Создаем сотрудника указанного типа
          public ScreenWriter createWriter()
          {
              return new ScreenWriter(Int32.Parse(this.Controls["WorkerPanel"+num].Controls["Skill"].Text));
          }

          public Designer createDesigner()
          {
             return new Designer(Int32.Parse(this.Controls["WorkerPanel" + num].Controls["Skill"].Text));
          }

          public SoundDesigner createSound()
          {
              return new SoundDesigner(Int32.Parse(this.Controls["WorkerPanel" + num].Controls["Skill"].Text));
          }

          public Programmer createCoder()
          {
              return new Programmer(Int32.Parse(this.Controls["WorkerPanel" + num].Controls["codeSkill"].Text), Int32.Parse(this.Controls["WorkerPanel" + num].Controls["Skill"].Text));
          }
          public Manager createManager()
          {
              return new Manager(Int32.Parse(this.Controls["WorkerPanel" + num].Controls["Skill"].Text));
          }
    }
}

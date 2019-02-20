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
        public string typeOf="";
        int num = 0;
        public newCrew()
        {
            InitializeComponent();
            Variants.ColumnCount = 3;
           r = new Random();
        }

        private void Crew_TextChanged(object sender, EventArgs e)
        {
            if (Crew.Text == "Менеджера")
            {
                Variants.RowCount = 2;
                for (int i = 0; i < 3; i++)
                {
                    Variants.Rows[0].Cells[i].Value = "Менеджер №" + (i + 1).ToString();
                    Variants.Rows[1].Cells[i].Value = r.Next(100).ToString();
                }
            }
            else if (Crew.Text == "Программиста")
            {
                Variants.RowCount = 3;
                for (int i = 0; i < 3; i++)
                {
                    Variants.Rows[0].Cells[i].Value = "Программист №" + (i + 1).ToString();
                    Variants.Rows[1].Cells[i].Value = r.Next(100).ToString();
                    Variants.Rows[2].Cells[i].Value = r.Next(20).ToString();
                }
            } else if (Crew.Text == "Дизайнера")
            {
                Variants.RowCount = 2;
                for (int i = 0; i < 3; i++)
                {
                    Variants.Rows[0].Cells[i].Value = "Дизайнер №" + (i + 1).ToString();
                    Variants.Rows[1].Cells[i].Value = r.Next(100).ToString();
                }
            } else if (Crew.Text == "Сценариста")
            {
                Variants.RowCount = 2;
                for (int i = 0; i < 3; i++)
                {
                    Variants.Rows[0].Cells[i].Value = "сценарист №" + (i + 1).ToString();
                    Variants.Rows[1].Cells[i].Value = r.Next(100).ToString();
                }
            } else if (Crew.Text == "Саунд-дизайнера")
            {
                Variants.RowCount = 2;
                for (int i = 0; i < 3; i++)
                {
                    Variants.Rows[0].Cells[i].Value = "Саунд №" + (i + 1).ToString();
                    Variants.Rows[1].Cells[i].Value = r.Next(100).ToString();
                }
            }
        }

        private void third_CheckedChanged(object sender, EventArgs e)
        {
            num = 2;
            second.Checked = false;
            first.Checked = false;
        }

        private void second_CheckedChanged(object sender, EventArgs e)
        {
            num = 1;
            third.Checked = false;
            first.Checked = false;
        }

        private void first_CheckedChanged(object sender, EventArgs e)
        {
            num = 0;
            third.Checked = false;
            second.Checked = false;
        }

        private void Hire_Click(object sender, EventArgs e)
        {
            //Указываем тип сотрудника для передачи на главную форму
            switch (Crew.Text){
                case "Менеджера": typeOf = "Manager";break;
                case "Программиста": typeOf = "Coder";break;
                case "Дизайнера": typeOf = "Designer";break;
                case "Сценариста":typeOf = "Writer";break;
                case "Саунд-дизайнера":typeOf = "Sound";break;           
            }
            this.Close();

        }

        //Создаем сотруждника указанного типа
        public ScreenWriter createWriter()
        {
            return new ScreenWriter(Int32.Parse(Variants.Rows[1].Cells[num].Value.ToString()));
        }

        public Designer createDesigner()
        {
            return new Designer(Int32.Parse(Variants.Rows[1].Cells[num].Value.ToString()));
        }

        public SoundDesigner createSound()
        {
            return new SoundDesigner(Int32.Parse(Variants.Rows[1].Cells[num].Value.ToString()));
        }

        public Programmer createCoder()
        {
            return new Programmer(Int32.Parse(Variants.Rows[1].Cells[num].Value.ToString()), Int32.Parse(Variants.Rows[2].Cells[num].Value.ToString()));
        }
        public Manager createManager()
        {
            return new Manager(Int32.Parse(Variants.Rows[1].Cells[num].Value.ToString()));
        }
    }
}

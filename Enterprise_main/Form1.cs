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
    public partial class form_Enterprise : Form
    {
        Director director1;
        int days = 1;
        Game currentGame;
        List<Human> crew;
    //    List<Manager> managers;
        public form_Enterprise()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_createFirm_Click(object sender, EventArgs e)
        {
            //Создаем директора предприятия
            director1 = new Director(txt_nameofFirm.Text, Int32.Parse(txt_startBudget.Text));
            //Выводим данные о бюджете и названии предприятия
            txt_Budget.Text = director1.returnBudget().ToString();
            txt_currName.Text = director1.returnName().ToString();

            //Создаем лист для команды разработчиков
       //     managers = new List<Manager>();
            crew = new List<Human>();

            //Выводим течение дней и запускаем процесс
            txt_currentData.Text = days.ToString();
            run_of_time.Enabled = true;
            //Добавляем программиста в команду
            crew.Add(new Programmer(50, 10));
            crew.Add(new Designer(50));
            crew.Add(new ScreenWriter(50));
            crew.Add(new SoundDesigner(50));

        }

        private void run_of_time_Tick(object sender, EventArgs e)
        {
            //Выводим данные о времени и располагаемом бюджете
            days++;
            txt_currentData.Text = days.ToString();
            txt_Budget.Text = director1.returnBudget().ToString();

            //Если нет проекта, то..
            if (!director1.hasProject)
            {
                //Создаем проект
                director1.startProject("Horror", "Medium", "AAAAAAAA");
                currentGame = director1.getGame();
                director1.hasProject = true;
            } else
            {
                //Если проект есть, выводим данные о его готовности
                txt_currReadiness.Text = director1.readiness_ofProject().ToString();
            }

            //Для каждого члена команды
            foreach(Human buddy in crew)
            {   
                if (days % 30 == 0)
                {
                    //Выплачиваем зарплату в нужный срок
                    director1.setBudget(director1.returnBudget() - buddy.GetPaid());
                }
                //Отправляем работать
                buddy.ToWork(currentGame);
            }
        }
    }
}

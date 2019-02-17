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
        Customer customer1;
        string genre, size, title;
        int days = 0;
        bool FinalFlag = false;
        Game currentGame;
        List<Human> crew;
        List<Manager> managers;
        DataTable dt;
        public form_Enterprise()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Position");
            dt.Columns.Add("Code Skill");
            dt.Columns.Add("Design Skill");
            dt.Columns.Add("Performance");
            dt.Columns.Add("Fatigue");

        }

        private void btn_createFirm_Click(object sender, EventArgs e)
        {
            //Выводим все надписи, предназначенные для удобства
            txt_startBudget.Visible = false;
            txt_nameofFirm.Visible = false;
            btn_createFirm.Visible = false;
            currReadiness.Visible = true;
            btn_HireCrew.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            //Создаем директора предприятия
            director1 = new Director(txt_nameofFirm.Text, Int32.Parse(txt_startBudget.Text));
            customer1 = new Customer(20000);
            //Выводим данные о бюджете и названии предприятия
            txt_Budget.Text = director1.returnBudget().ToString();
            txt_currName.Text = director1.returnName().ToString();

            //Создаем лист для команды разработчиков
            managers = new List<Manager>();
            crew = new List<Human>();

            //Выводим течение дней и запускаем процесс
            txt_currentData.Text = days.ToString();
            run_of_time.Enabled = true;
            crewTable.DataSource = dt;
            
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
                run_of_time.Enabled = false;
                GameCreation form1 = new GameCreation();
                form1.ShowDialog();
                if (form1.isDone)
                {
                    genre = form1.getGenre();
                    size = form1.getSize();
                    title = form1.getName();
                }
                run_of_time.Enabled = true;
                //Создаем проект
                FinalFlag = false;
                director1.startProject(genre, size, title);
                txt_CurrProject.Text = ("Title: " + title + "    Genre: " + genre + "    Size: " + size);
                currentGame = director1.getGame();
                currentGame.setRested(crew.Count / 3);
                director1.hasProject = true;
            }
            else
            {
                //Если проект есть, выводим данные о его готовности
                if (currentGame.getReadiness() != 100) { 
                currReadiness.Value = (int)director1.readiness_ofProject();
            } else
                {
                    //Если проект является завершенным, то...
                   if (!FinalFlag){
                        //Переназначаем прогресс бар для демонстрации дебага
                        FinalFlag = true;
                        label4.Text = "Деббажим:";
                        currReadiness.Maximum = currentGame.Bugs();
                        currReadiness.Value = currReadiness.Maximum;
                    } else {
                        //Выводим текущее количество багов
                        currReadiness.Value = currentGame.Bugs();
                    }
                }
            }
        if (crew.Count()==0)
            {
                run_of_time.Enabled = false;
                HireCrew();
            }
            run_of_time.Enabled = true;
        if (managers.Count != 0)
            {
                foreach (Manager man in managers)
                {
                    if (days % 30 == 0)
                    {
                        //Выплачиваем зарплату в нужный срок
                        director1.setBudget(director1.returnBudget() - man.GetPaid());
                    }
                    //Менеджеры работают, повышая производительность остальных
                    man.GetWork(crew);
                }
            }
            

            if (days % 30 == 0)
            {
                //Изменяем предпочтения игроков
                customer1.ChangePreferences();
            }

            //Для каждого члена команды
            foreach (Human buddy in crew)
            {   
                if (days % 30 == 0)
                {

                    //Выплачиваем зарплату в нужный срок
                    director1.setBudget(director1.returnBudget() - buddy.GetPaid());
                }

                crewTable.Rows[crew.IndexOf(buddy)].Cells[3].Value = buddy.getPerformance();
                crewTable.Rows[crew.IndexOf(buddy)].Cells[4].Value = buddy.getFatigue();
                //Отправляем работать
                buddy.ToWork(currentGame);
            }

            if (currentGame.getReadiness()==100 && currentGame.Bugs() <= 0)
            {
                //Высчитываем желательную цену продажи, оценку критиков, продаем и пополняем бюджет
                currReadiness.Maximum = 100;
                label4.Text = "Готовность:";
                double rating = getAverage();
                int our_price = director1.SellGame(customer1.getPopulation());
                int sellment =  customer1.BuyGame(currentGame,our_price,rating);
                director1.setBudget(director1.returnBudget() + sellment);
            }
        }
        //Функция, которая высчитывает средние характеристики специалистов и на их основе строит качество сделанной работы
        private double getAverage()
        {
            int design_quality=0, numOfDesigners=0;
            int optimization=0, numOfProgrammers=0;
            int sound_quality=0, numOfSounds=0;
            int plot_quality=0, numOfWriters=0;

            foreach(Human buddy in crew)
            {
                if (buddy is Programmer)
                {
                    numOfProgrammers++;
                    optimization += buddy.getCodeskill();
                } else if(buddy is ScreenWriter)
                {
                    numOfWriters++;
                    plot_quality += buddy.getDesignskill();
                } else if(buddy is Designer)
                {
                    numOfDesigners++;
                    design_quality += buddy.getDesignskill();
                } else
                {
                    numOfSounds++;
                    sound_quality += buddy.getDesignskill();
                }
            }
            double average = 0;
            if (numOfProgrammers > 0) average += optimization / numOfProgrammers;
            if (numOfDesigners > 0) average += design_quality / numOfDesigners;
            if (numOfSounds > 0) average += sound_quality / numOfSounds;
            if (numOfWriters > 0) average += plot_quality / numOfWriters;
            return average / 4 / 100;
        }

        //очищаем поля для вводов и вводим ограничения на ввод для бюджета
        private void txt_nameofFirm_MouseClick(object sender, MouseEventArgs e)
        {
            txt_nameofFirm.Text = "";
        }

        private void txt_startBudget_TextChanged(object sender, EventArgs e)
        {
            try
            {
          int  a = Int32.Parse(txt_startBudget.Text);
            }
            catch (FormatException)
            {
         if (txt_startBudget.Text!="")
                {
                    MessageBox.Show("Ошибка при вводе. Допустимы только целые числа", "ERROR", MessageBoxButtons.OK);
                    txt_startBudget.Text = "";
                } 
            }
        }

        private void btn_HireCrew_Click(object sender, EventArgs e)
        {
            run_of_time.Enabled = false;
            HireCrew();
            run_of_time.Enabled = true;
        }

        private void txt_startBudget_MouseClick(object sender, MouseEventArgs e)
        {
            txt_startBudget.Text = "";
        }

        private void HireCrew()
        {
            newCrew form2 = new newCrew();
            form2.ShowDialog();
            if (form2.typeOf != "")
            {
                if (form2.typeOf == "Manager") managers.Add(form2.createManager());
                if (form2.typeOf == "Coder")
                {
                    crew.Add(form2.createCoder());
                    dt.Rows.Add("Programmer", crew[crew.Count - 1].getCodeskill(), crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue());
                }
                if (form2.typeOf == "Designer")
                {
                    crew.Add(form2.createDesigner());
                    dt.Rows.Add("Designer", 0, crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue());
                }
                if (form2.typeOf == "Writer")
                {
                    crew.Add(form2.createWriter());
                    dt.Rows.Add("Screenwriter", 0, crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue());
                    }
                if (form2.typeOf == "Sound")
                {
                    crew.Add(form2.createSound());
                    dt.Rows.Add("Sound Designer", 0, crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue());
                    }
            }
        }
    }
}

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
        List<Developer> crew;
        List<Manager> managers;
        DataTable dt,dt1;
        public form_Enterprise()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Создаем две таблицы - для менеджеров и разработчиков
            dt = new DataTable();
            dt.Columns.Add("Position");
            dt.Columns.Add("Code Skill");
            dt.Columns.Add("Design Skill");
            dt.Columns.Add("Performance");
            dt.Columns.Add("Fatigue");
            dt.Columns.Add("FIRED!");
            dt1 = new DataTable();
            dt1.Columns.Add("Position");
            dt1.Columns.Add("Manager Skill");
            dt1.Columns.Add("Fatigue");
            dt1.Columns.Add("FIRED!");
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
            crew = new List<Developer>();

            //Выводим течение дней и запускаем процесс
            txt_currentData.Text = days.ToString();
            run_of_time.Enabled = true;
            crewTable.DataSource = dt;
            managersTable.DataSource = dt1;
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
                FinalFlag = false;
                director1.startProject(genre, size, title);
                txt_CurrProject.Text = ("Title: " + title + "    Genre: " + genre + "    Size: " + size);
                currentGame = director1.getGame();
                currentGame.setRested(crew.Count / 3 + 1);
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
                //Если разработчиков нет, но нанимаем их
                run_of_time.Enabled = false;
                HireCrew();
            }
            run_of_time.Enabled = true;
        if (managers.Count != 0)
            {
                foreach (Manager man in managers)
                {
                    //Выводим усталость менеджеров
                    managersTable.Rows[managers.IndexOf(man)].Cells[2].Value = man.getFatigue();
                    if (days % 30 == 0)
                    {
                        //Выплачиваем зарплату в нужный срок
                        director1.setBudget(director1.returnBudget() - man.GetPaid());
                    }
                    //Менеджеры работают, повышая производительность остальных
                    man.ToWork(crew);
                }
            }
            

            if (days % 30 == 0)
            {
                //Изменяем предпочтения игроков
                customer1.ChangePreferences();
            }

            //Для каждого члена команды
            foreach (Developer buddy in crew)
            {   
                if (days % 30 == 0)
                {

                    //Выплачиваем зарплату в нужный срок
                    director1.setBudget(director1.returnBudget() - buddy.GetPaid());
                }

                //Выводим производительность и усталость
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

            foreach(Developer buddy in crew)
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
        { //"Защита от дурака"
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

        //При нажатии на ячейку DISMISS выводим окно Да/Нет и уувольняем менеджера при подтверждении
        private void managersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (managersTable.CurrentCell.Value.ToString() == "DISMISS?")
            {
                run_of_time.Enabled = false;
                DialogResult result = MessageBox.Show("Вы точно хотите уволить сотрудника?", "ATTENTION", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    managers[managersTable.CurrentCell.RowIndex].Dismissed(crew);
                    managers.RemoveAt(managersTable.CurrentCell.RowIndex);
                    dt1.Rows.Remove(dt1.Rows[managersTable.CurrentCell.RowIndex]);
                }
                run_of_time.Enabled = true;
            }
        }

        //При нажатии на ячейку DISMISS выводим окно Да/Нет и уувольняем сотрудника при подтверждении
        private void crewTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (crewTable.CurrentCell.Value.ToString() == "DISMISS?")
            {
                run_of_time.Enabled = false;
                DialogResult result = MessageBox.Show("Вы точно хотите уволить сотрудника?", "ATTENTION", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    crew.RemoveAt(crewTable.CurrentCell.RowIndex);
                    dt.Rows.Remove(dt.Rows[crewTable.CurrentCell.RowIndex]);
                }
                run_of_time.Enabled = true;
            }
        }

        //Нажатие на кнопку Нанять
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
            //Выводим форму для нанимания сотрудников и нанимаем сотрудника указанного типа с указанными характеристиками
             newCrew form2 = new newCrew();
             form2.ShowDialog();
            switch (form2.getType())
            {
                case "Manager":
                    managers.Add(form2.createManager());
                    dt1.Rows.Add("Manager", managers.Last().getManagerSkill(), managers.Last().getFatigue(), "DISMISS?");
                    managersTable.Rows[dt1.Rows.Count - 1].Cells[3].Style.BackColor = Color.Red;
                    break;
                case "Designer":
                    crew.Add(form2.createDesigner());
                    dt.Rows.Add("Designer", 0, crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue(), "DISMISS?");
                    crewTable.Rows[dt.Rows.Count - 1].Cells[5].Style.BackColor = Color.Red;
                    break;
                case "Programmer":
                    crew.Add(form2.createCoder());
                    dt.Rows.Add("Programmer", crew[crew.Count - 1].getCodeskill(), crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue(), "DISMISS?");
                    crewTable.Rows[dt.Rows.Count - 1].Cells[5].Style.BackColor = Color.Red;
                    break;
                case "ScreenWriter":
                    crew.Add(form2.createWriter());
                    dt.Rows.Add("Screenwriter", 0, crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue(), "DISMISS?");
                    crewTable.Rows[dt.Rows.Count - 1].Cells[5].Style.BackColor = Color.Red;
                    break;
                case "SoundDesigner":
                    crew.Add(form2.createSound());
                    dt.Rows.Add("Sound Designer", 0, crew[crew.Count - 1].getDesignskill(), crew[crew.Count - 1].getPerformance(), crew[crew.Count - 1].getFatigue(), "DISMISS?");
                    crewTable.Rows[dt.Rows.Count - 1].Cells[5].Style.BackColor = Color.Red;
                    break;
            }           
             currentGame.setRested(crew.Count / 3 + 1);
             
        }
    }
}

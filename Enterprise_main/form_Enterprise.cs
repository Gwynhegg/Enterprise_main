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
        double rating = 0;
        Game currentGame;
        List<Developer> crew;
        List<CharacterPanel> crewPanel;
        List<Manager> managers;
        List<CharacterPanel> managerPanel;
        Point startManagers = new Point(10,135);
        Point startCrew = new Point(10,305);
        Random r = new Random();
        public form_Enterprise()
        {
            InitializeComponent();
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
            managerPanel = new List<CharacterPanel>();
            crew = new List<Developer>();
            crewPanel = new List<CharacterPanel>();


            //Выводим течение дней и запускаем процесс
            txt_currentData.Text = days.ToString();
            changeTime();
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
                changeTime();
                form_GameCreation form1 = new form_GameCreation();
                form1.ShowDialog();
                if (form1.isDone)
                {
                    genre = form1.getGenre();
                    size = form1.getSize();
                    title = form1.getName();
                }
                changeTime();
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
                changeTime();
                HireCrew();
                changeTime();
            }
            if (managers.Count != 0)
            {
                foreach (Manager man in managers)
                {
                    //Выводим усталость менеджеров
                    managerPanel[managers.IndexOf(man)].updateParams(man);
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
                customer1.ChangePopulation();
            }

            //Для каждого члена команды
            foreach (Developer buddy in crew)
            {
                //С определенным шансом разработчик "подхватывает" эффекты
                int chance = r.Next(1, 50);
                if (chance==1) buddy.AddNegatives(new Depression(r.Next(1, 20)));
    
                if (days % 30 == 0)
                {

                    //Выплачиваем зарплату в нужный срок
                    
                    director1.setBudget(director1.returnBudget() - buddy.GetPaid());
                }


                //Выводим производительность и усталость
                if (buddy is Programmer)
                {
                    crewPanel[crew.IndexOf(buddy)].updateParams(buddy);
                }
                else
                {
                    crewPanel[crew.IndexOf(buddy)].updateParams(buddy);
                }
                //Отправляем работать
                buddy.ToWork(currentGame);
            }

            if (currentGame.getReadiness()==100 && currentGame.Bugs() <= 0)
            {
                //Высчитываем желательную цену продажи, оценку критиков, продаем и пополняем бюджет
                currReadiness.Maximum = 100;
                label4.Text = "Готовность:";
                rating = getAverage();
                int our_price = director1.SellGame(customer1.getPopulation());
                changeTime();
                int sellment = customer1.BuyGame(currentGame, our_price, rating);
                form_Sellment formSellment = new form_Sellment(customer1.getPopulation(), rating, sellment);
                formSellment.ShowDialog();
                if (formSellment.isDone)
                {
                    changeTime();
                }
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

        //Нажатие на кнопку Нанять
        private void btn_HireCrew_Click(object sender, EventArgs e)
        {
            changeTime();
            HireCrew();
            changeTime();
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
                    if (managerPanel.Count % 5 == 0 && managerPanel.Count!=0)
                    {
                        startManagers.X = 10;
                        startManagers.Offset(0, 170);
                        foreach (CharacterPanel e in crewPanel)
                        {
                            e.Location = new Point(e.Location.X, e.Location.Y + 170);
                        }
                    }
                    managers.Add(form2.createManager());
                    managerPanel.Add(new CharacterPanel("Manager"));
                    managerPanel.Last().TopLevel = false;
                    this.Controls.Add(managerPanel.Last());
                    managerPanel.Last().Location = new Point(startManagers.X, startManagers.Y);
                    managerPanel.Last().Show();
                    startManagers.Offset(150, 0);
                    break;
                case "Designer":
                    crew.Add(form2.createDesigner());
                    createCharPanel("Designer");
                    break;
                case "Programmer":
                    crew.Add(form2.createCoder());
                    createCharPanel("Programmer");
                    break;
                case "ScreenWriter":
                    crew.Add(form2.createWriter());
                    createCharPanel("ScreenWriter");
                    break;
                case "SoundDesigner":
                    crew.Add(form2.createSound());
                    createCharPanel("SoundDesigner");
                    break;
            }           
             currentGame.setRested(crew.Count / 3 + 1);
             
        }

        private void form_Enterprise_Load(object sender, EventArgs e)
        {

        }

        private void createCharPanel(string speciality)
        {
            crewPanel.Add(new CharacterPanel(speciality));
            crewPanel.Last().TopLevel = false;
            this.Controls.Add(crewPanel.Last());
            crewPanel.Last().Location = new Point(startCrew.X,startCrew.Y);
            crewPanel.Last().Show();
            startCrew.Offset(150, 0);
            if (crewPanel.Count%5==0)
            {
                startCrew.X = 10;
                startCrew.Offset(0, 170);
            }
        }

        public void changeTime()
        {
            if (run_of_time.Enabled) run_of_time.Enabled = false; else run_of_time.Enabled = true;
        }
    }
}

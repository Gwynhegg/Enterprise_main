using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    //Класс, описывающий работу менеджера
    public class Manager : Managers
    {
        private int managerSkill,salary,self_fatigue,chance,startCount;
        private bool tired,alreadyUp=false;
        private double motivation;
        Random rnd = new Random();
        public Manager(int skill)
        {
            this.managerSkill = skill;
            salary = skill * 10;
            self_fatigue = 0;
        }

        //Выплачиваем менеджеру зарплату
        public override int GetPaid()
        {
            return salary;
        }
        //Менеджер работает, прибавляя производительность команде
        public override void ToWork(List<Developer> buddy)
        {

            chance = rnd.Next(1, 25);
            if (chance == 1) this.improveSkill(1);
            if (tired)
            {
                //Если устал, то отправляем в отпуск
                GetRest();
            } else
            { //Иначе увеличиваем производительность

               if (!alreadyUp)
               {
                    double temp = (double)managerSkill / 100;
                    motivation = (temp / buddy.Count());
                    startCount = buddy.Count;
                    foreach (Developer e in buddy)
                    {
                        e.set_AddPerformance(motivation);
                        alreadyUp = true;
                    }
                }
            }
           //Если устал, то убираем добавленную производительность и меняем триггер усталости
            self_fatigue += 2;
            if (self_fatigue >= 100)
            {
               for(int i=0;i<startCount;i++)
                {
                    buddy[i].set_AddPerformance(-motivation);
                }
                tired = true;
            }
        }
        //Отдыхаем...
        public override void GetRest()
        {
            self_fatigue -= 5;
            if (self_fatigue <= 0)
            {
                self_fatigue = 0;
                tired = false;
                alreadyUp = false;
            }
        }

        public override int getFatigue()
        {
            return self_fatigue;
        }

        public override int getManagerSkill()
        {
            return managerSkill;
        }
        //При увольнении менеджера его увеличение производительности отменяется
        public override void Dismissed(List<Developer> buddy)
        {
            if (!tired)
            {
                for(int i=0;i<startCount;i++)
                {
                    buddy[i].set_AddPerformance(-motivation);
                }
            }
        }

        public override void improveSkill(int training)
        {
            this.managerSkill += training;
        }
    }
}

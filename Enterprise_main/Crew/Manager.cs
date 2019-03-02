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
        private int managerSkill,salary,self_fatigue,chance;
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
            double temp = (double)managerSkill / 100;
            motivation = (temp / buddy.Count());

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
                    foreach (Developer e in buddy)
                    {
                        e.set_AddPerformance(e.getAddPerformance() + motivation);
                        alreadyUp=true;
                    }
                }
            }
           //Если устал, то убираем добавленную производительность и меняем триггер усталости
            self_fatigue += 2;
            if (self_fatigue >= 100)
            {
               foreach(Developer e in buddy)
                {
                    e.set_AddPerformance(e.getAddPerformance()-motivation);
                }
                tired = true;
                alreadyUp = false;
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
            foreach (Developer dev in buddy)
            {
                dev.set_AddPerformance(dev.getAddPerformance()-motivation);
            }
        }

        public override void improveSkill(int training)
        {
            this.managerSkill += training;
        }
    }
}

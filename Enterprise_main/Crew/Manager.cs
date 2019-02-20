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
        private int managerSkill,salary,self_fatigue;
        private bool tired;

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
            double motivation = (temp / buddy.Count());
            if (tired)
            {
                //Если устал, то отправляем в отпуск
                GetRest();
            } else
            { //Иначе увеличиваем производительность
                foreach (Developer e in buddy)
                {
                    e.set_AddPerformance(motivation);
                }
            }
           //Если устал, то убираем добавленную производительность и меняем триггер усталости
            self_fatigue += 2;
            if (self_fatigue >= 100)
            {
               foreach(Developer e in buddy)
                {
                    e.set_AddPerformance(0);
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
                dev.set_AddPerformance(0);
            }
        }
    }
}

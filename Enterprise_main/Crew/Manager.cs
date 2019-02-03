using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class Manager
    {
        private int managerSkill,salary;

        public Manager(int skill)
        {
            this.managerSkill = skill;
            salary = skill;
        }

        public  int GetPaid()
        {
            return salary;
        }

        public void GetWork(List<Human> buddy)
        {
            double temp = (double)managerSkill / 100;
            double motivation = (temp / buddy.Count());
            foreach(Human e in buddy)
            {
                e.set_AddPerformance(motivation);
            }
        }
    }
}

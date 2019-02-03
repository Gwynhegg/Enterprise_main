using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    //Абстрактный класс
    public abstract class Human
    {
        public abstract void ToWork(Game game);
        public abstract void GetRest();
        public abstract int GetPaid();
        public abstract void set_AddPerformance(double performance);
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    //Абстрактный класс
    public interface Human
    {
          void ToWork(Game game);
          void GetRest(Game game);
          int GetPaid();
          void set_AddPerformance(double performance);
          double getPerformance();
          int getFatigue();
          int getDesignskill();
          int getCodeskill();
    }

}

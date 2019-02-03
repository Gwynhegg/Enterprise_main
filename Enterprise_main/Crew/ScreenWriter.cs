using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class ScreenWriter : Human
    {
        private int designSkill;
        int self_fatigue, salary;
        double self_performance = 0.5;
        bool tired;
        //Конструктор класса, описывающий навыки сценариста, а также его зарплату
        public ScreenWriter(int designSkill)
        {
            this.designSkill = designSkill;
            salary = designSkill;
            self_fatigue = 0;
        }


        //Поступление платы сценаристу
        public override int GetPaid()
        {
            return salary;
        }

        public override void ToWork(Game game)
        {
            //Если работа сценариста не закончена и сценарист не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest();
            }
            else
            {
                int plotDifficulty = game.get_plot_difficulty();
                if (plotDifficulty > 0)
                {
                    plotDifficulty -= (int)(designSkill * self_performance);
                    self_fatigue += 2;
                    game.set_plot_difficulty(plotDifficulty);
                }
            }
            if (self_fatigue >= 100)
            {
                tired = true;
            }
        }

        public override void GetRest()
        {
            //Каждый день усталость спадает, пока не опустится до нуля
            self_fatigue -= 5;
            if (self_fatigue <= 0)
            {
                self_fatigue = 0;
                tired = false;
            }
        }

    }
}

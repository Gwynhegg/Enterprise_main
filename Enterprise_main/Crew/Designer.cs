using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class Designer : Human
    {
        private int designSkill;
        int self_fatigue, salary;
        double self_performance = 0.5,additional_performance=0;
        bool tired;
        //Конструктор класса, описывающий навыки дизайнера, а также его зарплату
        public Designer(int designSkill)
        {
            this.designSkill = designSkill;
            salary = designSkill;
            self_fatigue = 0;
        }


        //Поступление платы дизайнеру
        public override int GetPaid()
        {
            return salary;
        }

        public override void set_AddPerformance(double performance)
        {
            this.additional_performance = performance;
        }

        public override void ToWork(Game game)
        {
            //Если работа дизайнера не закончена и дизайнер не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest();
            }
            else
            {
                int designDifficulty = game.get_design_difficulty();
                if (designDifficulty > 0)
                {
                    designDifficulty -= (int)(designSkill * (self_performance+additional_performance));
                    self_fatigue += 2;
                    game.set_design_difficulty(designDifficulty);
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

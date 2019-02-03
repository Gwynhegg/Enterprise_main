using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class SoundDesigner : Human
    {
        private int designSkill;
        int self_fatigue, salary;
        double self_performance = 0.5;
        bool tired;
        //Конструктор класса, описывающий навыки звукового дизайнера, а также его зарплату
        public SoundDesigner(int designSkill)
        {
            this.designSkill = designSkill;
            salary = designSkill;
            self_fatigue = 0;
        }


        //Поступление платы звук. дизайнеру
        public override int GetPaid()
        {
            return salary;
        }

        public override void ToWork(Game game)
        {
            //Если работа звук. дизайнера не закончена и звук. дизайнер не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest();
            }
            else
            {
                int soundDifficulty = game.get_sound_difficulty();
                if (soundDifficulty > 0)
                {
                    soundDifficulty -= (int)(designSkill * self_performance);
                    self_fatigue += 2;
                    game.set_sound_difficulty(soundDifficulty);
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

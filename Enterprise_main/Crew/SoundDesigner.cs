using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class SoundDesigner : Developer
    {
        private int designSkill;
        int self_fatigue, salary;
        double self_performance = 0.5, additional_performance = 0;
        bool tired;
        //Конструктор класса, описывающий навыки звукового дизайнера, а также его зарплату
        public SoundDesigner(int designSkill)
        {
            this.designSkill = designSkill;
            salary = designSkill*10;
            self_fatigue = 0;
        }

        public override void set_AddPerformance(double performance)
        {
            this.additional_performance = performance;
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
                GetRest(game);
            }
            else
            {
                int soundDifficulty = game.get_sound_difficulty();
                if (soundDifficulty > 0)
                {
                    soundDifficulty -= (int)(designSkill * (self_performance+additional_performance));
                    self_fatigue += 2;
                    game.set_sound_difficulty(soundDifficulty);
                }
                else
                {
                    if (game.get_plot_difficulty() > 0)
                    {
                        int plotDifficulty = game.get_plot_difficulty();
                        plotDifficulty -= (int)((designSkill / 2) * (self_performance + additional_performance));
                        self_fatigue += 2;
                        game.set_plot_difficulty(plotDifficulty);
                    }
                    else
                    {
                        if (game.get_design_difficulty() > 0)
                        {
                            int designDifficulty = game.get_design_difficulty();
                            designDifficulty -= (int)((designSkill / 2) * (self_performance + additional_performance));
                            self_fatigue += 2;
                            game.set_design_difficulty(designDifficulty);
                        }
                    }
                }
            }
            if (self_fatigue >= 100)
            {                //Если возможное количество одновременно отдыхающих не исчерпано, то...

                if (game.getRested() > 0)
                {
                    tired = true;
                    game.setRested(game.getRested() - 1);
                }
                else
                {                    //Если же возможности для отдыха нет, понижаем производительность

                    if (self_performance > 0.01)
                    {
                        self_performance -= 0.01;
                    }
                }
            }
        }

        public override void GetRest(Game game)
        {
            //Каждый день усталость спадает, пока не опустится до нуля
            self_fatigue -= 5;
            if (self_fatigue <= 0)
            {
                game.setRested(game.getRested() + 1);
                self_performance = 0.5;
                self_fatigue = 0;
                tired = false;
            }
        }

        public override int getFatigue()
        {
            return self_fatigue;
        }

        public override double getPerformance()
        {
            return self_performance + additional_performance;
        }

        public override int getDesignskill()
        {
            return designSkill;
        }

        public override int getCodeskill()
        {
            return 0;
        }
    }
}

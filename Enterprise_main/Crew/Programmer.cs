using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    //Класс, опиcывающий программиста, который может в дизайн!!!
    public class Programmer : Human
    {
        private int codeSkill, designSkill;
        int self_fatigue, salary;
        double self_performance = 0.5;
        bool tired;
        //Конструктор класса, описывающий дизайнерские и кодерские навыки программиста, а также его зарплату
        public Programmer(int codeSkill, int designSkill)
        {
            this.codeSkill = codeSkill;
            this.designSkill = designSkill;
            salary = codeSkill + designSkill;
            self_fatigue = 0;
        }

        //Поступление платы программисту
        public override int GetPaid()
        {
            return salary;
        }
        //Программист работает...
        public override void ToWork(Game game)
        {
            //Если работа с кодом не закончена и программист не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest();
            }
            else
            {

                if (game.get_code_difficulty() > 0)
                {
                    int codeDifficulty = game.get_code_difficulty();
                    //Программист вносит лепту в его завершение и понемногу устает...
                    codeDifficulty -= (int)(codeSkill * self_performance);
                    self_fatigue += 2;
                    game.set_code_difficulty(codeDifficulty);
                }
                else
                {
                    if (game.get_design_difficulty() > 0)
                    {
                        int designDifficulty = game.get_design_difficulty();
                        designDifficulty -= (int)(designSkill * self_performance);
                        self_fatigue += 2;
                        game.set_design_difficulty(designDifficulty);
                    }
                    else
                    {
                        if (game.get_sound_difficulty() > 0)
                        {
                            int soundDifficulty = game.get_sound_difficulty();
                            soundDifficulty -= (int)(designSkill * self_performance);
                            self_fatigue += 2;
                            game.set_sound_difficulty(soundDifficulty);
                        }
                        else
                        {
                            if (game.get_plot_difficulty() > 0)
                            {
                                int plotDifficulty = game.get_plot_difficulty();
                                plotDifficulty -= (int)(designSkill * self_performance);
                                self_fatigue += 2;
                                game.set_plot_difficulty(plotDifficulty);
                            }
                        }
                    }
                }
            }
            //Если усталость достигает пика, то...                  
            if (self_fatigue >= 100)
            {
                tired = true;
            }
        }
        public override void GetRest()
        {
            //Каждый день усталость спадает, пока не опустится до нуля
            self_fatigue -= 5;
            if (self_fatigue <= 0) {
                self_fatigue = 0;
                tired = false;
            }
        }
    }

}

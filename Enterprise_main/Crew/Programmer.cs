using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    //Класс, опиcывающий программиста, который может в дизайн!!!
    public class Programmer : Coder
    {
        //Конструктор класса, описывающий дизайнерские и кодерские навыки программиста, а также его зарплату
        public Programmer(int codeSkill, int designSkill)
        {
            this.codeSkill = codeSkill;
            this.designSkill = designSkill;
            salary = (codeSkill + designSkill) * 10;
            self_fatigue = 0;
        }

        //Программист работает...
        public override void ToWork(Game game)
        {
            //Если негативные эффекты есть, то они оказывают влияние, пока не окончатся

            EffectsWork();
            chance = rnd.Next(1, 50);
            if (chance == 1) this.improveCodeSkill(1);
            if (chance == 2) this.improveDesignSkill(1);
            //Если работа с кодом не закончена и программист не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest(game);
            }
            else
            {
                if (game.get_code_difficulty() > 0)
                {
                    //Программист вносит лепту в его завершение и понемногу устает...
                    this.doCode(game, codeSkill + additional_skill, self_performance, additional_performance);
                    self_fatigue += 2;

                    //Упс...создание бага
                    if (rnd.Next(5) == 1) game.CreateBug();
                }
                else if (game.get_design_difficulty() > 0)
                {
                    this.doDesign(game, designSkill + additional_skill, self_performance, additional_performance);
                    self_fatigue += 2;

                }
                else if (game.get_sound_difficulty() > 0)
                {
                    this.doSound(game, designSkill + additional_skill, self_performance, additional_performance);
                    self_fatigue += 2;

                }
                else if (game.get_plot_difficulty() > 0)
                {
                    this.doPlot(game, designSkill+additional_skill, self_performance, additional_performance);
                    self_fatigue += 2;

                }

                if (game.getReadiness() == 100)
                {
                    game.Debug();
                    self_fatigue += 2;
                }
                TiredCheck(game);

            }

        }

    }

}

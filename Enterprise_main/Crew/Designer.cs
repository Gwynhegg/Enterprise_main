﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class Designer : Developer
    {

        //Конструктор класса, описывающий навыки дизайнера, а также его зарплату
        public Designer(int designSkill)
        {
            this.designSkill = designSkill;
            salary = designSkill * 10;
            self_fatigue = 0;
        }

        public override void ToWork(Game game)
        {
            EffectsWork();
            chance = rnd.Next(1, 50);
            if (chance == 2) this.improveDesignSkill(1);
            //Если работа дизайнера не закончена и дизайнер не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest(game);
            }
            else
            {
                if (game.get_design_difficulty() > 0)
                {
                    this.doDesign(game,designSkill, self_performance, additional_performance);
                    self_fatigue += 2;
                }
                else if (game.get_sound_difficulty() > 0)
                {
                     this.doSound(game, designSkill / 2, self_performance, additional_performance);
                     self_fatigue += 2;
                       
                }
                else if (game.get_plot_difficulty() > 0)
                {
                     this.doPlot(game, designSkill / 2, self_performance, additional_performance);
                     self_fatigue += 2;
                }
            }
            TiredCheck(game);
        }

    }
    }

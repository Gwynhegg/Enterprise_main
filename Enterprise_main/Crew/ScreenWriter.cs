using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class ScreenWriter : Developer
    {
        private int designSkill,additional_skill;
        int self_fatigue, salary,chance;
        double self_performance = 0.5,additional_performance=0;
        bool tired;
        Random rnd = new Random();
        PrivateEffects negative_effects;

        //Конструктор класса, описывающий навыки сценариста, а также его зарплату
        public ScreenWriter(int designSkill)
        {
            this.designSkill = designSkill;
            salary = designSkill * 10;
            self_fatigue = 0;
        }

        //Поступление платы сценаристу
        public override int GetPaid()
        {
            return salary;
        }
        //Получение негативных зарактеристик, влияющих на работу
        public override void AddNegatives(PrivateEffects effect)
        {
            negative_effects = effect;
        }

        public override void ToWork(Game game)
        {
            //Если негативные эффекты есть, то они оказывают влияние, пока не окончатся
            if (negative_effects != null)
            {
                if (negative_effects.getDuration() >= 0) negative_effects.HaveEffect(this);

            }

            chance = rnd.Next(1, 50);
            if (chance == 2) this.improveDesignSkill(1);
            //Если работа сценариста не закончена и сценарист не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest(game);
            }
            else
            {

                if (game.get_plot_difficulty() > 0)
                {
                    this.doPlot(game, designSkill, self_performance, additional_performance);
                    self_fatigue += 2;
                }
                else if (game.get_sound_difficulty() > 0)
                {
                    this.doSound(game, designSkill / 2, self_performance, additional_performance);
                    self_fatigue += 2;
                }
                else if (game.get_design_difficulty() > 0)
                {
                    this.doDesign(game, designSkill / 2, self_performance, additional_performance);
                    self_fatigue += 2;
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
                {
                    //Если же возможности для отдыха нет, понижаем производительность
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
            return self_performance;
        }


        public override void set_AddPerformance(double performance)
        {
            this.additional_performance = performance;
        }


        public override double getAddPerformance()
        {
            return additional_performance;
        }

        public override int getDesignskill()
        {
            return designSkill;
        }

       public override int getCodeskill()
        {
           return 0;
        }
        public override void set_AddEffSkill(int skill)
        {
            this.additional_skill = skill;
        }

        public override int getAddSkill()
        {
            return additional_skill;
        }

        public override void improveDesignSkill(int training)
        {
            this.designSkill += training;
        }
    }
}

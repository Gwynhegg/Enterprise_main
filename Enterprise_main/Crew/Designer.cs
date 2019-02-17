﻿using System;
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
        public  int GetPaid()
        {
            return salary;
        }

        public  void set_AddPerformance(double performance)
        {
            this.additional_performance = performance;
        }

        public  void ToWork(Game game)
        {
            //Если работа дизайнера не закончена и дизайнер не в отпуске, то...
            if (tired)
            //Если устал, то в отпуск
            {
                GetRest(game);
            }
            else
            {
                int designDifficulty = game.get_design_difficulty();
                if (designDifficulty > 0)
                {
                    designDifficulty -= (int)(designSkill * (self_performance + additional_performance));
                    self_fatigue += 2;
                    game.set_design_difficulty(designDifficulty);
                }
                else
                {
                    if (game.get_sound_difficulty() > 0)
                    {
                        int soundDifficulty = game.get_sound_difficulty();
                        soundDifficulty -= (int)((designSkill / 2) * (self_performance + additional_performance));
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

                    if (self_performance > 0.02)
                    {
                        self_performance -= 0.02;
                    }
                }
            }
        }

        public  void GetRest(Game game)
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

        public  int getFatigue()
        {
            return self_fatigue;
        }

        public  double getPerformance()
        {
            return self_performance + additional_performance;
        }

        public  int getDesignskill()
        {
            return designSkill;
        }

        public int getCodeskill()
        {
            return 0;
        }
    }
    }

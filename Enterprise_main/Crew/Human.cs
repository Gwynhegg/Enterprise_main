using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    //Абстрактный класс
    public abstract class Human
    {
        protected int self_fatigue, salary;

        public  int GetPaid()
        {
            return salary;
        }
        public  int getFatigue()
        {
            return self_fatigue;
        }
    }

    public abstract class Developer : Human
    {
        //Метод, описывающий работу
        protected int designSkill, additional_skill = 0,chance, codeSkill;
        protected double self_performance=0.5, additional_performance = 0;
        protected bool tired;
        protected Random rnd = new Random();
        protected List<PrivateEffects> effects = new List<PrivateEffects>();

        public abstract void ToWork(Game game);

        //Метод, описывающий отдых
        public void GetRest(Game game)
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

        //Геттеры для характеристик
        public  int getDesignskill()
        {
            return designSkill;
        }

        public  int getCodeskill()
        {
            return codeSkill;
        }

        public  int getAddSkill()
        {
            return additional_skill;
        }

        //Метод, который рандомно повышае характеристики на один(Тренировка)
        public  void improveDesignSkill(int training)
        {
            this.designSkill += training;
        }

        //Геттеры и сеттеры для производительности и навыков
        public  void set_AddPerformance(double performance)
        {
            this.additional_performance += performance;
        }

        public  double getAddPerformance()
        {
            return additional_performance;
        }

        public  double getPerformance()
        {
            return self_performance;
        }

        public double getTotalPerformance()
        {
            return getPerformance() + getAddPerformance();
        }

        public int getTotalCodeSkill()
        {
            return getCodeskill() + getAddSkill();
        }

        public int getTotalDesignSkill()
        {
            return getDesignskill() + getAddSkill();
        }

        //процесс работы, вкладывание очков в общий прогресс
        public void doDesign(Game game, int designSkill, double self_performance,double additional_performance)
        {
            int designDifficulty = game.get_design_difficulty();
            designDifficulty -= (int)(designSkill * (self_performance + additional_performance));
            game.set_design_difficulty(designDifficulty);
        }

        public void doSound(Game game, int designSkill, double self_performance, double additional_performance)
        {
            int soundDifficulty = game.get_sound_difficulty();
            soundDifficulty -= (int)(designSkill * (self_performance + additional_performance));
            game.set_sound_difficulty(soundDifficulty);
        }
        public void doPlot(Game game, int designSkill, double self_performance, double additional_performance)
        {
            int plotDifficulty = game.get_plot_difficulty();
            plotDifficulty -= (int)(designSkill * (self_performance + additional_performance));
            game.set_plot_difficulty(plotDifficulty);
        }

        public  void set_AddEffSkill(int skill)
        {
            this.additional_skill += skill;
        }

        //Добавление негативных влияний
        public void AddNegatives(PrivateEffects eff)
        {
            effects.Add(eff);
        }

        public void EffectsWork()
        {

            if (effects.Count != 0)
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    effects[i].HaveEffect(this);
                    if (effects[i].getDuration() == -1)
                    {
                        effects.Remove(effects[i]);
                        i--;
                    }
                }
            }
        }

        public void TiredCheck(Game game)
        {

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
    }

    public abstract class Coder : Developer
    {
        //тренинг навыков кодинга
        public void improveCodeSkill(int training)
        {
            codeSkill += training;
        }
        public void doCode(Game game, int codeSkill, double self_performance, double additional_performance)
        {
            int codeDifficulty = game.get_code_difficulty();
            codeDifficulty -= (int)(codeSkill * (self_performance + additional_performance));
            game.set_code_difficulty(codeDifficulty);
        }

    }

    public abstract class Managers : Human
    {
        
        public abstract void improveSkill(int training);
        public abstract void ToWork(List<Developer> human);
        public abstract void GetRest();
        public abstract int getManagerSkill();
        //Метод, обнуляющий влияни менеджера на коллектив при увольнении
        public abstract void Dismissed(List<Developer> human);
    }

}

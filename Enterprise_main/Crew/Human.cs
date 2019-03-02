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
        public abstract int GetPaid();
        public abstract int getFatigue();
    }

    public abstract class Developer : Human
    {
        //Метод, описывающий работу
        public abstract void ToWork(Game game);
        //Метод, описывающий отдых
        public abstract void GetRest(Game game);
        //Геттеры для характеристик
        public abstract int getDesignskill();
        public abstract int getCodeskill();
        public abstract int getAddSkill();
        //Метод, который рандомно повышае характеристики на один(Тренировка)
        public abstract void improveDesignSkill(int training);
        //Геттеры и сеттеры для производительности и навыков
        public abstract void set_AddPerformance(double performance);
        public abstract double getAddPerformance();
        public abstract double getPerformance();
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
        public abstract void set_AddEffSkill(int skill);
        //Добавление негативных влияний
        public abstract void AddNegatives(PrivateEffects eff);
    }

    public abstract class Coder : Developer
    {
        //тренинг навыков кодинга
        public abstract void improveCodeSkill(int training);
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

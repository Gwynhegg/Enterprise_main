using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public abstract class Human
    {
        int self_performance,self_fatigue, zp;
        bool tired = false;
        public abstract void ToWork(Game game);
        public abstract void GetRest();
        public abstract int GetPaid();
    }

    public class Programmer : Human
    {
        private int codeSkill, designSkill;
        int self_performance = 50, self_fatigue = 0, zp;
        bool tired = false;
        public Programmer(int codeSkill, int designSkill)
        {
            this.codeSkill = codeSkill;
            this.designSkill = designSkill;
            zp = codeSkill + designSkill;
        }
        public override int GetPaid()
        {
            return zp;
        }

        public override void ToWork(Game game)
        {
            int codeDifficulty = game.get_code_difficulty();
            if (codeDifficulty >0)
            {
                codeDifficulty -= codeSkill + self_performance;
                self_fatigue += 1;
                game.set_code_difficulty(codeDifficulty);
            }
            if (self_fatigue == 100)
            {
                tired = true;
            }
            while (tired)
            {
                GetRest();
            }
        }
        public override void GetRest()
        {
            self_fatigue--;
            if (self_fatigue == 0)
            {
                tired = true;
            }
        }
    }
}

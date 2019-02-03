using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class Game
    {
        private string genre, title, size;
        private int soundDifficulty, designDifficulty, codeDifficulty, plotDifficulty;
        public int numOfBugs;
        private double sumDifficulty, startDifficulty;

        public Game(string genre,string size,string title)
        {
            this.genre = genre;
            this.size = size;
            this.title = title;
        }
        public int get_code_difficulty()
        {
            return codeDifficulty;
        }
        public void set_code_difficulty(int changed_difficulty)
        {
            this.codeDifficulty = changed_difficulty;
        }
        public void getDifficulty()
        {
            int num = 1;
            switch (size)
            {
                case "Small": num = 1;break;
                case "Medium":num = 2;break;
                case "Large":num = 3;break;
            }
            switch (genre)
            {
                case "Horror" :
                    soundDifficulty = 1000 * num;
                    designDifficulty = 1000 * num;
                    codeDifficulty = 1500 * num;
                    plotDifficulty = 500 * num;
                    break;
                case "Shooter" :
                    soundDifficulty = 500 * num;
                    designDifficulty = 1000 * num;
                    codeDifficulty = 2000 * num;
                    plotDifficulty = 500 * num;
                    break;
                case "RPG":
                    soundDifficulty = 500 * num;
                    designDifficulty = 1000 * num;
                    codeDifficulty = 1000 * num;
                    plotDifficulty = 2000 * num;
                    break;
            }
            
            sumDifficulty = soundDifficulty + designDifficulty + codeDifficulty + plotDifficulty;
            startDifficulty = sumDifficulty;
        }

        public double getReadiness()
        {
            sumDifficulty = soundDifficulty + designDifficulty + codeDifficulty + plotDifficulty;
            Console.WriteLine(sumDifficulty / startDifficulty);
            return (100-sumDifficulty / startDifficulty * 100);
        }
    }
}

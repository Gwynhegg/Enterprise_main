using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public class Director
    {
        public Game currentGame;
        private string nameofFirm;
        private int budget;
        public bool hasProject = false;

        public Director(string name, int budget)
        {
            nameofFirm = name;
            this.budget = budget;
        }

        public int returnBudget()
        {
            return budget;
        }

        public void setBudget(int budget)
        {
            this.budget = budget;
        }

        public string returnName()
        {
            return nameofFirm;
        }

        public void startProject(string genre, string size, string title)
        {
            currentGame = new Game(genre,size,title);
            currentGame.getDifficulty();
        }
        public Game getGame()
        {
            return currentGame;
        }
        public double readiness_ofProject()
        {
            return currentGame.getReadiness();
        }
    }
}

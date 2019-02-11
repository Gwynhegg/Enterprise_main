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
        private int budget,start_budget;
        public bool hasProject = false;

        //Конструктор класса, определяющий имя фирмы и начальный бюджет
        public Director(string name, int budget)
        {
            nameofFirm = name;
            this.budget = budget;
        }

        //геттер бюджета
        public int returnBudget()
        {
            return budget;
        }
    
        //сеттер бюджета
        public void setBudget(int budget)
        {
            this.budget = budget;
        }

        //геттер имени фирмы
        public string returnName()
        {
            return nameofFirm;
        }

        //Метод начала проекта
        public void startProject(string genre, string size, string title)
        {
            //Создание нового экземпляра игры с заданным жанром, размером и названием
            currentGame = new Game(genre,size,title);
            //Просчитывание сложности игры
            currentGame.getDifficulty();
            start_budget = budget;
        }
        //геттер текущей игры
        public Game getGame()
        {
            return currentGame;
        }

        public int SellGame(int population)
        {
            hasProject = false;
            int costs = start_budget - budget;
            int price = (population / 2) / costs;
            return price;
        }
        //просчитывание готовности текущей игры
        public double readiness_ofProject()
        {
            return currentGame.getReadiness();
        }
    }
}

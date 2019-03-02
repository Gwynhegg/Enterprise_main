using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Enterprise_main
{
    class Customer
    {
        private int population;
        Random rnd = new Random();
        string temp;
        //Список предпочтений игроков
        List<string> wanted = new List<string>() { "Horror","Shooter","RPG","Simulator","Arcade","Strategy"};
        
    public int getPopulation()
        {
            return population;
        }
        //Создаем класс потребителей с численностью population
    public Customer(int population)
        {
            this.population = population;
        }
        //Изменяем предпочтения потребителей
    public void ChangePreferences()
        {
            for (int i = 0; i < wanted.Count; i++)
            {
                int j = rnd.Next(wanted.Count);
                temp = wanted[j];
                wanted[j] = wanted[i];
                wanted[i] = temp;
            }
        }
        //Покупка игры
    public int BuyGame(Game game,int our_price, double rating)
        {
            //Вычитываем желание покупки в зависимости от предпочтений, количества багов (И КАЧЕСТВА!!!!!!!)
            double desire = (100 - (wanted.IndexOf(game.getGenre()) * 10)-(game.Bugs()))*rating;
            //Возвращаем деньги от продажи игры 
            return (population * (int)desire / 100)*our_price;
        }
    }
}
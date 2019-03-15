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
            double desire = (100 - (wanted.IndexOf(game.getGenre()) * 10)-(game.getHiddenBugs()))*rating;
            //Возвращаем деньги от продажи игры 
            if (desire >= 50) desire += 10 * game.getSize(); else desire -= 10 * game.getSize();
            if (desire <=0) desire=0.01;
            if (desire > 100) population = (int)(population * (desire / 100));
            return (int)(population * desire / 100)*our_price;
        }

    public void ChangePopulation()
        {
            if (rnd.Next(10) > 3) population += rnd.Next(population / 2); else
            {
                if (population - population / 5 > 0) population -= rnd.Next(population / 5);
            }
        }
    }
}
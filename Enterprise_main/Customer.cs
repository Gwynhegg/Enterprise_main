using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Enterprise_main
{
    class Customer
    {
        private int population,want,game_price;
        Random rnd = new Random();
        string temp;
        List<string> wanted = new List<string>() { "Horror","Shooter","RPG"};
        
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
    public int BuyGame(Game game,int our_price)
        {
            //Вычитываем желание покупки в зависимости от предпочтений, количества багов (И КАЧЕСТВА!!!!!!!)
            int desire = 100 - (wanted.IndexOf(game.getGenre()) * 10)-(game.Bugs());
            //Возвращаем деньги от продажи игры (ДОРАБОТАТЬ!!!!!!!)
            return (population * desire / 100)*our_price;
        }
    }
}
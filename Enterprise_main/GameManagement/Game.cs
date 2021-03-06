﻿using System;
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
        private int numOfBugs, hiddenBugs;
        private double sumDifficulty, startDifficulty;
        private int numOfRested;
        Random r = new Random();

        //конструктор класса, определяющий жанр, размер и название игры
        public Game(string genre,string size,string title)
        {
            this.genre = genre;
            this.size = size;
            this.title = title;
        }
        public void setRested(int rest)
        {
            numOfRested = rest;
        }

        public int getRested()
        {
            return numOfRested;
        }
        //Создание бага
        public void CreateBug()
        {
            numOfBugs++;
        }

        public int getSize()
        {
            switch (size)
            {
                case "Small": return 0; 
                case "Medium": return 1; 
                case "Large": return 2;
            }
            return 0;
        }

        //Дебаггинг
        public void Debug()
        {
            numOfBugs--;
            if (r.Next(50) == 1) hiddenBugs++;
        }

        public int getHiddenBugs()
        {
            return hiddenBugs;
        }
        public int Bugs()
        {
            return numOfBugs;
        }
        //геттер и сеттер для сложности кода игры (работа программиста)
        public int get_code_difficulty()
        {
            return codeDifficulty;
        }
        public void set_code_difficulty(int changed_difficulty)
        {
            this.codeDifficulty = changed_difficulty;
        }

        //геттер и сеттер для сложности звуковой составляющей
        public int get_sound_difficulty()
        {
            return soundDifficulty;
        }
        public void set_sound_difficulty(int changed_difficulty)
        {
            this.soundDifficulty = changed_difficulty;
        }

        //геттер и сеттер для сложности дизайна
        public int get_design_difficulty()
        {
            return designDifficulty;
        }
        public void set_design_difficulty(int changed_difficulty)
        {
            this.designDifficulty = changed_difficulty;
        }

        //геттер и сеттер для сложности сюжета
        public int get_plot_difficulty()
        {
            return plotDifficulty;
        }
        public void set_plot_difficulty(int changed_difficulty)
        {
            this.plotDifficulty = changed_difficulty;
        }

        public string getGenre()
        {
            return genre;
        }
        //просчитывание сложности проекта
        public void getDifficulty()
        {
            int num = 1;
            //Коэффициент размера игры
            switch (size)
            {
                case "Small": num = 1;break;
                case "Medium":num = 3;break;
                case "Large":num = 5;break;
            }
            //Просчитывание характеристик для определенного жанра
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
                case "Simulator":
                    soundDifficulty = 1000 * num;
                    designDifficulty = 1000 * num;
                    codeDifficulty = 2000 * num;
                    plotDifficulty = 500 * num;
                    break;
                case "Strategy":
                    soundDifficulty = 1000 * num;
                    designDifficulty = 1500 * num;
                    codeDifficulty = 1000 * num;
                    plotDifficulty = 500 * num;
                    break;
                case "Arcade":
                    soundDifficulty = 1000 * num;
                    designDifficulty = 1500 * num;
                    codeDifficulty = 500 * num;
                    plotDifficulty = 1000 * num;
                    break;
            }
            
            //Суммируем сложность
            sumDifficulty = soundDifficulty + designDifficulty + codeDifficulty + plotDifficulty;
            startDifficulty = sumDifficulty;
        }

        public double getStartDifficulty()
        {
            return startDifficulty;
        }
        //Метод для вычисления готовности
        public double getReadiness()
        {
            //Пересчитываем текущую сложность проекта и сравниваем с изначальной
            if (soundDifficulty < 0) soundDifficulty = 0;
            if (designDifficulty < 0) designDifficulty = 0;
            if (codeDifficulty < 0) codeDifficulty = 0;
           if (plotDifficulty < 0) plotDifficulty = 0;

            sumDifficulty = soundDifficulty + designDifficulty + codeDifficulty + plotDifficulty;
            return (100-sumDifficulty / startDifficulty * 100);
        }
    }
}

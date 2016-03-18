using System;
using System.ComponentModel;
using TextAdventure.Living_Critter.Enemy_Types;
using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Objects;

namespace TextAdventure.Map
{
    public class Map
    {
        private readonly Random randNum = new Random();

        private const int MAX  = 70;
        private const int MIN = 55;

        private int width;
        private int height;
        private int enemies;
        private int containers;

        private readonly Enemy[,] enemyLocations;
        private readonly Container[,] containerLocations;

        public Map()
        {
            var r1 = new Random();
            var r2 = new Random();
            var widthHeight    = r2.Next(25, 40);
            width              = r1.Next(MIN, MAX)%widthHeight;
            height             = r1.Next(MIN, MAX) % (80 - widthHeight);
            enemies            = 0;
            containers         = 0;
            enemyLocations     = new Enemy[width, height];
            containerLocations = new Container[width, height];
            FillPoints();
        }

        public void FillPoints()
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (3 <= randNum.Next(100))
                    {
                        if (60 > randNum.Next(100))
                        {
                            enemyLocations[i, j] = GenerateEnemy(i, j);
                        }
                        else
                        {
                            containerLocations[i,j] = GenerateContainer(i, j);
                        }
                    }
                }
            }
        }

        public Container GenerateContainer(int w, int h)
        {
            var c = new Container();
            return c;
        }

        public Enemy GenerateEnemy(int w, int h)
        {
            var type = Enemy.enemyTypes[randNum.Next(0, 5)];
            var hLevel = Human.userLevel;
            var e = new Enemy(type, hLevel);
            return e;
        }
    }
}
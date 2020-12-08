using System;
using System.Threading;

namespace internship_4_oop_and_architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeSetup();
            string heroTypeAnswer = Console.ReadLine();
            if (heroTypeAnswer.ToUpper() == "WARRIOR")
            {
                Console.WriteLine("Great pick, enter your character's name:");
                var warrior = new Warrior()
                {
                    Name = Console.ReadLine(),
                    MaxHealth = 150,
                    CurrentHealth = 150,
                    CurrentExperience = 0,
                    MaxExperience=10,
                    Damage=15,
                    PlayerType=PlayerType.Warrior
                };
            }
            
            else if(heroTypeAnswer.ToUpper() == "MAGE")
            {
                var mage = new Mage()
                {
                    Name=Console.ReadLine(),
                    MaxHealth=65,
                    CurrentHealth=65,
                    CurrentExperience=0,
                    MaxExperience=10,
                    Damage=40,
                    PlayerType=PlayerType.Mage,
                    MaxMana=100,
                    CurrentMana=100
                };
            }

            else if(heroTypeAnswer.ToUpper() == "RANGER")
            {
                var ranger = new Ranger()
                {
                    Name = Console.ReadLine(),
                    MaxHealth = 100,
                    CurrentHealth = 100,
                    CurrentExperience = 0,
                    MaxExperience = 10,
                    Damage = 30,
                    PlayerType = PlayerType.Ranger,
                    CritChance=0.1f,
                    StunChance=0.05f
                };
            }

            else
                Console.WriteLine("Wrong input, try again!");

        }
        static void WelcomeSetup()
        {
            Console.Title = "Dungeon-Crawl Game";
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125);
            for (int i = 0; i < 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Welcome");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" to ");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("my ");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("game!");
                Thread.Sleep(100);
                Console.Clear();
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Welcome");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" to ");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("my ");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("game!");
                Thread.Sleep(100);
                Console.Clear();
                Thread.Sleep(100);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Warrior\t");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Mage\t");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Ranger\t");
            Console.ResetColor();
        }
    }
}

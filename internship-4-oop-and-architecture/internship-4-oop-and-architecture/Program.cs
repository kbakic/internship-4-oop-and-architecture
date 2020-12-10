using System;
using System.Collections.Generic;
using System.Threading;

namespace internship_4_oop_and_architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeSetup();

            var generatedEnemy = new List<EnemyType>();
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                int chance = rnd.Next(1, 100);
                if (chance <= 10)
                    generatedEnemy.Add((EnemyType)(3));
                else if (chance <= 40)
                    generatedEnemy.Add((EnemyType)(2));
                else
                    generatedEnemy.Add((EnemyType)(1));
            }

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
                    Level = 1,
                    Damage = 15,
                    DamageIncrease = 1.5f,
                    PlayerType=PlayerType.Warrior
                };
                Console.WriteLine("Your character has been created and you picked: " + warrior.PlayerType);

                foreach (var enemy in generatedEnemy)
                {
                    if (enemy == EnemyType.Goblin)
                    {
                        Console.WriteLine("Your luck picked Goblin as your enemy! This one is easy ;)");
                        var goblin = new Enemy
                        {
                            Name = "Goblin",
                            Health = 50,
                            Damage = 10,
                            EnemyType = EnemyType.Goblin,
                            isStunned = false
                        };
                        WarriorGame(warrior, goblin);
                    }
                }

            }
            
            else if(heroTypeAnswer.ToUpper() == "MAGE")
            {
                Console.WriteLine("Great pick, now enter your character's name:");

                var mage = new Mage()
                {
                    Name = Console.ReadLine(),
                    MaxHealth = 65,
                    CurrentHealth = 65,
                    CurrentExperience = 0,
                    MaxExperience = 10,
                    Level = 1,
                    Damage = 40,
                    PlayerType = PlayerType.Mage,
                    MaxMana = 100,
                    CurrentMana = 100,
                    Resurrection = true
                };
                Console.WriteLine("Your character has been created and you picked: " +  mage.PlayerType);

            }

            else if(heroTypeAnswer.ToUpper() == "RANGER")
            {
                Console.WriteLine("Great pick, now enter your character's name:");

                var ranger = new Ranger()
                {
                    Name = Console.ReadLine(),
                    MaxHealth = 100,
                    CurrentHealth = 100,
                    CurrentExperience = 0,
                    MaxExperience = 10,
                    Level=1,
                    Damage = 30,
                    PlayerType = PlayerType.Ranger,
                    CritChance=0.1f,
                    StunChance=0.05f
                };
                Console.WriteLine("Your character has been created and you picked: " + ranger.PlayerType);


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

        static Warrior WarriorGame(Warrior playerInfo,Enemy currentEnemy)
        {
            while (playerInfo.CurrentHealth > 0 && currentEnemy.Health > 0)
            {
                Console.WriteLine("Pick your next move: DirectAttack (1), SideAttack (2), CounterAttack (3) !");
                int pickMove = int.Parse(Console.ReadLine());

                Random randomPick = new Random();
                int enemyPickMove = randomPick.Next(1, 3);
                if (pickMove > 0 && pickMove < 4)
                {
                    if (!currentEnemy.isStunned)
                    {
                        if (pickMove == enemyPickMove)
                        {
                            Console.WriteLine("What are the chances, you picked the same move. Try again!");
                        }
                        else if (pickMove == 1 && enemyPickMove == 2 || pickMove==2 && enemyPickMove==3 || pickMove==3 && enemyPickMove==1)
                        {
                            Console.WriteLine("Nice pick! You attack first!");

                            Console.WriteLine("What type of attack do you want to perform? Normal Attack (N) or Rage Attack (R) ?");
                            string typeOfAttack = Console.ReadLine();

                            if (typeOfAttack.ToLower() != "n" && typeOfAttack.ToLower() != "r")
                                Console.WriteLine("Wrong pick mate! Let's try this again!");

                            else if (typeOfAttack.ToLower() == "n")
                            {
                                Console.WriteLine("Nice! You successfully attacked!");
                                currentEnemy.Health -= playerInfo.Damage;
                            }

                            else
                            {
                                Console.WriteLine($"Nice! {playerInfo.Name} is doing great!");
                                currentEnemy.Health -= playerInfo.Damage*playerInfo.DamageIncrease;
                                playerInfo.CurrentHealth -= playerInfo.CurrentHealth * 0.5f;
                            }
                        }

                        else if(pickMove==1 && enemyPickMove == 3 || pickMove==2 && enemyPickMove==1 || pickMove==3 && enemyPickMove==2)
                        {
                            Console.WriteLine($"Bad luck! {playerInfo.Name} is about to be hurt!");
                            playerInfo.CurrentHealth -= currentEnemy.Damage;
                        }
                        
                    }
                    
                }
                
                else if (currentEnemy.isStunned)
                {
                    Console.WriteLine("What type of attack do you want to perform? Normal Attack (N) or Rage Attack (R) ?");
                    string typeOfAttack = Console.ReadLine();

                    if (typeOfAttack.ToLower() != "n" && typeOfAttack.ToLower() != "r")
                        Console.WriteLine("Wrong pick mate! Let's try this again!");

                    else if (typeOfAttack.ToLower() == "n")
                    {
                        Console.WriteLine("Nice! You successfully attacked!");
                        currentEnemy.Health -= playerInfo.Damage;
                    }

                    else
                    {
                        Console.WriteLine($"Nice! {playerInfo.Name} is doing great!");
                        currentEnemy.Health -= playerInfo.Damage*playerInfo.DamageIncrease;
                        playerInfo.CurrentHealth -= playerInfo.CurrentHealth * 0.5f;
                    }
                    
                }

                else
                {
                    Console.WriteLine("Wrong input!");
                }

                Console.WriteLine($"╔══════════════╦═══════╗");
                Console.WriteLine($"║ Your Health  ║  {playerInfo.CurrentHealth}   ║");
                Console.WriteLine($"╠══════════════╬═══════╣");
                Console.WriteLine($"║ Enemy Health ║  {currentEnemy.Health}   ║");
                Console.WriteLine($"╚══════════════╩═══════╝");

            }
            if (playerInfo.CurrentHealth <= 0)
            {
                Console.WriteLine($"{playerInfo.Name} died! Better luck next time!");
                System.Environment.Exit(1);
            }
            else
            {
                Console.WriteLine($"Good job! {playerInfo.Name} worked hard and defeated {currentEnemy.Name}! Moving onto the next enemy!");
            }


            return playerInfo;
        }
    }

}


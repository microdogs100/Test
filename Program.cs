using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace MyTextRpg
{
    internal class Program
    {
        enum ClassType
        { 
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        enum MonsterType
        { 
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }
        
        static ClassType ChooseClass()
        {
            
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁사");
            Console.WriteLine("[3] 법사");

            ClassType choice = ClassType.None;
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    choice = ClassType.Knight;
                    Console.WriteLine("기사를 선택하셨습니다.");
                    break;
                case "2":
                    choice = ClassType.Archer;
                    Console.WriteLine("궁수를 선택하셨습니다.");
                    break;
                case "3":
                    choice = ClassType.Mage;
                    Console.WriteLine("법사를 선택하셨습니다.");
                    break;
            }

            return choice;
                        
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {            
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 13;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 16;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }

        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand =  new Random();
            int randMonster = rand.Next(1, 4);
            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.Write("슬라임 ");
                    Console.Write(randMonster);
                    Console.WriteLine(" 마리가 나타났습니다!");
                    monster.hp = 100;
                    monster.attack = 10;
                    break;
                case (int)MonsterType.Orc:
                    Console.Write("오크 ");
                    Console.Write(randMonster);
                    Console.WriteLine(" 마리가 나타났습니다!");
                    monster.hp = 75;
                    monster.attack = 13;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.Write("스켈레톤 ");
                    Console.Write(randMonster);
                    Console.WriteLine(" 마리가 나타났습니다!");
                    monster.hp = 50;
                    monster.attack = 16;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다");

                Monster monster;
                CreateRandomMonster(out monster);
                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 일정 확률로 마을에 돌아감");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Fight(ref player, ref monster);
                    if (player.hp <= 0)
                    {
                        break;
                    }                   
                }

                else if (userInput == "2")
                { 
                    Random random = new Random();
                    int randValue = random.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는 데 성공했습니다.");
                    }

                    else
                    {
                        Fight(ref player, ref monster);
                        if (player.hp <= 0)
                        {
                            break;
                        }
                    }
                        
                }

            }
        }

        static void EnterGame(ref Player player)
        { 
            while(true) 
            {
                Console.WriteLine("게임에 접속했습니다.");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string userInput = Console.ReadLine();
                if (userInput == "1")
                { 
                    EnterField(ref player);
                }

                else if (userInput == "2") 
                {
                    break;
                }
            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                 
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은체력{player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    
                    Console.WriteLine($"체력이 {player.hp} 남았습니다.");

                    Console.Write($"남은체력이 ");
                    Console.Write(player.hp = 0);
                    Console.WriteLine("이 되었습니다.");
                    Console.WriteLine();
                    Console.WriteLine("패배했습니다.");

                    break;
                }


            }
        }
        static void Main(string[] args)
        {

            while (true) 
            {
                ClassType choice = ChooseClass();

                if (choice != ClassType.None)
                {
                    
                    CreatePlayer(choice, out Player player);
                    Console.WriteLine($"HP{player.hp} ATTACK{player.attack}");

                    EnterGame(ref player); 
                    
                }
            }

            
            
            



        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameCore.Constants;

namespace GameCore
{
    public class Duel
    {
        static Hero GetHero(int Hero_ID)
        {
            Hero Hero1 = default;
            switch (Hero_ID)
            {
                case 0:
                    Hero1 = new Kensei((NamesID)Hero_ID);
                    break;
                case 1:
                    Hero1 = new Raider((NamesID)Hero_ID);
                    break;
                case 2:
                    Hero1 = new Tiandi((NamesID)Hero_ID);
                    break;
                case 3:
                    Hero1 = new Warden((NamesID)Hero_ID);
                    break;
                case 4:
                    Hero1 = new Berserker((NamesID)Hero_ID);
                    break;
                case 5:
                    Hero1 = new Gladiator((NamesID)Hero_ID);
                    break;
                case 6:
                    Hero1 = new Orochi((NamesID)Hero_ID);
                    break;
                case 7:
                    Hero1 = new Conqueror((NamesID)Hero_ID);
                    break;
                case 8:
                    Hero1 = new Conqueror((NamesID)Hero_ID);
                    break;
                case 9:
                    Hero1 = new Hitokiri((NamesID)Hero_ID);
                    break;
                case 10:
                    Hero1 = new Jormungandr((NamesID)Hero_ID);
                    break;
                case 11:
                    Hero1 = new Warlord((NamesID)Hero_ID);
                    break;
                case 12:
                    Hero1 = new Aramusha((NamesID)Hero_ID);
                    break;
                case 13:
                    Hero1 = new Centurion((NamesID)Hero_ID);
                    break;
                case 14:
                    Hero1 = new Highlander((NamesID)Hero_ID);
                    break;
                case 15:
                    Hero1 = new Valkyrie((NamesID)Hero_ID);
                    break;
            }
            return Hero1;
        }

        static Hero Hero1;
        static Hero Hero2;

        static GameType gameType;

        static int AI(Hero current_Hero, Hero opponent_Hero)
        {
            Random ran = new Random();

            if (opponent_Hero.HealthPoints <= current_Hero.DamagePoints ||
                current_Hero.HealthPoints == current_Hero.MaxHealthPoints)
                return 1;
            else if (opponent_Hero.HealthPoints <= 2 * current_Hero.DamagePoints &&
                current_Hero.HealthPoints > opponent_Hero.DamagePoints)
                return 1;
            else if (current_Hero.HealthPoints <= opponent_Hero.DamagePoints &&
                current_Hero.HealthPoints + Healing_Amount > opponent_Hero.DamagePoints)
                return 2;
            else
                return ran.Next(1, 2);
        }
        public Duel() 
        {
            gameType = GameType.EvE;

            Random ran = new Random();
            int First_Hero_ID = ran.Next(Constants.Names.Length - 1);
            int Second_Hero_ID = ran.Next(Constants.Names.Length - 1);

            Hero1 = GetHero(First_Hero_ID);
            Hero2 = GetHero(Second_Hero_ID);
        }
        public Duel(int First_Hero_ID)
        {
            gameType = GameType.PvE;

            Random ran = new Random();
            int Second_Hero_ID = ran.Next(Constants.Names.Length - 1);

            Hero1 = GetHero(First_Hero_ID);
            Hero2 = GetHero(Second_Hero_ID);

        }
        public Duel(int First_Hero_ID, int Second_Hero_ID)
        {
            gameType = GameType.PvP;

            Hero1 = GetHero(First_Hero_ID);
            Hero2 = GetHero(Second_Hero_ID);
        }

        public static int ReadKey()
        {
            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    //case ConsoleKey.D3:
                    //case ConsoleKey.D4:
                        return (int)cur_key - 48;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Menus.Footer();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return -1;
        }

        public static void Dueling()
        {
            Hero current_Hero;
            Hero opponent_Hero;
            int i = 0;

            if (gameType == GameType.PvP)
            {
                while (Hero1.isAlive && Hero2.isAlive)
                {
                    Menus.DisplayStatus(Hero1, Hero2, i);

                    if (i == 0)
                    {
                        current_Hero = Hero1;
                        opponent_Hero = Hero2;
                    }
                    else
                    {
                        current_Hero = Hero2;
                        opponent_Hero = Hero1;
                    }

                    switch (ReadKey())
                    {
                        case 1:
                            opponent_Hero.GetDamage(current_Hero.DamagePoints);
                            current_Hero.EquatePrevHealthPoints();
                            break;
                        case 2:
                            current_Hero.GetHealth();
                            opponent_Hero.EquatePrevHealthPoints();
                            break;
                        case -1:
                            current_Hero.EquatePrevHealthPoints();
                            opponent_Hero.EquatePrevHealthPoints();
                            Menus.Duel_End_Screen(Hero1, Hero2);
                            return;
                    }
                    i = i == 0 ? 1 : 0;
                    Menus.DisplayStatus(Hero1, Hero2, i);
                }
            }
            else if (gameType == GameType.PvE)
            {
                while (Hero1.isAlive && Hero2.isAlive)
                {
                    Menus.DisplayStatus(Hero1, Hero2, i);
                    if (i == 0)
                    {
                        current_Hero = Hero1;
                        opponent_Hero = Hero2;
                    }
                    else
                    {
                        current_Hero = Hero2;
                        opponent_Hero = Hero1;
                    }
                    if (i == 0)
                    {
                        switch (ReadKey())
                        {
                            case 1:
                                opponent_Hero.GetDamage(current_Hero.DamagePoints);
                                current_Hero.EquatePrevHealthPoints();
                                break;
                            case 2:
                                current_Hero.GetHealth();
                                opponent_Hero.EquatePrevHealthPoints();
                                break;
                            case -1:
                                current_Hero.EquatePrevHealthPoints();
                                opponent_Hero.EquatePrevHealthPoints();
                                Menus.Duel_End_Screen(Hero1, Hero2);
                                Console.ReadKey();
                                return;
                        }
                    }
                    else
                    {
                        Menus.PressAnyButton();
                        switch (AI(current_Hero,opponent_Hero))
                        {
                            case 1:
                                opponent_Hero.GetDamage(current_Hero.DamagePoints);
                                current_Hero.EquatePrevHealthPoints();
                                
                                break;
                            case 2:
                                current_Hero.GetHealth();
                                opponent_Hero.EquatePrevHealthPoints();
                                break;
                        }
                    }
                    i = i == 0 ? 1 : 0;
                }
            }
            else if (gameType == GameType.EvE)
            {
                while (Hero1.isAlive && Hero2.isAlive)
                {
                    Menus.DisplayStatus(Hero1, Hero2, i);

                    Menus.PressAnyButton();
                    
                    if (i == 0)
                    {
                        current_Hero = Hero1;
                        opponent_Hero = Hero2;
                    }
                    else
                    {
                        current_Hero = Hero2;
                        opponent_Hero = Hero1;
                    }

                    switch (AI(current_Hero, opponent_Hero))
                    {
                        case 1:
                            opponent_Hero.GetDamage(current_Hero.DamagePoints);
                            current_Hero.EquatePrevHealthPoints();
                            break;
                        case 2:
                            current_Hero.GetHealth();
                            opponent_Hero.EquatePrevHealthPoints();
                            break;
                    }

                    i = i == 0 ? 1 : 0;
                }

            }
            Menus.Duel_End_Screen(Hero1, Hero2);
        }
    }
    public class GameModes
    {

        public static MenuLevel PvP_Duel()
        {
            int[] PickedHeroes = new int[2];

            ConsoleKey key;
            for (int i = 0; i < 2; i++)
            {
                do{
                    key = Menus.ClassesDescriptions();
                    if (key != ConsoleKey.Escape)
                    {
                        if ((PickedHeroes[i] = Menus.HeroesPick(key)) != -1)
                            break;
                    }
                    else
                    {
                        return MenuLevel.GameType;
                    }
                } while(true);
            }
            Duel Duel = new Duel(PickedHeroes[0], PickedHeroes[1]);
            Duel.Dueling();

            return MenuLevel.GameType;
        }


        public static MenuLevel PvE_Duel()
        {
            int PickedHeroes;

            ConsoleKey key;

            do
            {
                key = Menus.ClassesDescriptions();
                if (key != ConsoleKey.Escape)
                {
                    if ((PickedHeroes = Menus.HeroesPick(key)) != -1)
                        break;
                }
                else
                {
                    return MenuLevel.GameType;
                }
            } while (true);

            Duel Duel = new Duel(PickedHeroes);
            Duel.Dueling();

            return MenuLevel.GameType;
        }

        public static MenuLevel EvE_Duel()
        {

            Duel Duel = new Duel();
            Duel.Dueling();

            return MenuLevel.GameType;
        }



        //public static void PvE_Brawl()
        //{

        //}
    }
}

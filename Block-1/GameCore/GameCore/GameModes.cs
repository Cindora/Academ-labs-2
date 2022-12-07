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

            switch (First_Hero_ID / 4)
            {
                case 0:
                    Hero1 = new Vanguard((NamesID)First_Hero_ID);
                    break;
                case 1:
                    Hero1 = new Assassin((NamesID)First_Hero_ID);
                    break;
                case 2:
                    Hero1 = new Heavy((NamesID)First_Hero_ID);
                    break;
                case 3:
                    Hero1 = new Hybrid((NamesID)First_Hero_ID);
                    break;
            }
            switch (Second_Hero_ID / 4)
            {
                case 0:
                    Hero2 = new Vanguard((NamesID)Second_Hero_ID);
                    break;
                case 1:
                    Hero2 = new Assassin((NamesID)Second_Hero_ID);
                    break;
                case 2:
                    Hero2 = new Heavy((NamesID)Second_Hero_ID);
                    break;
                case 3:
                    Hero2 = new Hybrid((NamesID)Second_Hero_ID);
                    break;
            }
        }
        public Duel(int First_Hero_ID)
        {
            gameType = GameType.PvE;

            Random ran = new Random();
            int Second_Hero_ID = ran.Next(Constants.Names.Length - 1);

            switch (First_Hero_ID / 4)
            {
                case 0:
                    Hero1 = new Vanguard((NamesID)First_Hero_ID);
                    break;
                case 1:
                    Hero1 = new Assassin((NamesID)First_Hero_ID);
                    break;
                case 2:
                    Hero1 = new Heavy((NamesID)First_Hero_ID);
                    break;
                case 3:
                    Hero1 = new Hybrid((NamesID)First_Hero_ID);
                    break;
            }
            switch (Second_Hero_ID / 4)
            {
                case 0:
                    Hero2 = new Vanguard((NamesID)Second_Hero_ID);
                    break;
                case 1:
                    Hero2 = new Assassin((NamesID)Second_Hero_ID);
                    break;
                case 2:
                    Hero2 = new Heavy((NamesID)Second_Hero_ID);
                    break;
                case 3:
                    Hero2 = new Hybrid((NamesID)Second_Hero_ID);
                    break;
            }

        }
        public Duel(int First_Hero_ID, int Second_Hero_ID)
        {
            gameType = GameType.PvP;

            switch (First_Hero_ID/4)
            {
                case 0:
                    Hero1 = new Vanguard((NamesID)First_Hero_ID);
                    break;
                case 1:
                    Hero1 = new Assassin((NamesID)First_Hero_ID);
                    break;
                case 2:
                    Hero1 = new Heavy((NamesID)First_Hero_ID);
                    break;
                case 3:
                    Hero1 = new Hybrid((NamesID)First_Hero_ID);
                    break;
            }
            switch (Second_Hero_ID / 4)
            {
                case 0:
                    Hero2 = new Vanguard((NamesID)Second_Hero_ID);
                    break;
                case 1:
                    Hero2 = new Assassin((NamesID)Second_Hero_ID);
                    break;
                case 2:
                    Hero2 = new Heavy((NamesID)Second_Hero_ID);
                    break;
                case 3:
                    Hero2 = new Hybrid((NamesID)Second_Hero_ID);
                    break;
            }
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

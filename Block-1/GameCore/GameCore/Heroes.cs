using System;
using static GameCore.Constants;

namespace GameCore
{
    public static class Constants
    {
        public enum NamesID
        {
            Kensei, Raider, Tiandi, Warden,
            Berserker, Gladiator, Orochi, Shinobi,
            Conqueror, Hitokiri, Jormungandr, Warlord,
            Aramusha, Centurion, Highlander, Valkyrie
        };
        public static string[] Names = { "Kensei", "Raider", "Tiandi", "Warden",
            "Berserker", "Gladiator", "Orochi", "Shinobi",
            "Conqueror", "Hitokiri", "Jormungandr", "Warlord",
            "Aramusha", "Centurion", "Highlander", "Valkyrie"};

        public enum ClassesID { Vanguard, Assassin, Heavy, Hybrid };
        public static string[] Classes = { "Авангард", "Ассассин", "Защитник", "Гибрид" };
        public enum _MaxHealthPoints : int { Vanguard = 100 + 25, Assassin = 100 - 15, Heavy = 100 + 45, Hybrid = 100 + 20 };
        public enum _DamagePoints : int { Vanguard = 20 + 20, Assassin = 20 + 30, Heavy = 20, Hybrid = 20 + 25 };
    }
    public abstract class Hero
    {
        public Constants.NamesID NameID;
        public Constants.ClassesID ClassID;
        public int MaxHealthPoints;
        public int HealthPoints;
        public int DamagePoints;
        public bool isAlive;

        public Hero()
        {
            isAlive = true;
        }

        public void GetDamage(int dmg)
        {
            HealthPoints -= dmg;
            if (HealthPoints <= 0)
                isAlive = false;
        }

        public void GetHealth(int hp)
        {
            HealthPoints += hp;
            if (HealthPoints > (int)MaxHealthPoints)
                HealthPoints = (int)MaxHealthPoints;
        }
    }

    public abstract class Vanguard : Hero
    {
        public Vanguard(NamesID NameID) : base()
        {
            this.NameID = NameID;
            ClassID = ClassesID.Vanguard;
            MaxHealthPoints = (int)_MaxHealthPoints.Vanguard;
            HealthPoints = MaxHealthPoints;
            DamagePoints = (int)_DamagePoints.Vanguard;
        }

        public static void description()
        {
            Console.WriteLine($"Боец авангарда. Имеет {(int)_MaxHealthPoints.Vanguard} очков здоровья, " +
                $"{(int)_DamagePoints.Vanguard} урона.\nДоступные герои: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}: {Constants.Names[i + 4 * (int)Constants.ClassesID.Vanguard]}.");
            }
        }
    }

    public abstract class Assassin : Hero
    {
        public Assassin(NamesID NameID) : base()
        {
            this.NameID = NameID;
            ClassID = ClassesID.Assassin;
            MaxHealthPoints = (int)_MaxHealthPoints.Assassin;
            HealthPoints = MaxHealthPoints;
            DamagePoints = (int)_DamagePoints.Assassin;
        }

        public static void description()
        {
            Console.WriteLine($"Боец-ассасин. Имеет {(int)_MaxHealthPoints.Assassin} очков здоровья, " +
                $"{(int)_DamagePoints.Assassin} урона.\nДоступные герои: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}: {Constants.Names[i + 4 * (int)Constants.ClassesID.Assassin]}.");
            }
        }
    }

    public abstract class Heavy : Hero
    {
        public Heavy(NamesID NameID) : base()
        {
            this.NameID = NameID;
            ClassID = ClassesID.Heavy;
            MaxHealthPoints = (int)_MaxHealthPoints.Heavy;
            HealthPoints = MaxHealthPoints;
            DamagePoints = (int)_DamagePoints.Heavy;
        }

        public static void description()
        {
            Console.WriteLine($"Боец-защитник. Имеет {(int)_MaxHealthPoints.Heavy} очков здоровья, " +
                $"{(int)_DamagePoints.Heavy} урона.\nДоступные герои: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i+1}: {Constants.Names[i + 4 * (int)Constants.ClassesID.Heavy]}.");
            }
        }
    }

    public abstract class Hybrid : Hero
    {
        public Hybrid(NamesID NameID) : base()
        {
            this.NameID = NameID;
            ClassID = ClassesID.Hybrid;
            MaxHealthPoints = (int)_MaxHealthPoints.Hybrid;
            HealthPoints = MaxHealthPoints;
            DamagePoints = (int)_DamagePoints.Hybrid;
        }

        public static void description()
        {
            Console.WriteLine($"Боец-гибрид. Имеет {(int)_MaxHealthPoints.Hybrid} очков здоровья, " +
                $"{(int)_DamagePoints.Hybrid} урона.\nДоступные герои: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i+1}: {Constants.Names[i + 4 * (int)Constants.ClassesID.Hybrid]}.");
            }
        }
    }
}
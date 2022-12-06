using System;
using static GameCore.Constants;

namespace GameCore
{
    public abstract class Hero
    {
        public Constants.NamesID NameID;
        public string Name;
        public Constants.ClassesID ClassID;
        public int MaxHealthPoints;
        public int HealthPoints;
        public int PrevHealthPoints;
        public int DamagePoints;
        public bool isAlive;

        public Hero()
        {
            isAlive = true;
        }

        public void EquatePrevHealthPoints()
        {
            PrevHealthPoints = HealthPoints;
        }

        public void GetDamage(int dmg)
        {
            PrevHealthPoints = HealthPoints;
            HealthPoints -= dmg;
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                isAlive = false;
            }
        }

        public void GetHealth(int hp)
        {
            PrevHealthPoints = HealthPoints;
            HealthPoints += hp;
            if (HealthPoints > (int)MaxHealthPoints)
                HealthPoints = (int)MaxHealthPoints;
        }
    }

    public class Vanguard : Hero
    {
        public Vanguard(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
            ClassID = ClassesID.Vanguard;
            MaxHealthPoints = (int)_MaxHealthPoints.Vanguard;
            HealthPoints = MaxHealthPoints;
            PrevHealthPoints = HealthPoints;
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

    public class Assassin : Hero
    {
        public Assassin(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
            ClassID = ClassesID.Assassin;
            MaxHealthPoints = (int)_MaxHealthPoints.Assassin;
            HealthPoints = MaxHealthPoints;
            PrevHealthPoints = HealthPoints;
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

    public class Heavy : Hero
    {
        public Heavy(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
            ClassID = ClassesID.Heavy;
            MaxHealthPoints = (int)_MaxHealthPoints.Heavy;
            HealthPoints = MaxHealthPoints;
            PrevHealthPoints = HealthPoints;
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

    public class Hybrid : Hero
    {
        public Hybrid(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
            ClassID = ClassesID.Hybrid;
            MaxHealthPoints = (int)_MaxHealthPoints.Hybrid;
            HealthPoints = MaxHealthPoints;
            PrevHealthPoints = HealthPoints;
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
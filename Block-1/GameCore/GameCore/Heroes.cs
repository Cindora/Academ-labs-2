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

        public void GetHealth()
        {
            PrevHealthPoints = HealthPoints;
            HealthPoints += Healing_Amount;
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
            string[] description = {$"Боец авангарда. Имеет {(int)_MaxHealthPoints.Vanguard} очков здоровья, " +
                $"{(int)_DamagePoints.Vanguard} урона.", "Доступные герои: "};

            Line_Number = 2;

            Console.SetCursorPosition(WindowWidth / 2 - description[0].Length / 2, Line_Number++);
            Console.Write(description[0]);
            Console.SetCursorPosition(WindowWidth / 2 - description[1].Length / 2, Line_Number);
            Console.Write(description[1]);

            Line_Number = 4;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 5, Line_Number++);
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
            string[] description = {$"Боец-ассасин. Имеет {(int)_MaxHealthPoints.Assassin} очков здоровья, " +
                $"{(int)_DamagePoints.Assassin} урона.", "Доступные герои: "};

            Line_Number = 2;

            Console.SetCursorPosition(WindowWidth / 2 - description[0].Length / 2, Line_Number++);
            Console.Write(description[0]);
            Console.SetCursorPosition(WindowWidth / 2 - description[1].Length / 2, Line_Number);
            Console.Write(description[1]);

            Line_Number = 4;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 7, Line_Number++);
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
            string[] description = {$"Боец-защитник. Имеет {(int)_MaxHealthPoints.Heavy} очков здоровья, " +
                $"{(int)_DamagePoints.Heavy} урона.", "Доступные герои: "};

            Line_Number = 2;

            Console.SetCursorPosition(WindowWidth / 2 - description[0].Length / 2, Line_Number++);
            Console.Write(description[0]);
            Console.SetCursorPosition(WindowWidth / 2 - description[1].Length / 2, Line_Number);
            Console.Write(description[1]);

            Line_Number = 4;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 7, Line_Number++);
                Console.WriteLine($"{i + 1}: {Constants.Names[i + 4 * (int)Constants.ClassesID.Heavy]}.");
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
            string[] description = {$"Боец-гибрид. Имеет {(int)_MaxHealthPoints.Hybrid} очков здоровья, " +
                $"{(int)_DamagePoints.Hybrid} урона.", "Доступные герои: "};

            Line_Number = 2;

            Console.SetCursorPosition(WindowWidth / 2 - description[0].Length / 2, Line_Number++);
            Console.Write(description[0]);
            Console.SetCursorPosition(WindowWidth / 2 - description[1].Length / 2, Line_Number);
            Console.Write(description[1]);

            Line_Number = 4;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - 7, Line_Number++);
                Console.WriteLine($"{i + 1}: {Constants.Names[i + 4 * (int)Constants.ClassesID.Hybrid]}.");
            }
        }
    }
}
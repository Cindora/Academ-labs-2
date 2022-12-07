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

    public abstract class Vanguard : Hero
    {
        public Vanguard() : base()
        {
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

    public class Kensei: Vanguard
    {
        public Kensei(NamesID NameID) : base()
        {
            this.NameID = NameID;
            Name = Constants.Names[(int)this.NameID];
        }
    }
    public class Raider : Vanguard
    {
        public Raider(NamesID NameID) : base()
        {
            this.NameID = NameID;
            Name = Constants.Names[(int)this.NameID];
        }
    }
    public class Tiandi : Vanguard
    {
        public Tiandi(NamesID NameID) : base()
        {
            this.NameID = NameID;
            Name = Constants.Names[(int)this.NameID];
        }
    }
    public class Warden : Vanguard
    {
        public Warden(NamesID NameID) : base()
        {
            this.NameID = NameID;
            Name = Constants.Names[(int)this.NameID];
        }
    }

    public abstract class Assassin : Hero
    {
        public Assassin() : base()
        {
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
    public class Berserker : Assassin
    {
        public Berserker(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Gladiator : Assassin
    {
        public Gladiator(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Orochi : Assassin
    {
        public Orochi(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Shinobi : Assassin
    {
        public Shinobi(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }

    public abstract class Heavy : Hero
    {
        public Heavy() : base()
        {
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
    public class Conqueror : Heavy
    {
        public Conqueror(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Hitokiri : Heavy
    {
        public Hitokiri(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Jormungandr : Heavy
    {
        public Jormungandr(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Warlord : Heavy
    {
        public Warlord(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }

    public abstract class Hybrid : Hero
    {
        public Hybrid() : base()
        {
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
    public class Aramusha : Hybrid
    {
        public Aramusha(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Centurion : Hybrid
    {
        public Centurion(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Highlander : Hybrid
    {
        public Highlander(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
    public class Valkyrie : Hybrid
    {
        public Valkyrie(NamesID NameID) : base()
        {
            this.NameID = NameID;
            this.Name = Constants.Names[(int)NameID];
        }
    }
}
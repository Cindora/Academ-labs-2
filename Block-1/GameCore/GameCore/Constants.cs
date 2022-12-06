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

        public enum GameType { PvP, PvE, EvE, NULL};

        public enum MenuLevel { NULL, GameType, ClassesDescriptions, HeroesPick };
    }
}

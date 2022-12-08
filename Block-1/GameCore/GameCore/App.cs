using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameCore.Constants;

namespace GameCore
{
    class App
    {
        static void Main(string[] args)
        {
            MenuLevel MenuLevel = MenuLevel.GameType;
            do
            {
                if (MenuLevel == MenuLevel.GameType)
                {
                    switch (Menus.GameType())
                    {
                        case GameType.PvP:
                            MenuLevel = GameModes.PvP_Duel();
                            break;
                        case GameType.PvE:
                            MenuLevel = GameModes.PvE_Duel();
                            break;
                        case GameType.EvE:
                            MenuLevel = GameModes.EvE_Duel();
                            break;
                        case GameType.NULL:
                            MenuLevel = MenuLevel.NULL;
                            break;
                    }
                }
            } while (MenuLevel != MenuLevel.NULL);
        }
    }
}

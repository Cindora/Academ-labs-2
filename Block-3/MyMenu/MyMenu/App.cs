using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static MyMenu.Constants;

namespace MyMenu
{
    class App
    {
        static void Main(string[] args)
        {
            MenuLevel MenuLevel = MenuLevel.GameType;
            var ProductList = new List<Product>();
            do
            {
                if (MenuLevel == MenuLevel.GameType)
                {
                    switch(Menus.MainMenu())
                    {
                        case MainMenuChoise.Products_View:
                            switch(Menus.ProductsMenu(ProductList))
                            {
                                case ProductsMenuChoise.AddProduct:
                                    var tmp = Menus.GetProductData();
                                    if (tmp!=null)
                                        ProductList.Add(tmp);

                                    break;
                                case ProductsMenuChoise.DelProduct:
                                    
                                    break;
                            }
                            
                            break;
                        case MainMenuChoise.Dishes_View:

                            break;
                        case MainMenuChoise.Fast_Day_Menu:

                            break;

                    }
                    
                }
            } while (MenuLevel != MenuLevel.NULL);
        }
    }
}

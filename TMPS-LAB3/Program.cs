using System;
using TMPS_LAB3.Factories;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            string name;
            string choice = "yes";
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine($"1) Creati o asigurare pentru {AsigType.Casa}");
            Console.WriteLine($"2) Creati o asigurare pentru {AsigType.Masina}");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: \n");

            switch (Console.ReadLine())
            {
                case "1":
                    ILevelFactory asigurationHouse = new Level1Factory();

                    Console.WriteLine("\nINTRODUCETI NUMELE COMPLET AL DUMNEAVOASTRA:");

                    name = Console.ReadLine();

                    IType type = asigurationHouse.CreateAsigurationType(name, 1, AsigType.Casa);
                    IProtection protection = asigurationHouse.CreateProtection("Protectia contra furturilor", AsigType.Casa);

                    type.Create();
                    protection.Apply();

                    Console.WriteLine("Doriti sa mai creati un utlizator cu acelasi tip asigurare? yes / no");
                    choice = Console.ReadLine();

                    if (choice.ToLower() == "yes")
                    {
                        Console.WriteLine("\nINTRODUCETI NUMELE COMPLET AL DUMNEAVOASTRA:");

                        name = Console.ReadLine();

                        var type2 = (IType)type.Clone();
                        type2 = asigurationHouse.CreateAsigurationType(name, 2, AsigType.Casa);
                        var protection2 = (IProtection)protection.Clone();
                        protection2 = asigurationHouse.CreateProtection("Protectia contra furturilor", AsigType.Casa);
                        type2.Create();
                        protection2.Apply();
                    }

                    //type.Create();
                    //protection.Apply();

                    Console.WriteLine("Doriti sa creati o alta asigurare ? yes / no \n");
                    choice = Console.ReadLine();

                    var returnChoice1 = Verify(choice);

                    return returnChoice1;

                case "2":
                    ILevelFactory asigurationCar = new Level2Factory();

                    Console.WriteLine("\nINTRODUCETI NUMELE COMPLET AL DUMNEAVOASTRA:");

                    name = Console.ReadLine();

                    IType typeCar = asigurationCar.CreateAsigurationType(name, 1, AsigType.Casa);
                    IProtection protectionCar = asigurationCar.CreateProtection("Protectia contra furturilor", AsigType.Casa);

                    typeCar.Create();
                    protectionCar.Apply();

                    Console.WriteLine("Doriti sa mai creati un utlizator cu acelasi tip asigurare? yes / no");
                    choice = Console.ReadLine();

                    if (choice.ToLower() == "yes")
                    {
                        Console.WriteLine("\nINTRODUCETI NUMELE COMPLET AL DUMNEAVOASTRA:");

                        name = Console.ReadLine();

                        var type2 = (IType)typeCar.Clone();
                        type2 = asigurationCar.CreateAsigurationType(name, 2, AsigType.Casa);
                        var protection2 = (IProtection)protectionCar.Clone();
                        protection2 = asigurationCar.CreateProtection("Protectie contra furturilor", AsigType.Casa);
                        type2.Create();
                        protection2.Apply();
                    }

                    Console.WriteLine("Doriti sa creati o alta asigurare ? yes / no \n");
                    choice = Console.ReadLine();

                    var returnChoice2 = Verify(choice);

                    return returnChoice2;

                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static bool Verify(string choice)
        {
            if (choice.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }

    }
}

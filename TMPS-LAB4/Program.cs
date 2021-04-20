using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPS_LAB4.Core;
using TMPS_LAB4.Data;

namespace TMPS_LAB4
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
            Console.Clear();
            Console.WriteLine("Alegeti optiunea:");
            Console.WriteLine("1) Vizualizati erarhia angajatilor");
            Console.WriteLine("2) Adaugati un nou angajat");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nOptiunea: \n");

            //Employee data
            #region
            EmployeeService Owner = new EmployeeService { EmployeId = 1, FirstName = "Raul", LastName = "Gonzales", Role = "Director general" };

            EmployeeService Manager1 = new EmployeeService { EmployeId = 2, FirstName = "Ferndado", LastName = "Torres", Role = "Departamentului de contabilitate" };
            EmployeeService Manager2 = new EmployeeService { EmployeId = 3, FirstName = "Mohamed", LastName = "Salah", Role = "Departamentului de productie" };
            Owner.AddSubordinate(Manager1);
            Owner.AddSubordinate(Manager2);

            EmployeeService Contabil1 = new EmployeeService { EmployeId = 4, FirstName = "Cristiano", LastName = "Ronaldo", Role = "Contabil" };
            EmployeeService Contabil2 = new EmployeeService { EmployeId = 5, FirstName = "Lionel", LastName = "Messi", Role = "Contabil" };
            Manager1.AddSubordinate(Contabil1);
            Manager1.AddSubordinate(Contabil2);

            EmployeeService ProductionManager1 = new EmployeeService { EmployeId = 6, FirstName = "Karim", LastName = "Benzema", Role = "Manager" };
            EmployeeService ProductionManager2 = new EmployeeService { EmployeId = 7, FirstName = "Steven", LastName = "Gerrard", Role = "Manager" };
            SimpleEmployee Casier = new SimpleEmployee { EmployeId = 8, FirstName = "Pepe", LastName = "Reina", Role = "Casier" };
            SimpleEmployee AsisClient = new SimpleEmployee { EmployeId = 9, FirstName = "Paul", LastName = "Dybala", Role = "Asistenta Client" };
            Manager2.AddSubordinate(ProductionManager1);
            Manager2.AddSubordinate(ProductionManager2);
            ProductionManager1.AddSubordinate(Casier);
            ProductionManager2.AddSubordinate(AsisClient);
            #endregion

            IEmployeeBuilder employe = new NewEmployeeBuilder();
            Director director = new Director();

            switch (Console.ReadLine())
            {
                #region
                case "1":
                    Console.Clear();
                    Console.WriteLine("Director general: {1} {2} | Role: {3}", Owner.EmployeId, Owner.FirstName, Owner.LastName, Owner.Role);

                    foreach (EmployeeService manager in Owner)
                    {
                        Console.WriteLine("\n\n\t{0}\n", manager.Role);
                        Console.WriteLine("\n\t SEF DEPARTAMENT: {1}  {2} | Role: Director al {3}", manager.EmployeId,
                            manager.FirstName, manager.LastName, manager.Role);

                        foreach (EmployeeService employee in manager)
                        {
                            Console.WriteLine(" \t\t ID Angajat: {0} | First Name: {1} | Last Name: {2} | Role: {3}", employee.EmployeId, employee.FirstName,
                                employee.LastName, employee.Role);

                            foreach (var simpleEmployee in employee)
                            {
                                Console.WriteLine("\t\t\t ID Angajat: {0} | First Name: {1} | Last Name: {2} | Role: {3}\n", simpleEmployee.EmployeId, simpleEmployee.FirstName,
                                    simpleEmployee.LastName, simpleEmployee.Role);
                            }
                        }
                    }
                    Console.ReadKey();
                    return true;
                #endregion
                #region
                case "2":
                    IEmployed choices = new EmployeeService();
                    Console.Clear();
                    Console.WriteLine("\n Introduceti prenumele: ");
                    choices.FirstName = Console.ReadLine();
                    Console.WriteLine("\n Introduceti numele: ");
                    choices.LastName = Console.ReadLine();
                    Console.WriteLine("\n Introduceti rolul: ");
                    choices.Role = Console.ReadLine();
                    director.Construct(employe, 1111, choices.FirstName, choices.LastName, choices.Role);
                    EmployeeService newEmployee = employe.Build();

                    Console.WriteLine("\n In ce departament va activa noul angajat?");
                    Console.WriteLine("1) Departament contabilitate");
                    Console.WriteLine("2) Departament productie");
                    var choice = Console.ReadLine();

                    if(choice == "1")
                    {
                        Manager1.AddSubordinate(newEmployee);
                    }
                    if(choice == "2")
                    {
                        Manager2.AddSubordinate(newEmployee);
                    }
                    Console.ReadKey();

                    Console.WriteLine("Director general: {1} {2} | Role: {3}", Owner.EmployeId, Owner.FirstName, Owner.LastName, Owner.Role);

                    foreach (EmployeeService manager in Owner)
                    {
                        Console.WriteLine("\n\n\t{0}\n", manager.Role);
                        Console.WriteLine("\n\t SEF DEPARTAMENT: {1}  {2} | Role: Director al {3}", manager.EmployeId,
                            manager.FirstName, manager.LastName, manager.Role);

                        foreach (EmployeeService employee in manager)
                        {
                            Console.WriteLine(" \t\t ID Angajat: {0} | First Name: {1} | Last Name: {2} | Role: {3}", employee.EmployeId, employee.FirstName,
                                employee.LastName, employee.Role);

                            foreach (var simpleEmployee in employee)
                            {
                                Console.WriteLine("\t\t\t ID Angajat: {0} | First Name: {1} | Last Name: {2} | Role: {3}\n", simpleEmployee.EmployeId, simpleEmployee.FirstName,
                                    simpleEmployee.LastName, simpleEmployee.Role);
                            }
                        }
                    }
                    Console.ReadKey();
                    return true;

                default:
                    return false;
                    #endregion
            }
        }
    }
}

using System;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Infrastructure;
using EducationPortalADO.DAL.Views.Shared;

namespace EducationPortalADO.DAL.Views.Home
{
    public class AccountView
    {
        public static void Show(string msg = null)
        {
            string login;
            string password;

            Console.Clear();
            Header.Show();
            
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }

            Console.WriteLine("Create account.");
            Console.WriteLine(@"(1)Create
(3)Show accounts
(5)Exit");
            
            int.TryParse(Console.ReadLine(), out var option);

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Input your login: ");
                    login = Console.ReadLine();

                    Console.WriteLine("Input your password: ");
                    password = Console.ReadLine();

                    Provider.AccountService.Create(new Entities.Account
                    {
                        Login = login,
                        Password = PasswordHasher.HashPassword(password)
                    });
                    break;
                case 3:
                    foreach (var account in Provider.AccountService.GetTop(100))
                    {
                        Console.WriteLine($"{account.Id}, {account.Login}, {account.Password}, {(Roles)account.Role}");
                    }

                    Console.ReadLine();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }

            Console.Clear();

            Home.Show();
        }
    }
}

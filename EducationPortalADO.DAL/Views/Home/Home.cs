using System;
using EducationPortalADO.DAL.Views.Shared;

namespace EducationPortalADO.DAL.Views.Home
{
    public static class Home
    {
        public static void Show(string msg = null)
        {
            Console.Clear();
            Header.Show();
            
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }
            
            AccountView.Show(msg);
        }
    }
}

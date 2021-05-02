using System;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.User
{
    class Registration
    {
        public string CurrentName { get; set; }
        public string CurrentPass { get; set; }
        public string CurrentMail { get; set; }
        public void NewUser()
        {
            Console.WriteLine("");
            CurrentName = Console.ReadLine();
            Console.WriteLine("");
            CurrentPass = Console.ReadLine();
            bool goodMail = true;
            while (goodMail)
            {
                Console.WriteLine("Введите email для связи");
                CurrentMail = Console.ReadLine();
                if (CurrentMail == null) Console.WriteLine("Введите email");
                char[] arr = CurrentMail.ToCharArray();
                foreach (char item in arr)
                {
                    if (item == '@') goodMail = false;
                    else Console.WriteLine("Введен некоректрный email!");
                }
            }
            Console.WriteLine("");
            CurrentPass = Console.ReadLine();
        }
        //public static void UserName()
        //{
        //    Dictionary<string, string> users = new Dictionary<string, string>();
        //    string currentName;
        //    string currentPass;
        //    currentName = Console.ReadLine();
        //    currentPass = Console.ReadLine();
        //    if (users.Keys.Contains(currentName))
        //    {
        //        Console.WriteLine("Извините, но данное имя занято, выберите другое.");
        //    }
        //    else users.Add(currentName, currentPass);
        //}
    }
}

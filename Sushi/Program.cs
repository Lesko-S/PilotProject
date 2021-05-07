using Sushi.BL.Sushi;
using System;

namespace Sushi
{
    class Program
    {
        public string EMail { get; set; }
        static void Main(string[] args)
        {
            #region Greating
            var time = DateTime.Now.TimeOfDay.Hours;
            int hours = Convert.ToInt32(time);
            Sushi.BL.Greating hello = new BL.Greating();
            hello.GoodPartOfDay(hours);
            #endregion
            #region Registration
            Console.WriteLine("Выберите действие: \n " +
                "1. Загегистрироваться \n " +
                "2. Войти \n " +
                "3. Продолжить без регистрации \n " +
                "0. Выход");
            Sushi.User.Registration newUser = new User.Registration();
            string choice = Console.ReadLine();
            int choiceInt = Convert.ToInt32(choice);
            Byer_sRights byer_SRights = new Byer_sRights();
            switch (choiceInt)
            {
                case 1:
                    newUser.NewUserRegistration();
                    break;
                case 2:
                    newUser.JoinAccaunt();
                    break;
                case 3:
                    byer_SRights.Logic();
                    break;
                default:
                    break;
            }
            #endregion
        }
    }
}

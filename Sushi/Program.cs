using System;

namespace Sushi
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Greating
            var time = DateTime.Now.TimeOfDay.Hours;
            int hours = Convert.ToInt32(time);
            Sushi.BL.Greating hello = new BL.Greating();
            hello.GoodPartOfDay(hours);
            #endregion
            #region Registration
            Console.WriteLine("У вас уже имеется аккаунт или желаете зарегистрироваться?");
            Sushi.User.Registration newUser = new User.Registration();
            newUser.NewUserRegistration();
            
            #endregion
        }
    }
}

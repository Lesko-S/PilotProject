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
            Console.WriteLine("У вас уже имеется аккаунт или желаете зарегистрироваться?");
            #region Registration
            Sushi.User.Registration registration = new User.Registration();
            
            #endregion
        }
    }
}

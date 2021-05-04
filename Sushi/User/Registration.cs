using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sushi.User
{
    class Registration
    {
        private static List<RegistrationProp> _users = new List<RegistrationProp>();
        public string CheckCurrentName(string userName, string userPass, ref string email)
        {
            using (StreamReader file = File.OpenText(@"D:\C#\Project\Sushi\User\users.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<RegistrationProp> registrationProp2 = (List<RegistrationProp>)serializer
                    .Deserialize(file, typeof(List<RegistrationProp>));
                var checkName =
                    from n in registrationProp2
                    where n.CurrentName.Contains(userName)
                    where n.CurrentPass.Contains(userPass)
                    select n.CurrentMail;
                var result = registrationProp2.FirstOrDefault();
                email = result.CurrentMail;
                return email;
            }
        }
        public List<RegistrationProp> Create(RegistrationProp registration)
        {
            _users.Add(registration);
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(@"D:\C#\Project\Sushi\User\users.json"))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                jsonSerializer.Serialize(writer, _users);
            }
            return _users;
        }
        public void NewUserRegistration()
        {
            bool goodName = true;
            RegistrationProp registration = new RegistrationProp();
            while (goodName == true)
            {
                string resultChecName = null;
                Console.WriteLine("Введите логин:");
                registration.CurrentName = Console.ReadLine();
                if (resultChecName == null)
                {
                    using (StreamReader file = File.OpenText(@"D:\C#\Project\Sushi\User\users.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<RegistrationProp> registrationProp = (List<RegistrationProp>)serializer
                            .Deserialize(file, typeof(List<RegistrationProp>));
                        var checkName =
                            from n in registrationProp
                            where n.CurrentName.Contains(registration.CurrentName)
                            select n.CurrentName;
                        var result = registrationProp.FirstOrDefault();
                        resultChecName = result.CurrentName.ToString();
                    }
                }
            }
            Console.WriteLine("Введите пароль:");
            registration.CurrentPass = Console.ReadLine();
            bool goodMail = true;
            while (goodMail)
            {
                Console.WriteLine("Введите email для связи");
                registration.CurrentMail = Console.ReadLine();
                if (registration.CurrentMail == null) Console.WriteLine("Введите email");
                if (registration.CurrentMail.Contains('@')) goodMail = false;
                else Console.WriteLine("Введен некоректрный email!");
            }
            Console.WriteLine("");
            Create(registration);
            Console.WriteLine("Аккаунт успешно зарегестрирован.");
            JoinAccaunt();
        }
        public void JoinAccaunt()
        {
            string email = null;
            while (email == null)
            {
                Console.WriteLine("Введите логин:");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                string pass = Console.ReadLine();
                CheckCurrentName(login, pass, ref email);
                if (email == null)
                {
                    Console.WriteLine("Вы ввдели неверные данные!");
                }
            }
            Program program = new Program();
            program.EMail = email;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sushi.User
{
    class Registration
    {
        private static List<RegistrationProp> _users = new List<RegistrationProp>();
        public string CheckCurrentName(string userName)
        {
            JsonSerializer dez = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(@"D:\C#\Project\Sushi\User\users.json"))
            using (JsonReader reader = new JsonTextReader(streamReader))
            {
                RegistrationProp reg = dez.Deserialize<RegistrationProp>(reader);
                dez.Deserialize<RegistrationProp>(reader);
                if (reg.CurrentName == userName) return reg.CurrentName;
                else return userName;
            }
        }
        public string CheckCurrenPass(string userName, string userPass)
        {
            JsonSerializer dez = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(@"D:\C#\Project\Sushi\User\users.json"))
            using (JsonReader reader = new JsonTextReader(streamReader))
            {
                RegistrationProp reg = dez.Deserialize<RegistrationProp>(reader);
                dez.Deserialize<RegistrationProp>(reader);
                if (reg.CurrentName == userName)
                {
                    if (reg.CurrentPass == userPass) return reg.CurrentPass;
                    else return null;
                }
                return userName;
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
            RegistrationProp registration = new RegistrationProp();
            Console.WriteLine("Введите логин:");
            registration.CurrentName = Console.ReadLine();
            // Добавить логику на пароль
            Console.WriteLine("Введите пароль:");
            registration.CurrentPass = Console.ReadLine();
            bool goodMail = true;
            while (goodMail)
            {
                Console.WriteLine("Введите email для связи");
                registration.CurrentMail = Console.ReadLine();
                if (registration.CurrentMail == null) Console.WriteLine("Введите email");
                char[] arr = registration.CurrentMail.ToCharArray();
                foreach (char item in arr)
                {
                    if (item == '@') goodMail = false;
                    //   else Console.WriteLine("Введен некоректрный email!");
                }
            }
            Console.WriteLine("");
            Create(registration);
            Console.WriteLine("Аккаунт успешно зарегестрирован.");
            JoinAccaunt();
        }
        public void JoinAccaunt()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            string pass = null;
            CheckCurrentName(login);
            RegistrationProp registrationProp = new RegistrationProp();
            if (login == registrationProp.CurrentName)
            {
                Console.WriteLine("Введите пароль:");
                while (pass == null)
                {
                    pass = Console.ReadLine();
                    CheckCurrenPass(login, pass);
                }
            }
        }
    }
}

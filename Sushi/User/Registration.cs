using Newtonsoft.Json;
using Sushi.BL.Sushi;
using Sushi.Extention;
using Sushi.Property;
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
            using (StreamReader file = File.OpenText(Constant.WayToUser))
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
            _users.Clear();
            _users.Add(registration);
            using (StreamReader file = File.OpenText(Constant.WayToUser))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<RegistrationProp> rP2 = (List<RegistrationProp>)serializer
                    .Deserialize(file, typeof(List<RegistrationProp>));
                _users.AddRange(rP2);
            }
            using (StreamWriter file = File.CreateText(Constant.WayToUser))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _users);
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
                    using (StreamReader file = File.OpenText(Constant.WayToUser))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<RegistrationProp> registrationProp = (List<RegistrationProp>)serializer
                            .Deserialize(file, typeof(List<RegistrationProp>));
                        var result = registrationProp.FirstOrDefault(n => n.CurrentName == registration.CurrentName);
                        if (result.CurrentName != registration.CurrentName)
                            resultChecName = result.CurrentName.ToString();
                        else Console.WriteLine("К сожалению данный логин занят. Придумайте другой!");
                    }
                }
                if (resultChecName != null) goodName = false;
            }
            Console.WriteLine("Введите пароль:");
            registration.CurrentPass = Console.ReadLine();
            bool goodMail = true;
            while (goodMail)
            {
                Console.WriteLine("Введите email для связи");
                registration.CurrentMail = Console.ReadLine();
                if (registration.CurrentMail == null) Console.WriteLine("Введите email");
                if (registration.CurrentMail.CharCount('@') == 1) goodMail = false;
                else Console.WriteLine("Введен некоректрный email!");
            }
            Console.WriteLine("");
            Create(registration);
            Console.WriteLine("Аккаунт успешно зарегестрирован.");
            JoinAccaunt();
        }
        public void JoinAccaunt()
        {
            string login = null;
            string loginInJson = null;
            string email = null;
            string pass = null;
            while (email == null)
            {
                if (loginInJson == null)
                {
                    Console.WriteLine("Введите логин:");
                    login = Console.ReadLine();
                    using (StreamReader file = File.OpenText(Constant.WayToUser))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<RegistrationProp> registrationProp = (List<RegistrationProp>)serializer
                            .Deserialize(file, typeof(List<RegistrationProp>));
                        var checkName =
                            from n in registrationProp
                            where n.CurrentName.Contains(login)
                            select n.CurrentName;
                        var result = registrationProp.FirstOrDefault();
                        loginInJson = result.CurrentName.ToString();
                    }
                }
                else
                {
                    Console.WriteLine("Введите пароль:");
                    pass = Console.ReadLine();
                    CheckCurrentName(login, pass, ref email);
                    if (email == null)
                    {
                        Console.WriteLine("Вы ввдели неверные данные!");
                    }
                }
            }
            Program program = new Program();
            program.EMail = email;
            AdminRoot adminRights = new AdminRoot();
            Byer_sRights byer_SRights = new Byer_sRights();
            if (login == "admin" && pass == "admin") adminRights.Logic();
            else byer_SRights.Logic();
        }
    }
}

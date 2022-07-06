namespace Order
{
    abstract class Person
    {
        protected string FirstName;
        protected string SecondName;
        protected string phoneNumber;
        protected abstract string PhoneNumber { get; set; }
        
       
        public Person(string name, string surname, string number)
        {
            FirstName = name;
            SecondName = surname;
            PhoneNumber = number;
        }

        public virtual void Info()
        {
            Console.WriteLine($"Имя:\t\t\t{FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия:\t\t{SecondName ?? "Нет данных"}");
        }
    }

    class Client : Person
    {
        protected string LastName;
        private string age;
        protected string Age 
        {
            get { return age; } 
            set
            {
                bool conv = int.TryParse(value, out int result);
                if (conv)
                {
                    if (result < 18)
                    {
                        Console.WriteLine($"Заказчик {SecondName ?? "(Фамилия не указана)"} {FirstName ?? "(Имя не указано)"}\nВозраст заказчика менее 18\n");
                        age = value;
                    }
                    else
                        age = value;
                }
                else
                    Console.WriteLine($"Заказчик {SecondName ?? "(Фамилия не указана)"} {FirstName ?? "(Имя не указано)"}\nНекоректное значение возраста\n");
                
            }
        }

        protected override string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                bool conv = uint.TryParse(value, out uint result);
                if (!conv)
                    Console.WriteLine($"Заказчик {SecondName ?? "(Фамилия не указана)"} {FirstName ?? "(Имя не указано)"}\nНекорректный ввод номера телефона\n");
                else
                    phoneNumber = value;
            }
        }

        public Client(string name, string surname, string lastname, string age, string number) : base (name, surname, number) 
        {
            LastName = lastname;
            Age = age;
        }

        public override void Info()
        {
            Console.WriteLine("------------------------------Информация о заказчике-------------------------------");
            base.Info();
            Console.WriteLine($"Отчество:\t\t{LastName ?? "Нет данных"}");
            Console.WriteLine($"Возраст:\t\t{Age ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона:\t\t{PhoneNumber ?? "Нет данных"}");
        }

        public string GetFullName()
        {
            return FirstName?.Initial() + LastName?.Initial() + " " + (SecondName ?? "Фамилия не указана");
        }
    }
    class Staff : Person 
    {
        protected override string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                bool conv = uint.TryParse(value, out uint result);
                if (!conv)
                    Console.WriteLine($"Персонал {SecondName ?? "(Фамилия не указана)"} {FirstName ?? "(Имя не указано)"}\nНекорректный ввод номера телефона\n");
                else
                    phoneNumber = value;
            }
        }
        public Staff(string name, string surname, string number) : base(name, surname, number) { }

        public override void Info()
        {
            Console.WriteLine("------------------------------Информация о курьере---------------------------------");
            base.Info();
            Console.WriteLine($"Номер телефона:\t\t{PhoneNumber ?? "Нет данных"}");
        }
    }
}

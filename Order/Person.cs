namespace Person
{
    abstract class Person
    {
        protected string FirstName { get; set; }
        protected string SecondName { get; set; }
        protected string LastName { get; set; }
        protected string Age { get; set; }
        protected string PhoneNumber { get; set; }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Имя:\t\t\t{FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия:\t\t{SecondName ?? "Нет данных"}");
            Console.WriteLine($"Отчество:\t\t{LastName ?? "Нет данных"}");
            Console.WriteLine($"Возраст:\t\t{Age ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона:\t\t{PhoneNumber ?? "Нет данных"}");
        }

        public Person(string name, string surname, string lastname, string age, string number)
        {
            FirstName = name;
            SecondName = surname;
            LastName = lastname;
            Age = age;
            PhoneNumber = number;
        }
    }

    class Client : Person
    {
        public Client(string name, string surname, string lastname, string age, string number) : base (name, surname, lastname, age, number) { }
        public override void GetInfo()
        {
            Console.WriteLine("------------------------------Информация о заказчике------------------------------");
            base.GetInfo();
        }
    }
    class Staff : Person 
    {
        public Staff(string name, string surname, string lastname, string age, string number) : base(name, surname, lastname, age, number) { }

        public override void GetInfo()
        {
            Console.WriteLine("------------------------------Информация о курьере---------------------------------");
            base.GetInfo();
        }
    }
}

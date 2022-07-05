namespace Order
{
    abstract class Person
    {
        protected string FirstName;
        protected string SecondName;
        protected string PhoneNumber;
       
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
        protected string Age;
        protected string LastName;

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
    }
    class Staff : Person 
    {
        public Staff(string name, string surname, string number) : base(name, surname, number) { }

        public override void Info()
        {
            Console.WriteLine("------------------------------Информация о курьере---------------------------------");
            base.Info();
            Console.WriteLine($"Номер телефона:\t\t{PhoneNumber ?? "Нет данных"}");
        }
    }
}

namespace Person
{
    abstract class Person
    {
        protected string FirstName { get; set; }
        protected string SecondName { get; set; }
        protected string LastName { get; set; }
        protected string Age { get; set; }
        protected string PhoneNumber { get; set; }

        protected internal abstract void GetInfo();
    }

    class Client : Person
    {
        protected internal override void GetInfo()
        {
            Console.WriteLine("------------------------------Информация о заказчике------------------------------");
            Console.WriteLine($"Имя:\t\t\t{FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия:\t\t{SecondName ?? "Нет данных"}");
            Console.WriteLine($"Отчество:\t\t{LastName ?? "Нет данных"}");
            Console.WriteLine($"Возраст:\t\t{Age ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона:\t\t{PhoneNumber ?? "Нет данных"}");
        }
    }
    class Staff : Person 
    {
        protected internal override void GetInfo()
        {
            Console.WriteLine("------------------------------Информация о курьере---------------------------------");
            Console.WriteLine($"Имя:\t\t\t{FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия:\t\t{SecondName ?? "Нет данных"}");
            Console.WriteLine($"Отчество:\t\t{LastName ?? "Нет данных"}");
            Console.WriteLine($"Возраст:\t\t{Age ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона:\t\t{PhoneNumber ?? "Нет данных"}");
        }
        public void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Курьерская служба------------------------------------");
            Console.WriteLine($"Название:\t\t\t{Company.Name}");
            Console.WriteLine($"Адрес:\t\t\t\t{Company.Address}");
            Console.WriteLine($"Телефон горячей линии:\t\t{Company.HotLinePhone}");
        }
    }
}

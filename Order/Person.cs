namespace Delivery
{
    using Company;

    abstract class Person
    {
        protected string FirstName { get; set; }
        protected string SecondName { get; set; }
        protected string LastName { get; set; }
        protected string Age { get; set; }
        protected string PhoneNumber { get; set; }

        public abstract void GetInfo();
    }

    class Client : Person
    {
        public override void GetInfo()
        {
            Console.WriteLine("-------Информация о заказчике-------");
            Console.WriteLine($"Имя: {FirstName??"Нет данных"}");
            Console.WriteLine($"Фамилия: {SecondName??"Нет данных"}");
            Console.WriteLine($"Отчество: {LastName??"Нет данных"}");
            Console.WriteLine($"Возраст: {Age??"Нет данных"}");
            Console.WriteLine($"Номер телефона: {PhoneNumber??"Нет данных"}");
        }
    }
    class Staff : Person 
    { 
        Company Company = new Company();

        public override void GetInfo()
        {
            Console.WriteLine("-------Информация о курьере-------");
            Console.WriteLine($"Имя: {FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия: {SecondName ?? "Нет данных"}");
            Console.WriteLine($"Отчество: {LastName ?? "Нет данных"}");
            Console.WriteLine($"Возраст: {Age ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона: {PhoneNumber ?? "Нет данных"}");
        }
        public void GetCompanyInfo()
        {
            Console.WriteLine("-------Курьерская служба-------");
            Console.WriteLine($"Название: {Company?.Name ?? "Нет данных"}");
            Console.WriteLine($"Адрес: {Company?.Address ?? "Нет данных"}");
            Console.WriteLine($"Телефон горячей линии: {Company?.HotLinePhone ?? "Нет данных"}");
        }
    }
}

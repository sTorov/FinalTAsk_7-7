namespace Order
{
    static class Company
    {
        internal static string Address;
        internal static string Name;
        internal static string HotLinePhone;

        static Company()
        {
            Name = "Delivery Clab";
            Address = "г. Москва, Невский проспект пр. д.14 к.4";
            HotLinePhone = "88005553535";
        }
    }

    static class PickPointContact
    {
        internal static string PhoneNumber;
        internal static string Email;

        static PickPointContact()
        {
            PhoneNumber = "111222333";
            Email = "PickPoint@gmail.com";
        }
    }

    static class Shop
    {
        internal static string Address;
        internal static string Email;
        internal static string PhoneNumber;

        static Shop()
        {
            Address = "Адрес магазина";
            Email = "Shop@Email.com";
            PhoneNumber = "555000123";
        }

    }
}

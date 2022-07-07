namespace Company
{
    static class DeliveryCompany
    {
        public static string Address;
        public static string Name;
        public static string HotLinePhone;

        static DeliveryCompany()
        {
            Name = "Delivery Clab";
            Address = "г. Москва, Невский проспект пр. д.14 к.4";
            HotLinePhone = "88005553535";
        }
    }

    static class PickPointContact
    {
        public static string PhoneNumber;
        public static string Email;

        static PickPointContact()
        {
            PhoneNumber = "111222333";
            Email = "PickPoint@gmail.com";
        }
    }

    static class Shop
    {
        public static string Address;
        public static string Email;
        public static string PhoneNumber;

        static Shop()
        {
            Address = "Адрес магазина";
            Email = "Shop@Email.com";
            PhoneNumber = "555000123";
        }

    }
}

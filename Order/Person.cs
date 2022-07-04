namespace Order
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }

       
        public Person(string name, string surname, string number)
        {
            FirstName = name;
            SecondName = surname;
            PhoneNumber = number;
        }
    }

    class Client : Person
    {
        public string Age { get; set; }
        public string LastName { get; set; }

        public Client(string name, string surname, string lastname, string age, string number) : base (name, surname, number) 
        {
            LastName = lastname;
            Age = age;
        }
    }
    class Staff : Person 
    {
        public Staff(string name, string surname, string number) : base(name, surname, number) { }
    }
}

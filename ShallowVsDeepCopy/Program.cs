using System;

namespace ShallowVsDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(15,"Henry","Ford");
            Console.WriteLine($"{p1.Description.LastName} is {p1.Age} year(s) old.");

            Person p2 = p1.DeepCopy();

            Person p3 = (Person)p1.ShallowCopy();
            p3.Age = 20;
            p3.Description.LastName = "Jack";

            

            Console.WriteLine($"P1: {p1.Description.LastName} is {p1.Age} year(s) old.");
            Console.WriteLine($"P2: {p2.Description.LastName} is {p2.Age} year(s) old.");
            Console.WriteLine($"P3: {p3.Description.LastName} is {p3.Age} year(s) old.");
            Console.ReadLine();
        }
    }
    public class Person
    {
        public int Age;
        public PersonDescription Description;

        public Person(int age, string firstName, string lastName)
        {
            this.Age = age;
            this.Description = new PersonDescription(firstName, lastName);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person deepCopyPerson = new Person(Age,Description.FirstName,Description.LastName);
            return deepCopyPerson;
        }
    }

    public class PersonDescription
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonDescription(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}

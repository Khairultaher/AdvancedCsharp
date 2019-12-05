using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQQueryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Data source
            //string[] names = { "Bill", "Steve", "James", "Mohan" };

            //// LINQ Query 
            //var query = from name in names
            //            where name.Contains("a")
            //            select name;


            //var query2 = names.Where(w => w.Contains("a"));

            //foreach (var item in query2)
            //{
            //    Console.WriteLine(item);
            //}

            // Student collection
            IList<Student> studentList = new List<Student>() 
            {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron"  }
            };

            IList<Standard> standardList = new List<Standard>() 
            {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            // LINQ Method Syntax to find out teenager students
            //var teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20);          
            //var data = teenAgerStudents.ToList<Student>();

            //Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;
            //var teenStudents = studentList.Where(isStudentTeenAger).ToList<Student>();

            //var groupedData = studentList.GroupBy(g => g.Age);
            //var groupedData = from p in studentList
            //                  group p by p.Age;

            //Query Syntax
            var innerJoinQ = from p in studentList
                            join q in standardList on p.StandardID equals q.StandardID
                            select new
                            {
                                StandardName = q.StandardName,
                                StudentName = p.StudentName
                            };

            //Method Syntax
            var innerJoinM = studentList.Join(// outer sequence 
                      standardList,  // inner sequence 
                      student => student.StudentID,    // outerKeySelector
                      standard => standard.StandardID,  // innerKeySelector
                      (student, standard) => new  // result selector
                      {
                          StandardName = standard.StandardName,
                          StudentName = student.StudentName
                      });

            //Query Syntax
            var groupJoinQ = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID
                            into studentGroup
                            select new
                            {
                                StandardName = std.StandardName,
                                Students = studentGroup,
                            };
            //Method Syntax
            var groupJoinM = standardList.GroupJoin(studentList,  //inner sequence
                                std => std.StandardID, //outerKeySelector 
                                s => s.StandardID,     //innerKeySelector
                                (std, studentsGroup) => new // resultSelector 
                                {
                                    StandarName = std.StandardName,
                                    Students = studentsGroup
                                });


            // Left Join Example
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };

            foreach (var v in query)
            {
                Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}");
            }

            Console.ReadLine();

        }
    }
}

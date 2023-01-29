using System;

namespace OverrideVsNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Child1();
            p.Hello();

            // override
            p = new Child2();
            p.Hello();

            // new
            p = new Child3();
            p.Hello();

            Child3 c = new Child3();
            c.Hello();


            //Child2 cc = new Child3(); // Compiletime Error: not possible
            Child2 cc = (Child2)new Parent(); // Runtime Error: Unable to cast object of type 'OverrideVsNew.Parent' to type 'OverrideVsNew.Child2'. 
            cc.Hello();

            Console.ReadLine();
        }
    }

    public class Parent
    {
        public virtual void Hello()
        {
            Console.WriteLine("Hello from the Parent");
        }
    }

    public class Child1 : Parent
    {
    }
    public class Child2 : Parent
    {
        public override void Hello()
        {
            Console.WriteLine("Hello from the Child2");
        }
    }
    public class Child3 : Parent
    {
        public new void Hello()
        {
            Console.WriteLine("Hello from the Child3");
        }
    }
}
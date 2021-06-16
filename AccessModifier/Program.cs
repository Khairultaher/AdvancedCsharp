using System;

namespace AccessModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            // ChildA childa = new Base("", ""); // Error: Can not implicitly convert type

            ChildA childa = new ChildA();
            // ChildB childb = childa; // Error: Can not implicitly convert type

            Console.ReadLine();
        }
    }

    public class Base
    {
        private string _t = string.Empty;

        public Base(string p1, string p2)
        {
            Prop1 = p1;
            Prop2 = p2;
        }

        public string Prop1 { get; set; }
        private string Prop2 { get; set; }
        public virtual string Prop3
        {
            get { return _t; }
            set
            {
                Console.WriteLine("I'm in base");
                _t = value;
            }
        }
        public virtual void Print()
        {
            Console.WriteLine(Prop1 + " " + Prop2);
        }
    }

    public class ChildA : Base
    {
        public  ChildA() : base("", "")
        {
        }

        public override string Prop3
        {
            get { return base.Prop3; }
            set
            {
                Console.WriteLine("I'm in derived");
                base.Prop3 = value;  // this assignment is invoking the base setter
            }
        }
        public override void Print()
        {
            Console.WriteLine(base.Prop1);
            //Console.WriteLine(base.Prop2); // Error: base.Prop2 is private
        }
        public static Base ChildofBase(Base papa)
        {
            ChildA r = new ChildA();
            r.Prop1 = papa.Prop1;
            //r.Prop2 = papa.Prop2; // Error: base.Prop2 is private
            return r;
        }
    }

    public class ChildB : Base
    {
        public ChildB() : base("", "")
        {
        }

        public override string Prop3
        {
            get { return base.Prop3; }
            set
            {
                Console.WriteLine("I'm in derived");
                base.Prop3 = value;  // this assignment is invoking the base setter
            }
        }
        public override void Print()
        {
            Console.WriteLine(base.Prop1);
            //Console.WriteLine(base.Prop2); // Error: base.Prop2 is private
        }
        public static Base ChildofBase(Base papa)
        {
            ChildB r = new ChildB();
            r.Prop1 = papa.Prop1;
            //r.Prop2 = papa.Prop2; // Error: base.Prop2 is private
            return r;
        }
    }
}

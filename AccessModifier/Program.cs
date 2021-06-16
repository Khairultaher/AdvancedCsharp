using System;

namespace AccessModifier
{
    // The default access for everything in C# is "the most restricted access you could declare for that member".
    // top level class: internal
    // method: private
    // members(unless an interface or enum): private (including nested classes)
    // members(of interface or enum): public
    // constructor: private (note that if no constructor is explicitly defined, a public default constructor will be automatically defined)
    // delegate: internal
    // interface: internal
    // explicitly implemented interface member : public!
    class Program
    {
        static void Main(string[] args)
        {
            // ChildA childa = new Base("", ""); // Error: Can not implicitly convert type

            ChildA childa = new ChildA();
            // ChildB childb = childa; // Error: Can not implicitly convert type
            //var res = childa.Prop4; // Error: Prop4 is protected

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
        public virtual string Prop2
        {
            get { return _t; }
            set
            {
                Console.WriteLine("I'm in base");
                _t = value;
            }
        }
        internal string Prop3 { get; set; }
        protected string Prop4 { get; set; }
        private string Prop5 { get; set; }

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

        public override string Prop2
        {
            get { return base.Prop3; }
            set
            {
                Console.WriteLine("I'm in derived");
                base.Prop2 = value;  // this assignment is invoking the base setter
            }
        }
        public override void Print()
        {
            // public
            Console.WriteLine(base.Prop1);
            // public
            Console.WriteLine(base.Prop2);
            // internal
            Console.WriteLine(base.Prop3);
            // protected
            Console.WriteLine(base.Prop4);
            // private
            //Console.WriteLine(base.Prop5); // Error: base.Prop5 is private
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

        public override string Prop2
        {
            get { return base.Prop3; }
            set
            {
                Console.WriteLine("I'm in derived");
                base.Prop2 = value;  // this assignment is invoking the base setter
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

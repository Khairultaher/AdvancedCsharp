using System;

namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number(100);
            number.PrintNumber();
            number.PrintMoney();

            Console.ReadLine();
        }
    }

    public class PrintHelper
    {
        // declare delegate
        public delegate void BeforePrint(string message);

        // declare event
        public event BeforePrint BeforePrintEvent;

        public PrintHelper()
        { 
        }

        public void PrintNumber(int num)
        {
            //call delegate method before going to print
            if (BeforePrintEvent != null)
                BeforePrintEvent("PrintNumber");
            Console.WriteLine("Number: {0,-12:N0}", num);
        }
        public void PrintDecimal(int dec)
        {
            if (BeforePrintEvent != null)
                BeforePrintEvent("PrintDecimal");
            Console.WriteLine("Decimal: {0:G}", dec);
        }
        public void PrintMoney(int money)
        {
            if (BeforePrintEvent != null)
                BeforePrintEvent("PrintMoney");
            Console.WriteLine("Money: {0:C}", money);
        }
        public void PrintTemperature(int num)
        {
            if (BeforePrintEvent != null)
                BeforePrintEvent("PrintMoney");
            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal(int dec)
        {
            if (BeforePrintEvent != null)
                BeforePrintEvent("PrintMoney");
            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }

    public class Number
    {
        private PrintHelper _printHelper;

        public Number(int val)
        {
            _value = val;

            _printHelper = new PrintHelper();
            //subscribe to beforePrintEvent event
            _printHelper.BeforePrintEvent += printHelper_beforePrintEvent;
        }
        //beforePrintevent handler
        void printHelper_beforePrintEvent(string message)
        {
            Console.WriteLine($"BeforPrintEventHandler: PrintHelper is going to print a value {message}");
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void PrintMoney()
        {
            _printHelper.PrintMoney(_value);
        }

        public void PrintNumber()
        {
            _printHelper.PrintNumber(_value);
        }
    }
}

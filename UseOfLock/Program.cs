using System;
using System.Threading;

namespace UseOfLock
{
    class Program
    {
        //static Maths maths = new Maths();
        static void Main(string[] args)
        {
            Maths maths = new Maths();
            Thread thread1 = new Thread(maths.Devide); // Child (1) thread within main thread
            thread1.Start();

            maths.Devide();

            Thread thread2 = new Thread(maths.Devide); // Child (2) thread within main thread
            thread1.Start();

            Console.ReadLine();
        }
    }

    class Maths
    {
        public int num1;
        public int num2;
        Random ran = new Random();
        public void Devide()
        {
            lock (this)
            {
                for (int i = 0; i < 100000; i++)
                {
                    try
                    {
                        num1 = ran.Next(1, 2);
                        num2 = ran.Next(1, 2);

                        int result = num1 / num2;

                        num1 = 0;
                        num2 = 0;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}

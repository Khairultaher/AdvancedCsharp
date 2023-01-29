using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStartTaskRunTaskFactoryStartNew
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("### Here three method call takes 4+3+3 sec ###");

            CustomerRepository repository = new CustomerRepository();

            #region Sync Call
            var start = DateTime.Now;

            var sync1 = repository.GetCustomers(" Sync1");
            var sync2 = repository.GetCustomersAsync(" Sync2", "F").Result;
            var sync3 = repository.GetCustomers(" Sync3", "M");

            var end = DateTime.Now;
            TimeSpan totalTime = end.Subtract(start);

            var synccustomers = sync1.Concat(sync2).Concat(sync3).ToList();
            Console.WriteLine($"(3) Sync Call takes : {totalTime.TotalSeconds} sec with data({synccustomers.Count})");

            Console.WriteLine($"================================================");
            #endregion

            #region Async Call
            start = DateTime.Now;

            var async1 = repository.GetCustomersAsync(" Async1");
            var async2 = repository.GetCustomersAsync(" Async2", "F");
            var async3 = repository.GetCustomersAsync(" Async3", "M");

            await Task.WhenAll(new List<Task> { async1, async2, async3 });
            end = DateTime.Now;
            totalTime = end.Subtract(start);

            var asynccustomers = async1.Result.Concat(async2.Result).Concat(async3.Result).ToList();
            Console.WriteLine($"(3) Async Call takes : {totalTime.TotalSeconds} sec with data({asynccustomers.Count})");

            Console.WriteLine($"================================================");
            #endregion

            #region Call with new Thread
            start = DateTime.Now;

            var maleCustomers = new List<Customer>();
            var thread1 = new Thread(() => {
                maleCustomers = repository.GetCustomersAsync(" Thread1").Result;
            });
            thread1.Start();

            var femaleCustomers = new List<Customer>();
            var thread2 = new Thread(() => {
                femaleCustomers = repository.GetCustomersAsync(" Thread2", "F").Result;
            });
            thread2.Start();

            var threadcustomers = new List<Customer>();
            var thread3 = new Thread(() => {
                threadcustomers = repository.GetCustomersAsync(" Thread3", "M").Result;
            });
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            end = DateTime.Now;
            totalTime = end.Subtract(start);

            threadcustomers = threadcustomers.Concat(maleCustomers).Concat(femaleCustomers).ToList();
            Console.WriteLine($"(3) Call with (3) new Thread takes : {totalTime.TotalSeconds} sec with data({threadcustomers.Count})");

            Console.WriteLine($"================================================");
            #endregion

            #region Call with Task.Factory.StartNew
            start = DateTime.Now;

            var task1 = Task.Factory.StartNew(() => {
                return Task.FromResult(repository.GetCustomers(" Task1"));
            }).Unwrap();

            var task2 = Task.Factory.StartNew(() => {
                return repository.GetCustomersAsync(" Task2", "F");
            }).Unwrap();

            var task3 = Task.Factory.StartNew(() => {
                return repository.GetCustomersAsync(" Task3", "M");
            }).Unwrap();

            await Task.WhenAll(new List<Task> { task1, task2, task3 });

            end = DateTime.Now;
            totalTime = end.Subtract(start);

            var taskcustomers = task1.Result.Concat(task2.Result).Concat(task3.Result).ToList();
            Console.WriteLine($"(3) Call with (3) Task.Factory.StartNew takes : {totalTime.TotalSeconds} sec with data({taskcustomers.Count})");
            #endregion

            Console.ReadLine();
        }
    }

    public class CustomerRepository
    {
        private List<Customer> customers;
        public CustomerRepository()
        {
            customers = new List<Customer>
            {
                new Customer(){ Id = 1, Gender = "M", Name = "A"},
                new Customer(){ Id = 2, Gender = "M", Name = "B"},
                new Customer(){ Id = 3, Gender = "M", Name = "C"},
                new Customer(){ Id = 4, Gender = "M", Name = "D"},
                new Customer(){ Id = 5, Gender = "M", Name = "E"},

                new Customer(){ Id = 6, Gender = "F", Name = "F"},
                new Customer(){ Id = 7, Gender = "F", Name = "G"},
                new Customer(){ Id = 8, Gender = "F", Name = "H"},
                new Customer(){ Id = 9, Gender = "F", Name = "I"},
                new Customer(){ Id = 10, Gender = "F", Name = "J"},
            };
        }

        public void RunThreeSecondLongProcess(string from)
        {

            Thread.Sleep(3000);
            Console.WriteLine($"{from}");
        }

        public async Task RunThreeSecondLongProcessAsync(string from)
        {
            await Task.Delay(3000);
            Console.WriteLine($"{from}");
        }

        public List<Customer> GetCustomers(string caller)
        {
            Console.WriteLine($"{caller} start running...");
            Thread.Sleep(4000);
            return customers.ToList();
        }

        public List<Customer> GetCustomers(string caller, string gender)
        {
            Console.WriteLine($"{caller} start running...");
            Thread.Sleep(3000);
            return customers.Where(w => w.Gender == gender).ToList();
        }
        public async Task<List<Customer>> GetCustomersAsync(string caller)
        {
            Console.WriteLine($"{caller} start running...");
            await Task.Delay(4000);
            return customers.ToList();
        }
        public async Task<List<Customer>> GetCustomersAsync(string caller, string gender)
        {
            Console.WriteLine($"{caller} start running...");
            await Task.Delay(3000);
            return customers.Where(w => w.Gender == gender).ToList();
        }

    }
    public class Customer
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
    }
}
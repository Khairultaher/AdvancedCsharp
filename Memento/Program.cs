/*
 * The Memento pattern is a behavioral design pattern that allows an object's internal state to be saved 
 * and restored at a later time
 * 
 * The memento design pattern is used when we want to save the state of an object so that we can restore later on.
*/

var ba = new BankAccount(100);
var m1 = ba.Deposit(50);
var m2 = ba.Deposit(25);
Console.WriteLine(ba);
ba.Restore(m1);
Console.WriteLine(ba);

class BankAccount
{
    private int balance;
    public BankAccount(int balance)
    {
        this.balance = balance;
    }
    public Memento Deposit(int amount)
    {
        balance += amount;
        return new Memento(balance);
    }
    public void Restore(Memento memento)
    {
        balance = memento.Balance;
    }
    public override string ToString()
    {
        return $"Balance: {balance}";
    }
    public class Memento
    {
        public int Balance { get; }
        public Memento(int balance)
        {
            Balance = balance;
        }
    }
}



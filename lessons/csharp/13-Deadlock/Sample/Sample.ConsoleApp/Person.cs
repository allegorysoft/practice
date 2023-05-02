namespace Sample.ConsoleApp;

public class Person
{
    private static int _counter = 0;

    public int Id { get; }
    public int Balance { get; protected set; } = 500;

    public Person()
    {
        Interlocked.Increment(ref _counter);
        Id = _counter;
    }

    public void Transfer(int amount, Person to)
    {
        object lockObject1 = Id > to.Id ? this : to;
        object lockObject2 = lockObject1 == this ? to : this;

        lock (lockObject1)
        {
            Thread.Sleep(1000);
            lock (lockObject2)
            {
                Balance -= amount;
                to.Balance += amount;
            }
        }
    }

    public void TransferDeadLock(int amount, Person to)
    {
        lock (this)
        {
            Thread.Sleep(1000);
            lock (to)
            {
                Balance -= amount;
                to.Balance += amount;
            }
        }
    }
}
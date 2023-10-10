using Jantar_dos_Filosofos;

class Program
{
    static void Main(string[] args)
    {
        int numPhilosophers = 5;
        Filosofo[] philosophers = new Filosofo[numPhilosophers];
        object[] forks = new object[numPhilosophers];

        for (int i = 0; i < numPhilosophers; i++)
        {
            forks[i] = new object();
        }

        for (int i = 0; i < numPhilosophers; i++)
        {
            philosophers[i] = new Filosofo(i, forks[i], forks[(i + 1) % numPhilosophers]);
            Thread philosopherThread = new Thread(philosophers[i].Eat);
            philosopherThread.Start();
        }

        Console.ReadLine(); // Let the philosophers dine indefinitely
    }
}
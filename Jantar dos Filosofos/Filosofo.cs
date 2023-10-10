using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jantar_dos_Filosofos
{
    internal class Filosofo
    {
        private int id;
        private object leftFork;
        private object rightFork;

        public Filosofo(int id, object leftFork, object rightFork)
        {
            this.id = id;
            this.leftFork = leftFork;
            this.rightFork = rightFork;
        }

        public void Eat()
        {
            int i = 0;
            while (i != 1000)
            {
                // Philosopher picks up forks based on their ID
                if (id % 2 == 0)
                {
                    Monitor.Enter(leftFork);
                    Monitor.Enter(rightFork);
                }
                else
                {
                    Monitor.Enter(rightFork);
                    Monitor.Enter(leftFork);
                }

                Console.WriteLine($"Philosopher {id} is eating.");
                Thread.Sleep(100); // Simulate eating

                Monitor.Exit(leftFork);
                Monitor.Exit(rightFork);

                Console.WriteLine($"Philosopher {id} is thinking.");
                Console.WriteLine(i);
                Thread.Sleep(100); // Simulate thinking
                i++;
            }
            
        }
    }
}

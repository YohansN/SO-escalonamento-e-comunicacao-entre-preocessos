using Round_Robin;
using System.Diagnostics;
public class Program
{
    static void RoundRobin(List<Processo> processos, int quantum)
    {
        int n = processos.Count;
        int numProcessosInicial = n;
        int tempo = 0;
        int tempoTotaldeEspera = 0;
        int totalTurnaroundTime = 0;
        int processosCompletos = 0;

        while (processosCompletos < n)
        {
            for(int i = 0; i < n-1; i++)
            {
                Processo processo = processos[i];
                if (processo.TempoRestante > 0)
                {
                    if (processo.TempoRestante <= quantum)
                    {
                        tempo += processo.TempoRestante;
                        processo.TempoRestante = 0;
                        processos.RemoveAt(0); //Processo terminou e sai da fila.
                        totalTurnaroundTime += tempo;
                        processosCompletos++;
                    }
                    else
                    {
                        tempo += quantum;
                        processo.TempoRestante -= quantum;
                        //Processo foi preemptado pelo quantum e vai para o fim da fila.
                        processos.Add(processo);
                        processos.RemoveAt(0);
                    }
                    tempoTotaldeEspera += tempo - processo.BurstTime;
                }
                i++;
            }
        }

        double tempoMedioDeEspera = (double)tempoTotaldeEspera / numProcessosInicial;
        double tempoMedioDeRetorno = (double)totalTurnaroundTime / numProcessosInicial;
        double throughput = (double)n / tempo;

        Console.WriteLine($"Tempo Médio de Espera: {tempoMedioDeEspera}");
        Console.WriteLine($"Tempo Médio de Retorno: {tempoMedioDeRetorno}");
        Console.WriteLine($"Vazão: {throughput} processos/s");

    }

    static void Main(string[] args)
    {
        List<Processo> processos1 = new List<Processo>
        {
            new Processo(1, 4),
            new Processo(2, 4),
            new Processo(3, 4)
        };

        int quantum = 2;
        Console.WriteLine($"Quantum = {quantum}:");
        RoundRobin(processos1, quantum);
        Console.WriteLine();

        List<Processo> processos2 = new List<Processo>
        {
            new Processo(1, 4),
            new Processo(2, 4),
            new Processo(3, 4)
        };

        quantum = 5;
        Console.WriteLine($"Quantum = {quantum}:");
        RoundRobin(processos2, quantum);
        Console.WriteLine();

        List<Processo> processos3 = new List<Processo>
        {
            new Processo(1, 4),
            new Processo(2, 4),
            new Processo(3, 4)
        };

        quantum = 10;
        Console.WriteLine($"Quantum = {quantum}:");
        RoundRobin(processos3, quantum);
        Console.WriteLine();

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    internal class Processo
    {
        public int Pid { get; }
        public int BurstTime { get; }
        public int TempoRestante { get; set; }

        public Processo(int pid, int burstTime)
        {
            Pid = pid;
            BurstTime = burstTime;
            TempoRestante = burstTime;
        }
    }
}

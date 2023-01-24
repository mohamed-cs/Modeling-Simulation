using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class PerformanceMeasures
    {
        public decimal AverageWaitingTime { get; set; }
        public int MaxQueueLength { get; set; }
        public decimal WaitingProbability { get; set; }

        public PerformanceMeasures()
        {
        }

        public PerformanceMeasures(decimal averageWaitingTime, int maxQueueLength, decimal waitingProbability)
        {
            AverageWaitingTime = averageWaitingTime;
            MaxQueueLength = maxQueueLength;
            WaitingProbability = waitingProbability;
        }
    }
}

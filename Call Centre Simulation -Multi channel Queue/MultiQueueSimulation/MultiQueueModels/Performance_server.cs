using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Performance_server
    {
        public int ID { get; set; }
        public float IdleProbability { get; set; }
        public float AverageServiceTime { get; set; }

        public float Utilization { get; set; }

        public Performance_server()
        {
        }

        public Performance_server(int iD, float idleProbability, float averageServiceTime, float utilization)
        {
            ID = iD;
            IdleProbability = idleProbability;
            AverageServiceTime = averageServiceTime;
            Utilization = utilization;
        }
    }


}

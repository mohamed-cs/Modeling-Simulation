using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationCase
    {
        public SimulationCase()
        {
            this.AssignedServer = new Server();
        }

        public int CustomerNumber { get; set; }//
        public int RandomInterArrival { get; set; }//
        public int InterArrival { get; set; }//
        public int ArrivalTime { get; set; }//
        public int RandomService { get; set; }//
        public int ServiceTime { get; set; }//
        public Server AssignedServer { get; set; }//
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int TimeInQueue { get; set; }

        public SimulationCase(int customerNumber, int randomInterArrival, int interArrival, int arrivalTime, int randomService, int serviceTime, Server assignedServer, int startTime, int endTime, int timeInQueue)
        {
            CustomerNumber = customerNumber;
            RandomInterArrival = randomInterArrival;
            InterArrival = interArrival;
            ArrivalTime = arrivalTime;
            RandomService = randomService;
            ServiceTime = serviceTime;
            AssignedServer = assignedServer;
            StartTime = startTime;
            EndTime = endTime;
            TimeInQueue = timeInQueue;
        }

        public SimulationCase(int customerNumber, int randomInterArrival, int interArrival, int arrivalTime)
        {
            CustomerNumber = customerNumber;
            RandomInterArrival = randomInterArrival;
            InterArrival = interArrival;
            ArrivalTime = arrivalTime;
        }

        public static decimal wating_average(List<SimulationCase> cases)
        {
            int sum = 0;

            for (int i=0;i<cases.Count;i++)
            {
                sum += cases[i].TimeInQueue;
            }

            
            return (decimal)sum/ cases.Count;
        }
    }


}

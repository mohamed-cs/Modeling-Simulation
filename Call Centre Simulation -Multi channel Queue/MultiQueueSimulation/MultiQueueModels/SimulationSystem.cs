using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.IO;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        public int time_system_reach = 0;

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }



        public SimulationSystem(string testFile)
        {
            // parse the text file

            // refactor into function
            #region PARSING
            FileStream fs = new FileStream(testFile, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            // reading number of server
            string property = sr.ReadLine(); //read property name
            string value = sr.ReadLine(); // read property value
            Console.WriteLine("{0}: {1}", property, value); // write to the console
            this.NumberOfServers = int.Parse(value); // parse number and assign to class property
            sr.ReadLine(); // consume new line between properties

            // reading stopping number
            property = sr.ReadLine(); //read property name
            value = sr.ReadLine(); // read property value
            Console.WriteLine("{0}: {1}", property, value); // write to the console
            this.StoppingNumber = int.Parse(value); // parse number and assign to class property
            sr.ReadLine(); // consume new line between properties


            // reading stopping criteria
            property = sr.ReadLine(); //read property name
            value = sr.ReadLine(); // read property value
            Console.WriteLine("{0}: {1}", property, value); // write to the console

            switch (int.Parse(value))
            {
                case 1:
                    this.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                    break;
                case 2:
                    this.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                    break;
            }

            sr.ReadLine(); // consume new line between properties


            // reading selection method
            property = sr.ReadLine(); // read property name
            value = sr.ReadLine(); // read property value
            Console.WriteLine("{0}: {1}", property, value); // write to the console
            switch (int.Parse(value))
            {
                case 1:
                    this.SelectionMethod = Enums.SelectionMethod.HighestPriority;
                    break;
                case 2:
                    this.SelectionMethod = Enums.SelectionMethod.Random;
                    break;
                case 3:
                    this.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                    break;

            }
            sr.ReadLine(); // consume new line between properties

            // reading Interarrival Distribution
            property = sr.ReadLine(); // read property name
            string line = sr.ReadLine();
            List<TimeDistribution> times = new List<TimeDistribution>();

            decimal cummProb = 0;
            while (line != "")
            {
                TimeDistribution td = new TimeDistribution();
                Console.WriteLine(line);

                string[] numbers = line.Split(',');

                td.Time = int.Parse(numbers[0]);
                td.Probability = decimal.Parse(numbers[1]);
                td.CummProbability = cummProb + td.Probability;
                td.MinRange = (int)(cummProb * 100)+1;
                td.MaxRange = (int)(((double)td.CummProbability) * 100);

                cummProb += td.Probability;

                Console.WriteLine("Time: {0}", td.Time);
                Console.WriteLine("Probability: {0}", td.Probability);
                Console.WriteLine("CummProbability: {0}", td.CummProbability);
                Console.WriteLine("MinRange: {0}", td.MinRange);
                Console.WriteLine("MaxRange: {0}", td.MaxRange);
                Console.WriteLine("------------------------------");

                times.Add(td);
                line = sr.ReadLine();
            }

            this.InterarrivalDistribution = times;

            // reading services distribution

            Console.WriteLine("------------------------------");
            Console.WriteLine("------------------------------");


            List<Server> myServers = new List<Server>();

            int serverID = 1;

            while (true)
            {

                // time dist for 1 server

                property = sr.ReadLine(); // read property name

                if (property == null)
                {
                    break;
                }


                line = sr.ReadLine();

                Server server = new Server();

                server.ID = serverID++;

                decimal serverCummProb = 0;

                List<TimeDistribution> serverTimes = new List<TimeDistribution>();

                while (line != "" && line != null)
                {

                    TimeDistribution s = new TimeDistribution();
                    Console.WriteLine(line);

                    string[] nums = line.Split(',');

                    s.Time = int.Parse(nums[0]);
                    s.Probability = decimal.Parse(nums[1]);
                    s.CummProbability = serverCummProb + s.Probability;
                    s.MinRange = (int)(serverCummProb * 100)+1;
                    s.MaxRange = (int)(((double)s.CummProbability) * 100);

                    serverCummProb += s.Probability;

                    Console.WriteLine("Time: {0}", s.Time);
                    Console.WriteLine("Probability: {0}", s.Probability);
                    Console.WriteLine("CummProbability: {0}", s.CummProbability);
                    Console.WriteLine("MinRange: {0}", s.MinRange);
                    Console.WriteLine("MaxRange: {0}", s.MaxRange);
                    Console.WriteLine("------------------------------");

                    line = sr.ReadLine();
                    serverTimes.Add(s);
                }

                server.TimeDistribution = serverTimes;

                //TODO: calc other server properties


                myServers.Add(server);

            }

            this.Servers = myServers;


            this.PerformanceMeasures = new PerformanceMeasures();

            #endregion
        }



        public void Interval_distributions_complete()
    {
            int min_range = 1;
            int max_range = 100;
            int size = this.InterarrivalDistribution.Count;

            for (int i=0;i<size;i++)
            {
               float cmmulative_sum = 0.0f ;

                int lower, upper;


                if (i==0)
                {
                    cmmulative_sum = (float)this.InterarrivalDistribution[i].Probability;
                    lower = min_range;
                    upper = (int)cmmulative_sum*100;

                }
                else if (i==(size-1))
                {
                    for (int j=0;j<=i;j++)
                    {
                        cmmulative_sum += (float)this.InterarrivalDistribution[j].Probability;
                    }

                    upper = max_range;
                    lower = (this.InterarrivalDistribution[i - 1].MaxRange)*100 + 1;
                }
                else
                {
                    for (int j = 0; j <= i; j++)
                    {
                        cmmulative_sum += (float)this.InterarrivalDistribution[j].Probability;
                    }
                    lower = (this.InterarrivalDistribution[i - 1].MaxRange)*100 + 1;
                    upper = (int)(cmmulative_sum * 100);

                }

                this.InterarrivalDistribution[i].MinRange = lower;
                this.InterarrivalDistribution[i].MaxRange = upper;
                this.InterarrivalDistribution[i].CummProbability = (decimal)cmmulative_sum;

            }


           

    }
        public void servers_complete()
        {
            for (int i=0;i<this.Servers.Count;i++)
            {
                this.Servers[i].server_time_distributions();
            }

        }


        public int get_interval_number(int interval_random)
        {

            for (int i=0;i<this.InterarrivalDistribution.Count;i++)
            {
                if (interval_random >= this.InterarrivalDistribution[i].MinRange && interval_random <= this.InterarrivalDistribution[i].MaxRange)
                {
                    return this.InterarrivalDistribution[i].Time;
                }
            }

            return 0;
        }


        public int select_server_random()
        {
            List<int> available_server_index = new List<int>();

            for (int i=0; i< this.Servers.Count;i++)
            {
                if (!this.Servers[i].IsRunning)
                {
                    available_server_index.Add(i);
                }
            }

            if (available_server_index.Count > 0)
            {
                Random random = new Random();

                int index = random.Next(available_server_index.Count);
                return available_server_index[index];
            }
            else if (available_server_index.Count==0)
            {
                return -1;
            }
            return -1;

        }


        public int select_server_with_priority()
        {
            List<int> available_server_high_priority_index = new List<int>();
            List<int> available_server_normal_index = new List<int>();

            for (int i=0;i<this.Servers.Count;i++)
            {
                if (!this.Servers[i].IsRunning)
                {
                    if (this.Servers[i].Priority == Enums.Priority.High)
                    {
                        available_server_high_priority_index.Add(i);
                    }
                    else
                    {
                        available_server_normal_index.Add(i);
                    }
                }
            }


            if (available_server_high_priority_index.Count > 0)
            {
                return available_server_high_priority_index[0];
            }
            else if (available_server_normal_index.Count >0)
            {
                return available_server_normal_index[0];
            }
            
            return -1;

        }

        public int select_server_has_leaset_utilitazation()
        {
            
            List<int> available_servers = new List<int>();
            List<decimal> utilization = new List<decimal>();
            for (int i = 0; i < this.Servers.Count; i++)
            {   
                if (time_system_reach==0)
                {
                    time_system_reach = 1;
                }
                this.Servers[i].Utilization = (decimal)this.Servers[i].TotalWorkingTime/time_system_reach;

                if (!this.Servers[i].IsRunning)
                {
                    available_servers.Add(i);
                    utilization.Add(this.Servers[i].Utilization);
                }
            }

            if (available_servers.Count > 0)
            { 
            return available_servers[utilization.IndexOf(utilization.Min())];
            }

            return -1;
        }

        public int select_server()
        {
            if (this.SelectionMethod == Enums.SelectionMethod.Random)
            {
                return this.select_server_random();
            }
            else if (this.SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {
                return this.select_server_with_priority();
            }
            else if (this.SelectionMethod == Enums.SelectionMethod.LeastUtilization)
            {
                return this.select_server_has_leaset_utilitazation();
            }
            return -1;
        }


        public void server_running(int service_arrival_time)
        {
            for (int i=0;i<this.Servers.Count;i++)
            {
                if (this.Servers[i].FinishTime <= service_arrival_time)
                {
                    this.Servers[i].IsRunning = false;
                }
                else if (this.Servers[i].FinishTime > service_arrival_time)
                {
                    this.Servers[i].IsRunning = true;
                }
            }
        }

        public int server_search(int arrival_time)
        {
            int server_id = -1;
            int min_finished_time = 1000000000;

            for(int i=0;i<this.Servers.Count;i++)
            {
                if (this.Servers[i].IsRunning && this.Servers[i].FinishTime >arrival_time)
                {
                   if (this.Servers[i].FinishTime <min_finished_time)
                    {
                        min_finished_time = this.Servers[i].FinishTime;
                        server_id = i;
                    }
                }
            }

            return server_id;
        }


        public void average_service_time_per_server()
        {   

            for(int i=0;i<this.Servers.Count;i++)
            {   
                if (this.Servers[i].number_of_assigned_service == 0)
                {
                    this.Servers[i].AverageServiceTime = 0;
                }
                else
                {
                    this.Servers[i].AverageServiceTime = (decimal)this.Servers[i].TotalWorkingTime / this.Servers[i].number_of_assigned_service;
                }
                
            }

        }

        public void servers_idle_times()
        {
            int max_endtime = 0;

            for (int i=0;i<this.SimulationTable.Count;i++)
            {
                if (this.SimulationTable[i].EndTime > max_endtime)
                {
                    max_endtime = this.SimulationTable[i].EndTime;
                }
            }

            for(int i=0;i<this.Servers.Count;i++)
            {
                this.Servers[i].IdleProbability = ((decimal)(max_endtime - this.Servers[i].TotalWorkingTime) / max_endtime);

            }
        }

       

        public List<Performance_server> get_per()
        {
            List<Performance_server> pers = new List<Performance_server>();

            for(int i=0;i<this.Servers.Count;i++)
            {
                Performance_server s = new Performance_server();

                s.ID = this.Servers[i].ID;
                s.IdleProbability = (float)this.Servers[i].IdleProbability;
                s.Utilization = (float)this.Servers[i].Utilization;
                s.AverageServiceTime = (float)this.Servers[i].AverageServiceTime;
                pers.Add(s);
            }

            return pers;
        }

        public void utilitazion_res()
        {
            int max_endtime = 0;

            for (int i = 0; i < this.SimulationTable.Count; i++)
            {
                if (this.SimulationTable[i].EndTime > max_endtime)
                {
                    max_endtime = this.SimulationTable[i].EndTime;
                }
            }

            for (int i = 0; i < this.Servers.Count; i++)
            {
                this.Servers[i].Utilization = (decimal)this.Servers[i].TotalWorkingTime / max_endtime;
            }
        }



    }



}

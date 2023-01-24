using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;
using System.Collections;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            Application.Run(form);

            /*
            SimulationSystem system = new SimulationSystem(form.path);

            MessageBox.Show("Data read successfulyy");

            //note that queue store the index of queued service in cases list
            //so i can edit on it when any server is get free 

            Queue<int> wating_queue = new Queue<int>();

            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                int customers_limit = system.StoppingNumber;
                

                int customer_no = 1;


                

                List<SimulationCase> cases = new List<SimulationCase>();
                Random rand = new Random();

                while (customer_no <= customers_limit)
                {
                    int random_interval = 0;
                    int inter_arrival = 0;
                    int arrival_time = 0;
                    int random_duration = 0;
                    int service_duration = 0;
                    int server_index = 0;
                    int time_service_begin = 0;
                    int time_service_end = 0;
                    int time_inqueue = 0;

                    if (customer_no == 1)
                    {
                        
                        arrival_time= 0;
                    }
                    else if (customer_no > 1)
                    {
                        random_interval = rand.Next(1, 100);
                        inter_arrival = system.get_interval_number(random_interval);

                        arrival_time = inter_arrival + cases[cases.Count - 1].ArrivalTime;
                    }


                    system.server_running(arrival_time);

                    random_duration = rand.Next(1, 100);
                    
                    server_index = system.select_server();



                    

                    if (server_index == -1)
                    {

                        Console.WriteLine("========>{0}", customer_no);

                        int used_server_id = system.server_search(arrival_time);


                        server_index = used_server_id;
                        system.Servers[server_index].IsRunning = true;
                        system.Servers[server_index].number_of_assigned_service += 1;
                        service_duration = system.Servers[server_index].get_interval_number(random_duration);
                        system.Servers[server_index].TotalWorkingTime += service_duration;

                        time_service_begin = system.Servers[server_index].FinishTime;
                        time_inqueue = time_service_begin-arrival_time;

                        time_service_end = arrival_time + service_duration + time_inqueue;

                        system.Servers[server_index].FinishTime = time_service_end;

                        SimulationCase c_q = new SimulationCase(customer_no, random_interval, inter_arrival, arrival_time, random_duration, service_duration, system.Servers[server_index], time_service_begin, time_service_end, time_inqueue);

                        cases.Add(c_q);

                        customer_no += 1;

                        continue;
                    }

                 

                    system.Servers[server_index].IsRunning = true;

                    system.Servers[server_index].number_of_assigned_service += 1;
                        

                    service_duration = system.Servers[server_index].get_interval_number(random_duration);
                    system.Servers[server_index].TotalWorkingTime += service_duration;


                    time_service_begin = arrival_time;
                    time_inqueue = 0;

                    time_service_end = arrival_time + service_duration + time_inqueue;

                    system.Servers[server_index].FinishTime = time_service_end;


                    SimulationCase c = new SimulationCase(customer_no, random_interval, inter_arrival,arrival_time, random_duration, service_duration, system.Servers[server_index], time_service_begin, time_service_end, time_inqueue);

                    cases.Add(c);
                    

                    
                  

                    customer_no += 1;

                }


                MessageBox.Show("finished");

            }
            else if (system.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
            {
                int time = system.StoppingNumber;
                int customer_no = 1;

                List<SimulationCase> cases = new List<SimulationCase>();
                Random rand = new Random();
                int last_finish = 0;

                while (last_finish<=time)
                {
                    int random_interval = 0;
                    int inter_arrival = 0;
                    int arrival_time = 0;
                    int random_duration = 0;
                    int service_duration = 0;
                    int server_index = 0;
                    int time_service_begin = 0;
                    int time_service_end = 0;
                    int time_inqueue = 0;

                    if (customer_no == 1)
                    {

                        arrival_time = 0;
                    }
                    else if (customer_no > 1)
                    {
                        random_interval = rand.Next(1, 100);
                        inter_arrival = system.get_interval_number(random_interval);

                        arrival_time = inter_arrival + cases[cases.Count - 1].ArrivalTime;
                    }


                    system.server_running(arrival_time);

                    random_duration = rand.Next(1, 100);

                    server_index = system.select_server();





                    if (server_index == -1)
                    {

                        Console.WriteLine("========>{0}", customer_no);

                        int used_server_id = system.server_search(arrival_time);


                        server_index = used_server_id;
                        system.Servers[server_index].IsRunning = true;
                        system.Servers[server_index].number_of_assigned_service += 1;
                        service_duration = system.Servers[server_index].get_interval_number(random_duration);
                        system.Servers[server_index].TotalWorkingTime += service_duration;

                        time_service_begin = system.Servers[server_index].FinishTime;
                        time_inqueue = time_service_begin - arrival_time;

                        time_service_end = arrival_time + service_duration + time_inqueue;

                        system.Servers[server_index].FinishTime = time_service_end;

                        SimulationCase c_q = new SimulationCase(customer_no, random_interval, inter_arrival, arrival_time, random_duration, service_duration, system.Servers[server_index], time_service_begin, time_service_end, time_inqueue);

                        cases.Add(c_q);

                        customer_no += 1;

                        last_finish = time_service_end;

                        continue;
                    }



                    system.Servers[server_index].IsRunning = true;

                    system.Servers[server_index].number_of_assigned_service += 1;


                    service_duration = system.Servers[server_index].get_interval_number(random_duration);
                    system.Servers[server_index].TotalWorkingTime += service_duration;


                    time_service_begin = arrival_time;
                    time_inqueue = 0;

                    time_service_end = arrival_time + service_duration + time_inqueue;

                    system.Servers[server_index].FinishTime = time_service_end;

                    last_finish = time_service_end;

                    SimulationCase c = new SimulationCase(customer_no, random_interval, inter_arrival, arrival_time, random_duration, service_duration, system.Servers[server_index], time_service_begin, time_service_end, time_inqueue);

                    cases.Add(c);





                    customer_no += 1;

                }


                MessageBox.Show("finished");
            }

            Form2 form2 = new Form2();
            Application.Run(form2);
            */

            //string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            //MessageBox.Show(result);
            
           
        }
    }
}

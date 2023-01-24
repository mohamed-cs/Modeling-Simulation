using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{

    public partial class Form1 : Form
    {   

        public string path { get; set; }
        List<SimulationCase> cases = new List<SimulationCase>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog v1 = new OpenFileDialog();
            v1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (v1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = v1.FileName;
                this.path = v1.FileName;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SimulationSystem system = new SimulationSystem(this.path);

 
            MessageBox.Show("Data read successfulyy");

            system.Servers[0].Priority = Enums.Priority.High;

            int max_queue_length = 0;

            int customer_waiting_count = 0;

            List<SimulationCase> queue = new List<SimulationCase>();

            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                int customers_limit = system.StoppingNumber;


                int customer_no = 1;


                Random rand = new Random();

                while (customer_no <= customers_limit)
                {
                    int random_interval = 1;
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

                    for(int i=0;i<queue.Count;i++)
                    {
                        if (arrival_time >= queue[i].StartTime)
                        {
                            queue.RemoveAt(i);
                        }
                    }

                    system.server_running(arrival_time);

                    random_duration = rand.Next(1, 100);

                    server_index = system.select_server();

                    



                    if (server_index == -1)
                    {
                        customer_waiting_count += 1;

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

                        queue.Add(c_q);

                        cases.Add(c_q);

                        customer_no += 1;

                        system.time_system_reach = time_service_end;


                        if (queue.Count > max_queue_length)
                        {
                            max_queue_length = queue.Count;
                        }


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


                    SimulationCase c = new SimulationCase(customer_no, random_interval, inter_arrival, arrival_time, random_duration, service_duration, system.Servers[server_index], time_service_begin, time_service_end, time_inqueue);

                    cases.Add(c);



                    system.time_system_reach = time_service_end;

                    customer_no += 1;

                }


                MessageBox.Show("finished");

            }
            else if (system.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
            {
                int time = system.StoppingNumber;
                int customer_no = 1;

                
                Random rand = new Random();
                int last_finish = 0;

                while (last_finish <= time)
                {
                    int random_interval = 1;
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
                        customer_waiting_count += 1;

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

                        system.time_system_reach = time_service_end;

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


                    system.time_system_reach = time_service_end;


                    customer_no += 1;

                }


                MessageBox.Show("finished");
            }


            system.SimulationTable = cases;


            //performance for system 

            decimal average_wait_time = (decimal)SimulationCase.wating_average(cases);
            decimal waiting_probability = (decimal)customer_waiting_count / (decimal)cases.Count;

            
            int wait_queue = max_queue_length;

            PerformanceMeasures per = new PerformanceMeasures(average_wait_time,wait_queue,waiting_probability);

            //performance by server
            system.PerformanceMeasures = per;




            system.average_service_time_per_server();

            system.servers_idle_times();
            system.utilitazion_res();


            List<Performance_server> pers = system.get_per();

            string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            MessageBox.Show(result);

            this.Hide();

            Form2 form2 = new Form2(cases,system.PerformanceMeasures,pers);
            
            form2.ShowDialog();
            
            this.Close();



        }
    }
}

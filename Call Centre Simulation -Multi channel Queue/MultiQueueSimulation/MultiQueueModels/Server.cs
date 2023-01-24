using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        //optional if needed use them
        public int FinishTime { get; set; }

        public int TotalWorkingTime  { get; set; }

    public int number_of_assigned_service = 0;

        public Enums.Priority Priority = Enums.Priority.normal;

        public bool IsRunning = false;


        public void server_time_distributions()
        {
            int min_range = 1;
            int max_range = 100;
            int size = this.TimeDistribution.Count;

            for (int i = 0; i < size; i++)
            {
                float cmmulative_sum = 0.0f;

                int lower, upper;


                if (i == 0)
                {
                    cmmulative_sum = (float)this.TimeDistribution[i].Probability;
                    lower = min_range;
                    upper = (int)cmmulative_sum;

                }
                else if (i == (size - 1))
                {
                    for (int j = 0; j <= i; j++)
                    {
                        cmmulative_sum += (float)this.TimeDistribution[j].Probability;
                    }

                    upper = max_range;
                    lower = this.TimeDistribution[i - 1].MaxRange + 1;
                }
                else
                {
                    for (int j = 0; j <= i; j++)
                    {
                        cmmulative_sum += (float)this.TimeDistribution[j].Probability;
                    }
                    lower = this.TimeDistribution[i - 1].MaxRange + 1;
                    upper = (int)(cmmulative_sum * 100);

                }

                this.TimeDistribution[i].MinRange = lower;
                this.TimeDistribution[i].MaxRange = upper;
                this.TimeDistribution[i].CummProbability = (decimal)cmmulative_sum;

            }


        }

        public int get_interval_number(int interval_random)
        {

            for (int i = 0; i < this.TimeDistribution.Count; i++)
            {
                if (interval_random >= this.TimeDistribution[i].MinRange && interval_random <= this.TimeDistribution[i].MaxRange)
                {
                    return this.TimeDistribution[i].Time;
                }
            }

            return 0;
        }
    }
}

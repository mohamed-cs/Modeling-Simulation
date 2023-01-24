using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryModels
{
    public class SimulationSystem
    {
        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }
        public int ReviewPeriod { get; set; }
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }
        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }

        ///////////// OUTPUTS /////////////

        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }




        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }

        public SimulationSystem(String Path)
        {
            string[] lines = File.ReadAllLines(Path);

            // lines in the testcase file start at 1 so each index is one less
             
            this.OrderUpTo = Int32.Parse(lines[1]);
            this.ReviewPeriod = Int32.Parse(lines[4]);
            this.StartInventoryQuantity = Int32.Parse(lines[7]);
            this.StartLeadDays = Int32.Parse(lines[10]);
            this.StartOrderQuantity = Int32.Parse(lines[13]);
            this.NumberOfDays = Int32.Parse(lines[16]);
            this.DemandDistribution = parsetypeofDemandDistribution(lines, 19, 5);
            this.LeadDaysDistribution = parsetypeofDemandDistribution(lines, 26, 3);
        }
    
        
        public List<Distribution> parsetypeofDemandDistribution(string[]lines,int dist_index,int dist_size)
        {
            List<Distribution> deman_dis = new List<Distribution>();

            
            for (int i=0;i<dist_size;i++)
            {
                Distribution dist = new Distribution();

                //split the line at comma
                string[] dayTypeDist = lines[dist_index].Split(',');

                dist.Value = Int32.Parse(dayTypeDist[0]);

                dist.Probability = Decimal.Parse(dayTypeDist[1]);

                dist.CummProbability = 0;

                
                dist.CummProbability = dist.Probability;

                dist.MinRange = 1;

                if (i >0)
                {
                    dist.CummProbability += deman_dis[i-1].CummProbability;
                    dist.MinRange = deman_dis[i - 1].MaxRange + 1;
                }


                dist.MaxRange = (int)(dist.CummProbability * 100);

                deman_dis.Add(dist);

                dist_index += 1;
            }


            return deman_dis;
        }



        public int get_random_eqv(int random,List<Distribution> dist)
        {
            int value = 0;

            for (int i=0; i<dist.Count;i++)
            {
                if ((random >= dist[i].MinRange) && (random <= dist[i].MaxRange))
                {
                    value = dist[i].Value;
                    break;
                }
            }

            return value;
        }


        public void System_run()
        {

            
            int Days = 1;
            int cycle_no = 1;
            int Day_within_cycle = 1;

            int inventory_capacity = this.StartInventoryQuantity;

            int review_period = 0;

            int day_order_arrive = this.StartLeadDays;

            int order_quantity = this.StartOrderQuantity;

            int shortage = 0;

            List<SimulationCase> casees = new List<SimulationCase>();

            while (Days <= this.NumberOfDays)
            {
                SimulationCase c= new SimulationCase();

                day_order_arrive -= 1;

                c.Day = Days;

                if (Day_within_cycle > this.ReviewPeriod)
                {
                    cycle_no += 1;
                    Day_within_cycle = 1;
                }

                c.Cycle = cycle_no;
                c.DayWithinCycle = Day_within_cycle;
                
                if (day_order_arrive == -1)
                {
                   inventory_capacity += order_quantity;
                    
                }

                c.BeginningInventory = inventory_capacity;

                Random r = new Random();

                c.RandomDemand= r.Next(1, 100);

                MessageBox.Show(c.RandomDemand.ToString());

                c.Demand = get_random_eqv(c.RandomDemand, this.DemandDistribution);

                if ((inventory_capacity >= c.Demand) && (shortage !=0) && (inventory_capacity >= c.Demand+shortage))
                {
                    inventory_capacity -= c.Demand;
                    inventory_capacity -= shortage;
                    c.ShortageQuantity = 0;
                    shortage = 0;
                    
                }
                else if ((inventory_capacity >= c.Demand) && (shortage != 0))
                {
                    inventory_capacity -= c.Demand;
                    shortage -= inventory_capacity;

                    inventory_capacity = 0;

                    c.ShortageQuantity = shortage;
                    

                }
                else if (inventory_capacity >= c.Demand)
                {
                    inventory_capacity -= c.Demand;
                    c.ShortageQuantity = 0;
                    
                }
                else if (inventory_capacity < c.Demand)
                {
                    shortage += Math.Abs(inventory_capacity - c.Demand);

                     c.ShortageQuantity=shortage;

                    inventory_capacity = 0;
                   
                }

                c.EndingInventory = inventory_capacity;


                if (Day_within_cycle != this.ReviewPeriod)
                {
                    c.OrderQuantity = 0;
                    c.RandomLeadDays = 0;
                    c.LeadDays = 0;
                }
                else if (Day_within_cycle == this.ReviewPeriod)
                {
                    order_quantity = this.OrderUpTo - inventory_capacity + shortage;
                    Random rr = new Random();

                    c.OrderQuantity = order_quantity;

                    c.RandomLeadDays= rr.Next(1, 100);
                    c.LeadDays = get_random_eqv(c.RandomLeadDays, this.LeadDaysDistribution);
                    day_order_arrive = c.LeadDays;
                }




                Day_within_cycle += 1;
                Days += 1;

                casees.Add(c);

            }

            this.SimulationTable = casees;

            int end_avg = 0;
            int short_avg = 0;

            for (int i=0;i<this.SimulationTable.Count;i++)
            {
                end_avg += this.SimulationTable[i].EndingInventory;
                short_avg += this.SimulationTable[i].ShortageQuantity;
            }


            PerformanceMeasures performance = new PerformanceMeasures();

            performance.EndingInventoryAverage = (decimal)end_avg / this.SimulationTable.Count;
            performance.ShortageQuantityAverage = (decimal)short_avg / this.SimulationTable.Count;

            this.PerformanceMeasures = performance;

        }




    }
}

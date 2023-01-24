using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace NewspaperSellerModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
            
        }

        public SimulationSystem(string file)
        {
            string[] lines = File.ReadAllLines(file);

            // lines in the testcase file start at 1 so each index is one less
            this.NumOfNewspapers = Int32.Parse(lines[1]);
            this.NumOfRecords = Int32.Parse(lines[4]);  //num of days
            this.PurchasePrice = Decimal.Parse(lines[7]);
            this.ScrapPrice = Decimal.Parse(lines[10]);
            this.SellingPrice = Decimal.Parse(lines[13]);
            this.UnitProfit = this.SellingPrice - this.PurchasePrice;

            this.DayTypeDistributions = this.parseDayTypeDistribution(lines[16]);

            this.DemandDistributions = this.parseDemandDistributions(lines);

            this.creat_table();

            Console.WriteLine("finish");  
            
        }
     
        ///////////// INPUTS /////////////
        public int NumOfNewspapers { get; set; }
        public int NumOfRecords { get; set; }
        public decimal PurchasePrice { get; set;}
        public decimal SellingPrice { get; set; }
        public decimal ScrapPrice { get; set; }
        public decimal UnitProfit { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }
        

        public void creat_table()
        {
            // this.PerformanceMeasures.

            this.SimulationTable = new List<SimulationCase>();

            this.PerformanceMeasures = new PerformanceMeasures();

           this.PerformanceMeasures.TotalLostProfit  =0;
           this.PerformanceMeasures.TotalNetProfit   =0;
           this.PerformanceMeasures.TotalSalesProfit =0;                
           this.PerformanceMeasures.TotalScrapProfit =0;
           
             for(int i=0 ; i< this.NumOfRecords ; i++)
             {  SimulationCase mycase = new SimulationCase();
                //case = new SimulationCase( this.PurchasePrice,this.ScrapPrice,  this.DayTypeDistributions ,this.DemandDistributions , this.SellingPrice, this.NumOfNewspapers);
                mycase.construct(this.PurchasePrice,this.ScrapPrice ,  this.DayTypeDistributions ,this.DemandDistributions , this.SellingPrice, this.NumOfNewspapers);
                //this.SimulationTable.Add(mycase);
                this.PerformanceMeasures.TotalLostProfit += mycase.LostProfit;
                this.PerformanceMeasures.TotalNetProfit +=mycase.DailyNetProfit;
                this.PerformanceMeasures.TotalSalesProfit += mycase.SalesProfit;
                this.PerformanceMeasures.TotalScrapProfit +=mycase.ScrapProfit;
                this.PerformanceMeasures.TotalCost += mycase.DailyCost;

               // Console.WriteLine(mycase.RandomDemand);
                MessageBox.Show(mycase.RandomDemand.ToString());
                SimulationTable.Add(mycase);

             }

            this.PerformanceMeasures.DaysWithMoreDemand = SimulationCase.num_DaysWithMoreDemand;
            this.PerformanceMeasures.DaysWithUnsoldPapers = SimulationCase.num_DaysWithUnsoldPapers;


        }

        List<DayTypeDistribution> parseDayTypeDistribution(string line)
        {
            string[] dayTypeDist = line.Split(',');//split the line at comma

            List<DayTypeDistribution> dayTypeDistributions = new List<DayTypeDistribution>();
            decimal cummProb = 0;
            for (int i = 0; i < dayTypeDist.Length; i++)
            {
                Enums.DayType dayType;
                switch (i)
                {
                    case 0:
                        dayType = Enums.DayType.Good; break;
                    case 1:
                        dayType = Enums.DayType.Fair; break;
                    case 2:
                        dayType = Enums.DayType.Poor; break;
                    default:
                        dayType = Enums.DayType.Good; break;
                }

                decimal prob = Decimal.Parse(dayTypeDist[i]);
                cummProb += prob;
                DayTypeDistribution d = new DayTypeDistribution(dayType, prob, cummProb, (int)((cummProb - prob) * 100) + 1, (int)(cummProb * 100));
                dayTypeDistributions.Add(d);
            }
            return dayTypeDistributions;
        }

        List<DemandDistribution> parseDemandDistributions(string[] lines)
        {
            List<DemandDistribution> demandDistributions = new List<DemandDistribution>();

            decimal[] daysCummProb = { 0, 0, 0 }; // cummulative probability for each day {good, fair, poor}
            for (int i = 0; i < 7 /* number of demand dist lines*/; i++)
            {
                string[] demandDists = lines[19 + i].Split(',');// starts at line 19 ends at line 19+6 which is 25

                List<DayTypeDistribution> distributions = new List<DayTypeDistribution>(); // list of Day Type Distribution for each demand

                for (int j = 1; j < demandDists.Length; j++)
                {
                    Enums.DayType dayType;

                    switch (i)
                    {
                        case 0:
                            dayType = Enums.DayType.Good; break;
                        case 1:
                            dayType = Enums.DayType.Fair; break;
                        case 2:
                            dayType = Enums.DayType.Poor; break;
                        default:
                            dayType = Enums.DayType.Good; break;
                    }
                    decimal dayProb = Decimal.Parse(demandDists[j]);
                    daysCummProb[j - 1] += dayProb;
                    DayTypeDistribution dd = new DayTypeDistribution(dayType, dayProb, daysCummProb[j - 1], (int)((daysCummProb[j - 1] - dayProb) * 100) + 1, (int)(daysCummProb[j - 1] * 100));
                    distributions.Add(dd);
                }

                DemandDistribution d = new DemandDistribution(Int32.Parse(demandDists[0]), distributions);
                demandDistributions.Add(d);
            }

            return demandDistributions;
        }
        
        

    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationCase
    {
        static int Day_num  = 0;
      public  static int num_DaysWithMoreDemand =0;
       public static int num_DaysWithUnsoldPapers = 0;

        public int DayNo { get; set; }
        public int RandomNewsDayType { get; set; }
        public Enums.DayType NewsDayType { get; set; }
        public int RandomDemand { get; set; }
        public int Demand { get; set; }
        public decimal DailyCost { get; set; }
        public decimal SalesProfit { get; set; }
        public decimal LostProfit { get; set; }
        public decimal ScrapProfit { get; set; }
        public decimal DailyNetProfit { get; set; }

        public void construct( decimal PurchasePrice ,decimal ScrapPrice, List<DayTypeDistribution> dayTypeDistributions , List<DemandDistribution> demandDistributions , decimal SellingPrice ,  int NumOfNewspapers)
        {
            Day_num +=1;
            this.DailyCost = NumOfNewspapers * PurchasePrice;
            this.DayNo = Day_num;
             Random r = new Random();
   
            this.RandomNewsDayType= r.Next(1,100);
             r = new Random();
            this.RandomDemand = r.Next(1,100);

            Console.WriteLine(RandomDemand);

            if(this.RandomNewsDayType >= dayTypeDistributions[0].MinRange && this.RandomNewsDayType <= dayTypeDistributions[0].MaxRange)
            {
                this.NewsDayType = Enums.DayType.Good;
                for(int i=0 ;i<7 ; i++)
                {
                  if (this.RandomDemand<= demandDistributions[i].DayTypeDistributions[0].MaxRange && this.RandomDemand >= demandDistributions[i].DayTypeDistributions[0].MinRange)
                    {
                        this.Demand = demandDistributions[i].Demand;
                        break;
                    }
                }
            }
            else if(this.RandomNewsDayType >= dayTypeDistributions[1].MinRange && this.RandomNewsDayType <= dayTypeDistributions[1].MaxRange)
            {
                this.NewsDayType = Enums.DayType.Fair;
                for(int i=0 ;i<7 ; i++)
                {
                  if (this.RandomDemand<= demandDistributions[i].DayTypeDistributions[1].MaxRange && this.RandomDemand >= demandDistributions[i].DayTypeDistributions[1].MinRange)
                    {
                        this.Demand = demandDistributions[i].Demand;
                        break;
                    }
                }


            }
            else if(this.RandomNewsDayType >= dayTypeDistributions[2].MinRange && this.RandomNewsDayType <= dayTypeDistributions[2].MaxRange)
            {
                 this.NewsDayType = Enums.DayType.Poor;
                for(int i=0 ;i<7 ; i++)
                {
                  if (this.RandomDemand<= demandDistributions[i].DayTypeDistributions[2].MaxRange && this.RandomDemand >= demandDistributions[i].DayTypeDistributions[2].MinRange)
                    {
                        this.Demand = demandDistributions[i].Demand;
                        break;
                    }
                }
            }
               int sold_num , scrap_papers;
            this.LostProfit = 0;   
            if(this.Demand< NumOfNewspapers) // anharda fi war2 mtba34
            {
                LostProfit = 0;
                sold_num = this.Demand ;
                scrap_papers = -1*this.Demand + NumOfNewspapers;
                num_DaysWithUnsoldPapers +=1;
            }
            else //fi war2 etba2 eza kan 2ad el m3aia aw akbar mn el m3aia
            {
                 sold_num = NumOfNewspapers ;
                 scrap_papers = 0;
                 
                if (this.Demand > NumOfNewspapers)
                {
                    this.LostProfit = (decimal)(this.Demand - NumOfNewspapers) * (SellingPrice - PurchasePrice);
                    num_DaysWithMoreDemand += 1;
                }

            }
            this.SalesProfit = (decimal) sold_num * SellingPrice;
             
            //this.LostProfit = (decimal)(this.Demand - NumOfNewspapers)* (SellingPrice - PurchasePrice );
            this.ScrapProfit = (decimal) scrap_papers * ScrapPrice;

            this.DailyNetProfit = (decimal)this.SalesProfit - this.DailyCost - this.LostProfit + this.ScrapProfit;
            
        }
    }
}

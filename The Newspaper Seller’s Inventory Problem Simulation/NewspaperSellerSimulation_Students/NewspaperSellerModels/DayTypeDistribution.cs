using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class DayTypeDistribution
    {

        public DayTypeDistribution() { }

        public DayTypeDistribution(Enums.DayType DayType, decimal Probability, decimal CummProbability, int MinRange, int MaxRange)
        {
            this.DayType = DayType;
            this.Probability = Probability;
            this.CummProbability = CummProbability;
            this.MinRange = MinRange;
            this.MaxRange = MaxRange;
        }

        public Enums.DayType DayType { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }





    }
}

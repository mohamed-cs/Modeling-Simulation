using NewspaperSellerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Form4 : Form
    {
        SimulationSystem system;

        public Form4()
        {
            InitializeComponent();
        }
        public Form4(SimulationSystem sys)
        {
            InitializeComponent();
            this.system = new SimulationSystem();
            this.system = sys;
        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            label5.Text = this.system.PerformanceMeasures.TotalSalesProfit.ToString();
            label6.Text = this.system.PerformanceMeasures.TotalCost.ToString();
            label7.Text = this.system.PerformanceMeasures.TotalLostProfit.ToString();
            label9.Text = this.system.PerformanceMeasures.TotalScrapProfit.ToString();
            label11.Text = this.system.PerformanceMeasures.TotalNetProfit.ToString();
            label13.Text = this.system.PerformanceMeasures.DaysWithMoreDemand.ToString();
            label15.Text = this.system.PerformanceMeasures.DaysWithUnsoldPapers.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(this.system);
            form2.ShowDialog();
            this.Close();
        }
    }
}

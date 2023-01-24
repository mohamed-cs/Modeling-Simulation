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
    public partial class Form3 : Form
    {
        SimulationSystem system;

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(SimulationSystem sys)
        {
            InitializeComponent();
            this.system = sys;

        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }


        private void Form3_Load(object sender, EventArgs e)
        {
            
            

            for (int i =0; i<this.system.SimulationTable.Count;i++)
            {
                dataGridView1.Rows.Add(this.system.SimulationTable[i].DayNo, this.system.SimulationTable[i].RandomNewsDayType, this.system.SimulationTable[i].NewsDayType, this.system.SimulationTable[i].RandomDemand, this.system.SimulationTable[i].Demand, this.system.SimulationTable[i].SalesProfit, this.system.SimulationTable[i].LostProfit, this.system.SimulationTable[i].ScrapProfit, this.system.SimulationTable[i].DailyNetProfit);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 form2 = new Form2(this.system);
            form2.ShowDialog();
            this.Close();
        }
    }
}

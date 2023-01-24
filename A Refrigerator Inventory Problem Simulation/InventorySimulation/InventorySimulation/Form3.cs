using InventoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySimulation
{
    public partial class Form3 : Form
    {
        List<SimulationCase> cases { get; set; }
        PerformanceMeasures performance { get; set; }
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(List<SimulationCase> cases, PerformanceMeasures performance)
        {
            InitializeComponent();
            this.performance = performance;
            this.cases = cases;

        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }


        private void Form3_Load(object sender, EventArgs e)
        {
            
            

            for (int i =0; i<cases.Count;i++)
            {
                dataGridView1.Rows.Add(cases[i].Day, cases[i].Cycle, cases[i].DayWithinCycle, cases[i].BeginningInventory, cases[i].RandomDemand, cases[i].Demand, cases[i].EndingInventory, cases[i].ShortageQuantity, cases[i].OrderQuantity, cases[i].RandomLeadDays, cases[i].LeadDays);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 form2 = new Form2(cases,performance);
            form2.ShowDialog();
            this.Close();
        }



        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form4 : Form
    {
        List<SimulationCase> cases { get; set; }
        PerformanceMeasures performance { get; set; }

        public Form4()
        {
            InitializeComponent();
        }
        public Form4(List<SimulationCase> cases, PerformanceMeasures performance)
        {
            InitializeComponent();
            this.cases = cases;
            this.performance = performance;
        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            label5.Text = performance.EndingInventoryAverage.ToString();
            label6.Text = performance.ShortageQuantityAverage.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(cases,performance);
            form2.ShowDialog();
            this.Close();
        }
    }
}

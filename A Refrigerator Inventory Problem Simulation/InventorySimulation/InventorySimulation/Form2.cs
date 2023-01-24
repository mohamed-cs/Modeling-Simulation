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
    
    public partial class Form2 : Form
    {
        List<SimulationCase> cases { get; set; }

        PerformanceMeasures performance { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(List<SimulationCase> cases , PerformanceMeasures performance)
        {
            InitializeComponent();
            this.cases=cases;
            this.performance = performance;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form3 form3 = new Form3(this.cases,performance);
            form3.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4(cases,this.performance);
            form4.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           Form1 form = new Form1();
           form.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

      
    }
}

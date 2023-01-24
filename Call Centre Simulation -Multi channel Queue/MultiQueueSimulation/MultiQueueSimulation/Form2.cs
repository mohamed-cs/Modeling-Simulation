using MultiQueueModels;
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
    
    public partial class Form2 : Form
    {
        List<SimulationCase> cases = new List<SimulationCase>();
        PerformanceMeasures performance = new PerformanceMeasures();
        List<Performance_server> serv_per = new List<Performance_server>();

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(List<SimulationCase> caseess,PerformanceMeasures per,List<Performance_server> serv_per)
        {
            InitializeComponent();
            cases = caseess;
            performance = per;
            this.serv_per = serv_per;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form3 form3 = new Form3(cases);
            form3.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4(performance);
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5(serv_per);
            form5.ShowDialog();
            this.Close();
        }
    }
}

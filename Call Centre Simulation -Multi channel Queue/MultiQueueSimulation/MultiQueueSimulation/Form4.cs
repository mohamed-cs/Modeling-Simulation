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
    public partial class Form4 : Form
    {
        PerformanceMeasures performance = new PerformanceMeasures();

        public Form4()
        {
            InitializeComponent();
        }
        public Form4(PerformanceMeasures per)
        {
            InitializeComponent();
            performance = per;
        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            label5.Text = performance.AverageWaitingTime.ToString();
            label6.Text = performance.MaxQueueLength.ToString();
            label7.Text = performance.WaitingProbability.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
    }
}

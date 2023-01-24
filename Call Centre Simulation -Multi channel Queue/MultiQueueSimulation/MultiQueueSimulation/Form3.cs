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
    public partial class Form3 : Form
    {
        List<SimulationCase> cases = new List<SimulationCase>();
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(List<SimulationCase> caseess)
        {
            cases = caseess;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form3_Load(object sender, EventArgs e)
        {
            for(int i =0; i<cases.Count;i++)
            {
                dataGridView1.Rows.Add(cases[i].CustomerNumber, cases[i].RandomInterArrival, cases[i].InterArrival, cases[i].ArrivalTime, cases[i].RandomService, cases[i].ServiceTime, cases[i].AssignedServer.ID, cases[i].StartTime, cases[i].EndTime, cases[i].TimeInQueue);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
    }
}

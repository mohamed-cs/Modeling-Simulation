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
    public partial class Form5 : Form
    {
        List<Performance_server> serv_pers = new List<Performance_server>();

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(List<Performance_server> pers)
        {
            InitializeComponent();
            serv_pers = pers;

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            for(int i=0;i<serv_pers.Count;i++)
            {
                dataGridView1.Rows.Add(serv_pers[i].ID, serv_pers[i].IdleProbability, serv_pers[i].AverageServiceTime, serv_pers[i].Utilization);
            }
        }
    }
}

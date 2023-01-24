using NewspaperSellerModels;
using NewspaperSellerTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MultiQueueSimulation
{

    public partial class Form1 : Form
    {   

        public string path { get; set; }
        public SimulationSystem system { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog v1 = new OpenFileDialog();
            v1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (v1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = v1.FileName;
                this.path = v1.FileName;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.system = new SimulationSystem();
            this.system = new SimulationSystem(this.path);

 
            MessageBox.Show("Data read successfulyy");


            char test_id = this.path[this.path.Length - 5];

            if (test_id == '1')
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);

            }
            else if (test_id == '2')
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);

            }
            else if (test_id == '3')
            {
                string result = TestingManager.Test(system, Constants.FileNames.TestCase3);
                MessageBox.Show(result);

            }


            this.Hide();

            Form2 form2 = new Form2(system);
            
            form2.ShowDialog();
            
            this.Close();



        }
    }
}

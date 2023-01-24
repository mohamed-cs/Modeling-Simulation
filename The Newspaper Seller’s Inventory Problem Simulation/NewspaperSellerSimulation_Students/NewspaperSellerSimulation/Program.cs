using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueSimulation;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           // String path = "C:\\Users\\moham\\OneDrive\\Desktop\\NewspaperSellerSimulation_Students\\NewspaperSellerSimulation_Students\\NewspaperSellerSimulation\\TestCases\\TestCase1.txt";
            //SimulationSystem system = new SimulationSystem(path);
            


            //string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
           
           // MessageBox.Show(result);
        }
    }
}

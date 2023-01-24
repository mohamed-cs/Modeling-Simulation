namespace LCG_Task
{
    public partial class Form1 : Form
    {

        int multiplier;
        uint seed;
        int increment;
        int modlues;
        int num_iterations;

        uint cycle_start;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public uint lcg()
        {
            uint rand = 0;

            uint eq= (uint)((this.multiplier * this.seed) + this.increment);
            rand = ((uint)(eq % this.modlues));
            this.seed = rand;

            return rand;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            multiplier =Int32.Parse(this.textBox1.Text);
            seed = (uint)(Int32.Parse(this.textBox2.Text));
            increment = Int32.Parse(this.textBox3.Text);
            modlues = Int32.Parse(this.textBox4.Text);
            num_iterations = Int32.Parse(this.textBox5.Text);


            int j = 0;

            for (int i=0;i<this.num_iterations;i++)
            {
                uint rand = lcg(); ;
                dataGridView1.Rows.Add(rand.ToString());
                if (i==0)
                {
                    cycle_start = rand;
                }

                if (rand == cycle_start && j ==0 && i !=0)
                {
                    this.label7.Text = i.ToString();
                    j += 1;

                }

            }

            if (j !=1)
            {
                this.label7.Text = actual_peroid_length().ToString();
            }
            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.seed = 0;
            this.multiplier = 0;
            this.num_iterations = 0;
            this.modlues = 0;
            this.increment = 0;
            this.label7.Text = "";

        }
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        public bool powerOfTwo(int n)
        {
            if (n == 0) { return false; }
            while (n != 1)
            {
                n = n / 2;
                if (n % 2 != 0 && n != 1) { return false; }
            }
            return true;
        }

        public int actual_peroid_length()
        {
            int k = (this.modlues - 1);

            if (powerOfTwo(this.modlues) && this.increment != 0 &&
                relative(this.increment, this.modlues) && ((this.multiplier) == (4*k+1)))
            {
                return this.modlues;
            }
            else if (powerOfTwo(this.modlues) && this.increment == 0 && ((this.multiplier == 3 + (8 * k) || (this.multiplier == 5 + (8 * k)))))
            {
                return (int)this.modlues / 4;
            }
            else if (IsPrime(this.modlues) && this.increment == 0 && ((Math.Pow(this.multiplier, k) - 1) % this.modlues == 0))
            {
                return this.modlues - 1;
            }
            return 0;

        }


        public int gcd(int a,int b)
        {
            int t;
            while (b!=0)
            {
                t = a;
                a = b;
                a = t % b;

            }
            return a;
        }

        public bool relative(int a,int b)
        {
            return this.gcd(a, b) == 1;
        }


    }
}
namespace MultiQueueSimulation
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Customer_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random_interarrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interarrival_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random_servicetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service_duraton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.server_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeservice_begin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeservice_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delay_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Data";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customer_No,
            this.Random_interarrival,
            this.Interarrival_time,
            this.Arrival_Time,
            this.Random_servicetime,
            this.Service_duraton,
            this.server_index,
            this.timeservice_begin,
            this.timeservice_end,
            this.delay_time});
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 331);
            this.dataGridView1.TabIndex = 3;
            // 
            // Customer_No
            // 
            this.Customer_No.HeaderText = "Customer_No";
            this.Customer_No.Name = "Customer_No";
            // 
            // Random_interarrival
            // 
            this.Random_interarrival.HeaderText = "Random_interarrival";
            this.Random_interarrival.Name = "Random_interarrival";
            // 
            // Interarrival_time
            // 
            this.Interarrival_time.HeaderText = "Interarrival_time";
            this.Interarrival_time.Name = "Interarrival_time";
            // 
            // Arrival_Time
            // 
            this.Arrival_Time.HeaderText = "Arrival_Time";
            this.Arrival_Time.Name = "Arrival_Time";
            // 
            // Random_servicetime
            // 
            this.Random_servicetime.HeaderText = "Random_servicetime";
            this.Random_servicetime.Name = "Random_servicetime";
            // 
            // Service_duraton
            // 
            this.Service_duraton.HeaderText = "Service_duraton";
            this.Service_duraton.Name = "Service_duraton";
            // 
            // server_index
            // 
            this.server_index.HeaderText = "server_index";
            this.server_index.Name = "server_index";
            // 
            // timeservice_begin
            // 
            this.timeservice_begin.HeaderText = "timeservice_begin";
            this.timeservice_begin.Name = "timeservice_begin";
            // 
            // timeservice_end
            // 
            this.timeservice_end.HeaderText = "timeservice_end";
            this.timeservice_end.Name = "timeservice_end";
            // 
            // delay_time
            // 
            this.delay_time.HeaderText = "delay_time";
            this.delay_time.Name = "delay_time";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(647, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 398);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random_interarrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interarrival_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random_servicetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service_duraton;
        private System.Windows.Forms.DataGridViewTextBoxColumn server_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeservice_begin;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeservice_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn delay_time;
        private System.Windows.Forms.Button button1;
    }
}
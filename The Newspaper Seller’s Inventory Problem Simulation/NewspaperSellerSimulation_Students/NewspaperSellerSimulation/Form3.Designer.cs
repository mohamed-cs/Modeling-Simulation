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
            this.Day_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random_N_For_day_types = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random_N_For_Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lost_Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salvage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daily_Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Day_Index,
            this.Random_N_For_day_types,
            this.Day_Type,
            this.Random_N_For_Demand,
            this.Demand,
            this.Revenue,
            this.Lost_Profit,
            this.Salvage,
            this.Daily_Profit});
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 331);
            this.dataGridView1.TabIndex = 3;
            // 
            // Day_Index
            // 
            this.Day_Index.HeaderText = "Day Index";
            this.Day_Index.Name = "Day_Index";
            // 
            // Random_N_For_day_types
            // 
            this.Random_N_For_day_types.HeaderText = "Random_N_For_day_types";
            this.Random_N_For_day_types.Name = "Random_N_For_day_types";
            // 
            // Day_Type
            // 
            this.Day_Type.HeaderText = "Day_Type";
            this.Day_Type.Name = "Day_Type";
            // 
            // Random_N_For_Demand
            // 
            this.Random_N_For_Demand.HeaderText = "Random_N_For_Demand";
            this.Random_N_For_Demand.Name = "Random_N_For_Demand";
            // 
            // Demand
            // 
            this.Demand.HeaderText = "Demand";
            this.Demand.Name = "Demand";
            // 
            // Revenue
            // 
            this.Revenue.HeaderText = "Revenue";
            this.Revenue.Name = "Revenue";
            // 
            // Lost_Profit
            // 
            this.Lost_Profit.HeaderText = "Lost_Profit";
            this.Lost_Profit.Name = "Lost_Profit";
            // 
            // Salvage
            // 
            this.Salvage.HeaderText = "Salvage";
            this.Salvage.Name = "Salvage";
            // 
            // Daily_Profit
            // 
            this.Daily_Profit.HeaderText = "Daily_Profit";
            this.Daily_Profit.Name = "Daily_Profit";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random_N_For_day_types;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random_N_For_Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lost_Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salvage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daily_Profit;
    }
}
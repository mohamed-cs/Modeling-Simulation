namespace InventorySimulation
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day_within_cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beginning_Inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random_Digit_for_Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ending_Inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shortage_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Random_Digitfor_Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lead_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days_until_Order_arrives = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Day,
            this.Cycle,
            this.Day_within_cycle,
            this.Beginning_Inventory,
            this.Random_Digit_for_Demand,
            this.Demand,
            this.Ending_Inventory,
            this.Shortage_Quantity,
            this.Order_Quantity,
            this.Random_Digitfor_Demand,
            this.Lead_Time,
            this.Days_until_Order_arrives});
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 331);
            this.dataGridView1.TabIndex = 3;
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
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            // 
            // Cycle
            // 
            this.Cycle.HeaderText = "Cycle";
            this.Cycle.Name = "Cycle";
            // 
            // Day_within_cycle
            // 
            this.Day_within_cycle.HeaderText = "Day_within_cycle";
            this.Day_within_cycle.Name = "Day_within_cycle";
            // 
            // Beginning_Inventory
            // 
            this.Beginning_Inventory.HeaderText = "Beginning_Inventory";
            this.Beginning_Inventory.Name = "Beginning_Inventory";
            // 
            // Random_Digit_for_Demand
            // 
            this.Random_Digit_for_Demand.HeaderText = "Random_Digit_for_Demand";
            this.Random_Digit_for_Demand.Name = "Random_Digit_for_Demand";
            // 
            // Demand
            // 
            this.Demand.HeaderText = "Demand";
            this.Demand.Name = "Demand";
            // 
            // Ending_Inventory
            // 
            this.Ending_Inventory.HeaderText = "Ending_Inventory";
            this.Ending_Inventory.Name = "Ending_Inventory";
            // 
            // Shortage_Quantity
            // 
            this.Shortage_Quantity.HeaderText = "Shortage_Quantity";
            this.Shortage_Quantity.Name = "Shortage_Quantity";
            // 
            // Order_Quantity
            // 
            this.Order_Quantity.HeaderText = "Order_Quantity";
            this.Order_Quantity.Name = "Order_Quantity";
            // 
            // Random_Digitfor_Demand
            // 
            this.Random_Digitfor_Demand.HeaderText = "Random_Digitfor_Demand";
            this.Random_Digitfor_Demand.Name = "Random_Digitfor_Demand";
            // 
            // Lead_Time
            // 
            this.Lead_Time.HeaderText = "Lead_Time";
            this.Lead_Time.Name = "Lead_Time";
            // 
            // Days_until_Order_arrives
            // 
            this.Days_until_Order_arrives.HeaderText = "Days_until_Order_arrives";
            this.Days_until_Order_arrives.Name = "Days_until_Order_arrives";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day_within_cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beginning_Inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random_Digit_for_Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ending_Inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shortage_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random_Digitfor_Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lead_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days_until_Order_arrives;
    }
}
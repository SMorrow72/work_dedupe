namespace IDDedup
{
    partial class ItemsReturned
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
            this.sourceLbl = new System.Windows.Forms.Label();
            this.sourceDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.targetLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLbl.Location = new System.Drawing.Point(12, 5);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(76, 24);
            this.sourceLbl.TabIndex = 0;
            this.sourceLbl.Text = "Source:";
            // 
            // sourceDataGrid
            // 
            this.sourceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sourceDataGrid.Location = new System.Drawing.Point(16, 32);
            this.sourceDataGrid.Name = "sourceDataGrid";
            this.sourceDataGrid.Size = new System.Drawing.Size(822, 251);
            this.sourceDataGrid.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(822, 258);
            this.dataGridView1.TabIndex = 2;
            // 
            // targetLbl
            // 
            this.targetLbl.AutoSize = true;
            this.targetLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetLbl.Location = new System.Drawing.Point(12, 286);
            this.targetLbl.Name = "targetLbl";
            this.targetLbl.Size = new System.Drawing.Size(69, 24);
            this.targetLbl.TabIndex = 3;
            this.targetLbl.Text = "Target:";
            // 
            // ItemsReturned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 583);
            this.Controls.Add(this.targetLbl);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sourceDataGrid);
            this.Controls.Add(this.sourceLbl);
            this.Name = "ItemsReturned";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sourceDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sourceLbl;
        private System.Windows.Forms.DataGridView sourceDataGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label targetLbl;
    }
}


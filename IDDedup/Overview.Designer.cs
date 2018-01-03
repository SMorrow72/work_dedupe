namespace IDDedup
{
    partial class Overview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.srcLbl = new System.Windows.Forms.Label();
            this.srcIdTxtBox = new System.Windows.Forms.TextBox();
            this.tgtLbl = new System.Windows.Forms.Label();
            this.tgtIdTxtBox = new System.Windows.Forms.TextBox();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.dgvTarget = new System.Windows.Forms.DataGridView();
            this.searchBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentTableLabel = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.comboSearchBtn = new System.Windows.Forms.Button();
            this.labelSrc = new System.Windows.Forms.Label();
            this.labelTgt = new System.Windows.Forms.Label();
            this.dgvListSrc = new System.Windows.Forms.DataGridView();
            this.dgvListTgt = new System.Windows.Forms.DataGridView();
            this.delBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.viewDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.allVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTgt2 = new System.Windows.Forms.Label();
            this.labelSrc2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarget)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTgt)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // srcLbl
            // 
            this.srcLbl.AutoSize = true;
            this.srcLbl.Location = new System.Drawing.Point(13, 38);
            this.srcLbl.Name = "srcLbl";
            this.srcLbl.Size = new System.Drawing.Size(58, 13);
            this.srcLbl.TabIndex = 0;
            this.srcLbl.Text = "Source ID:";
            // 
            // srcIdTxtBox
            // 
            this.srcIdTxtBox.Location = new System.Drawing.Point(77, 35);
            this.srcIdTxtBox.Name = "srcIdTxtBox";
            this.srcIdTxtBox.Size = new System.Drawing.Size(100, 20);
            this.srcIdTxtBox.TabIndex = 1;
            // 
            // tgtLbl
            // 
            this.tgtLbl.AutoSize = true;
            this.tgtLbl.Location = new System.Drawing.Point(194, 38);
            this.tgtLbl.Name = "tgtLbl";
            this.tgtLbl.Size = new System.Drawing.Size(55, 13);
            this.tgtLbl.TabIndex = 2;
            this.tgtLbl.Text = "Target ID:";
            // 
            // tgtIdTxtBox
            // 
            this.tgtIdTxtBox.Location = new System.Drawing.Point(256, 35);
            this.tgtIdTxtBox.Name = "tgtIdTxtBox";
            this.tgtIdTxtBox.Size = new System.Drawing.Size(100, 20);
            this.tgtIdTxtBox.TabIndex = 3;
            // 
            // dgvSource
            // 
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Location = new System.Drawing.Point(770, 82);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSource.Size = new System.Drawing.Size(720, 313);
            this.dgvSource.TabIndex = 4;
            this.dgvSource.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSource_DataError);
            // 
            // dgvTarget
            // 
            this.dgvTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarget.Location = new System.Drawing.Point(770, 417);
            this.dgvTarget.Name = "dgvTarget";
            this.dgvTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarget.Size = new System.Drawing.Size(720, 313);
            this.dgvTarget.TabIndex = 5;
            this.dgvTarget.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTarget_DataError);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(376, 33);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(89, 23);
            this.searchBtn.TabIndex = 8;
            this.searchBtn.Text = "Deep Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 741);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1506, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // currentTableLabel
            // 
            this.currentTableLabel.AutoSize = true;
            this.currentTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTableLabel.Location = new System.Drawing.Point(770, 35);
            this.currentTableLabel.Name = "currentTableLabel";
            this.currentTableLabel.Size = new System.Drawing.Size(0, 17);
            this.currentTableLabel.TabIndex = 10;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(486, 82);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(272, 648);
            this.treeView.TabIndex = 11;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // comboSearchBtn
            // 
            this.comboSearchBtn.Location = new System.Drawing.Point(482, 33);
            this.comboSearchBtn.Name = "comboSearchBtn";
            this.comboSearchBtn.Size = new System.Drawing.Size(89, 23);
            this.comboSearchBtn.TabIndex = 12;
            this.comboSearchBtn.Text = "Combo Search";
            this.comboSearchBtn.UseVisualStyleBackColor = true;
            this.comboSearchBtn.Click += new System.EventHandler(this.comboSearchBtn_Click);
            // 
            // labelSrc
            // 
            this.labelSrc.AutoSize = true;
            this.labelSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSrc.Location = new System.Drawing.Point(12, 62);
            this.labelSrc.Name = "labelSrc";
            this.labelSrc.Size = new System.Drawing.Size(57, 17);
            this.labelSrc.TabIndex = 15;
            this.labelSrc.Text = "Source:";
            // 
            // labelTgt
            // 
            this.labelTgt.AutoSize = true;
            this.labelTgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTgt.Location = new System.Drawing.Point(9, 397);
            this.labelTgt.Name = "labelTgt";
            this.labelTgt.Size = new System.Drawing.Size(54, 17);
            this.labelTgt.TabIndex = 16;
            this.labelTgt.Text = "Target:";
            // 
            // dgvListSrc
            // 
            this.dgvListSrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListSrc.Location = new System.Drawing.Point(12, 82);
            this.dgvListSrc.Name = "dgvListSrc";
            this.dgvListSrc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListSrc.Size = new System.Drawing.Size(460, 313);
            this.dgvListSrc.TabIndex = 17;
            this.dgvListSrc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListSrc_CellClick);
            // 
            // dgvListTgt
            // 
            this.dgvListTgt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTgt.Location = new System.Drawing.Point(12, 417);
            this.dgvListTgt.Name = "dgvListTgt";
            this.dgvListTgt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListTgt.Size = new System.Drawing.Size(460, 313);
            this.dgvListTgt.TabIndex = 18;
            this.dgvListTgt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTgt_CellClick);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(598, 33);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 19;
            this.delBtn.Text = "Delete";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(683, 33);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 20;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDropDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1506, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // viewDropDown
            // 
            this.viewDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allVisibleToolStripMenuItem,
            this.treeOnlyToolStripMenuItem,
            this.listBoxOnlyToolStripMenuItem});
            this.viewDropDown.Image = ((System.Drawing.Image)(resources.GetObject("viewDropDown.Image")));
            this.viewDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewDropDown.Name = "viewDropDown";
            this.viewDropDown.Size = new System.Drawing.Size(29, 22);
            this.viewDropDown.Text = "View";
            // 
            // allVisibleToolStripMenuItem
            // 
            this.allVisibleToolStripMenuItem.Name = "allVisibleToolStripMenuItem";
            this.allVisibleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allVisibleToolStripMenuItem.Text = "All Visible";
            this.allVisibleToolStripMenuItem.Click += new System.EventHandler(this.allVisibleToolStripMenuItem_Click);
            // 
            // treeOnlyToolStripMenuItem
            // 
            this.treeOnlyToolStripMenuItem.Name = "treeOnlyToolStripMenuItem";
            this.treeOnlyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.treeOnlyToolStripMenuItem.Text = "Tree Only";
            this.treeOnlyToolStripMenuItem.Click += new System.EventHandler(this.treeOnlyToolStripMenuItem_Click);
            // 
            // listBoxOnlyToolStripMenuItem
            // 
            this.listBoxOnlyToolStripMenuItem.Name = "listBoxOnlyToolStripMenuItem";
            this.listBoxOnlyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.listBoxOnlyToolStripMenuItem.Text = "List Box Only";
            this.listBoxOnlyToolStripMenuItem.Click += new System.EventHandler(this.listBoxOnlyToolStripMenuItem_Click);
            // 
            // labelTgt2
            // 
            this.labelTgt2.AutoSize = true;
            this.labelTgt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTgt2.Location = new System.Drawing.Point(770, 397);
            this.labelTgt2.Name = "labelTgt2";
            this.labelTgt2.Size = new System.Drawing.Size(54, 17);
            this.labelTgt2.TabIndex = 22;
            this.labelTgt2.Text = "Target:";
            // 
            // labelSrc2
            // 
            this.labelSrc2.AutoSize = true;
            this.labelSrc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSrc2.Location = new System.Drawing.Point(770, 62);
            this.labelSrc2.Name = "labelSrc2";
            this.labelSrc2.Size = new System.Drawing.Size(57, 17);
            this.labelSrc2.TabIndex = 23;
            this.labelSrc2.Text = "Source:";
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 763);
            this.Controls.Add(this.labelSrc2);
            this.Controls.Add(this.labelTgt2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.dgvListTgt);
            this.Controls.Add(this.dgvListSrc);
            this.Controls.Add(this.labelTgt);
            this.Controls.Add(this.labelSrc);
            this.Controls.Add(this.comboSearchBtn);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.currentTableLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.dgvTarget);
            this.Controls.Add(this.dgvSource);
            this.Controls.Add(this.tgtIdTxtBox);
            this.Controls.Add(this.tgtLbl);
            this.Controls.Add(this.srcIdTxtBox);
            this.Controls.Add(this.srcLbl);
            this.Name = "Overview";
            this.Text = "Overview";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarget)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTgt)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label srcLbl;
        private System.Windows.Forms.TextBox srcIdTxtBox;
        private System.Windows.Forms.Label tgtLbl;
        private System.Windows.Forms.TextBox tgtIdTxtBox;
        private System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.DataGridView dgvTarget;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label currentTableLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button comboSearchBtn;
        private System.Windows.Forms.Label labelSrc;
        private System.Windows.Forms.Label labelTgt;
        private System.Windows.Forms.DataGridView dgvListTgt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton viewDropDown;
        private System.Windows.Forms.ToolStripMenuItem allVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listBoxOnlyToolStripMenuItem;
        protected System.Windows.Forms.DataGridView dgvListSrc;
        private System.Windows.Forms.Label labelTgt2;
        private System.Windows.Forms.Label labelSrc2;
    }
}
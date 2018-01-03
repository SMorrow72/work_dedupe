using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LECOM;

namespace IDDedup
{
    public partial class Overview : Form
    {
        public SqlConnection conn;
        public Form _thisForm;
        public TreeNode _lastNodeClicked;
        public TreeNode _workingNode;
        public DataGridViewRow _lastRowClicked;
        public DataGridViewRow _workingRow;
        public string _lastObjectClicked;

        public Overview()
        {
            InitializeComponent();
            _thisForm = this;
            conn = this.WSqlConnection("ID Num Dedupe", "IT-SMORROW", "TmsEprd");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (srcIdTxtBox.TextLength == 7 && tgtIdTxtBox.TextLength == 7)
            {
                PopulateDataGridsDeepSearch();
                treeView.Visible = false;
                //Only show the related controls
                dgvSource.Location = new Point(486, 82);
                dgvTarget.Location = new Point(486, 417);
            }
            else
                MessageBox.Show("Error: ID Number(s) invalid! Please enter 7-digit numeric values only.");
            
        }

        private void comboSearchBtn_Click(object sender, EventArgs e)
        {
            if (srcIdTxtBox.TextLength == 7 && tgtIdTxtBox.TextLength == 7)
            {
                ChangeIDsAsc();

                treeView.Visible = true;
                PopulateListBoxes();
            }
            else 
                MessageBox.Show("Error: Id Numbers(s) invalid! Please enter 7-digit numeric values only.");
            
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (_lastObjectClicked != null)
            {
                _workingNode = _lastNodeClicked;
                DeleteRow();

                if (_lastObjectClicked == "Tree")
                    PopulateDataGridsTree();
                else if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                    PopulateDataGridsFromListBox();
            }
            else
                MessageBox.Show("Error: You must select an item from the Tree or List Box to delete.");
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateRow();

            if (_lastObjectClicked == "Tree")
                PopulateDataGridsTree();
            else if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                PopulateDataGridsFromListBox();
        }  

        private void allVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thisForm.Size = new System.Drawing.Size(1522, 802);

            dgvListSrc.Visible = true;
            dgvListSrc.Location = new Point(12, 82);

            dgvListTgt.Visible = true;
            dgvListTgt.Location = new Point(12, 417);

            labelSrc.Visible = true;
            labelSrc.Location = new Point(12, 62);

            labelTgt.Visible = true;
            labelTgt.Location = new Point(12, 397);

            treeView.Visible = true;
            treeView.Location = new Point(486, 82);
            
            //These controls are always visible
            labelSrc2.Location = new Point(770, 62);
            labelTgt2.Location = new Point(770, 397);
            dgvSource.Location = new Point(770, 82);
            dgvTarget.Location = new Point(770, 417);

            
        }

        private void treeOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thisForm.Size = new System.Drawing.Size(1050, 802);

            dgvListSrc.Visible = false;
            dgvListTgt.Visible = false;
            labelSrc.Visible = false;
            labelTgt.Visible = false;

            treeView.Visible = true;
            treeView.Location = new Point(12, 82);

            labelSrc2.Location = new Point(300, 62);
            labelTgt2.Location = new Point(300, 397);
            dgvSource.Location = new Point(300, 82);
            dgvTarget.Location = new Point(300, 417);
        }

        private void listBoxOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thisForm.Size = new System.Drawing.Size(1231, 802);

            dgvListSrc.Visible = true;
            dgvListSrc.Location = new Point(12, 82);

            dgvListTgt.Visible = true;
            dgvListTgt.Location = new Point(12, 417);

            labelSrc.Visible = true;
            labelSrc.Location = new Point(12, 62);

            labelTgt.Visible = true;
            labelTgt.Location = new Point(12, 397);

            treeView.Visible = false;

            labelSrc2.Location = new Point(486, 62);
            labelTgt2.Location = new Point(486, 397);
            dgvSource.Location = new Point(486, 82);
            dgvTarget.Location = new Point(486, 417);
        }   

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _lastNodeClicked = e.Node;
            _workingNode = e.Node;

            _lastObjectClicked = "Tree";

            PopulateDataGridsTree();
            currentTableLabel.Text = "Current Table: " + _workingNode.ToString();

            ButtonState(Enabled);

            //CheckSiteIDButtonState();
        }

        //Set listbox cell clicks to populate the big data grid views
        private void dgvListSrc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _lastRowClicked = dgvListSrc.CurrentRow;
            _workingRow = dgvListSrc.CurrentRow;
            _lastObjectClicked = "dgvListSrc";

            PopulateDataGridsFromListBox();
            currentTableLabel.Text = "Current Table: " + _workingRow.Cells[0].Value.ToString();
        }

        private void dgvListTgt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _lastRowClicked = dgvListTgt.CurrentRow;
            _workingRow = dgvListTgt.CurrentRow;
            _lastObjectClicked = "dgvListTgt";

            PopulateDataGridsFromListBox();
            currentTableLabel.Text = "Current Table: " + _workingRow.Cells[0].Value.ToString();
        }


        //This function uses the old procedure to populate the tree with rows
        //that have foreign key relationships
        private void ChangeIDsAsc()
        {
            using (new CursorWait())
            {
                //set the procedure name as the command
                string cmdText = "FIND_ID_NUM_ASC";

                //Set the Source ID number from its text box
                int IDNumSource;

                this.Cursor = Cursors.AppStarting;

                if (srcIdTxtBox.Text.Trim() == "")
                    IDNumSource = -1;
                else
                    IDNumSource = System.Convert.ToInt32(srcIdTxtBox.Text);

                //set parameters for the stored procedure
                var parms = new SqlParameters();
                parms.Add("id_num", IDNumSource, SqlDbType.Int);


                //execute stored procedure and store results in a table
                var dtResults = conn.FetchTable(cmdText, SQLTypes.StoredProcedure, parms);

                //clear both data grid views
                dgvSource.DataSource = null;
                dgvTarget.DataSource = null;

                treeView.BeginUpdate();

                treeView.Nodes.Clear();

                foreach (DataRow drResult in dtResults.Rows)
                {
                    

                    switch (DeleteLevel(drResult))
                    {
                        case "0":
                            Level0(drResult);
                            break;
                        case "1":
                            Level1(drResult);
                            break;
                        case "2":
                            Level2(drResult, dtResults);
                            break;
                        case "3":
                            Level3(drResult, dtResults);
                            break;
                        case "4":
                            Level4(drResult, dtResults);
                            break;
                        case "5":
                            Level5(drResult, dtResults);
                            break;
                    } //switch
                }//Results foreach

                this.Cursor = Cursors.Default;

                treeView.EndUpdate();
            }     
        }

        //searches both system and custom tables, based on tree
        private void PopulateDataGridsTree()
        {
            using (new CursorWait())
            {
                string cmdText = "select * from " + _workingNode.Text.Trim() + " where " + _workingNode.Name.Substring(0, _workingNode.Name.Length - 2).Trim() + " = @Value";
                int IDNumSource;
                int IDNumTarget;

                ToolStripUpdate("Validating IDs...");


                //validate and set both ID nums
                if (srcIdTxtBox.Text.Trim() == "")
                    IDNumSource = -1;
                else
                    IDNumSource = System.Convert.ToInt32(srcIdTxtBox.Text);

                if (tgtIdTxtBox.Text.Trim() == "")
                {
                    IDNumTarget = -1;
                    IDNumSource = -1;
                }
                else
                    IDNumTarget = System.Convert.ToInt32(tgtIdTxtBox.Text);

                Console.WriteLine("IDs Validated");


                ToolStripUpdate("Setting SQL Parameters...");


                //source params
                var parmsSrc = new SqlParameters();
                parmsSrc.Add("Value", IDNumSource, SqlDbType.Int);

                //target params
                var parmsTgt = new SqlParameters();
                parmsTgt.Add("Value", IDNumTarget, SqlDbType.Int);

                Console.WriteLine("SQL Parameters declared");

                //execute the command and populate the DGVs
                ToolStripUpdate("Searching for Source ID instances...");

                dgvSource.DataSource = conn.FetchTable(cmdText, SQLTypes.Text, parmsSrc);
                dgvSource.Refresh();
                Console.WriteLine("Source ID search complete!");

                ToolStripUpdate("Searching for Target ID instances...");
                
                dgvTarget.DataSource = conn.FetchTable(cmdText, SQLTypes.Text, parmsTgt);
                dgvTarget.Refresh();

                ToolStripUpdate("Search Complete!");

                if (dgvSource.Rows.Count > 0 || dgvTarget.Rows.Count > 0)
                {
                    labelSrc2.Text = "Source: " + dgvSource.Rows.Count.ToString() + " items";
                    labelTgt2.Text = "Target: " + dgvTarget.Rows.Count.ToString() + " items";
                }
            }
        }

        private void PopulateDataGridsFromListBox()
        {
            using (new CursorWait())
            {
                string tableName = "";
                string columnName = "";

                if (_lastObjectClicked == "dgvListSrc")
                {
                    tableName = dgvListSrc.CurrentRow.Cells[0].Value.ToString();
                    columnName = dgvListSrc.CurrentRow.Cells[1].Value.ToString();
                }
                else if (_lastObjectClicked == "dgvListTgt")
                {
                    tableName = dgvListTgt.CurrentRow.Cells[0].Value.ToString();
                    columnName = dgvListTgt.CurrentRow.Cells[1].Value.ToString();
                }

                string cmdText = "select * from " + tableName + " where " + columnName + " = @Value";
                int IDNumSource;
                int IDNumTarget;

                //validate and set both ID nums
                if (srcIdTxtBox.Text.Trim() == "")
                    IDNumSource = -1;
                else
                    IDNumSource = System.Convert.ToInt32(srcIdTxtBox.Text);

                if (tgtIdTxtBox.Text.Trim() == "")
                {
                    IDNumTarget = -1;
                    IDNumSource = -1;
                }
                else
                    IDNumTarget = System.Convert.ToInt32(tgtIdTxtBox.Text);

                Console.WriteLine("IDs Validated");


                ToolStripUpdate("Setting SQL Parameters...");


                //source params
                var parmsSrc = new SqlParameters();
                parmsSrc.Add("Value", IDNumSource, SqlDbType.Int);

                //target params
                var parmsTgt = new SqlParameters();
                parmsTgt.Add("Value", IDNumTarget, SqlDbType.Int);

                Console.WriteLine("SQL Parameters declared");

                //execute the command and populate the DGVs
                ToolStripUpdate("Searching for Source ID instances...");

                dgvSource.DataSource = conn.FetchTable(cmdText, SQLTypes.Text, parmsSrc);
                dgvSource.Refresh();
                Console.WriteLine("Source ID search complete!");

                ToolStripUpdate("Searching for Target ID instances...");

                dgvTarget.DataSource = conn.FetchTable(cmdText, SQLTypes.Text, parmsTgt);
                dgvTarget.Refresh();

                ToolStripUpdate("Search Complete!");


                if (dgvSource.Rows.Count > 0 || dgvTarget.Rows.Count > 0)
                {
                    labelSrc2.Text = "Source: " + dgvSource.Rows.Count.ToString() + " items";
                    labelTgt2.Text = "Target: " + dgvTarget.Rows.Count.ToString() + " items";
                }
            }            
        }

        //populate the data grids in the combined-source scenario
        //in which my ID search references custom tables only
        private void PopulateListBoxes()
        {
            using (new CursorWait())
            {
                string cmdText = "FindTablesWithID";
                int IDNumSource;
                int IDNumTarget;

                ToolStripUpdate("Validating IDs...");


                //validate and set both ID nums
                if (srcIdTxtBox.Text.Trim() == "")
                    IDNumSource = -1;
                else
                    IDNumSource = System.Convert.ToInt32(srcIdTxtBox.Text);

                if (tgtIdTxtBox.Text.Trim() == "")
                {
                    IDNumTarget = -1;
                    IDNumSource = -1;
                }
                else
                    IDNumTarget = System.Convert.ToInt32(tgtIdTxtBox.Text);
                Console.WriteLine("IDs Validated");

                ToolStripUpdate("Setting SQL Parameters...");

                //source params
                var parmsSrc = new SqlParameters();
                parmsSrc.Add("SearchStr", IDNumSource, SqlDbType.Int);
                parmsSrc.Add("CustomTablesOnly", 1, SqlDbType.Bit);

                //target params
                var parmsTgt = new SqlParameters();
                parmsTgt.Add("SearchStr", IDNumTarget, SqlDbType.Int);
                parmsTgt.Add("CustomTablesOnly", 1, SqlDbType.Bit);


                //execute the command and populate the DGVs
                ToolStripUpdate("Searching for Source ID instances...");

                dgvListSrc.DataSource = conn.FetchTable(cmdText, SQLTypes.StoredProcedure, parmsSrc);

                ToolStripUpdate("Searching for Target ID instances...");
                dgvListTgt.DataSource = conn.FetchTable(cmdText, SQLTypes.StoredProcedure, parmsTgt);

                ToolStripUpdate("Search Complete!");


                if (dgvListSrc.Rows.Count > 0 || dgvListTgt.Rows.Count > 0)
                {
                    labelSrc.Text = "Source:  " + dgvListSrc.Rows.Count.ToString() + " items";
                    labelSrc.Refresh();
                    labelTgt.Text = "Target: " + dgvListTgt.Rows.Count.ToString() + " items";
                    labelTgt.Refresh();
                }
            }
        }

        private void PopulateDataGridsDeepSearch()
        {
            using (new CursorWait())
            {
                string cmdText = "FindTablesWithID";
                int IDNumSource;
                int IDNumTarget;
                ToolStripUpdate("Validating IDs...");
                
                //validate and set both ID nums
                if (srcIdTxtBox.Text.Trim() == "")
                    IDNumSource = -1;
                else
                    IDNumSource = System.Convert.ToInt32(srcIdTxtBox.Text);

                if (tgtIdTxtBox.Text.Trim() == "")
                {
                    IDNumTarget = -1;
                    IDNumSource = -1;
                }
                else
                    IDNumTarget = System.Convert.ToInt32(tgtIdTxtBox.Text);
                Console.WriteLine("IDs Validated");

                ToolStripUpdate("Setting SQL Parameters...");

                //source params
                var parmsSrc = new SqlParameters();
                parmsSrc.Add("SearchStr", IDNumSource, SqlDbType.Int);
                parmsSrc.Add("CustomTablesOnly", 0, SqlDbType.Bit);

                //target params
                var parmsTgt = new SqlParameters();
                parmsTgt.Add("SearchStr", IDNumTarget, SqlDbType.Int);
                parmsTgt.Add("CustomTablesOnly", 0, SqlDbType.Bit);

                //execute the command and populate the DGVs
                ToolStripUpdate("Searching for Source ID instances...");

                dgvListSrc.DataSource = conn.FetchTable(cmdText, SQLTypes.StoredProcedure, parmsSrc);

                ToolStripUpdate("Searching for Target ID instances...");
                
                dgvListTgt.DataSource = conn.FetchTable(cmdText, SQLTypes.StoredProcedure, parmsTgt);

                ToolStripUpdate("Search Complete!");

                if (dgvListSrc.Rows.Count > 0 || dgvListTgt.Rows.Count > 0)
                {
                    labelSrc.Text = "Source:  " + dgvListSrc.Rows.Count.ToString() + " items";
                    labelSrc.Refresh();
                    labelTgt.Text = "Target: " + dgvListTgt.Rows.Count.ToString() + " items";
                    labelTgt.Refresh();
                }
            }           
        }

        private void DeleteRow()
        {
            using (new CursorWait())
            {
                try
                {
                    ToolStripUpdate("Deleting Item...");

                    string commandText = "select * from lecom_pk_tv(@table)";

                    var parms = new SqlParameters();

                    //set the table to query based on either a Tree Node or a dgv Row
                    if (_lastObjectClicked == "Tree")
                        parms = new SqlParameters(new object[,] { { "table", _workingNode.Text.Trim(), SqlDbType.VarChar } });
                    else if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                        parms = new SqlParameters(new object[,] { { "table", _workingRow.Cells[0].Value.ToString().Trim(), SqlDbType.VarChar } });

                    conn.BeginTransaction();

                    var dtPKColumns = conn.FetchTable(commandText, SQLTypes.Text, parms);

                    foreach (DataGridViewRow TheRow in dgvSource.SelectedRows)
                    {
                        string commandText2 = "";

                        if (_lastObjectClicked == "Tree")
                            commandText2 = "delete from " + _workingNode.Text.Trim() + " where";
                        else if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                            commandText2 = "delete from " + _workingRow.Cells[0].Value.ToString().Trim() + " where";

                        foreach (DataRow drPKColumn in dtPKColumns.Rows)
                        {
                            string PK = drPKColumn["column_name"].ToString().Trim();

                            if (commandText2.Trim().Right(5) == "where")
                                commandText2 = commandText2.Trim() + " " + PK + " = '" + TheRow.Cells[PK].Value + "'";
                            else
                                commandText2 = commandText2.Trim() + " and " + PK + " = '" + TheRow.Cells[PK].Value + "'";

                            Console.WriteLine(commandText2);
                        }
                        conn.Execute(commandText2, suppressErrorMessages: true);
                    }
                    if (conn.ErrorHandler.IsError){
                        conn.Rollback();
                        string exceptionMessage = conn.ErrorHandler.Exception.Message.Trim();
                        string exceptionMessageCust = "";

                        if (exceptionMessage.Contains("REFERENCE") || exceptionMessage.Contains("FOREIGN KEY"))
                            exceptionMessageCust = "Error: deleting this record conflicts with other records in the database. Consider deleting the record from subtables/listed tables of conflict before deleting this one. (You may need to use a primary key value other than ID_NUM)";
                        else if (exceptionMessage.Contains("Incorrect syntax near 'where'"))
                            exceptionMessageCust = "Error: The record you are trying to delete has no primary key to reference.";

                        MessageBox.Show(exceptionMessageCust + Environment.NewLine + " Full Exception: " + exceptionMessage + Environment.NewLine + "Command Text: " + conn.ErrorHandler.CommandText.ToString());
                    }
                        
                    else
                    {
                        conn.Commit();
                        ToolStripUpdate("Item Deleted!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }           
        }

        // Update the Target file with the source's values
        private void UpdateRow()
        {
            using (new CursorWait())
            {
                ToolStripUpdate("Updating Records...");

                string commandText = "select * from lecom_pk_tv(@Table)";
                var parms = new SqlParameters();

                if (_lastObjectClicked == "Tree")
                    parms = new SqlParameters(new object[,] { { "Table", _workingNode.Text.Trim(), SqlDbType.VarChar } });
                else if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                    parms = new SqlParameters(new object[,] { { "Table", _workingRow.Cells[0].Value.ToString().Trim(), SqlDbType.VarChar } });

                var dtResults = conn.FetchTable(commandText, SQLTypes.Text, parms);

                conn.BeginTransaction();

                foreach (DataGridViewRow TheRow in dgvSource.SelectedRows)
                {
                    string commandText2 = "";
                    string idField = "";

                    //Set the first part of the SQL Command
                    if (_lastObjectClicked == "Tree")
                    {
                        idField = IDFieldTree(_workingNode).Trim();
                        commandText2 = "update " + _workingNode.Text.Trim() + " set " + idField + " = " + tgtIdTxtBox.Text.Trim() + " where";
                    }      
                    else if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                    {
                        idField = IDFieldList(_workingRow);
                        commandText2 = "update " + _workingRow.Cells[0].Value.ToString().Trim() + " set " + idField + " = " + tgtIdTxtBox.Text.Trim() + " where";
                    }
                        
                    //Set the second part of the SQL command
                    if (dtResults.Rows.Count != 0)
                    {
                        foreach (DataRow drResults in dtResults.Rows)
                        {
                            if (commandText2.Trim().Right(5) == "where")
                                commandText2 = commandText2.Trim() + " " + drResults[0].ToString() + " = " + TheRow.Cells[drResults[0].ToString()].Value + "";
                            else
                                commandText2 = commandText2.Trim() + " and " + drResults[0].ToString() + " = '" + TheRow.Cells[drResults[0].ToString()].Value + "'";
                        }
                        conn.Execute(commandText2, suppressErrorMessages: true);
                    }

                        //When there is no Primary Key, use the default ID column 
                    //WARNING: THIS CHANGES ALL SOURCE RECORDS
                    else
                    {
                        if (_lastObjectClicked == "dgvListSrc" || _lastObjectClicked == "dgvListTgt")
                            commandText2 = commandText2.Trim() + " " + idField + " = " + dgvListSrc.SelectedRows[0].Cells[2].Value.ToString() + "";
                        //I honestly don't know how to do this with Tree last selected
                        else
                            MessageBox.Show("Error: no Primary Key present.");

                        DialogResult dr = MessageBox.Show("WARNING: This table does not have a defined primary key. This operation is based on the ID Number itself, which will result in updating all source records in this table. Continue?", "Warning: No Primary Key Present", MessageBoxButtons.OKCancel);
                        switch (dr)
                        {
                            case DialogResult.OK:
                                conn.Execute(commandText2, suppressErrorMessages: true);
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                    }

   
                }

                //Handle errors and make suggestions
                if (conn.ErrorHandler.IsError)
                {
                    conn.Rollback();
                    string exceptionMessage = conn.ErrorHandler.Exception.Message.Trim();
                    string exceptionMessageCust = "";

                    if (exceptionMessage.Contains("FOREIGN KEY constraint") || exceptionMessage.Contains("REFERENCE constraint"))
                        exceptionMessageCust = "Error: updating this record conflicts with other records in the database. Consider altering/deleting the conflicting record.";
                    else if (exceptionMessage.Contains("PRIMARY KEY constraint"))
                        exceptionMessageCust = "Error: a record with the same Primary Key already exists in the target table. You may not need to update this record.";


                    MessageBox.Show(exceptionMessageCust + Environment.NewLine + Environment.NewLine + "Full Exception: " + exceptionMessage + Environment.NewLine + Environment.NewLine + "Command Text: " + conn.ErrorHandler.CommandText.ToString());
                }
                    
                else
                {
                    conn.Commit();
                    ToolStripUpdate("Record Updated!");
                }
                    
            }
        }

        private void ToolStripUpdate(string message)
        {
            toolStripStatusLabel1.Text = message;
            statusStrip1.Refresh();
        }

        //Define dynamic strings
        private string DeleteLevel(DataRow dr)
        {
            return dr["DELETE_LEVEL"].ToString().Trim();
        }

        private string TableName(DataRow dr)
        {
            return dr["TABLE_NAME"].ToString().Trim();
        }

        private string ColumnName(DataRow dr)
        {
            return dr["COLUMN_NAME"].ToString().Trim();
        }

        private string ParentTableName(DataRow dr)
        {
            return dr["PARENT_TABLE_NAME"].ToString().Trim();
        }

        private string ParentColumnName(DataRow dr)
        {
            return dr["PARENT_COLUMN_NAME"].ToString().Trim();
        }

        //Define levels of the tree structure

        private void Level0(DataRow dr)
        {
            treeView.Nodes.Add(TableName(dr) + "." + ColumnName(dr) + ".0", TableName(dr));
        }

        private void Level1(DataRow dr)
        {
            int Parent1;

            Parent1 = treeView.Nodes.IndexOfKey(ParentTableName(dr) + "." + ParentColumnName(dr) + ".0");

            treeView.Nodes[Parent1].Nodes.Add(TableName(dr) + "." + ColumnName(dr) + ".1", TableName(dr));
        }

        private void Level2(DataRow dr, DataTable dt)
        {
            int Parent1;
            int Parent2;

            foreach (DataRow drChild1 in dt.Rows)
            {
                if (TableName(drChild1) == ParentTableName(dr) && DeleteLevel(drChild1) == "1")
                {
                    Parent1 = treeView.Nodes.IndexOfKey(ParentTableName(drChild1) + "." + ParentColumnName(drChild1) + ".0");
                    Parent2 = treeView.Nodes[Parent1].Nodes.IndexOfKey(ParentTableName(dr) + "." + ParentColumnName(dr) + ".1");

                    treeView.Nodes[Parent1].Nodes[Parent2].Nodes.Add(TableName(dr) + "." + ColumnName(dr) + ".2", TableName(dr));

                    break;
                }
            }
        }

        private void Level3(DataRow dr, DataTable dt)
        {
            int Parent1;
            int Parent2;
            int Parent3;

            foreach (DataRow drChild1 in dt.Rows)
            {
                if (TableName(drChild1) == ParentTableName(dr) && DeleteLevel(drChild1) == "2")
                {
                    foreach (DataRow drChild2 in dt.Rows)
                    {
                        if (TableName(drChild2) == ParentTableName(drChild1) && DeleteLevel(drChild2) == "1")
                        {
                            Parent1 = treeView.Nodes.IndexOfKey(ParentTableName(drChild2) + "." + ParentColumnName(drChild2) + ".0");
                            Parent2 = treeView.Nodes[Parent1].Nodes.IndexOfKey(ParentTableName(drChild1) + "." + ParentColumnName(drChild1) + ".1");
                            Parent3 = treeView.Nodes[Parent1].Nodes[Parent2].Nodes.IndexOfKey(ParentTableName(dr) + "." + ParentColumnName(dr) + ".2");

                            treeView.Nodes[Parent1].Nodes[Parent2].Nodes[Parent3].Nodes.Add(TableName(dr) + "." + ColumnName(dr) + ".3", TableName(dr));

                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void Level4(DataRow dr, DataTable dt)
        {
            int Parent1;
            int Parent2;
            int Parent3;
            int Parent4;

            foreach (DataRow drChild1 in dt.Rows)
            {
                if (TableName(drChild1) == ParentTableName(dr) && DeleteLevel(drChild1) == "3")
                {
                    foreach (DataRow drChild2 in dt.Rows)
                    {
                        if (TableName(drChild2) == ParentTableName(drChild1) && DeleteLevel(drChild2) == "2")
                        {
                            foreach (DataRow drChild3 in dt.Rows)
                            {
                                if (TableName(drChild3) == ParentTableName(drChild2) && DeleteLevel(drChild3) == "1")
                                {
                                    Parent1 = treeView.Nodes.IndexOfKey(ParentTableName(drChild3) + "." + ParentColumnName(drChild3) + ".0");
                                    Parent2 = treeView.Nodes[Parent1].Nodes.IndexOfKey(ParentTableName(drChild2) + "." + ParentColumnName(drChild2) + ".1");
                                    Parent3 = treeView.Nodes[Parent1].Nodes[Parent2].Nodes.IndexOfKey(ParentTableName(drChild1) + "." + ParentColumnName(drChild1) + ".2");
                                    Parent4 = treeView.Nodes[Parent1].Nodes[Parent2].Nodes[Parent3].Nodes.IndexOfKey(ParentTableName(dr) + "." + ParentColumnName(dr) + ".3");

                                    treeView.Nodes[Parent1].Nodes[Parent2].Nodes[Parent3].Nodes[Parent4].Nodes.Add(TableName(dr) + "." + ColumnName(dr) + ".4", TableName(dr));

                                    break;
                                } // Child3 if
                            } // Child3 foreach

                            break;
                        } // Child2 if
                    } // Child2 foreach

                    break;
                } // Child1 if
            } // Child1 foreach
        }

        private void Level5(DataRow dr, DataTable dt)
        {
            int Parent1;
            int Parent2;
            int Parent3;
            int Parent4;
            int Parent5;

            foreach (DataRow drChild1 in dt.Rows)
            {
                if (TableName(drChild1) == ParentTableName(dr) && DeleteLevel(drChild1) == "4")
                {
                    foreach (DataRow drChild2 in dt.Rows)
                    {
                        if (TableName(drChild2) == ParentTableName(drChild1) && DeleteLevel(drChild2) == "3")
                        {
                            foreach (DataRow drChild3 in dt.Rows)
                            {
                                if (TableName(drChild3) == ParentTableName(drChild2) && DeleteLevel(drChild3) == "2")
                                {
                                    foreach (DataRow drChild4 in dt.Rows)
                                    {
                                        if (TableName(drChild4) == ParentTableName(drChild3) && DeleteLevel(drChild4) == "1")
                                        {
                                            Parent1 = treeView.Nodes.IndexOfKey(ParentTableName(drChild4) + "." + ParentColumnName(drChild4) + ".0");
                                            Parent2 = treeView.Nodes[Parent1].Nodes.IndexOfKey(ParentTableName(drChild3) + "." + ParentColumnName(drChild3) + ".1");
                                            Parent3 = treeView.Nodes[Parent1].Nodes[Parent2].Nodes.IndexOfKey(ParentTableName(drChild2) + "." + ParentColumnName(drChild2) + ".2");
                                            Parent4 = treeView.Nodes[Parent1].Nodes[Parent2].Nodes[Parent3].Nodes.IndexOfKey(ParentTableName(drChild1) + "." + ParentColumnName(drChild1) + ".3");
                                            Parent5 = treeView.Nodes[Parent1].Nodes[Parent2].Nodes[Parent3].Nodes[Parent4].Nodes.IndexOfKey(ParentTableName(dr) + "." + ParentColumnName(dr) + ".4");

                                            treeView.Nodes[Parent1].Nodes[Parent2].Nodes[Parent3].Nodes[Parent4].Nodes[Parent5].Nodes.Add(TableName(dr) + "." + ColumnName(dr) + ".5", TableName(dr));

                                            break;
                                        } // Child4 if
                                    } // Child4 foreach

                                    break;
                                } // Child3 if
                            } // Child3 foreach

                            break;
                        } // Child2 if
                    } // Child2 foreach

                    break;
                } // Child1 if
            } // Child1 foreach
        }

        public string IDFieldTree(TreeNode TheNode)
        {
            string IDField;

            IDField = TheNode.Name.Trim().Right(TheNode.Name.Trim().Length - TheNode.Name.Trim().IndexOf("."));
            IDField = IDField.Substring(1, IDField.Length - 3);

            return IDField;
        }

        public string IDFieldList(DataGridViewRow TheRow)
        {
            string IDField;

            IDField = TheRow.Cells[1].Value.ToString();
            
            return IDField;
        }

        private void ButtonState(bool state)
        {
            comboSearchBtn.Enabled = state;
            searchBtn.Enabled = state;
        }

        private void dgvSource_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message != "Parameter is not valid.")
            {
                conn.ErrorHandler.GenerateError(e.Exception);
                conn.ErrorHandler.Handle();
            }
        }

        private void dgvTarget_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message != "Parameter is not valid.")
            {
                conn.ErrorHandler.GenerateError(e.Exception);
                conn.ErrorHandler.Handle();
            }
        }

        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                // Wait
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) Application.UseWaitCursor = true;
            }

            public void Dispose()
            {
                // Reset
                Cursor.Current = Cursors.Default;
                Application.UseWaitCursor = false;
            }
        }  
        
    }
}

using System;
using System.Windows.Forms;

namespace POPC_TRACEABILITY
{
    public partial class OpenProcessList : Form
    {
        public OpenProcessList()
        {
            InitializeComponent();
            DgvList.Columns.Add("clmOrderNumber","Order Number");
            DgvList.Columns.Add("clmProductReference", "Product Reference");
            DgvList.Columns.Add("clmStartDate", "Start Date");

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public string SelectedOrderNumber;
        public DataGridView DgvList;
        
        private Button _btnClose;
        private Button _btnLoadOrderNumber;
        private Label _label1;
        public bool LoadNew;
        private void OpenProcessList_Load(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadOrderNumber_Click(object sender, EventArgs e)
        {
            LoadNew = true;
            SelectedOrderNumber = DgvList.SelectedRows[0].Cells[0].Value.ToString();
            Close();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvList = new System.Windows.Forms.DataGridView();
            this._btnClose = new System.Windows.Forms.Button();
            this._btnLoadOrderNumber = new System.Windows.Forms.Button();
            this._label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.DgvList.Location = new System.Drawing.Point(12, 48);
            this.DgvList.MultiSelect = false;
            this.DgvList.Name = "DgvList";
            this.DgvList.ReadOnly = true;
            this.DgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvList.ShowEditingIcon = false;
            this.DgvList.Size = new System.Drawing.Size(663, 455);
            this.DgvList.TabIndex = 8;
            // 
            // _btnClose
            // 
            this._btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnClose.Location = new System.Drawing.Point(600, 509);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 53);
            this._btnClose.TabIndex = 6;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _btnLoadOrderNumber
            // 
            this._btnLoadOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnLoadOrderNumber.Location = new System.Drawing.Point(474, 509);
            this._btnLoadOrderNumber.Name = "_btnLoadOrderNumber";
            this._btnLoadOrderNumber.Size = new System.Drawing.Size(120, 53);
            this._btnLoadOrderNumber.TabIndex = 5;
            this._btnLoadOrderNumber.Text = "Load Order Number";
            this._btnLoadOrderNumber.UseVisualStyleBackColor = true;
            this._btnLoadOrderNumber.Visible = false;
            this._btnLoadOrderNumber.Click += new System.EventHandler(this.btnLoadOrderNumber_Click);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._label1.Location = new System.Drawing.Point(225, 9);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(218, 25);
            this._label1.TabIndex = 9;
            this._label1.Text = "Load Order Number";
            // 
            // OpenProcessList
            // 
            this.ClientSize = new System.Drawing.Size(687, 574);
            this.Controls.Add(this._label1);
            this.Controls.Add(this.DgvList);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnLoadOrderNumber);
            this.Name = "OpenProcessList";
            this.Load += new System.EventHandler(this.OpenProcessList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

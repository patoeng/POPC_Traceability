namespace POPC_TRACEABILITY
{
    partial class Setting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_ReadInterval = new System.Windows.Forms.TextBox();
            this.tb_PLCPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_PLCAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tb_ReadInterval);
            this.groupBox1.Controls.Add(this.tb_PLCPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_PLCAddress);
            this.groupBox1.Location = new System.Drawing.Point(42, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 139);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(462, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "ms";
            // 
            // tb_ReadInterval
            // 
            this.tb_ReadInterval.Location = new System.Drawing.Point(168, 89);
            this.tb_ReadInterval.Name = "tb_ReadInterval";
            this.tb_ReadInterval.Size = new System.Drawing.Size(291, 20);
            this.tb_ReadInterval.TabIndex = 3;
            // 
            // tb_PLCPort
            // 
            this.tb_PLCPort.Location = new System.Drawing.Point(168, 61);
            this.tb_PLCPort.Name = "tb_PLCPort";
            this.tb_PLCPort.Size = new System.Drawing.Size(291, 20);
            this.tb_PLCPort.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "READ INTERVAL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "IP ADDRESS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PLC PORT";
            // 
            // tb_PLCAddress
            // 
            this.tb_PLCAddress.Location = new System.Drawing.Point(168, 31);
            this.tb_PLCAddress.Name = "tb_PLCAddress";
            this.tb_PLCAddress.Size = new System.Drawing.Size(291, 20);
            this.tb_PLCAddress.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(188, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(237, 37);
            this.label10.TabIndex = 10;
            this.label10.Text = "PO PC Setting";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(515, 207);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 43);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(426, 207);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(75, 43);
            this.btn_Reload.TabIndex = 12;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 262);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_ReadInterval;
        private System.Windows.Forms.TextBox tb_PLCPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_PLCAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Reload;
    }
}
namespace POPC_TRACEABILITY
{
    partial class PLC
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_IpAddress = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.gb_Input = new System.Windows.Forms.GroupBox();
            this.chb_PoPcOk = new System.Windows.Forms.CheckBox();
            this.chb_PassButton = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chb_IndicatorLamp = new System.Windows.Forms.CheckBox();
            this.tmr_DisplayUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmr_Scanner = new System.Windows.Forms.Timer(this.components);
            this.chb_IndicatorLampGreen = new System.Windows.Forms.CheckBox();
            this.chb_IndicatorLampRed = new System.Windows.Forms.CheckBox();
            this.gb_Input.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address";
            // 
            // lbl_IpAddress
            // 
            this.lbl_IpAddress.AutoSize = true;
            this.lbl_IpAddress.Location = new System.Drawing.Point(87, 13);
            this.lbl_IpAddress.Name = "lbl_IpAddress";
            this.lbl_IpAddress.Size = new System.Drawing.Size(70, 13);
            this.lbl_IpAddress.TabIndex = 2;
            this.lbl_IpAddress.Text = "lbl_IpAddress";
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(163, 13);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(42, 13);
            this.lbl_Port.TabIndex = 3;
            this.lbl_Port.Text = "lbl_Port";
            // 
            // gb_Input
            // 
            this.gb_Input.Controls.Add(this.chb_PoPcOk);
            this.gb_Input.Controls.Add(this.chb_PassButton);
            this.gb_Input.Location = new System.Drawing.Point(22, 58);
            this.gb_Input.Name = "gb_Input";
            this.gb_Input.Size = new System.Drawing.Size(144, 116);
            this.gb_Input.TabIndex = 4;
            this.gb_Input.TabStop = false;
            this.gb_Input.Text = "INPUT";
            // 
            // chb_PoPcOk
            // 
            this.chb_PoPcOk.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_PoPcOk.AutoSize = true;
            this.chb_PoPcOk.Enabled = false;
            this.chb_PoPcOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_PoPcOk.Location = new System.Drawing.Point(33, 48);
            this.chb_PoPcOk.Name = "chb_PoPcOk";
            this.chb_PoPcOk.Size = new System.Drawing.Size(73, 23);
            this.chb_PoPcOk.TabIndex = 0;
            this.chb_PoPcOk.Text = "PO PC OK  ";
            this.chb_PoPcOk.UseVisualStyleBackColor = true;
            // 
            // chb_PassButton
            // 
            this.chb_PassButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_PassButton.AutoSize = true;
            this.chb_PassButton.Enabled = false;
            this.chb_PassButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_PassButton.Location = new System.Drawing.Point(33, 19);
            this.chb_PassButton.Name = "chb_PassButton";
            this.chb_PassButton.Size = new System.Drawing.Size(73, 23);
            this.chb_PassButton.TabIndex = 0;
            this.chb_PassButton.Text = "Start Button";
            this.chb_PassButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_IndicatorLampRed);
            this.groupBox1.Controls.Add(this.chb_IndicatorLampGreen);
            this.groupBox1.Controls.Add(this.chb_IndicatorLamp);
            this.groupBox1.Location = new System.Drawing.Point(189, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 116);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OUTPUT";
            // 
            // chb_IndicatorLamp
            // 
            this.chb_IndicatorLamp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_IndicatorLamp.AutoSize = true;
            this.chb_IndicatorLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_IndicatorLamp.Location = new System.Drawing.Point(16, 19);
            this.chb_IndicatorLamp.Name = "chb_IndicatorLamp";
            this.chb_IndicatorLamp.Size = new System.Drawing.Size(87, 23);
            this.chb_IndicatorLamp.TabIndex = 0;
            this.chb_IndicatorLamp.Text = "Indicator Lamp";
            this.chb_IndicatorLamp.UseVisualStyleBackColor = true;
            this.chb_IndicatorLamp.CheckedChanged += new System.EventHandler(this.chb_IndicatorLamp_CheckedChanged);
            // 
            // tmr_DisplayUpdate
            // 
            this.tmr_DisplayUpdate.Enabled = true;
            this.tmr_DisplayUpdate.Interval = 750;
            this.tmr_DisplayUpdate.Tick += new System.EventHandler(this.tmr_DisplayUpdate_Tick);
            // 
            // tmr_Scanner
            // 
            this.tmr_Scanner.Tick += new System.EventHandler(this.tmr_Scanner_Tick);
            // 
            // chb_IndicatorLampGreen
            // 
            this.chb_IndicatorLampGreen.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_IndicatorLampGreen.AutoSize = true;
            this.chb_IndicatorLampGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_IndicatorLampGreen.Location = new System.Drawing.Point(16, 48);
            this.chb_IndicatorLampGreen.Name = "chb_IndicatorLampGreen";
            this.chb_IndicatorLampGreen.Size = new System.Drawing.Size(75, 23);
            this.chb_IndicatorLampGreen.TabIndex = 0;
            this.chb_IndicatorLampGreen.Text = "Green Lamp";
            this.chb_IndicatorLampGreen.UseVisualStyleBackColor = true;
            this.chb_IndicatorLampGreen.CheckedChanged += new System.EventHandler(this.chb_IndicatorLampGreen_CheckedChanged);
            // 
            // chb_IndicatorLampRed
            // 
            this.chb_IndicatorLampRed.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_IndicatorLampRed.AutoSize = true;
            this.chb_IndicatorLampRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_IndicatorLampRed.Location = new System.Drawing.Point(16, 77);
            this.chb_IndicatorLampRed.Name = "chb_IndicatorLampRed";
            this.chb_IndicatorLampRed.Size = new System.Drawing.Size(66, 23);
            this.chb_IndicatorLampRed.TabIndex = 0;
            this.chb_IndicatorLampRed.Text = "Red Lamp";
            this.chb_IndicatorLampRed.UseVisualStyleBackColor = true;
            this.chb_IndicatorLampRed.CheckedChanged += new System.EventHandler(this.chb_IndicatorLampRed_CheckedChanged);
            // 
            // PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_Input);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.lbl_IpAddress);
            this.Controls.Add(this.label1);
            this.Name = "PLC";
            this.Text = "PLC";
            this.Load += new System.EventHandler(this.PLC_Load);
            this.VisibleChanged += new System.EventHandler(this.PLC_VisibleChanged);
            this.gb_Input.ResumeLayout(false);
            this.gb_Input.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_IpAddress;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.GroupBox gb_Input;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chb_PoPcOk;
        private System.Windows.Forms.CheckBox chb_PassButton;
        private System.Windows.Forms.CheckBox chb_IndicatorLamp;
        private System.Windows.Forms.Timer tmr_DisplayUpdate;
        private System.Windows.Forms.Timer tmr_Scanner;
        private System.Windows.Forms.CheckBox chb_IndicatorLampRed;
        private System.Windows.Forms.CheckBox chb_IndicatorLampGreen;
    }
}
﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ModbusTCP;

namespace POPC_TRACEABILITY
{
    public partial class Plc : Form
    {
        
        public Plc()
        {
            InitializeComponent();
            PlcInitialization();
        }
        public Plc(string ipAddress, ushort port, int interval)
        {
            InitializeComponent();
            IpAddress = ipAddress;
            PlcPort = port;
            ScannerInterval = interval;

            PlcInitialization();
        }
        public event NoParamDelegate DataUpdated;
        public event IntDelegate PoPcReadyForNewOrderNumber;
        public event IntDelegate OutputQtyChanged;
        public event IntDelegate RejectQtyChanged;
        public event PopcStateChanged PopcStateChangedEvent;


        private int[] _data;
        private Master _master;

        public string IpAddress { get; protected set; }
        public ushort PlcPort { get; protected set; }  
        public int ScannerInterval { get; protected set; }

        public bool PassPushButton { get; protected set; }
        public bool FailPushButton { get; protected set; }
        public bool PoPcTestOk { get; protected set; }
        public bool IndicatorLamp1 { get; protected set; }
        public bool IndicatorLampRed { get; protected set; }
        public bool IndicatorLampGreen { get; protected set; }

        public int PoPcNewOrderNumber { get; protected set; }
        public int QuantityOutput { get; protected set; }
        public int QuantityFail { get; protected set; }
        public int QuantityProccessable { get; protected set; }

        private PopcStates _popcStates;

        public PopcStates PopcStates
        {
            get { return _popcStates; }
            protected set
            {
                if (value != _popcStates)
                {
                    _popcStates = value;
                    PopcStateChangedEvent?.Invoke(_popcStates);
                }
            }
        }

        private readonly Color _onColor = Color.Yellow;
        private readonly Color _offColor = Color.YellowGreen;

        private void UpdateDisplay()
        {
            
            chb_PassButton.BackColor = PassPushButton ? _onColor : _offColor;
            chb_PoPcOk.BackColor = PoPcTestOk ? _onColor : _offColor;
            chb_IndicatorLamp.BackColor = IndicatorLamp1 ? _onColor : _offColor;
            chb_IndicatorLampGreen.BackColor = IndicatorLampGreen ? _onColor : _offColor;
            chb_IndicatorLampRed.BackColor = IndicatorLampRed ? _onColor : _offColor;
        }

        public void SetIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public void SetPlcPort(ushort port)
        {
            PlcPort = port;
        }

        public void SetScannerInterval(int scannerInterval)
        {
            ScannerInterval = scannerInterval;
        }
        private void PlcInitialization()
        {
            tmr_Scanner.Interval = ScannerInterval;
            lbl_IpAddress.Text = IpAddress;
            lbl_Port.Text = PlcPort.ToString();
            _master = new Master(IpAddress,PlcPort);
        }
        private void PLC_Load(object sender, EventArgs e)
        {
         
           
        }

        private void tmr_Scanner_Tick(object sender, EventArgs e)
        {
            tmr_Scanner.Stop();
            try
            {
                byte[] temp = { };
                PlcCommand.GetPlcRawData(_master, 25, ref temp);
                _data = ModbusTcpHelper.ByteArrayToWordArray(temp);
                MemoryMapping(_data);
                DataUpdated?.Invoke();
            }
            finally
            {
                tmr_Scanner.Start();
            }
        }

        private void MemoryMapping(int[] data)
        {
            PopcStates = (PopcStates) data[0];
            LoadPoPcNewOrderNumber(data[2]);
            LoadOutput(data[4]);
            LoadFail(data[6]);
            QuantityProccessable = data[8];
            InputOutputMapping(data[10]);
        }

        private void InputOutputMapping(int data)
        {
            PassPushButton = (data & 0x01) == 0x01;
            FailPushButton = (data>>1 & 0x01) == 0x01;
            PoPcTestOk = (data >> 2 & 0x01) == 0x01;
            IndicatorLamp1 = (data >> 3 & 0x01) == 0x01;
            IndicatorLampGreen = (data >> 4 & 0x01) == 0x01;
            IndicatorLampRed = (data >> 5 & 0x01) == 0x01;

        }

        private void LoadPoPcNewOrderNumber(int data)
        {
            if (PoPcNewOrderNumber != data )
            {
                PoPcNewOrderNumber = data;
                if (data >= 2)
                {
                    PoPcReadyForNewOrderNumber?.Invoke(data);
                }
            }
        }

        private void LoadOutput(int data)
        {
            if (QuantityOutput != data)
            {
                QuantityOutput = data;
                OutputQtyChanged?.Invoke(data);
               
            }
        }
        private void LoadFail(int data)
        {
            if (QuantityFail != data)
            {
                QuantityFail = data;
                RejectQtyChanged?.Invoke(data);

            }
        }
        public void StartTicker()
        {
            tmr_Scanner.Enabled = true;
        }

        public void StopTicker()
        {
            tmr_Scanner.Enabled = false;
        }

        public void SetPoPcNewOrderNumber()
        {
            PlcCommand.SetNewOrderNumber(_master);
        }
        public void ResetPoPcNewOrderNumber()
        {
            PlcCommand.ResetNewOrderNumber(_master);
        }
        public void ResetSequence()
        {
            PlcCommand.ResetSequence(_master);
        }

        public void SetPoPcState(PopcStates states)
        {
            PlcCommand.SetPoPcState(_master,states);
        }
        public void SetQuantityOutput(int value)
        {
            PlcCommand.SetOutputQty(_master,value);
        }
        public void SetQuantityReject(int value)
        {
            PlcCommand.SetNgQty(_master, value);
        }

        public void SetQuantityProcessable(int value)
        {
            PlcCommand.SetProcessableQty(_master,value);
        }

        private void tmr_DisplayUpdate_Tick(object sender, EventArgs e)
        {
            if (Visible) UpdateDisplay();
        }

        private void chb_IndicatorLamp_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommand.DebugIndicator(_master, chb_IndicatorLamp.CheckState == CheckState.Checked ? 1 : 0);
        }

        private void PLC_VisibleChanged(object sender, EventArgs e)
        {
            PlcCommand.DebugMode(_master, Visible == false ? 0 : 1);
        }

        private void chb_IndicatorLampGreen_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommand.DebugIndicatorGreen(_master, chb_IndicatorLampGreen.CheckState == CheckState.Checked ? 1 : 0);
        }

        private void chb_IndicatorLampRed_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommand.DebugIndicatorRed(_master, chb_IndicatorLampRed.CheckState == CheckState.Checked ? 1 : 0);
        }
    }
}

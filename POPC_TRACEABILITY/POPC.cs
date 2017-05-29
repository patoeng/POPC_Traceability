﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XS156Client35;
using XS156Client35.Models;

namespace POPC_TRACEABILITY
{
    public partial class POPC : Form
    {
        public  PLC M221Plc;
        public XS156Client35.IXs156Client Xs156Client;

        private Color OnColor = Color.Yellow;
        private Color OffColor = Color.YellowGreen;

        private string _plcIpAddress;
        private ushort _plcPort;
        private int _plcTickerInterval;


     
        public POPC()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadSetting()
        {
            _plcIpAddress = SettingHelper.PlcIpAddress();
            _plcPort = (ushort)SettingHelper.PlcPort();
            _plcTickerInterval = SettingHelper.PlcReadInterval();
        }

        private void ResetEvent()
        {
            if (M221Plc != null)
            {
               
                M221Plc.DataUpdated -= M221_Dataupdated;
                M221Plc.OutputQtyChanged -= M221Plc_OutputQtyChanged;
                M221Plc.RejectQtyChanged -= M221Plc_RejectQtyChanged;
                M221Plc.PoPcReadyForNewOrderNumber -= M221Plc_ReadyNewOrderNumber;
                M221Plc.Dispose();
                M221Plc = null;
            }
            if (Xs156Client != null)
            {
              
                Xs156Client.TrackingDataBagUpdatedEvent -= XS156_TrackingUpdated;
                Xs156Client.TrackingReferenceNewlyLoaded -= XS156_NewLoadExist;
                Xs156Client.ExceptionEvent -= Xs156Exception;
                Xs156Client = null;
            }
        }
        private void LoadAll()
        {
            LoadSetting();

            if (M221Plc == null)
            {
                M221Plc = new PLC(_plcIpAddress,_plcPort,_plcTickerInterval);
                M221Plc.DataUpdated += M221_Dataupdated;
                M221Plc.OutputQtyChanged += M221Plc_OutputQtyChanged;
                M221Plc.RejectQtyChanged += M221Plc_RejectQtyChanged;
                M221Plc.PoPcReadyForNewOrderNumber += M221Plc_ReadyNewOrderNumber;
                M221Plc.StartTicker();
            }

           
            if (Xs156Client == null)
            {
                Xs156Client = new Xs156Client();
                Xs156Client.TrackingDataBagUpdatedEvent += XS156_TrackingUpdated;
                Xs156Client.TrackingReferenceNewlyLoaded += XS156_NewLoadExist;
                Xs156Client.ExceptionEvent += Xs156Exception;
                Xs156Client.StartUpdater();
            }
        }

        private void XS156_NewLoadExist(TrackingDataBag data)
        {
            M221Plc?.SetPoPcNewOrderNumber();
        }

        private void Xs156Exception(string info)
        {
            MessageBox.Show(info);
        }

        private void XS156_TrackingUpdated(TrackingDataBag data)
        {
            Invoke(new TrackingBagDelegate(trackingBagHandler), new object[] { data });
           
        }

        private void trackingBagHandler(TrackingDataBag data)
        {
            chb_Traceability.BackColor = chb_Traceability.BackColor == OnColor ? OffColor : OnColor;
            lbl_Processable.Text = data.ProcessableQuantity.ToString("000");
            if (M221Plc != null)
            {
                if (M221Plc.QuantityProccessable != data.ProcessableQuantity)
                {
                    M221Plc.SetQuantityProcessable(data.ProcessableQuantity);
                }
            }
            lbl_OrderNumber.Text = data.OrderNumber;
            lbl_Reference.Text = data.CurrentReferenceName;
            if (_afterReload)
            {
                M221Plc?.SetQuantityOutput(data.OutputQuantity);
                M221Plc?.SetQuantityReject(data.RejectedQuantity);
                M221Plc?.SetQuantityProcessable(data.ProcessableQuantity);
                M221Plc?.ResetPoPcNewOrderNumber();
                _afterReload = false;
            }
        }

        private bool _afterReload;
        private void M221Plc_ReadyNewOrderNumber(int data)
        {
            Xs156Client.StopUpdater();
            Xs156Client.Reload();
            _afterReload = true;
            Xs156Client.StartUpdater();
            M221Plc.ResetPoPcNewOrderNumber();
        }

        private void M221Plc_RejectQtyChanged(int data)
        {
            lbl_RejectQty.Text = data.ToString("000");
            if (M221Plc.PoPcNewOrderNumber<2)
            Xs156Client?.SetRejectQuantity(data);
        }

        private void M221Plc_OutputQtyChanged(int data)
        {
            lbl_PassQty.Text = data.ToString("000");
            if (M221Plc.PoPcNewOrderNumber < 2)
                Xs156Client?.SetOutputQuantity(data);
        }

        private void M221_Dataupdated()
        {
            chb_Plc.BackColor = chb_Plc.BackColor == OnColor ? OffColor : OnColor;
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            using (Setting form = new Setting())
            {
                form.ShowDialog();
            }
        }

        private void btn_Debug_Click(object sender, EventArgs e)
        {
            M221Plc?.ShowDialog();
        }

        private void POPC_Load(object sender, EventArgs e)
        {

        }

       

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            M221Plc?.ResetSequence();
            ResetEvent();
            LoadAll();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using XS156Client35;
using XS156Client35.Models;

namespace POPC_TRACEABILITY
{
    public partial class Popc : Form
    {
        public  Plc M221Plc;
        public IXs156Client Xs156Client;

        private readonly Color _onColor = Color.Yellow;
        private readonly Color _offColor = Color.YellowGreen;

        private string _plcIpAddress;
        private ushort _plcPort;
        private int _plcTickerInterval;
        private readonly Xs156Setting _setting = new Xs156Setting();


        public Popc()
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
                M221Plc.PopcStateChangedEvent -= M221Plc_PopcStateChangedEvent;
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

        private void M221Plc_PopcStateChangedEvent(PopcStates states)
        {
            switch (states)
            {
                case PopcStates.Idle:
                    tbMessage.Text = @"Idle";
                    break;
                case PopcStates.WaitingForProcessable:
                    tbMessage.Text = @"Menunggu Processable produk dari process sebelumnya." + "\r\n" +
                                     @"Lepas kabel produk dari terminal jika ada.";
                    break;
                case PopcStates.WaitingForStartTestTimer:
                    tbMessage.Text = @"Pasang kabel Produk," + "\r\n" + @"Tekan dan tahan tombol untuk mulai testing.";
                    break;
                case PopcStates.TestSequence1:
                    tbMessage.Text = @"Test produk, dekatkan ke logam." + "\r\n" + @"Lepaskan tombol jika FAIL.";
                    break;
                case PopcStates.TestSequence2:
                    tbMessage.Text = @"Test produk sekali lagi , dekatkan ke logam. " + "\r\n" +
                                     @"Lepaskan tombol jika FAIL.";
                    break;
                case PopcStates.TestPass:
                    tbMessage.Text = @"Test produk PASS." + "\r\n" + @"Lepaskan tombol. Lepaskan kabel produk ";
                    break;
                case PopcStates.TestFailNeedRetry:
                    btnTestLagi.Visible = true;
                    tbMessage.Text = @"Test produk FAIL.Tekan tombol sekali jika benar FAIL," + "\r\n" + @" atau tekan tombol TEST LAGI untuk test ulang.";
                    break;
                case PopcStates.TestFailConfirmed:
                    tbMessage.Text = @"Test produk FAIL. Terkonfirmasi. ";
                    break;
                case PopcStates.Done:
                    tbMessage.Text = @"Lepaskan kabel produk. ";
                    break;
            }
            if (states != PopcStates.TestFailNeedRetry)
            {
                btnTestLagi.Visible = false;
            }
        }

        private void LoadAll()
        {
            LoadSetting();

            if (M221Plc == null)
            {
                M221Plc = new Plc(_plcIpAddress,_plcPort,_plcTickerInterval);
                M221Plc.DataUpdated += M221_Dataupdated;
                M221Plc.OutputQtyChanged += M221Plc_OutputQtyChanged;
                M221Plc.RejectQtyChanged += M221Plc_RejectQtyChanged;
                M221Plc.PoPcReadyForNewOrderNumber += M221Plc_ReadyNewOrderNumber;
                M221Plc.PopcStateChangedEvent += M221Plc_PopcStateChangedEvent;
                M221Plc.StartTicker();
            }

           
            if (Xs156Client == null)
            {
                Xs156Client = new Xs156Client();
                Xs156Client.TrackingDataBagUpdatedEvent += XS156_TrackingUpdated;
                Xs156Client.TrackingReferenceNewlyLoaded += XS156_NewLoadExist;
                Xs156Client.ExceptionEvent += Xs156Exception;

             
                if (_setting.GetBufferingMode()&& lbl_Reference.Text.Contains(@"XS"))
                {
                    Xs156Client.LoadByOrderNumber(lbl_OrderNumber.Text);
                }

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
            chb_Traceability.BackColor = chb_Traceability.BackColor == _onColor ? _offColor : _onColor;
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
            if (_setting.GetBufferingMode()) return;
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
            chb_Plc.BackColor = chb_Plc.BackColor == _onColor ? _offColor : _onColor;
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

        private void btnLoadOrderNumber_Click(object sender, EventArgs e)
        {
            using (var frm = new OpenProcessList())
            {
                Xs156Client.GetOpenProcess();
                int i;
                for (i = 0; i < Xs156Client.GetOpenProcessCount(); i++)
                {
                    frm.DgvList.Rows.Add(new object[]
                        {
                            Xs156Client.CurrentOpenProcess().OrderNumber,
                            Xs156Client.CurrentOpenProcess().CurrentReferenceName,
                            Xs156Client.CurrentOpenProcess().StartDateTime
                        }
                    );

                    Xs156Client.OpenProcessNext();
                }

                frm.ShowDialog();
               

                if (frm.LoadNew)
                {
                    var ask = MessageBox.Show(@"Yakin load order number " + frm.SelectedOrderNumber + @" ?", @"Traceability", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ask != DialogResult.OK) return;
                    try
                    {
                        Xs156Client.LoadByOrderNumber(frm.SelectedOrderNumber);
                        Xs156Client.StartUpdater();
                        M221Plc.SetPoPcState(PopcStates.Idle);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, @"Traceability");
                       
                    }
                }
            }
        }

        private void btnTestLagi_Click(object sender, EventArgs e)
        {
            M221Plc.SetPoPcState(PopcStates.WaitingForStartTestTimer);
            btnTestLagi.Visible = false;
        }
    }
}

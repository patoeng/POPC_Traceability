using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POPC_TRACEABILITY
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void LoadSetting()
        {
            tb_PLCAddress.Text = SettingHelper.PlcIpAddress();
            tb_PLCPort.Text = SettingHelper.PlcPort().ToString();
            tb_ReadInterval.Text = SettingHelper.PlcReadInterval().ToString();
        }

        private void SaveSetting()
        {
            try
            {
                SettingHelper.SetPlcIpAddress(tb_PLCAddress.Text);
                SettingHelper.SetReadInterval(Convert.ToInt32(tb_ReadInterval.Text));
                SettingHelper.SetPlcPort(Convert.ToInt32(tb_PLCPort.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveSetting();
            Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }
    }
}

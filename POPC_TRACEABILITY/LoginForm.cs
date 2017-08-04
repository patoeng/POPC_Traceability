using System;
using System.Windows.Forms;

namespace POPC_TRACEABILITY
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public DialogResult Result = DialogResult.Cancel;
        public string Password;
        private void LoginForm_Load(object sender, EventArgs e)
        { 
            tb_Password.Clear();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Password = tb_Password.Text;
            Result = DialogResult.OK;
            Hide();
            Close();
        }

        private void tb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(btn_Login,null);
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            tb_Password.Focus();
        }
    }
}

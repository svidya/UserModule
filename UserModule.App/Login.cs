using System;
using System.Windows.Forms;
using UserModule.interfaces;

namespace UserModule.App
{
    public partial class Login : Form
    {
        private ILoginModulePresenter _loginPresenter;
      
        public static long staticOperatorId;
       

        public Login()
        {
            InitializeComponent();
            _loginPresenter = new LoginModulePresenter();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            try
            {
                long operatorId = _loginPresenter.Login(username, password);
                staticOperatorId = operatorId;
                if (operatorId > 0)
                {
                    var userRegistration = new UserProfileEntry();
                    userRegistration.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                                

        }

        
    }
}

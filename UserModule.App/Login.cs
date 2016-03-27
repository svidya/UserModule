using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserModule.App.Presenter;
using UserModule.Data;



namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        LoginModulePresenter _presenter = new LoginModulePresenter();
        public static long staticOperatorId;
       

        public Login()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            try
            {
                long operatorId = _presenter.Login(username, password);
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

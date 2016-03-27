using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserModule.Data;



namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        private IUserProfileService userProfileService;
        public static long operatorId;
        public static string operatorName;
        
        public Login()
        {
            InitializeComponent();
            userProfileService = new UserProfileService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            DataRow dRow = userProfileService.GetUserProfileByName(username);

            var dbPassword = dRow["UserProfilePassword"].ToString();
            var dbOperatorId = Convert.ToInt64(dRow["UserProfileId"]);
            var isAdmin = dRow["UserProfileUserLevelToUserAdmin"].ToString();
            operatorId = dbOperatorId;
            operatorName = dRow["UserProfileName"].ToString(); 
            

           if(password.Equals(dbPassword) && isAdmin.Equals("Y"))
            {
                var userRegistration = new UserProfileEntry();
                userRegistration.Show();   
                this.Hide();
            }

            else
            {
                MessageBox.Show("Youcannot Login to the system as you dont have admin access or you have entered the wrong credentials ");
            }
                               

        }

        
    }
}

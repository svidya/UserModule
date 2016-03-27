using System;
using System.Windows.Forms;
using UserModule.Data;

namespace WindowsFormsApplication1
{
    public partial class UserProfileEntry : Form
    {
        private IUserProfileService userProfileService;

        public static long userProfileId;
        public static string userProfileName;

        long _operatorId;
        public long OperatorId
        {
            get
            {
                return this._operatorId;
            }
            set
            {
                this._operatorId = Login.operatorId;
            }
        }
        public UserProfileEntry()
        {
            InitializeComponent();
            userProfileService = new UserProfileService();
           
        }

        private void UserProfileEntry_Load(object sender, EventArgs e)
        {
           long userProfileId = userProfileService.RegisterUserProfile(" ");
           txtUserId.Text = userProfileId.ToString();
           txtOperatorName.Text = Login.operatorName;  
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            UserProfileEntity userProfile = new UserProfileEntity();
            userProfile.UserProfileId = Convert.ToInt64(txtUserId.Text);
            userProfile.UserProfileDomainName = txtDomain.Text;
            userProfile.UserProfileName = txtFullName.Text;
            userProfile.UserProfileAccount = txtUserName.Text;
            userProfile.IsAdmin = chkAdmin.Checked;
            userProfile.UserProfileMailAddress = txtEmail.Text;
            userProfile.Operator = userProfileService.GetUserProfileById(OperatorId);

            bool isUpdated = userProfileService.UpdateUserProfile(userProfile);
            
        }

        private void btnGrantAccess_Click(object sender, EventArgs e)
        {
            var userAccessForm = new UserAccessForm();
            userAccessForm.Show();
            this.Hide();
        }

        

    }
}

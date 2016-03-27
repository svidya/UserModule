using System;
using System.Windows.Forms;
using UserModule.App.Presenter;
using UserModule.Data;
using UserModule.interfaces;

namespace WindowsFormsApplication1
{
    public partial class UserProfileEntry : Form , IUserProfileEntryView
    {
        UserModulePresenter _presenter = new UserModulePresenter();     

        public static long userProfileId;
        public static string userProfileName;

        
        #region Properties
        //public static long OperatorId
        //{
        //    get
        //    {
        //        return this._operatorId;
        //    }
        //    set
        //    {
        //        this._operatorId = Login.staticOperatorId;
        //    }
        //}

       public string UserProfileId
        {
            get
            {
                return txtUserId.Text;
            }

            set
            {
                txtUserId.Text = value;
            }
        }

        public string UserProfileDomainName
        {
            get
            {
                return txtDomain.Text;
            }

            set
            {
                txtDomain.Text = value;
            }
        }

        public string UserProfileName
        {
            get
            {
                return txtFullName.Text;
            }

            set
            {
                txtFullName.Text = value;
            }
        }

        public string UserProfileAccount
        {
            get
            {
                return txtUserName.Text;
            }

            set
            {
                txtUserName.Text = value;
            }
        }

        public bool isAdmin
        {
            get
            {
                return chkAdmin.Checked;
            }

            set
            {
                chkAdmin.Checked = value;
            }
        }

        public string UserProfileMailAddress
        {
            get
            {
                return txtEmail.Text;
            }

            set
            {
                txtEmail.Text = value;
            }
        }
        #endregion

        public UserProfileEntry()
        {
            InitializeComponent();   
        }

        private void UserProfileEntry_Load(object sender, EventArgs e)
        {
           long userProfileId = _presenter.RegisterUserProfile(" ");
           txtUserId.Text = userProfileId.ToString();
           string operatorName = _presenter.GetOperatorName(Login.staticOperatorId);
           txtOperatorName.Text = operatorName;  
        }


        private void btnSave_Click(object sender, EventArgs e)
        {   
            bool isUpdated = _presenter.UpdateUserData(UserProfileId,UserProfileDomainName,UserProfileName,UserProfileAccount,
                isAdmin,UserProfileMailAddress,Login.staticOperatorId);
            
        }

        private void btnGrantAccess_Click(object sender, EventArgs e)
        {
            var userAccessForm = new UserAccessForm();
            userAccessForm.Show();
            this.Hide();
        }

        

    }
}

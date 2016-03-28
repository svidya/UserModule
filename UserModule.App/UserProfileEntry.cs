using System;
using System.Windows.Forms;
using UserModule.Interfaces;

namespace UserModule.App
{
    public partial class UserProfileEntry : Form, IUserProfileEntryView
    {   

        #region Properties  and Variables

        private IUserModulePresenter _presenter;  

        public static long staticuserProfileId;
        public static string staticuserProfileName;
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
            _presenter = new UserModulePresenter();
        }

        #region Events
        private void UserProfileEntry_Load(object sender, EventArgs e)
        {
            long userProfileId = _presenter.RegisterUserProfile(" ");
            txtUserId.Text = userProfileId.ToString();
            string operatorName = _presenter.GetOperatorName(Login.staticOperatorId);
            txtOperatorName.Text = operatorName;
            btnEdit.Enabled = false;
            btnGrantAccess.Enabled = false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isUpdated = _presenter.UpdateUserData(UserProfileId, UserProfileDomainName, UserProfileName, UserProfileAccount,
                    isAdmin, UserProfileMailAddress, Login.staticOperatorId);
                if (isUpdated)
                {
                    MessageBox.Show("User profile created successfully.Please Grant Access.");
                    EnableTextBoxControls(false);
                    btnEdit.Enabled = true;
                    btnGrantAccess.Enabled = true;
                    staticuserProfileId = Convert.ToInt64(UserProfileId);
                    staticuserProfileName = UserProfileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnGrantAccess_Click(object sender, EventArgs e)
        {
            var userAccessForm = new UserAccessForm();
            userAccessForm.Show();
            this.Hide();
        }

        private void dtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDeleted = _presenter.DeleteUserData(UserProfileId);
                if (isDeleted)
                {
                    this.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableTextBoxControls(true);
        }
        #endregion


        #region Methods
        private void EnableTextBoxControls(bool enabled)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox && control is CheckBox)
                        control.Enabled = enabled;
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        #endregion
    }
}

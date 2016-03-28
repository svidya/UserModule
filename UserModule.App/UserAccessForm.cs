using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserModule.Interfaces;

namespace UserModule.App
{
    public partial class UserAccessForm : Form
    {
        #region Properties and Variables
        private IUserAccessPresenter _userAccessPresenter;

        public UserAccessForm()
        {
            InitializeComponent();
            _userAccessPresenter = new UserAccessPresenter();
        }
        #endregion

        #region Events
        private void UserAccessForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = UserProfileEntry.staticuserProfileName;
            

            //Async Delegate 
            var tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            DataTable dtSystemTbl = null;
            DataTable dtBranchTbl = null;
            DataTable dtUserLevelTbl = null;
            Task t = Task.Factory.StartNew(() =>
            {
                dtSystemTbl = _userAccessPresenter.GetLocalSystem();
                dtBranchTbl = _userAccessPresenter.GetBranchCodes();
                dtUserLevelTbl = _userAccessPresenter.GetUserLevels();

            }, token).ContinueWith(ant =>
            {
                tblLayoutGridPanel.Visible = true;
                userAccessGrid.DataSource = dtSystemTbl;
                userAccessGrid.Columns[0].Visible = false;
                tblLayoutButtonPanel.Visible = true;

                AddBranches(dtBranchTbl);
                AddUserLevels(dtUserLevelTbl);


            }, CancellationToken.None,
           TaskContinuationOptions.None,
           scheduler);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool saveChanges = false;

            try
            {
                var collection = userAccessGrid.Rows;
                saveChanges = _userAccessPresenter.SaveChanges(collection, UserProfileEntry.staticuserProfileId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var userEntry = new UserProfileEntry();
            userEntry.Show();
            this.Hide();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods
        private void AddBranches(DataTable branchCodes)
        {
            foreach (DataRow dr in branchCodes.Rows)
            {
                var checkBox = new DataGridViewCheckBoxColumn();
                checkBox.ValueType = typeof(bool);
                checkBox.HeaderText = dr["BranchCode"].ToString();
                checkBox.ToolTipText = dr["BranchCode"].ToString();
                userAccessGrid.Columns.Add(checkBox);
            }
        }


        public void AddUserLevels(DataTable userLevels)
        {
            var comboBox = new DataGridViewComboBoxColumn();
            comboBox.Name = "Permissions";
            comboBox.DataSource = userLevels;

            comboBox.ValueMember = "UserLevelCategoryId";
            comboBox.DisplayMember = "UserLevelCategoryName";

            userAccessGrid.Columns.Add(comboBox);
        }
        #endregion

    }
}

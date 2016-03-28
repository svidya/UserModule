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
        private long userProfileId;

        public string ConnectionString;

        public long UserProfileId
        {
            get
            {
                return this.userProfileId;
            }
            set
            {
                this.userProfileId = UserProfileEntry.staticuserProfileId;
            }
        }

        private string userName;
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = UserProfileEntry.staticuserProfileName;
            }
        }

        public UserAccessForm()
        {
            InitializeComponent();
            _userAccessPresenter = new UserAccessPresenter();
        }
        #endregion        
        
        #region Events
        private void UserAccessForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = UserName;

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
                tableLayoutPanel1.Visible = true;
                dataGridView1.DataSource = dtSystemTbl;
                dataGridView1.Columns[0].Visible = false;

                AddBranches(dtBranchTbl);
                AddUserLevels(dtUserLevelTbl);


            }, CancellationToken.None,
           TaskContinuationOptions.None,
           scheduler);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool saveChanges = false;

            var collection = dataGridView1.Rows;
            saveChanges = _userAccessPresenter.SaveChanges(collection, UserProfileId);    

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
                dataGridView1.Columns.Add(checkBox);
            }
        }


        public void AddUserLevels(DataTable userLevels)
        {
            var comboBox = new DataGridViewComboBoxColumn();
            comboBox.Name = "Permissions";
            comboBox.DataSource = userLevels;

            comboBox.ValueMember = "UserLevelCategoryId";
            comboBox.DisplayMember = "UserLevelCategoryName";

            dataGridView1.Columns.Add(comboBox);
        }
        #endregion

    }
}

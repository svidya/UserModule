using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UserModule.Data;

namespace WindowsFormsApplication1
{
    public partial class UserAccessForm : Form
    {
        private long userProfileId;

        public string ConnectionString;

        public long OperatorId
        {
            get
            {
                return this.userProfileId;
            }
            set
            {
                this.userProfileId = UserProfileEntry.userProfileId;
            }
        }

        DataTable dt = new DataTable();
        public UserAccessForm()
        {
            InitializeComponent();
        }

        private void UserAccessForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadData();
            dataGridView1.Columns[0].Visible = false;
            
            AddBranches();
            AddPermissions();
            

        }

        private void AddBranches()
        {      

            DataTable branchCodes = LoadBranchCodes();

            foreach(DataRow dr in branchCodes.Rows)
            {
                var checkBox = new DataGridViewCheckBoxColumn();
                checkBox.ValueType = typeof(bool);
                //checkBox.Name = "chk"+ dr["BranchCode"].ToString();
                checkBox.HeaderText= dr["BranchCode"].ToString();
                dataGridView1.Columns.Add(checkBox);
            }
        }

        private DataTable LoadBranchCodes()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["UserProfile"].ToString();
            DataTable ds = new DataTable();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                sqlDataAdapter.SelectCommand = new SqlCommand();
                sqlDataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                sqlDataAdapter.SelectCommand.CommandText = string.Format(Script.sqlGetBranchCodes);

                // Add the input parameters to the parameter collection
                // sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@localSystemId", systemId);

                // Fill the table from adapter
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        private DataTable LoadData()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["UserProfile"].ToString();
            DataSet ds = new DataSet();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                sqlDataAdapter.SelectCommand = new SqlCommand();
                sqlDataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                sqlDataAdapter.SelectCommand.CommandText = string.Format(Script.sqlGetLocalSystem);

            
                sqlDataAdapter.Fill(dt);
            }

            return dt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var userEntry = new UserProfileEntry();
            userEntry.Show();
            this.Hide();
        }

        public void AddPermissions()
        {
            var comboBox = new DataGridViewComboBoxColumn();
            comboBox.Name = "Permissions";    
            DataTable permissions = LoadPermissions();
            comboBox.DataSource = permissions;

            comboBox.ValueMember = "UserLevelCategoryId";
            comboBox.DisplayMember = "UserLevelCategoryName";
            
            dataGridView1.Columns.Add(comboBox);
        }

        public DataTable LoadPermissions()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["UserProfile"].ToString();
            DataTable ds = new DataTable();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                sqlDataAdapter.SelectCommand = new SqlCommand();
                sqlDataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                sqlDataAdapter.SelectCommand.CommandText = string.Format(Script.sqlGetUserLevelCategory);

                // Fill the table from adapter
                sqlDataAdapter.Fill(ds);
            }

            return ds;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

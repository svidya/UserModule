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

        //private int GetNewUserData()
        //{
        //    string name = string.Empty;
            
        //    var sqlCommand = "Insert into UserProfile(UserProfileName) Values(@userProfileName); Select scope_identity()";
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
        //        {
        //            cmd.Parameters.AddWithValue("@userProfileName", name);
                    
        //            con.Open();

        //            var modified = cmd.ExecuteScalar();

        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //            return Convert.ToInt32(modified);
                    
        //        }
        //    }
           


        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            string domainName = txtDomain.Text;
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            bool isAdmin = chkAdmin.Checked;
            userProfileId = Convert.ToInt32(txtUserId.Text);

            //UpdateUserProfile(domainName, userName, email, isAdmin, userProfileId);
        }

        private void btnGrantAccess_Click(object sender, EventArgs e)
        {
            var userAccessForm = new UserAccessForm();
            userAccessForm.Show();
            this.Hide();
        }

        //private void UpdateUserProfile(string domainName, string userName, string email, bool isAdmin, int userProfileId)
        //{
        //    var sqlCommand = "Update UserProfile SET UserProfileStatus = @status,UserProfileAccount = @profileAccount, UserProfileName = @userName, UserProfileDomainName = @domainName, UserProfileMailAddress = @email, UserProfileUserLevelToUserAdmin = @isAdmin, UserProfileTimeStamp = @dateTime where UserProfileId = @userProfileId ";


        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {   
        //        using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
        //        {
        //            cmd.Parameters.AddWithValue("@status", 0);
        //            cmd.Parameters.AddWithValue("@profileAccount", userName);
        //            cmd.Parameters.AddWithValue("@userName", userName);
        //            cmd.Parameters.AddWithValue("@domainName", domainName);
        //            cmd.Parameters.AddWithValue("@email", email);
        //            cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
        //            cmd.Parameters.AddWithValue("@dateTime", DateTime.Now);
        //            cmd.Parameters.AddWithValue("@userProfileId",userProfileId);


        //            con.Open();

        //            var modified = cmd.ExecuteNonQuery();

        //            if (con.State == ConnectionState.Open)
        //                con.Close();


        //        }
        //    }

        //}

        //private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        //{

        //}
        ////private void GetData(string selectCommand)
        ////{
        ////    try
        ////    {
        ////        // Specify a connection string. Replace the given value with a 
        ////        // valid connection string for a Northwind SQL Server sample
        ////        // database accessible to your system.
        ////        String connectionString = "Data Source=vidya-pc;Initial Catalog=assignment;Integrated Security=True";
        ////        /* "Integrated Security=SSPI;Persist Security Info=False;" +*/


        ////        // Create a new data adapter based on the specified query.
        ////        var dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

        ////        // Create a command builder to generate SQL update, insert, and
        ////        // delete commands based on selectCommand. These are used to
        ////        // update the database.
        ////        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

        ////        // Populate a new data table and bind it to the BindingSource.
        ////        DataTable table = new DataTable();
        ////        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        ////        dataAdapter.Fill(table);
        ////       // bindingSource1.DataSource = table;

        ////        // Resize the DataGridView columns to fit the newly loaded content.
        ////        dataGridView1.AutoResizeColumns(
        ////            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        ////    }
        ////    catch (SqlException)
        ////    {
        ////        MessageBox.Show("To run this example, replace the value of the " +
        ////            "connectionString variable with a connection string that is " +
        ////            "valid for your system.");
        ////    }
        ////}


    }
}

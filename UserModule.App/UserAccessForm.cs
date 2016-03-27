using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserModule.Sql;

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
            AddPermissions();

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

                // Add the input parameters to the parameter collection
               // sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Occupation", occupation == null ? DBNull.Value : occupation);
                //sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MaritalStatus", maritalStatus == null ? DBNull.Value : maritalStatus);

                // Fill the table from adapter
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
            DataTable dPermissions = new DataTable();
            long systemId = 0;

            
            DataGridViewComboBoxCell comboBoxCell = null;

            //foreach(DataRow dr in dt.Rows)
            //{
            //    //ArrayList permissions = new ArrayList();
            //    //comboBoxCell = new DataGridViewComboBoxCell();
            //    //systemId = Convert.ToInt64(dr["LocalSystemId"]);
            //    //dPermissions = LoadPermissions(systemId);

          


            //}

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ArrayList permissions = new ArrayList();
                comboBoxCell = new DataGridViewComboBoxCell();
                systemId = Convert.ToInt64(row.Cells[0].Value);
                dPermissions = LoadPermissions(systemId);
                //comboBoxCell.DataSource = dPermissions;
                foreach (DataRow dataRow in dPermissions.Rows)
                {
                    permissions.Add(dataRow["UserLevelCategoryName"].ToString());
                }
                comboBoxCell.Items.AddRange(permissions.ToArray());

                row.Cells.Add(comboBoxCell);

            }
           

        }

        public DataTable LoadPermissions(long systemId)
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

                // Add the input parameters to the parameter collection
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@localSystemId", systemId);

                // Fill the table from adapter
                sqlDataAdapter.Fill(ds);
            }

            return ds;

        }
    }
}

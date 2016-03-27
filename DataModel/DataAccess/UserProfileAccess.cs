using System;
using System.Data;
using System.Data.SqlClient;
using UserModule.DataModel;
using UserModule.Sql;

namespace UserModule.DataAccess
{
    public class UserProfileAccess :  ConnectionAccess,IUserProfileAccess
    {
      

        public DataTable GetAllUserProfiles()
        {
            throw new NotImplementedException();
        }

        public DataRow GetUserProfileById(long id)
        {
            throw new NotImplementedException();
        }

        public long AddUserProfile(string userName)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = new SqlConnection(this.ConnectionString);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = Script.sqlAddUserProfile;
                sqlCommand.Parameters.AddWithValue("@userProfileName", userName);

                sqlCommand.Connection.Open();

                var userProfileId = sqlCommand.ExecuteScalar();

                sqlCommand.Connection.Close();


                return Convert.ToInt64(userProfileId);
            }
        }

        public bool UpdateUserProfile(UserProfileEntity userProfile)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserProfile(long userProfileId)
        {
            throw new NotImplementedException();
        }

        public DataRow GetUserProfileByName(string userName)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Script.sqlGetUserProfileByName;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@profileAccount", userName);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }
    }
}

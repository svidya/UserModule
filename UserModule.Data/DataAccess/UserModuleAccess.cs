using System;
using System.Data;
using System.Data.SqlClient;

namespace UserModule.Data
{
    public class UserModuleAccess: ConnectionAccess,IUserModuleAccess
    {
        #region Methods 
        public DataTable GetAllUserProfiles()
        {
            //To Do Implementation
            return null;
        }

        public DataRow GetUserProfileById(long id)
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataRow dataRow;

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new SqlCommand();
                    dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = Script.sqlGetUserProfileById;

                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@userprofileId", id);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@status", UserProfileStatus.Active);

                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);

                    // Get the datarow from the table
                    dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                    return dataRow;
                }
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }

        }

        public long AddUserProfile(string userName)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = new SqlConnection(ConnectionString);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = Script.sqlAddUserProfile;
                    sqlCommand.Parameters.AddWithValue("@userProfileName", userName);

                    sqlCommand.Connection.Open();

                    var userProfileId = sqlCommand.ExecuteScalar();

                    sqlCommand.Connection.Close();

                    return Convert.ToInt64(userProfileId);
                }
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw;
            }
        }

        public bool UpdateUserProfile(UserProfileEntity userProfile)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Set the command object properties
                    sqlCommand.Connection = new SqlConnection(ConnectionString);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = Script.sqlUpdateUserProfile;

                    // Add the input parameters to the parameter collection
                    sqlCommand.Parameters.AddWithValue("@status", UserProfileStatus.Active);
                    sqlCommand.Parameters.AddWithValue("@profileAccount", userProfile.UserProfileAccount);
                    sqlCommand.Parameters.AddWithValue("@fullName", userProfile.UserProfileName);
                    sqlCommand.Parameters.AddWithValue("@domainName", userProfile.UserProfileDomainName);
                    sqlCommand.Parameters.AddWithValue("@email", userProfile.UserProfileMailAddress);
                    sqlCommand.Parameters.AddWithValue("@isAdmin", userProfile.IsAdmin ? "Y" : "N");
                    sqlCommand.Parameters.AddWithValue("@dateTime", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@password", Script.defaultPassword);
                    sqlCommand.Parameters.AddWithValue("@operatorId", userProfile.OperatorId);

                    sqlCommand.Parameters.AddWithValue("@userProfileId", userProfile.UserProfileId);

                    // Open the connection, execute the query and close the connection
                    sqlCommand.Connection.Open();
                    var rowsAffected = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }
        }

        public bool DeleteUserProfile(long userProfileId)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // Set the command object properties
                    sqlCommand.Connection = new SqlConnection(ConnectionString);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = Script.sqlDeleteUserProfile;

                    // Add the input parameters to the parameter collection       
                    sqlCommand.Parameters.AddWithValue("@status", UserProfileStatus.Deleted);
                    sqlCommand.Parameters.AddWithValue("@userProfileId", userProfileId);


                    // Open the connection, execute the query and close the connection
                    sqlCommand.Connection.Open();
                    var rowsAffected = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }
        }

        public DataRow GetUserProfileByName(string userName)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            try
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    // Create the command and set its properties
                    dataAdapter.SelectCommand = new SqlCommand();
                    dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand.CommandText = Script.sqlGetUserProfileByName;

                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@profileAccount", userName);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@status", UserProfileStatus.Active);

                    // Fill the datatable From adapter
                    dataAdapter.Fill(dataTable);

                    // Get the datarow from the table
                    dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                    return dataRow;
                }
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }
        }

        #endregion
    }
}

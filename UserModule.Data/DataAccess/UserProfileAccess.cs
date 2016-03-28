using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UserModule.Data
{
    public class UserProfileAccess : ConnectionAccess, IUserProfileAccess
    {
        #region Methods
        public DataTable GetBranchCodes()
        {
            try
            {
                DataTable dtBranchCodes = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    // Create the command and set its properties
                    sqlDataAdapter.SelectCommand = new SqlCommand();
                    sqlDataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                    // Assign the SQL to the command object
                    sqlDataAdapter.SelectCommand.CommandText = string.Format(Script.sqlGetBranchCodes);

                    // Fill the table from adapter
                    sqlDataAdapter.Fill(dtBranchCodes);
                }
                return dtBranchCodes;
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }

        }

        public DataTable GetLocalSystem()
        {
            try
            {
                DataTable dtLocalSystems = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    // Create the command and set its properties
                    sqlDataAdapter.SelectCommand = new SqlCommand();
                    sqlDataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                    // Assign the SQL to the command object
                    sqlDataAdapter.SelectCommand.CommandText = string.Format(Script.sqlGetLocalSystem);


                    sqlDataAdapter.Fill(dtLocalSystems);
                }

                return dtLocalSystems;
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }

        }

        public DataTable GetUserLevels()
        {
            try
            {
                DataTable dtUserLevels = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    // Create the command and set its properties
                    sqlDataAdapter.SelectCommand = new SqlCommand();
                    sqlDataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                    // Assign the SQL to the command object
                    sqlDataAdapter.SelectCommand.CommandText = string.Format(Script.sqlGetUserLevelCategory);

                    // Fill the table from adapter
                    sqlDataAdapter.Fill(dtUserLevels);
                }

                return dtUserLevels;
            }
            catch (Exception ex)
            {
                //TO DO Write custom Code for Exception Handling
                throw ex;
            }

        }

        public bool SaveChanges(long systemId, List<string> branchCodes, long comboBoxSelectedValue, long userProfileId)
        {
            bool saveBranchCodes = false;
            bool saveUserAccess = false;
            foreach(var code in branchCodes)
            {
                saveBranchCodes = SaveBranchCodes(code, systemId, userProfileId); 
            }

            saveUserAccess = SaveUserAccessDetails(systemId, comboBoxSelectedValue, userProfileId);

            if(saveBranchCodes && saveUserAccess)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private bool SaveUserAccessDetails(long systemId, long comboBoxSelectedValue, long userId)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = new SqlConnection(ConnectionString);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = Script.sqlInsertLocalAccess;
                sqlCommand.Parameters.AddWithValue("@userAccessStatus", UserProfileStatus.Active);
                sqlCommand.Parameters.AddWithValue("@userProfileId", userId);
                sqlCommand.Parameters.AddWithValue("@localSystemId", systemId);
                sqlCommand.Parameters.AddWithValue("@userLevelId", comboBoxSelectedValue);

                sqlCommand.Connection.Open();

                var accessId = sqlCommand.ExecuteScalar();


                sqlCommand.Connection.Close();

                return Convert.ToInt64(accessId) > 0 ? true : false;
            }

        }

        private bool SaveBranchCodes(string code,long localSystemId,long userId)
        {   
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = new SqlConnection(ConnectionString);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = Script.sqlInsertLocalAccess;
                sqlCommand.Parameters.AddWithValue("@userAccessStatus", UserProfileStatus.Active);
                sqlCommand.Parameters.AddWithValue("@userProfileId", userId);
                sqlCommand.Parameters.AddWithValue("@localSystemId", localSystemId);
                sqlCommand.Parameters.AddWithValue("@branchCode", code);

                sqlCommand.Connection.Open();

                var localsystemId = sqlCommand.ExecuteScalar(); 

                sqlCommand.Connection.Close();

                return Convert.ToInt64(localsystemId) > 0 ?  true : false;
            }
        }

        #endregion
    }
}


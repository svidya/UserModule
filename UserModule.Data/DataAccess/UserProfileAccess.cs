using System;
using System.Data;
using System.Data.SqlClient;

namespace UserModule.Data
{
    public class UserProfileAccess : ConnectionAccess, IUserProfileAccess
    {
        public DataTable GetBranchCodes()
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

        public DataTable GetLocalSystem()
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

        public DataTable GetUserLevels()
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
    }
}

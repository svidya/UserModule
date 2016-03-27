using System.Configuration;

namespace UserModule.DataAccess
{
    public abstract class ConnectionAccess
    {
        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UserProfile"].ToString();
            }
        }
    }
}

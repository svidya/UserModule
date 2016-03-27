using System.Configuration;

namespace UserModule.Data
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

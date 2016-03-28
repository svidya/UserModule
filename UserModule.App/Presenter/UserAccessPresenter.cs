using System.Data;
using System.Threading;
using UserModule.Data;
using UserModule.interfaces;

namespace UserModule.App
{
    public class UserAccessPresenter : IUserAccessPresenter
    {
        private IUserAccessService userAccessService = UserAccessService.Instance;
        public DataTable GetBranchCodes()
        {  
            return userAccessService.GetBranchCodes();
        }

        public DataTable GetLocalSystem()
        {
            Thread.Sleep(10000);
            return userAccessService.GetLocalSystem();
        }

        public DataTable GetUserLevels()
        {
            return userAccessService.GetUserLevels();
        }
    }
}

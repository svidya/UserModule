using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UserModule.Data
{
    public class UserAccessService : IUserAccessService
    {
        #region Singleton Pattern
        private static IUserAccessService _instance;
        private static object _lockbject = new object();


        public static IUserAccessService Instance
        {
            get
            {

                lock (_lockbject)
                {
                    if (_instance == null)
                    {
                        _instance = new UserAccessService();
                    }
                }

                return _instance;
            }
        }


        private IUserProfileAccess userProfileAccess;
       

        private UserAccessService()
        {
            this.userProfileAccess = new UserProfileAccess();   

        }

        #endregion

        #region Methods
        public DataTable GetBranchCodes()
        {
            return userProfileAccess.GetBranchCodes();
        }

        public DataTable GetLocalSystem()
        {
            return userProfileAccess.GetLocalSystem();
        }

        public DataTable GetUserLevels()
        {
            return userProfileAccess.GetUserLevels();
        }
        #endregion
    }
}

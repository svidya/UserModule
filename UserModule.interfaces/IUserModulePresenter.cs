using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UserModule.interfaces
{
    public interface IUserModulePresenter
    {   
       
        bool UpdateUserData(string userProfileId, string userProfileDomainName, string userProfileName, string userProfileAccount, bool isAdmin, string userProfileMailAddress,long operatorId);
        long RegisterUserProfile(string userName);  
        string GetOperatorName(long operatorId);

        bool DeleteUserData(string userProfileId);
        
    }
}

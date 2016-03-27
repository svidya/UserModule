using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserModule.interfaces
{
    public interface IUserProfileEntity
    {
         long UserProfileId { get; set; }
         int UserProfileStatus { get; set; }
         string UserProfileAccount { get; set; }
         string UserProfileName { get; set; }
         string Password { get; set; }
         string UserProfileDomainName { get; set; }
         string UserProfileMailAddress { get; set; }
         bool IsAdmin { get; set; }
         long OperatorId { get; set; }
         IUserProfileEntity Operator { get; set; }
         DateTime UserProfileTimeStamp { get; set; }


    }
}

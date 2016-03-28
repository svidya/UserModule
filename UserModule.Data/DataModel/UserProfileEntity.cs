using System;
using UserModule.Interfaces;

namespace UserModule.Data
{
    public class UserProfileEntity: IUserProfileEntity
    {
        public long UserProfileId { get; set; }
        public int UserProfileStatus { get; set; }
        public string UserProfileAccount { get; set; }
        public string UserProfileName { get; set; }
        public string Password { get; set; }
        public string UserProfileDomainName { get; set; }
        public string UserProfileMailAddress { get; set; }
        public bool IsAdmin { get; set; }  
        public long OperatorId { get; set; }
        public IUserProfileEntity Operator { get; set; }
        public DateTime UserProfileTimeStamp { get; set; }

    }

    public enum UserProfileStatus
    {
       Active = 0,
       Deleted = -1
    }
}

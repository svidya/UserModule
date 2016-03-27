using System;

namespace UserModule.Data
{
    public class UserProfileEntity
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
        public UserProfileEntity Operator { get; set; }
        public DateTime UserProfileTimeStamp { get; set; }
         

    }
}

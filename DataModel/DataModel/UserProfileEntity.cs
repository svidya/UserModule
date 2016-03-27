using System;

namespace UserModule.DataModel
{
    public class UserProfileEntity
    {
        public long UserProfileId { get; set; }
        public int UserProfileStatus { get; set; }
        public string UserProfileAccount { get; set; }
        public string UserProfileDomainName { get; set; }
        public string UserProfileMailAddress { get; set; }
        public bool IsAdmin { get; set; }
        public long OperatorId { get; set; }
        public DateTime UserProfileTimeStamp { get; set; }
         

    }
}

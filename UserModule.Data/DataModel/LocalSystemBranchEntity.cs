using System.Collections.Generic;

namespace UserModule.Data
{
    public class LocalSystemBranchEntity
    {
        public long localSystemBranchId { get; set; }

        public int localSystemBranchStatus { get; set; }

        public BranchEntity localSystemBranchCode { get; set; }

        public UserProfileEntity userProfile { get; set; }

        public LocalSystemEntity localSystem { get; set; }

        public List<LocalSystemEntity> localSystemList { get; set; }

        public List<UserProfileEntity> userProfileList { get; set; }


    }
}

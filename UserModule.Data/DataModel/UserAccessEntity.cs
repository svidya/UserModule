
using System.Collections.Generic;

namespace UserModule.Data
{
    public class UserAccessEntity
    {
        public long userAccessId { get; set; }
        public int userAccessStatus { get; set; }     
        public UserProfileEntity userProfile { get; set; }
        public LocalSystemEntity localSystem { get; set; }         
        public UserLevelCategoryEntity userLevelCategory { get; set; }
        public List<UserLevelCategoryEntity>   userCategoryList { get; set; }  
        public List<LocalSystemEntity> localSystemList { get; set; }

    }
}

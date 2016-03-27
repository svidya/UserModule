
namespace UserModule.Data
{
    public class UserAccessEntity
    {
        public long UserAccessId { get; set; }
        public int UserAccessStatus { get; set; }

        public UserProfileEntity UserProfile { get; set; }

        public LocalSystemEntity LocalSystem { get; set; }   

    }
}

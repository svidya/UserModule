namespace UserModule.Data
{
    public class UserLevelCategoryEntity
    {   
        public long UserLevelCatgoryId { get; set; }

        public string UserLevelCategoryName { get; set; }

        public LocalSystemEntity LocalSystem { get; set; }
    }
}

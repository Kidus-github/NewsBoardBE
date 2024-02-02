namespace NewsBoardBE.Modals
{
    public class NewsBoardDatabaseSettings : INewsBoardDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ContentCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string LikeCollectionName { get; set; }
        public string BookmarkCollectionName { get; set;}
        public string ContentShareCollectionName { get; set; }
        public string ContentTagCollectionName { get; set; }
        public string FollowCollectionName { get; set; }
        public string NotificationCollectionName { get; set; }
        
    }
}

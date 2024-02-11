namespace NewsBoardBE.Modals
{
    public class NewsBoardDatabaseSettings : INewsBoardDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ContentCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string CommentCollectionName { get; set; }
        public string LikeCollectionName { get; set; }
        public string BookmarkCollectionName { get; set;}
        public string ContentShareCollectionName { get; set; }
        public string ContentTagCollectionName { get; set; }
        public string FollowCollectionName { get; set; }
        public string NotificationCollectionName { get; set; }

        public string PaymentTransactionCollectionName { get; set; }
        public string ReportCollectionName { get; set; }
        public string SearchHistoryCollectionName { get; set; }
        public string SourceCollectionName { get; set; }
        public string SubscripitonCollectionName { get; set; }
        public string TagCollectionName { get; set; }
        public string TrendingCollectionName { get; set; }
    }
}

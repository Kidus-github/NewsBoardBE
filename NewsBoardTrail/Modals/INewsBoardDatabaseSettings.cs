namespace NewsBoardBE.Modals
{
    public interface INewsBoardDatabaseSettings
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ContentCollectionName { get; set; }
        string CategoryCollectionName { get; set; }
        string LikeCollectionName { get; set; }
        string BookmarkCollectionName { get; set; }
        string ContentShareCollectionName { get; set; }
        string ContentTagCollectionName { get; set; }
        string FollowCollectionName { get; set; }
        string NotificationCollectionName { get; set; }

        string PaymentTransactionCollectionName { get; set; }
        string ReportCollectionName { get; set; }
        string SearchHistoryCollectionName { get; set; }
        string SourceCollectionName { get; set; }
        string SubscripitonCollectionName { get; set; }
        string TagCollectionName { get; set; }
        string TrendingCollectionName { get; set; }
    }
}

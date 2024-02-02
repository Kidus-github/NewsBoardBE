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
    }
}

using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class ReportService: INewsBoardServices<Report>
    {
        private readonly IMongoCollection<Report> _reportServiceCollection;

        public ReportService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _reportServiceCollection = database.GetCollection<Report>(settings.ReportCollectionName);
        }

        public Report Create(Report entity)
        {
            _reportServiceCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {

            _reportServiceCollection.DeleteOne(report => report.ReporterId == id);

        }
        public List<Report> Get()
        {
            return _reportServiceCollection.Find(report => true).ToList();
        }

        public Report GetById(string id)
        {
            return _reportServiceCollection.Find(report => report.ReportId == id).FirstOrDefault();
        }

        public void Update(string id, Report entity)
        {
            _reportServiceCollection.ReplaceOne(report => report.ReportId == id, entity);
        }

    }
}

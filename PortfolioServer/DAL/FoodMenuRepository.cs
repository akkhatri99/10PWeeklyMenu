using MongoDB.Driver;
using PortfolioServer.Interfaces;
using PortfolioServer.Models;

namespace PortfolioServer.DAL
{
    public class FoodMenuRepository : MongoRepository<FoodMenu>, IFoodMenuRepository
    {
        public IEnumerable<FoodMenu> GetWeeklyData()
        {
            FilterDefinition<FoodMenu> dateFilter = Builders<FoodMenu>.Filter.Lte(x => x.Date, DateTime.UtcNow.AddDays(7));
            return Collection.Find(dateFilter).ToList();
        }
        public void InsertManyData(IEnumerable<FoodMenu> data)
        {
            Collection.InsertMany(data);
        }
        public void InsertData(FoodMenu data)
        {
            Collection.InsertOne(data);
        }

        public void Delete(string name)
        {
            FilterDefinition<FoodMenu> nameFilter = Builders<FoodMenu>.Filter.Eq(x => x.Item, name);
            Collection.DeleteOne(nameFilter);
        }

        public void UpdateLike(string name)
        {
            FilterDefinition<FoodMenu> nameFilter = Builders<FoodMenu>.Filter.Eq(x => x.Item, name);
            var update = Builders<FoodMenu>.Update.Inc(x => x.LikeCount, 1);
            Collection.UpdateOne(nameFilter, update);
        }

        public void UpdateDisLike(string name)
        {
            FilterDefinition<FoodMenu> nameFilter = Builders<FoodMenu>.Filter.Eq(x => x.Item, name);
            var update = Builders<FoodMenu>.Update.Inc(x => x.DislikeCount, 1);
            Collection.UpdateOne(nameFilter, update);
        }
    }
}

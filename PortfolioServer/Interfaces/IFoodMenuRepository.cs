using PortfolioServer.Models;

namespace PortfolioServer.Interfaces
{
    public interface IFoodMenuRepository
    {
        public IEnumerable<FoodMenu> GetWeeklyData();
        public void InsertManyData(IEnumerable<FoodMenu> data);
        public void InsertData(FoodMenu data);
        public void Delete(string name);
        public void UpdateLike(string name);
        public void UpdateDisLike(string name);
    }
}

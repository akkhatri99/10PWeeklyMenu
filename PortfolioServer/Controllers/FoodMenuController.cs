using Microsoft.AspNetCore.Mvc;
using PortfolioServer.DAL;
using PortfolioServer.Interfaces;
using PortfolioServer.Models;

namespace PortfolioServer.Controllers
{
    [ApiController]
    //[Route("[UserData]")]
    public class FoodMenuController : ControllerBase
    {
        private readonly IFoodMenuRepository _foodMenuRepository;
        
        private readonly ILogger<FoodMenuController> _logger;

        public FoodMenuController(ILogger<FoodMenuController> logger, IFoodMenuRepository foodMenuRepository)
        {
            _logger = logger;
            _foodMenuRepository = foodMenuRepository;
        }

        [HttpGet]
        [Route("/GetWeeklyData")]
        public IEnumerable<FoodMenu> GetData()
        {
            return _foodMenuRepository.GetWeeklyData();
        }
        [HttpPut]
        [Route("/AddOneData")]
        public FoodMenu PutOneData(FoodMenu data)
        {
            _foodMenuRepository.InsertData(data);
            return data;
        }

        [HttpPut]
        [Route("/AddData")]
        public string PutManyData (IEnumerable<FoodMenu> data)
        {
            _foodMenuRepository.InsertManyData(data);
            return "Multiple data added Successfully";
        }

        [HttpDelete]
        [Route("/DeleteData")]
        public string DeleteData (string name)
        {
            _foodMenuRepository.Delete(name);
            return "Data Deleted Successfully";
        }

        [HttpPut]
        [Route("/UpdateLike")]
        public IActionResult UpdateLike(FoodMenu data)
        {
            _foodMenuRepository.UpdateLike(data.Item);
            return Ok();
        }

        [HttpPut]
        [Route("/UpdateDisLike")]
        public IActionResult UpdateDisLike(FoodMenu data)
        {
            _foodMenuRepository.UpdateDisLike(data.Item);
            return Ok();
        }
    }
}

using DigitalServerItems.Models;

namespace DigitalServerItems.Repositories
{
    public class GeneralRepository: IGeneralRepository
    {
        private readonly ApiContext _apiContext;
        public ApiContext ApiContext => _apiContext;
        public GeneralRepository()
        {
            _apiContext = new();
            SeedData.Initialize(ApiContext);
        }
    }
}

using ProductAPI.Models;
using ProductAPI.Services.services;

namespace ProductAPI.Services.Repository
{
    public class PRoductRepository : IProductService
    {
        private readonly MyDBContext myDBContext;
        public PRoductRepository(MyDBContext myDB)
        {
            myDBContext = myDB;
        }

        public List<ProductTest> GetALLProducts()
        {
           return  myDBContext.ProductTest.ToList();
        }
    }
}

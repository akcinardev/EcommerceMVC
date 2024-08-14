using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
		private ApplicationDbContext _db;
        public ProductRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
			_db.SaveChanges();
		}

        public void Update(Product product)
        {
			_db.Products.Update(product);
		}
    }
}

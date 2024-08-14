using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
	public class CategoryRepo : Repository<Category>, ICategoryRepo
	{
		private ApplicationDbContext _db;
        public CategoryRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Category category)
		{
			_db.Categories.Update(category);
		}
	}
}
